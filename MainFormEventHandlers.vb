Imports System.Diagnostics.Metrics
Imports System.IO
Imports System.Reflection.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class MainFormEventHandlers



    Public Sub UpdateWebviewUserDataCheckListBox_CheckBox_Click(sender As Object, e As EventArgs) 'Handles FilterAvailableUserData_CheckBox.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

    Public Sub WebviewUserDataFolder_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        MainFormController.DisplayUserData(Form1.WebviewUserDataFolder_ListBox.SelectedItem)
        MainFormController.DisplayGroupList(Form1.WebviewUserDataFolder_ListBox.SelectedItem)
        MainFormController.DisplayFBActivityLogs(Form1.WebviewUserDataFolder_ListBox.SelectedItem)
        MainFormController.DisplayFBNotificationList(Form1.WebviewUserDataFolder_ListBox.SelectedItem)
        MainFormController.DisplayFBMessengerList(Form1.WebviewUserDataFolder_ListBox.SelectedItem)


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

        'Form1.Action_TabControl.SelectedTab.Text
        Dim assetFolderListBoxSelectedItems = Nothing
        Select Case Form1.Action_TabControl.SelectedTab.Text
            Case "發帖"
                assetFolderListBoxSelectedItems = Form1.MyAssetsFolder_ListBox.SelectedItems
            Case "拍賣"
                assetFolderListBoxSelectedItems = Form1.FBMarkplaceProducts_ListBox.SelectedItems
            Case "分享"
                assetFolderListBoxSelectedItems = Form1.FBPostShareURLAssetFolder_ListBox.SelectedItems
            Case "留言"
                assetFolderListBoxSelectedItems = Form1.FBCommentAssetFolder_ListBox.SelectedItems
            Case "自訂"
                assetFolderListBoxSelectedItems = Form1.FBCustomizeCommentAssetFolder_ListBox.SelectedItems
            Case "回應"
                assetFolderListBoxSelectedItems = Form1.FBResponseAssetFolder_ListBox.SelectedItems
            Case "順序回應通知"
                assetFolderListBoxSelectedItems = Form1.FBResponseAssetFolder_ListBox.SelectedItems
            Case Else
                MsgBox("不支援此執行動作")
                Exit Sub
        End Select


        Dim content As String = ""
        If assetFolderListBoxSelectedItems.Count > 0 Then
            For Each item In assetFolderListBoxSelectedItems
                content += item + "&"
            Next
            content = content.TrimEnd("&")
        Else
            content = "隨機"
        End If

        Dim selectedListviewItems = Form1.ScriptQueue_ListView.SelectedItems
        If selectedListviewItems.Count > 0 Then
            For Each item As ListViewItem In selectedListviewItems

                If item.SubItems(4).Text = Form1.Action_TabControl.SelectedTab.Text Then
                    With item.SubItems
                        .Item(5).Text = content
                    End With
                ElseIf item.SubItems(4).Text = "順序回應通知" And Form1.Action_TabControl.SelectedTab.Text = "回應" Then
                    With item.SubItems
                        .Item(5).Text = content
                    End With
                End If
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
            MainFormController.ResetListviewItemsBackgroundColor(Form1.ScriptQueue_ListView)
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

            ' 先把原本Listbox選的清掉
            Form1.WebviewUserDataFolder_ListBox.ClearSelected()
            Form1.MyAssetsFolder_ListBox.ClearSelected()
            Form1.FBPostShareURLAssetFolder_ListBox.ClearSelected()
            Form1.FBCommentAssetFolder_ListBox.ClearSelected()

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


            '先宣告待會要用的asset listbox
            Dim assetsFolder_ListBox = Nothing

            ' 設定tab 順便設定是執行動作用的asset listbox
            Select Case action
                Case "發帖"
                    Form1.Action_TabControl.SelectedTab = Form1.FBPost_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
                    assetsFolder_ListBox = Form1.MyAssetsFolder_ListBox
                Case "拍賣"
                    Form1.Action_TabControl.SelectedTab = Form1.FBMarketplace_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
                    assetsFolder_ListBox = Form1.FBMarkplaceProducts_ListBox

                Case "分享"
                    Form1.Action_TabControl.SelectedTab = Form1.FBPostShareURL_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
                    assetsFolder_ListBox = Form1.FBPostShareURLAssetFolder_ListBox
                Case "留言"
                    Form1.Action_TabControl.SelectedTab = Form1.FBComment_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBActivityLogs_TabPage
                    assetsFolder_ListBox = Form1.FBCommentAssetFolder_ListBox
                Case "自訂"
                    Form1.Action_TabControl.SelectedTab = Form1.FBCustomizeComment_TabPage
                    Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
                    assetsFolder_ListBox = Form1.FBCustomizeCommentAssetFolder_ListBox
                Case "測試項"
                    Form1.Action_TabControl.SelectedTab = Form1.FBActivityLogs_TabPage
            End Select

            ' 填入社團名稱跟網址，動作是留言的話，要填到留言的面板去
            If action = "留言" Then
                Form1.FBActivityLogsGroupName_TextBox.Text = urlName
                Form1.FBActivityLogsGroupURL_TextBox.Text = url
            Else
                Form1.FBGroupName_TextBox.Text = urlName
                Form1.FBGroupUrl_TextBox.Text = url
            End If


            ' 設定時間，這是通用的
            Dim waitSecondsStr = Split(waitTime, "±")(0)
            Dim RandomWaitSeconds = Split(waitTime, "±")(1)
            Dim SplitedWaitSecondsStr() As String = Split(UtilsModule.ConvertSecondsToTimeFormat(waitSecondsStr), ":")
            Form1.ExecutionWaitHours_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(0))
            Form1.ExecutionWaitMinutes_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(1))
            Form1.ExecutionWaitSeconds_NumericUpDown.Value = CInt(SplitedWaitSecondsStr(2))
            Form1.ExecutionWaitRandomSeconds_NumericUpDown.Value = CInt(RandomWaitSeconds)

            '根據執行動作設定的 assetsFolder_ListBox 設定選擇資料夾
            If assetsFolder_ListBox IsNot Nothing Then
                If content <> "隨機" Then '如果不是隨機就選
                    Dim itemsToSelect As String() = Split(content, "&")
                    For i As Integer = 0 To assetsFolder_ListBox.Items.Count - 1
                        If itemsToSelect.Contains(assetsFolder_ListBox.Items(i).ToString()) Then
                            assetsFolder_ListBox.SetSelected(i, True)
                        End If
                    Next
                End If
            End If

        End If

    End Sub

    Public Sub RevealFBPasswordText_Button_Click(sender As Object, e As EventArgs)
        If Form1.FBPassword_TextBox.PasswordChar = "*" Then
            Form1.RevealFBPasswordText_Button.Text = "隱藏"
            Form1.FBPassword_TextBox.PasswordChar = vbNullChar
        ElseIf Form1.FBPassword_TextBox.PasswordChar = vbNullChar Then
            Form1.RevealFBPasswordText_Button.Text = "顯示"
            Form1.FBPassword_TextBox.PasswordChar = "*"
        End If

    End Sub

    Public Sub RevealEmailPasswordText_Button_Click(sender As Object, e As EventArgs)
        If Form1.EmailPassword_TextBox.PasswordChar = "*" Then
            Form1.RevealEmailPasswordText_Button.Text = "隱藏"
            Form1.EmailPassword_TextBox.PasswordChar = vbNullChar
        ElseIf Form1.EmailPassword_TextBox.PasswordChar = vbNullChar Then
            Form1.RevealEmailPasswordText_Button.Text = "顯示"
            Form1.EmailPassword_TextBox.PasswordChar = "*"
        End If
    End Sub


    Public Async Sub NavigateTo_Url_Button_Click(sender As Object, e As EventArgs)
        Dim myUrl = Form1.Navigate_Url_TextBox.Text
        Await Navigate_GoToUrl_Task(myUrl)
    End Sub


    Public Sub CreateUserDataFolderButton_Click(sender As Object, e As EventArgs)
        Try
            Dim folderName = Form1.UserDataFolderName_TextBox.Text
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

    Public Sub SaveUserData_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName = Form1.WebviewUserDataFolder_ListBox.SelectedItem
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

    Public Async Sub Move_UserDataFolder_Button_Click(sender As Object, e As EventArgs)
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
                MainFormController.UpdateWebviewUserDataCheckListBox()

            Else
                MsgBox("未選擇任何資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("移動失敗")
        End Try

    End Sub


    Public Sub AddGroupDataToGroupListview_Button_Click(sender As Object, e As EventArgs)
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

    Public Sub EditSelectedGroupListviewItem_Button_Click(sender As Object, e As EventArgs)
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

    Public Sub DeleteSelectedGroup_Button_Click(sender As Object, e As EventArgs)
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
                        MsgBox("刪除完成")
                    Else
                        MsgBox("檔案不存在")
                    End If
                    Form1.FBGroups_ListView.Items.Clear()
                End If

            End If
        Catch ex As Exception
            MsgBox("刪除失敗")
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub GetJoinedGroupList_Button_Click(sender As Object, e As EventArgs)
        Webview2Controller.GetJoinedGroupList()
    End Sub

    Public Sub GetCurrentUrl_Button_Click(sender As Object, e As EventArgs)
        Try
            Form1.Navigate_Url_TextBox.Text = Webview2Controller.edgeDriver.Url
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("未偵測到Edge driver")
        End Try

    End Sub

    Public Sub GetFBGroupList_Button_Click(sender As Object, e As EventArgs)
        Webview2Controller.GetFBGroupList()
    End Sub

    Public Sub SaveListviewGroupList_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                MsgBox("未選擇使用者")
                Exit Sub
            End If

            Dim items As New List(Of GroupListviewDataStruct)()
            For Each item As ListViewItem In Form1.FBGroups_ListView.Items

                Dim listViewItemData As New GroupListviewDataStruct With {
                    .Name = item.Text,
                    .Url = item.SubItems(1).Text
                }
                items.Add(listViewItemData)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(items, Formatting.Indented)
            Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBGroupList.json")
            File.WriteAllText(filePath, jsonStr)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try
    End Sub

    Public Sub FBGroups_ListView_SelectedIndexChanged(sender As Object, e As EventArgs)
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


    Public Sub ReadActivityLogs_Button_Click(sender As Object, e As EventArgs)
        Webview2Controller.ReadActivityLogs(Form1.NumberOfActivityLogsPageDropDown_NumericUpDown.Value)
    End Sub

    Public Async Sub NavigateToActivityLogsPage_Button_Click(sender As Object, e As EventArgs)
        Await Webview2Controller.Navigate_GoToUrl_Task("https://www.facebook.com/100002728990423/allactivity?activity_history=false&category_key=GROUPPOSTS&manage_mode=false&should_load_landing_page=false")
    End Sub

    Public Sub SaveFBActivityLogListview_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                MsgBox("未選擇使用者")
                Exit Sub
            End If

            Dim items As New List(Of GroupListviewDataStruct)()
            For Each item As ListViewItem In Form1.FBActivityLogs_ListView.Items

                Dim listViewItemData As New GroupListviewDataStruct With {
                    .Name = item.Text,
                    .Url = item.SubItems(1).Text
                }
                items.Add(listViewItemData)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(items, Formatting.Indented)
            Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBActivityLogList.json")
            File.WriteAllText(filePath, jsonStr)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try

    End Sub



    Public Sub FBActivityLogs_ListView_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If Form1.FBActivityLogs_ListView.SelectedItems.Count > 0 Then
                'Debug.WriteLine(Form1.FBGroups_ListView.SelectedItems(0).Text)
                Dim selectedItem = Form1.FBActivityLogs_ListView.SelectedItems(0)
                Form1.FBActivityLogsGroupName_TextBox.Text = selectedItem.Text
                Form1.FBActivityLogsGroupURL_TextBox.Text = selectedItem.SubItems(1).Text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub DeleteSelectedFBActivityLogListviewItems_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBActivityLogs_ListView.SelectedItems
            If selectedItems.Count > 0 Then
                For i As Integer = selectedItems.Count - 1 To 0 Step -1
                    Form1.FBActivityLogs_ListView.Items.Remove(selectedItems(i))
                Next
            Else

                If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                    MsgBox("未選擇使用者")
                    Exit Sub
                End If

                Dim result As DialogResult = MessageBox.Show("確定要近期活動列表檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBActivityLogList.json")

                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                        MsgBox("刪除完成")
                    Else
                        MsgBox("檔案不存在")
                    End If
                    Form1.FBActivityLogs_ListView.Items.Clear()
                End If

            End If
        Catch ex As Exception
            MsgBox("刪除失敗")
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Async Sub NavigateToFBActivityLogSelectedGroupURL_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task(Form1.FBActivityLogsGroupURL_TextBox.Text)
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub DisplayCurrUrlToFBActivityLogUrl_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Form1.FBActivityLogsGroupURL_TextBox.Text = Webview2Controller.edgeDriver.Url
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub AddItemToFBActivityLogListview_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim name = Form1.FBActivityLogsGroupName_TextBox.Text
            Dim url = Form1.FBActivityLogsGroupURL_TextBox.Text

            If name <> "" And url <> "" Then
                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBActivityLogs_ListView.Items.Insert(0, newItem)
            Else
                MsgBox("欄位不得為空")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub EditSelectedFBActivityLogListviewItem_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.FBActivityLogs_ListView.SelectedItems.Count > 0 Then
                Dim name = Form1.FBActivityLogsGroupName_TextBox.Text
                Dim url = Form1.FBActivityLogsGroupURL_TextBox.Text
                If name <> "" And url <> "" Then
                    Dim selectedItem = Form1.FBActivityLogs_ListView.SelectedItems(0)
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

    Public Async Sub WebviewUserDataFolder_ListBox_DoubleClick(sender As Object, e As EventArgs)
        Try
            'Debug.WriteLine("IsWebview2Lock" & IsWebview2Lock)
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem = "" Then
                Exit Sub
            End If

            If IsWebview2Lock = True Then
                MsgBox("Webview2載入中，請稍後")
                Exit Sub
            End If

            Dim userDataFolder = Nothing
            Dim folderName = Split(Form1.WebviewUserDataFolder_ListBox.SelectedItem, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(webivewUserDataDirectory, folderName(0), folderName(1))
            End If
            ' need to auto detect debug port
            ' use 9222 for development
            'Dim debugPort = DebugForm.Webview_Edge_Debug_Port_NumericUpDown.Value
            'Dim debugPort = 9222
            Await RestartMainWebView2(userDataFolder)
            Await Navigate_GoToUrl_Task(Form1.Navigate_Url_TextBox.Text)
        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try
    End Sub

    Public Sub ReadCookie_Button_Click(sender As Object, e As EventArgs)
        Webview2Controller.ReadCookie()
    End Sub

    Public Sub SetCookie_Button_Click(sender As Object, e As EventArgs)
        Webview2Controller.SetCookie()
    End Sub



    Public Async Sub TurnOnSetSeleteKeyboardShortcuts_Button_Click(sender As Object, e As EventArgs)

        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In Form1.WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))

                Await Webview2Controller.RestartMainWebView2(userDataFolder)
                Await Webview2Controller.Navigate_GoToUrl_Task("https://www.facebook.com/")
                Await Webview2Controller.Delay_msec(1000)
                Await Webview2Controller.TurnOnFBKeyboardShortcuts_Task()
                Await Webview2Controller.Delay_msec(1000)
                'Debug.WriteLine("EOF")
            End If
        Next
    End Sub

    Public Async Sub SetSeletedFBLanguageTo_zhTW_Button_Click(sender As Object, e As EventArgs)

        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In Form1.WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders
            'Debug.WriteLine("item : " & item)

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If

            Await Webview2Controller.RestartMainWebView2(userDataFolder)
            Await Webview2Controller.Navigate_GoToUrl_Task("https://www.facebook.com/")
            Await Webview2Controller.Delay_msec(1000)

            Await SetFBLanguageTo_zhTW_Task()
            Await Webview2Controller.Delay_msec(1000)
            'Debug.WriteLine("EOF")
        Next

    End Sub

    Public Async Sub RequestFriend_Button_Click(sender As Object, e As EventArgs)
        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In Form1.WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders
            'Debug.WriteLine("item : " & item)

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If

            Await Webview2Controller.RestartMainWebView2(userDataFolder)
            Await Webview2Controller.Delay_msec(1000)

            Await Navigate_GoToUrl_Task(Form1.Navigate_Url_TextBox.Text)

            Await FBRquestFrient()

            Await Webview2Controller.Delay_msec(1000)
            'Debug.WriteLine("EOF")
        Next
    End Sub


    Public Async Sub NavigateToSelectedGroup_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task(Form1.FBGroupUrl_TextBox.Text)
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub DisplayCurrUrlToGroupUrl_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Form1.FBGroupUrl_TextBox.Text = Webview2Controller.edgeDriver.Url
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub ShowEmojiPicker_Button_Click(sender As Object, e As EventArgs)
        If EmojiPickerForm.Visible Then
            EmojiPickerForm.Hide()
            'emojiPickerForm.UpdateForm2Position()
        Else
            EmojiPickerForm.Show()
            EmojiPickerForm.UpdateForm2Position()
        End If
    End Sub

    Public Sub Form1_Move(sender As Object, e As EventArgs)
        If EmojiPickerForm IsNot Nothing Then
            EmojiPickerForm.UpdateForm2Position()
        End If
    End Sub

    Public Sub Form1_Resize(sender As Object, e As EventArgs)
        If EmojiPickerForm IsNot Nothing Then
            EmojiPickerForm.UpdateForm2Position()
        End If
    End Sub


    Public Sub InsertToQueueListview_Button_Click(sender As Object, e As EventArgs)
        'Debug.WriteLine("click")
        InserScriptItemToListview(False)

    End Sub

    Public Sub InsertSchedulerScriptToListview_Button_Click(sender As Object, e As EventArgs)
        InserScriptItemToListview(True)
    End Sub

    Public Sub SelectListviewItemsByUserDataButton_Click(sender As Object, e As EventArgs)
        If Form1.userData_ComboBox.Text <> "" Then
            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
                If item.SubItems(0).Text = Form1.userData_ComboBox.Text Then
                    item.Selected = True
                End If
            Next
        Else
            For Each item As ListViewItem In Form1.ScriptQueue_ListView.Items
                item.Selected = True
            Next
        End If
    End Sub


    Public Async Sub ReadFBNotifications_Button_Click(sender As Object, e As EventArgs)
        If ActivedUserDataFolderPath Is Nothing Then
            MsgBox("未偵測到啟用的edgedriver")
            Exit Sub

        End If
        Await Webview2Controller.ReadFBNotifications(Form1.ReadFBNotifications_CheckBox.Checked, Form1.UnreadFBNotifications_CheckBox.Checked)
    End Sub

    Public Sub SaveFBNotificationsListview_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                MsgBox("未選擇使用者")
                Exit Sub
            End If

            Dim items As New List(Of GroupListviewDataStruct)()
            For Each item As ListViewItem In Form1.FBNotificationsData_Listview.Items

                Dim listViewItemData As New GroupListviewDataStruct With {
                    .Name = item.Text,
                    .Url = item.SubItems(1).Text
                }
                items.Add(listViewItemData)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(items, Formatting.Indented)
            Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBNotificationList.json")
            File.WriteAllText(filePath, jsonStr)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try
    End Sub


    Public Sub FBNotificationsData_Listview_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If Form1.FBNotificationsData_Listview.SelectedItems.Count > 0 Then
                'Debug.WriteLine(Form1.FBGroups_ListView.SelectedItems(0).Text)
                Dim selectedItem = Form1.FBNotificationsData_Listview.SelectedItems(0)
                Form1.FBNotificationsName_TextBox.Text = selectedItem.Text
                Form1.FBNotificationsUrl_TextBox.Text = selectedItem.SubItems(1).Text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub DeleteSelectedFBNotificationsListviewItems_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim selectedItems = Form1.FBNotificationsData_Listview.SelectedItems
            If selectedItems.Count > 0 Then
                For i As Integer = selectedItems.Count - 1 To 0 Step -1
                    Form1.FBNotificationsData_Listview.Items.Remove(selectedItems(i))
                Next
            Else

                If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                    MsgBox("未選擇使用者")
                    Exit Sub
                End If

                Dim result As DialogResult = MessageBox.Show("確定要刪除通知列表檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBNotificationList.json")

                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                        MsgBox("刪除完成")
                    Else
                        MsgBox("檔案不存在")
                    End If
                    Form1.FBNotificationsData_Listview.Items.Clear()
                End If

            End If
        Catch ex As Exception
            MsgBox("刪除失敗")
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBNotificationsDisplayCurrUrl_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Form1.FBNotificationsUrl_TextBox.Text = Webview2Controller.edgeDriver.Url
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Async Sub FBNotificationsNavigateToSelectedURL_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task(Form1.FBNotificationsUrl_TextBox.Text)
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBNotificationsAddItemToListview_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim name = Form1.FBNotificationsName_TextBox.Text
            Dim url = Form1.FBNotificationsUrl_TextBox.Text

            If name <> "" And url <> "" Then
                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBNotificationsData_Listview.Items.Insert(0, newItem)
            Else
                MsgBox("欄位不得為空")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Sub FBNotificationsEditSelectedListviewItem_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.FBNotificationsData_Listview.SelectedItems.Count > 0 Then
                Dim name = Form1.FBNotificationsName_TextBox.Text
                Dim url = Form1.FBNotificationsUrl_TextBox.Text
                If name <> "" And url <> "" Then
                    Dim selectedItem = Form1.FBNotificationsData_Listview.SelectedItems(0)
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


    Public Sub DefaultScriptInsertion_RadioButton_Click(sender As Object, e As EventArgs)
        Form1.CustomizeScriptInsertion_RadioButton.Checked = False
        Form1.CustomizeAction_ComboBox.Enabled = False
    End Sub

    Public Sub CustomizeScriptInsertion_RadioButton_Click(sender As Object, e As EventArgs)
        Form1.DefaultScriptInsertion_RadioButton.Checked = False
        Form1.CustomizeAction_ComboBox.Enabled = True
    End Sub


    Public Sub FBUrlData_TabControl_SelectedIndexChanged(sender As Object, e As EventArgs)

        If Form1.FBUrlData_TabControl.SelectedTab Is Form1.FBNotifications_TabPage Then
            Form1.Action_TabControl.SelectedTab = Form1.FBRespondNotifications_TabPage
        ElseIf Form1.FBUrlData_TabControl.SelectedTab Is Form1.FBGroups_TabPage Then
            Form1.Action_TabControl.SelectedTab = Form1.FBPost_TabPage
        ElseIf Form1.FBUrlData_TabControl.SelectedTab Is Form1.FBActivityLogs_TabPage Then
            Form1.Action_TabControl.SelectedTab = Form1.FBComment_TabPage
        End If

    End Sub

    Public Sub Action_TabControl_SelectedIndexChanged(sender As Object, e As EventArgs)

        If Form1.Action_TabControl.SelectedTab Is Form1.FBRespondNotifications_TabPage Then
            Form1.FBUrlData_TabControl.SelectedTab = Form1.FBNotifications_TabPage

        ElseIf Form1.Action_TabControl.SelectedTab Is Form1.FBComment_TabPage Or Form1.Action_TabControl.SelectedTab Is Form1.FBCustomizeComment_TabPage Then

            Form1.FBUrlData_TabControl.SelectedTab = Form1.FBActivityLogs_TabPage
        Else
            Form1.FBUrlData_TabControl.SelectedTab = Form1.FBGroups_TabPage
        End If

    End Sub

    Public Sub DeselecteAllFBGroups_ListViewItems_Button_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In Form1.FBGroups_ListView.Items
            item.Selected = False
        Next
    End Sub

    Public Sub DeselectAllFBActivityLogs_ListViewItems_Button_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In Form1.FBActivityLogs_ListView.SelectedItems
            item.Selected = False
        Next
    End Sub

    Public Sub DeselecteAllFBNotificationsData_ListviewItems_Button_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In Form1.FBNotificationsData_Listview.SelectedItems
            item.Selected = False
        Next
    End Sub

    Public Sub DeselecteAllFBMessengerData_ListviewItems_Button_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In Form1.FBMessengerData_Listview.SelectedItems
            item.Selected = False
        Next
    End Sub


    Public Sub FBMessengerAddItemToListview_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim name = Form1.FBMessengerName_TextBox.Text
            Dim url = Form1.FBMessengerUrl_TextBox.Text

            If name <> "" And url <> "" Then
                Dim newItem As New ListViewItem(name)
                newItem.SubItems.Add(url)
                Form1.FBMessengerData_Listview.Items.Insert(0, newItem)
            Else
                MsgBox("欄位不得為空")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub SaveFBMessengerListview_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                MsgBox("未選擇使用者")
                Exit Sub
            End If

            Dim items As New List(Of GroupListviewDataStruct)()
            For Each item As ListViewItem In Form1.FBMessengerData_Listview.Items

                Dim listViewItemData As New GroupListviewDataStruct With {
                    .Name = item.Text,
                    .Url = item.SubItems(1).Text
                }
                items.Add(listViewItemData)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(items, Formatting.Indented)
            Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBMessengerList.json")
            File.WriteAllText(filePath, jsonStr)
            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try
    End Sub


    Public Sub FBMessengerData_Listview_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            If Form1.FBMessengerData_Listview.SelectedItems.Count > 0 Then
                'Debug.WriteLine(Form1.FBGroups_ListView.SelectedItems(0).Text)
                Dim selectedItem = Form1.FBMessengerData_Listview.SelectedItems(0)
                Form1.FBMessengerName_TextBox.Text = selectedItem.Text
                Form1.FBMessengerUrl_TextBox.Text = selectedItem.SubItems(1).Text
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub DeleteSelectedFBMessengerListviewItems_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim selectedItems = Form1.FBMessengerData_Listview.SelectedItems
            If selectedItems.Count > 0 Then
                For i As Integer = selectedItems.Count - 1 To 0 Step -1
                    Form1.FBMessengerData_Listview.Items.Remove(selectedItems(i))
                Next
            Else

                If Form1.WebviewUserDataFolder_ListBox.SelectedItem Is Nothing Then
                    MsgBox("未選擇使用者")
                    Exit Sub
                End If

                Dim result As DialogResult = MessageBox.Show("確定要刪除聊天室列表檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim filePath As String = Path.Combine(webivewUserDataDirectory, Form1.WebviewUserDataFolder_ListBox.SelectedItem, "FBMessengerList.json")

                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                        MsgBox("刪除完成")
                    Else
                        MsgBox("檔案不存在")
                    End If
                    Form1.FBMessengerData_Listview.Items.Clear()
                End If

            End If
        Catch ex As Exception
            MsgBox("刪除失敗")
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBMessengerDisplayCurrUrl_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Form1.FBMessengerUrl_TextBox.Text = Webview2Controller.edgeDriver.Url
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Async Sub FBMessengerNavigateToSelectedURL_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task(Form1.FBMessengerUrl_TextBox.Text)
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub FBMessengerEditSelectedListviewItem_Button_Click(sender As Object, e As EventArgs)
        Try
            If Form1.FBMessengerData_Listview.SelectedItems.Count > 0 Then
                Dim name = Form1.FBMessengerName_TextBox.Text
                Dim url = Form1.FBMessengerUrl_TextBox.Text
                If name <> "" And url <> "" Then
                    Dim selectedItem = Form1.FBMessengerData_Listview.SelectedItems(0)
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

    Public Async Sub FBMessengerNavigateToMessenger_Button_Click(sender As Object, e As EventArgs)
        Try
            If Webview2Controller.edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task("https://www.messenger.com/")
            Else
                MsgBox("未偵測到EdgeDriver")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
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

        If selectedUserDataFolderItems.Count < 1 Then
            MsgBox("未選擇userdata")
            Exit Sub
        End If

        If Form1.CustomizeScriptInsertion_RadioButton.Checked Then
            selecteAction = Form1.CustomizeAction_ComboBox.Text
            If selecteAction = "" Then
                MsgBox("未選擇自訂功能")
                Exit Sub
            End If
        End If

        Select Case selecteAction
            Case "發帖"
                If Form1.MyAssetsFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.MyAssetsFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "拍賣"
                If Form1.FBMarkplaceProducts_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBMarkplaceProducts_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "分享"
                If Form1.FBPostShareURLAssetFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBPostShareURLAssetFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "留言"
                selectedGroupItems = Form1.FBActivityLogs_ListView.SelectedItems
                If Form1.FBCommentAssetFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBCommentAssetFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "自訂"
                If Form1.FBCustomizeCommentAssetFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBCustomizeCommentAssetFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "回應"
                selectedGroupItems = Form1.FBNotificationsData_Listview.SelectedItems
                If Form1.FBResponseAssetFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBResponseAssetFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If
            Case "順序回應通知"
                selectedGroupItems = Form1.FBNotificationsData_Listview.SelectedItems
                If Form1.FBResponseAssetFolder_ListBox.SelectedItems.Count > 0 Then
                    For Each item In Form1.FBResponseAssetFolder_ListBox.SelectedItems
                        content += item + "&"
                    Next
                    content = content.TrimEnd("&")
                Else
                    content = "隨機"
                End If

        End Select

        Dim selectedUserDataFolder = "NULL"

        ' 第一個選擇的UserDataFolder
        For Each selectedUserData In selectedUserDataFolderItems
            selectedUserDataFolder = selectedUserData.ToString()
        Next

        ' refactor test
        If scheduled Then '定時執行

            Dim baseSeconds = Form1.ScheduledExecutionHours_NumericUpDown.Value * 3600 + Form1.ScheduledExecutionMinutes_NumericUpDown.Value * 60 + Form1.ScheduledExecutionSeconds_NumericUpDown.Value
            executionTime = UtilsModule.ConvertSecondsToTimeFormat(baseSeconds)
            If Form1.CustomizeScriptInsertion_RadioButton.Checked Then ' 自訂功能
                AddScriptQueueItem(selectedUserDataFolder, executionTime, "NULL", "NULL", content, selecteAction, executionWaitSeconds)
            Else ' 預設功能


                If selectedGroupItems.Count > 0 Then ' 有選超過一個網址項目
                    For Each selectedGroupItem As ListViewItem In selectedGroupItems
                        executionTime = UtilsModule.ConvertSecondsToTimeFormat(baseSeconds)
                        baseSeconds += Form1.SchedulerIntervalSeconds_NumericUpDown.Value
                        AddScriptQueueItem(selectedUserDataFolder, executionTime, selectedGroupItem.Text, selectedGroupItem.SubItems(1).Text, content, selecteAction, executionWaitSeconds)
                    Next
                Else ' 沒選就隨機
                    AddScriptQueueItem(selectedUserDataFolder, executionTime, "隨機", "隨機", content, selecteAction, executionWaitSeconds)
                End If

            End If

        Else ' 順序執行
            If Form1.CustomizeScriptInsertion_RadioButton.Checked Then ' 自訂功能
                AddScriptQueueItem(selectedUserDataFolder, executionTime, "NULL", "NULL", content, selecteAction, executionWaitSeconds)
            Else ' 預設功能
                If selectedGroupItems.Count > 0 Then
                    For Each selectedGroupItem As ListViewItem In selectedGroupItems
                        AddScriptQueueItem(selectedUserDataFolder, executionTime, selectedGroupItem.Text, selectedGroupItem.SubItems(1).Text, content, selecteAction, executionWaitSeconds)
                    Next
                Else ' 沒選就隨機
                    AddScriptQueueItem(selectedUserDataFolder, executionTime, "隨機", "隨機", content, selecteAction, executionWaitSeconds)
                End If
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

End Class
