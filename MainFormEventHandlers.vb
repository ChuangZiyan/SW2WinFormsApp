﻿Imports System.IO
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
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        'Debug.WriteLine("itm : " & item)
                        Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", item)
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
                        Dim filePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "media", item)
                        File.Delete(filePath)
                    Next
                End If

            End If

            UpdateMediaSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)

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
                ' 刪掉選擇的
                Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    For Each item In selectedItems
                        Dim textFilePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If
            Else
                ' 刪掉全部
                'MsgBox("未選擇要刪除的檔案")
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.TextFileSelector_ListBox.Items
                        Dim textFilePath = Path.Combine(AppInitModule.myAssetsDirectory, Form1.MyAssetsFolder_ListBox.SelectedItem, "textFiles", item)
                        File.Delete(textFilePath)
                    Next
                End If

            End If

            UpdateTextFileSelectorListBoxItems(Form1.MyAssetsFolder_ListBox.SelectedItem)

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
        InserScriptItemToListview(False)

    End Sub

    Public Sub InsertSchedulerScriptToListview_Button_Click(sender As Object, e As EventArgs)
        InserScriptItemToListview(True)
    End Sub


    Public Sub InserScriptItemToListview(Optional scheduled As Boolean = False)
        ' sequence | scheduled


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
            For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content = "隨機"
        End If



        If scheduled Then '定時執行
            Dim baseSeconds = Form1.ScheduledExecutionHours_NumericUpDown.Value * 3600 + Form1.ScheduledExecutionMinutes_NumericUpDown.Value * 60 + Form1.ScheduledExecutionSeconds_NumericUpDown.Value


            For Each selectedGroupItem As ListViewItem In selectedGroupItems
                executionTime = UtilsModule.ConvertSecondsToTimeFormat(baseSeconds)
                baseSeconds += Form1.SchedulerIntervalSeconds_NumericUpDown.Value
                AddScriptQueueItem(selectedUserDataFolder, executionTime, selectedGroupItem.Text, selectedGroupItem.SubItems(1).Text, content, selecteAction, executionWaitSeconds)
            Next
        Else '順序執行
            If selectedUserDataFolderItems.Count > 1 Then ' 如果你選擇超過一個帳號，多帳號對一社團
                For Each selectedUserData In selectedUserDataFolderItems
                    AddScriptQueueItem(selectedUserData.ToString(), executionTime, selectedGroupName, selectedGroupUrl, content, selecteAction, executionWaitSeconds)
                Next
            Else ' 一帳號對多社團
                For Each selectedGroupItem As ListViewItem In selectedGroupItems
                    AddScriptQueueItem(selectedUserDataFolder, executionTime, selectedGroupItem.Text, selectedGroupItem.SubItems(1).Text, content, selecteAction, executionWaitSeconds)
                Next
            End If

        End If


    End Sub



    Private Sub AddScriptQueueItem(userData As String, excutionTime As String, groupName As String, groupUrl As String, content As String, action As String, waitTime As String)
        Dim scriptQueueItem As New ListViewItem(userData)

        ' 執行時間
        scriptQueueItem.SubItems.Add(excutionTime)

        ' 網址名稱
        scriptQueueItem.SubItems.Add(groupName)

        ' 目標網址
        scriptQueueItem.SubItems.Add(groupUrl)

        ' 執行動作
        scriptQueueItem.SubItems.Add(action)

        '選擇內容
        scriptQueueItem.SubItems.Add(content)

        ' 執行內容
        scriptQueueItem.SubItems.Add("")

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
                    .Item(11).Text = (Form1.ExecutionWaitHours_NumericUpDown.Value * 3600 + Form1.ExecutionWaitMinutes_NumericUpDown.Value * 60 + Form1.ExecutionWaitSeconds_NumericUpDown.Value) & "±" & Form1.ExecutionWaitRandomSeconds_NumericUpDown.Value
                End With
            Next
        End If

    End Sub

    Public Sub ModifySelectedScriptListviewAsset_Button_Click(sender As Object, e As EventArgs)
        ' UserData
        Dim content = ""
        If Form1.MyAssetsFolder_ListBox.SelectedItems.Count > 0 Then
            For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content = "隨機"
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


    Public Sub ModifyListviewScheduleTime_Button_Click(sender As Object, e As EventArgs)
        Dim selectedListviewItems = Form1.ScriptQueue_ListView.SelectedItems
        If selectedListviewItems.Count > 0 Then
            Dim baseSeconds = Form1.ScheduledExecutionHours_NumericUpDown.Value * 3600 + Form1.ScheduledExecutionMinutes_NumericUpDown.Value * 60 + Form1.ScheduledExecutionSeconds_NumericUpDown.Value
            For Each item As ListViewItem In selectedListviewItems

                Dim executionTime = UtilsModule.ConvertSecondsToTimeFormat(baseSeconds)

                With item.SubItems
                    .Item(1).Text = executionTime
                End With
                baseSeconds += Form1.SchedulerIntervalSeconds_NumericUpDown.Value
            Next
        End If

    End Sub

    Public Sub ModifyListviewScheduleTimeTNull_Button_Click(sender As Object, e As EventArgs)
        Dim selectedListviewItems = Form1.ScriptQueue_ListView.SelectedItems
        If selectedListviewItems.Count > 0 Then
            For Each item As ListViewItem In selectedListviewItems
                With item.SubItems
                    .Item(1).Text = "NULL"
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
                item.SubItems(12).Text = "略過"
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
                item.SubItems(12).Text = ""
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
                item.SubItems(12).Text = "略過"
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
                item.SubItems(12).Text = ""
            Next

            Form1.ScriptQueue_ListView.SelectedItems.Clear()
            Form1.ScriptQueue_ListView.Refresh()

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


    Public Sub SaveFBWritePostWaitSecondsConfig_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName = Form1.MyAssetsFolder_ListBox.SelectedItem
            Dim configFilePath = Path.Combine(AppInitModule.myAssetsDirectory, folderName, "FBWritePostWaitSecondsConfig.txt")
            Dim myConfig As String = Form1.FBWritePostUploadWaitSeconds_NumericUpDown.Value & "," & Form1.FBWritePostSubmitWaitSeconds_NumericUpDown.Value
            File.WriteAllText(configFilePath, myConfig)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub

    Public Sub SchedulerTime_Label_Click(sender As Object, e As EventArgs)
        Dim now As DateTime = DateTime.Now
        Dim timeSinceMidnight As TimeSpan = now - now.Date
        Dim baseSeconds = CInt(timeSinceMidnight.TotalSeconds)
        ' 加上時間間隔
        baseSeconds += Form1.SchedulerIntervalSeconds_NumericUpDown.Value

        Dim splitedTimeStr = Split(UtilsModule.ConvertSecondsToTimeFormat(baseSeconds), ":")
        Form1.ScheduledExecutionHours_NumericUpDown.Value = splitedTimeStr(0)
        Form1.ScheduledExecutionMinutes_NumericUpDown.Value = splitedTimeStr(1)
        Form1.ScheduledExecutionSeconds_NumericUpDown.Value = splitedTimeStr(2)

    End Sub

    Public Sub SyncTimeToDateTimePicker_Label_Click(sender As Object, e As EventArgs)
        Form1.ScheduledTimeSorting_DateTimePicker.Value = DateTime.Now
    End Sub

    Public Sub SortListviewItemByTime_Button_Click(sender As Object, e As EventArgs)

        Dim selectedTime As DateTime = Form1.ScheduledTimeSorting_DateTimePicker.Value
        Dim items As List(Of ListViewItem) = Form1.ScriptQueue_ListView.Items.Cast(Of ListViewItem).ToList()


        Dim nullItems As New List(Of ListViewItem)
        Dim notNullItems As New List(Of ListViewItem)

        ' 先分離NULL的item
        For Each item In items

            If item.SubItems(1).Text = "NULL" Then
                nullItems.Add(item)
            Else
                notNullItems.Add(item)
            End If
        Next



        ' 把不是Null的Item照時間排序
        notNullItems.Sort(Function(x, y)
                              Dim timeX As DateTime = DateTime.Parse(x.SubItems(1).Text)
                              Dim timeY As DateTime = DateTime.Parse(y.SubItems(1).Text)
                              Return timeX.CompareTo(timeY)
                          End Function)

        ' 然後用選擇的時間切斷
        Dim greaterOrEqualItems = notNullItems.Where(Function(item) DateTime.Parse(item.SubItems(1).Text).TimeOfDay >= selectedTime.TimeOfDay).ToList()
        Dim lessItems = notNullItems.Where(Function(item) DateTime.Parse(item.SubItems(1).Text).TimeOfDay < selectedTime.TimeOfDay).ToList()

        ' 最後再合併起來
        Dim sortedItems = greaterOrEqualItems.Concat(lessItems).Concat(nullItems).ToList()
        'sortedItems = sortedItems.Concat(notNullItems).ToList()
        Form1.ScriptQueue_ListView.Items.Clear()
        Form1.ScriptQueue_ListView.Items.AddRange(sortedItems.ToArray())
    End Sub


    Public Sub ScriptQueue_ListView_DoubleClick(sender As Object, e As EventArgs)
        If Form1.ScriptQueue_ListView.SelectedItems.Count > 0 Then


            For Each item As ListViewItem In Form1.FBGroups_ListView.Items
                item.Selected = False
            Next

            Form1.WebviewUserDataFolder_ListBox.ClearSelected()

            Form1.MyAssetsFolder_ListBox.ClearSelected()



            Dim selectedItem As ListViewItem = Form1.ScriptQueue_ListView.SelectedItems(0)

            Dim userData = selectedItem.SubItems(0).Text
            Dim scheduleTime = selectedItem.SubItems(1).Text
            Dim urlName = selectedItem.SubItems(2).Text
            Dim url = selectedItem.SubItems(3).Text
            Dim action = selectedItem.SubItems(4).Text
            Dim content = selectedItem.SubItems(5).Text
            Dim waitTime = selectedItem.SubItems(11).Text

            ' 選取userData
            Form1.WebviewUserDataFolder_ListBox.SelectedItem = userData


            ' 不是NULL的話設定執行時間
            If scheduleTime <> "NULL" Then
                Dim splitedScheduleTime() As String = Split(scheduleTime, ":")
                Form1.ScheduledExecutionHours_NumericUpDown.Value = CInt(splitedScheduleTime(0))
                Form1.ScheduledExecutionMinutes_NumericUpDown.Value = CInt(splitedScheduleTime(1))
                Form1.ScheduledExecutionSeconds_NumericUpDown.Value = CInt(splitedScheduleTime(2))
            End If

            ' 社團名稱跟網址
            Form1.FBGroupName_TextBox.Text = urlName
            Form1.FBGroupUrl_TextBox.Text = url


            ' 設定tab
            Select Case action
                Case "發帖"
                    Form1.Action_TabControl.SelectedTab = Form1.FBPost_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
                Case "測試項"
                    Form1.Action_TabControl.SelectedTab = Form1.TabPage2
            End Select


            ' 設定時間
            Dim waitSecondsStr = Split(waitTime, "±")(0)
            Dim RandomWaitSeconds = Split(waitTime, "±")(1)
            Dim SplitedWaitSecondsStr() As String = Split(UtilsModule.ConvertSecondsToTimeFormat(waitSecondsStr), ":")
            Form1.ExecutionWaitHours_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(0))
            Form1.ExecutionWaitMinutes_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(1))
            Form1.ExecutionWaitSeconds_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(2))
            Form1.ExecutionWaitRandomSeconds_NumericUpDown.Value = CInt(RandomWaitSeconds)

            ' 設定選擇資料夾
            If content <> "隨機" Then
                Dim itemsToSelect As String() = Split(content, "&")
                For i As Integer = 0 To Form1.MyAssetsFolder_ListBox.Items.Count - 1
                    If itemsToSelect.Contains(Form1.MyAssetsFolder_ListBox.Items(i).ToString()) Then
                        Form1.MyAssetsFolder_ListBox.SetSelected(i, True)
                    End If
                Next
            End If



        End If

    End Sub


    Public Sub CreateNewAssetFolder_Button_Click(sender As Object, e As EventArgs)
        MainFormController.CreateNewAssetFolder(Form1.NewAssetFolderName_TextBox.Text)
    End Sub




    Public Sub TextEmoji_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Form1.PreviewTextFile_RichTextBox.SelectedText = Form1.TextEmoji_ListBox.SelectedItem

    End Sub

End Class
