@echo off
title Snow Agent Batch Install Utility

call :main
timeout 5
exit

:main
set isPresent_32BitSnowAgent="0"
set isPresent_64BitSnowAgent="0"
echo NOTICE: This program is property of Triumph Motorcycles Ltd.
echo The purpose of this program is to execute Scan and Send for the Snow Inventory Agent for Windows.
echo Contact the IT Service Desk - UK for more information.
echo.
echo [SCANNING FOR EXISTING SNOW AGENT INSTALLATIONS]

call :detectExistingSnowAgentInstallations
if %errorlevel% neq 0 exit

call :scanSnowAgent
if %errorlevel% neq 0 exit

call :sendSnowAgent
if %errorlevel% equ 0 (echo. & echo [EXITING: Error: Snow Agent Scan and Send encountered an issue] & exit) else (echo. & echo [EXITING: Success: Snow Agent Scan and Send completed successfully] & exit)

:detectExistingSnowAgentInstallations
if exist "C:\Program Files (x86)\Snow Software" (echo # Existing Snow Agent 32-Bit install detected! & set isPresent_32BitSnowAgent="1") else (echo # No Snow Agent 32-Bit install detected!)
if exist "C:\Program Files\Snow Software" (echo # Existing Snow Agent 64-Bit install detected! & set isPresent_64BitSnowAgent="1") else (echo # No Snow Agent 64-Bit install detected!)
goto:eof

:scanSnowAgent
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" (call :scanSnowAgent_64Bit) else (call :scanSnowAgent_32Bit)
goto:eof

:scanSnowAgent_32Bit
cd "C:\Program Files (x86)\Snow Software\Inventory\Agent\"
echo.
echo [RUNNING SNOW AGENT SCAN]
snowagent.exe scan
if %errorlevel% equ 0 (echo # Snow Agent Scan success!) else (echo. & echo # Snow Agent Scan fail! & timeout 5 & exit /b 1)
goto:eof

:scanSnowAgent_64Bit
cd "C:\Program Files\Snow Software\Inventory\Agent\"
echo.
echo [RUNNING SNOW AGENT SCAN]
snowagent.exe scan
if %errorlevel% equ 0 (echo # Snow Agent Scan success!) else (echo. & echo # Snow Agent Scan fail! & timeout 5 & exit /b 1)
goto:eof

:sendSnowAgent
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" (call :sendSnowAgent_64Bit) else (call :sendSnowAgent_32Bit)
goto:eof

:sendSnowAgent_32Bit
cd "C:\Program Files (x86)\Snow Software\Inventory\Agent\"
echo.
echo [SENDING SNOW AGENT SCAN]
snowagent.exe send
if %errorlevel% equ 0 (echo # Snow Agent Scan sent successfully! & echo [%date% @ %time%] %COMPUTERNAME% Snow: Scanned, Sent >> "\\S-UKVM-FP15\grpgnrl\Daniel Mullings\Support Files\Scripts\Snow\SnowReinstallerLog.txt" & timeout 5 & exit /b 0) else (echo # Error sending Snow Agent Scan! & timeout 5 & exit /b 2)
goto:eof

:sendSnowAgent_64Bit
cd "C:\Program Files\Snow Software\Inventory\Agent\"
echo.
echo [SENDING SNOW AGENT SCAN]
snowagent.exe send
if %errorlevel% equ 0 (echo # Snow Agent Scan sent successfully! & echo [%date% @ %time%] %COMPUTERNAME% Snow: Scanned, Sent >> "\\S-UKVM-FP15\grpgnrl\Daniel Mullings\Support Files\Scripts\Snow\SnowReinstallerLog.txt" & timeout 5 & exit /b 0) else (echo # Error sending Snow Agent Scan! & timeout 5 & exit /b 2)
goto:eof