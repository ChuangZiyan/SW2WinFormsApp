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
        Dim ListViewItem3 As ListViewItem = New ListViewItem(New String() {"google", "https://google.com/"}, -1)
        Dim ListViewItem4 As ListViewItem = New ListViewItem(New String() {"Bing", "https://bing.com/"}, -1)
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
        ShowDebugPanel_Button = New Button()
        TurnOnSetSeleteKeyboardShortcuts_Button = New Button()
        WebviewUserDataFolder_ListBox = New ListBox()
        RequestFriend_Button = New Button()
        GetCurrentUrl_Button = New Button()
        Webview2EdgeVersion_TextBox = New TextBox()
        Label8 = New Label()
        FBData_TabControl = New TabControl()
        FBGroups_TabPage = New TabPage()
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
        GetJoinedGroupList_Button = New Button()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        UserInfo_GroupBox.SuspendLayout()
        UserDataFoldListFilter_GroupBox.SuspendLayout()
        FBData_TabControl.SuspendLayout()
        FBGroups_TabPage.SuspendLayout()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.BackColor = Color.White
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.ForeColor = Color.Black
        Main_WebView2.Location = New Point(876, 12)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(588, 496)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(876, 514)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(388, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(1270, 514)
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
        UserInfo_GroupBox.Size = New Size(223, 678)
        UserInfo_GroupBox.TabIndex = 7
        UserInfo_GroupBox.TabStop = False
        UserInfo_GroupBox.Text = "使用者紀錄"
        ' 
        ' SaveUserData_Button
        ' 
        SaveUserData_Button.Location = New Point(6, 636)
        SaveUserData_Button.Name = "SaveUserData_Button"
        SaveUserData_Button.Size = New Size(206, 29)
        SaveUserData_Button.TabIndex = 18
        SaveUserData_Button.Text = "儲存"
        SaveUserData_Button.UseVisualStyleBackColor = True
        ' 
        ' Remark_RichTextBox
        ' 
        Remark_RichTextBox.Location = New Point(6, 491)
        Remark_RichTextBox.Name = "Remark_RichTextBox"
        Remark_RichTextBox.Size = New Size(206, 139)
        Remark_RichTextBox.TabIndex = 17
        Remark_RichTextBox.Text = ""
        ' 
        ' SetCookie_Button
        ' 
        SetCookie_Button.Location = New Point(117, 437)
        SetCookie_Button.Name = "SetCookie_Button"
        SetCookie_Button.Size = New Size(95, 29)
        SetCookie_Button.TabIndex = 16
        SetCookie_Button.Text = "設定Cookie"
        SetCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadCookie_Button
        ' 
        ReadCookie_Button.Location = New Point(6, 437)
        ReadCookie_Button.Name = "ReadCookie_Button"
        ReadCookie_Button.Size = New Size(105, 29)
        ReadCookie_Button.TabIndex = 15
        ReadCookie_Button.Text = "讀取Cookie"
        ReadCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(6, 469)
        Label7.Name = "Label7"
        Label7.Size = New Size(39, 19)
        Label7.TabIndex = 14
        Label7.Text = "備註"
        ' 
        ' FBCookie_RichTextBox
        ' 
        FBCookie_RichTextBox.Location = New Point(6, 305)
        FBCookie_RichTextBox.Name = "FBCookie_RichTextBox"
        FBCookie_RichTextBox.Size = New Size(206, 126)
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
        UserDataFolderName_TextBox.Location = New Point(12, 558)
        UserDataFolderName_TextBox.Name = "UserDataFolderName_TextBox"
        UserDataFolderName_TextBox.Size = New Size(94, 27)
        UserDataFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateUserDataFolderButton
        ' 
        CreateUserDataFolderButton.Location = New Point(112, 558)
        CreateUserDataFolderButton.Name = "CreateUserDataFolderButton"
        CreateUserDataFolderButton.Size = New Size(94, 29)
        CreateUserDataFolderButton.TabIndex = 10
        CreateUserDataFolderButton.Text = "新增"
        CreateUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedUserDataFolderButton
        ' 
        DeleteSelectedUserDataFolderButton.Location = New Point(112, 593)
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
        UserDataFoldListFilter_GroupBox.Location = New Point(12, 459)
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
        Move_UserDataFolder_Button.Location = New Point(12, 591)
        Move_UserDataFolder_Button.Name = "Move_UserDataFolder_Button"
        Move_UserDataFolder_Button.Size = New Size(94, 29)
        Move_UserDataFolder_Button.TabIndex = 14
        Move_UserDataFolder_Button.Text = "移動所選"
        Move_UserDataFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' SetSeletedFBLanguageTo_zhTW_Button
        ' 
        SetSeletedFBLanguageTo_zhTW_Button.Location = New Point(12, 626)
        SetSeletedFBLanguageTo_zhTW_Button.Name = "SetSeletedFBLanguageTo_zhTW_Button"
        SetSeletedFBLanguageTo_zhTW_Button.Size = New Size(94, 29)
        SetSeletedFBLanguageTo_zhTW_Button.TabIndex = 15
        SetSeletedFBLanguageTo_zhTW_Button.Text = "設定中文"
        SetSeletedFBLanguageTo_zhTW_Button.UseVisualStyleBackColor = True
        ' 
        ' ShowDebugPanel_Button
        ' 
        ShowDebugPanel_Button.Location = New Point(1261, 731)
        ShowDebugPanel_Button.Name = "ShowDebugPanel_Button"
        ShowDebugPanel_Button.Size = New Size(94, 29)
        ShowDebugPanel_Button.TabIndex = 16
        ShowDebugPanel_Button.Text = "debug"
        ShowDebugPanel_Button.UseVisualStyleBackColor = True
        ' 
        ' TurnOnSetSeleteKeyboardShortcuts_Button
        ' 
        TurnOnSetSeleteKeyboardShortcuts_Button.Location = New Point(112, 628)
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
        WebviewUserDataFolder_ListBox.Size = New Size(194, 441)
        WebviewUserDataFolder_ListBox.TabIndex = 18
        ' 
        ' RequestFriend_Button
        ' 
        RequestFriend_Button.Location = New Point(12, 661)
        RequestFriend_Button.Name = "RequestFriend_Button"
        RequestFriend_Button.Size = New Size(94, 29)
        RequestFriend_Button.TabIndex = 19
        RequestFriend_Button.Text = "加好友"
        RequestFriend_Button.UseVisualStyleBackColor = True
        ' 
        ' GetCurrentUrl_Button
        ' 
        GetCurrentUrl_Button.Location = New Point(1370, 514)
        GetCurrentUrl_Button.Name = "GetCurrentUrl_Button"
        GetCurrentUrl_Button.Size = New Size(94, 29)
        GetCurrentUrl_Button.TabIndex = 20
        GetCurrentUrl_Button.Text = "取得網址"
        GetCurrentUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' Webview2EdgeVersion_TextBox
        ' 
        Webview2EdgeVersion_TextBox.Location = New Point(1073, 731)
        Webview2EdgeVersion_TextBox.Name = "Webview2EdgeVersion_TextBox"
        Webview2EdgeVersion_TextBox.Size = New Size(182, 27)
        Webview2EdgeVersion_TextBox.TabIndex = 21
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(985, 736)
        Label8.Name = "Label8"
        Label8.Size = New Size(82, 19)
        Label8.TabIndex = 22
        Label8.Text = "Edge版本: "
        ' 
        ' FBData_TabControl
        ' 
        FBData_TabControl.Controls.Add(FBGroups_TabPage)
        FBData_TabControl.Controls.Add(TabPage2)
        FBData_TabControl.Location = New Point(441, 13)
        FBData_TabControl.Name = "FBData_TabControl"
        FBData_TabControl.SelectedIndex = 0
        FBData_TabControl.Size = New Size(429, 677)
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
        FBGroups_TabPage.Size = New Size(421, 645)
        FBGroups_TabPage.TabIndex = 0
        FBGroups_TabPage.Text = "社團"
        FBGroups_TabPage.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedGroup_Button
        ' 
        DeleteSelectedGroup_Button.Location = New Point(321, 332)
        DeleteSelectedGroup_Button.Name = "DeleteSelectedGroup_Button"
        DeleteSelectedGroup_Button.Size = New Size(94, 29)
        DeleteSelectedGroup_Button.TabIndex = 11
        DeleteSelectedGroup_Button.Text = "刪除"
        DeleteSelectedGroup_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveListviewGroupList_Button
        ' 
        SaveListviewGroupList_Button.Location = New Point(221, 332)
        SaveListviewGroupList_Button.Name = "SaveListviewGroupList_Button"
        SaveListviewGroupList_Button.Size = New Size(94, 29)
        SaveListviewGroupList_Button.TabIndex = 10
        SaveListviewGroupList_Button.Text = "儲存"
        SaveListviewGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' GetFBGroupList_Button
        ' 
        GetFBGroupList_Button.Location = New Point(6, 332)
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
        FBGroupUrl_TextBox.Size = New Size(353, 27)
        FBGroupUrl_TextBox.TabIndex = 4
        ' 
        ' FBGroupName_TextBox
        ' 
        FBGroupName_TextBox.Location = New Point(62, 6)
        FBGroupName_TextBox.Name = "FBGroupName_TextBox"
        FBGroupName_TextBox.Size = New Size(353, 27)
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
        FBGroups_ListView.Items.AddRange(New ListViewItem() {ListViewItem3, ListViewItem4})
        FBGroups_ListView.Location = New Point(6, 107)
        FBGroups_ListView.Name = "FBGroups_ListView"
        FBGroups_ListView.Size = New Size(409, 219)
        FBGroups_ListView.TabIndex = 0
        FBGroups_ListView.UseCompatibleStateImageBehavior = False
        FBGroups_ListView.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "社團名稱"
        ColumnHeader1.Width = 150
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "社團網址"
        ColumnHeader2.Width = 250
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 28)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(421, 645)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' GetJoinedGroupList_Button
        ' 
        GetJoinedGroupList_Button.Location = New Point(106, 332)
        GetJoinedGroupList_Button.Name = "GetJoinedGroupList_Button"
        GetJoinedGroupList_Button.Size = New Size(109, 29)
        GetJoinedGroupList_Button.TabIndex = 12
        GetJoinedGroupList_Button.Text = "讀取加入社團"
        GetJoinedGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1482, 770)
        Controls.Add(FBData_TabControl)
        Controls.Add(Label8)
        Controls.Add(Webview2EdgeVersion_TextBox)
        Controls.Add(GetCurrentUrl_Button)
        Controls.Add(RequestFriend_Button)
        Controls.Add(WebviewUserDataFolder_ListBox)
        Controls.Add(TurnOnSetSeleteKeyboardShortcuts_Button)
        Controls.Add(ShowDebugPanel_Button)
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
    Friend WithEvents ShowDebugPanel_Button As Button
    Friend WithEvents TurnOnSetSeleteKeyboardShortcuts_Button As Button
    Friend WithEvents WebviewUserDataFolder_ListBox As ListBox
    Friend WithEvents RequestFriend_Button As Button
    Friend WithEvents GetCurrentUrl_Button As Button
    Friend WithEvents Webview2EdgeVersion_TextBox As TextBox
    Friend WithEvents Label8 As Label
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

End Class
