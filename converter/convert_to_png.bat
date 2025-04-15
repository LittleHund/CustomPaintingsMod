@echo off

:: Set the source and destination folder paths
set sourceFolder=ImagesToConvert
set destFolder=..\..\CustomPaintings

:: Get the name of the batch file so we can avoid deleting it
set batFile=%~nx0

:: Change to the source folder
cd /d "%sourceFolder%"

:: Convert all files to PNG format and save them to the destination folder
for %%f in (*.*) do (
    :: Skip the batch file
    if "%%~nxf" neq "%batFile%" (
        mogrify -format png "%%f"
        move "%%~dpnf.png" "%destFolder%"
        del "%%f"
    )
)

@echo off
setlocal enabledelayedexpansion

:: Set the starting number for the filenames
set counter=1

:: Step 1: Rename to temp names to avoid collisions
for /f "delims=" %%f in ('dir /b /a:-d /o:n "%destFolder%"') do (
    ren "%destFolder%\%%f" "temp_%%f"
)

:: Step 2: Rename temp files to numbered names
for /f "delims=" %%f in ('dir /b /a:-d /o:n "%destFolder%"') do (
    ren "%destFolder%\%%f" "!counter!%%~xf"
    set /a counter+=1
)

echo Files have been renamed successfully.
pause