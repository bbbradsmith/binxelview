
Binxelview binary image explorer

Version 1.6.2.0
2024-10-13
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

Video demonstration:
https://www.youtube.com/watch?v=3GAPvPCM-lg

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

Alt+0 - Return to position to the start of the file.

Alt+B - Advance the position by 1 byte.
Alt+I - Advance the position by 1 bit.
Alt+X - Advance the position by 1 pixel.
Alt+R - Advance the position by 1 row.
Alt+N - Advance the position by 1 image (or 16 rows if the image height is 1).

Shift+Alt+B,I,X,R,N - Retreat the position by 1 byte, bit, pixel, row, image.

Ctrl+O - Open a new file.
Ctrl+R - Reload the current file.
Ctrl+W - Toggle pixel window.


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

* Twiddle (Advanced menu)
    This will rearrange the pixel X and Y within a tile to use a Morton (Z/N) ordering,
    commonly seen in square textures "twiddled" or "swizzled" for GPU cache coherence.
    Width and Height should be the same, and a power of two.
    See: https://en.wikipedia.org/wiki/Z-order_curve


Presets can be loaded and saved.
The Preset menu is populated from the directory of the executable,
but this can be changed to another directory of your choice, which will be saved with your options.


Palette
-------

If the BPP setting is less than 15, custom palettes can be used,
otherwise an automatic RGB or Greyscale palette can be applied.

Custom palettes are 24-bit RGB triples (8 bits for each component).
Click on a colour in the palette box to edit it.

If you are able to view a block of palette data in a file, you can quickly copy it to the palette.
Right click on the first pixel of the block, and the palette will be generated with the colour of
each pixel starting with that one. Note that this assumes contiguous pixel data, and will not account
for row stride, next stride, or tiling. (Stride for row and next should be auto, tiling values should be 0.)

For example, using the 24BPP preset, you can view a saved palette file as coloured pixels.
Right clicking on the first pixel, you can "load" this palette directly from the file.
Similarly, the VGA Palette preset may be able to find palettes in a format commonly found in DOS games.
After transferring the palette, you will need to select another preset to view other data in the file
using that palette.


Other Notes
-----------

Due to signed 32-bit integer limitations of C sharp, files must be less than 2GB in size.
To inspect extremely large files, you may have to split them first.


Command Line Options and INI Configuration Files
------------------------------------------------

To open a file, just add that file's path to the command line.

Options can be set with a command line argument beginning with '-',
followed by the option name, an '=' separator, and the value for the option.
If a space is required in the value, you should enclose the entire argument in quotes.
Paths can be either absolute or relative to the current working directory.
For an INI file, paths can be either absolute or relative to the INI file's directory.

  "-ini=mysettings.ini"
    Loads an applies settings from another INI file besides the default.
    This option can only be used from the command line, and not within an INI file.
    If the save on exit option is enabled (see -saveini below),
    it will save to this file used with -ini, rather than the default location.
    (This only applies to the command line. INI files loaded from the Options menu do not
    become the save on exit file.)

  -saveini=1
    If this option is enabled (1) current settings will be saved back to the loaded INI when you quit.
    If this option is disabled (0) your current settings will not be remembered when you quit.

  "-presetfile=C:\mypreset.bxp"
    Loads the current preset directly from a file, without adding it to the preset library.

  "-preset=Atari ST 4BPP"
    Chooses a named preset from your preset library.

  "-presetdir=C:\mypresets"
    Discards the preset library and reloads a new library from this directory only.
    If also using -preset or -presetfile, these options should come after -presetdir.

  "-pal=my palettes\red.pal"
    Loads a palette file. If -paltype is not used (see below) it will detect the type by the file extension.
    If the extension is .BMP .GIF .PNG or .TIF it will load it as an palette from an image.
    If the extension is .VGA it will load it as 6-bit RGB18 format.
    If the extension is .RIFF it will load it as a Microsoft RIFF palette.
    Otherwise it will load it as RGB24.

  -paltype=1
    Overrides the extension check for the next -pal option. (Must be used before -pal.)
    0 = RGB24, 1 = Image, 2 = VGA, 3 = RIFF, -1 = Use extension.

  -autopal=Greyscale
    Chooses an automatic palette, one of:
      RGB - RGB with the current preset BPP, bits evenly divided with G bits >= R bits >= B bits. (Red is MSB.)
      Random - Every colour is randomized.
      Greyscale - Gradient from black to white.
      Cubehelix - Smooth gradient with rotating hue, created by Dave Green.
                  See: https://people.phy.cam.ac.uk/dag9/CUBEHELIX/

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

  -splitview=1
    Set the "Pixel Window" option to create a separate viewing window (1 on, 0 off).

  -splitvieww=640
  -splitviewh=480
    Set the Pixel Window's width and height.

  -horizontal=1
    Set the layout option (1 horizontal, 0 vertical).

  -twiddle=1
    Set the twiddle option (0 off, 1 twiddle Z, 2 twiddle N).


