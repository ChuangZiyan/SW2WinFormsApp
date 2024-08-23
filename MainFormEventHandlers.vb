Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports Microsoft.Web.WebView2.WinForms

Public Class MainFormEventHandlers



    Public Sub UpdateWebviewUserDataCheckListBox_CheckBox_Click(sender As Object, e As EventArgs) 'Handles FilterAvailableUserData_CheckBox.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub


    Public Sub DeselectAllMyAssetFolderListboxItems_Button_Click(sender As Object, e As EventArgs)
        Form1.MyAssetsFolder_ListBox.ClearSelected()
        Form1.MediaSelector_ListBox.Items.Clear()
        Form1.TextFileSelector_ListBox.Items.Clear()
        Form1.PreviewTextFile_RichTextBox.Clear()
        Form1.MediaPreview_PictureBox.ImageLocation = Nothing
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
            If File.Exists(filePath) Then
                Process.Start("Explorer", filePath)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub InsertToQueueListview_Button_Click(sender As Object, e As EventArgs)
        'Debug.WriteLine("click")
        Dim selectedUserDataFolderItems = Form1.WebviewUserDataFolder_ListBox.SelectedItems
        Dim selectedGroupItems = Form1.FBGroups_ListView.SelectedItems

        Dim executionTime = "NULL"
        Dim executionWaitSeconds = (Form1.ExecutionWaitHours_NumericUpDown.Value * 3600 + Form1.ExecutionWaitMinutes_NumericUpDown.Value * 60 + Form1.ExecutionWaitSeconds_NumericUpDown.Value) & "±" & Form1.ExecutionWaitRandomSeconds_NumericUpDown.Value
        Dim selectedGroupName = "NULL"
        Dim selectedGroupUrl = "NULL"


        Dim selecteAction = Form1.Action_TabControl.SelectedTab.Text
        Dim content = ""


        Dim selectedUserDataFolder = "NULL"


        ' 第一個選擇的UserDataFolder
        For Each selectedUserData In selectedUserDataFolderItems
            selectedUserDataFolder = selectedUserData.ToString()
        Next

        ' 第一個選擇的Group
        If selectedGroupItems.Count > 0 Then
            Dim selectedItem = selectedGroupItems(0)
            selectedGroupName = selectedItem.Text
            selectedGroupUrl = selectedItem.SubItems(1).Text
        End If


        ' UserData
        If Form1.MyAssetsFolder_ListBox.SelectedItems.Count > 0 Then
            content += "資料夾="
            For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content += "資料夾=隨機"
        End If


        If selectedUserDataFolderItems.Count > 1 Then ' 如果你選擇超過一個帳號，多帳號對一社團
            For Each selectedUserData In selectedUserDataFolderItems
                AddScriptQueueItem(selectedUserData.ToString(), selectedGroupName, selectedGroupUrl, content, selecteAction, executionWaitSeconds, executionTime)
            Next
        Else ' 一帳號對多社團
            For Each selectedGroupItem As ListViewItem In selectedGroupItems
                AddScriptQueueItem(selectedUserDataFolder, selectedGroupItem.Text, selectedGroupItem.SubItems(1).Text, content, selecteAction, executionWaitSeconds, executionTime)
            Next
        End If


    End Sub


    Private Sub AddScriptQueueItem(userData As String, groupName As String, groupUrl As String, content As String, action As String, waitTime As String, excutionTime As String)
        Dim scriptQueueItem As New ListViewItem(userData)

        ' 執行時間
        scriptQueueItem.SubItems.Add(excutionTime)

        ' 網址名稱
        scriptQueueItem.SubItems.Add(groupName)

        ' 目標網址
        scriptQueueItem.SubItems.Add(groupUrl)

        ' 執行動作
        scriptQueueItem.SubItems.Add(action)

        ' 執行內容
        scriptQueueItem.SubItems.Add(content)

        ' 上載等待
        scriptQueueItem.SubItems.Add(0)

        ' 送出等待
        scriptQueueItem.SubItems.Add(0)

        ' 執行成功次數
        scriptQueueItem.SubItems.Add(0)

        ' 執行失敗次數
        scriptQueueItem.SubItems.Add(0)

        ' 等待時間
        scriptQueueItem.SubItems.Add(waitTime)

        ' 備註
        scriptQueueItem.SubItems.Add("")

        Form1.ScriptQueue_ListView.Items.Add(scriptQueueItem)
    End Sub

    Public Sub ModifySelectedScriptListviewWaitTime()
        Dim selectedListviewItems = Form1.ScriptQueue_ListView.SelectedItems
        If selectedListviewItems.Count > 0 Then
            For Each item As ListViewItem In selectedListviewItems
                With item.SubItems
                    '.Item(0).Text = userData
                    '.Item(1).Text = executionTime
                    '.Item(2).Text = groupName
                    '.Item(3).Text = groupUrl
                    '.Item(4).Text = content
                    '.Item(5).Text = action
                    '.Item(6).Text = "0"
                    '.Item(7).Text = "0"
                    .Item(10).Text = (Form1.ExecutionWaitHours_NumericUpDown.Value * 3600 + Form1.ExecutionWaitMinutes_NumericUpDown.Value * 60 + Form1.ExecutionWaitSeconds_NumericUpDown.Value) & "±" & Form1.ExecutionWaitRandomSeconds_NumericUpDown.Value
                    '.Item(9).Text = ""
                End With
            Next
        End If

    End Sub

    Public Sub ModifySelectedScriptListviewAsset_Button_Click(sender As Object, e As EventArgs)
        ' UserData
        Dim content = ""
        If Form1.MyAssetsFolder_ListBox.SelectedItems.Count > 0 Then
            content += "資料夾="
            For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content += "資料夾=隨機"
        End If


        Dim selectedListviewItems = Form1.ScriptQueue_ListView.SelectedItems
        If selectedListviewItems.Count > 0 Then
            For Each item As ListViewItem In selectedListviewItems
                With item.SubItems
                    .Item(5).Text = content
                End With
            Next
        End If

    End Sub




    Public Sub PauseScriptExecution_Button_Click(sender As Object, e As EventArgs)
        Form1.PAUSE = True
    End Sub

    Public Sub ContinueScriptExecution_Button_Click(sender As Object, e As EventArgs)
        Form1.PAUSE = False
    End Sub


    Public Sub MarkUserDataToSkip_Button_Click(sender As Object, e As EventArgs)

        Dim markUserdata = Form1.userData_ComboBox.Text
        For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
            If item.SubItems(0).Text = markUserdata Then
                item.ForeColor = Color.LightGray
                item.SubItems(11).Text = "略過"
                'item.BackColor = Color.LightGray
            End If
        Next

        Form1.ScriptQueue_ListView.SelectedItems.Clear()
        Form1.ScriptQueue_ListView.Refresh()
    End Sub


    Public Sub UnmarkUserDataToSkip_Button_Button_Click(sender As Object, e As EventArgs)

        Dim markUserdata = Form1.userData_ComboBox.Text
        For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
            If item.SubItems(0).Text = markUserdata Then
                item.ForeColor = Color.Black
                item.SubItems(11).Text = ""
                'item.BackColor = Color.LightGray
            End If
        Next
        Form1.ScriptQueue_ListView.SelectedItems.Clear()
        Form1.ScriptQueue_ListView.Refresh()
    End Sub

    Public Sub SaveScriptListViewToFile_Button_Click(sender As Object, e As EventArgs)
        Try
            MainFormController.SaveScriptListViewToFile()
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub

    Public Sub MarkSelectedScriptListviewItem_Button_Click(sender As Object, e As EventArgs)

        Dim scriptListviewSelectedItems = Form1.ScriptQueue_ListView.SelectedItems

        If scriptListviewSelectedItems.Count > 0 Then

            For Each item As ListViewItem In scriptListviewSelectedItems
                item.ForeColor = Color.LightGray
                item.SubItems(11).Text = "略過"
            Next


            Form1.ScriptQueue_ListView.SelectedItems.Clear()
            Form1.ScriptQueue_ListView.Refresh()

        End If


    End Sub


    Public Sub UnmarkSelectedScriptListviewItem_Button_Click(sender As Object, e As EventArgs)
        Dim scriptListviewSelectedItems = Form1.ScriptQueue_ListView.SelectedItems

        If scriptListviewSelectedItems.Count > 0 Then

            For Each item As ListViewItem In scriptListviewSelectedItems
                item.ForeColor = Color.Black
                item.SubItems(11).Text = ""
            Next

            Form1.ScriptQueue_ListView.SelectedItems.Clear()
            Form1.ScriptQueue_ListView.Refresh()

        End If

    End Sub


    Public Sub ScriptQueue_ListView_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim scriptListviewSelectedItems = Form1.ScriptQueue_ListView.SelectedItems

        If scriptListviewSelectedItems.Count > 0 Then

            Dim url As String = scriptListviewSelectedItems(0).SubItems(3).Text
            Form1.Navigate_Url_TextBox.Text = url

        End If

    End Sub


    Public Sub DeleteSelectedScriptListviewItem_Button_Click(sender As Object, e As EventArgs)
        Dim scriptListviewSelectedItems = Form1.ScriptQueue_ListView.SelectedItems
        If scriptListviewSelectedItems.Count > 0 Then
            For Each item As ListViewItem In scriptListviewSelectedItems
                Form1.ScriptQueue_ListView.Items.Remove(item)
            Next
        End If
    End Sub


    Public Sub DeleteScriptListviewItemByUserData_Button_Click(sender As Object, e As EventArgs)

        If Form1.userData_ComboBox.Text <> "" Then
            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items

                If item.SubItems(0).Text = Form1.userData_ComboBox.Text Then
                    Form1.ScriptQueue_ListView.Items.Remove(item)
                End If

            Next
        End If

    End Sub


    Public Sub ResetScript_Button_Click(sender As Object, e As EventArgs)
        'Await Webview2Controller.ResetWebview2()
        If Webview2Controller.edgeDriver IsNot Nothing Then
            edgeDriver.Quit()
        End If
        Dim appPath As String = Application.ExecutablePath
        System.Diagnostics.Process.Start(appPath)
        Application.Exit()

    End Sub

End Class
