Imports System.IO

Module AppInitModule


    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public ReadOnly webivewUserDataDirectory As String = Path.Combine(appBaseDirectory, "WebviewUserData")
    Public ReadOnly availableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "available")
    Public ReadOnly unavailableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "unavailable")


    Public Sub InitializeMainApp()
        InitializeDataDirectory()
        UpdateWebviewUserDataCheckListBox()
    End Sub


    Public Sub InitializeDataDirectory()
        If Not Directory.Exists(webivewUserDataDirectory) Then
            Directory.CreateDirectory(webivewUserDataDirectory)
        End If

        If Not Directory.Exists(availableUserDataDirectory) Then
            Directory.CreateDirectory(availableUserDataDirectory)
        End If

        If Not Directory.Exists(unavailableUserDataDirectory) Then
            Directory.CreateDirectory(unavailableUserDataDirectory)
        End If
    End Sub


End Module
