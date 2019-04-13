
Binxelview binary image explorer

Version 1.0.0.0
2019-04-12
Brad Smith

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
https://ci.appveyor.com/project/bbbradsmith/binxelview/branch/master/artifacts


Requirements
------------

.NET 4.6.1 framework
Windows 7 SP1, 8, 10

The .NET runtime can be downloaded here:
 https://www.microsoft.com/en-ca/download/details.aspx?id=49981

This project is open source, and might be compatible with other .NET frameworks,
or substitutes, which could potentially enable use on other platforms.


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

Alt+B will return to position to the start of the file.
Alt+N will advance the position by 1 image (or 16 rows if the image height is 1).
Shift+Alt+N will retreat the position by 1 image.


Pixel Formats
-------------

* Little Endian
    Determines which bits of a byte have the lowest address.
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

* Plane tiling
    This performs a secondary subdivision of the image into tiles.
    The group size is the width of a tile.
    The shift is an additional offset to move the read position when the end of a group is reached.
    Example: (Atari 4BPP.bxp)
        Atari ST video memory stores 16 pixels in a tile.
        In 4BPP mode, each pixel has 4 bits,
          but each of these bits is stored in a separate 2-byte word.
        Unchecking Chunky mode allows us to specify where the 4 bits are found:
          0, 2, 4, and 6 bytes relative to the read position.
        Using a pixel stride of 1 bit will advance through the 16 pixels one by one.
        Using an plane X group of 16 pixels, once the 16th pixel is read,
          a shift of 6 bytes will skip over the next 3 words to find the start of the next tile.

Presets can be loaded and saved. The Preset menu is populated from the current working directory.
You can save a preset file "Default.bxp" to replace the default.


Palette
-------

If the BPP setting is less than 15, custom palettes can be used,
otherwise an automatic RGB or Greyscale palette can be applied.

Custom palettes are 24-bit RGB triples (8 bits for each component).
Click on a colour in the palette box to edit it.


License
-------

This program was written by Brad Smith.
It is made freely available under the the terms of the Creative Commons Attribution license:
https://creativecommons.org/licenses/by/4.0/

Source code is available at GitHub:
https://github.com/bbbradsmith/binxelview

Author's website:
http://rainwarrior.ca
