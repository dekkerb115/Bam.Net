@echo on
SET CONFIG=%1
IF [%1]==[] SET CONFIG=Release
SET LIB=net462
SET VER=v4.6.2

MD Bam.Net.Drawing\lib\%LIB%
copy /Y .\BuildOutput\%CONFIG%\%VER%\Bam.Net.Drawing.dll Bam.Net.Drawing\lib\%LIB%\Bam.Net.Drawing.dll
copy /Y .\BuildOutput\%CONFIG%\%VER%\Bam.Net.Drawing.xml Bam.Net.Drawing\lib\%LIB%\Bam.Net.Drawing.xml