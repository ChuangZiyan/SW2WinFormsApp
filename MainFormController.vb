Imports System.ComponentModel
Imports System.IO
Imports System.Net.Http
Imports System.Reflection.Metadata
Imports System.Reflection.PortableExecutable
Imports System.Security.Permissions
Imports System.Text.Json.Serialization
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
Imports SW2WinFormsApp.FBMarketplaceEventHandlers

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
        Form1.Text = "UserData: " & myUserData & "    Port: " & Webview2Controller.DebugPortInUse & "    |    " & status & "    - MainWebview2Form " & AppInitModule.appVersion
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
                line = line.Replace(vbCr, "").Replace(vbLf, "")
                writer.WriteLine(line)
            Next
        End Using

        For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
            If item.SubItems(12).Text = "略過" Then
                item.ForeColor = Color.LightGray
            End If
        Next

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


    Public Sub SetLiteMode(mode As String)
        Try
            Debug.WriteLine($"set LiteMode {mode}")

            Dim LiteModeComponentsSize As LiteModeComponents = ReadLiteModeComponentsJson()

            ' 隱藏所有元件
            'Form1.UserDataManager_Panel.Visible = False
            'Form1.FBUrlData_TabControl.Visible = False
            'Form1.ScriptTask_GroupBox.Visible = False
            'Form1.ScriptQueueManager_Panel.Visible = False
            'Form1.Action_TabControl.Visible = False
            'Form1.ShowEmojiPicker_Button.Visible = False
            'Form1.Main_WebView2_Panel.Visible = False

            If mode = "normal" Then
                ' 設定回原來大小
                Form1.Size = New Size(LiteModeComponentsSize.NormalModeSize.Width, LiteModeComponentsSize.NormalModeSize.Height)
                SetForm1ScrollPosition(LiteModeComponentsSize.NormalModeSize.PositionX, LiteModeComponentsSize.NormalModeSize.PositionY)

                ' 把webivew搬回原來位子然後
                'Form1.Main_WebView2_Panel.Location = New Point(1158, 531)

                ' 把script listview 搬回原來位子
                'Form1.ScriptQueueManager_Panel.Location = New Point(12, 663)


                ' 顯示所有元件
                'Form1.UserDataManager_Panel.Visible = True
                'Form1.FBUrlData_TabControl.Visible = True
                'Form1.ScriptTask_GroupBox.Visible = True
                'Form1.ScriptQueueManager_Panel.Visible = True
                'Form1.Action_TabControl.Visible = True
                'Form1.ShowEmojiPicker_Button.Visible = True
                'Form1.Main_WebView2_Panel.Visible = True


                ' Menu防呆
                'Form1.SetNormalMode_ToolStripMenuItem.Enabled = False
                'Form1.SetWebviewMode_ToolStripMenuItem.Enabled = True
                'Form1.SetScriptListViewMode_ToolStripMenuItem.Enabled = True

            ElseIf mode = "webview" Then
                ' 把webview搬到左上角然後顯示出來
                'Form1.Main_WebView2_Panel.Location = New Point(10, 25)
                'Form1.Size = New Size(725, 670)
                Form1.Size = New Size(LiteModeComponentsSize.WebviewLiteModeSize.Width, LiteModeComponentsSize.WebviewLiteModeSize.Height)
                SetForm1ScrollPosition(LiteModeComponentsSize.WebviewLiteModeSize.PositionX, LiteModeComponentsSize.WebviewLiteModeSize.PositionY)
                'Form1.Main_WebView2_Panel.Visible = True

                ' Menu防呆
                'Form1.SetNormalMode_ToolStripMenuItem.Enabled = True 
                'Form1.SetWebviewMode_ToolStripMenuItem.Enabled = False
                'Form1.SetScriptListViewMode_ToolStripMenuItem.Enabled = True

            ElseIf mode = "script_queue_listview" Then

                ' 把script listview搬到左上角
                'Form1.ScriptQueueManager_Panel.Location = New Point(10, 25)
                'Form1.Size = New Size(1180, 540)
                Form1.Size = New Size(LiteModeComponentsSize.ScriptListViewLiteModeSize.Width, LiteModeComponentsSize.ScriptListViewLiteModeSize.Height)
                SetForm1ScrollPosition(LiteModeComponentsSize.ScriptListViewLiteModeSize.PositionX, LiteModeComponentsSize.ScriptListViewLiteModeSize.PositionY)
                'Form1.ScriptQueueManager_Panel.Visible = True

                ' Menu防呆
                'Form1.SetNormalMode_ToolStripMenuItem.Enabled = True
                'Form1.SetWebviewMode_ToolStripMenuItem.Enabled = True
                'Form1.SetScriptListViewMode_ToolStripMenuItem.Enabled = False

            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("發生錯誤，可能是設定檔格式不正確，建議刪除設定檔後重試一次")

        End Try


    End Sub



    Function ReadLiteModeComponentsJson() As LiteModeComponents
        Try
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim filePath = Path.Combine(documentsPath, "LiteModeComponents.json")
            Debug.WriteLine(filePath)

            If Not File.Exists(filePath) Then
                ' 檔案不存在就寫入一個預設的
                WriteDefaultLiteModeComponentsJson()

            End If

            Dim jsonContent As String = File.ReadAllText(filePath)
            Return JsonConvert.DeserializeObject(Of LiteModeComponents)(jsonContent)
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        Return Nothing
    End Function


    Public Sub WriteDefaultLiteModeComponentsJson()

        Try
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim filePath = Path.Combine(documentsPath, "LiteModeComponents.json")

            ' 這個是偏移量，可以寫0
            Dim offset = 0


            ' 預設值
            Dim liteModeComponents As New LiteModeComponents() With {
                .NormalModeSize = New LiteModeComponentSize With {
                    .Width = 1900,
                    .Height = 1180,
                    .PositionX = 0,
                    .PositionY = 0
                },
                .WebviewLiteModeSize = New LiteModeComponentSize With {
                    .Width = Form1.Main_WebView2_Panel.Width + offset,
                    .Height = Form1.Main_WebView2_Panel.Height + offset,
                    .PositionX = 9999,
                    .PositionY = 9999
                },
                .ScriptListViewLiteModeSize = New LiteModeComponentSize With {
                    .Width = Form1.ScriptQueueManager_Panel.Width + offset,
                    .Height = Form1.ScriptQueueManager_Panel.Height + offset,
                    .PositionX = 0,
                    .PositionY = 9999
                }
            }


            ' 這個是抓螢幕放大比例
            Dim scaleVal = GetMonitorScale()


            ' 根據放大比例寫預設的大小跟滾動距離
            Select Case scaleVal
                ' 放大比例100%要用的數據，下面以此類推
                Case 100
                    liteModeComponents = New LiteModeComponents() With {
                        .NormalModeSize = New LiteModeComponentSize With {
                            .Width = 1900,
                            .Height = 1180,
                            .PositionX = 0,
                            .PositionY = 0
                        },
                        .WebviewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.Main_WebView2_Panel.Width + offset,
                            .Height = Form1.Main_WebView2_Panel.Height + offset,
                            .PositionX = 9999,
                            .PositionY = 9999
                        },
                        .ScriptListViewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.ScriptQueueManager_Panel.Width + offset,
                            .Height = Form1.ScriptQueueManager_Panel.Height + offset,
                            .PositionX = 0,
                            .PositionY = 9999
                        }
                    }
                Case 125
                    liteModeComponents = New LiteModeComponents() With {
                        .NormalModeSize = New LiteModeComponentSize With {
                            .Width = 1900,
                            .Height = 1180,
                            .PositionX = 0,
                            .PositionY = 0
                        },
                        .WebviewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.Main_WebView2_Panel.Width + offset,
                            .Height = Form1.Main_WebView2_Panel.Height + offset,
                            .PositionX = 9999,
                            .PositionY = 9999
                        },
                        .ScriptListViewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.ScriptQueueManager_Panel.Width + offset,
                            .Height = Form1.ScriptQueueManager_Panel.Height + offset,
                            .PositionX = 0,
                            .PositionY = 9999
                        }
                    }
                Case 150
                    liteModeComponents = New LiteModeComponents() With {
                        .NormalModeSize = New LiteModeComponentSize With {
                            .Width = 1900,
                            .Height = 1180,
                            .PositionX = 0,
                            .PositionY = 0
                        },
                        .WebviewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.Main_WebView2_Panel.Width + offset,
                            .Height = Form1.Main_WebView2_Panel.Height + offset,
                            .PositionX = 9999,
                            .PositionY = 9999
                        },
                        .ScriptListViewLiteModeSize = New LiteModeComponentSize With {
                            .Width = Form1.ScriptQueueManager_Panel.Width + offset,
                            .Height = Form1.ScriptQueueManager_Panel.Height + offset,
                            .PositionX = 0,
                            .PositionY = 9999
                        }
                    }

            End Select


            Dim jsonString As String = JsonConvert.SerializeObject(liteModeComponents, Formatting.Indented)
            ' 將 JSON 字串寫入檔案
            File.WriteAllText(filePath, jsonString)
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Private Sub SetForm1ScrollPosition(x As Integer, y As Integer)
        ' 設定卷軸位置
        Form1.AutoScrollPosition = New Point(x, y)
    End Sub

    Public Class LiteModeComponents
        Public Property NormalModeSize As LiteModeComponentSize
        Public Property WebviewLiteModeSize As LiteModeComponentSize
        Public Property ScriptListViewLiteModeSize As LiteModeComponentSize
    End Class


    Public Class LiteModeComponentSize

        Public Property Width As Integer
        Public Property Height As Integer

        Public Property PositionX As Integer
        Public Property PositionY As Integer

    End Class


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
