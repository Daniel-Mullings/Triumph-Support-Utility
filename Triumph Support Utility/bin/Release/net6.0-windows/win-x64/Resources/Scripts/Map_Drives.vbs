dim ws : set ws = createobject("wscript.shell")
Set objSysInfo = CreateObject("ADSystemInfo")
strUserPath = "LDAP://" & objSysInfo.UserName
strhomeDirectory = "LDAP://" & objSysInfo.UserName
Set objUser = GetObject(strUserPath)
Set objUser = GetObject(strhomeDirectory)
ws.run "cmd /c %logonserver%\netlogon\" & objUser.ScriptPath & " /persistent:yes"
ws.run "cmd /c net use H: " & objUser.homeDirectory & " /persistent:yes"