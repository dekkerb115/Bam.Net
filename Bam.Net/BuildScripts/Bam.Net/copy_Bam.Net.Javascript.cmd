@echo off

SET LIB=net40
SET VER=v4.0
SET NEXT=NEXT
GOTO COPY

:NEXT
SET LIB=net45
SET VER=v4.5
SET NEXT=END
GOTO COPY

:COPY
MD Bam.Net.Javascript\lib\%LIB%
copy /Y .\BuildOutput\Release\%VER%\Bam.Net.Javascript.dll Bam.Net.Javascript\lib\%LIB%\Bam.Net.Javascript.dll
copy /Y .\BuildOutput\Release\%VER%\Bam.Net.Javascript.xml Bam.Net.Javascript\lib\%LIB%\Bam.Net.Javascript.xml
GOTO %NEXT%

:END

