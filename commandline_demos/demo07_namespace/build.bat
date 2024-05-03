@echo off

csc -target:library Furnitures.cs

csc -target:library Data.cs

csc -out:fs.exe Program.cs -r:Furnitures.dll,Data.dll
