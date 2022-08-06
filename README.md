# pumpy
File Pumper &amp; Size Increaser Tool

**pumpy** is a file size increaser CLI and GUI tool. Supports all extensions.

## Features

* Doesn't breaks the file (fills with meaningless zero byte)
* All extensions supported
* Light speed pump (1gb under 1min)

## Usage

CLI tool requires 2 param. Let's pump the **someico.ico** from **3 MB** to **8 MB**.

```bash
pumpy.exe <Target File Path> <Increase Size>
```
* Target File Path: The full path of target file to pump. (Ex: C:\\somefile.txt)
* Increase Size: Increase size as MB. (Ex: 10 equals to 10MB) [use gui tool for gb option]

## Example
```bash
pump.exe "C:\\someico.ico" 5 
```

**Output**
```bash
root@pumpY:~ > File analyzed | someicon.ico - 3MB
root@pumpY:~ > Pumping '5' MB...
root@pumpY:~ > Success | 3mb => 8mb
```

## GUI Tool
Don't want CLI? Interact with [GUI](https://github.com/arshx86/pumpy/releases/tag/build) for easily pump.

![](https://media.discordapp.net/attachments/1000894685004431420/1005274843199057920/unknown.png)
