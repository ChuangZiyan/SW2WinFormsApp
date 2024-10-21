﻿Imports SkiaSharp
Imports System.IO

Public Class FBPersonalPostEventHandlers



    Public Sub FBPersonalPostCreateNewAssetFolder_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName As String = Form1.FBPersonalPostAssetFolderName_TextBox.Text
            Dim folderPath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) And Not folderName.Contains("&"c) Then
                Directory.CreateDirectory(folderPath)
                Directory.CreateDirectory(Path.Combine(folderPath, "textFiles"))
                Directory.CreateDirectory(Path.Combine(folderPath, "media"))
                UpdateAssetsFolderListBox()

                '新增後直接選擇該資料夾
                Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem = folderName
                Form1.FBPersonalPostAssetFolderName_TextBox.Clear()

                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


    Public Shared Sub UpdateAssetsFolderListBox()
        Try
            Form1.FBPersonalPostAssetFolder_ListBox.Items.Clear()

            Dim dirs As String() = Directory.GetDirectories(AppInitModule.FBPersonalPostAssetsDirectory)
            For Each dir As String In dirs
                Form1.FBPersonalPostAssetFolder_ListBox.Items.Add(Path.GetFileName(dir))
            Next

            Form1.FBPersonalPostMediaSelector_ListBox.Items.Clear()
            Form1.FBPersonalPostTextFileSelector_ListBox.Items.Clear()
            Form1.FBPersonalPostAssetFolderName_TextBox.Clear()
            Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Clear()
            Form1.FBPersonalPostMediaPreviewer_PictureBox.ImageLocation = Nothing

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub FBPersonalPostDeselectAllAssetFolderListboxItems_Button_Click(sender As Object, e As EventArgs)
        Form1.FBPersonalPostAssetFolder_ListBox.ClearSelected()
        Form1.FBPersonalPostTextFileSelector_ListBox.Items.Clear()
        Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Clear()
        Form1.FBPersonalPostMediaSelector_ListBox.Items.Clear()
        Form1.FBPersonalPostMediaPreviewer_PictureBox.ImageLocation = Nothing
    End Sub


    Public Sub FBPersonalPostDeleteSelectedAssetFolder_Button_Click(sender As Object, e As EventArgs)
        Try

            Dim selectedItems = Form1.FBPersonalPostAssetFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In selectedItems
                        Dim folderPath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdateAssetsFolderListBox()
                    MsgBox("刪除完成")
                End If
            Else
                ' 刪除全部資料夾
                'MsgBox("未選擇要刪除的資料夾")
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.FBPersonalPostAssetFolder_ListBox.Items
                        Dim folderPath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdateAssetsFolderListBox()

                    MsgBox("刪除完成")
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除失敗")
        End Try
    End Sub


    Public Sub FBPersonalPostCreateNewTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            'Debug.WriteLine("filename : " & fileName)
            'Debug.WriteLine("Form1.MyAssetsFolder_ListBox.SelectedItem:" & Form1.MyAssetsFolder_ListBox.SelectedItem)
            Dim fileName = Form1.FBPersonalPostNewTextFileName_TextBox.Text
            If String.IsNullOrEmpty(fileName) Then
                MsgBox("不合法檔案名稱")
                Exit Sub
            End If
            If Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "textFiles", fileName & ".txt")
                If File.Exists(filePath) Then
                    MsgBox("已有相同檔案名稱")
                    Exit Sub
                End If

                UtilsModule.MyWriteFile(Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Text, filePath)
                Form1.FBPersonalPostNewTextFileName_TextBox.Clear()
                UpdateTextFileSelectorListBoxItems(Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem)
            Else
                MsgBox("未選擇資料夾")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("建立文字檔失敗，檔名也許不合法")
        End Try
    End Sub

    Private Sub UpdateTextFileSelectorListBoxItems(folderName As String)
        Try
            Form1.FBPersonalPostTextFileSelector_ListBox.Items.Clear()
            Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Clear()
            Dim textFileFolder = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, folderName, "textFiles")
            If Directory.Exists(textFileFolder) Then
                Dim textFiles As String() = Directory.GetFiles(textFileFolder, "*.txt")
                For Each file As String In textFiles
                    Form1.FBPersonalPostTextFileSelector_ListBox.Items.Add(Path.GetFileName(file))
                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Private Sub UpdateFBPersonalPostMediaListbox(folderName)
        Try
            Form1.FBPersonalPostMediaSelector_ListBox.Items.Clear()
            Form1.FBPersonalPostMediaPreviewer_PictureBox.ImageLocation = Nothing
            Dim mediaFolder = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, folderName, "media")
            If Directory.Exists(mediaFolder) Then
                Dim allowedExtension As String() = {".WEBP", ".webp", ".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG"}
                Dim mediaFiles As String() = Directory.GetFiles(mediaFolder)
                For Each file As String In mediaFiles
                    If allowedExtension.Contains(Path.GetExtension(file)) Then
                        Form1.FBPersonalPostMediaSelector_ListBox.Items.Add(Path.GetFileName(file))
                    End If

                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBPersonalPostAssetFolder_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim selectedItem = Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            UpdateTextFileSelectorListBoxItems(selectedItem)
            UpdateFBPersonalPostMediaListbox(selectedItem)
            DisplayFBPersonalPostWaitSeconds(selectedItem)

            Dim myBaseURLFilePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, selectedItem, "myBaseURL.txt")

        End If
    End Sub


    Private Sub DisplayFBPersonalPostWaitSeconds(folderName)
        Try
            Dim configFilePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, folderName, "FBPersonalPostWaitSecondsConfig.txt")
            If File.Exists(configFilePath) Then
                Dim myText = File.ReadAllText(configFilePath)
                Form1.FBPersonalPostUploadWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(0))
                Form1.FBPersonalPostSubmitWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(1))

            Else
                File.WriteAllText(configFilePath, "30,30")
                Form1.FBPersonalPostUploadWaitSeconds_NumericUpDown.Value = 30
                Form1.FBPersonalPostSubmitWaitSeconds_NumericUpDown.Value = 30
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPersonalPostTextFileSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.FBPersonalPostTextFileSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Clear()
                Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "textFiles", selectedItem)
                Dim text = File.ReadAllText(filePath)
                Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Text = text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub FBPersonalPostDeleteSelectedTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBPersonalPostTextFileSelector_ListBox.SelectedItems


            If selectedItems.Count > 0 Then
                ' 刪掉選擇的
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        Dim textFilePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If
            Else
                ' 刪掉全部
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.FBPersonalPostTextFileSelector_ListBox.Items
                        Dim textFilePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "textFiles", item)
                        Debug.WriteLine(textFilePath)
                        File.Delete(textFilePath)
                    Next
                End If

            End If

            UpdateTextFileSelectorListBoxItems(Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBPersonalPostSaveTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedAssetItem = Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem
            Dim selectedTextItem = Form1.FBPersonalPostTextFileSelector_ListBox.SelectedItem
            If selectedAssetItem IsNot Nothing Then
                '儲存等待秒數
                Dim configFilePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, selectedAssetItem, "FBPersonalPostWaitSecondsConfig.txt")
                Dim myConfig As String = Form1.FBPersonalPostUploadWaitSeconds_NumericUpDown.Value & "," & Form1.FBPersonalPostSubmitWaitSeconds_NumericUpDown.Value
                File.WriteAllText(configFilePath, myConfig)

                ' 儲存文字檔
                If selectedTextItem IsNot Nothing Then
                    Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, selectedAssetItem, "textFiles", selectedTextItem)
                    UtilsModule.MyWriteFile(Form1.FBPersonalPostTextFilePreviewer_RichTextBox.Text, filePath)
                End If

                MsgBox("儲存成功")
            Else
                MsgBox("未選擇資料夾")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub

    Public Sub FBPersonalPostMediaSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.FBPersonalPostMediaSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "media", selectedItem)

                If {".webp", ".WEBP"}.Contains(Path.GetExtension(selectedItem)) Then
                    Dim skBitmap As SKBitmap = SKBitmap.Decode(filePath)
                    Dim bitmap As Bitmap = UtilsModule.SKBitmapToBitmap(skBitmap)
                    Form1.FBPersonalPostMediaPreviewer_PictureBox.Image = bitmap
                Else
                    Form1.FBPersonalPostMediaPreviewer_PictureBox.ImageLocation = filePath
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPersonalPostRevealMediaFoldesrInFileExplorer_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBPersonalPostAssetFolder_ListBox.SelectedItems
            If selectedItems.Count > 0 Then
                For Each item In selectedItems
                    Dim folderPath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, item, "media")
                    Process.Start("explorer.exe", folderPath)
                Next
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBPersonalPostDeleteSelectedMedia_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedAssetFolder = Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem
            If selectedAssetFolder IsNot Nothing Then
                Dim selectedItems = Form1.FBPersonalPostMediaSelector_ListBox.SelectedItems
                If selectedItems.Count > 0 Then
                    ' 刪除所選
                    Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        For Each item In selectedItems
                            'Debug.WriteLine("itm : " & item)
                            Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, selectedAssetFolder, "media", item)
                            File.Delete(filePath)
                        Next
                    End If

                Else
                    ' 刪除全部
                    'MsgBox("未選擇要刪除的檔案")
                    Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        For Each item In Form1.FBPersonalPostMediaSelector_ListBox.Items
                            'Debug.WriteLine("itm : " & item)
                            Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, selectedAssetFolder, "media", item)
                            File.Delete(filePath)
                        Next
                    End If

                End If

                UpdateFBPersonalPostMediaListbox(selectedAssetFolder)
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPersonalPostAssetFolder_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Try
            Dim foldPath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem)

            If Path.Exists(foldPath) Then
                Process.Start("Explorer", foldPath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBPersonalPostTextFileSelector_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.FBPersonalPostAssetsDirectory, Form1.FBPersonalPostAssetFolder_ListBox.SelectedItem, "TextFiles", Form1.FBPersonalPostTextFileSelector_ListBox.SelectedItem)
            If File.Exists(filePath) Then
                    Process.Start("notepad.exe", filePath)
                End If
            Catch ex As Exception
                Debug.WriteLine(ex)
            End Try

        End Sub



End Class