INI files provide the same options as the command line, with minor differences:
  - One option may be used per line, there is no leading - for an option like the command line.
  - Blank lines, or lines starting with # will be ignored.
  - Paths can be either absolute or relative to the INI file's directory.
    Paths inside the INI directory (or subdirectories) will be automatically saved as relative.
  - The 'ini' option cannot be used to load an INI file from within an INI file.

If not overridden with the -ini command line option, Binxelview will look for Binxelview.ini.
It will search 3 locations, checked in this order:
  - The current working directory.
  - The executable directory.
  - The appdata local folder. (%LOCALAPPDATA%\Binxelview\Binxelview.ini)

When save on exit is applied, options will be saved back to the first INI file that was found,
or the INI selected from the command line -ini option. If no INI was found, it will try to create
a default Binxelview.ini file in 2 possible locations, attempted in order. (Appdata is used
as a fallback in case the executable is installed in a protected location like Program Files.)
  - The executable directory.
  - The appdata local folder.


Because save on exit is an option saved to the INI file, if you want to create a "read only"
INI that gives you an unchanging default setup, turn off save on exit, then "Save Current Options"
from the menu. This will save the current options now, since disabling that option will prevent
them from being saved when you exit the program.


You can create "workspaces" for Binxelview by putting a Binxelview.ini, presets, etc. into
a folder, then opening Binxelview with that folder as the current working directory.

Alternatively, you might use the -ini command line option to create a shortcut that applies
a specific INI setup.


Changes
-------

1.6.3.0 (unreleased beta)
- Fix relative INI path edge case, when the target directory has a similar name to the INI directory.
- Fix inefficient UI updates which were accidentally recursive.
- Fix PixelView not updating scroll position on first open.
- Fix crash bug when lowering BPP and bit ordering grid was scrolled down too far.

1.6.2.0 (2024-10-13)
- Option persistence, INI file save and load.
- Command line arguments for options.
- Pixel window option for second viewing window.
- Maximum file size increased from 256MB to 2GB.
- Option to disable grid padding between cells.
- "Export Binary Chunk" option added to File menu. (Contributor: damieng)
- File menu reload option.
- Added global Ctrl hotkeys.
- Right click context menu option to move position to the selected pixel.
- Right click context menu option to copy to the palette starting from the selected pixel.
- Added Cubehelix automatic palette option.
- Automatic palette modes are now a dropdown list.
- Tab stop organization of interface. (Contributor: Erquint)
- "Little Endian" renamed to "Reverse Byte" for clarity.
- Limit width to 65536 to prevent out of memory from accidentally typing huge widths.
- Indicate hexadecimal position with bold font.
- Fix image loaded as palette not releasing file handle.
- Remember last used file type filter from the load palette dialog.
- Removed default preset, as persistent options will remember your last preset instead.
- Indicate selected preset in the presets menu.
- Added redundant menu option for background colour, to find easier and be keyboard accessible.
- Use byte/bit for default chunky table instead of just bit.
- Palette load option for common VGA format. (Contributor: foone)
- Microsoft RIFF palette support.
- GB CHR 8px preset. (Contributor: Lord-Nightmare)
- ZX Spectrum preset. (Contributor: damieng)
- SNES 8BPP preset. (Contributor: ButThouMust)
- Genesis/MegaDrive 8px preset.
- PS1 15BPP and 4BPP presets. (Contributor: HeyItsLollie)
- VGA Palette preset.

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
