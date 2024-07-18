Imports System.IO

Module MainFormController


    Private Sub MsgBox(message)
        MessageBox.Show(message, "訊息")
    End Sub

    Public Sub UpdateWebviewProfileCheckListBox()
        Form1.WebviewProfile_CheckedListBox.Items.Clear()
        Dim dirs As String() = Directory.GetDirectories(AppInitModule.webivewProfileDirectory)
        For Each dir As String In dirs
            Form1.WebviewProfile_CheckedListBox.Items.Add(Path.GetFileName(dir))
        Next

    End Sub

    Public Sub CreateProfileFolder(folderName As String)
        Try
            Dim folderPath = Path.Combine(AppInitModule.webivewProfileDirectory, folderName)

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
                UpdateWebviewProfileCheckListBox()
                Form1.ProfileFolderName_TextBox.Clear()
                MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub

    Public Sub DeleteProfileFolder(folderName As String)

        Try
            If folderName = "" Then
                MsgBox("未選擇資料夾")
                Exit Sub
            End If

            Dim folderPath = Path.Combine(AppInitModule.webivewProfileDirectory, folderName)

            If Directory.Exists(folderPath) Then
                Dim result As DialogResult = MessageBox.Show("確定要刪除此資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Directory.Delete(folderPath, True)
                    UpdateWebviewProfileCheckListBox()
                    MsgBox("資料夾已成功刪除")
                End If
            Else
                MsgBox("資料夾不存在")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除資料夾失敗")
        End Try

    End Sub


End Module
