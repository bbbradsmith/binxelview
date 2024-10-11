
Binxelview binary image explorer

Version 1.5.0.0
2020-07-31
Brad Smith et al.

https://github.com/bbbradsmith/binxelview
http://rainwarrior.ca


This is a relatively simple tool for making visual analysis of data in binary files.
It is intended to find and visualize data that is organized in a grid within the file,
to assist locating uncompressed graphical image, or tile based video game maps,
or other appropriate data within the file.

This is not a generic image viewing tool, nor is it an editing tool.
I wrote it to use as the first step in analyzing or reverse engineering unknown file formats,
which might contain data that can be identified visually in a grid.
Once the data is identified and located within the file,
more work would follow with other appropriate tools.


Unstable preview builds:
https://nightly.link/bbbradsmith/binxelview/workflows/build/master


Requirements
------------

.NET 4 framework
Windows XP SP3, Vista, 7, 8, 10

The .NET runtime can be downloaded here:
https://www.microsoft.com/en-ca/download/details.aspx?id=17718

This project is open source, and might be compatible with other .NET frameworks,
which could potentially enable use on other platforms.


Basic Use
---------

Open a binary file that you wish to inspect.
Choose an image data type preset from the preset menu.
Use the scroll bar to scan through the file looking for data.
Fine tune the packing parameters to bring the grid of data into alignment.
Hover over the image to see information about each pixel.

The lower panel displays the current loaded binary file according to a chosen pixel format.
The top left corner of the display will start at the byte/bit offset given in the Position panel.

Right click on an image for an option to save it to disk.
If the pixels are 8-BPP or less, it will be saved as an indexed image.

Alt+0 will return to position to the start of the file.

Alt+B will advance the position by 1 byte.
Alt+I will advance the position by 1 bit.
Alt+X will advance the position by 1 pixel.
Alt+R will advance the position by 1 row.
Alt+N will advance the position by 1 image (or 16 rows if the image height is 1).

Shift+Alt+B,I,X,R,N will retreat the position by 1 byte, bit, pixel, row, image.


Pixel Formats
-------------

* Reverse Byte
    Reverses the order of bits within each byte.
* Chunky
    Bits of a pixel are taken contiguously.
    Uncheck this to allow editing of the adjacent bits table.
* Bits table
    When not in chunky mode, you can control where each bit of a pixel is found relative to the first.
    Enter a byte and bit offset for each bit of the pixel's data.

* BPP
    Bits per pixel.
* Width
    The width of a row of the image, adjust this until you see your target data come into alignment.
* Height
    The height of an image within the file. Use 1 to just view contiguous data.

* Pixel stride
    After each pixel is read, the read position is advanced by this many bytes and bits.
* Row stride
    After a row of pixels is completed, the next row starts at this distance from the previous one.
* Next stride
    After a complete image is read, the next image starts at this distance from the previous.

* Tiling
    This performs a secondary subdivision of the image into tiles.
    The size indicates the pixel width/height of a tile. Size 0 disables tiling on that axis.
    The stride is the distance between the start of each tile pixel (X) or row (Y).
    Example 1: (Atari 4BPP.bxp)
        Atari ST video memory stores 16 pixels in a tile.
        In 4BPP mode, each pixel has 4 bits,
          but each of these bits is stored in a separate 2-byte word.
        Unchecking Chunky mode allows us to specify where the 4 bits are found:
          0, 2, 4, and 6 bytes relative to the read position.
        Using a pixel stride of 1 bit will advance through the 16 pixels one by one.
        Using an tile X size of 16 pixels, on every 16th pixel
          a stride of 8 bytes will advance to the start of the next tile.
    Example 2: (MSX 1BPP 16px.bxp)
        This format stores the left half of a 16x16 sprite vertically, then the right half, in 32 byte blocks.
        BPP=1, Width=16, Height=16
        Pixel=1 bit (A), Row=1 byte (B), Next=32 bytes
        Tile X size=8 pixels (C), Tile X stride=16 bytes (D)
        This means:
          From the current row, read 8 (C) x 1BPP (A) pixels to fill the first tile.
          Advance 16 bytes (D) from the start of the row, then read the second tile.
          The next row will begin again 1 byte (B) from the start of the previous row.

Presets can be loaded and saved.
The Preset menu is populated both from the current working directory,
and also from the directory of the executable.
You can save a preset file "Default.bxp" to replace the default.


Palette
-------

If the BPP setting is less than 15, custom palettes can be used,
otherwise an automatic RGB or Greyscale palette can be applied.

Custom palettes are 24-bit RGB triples (8 bits for each component).
Click on a colour in the palette box to edit it.

You can create a default palette named "default.pal" to be loaded automatically at startup.
As with presets, it will check the current working directory for "default.pal" first,
before also checking the directory of the executable.

If you are able to view a block of palette data in a file, you can quickly copy it to the palette.
Right click on the first pixel of the block, and the palette will be generated with the colour of
each pixel starting with that one. Note that this assumes contiguous pixel data, and will not account
for row stride, next stride, or tiling. (Stride for row and next should be auto, tiling values should be 0.)

