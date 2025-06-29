@echo off
setlocal enabledelayedexpansion

:: Set the source and destination folder paths
set "batFolder=%~dp0"
set "sourceFolder=%batFolder%GifsToConvert"
set "destFolder=%batFolder%..\CustomPaintings"
set "ffmpegExe=%batFolder%ffmpeg.exe"

:: Make sure ffmpeg exists
if not exist "%ffmpegExe%" (
    echo ffmpeg.exe not found in the batch file's directory.
    pause
    exit /b
)

:: Create destination folder if it doesn't exist
if not exist "%destFolder%" (
    mkdir "%destFolder%"
)

:: Change to the source folder
pushd "%sourceFolder%" || (echo Source folder not found. & pause & exit /b)

:: Convert all .gif files to .mp4 and move to destination
for %%f in (*.gif) do (
    echo Converting: %%f
    "%ffmpegExe%" -y -i "%%f" -vf "fps=15,scale=trunc(iw/2)*2:trunc(ih/2)*2" -movflags faststart -pix_fmt yuv420p "%destFolder%\%%~nf.mp4"
    del "%%f"
)

popd

:: Rename converted files to avoid collisions, then number them
cd /d "%destFolder%"

:: Step 1: Rename to temp names to avoid name collisions
for /f "delims=" %%f in ('dir /b /a:-d /o:n *.mp4') do (
    ren "%%f" "temp_%%f"
)

:: Step 2: Rename temp files to numbered names
set counter=1
for /f "delims=" %%f in ('dir /b /a:-d /o:n temp_*.mp4') do (
    ren "%%f" "!counter!.mp4"
    set /a counter+=1
)

echo All GIFs have been converted and renamed.
pause
