Imports System.IO

Module AppInitModule

    ' app base 
    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public ReadOnly appConfigsDirectory As String = Path.Combine(appBaseDirectory, "appConfigs")

    ' UserData
    Public ReadOnly webivewUserDataDirectory As String = Path.Combine(appBaseDirectory, "WebviewUserData")
    Public ReadOnly availableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "available")
    Public ReadOnly unavailableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "unavailable")

    ' Assets
    Public ReadOnly myAssetsDirectory As String = Path.Combine(appBaseDirectory, "myAssets")

    Public ReadOnly FBPostAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostAssets")
    Public ReadOnly FBMarketPlaceAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBmarketplaceAssets")
    Public ReadOnly FBPostShareURLAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostShareURLAssets")
    Public ReadOnly FBCommentAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBCommentAssets")

    ' auto save script csv file path 
    ' Public ReadOnly AutoSaveScriptCSVFilePath As String = Path.Combine()


    'Private mainFormEventHandlers As New MainFormEventHandlers()


    Public Sub InitializeMainApp()
        InitializeDataDirectory()
        UpdateWebviewUserDataCheckListBox()
        FBPostEventHandlers.UpdateAssetsFolderListBox()
        FBMarketplaceEventHandlers.UpdateMarketplaceAssetsFolderListBox()
        FBPostShareURLEventHandlers.UpdatePostShareURLAssetsFolderListBox()
        FBCommemtEventHandlers.UpdateAssetsFolderListBox()
    End Sub


    Public Sub InitializeDataDirectory()

        ' 初始化所有資料夾，把路徑放進去就會在程式啟動時候自動建立
        Dim myDirectories() As String = {
                appConfigsDirectory,
                webivewUserDataDirectory,
                availableUserDataDirectory,
                unavailableUserDataDirectory,
                myAssetsDirectory,
                FBPostAssetsDirectory,
                FBMarketPlaceAssetsDirectory,
                FBPostShareURLAssetsDirectory,
                FBCommentAssetsDirectory
        }

        For Each myDir In myDirectories
            If Not Directory.Exists(myDir) Then
                Directory.CreateDirectory(myDir)
            End If
        Next

    End Sub




End Module
