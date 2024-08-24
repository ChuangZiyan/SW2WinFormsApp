Imports System.IO
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


    Public Sub CreateUserDataFolder(folderName As String)
        Try
            Dim folderPath = Path.Combine(AppInitModule.availableUserDataDirectory, folderName)

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
                UpdateWebviewUserDataCheckListBox()
                Form1.UserDataFolderName_TextBox.Clear()
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub



    Public Sub SaveUserData(folderName As String)
        Try
            If folderName = "" Then
                MsgBox("未選擇資料夾")
                Exit Sub
            End If

            Dim userDataFilePath = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName, "myUserData.json")

            Dim userDataStruct As New UserDataStruct With {
                .FBAccount = Form1.FBAccount_TextBox.Text,
                .FBPassword = Form1.FBPassword_TextBox.Text,
                .FB2FA = Form1.FB2FA_TextBox.Text,
                .EmailAccount = Form1.EmailAccount_TextBox.Text,
                .EmailPassword = Form1.EmailPassword_TextBox.Text,
                .FBCookie = Form1.FBCookie_RichTextBox.Text,
                .Remark = Form1.Remark_RichTextBox.Text
            }

            Dim jsonString As String = JsonConvert.SerializeObject(userDataStruct, Formatting.Indented)

            File.WriteAllText(userDataFilePath, jsonString)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub


    Public Async Sub MoveUserDataFolder()
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItems.Count <> 0 Then

                For Each item As String In Form1.WebviewUserDataFolder_ListBox.SelectedItems
                    'Debug.WriteLine("item : " & item)
                    Dim myFolders = Split(item, "\")
                    Dim folderPath = Path.Combine(AppInitModule.webivewUserDataDirectory, myFolders(0), myFolders(1))
                    If myFolders(1) = Webview2Controller.ActivedWebview2UserData Then
                        Await ResetWebview2()
                        'Debug.WriteLine("after reset")
                        Await Delay_msec(200)
                    End If

                    If myFolders(0) = "available" Then ' move to unavailable
                        Dim destinationPath = Path.Combine(AppInitModule.webivewUserDataDirectory, "unavailable", myFolders(1))
                        Directory.Move(folderPath, destinationPath)
                    ElseIf myFolders(0) = "unavailable" Then ' move to unavailable
                        Dim destinationPath = Path.Combine(AppInitModule.webivewUserDataDirectory, "available", myFolders(1))
                        Directory.Move(folderPath, destinationPath)
                    End If
                Next
                UpdateWebviewUserDataCheckListBox()

            Else
                MsgBox("未選擇任何資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("移動失敗")
        End Try



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


    Public Sub SetForm1TitleStatus(status As String)
        Dim myUserData = Webview2Controller.ActivedWebview2UserData
        Form1.Text = "UserData: " & myUserData & "    Port: " & Webview2Controller.DebugPortInUse & "    |    " & status & "    - MainWebview2Form"
    End Sub


    Public Sub SaveGroupListviewData()
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                MsgBox("未選擇使用者")
                Exit Sub
            End If

            Dim items As New List(Of GroupListviewDataStruct)()

            For Each item As ListViewItem In Form1.FBGroups_ListView.Items

                'Debug.WriteLine("item: " & item.Text)
                'Debug.WriteLine("itemsub: " & item.SubItems(1).Text)

                Dim listViewItemData As New GroupListviewDataStruct With {
                    .Name = item.Text,
                    .Url = item.SubItems(1).Text
                }
                items.Add(listViewItemData)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(items, Formatting.Indented)

            'Debug.WriteLine(jsonStr)
            Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBGroupList.json")
            'Debug.WriteLine(filePath)
            'Debug.WriteLine(Webview2Controller.ActivedUserDataFolderPath)
            File.WriteAllText(filePath, jsonStr)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try


    End Sub

    Public Sub DisplaySelectedGroup()
        Try
            If Form1.FBGroups_ListView.SelectedItems.Count > 0 Then
                'Debug.WriteLine(Form1.FBGroups_ListView.SelectedItems(0).Text)
                Dim selectedItem = Form1.FBGroups_ListView.SelectedItems(0)
                Form1.FBGroupName_TextBox.Text = selectedItem.Text
                Form1.FBGroupUrl_TextBox.Text = selectedItem.SubItems(1).Text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub AddNewGroupDataToGroupListview()
        Try
            Dim name = Form1.FBGroupName_TextBox.Text
            Dim url = Form1.FBGroupUrl_TextBox.Text

            If name <> "" And url <> "" Then
                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBGroups_ListView.Items.Insert(0, newItem)
            Else
                MsgBox("欄位不得為空")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try


    End Sub


    Public Sub EditSelectedGroupListviewItem()
        Try
            If Form1.FBGroups_ListView.SelectedItems.Count > 0 Then
                Dim name = Form1.FBGroupName_TextBox.Text
                Dim url = Form1.FBGroupUrl_TextBox.Text
                If name <> "" And url <> "" Then
                    Dim selectedItem = Form1.FBGroups_ListView.SelectedItems(0)
                    selectedItem.Text = name
                    selectedItem.SubItems(1).Text = url

                Else
                    MsgBox("欄位不得為空")
                End If
            Else
                MsgBox("未選擇欄位")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub DeleteSelectedGroupList()
        Try
            Dim selectedItems = Form1.FBGroups_ListView.SelectedItems
            If selectedItems.Count > 0 Then
                For i As Integer = selectedItems.Count - 1 To 0 Step -1
                    Form1.FBGroups_ListView.Items.Remove(selectedItems(i))
                Next
            Else


                If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                    MsgBox("未選擇使用者")
                    Exit Sub
                End If

                Dim result As DialogResult = MessageBox.Show("確定要刪除社團列表檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBGroupList.json")

                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                        Form1.FBGroups_ListView.Items.Clear()
                        MsgBox("刪除完成")
                    Else
                        MsgBox("檔案不存在")
                    End If

                End If

            End If
        Catch ex As Exception
            MsgBox("刪除失敗")
            Debug.WriteLine(ex)
        End Try

    End Sub



    Public Sub UpdateAssetsFolderListBox()
        Try
            Form1.MyAssetsFolder_ListBox.Items.Clear()

            Dim dirs As String() = Directory.GetDirectories(AppInitModule.myAssetsDirectory)
            For Each dir As String In dirs
                Form1.MyAssetsFolder_ListBox.Items.Add(Path.GetFileName(dir))
            Next
            Form1.MediaSelector_ListBox.Items.Clear()
            Form1.TextFileSelector_ListBox.Items.Clear()
            Form1.NewAssetFolderName_TextBox.Clear()
            Form1.PreviewTextFile_RichTextBox.Clear()
            Form1.MediaPreview_PictureBox.ImageLocation = Nothing

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub CreateNewAssetFolder(folderName As String)
        Try
            Dim folderPath = Path.Combine(AppInitModule.myAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
                Directory.CreateDirectory(Path.Combine(folderPath, "textFiles"))
                Directory.CreateDirectory(Path.Combine(folderPath, "media"))

                UpdateAssetsFolderListBox()
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub


    Public Sub DeletedSelectedAssetFolders()
        Try

            Dim selectedItems = Form1.MyAssetsFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In selectedItems
                        Dim folderPath = Path.Combine(AppInitModule.myAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next

                    UpdateAssetsFolderListBox()
                    MsgBox("刪除完成")
                End If
            Else
                MsgBox("未選擇要刪除的資料夾")
            End If


        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除失敗")
        End Try

    End Sub


    Public Sub UpdateTextFileSelectorListBoxItems(folderName As String)
        Try
            Form1.TextFileSelector_ListBox.Items.Clear()
            Form1.PreviewTextFile_RichTextBox.Clear()
            Dim textFileFolder = Path.Combine(AppInitModule.myAssetsDirectory, folderName, "textFiles")
            If Directory.Exists(textFileFolder) Then
                Dim textFiles As String() = Directory.GetFiles(textFileFolder, "*.txt")
                For Each file As String In textFiles
                    Form1.TextFileSelector_ListBox.Items.Add(Path.GetFileName(file))
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub UpdateMediaSelectorListBoxItems(folderName As String)
        Try
            Form1.MediaSelector_ListBox.Items.Clear()
            Form1.MediaPreview_PictureBox.ImageLocation = Nothing
            Dim mediaFolder = Path.Combine(AppInitModule.myAssetsDirectory, folderName, "media")
            If Directory.Exists(mediaFolder) Then
                Dim allowedExtension As String() = {".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".mp4", ".MP4"}
                Dim mediaFiles As String() = Directory.GetFiles(mediaFolder)
                For Each file As String In mediaFiles
                    If allowedExtension.Contains(Path.GetExtension(file)) Then
                        Form1.MediaSelector_ListBox.Items.Add(Path.GetFileName(file))
                    End If

                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub



    Public Sub DisplayFBWritePostWaitSeconds(folderName)
        Try
            Dim configFilePath = Path.Combine(AppInitModule.myAssetsDirectory, folderName, "FBWritePostWaitSecondsConfig.txt")
            If File.Exists(configFilePath) Then
                Debug.WriteLine("######")
                Dim myText = File.ReadAllText(configFilePath)
                Form1.FBWritePostUploadWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(0))
                Form1.FBWritePostSubmitWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(1))

            Else
                Debug.WriteLine("#!!!!!")
                File.WriteAllText(configFilePath, "30,30")
                Form1.FBWritePostUploadWaitSeconds_NumericUpDown.Value = 30
                Form1.FBWritePostSubmitWaitSeconds_NumericUpDown.Value = 30
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub



    Public Sub PreviewTextFileToRichTextBox(fileName As String)

        Try
            Form1.PreviewTextFile_RichTextBox.Clear()
            Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", fileName)
            Dim text = File.ReadAllText(filePath)
            Form1.PreviewTextFile_RichTextBox.Text = text
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub PreviewMediaToPictureBox(fileName As String)
        Try
            Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", fileName)
            'Debug.WriteLine("img" & filePath)
            Form1.MediaPreview_PictureBox.ImageLocation = filePath
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub CreateNewTextFile(fileName As String)
        Try
            'Debug.WriteLine("filename : " & fileName)
            'Debug.WriteLine("Form1.MyAssetsFolder_ListBox.SelectedItem:" & Form1.MyAssetsFolder_ListBox.SelectedItem)
            If String.IsNullOrEmpty(fileName) Then
                MsgBox("不合法檔案名稱")
                Exit Sub
            End If
            If Form1.MyAssetsFolder_ListBox.SelectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", fileName & ".txt")
                If File.Exists(filePath) Then
                    MsgBox("已有相同檔案名稱")
                    Exit Sub
                End If
                MyWriteFile(filePath)
                Form1.NewTextFileName_TextBox.Clear()
                UpdateTextFileSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)

            Else
                MsgBox("未選擇資料夾")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("建立文字檔失敗，檔名也許不合法")
        End Try

    End Sub


    Public Sub SaveEditedTextFile(fileName As String)
        Try
            Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", fileName)
            MyWriteFile(filePath)
            MsgBox("修改成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Private Sub MyWriteFile(filePath As String)
        Try
            Debug.WriteLine("path : " & filePath)
            Using writer As New StreamWriter(filePath)

                ' BMP pattern
                Dim pattern_BMP As String = "[\uD800-\uDBFF][\uDC00-\uDFFF]"
                ' remove non BMP char
                Dim inputString = Form1.PreviewTextFile_RichTextBox.Text
                Dim resultString As String = Regex.Replace(inputString, pattern_BMP, "")
                writer.Write(resultString)
                Form1.PreviewTextFile_RichTextBox.Text = resultString
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub



    Public Sub ResetScriptQueueListviewItemsBackgroundColor()

        For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
            item.BackColor = Color.White
            item.ForeColor = Color.Black
        Next

    End Sub



    Public Sub SaveScriptListViewToFile()

        Dim filePath As String = Path.Combine(AppInitModule.appConfigsDirectory, "scriptListviewData.txt")
        Using writer As New StreamWriter(filePath)
            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
                item.SubItems(8).Text = "0"
                item.SubItems(9).Text = "0"
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
                If item.SubItems(11).Text = "略過" Then
                    item.ForeColor = Color.LightGray
                End If
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Function GetRandomAssetFolder(content As String)

        Try
            Dim myAssetFolderPath As String = Nothing
            content = content.Replace("資料夾=", "")
            Dim rand As New Random()

            If content = "隨機" Then
                Dim directoryPath As String = Path.Combine()

                ' 獲取目錄下所有的子資料夾
                Dim directories As String() = Directory.GetDirectories(AppInitModule.myAssetsDirectory)
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
                myAssetFolderPath = Path.Combine(AppInitModule.myAssetsDirectory, directories(randomIndex))
            End If
            Return myAssetFolderPath
        Catch ex As Exception
            Return False
        End Try

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
