Function MapDrives
    dim ws : set ws = createobject("wscript.shell")
    Set objSysInfo = CreateObject("ADSystemInfo")
    strUserPath = "LDAP://" & objSysInfo.UserName
    strhomeDirectory = "LDAP://" & objSysInfo.UserName
    Set objUser = GetObject(strUserPath)
    Set objUser = GetObject(strhomeDirectory)
    ws.run "cmd /c %logonserver%\netlogon\" & objUser.ScriptPath & " /persistent:yes"
    ws.run "cmd /c net use H: " & objUser.homeDirectory & " /persistent:yes"
End Function

'If subsequent function call results in error, continue execution
On Error Resume Next
call MapDrives()


If Err.Number = 0 Then
    WScript.Quit(0)
End If

WScript.Quit(1)