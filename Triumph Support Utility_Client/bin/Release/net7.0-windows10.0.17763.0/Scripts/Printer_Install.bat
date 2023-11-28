@echo off
setlocal

set "shareName=%~1"
set "printerName=%~2"

call :InstallPrinter
exit

:InstallPrinter
cd C:\WINDOWS\SYSTEM
rundll32 printui.dll,PrintUIEntry /in /n "\\%shareName%\%printerName%"
call :VerifyPrinterInstall
goto:eof

:VerifyPrinterInstall
wmic printer list brief | findstr /i /c:"%printerName%"
exit /b %errorlevel%
goto:eof