Dim shellExecuteVisible
If WScript.Arguments.Count > 0 Then
    shellExecuteVisible = CStr(WScript.Arguments.Item(0))
Else
    shellExecuteVisible = 1
End If

Function MapDrives(p_shellExecuteVisible)
    dim ws : set ws = createobject("wscript.shell")
    Set objSysInfo = CreateObject("ADSystemInfo")
    strUserPath = "LDAP://" & objSysInfo.UserName
    strhomeDirectory = "LDAP://" & objSysInfo.UserName
    Set objUser = GetObject(strUserPath)
    Set objUser = GetObject(strhomeDirectory)
    ws.run "cmd /c %logonserver%\netlogon\" & objUser.ScriptPath & " /persistent:yes", p_shellExecuteVisible
    ws.run "cmd /c net use H: " & objUser.homeDirectory & " /persistent:yes", p_shellExecuteVisible
End Function

'If subsequent function call results in error, continue execution
On Error Resume Next
call MapDrives(shellExecuteVisible)


If Err.Number = 0 Then
    WScript.Quit(0)
End If

WScript.Quit(1)