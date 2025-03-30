Imports System.IO
Imports Newtonsoft.Json
Imports SW2WinFormsApp.FBMarketplaceEventHandlers

Module AppInitModule

    ' app base 
    Public ReadOnly appBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public ReadOnly appConfigsDirectory As String = Path.Combine(appBaseDirectory, "appConfigs")

    ' UserData
    Public webivewUserDataDirectory As String = Path.Combine(appBaseDirectory, "WebviewUserData")
    Public availableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "available")
    Public unavailableUserDataDirectory As String = Path.Combine(webivewUserDataDirectory, "unavailable")

    ' Assets
    Public myAssetsDirectory As String = Path.Combine(appBaseDirectory, "myAssets")
    Public FBPostAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostAssets")
    Public FBMarketPlaceAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBMarketplaceAssets")
    Public FBPostShareURLAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPostShareURLAssets")
    Public FBCommentAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBCommentAssets")
    Public FBCustomizeCommentAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBCustomizeCommentAssets")
    Public FBResponseAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBResponseAssets")
    Public FBMessengerAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBMessengerAssets")
    Public FBStoryAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBStoryAssets")
    Public FBPersonalPostAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBPersonalPostAssets")
    Public FBReelsAssetsDirectory As String = Path.Combine(myAssetsDirectory, "FBReelsAssets")

    ' download media resources
    Public DownloadedMediaResourcesAssetsDirectory As String = Path.Combine(myAssetsDirectory, "DownloadedMediaResourcesAssets")
    Public DownloadedImagesResourcesAssetsDirectory As String = Path.Combine(DownloadedMediaResourcesAssetsDirectory, "images")
    Public DownloadedVideosResourcesAssetsDirectory As String = Path.Combine(DownloadedMediaResourcesAssetsDirectory, "videos")


    ' app configs
    Public ReadOnly versionNumber As String = "v1.1"
    ReadOnly currentDate As DateTime = DateTime.Today
    Public ReadOnly appVersion As String = currentDate.ToString("yyyyMMdd.") & versionNumber
    Public ReadOnly appUUID As String = Guid.NewGuid().ToString()




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


        PipeServerModule.StartPipeServer(appUUID, Form1)

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
            'If Not File.Exists(filePath) Then
            Dim webview2AppProfile As New Webview2AppProfile() With {
                    .Version = "20241211.v1.11",
                    .BuildDate = "2024-12-11",
                    .UUID = appUUID
                }
            Dim jsonString As String = JsonConvert.SerializeObject(webview2AppProfile, Formatting.Indented)
            ' 指定檔案路徑
            ' 將 JSON 字串寫入檔案
            File.WriteAllText(filePath, jsonString)
            'End If


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
                    .ScheduledRun = False,
                    .NumberOfRuns = 1
                }
                Dim jsonString As String = JsonConvert.SerializeObject(appConfigs, Formatting.Indented)
                File.WriteAllText(filePath, jsonString)
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("寫入appConfigs檔案錯誤")
        End Try

    End Sub

    Public Function GetAppConfigs()
        Try
            Dim appConfigs As New AppConfigs With {
                .AutoRun = False,
                .AutoRunDelaySeconds = 15,
                .ScheduledRun = False,
                .NumberOfRuns = 1
            }

            Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "appConfigs.json")
            ' Debug.WriteLine(filePath)
            ' 如果 profile.json 檔案存在，就讀取檔案並反序列化
            If File.Exists(filePath) Then
                Dim jsonString As String = File.ReadAllText(filePath)
                appConfigs = JsonConvert.DeserializeObject(Of AppConfigs)(jsonString)
            Else
                Dim jsonString As String = JsonConvert.SerializeObject(appConfigs, Formatting.Indented)
                File.WriteAllText(filePath, jsonString)
            End If

            Return appConfigs
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Class AppConfigs
        Public Property AutoRun As Boolean
        Public Property AutoRunDelaySeconds As Integer
        Public Property ScheduledRun As Boolean
        Public Property NumberOfRuns As Integer

    End Class

    Public Class Webview2AppProfile
        Public Property Version As String
        Public Property BuildDate As String
        Public Property UUID As String

    End Class

End Module
