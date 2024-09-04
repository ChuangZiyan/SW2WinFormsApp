Imports System.IO

Module AppInitModule

    ' user data
    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory

    Public ReadOnly appConfigsDirectory As String = Path.Combine(appBaseDirectory, "appConfigs")

    Public ReadOnly webivewUserDataDirectory As String = Path.Combine(appBaseDirectory, "WebviewUserData")
    Public ReadOnly availableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "available")
    Public ReadOnly unavailableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "unavailable")

    ' assets
    Public ReadOnly myAssetsDirectory As String = Path.Combine(appBaseDirectory, "myAssets")

    Public ReadOnly FBPostAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostAssets")
    Public ReadOnly FBMarketPlaceAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBmarketplaceAssets")

    ' auto save script csv file path 
    'Public ReadOnly AutoSaveScriptCSVFilePath As String = Path.Combine()


    Private mainFormEventHandlers As New MainFormEventHandlers()


    Public Sub InitializeMainApp()
        InitializeDataDirectory()
        UpdateWebviewUserDataCheckListBox()
        FBPostEventHandlers.UpdateAssetsFolderListBox()
        FBMarketplaceEventHandlers.UpdateMarketplaceAssetsFolderListBox()
    End Sub


    Public Sub InitializeDataDirectory()

        Dim myDirectories() As String = {
                appConfigsDirectory,
                webivewUserDataDirectory,
                availableUserDataDirectory,
                unavailableUserDataDirectory,
                myAssetsDirectory,
                FBPostAssetsDirectory,
                FBMarketPlaceAssetsDirectory
        }

        For Each myDir In myDirectories
            If Not Directory.Exists(myDir) Then
                Directory.CreateDirectory(myDir)
            End If
        Next

    End Sub




End Module