For example, using the 24BPP preset, you can view a saved palette file as coloured pixels.
Right clicking on the first pixel, you can "load" this palette directly from the file.
Similarly, the VGA Palette preset may be able to find palettes in a format commonly found in DOS games.
After transferring the palette, you will need to select another preset to view other data in the file
using that palette.


Hotkeys
-------

The following global hotkeys may be used:

Ctrl+O - Open a new file.
Ctrl+R - Reload the current file.


Other Notes
-----------

Due to signed 32-bit integer limitations of C sharp, files must be less than 2GB in size.
To inspect extremely large files, you may have to split them first.

The Twiddle options will rearrange the pixel X and Y within a tile to use a
Morton (Z/N) ordering, commonly seen in square textures "twiddled" or "swizzled" for
GPU cache coherence.


Command Line Options
--------------------

To open a file, just add that file's path to the command line.

Options can be set with a command line argument beginning with '-',
followed by the option name, an '=' separator, and the value for the option.
If a space is required in the value, you should enclose the entire argument in quotes.

  "-presetfile=C:\mypreset.bxp"
    Replaces the default preset with one from a file.

  "-preset=Atari ST 4BPP"
    Chooses a named preset from your preset library instead of the default.

  "-pal=C:\red.pal"
    Loads a palette file.
    If the extension is .BMP .GIF .PNG or .TIF it will load it as an palette from an image.
    If the extension is .VGA it will load it as 6-bit RGB18 format.
    If the extension is .RIFF it will load it as a Microsoft RIFF palette.
    Otherwise it will load it as RGB24.

  -autopal=Greyscale
    Chooses an automatic palette, one of:
      RGB - RGB with the current preset BPP, bits evenly divided with G >= R >= B, red as the highest bits.
      Random - Every colour is randomized.
      Greyscale - Gradient from black to white.
      Cubehelix - Smooth gradient with rotating hue, created by Dave Green. See: https://people.phy.cam.ac.uk/dag9/CUBEHELIX/

  -background=FF0088
    Set the Background grid colour, uses a 6 digit hexadecimal RRGGBB value.

  -zoom=3
    Set the Zoom value.

  -grid=1
    Set the Grid Padding option (1 on, 0 off).

  -hexpos=1
    Set the Position byte display to use hexadecimal (1 hexadecimal, 0 decimal).

  -snapscroll=1
    Set the "Snap scroll to next stride" option (1 on, 0 off).

  -horizontal=1
    Set the layout option (1 horizontal, 0 vertical).

  -twiddle=1
    Set the twiddle option (0 off, 1 twiddle Z, 2 twiddle N).


Changes
-------

1.6.0.0 (unreleased beta)
- GB CHR 8px preset. (Contributor: Lord-Nightmare)
- ZX Spectrum preset. (Contributor: damieng)
- Now loads presets from executable directory after trying current directory first. (Contributor: damieng)
- Option to disable grid padding between cells.
- "Little Endian" renamed to "Reverse Byte" for clarity.
- "Export Binary Chunk" option added to File menu. (Contributor: damieng)
- Tab stop organization of interface. (Contributor: Erquint)
- Palette load option for common VGA format. (Contributor: foone)
- Limit width to 65536 to prevent out of memory from accidentally typing huge widths.
- SNES 8BPP preset. (Contributor: ButThouMust)
- Maximum file size increased from 256MB to 2GB.
- Right click context menu option to move position to the selected pixel.
- File menu reload option.
- Added global Ctrl hotkeys.
- Added Cubehelix automatic palette option.
- Automatic palette modes are now a dropdown list.
- Right click context menu option to copy to the palette starting from the selected pixel.
- PS1 15BPP and 4BPP presets. (Contributor: HeyItsLollie)
- VGA Palette preset.
- Indicate hexadecimal position with bold font.
- Command line arguments for options.
- Default palette ability.
- Fix image loaded as palette not releasing file handle.
- Remember last used file type filter from the load palette dialog.
- Microsoft RIFF palette support.

1.5.0.0 (2020-07-31)
- Twiddle option for inspecting textures stored with morton ordering of pixels.
- Snap scroll to next stride enabled by default.

1.4.0.0 (2019-04-25)
- Less jitter on snap scrollbar.
- Loading palette now refreshes the pixel view.
- Can load palette from image via file dialog filter dropdown.

1.3.0.0 (2019-04-16)
- Fix crash on negative next stride.
- Fix scrollbar moving on release.
- Option to snap scroll to next stride (scroll without losing image alignment).
- Horizontal layout option.

1.2.0.0 (2019-04-14)
- Renamed tiling "group" to "size".
- Allow partial images in view on right side.

1.1.0.0 (2019-04-13)
- Switch from .NET 4 (from 4.6.1) for XP support.
- Buttons with keyboard shortcuts for advance byte/bit/pixel/row/next and zero.
- Renamed "phase tiling" to just "tiling".
- The relative "shift" of phase tiling is now just an absolute "stride".
- Internal preset version now 2 for the semantic change of tiling.


License
-------

This program was written by Brad Smith, with contributions from other authors.
It is made freely available under the the terms of the Creative Commons Attribution license:
https://creativecommons.org/licenses/by/4.0/

Source code is available at GitHub:
https://github.com/bbbradsmith/binxelview

Author's website:
http://rainwarrior.ca
