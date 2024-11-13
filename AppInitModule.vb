Imports System.IO
Imports Newtonsoft.Json
Imports SW2WinFormsApp.FBMarketplaceEventHandlers

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
    Public ReadOnly FBMarketPlaceAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBMarketplaceAssets")
    Public ReadOnly FBPostShareURLAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostShareURLAssets")
    Public ReadOnly FBCommentAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBCommentAssets")
    Public ReadOnly FBCustomizeCommentAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBCustomizeCommentAssets")
    Public ReadOnly FBResponseAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBResponseAssets")
    Public ReadOnly FBMessengerAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBMessengerAssets")
    Public ReadOnly FBStoryAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBStoryAssets")
    Public ReadOnly FBPersonalPostAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPersonalPostAssets")
    Public ReadOnly FBReelsAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBReelsAssets")

    ' download media resources
    Public ReadOnly DownloadedMediaResourcesAssetsDirectory As String = Path.Combine(myAssetsDirectory, "DownloadedMediaResourcesAssets")
    Public ReadOnly DownloadedImagesResourcesAssetsDirectory As String = Path.Combine(DownloadedMediaResourcesAssetsDirectory, "images")
    Public ReadOnly DownloadedVideosResourcesAssetsDirectory As String = Path.Combine(DownloadedMediaResourcesAssetsDirectory, "videos")



    ' app configs
    Public ReadOnly versionNumber As String = "v1.005"
    ReadOnly currentDate As DateTime = DateTime.Today
    Public ReadOnly appVersion As String = currentDate.ToString("yyyyMMdd.") & versionNumber


    ' auto save script csv file path 
    ' Public ReadOnly AutoSaveScriptCSVFilePath As String = Path.Combine()


    'Private mainFormEventHandlers As New MainFormEventHandlers()


    Public Sub InitializeMainApp()

        'Debug.WriteLine(appVersion)
        InitializeDataDirectory()
        InitProfile()
        InitAppConfigsFile()
        UpdateWebviewUserDataCheckListBox()
        FBPostEventHandlers.UpdateAssetsFolderListBox()
        FBMarketplaceEventHandlers.UpdateMarketplaceAssetsFolderListBox()
        FBPostShareURLEventHandlers.UpdatePostShareURLAssetsFolderListBox()
        FBCommentEventHandlers.UpdateAssetsFolderListBox()
        FBCustomizeCommentEventHandlers.UpdateAssetsFolderListBox()
        FBResponseEventHandlers.UpdateAssetsFolderListBox()
        FBMessengerEventHandlers.UpdateAssetsFolderListBox()
        FBStoryEventHandlers.UpdateAssetsFolderListBox()
        FBPersonalPostEventHandlers.UpdateAssetsFolderListBox()
        FBReelsEventHandlers.UpdateAssetsFolderListBox()
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
                FBCommentAssetsDirectory,
                FBCustomizeCommentAssetsDirectory,
                FBResponseAssetsDirectory,
                FBMessengerAssetsDirectory,
                FBPersonalPostAssetsDirectory,
                FBReelsAssetsDirectory,
                DownloadedMediaResourcesAssetsDirectory,
                DownloadedImagesResourcesAssetsDirectory,
                DownloadedVideosResourcesAssetsDirectory
        }

        For Each myDir In myDirectories
            If Not Directory.Exists(myDir) Then
                Directory.CreateDirectory(myDir)
            End If
        Next

    End Sub


    Private Sub InitProfile()
        Try
            Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "profile.json")
            If Not File.Exists(filePath) Then
                Dim webview2AppProfile As New Webview2AppProfile() With {
                    .Version = appVersion,
                    .BuildDate = currentDate.ToString("yyyy-MM-dd")
                }
                Dim jsonString As String = JsonConvert.SerializeObject(webview2AppProfile, Formatting.Indented)
                ' 指定檔案路徑
                ' 將 JSON 字串寫入檔案
                File.WriteAllText(filePath, jsonString)
            End If


        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("寫入Profile檔錯誤")
        End Try

    End Sub

    Private Sub InitAppConfigsFile()

        Try
            ' 指定檔案路徑
            Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "appConfigs.json")
            If Not File.Exists(filePath) Then
                Dim appConfigs As New AppConfigs() With {
                    .AutoRun = False,
                    .AutoRunDelaySeconds = 15,
                    .ScheduledRun = False
                }
                Dim jsonString As String = JsonConvert.SerializeObject(appConfigs, Formatting.Indented)
                File.WriteAllText(filePath, jsonString)
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("寫入appConfigs檔案錯誤")
        End Try

    End Sub


    Public Class AppConfigs
        Public Property AutoRun As Boolean
        Public Property AutoRunDelaySeconds As Integer
        Public Property ScheduledRun As Boolean

    End Class

    Public Class Webview2AppProfile
        Public Property Version As String
        Public Property BuildDate As String

    End Class

End Module
