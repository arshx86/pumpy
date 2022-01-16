# pumpy
File Pumper &amp; Size Increaser Tool

## About tool

**pumpy** is a file size increaser CLI tool. Supports all extensions.

## Advantages

* Tool doesn't break the file.
* Supports all type of files. (png, jpg, ico, png, txt - Even the exe!)
* Fast pump/write. (1gb under of 2min)

## Usage

Pumpy has simple usage, it only wants 3 parameters from you. 
```bash
pumpy.exe <Target File Path> <Increase Size>
```
> Target File Path: The full path of target file to pump. (Ex: C:\\somefile.txt)
> Increase Size: Increase size as MB. (Ex: 10 equals to 10MB)

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
You can see the 3mb file increased to 8mb in here.


