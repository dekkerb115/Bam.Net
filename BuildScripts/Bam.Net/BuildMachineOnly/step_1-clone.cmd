@echo off
SET BRANCH=%2
IF [%2]==[] SET BRANCH=master
SET ROOT=%1
IF [%1]==[] SET ROOT=C:\src
Z:
cd \Workspace\Build
call clone.cmd %ROOT% %BRANCH%
Z:
cd \Workspace\Build

For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ("%TIME%") do (set mytime=%%a%%b)

echo %mydate%_%mytime% Step 1 Complete - Clone

echo %mydate%_%mytime% Step 1 Complete - Clone >> Z:\Workspace\build.log