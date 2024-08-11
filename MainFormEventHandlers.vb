Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports Microsoft.Web.WebView2.WinForms

Public Class MainFormEventHandlers



    Public Sub UpdateWebviewUserDataCheckListBox_CheckBox_Click(sender As Object, e As EventArgs) 'Handles FilterAvailableUserData_CheckBox.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

    Public Async Sub DeleteUserDataFolders_Button_Click()

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


    Public Sub DeleteSelectedMediaFile_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.MediaSelector_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        'Debug.WriteLine("itm : " & item)
                        Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", item)
                        File.Delete(filePath)
                    Next
                End If
                UpdateMediaSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)
            Else
                MsgBox("未選擇要刪除的檔案")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub RevealMediaFoldersInFileExplorer_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.MyAssetsFolder_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                For Each item In selectedItems
                    Dim folderPath = Path.Combine(AppInitModule.myAssetsDirectory, item, "media")
                    Process.Start("explorer.exe", folderPath)
                Next
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub DeleteSelectedTextFiles_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.TextFileSelector_ListBox.SelectedItems


            If selectedItems.Count > 0 Then
                Dim result As DialogResult = MessageBox.Show("確定要刪除社團列表檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        Debug.WriteLine("itm : " & item)
                        Dim textFilePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If
                UpdateTextFileSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)
            Else
                MsgBox("未選擇要刪除的檔案")
            End If



        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub RevealAssetFolderInFileExplorer_DoubleClick(sender As Object, e As EventArgs)
        Try
            Dim foldPath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem)

            If Path.Exists(foldPath) Then
                Process.Start("Explorer", foldPath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub EditSelectedTextFileWithNotepad(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "TextFiles", Form1.TextFileSelector_ListBox.SelectedItem)
            Debug.WriteLine("filepath" & filePath)
            If File.Exists(filePath) Then
                Process.Start("notepad.exe", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub PlaySelectedMedia(sender As Object, e As EventArgs)
        Try

            Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "Media", Form1.MediaSelector_ListBox.SelectedItem)
            Debug.WriteLine("filepath" & filePath)
            If File.Exists(filePath) Then
                Process.Start("Explorer", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub InsertToQueueListview_Button_Click(sender As Object, e As EventArgs)
        Debug.WriteLine("click")
        Dim selectedUserDataFolderItems = Form1.WebviewUserDataFolder_ListBox.SelectedItems
        Dim selectedGroupItems = Form1.FBGroups_ListView.SelectedItems

        Dim excutionTime = "NULL"
        Dim selectedGroupName = "NULL"
        Dim selectedGroupUrl = "NULL"


        Dim selecteAction = Form1.Action_TabControl.SelectedTab.Text
        Dim content = ""

        Dim delayTime = "NULL"





        If Form1.MyAssetsFolder_ListBox.SelectedItems.Count > 0 Then
            content += "資料夾="
            For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content += "資料夾=隨機"
        End If


        If selectedGroupItems.Count > 0 Then
            Dim selectedItem = Form1.FBGroups_ListView.SelectedItems(0)
            selectedGroupName = selectedItem.Text
            selectedGroupUrl = selectedItem.SubItems(1).Text

        End If


        If Form1.TextFileSelector_ListBox.SelectedItems.Count > 0 Then

        End If

        For Each selectedUserData In selectedUserDataFolderItems

            Dim scriptQueueItem As New ListViewItem(selectedUserData.ToString)

            '執行時間
            scriptQueueItem.SubItems.Add(excutionTime)

            '網址名稱
            scriptQueueItem.SubItems.Add(selectedGroupName)

            '目標網址
            scriptQueueItem.SubItems.Add(selectedGroupUrl)

            '執行內容
            scriptQueueItem.SubItems.Add(content)

            '執行動作
            scriptQueueItem.SubItems.Add(selecteAction)

            '執行結果
            scriptQueueItem.SubItems.Add("NULL")

            '等待時間
            scriptQueueItem.SubItems.Add(delayTime)


            Form1.ScriptQueue_ListView.Items.Add(scriptQueueItem)




        Next











    End Sub

End Class
