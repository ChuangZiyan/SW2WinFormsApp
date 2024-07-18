Imports System.IO

Module AppInitModule


    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public ReadOnly webivewProfileDirectory As String = Path.Combine(appBaseDirectory, "WebviewProfile")




    Public Sub InitializeMainApp()
        InitializeDataDirectory()
        UpdateWebviewProfileCheckListBox()
    End Sub


    Public Sub InitializeDataDirectory()
        If Not Directory.Exists(webivewProfileDirectory) Then
            Directory.CreateDirectory(webivewProfileDirectory)
        End If
    End Sub




End Module
