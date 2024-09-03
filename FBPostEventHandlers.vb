﻿Imports System.IO
Imports System.Text.RegularExpressions

Public Class FBPostEventHandlers
    Public Sub CreateNewAssetFolder_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName As String = Form1.NewAssetFolderName_TextBox.Text
            Dim folderPath = Path.Combine(AppInitModule.FBPostAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) And Not folderName.Contains("&"c) Then
                Directory.CreateDirectory(folderPath)
                Directory.CreateDirectory(Path.Combine(folderPath, "textFiles"))
                Directory.CreateDirectory(Path.Combine(folderPath, "media"))
                UpdateAssetsFolderListBox()

                '新增後直接選擇該資料夾
                Form1.MyAssetsFolder_ListBox.SelectedItem = folderName
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


    Public Sub RevealAssetFolderInFileExplorer_DoubleClick(sender As Object, e As EventArgs)
        Try
            Dim foldPath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem)

            If Path.Exists(foldPath) Then
                Process.Start("Explorer", foldPath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub DeleteSelectedTextFiles_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.TextFileSelector_ListBox.SelectedItems


            If selectedItems.Count > 0 Then
                ' 刪掉選擇的
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        Dim textFilePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If
            Else
                ' 刪掉全部
                'MsgBox("未選擇要刪除的檔案")
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.TextFileSelector_ListBox.Items
                        Dim textFilePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If

            End If

            UpdateTextFileSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub RevealMediaFoldersInFileExplorer_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.MyAssetsFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                For Each item In selectedItems
                    Dim folderPath = Path.Combine(AppInitModule.FBPostAssetsDirectory, item, "media")
                    Process.Start("explorer.exe", folderPath)
                Next
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub DeleteSelectedMediaFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.MediaSelector_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        'Debug.WriteLine("itm : " & item)
                        Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", item)
                        File.Delete(filePath)
                    Next
                End If

            Else
                ' 刪除全部
                'MsgBox("未選擇要刪除的檔案")
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In Form1.MediaSelector_ListBox.Items
                        'Debug.WriteLine("itm : " & item)
                        Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", item)
                        File.Delete(filePath)
                    Next
                End If

            End If

            UpdateMediaSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub EditSelectedTextFileWithNotepad(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "TextFiles", Form1.TextFileSelector_ListBox.SelectedItem)
            If File.Exists(filePath) Then
                Process.Start("notepad.exe", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub PlaySelectedMedia(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "Media", Form1.MediaSelector_ListBox.SelectedItem)
            If File.Exists(filePath) Then
                Process.Start("Explorer", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub SaveFBWritePostWaitSecondsConfig_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName = Form1.MyAssetsFolder_ListBox.SelectedItem
            Dim configFilePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, folderName, "FBWritePostWaitSecondsConfig.txt")
            Dim myConfig As String = Form1.FBWritePostUploadWaitSeconds_NumericUpDown.Value & "," & Form1.FBWritePostSubmitWaitSeconds_NumericUpDown.Value
            File.WriteAllText(configFilePath, myConfig)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub


    Public Sub DeselectAllMyAssetFolderListboxItems_Button_Click(sender As Object, e As EventArgs)
        Form1.MyAssetsFolder_ListBox.ClearSelected()
        Form1.MediaSelector_ListBox.Items.Clear()
        Form1.TextFileSelector_ListBox.Items.Clear()
        Form1.PreviewTextFile_RichTextBox.Clear()
        Form1.MediaPreview_PictureBox.ImageLocation = Nothing
    End Sub




    Public Sub InitEmojiPickerTableLayoutPanel()
        Dim emojis As String() = {"🙂", "😃", "🙁", "😢", "😛", "😇", "😈", "😳", "😉", "😮", "😑", "😠", "😘", "❤", "😊", "😎", "🦈", "🤖", "😠", "v", "😕", "3", "L", "💩", "🐧",
            "☺️", "☹️", "☠️", "✊", "✌️", "☝️", "✋", "✍️",
            "‍♀️", "‍♂️", "⚕️", "⚖️", "❄️", "⭐️", "✨", "⚡️",
            "☄️", "☀️", "⛅️", "☁️", "⛈", "☃️", "⛄️", "☔️",
            "☂️", "☘️", "☕", "⚽️", "⚾️", "⛳️", "⛸", "⛷️",
            "⛹️", "♟", "✈️", "⛵️", "⛴", "⚓️", "⛽️", "⛲️",
            "⛰", "⛺️", "⛪️", "⛩", "⌚️", "⌨️", "☎️", "⏱",
            "⏲", "⏰", "⌛️", "⏳", "⚒", "⛏", "⚙️", "⛓",
            "⚔️", "⚰️", "⚱️", "⚗️", "✉️", "✂️", "✒️", "✏️",
            "❤️", "❣️", "☮️", "✝️", "☪️", "☸️", "✡️", "☯️",
            "☦️", "⛎", "♈️", "♉️", "♊️", "♋️", "♌️", "♍️",
            "♎️", "♏️", "♐️", "♑️", "♒️", "♓️", "⚛️", "☢️",
            "☣️", "✴️", "㊙️", "㊗️", "❌", "⭕️", "⛔️", "♨️",
            "❗️", "❕", "❓", "❔", "‼️", "⁉️", "〽️", "⚠️",
            "⚜️", "♻️", "✅", "❇️", "✳️", "❎", "Ⓜ️", "♿️",
            "⚧", "ℹ️", "0️⃣", "1️⃣", "2️⃣", "3️⃣", "4️⃣", "5️⃣",
            "6️⃣", "7️⃣", "8️⃣", "9️⃣", "#️⃣", "*️⃣", "⏏️", "▶️",
            "⏸", "⏯", "⏹", "⏺", "⏭", "⏮", "⏩", "⏪", "⏬", "◀️",
            "➡️", "⬅️", "⬆️", "⬇️", "↗️", "↘️", "↙️", "↖️",
            "↕️", "↔️", "↪️", "↩️", "⤴️", "⤵️", "➕", "➖",
            "➗", "✖️", "♾️", "™️", "©️", "®️", "〰️", "➰",
            "➿", "✔️", "☑️", "⚫️", "⚪️", "▪️", "▫️", "◾️",
            "◽️", "◼️", "◻️", "⬛️", "⬜️", "♠️", "♣️", "♥️", "♦️"
        }

        Dim emojiIndex As Integer = 0
        For row As Integer = 0 To 2
            For col As Integer = 0 To 67
                Dim lbl As New Label With {
                    .Name = emojiIndex & "_emoji_Label",
                    .Text = emojis(emojiIndex),
                    .Font = New Font("Segoe UI Emoji", 16),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Cursor = Cursors.Hand
                }
                AddHandler lbl.Click, AddressOf EmojisLabel_Click


                Form1.EmojiPicker_TableLayoutPanel.Controls.Add(lbl, col, row)
                emojiIndex += 1
            Next
        Next

    End Sub



    Public Sub EmojisLabel_Click(sender As Object, e As EventArgs)

        Try
            Dim clickedLabel As Label = CType(sender, Label)
            Debug.WriteLine("click " & clickedLabel.Name)
            Dim emojisStr As String() = {":)", ":D", ":(", ":'(", ":P", "O:)", "3:)", "o.O", ";)", ":O", "-_-", ">:O", ":*", "<3", "^_^", "8|", "(^^^)", ":|]", ">:(", ":v", ":/", ":3", "(y)", ":poop:", "<("")"}
            Dim emojiIndex = CInt(Split(clickedLabel.Name, "_")(0))

            Dim myEmoji As String

            ' 如果點的在轉換清單內，就轉換成文字
            If emojiIndex < emojisStr.Count Then
                myEmoji = emojisStr(emojiIndex)
            Else
                '不轉換，用原本的表情插入
                myEmoji = clickedLabel.Text
            End If

            Form1.PreviewTextFile_RichTextBox.SelectedText = myEmoji

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub DeletedSelectedAssetFolders(sender As Object, e As EventArgs)
        Try

            Dim selectedItems = Form1.MyAssetsFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In selectedItems
                        Dim folderPath = Path.Combine(AppInitModule.FBPostAssetsDirectory, item)
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

                    For Each item In Form1.MyAssetsFolder_ListBox.Items
                        Dim folderPath = Path.Combine(AppInitModule.FBPostAssetsDirectory, item)
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



    Public Sub MyAssetsFolder_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedItem = Form1.MyAssetsFolder_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            UpdateTextFileSelectorListBoxItems(selectedItem)
            UpdateMediaSelectorListBoxItems(selectedItem)
            DisplayFBWritePostWaitSeconds(selectedItem)

        End If
    End Sub

    Public Sub MediaSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.MediaSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                'MainFormController.PreviewMediaToPictureBox(selectedItem)
                Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", selectedItem)
                'Debug.WriteLine("img" & filePath)

                Dim allowedVideoExtension As String() = {".mp4", ".MP4"}
                If allowedVideoExtension.Contains(Path.GetExtension(selectedItem)) Then
                    Form1.MediaPreview_PictureBox.Image = My.Resources.PlayVideo

                Else
                    Form1.MediaPreview_PictureBox.ImageLocation = filePath
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub



    Public Sub TextFileSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.TextFileSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Form1.PreviewTextFile_RichTextBox.Clear()
                Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", selectedItem)
                Dim text = File.ReadAllText(filePath)
                Form1.PreviewTextFile_RichTextBox.Text = text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub CreateNewTextFile_Button_Click(sender As Object, e As EventArgs)

        Try
            'Debug.WriteLine("filename : " & fileName)
            'Debug.WriteLine("Form1.MyAssetsFolder_ListBox.SelectedItem:" & Form1.MyAssetsFolder_ListBox.SelectedItem)
            Dim fileName = Form1.NewTextFileName_TextBox.Text
            If String.IsNullOrEmpty(fileName) Then
                MsgBox("不合法檔案名稱")
                Exit Sub
            End If
            If Form1.MyAssetsFolder_ListBox.SelectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", fileName & ".txt")
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


    Public Sub CreateNewTextFile(fileName As String)
        Try
            'Debug.WriteLine("filename : " & fileName)
            'Debug.WriteLine("Form1.MyAssetsFolder_ListBox.SelectedItem:" & Form1.MyAssetsFolder_ListBox.SelectedItem)
            If String.IsNullOrEmpty(fileName) Then
                MsgBox("不合法檔案名稱")
                Exit Sub
            End If
            If Form1.MyAssetsFolder_ListBox.SelectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", fileName & ".txt")
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

    Public Sub SaveEditedTextFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.TextFileSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBPostAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", selectedItem)
                MyWriteFile(filePath)
                MsgBox("修改成功")
            Else
                MsgBox("未選擇檔案")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("修改失敗")
        End Try


    End Sub



End Class
