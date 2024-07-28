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
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        UserInfo_GroupBox.SuspendLayout()
        UserDataFoldListFilter_GroupBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.BackColor = Color.White
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.ForeColor = Color.Black
        Main_WebView2.Location = New Point(546, 12)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(795, 632)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(546, 650)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(431, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(983, 650)
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
        UserInfo_GroupBox.Location = New Point(226, 12)
        UserInfo_GroupBox.Name = "UserInfo_GroupBox"
        UserInfo_GroupBox.Size = New Size(314, 665)
        UserInfo_GroupBox.TabIndex = 7
        UserInfo_GroupBox.TabStop = False
        UserInfo_GroupBox.Text = "使用者紀錄"
        ' 
        ' SaveUserData_Button
        ' 
        SaveUserData_Button.Location = New Point(6, 630)
        SaveUserData_Button.Name = "SaveUserData_Button"
        SaveUserData_Button.Size = New Size(302, 29)
        SaveUserData_Button.TabIndex = 18
        SaveUserData_Button.Text = "儲存"
        SaveUserData_Button.UseVisualStyleBackColor = True
        ' 
        ' Remark_RichTextBox
        ' 
        Remark_RichTextBox.Location = New Point(6, 491)
        Remark_RichTextBox.Name = "Remark_RichTextBox"
        Remark_RichTextBox.Size = New Size(302, 133)
        Remark_RichTextBox.TabIndex = 17
        Remark_RichTextBox.Text = ""
        ' 
        ' SetCookie_Button
        ' 
        SetCookie_Button.Location = New Point(175, 437)
        SetCookie_Button.Name = "SetCookie_Button"
        SetCookie_Button.Size = New Size(133, 29)
        SetCookie_Button.TabIndex = 16
        SetCookie_Button.Text = "設定Cookie"
        SetCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadCookie_Button
        ' 
        ReadCookie_Button.Location = New Point(6, 437)
        ReadCookie_Button.Name = "ReadCookie_Button"
        ReadCookie_Button.Size = New Size(144, 29)
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
        FBCookie_RichTextBox.Size = New Size(302, 126)
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
        FB2FA_TextBox.Size = New Size(302, 27)
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
        RevealEmailPasswordText_Button.Location = New Point(258, 199)
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
        EmailPassword_TextBox.Size = New Size(246, 27)
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
        EmailAccount_TextBox.Size = New Size(302, 27)
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
        RevealFBPasswordText_Button.Location = New Point(258, 95)
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
        FBPassword_TextBox.Size = New Size(246, 27)
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
        FBAccount_TextBox.Size = New Size(302, 27)
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
        UserDataFolderName_TextBox.Location = New Point(12, 582)
        UserDataFolderName_TextBox.Name = "UserDataFolderName_TextBox"
        UserDataFolderName_TextBox.Size = New Size(94, 27)
        UserDataFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateUserDataFolderButton
        ' 
        CreateUserDataFolderButton.Location = New Point(126, 582)
        CreateUserDataFolderButton.Name = "CreateUserDataFolderButton"
        CreateUserDataFolderButton.Size = New Size(94, 29)
        CreateUserDataFolderButton.TabIndex = 10
        CreateUserDataFolderButton.Text = "新增"
        CreateUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedUserDataFolderButton
        ' 
        DeleteSelectedUserDataFolderButton.Location = New Point(126, 617)
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
        UserDataFoldListFilter_GroupBox.Location = New Point(12, 483)
        UserDataFoldListFilter_GroupBox.Name = "UserDataFoldListFilter_GroupBox"
        UserDataFoldListFilter_GroupBox.Size = New Size(208, 93)
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
        Move_UserDataFolder_Button.Location = New Point(12, 615)
        Move_UserDataFolder_Button.Name = "Move_UserDataFolder_Button"
        Move_UserDataFolder_Button.Size = New Size(94, 29)
        Move_UserDataFolder_Button.TabIndex = 14
        Move_UserDataFolder_Button.Text = "移動所選"
        Move_UserDataFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' SetSeletedFBLanguageTo_zhTW_Button
        ' 
        SetSeletedFBLanguageTo_zhTW_Button.Location = New Point(12, 650)
        SetSeletedFBLanguageTo_zhTW_Button.Name = "SetSeletedFBLanguageTo_zhTW_Button"
        SetSeletedFBLanguageTo_zhTW_Button.Size = New Size(94, 29)
        SetSeletedFBLanguageTo_zhTW_Button.TabIndex = 15
        SetSeletedFBLanguageTo_zhTW_Button.Text = "設定中文"
        SetSeletedFBLanguageTo_zhTW_Button.UseVisualStyleBackColor = True
        ' 
        ' ShowDebugPanel_Button
        ' 
        ShowDebugPanel_Button.Location = New Point(1247, 681)
        ShowDebugPanel_Button.Name = "ShowDebugPanel_Button"
        ShowDebugPanel_Button.Size = New Size(94, 29)
        ShowDebugPanel_Button.TabIndex = 16
        ShowDebugPanel_Button.Text = "debug"
        ShowDebugPanel_Button.UseVisualStyleBackColor = True
        ' 
        ' TurnOnSetSeleteKeyboardShortcuts_Button
        ' 
        TurnOnSetSeleteKeyboardShortcuts_Button.Location = New Point(126, 652)
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
        WebviewUserDataFolder_ListBox.Size = New Size(208, 460)
        WebviewUserDataFolder_ListBox.TabIndex = 18
        ' 
        ' RequestFriend_Button
        ' 
        RequestFriend_Button.Location = New Point(12, 685)
        RequestFriend_Button.Name = "RequestFriend_Button"
        RequestFriend_Button.Size = New Size(94, 29)
        RequestFriend_Button.TabIndex = 19
        RequestFriend_Button.Text = "加好友"
        RequestFriend_Button.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1563, 824)
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

End Class
