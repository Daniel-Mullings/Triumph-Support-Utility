Public Class info

    Public Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtIP.Text = GetIPv4Address()
        txtUsername.Text = SystemInformation.UserName
        txtName.Text = My.Computer.Name
        txtOS.Text = My.Computer.Info.OSFullName
        txtDomain.Text = SystemInformation.UserDomainName
        txtScreen.Text = SystemInformation.PrimaryMonitorSize.Width & " x " & SystemInformation.PrimaryMonitorSize.Height
        txtLogon.Text = Replace(Environment.GetEnvironmentVariable("LOGONSERVER"), “\”, “”)

        If Environment.Is64BitOperatingSystem Then
            txtOSPlatform.Text = "64 bit"
        Else
            txtOSPlatform.Text = "32 bit"
        End If
    End Sub

    Private Sub btnMapDrives_Click(sender As Object, e As EventArgs)
        MsgBox("I'll make this work later....")
    End Sub

    Private Sub btnRemote_Click(sender As Object, e As EventArgs)
        MsgBox("I'll make this work later....")
    End Sub

    'Private Sub btnMapDrives_Click_1(sender As Object, e As EventArgs) Handles btnMapDrives.Click
    'Dim ws = CreateObject("wscript.shell")
    'Dim objSysInfo = CreateObject("ADSystemInfo")
    'Dim strUserPath = "LDAP://" & objSysInfo.UserName
    'Dim objUser = GetObject(strUserPath)

    '    "cmd /c %logonserver%\netlogon\" & objUser.ScriptPath
    'End Sub
End Class
