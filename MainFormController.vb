Imports System.IO
Imports Newtonsoft.Json

Module MainFormController


    Private Sub MsgBox(message)
        MessageBox.Show(message, "訊息")
    End Sub

    Public Sub UpdateWebviewUserDataCheckListBox()
        Form1.WebviewUserDataFolder_ListBox.Items.Clear()

        If Form1.FilterAvailableUserData_CheckBox.Checked = True Then
            Dim dirs As String() = Directory.GetDirectories(AppInitModule.availableUserDataDirectory)
            For Each dir As String In dirs
                Form1.WebviewUserDataFolder_ListBox.Items.Add("available" & "\" & Path.GetFileName(dir))
            Next
        End If

        If Form1.FilterUnavailableUserData_CheckBox.Checked = True Then
            Dim dirs As String() = Directory.GetDirectories(AppInitModule.unavailableUserDataDirectory)
            For Each dir As String In dirs
                Form1.WebviewUserDataFolder_ListBox.Items.Add("unavailable" & "\" & Path.GetFileName(dir))
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

    Public Async Sub DeleteUserDataFolders()

        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItems.Count <> 0 Then
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    MainFormController.SetForm1TitleStatus("刪除中...")
                    For Each item As String In Form1.WebviewUserDataFolder_ListBox.SelectedItems
                        'Debug.WriteLine("item : " & item)
                        'Debug.WriteLine("curr : " & Webview2Controller.ActivedWebview2UserData)
                        If Split(item, "\")(1) = Webview2Controller.ActivedWebview2UserData Then
                            Await ResetWebview2()
                            Debug.WriteLine("after reset")
                            Await Delay_msec(200)
                        End If
                        Dim myFolders = Split(item, "\")
                        Dim folderPath = Path.Combine(AppInitModule.webivewUserDataDirectory, myFolders(0), myFolders(1))
                        Directory.Delete(folderPath, True)
                    Next
                    UpdateWebviewUserDataCheckListBox()
                    MainFormController.SetForm1TitleStatus("完成")
                    MsgBox("刪除完成")
                End If
            Else
                MsgBox("未選擇任何資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除資料夾失敗")
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
                        Debug.WriteLine("after reset")
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


    Public Sub SetForm1TitleStatus(status As String)
        Dim myUserData = Webview2Controller.ActivedWebview2UserData
        Form1.Text = "UserData: " & myUserData & "    Port: " & Webview2Controller.DebugPortInUse & "    |    " & status & "    - MainWebview2Form"
    End Sub



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
