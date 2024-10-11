using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Binxelview
{
    public partial class BinxelviewForm : Form
    {
        const int MAX_BPP = 32;
        const int PRESET_VERSION = 2;
        const int PALETTE_BITS = 14; // maximum bits to fill 128 x 128 square
        const int PALETTE_DIM = 128; // should match paletteBox size

        enum PaletteMode
        {
            PALETTE_CUSTOM = 0, // entries below are same order as comboBoxPalette.Items
            PALETTE_RGB,
            PALETTE_RANDOM,
            PALETTE_GREY,
            PALETTE_CUBEHELIX,
        };

        byte[] data = {};
        string data_path = "";
        string data_file = "";
        long pos_byte = 0;
        int pos_bit = 0;
        int next_increment_byte = 1;
        int next_increment_bit = 0;
        int selected_tile = -1;
        long selected_pos = -1;

        Preset preset;
        Preset default_preset;
        List<Preset> presets;

        Bitmap palette_bmp = new Bitmap(PALETTE_DIM, PALETTE_DIM);
        Bitmap pixel_bmp = null;
        Color[] palette = new Color[PALETTE_DIM * PALETTE_DIM];
        int[] palette_raw = new int[PALETTE_DIM * PALETTE_DIM]; // int version of palette
        string palette_error = "";
        int background_raw = SystemColors.Control.ToArgb(); // int version of background setting
        int[] twiddle_cache = null;
        int twiddle_cache_order = 0;
        int twiddle_cache_w = 0;
        int twiddle_cache_h = 0;
        bool disable_pixel_redraw = false; // used to temporarily block redraws during repeated updates
        Font posfont_regular, posfont_bold;
        Random random = new Random();

        // settings
        int zoom = 2;
        bool hidegrid = false;
        Color background = SystemColors.Control;
        PaletteMode palette_mode = PaletteMode.PALETTE_RGB;
        bool decimal_position = false;
        bool snap_scroll = true;
        bool horizontal_layout = false;
        int twiddle = 0;

        //
        // Preset
        //

        struct Preset
        {
            public string name;
            public bool little_endian;
            public bool chunky;
            public int bpp;
            public int width;
            public int height;
            public int pixel_stride_byte;
            public int pixel_stride_bit;
            public bool pixel_stride_auto;
            public int row_stride_byte;
            public int row_stride_bit;
            public bool row_stride_auto;
            public int next_stride_byte;
            public int next_stride_bit;
            public bool next_stride_auto;
            public int tile_size_x;
            public int tile_stride_byte_x;
            public int tile_stride_bit_x;
            public int tile_size_y;
            public int tile_stride_byte_y;
            public int tile_stride_bit_y;
            public int[] bit_stride_byte;
            public int[] bit_stride_bit;

            static public string last_error = "";

            public void empty()
            {
                name = "";
                little_endian = true;
                chunky = true;
                bpp = 8;
                width = 8;
                height = 1;
                pixel_stride_byte = 1;
                row_stride_byte = 8;
                next_stride_byte = 8;
                pixel_stride_bit = 0;
                row_stride_bit = 0;
                next_stride_bit = 0;
                tile_size_x = 0;
                tile_size_y = 0;
                tile_stride_byte_x = 0;
                tile_stride_byte_y = 0;
                tile_stride_bit_x = 0;
                tile_stride_bit_y = 0;
                pixel_stride_auto = true;
                row_stride_auto = true;
                next_stride_auto = true;
                bit_stride_byte = new int[MAX_BPP];
                bit_stride_bit = new int[MAX_BPP];
                for (int i = 0; i < MAX_BPP; ++i)
                {
                    bit_stride_byte[i] = 0;
                    bit_stride_bit[i] = i;
                }
            }

            public Preset copy()
            {
                Preset p = new Preset();
                p = this;
                p.bit_stride_byte = (int[])bit_stride_byte.Clone();
                p.bit_stride_bit = (int[])bit_stride_bit.Clone();
                return p;
            }

            public bool saveFile(string path)
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(string.Format("{0}", PRESET_VERSION));
                        sw.WriteLine(string.Format("{0} {1}", little_endian ? 1 : 0, chunky ? 1 : 0));
                        sw.WriteLine(string.Format("{0} {1} {2}", bpp, width, height));
                        sw.WriteLine(string.Format("{0} {1} {2}", pixel_stride_byte, row_stride_byte, next_stride_byte));
                        sw.WriteLine(string.Format("{0} {1} {2}", pixel_stride_bit, row_stride_bit, next_stride_bit));
                        sw.WriteLine(string.Format("{0} {1} {2}", pixel_stride_auto ? 1 : 0, row_stride_auto ? 1 : 0, next_stride_auto ? 1 : 0));
                        sw.WriteLine(string.Format("{0} {1} {2}", tile_size_x, tile_stride_byte_x, tile_stride_bit_x));
                        sw.WriteLine(string.Format("{0} {1} {2}", tile_size_y, tile_stride_byte_y, tile_stride_bit_y));
                        if (!chunky)
                        {
                            for (int i = 0; i < bpp; ++i)
                            {
                                sw.WriteLine(string.Format("{0} {1}", bit_stride_byte[i], bit_stride_bit[i]));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    last_error = ex.ToString();
                    return false;
                }

                return true;
            }

            public bool loadFile(string path)
            {
                empty();
                try
                {
                    // version
                    // endian chunky
                    // bpp width height
                    // (stride byte) pixel row next
                    // (stride bit) pixel row next
                    // (stride auto) pixel row next
                    // plane X size byte bit
                    // plane Y size byte bit
                    // (bpp * bit stride) byte bit

                    name = Path.GetFileNameWithoutExtension(path);

                    using (TextReader tr = File.OpenText(path))
                    {
                        string l = tr.ReadLine();
                        int v = int.Parse(l);
                        if (v > PRESET_VERSION) return false;
                        int version = v;

                        l = tr.ReadLine();
                        string[] ls = l.Split(' ');
                        little_endian = int.Parse(ls[0]) != 0;
                        chunky = int.Parse(ls[1]) != 0;

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        bpp = int.Parse(ls[0]);
                        width = int.Parse(ls[1]);
                        height = int.Parse(ls[2]);

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        pixel_stride_byte = int.Parse(ls[0]);
                        row_stride_byte = int.Parse(ls[1]);
                        next_stride_byte = int.Parse(ls[2]);

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        pixel_stride_bit = int.Parse(ls[0]);
                        row_stride_bit = int.Parse(ls[1]);
                        next_stride_bit = int.Parse(ls[2]);

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        pixel_stride_auto = int.Parse(ls[0]) != 0;
                        row_stride_auto = int.Parse(ls[1]) != 0;
                        next_stride_auto = int.Parse(ls[2]) != 0;

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        tile_size_x = int.Parse(ls[0]);
                        tile_stride_byte_x = int.Parse(ls[1]);
                        tile_stride_bit_x = int.Parse(ls[2]);

                        l = tr.ReadLine();
                        ls = l.Split(' ');
                        tile_size_y = int.Parse(ls[0]);
                        tile_stride_byte_y = int.Parse(ls[1]);
                        tile_stride_bit_y = int.Parse(ls[2]);

                        if (!chunky)
                        {
                            for (int i = 0; i < bpp; ++i)
                            {
                                l = tr.ReadLine();
                                ls = l.Split(' ');
                                bit_stride_byte[i] = int.Parse(ls[0]);
                                bit_stride_bit[i] = int.Parse(ls[1]);
                            }
                        }

                        if (version == 1)
                        {
                            // version 1 used tile stride as an additional "shift" on top of the pixel/row strides
                            // convert the shift to an absolute stride

                            int tile_stride_x = tile_stride_bit_x + (tile_stride_byte_x * 8);
                            int tile_stride_y = tile_stride_bit_y + (tile_stride_byte_y * 8);

                            int stride_x = pixel_stride_bit + (pixel_stride_byte * 8);
                            int stride_y = row_stride_bit + (row_stride_byte * 8);

                            if (tile_stride_x == 0)
                            {
                                tile_size_x = 0;
                            }
                            else
                            {
                                tile_stride_x += (stride_x * tile_size_x);
                                tile_stride_byte_x = tile_stride_x >> 3;
                                tile_stride_bit_x = tile_stride_x & 7;
                            }

                            if (tile_stride_y == 0)
                            {
                                tile_size_y = 0;
                            }
                            else
                            {
                                tile_stride_y += (stride_y * tile_size_y);
                                tile_stride_byte_y = tile_stride_y >> 3;
                                tile_stride_bit_y = tile_stride_y & 7;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    last_error = ex.ToString();
                    return false;
                }

                return true;
            }
        };

        //
        // Options
        //

        string parseOption(string optline)
        {
            int eqpos = optline.IndexOf("=");
            if (eqpos < 0) return "No = in option: "+optline;
            string opt = optline.Substring(0,eqpos).ToUpperInvariant();
            string val = optline.Substring(eqpos+1);
            string valu = val.ToUpperInvariant();

            if (opt == "PRESETFILE") // load preset file to replace default
            {
                Preset p = new Preset();
                if (!p.loadFile(val)) return "Could not load preset file: "+val+"\n"+Preset.last_error;
                default_preset = p;
                preset = default_preset.copy();
                return "";
            }
            if (opt == "PRESET") // select named preset from the library
            {
                foreach (Preset p in presets)
                {
                    if (val == p.name)
                    {
                        preset = p.copy();
                        return "";
                    }
                }
                return "Preset not found in loaded presets: "+val;
            }
            if (opt == "PAL") // load palette file
            {
                bool image =
                    valu.EndsWith(".BMP") ||
                    valu.EndsWith(".GIF") ||
                    valu.EndsWith(".PNG") ||
                    valu.EndsWith(".TIF");
                bool vga =
                    valu.EndsWith(".VGA");
                if (!openPalette(val,image,vga)) return "Could not load palette file: "+val+"\n"+palette_error;
                return "";
            }
            if (opt == "AUTOPAL")
            {
                if      (valu == "RGB"      ) { palette_mode = PaletteMode.PALETTE_RGB;       }
                else if (valu == "RANDOM"   ) { palette_mode = PaletteMode.PALETTE_RANDOM;    }
                else if (valu == "GREYSCALE") { palette_mode = PaletteMode.PALETTE_GREY;      }
                else if (valu == "CUBEHELIX") { palette_mode = PaletteMode.PALETTE_CUBEHELIX; }
                else return "Unknown autopal value: "+val;
                comboBoxPalette.SelectedIndex = (int)palette_mode - 1;
                return "";
            }
            if (opt == "BACKGROUND")
            {
                int v;
                if (!int.TryParse(val,System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out v))
                    return "Could not parse hex color for background: "+val;
                background_raw = (v & 0x00FFFFFF) | unchecked((int)0xFF000000);
                background = Color.FromArgb(background_raw);
                return "";
            }
            if (opt == "ZOOM")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for zoom: "+val;
                if (v < 1) return "Zoom must be 1 or greater: "+val;
                zoom = v;
                numericZoom.Value = v;
                return "";
            }
            if (opt == "GRID")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for grid: "+val;
                if (v != 0 && v != 1) return "Grid value must be 0 or 1: "+val;
                hidegrid = (v == 0);
                gridToolStripMenuItem.Checked = !hidegrid;
                return "";
            }
            if (opt == "HEXPOS")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for hexpos: "+val;
                if (v != 0 && v != 1) return "Hexpos value must be 0 or 1: "+val;
                decimal_position = (v == 0);
                decimalPositionToolStripMenuItem.Checked = decimal_position;
                hexadecimalPositionToolStripMenuItem.Checked = !decimal_position;
                numericPosByte.Font = decimal_position ? posfont_regular : posfont_bold;
                return "";
            }
            if (opt == "SNAPSCROLL")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for snapscroll: "+val;
                if (v != 0 && v != 1) return "Snapscroll value must be 0 or 1: "+val;
                snap_scroll = (v != 0);
                snapScrollToNextStrideToolStripMenuItem.Checked = snap_scroll;
                return "";
            }
            if (opt == "HORIZONTAL")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for horizontal: "+val;
                if (v != 0 && v != 1) return "Horizontal value must be 0 or 1: "+val;
                horizontal_layout = (v != 0);
                verticalLayoutToolStripMenuItem.Checked = !horizontal_layout;
                horizontalLayoutToolStripMenuItem.Checked = horizontal_layout;
                return "";
            }
            if (opt == "TWIDDLE")
            {
                int v;
                if (!int.TryParse(val,out v)) return "Could not parse integer for twiddle: "+val;
                if (v <  0 || v > 2) return "Twiddle value must be 0, 1 or 2: "+val;
                twiddle = v;
                twiddleZToolStripMenuItem.Checked = twiddle == 1;
                twiddleNToolStripMenuItem.Checked = twiddle == 2;
                return "";
            }
            return "Invalid option: "+optline;
        }

        //
        // Pixel building
        //

        int[] bit_stride = new int[MAX_BPP];
        long[] pixel_buffer = null;
        int[] color_buffer = null;
        int pixel_buffer_width;
        int pixel_buffer_height;

        int pixel_gx = 1;
        int pixel_gy = 1;
        int pixel_padx = 0;
        int pixel_pady = 0;
        int pixel_twp = 1;
        int pixel_thp = 1;

        void prepareBitStride()
        {
            if (preset.chunky)
            {
                for (int i = 0; i < preset.bpp; ++i)
                {
                    bit_stride[i] = i;
                }
            }
            else
            {
                for (int i = 0; i < preset.bpp; ++i)
                {
                    bit_stride[i] = preset.bit_stride_bit[i] + (preset.bit_stride_byte[i] * 8);
                }
            }
        }

        void twiddleCacheCheck(int tw, int th)
        {
            // rebuild index of twiddle ordering
            if (twiddle_cache == null ||
                twiddle_cache_order != twiddle ||
                twiddle_cache_w != tw ||
                twiddle_cache_h != th )
            {
                twiddle_cache_order = twiddle;
                twiddle_cache_w = tw;
                twiddle_cache_h = th;
                twiddle_cache = new int[tw * th];
                for (int y = 0; y < th; ++y)
                {
                    for (int x = 0; x < tw; ++x)
                    {
                        int twx = x;
                        int twy = y;
                        int bit = 0;
                        int twxy = 0;
                        if (twiddle == 2) // N instead of Z order
                        {
                            int temp = twx;
                            twx = twy;
                            twy = temp;
                        }
                        while (twx > 0 || twy > 0) // interleaved bits = Z order / morton
                        {
                            twxy |=
                                ((twx >> bit) & 1) << (bit * 2 + 0) |
                                ((twy >> bit) & 1) << (bit * 2 + 1);
                            twx &= ~(1 << bit);
                            twy &= ~(1 << bit);
                            bit += 1;
                        }
                        twiddle_cache[x + (y * tw)] = twxy;
                    }
                }
            }
        }

        unsafe long buildPixel(long pos, int bpp, bool little_endian, int length, byte* data_raw, int* bit_stride_raw)
        {
            uint p = 0;
            for (int b = 0; b < bpp; ++b)
            {
                long bpos = pos + bit_stride_raw[b];
                long dpos_byte = bpos >> 3;
                if (dpos_byte < 0 || dpos_byte >= length)
                {
                    return -1;
                }
                int dpos_bit = (int)(bpos & 7);
                if (!little_endian) dpos_bit = 7 - dpos_bit;
                p |= (uint)((data_raw[dpos_byte] >> dpos_bit) & 1) << b;
            }
            return (long)p;
        }

        long readPixel(long pos) // slow/safe version of buildPixel, for convenient single pixel queries
        {
            prepareBitStride();
            long p;
            unsafe
            {
                fixed (byte* data_raw = data)
                fixed (int* bit_stride_raw = bit_stride)
                {
                    p = buildPixel(pos, preset.bpp, preset.little_endian, data.Length, data_raw, bit_stride_raw);
                }
            }
            return p;
        }

        unsafe void renderTile(
            long pos, int bpp, bool little_endian,
            int length, int w, int h,
            int pixel_stride, int row_stride, int render_stride,
            int tile_size_x, int tile_size_y, int tile_shift_x, int tile_shift_y,
            byte* data, int* bit_stride, long* render_buffer, int* twiddle_raw)
        {
            long pos_row = pos;
            int plane_y = 0;
            for (int y=0; y<h; ++y)
            {
                int plane_x = 0;
                long pos_pixel = pos_row;
                long* render_row = render_buffer + (y * render_stride);
                for (int x=0; x<w; ++x)
                {
                    if (twiddle_raw != null)
                    {
                        int twxy = twiddle_raw[x + (y * w)];
                        int twy = twxy / w;
                        int twx = twxy % w;
                        pos_pixel = pos + (twy * row_stride) + (twx * pixel_stride);
                    }

                    render_row[x] = buildPixel(pos_pixel, bpp, little_endian, length, data, bit_stride);
                    pos_pixel += pixel_stride;
                    ++plane_x;
                    if (plane_x >= tile_size_x)
                    {
                        plane_x = 0;
                        pos_pixel += tile_shift_x;
                    }
                }
                pos_row += row_stride;
                ++plane_y;
                if (plane_y >= tile_size_y)
                {
                    plane_y = 0;
                    pos_row += tile_shift_y;
                }
            }
        }

        void renderGrid(long pos, int gx, int gy, int padx, int pady, int minx, int miny, bool color)
        {
            // prepares pixel_buffer
            int tw = preset.width;
            int th = preset.height;
            int twp = tw + padx;
            int thp = th + pady;
            int pixels_w = (gx * twp) + padx;
            int pixels_h = (gy * thp) + pady;
            if (pixels_w < minx) pixels_w = minx;
            if (pixels_h < miny) pixels_h = miny;
            int pixels_needed = pixels_w * pixels_h;
            if (pixel_buffer == null ||
                color_buffer == null ||
                pixel_buffer_width != pixels_w ||
                pixel_buffer_height != pixels_h)
            {
                pixel_buffer = new long[pixels_needed];
                color_buffer = new int[pixels_needed];
                pixel_buffer_width = pixels_w;
                pixel_buffer_height = pixels_h;
            }

            prepareBitStride();
            int pixel_stride = preset.pixel_stride_bit + (preset.pixel_stride_byte * 8);
            int row_stride = preset.row_stride_bit + (preset.row_stride_byte * 8);
            int next_stride = preset.next_stride_bit + (preset.next_stride_byte * 8);
            int tile_size_x = preset.tile_size_x;
            int tile_size_y = preset.tile_size_y;
            int tile_shift_x = preset.tile_stride_bit_x + (preset.tile_stride_byte_x * 8) - (tile_size_x * pixel_stride);
            int tile_shift_y = preset.tile_stride_bit_y + (preset.tile_stride_byte_y * 8) - (tile_size_y * row_stride);
            int bpp = preset.bpp;
            bool little_endian = preset.little_endian;
            if (tile_size_x == 0) tile_shift_x = 0;
            if (tile_size_y == 0) tile_shift_y = 0;
            // tile stride is converted to a relative shift that is applied at the end of each tile

            if (twiddle != 0)
            {
                twiddleCacheCheck(tw,th);
            }
            else
            {
                twiddle_cache = null;
            }

            int rgx = gx;
            int rgy = gy;
            if (horizontal_layout)
            {
                rgx = gy;
                rgy = gx;
            }

            int length = data.Length;

            unsafe
            {
                fixed (byte* data_raw = data)
                fixed (int* bit_stride_raw = bit_stride)
                fixed (int* color_buffer_raw = color_buffer)
                fixed (long* pixel_buffer_raw = pixel_buffer)
                fixed (int* twiddle_raw = twiddle_cache)
                {
                    for (int i=0; i < pixels_needed; ++i)
                    {
                        pixel_buffer_raw[i] = -1;
                    }

                    for (int tx = 0; tx < rgx; ++tx)
                    {
                        int sx = padx + (twp * tx);
                        for (int ty = 0; ty < rgy; ++ty)
                        {
                            int sy = pady + (thp * ty);
                            if (horizontal_layout)
                            {
                                sx = padx + (twp * ty);
                                sy = pady + (thp * tx);
                            }

                            renderTile(pos, bpp, little_endian, length, tw, th,
                                pixel_stride, row_stride, pixel_buffer_width,
                                tile_size_x, tile_size_y, tile_shift_x, tile_shift_y,
                                data_raw, bit_stride_raw,
                                pixel_buffer_raw + sx + (sy * pixel_buffer_width),
                                twiddle_raw);
                            pos += next_stride;
                        }
                    }

                    if (color)
                    {
                        for (int i = 0; i < pixels_needed; ++i)
                        {
                            color_buffer_raw[i] = getPaletteRaw(pixel_buffer_raw[i]);
                        }
                    }
                }
            }
        }

        void renderGridColorToBitmap(Bitmap b, int zoom)
        {
            int w = b.Width;
            int h = b.Height;

            BitmapData bdata = b.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                b.PixelFormat);

            unsafe
            {
                fixed (int* color_buffer_raw = color_buffer)
                {
                    int* braw = (int*)bdata.Scan0;
                    int stride = bdata.Stride / (Image.GetPixelFormatSize(b.PixelFormat) / 8);

                    int zy = 0;
                    int cy = 0;
                    for (int y=0; y<h; ++y)
                    {
                        int* out_row = braw + (y * stride);
                        if (zy <= 0)
                        {
                            int zx = 0;
                            int cx = 0;
                            int* color_row = color_buffer_raw + (pixel_buffer_width * cy);
                            ++cy;
                            for (int x = 0; x < w; ++x)
                            {
                                if (zx <= 0)
                                {
                                    out_row[x] = color_row[cx];
                                    ++cx;
                                    zx = zoom;
                                }
                                else
                                {
                                    out_row[x] = out_row[x - 1];
                                }
                                --zx;
                            }
                            zy = zoom;
                        }
                        else
                        {
                            for (int x=0; x<w; ++x)
                            {
                                out_row[x] = (out_row - stride)[x];
                            }
                        }
                        --zy;
                    }
                }
            }
            b.UnlockBits(bdata);
        }

        Bitmap renderGridIndexToBitmap()
        {
            int w = pixel_buffer_width;
            int h = pixel_buffer_height;
            Bitmap b = new Bitmap(w, h, PixelFormat.Format8bppIndexed);

            BitmapData bdata = b.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                b.PixelFormat);
            unsafe
            {
                byte* braw = (byte*)bdata.Scan0;
                int stride = bdata.Stride;

                fixed(long* pixel_buffer_raw = pixel_buffer)
                {
                    int i = 0;
                    for (int y=0; y<h; ++y)
                    {
                        byte* out_row = braw + (y * stride);
                        for (int x = 0; x < w; ++x)
                        {
                            long p = pixel_buffer_raw[i];
                            ++i;
                            if (p < 0) p = 255;
                            if (p > 255) p = 255;
                            out_row[x] = (byte)p;
                        }
                    }
                }
            }
            b.UnlockBits(bdata);

            ColorPalette bpal = b.Palette; // clone the palette
            Color[] pal = bpal.Entries;
            for (int i = 0; i < 255; ++i)
            {
                pal[i] = background;
            }
            int pcount = (preset.bpp > 8) ? 256 : (1 << preset.bpp);
            for (int i = 0; i < pcount; ++i)
            {
                pal[i] = getPalette(i);
            }
            b.Palette = bpal; // set the palette to the modified clone

            return b;
        }

        //
        // Palette
        //

        // internal range values for automatic palette generation
        int palette_rshift=0, palette_gshift=0, palette_bshift=0;
        int palette_rmask=1,  palette_gmask=1,  palette_bmask=1;
        long palette_greymask;

        void setPalette(int i, int r, int g, int b) // set a palette colour
        {
            palette[i] = Color.FromArgb(255, r, g, b);
            palette_raw[i] = palette[i].ToArgb();
        }

        void autoPaletteSetup() // setup range values for automatic palettes
        {
            // greyscale range
            palette_greymask = (1L << preset.bpp) - 1L;

            // RGB range
            int rb = preset.bpp / 3; // assign least bits to blue
            int rr = (preset.bpp - rb) / 2;
            int rg = preset.bpp - (rr + rb); // assign most bits to green
            palette_rshift = 0;
            palette_gshift = rr;
            palette_bshift = rr + rg;
            palette_rmask = (1 << rr) - 1;
            palette_gmask = (1 << rg) - 1;
            palette_bmask = (1 << rb) - 1;
            if (palette_rmask < 1) palette_rmask = 1;
            if (palette_gmask < 1) palette_gmask = 1;
            if (palette_bmask < 1) palette_bmask = 1;
        }

        unsafe int cubeHelix(long x)
        {
            // Dave Green's cubehelix as described and implemented here:
            // https://people.phy.cam.ac.uk/dag9/CUBEHELIX/
            // https://people.phy.cam.ac.uk/dag9/CUBEHELIX/cubetry.html
            double fract = (double)x / (double)palette_greymask;
            const double start = 0.5; // starting colour
            const double rotations = -2.0; // hue cycles across gradient, default was -1.5
            const double saturation = 1.8; // default was 1.0
            //const double gamma = 1.0; // gamma of 1.0 assumed 
            double angle = 2.0 * Math.PI * ((start / 3.0) + 1.0 + (rotations * fract));
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            //fract = Math.Pow(fract, gamma); // gamma of 1.0 assumed
            double amp = 255.0 * saturation * fract * ((1.0 - fract) / 2.0);
            fract *= 255.0;
            double rf = fract + amp * (-0.14861 * cos +1.78277 * sin);
            double gf = fract + amp * (-0.29227 * cos -0.90649 * sin);
            double bf = fract + amp * (+1.97294 * cos +0.00000 * sin);
            rf = (rf >= 0.0) ? rf : 0.0;
            gf = (gf >= 0.0) ? gf : 0.0;
            bf = (bf >= 0.0) ? bf : 0.0;
            int r = (rf < 255.0) ? (int)rf : 255;
            int g = (gf < 255.0) ? (int)gf : 255;
            int b = (bf < 255.0) ? (int)bf : 255;
            return b | (g << 8) | (r << 16) | unchecked((int)0xFF000000);
        }

        unsafe int autoPaletteRaw(long x) // generated palettes
        {
            switch (palette_mode)
            {
                default:
                case PaletteMode.PALETTE_RGB:
                    int ix = (int)x;
                    int r = (((ix >> palette_rshift) & palette_rmask) * 255) / palette_rmask;
                    int g = (((ix >> palette_gshift) & palette_gmask) * 255) / palette_gmask;
                    int b = (((ix >> palette_bshift) & palette_bmask) * 255) / palette_bmask;
                    return b | (g << 8) | (r << 16) | unchecked((int)0xFF000000);
                case PaletteMode.PALETTE_GREY:
                    long lx = (x >= 0) ? x : (x + (1L << 32));
                    int grey = (int)((lx * 255L) / palette_greymask);
                    return grey | (grey << 8) | (grey << 16) | unchecked((int)0xFF000000);
                case PaletteMode.PALETTE_CUBEHELIX:
                    return cubeHelix(x);
            }
        }

        unsafe int getPaletteRaw(long x)
        {
            if (x < 0) return background_raw;
            if (preset.bpp <= PALETTE_BITS) return palette_raw[x];
            return autoPaletteRaw(x);
        }

        Color getPalette(long x)
        {
            if (preset.bpp <= PALETTE_BITS) return palette[x];
            int p = autoPaletteRaw(x);
            return Color.FromArgb(p);
        }

        void randomPalette()
        {
            // randomizes the entire palette, not just the current used area,
            // and does not switch to custom palette mode.
            for (int i = 0; i < (PALETTE_DIM * PALETTE_DIM); ++i)
            {
                setPalette(i,
                    random.Next() & 255,
                    random.Next() & 255,
                    random.Next() & 255);
            }
        }

        void autoPalette() // regenerate automatic palettes
        {
            autoPaletteSetup();
            if (palette_mode == PaletteMode.PALETTE_CUSTOM) return;
            if (palette_mode == PaletteMode.PALETTE_RANDOM) { randomPalette(); return; }
            if (preset.bpp > PALETTE_BITS) return;
            for (int i=0; i < (1 << preset.bpp); ++i)
            {
                int p = autoPaletteRaw(i);
                int b = (p >>  0) & 0xFF;
                int g = (p >>  8) & 0xFF;
                int r = (p >> 16) & 0xFF;
                setPalette(i,r,g,b);
            }
        }

        void refreshPalette()
        {
            autoPaletteSetup();
            // disable these if BPP is too high to use an actual palette
            bool palenable = preset.bpp <= PALETTE_BITS;
            buttonLoadPal.Enabled = palenable;
            buttonSavePal.Enabled = palenable;
            pixelsToPaletteToolStripMenuItem.Enabled = palenable;
            redrawPalette();
        }

        //
        // Position and Scroll
        //

        void scrollRange()
        {
            if (pixelScroll.Value > data.Length) pixelScroll.Value = data.Length;
            pixelScroll.Maximum = data.Length;

            next_increment_byte = preset.next_stride_byte * ((preset.height == 1) ? 16 : 1);
            next_increment_bit = preset.next_stride_bit * ((preset.height == 1) ? 16 : 1);
            int nb = next_increment_bit / 8;
            next_increment_byte += nb;
            next_increment_bit -= nb * 8;

            pixelScroll.LargeChange = (next_increment_byte >= 0) ? next_increment_byte : -next_increment_byte;

            pixelScroll.SmallChange = 1;
            if (snap_scroll)
            {
                pixelScroll.SmallChange = pixelScroll.LargeChange;
            }
        }

        void updatePos(bool update_scroll = true)
        {
            numericPosByte.Hexadecimal = (pos_byte >= 0) && !decimal_position;
            numericPosByte.Value = pos_byte;
            numericPosBit.Value = pos_bit;
            if (update_scroll)
            {
                pixelScroll.Value =
                    ((int)pos_byte < pixelScroll.Minimum) ? pixelScroll.Minimum :
                    ((int)pos_byte > pixelScroll.Maximum) ? pixelScroll.Maximum :
                    (int)pos_byte;
            }
        }

        void normalizePos()
        {
            int nb = pos_bit / 8;
            pos_byte += nb;
            pos_bit -= nb * 8;
            updatePos();
        }

        //
        // Files
        //

        bool openFile(string path)
        {
            byte[] read_data;
            try
            {
                read_data = File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open file:\n" + path + "\n\n" + ex.ToString(), "Binxelview");
                return false;
            }
            data = read_data;
            if (pos_byte >= data.Length)
            {
                pos_byte = 0;
            }
            pos_bit = 0;
            updatePos();
            scrollRange();
            data_path = path;
            data_file = Path.GetFileName(path);
            this.Text = "Binxelview (" + data_file + ")";
            redrawPixels();
            return true;
        }

        void reloadPresets()
        {
            // remove everything but Reload and separator
            while (presetToolStripMenuItem.DropDownItems.Count > 2)
            {
                presetToolStripMenuItem.DropDownItems.RemoveAt(2);
            }

            presets = new List<Preset>();
            DirectoryInfo d_cwd = new DirectoryInfo(".");
            DirectoryInfo d_app = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            FileInfo[] files_cwd = d_cwd.GetFiles("*.bxp");
            FileInfo[] files_app = d_app.GetFiles("*.bxp");
            FileInfo[] files = new FileInfo[files_cwd.Length+files_app.Length];
            Array.Copy(files_cwd,0,files,0,files_cwd.Length);
            Array.Copy(files_app,0,files,files_cwd.Length,files_app.Length);
            foreach (FileInfo file in files)
            {
                Preset p = new Preset();
                if (p.loadFile(file.FullName))
                {
                    bool duplicate = false;
                    foreach (Preset pe in presets)
                    {
                        if (pe.name == p.name)
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (!duplicate)
                    {
                        presets.Add(p);
                        if (p.name.ToLower()=="default")
                        {
                            default_preset = p.copy();
                            scrollRange();
                        }
                    }
                }
            }
            presets.Sort((x, y) => x.name.CompareTo(y.name));

            for (int i = 0; i < presets.Count; ++i)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = presets[i].name;
                item.Text = presets[i].name;
                item.Tag = i;
                item.Click += presetMenu_Select;
                presetToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        bool openPalette(string path, bool image, bool sixbit_vga)
        {
            palette_mode = PaletteMode.PALETTE_CUSTOM;

            if (image)
            {
                Image img;
                try
                {
                    img = Image.FromFile(path);
                }
                catch (Exception ex)
                {
                    palette_error = ex.ToString();
                    return false;
                }

                Color[] cols = img.Palette.Entries;
                if (cols.Length < 1)
                {
                    palette_error = "Image does not contain a palette.";
                    return false;
                }
                for (int i=0; (i<(PALETTE_DIM*PALETTE_DIM)) && (i<cols.Length); ++i)
                {
                    Color c = cols[i];
                    setPalette(i, c.R, c.G, c.B);
                }
                return true;
            }

            byte[] read_data;
            try
            {
                read_data = File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                palette_error = ex.ToString();
                return false;
            }

            for (int i=0; (i<(PALETTE_DIM*PALETTE_DIM)) && (((i*3)+2)<read_data.Length); ++i)
            {
                int r = read_data[(i * 3) + 0];
                int g = read_data[(i * 3) + 1];
                int b = read_data[(i * 3) + 2];
                if (sixbit_vga)
                {
                    // Convert 18-bit VGA palette to 24-bit
                    r = r * 255 / 63;
                    g = g * 255 / 63;
                    b = b * 255 / 63;
                    // Clamp, in case the data isn't entirely valid
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                }
                setPalette(i, r, g, b);
            }
            return true;
        }

        bool savePalette(string path)
        {
            if (preset.bpp > PALETTE_BITS)
            {
                palette_error = String.Format("Custom palettes are limited to {0} BPP.", PALETTE_BITS);
                return false;
            }

            byte[] write_data = new byte[(1 << preset.bpp) * 3];
            for (int i=0; i<(1<<preset.bpp); ++i)
            {
                write_data[(i * 3) + 0] = palette[i].R;
                write_data[(i * 3) + 1] = palette[i].G;
                write_data[(i * 3) + 2] = palette[i].B;
            }

            try
            {
                File.WriteAllBytes(path, write_data);
            }
            catch (Exception ex)
            {
                palette_error = ex.ToString();
                return false;
            }

            return true;
        }

        //
        // Redraws
        //

        void redrawPixels()
        {
            if (disable_pixel_redraw) return;

            int w = pixelBox.Width - 2;
            int h = pixelBox.Height - 2;
            if (w < 1 || h < 1) return;

            if (pixel_bmp == null ||
                pixel_bmp.Width != w ||
                pixel_bmp.Height != h)
            {
                pixel_bmp = new Bitmap(w,h,PixelFormat.Format32bppArgb);
            }

            int sx = (w + zoom - 1) / zoom;
            int sy = (h + zoom - 1) / zoom;

            int padx = (preset.width == 1 || hidegrid) ? 0 : 1;
            int pady = (preset.height == 1 || hidegrid) ? 0 : 1;
            int twp = padx + preset.width;
            int thp = pady + preset.height;

            int gx = (sx + twp - 1) / twp; // round up horizontally (allow data to extend past right side)
            int gy = sy / thp; // round down vertically (confine grid to vertical space)
            if (horizontal_layout)
            {
                gx = sx / twp;
                gy = (sy + thp - 1) / thp;
            }
            if (gx < 1) gx = 1;
            if (gy < 1) gy = 1;

            // record tile grid settings
            pixel_gx = gx;
            pixel_gy = gy;
            pixel_padx = padx;
            pixel_pady = pady;
            pixel_twp = twp;
            pixel_thp = thp;

            renderGrid((pos_byte * 8) + pos_bit, gx, gy, padx, pady, sx, sy, true);
            renderGridColorToBitmap(pixel_bmp, zoom);
            pixelBox.Image = pixel_bmp;
        }

        void redrawPreset()
        {
            if (preset.pixel_stride_auto)
            {
                preset.pixel_stride_byte = preset.bpp >> 3;
                preset.pixel_stride_bit = (preset.bpp & 7);
            }
            if (preset.row_stride_auto)
            {
                int bits = (preset.pixel_stride_bit + (preset.pixel_stride_byte*8)) * preset.width;
                preset.row_stride_byte = bits >> 3;
                preset.row_stride_bit = bits & 7;
            }
            if (preset.next_stride_auto)
            {
                int bits = (preset.row_stride_bit + (preset.row_stride_byte*8)) * preset.height;
                preset.next_stride_byte = bits >> 3;
                preset.next_stride_bit = bits & 7;
            }

            disable_pixel_redraw = true; // prevent Value events from redrawing pixels

            checkEndian.Checked = !preset.little_endian;
            checkChunky.Checked = preset.chunky;
            checkAutoPixel.Checked = preset.pixel_stride_auto;
            checkAutoRow.Checked = preset.row_stride_auto;
            checkAutoNext.Checked = preset.next_stride_auto;
            numericBPP.Value = preset.bpp;
            numericWidth.Value = preset.width;
            numericHeight.Value = preset.height;
            numericPixelStrideByte.Value = preset.pixel_stride_byte;
            numericRowStrideByte.Value = preset.row_stride_byte;
            numericNextStrideByte.Value = preset.next_stride_byte;
            numericPixelStrideBit.Value = preset.pixel_stride_bit;
            numericRowStrideBit.Value = preset.row_stride_bit;
            numericNextStrideBit.Value = preset.next_stride_bit;
            numericPixelStrideByte.Enabled = !preset.pixel_stride_auto;
            numericRowStrideByte.Enabled = !preset.row_stride_auto;
            numericNextStrideByte.Enabled = !preset.next_stride_auto;
            numericPixelStrideBit.Enabled = !preset.pixel_stride_auto;
            numericRowStrideBit.Enabled = !preset.row_stride_auto;
            numericNextStrideBit.Enabled = !preset.next_stride_auto;
            numericTileSizeX.Value = preset.tile_size_x;
            numericTileSizeY.Value = preset.tile_size_y;
            numericTileStrideByteX.Value = preset.tile_stride_byte_x;
            numericTileStrideByteY.Value = preset.tile_stride_byte_y;
            numericTileStrideBitX.Value = preset.tile_stride_bit_x;
            numericTileStrideBitY.Value = preset.tile_stride_bit_y;

            int old_scroll = dataGridPixel.FirstDisplayedScrollingRowIndex;
            dataGridPixel.Rows.Clear();
            for (int i = 0; i < preset.bpp; ++i)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dataGridPixel);
                r.Cells[0].Value = i;
                r.Cells[1].Value = preset.bit_stride_byte[i];
                r.Cells[2].Value = preset.bit_stride_bit[i];
                r.Cells[0].Style.BackColor = SystemColors.ControlLight;
                r.Cells[1].Style.BackColor = r.Cells[2].Style.BackColor =
                    preset.chunky ? SystemColors.ControlLight : SystemColors.Window;
                r.Cells[2].Style.ForeColor = SystemColors.MenuHighlight;
                dataGridPixel.Rows.Add(r);
            }
            if (old_scroll < 0) old_scroll = 0;
            //if (old_scroll >= dataGridPixel.Rows.Count) old_scroll = 0;
            dataGridPixel.FirstDisplayedScrollingRowIndex = old_scroll;
            dataGridPixel.Enabled = !preset.chunky;

            disable_pixel_redraw = false;
        }

        void redrawPalette()
        {
            int bx = preset.bpp / 2;
            int by = preset.bpp - bx;
            for (int y = 0; y < PALETTE_DIM; ++y)
            {
                for (int x = 0; x < PALETTE_DIM; ++x)
                {
                    long px = ((long)x * (1 << bx)) / PALETTE_DIM;
                    long py = ((long)y * (1 << by)) / PALETTE_DIM;
                    Color c = getPalette(px + (py * (1 << bx)));
                    palette_bmp.SetPixel(x, y, c);
                }
            }
            paletteBox.Image = palette_bmp;
            paletteBox.Refresh();
        }

        //
        // Forms designer linked code
        //

        public BinxelviewForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Load Binary File";
            if (d.ShowDialog() == DialogResult.OK)
            {
                openFile(d.FileName);
            }
        }

        private void reloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data_path.Length > 0)
            {
                openFile(data_path);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BinxelviewForm_Load(object sender, EventArgs e)
        {
            posfont_regular = new Font(numericPosByte.Font, FontStyle.Regular);
            posfont_bold = new Font(numericPosByte.Font, FontStyle.Bold);

            // initialize Auto palette selection
            comboBoxPalette.SelectedIndex = (int)PaletteMode.PALETTE_RGB - 1;

            // setup presets
            default_preset.empty();
            reloadPresets(); // loads "Default" preset if it exists
            preset = default_preset.copy();

            // open file from the command line
            string[] args = Environment.GetCommandLineArgs();
            string arg_err = "";
            for (int i=1; i<args.Length; ++i)
            {
                string arg = args[i];
                if (!arg.StartsWith("-")) // anything that doesn't start with - is the file to open
                {
                    openFile(arg);
                }
                else // anything that starts with - or -- is an option
                {
                    string sarg = arg.Substring(1);
                    if (sarg.StartsWith("-")) sarg = sarg.Substring(1);
                    string opt_err = parseOption(sarg);
                    if (opt_err.Length > 0 && arg_err.Length > 0) arg_err += "\n";
                    arg_err += opt_err;
                }
            }
            if (arg_err.Length > 0)
            {
                MessageBox.Show("Command line error:\n" + arg_err,"Binxelview");
            }

            scrollRange();
            redrawPreset();
            autoPalette();
            refreshPalette();
            bgBox.BackColor = background;
            redrawPixels();
            numericPosByte.Font = decimal_position ? posfont_regular : posfont_bold;
        }

        private void BinxelviewForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files) openFile(file);
        }

        private void BinxelviewForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop)) ?
                DragDropEffects.Copy : DragDropEffects.None;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string about =
                "Binxelview binary image explorer\n" +
                System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() + "\n" +
                "\n" +
                "https://github.com/bbbradsmith/binxelview";
            MessageBox.Show(about, "Binxelview");
        }

        void presetMenu_Select(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = (int)item.Tag;
            int old_bpp = preset.bpp;
            preset = presets[index].copy();
            scrollRange();
            redrawPreset();
            if (old_bpp != preset.bpp && palette_mode != PaletteMode.PALETTE_RANDOM) autoPalette();
            refreshPalette();
        }

        private void reloadPresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadPresets();
        }

        private void buttonDefaultPreset_Click(object sender, EventArgs e)
        {
            int old_bpp = preset.bpp;
            preset = default_preset.copy();
            scrollRange();
            if (old_bpp != preset.bpp && palette_mode != PaletteMode.PALETTE_RANDOM) autoPalette();
            refreshPalette();
            redrawPreset();
        }

        private void buttonLoadPreset_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Load Preset";
            d.DefaultExt = "bxp";
            d.Filter = "Binxelview Preset (*.bxp)|*.bxp|All files (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                Preset p = new Preset();
                if (p.loadFile(d.FileName))
                {
                    int old_bpp = preset.bpp;
                    preset = p;
                    scrollRange();
                    if (old_bpp != preset.bpp && palette_mode != PaletteMode.PALETTE_RANDOM) autoPalette();
                    refreshPalette();
                    redrawPreset();
                }
                else
                {
                    MessageBox.Show("Unable to load preset:\n" + d.FileName + "\n\n" + Preset.last_error, "Binxelview");
                }
            }
        }

        private void buttonSavePreset_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Title = "Save Preset";
            d.DefaultExt = "bxp";
            d.Filter = "Binxelview Preset (*.bxp)|*.bxp|All files (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (!preset.saveFile(d.FileName))
                {
                    MessageBox.Show("Unable to save preset:\n" + d.FileName + "\n\n" + Preset.last_error, "Binxelview");
                }
                else
                {
                    reloadPresets();
                }
            }
        }

        private void checkEndian_CheckedChanged(object sender, EventArgs e)
        {
            preset.little_endian = !checkEndian.Checked;
            redrawPixels();
        }

        private void checkChunky_CheckedChanged(object sender, EventArgs e)
        {
            preset.chunky = checkChunky.Checked;
            redrawPreset();
            redrawPixels();
        }

        private void numericBPP_ValueChanged(object sender, EventArgs e)
        {
            int old_bpp = preset.bpp;
            preset.bpp = (int)numericBPP.Value;
            if (old_bpp != preset.bpp && palette_mode != PaletteMode.PALETTE_RANDOM) autoPalette();
            refreshPalette();
            redrawPreset();
            redrawPixels();
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            preset.width = (int)numericWidth.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericHeight_ValueChanged(object sender, EventArgs e)
        {
            preset.height = (int)numericHeight.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericPixelStrideByte_ValueChanged(object sender, EventArgs e)
        {
            preset.pixel_stride_byte = (int)numericPixelStrideByte.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericRowStrideByte_ValueChanged(object sender, EventArgs e)
        {
            preset.row_stride_byte = (int)numericRowStrideByte.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericNextStrideByte_ValueChanged(object sender, EventArgs e)
        {
            preset.next_stride_byte = (int)numericNextStrideByte.Value;
            scrollRange();
            redrawPreset();
            redrawPixels();
        }

        private void numericPixelStrideBit_ValueChanged(object sender, EventArgs e)
        {
            preset.pixel_stride_bit = (int)numericPixelStrideBit.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericRowStrideBit_ValueChanged(object sender, EventArgs e)
        {
            preset.row_stride_bit = (int)numericRowStrideBit.Value;
            redrawPreset();
            redrawPixels();
        }

        private void numericNextStrideBit_ValueChanged(object sender, EventArgs e)
        {
            preset.next_stride_bit = (int)numericNextStrideBit.Value;
            redrawPreset();
            redrawPixels();
        }

        private void checkAutoPixel_CheckedChanged(object sender, EventArgs e)
        {
            preset.pixel_stride_auto = checkAutoPixel.Checked;
            redrawPreset();
            redrawPixels();
        }

        private void checkAutoRow_CheckedChanged(object sender, EventArgs e)
        {
            preset.row_stride_auto = checkAutoRow.Checked;
            redrawPreset();
            redrawPixels();
        }

        private void checkAutoNext_CheckedChanged(object sender, EventArgs e)
        {
            preset.next_stride_auto = checkAutoNext.Checked;
            redrawPreset();
            redrawPixels();
        }

        private void numericTileSizeX_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_size_x = (int)numericTileSizeX.Value;
            redrawPixels();
        }

        private void numericTileSizeY_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_size_y = (int)numericTileSizeY.Value;
            redrawPixels();
        }

        private void numericTileStrideByteX_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_stride_byte_x = (int)numericTileStrideByteX.Value;
            redrawPixels();
        }

        private void numericTileStrideByteY_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_stride_byte_y = (int)numericTileStrideByteY.Value;
            redrawPixels();
        }

        private void numericTileStrideBitX_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_stride_bit_x = (int)numericTileStrideBitX.Value;
            redrawPixels();
        }

        private void numericTileStrideBitY_ValueChanged(object sender, EventArgs e)
        {
            preset.tile_stride_bit_y = (int)numericTileStrideBitY.Value;
            redrawPixels();
        }

        private void buttonAutoPal_Click(object sender, EventArgs e)
        {
            palette_mode = (PaletteMode)(comboBoxPalette.SelectedIndex + 1);
            autoPalette();
            refreshPalette();
            redrawPixels();
        }

        private void comboBoxPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            // generate new palette if we were previously using an automatic palette
            if (palette_mode != PaletteMode.PALETTE_CUSTOM)
            {
                buttonAutoPal_Click(sender, e);
            }
        }

        private void paletteBox_MouseMove(object sender, MouseEventArgs e)
        {
            int bx = preset.bpp / 2;
            int by = preset.bpp - bx;
            long px = ((long)e.X * (1 << bx)) / PALETTE_DIM;
            long py = ((long)e.Y * (1 << by)) / PALETTE_DIM;
            long index = px + (py * (1 << bx));
            Color c = getPalette(index);
            int ch = (c.R << 16) | (c.G << 8) | c.B;
            labelInfoPal.Text = String.Format("{0:D} = {1:D},{2:D},{3:D}\n{4:X2} = {5:X6}",(uint)index,c.R,c.G,c.B,(uint)index,ch);
        }

        private void paletteBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (preset.bpp > PALETTE_BITS) return;

            int bx = preset.bpp / 2;
            int by = preset.bpp - bx;
            long px = ((long)e.X * (1 << bx)) / PALETTE_DIM;
            long py = ((long)e.Y * (1 << by)) / PALETTE_DIM;
            long index = px + (py * (1 << bx));
            Color c = getPalette(index);

            ColorDialog d = new ColorDialog();
            d.Color = c;
            //d.Title = String.Format("Edit palette {0:D} ({0:X})", index, index);
            d.AllowFullOpen = true;
            if (d.ShowDialog() == DialogResult.OK)
            {
                palette_mode = PaletteMode.PALETTE_CUSTOM;
                setPalette((int)index, d.Color.R, d.Color.G, d.Color.B);
                redrawPixels();
            }
            refreshPalette();
        }

        private void bgBox_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.Color = background;
            d.AllowFullOpen = true;
            if (d.ShowDialog() == DialogResult.OK)
            {
                background = d.Color;
                background_raw = background.ToArgb();
                redrawPixels();
                bgBox.BackColor = background;
            }
        }

        private void buttonLoadPal_Click(object sender, EventArgs e)
        {
            if (preset.bpp > PALETTE_BITS) return;

            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Load Palette";
            d.DefaultExt = "pal";
            d.Filter =
                "Palette, RGB24 (*.pal)|*.pal|" +
                "Image (*.bmp;*.gif;*.png;*.tif)|*.bmp;*.gif;*.png;*.tif|" +
                "VGA Palette, 6-bit RGB18 (*.*)|*.*|"+
                "All files, RGB24 (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (openPalette(d.FileName,d.FilterIndex==2,d.FilterIndex==3))
                {
                    refreshPalette();
                    redrawPixels();
                }
                else
                {
                    MessageBox.Show("Unable to load palette:\n" + d.FileName + "\n\n" + palette_error, "Binxelview");
                }
            }
        }

        private void buttonSavePal_Click(object sender, EventArgs e)
        {
            if (preset.bpp > PALETTE_BITS) return;

            SaveFileDialog d = new SaveFileDialog();
            d.Title = "Save Palette";
            d.DefaultExt = "pal";
            d.Filter = "RGB Palette (*.pal)|*.pal|All files (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (!savePalette(d.FileName))
                {
                    MessageBox.Show("Unable to save palette:\n" + d.FileName + "\n\n" + palette_error, "Binxelview");
                }
            }
        }

        private void numericPosByte_ValueChanged(object sender, EventArgs e)
        {
            pos_byte = (long)numericPosByte.Value;
            updatePos();
            redrawPixels();
        }

        private void numericPosBit_ValueChanged(object sender, EventArgs e)
        {
            pos_bit = (int)numericPosBit.Value;
            redrawPixels();
        }

        private void numericZoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = (int)numericZoom.Value;
            redrawPixels();
        }

        private void decimalPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimalPositionToolStripMenuItem.Checked = true;
            hexadecimalPositionToolStripMenuItem.Checked = false;
            decimal_position = true;
            numericPosByte.Font = posfont_regular;
            updatePos();
        }

        private void hexadecimalPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimalPositionToolStripMenuItem.Checked = false;
            hexadecimalPositionToolStripMenuItem.Checked = true;
            decimal_position = false;
            numericPosByte.Font = posfont_bold;
            updatePos();
        }

        private void saveImageContextItem_Click(object sender, EventArgs e)
        {
            if (preset.width == 1 || preset.height == 1)
            {
                // if height is 1, we need to save everything seen anyway
                saveAllVisibleContextItem_Click(sender, e);
                return;
            }

            if (selected_tile < 0) // shouldn't happen, but giving an error just in case
            {
                MessageBox.Show("No image selected?", "Binxelview");
                return;
            }

            long pos = (pos_byte * 8) + pos_bit;
            pos += selected_tile * ((preset.next_stride_byte * 8) + preset.next_stride_bit);

            SaveFileDialog d = new SaveFileDialog();
            d.Title = "Save Image";
            d.DefaultExt = "png";
            d.Filter = "PNG Image (*.png)|*.png|All files (*.*)|*.*";
            d.FileName = data_file + string.Format(".{0:X8}.{1:D1}.png", pos >> 3, pos & 7);
            if (d.ShowDialog() == DialogResult.OK)
            {
                int w = preset.width;
                int h = preset.height;
                renderGrid(pos, 1, 1, 0, 0, w, h, true);

                Bitmap b;
                if (preset.bpp <= 8)
                {
                    b = renderGridIndexToBitmap();
                }
                else
                {
                    b = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                    renderGridColorToBitmap(b, 1);
                }

                try
                {
                    b.Save(d.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save image:\n" + d.FileName + "\n\n" + ex.ToString(), "Binxelview");
                }

                redrawPixels();
            }
        }

        private void saveAllVisibleContextItem_Click(object sender, EventArgs e)
        {
            saveAllVisibleToolStripMenuItem_Click(sender, e);
        }

        private void saveAllVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long pos = (pos_byte * 8) + pos_bit;

            SaveFileDialog d = new SaveFileDialog();
            d.Title = "Save All Visible";
            d.DefaultExt = "png";
            d.Filter = "PNG Image (*.png)|*.png|All files (*.*)|*.*";
            d.FileName = data_file + string.Format(".{0:X8}.{1:D1}.png",pos>>3,pos&7);
            if (d.ShowDialog() == DialogResult.OK)
            {
                int w = pixel_gx * pixel_twp + pixel_padx;
                int h = pixel_gy * pixel_thp + pixel_pady;
                renderGrid(pos, pixel_gx, pixel_gy, pixel_padx, pixel_pady, w, h, true);

                Bitmap b;
                if (preset.bpp <= 8)
                {
                    b = renderGridIndexToBitmap();
                }
                else
                {
                    b = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                    renderGridColorToBitmap(b, 1);
                }

                try
                {
                    b.Save(d.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save image:\n" + d.FileName + "\n\n" + ex.ToString(), "Binxelview");
                }

                redrawPixels();
            }
        }

        private void positionToPixelToolContextItem_Click(object sender, EventArgs e)
        {
            if (selected_pos >= 0 && selected_pos < (data.Length * (long)8))
            {
                pos_byte = selected_pos >> 3;
                pos_bit = (int)(selected_pos & 7);
                updatePos(true);
            }
        }

        private void pixelsToPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long read_pos = selected_pos;
            if (read_pos < 0) return;
            // extract new palette
            Color[] new_pal = new Color[PALETTE_DIM*PALETTE_DIM];
            int count = 0;
            for (int i=0; i<(PALETTE_DIM*PALETTE_DIM); ++i)
            {
                long p = readPixel(read_pos);
                if (p < 0) break;
                Color c = getPalette(p); // can't modify the new palette because we read it here
                new_pal[i] = c;
                ++count;
                read_pos += preset.pixel_stride_bit;
                read_pos += preset.pixel_stride_byte * 8;
            }
            // replace old palette
            for (int i=0; i<count; ++i)
            {
                palette_mode = PaletteMode.PALETTE_CUSTOM;
                Color c = new_pal[i];
                setPalette(i,c.R,c.G,c.B);
            }
            refreshPalette();
            redrawPixels();
        }

        private void pixelBox_Resize(object sender, EventArgs e)
        {
            redrawPixels();
        }

        private void buttonZoom_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) != 0)
            {
                --zoom;
            }
            else
            {
                ++zoom;
            }
            if (zoom < numericZoom.Minimum) zoom = (int)numericZoom.Minimum;
            if (zoom > numericZoom.Maximum) zoom = (int)numericZoom.Maximum;
            numericZoom.Value = zoom;
            redrawPixels();
        }

        private void buttonZoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            --zoom;
            if (zoom < numericZoom.Minimum) zoom = (int)numericZoom.Minimum;
            numericZoom.Value = zoom;
            redrawPixels();
        }

        private void common_AdvanceClick(int inc_byte, int inc_bit)
        {
            if ((Control.ModifierKeys & Keys.Shift) != 0)
            {
                pos_byte -= inc_byte;
                pos_bit -= inc_bit;
            }
            else
            {
                pos_byte += inc_byte;
                pos_bit += inc_bit;
            }
            normalizePos();
        }

        private void common_AdvanceMouseDown(MouseEventArgs e, int inc_byte, int inc_bit)
        {
            if (e.Button != MouseButtons.Right) return;
            pos_byte -= inc_byte;
            pos_bit -= inc_bit;
            normalizePos();
        }

        private void buttonBytePos_Click(object sender, EventArgs e)
        {
            common_AdvanceClick(1, 0);
        }

        private void buttonBitPos_Click(object sender, EventArgs e)
        {
            common_AdvanceClick(0, 1);
        }

        private void buttonPixel_Click(object sender, EventArgs e)
        {
            common_AdvanceClick(preset.pixel_stride_byte, preset.pixel_stride_bit);
        }

        private void buttonRow_Click(object sender, EventArgs e)
        {
            common_AdvanceClick(preset.row_stride_byte, preset.row_stride_bit);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            common_AdvanceClick(next_increment_byte, next_increment_bit);
        }

        private void buttonBytePos_MouseDown(object sender, MouseEventArgs e)
        {
            common_AdvanceMouseDown(e, 1, 0);
        }

        private void buttonBitPos_MouseDown(object sender, MouseEventArgs e)
        {
            common_AdvanceMouseDown(e, 0, 1);
        }

        private void buttonPixel_MouseDown(object sender, MouseEventArgs e)
        {
            common_AdvanceMouseDown(e, preset.pixel_stride_byte, preset.pixel_stride_bit);
        }

        private void buttonRow_MouseDown(object sender, MouseEventArgs e)
        {
            common_AdvanceMouseDown(e, preset.row_stride_byte, preset.row_stride_bit);
        }

        private void buttonNext_MouseDown(object sender, MouseEventArgs e)
        {
            common_AdvanceMouseDown(e, next_increment_byte, next_increment_bit);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            pos_byte = 0;
            pos_bit = 0;
            updatePos();
        }

        private void snapScrollToNextStrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            snap_scroll = !snap_scroll;
            snapScrollToNextStrideToolStripMenuItem.Checked = snap_scroll;
            scrollRange();
        }

        private void verticalLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            horizontal_layout = false;
            verticalLayoutToolStripMenuItem.Checked = true;
            horizontalLayoutToolStripMenuItem.Checked = false;
            redrawPixels();
        }

        private void horizontalLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            horizontal_layout = true;
            verticalLayoutToolStripMenuItem.Checked = false;
            horizontalLayoutToolStripMenuItem.Checked = true;
            redrawPixels();
        }

        private void twiddleNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (twiddle == 2) twiddle = 0;
            else twiddle = 2;
            twiddleZToolStripMenuItem.Checked = twiddle == 1;
            twiddleNToolStripMenuItem.Checked = twiddle == 2;
            redrawPixels();
        }

        private void twiddleZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (twiddle == 1) twiddle = 0;
            else twiddle = 1;
            twiddleZToolStripMenuItem.Checked = twiddle == 1;
            twiddleNToolStripMenuItem.Checked = twiddle == 2;
            redrawPixels();
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidegrid = !hidegrid;
            gridToolStripMenuItem.Checked = !hidegrid;
            redrawPixels();
        }

        private void exportBinaryChunkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryChunkExportForm exportForm = new BinaryChunkExportForm(pos_byte, !decimal_position, data);
            exportForm.ShowDialog();
        }

        private void pixelBox_MouseMove(object sender, MouseEventArgs e)
        {
            // clear selection
            selected_tile = -1;
            selected_pos = -1;
            saveImageToolStripMenuItem.Enabled = false;
            pixelsToPaletteToolStripMenuItem.Enabled = false;

            // grid settings from last redrawPixels
            int padx = pixel_padx;
            int pady = pixel_pady;
            int twp = pixel_twp;
            int thp = pixel_thp;
            int gx = pixel_gx;
            int gy = pixel_gy;

            int x = e.X / zoom;
            int y = e.Y / zoom;

            // find tile X / Y

            int tw = preset.width;
            int th = preset.height;

            int tx = x / twp;
            int ty = y / thp;
            int tile = (tx * gy) + ty;
            if (horizontal_layout) tile = (ty * gx) + tx;
            if (tx >= gx) return;
            if (ty >= gy) return;
            if (tile < 0) return;

            int ox = (x - (tx * twp)) - padx;
            int oy = (y - (ty * thp)) - pady;
            if (ox < 0 || ox >= tw) return;
            if (oy < 0 || oy >= th) return;

            // find data at pixel

            int row_stride = (preset.row_stride_byte * 8) + preset.row_stride_bit;
            int pixel_stride = (preset.pixel_stride_byte * 8) + preset.pixel_stride_bit;

            if (twiddle != 0)
            {
                twiddleCacheCheck(tw, th);
                int twoxy = twiddle_cache[ox + (oy * tw)];
                oy = twoxy / tw;
                ox = twoxy % th;
            }

            long pos =
                (pos_byte * 8) + pos_bit +
                (((preset.next_stride_byte * 8) + preset.next_stride_bit) * tile) +
                (row_stride * oy) +
                (pixel_stride * ox);

            if (preset.tile_size_x != 0)
            {
                pos += (ox / preset.tile_size_x) * ((preset.tile_stride_byte_x * 8) + preset.tile_stride_bit_x - (preset.tile_size_x * pixel_stride));
            }
            if (preset.tile_size_y != 0)
            {
                pos += (oy / preset.tile_size_y) * ((preset.tile_stride_byte_y * 8) + preset.tile_stride_bit_y - (preset.tile_size_y * row_stride));
            }

            long p = readPixel(pos);
            if (p < 0) return;

            // record selection
            selected_tile = tile;
            selected_pos = pos;
            saveImageToolStripMenuItem.Enabled = true;
            pixelsToPaletteToolStripMenuItem.Enabled = true;

            // pixel info
            labelInfoPixel.Text = String.Format("{0:D}+{1:D1} = {2:D}\n{0:X8}+{1:D1} = {2:X}", (int)(pos>>3), (int)(pos&7), p);
        }

        private void pixelScroll_Scroll(object sender, ScrollEventArgs e)
        {
            if (snap_scroll)
            {
                int next_stride = preset.next_stride_bit + (preset.next_stride_byte * 8);
                if (next_stride < 0) next_stride = -next_stride;
                if (next_stride == 0) next_stride = 8;
                long old_pos = (pos_byte * 8) + pos_bit;

                long snap_old = old_pos / next_stride;
                long snap_off = old_pos % next_stride;

                long target_pos = (long)(e.NewValue) * 8;
                long snap_new = (long)target_pos / next_stride;
                long new_pos = (snap_new * next_stride) + snap_off;

                pos_byte = new_pos / 8;
                pos_bit = (int)(new_pos % 8);
            }
            else
            {
                pos_byte = (long)e.NewValue;
            }

            updatePos(false);
            redrawPixels();
        }

        private void dataGridPixel_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int result;
            if (!int.TryParse(e.FormattedValue.ToString(), out result))
            {
                e.Cancel = true;
            }
        }

        private void dataGridPixel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex;
            int y = e.RowIndex;
            if (x < 1) return;
            if (x > 2) return;
            if (y < 0) return;
            if (y >= MAX_BPP) return;

            int result;
            string value = (string)dataGridPixel.Rows[y].Cells[x].Value;
            if (int.TryParse(value,out result))
            {
                if (x == 1) preset.bit_stride_byte[y] = result;
                if (x == 2) preset.bit_stride_bit[y] = result;
                redrawPixels();
            }
        }

        //
        // Other Form overrides
        //

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // global hotkeys
            switch (keyData)
            {
                case Keys.Control | Keys.O:
                    openToolStripMenuItem_Click(this, null);
                    return true;
                case Keys.Control | Keys.R:
                    reloadFileToolStripMenuItem_Click(this, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
