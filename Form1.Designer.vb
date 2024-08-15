<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem1 As ListViewItem = New ListViewItem(New String() {"google", "https://google.com/"}, -1)
        Dim ListViewItem2 As ListViewItem = New ListViewItem(New String() {"Bing", "https://bing.com/"}, -1)
        Main_WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Navigate_Url_TextBox = New TextBox()
        NavigateTo_Url_Button = New Button()
        UserInfo_GroupBox = New GroupBox()
        SaveUserData_Button = New Button()
        Remark_RichTextBox = New RichTextBox()
        SetCookie_Button = New Button()
        ReadCookie_Button = New Button()
        Label7 = New Label()
        FBCookie_RichTextBox = New RichTextBox()
        Label6 = New Label()
        FB2FA_TextBox = New TextBox()
        Label5 = New Label()
        RevealEmailPasswordText_Button = New Button()
        EmailPassword_TextBox = New TextBox()
        Label3 = New Label()
        EmailAccount_TextBox = New TextBox()
        Label4 = New Label()
        RevealFBPasswordText_Button = New Button()
        FBPassword_TextBox = New TextBox()
        Label2 = New Label()
        FBAccount_TextBox = New TextBox()
        Label1 = New Label()
        UserDataFolderName_TextBox = New TextBox()
        CreateUserDataFolderButton = New Button()
        DeleteSelectedUserDataFolderButton = New Button()
        UserDataFoldListFilter_GroupBox = New GroupBox()
        FilterUnavailableUserData_CheckBox = New CheckBox()
        FilterAvailableUserData_CheckBox = New CheckBox()
        Move_UserDataFolder_Button = New Button()
        SetSeletedFBLanguageTo_zhTW_Button = New Button()
        TurnOnSetSeleteKeyboardShortcuts_Button = New Button()
        WebviewUserDataFolder_ListBox = New ListBox()
        RequestFriend_Button = New Button()
        GetCurrentUrl_Button = New Button()
        FBData_TabControl = New TabControl()
        FBGroups_TabPage = New TabPage()
        GetJoinedGroupList_Button = New Button()
        DeleteSelectedGroup_Button = New Button()
        SaveListviewGroupList_Button = New Button()
        GetFBGroupList_Button = New Button()
        EditSelectedGroupListviewItem_Button = New Button()
        AddGroupDataToGroupListview_Button = New Button()
        DisplayCurrUrlToGroupUrl_Button = New Button()
        NavigateToSelectedGroup_Button = New Button()
        FBGroupUrl_TextBox = New TextBox()
        FBGroupName_TextBox = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        FBGroups_ListView = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        TabPage2 = New TabPage()
        ScriptQueue_ListView = New ListView()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ColumnHeader7 = New ColumnHeader()
        ColumnHeader6 = New ColumnHeader()
        ColumnHeader8 = New ColumnHeader()
        ColumnHeader5 = New ColumnHeader()
        ColumnHeader9 = New ColumnHeader()
        ColumnHeader10 = New ColumnHeader()
        Action_TabControl = New TabControl()
        TabPage1 = New TabPage()
        DeselectAllMyAssetFolderListboxItems_Button = New Button()
        DeleteSelectedTextFiles_Button = New Button()
        NewTextFileName_TextBox = New TextBox()
        MediaSelector_ListBox = New ListBox()
        TextFileSelector_ListBox = New ListBox()
        MyAssetsFolder_ListBox = New ListBox()
        SaveEditedTextFile_Button = New Button()
        CreateNewTextFile_Button = New Button()
        DeleteSelectedMedia_Button = New Button()
        RevealMediaFoldesrInFileExplorer_Button = New Button()
        DeleteSelectedAssetFolder_Button = New Button()
        NewAssetFolderName_TextBox = New TextBox()
        MediaPreview_PictureBox = New PictureBox()
        PreviewTextFile_RichTextBox = New RichTextBox()
        CreateNewAssetFolder_Button = New Button()
        TabPage3 = New TabPage()
        ScriptTask_GroupBox = New GroupBox()
        ContinueScriptExecution_Button = New Button()
        PauseScriptExecution_Button = New Button()
        Button3 = New Button()
        Label20 = New Label()
        NumericUpDown2 = New NumericUpDown()
        Label19 = New Label()
        ExecutionScriptQueue_Button = New Button()
        Label18 = New Label()
        ExecutionWaitRandomSeconds_NumericUpDown = New NumericUpDown()
        Label17 = New Label()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        ExecutionWaitMinutes_NumericUpDown = New NumericUpDown()
        ExecutionWaitHours_NumericUpDown = New NumericUpDown()
        ExecutionWaitSeconds_NumericUpDown = New NumericUpDown()
        InsertToQueueListview_Button = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label13 = New Label()
        NumericUpDown1 = New NumericUpDown()
        DateTimePicker1 = New DateTimePicker()
        Label12 = New Label()
        Label11 = New Label()
        Label8 = New Label()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        UserInfo_GroupBox.SuspendLayout()
        UserDataFoldListFilter_GroupBox.SuspendLayout()
        FBData_TabControl.SuspendLayout()
        FBGroups_TabPage.SuspendLayout()
        Action_TabControl.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(MediaPreview_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        ScriptTask_GroupBox.SuspendLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitRandomSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitMinutes_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitHours_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.BackColor = Color.White
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.ForeColor = Color.Black
        Main_WebView2.Location = New Point(1096, 607)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(669, 439)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1.0R
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(1096, 574)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(424, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(1526, 574)
        NavigateTo_Url_Button.Name = "NavigateTo_Url_Button"
        NavigateTo_Url_Button.Size = New Size(94, 29)
        NavigateTo_Url_Button.TabIndex = 6
        NavigateTo_Url_Button.Text = "前往"
        NavigateTo_Url_Button.UseVisualStyleBackColor = True
        ' 
        ' UserInfo_GroupBox
        ' 
        UserInfo_GroupBox.Controls.Add(SaveUserData_Button)
        UserInfo_GroupBox.Controls.Add(Remark_RichTextBox)
        UserInfo_GroupBox.Controls.Add(SetCookie_Button)
        UserInfo_GroupBox.Controls.Add(ReadCookie_Button)
        UserInfo_GroupBox.Controls.Add(Label7)
        UserInfo_GroupBox.Controls.Add(FBCookie_RichTextBox)
        UserInfo_GroupBox.Controls.Add(Label6)
        UserInfo_GroupBox.Controls.Add(FB2FA_TextBox)
        UserInfo_GroupBox.Controls.Add(Label5)
        UserInfo_GroupBox.Controls.Add(RevealEmailPasswordText_Button)
        UserInfo_GroupBox.Controls.Add(EmailPassword_TextBox)
        UserInfo_GroupBox.Controls.Add(Label3)
        UserInfo_GroupBox.Controls.Add(EmailAccount_TextBox)
        UserInfo_GroupBox.Controls.Add(Label4)
        UserInfo_GroupBox.Controls.Add(RevealFBPasswordText_Button)
        UserInfo_GroupBox.Controls.Add(FBPassword_TextBox)
        UserInfo_GroupBox.Controls.Add(Label2)
        UserInfo_GroupBox.Controls.Add(FBAccount_TextBox)
        UserInfo_GroupBox.Controls.Add(Label1)
        UserInfo_GroupBox.Location = New Point(212, 12)
        UserInfo_GroupBox.Name = "UserInfo_GroupBox"
        UserInfo_GroupBox.Size = New Size(223, 589)
        UserInfo_GroupBox.TabIndex = 7
        UserInfo_GroupBox.TabStop = False
        UserInfo_GroupBox.Text = "使用者紀錄"
        ' 
        ' SaveUserData_Button
        ' 
        SaveUserData_Button.Location = New Point(6, 554)
        SaveUserData_Button.Name = "SaveUserData_Button"
        SaveUserData_Button.Size = New Size(206, 29)
        SaveUserData_Button.TabIndex = 18
        SaveUserData_Button.Text = "儲存"
        SaveUserData_Button.UseVisualStyleBackColor = True
        ' 
        ' Remark_RichTextBox
        ' 
        Remark_RichTextBox.Location = New Point(6, 429)
        Remark_RichTextBox.Name = "Remark_RichTextBox"
        Remark_RichTextBox.Size = New Size(206, 119)
        Remark_RichTextBox.TabIndex = 17
        Remark_RichTextBox.Text = ""
        ' 
        ' SetCookie_Button
        ' 
        SetCookie_Button.Location = New Point(117, 373)
        SetCookie_Button.Name = "SetCookie_Button"
        SetCookie_Button.Size = New Size(95, 29)
        SetCookie_Button.TabIndex = 16
        SetCookie_Button.Text = "設定Cookie"
        SetCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadCookie_Button
        ' 
        ReadCookie_Button.Location = New Point(6, 373)
        ReadCookie_Button.Name = "ReadCookie_Button"
        ReadCookie_Button.Size = New Size(105, 29)
        ReadCookie_Button.TabIndex = 15
        ReadCookie_Button.Text = "讀取Cookie"
        ReadCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(6, 407)
        Label7.Name = "Label7"
        Label7.Size = New Size(39, 19)
        Label7.TabIndex = 14
        Label7.Text = "備註"
        ' 
        ' FBCookie_RichTextBox
        ' 
        FBCookie_RichTextBox.Location = New Point(6, 305)
        FBCookie_RichTextBox.Name = "FBCookie_RichTextBox"
        FBCookie_RichTextBox.Size = New Size(206, 62)
        FBCookie_RichTextBox.TabIndex = 13
        FBCookie_RichTextBox.Text = ""
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(6, 283)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 19)
        Label6.TabIndex = 12
        Label6.Text = "Cookie"
        ' 
        ' FB2FA_TextBox
        ' 
        FB2FA_TextBox.Location = New Point(6, 253)
        FB2FA_TextBox.Name = "FB2FA_TextBox"
        FB2FA_TextBox.Size = New Size(206, 27)
        FB2FA_TextBox.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(6, 231)
        Label5.Name = "Label5"
        Label5.Size = New Size(69, 19)
        Label5.TabIndex = 10
        Label5.Text = "雙重認證"
        ' 
        ' RevealEmailPasswordText_Button
        ' 
        RevealEmailPasswordText_Button.Location = New Point(162, 201)
        RevealEmailPasswordText_Button.Name = "RevealEmailPasswordText_Button"
        RevealEmailPasswordText_Button.Size = New Size(50, 29)
        RevealEmailPasswordText_Button.TabIndex = 9
        RevealEmailPasswordText_Button.Text = "顯示"
        RevealEmailPasswordText_Button.UseVisualStyleBackColor = True
        ' 
        ' EmailPassword_TextBox
        ' 
        EmailPassword_TextBox.Location = New Point(6, 201)
        EmailPassword_TextBox.Name = "EmailPassword_TextBox"
        EmailPassword_TextBox.PasswordChar = "*"c
        EmailPassword_TextBox.Size = New Size(150, 27)
        EmailPassword_TextBox.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 179)
        Label3.Name = "Label3"
        Label3.Size = New Size(77, 19)
        Label3.TabIndex = 7
        Label3.Text = "Email密碼"
        ' 
        ' EmailAccount_TextBox
        ' 
        EmailAccount_TextBox.Location = New Point(6, 149)
        EmailAccount_TextBox.Name = "EmailAccount_TextBox"
        EmailAccount_TextBox.Size = New Size(206, 27)
        EmailAccount_TextBox.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 127)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 19)
        Label4.TabIndex = 5
        Label4.Text = "Email帳號"
        ' 
        ' RevealFBPasswordText_Button
        ' 
        RevealFBPasswordText_Button.Location = New Point(162, 97)
        RevealFBPasswordText_Button.Name = "RevealFBPasswordText_Button"
        RevealFBPasswordText_Button.Size = New Size(50, 29)
        RevealFBPasswordText_Button.TabIndex = 4
        RevealFBPasswordText_Button.Text = "顯示"
        RevealFBPasswordText_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPassword_TextBox
        ' 
        FBPassword_TextBox.Location = New Point(6, 97)
        FBPassword_TextBox.Name = "FBPassword_TextBox"
        FBPassword_TextBox.PasswordChar = "*"c
        FBPassword_TextBox.Size = New Size(150, 27)
        FBPassword_TextBox.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 75)
        Label2.Name = "Label2"
        Label2.Size = New Size(105, 19)
        Label2.TabIndex = 2
        Label2.Text = "Fackbook密碼"
        ' 
        ' FBAccount_TextBox
        ' 
        FBAccount_TextBox.Location = New Point(6, 45)
        FBAccount_TextBox.Name = "FBAccount_TextBox"
        FBAccount_TextBox.Size = New Size(206, 27)
        FBAccount_TextBox.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 19)
        Label1.TabIndex = 0
        Label1.Text = "Fackbook帳號"
        ' 
        ' UserDataFolderName_TextBox
        ' 
        UserDataFolderName_TextBox.Location = New Point(12, 463)
        UserDataFolderName_TextBox.Name = "UserDataFolderName_TextBox"
        UserDataFolderName_TextBox.Size = New Size(94, 27)
        UserDataFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateUserDataFolderButton
        ' 
        CreateUserDataFolderButton.Location = New Point(112, 463)
        CreateUserDataFolderButton.Name = "CreateUserDataFolderButton"
        CreateUserDataFolderButton.Size = New Size(94, 29)
        CreateUserDataFolderButton.TabIndex = 10
        CreateUserDataFolderButton.Text = "新增"
        CreateUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedUserDataFolderButton
        ' 
        DeleteSelectedUserDataFolderButton.Location = New Point(112, 498)
        DeleteSelectedUserDataFolderButton.Name = "DeleteSelectedUserDataFolderButton"
        DeleteSelectedUserDataFolderButton.Size = New Size(94, 29)
        DeleteSelectedUserDataFolderButton.TabIndex = 11
        DeleteSelectedUserDataFolderButton.Text = "刪除所選"
        DeleteSelectedUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' UserDataFoldListFilter_GroupBox
        ' 
        UserDataFoldListFilter_GroupBox.Controls.Add(FilterUnavailableUserData_CheckBox)
        UserDataFoldListFilter_GroupBox.Controls.Add(FilterAvailableUserData_CheckBox)
        UserDataFoldListFilter_GroupBox.Location = New Point(12, 363)
        UserDataFoldListFilter_GroupBox.Name = "UserDataFoldListFilter_GroupBox"
        UserDataFoldListFilter_GroupBox.Size = New Size(194, 93)
        UserDataFoldListFilter_GroupBox.TabIndex = 13
        UserDataFoldListFilter_GroupBox.TabStop = False
        UserDataFoldListFilter_GroupBox.Text = "顯示"
        ' 
        ' FilterUnavailableUserData_CheckBox
        ' 
        FilterUnavailableUserData_CheckBox.AutoSize = True
        FilterUnavailableUserData_CheckBox.Location = New Point(6, 55)
        FilterUnavailableUserData_CheckBox.Name = "FilterUnavailableUserData_CheckBox"
        FilterUnavailableUserData_CheckBox.Size = New Size(61, 23)
        FilterUnavailableUserData_CheckBox.TabIndex = 1
        FilterUnavailableUserData_CheckBox.Text = "無效"
        FilterUnavailableUserData_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FilterAvailableUserData_CheckBox
        ' 
        FilterAvailableUserData_CheckBox.AutoSize = True
        FilterAvailableUserData_CheckBox.Checked = True
        FilterAvailableUserData_CheckBox.CheckState = CheckState.Checked
        FilterAvailableUserData_CheckBox.Location = New Point(6, 26)
        FilterAvailableUserData_CheckBox.Name = "FilterAvailableUserData_CheckBox"
        FilterAvailableUserData_CheckBox.Size = New Size(61, 23)
        FilterAvailableUserData_CheckBox.TabIndex = 0
        FilterAvailableUserData_CheckBox.Text = "可用"
        FilterAvailableUserData_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' Move_UserDataFolder_Button
        ' 
        Move_UserDataFolder_Button.Location = New Point(12, 496)
        Move_UserDataFolder_Button.Name = "Move_UserDataFolder_Button"
        Move_UserDataFolder_Button.Size = New Size(94, 29)
        Move_UserDataFolder_Button.TabIndex = 14
        Move_UserDataFolder_Button.Text = "移動所選"
        Move_UserDataFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' SetSeletedFBLanguageTo_zhTW_Button
        ' 
        SetSeletedFBLanguageTo_zhTW_Button.Location = New Point(12, 531)
        SetSeletedFBLanguageTo_zhTW_Button.Name = "SetSeletedFBLanguageTo_zhTW_Button"
        SetSeletedFBLanguageTo_zhTW_Button.Size = New Size(94, 29)
        SetSeletedFBLanguageTo_zhTW_Button.TabIndex = 15
        SetSeletedFBLanguageTo_zhTW_Button.Text = "設定中文"
        SetSeletedFBLanguageTo_zhTW_Button.UseVisualStyleBackColor = True
        ' 
        ' TurnOnSetSeleteKeyboardShortcuts_Button
        ' 
        TurnOnSetSeleteKeyboardShortcuts_Button.Location = New Point(112, 533)
        TurnOnSetSeleteKeyboardShortcuts_Button.Name = "TurnOnSetSeleteKeyboardShortcuts_Button"
        TurnOnSetSeleteKeyboardShortcuts_Button.Size = New Size(94, 29)
        TurnOnSetSeleteKeyboardShortcuts_Button.TabIndex = 17
        TurnOnSetSeleteKeyboardShortcuts_Button.Text = "設定快捷鍵"
        TurnOnSetSeleteKeyboardShortcuts_Button.UseVisualStyleBackColor = True
        ' 
        ' WebviewUserDataFolder_ListBox
        ' 
        WebviewUserDataFolder_ListBox.FormattingEnabled = True
        WebviewUserDataFolder_ListBox.ItemHeight = 19
        WebviewUserDataFolder_ListBox.Location = New Point(12, 12)
        WebviewUserDataFolder_ListBox.Name = "WebviewUserDataFolder_ListBox"
        WebviewUserDataFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        WebviewUserDataFolder_ListBox.Size = New Size(194, 346)
        WebviewUserDataFolder_ListBox.TabIndex = 18
        ' 
        ' RequestFriend_Button
        ' 
        RequestFriend_Button.Location = New Point(12, 566)
        RequestFriend_Button.Name = "RequestFriend_Button"
        RequestFriend_Button.Size = New Size(94, 29)
        RequestFriend_Button.TabIndex = 19
        RequestFriend_Button.Text = "加好友"
        RequestFriend_Button.UseVisualStyleBackColor = True
        ' 
        ' GetCurrentUrl_Button
        ' 
        GetCurrentUrl_Button.Location = New Point(1626, 574)
        GetCurrentUrl_Button.Name = "GetCurrentUrl_Button"
        GetCurrentUrl_Button.Size = New Size(94, 29)
        GetCurrentUrl_Button.TabIndex = 20
        GetCurrentUrl_Button.Text = "取得網址"
        GetCurrentUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBData_TabControl
        ' 
        FBData_TabControl.Controls.Add(FBGroups_TabPage)
        FBData_TabControl.Controls.Add(TabPage2)
        FBData_TabControl.Location = New Point(441, 12)
        FBData_TabControl.Name = "FBData_TabControl"
        FBData_TabControl.SelectedIndex = 0
        FBData_TabControl.Size = New Size(649, 423)
        FBData_TabControl.TabIndex = 23
        ' 
        ' FBGroups_TabPage
        ' 
        FBGroups_TabPage.Controls.Add(GetJoinedGroupList_Button)
        FBGroups_TabPage.Controls.Add(DeleteSelectedGroup_Button)
        FBGroups_TabPage.Controls.Add(SaveListviewGroupList_Button)
        FBGroups_TabPage.Controls.Add(GetFBGroupList_Button)
        FBGroups_TabPage.Controls.Add(EditSelectedGroupListviewItem_Button)
        FBGroups_TabPage.Controls.Add(AddGroupDataToGroupListview_Button)
        FBGroups_TabPage.Controls.Add(DisplayCurrUrlToGroupUrl_Button)
        FBGroups_TabPage.Controls.Add(NavigateToSelectedGroup_Button)
        FBGroups_TabPage.Controls.Add(FBGroupUrl_TextBox)
        FBGroups_TabPage.Controls.Add(FBGroupName_TextBox)
        FBGroups_TabPage.Controls.Add(Label10)
        FBGroups_TabPage.Controls.Add(Label9)
        FBGroups_TabPage.Controls.Add(FBGroups_ListView)
        FBGroups_TabPage.Location = New Point(4, 28)
        FBGroups_TabPage.Name = "FBGroups_TabPage"
        FBGroups_TabPage.Padding = New Padding(3)
        FBGroups_TabPage.Size = New Size(641, 391)
        FBGroups_TabPage.TabIndex = 0
        FBGroups_TabPage.Text = "社團"
        FBGroups_TabPage.UseVisualStyleBackColor = True
        ' 
        ' GetJoinedGroupList_Button
        ' 
        GetJoinedGroupList_Button.Location = New Point(106, 349)
        GetJoinedGroupList_Button.Name = "GetJoinedGroupList_Button"
        GetJoinedGroupList_Button.Size = New Size(109, 29)
        GetJoinedGroupList_Button.TabIndex = 12
        GetJoinedGroupList_Button.Text = "讀取加入社團"
        GetJoinedGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedGroup_Button
        ' 
        DeleteSelectedGroup_Button.Location = New Point(321, 349)
        DeleteSelectedGroup_Button.Name = "DeleteSelectedGroup_Button"
        DeleteSelectedGroup_Button.Size = New Size(94, 29)
        DeleteSelectedGroup_Button.TabIndex = 11
        DeleteSelectedGroup_Button.Text = "刪除"
        DeleteSelectedGroup_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveListviewGroupList_Button
        ' 
        SaveListviewGroupList_Button.Location = New Point(221, 349)
        SaveListviewGroupList_Button.Name = "SaveListviewGroupList_Button"
        SaveListviewGroupList_Button.Size = New Size(94, 29)
        SaveListviewGroupList_Button.TabIndex = 10
        SaveListviewGroupList_Button.Text = "儲存"
        SaveListviewGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' GetFBGroupList_Button
        ' 
        GetFBGroupList_Button.Location = New Point(6, 349)
        GetFBGroupList_Button.Name = "GetFBGroupList_Button"
        GetFBGroupList_Button.Size = New Size(94, 29)
        GetFBGroupList_Button.TabIndex = 9
        GetFBGroupList_Button.Text = "讀取社團"
        GetFBGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' EditSelectedGroupListviewItem_Button
        ' 
        EditSelectedGroupListviewItem_Button.Location = New Point(306, 72)
        EditSelectedGroupListviewItem_Button.Name = "EditSelectedGroupListviewItem_Button"
        EditSelectedGroupListviewItem_Button.Size = New Size(94, 29)
        EditSelectedGroupListviewItem_Button.TabIndex = 8
        EditSelectedGroupListviewItem_Button.Text = "修改"
        EditSelectedGroupListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' AddGroupDataToGroupListview_Button
        ' 
        AddGroupDataToGroupListview_Button.Location = New Point(206, 72)
        AddGroupDataToGroupListview_Button.Name = "AddGroupDataToGroupListview_Button"
        AddGroupDataToGroupListview_Button.Size = New Size(94, 29)
        AddGroupDataToGroupListview_Button.TabIndex = 7
        AddGroupDataToGroupListview_Button.Text = "增加"
        AddGroupDataToGroupListview_Button.UseVisualStyleBackColor = True
        ' 
        ' DisplayCurrUrlToGroupUrl_Button
        ' 
        DisplayCurrUrlToGroupUrl_Button.Location = New Point(106, 72)
        DisplayCurrUrlToGroupUrl_Button.Name = "DisplayCurrUrlToGroupUrl_Button"
        DisplayCurrUrlToGroupUrl_Button.Size = New Size(94, 29)
        DisplayCurrUrlToGroupUrl_Button.TabIndex = 6
        DisplayCurrUrlToGroupUrl_Button.Text = "取得網址"
        DisplayCurrUrlToGroupUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' NavigateToSelectedGroup_Button
        ' 
        NavigateToSelectedGroup_Button.Location = New Point(6, 72)
        NavigateToSelectedGroup_Button.Name = "NavigateToSelectedGroup_Button"
        NavigateToSelectedGroup_Button.Size = New Size(94, 29)
        NavigateToSelectedGroup_Button.TabIndex = 5
        NavigateToSelectedGroup_Button.Text = "前往"
        NavigateToSelectedGroup_Button.UseVisualStyleBackColor = True
        ' 
        ' FBGroupUrl_TextBox
        ' 
        FBGroupUrl_TextBox.Location = New Point(62, 39)
        FBGroupUrl_TextBox.Name = "FBGroupUrl_TextBox"
        FBGroupUrl_TextBox.Size = New Size(573, 27)
        FBGroupUrl_TextBox.TabIndex = 4
        ' 
        ' FBGroupName_TextBox
        ' 
        FBGroupName_TextBox.Location = New Point(62, 6)
        FBGroupName_TextBox.Name = "FBGroupName_TextBox"
        FBGroupName_TextBox.Size = New Size(573, 27)
        FBGroupName_TextBox.TabIndex = 3
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(6, 42)
        Label10.Name = "Label10"
        Label10.Size = New Size(50, 19)
        Label10.TabIndex = 2
        Label10.Text = "網址 : "
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(6, 9)
        Label9.Name = "Label9"
        Label9.Size = New Size(50, 19)
        Label9.TabIndex = 1
        Label9.Text = "名稱 : "
        ' 
        ' FBGroups_ListView
        ' 
        FBGroups_ListView.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
        FBGroups_ListView.FullRowSelect = True
        FBGroups_ListView.Items.AddRange(New ListViewItem() {ListViewItem1, ListViewItem2})
        FBGroups_ListView.Location = New Point(6, 107)
        FBGroups_ListView.Name = "FBGroups_ListView"
        FBGroups_ListView.Size = New Size(629, 236)
        FBGroups_ListView.TabIndex = 0
        FBGroups_ListView.UseCompatibleStateImageBehavior = False
        FBGroups_ListView.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "社團名稱"
        ColumnHeader1.Width = 170
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "社團網址"
        ColumnHeader2.Width = 450
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 28)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(641, 391)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' ScriptQueue_ListView
        ' 
        ScriptQueue_ListView.Columns.AddRange(New ColumnHeader() {ColumnHeader3, ColumnHeader4, ColumnHeader7, ColumnHeader6, ColumnHeader8, ColumnHeader5, ColumnHeader9, ColumnHeader10})
        ScriptQueue_ListView.FullRowSelect = True
        ScriptQueue_ListView.Location = New Point(12, 607)
        ScriptQueue_ListView.Name = "ScriptQueue_ListView"
        ScriptQueue_ListView.Size = New Size(1074, 439)
        ScriptQueue_ListView.TabIndex = 24
        ScriptQueue_ListView.UseCompatibleStateImageBehavior = False
        ScriptQueue_ListView.View = View.Details
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "執行帳號"
        ColumnHeader3.Width = 150
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "執行時間"
        ColumnHeader4.Width = 80
        ' 
        ' ColumnHeader7
        ' 
        ColumnHeader7.Text = "網址名稱"
        ColumnHeader7.Width = 150
        ' 
        ' ColumnHeader6
        ' 
        ColumnHeader6.Text = "目標網址"
        ColumnHeader6.Width = 240
        ' 
        ' ColumnHeader8
        ' 
        ColumnHeader8.Text = "執行內容"
        ColumnHeader8.Width = 200
        ' 
        ' ColumnHeader5
        ' 
        ColumnHeader5.Text = "執行動作"
        ColumnHeader5.Width = 80
        ' 
        ' ColumnHeader9
        ' 
        ColumnHeader9.Text = "執行結果"
        ColumnHeader9.Width = 80
        ' 
        ' ColumnHeader10
        ' 
        ColumnHeader10.Text = "等待時間"
        ColumnHeader10.Width = 90
        ' 
        ' Action_TabControl
        ' 
        Action_TabControl.Controls.Add(TabPage1)
        Action_TabControl.Controls.Add(TabPage3)
        Action_TabControl.Location = New Point(1096, 12)
        Action_TabControl.Name = "Action_TabControl"
        Action_TabControl.SelectedIndex = 0
        Action_TabControl.Size = New Size(673, 499)
        Action_TabControl.TabIndex = 25
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(DeselectAllMyAssetFolderListboxItems_Button)
        TabPage1.Controls.Add(DeleteSelectedTextFiles_Button)
        TabPage1.Controls.Add(NewTextFileName_TextBox)
        TabPage1.Controls.Add(MediaSelector_ListBox)
        TabPage1.Controls.Add(TextFileSelector_ListBox)
        TabPage1.Controls.Add(MyAssetsFolder_ListBox)
        TabPage1.Controls.Add(SaveEditedTextFile_Button)
        TabPage1.Controls.Add(CreateNewTextFile_Button)
        TabPage1.Controls.Add(DeleteSelectedMedia_Button)
        TabPage1.Controls.Add(RevealMediaFoldesrInFileExplorer_Button)
        TabPage1.Controls.Add(DeleteSelectedAssetFolder_Button)
        TabPage1.Controls.Add(NewAssetFolderName_TextBox)
        TabPage1.Controls.Add(MediaPreview_PictureBox)
        TabPage1.Controls.Add(PreviewTextFile_RichTextBox)
        TabPage1.Controls.Add(CreateNewAssetFolder_Button)
        TabPage1.Location = New Point(4, 28)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(665, 467)
        TabPage1.TabIndex = 0
        TabPage1.Text = "發帖"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' DeselectAllMyAssetFolderListboxItems_Button
        ' 
        DeselectAllMyAssetFolderListboxItems_Button.Location = New Point(6, 324)
        DeselectAllMyAssetFolderListboxItems_Button.Name = "DeselectAllMyAssetFolderListboxItems_Button"
        DeselectAllMyAssetFolderListboxItems_Button.Size = New Size(170, 29)
        DeselectAllMyAssetFolderListboxItems_Button.TabIndex = 18
        DeselectAllMyAssetFolderListboxItems_Button.Text = "取消選擇"
        DeselectAllMyAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedTextFiles_Button
        ' 
        DeleteSelectedTextFiles_Button.Location = New Point(451, 187)
        DeleteSelectedTextFiles_Button.Name = "DeleteSelectedTextFiles_Button"
        DeleteSelectedTextFiles_Button.Size = New Size(94, 29)
        DeleteSelectedTextFiles_Button.TabIndex = 17
        DeleteSelectedTextFiles_Button.Text = "刪除所選"
        DeleteSelectedTextFiles_Button.UseVisualStyleBackColor = True
        ' 
        ' NewTextFileName_TextBox
        ' 
        NewTextFileName_TextBox.Location = New Point(182, 187)
        NewTextFileName_TextBox.Name = "NewTextFileName_TextBox"
        NewTextFileName_TextBox.Size = New Size(163, 27)
        NewTextFileName_TextBox.TabIndex = 16
        ' 
        ' MediaSelector_ListBox
        ' 
        MediaSelector_ListBox.FormattingEnabled = True
        MediaSelector_ListBox.ItemHeight = 19
        MediaSelector_ListBox.Location = New Point(182, 222)
        MediaSelector_ListBox.Name = "MediaSelector_ListBox"
        MediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        MediaSelector_ListBox.Size = New Size(163, 156)
        MediaSelector_ListBox.TabIndex = 15
        ' 
        ' TextFileSelector_ListBox
        ' 
        TextFileSelector_ListBox.FormattingEnabled = True
        TextFileSelector_ListBox.ItemHeight = 19
        TextFileSelector_ListBox.Location = New Point(182, 6)
        TextFileSelector_ListBox.Name = "TextFileSelector_ListBox"
        TextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        TextFileSelector_ListBox.Size = New Size(163, 175)
        TextFileSelector_ListBox.TabIndex = 14
        ' 
        ' MyAssetsFolder_ListBox
        ' 
        MyAssetsFolder_ListBox.FormattingEnabled = True
        MyAssetsFolder_ListBox.ItemHeight = 19
        MyAssetsFolder_ListBox.Location = New Point(6, 6)
        MyAssetsFolder_ListBox.Name = "MyAssetsFolder_ListBox"
        MyAssetsFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        MyAssetsFolder_ListBox.Size = New Size(170, 308)
        MyAssetsFolder_ListBox.TabIndex = 13
        ' 
        ' SaveEditedTextFile_Button
        ' 
        SaveEditedTextFile_Button.Location = New Point(551, 187)
        SaveEditedTextFile_Button.Name = "SaveEditedTextFile_Button"
        SaveEditedTextFile_Button.Size = New Size(94, 29)
        SaveEditedTextFile_Button.TabIndex = 12
        SaveEditedTextFile_Button.Text = "儲存修改"
        SaveEditedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' CreateNewTextFile_Button
        ' 
        CreateNewTextFile_Button.Location = New Point(351, 187)
        CreateNewTextFile_Button.Name = "CreateNewTextFile_Button"
        CreateNewTextFile_Button.Size = New Size(94, 29)
        CreateNewTextFile_Button.TabIndex = 11
        CreateNewTextFile_Button.Text = "新增文字檔"
        CreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedMedia_Button
        ' 
        DeleteSelectedMedia_Button.Location = New Point(182, 427)
        DeleteSelectedMedia_Button.Name = "DeleteSelectedMedia_Button"
        DeleteSelectedMedia_Button.Size = New Size(163, 29)
        DeleteSelectedMedia_Button.TabIndex = 9
        DeleteSelectedMedia_Button.Text = "刪除所選"
        DeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' RevealMediaFoldesrInFileExplorer_Button
        ' 
        RevealMediaFoldesrInFileExplorer_Button.Location = New Point(182, 392)
        RevealMediaFoldesrInFileExplorer_Button.Name = "RevealMediaFoldesrInFileExplorer_Button"
        RevealMediaFoldesrInFileExplorer_Button.Size = New Size(163, 29)
        RevealMediaFoldesrInFileExplorer_Button.TabIndex = 8
        RevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        RevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedAssetFolder_Button
        ' 
        DeleteSelectedAssetFolder_Button.Location = New Point(6, 427)
        DeleteSelectedAssetFolder_Button.Name = "DeleteSelectedAssetFolder_Button"
        DeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        DeleteSelectedAssetFolder_Button.TabIndex = 7
        DeleteSelectedAssetFolder_Button.Text = "刪除所選"
        DeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' NewAssetFolderName_TextBox
        ' 
        NewAssetFolderName_TextBox.Location = New Point(6, 359)
        NewAssetFolderName_TextBox.Name = "NewAssetFolderName_TextBox"
        NewAssetFolderName_TextBox.Size = New Size(170, 27)
        NewAssetFolderName_TextBox.TabIndex = 6
        ' 
        ' MediaPreview_PictureBox
        ' 
        MediaPreview_PictureBox.Location = New Point(351, 222)
        MediaPreview_PictureBox.Name = "MediaPreview_PictureBox"
        MediaPreview_PictureBox.Size = New Size(294, 234)
        MediaPreview_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        MediaPreview_PictureBox.TabIndex = 5
        MediaPreview_PictureBox.TabStop = False
        ' 
        ' PreviewTextFile_RichTextBox
        ' 
        PreviewTextFile_RichTextBox.Location = New Point(351, 6)
        PreviewTextFile_RichTextBox.Name = "PreviewTextFile_RichTextBox"
        PreviewTextFile_RichTextBox.Size = New Size(294, 175)
        PreviewTextFile_RichTextBox.TabIndex = 4
        PreviewTextFile_RichTextBox.Text = ""
        ' 
        ' CreateNewAssetFolder_Button
        ' 
        CreateNewAssetFolder_Button.Location = New Point(6, 392)
        CreateNewAssetFolder_Button.Name = "CreateNewAssetFolder_Button"
        CreateNewAssetFolder_Button.Size = New Size(170, 29)
        CreateNewAssetFolder_Button.TabIndex = 2
        CreateNewAssetFolder_Button.Text = "建立"
        CreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Location = New Point(4, 28)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(665, 467)
        TabPage3.TabIndex = 1
        TabPage3.Text = "TabPage3"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' ScriptTask_GroupBox
        ' 
        ScriptTask_GroupBox.Controls.Add(ContinueScriptExecution_Button)
        ScriptTask_GroupBox.Controls.Add(PauseScriptExecution_Button)
        ScriptTask_GroupBox.Controls.Add(Button3)
        ScriptTask_GroupBox.Controls.Add(Label20)
        ScriptTask_GroupBox.Controls.Add(NumericUpDown2)
        ScriptTask_GroupBox.Controls.Add(Label19)
        ScriptTask_GroupBox.Controls.Add(ExecutionScriptQueue_Button)
        ScriptTask_GroupBox.Controls.Add(Label18)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitRandomSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(Label17)
        ScriptTask_GroupBox.Controls.Add(Label16)
        ScriptTask_GroupBox.Controls.Add(Label15)
        ScriptTask_GroupBox.Controls.Add(Label14)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitMinutes_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitHours_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(InsertToQueueListview_Button)
        ScriptTask_GroupBox.Controls.Add(Button2)
        ScriptTask_GroupBox.Controls.Add(Button1)
        ScriptTask_GroupBox.Controls.Add(Label13)
        ScriptTask_GroupBox.Controls.Add(NumericUpDown1)
        ScriptTask_GroupBox.Controls.Add(DateTimePicker1)
        ScriptTask_GroupBox.Controls.Add(Label12)
        ScriptTask_GroupBox.Controls.Add(Label11)
        ScriptTask_GroupBox.Controls.Add(Label8)
        ScriptTask_GroupBox.Location = New Point(441, 441)
        ScriptTask_GroupBox.Name = "ScriptTask_GroupBox"
        ScriptTask_GroupBox.Size = New Size(645, 160)
        ScriptTask_GroupBox.TabIndex = 26
        ScriptTask_GroupBox.TabStop = False
        ScriptTask_GroupBox.Text = "腳本任務"
        ' 
        ' ContinueScriptExecution_Button
        ' 
        ContinueScriptExecution_Button.Location = New Point(524, 105)
        ContinueScriptExecution_Button.Name = "ContinueScriptExecution_Button"
        ContinueScriptExecution_Button.Size = New Size(94, 29)
        ContinueScriptExecution_Button.TabIndex = 25
        ContinueScriptExecution_Button.Text = "繼續"
        ContinueScriptExecution_Button.UseVisualStyleBackColor = True
        ' 
        ' PauseScriptExecution_Button
        ' 
        PauseScriptExecution_Button.Location = New Point(424, 105)
        PauseScriptExecution_Button.Name = "PauseScriptExecution_Button"
        PauseScriptExecution_Button.Size = New Size(94, 29)
        PauseScriptExecution_Button.TabIndex = 24
        PauseScriptExecution_Button.Text = "暫停"
        PauseScriptExecution_Button.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(558, 63)
        Button3.Name = "Button3"
        Button3.Size = New Size(60, 29)
        Button3.TabIndex = 23
        Button3.Text = "修改"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(148, 112)
        Label20.Name = "Label20"
        Label20.Size = New Size(24, 19)
        Label20.TabIndex = 22
        Label20.Text = "次"
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(92, 105)
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(50, 27)
        NumericUpDown2.TabIndex = 21
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(10, 110)
        Label19.Name = "Label19"
        Label19.Size = New Size(76, 19)
        Label19.TabIndex = 20
        Label19.Text = "執行次數 :"
        ' 
        ' ExecutionScriptQueue_Button
        ' 
        ExecutionScriptQueue_Button.BackColor = SystemColors.GradientInactiveCaption
        ExecutionScriptQueue_Button.Location = New Point(178, 105)
        ExecutionScriptQueue_Button.Name = "ExecutionScriptQueue_Button"
        ExecutionScriptQueue_Button.Size = New Size(240, 29)
        ExecutionScriptQueue_Button.TabIndex = 19
        ExecutionScriptQueue_Button.Text = "執行腳本"
        ExecutionScriptQueue_Button.UseVisualStyleBackColor = False
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(350, 71)
        Label18.Name = "Label18"
        Label18.Size = New Size(50, 19)
        Label18.TabIndex = 18
        Label18.Text = "隨機±"
        ' 
        ' ExecutionWaitRandomSeconds_NumericUpDown
        ' 
        ExecutionWaitRandomSeconds_NumericUpDown.Location = New Point(406, 66)
        ExecutionWaitRandomSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitRandomSeconds_NumericUpDown.Name = "ExecutionWaitRandomSeconds_NumericUpDown"
        ExecutionWaitRandomSeconds_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitRandomSeconds_NumericUpDown.TabIndex = 17
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(462, 71)
        Label17.Name = "Label17"
        Label17.Size = New Size(24, 19)
        Label17.TabIndex = 16
        Label17.Text = "秒"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(320, 71)
        Label16.Name = "Label16"
        Label16.Size = New Size(24, 19)
        Label16.TabIndex = 15
        Label16.Text = "秒"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(234, 71)
        Label15.Name = "Label15"
        Label15.Size = New Size(24, 19)
        Label15.TabIndex = 14
        Label15.Text = "分"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(148, 71)
        Label14.Name = "Label14"
        Label14.Size = New Size(24, 19)
        Label14.TabIndex = 13
        Label14.Text = "時"
        ' 
        ' ExecutionWaitMinutes_NumericUpDown
        ' 
        ExecutionWaitMinutes_NumericUpDown.Location = New Point(178, 66)
        ExecutionWaitMinutes_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitMinutes_NumericUpDown.Name = "ExecutionWaitMinutes_NumericUpDown"
        ExecutionWaitMinutes_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitMinutes_NumericUpDown.TabIndex = 12
        ' 
        ' ExecutionWaitHours_NumericUpDown
        ' 
        ExecutionWaitHours_NumericUpDown.Location = New Point(92, 66)
        ExecutionWaitHours_NumericUpDown.Name = "ExecutionWaitHours_NumericUpDown"
        ExecutionWaitHours_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitHours_NumericUpDown.TabIndex = 11
        ' 
        ' ExecutionWaitSeconds_NumericUpDown
        ' 
        ExecutionWaitSeconds_NumericUpDown.Location = New Point(264, 66)
        ExecutionWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitSeconds_NumericUpDown.Name = "ExecutionWaitSeconds_NumericUpDown"
        ExecutionWaitSeconds_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitSeconds_NumericUpDown.TabIndex = 10
        ' 
        ' InsertToQueueListview_Button
        ' 
        InsertToQueueListview_Button.Location = New Point(492, 63)
        InsertToQueueListview_Button.Name = "InsertToQueueListview_Button"
        InsertToQueueListview_Button.Size = New Size(60, 29)
        InsertToQueueListview_Button.TabIndex = 9
        InsertToQueueListview_Button.Text = "插入"
        InsertToQueueListview_Button.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(532, 28)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 7
        Button2.Text = "修改"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(432, 28)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 6
        Button1.Text = "插入"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(402, 36)
        Label13.Name = "Label13"
        Label13.Size = New Size(24, 19)
        Label13.TabIndex = 5
        Label13.Text = "秒"
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(329, 30)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(67, 27)
        NumericUpDown1.TabIndex = 4
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Time
        DateTimePicker1.Location = New Point(92, 30)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.ShowUpDown = True
        DateTimePicker1.Size = New Size(150, 27)
        DateTimePicker1.TabIndex = 3
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(10, 71)
        Label12.Name = "Label12"
        Label12.Size = New Size(76, 19)
        Label12.TabIndex = 2
        Label12.Text = "等待時間 :"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(248, 36)
        Label11.Name = "Label11"
        Label11.Size = New Size(76, 19)
        Label11.TabIndex = 1
        Label11.Text = "相隔時間 :"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(10, 36)
        Label8.Name = "Label8"
        Label8.Size = New Size(76, 19)
        Label8.TabIndex = 0
        Label8.Text = "執行時間 :"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9.0F, 19.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1782, 1053)
        Controls.Add(ScriptTask_GroupBox)
        Controls.Add(Action_TabControl)
        Controls.Add(ScriptQueue_ListView)
        Controls.Add(FBData_TabControl)
        Controls.Add(GetCurrentUrl_Button)
        Controls.Add(RequestFriend_Button)
        Controls.Add(WebviewUserDataFolder_ListBox)
        Controls.Add(TurnOnSetSeleteKeyboardShortcuts_Button)
        Controls.Add(SetSeletedFBLanguageTo_zhTW_Button)
        Controls.Add(Move_UserDataFolder_Button)
        Controls.Add(UserDataFoldListFilter_GroupBox)
        Controls.Add(DeleteSelectedUserDataFolderButton)
        Controls.Add(CreateUserDataFolderButton)
        Controls.Add(UserDataFolderName_TextBox)
        Controls.Add(UserInfo_GroupBox)
        Controls.Add(NavigateTo_Url_Button)
        Controls.Add(Navigate_Url_TextBox)
        Controls.Add(Main_WebView2)
        Name = "Form1"
        Text = "Form1"
        CType(Main_WebView2, ComponentModel.ISupportInitialize).EndInit()
        UserInfo_GroupBox.ResumeLayout(False)
        UserInfo_GroupBox.PerformLayout()
        UserDataFoldListFilter_GroupBox.ResumeLayout(False)
        UserDataFoldListFilter_GroupBox.PerformLayout()
        FBData_TabControl.ResumeLayout(False)
        FBGroups_TabPage.ResumeLayout(False)
        FBGroups_TabPage.PerformLayout()
        Action_TabControl.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        CType(MediaPreview_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        ScriptTask_GroupBox.ResumeLayout(False)
        ScriptTask_GroupBox.PerformLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitRandomSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitMinutes_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitHours_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Main_WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Navigate_Url_TextBox As TextBox
    Friend WithEvents NavigateTo_Url_Button As Button
    Friend WithEvents UserInfo_GroupBox As GroupBox
    Friend WithEvents UserDataFolderName_TextBox As TextBox
    Friend WithEvents CreateUserDataFolderButton As Button
    Friend WithEvents DeleteSelectedUserDataFolderButton As Button
    Friend WithEvents UserDataFoldListFilter_GroupBox As GroupBox
    Friend WithEvents FilterAvailableUserData_CheckBox As CheckBox
    Friend WithEvents FilterUnavailableUserData_CheckBox As CheckBox
    Friend WithEvents FBAccount_TextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FBCookie_RichTextBox As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents FB2FA_TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents RevealEmailPasswordText_Button As Button
    Friend WithEvents EmailPassword_TextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents EmailAccount_TextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents RevealFBPasswordText_Button As Button
    Friend WithEvents FBPassword_TextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Remark_RichTextBox As RichTextBox
    Friend WithEvents SetCookie_Button As Button
    Friend WithEvents ReadCookie_Button As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents SaveUserData_Button As Button
    Friend WithEvents Move_UserDataFolder_Button As Button
    Friend WithEvents SetSeletedFBLanguageTo_zhTW_Button As Button
    Friend WithEvents TurnOnSetSeleteKeyboardShortcuts_Button As Button
    Friend WithEvents WebviewUserDataFolder_ListBox As ListBox
    Friend WithEvents RequestFriend_Button As Button
    Friend WithEvents GetCurrentUrl_Button As Button
    Friend WithEvents FBData_TabControl As TabControl
    Friend WithEvents FBGroups_TabPage As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FBGroups_ListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents FBGroupUrl_TextBox As TextBox
    Friend WithEvents FBGroupName_TextBox As TextBox
    Friend WithEvents EditSelectedGroupListviewItem_Button As Button
    Friend WithEvents AddGroupDataToGroupListview_Button As Button
    Friend WithEvents DisplayCurrUrlToGroupUrl_Button As Button
    Friend WithEvents NavigateToSelectedGroup_Button As Button
    Friend WithEvents DeleteSelectedGroup_Button As Button
    Friend WithEvents SaveListviewGroupList_Button As Button
    Friend WithEvents GetFBGroupList_Button As Button
    Friend WithEvents GetJoinedGroupList_Button As Button
    Friend WithEvents ScriptQueue_ListView As ListView
    Friend WithEvents Action_TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents MediaPreview_PictureBox As PictureBox
    Friend WithEvents PreviewTextFile_RichTextBox As RichTextBox
    Friend WithEvents CreateNewAssetFolder_Button As Button
    Friend WithEvents CreateNewTextFile_Button As Button
    Friend WithEvents DeleteSelectedMedia_Button As Button
    Friend WithEvents RevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents DeleteSelectedAssetFolder_Button As Button
    Friend WithEvents NewAssetFolderName_TextBox As TextBox
    Friend WithEvents SaveEditedTextFile_Button As Button
    Friend WithEvents MyAssetsFolder_ListBox As ListBox
    Friend WithEvents TextFileSelector_ListBox As ListBox
    Friend WithEvents MediaSelector_ListBox As ListBox
    Friend WithEvents NewTextFileName_TextBox As TextBox
    Friend WithEvents DeleteSelectedTextFiles_Button As Button
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ScriptTask_GroupBox As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents InsertToQueueListview_Button As Button
    Friend WithEvents ExecutionWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ExecutionWaitMinutes_NumericUpDown As NumericUpDown
    Friend WithEvents ExecutionWaitHours_NumericUpDown As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ExecutionWaitRandomSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents DeselectAllMyAssetFolderListboxItems_Button As Button
    Friend WithEvents ExecutionScriptQueue_Button As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Button3 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents ContinueScriptExecution_Button As Button
    Friend WithEvents PauseScriptExecution_Button As Button

End Class
