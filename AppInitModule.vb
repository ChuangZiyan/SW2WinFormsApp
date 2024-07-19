Imports System.IO

Module AppInitModule


    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public ReadOnly webivewUserDataDirectory As String = Path.Combine(appBaseDirectory, "WebviewUserData")


    Public Sub InitializeMainApp()
        InitializeDataDirectory()
        UpdateWebviewUserDataCheckListBox()
    End Sub


    Public Sub InitializeDataDirectory()
        If Not Directory.Exists(webivewUserDataDirectory) Then
            Directory.CreateDirectory(webivewUserDataDirectory)
        End If
    End Sub


End Module
