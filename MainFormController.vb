Imports System.IO
Imports System.Net.Http
Imports System.Reflection.Metadata
Imports System.Reflection.PortableExecutable
Imports System.Security.Permissions
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Module MainFormController

    Private Sub MsgBox(message)
        MessageBox.Show(message, "訊息")
    End Sub

    Public Sub UpdateWebviewUserDataCheckListBox()
        Form1.WebviewUserDataFolder_ListBox.Items.Clear()
        Form1.userData_ComboBox.Items.Clear()

        If Form1.FilterAvailableUserData_CheckBox.Checked = True Then
            Dim dirs As String() = Directory.GetDirectories(AppInitModule.availableUserDataDirectory)
            For Each dir As String In dirs
                Form1.WebviewUserDataFolder_ListBox.Items.Add("available" & "\" & Path.GetFileName(dir))
                '順便更新下面的userdata combox
                Form1.userData_ComboBox.Items.Add("available" & "\" & Path.GetFileName(dir))

            Next
        End If

        If Form1.FilterUnavailableUserData_CheckBox.Checked = True Then
            Dim dirs As String() = Directory.GetDirectories(AppInitModule.unavailableUserDataDirectory)
            For Each dir As String In dirs
                Form1.WebviewUserDataFolder_ListBox.Items.Add("unavailable" & "\" & Path.GetFileName(dir))
                '順便更新下面的userdata combox
                Form1.userData_ComboBox.Items.Add("unavailable" & "\" & Path.GetFileName(dir))
            Next
        End If


    End Sub



    Public Sub DisplayUserData(FolderName)
        If FolderName = "" Then
            Exit Sub
        End If

        Dim userDataJsonFilePath As String = Path.Combine(AppInitModule.webivewUserDataDirectory, FolderName, "myUserData.json")

        'Debug.WriteLine(userDataJsonFilePath)

        If File.Exists(userDataJsonFilePath) Then
            Dim jsonString As String = File.ReadAllText(userDataJsonFilePath)

            Dim userDataJson As UserDataStruct = JsonConvert.DeserializeObject(Of UserDataStruct)(jsonString)
            'Debug.WriteLine(userDataJson.Remark)
            Form1.FBAccount_TextBox.Text = userDataJson.FBAccount
            Form1.FBPassword_TextBox.Text = userDataJson.FBPassword
            Form1.FB2FA_TextBox.Text = userDataJson.FB2FA
            Form1.EmailAccount_TextBox.Text = userDataJson.EmailAccount
            Form1.EmailPassword_TextBox.Text = userDataJson.EmailPassword
            Form1.FBCookie_RichTextBox.Text = userDataJson.FBCookie
            Form1.Remark_RichTextBox.Text = userDataJson.Remark
        Else
            Form1.FBAccount_TextBox.Text = ""
            Form1.FBPassword_TextBox.Text = ""
            Form1.FB2FA_TextBox.Text = ""
            Form1.EmailAccount_TextBox.Text = ""
            Form1.EmailPassword_TextBox.Text = ""
            Form1.FBCookie_RichTextBox.Text = ""
            Form1.Remark_RichTextBox.Text = ""
        End If

    End Sub


    Public Sub DisplayGroupList(FolderName)
        If FolderName = "" Then
            Exit Sub
        End If

        Form1.FBGroups_ListView.Items.Clear()

        Form1.FBGroupName_TextBox.Text = ""
        Form1.FBGroupUrl_TextBox.Text = ""

        Dim groupListJsonFilePath As String = Path.Combine(AppInitModule.webivewUserDataDirectory, FolderName, "FBGroupList.json")

        'Debug.WriteLine(userDataJsonFilePath)

        If File.Exists(groupListJsonFilePath) Then
            Dim jsonString As String = File.ReadAllText(groupListJsonFilePath)

            'Dim groupListDataJson As GroupListviewDataStruct = JsonConvert.DeserializeObject(Of GroupListviewDataStruct)(jsonString)
            'Debug.WriteLine(userDataJson.Remark)

            Dim jsonArray As JArray = JArray.Parse(jsonString)

            ' 使用 For Each 迴圈逐個處理每個項目
            For Each item As JObject In jsonArray
                Dim name As String = item("Name").ToString()
                Dim url As String = item("Url").ToString()

                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBGroups_ListView.Items.Add(newItem)

            Next

        End If

    End Sub

    Public Sub DisplayFBActivityLogs(FolderName)
        If FolderName = "" Then
            Exit Sub
        End If

        Form1.FBActivityLogs_ListView.Items.Clear()

        Form1.FBActivityLogsGroupName_TextBox.Text = ""
        Form1.FBActivityLogsGroupURL_TextBox.Text = ""

        Dim activityLogGroupListJsonFilePath As String = Path.Combine(AppInitModule.webivewUserDataDirectory, FolderName, "FBActivityLogList.json")

        'Debug.WriteLine(userDataJsonFilePath)

        If File.Exists(activityLogGroupListJsonFilePath) Then
            Dim jsonString As String = File.ReadAllText(activityLogGroupListJsonFilePath)

            Dim jsonArray As JArray = JArray.Parse(jsonString)

            ' 使用 For Each 迴圈逐個處理每個項目
            For Each item As JObject In jsonArray
                Dim name As String = item("Name").ToString()
                Dim url As String = item("Url").ToString()

                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBActivityLogs_ListView.Items.Add(newItem)

            Next

        End If

    End Sub


    Public Sub DisplayFBNotificationList(FolderName)
        If FolderName = "" Then
            Exit Sub
        End If

        Form1.FBNotificationsData_Listview.Items.Clear()

        Form1.FBNotificationsName_TextBox.Text = ""
        Form1.FBNotificationsUrl_TextBox.Text = ""

        Dim jsonFilePath As String = Path.Combine(AppInitModule.webivewUserDataDirectory, FolderName, "FBNotificationList.json")

        'Debug.WriteLine(userDataJsonFilePath)

        If File.Exists(jsonFilePath) Then
            Dim jsonString As String = File.ReadAllText(jsonFilePath)

            Dim jsonArray As JArray = JArray.Parse(jsonString)

            ' 使用 For Each 迴圈逐個處理每個項目
            For Each item As JObject In jsonArray
                Dim name As String = item("Name").ToString()
                Dim url As String = item("Url").ToString()

                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBNotificationsData_Listview.Items.Add(newItem)
            Next

        End If
    End Sub

    Public Sub DisplayFBMessengerList(FolderName)
        If FolderName = "" Then
            Exit Sub
        End If

        Form1.FBMessengerData_Listview.Items.Clear()

        Form1.FBMessengerName_TextBox.Text = ""
        Form1.FBMessengerUrl_TextBox.Text = ""

        Dim jsonFilePath As String = Path.Combine(AppInitModule.webivewUserDataDirectory, FolderName, "FBMessengerList.json")


        If File.Exists(jsonFilePath) Then
            Dim jsonString As String = File.ReadAllText(jsonFilePath)

            Dim jsonArray As JArray = JArray.Parse(jsonString)

            ' 使用 For Each 迴圈逐個處理每個項目
            For Each item As JObject In jsonArray
                Dim name As String = item("Name").ToString()
                Dim url As String = item("Url").ToString()

                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBMessengerData_Listview.Items.Add(newItem)
            Next

        End If
    End Sub


    Public Sub SetForm1TitleStatus(status As String)
        Dim myUserData = Webview2Controller.ActivedWebview2UserData
        Form1.Text = "UserData: " & myUserData & "    Port: " & Webview2Controller.DebugPortInUse & "    |    " & status & "    - MainWebview2Form"
    End Sub




    Public Sub ResetListviewItemsBackgroundColor(lv)

        For Each item As ListViewItem In lv.Items
            item.BackColor = Color.White
            item.ForeColor = Color.Black
        Next

    End Sub



    Public Sub SaveScriptListViewToFile()

        Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "scriptListviewData.txt")
        Using writer As New StreamWriter(filePath)
            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
                If item.SubItems(2).Text.Contains("隨機") Then
                    item.SubItems(2).Text = "隨機"
                End If

                If item.SubItems(3).Text.Contains("隨機") Then
                    item.SubItems(3).Text = "隨機"
                End If

                item.SubItems(6).Text = ""
                item.SubItems(7).Text = "0"
                item.SubItems(8).Text = "0"
                item.SubItems(9).Text = "0"
                item.SubItems(10).Text = "0"
                Dim subItemTexts As New List(Of String)()
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    subItemTexts.Add(subItem.Text)
                Next
                Dim line As String = String.Join("&nbsp;", subItemTexts)
                'Dim line As String = String.Join("&nbsp;", item.SubItems.Cast(Of ListViewItem.ListViewSubItem).Select(Function(subItem) subItem.Text))
                writer.WriteLine(line)
            Next
        End Using
    End Sub

    Public Sub LoadFileToScriptListview()
        Try
            Form1.ScriptQueue_ListView.Items.Clear()

            Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "scriptListviewData.txt")

            If File.Exists(filePath) Then
                ' 如果檔案是空的就跳過
                If New FileInfo(filePath).Length = 0 Then
                    Return
                End If

                Using reader As New StreamReader(filePath)
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()
                        Dim values As String() = line.Split("&nbsp;")
                        Dim listViewItem As New ListViewItem(values(0))
                        For i As Integer = 1 To values.Length - 1
                            listViewItem.SubItems.Add(values(i))
                        Next

                        '加回去listview
                        Form1.ScriptQueue_ListView.Items.Add(listViewItem)
                    End While
                End Using
            End If

            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
                If item.SubItems(12).Text = "略過" Then
                    item.ForeColor = Color.LightGray
                End If
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Function GetRandomAssetFolder(content As String, targetDirectory As String)

        Try
            Dim myAssetFolderPath As String = Nothing
            Dim rand As New Random()

            If content = "隨機" Then
                Dim directoryPath As String = Path.Combine()

                ' 獲取目錄下所有的子資料夾
                Dim directories As String() = Directory.GetDirectories(targetDirectory)
                If directories.Length > 0 Then

                    Dim randomIndex As Integer = rand.Next(0, directories.Length)
                    myAssetFolderPath = directories(randomIndex)

                    'Debug.WriteLine("隨機選取的資料夾: " & myAssetFolderPath)
                Else
                    Debug.WriteLine("該目錄下沒有資料夾")
                End If

            Else
                Dim directories = Split(content, "&")
                Dim randomIndex As Integer = rand.Next(0, directories.Length)
                myAssetFolderPath = Path.Combine(targetDirectory, directories(randomIndex))
            End If
            Return myAssetFolderPath
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function GetRandomFBUrlData(type As String, userDataFolderPath As String) As JToken
        Try
            Dim fileName As String = Nothing
            Select Case type
                Case "發帖"
                    fileName = "FBGroupList.json"
                Case "留言"
                    fileName = "FBActivityLogList.json"
                Case "訊息"
                    fileName = "FBMessengerList.json"
            End Select

            Dim filePath = Path.Combine(userDataFolderPath, fileName)

            If File.Exists(filePath) Then
                Dim jsonString As String = File.ReadAllText(filePath)
                Dim jsonArray As JArray = JArray.Parse(jsonString)

                Dim rnd As New Random()
                Dim randomIndex As Integer = rnd.Next(0, jsonArray.Count)
                Dim randomItem As JToken = jsonArray(randomIndex)

                'Debug.WriteLine("Name : " & randomItem("Name").ToString)
                'Debug.WriteLine("URL : " & randomItem("Url").ToString)

                Return randomItem
            End If

            Return Nothing
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return Nothing
        End Try

    End Function


    Public Sub EnabledAllExecutionButton(flag As Boolean)
        Form1.ExecutionScriptQueue_Button.Enabled = flag
        Form1.ExecuteSelectedScriptListviewItem_Button.Enabled = flag
        Form1.PauseScriptExecution_Button.Enabled = flag
        Form1.ContinueScriptExecution_Button.Enabled = flag
        Form1.ScheduledExecutionScriptQueue_Button.Enabled = flag
        Form1.StopScheduledExecutionScriptQueue_Button.Enabled = flag
        Form1.ExecutionScriptQueue_Button.Enabled = flag
        Form1.ScheduledExecutionScriptQueue_Button.Enabled = flag

    End Sub


    Public Sub CenterSelectedItem(listview As Object, selectedItem As ListViewItem)
        Try
            If selectedItem IsNot Nothing Then
                selectedItem.EnsureVisible()
                Dim visibleItemsCount As Integer = listview.ClientSize.Height \ listview.Items(0).Bounds.Height
                Dim topIndex As Integer = Math.Max(selectedItem.Index - visibleItemsCount \ 2, 0)
                listview.TopItem = listview.Items(topIndex)
            End If
        Catch ex As Exception
            Debug.WriteLine("ex")
        End Try

    End Sub

    Public Async Function DownloadAllMediaFromPageAsync() As Task
        Try

            ' 抓取圖片的 src 屬性
            Dim imageElements = edgeDriver.FindElements(By.TagName("img"))
            Dim imageUrls As New List(Of String)
            For Each imageElement In imageElements
                Dim imageUrl = imageElement.GetAttribute("src")
                If Not String.IsNullOrEmpty(imageUrl) Then
                    imageUrls.Add(imageUrl)
                End If
            Next

            ' 抓取影片的 src 屬性
            Dim videoElements = edgeDriver.FindElements(By.TagName("video"))
            Dim videoUrls As New List(Of String)
            For Each videoElement In videoElements
                Dim videoUrl = videoElement.GetAttribute("src")
                If Not String.IsNullOrEmpty(videoUrl) Then
                    videoUrls.Add(videoUrl)
                End If
            Next

            ' 使用 HttpClient 下載圖片和影片
            Dim downloadTasks As New List(Of Task)
            Using httpClient As New HttpClient()

                ' 下載圖片到 images 資料夾
                For Each imageUrl In imageUrls
                    Dim fileName = Path.Combine(AppInitModule.DownloadedImagesResourcesAssetsDirectory, "image_" & Guid.NewGuid().ToString() & ".jpg")
                    Dim isLargeEnough = Await IsFileLargerThan1KB(httpClient, imageUrl)
                    If isLargeEnough Then
                        downloadTasks.Add(DownloadFileAsync(httpClient, imageUrl, fileName))
                    Else
                        Console.WriteLine("圖片太小，跳過下載：" & imageUrl)
                    End If

                Next

                ' 下載影片到 videos 資料夾
                For Each videoUrl In videoUrls
                    Dim fileName = Path.Combine(AppInitModule.DownloadedVideosResourcesAssetsDirectory, "video_" & Guid.NewGuid().ToString() & ".mp4")
                    downloadTasks.Add(DownloadFileAsync(httpClient, videoUrl, fileName))
                Next

                ' 等待所有下載完成
                Await Task.WhenAll(downloadTasks)
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try



    End Function

    Private Async Function IsFileLargerThan1KB(httpClient As HttpClient, url As String) As Task(Of Boolean)
        Try
            Dim request = New HttpRequestMessage(HttpMethod.Head, url)
            Dim response = Await httpClient.SendAsync(request)
            If response.IsSuccessStatusCode AndAlso response.Content.Headers.ContentLength.HasValue Then
                Return response.Content.Headers.ContentLength.Value > 1024 ' 1 KB = 1024 Bytes
            End If
        Catch ex As Exception
            Console.WriteLine("無法檢查大小：" & url & " 錯誤訊息：" & ex.Message)
        End Try
        Return False
    End Function




    Public Class GroupListviewDataStruct
        Public Property Name As String
        Public Property Url As String

    End Class

    Public Class UserDataStruct
        Public Property FBAccount As String
        Public Property FBPassword As String
        Public Property EmailAccount As String
        Public Property EmailPassword As String
        Public Property FB2FA As String
        Public Property FBCookie As String
        Public Property Remark As String

    End Class

End Module
