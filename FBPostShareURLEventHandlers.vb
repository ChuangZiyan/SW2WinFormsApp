Imports System.IO
Imports Newtonsoft.Json
Imports SW2WinFormsApp.FBMarketplaceEventHandlers

Public Class FBPostShareURLEventHandlers

    Public Sub FBPostShareURLCreateNewAssetFolder_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim folderName As String = Form1.FBPostShareURLAssetFolderName_TextBox.Text
            Dim folderPath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) And Not folderName.Contains("&"c) Then
                Directory.CreateDirectory(folderPath)
                Directory.CreateDirectory(Path.Combine(folderPath, "textFiles"))
                File.WriteAllText(Path.Combine(folderPath, "myBaseURL.txt"), "")
                UpdatePostShareURLAssetsFolderListBox()

                '新增後直接選擇該資料夾
                Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem = folderName
                Form1.FBPostShareURLAssetFolderName_TextBox.Clear()
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub
    Public Sub FBPostShareURLAssetFolder_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Try
            Dim foldPath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem)

            If Path.Exists(foldPath) Then
                Process.Start("Explorer", foldPath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Shared Sub UpdatePostShareURLAssetsFolderListBox()
        Try
            Form1.FBPostShareURLAssetFolder_ListBox.Items.Clear()

            Dim dirs As String() = Directory.GetDirectories(AppInitModule.FBPostShareURLAssetsDirectory)
            For Each dir As String In dirs
                Form1.FBPostShareURLAssetFolder_ListBox.Items.Add(Path.GetFileName(dir))
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPostShareURLDeselectAllAssetFolderListboxItems_Button_Click(sender As Object, e As EventArgs)
        Form1.FBPostShareURLAssetFolder_ListBox.ClearSelected()
        ClearFBPostShareURLData()

    End Sub


    Public Sub FBPostShareURLDeleteSelectedAssetFolder_Button_Click(sender As Object, e As EventArgs)
        Try

            Dim selectedItems = Form1.FBPostShareURLAssetFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In selectedItems
                        Dim folderPath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdatePostShareURLAssetsFolderListBox()
                    MsgBox("刪除完成")
                End If
            Else
                ' 刪除全部資料夾
                'MsgBox("未選擇要刪除的資料夾")
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.FBPostShareURLAssetFolder_ListBox.Items
                        Dim folderPath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdatePostShareURLAssetsFolderListBox()

                    MsgBox("刪除完成")
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除失敗")
        End Try
    End Sub


    Public Sub FBPostShareURLCreateNewTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            'Debug.WriteLine("filename : " & fileName)
            'Debug.WriteLine("Form1.MyAssetsFolder_ListBox.SelectedItem:" & Form1.MyAssetsFolder_ListBox.SelectedItem)
            Dim fileName = Form1.FBPostShareURLTextFileName_TextBox.Text
            If String.IsNullOrEmpty(fileName) Then
                MsgBox("不合法檔案名稱")
                Exit Sub
            End If
            If Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem, "textFiles", fileName & ".txt")
                If File.Exists(filePath) Then
                    MsgBox("已有相同檔案名稱")
                    Exit Sub
                End If

                UtilsModule.MyWriteFile(Form1.FBPostShareURLTextFilePreviewer_RichTextBox.Text, filePath)
                Form1.FBPostShareURLTextFileName_TextBox.Clear()
                UpdateTextFileSelectorListBoxItems(Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem)
            Else
                MsgBox("未選擇資料夾")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("建立文字檔失敗，檔名也許不合法")
        End Try
    End Sub

    Public Sub FBPostShareURLDeleteSelectedTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBPostShareURLTextFile_ListBox.SelectedItems


            If selectedItems.Count > 0 Then
                ' 刪掉選擇的
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        Dim textFilePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If
            Else
                ' 刪掉全部
                'MsgBox("未選擇要刪除的檔案")
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.FBPostShareURLTextFile_ListBox.Items
                        Dim textFilePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If

            End If

            UpdateTextFileSelectorListBoxItems(Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Private Sub UpdateTextFileSelectorListBoxItems(folderName As String)
        Try
            Form1.FBPostShareURLTextFile_ListBox.Items.Clear()
            Form1.FBPostShareURLTextFilePreviewer_RichTextBox.Clear()
            Dim textFileFolder = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, folderName, "textFiles")
            If Directory.Exists(textFileFolder) Then
                Dim textFiles As String() = Directory.GetFiles(textFileFolder, "*.txt")
                For Each file As String In textFiles
                    Form1.FBPostShareURLTextFile_ListBox.Items.Add(Path.GetFileName(file))
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub FBPostShareURLAssetFolder_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        ClearFBPostShareURLData()
        Dim selectedItem = Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            UpdateTextFileSelectorListBoxItems(selectedItem)
            DisplayFBWritePostWaitSeconds(selectedItem)
            ' display base url
            Dim myBaseURLFilePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, selectedItem, "myBaseURL.txt")
            If File.Exists(myBaseURLFilePath) Then
                Form1.FBPostShareURLBaseURL_TextBox.Text = File.ReadAllText(myBaseURLFilePath)
            End If
        End If

    End Sub


    Private Sub ClearFBPostShareURLData()
        Form1.FBPostShareURLBaseURL_TextBox.Clear()
        Form1.FBPostShareURLUploadWaitSeconds_NumericUpDown.Value = 0
        Form1.FBPostShareURLSubmitWaitSeconds_NumericUpDown.Value = 0
    End Sub

    Private Sub DisplayFBWritePostWaitSeconds(folderName)
        Try
            Dim configFilePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, folderName, "FBPostShareURLWaitSecondsConfig.txt")
            If File.Exists(configFilePath) Then
                Dim myText = File.ReadAllText(configFilePath)
                Form1.FBPostShareURLUploadWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(0))
                Form1.FBPostShareURLSubmitWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(1))

            Else
                File.WriteAllText(configFilePath, "30,30")
                Form1.FBPostShareURLUploadWaitSeconds_NumericUpDown.Value = 30
                Form1.FBPostShareURLSubmitWaitSeconds_NumericUpDown.Value = 30
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBPostShareURLTextFile_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.FBPostShareURLTextFile_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Form1.FBPostShareURLTextFilePreviewer_RichTextBox.Clear()
                Dim filePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem, "textFiles", selectedItem)
                Dim text = File.ReadAllText(filePath)
                Form1.FBPostShareURLTextFilePreviewer_RichTextBox.Text = text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBPostShareURLSaveTextFile_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim selectedItem = Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem

            If selectedItem IsNot Nothing Then

                '先檢查網址格式
                Dim myBaseUrl = Form1.FBPostShareURLBaseURL_TextBox.Text
                If UtilsModule.IsValidUrl(myBaseUrl) Or myBaseUrl = "" Then
                    ' 儲存網址
                    File.WriteAllText(Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, selectedItem, "myBaseURL.txt"), myBaseUrl)

                    ' 儲存 等待時間
                    Dim configFilePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, selectedItem, "FBPostShareURLWaitSecondsConfig.txt")
                    Dim myConfig As String = Form1.FBPostShareURLUploadWaitSeconds_NumericUpDown.Value & "," & Form1.FBPostShareURLSubmitWaitSeconds_NumericUpDown.Value
                    File.WriteAllText(configFilePath, myConfig)

                    ' 儲存文字檔
                    Dim selectedTextItem = Form1.FBPostShareURLTextFile_ListBox.SelectedItem
                    If selectedTextItem IsNot Nothing Then
                        Dim filePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, selectedItem, "textFiles", selectedTextItem)
                        MyWriteFile(Form1.FBPostShareURLTextFilePreviewer_RichTextBox.Text, filePath)
                    End If
                    MsgBox("儲存成功")
                Else
                    MsgBox("網址格式不正確")
                End If

            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub


    Public Sub FBPostShareURLTextFile_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.FBPostShareURLAssetsDirectory, Form1.FBPostShareURLAssetFolder_ListBox.SelectedItem, "TextFiles", Form1.FBPostShareURLTextFile_ListBox.SelectedItem)
            If File.Exists(filePath) Then
                Process.Start("notepad.exe", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub FBPostShareURLGetCurrentURL_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Form1.FBPostShareURLBaseURL_TextBox.Text = Webview2Controller.edgeDriver.Url
            Else
                MsgBox("未偵測到edgedriver")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPostShareURLNavigateToURL_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim myURL = Form1.FBPostShareURLBaseURL_TextBox.Text
            If UtilsModule.IsValidUrl(myURL) Then
                If Webview2Controller.edgeDriver IsNot Nothing Then
                    Webview2Controller.Navigate_GoToUrl_Task(myURL)
                Else
                    MsgBox("未偵測到edgedriver")
                End If
            Else
                MsgBox("網址格式錯誤")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

End Class
