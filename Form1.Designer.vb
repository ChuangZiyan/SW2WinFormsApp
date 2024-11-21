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
        TurnOnSetSeleteKeyboardShortcuts_Button = New Button()
        WebviewUserDataFolder_ListBox = New ListBox()
        RequestFriend_Button = New Button()
        GetCurrentUrl_Button = New Button()
        FBUrlData_TabControl = New TabControl()
        FBGroupsUrlData_TabPage = New TabPage()
        DeselecteAllFBGroups_ListViewItems_Button = New Button()
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
        FBActivityLogsUrlData_TabPage = New TabPage()
        DeselectAllFBActivityLogs_ListViewItems_Button = New Button()
        NavigateToActivityLogsPage_Button = New Button()
        Label46 = New Label()
        NumberOfActivityLogsPageDropDown_NumericUpDown = New NumericUpDown()
        ReadActivityLogs_Button = New Button()
        DeleteSelectedFBActivityLogListviewItems_Button = New Button()
        SaveFBActivityLogListview_Button = New Button()
        EditSelectedFBActivityLogListviewItem_Button = New Button()
        AddItemToFBActivityLogListview_Button = New Button()
        DisplayCurrUrlToFBActivityLogUrl_Button = New Button()
        NavigateToFBActivityLogSelectedGroupURL_Button = New Button()
        FBActivityLogsGroupURL_TextBox = New TextBox()
        FBActivityLogsGroupName_TextBox = New TextBox()
        Label44 = New Label()
        Label45 = New Label()
        FBActivityLogs_ListView = New ListView()
        ColumnHeader16 = New ColumnHeader()
        ColumnHeader17 = New ColumnHeader()
        FBNotificationsUrlData_TabPage = New TabPage()
        DeselecteAllFBNotificationsData_ListviewItems_Button = New Button()
        ReadFBNotifications_CheckBox = New CheckBox()
        UnreadFBNotifications_CheckBox = New CheckBox()
        DeleteSelectedFBNotificationsListviewItems_Button = New Button()
        SaveFBNotificationsListview_Button = New Button()
        ReadFBNotifications_Button = New Button()
        FBNotificationsEditSelectedListviewItem_Button = New Button()
        FBNotificationsAddItemToListview_Button = New Button()
        FBNotificationsDisplayCurrUrl_Button = New Button()
        FBNotificationsNavigateToSelectedURL_Button = New Button()
        FBNotificationsUrl_TextBox = New TextBox()
        FBNotificationsName_TextBox = New TextBox()
        Label50 = New Label()
        Label51 = New Label()
        FBNotificationsData_Listview = New ListView()
        ColumnHeader18 = New ColumnHeader()
        ColumnHeader19 = New ColumnHeader()
        FBMessengerUrlData_TabPage = New TabPage()
        FBMessengerMessageSource_ComboBox = New ComboBox()
        FBMessengerReadMessage_Button = New Button()
        DeselecteAllFBMessenger_ListviewItems_Button = New Button()
        FBMessengerReadMessage_CheckBox = New CheckBox()
        FBMessengerUnreadMessage_CheckBox = New CheckBox()
        DeleteSelectedFBMessengerListviewItems_Button = New Button()
        SaveFBMessengerListview_Button = New Button()
        FBMessengerNavigateToMessenger_Button = New Button()
        FBMessengerEditSelectedListviewItem_Button = New Button()
        FBMessengerAddItemToListview_Button = New Button()
        FBMessengerDisplayCurrUrl_Button = New Button()
        FBMessengerNavigateToSelectedURL_Button = New Button()
        FBMessengerUrl_TextBox = New TextBox()
        FBMessengerName_TextBox = New TextBox()
        Label56 = New Label()
        Label57 = New Label()
        FBMessengerData_Listview = New ListView()
        ColumnHeader20 = New ColumnHeader()
        ColumnHeader21 = New ColumnHeader()
        FBMediaDownloader_TabPage = New TabPage()
        FBMediaDownloaderDownloadMediaResources_Button = New Button()
        FBMediaDownloaderRevealDownloadMediaFolder_Button = New Button()
        Label70 = New Label()
        FBImageDownloadUrl_TextBox = New TextBox()
        FBImageDownloadGetMediaResourcesUrl_Button = New Button()
        FBMediaDownloaderNavigateToUrl_Button = New Button()
        FBMediaDownloaderNextMediaCount_NumericUpDown = New NumericUpDown()
        FBMediaDownloaderUrls_ListView = New ListView()
        MediaResourceUrl_ColumnHeader = New ColumnHeader()
        Label71 = New Label()
        FBMediaDownloaderGetUrl_Button = New Button()
        ScriptQueue_ListView = New ListView()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ColumnHeader7 = New ColumnHeader()
        ColumnHeader6 = New ColumnHeader()
        ColumnHeader5 = New ColumnHeader()
        ColumnHeader15 = New ColumnHeader()
        ColumnHeader8 = New ColumnHeader()
        ColumnHeader13 = New ColumnHeader()
        ColumnHeader14 = New ColumnHeader()
        ColumnHeader9 = New ColumnHeader()
        ColumnHeader11 = New ColumnHeader()
        ColumnHeader10 = New ColumnHeader()
        ColumnHeader12 = New ColumnHeader()
        Action_TabControl = New TabControl()
        FBPostAssets_TabPage = New TabPage()
        Label23 = New Label()
        Label22 = New Label()
        Label21 = New Label()
        FBWritePostUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBWritePostSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
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
        FBMarketplaceAssets_TabPage = New TabPage()
        FBMarketplaceShareGroupsByRandom_RadioButton = New RadioButton()
        FBMarketplaceShareGroupsBySequence_RadioButton = New RadioButton()
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button = New Button()
        FBMarketplaceShareGroupsCount_NumericUpDown = New NumericUpDown()
        Label36 = New Label()
        Label34 = New Label()
        Label35 = New Label()
        FBMarketplaceUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBMarketplaceSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBMarketplaceOnMarketplace_CheckBox = New CheckBox()
        FBMarketplaceHomeDelivery_CheckBox = New CheckBox()
        FBMarketplacePickUp_CheckBox = New CheckBox()
        FBMarketplaceMeetInPerson_CheckBox = New CheckBox()
        FBMarketplaceProductTag_TextBox = New TextBox()
        Label33 = New Label()
        FBMarketplaceDeleteSelectedMedia_Button = New Button()
        FBMarketplaceMediaPreviewer_PictureBox = New PictureBox()
        FBMarketplaceMediaSelector_ListBox = New ListBox()
        Label32 = New Label()
        Label31 = New Label()
        FBMarketplaceSavePruductInfo_Button = New Button()
        FBMarketplaceProductDescription_RichTextBox = New RichTextBox()
        Label30 = New Label()
        FBMarketplaceProductLocation_TextBox = New TextBox()
        FBMarketplaceProductStatus_NumericUpDown = New ComboBox()
        FBMarketplaceProductPrice_NumericUpDown = New NumericUpDown()
        FBMarketplaceProductName_TextBox = New TextBox()
        Label29 = New Label()
        Label28 = New Label()
        Label27 = New Label()
        Label26 = New Label()
        Label8 = New Label()
        FBmarketplaceDeselectAllProductFolderListboxItems_Button = New Button()
        FBMarketplaceDeleteSelectedAssetFolder_Button = New Button()
        NewMarketplaceAssetFolderName_TextBox = New TextBox()
        CreateNewMarketplaceAssetFolder_Button = New Button()
        FBMarkplaceProducts_ListBox = New ListBox()
        FBPostShareURLAssets_TabPage = New TabPage()
        FBPostShareURLGetCurrentURL_Button = New Button()
        FBPostShareURLNavigateToURL_Button = New Button()
        FBPostShareURLDeleteSelectedTextFile_Button = New Button()
        FBPostShareURLTextFileName_TextBox = New TextBox()
        FBPostShareURLTextFile_ListBox = New ListBox()
        FBPostShareURLSaveTextFile_Button = New Button()
        FBPostShareURLCreateNewTextFile_Button = New Button()
        FBPostShareURLTextFilePreviewer_RichTextBox = New RichTextBox()
        FBPostShareURLBaseURL_TextBox = New TextBox()
        Label40 = New Label()
        Label38 = New Label()
        Label39 = New Label()
        FBPostShareURLUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBPostShareURLSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        Label37 = New Label()
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button = New Button()
        FBPostShareURLAssetFolder_ListBox = New ListBox()
        FBPostShareURLDeleteSelectedAssetFolder_Button = New Button()
        FBPostShareURLAssetFolderName_TextBox = New TextBox()
        FBPostShareURLCreateNewAssetFolder_Button = New Button()
        FBCommentAssets_TabPage = New TabPage()
        Label41 = New Label()
        Label42 = New Label()
        Label43 = New Label()
        FBCommentUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBCommentSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBCommentDeselectAllAssetFolderListboxItems_Button = New Button()
        FBCommentDeleteSelectedTextFile_Button = New Button()
        FBCommentNewTextFileName_TextBox = New TextBox()
        FBCommentMediaSelector_ListBox = New ListBox()
        FBCommentTextFileSelector_ListBox = New ListBox()
        FBCommentAssetFolder_ListBox = New ListBox()
        FBCommentSaveTextFile_Button = New Button()
        FBCommentCreateNewTextFile_Button = New Button()
        FBCommentDeleteSelectedMedia_Button = New Button()
        FBCommentRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBCommentDeleteSelectedAssetFolder_Button = New Button()
        FBCommentAssetFolderName_TextBox = New TextBox()
        FBCommentMediaPreviewer_PictureBox = New PictureBox()
        FBCommentTextFilePreviewer_RichTextBox = New RichTextBox()
        FBCommentCreateNewAssetFolder_Button = New Button()
        FBCustomizeCommentAssets_TabPage = New TabPage()
        Label47 = New Label()
        Label48 = New Label()
        Label49 = New Label()
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button = New Button()
        FBCustomizeCommentDeleteSelectedTextFile_Button = New Button()
        FBCustomizeCommentNewTextFileName_TextBox = New TextBox()
        FBCustomizeCommentMediaSelector_ListBox = New ListBox()
        FBCustomizeCommentTextFileSelector_ListBox = New ListBox()
        FBCustomizeCommentAssetFolder_ListBox = New ListBox()
        FBCustomizeCommentSaveTextFile_Button = New Button()
        FBCustomizeCommentCreateNewTextFile_Button = New Button()
        FBCustomizeCommentDeleteSelectedMedia_Button = New Button()
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBCustomizeCommentDeleteSelectedAssetFolder_Button = New Button()
        FBCustomizeCommentAssetFolderName_TextBox = New TextBox()
        FBCustomizeCommentMediaPreviewer_PictureBox = New PictureBox()
        FBCustomizeCommentTextFilePreviewer_RichTextBox = New RichTextBox()
        FBCustomizeCommentCreateNewAssetFolder_Button = New Button()
        FBRespondNotificationsAssets_TabPage = New TabPage()
        Label52 = New Label()
        Label53 = New Label()
        Label54 = New Label()
        FBResponseUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBResponseSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBResponseDeselectAllAssetFolderListboxItems_Button = New Button()
        FBResponseDeleteSelectedTextFile_Button = New Button()
        FBResponseNewTextFileName_TextBox = New TextBox()
        FBResponseMediaSelector_ListBox = New ListBox()
        FBResponseTextFileSelector_ListBox = New ListBox()
        FBResponseAssetFolder_ListBox = New ListBox()
        FBResponseSaveTextFile_Button = New Button()
        FBResponseCreateNewTextFile_Button = New Button()
        FBResponseDeleteSelectedMedia_Button = New Button()
        FBResponseRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBResponseDeleteSelectedAssetFolder_Button = New Button()
        FBResponseAssetFolderName_TextBox = New TextBox()
        FBResponseMediaPreviewer_PictureBox = New PictureBox()
        FBResponseTextFilePreviewer_RichTextBox = New RichTextBox()
        FBResponseCreateNewAssetFolder_Button = New Button()
        FBMessengerAssets_TabPage = New TabPage()
        Label58 = New Label()
        Label59 = New Label()
        Label60 = New Label()
        FBMessengerUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBMessengerSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBMessengerDeselectAllAssetFolderListboxItems_Button = New Button()
        FBMessengerDeleteSelectedTextFile_Button = New Button()
        FBMessengerNewTextFileName_TextBox = New TextBox()
        FBMessengerMediaSelector_ListBox = New ListBox()
        FBMessengerTextFileSelector_ListBox = New ListBox()
        FBMessengerAssetFolder_ListBox = New ListBox()
        FBMessengerSaveTextFile_Button = New Button()
        FBMessengerCreateNewTextFile_Button = New Button()
        FBMessengerDeleteSelectedMedia_Button = New Button()
        FBMessengerRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBMessengerDeleteSelectedAssetFolder_Button = New Button()
        FBMessengerAssetFolderName_TextBox = New TextBox()
        FBMessengerMediaPreviewer_PictureBox = New PictureBox()
        FBMessengerTextFilePreviewer_RichTextBox = New RichTextBox()
        FBMessengerCreateNewAssetFolder_Button = New Button()
        FBStoryAssets_TabPage = New TabPage()
        Label61 = New Label()
        Label62 = New Label()
        Label63 = New Label()
        FBStoryUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBStorySubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBStoryDeselectAllAssetFolderListboxItems_Button = New Button()
        FBStoryDeleteSelectedTextFile_Button = New Button()
        FBStoryNewTextFileName_TextBox = New TextBox()
        FBStoryMediaSelector_ListBox = New ListBox()
        FBStoryTextFileSelector_ListBox = New ListBox()
        FBStoryAssetFolder_ListBox = New ListBox()
        FBStorySaveTextFile_Button = New Button()
        FBStoryCreateNewTextFile_Button = New Button()
        FBStoryDeleteSelectedMedia_Button = New Button()
        FBStoryRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBStoryDeleteSelectedAssetFolder_Button = New Button()
        FBStoryAssetFolderName_TextBox = New TextBox()
        FBStoryMediaPreviewer_PictureBox = New PictureBox()
        FBStoryTextFilePreviewer_RichTextBox = New RichTextBox()
        FBStoryCreateNewAssetFolder_Button = New Button()
        FBPersonalPostAssets_TabPage = New TabPage()
        SingleMediaAllowed_CheckBox = New CheckBox()
        Label64 = New Label()
        Label65 = New Label()
        Label66 = New Label()
        FBPersonalPostUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBPersonalPostSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button = New Button()
        FBPersonalPostDeleteSelectedTextFile_Button = New Button()
        FBPersonalPostNewTextFileName_TextBox = New TextBox()
        FBPersonalPostMediaSelector_ListBox = New ListBox()
        FBPersonalPostTextFileSelector_ListBox = New ListBox()
        FBPersonalPostAssetFolder_ListBox = New ListBox()
        FBPersonalPostSaveTextFile_Button = New Button()
        FBPersonalPostCreateNewTextFile_Button = New Button()
        FBPersonalPostDeleteSelectedMedia_Button = New Button()
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBPersonalPostDeleteSelectedAssetFolder_Button = New Button()
        FBPersonalPostAssetFolderName_TextBox = New TextBox()
        FBPersonalPostMediaPreviewer_PictureBox = New PictureBox()
        FBPersonalPostTextFilePreviewer_RichTextBox = New RichTextBox()
        FBPersonalPostCreateNewAssetFolder_Button = New Button()
        FBReelsAssets_TabPage = New TabPage()
        Label67 = New Label()
        Label68 = New Label()
        Label69 = New Label()
        FBReelsUploadWaitSeconds_NumericUpDown = New NumericUpDown()
        FBReelsSubmitWaitSeconds_NumericUpDown = New NumericUpDown()
        FBReelsDeselectAllAssetFolderListboxItems_Button = New Button()
        FBReelsDeleteSelectedTextFile_Button = New Button()
        FBReelsNewTextFileName_TextBox = New TextBox()
        FBReelsMediaSelector_ListBox = New ListBox()
        FBReelsTextFileSelector_ListBox = New ListBox()
        FBReelsAssetFolder_ListBox = New ListBox()
        FBReelsSaveTextFile_Button = New Button()
        FBReelsCreateNewTextFile_Button = New Button()
        FBReelsDeleteSelectedMedia_Button = New Button()
        FBReelsRevealMediaFoldesrInFileExplorer_Button = New Button()
        FBReelsDeleteSelectedAssetFolder_Button = New Button()
        FBReelsAssetFolderName_TextBox = New TextBox()
        FBReelsMediaPreviewer_PictureBox = New PictureBox()
        FBReelsTextFilePreviewer_RichTextBox = New RichTextBox()
        FBReelsCreateNewAssetFolder_Button = New Button()
        DevTool_TabPage = New TabPage()
        DevTool_ClearOutputRichTextBox_Button = New Button()
        Label73 = New Label()
        DevTool_ClickElementByCssSelector_Button = New Button()
        DevTool_ResultOutput_RichTextBox = New RichTextBox()
        DevTool_FindElementByCssSelector_Button = New Button()
        Label72 = New Label()
        DevTool_CssSelectorInput_TextBox = New TextBox()
        ShowEmojiPicker_Button = New Button()
        ScriptTask_GroupBox = New GroupBox()
        Label55 = New Label()
        CustomizeAction_ComboBox = New ComboBox()
        CustomizeScriptInsertion_RadioButton = New RadioButton()
        DefaultScriptInsertion_RadioButton = New RadioButton()
        SortListviewItemByTime_Button = New Button()
        ScheduledTimeSorting_DateTimePicker = New DateTimePicker()
        SyncTimeToDateTimePicker_Label = New Label()
        ModifyListviewScheduleTimeTNull_Button = New Button()
        StopScheduledExecutionScriptQueue_Button = New Button()
        Label24 = New Label()
        Label25 = New Label()
        ScheduledExecutionMinutes_NumericUpDown = New NumericUpDown()
        ScheduledExecutionHours_NumericUpDown = New NumericUpDown()
        ScheduledExecutionSeconds_NumericUpDown = New NumericUpDown()
        ScheduledExecutionScriptQueue_Button = New Button()
        ExecuteSelectedScriptListviewItem_Button = New Button()
        ModifySelectedScriptListviewAsset_Button = New Button()
        ContinueScriptExecution_Button = New Button()
        PauseScriptExecution_Button = New Button()
        ModifySelectedScriptListviewWaitTime_Button = New Button()
        Label20 = New Label()
        ScriptExecutionCount_NumericUpDown = New NumericUpDown()
        Label19 = New Label()
        ExecutionScriptQueue_Button = New Button()
        Label18 = New Label()
        ExecutionWaitRandomSeconds_NumericUpDown = New NumericUpDown()
        ResetScript_Button = New Button()
        Label17 = New Label()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        ExecutionWaitMinutes_NumericUpDown = New NumericUpDown()
        ExecutionWaitHours_NumericUpDown = New NumericUpDown()
        ExecutionWaitSeconds_NumericUpDown = New NumericUpDown()
        InsertToQueueListview_Button = New Button()
        ModifyListviewScheduleTime_Button = New Button()
        InsertSchedulerScriptToListview_Button = New Button()
        Label13 = New Label()
        SchedulerIntervalSeconds_NumericUpDown = New NumericUpDown()
        Label12 = New Label()
        Label11 = New Label()
        SchedulerTime_Label = New Label()
        userData_ComboBox = New ComboBox()
        MarkUserDataToSkip_Button = New Button()
        UnmarkUserDataToSkip_Button_Button = New Button()
        SaveScriptListViewToCSVFile_Button = New Button()
        MarkSelectedScriptListviewItem_Button = New Button()
        UnmarkSelectedScriptListviewItem_Button = New Button()
        DeleteSelectedScriptListviewItem_Button = New Button()
        DeleteScriptListviewItemByUserData_Button = New Button()
        SelectScriptListviewItemsByUserDataButton = New Button()
        EditScriptFile_Button = New Button()
        SwapScriptQueueListViewItems_Button = New Button()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        UserInfo_GroupBox.SuspendLayout()
        UserDataFoldListFilter_GroupBox.SuspendLayout()
        FBUrlData_TabControl.SuspendLayout()
        FBGroupsUrlData_TabPage.SuspendLayout()
        FBActivityLogsUrlData_TabPage.SuspendLayout()
        CType(NumberOfActivityLogsPageDropDown_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        FBNotificationsUrlData_TabPage.SuspendLayout()
        FBMessengerUrlData_TabPage.SuspendLayout()
        FBMediaDownloader_TabPage.SuspendLayout()
        CType(FBMediaDownloaderNextMediaCount_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        Action_TabControl.SuspendLayout()
        FBPostAssets_TabPage.SuspendLayout()
        CType(FBWritePostUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBWritePostSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(MediaPreview_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBMarketplaceAssets_TabPage.SuspendLayout()
        CType(FBMarketplaceShareGroupsCount_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMarketplaceUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMarketplaceSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMarketplaceMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMarketplaceProductPrice_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        FBPostShareURLAssets_TabPage.SuspendLayout()
        CType(FBPostShareURLUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBPostShareURLSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        FBCommentAssets_TabPage.SuspendLayout()
        CType(FBCommentUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBCommentSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBCommentMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBCustomizeCommentAssets_TabPage.SuspendLayout()
        CType(FBCustomizeCommentUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBCustomizeCommentSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBCustomizeCommentMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBRespondNotificationsAssets_TabPage.SuspendLayout()
        CType(FBResponseUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBResponseSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBResponseMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBMessengerAssets_TabPage.SuspendLayout()
        CType(FBMessengerUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMessengerSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBMessengerMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBStoryAssets_TabPage.SuspendLayout()
        CType(FBStoryUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBStorySubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBStoryMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBPersonalPostAssets_TabPage.SuspendLayout()
        CType(FBPersonalPostUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBPersonalPostSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBPersonalPostMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        FBReelsAssets_TabPage.SuspendLayout()
        CType(FBReelsUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBReelsSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(FBReelsMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).BeginInit()
        DevTool_TabPage.SuspendLayout()
        ScriptTask_GroupBox.SuspendLayout()
        CType(ScheduledExecutionMinutes_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ScheduledExecutionHours_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ScheduledExecutionSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ScriptExecutionCount_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitRandomSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitMinutes_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitHours_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(ExecutionWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        CType(SchedulerIntervalSeconds_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.BackColor = Color.White
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.ForeColor = Color.Black
        Main_WebView2.Location = New Point(1147, 517)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(672, 541)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(1147, 1065)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(272, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(1425, 1065)
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
        UserInfo_GroupBox.Location = New Point(212, 11)
        UserInfo_GroupBox.Name = "UserInfo_GroupBox"
        UserInfo_GroupBox.Size = New Size(222, 589)
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
        SetCookie_Button.Location = New Point(117, 372)
        SetCookie_Button.Name = "SetCookie_Button"
        SetCookie_Button.Size = New Size(95, 29)
        SetCookie_Button.TabIndex = 16
        SetCookie_Button.Text = "設定Cookie"
        SetCookie_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadCookie_Button
        ' 
        ReadCookie_Button.Location = New Point(6, 372)
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
        Label6.Location = New Point(6, 282)
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
        EmailPassword_TextBox.Size = New Size(151, 27)
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
        RevealFBPasswordText_Button.Location = New Point(162, 98)
        RevealFBPasswordText_Button.Name = "RevealFBPasswordText_Button"
        RevealFBPasswordText_Button.Size = New Size(50, 29)
        RevealFBPasswordText_Button.TabIndex = 4
        RevealFBPasswordText_Button.Text = "顯示"
        RevealFBPasswordText_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPassword_TextBox
        ' 
        FBPassword_TextBox.Location = New Point(6, 98)
        FBPassword_TextBox.Name = "FBPassword_TextBox"
        FBPassword_TextBox.PasswordChar = "*"c
        FBPassword_TextBox.Size = New Size(151, 27)
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
        FBAccount_TextBox.Location = New Point(6, 46)
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
        UserDataFolderName_TextBox.Location = New Point(12, 464)
        UserDataFolderName_TextBox.Name = "UserDataFolderName_TextBox"
        UserDataFolderName_TextBox.Size = New Size(94, 27)
        UserDataFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateUserDataFolderButton
        ' 
        CreateUserDataFolderButton.Location = New Point(112, 464)
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
        UserDataFoldListFilter_GroupBox.Location = New Point(12, 364)
        UserDataFoldListFilter_GroupBox.Name = "UserDataFoldListFilter_GroupBox"
        UserDataFoldListFilter_GroupBox.Size = New Size(194, 92)
        UserDataFoldListFilter_GroupBox.TabIndex = 13
        UserDataFoldListFilter_GroupBox.TabStop = False
        UserDataFoldListFilter_GroupBox.Text = "顯示"
        ' 
        ' FilterUnavailableUserData_CheckBox
        ' 
        FilterUnavailableUserData_CheckBox.AutoSize = True
        FilterUnavailableUserData_CheckBox.Location = New Point(6, 54)
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
        FilterAvailableUserData_CheckBox.Location = New Point(6, 27)
        FilterAvailableUserData_CheckBox.Name = "FilterAvailableUserData_CheckBox"
        FilterAvailableUserData_CheckBox.Size = New Size(61, 23)
        FilterAvailableUserData_CheckBox.TabIndex = 0
        FilterAvailableUserData_CheckBox.Text = "可用"
        FilterAvailableUserData_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' Move_UserDataFolder_Button
        ' 
        Move_UserDataFolder_Button.Location = New Point(12, 497)
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
        WebviewUserDataFolder_ListBox.Location = New Point(12, 11)
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
        GetCurrentUrl_Button.Location = New Point(1525, 1065)
        GetCurrentUrl_Button.Name = "GetCurrentUrl_Button"
        GetCurrentUrl_Button.Size = New Size(94, 29)
        GetCurrentUrl_Button.TabIndex = 20
        GetCurrentUrl_Button.Text = "取得網址"
        GetCurrentUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBUrlData_TabControl
        ' 
        FBUrlData_TabControl.Controls.Add(FBGroupsUrlData_TabPage)
        FBUrlData_TabControl.Controls.Add(FBActivityLogsUrlData_TabPage)
        FBUrlData_TabControl.Controls.Add(FBNotificationsUrlData_TabPage)
        FBUrlData_TabControl.Controls.Add(FBMessengerUrlData_TabPage)
        FBUrlData_TabControl.Controls.Add(FBMediaDownloader_TabPage)
        FBUrlData_TabControl.Location = New Point(440, 11)
        FBUrlData_TabControl.Name = "FBUrlData_TabControl"
        FBUrlData_TabControl.SelectedIndex = 0
        FBUrlData_TabControl.Size = New Size(700, 383)
        FBUrlData_TabControl.TabIndex = 23
        ' 
        ' FBGroupsUrlData_TabPage
        ' 
        FBGroupsUrlData_TabPage.Controls.Add(DeselecteAllFBGroups_ListViewItems_Button)
        FBGroupsUrlData_TabPage.Controls.Add(GetJoinedGroupList_Button)
        FBGroupsUrlData_TabPage.Controls.Add(DeleteSelectedGroup_Button)
        FBGroupsUrlData_TabPage.Controls.Add(SaveListviewGroupList_Button)
        FBGroupsUrlData_TabPage.Controls.Add(GetFBGroupList_Button)
        FBGroupsUrlData_TabPage.Controls.Add(EditSelectedGroupListviewItem_Button)
        FBGroupsUrlData_TabPage.Controls.Add(AddGroupDataToGroupListview_Button)
        FBGroupsUrlData_TabPage.Controls.Add(DisplayCurrUrlToGroupUrl_Button)
        FBGroupsUrlData_TabPage.Controls.Add(NavigateToSelectedGroup_Button)
        FBGroupsUrlData_TabPage.Controls.Add(FBGroupUrl_TextBox)
        FBGroupsUrlData_TabPage.Controls.Add(FBGroupName_TextBox)
        FBGroupsUrlData_TabPage.Controls.Add(Label10)
        FBGroupsUrlData_TabPage.Controls.Add(Label9)
        FBGroupsUrlData_TabPage.Controls.Add(FBGroups_ListView)
        FBGroupsUrlData_TabPage.Location = New Point(4, 28)
        FBGroupsUrlData_TabPage.Name = "FBGroupsUrlData_TabPage"
        FBGroupsUrlData_TabPage.Padding = New Padding(3)
        FBGroupsUrlData_TabPage.Size = New Size(692, 351)
        FBGroupsUrlData_TabPage.TabIndex = 0
        FBGroupsUrlData_TabPage.Text = "社團"
        FBGroupsUrlData_TabPage.UseVisualStyleBackColor = True
        ' 
        ' DeselecteAllFBGroups_ListViewItems_Button
        ' 
        DeselecteAllFBGroups_ListViewItems_Button.Location = New Point(591, 72)
        DeselecteAllFBGroups_ListViewItems_Button.Name = "DeselecteAllFBGroups_ListViewItems_Button"
        DeselecteAllFBGroups_ListViewItems_Button.Size = New Size(94, 29)
        DeselecteAllFBGroups_ListViewItems_Button.TabIndex = 13
        DeselecteAllFBGroups_ListViewItems_Button.Text = "取消選擇"
        DeselecteAllFBGroups_ListViewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' GetJoinedGroupList_Button
        ' 
        GetJoinedGroupList_Button.Location = New Point(102, 312)
        GetJoinedGroupList_Button.Name = "GetJoinedGroupList_Button"
        GetJoinedGroupList_Button.Size = New Size(109, 29)
        GetJoinedGroupList_Button.TabIndex = 12
        GetJoinedGroupList_Button.Text = "讀取加入社團"
        GetJoinedGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedGroup_Button
        ' 
        DeleteSelectedGroup_Button.Location = New Point(592, 312)
        DeleteSelectedGroup_Button.Name = "DeleteSelectedGroup_Button"
        DeleteSelectedGroup_Button.Size = New Size(94, 29)
        DeleteSelectedGroup_Button.TabIndex = 11
        DeleteSelectedGroup_Button.Text = "刪除"
        DeleteSelectedGroup_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveListviewGroupList_Button
        ' 
        SaveListviewGroupList_Button.Location = New Point(495, 312)
        SaveListviewGroupList_Button.Name = "SaveListviewGroupList_Button"
        SaveListviewGroupList_Button.Size = New Size(94, 29)
        SaveListviewGroupList_Button.TabIndex = 10
        SaveListviewGroupList_Button.Text = "儲存"
        SaveListviewGroupList_Button.UseVisualStyleBackColor = True
        ' 
        ' GetFBGroupList_Button
        ' 
        GetFBGroupList_Button.Location = New Point(3, 312)
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
        DisplayCurrUrlToGroupUrl_Button.Location = New Point(105, 72)
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
        FBGroupUrl_TextBox.Size = New Size(624, 27)
        FBGroupUrl_TextBox.TabIndex = 4
        ' 
        ' FBGroupName_TextBox
        ' 
        FBGroupName_TextBox.Location = New Point(62, 6)
        FBGroupName_TextBox.Name = "FBGroupName_TextBox"
        FBGroupName_TextBox.Size = New Size(624, 27)
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
        FBGroups_ListView.Location = New Point(6, 106)
        FBGroups_ListView.Name = "FBGroups_ListView"
        FBGroups_ListView.Size = New Size(680, 200)
        FBGroups_ListView.TabIndex = 0
        FBGroups_ListView.UseCompatibleStateImageBehavior = False
        FBGroups_ListView.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "社團名稱"
        ColumnHeader1.Width = 200
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "社團網址"
        ColumnHeader2.Width = 470
        ' 
        ' FBActivityLogsUrlData_TabPage
        ' 
        FBActivityLogsUrlData_TabPage.Controls.Add(DeselectAllFBActivityLogs_ListViewItems_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(NavigateToActivityLogsPage_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(Label46)
        FBActivityLogsUrlData_TabPage.Controls.Add(NumberOfActivityLogsPageDropDown_NumericUpDown)
        FBActivityLogsUrlData_TabPage.Controls.Add(ReadActivityLogs_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(DeleteSelectedFBActivityLogListviewItems_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(SaveFBActivityLogListview_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(EditSelectedFBActivityLogListviewItem_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(AddItemToFBActivityLogListview_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(DisplayCurrUrlToFBActivityLogUrl_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(NavigateToFBActivityLogSelectedGroupURL_Button)
        FBActivityLogsUrlData_TabPage.Controls.Add(FBActivityLogsGroupURL_TextBox)
        FBActivityLogsUrlData_TabPage.Controls.Add(FBActivityLogsGroupName_TextBox)
        FBActivityLogsUrlData_TabPage.Controls.Add(Label44)
        FBActivityLogsUrlData_TabPage.Controls.Add(Label45)
        FBActivityLogsUrlData_TabPage.Controls.Add(FBActivityLogs_ListView)
        FBActivityLogsUrlData_TabPage.Location = New Point(4, 28)
        FBActivityLogsUrlData_TabPage.Name = "FBActivityLogsUrlData_TabPage"
        FBActivityLogsUrlData_TabPage.Padding = New Padding(3)
        FBActivityLogsUrlData_TabPage.Size = New Size(692, 351)
        FBActivityLogsUrlData_TabPage.TabIndex = 1
        FBActivityLogsUrlData_TabPage.Text = "留言"
        FBActivityLogsUrlData_TabPage.UseVisualStyleBackColor = True
        ' 
        ' DeselectAllFBActivityLogs_ListViewItems_Button
        ' 
        DeselectAllFBActivityLogs_ListViewItems_Button.Location = New Point(591, 72)
        DeselectAllFBActivityLogs_ListViewItems_Button.Name = "DeselectAllFBActivityLogs_ListViewItems_Button"
        DeselectAllFBActivityLogs_ListViewItems_Button.Size = New Size(94, 29)
        DeselectAllFBActivityLogs_ListViewItems_Button.TabIndex = 29
        DeselectAllFBActivityLogs_ListViewItems_Button.Text = "取消選擇"
        DeselectAllFBActivityLogs_ListViewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' NavigateToActivityLogsPage_Button
        ' 
        NavigateToActivityLogsPage_Button.Location = New Point(5, 310)
        NavigateToActivityLogsPage_Button.Name = "NavigateToActivityLogsPage_Button"
        NavigateToActivityLogsPage_Button.Size = New Size(110, 29)
        NavigateToActivityLogsPage_Button.TabIndex = 28
        NavigateToActivityLogsPage_Button.Text = "前往最近貼文"
        NavigateToActivityLogsPage_Button.UseVisualStyleBackColor = True
        ' 
        ' Label46
        ' 
        Label46.AutoSize = True
        Label46.Location = New Point(121, 315)
        Label46.Name = "Label46"
        Label46.Size = New Size(80, 19)
        Label46.TabIndex = 27
        Label46.Text = "下拉次數 : "
        ' 
        ' NumberOfActivityLogsPageDropDown_NumericUpDown
        ' 
        NumberOfActivityLogsPageDropDown_NumericUpDown.Location = New Point(207, 312)
        NumberOfActivityLogsPageDropDown_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        NumberOfActivityLogsPageDropDown_NumericUpDown.Name = "NumberOfActivityLogsPageDropDown_NumericUpDown"
        NumberOfActivityLogsPageDropDown_NumericUpDown.Size = New Size(62, 27)
        NumberOfActivityLogsPageDropDown_NumericUpDown.TabIndex = 26
        NumberOfActivityLogsPageDropDown_NumericUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' ReadActivityLogs_Button
        ' 
        ReadActivityLogs_Button.Location = New Point(275, 310)
        ReadActivityLogs_Button.Name = "ReadActivityLogs_Button"
        ReadActivityLogs_Button.Size = New Size(110, 29)
        ReadActivityLogs_Button.TabIndex = 25
        ReadActivityLogs_Button.Text = "讀取最近貼文"
        ReadActivityLogs_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedFBActivityLogListviewItems_Button
        ' 
        DeleteSelectedFBActivityLogListviewItems_Button.Location = New Point(592, 312)
        DeleteSelectedFBActivityLogListviewItems_Button.Name = "DeleteSelectedFBActivityLogListviewItems_Button"
        DeleteSelectedFBActivityLogListviewItems_Button.Size = New Size(94, 29)
        DeleteSelectedFBActivityLogListviewItems_Button.TabIndex = 24
        DeleteSelectedFBActivityLogListviewItems_Button.Text = "刪除"
        DeleteSelectedFBActivityLogListviewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveFBActivityLogListview_Button
        ' 
        SaveFBActivityLogListview_Button.Location = New Point(495, 312)
        SaveFBActivityLogListview_Button.Name = "SaveFBActivityLogListview_Button"
        SaveFBActivityLogListview_Button.Size = New Size(94, 29)
        SaveFBActivityLogListview_Button.TabIndex = 23
        SaveFBActivityLogListview_Button.Text = "儲存"
        SaveFBActivityLogListview_Button.UseVisualStyleBackColor = True
        ' 
        ' EditSelectedFBActivityLogListviewItem_Button
        ' 
        EditSelectedFBActivityLogListviewItem_Button.Location = New Point(306, 72)
        EditSelectedFBActivityLogListviewItem_Button.Name = "EditSelectedFBActivityLogListviewItem_Button"
        EditSelectedFBActivityLogListviewItem_Button.Size = New Size(94, 29)
        EditSelectedFBActivityLogListviewItem_Button.TabIndex = 21
        EditSelectedFBActivityLogListviewItem_Button.Text = "修改"
        EditSelectedFBActivityLogListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' AddItemToFBActivityLogListview_Button
        ' 
        AddItemToFBActivityLogListview_Button.Location = New Point(206, 72)
        AddItemToFBActivityLogListview_Button.Name = "AddItemToFBActivityLogListview_Button"
        AddItemToFBActivityLogListview_Button.Size = New Size(94, 29)
        AddItemToFBActivityLogListview_Button.TabIndex = 20
        AddItemToFBActivityLogListview_Button.Text = "增加"
        AddItemToFBActivityLogListview_Button.UseVisualStyleBackColor = True
        ' 
        ' DisplayCurrUrlToFBActivityLogUrl_Button
        ' 
        DisplayCurrUrlToFBActivityLogUrl_Button.Location = New Point(105, 72)
        DisplayCurrUrlToFBActivityLogUrl_Button.Name = "DisplayCurrUrlToFBActivityLogUrl_Button"
        DisplayCurrUrlToFBActivityLogUrl_Button.Size = New Size(94, 29)
        DisplayCurrUrlToFBActivityLogUrl_Button.TabIndex = 19
        DisplayCurrUrlToFBActivityLogUrl_Button.Text = "取得網址"
        DisplayCurrUrlToFBActivityLogUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' NavigateToFBActivityLogSelectedGroupURL_Button
        ' 
        NavigateToFBActivityLogSelectedGroupURL_Button.Location = New Point(6, 72)
        NavigateToFBActivityLogSelectedGroupURL_Button.Name = "NavigateToFBActivityLogSelectedGroupURL_Button"
        NavigateToFBActivityLogSelectedGroupURL_Button.Size = New Size(94, 29)
        NavigateToFBActivityLogSelectedGroupURL_Button.TabIndex = 18
        NavigateToFBActivityLogSelectedGroupURL_Button.Text = "前往"
        NavigateToFBActivityLogSelectedGroupURL_Button.UseVisualStyleBackColor = True
        ' 
        ' FBActivityLogsGroupURL_TextBox
        ' 
        FBActivityLogsGroupURL_TextBox.Location = New Point(62, 39)
        FBActivityLogsGroupURL_TextBox.Name = "FBActivityLogsGroupURL_TextBox"
        FBActivityLogsGroupURL_TextBox.Size = New Size(624, 27)
        FBActivityLogsGroupURL_TextBox.TabIndex = 17
        ' 
        ' FBActivityLogsGroupName_TextBox
        ' 
        FBActivityLogsGroupName_TextBox.Location = New Point(62, 6)
        FBActivityLogsGroupName_TextBox.Name = "FBActivityLogsGroupName_TextBox"
        FBActivityLogsGroupName_TextBox.Size = New Size(624, 27)
        FBActivityLogsGroupName_TextBox.TabIndex = 16
        ' 
        ' Label44
        ' 
        Label44.AutoSize = True
        Label44.Location = New Point(6, 42)
        Label44.Name = "Label44"
        Label44.Size = New Size(50, 19)
        Label44.TabIndex = 15
        Label44.Text = "網址 : "
        ' 
        ' Label45
        ' 
        Label45.AutoSize = True
        Label45.Location = New Point(6, 9)
        Label45.Name = "Label45"
        Label45.Size = New Size(50, 19)
        Label45.TabIndex = 14
        Label45.Text = "名稱 : "
        ' 
        ' FBActivityLogs_ListView
        ' 
        FBActivityLogs_ListView.Columns.AddRange(New ColumnHeader() {ColumnHeader16, ColumnHeader17})
        FBActivityLogs_ListView.FullRowSelect = True
        FBActivityLogs_ListView.Location = New Point(6, 106)
        FBActivityLogs_ListView.Name = "FBActivityLogs_ListView"
        FBActivityLogs_ListView.Size = New Size(680, 200)
        FBActivityLogs_ListView.TabIndex = 13
        FBActivityLogs_ListView.UseCompatibleStateImageBehavior = False
        FBActivityLogs_ListView.View = View.Details
        ' 
        ' ColumnHeader16
        ' 
        ColumnHeader16.Text = "社團名稱"
        ColumnHeader16.Width = 200
        ' 
        ' ColumnHeader17
        ' 
        ColumnHeader17.Text = "貼文網址"
        ColumnHeader17.Width = 470
        ' 
        ' FBNotificationsUrlData_TabPage
        ' 
        FBNotificationsUrlData_TabPage.Controls.Add(DeselecteAllFBNotificationsData_ListviewItems_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(ReadFBNotifications_CheckBox)
        FBNotificationsUrlData_TabPage.Controls.Add(UnreadFBNotifications_CheckBox)
        FBNotificationsUrlData_TabPage.Controls.Add(DeleteSelectedFBNotificationsListviewItems_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(SaveFBNotificationsListview_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(ReadFBNotifications_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsEditSelectedListviewItem_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsAddItemToListview_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsDisplayCurrUrl_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsNavigateToSelectedURL_Button)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsUrl_TextBox)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsName_TextBox)
        FBNotificationsUrlData_TabPage.Controls.Add(Label50)
        FBNotificationsUrlData_TabPage.Controls.Add(Label51)
        FBNotificationsUrlData_TabPage.Controls.Add(FBNotificationsData_Listview)
        FBNotificationsUrlData_TabPage.Location = New Point(4, 28)
        FBNotificationsUrlData_TabPage.Name = "FBNotificationsUrlData_TabPage"
        FBNotificationsUrlData_TabPage.Size = New Size(692, 351)
        FBNotificationsUrlData_TabPage.TabIndex = 2
        FBNotificationsUrlData_TabPage.Text = "通知"
        FBNotificationsUrlData_TabPage.UseVisualStyleBackColor = True
        ' 
        ' DeselecteAllFBNotificationsData_ListviewItems_Button
        ' 
        DeselecteAllFBNotificationsData_ListviewItems_Button.Location = New Point(591, 72)
        DeselecteAllFBNotificationsData_ListviewItems_Button.Name = "DeselecteAllFBNotificationsData_ListviewItems_Button"
        DeselecteAllFBNotificationsData_ListviewItems_Button.Size = New Size(94, 29)
        DeselecteAllFBNotificationsData_ListviewItems_Button.TabIndex = 29
        DeselecteAllFBNotificationsData_ListviewItems_Button.Text = "取消選擇"
        DeselecteAllFBNotificationsData_ListviewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadFBNotifications_CheckBox
        ' 
        ReadFBNotifications_CheckBox.AutoSize = True
        ReadFBNotifications_CheckBox.Location = New Point(177, 316)
        ReadFBNotifications_CheckBox.Name = "ReadFBNotifications_CheckBox"
        ReadFBNotifications_CheckBox.Size = New Size(61, 23)
        ReadFBNotifications_CheckBox.TabIndex = 28
        ReadFBNotifications_CheckBox.Text = "已讀"
        ReadFBNotifications_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' UnreadFBNotifications_CheckBox
        ' 
        UnreadFBNotifications_CheckBox.AutoSize = True
        UnreadFBNotifications_CheckBox.Checked = True
        UnreadFBNotifications_CheckBox.CheckState = CheckState.Checked
        UnreadFBNotifications_CheckBox.Location = New Point(110, 316)
        UnreadFBNotifications_CheckBox.Name = "UnreadFBNotifications_CheckBox"
        UnreadFBNotifications_CheckBox.Size = New Size(61, 23)
        UnreadFBNotifications_CheckBox.TabIndex = 27
        UnreadFBNotifications_CheckBox.Text = "未讀"
        UnreadFBNotifications_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedFBNotificationsListviewItems_Button
        ' 
        DeleteSelectedFBNotificationsListviewItems_Button.Location = New Point(592, 312)
        DeleteSelectedFBNotificationsListviewItems_Button.Name = "DeleteSelectedFBNotificationsListviewItems_Button"
        DeleteSelectedFBNotificationsListviewItems_Button.Size = New Size(94, 29)
        DeleteSelectedFBNotificationsListviewItems_Button.TabIndex = 24
        DeleteSelectedFBNotificationsListviewItems_Button.Text = "刪除"
        DeleteSelectedFBNotificationsListviewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveFBNotificationsListview_Button
        ' 
        SaveFBNotificationsListview_Button.Location = New Point(495, 312)
        SaveFBNotificationsListview_Button.Name = "SaveFBNotificationsListview_Button"
        SaveFBNotificationsListview_Button.Size = New Size(94, 29)
        SaveFBNotificationsListview_Button.TabIndex = 23
        SaveFBNotificationsListview_Button.Text = "儲存"
        SaveFBNotificationsListview_Button.UseVisualStyleBackColor = True
        ' 
        ' ReadFBNotifications_Button
        ' 
        ReadFBNotifications_Button.Location = New Point(10, 312)
        ReadFBNotifications_Button.Name = "ReadFBNotifications_Button"
        ReadFBNotifications_Button.Size = New Size(94, 29)
        ReadFBNotifications_Button.TabIndex = 22
        ReadFBNotifications_Button.Text = "讀取通知"
        ReadFBNotifications_Button.UseVisualStyleBackColor = True
        ' 
        ' FBNotificationsEditSelectedListviewItem_Button
        ' 
        FBNotificationsEditSelectedListviewItem_Button.Location = New Point(306, 72)
        FBNotificationsEditSelectedListviewItem_Button.Name = "FBNotificationsEditSelectedListviewItem_Button"
        FBNotificationsEditSelectedListviewItem_Button.Size = New Size(94, 29)
        FBNotificationsEditSelectedListviewItem_Button.TabIndex = 21
        FBNotificationsEditSelectedListviewItem_Button.Text = "修改"
        FBNotificationsEditSelectedListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' FBNotificationsAddItemToListview_Button
        ' 
        FBNotificationsAddItemToListview_Button.Location = New Point(206, 72)
        FBNotificationsAddItemToListview_Button.Name = "FBNotificationsAddItemToListview_Button"
        FBNotificationsAddItemToListview_Button.Size = New Size(94, 29)
        FBNotificationsAddItemToListview_Button.TabIndex = 20
        FBNotificationsAddItemToListview_Button.Text = "增加"
        FBNotificationsAddItemToListview_Button.UseVisualStyleBackColor = True
        ' 
        ' FBNotificationsDisplayCurrUrl_Button
        ' 
        FBNotificationsDisplayCurrUrl_Button.Location = New Point(105, 72)
        FBNotificationsDisplayCurrUrl_Button.Name = "FBNotificationsDisplayCurrUrl_Button"
        FBNotificationsDisplayCurrUrl_Button.Size = New Size(94, 29)
        FBNotificationsDisplayCurrUrl_Button.TabIndex = 19
        FBNotificationsDisplayCurrUrl_Button.Text = "取得網址"
        FBNotificationsDisplayCurrUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBNotificationsNavigateToSelectedURL_Button
        ' 
        FBNotificationsNavigateToSelectedURL_Button.Location = New Point(6, 72)
        FBNotificationsNavigateToSelectedURL_Button.Name = "FBNotificationsNavigateToSelectedURL_Button"
        FBNotificationsNavigateToSelectedURL_Button.Size = New Size(94, 29)
        FBNotificationsNavigateToSelectedURL_Button.TabIndex = 18
        FBNotificationsNavigateToSelectedURL_Button.Text = "前往"
        FBNotificationsNavigateToSelectedURL_Button.UseVisualStyleBackColor = True
        ' 
        ' FBNotificationsUrl_TextBox
        ' 
        FBNotificationsUrl_TextBox.Location = New Point(92, 39)
        FBNotificationsUrl_TextBox.Name = "FBNotificationsUrl_TextBox"
        FBNotificationsUrl_TextBox.Size = New Size(593, 27)
        FBNotificationsUrl_TextBox.TabIndex = 17
        ' 
        ' FBNotificationsName_TextBox
        ' 
        FBNotificationsName_TextBox.Location = New Point(92, 5)
        FBNotificationsName_TextBox.Name = "FBNotificationsName_TextBox"
        FBNotificationsName_TextBox.Size = New Size(593, 27)
        FBNotificationsName_TextBox.TabIndex = 16
        ' 
        ' Label50
        ' 
        Label50.AutoSize = True
        Label50.Location = New Point(6, 42)
        Label50.Name = "Label50"
        Label50.Size = New Size(80, 19)
        Label50.TabIndex = 15
        Label50.Text = "回應網址 : "
        ' 
        ' Label51
        ' 
        Label51.AutoSize = True
        Label51.Location = New Point(6, 9)
        Label51.Name = "Label51"
        Label51.Size = New Size(80, 19)
        Label51.TabIndex = 14
        Label51.Text = "人物名稱 : "
        ' 
        ' FBNotificationsData_Listview
        ' 
        FBNotificationsData_Listview.Columns.AddRange(New ColumnHeader() {ColumnHeader18, ColumnHeader19})
        FBNotificationsData_Listview.FullRowSelect = True
        FBNotificationsData_Listview.Location = New Point(6, 106)
        FBNotificationsData_Listview.Name = "FBNotificationsData_Listview"
        FBNotificationsData_Listview.Size = New Size(680, 200)
        FBNotificationsData_Listview.TabIndex = 13
        FBNotificationsData_Listview.UseCompatibleStateImageBehavior = False
        FBNotificationsData_Listview.View = View.Details
        ' 
        ' ColumnHeader18
        ' 
        ColumnHeader18.Text = "人物名稱"
        ColumnHeader18.Width = 200
        ' 
        ' ColumnHeader19
        ' 
        ColumnHeader19.Text = "回應網址"
        ColumnHeader19.Width = 470
        ' 
        ' FBMessengerUrlData_TabPage
        ' 
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerMessageSource_ComboBox)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerReadMessage_Button)
        FBMessengerUrlData_TabPage.Controls.Add(DeselecteAllFBMessenger_ListviewItems_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerReadMessage_CheckBox)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerUnreadMessage_CheckBox)
        FBMessengerUrlData_TabPage.Controls.Add(DeleteSelectedFBMessengerListviewItems_Button)
        FBMessengerUrlData_TabPage.Controls.Add(SaveFBMessengerListview_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerNavigateToMessenger_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerEditSelectedListviewItem_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerAddItemToListview_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerDisplayCurrUrl_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerNavigateToSelectedURL_Button)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerUrl_TextBox)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerName_TextBox)
        FBMessengerUrlData_TabPage.Controls.Add(Label56)
        FBMessengerUrlData_TabPage.Controls.Add(Label57)
        FBMessengerUrlData_TabPage.Controls.Add(FBMessengerData_Listview)
        FBMessengerUrlData_TabPage.Location = New Point(4, 28)
        FBMessengerUrlData_TabPage.Name = "FBMessengerUrlData_TabPage"
        FBMessengerUrlData_TabPage.Size = New Size(692, 351)
        FBMessengerUrlData_TabPage.TabIndex = 3
        FBMessengerUrlData_TabPage.Text = "聊天室"
        FBMessengerUrlData_TabPage.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerMessageSource_ComboBox
        ' 
        FBMessengerMessageSource_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        FBMessengerMessageSource_ComboBox.FormattingEnabled = True
        FBMessengerMessageSource_ComboBox.Items.AddRange(New Object() {"", "聊天室", "Marketplace", "陌生訊息"})
        FBMessengerMessageSource_ComboBox.Location = New Point(344, 312)
        FBMessengerMessageSource_ComboBox.Name = "FBMessengerMessageSource_ComboBox"
        FBMessengerMessageSource_ComboBox.Size = New Size(145, 27)
        FBMessengerMessageSource_ComboBox.TabIndex = 46
        ' 
        ' FBMessengerReadMessage_Button
        ' 
        FBMessengerReadMessage_Button.Location = New Point(244, 312)
        FBMessengerReadMessage_Button.Name = "FBMessengerReadMessage_Button"
        FBMessengerReadMessage_Button.Size = New Size(94, 29)
        FBMessengerReadMessage_Button.TabIndex = 45
        FBMessengerReadMessage_Button.Text = "讀取"
        FBMessengerReadMessage_Button.UseVisualStyleBackColor = True
        ' 
        ' DeselecteAllFBMessenger_ListviewItems_Button
        ' 
        DeselecteAllFBMessenger_ListviewItems_Button.Location = New Point(591, 72)
        DeselecteAllFBMessenger_ListviewItems_Button.Name = "DeselecteAllFBMessenger_ListviewItems_Button"
        DeselecteAllFBMessenger_ListviewItems_Button.Size = New Size(94, 29)
        DeselecteAllFBMessenger_ListviewItems_Button.TabIndex = 44
        DeselecteAllFBMessenger_ListviewItems_Button.Text = "取消選擇"
        DeselecteAllFBMessenger_ListviewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerReadMessage_CheckBox
        ' 
        FBMessengerReadMessage_CheckBox.AutoSize = True
        FBMessengerReadMessage_CheckBox.Location = New Point(177, 316)
        FBMessengerReadMessage_CheckBox.Name = "FBMessengerReadMessage_CheckBox"
        FBMessengerReadMessage_CheckBox.Size = New Size(61, 23)
        FBMessengerReadMessage_CheckBox.TabIndex = 43
        FBMessengerReadMessage_CheckBox.Text = "已讀"
        FBMessengerReadMessage_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerUnreadMessage_CheckBox
        ' 
        FBMessengerUnreadMessage_CheckBox.AutoSize = True
        FBMessengerUnreadMessage_CheckBox.Checked = True
        FBMessengerUnreadMessage_CheckBox.CheckState = CheckState.Checked
        FBMessengerUnreadMessage_CheckBox.Location = New Point(110, 316)
        FBMessengerUnreadMessage_CheckBox.Name = "FBMessengerUnreadMessage_CheckBox"
        FBMessengerUnreadMessage_CheckBox.Size = New Size(61, 23)
        FBMessengerUnreadMessage_CheckBox.TabIndex = 42
        FBMessengerUnreadMessage_CheckBox.Text = "未讀"
        FBMessengerUnreadMessage_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedFBMessengerListviewItems_Button
        ' 
        DeleteSelectedFBMessengerListviewItems_Button.Location = New Point(592, 312)
        DeleteSelectedFBMessengerListviewItems_Button.Name = "DeleteSelectedFBMessengerListviewItems_Button"
        DeleteSelectedFBMessengerListviewItems_Button.Size = New Size(94, 29)
        DeleteSelectedFBMessengerListviewItems_Button.TabIndex = 41
        DeleteSelectedFBMessengerListviewItems_Button.Text = "刪除"
        DeleteSelectedFBMessengerListviewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveFBMessengerListview_Button
        ' 
        SaveFBMessengerListview_Button.Location = New Point(495, 312)
        SaveFBMessengerListview_Button.Name = "SaveFBMessengerListview_Button"
        SaveFBMessengerListview_Button.Size = New Size(94, 29)
        SaveFBMessengerListview_Button.TabIndex = 40
        SaveFBMessengerListview_Button.Text = "儲存"
        SaveFBMessengerListview_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerNavigateToMessenger_Button
        ' 
        FBMessengerNavigateToMessenger_Button.Location = New Point(10, 312)
        FBMessengerNavigateToMessenger_Button.Name = "FBMessengerNavigateToMessenger_Button"
        FBMessengerNavigateToMessenger_Button.Size = New Size(94, 29)
        FBMessengerNavigateToMessenger_Button.TabIndex = 39
        FBMessengerNavigateToMessenger_Button.Text = "前往Msg"
        FBMessengerNavigateToMessenger_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerEditSelectedListviewItem_Button
        ' 
        FBMessengerEditSelectedListviewItem_Button.Location = New Point(306, 72)
        FBMessengerEditSelectedListviewItem_Button.Name = "FBMessengerEditSelectedListviewItem_Button"
        FBMessengerEditSelectedListviewItem_Button.Size = New Size(94, 29)
        FBMessengerEditSelectedListviewItem_Button.TabIndex = 38
        FBMessengerEditSelectedListviewItem_Button.Text = "修改"
        FBMessengerEditSelectedListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerAddItemToListview_Button
        ' 
        FBMessengerAddItemToListview_Button.Location = New Point(206, 72)
        FBMessengerAddItemToListview_Button.Name = "FBMessengerAddItemToListview_Button"
        FBMessengerAddItemToListview_Button.Size = New Size(94, 29)
        FBMessengerAddItemToListview_Button.TabIndex = 37
        FBMessengerAddItemToListview_Button.Text = "增加"
        FBMessengerAddItemToListview_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerDisplayCurrUrl_Button
        ' 
        FBMessengerDisplayCurrUrl_Button.Location = New Point(105, 72)
        FBMessengerDisplayCurrUrl_Button.Name = "FBMessengerDisplayCurrUrl_Button"
        FBMessengerDisplayCurrUrl_Button.Size = New Size(94, 29)
        FBMessengerDisplayCurrUrl_Button.TabIndex = 36
        FBMessengerDisplayCurrUrl_Button.Text = "取得網址"
        FBMessengerDisplayCurrUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerNavigateToSelectedURL_Button
        ' 
        FBMessengerNavigateToSelectedURL_Button.Location = New Point(6, 72)
        FBMessengerNavigateToSelectedURL_Button.Name = "FBMessengerNavigateToSelectedURL_Button"
        FBMessengerNavigateToSelectedURL_Button.Size = New Size(94, 29)
        FBMessengerNavigateToSelectedURL_Button.TabIndex = 35
        FBMessengerNavigateToSelectedURL_Button.Text = "前往"
        FBMessengerNavigateToSelectedURL_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerUrl_TextBox
        ' 
        FBMessengerUrl_TextBox.Location = New Point(92, 39)
        FBMessengerUrl_TextBox.Name = "FBMessengerUrl_TextBox"
        FBMessengerUrl_TextBox.Size = New Size(593, 27)
        FBMessengerUrl_TextBox.TabIndex = 34
        ' 
        ' FBMessengerName_TextBox
        ' 
        FBMessengerName_TextBox.Location = New Point(92, 5)
        FBMessengerName_TextBox.Name = "FBMessengerName_TextBox"
        FBMessengerName_TextBox.Size = New Size(593, 27)
        FBMessengerName_TextBox.TabIndex = 33
        ' 
        ' Label56
        ' 
        Label56.AutoSize = True
        Label56.Location = New Point(6, 42)
        Label56.Name = "Label56"
        Label56.Size = New Size(80, 19)
        Label56.TabIndex = 32
        Label56.Text = "回應網址 : "
        ' 
        ' Label57
        ' 
        Label57.AutoSize = True
        Label57.Location = New Point(6, 9)
        Label57.Name = "Label57"
        Label57.Size = New Size(80, 19)
        Label57.TabIndex = 31
        Label57.Text = "人物名稱 : "
        ' 
        ' FBMessengerData_Listview
        ' 
        FBMessengerData_Listview.Columns.AddRange(New ColumnHeader() {ColumnHeader20, ColumnHeader21})
        FBMessengerData_Listview.FullRowSelect = True
        FBMessengerData_Listview.Location = New Point(6, 106)
        FBMessengerData_Listview.Name = "FBMessengerData_Listview"
        FBMessengerData_Listview.Size = New Size(680, 200)
        FBMessengerData_Listview.TabIndex = 30
        FBMessengerData_Listview.UseCompatibleStateImageBehavior = False
        FBMessengerData_Listview.View = View.Details
        ' 
        ' ColumnHeader20
        ' 
        ColumnHeader20.Text = "人物名稱"
        ColumnHeader20.Width = 200
        ' 
        ' ColumnHeader21
        ' 
        ColumnHeader21.Text = "回應網址"
        ColumnHeader21.Width = 470
        ' 
        ' FBMediaDownloader_TabPage
        ' 
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderDownloadMediaResources_Button)
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderRevealDownloadMediaFolder_Button)
        FBMediaDownloader_TabPage.Controls.Add(Label70)
        FBMediaDownloader_TabPage.Controls.Add(FBImageDownloadUrl_TextBox)
        FBMediaDownloader_TabPage.Controls.Add(FBImageDownloadGetMediaResourcesUrl_Button)
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderNavigateToUrl_Button)
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderNextMediaCount_NumericUpDown)
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderUrls_ListView)
        FBMediaDownloader_TabPage.Controls.Add(Label71)
        FBMediaDownloader_TabPage.Controls.Add(FBMediaDownloaderGetUrl_Button)
        FBMediaDownloader_TabPage.Location = New Point(4, 28)
        FBMediaDownloader_TabPage.Name = "FBMediaDownloader_TabPage"
        FBMediaDownloader_TabPage.Size = New Size(692, 351)
        FBMediaDownloader_TabPage.TabIndex = 4
        FBMediaDownloader_TabPage.Text = "圖片下載"
        FBMediaDownloader_TabPage.UseVisualStyleBackColor = True
        ' 
        ' FBMediaDownloaderDownloadMediaResources_Button
        ' 
        FBMediaDownloaderDownloadMediaResources_Button.Location = New Point(486, 317)
        FBMediaDownloaderDownloadMediaResources_Button.Name = "FBMediaDownloaderDownloadMediaResources_Button"
        FBMediaDownloaderDownloadMediaResources_Button.Size = New Size(94, 29)
        FBMediaDownloaderDownloadMediaResources_Button.TabIndex = 39
        FBMediaDownloaderDownloadMediaResources_Button.Text = "下載資源"
        FBMediaDownloaderDownloadMediaResources_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMediaDownloaderRevealDownloadMediaFolder_Button
        ' 
        FBMediaDownloaderRevealDownloadMediaFolder_Button.Location = New Point(589, 317)
        FBMediaDownloaderRevealDownloadMediaFolder_Button.Name = "FBMediaDownloaderRevealDownloadMediaFolder_Button"
        FBMediaDownloaderRevealDownloadMediaFolder_Button.Size = New Size(94, 29)
        FBMediaDownloaderRevealDownloadMediaFolder_Button.TabIndex = 40
        FBMediaDownloaderRevealDownloadMediaFolder_Button.Text = "打開資料夾"
        FBMediaDownloaderRevealDownloadMediaFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' Label70
        ' 
        Label70.AutoSize = True
        Label70.Location = New Point(9, 18)
        Label70.Name = "Label70"
        Label70.Size = New Size(50, 19)
        Label70.TabIndex = 0
        Label70.Text = "網址 : "
        ' 
        ' FBImageDownloadUrl_TextBox
        ' 
        FBImageDownloadUrl_TextBox.Location = New Point(65, 13)
        FBImageDownloadUrl_TextBox.Name = "FBImageDownloadUrl_TextBox"
        FBImageDownloadUrl_TextBox.Size = New Size(417, 27)
        FBImageDownloadUrl_TextBox.TabIndex = 1
        ' 
        ' FBImageDownloadGetMediaResourcesUrl_Button
        ' 
        FBImageDownloadGetMediaResourcesUrl_Button.Location = New Point(186, 315)
        FBImageDownloadGetMediaResourcesUrl_Button.Name = "FBImageDownloadGetMediaResourcesUrl_Button"
        FBImageDownloadGetMediaResourcesUrl_Button.Size = New Size(124, 29)
        FBImageDownloadGetMediaResourcesUrl_Button.TabIndex = 9
        FBImageDownloadGetMediaResourcesUrl_Button.Text = "獲取資源網址"
        FBImageDownloadGetMediaResourcesUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMediaDownloaderNavigateToUrl_Button
        ' 
        FBMediaDownloaderNavigateToUrl_Button.Location = New Point(488, 13)
        FBMediaDownloaderNavigateToUrl_Button.Name = "FBMediaDownloaderNavigateToUrl_Button"
        FBMediaDownloaderNavigateToUrl_Button.Size = New Size(94, 29)
        FBMediaDownloaderNavigateToUrl_Button.TabIndex = 2
        FBMediaDownloaderNavigateToUrl_Button.Text = "前往"
        FBMediaDownloaderNavigateToUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMediaDownloaderNextMediaCount_NumericUpDown
        ' 
        FBMediaDownloaderNextMediaCount_NumericUpDown.Location = New Point(110, 317)
        FBMediaDownloaderNextMediaCount_NumericUpDown.Name = "FBMediaDownloaderNextMediaCount_NumericUpDown"
        FBMediaDownloaderNextMediaCount_NumericUpDown.Size = New Size(70, 27)
        FBMediaDownloaderNextMediaCount_NumericUpDown.TabIndex = 8
        ' 
        ' FBMediaDownloaderUrls_ListView
        ' 
        FBMediaDownloaderUrls_ListView.Columns.AddRange(New ColumnHeader() {MediaResourceUrl_ColumnHeader})
        FBMediaDownloaderUrls_ListView.Location = New Point(8, 46)
        FBMediaDownloaderUrls_ListView.Name = "FBMediaDownloaderUrls_ListView"
        FBMediaDownloaderUrls_ListView.Size = New Size(674, 263)
        FBMediaDownloaderUrls_ListView.TabIndex = 3
        FBMediaDownloaderUrls_ListView.UseCompatibleStateImageBehavior = False
        FBMediaDownloaderUrls_ListView.View = View.Details
        ' 
        ' MediaResourceUrl_ColumnHeader
        ' 
        MediaResourceUrl_ColumnHeader.Text = "資源網址"
        MediaResourceUrl_ColumnHeader.Width = 670
        ' 
        ' Label71
        ' 
        Label71.AutoSize = True
        Label71.Location = New Point(9, 320)
        Label71.Name = "Label71"
        Label71.Size = New Size(95, 19)
        Label71.TabIndex = 7
        Label71.Text = "下一頁次數 : "
        ' 
        ' FBMediaDownloaderGetUrl_Button
        ' 
        FBMediaDownloaderGetUrl_Button.Location = New Point(588, 13)
        FBMediaDownloaderGetUrl_Button.Name = "FBMediaDownloaderGetUrl_Button"
        FBMediaDownloaderGetUrl_Button.Size = New Size(94, 29)
        FBMediaDownloaderGetUrl_Button.TabIndex = 4
        FBMediaDownloaderGetUrl_Button.Text = "取得網址"
        FBMediaDownloaderGetUrl_Button.UseVisualStyleBackColor = True
        ' 
        ' ScriptQueue_ListView
        ' 
        ScriptQueue_ListView.Columns.AddRange(New ColumnHeader() {ColumnHeader3, ColumnHeader4, ColumnHeader7, ColumnHeader6, ColumnHeader5, ColumnHeader15, ColumnHeader8, ColumnHeader13, ColumnHeader14, ColumnHeader9, ColumnHeader11, ColumnHeader10, ColumnHeader12})
        ScriptQueue_ListView.FullRowSelect = True
        ScriptQueue_ListView.Location = New Point(12, 641)
        ScriptQueue_ListView.Name = "ScriptQueue_ListView"
        ScriptQueue_ListView.Size = New Size(1129, 417)
        ScriptQueue_ListView.TabIndex = 24
        ScriptQueue_ListView.UseCompatibleStateImageBehavior = False
        ScriptQueue_ListView.View = View.Details
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "執行帳號"
        ColumnHeader3.Width = 120
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
        ColumnHeader6.Width = 100
        ' 
        ' ColumnHeader5
        ' 
        ColumnHeader5.Text = "執行動作"
        ColumnHeader5.Width = 80
        ' 
        ' ColumnHeader15
        ' 
        ColumnHeader15.Text = "選擇內容"
        ColumnHeader15.Width = 100
        ' 
        ' ColumnHeader8
        ' 
        ColumnHeader8.Text = "執行內容"
        ColumnHeader8.Width = 150
        ' 
        ' ColumnHeader13
        ' 
        ColumnHeader13.Text = "上傳等待"
        ColumnHeader13.Width = 80
        ' 
        ' ColumnHeader14
        ' 
        ColumnHeader14.Text = "送出等待"
        ColumnHeader14.Width = 80
        ' 
        ' ColumnHeader9
        ' 
        ColumnHeader9.Text = "成功"
        ColumnHeader9.Width = 50
        ' 
        ' ColumnHeader11
        ' 
        ColumnHeader11.Text = "失敗"
        ColumnHeader11.Width = 50
        ' 
        ' ColumnHeader10
        ' 
        ColumnHeader10.Text = "等待時間"
        ColumnHeader10.Width = 90
        ' 
        ' ColumnHeader12
        ' 
        ColumnHeader12.Text = "備註"
        ' 
        ' Action_TabControl
        ' 
        Action_TabControl.Controls.Add(FBPostAssets_TabPage)
        Action_TabControl.Controls.Add(FBMarketplaceAssets_TabPage)
        Action_TabControl.Controls.Add(FBPostShareURLAssets_TabPage)
        Action_TabControl.Controls.Add(FBCommentAssets_TabPage)
        Action_TabControl.Controls.Add(FBCustomizeCommentAssets_TabPage)
        Action_TabControl.Controls.Add(FBRespondNotificationsAssets_TabPage)
        Action_TabControl.Controls.Add(FBMessengerAssets_TabPage)
        Action_TabControl.Controls.Add(FBStoryAssets_TabPage)
        Action_TabControl.Controls.Add(FBPersonalPostAssets_TabPage)
        Action_TabControl.Controls.Add(FBReelsAssets_TabPage)
        Action_TabControl.Controls.Add(DevTool_TabPage)
        Action_TabControl.Location = New Point(1147, 11)
        Action_TabControl.Name = "Action_TabControl"
        Action_TabControl.SelectedIndex = 0
        Action_TabControl.Size = New Size(672, 499)
        Action_TabControl.TabIndex = 25
        ' 
        ' FBPostAssets_TabPage
        ' 
        FBPostAssets_TabPage.Controls.Add(Label23)
        FBPostAssets_TabPage.Controls.Add(Label22)
        FBPostAssets_TabPage.Controls.Add(Label21)
        FBPostAssets_TabPage.Controls.Add(FBWritePostUploadWaitSeconds_NumericUpDown)
        FBPostAssets_TabPage.Controls.Add(FBWritePostSubmitWaitSeconds_NumericUpDown)
        FBPostAssets_TabPage.Controls.Add(DeselectAllMyAssetFolderListboxItems_Button)
        FBPostAssets_TabPage.Controls.Add(DeleteSelectedTextFiles_Button)
        FBPostAssets_TabPage.Controls.Add(NewTextFileName_TextBox)
        FBPostAssets_TabPage.Controls.Add(MediaSelector_ListBox)
        FBPostAssets_TabPage.Controls.Add(TextFileSelector_ListBox)
        FBPostAssets_TabPage.Controls.Add(MyAssetsFolder_ListBox)
        FBPostAssets_TabPage.Controls.Add(SaveEditedTextFile_Button)
        FBPostAssets_TabPage.Controls.Add(CreateNewTextFile_Button)
        FBPostAssets_TabPage.Controls.Add(DeleteSelectedMedia_Button)
        FBPostAssets_TabPage.Controls.Add(RevealMediaFoldesrInFileExplorer_Button)
        FBPostAssets_TabPage.Controls.Add(DeleteSelectedAssetFolder_Button)
        FBPostAssets_TabPage.Controls.Add(NewAssetFolderName_TextBox)
        FBPostAssets_TabPage.Controls.Add(MediaPreview_PictureBox)
        FBPostAssets_TabPage.Controls.Add(PreviewTextFile_RichTextBox)
        FBPostAssets_TabPage.Controls.Add(CreateNewAssetFolder_Button)
        FBPostAssets_TabPage.Location = New Point(4, 28)
        FBPostAssets_TabPage.Name = "FBPostAssets_TabPage"
        FBPostAssets_TabPage.Padding = New Padding(3)
        FBPostAssets_TabPage.Size = New Size(664, 467)
        FBPostAssets_TabPage.TabIndex = 0
        FBPostAssets_TabPage.Text = "發帖"
        FBPostAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(6, 364)
        Label23.Name = "Label23"
        Label23.Size = New Size(50, 19)
        Label23.TabIndex = 24
        Label23.Text = "名稱 : "
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(334, 13)
        Label22.Name = "Label22"
        Label22.Size = New Size(80, 19)
        Label22.TabIndex = 23
        Label22.Text = "送出等待 : "
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(183, 13)
        Label21.Name = "Label21"
        Label21.Size = New Size(80, 19)
        Label21.TabIndex = 21
        Label21.Text = "上載等待 : "
        ' 
        ' FBWritePostUploadWaitSeconds_NumericUpDown
        ' 
        FBWritePostUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBWritePostUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBWritePostUploadWaitSeconds_NumericUpDown.Name = "FBWritePostUploadWaitSeconds_NumericUpDown"
        FBWritePostUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBWritePostUploadWaitSeconds_NumericUpDown.TabIndex = 20
        ' 
        ' FBWritePostSubmitWaitSeconds_NumericUpDown
        ' 
        FBWritePostSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBWritePostSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBWritePostSubmitWaitSeconds_NumericUpDown.Name = "FBWritePostSubmitWaitSeconds_NumericUpDown"
        FBWritePostSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBWritePostSubmitWaitSeconds_NumericUpDown.TabIndex = 19
        ' 
        ' DeselectAllMyAssetFolderListboxItems_Button
        ' 
        DeselectAllMyAssetFolderListboxItems_Button.Location = New Point(6, 326)
        DeselectAllMyAssetFolderListboxItems_Button.Name = "DeselectAllMyAssetFolderListboxItems_Button"
        DeselectAllMyAssetFolderListboxItems_Button.Size = New Size(170, 29)
        DeselectAllMyAssetFolderListboxItems_Button.TabIndex = 18
        DeselectAllMyAssetFolderListboxItems_Button.Text = "取消選擇"
        DeselectAllMyAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedTextFiles_Button
        ' 
        DeleteSelectedTextFiles_Button.Location = New Point(435, 189)
        DeleteSelectedTextFiles_Button.Name = "DeleteSelectedTextFiles_Button"
        DeleteSelectedTextFiles_Button.Size = New Size(94, 29)
        DeleteSelectedTextFiles_Button.TabIndex = 17
        DeleteSelectedTextFiles_Button.Text = "刪除所選"
        DeleteSelectedTextFiles_Button.UseVisualStyleBackColor = True
        ' 
        ' NewTextFileName_TextBox
        ' 
        NewTextFileName_TextBox.Location = New Point(183, 189)
        NewTextFileName_TextBox.Name = "NewTextFileName_TextBox"
        NewTextFileName_TextBox.Size = New Size(145, 27)
        NewTextFileName_TextBox.TabIndex = 16
        ' 
        ' MediaSelector_ListBox
        ' 
        MediaSelector_ListBox.FormattingEnabled = True
        MediaSelector_ListBox.ItemHeight = 19
        MediaSelector_ListBox.Location = New Point(183, 224)
        MediaSelector_ListBox.Name = "MediaSelector_ListBox"
        MediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        MediaSelector_ListBox.Size = New Size(145, 156)
        MediaSelector_ListBox.TabIndex = 15
        ' 
        ' TextFileSelector_ListBox
        ' 
        TextFileSelector_ListBox.FormattingEnabled = True
        TextFileSelector_ListBox.ItemHeight = 19
        TextFileSelector_ListBox.Location = New Point(183, 46)
        TextFileSelector_ListBox.Name = "TextFileSelector_ListBox"
        TextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        TextFileSelector_ListBox.Size = New Size(145, 137)
        TextFileSelector_ListBox.TabIndex = 14
        ' 
        ' MyAssetsFolder_ListBox
        ' 
        MyAssetsFolder_ListBox.FormattingEnabled = True
        MyAssetsFolder_ListBox.ItemHeight = 19
        MyAssetsFolder_ListBox.Location = New Point(6, 8)
        MyAssetsFolder_ListBox.Name = "MyAssetsFolder_ListBox"
        MyAssetsFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        MyAssetsFolder_ListBox.Size = New Size(170, 308)
        MyAssetsFolder_ListBox.TabIndex = 13
        ' 
        ' SaveEditedTextFile_Button
        ' 
        SaveEditedTextFile_Button.Location = New Point(534, 189)
        SaveEditedTextFile_Button.Name = "SaveEditedTextFile_Button"
        SaveEditedTextFile_Button.Size = New Size(94, 29)
        SaveEditedTextFile_Button.TabIndex = 12
        SaveEditedTextFile_Button.Text = "儲存"
        SaveEditedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' CreateNewTextFile_Button
        ' 
        CreateNewTextFile_Button.Location = New Point(334, 189)
        CreateNewTextFile_Button.Name = "CreateNewTextFile_Button"
        CreateNewTextFile_Button.Size = New Size(94, 29)
        CreateNewTextFile_Button.TabIndex = 11
        CreateNewTextFile_Button.Text = "新增文字檔"
        CreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedMedia_Button
        ' 
        DeleteSelectedMedia_Button.Location = New Point(183, 429)
        DeleteSelectedMedia_Button.Name = "DeleteSelectedMedia_Button"
        DeleteSelectedMedia_Button.Size = New Size(147, 29)
        DeleteSelectedMedia_Button.TabIndex = 9
        DeleteSelectedMedia_Button.Text = "刪除所選"
        DeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' RevealMediaFoldesrInFileExplorer_Button
        ' 
        RevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        RevealMediaFoldesrInFileExplorer_Button.Name = "RevealMediaFoldesrInFileExplorer_Button"
        RevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        RevealMediaFoldesrInFileExplorer_Button.TabIndex = 8
        RevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        RevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedAssetFolder_Button
        ' 
        DeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        DeleteSelectedAssetFolder_Button.Name = "DeleteSelectedAssetFolder_Button"
        DeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        DeleteSelectedAssetFolder_Button.TabIndex = 7
        DeleteSelectedAssetFolder_Button.Text = "刪除所選"
        DeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' NewAssetFolderName_TextBox
        ' 
        NewAssetFolderName_TextBox.Location = New Point(62, 360)
        NewAssetFolderName_TextBox.Name = "NewAssetFolderName_TextBox"
        NewAssetFolderName_TextBox.Size = New Size(115, 27)
        NewAssetFolderName_TextBox.TabIndex = 6
        ' 
        ' MediaPreview_PictureBox
        ' 
        MediaPreview_PictureBox.Location = New Point(334, 224)
        MediaPreview_PictureBox.Name = "MediaPreview_PictureBox"
        MediaPreview_PictureBox.Size = New Size(325, 234)
        MediaPreview_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        MediaPreview_PictureBox.TabIndex = 5
        MediaPreview_PictureBox.TabStop = False
        ' 
        ' PreviewTextFile_RichTextBox
        ' 
        PreviewTextFile_RichTextBox.Location = New Point(334, 44)
        PreviewTextFile_RichTextBox.Name = "PreviewTextFile_RichTextBox"
        PreviewTextFile_RichTextBox.Size = New Size(325, 140)
        PreviewTextFile_RichTextBox.TabIndex = 4
        PreviewTextFile_RichTextBox.Text = ""
        PreviewTextFile_RichTextBox.WordWrap = False
        ' 
        ' CreateNewAssetFolder_Button
        ' 
        CreateNewAssetFolder_Button.Location = New Point(6, 393)
        CreateNewAssetFolder_Button.Name = "CreateNewAssetFolder_Button"
        CreateNewAssetFolder_Button.Size = New Size(170, 29)
        CreateNewAssetFolder_Button.TabIndex = 2
        CreateNewAssetFolder_Button.Text = "建立"
        CreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceAssets_TabPage
        ' 
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceShareGroupsByRandom_RadioButton)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceShareGroupsBySequence_RadioButton)
        FBMarketplaceAssets_TabPage.Controls.Add(RevealFBMarketplaceMediaFoldesrInFileExplorer_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceShareGroupsCount_NumericUpDown)
        FBMarketplaceAssets_TabPage.Controls.Add(Label36)
        FBMarketplaceAssets_TabPage.Controls.Add(Label34)
        FBMarketplaceAssets_TabPage.Controls.Add(Label35)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceUploadWaitSeconds_NumericUpDown)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceSubmitWaitSeconds_NumericUpDown)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceOnMarketplace_CheckBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceHomeDelivery_CheckBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplacePickUp_CheckBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceMeetInPerson_CheckBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductTag_TextBox)
        FBMarketplaceAssets_TabPage.Controls.Add(Label33)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceDeleteSelectedMedia_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceMediaPreviewer_PictureBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceMediaSelector_ListBox)
        FBMarketplaceAssets_TabPage.Controls.Add(Label32)
        FBMarketplaceAssets_TabPage.Controls.Add(Label31)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceSavePruductInfo_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductDescription_RichTextBox)
        FBMarketplaceAssets_TabPage.Controls.Add(Label30)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductLocation_TextBox)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductStatus_NumericUpDown)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductPrice_NumericUpDown)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceProductName_TextBox)
        FBMarketplaceAssets_TabPage.Controls.Add(Label29)
        FBMarketplaceAssets_TabPage.Controls.Add(Label28)
        FBMarketplaceAssets_TabPage.Controls.Add(Label27)
        FBMarketplaceAssets_TabPage.Controls.Add(Label26)
        FBMarketplaceAssets_TabPage.Controls.Add(Label8)
        FBMarketplaceAssets_TabPage.Controls.Add(FBmarketplaceDeselectAllProductFolderListboxItems_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarketplaceDeleteSelectedAssetFolder_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(NewMarketplaceAssetFolderName_TextBox)
        FBMarketplaceAssets_TabPage.Controls.Add(CreateNewMarketplaceAssetFolder_Button)
        FBMarketplaceAssets_TabPage.Controls.Add(FBMarkplaceProducts_ListBox)
        FBMarketplaceAssets_TabPage.Location = New Point(4, 28)
        FBMarketplaceAssets_TabPage.Name = "FBMarketplaceAssets_TabPage"
        FBMarketplaceAssets_TabPage.Size = New Size(664, 467)
        FBMarketplaceAssets_TabPage.TabIndex = 2
        FBMarketplaceAssets_TabPage.Text = "拍賣"
        FBMarketplaceAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceShareGroupsByRandom_RadioButton
        ' 
        FBMarketplaceShareGroupsByRandom_RadioButton.AutoSize = True
        FBMarketplaceShareGroupsByRandom_RadioButton.Location = New Point(400, 203)
        FBMarketplaceShareGroupsByRandom_RadioButton.Name = "FBMarketplaceShareGroupsByRandom_RadioButton"
        FBMarketplaceShareGroupsByRandom_RadioButton.Size = New Size(60, 23)
        FBMarketplaceShareGroupsByRandom_RadioButton.TabIndex = 70
        FBMarketplaceShareGroupsByRandom_RadioButton.Text = "隨機"
        FBMarketplaceShareGroupsByRandom_RadioButton.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceShareGroupsBySequence_RadioButton
        ' 
        FBMarketplaceShareGroupsBySequence_RadioButton.AutoSize = True
        FBMarketplaceShareGroupsBySequence_RadioButton.Checked = True
        FBMarketplaceShareGroupsBySequence_RadioButton.Location = New Point(334, 203)
        FBMarketplaceShareGroupsBySequence_RadioButton.Name = "FBMarketplaceShareGroupsBySequence_RadioButton"
        FBMarketplaceShareGroupsBySequence_RadioButton.Size = New Size(60, 23)
        FBMarketplaceShareGroupsBySequence_RadioButton.TabIndex = 69
        FBMarketplaceShareGroupsBySequence_RadioButton.TabStop = True
        FBMarketplaceShareGroupsBySequence_RadioButton.Text = "順序"
        FBMarketplaceShareGroupsBySequence_RadioButton.UseVisualStyleBackColor = True
        ' 
        ' RevealFBMarketplaceMediaFoldesrInFileExplorer_Button
        ' 
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.Location = New Point(282, 424)
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.Name = "RevealFBMarketplaceMediaFoldesrInFileExplorer_Button"
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.Size = New Size(51, 29)
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.TabIndex = 68
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.Text = "開啟"
        RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceShareGroupsCount_NumericUpDown
        ' 
        FBMarketplaceShareGroupsCount_NumericUpDown.Location = New Point(267, 201)
        FBMarketplaceShareGroupsCount_NumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        FBMarketplaceShareGroupsCount_NumericUpDown.Name = "FBMarketplaceShareGroupsCount_NumericUpDown"
        FBMarketplaceShareGroupsCount_NumericUpDown.Size = New Size(60, 27)
        FBMarketplaceShareGroupsCount_NumericUpDown.TabIndex = 66
        ' 
        ' Label36
        ' 
        Label36.AutoSize = True
        Label36.Location = New Point(183, 203)
        Label36.Name = "Label36"
        Label36.Size = New Size(80, 19)
        Label36.TabIndex = 65
        Label36.Text = "其他社團 : "
        ' 
        ' Label34
        ' 
        Label34.AutoSize = True
        Label34.Location = New Point(334, 174)
        Label34.Name = "Label34"
        Label34.Size = New Size(80, 19)
        Label34.TabIndex = 63
        Label34.Text = "送出等待 : "
        ' 
        ' Label35
        ' 
        Label35.AutoSize = True
        Label35.Location = New Point(183, 174)
        Label35.Name = "Label35"
        Label35.Size = New Size(80, 19)
        Label35.TabIndex = 62
        Label35.Text = "上載等待 : "
        ' 
        ' FBMarketplaceUploadWaitSeconds_NumericUpDown
        ' 
        FBMarketplaceUploadWaitSeconds_NumericUpDown.Location = New Point(267, 168)
        FBMarketplaceUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBMarketplaceUploadWaitSeconds_NumericUpDown.Name = "FBMarketplaceUploadWaitSeconds_NumericUpDown"
        FBMarketplaceUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBMarketplaceUploadWaitSeconds_NumericUpDown.TabIndex = 61
        ' 
        ' FBMarketplaceSubmitWaitSeconds_NumericUpDown
        ' 
        FBMarketplaceSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 168)
        FBMarketplaceSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBMarketplaceSubmitWaitSeconds_NumericUpDown.Name = "FBMarketplaceSubmitWaitSeconds_NumericUpDown"
        FBMarketplaceSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBMarketplaceSubmitWaitSeconds_NumericUpDown.TabIndex = 60
        ' 
        ' FBMarketplaceOnMarketplace_CheckBox
        ' 
        FBMarketplaceOnMarketplace_CheckBox.AutoSize = True
        FBMarketplaceOnMarketplace_CheckBox.Checked = True
        FBMarketplaceOnMarketplace_CheckBox.CheckState = CheckState.Checked
        FBMarketplaceOnMarketplace_CheckBox.Location = New Point(494, 172)
        FBMarketplaceOnMarketplace_CheckBox.Name = "FBMarketplaceOnMarketplace_CheckBox"
        FBMarketplaceOnMarketplace_CheckBox.Size = New Size(161, 23)
        FBMarketplaceOnMarketplace_CheckBox.TabIndex = 59
        FBMarketplaceOnMarketplace_CheckBox.Text = "新增到Marketplace"
        FBMarketplaceOnMarketplace_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceHomeDelivery_CheckBox
        ' 
        FBMarketplaceHomeDelivery_CheckBox.AutoSize = True
        FBMarketplaceHomeDelivery_CheckBox.Location = New Point(594, 141)
        FBMarketplaceHomeDelivery_CheckBox.Name = "FBMarketplaceHomeDelivery_CheckBox"
        FBMarketplaceHomeDelivery_CheckBox.Size = New Size(61, 23)
        FBMarketplaceHomeDelivery_CheckBox.TabIndex = 58
        FBMarketplaceHomeDelivery_CheckBox.Text = "送門"
        FBMarketplaceHomeDelivery_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplacePickUp_CheckBox
        ' 
        FBMarketplacePickUp_CheckBox.AutoSize = True
        FBMarketplacePickUp_CheckBox.Location = New Point(527, 141)
        FBMarketplacePickUp_CheckBox.Name = "FBMarketplacePickUp_CheckBox"
        FBMarketplacePickUp_CheckBox.Size = New Size(61, 23)
        FBMarketplacePickUp_CheckBox.TabIndex = 57
        FBMarketplacePickUp_CheckBox.Text = "取貨"
        FBMarketplacePickUp_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceMeetInPerson_CheckBox
        ' 
        FBMarketplaceMeetInPerson_CheckBox.AutoSize = True
        FBMarketplaceMeetInPerson_CheckBox.Location = New Point(460, 142)
        FBMarketplaceMeetInPerson_CheckBox.Name = "FBMarketplaceMeetInPerson_CheckBox"
        FBMarketplaceMeetInPerson_CheckBox.Size = New Size(61, 23)
        FBMarketplaceMeetInPerson_CheckBox.TabIndex = 56
        FBMarketplaceMeetInPerson_CheckBox.Text = "面交"
        FBMarketplaceMeetInPerson_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceProductTag_TextBox
        ' 
        FBMarketplaceProductTag_TextBox.Location = New Point(267, 105)
        FBMarketplaceProductTag_TextBox.Name = "FBMarketplaceProductTag_TextBox"
        FBMarketplaceProductTag_TextBox.Size = New Size(183, 27)
        FBMarketplaceProductTag_TextBox.TabIndex = 47
        ' 
        ' Label33
        ' 
        Label33.AutoSize = True
        Label33.Location = New Point(183, 113)
        Label33.Name = "Label33"
        Label33.Size = New Size(80, 19)
        Label33.TabIndex = 46
        Label33.Text = "商品標籤 : "
        ' 
        ' FBMarketplaceDeleteSelectedMedia_Button
        ' 
        FBMarketplaceDeleteSelectedMedia_Button.Location = New Point(339, 423)
        FBMarketplaceDeleteSelectedMedia_Button.Name = "FBMarketplaceDeleteSelectedMedia_Button"
        FBMarketplaceDeleteSelectedMedia_Button.Size = New Size(94, 29)
        FBMarketplaceDeleteSelectedMedia_Button.TabIndex = 45
        FBMarketplaceDeleteSelectedMedia_Button.Text = "刪除所選"
        FBMarketplaceDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceMediaPreviewer_PictureBox
        ' 
        FBMarketplaceMediaPreviewer_PictureBox.Location = New Point(437, 282)
        FBMarketplaceMediaPreviewer_PictureBox.Name = "FBMarketplaceMediaPreviewer_PictureBox"
        FBMarketplaceMediaPreviewer_PictureBox.Size = New Size(219, 172)
        FBMarketplaceMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBMarketplaceMediaPreviewer_PictureBox.TabIndex = 44
        FBMarketplaceMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBMarketplaceMediaSelector_ListBox
        ' 
        FBMarketplaceMediaSelector_ListBox.FormattingEnabled = True
        FBMarketplaceMediaSelector_ListBox.ItemHeight = 19
        FBMarketplaceMediaSelector_ListBox.Location = New Point(183, 281)
        FBMarketplaceMediaSelector_ListBox.Name = "FBMarketplaceMediaSelector_ListBox"
        FBMarketplaceMediaSelector_ListBox.Size = New Size(250, 137)
        FBMarketplaceMediaSelector_ListBox.TabIndex = 43
        ' 
        ' Label32
        ' 
        Label32.AutoSize = True
        Label32.Location = New Point(437, 258)
        Label32.Name = "Label32"
        Label32.Size = New Size(39, 19)
        Label32.TabIndex = 42
        Label32.Text = "預覽"
        ' 
        ' Label31
        ' 
        Label31.AutoSize = True
        Label31.Location = New Point(183, 258)
        Label31.Name = "Label31"
        Label31.Size = New Size(39, 19)
        Label31.TabIndex = 41
        Label31.Text = "媒體"
        ' 
        ' FBMarketplaceSavePruductInfo_Button
        ' 
        FBMarketplaceSavePruductInfo_Button.Location = New Point(183, 424)
        FBMarketplaceSavePruductInfo_Button.Name = "FBMarketplaceSavePruductInfo_Button"
        FBMarketplaceSavePruductInfo_Button.Size = New Size(94, 29)
        FBMarketplaceSavePruductInfo_Button.TabIndex = 40
        FBMarketplaceSavePruductInfo_Button.Text = "儲存商品"
        FBMarketplaceSavePruductInfo_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceProductDescription_RichTextBox
        ' 
        FBMarketplaceProductDescription_RichTextBox.Location = New Point(460, 39)
        FBMarketplaceProductDescription_RichTextBox.Name = "FBMarketplaceProductDescription_RichTextBox"
        FBMarketplaceProductDescription_RichTextBox.Size = New Size(196, 93)
        FBMarketplaceProductDescription_RichTextBox.TabIndex = 39
        FBMarketplaceProductDescription_RichTextBox.Text = ""
        FBMarketplaceProductDescription_RichTextBox.WordWrap = False
        ' 
        ' Label30
        ' 
        Label30.AutoSize = True
        Label30.Location = New Point(460, 9)
        Label30.Name = "Label30"
        Label30.Size = New Size(80, 19)
        Label30.TabIndex = 38
        Label30.Text = "商品介紹 : "
        ' 
        ' FBMarketplaceProductLocation_TextBox
        ' 
        FBMarketplaceProductLocation_TextBox.Location = New Point(267, 138)
        FBMarketplaceProductLocation_TextBox.Name = "FBMarketplaceProductLocation_TextBox"
        FBMarketplaceProductLocation_TextBox.Size = New Size(183, 27)
        FBMarketplaceProductLocation_TextBox.TabIndex = 37
        ' 
        ' FBMarketplaceProductStatus_NumericUpDown
        ' 
        FBMarketplaceProductStatus_NumericUpDown.FormattingEnabled = True
        FBMarketplaceProductStatus_NumericUpDown.Items.AddRange(New Object() {"全新", "二手 - 近全新", "二手 - 良好", "二手 - 普通"})
        FBMarketplaceProductStatus_NumericUpDown.Location = New Point(267, 72)
        FBMarketplaceProductStatus_NumericUpDown.Name = "FBMarketplaceProductStatus_NumericUpDown"
        FBMarketplaceProductStatus_NumericUpDown.Size = New Size(183, 27)
        FBMarketplaceProductStatus_NumericUpDown.TabIndex = 36
        ' 
        ' FBMarketplaceProductPrice_NumericUpDown
        ' 
        FBMarketplaceProductPrice_NumericUpDown.Location = New Point(267, 39)
        FBMarketplaceProductPrice_NumericUpDown.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        FBMarketplaceProductPrice_NumericUpDown.Name = "FBMarketplaceProductPrice_NumericUpDown"
        FBMarketplaceProductPrice_NumericUpDown.Size = New Size(183, 27)
        FBMarketplaceProductPrice_NumericUpDown.TabIndex = 35
        ' 
        ' FBMarketplaceProductName_TextBox
        ' 
        FBMarketplaceProductName_TextBox.Location = New Point(267, 6)
        FBMarketplaceProductName_TextBox.Name = "FBMarketplaceProductName_TextBox"
        FBMarketplaceProductName_TextBox.Size = New Size(183, 27)
        FBMarketplaceProductName_TextBox.TabIndex = 34
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.Location = New Point(212, 47)
        Label29.Name = "Label29"
        Label29.Size = New Size(50, 19)
        Label29.TabIndex = 33
        Label29.Text = "價格 : "
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.Location = New Point(212, 141)
        Label28.Name = "Label28"
        Label28.Size = New Size(50, 19)
        Label28.TabIndex = 32
        Label28.Text = "地點 : "
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Location = New Point(183, 80)
        Label27.Name = "Label27"
        Label27.Size = New Size(80, 19)
        Label27.TabIndex = 31
        Label27.Text = "商品狀態 : "
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Location = New Point(183, 14)
        Label26.Name = "Label26"
        Label26.Size = New Size(80, 19)
        Label26.TabIndex = 30
        Label26.Text = "商品名稱 : "
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(6, 364)
        Label8.Name = "Label8"
        Label8.Size = New Size(50, 19)
        Label8.TabIndex = 29
        Label8.Text = "名稱 : "
        ' 
        ' FBmarketplaceDeselectAllProductFolderListboxItems_Button
        ' 
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.Location = New Point(6, 326)
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.Name = "FBmarketplaceDeselectAllProductFolderListboxItems_Button"
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.Size = New Size(170, 29)
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.TabIndex = 28
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.Text = "取消選擇"
        FBmarketplaceDeselectAllProductFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarketplaceDeleteSelectedAssetFolder_Button
        ' 
        FBMarketplaceDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBMarketplaceDeleteSelectedAssetFolder_Button.Name = "FBMarketplaceDeleteSelectedAssetFolder_Button"
        FBMarketplaceDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBMarketplaceDeleteSelectedAssetFolder_Button.TabIndex = 27
        FBMarketplaceDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBMarketplaceDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' NewMarketplaceAssetFolderName_TextBox
        ' 
        NewMarketplaceAssetFolderName_TextBox.Location = New Point(62, 360)
        NewMarketplaceAssetFolderName_TextBox.Name = "NewMarketplaceAssetFolderName_TextBox"
        NewMarketplaceAssetFolderName_TextBox.Size = New Size(115, 27)
        NewMarketplaceAssetFolderName_TextBox.TabIndex = 26
        ' 
        ' CreateNewMarketplaceAssetFolder_Button
        ' 
        CreateNewMarketplaceAssetFolder_Button.Location = New Point(6, 393)
        CreateNewMarketplaceAssetFolder_Button.Name = "CreateNewMarketplaceAssetFolder_Button"
        CreateNewMarketplaceAssetFolder_Button.Size = New Size(170, 29)
        CreateNewMarketplaceAssetFolder_Button.TabIndex = 25
        CreateNewMarketplaceAssetFolder_Button.Text = "建立"
        CreateNewMarketplaceAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMarkplaceProducts_ListBox
        ' 
        FBMarkplaceProducts_ListBox.FormattingEnabled = True
        FBMarkplaceProducts_ListBox.ItemHeight = 19
        FBMarkplaceProducts_ListBox.Location = New Point(6, 8)
        FBMarkplaceProducts_ListBox.Name = "FBMarkplaceProducts_ListBox"
        FBMarkplaceProducts_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBMarkplaceProducts_ListBox.Size = New Size(170, 308)
        FBMarkplaceProducts_ListBox.TabIndex = 14
        ' 
        ' FBPostShareURLAssets_TabPage
        ' 
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLGetCurrentURL_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLNavigateToURL_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLDeleteSelectedTextFile_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLTextFileName_TextBox)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLTextFile_ListBox)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLSaveTextFile_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLCreateNewTextFile_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLTextFilePreviewer_RichTextBox)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLBaseURL_TextBox)
        FBPostShareURLAssets_TabPage.Controls.Add(Label40)
        FBPostShareURLAssets_TabPage.Controls.Add(Label38)
        FBPostShareURLAssets_TabPage.Controls.Add(Label39)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLUploadWaitSeconds_NumericUpDown)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLSubmitWaitSeconds_NumericUpDown)
        FBPostShareURLAssets_TabPage.Controls.Add(Label37)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLDeselectAllAssetFolderListboxItems_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLAssetFolder_ListBox)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLDeleteSelectedAssetFolder_Button)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLAssetFolderName_TextBox)
        FBPostShareURLAssets_TabPage.Controls.Add(FBPostShareURLCreateNewAssetFolder_Button)
        FBPostShareURLAssets_TabPage.Location = New Point(4, 28)
        FBPostShareURLAssets_TabPage.Name = "FBPostShareURLAssets_TabPage"
        FBPostShareURLAssets_TabPage.Size = New Size(664, 467)
        FBPostShareURLAssets_TabPage.TabIndex = 3
        FBPostShareURLAssets_TabPage.Text = "分享"
        FBPostShareURLAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLGetCurrentURL_Button
        ' 
        FBPostShareURLGetCurrentURL_Button.Location = New Point(338, 96)
        FBPostShareURLGetCurrentURL_Button.Name = "FBPostShareURLGetCurrentURL_Button"
        FBPostShareURLGetCurrentURL_Button.Size = New Size(94, 29)
        FBPostShareURLGetCurrentURL_Button.TabIndex = 44
        FBPostShareURLGetCurrentURL_Button.Text = "取得網址"
        FBPostShareURLGetCurrentURL_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLNavigateToURL_Button
        ' 
        FBPostShareURLNavigateToURL_Button.Location = New Point(238, 96)
        FBPostShareURLNavigateToURL_Button.Name = "FBPostShareURLNavigateToURL_Button"
        FBPostShareURLNavigateToURL_Button.Size = New Size(94, 29)
        FBPostShareURLNavigateToURL_Button.TabIndex = 43
        FBPostShareURLNavigateToURL_Button.Text = "前往"
        FBPostShareURLNavigateToURL_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLDeleteSelectedTextFile_Button
        ' 
        FBPostShareURLDeleteSelectedTextFile_Button.Location = New Point(435, 429)
        FBPostShareURLDeleteSelectedTextFile_Button.Name = "FBPostShareURLDeleteSelectedTextFile_Button"
        FBPostShareURLDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBPostShareURLDeleteSelectedTextFile_Button.TabIndex = 42
        FBPostShareURLDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBPostShareURLDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLTextFileName_TextBox
        ' 
        FBPostShareURLTextFileName_TextBox.Location = New Point(183, 429)
        FBPostShareURLTextFileName_TextBox.Name = "FBPostShareURLTextFileName_TextBox"
        FBPostShareURLTextFileName_TextBox.Size = New Size(145, 27)
        FBPostShareURLTextFileName_TextBox.TabIndex = 41
        ' 
        ' FBPostShareURLTextFile_ListBox
        ' 
        FBPostShareURLTextFile_ListBox.FormattingEnabled = True
        FBPostShareURLTextFile_ListBox.ItemHeight = 19
        FBPostShareURLTextFile_ListBox.Location = New Point(183, 153)
        FBPostShareURLTextFile_ListBox.Name = "FBPostShareURLTextFile_ListBox"
        FBPostShareURLTextFile_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBPostShareURLTextFile_ListBox.Size = New Size(145, 270)
        FBPostShareURLTextFile_ListBox.TabIndex = 40
        ' 
        ' FBPostShareURLSaveTextFile_Button
        ' 
        FBPostShareURLSaveTextFile_Button.Location = New Point(534, 429)
        FBPostShareURLSaveTextFile_Button.Name = "FBPostShareURLSaveTextFile_Button"
        FBPostShareURLSaveTextFile_Button.Size = New Size(94, 29)
        FBPostShareURLSaveTextFile_Button.TabIndex = 39
        FBPostShareURLSaveTextFile_Button.Text = "儲存"
        FBPostShareURLSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLCreateNewTextFile_Button
        ' 
        FBPostShareURLCreateNewTextFile_Button.Location = New Point(334, 429)
        FBPostShareURLCreateNewTextFile_Button.Name = "FBPostShareURLCreateNewTextFile_Button"
        FBPostShareURLCreateNewTextFile_Button.Size = New Size(94, 29)
        FBPostShareURLCreateNewTextFile_Button.TabIndex = 38
        FBPostShareURLCreateNewTextFile_Button.Text = "新增文字檔"
        FBPostShareURLCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLTextFilePreviewer_RichTextBox
        ' 
        FBPostShareURLTextFilePreviewer_RichTextBox.Location = New Point(334, 153)
        FBPostShareURLTextFilePreviewer_RichTextBox.Name = "FBPostShareURLTextFilePreviewer_RichTextBox"
        FBPostShareURLTextFilePreviewer_RichTextBox.Size = New Size(325, 270)
        FBPostShareURLTextFilePreviewer_RichTextBox.TabIndex = 37
        FBPostShareURLTextFilePreviewer_RichTextBox.Text = ""
        FBPostShareURLTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBPostShareURLBaseURL_TextBox
        ' 
        FBPostShareURLBaseURL_TextBox.Location = New Point(238, 63)
        FBPostShareURLBaseURL_TextBox.Name = "FBPostShareURLBaseURL_TextBox"
        FBPostShareURLBaseURL_TextBox.Size = New Size(421, 27)
        FBPostShareURLBaseURL_TextBox.TabIndex = 36
        ' 
        ' Label40
        ' 
        Label40.AutoSize = True
        Label40.Location = New Point(183, 70)
        Label40.Name = "Label40"
        Label40.Size = New Size(50, 19)
        Label40.TabIndex = 35
        Label40.Text = "網址 : "
        ' 
        ' Label38
        ' 
        Label38.AutoSize = True
        Label38.Location = New Point(334, 13)
        Label38.Name = "Label38"
        Label38.Size = New Size(80, 19)
        Label38.TabIndex = 34
        Label38.Text = "送出等待 : "
        ' 
        ' Label39
        ' 
        Label39.AutoSize = True
        Label39.Location = New Point(183, 13)
        Label39.Name = "Label39"
        Label39.Size = New Size(80, 19)
        Label39.TabIndex = 33
        Label39.Text = "上載等待 : "
        ' 
        ' FBPostShareURLUploadWaitSeconds_NumericUpDown
        ' 
        FBPostShareURLUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBPostShareURLUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBPostShareURLUploadWaitSeconds_NumericUpDown.Name = "FBPostShareURLUploadWaitSeconds_NumericUpDown"
        FBPostShareURLUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBPostShareURLUploadWaitSeconds_NumericUpDown.TabIndex = 32
        ' 
        ' FBPostShareURLSubmitWaitSeconds_NumericUpDown
        ' 
        FBPostShareURLSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBPostShareURLSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBPostShareURLSubmitWaitSeconds_NumericUpDown.Name = "FBPostShareURLSubmitWaitSeconds_NumericUpDown"
        FBPostShareURLSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBPostShareURLSubmitWaitSeconds_NumericUpDown.TabIndex = 31
        ' 
        ' Label37
        ' 
        Label37.AutoSize = True
        Label37.Location = New Point(6, 364)
        Label37.Name = "Label37"
        Label37.Size = New Size(50, 19)
        Label37.TabIndex = 30
        Label37.Text = "名稱 : "
        ' 
        ' FBPostShareURLDeselectAllAssetFolderListboxItems_Button
        ' 
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.Name = "FBPostShareURLDeselectAllAssetFolderListboxItems_Button"
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.TabIndex = 29
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBPostShareURLDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLAssetFolder_ListBox
        ' 
        FBPostShareURLAssetFolder_ListBox.FormattingEnabled = True
        FBPostShareURLAssetFolder_ListBox.ItemHeight = 19
        FBPostShareURLAssetFolder_ListBox.Location = New Point(6, 8)
        FBPostShareURLAssetFolder_ListBox.Name = "FBPostShareURLAssetFolder_ListBox"
        FBPostShareURLAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBPostShareURLAssetFolder_ListBox.Size = New Size(170, 308)
        FBPostShareURLAssetFolder_ListBox.TabIndex = 28
        ' 
        ' FBPostShareURLDeleteSelectedAssetFolder_Button
        ' 
        FBPostShareURLDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBPostShareURLDeleteSelectedAssetFolder_Button.Name = "FBPostShareURLDeleteSelectedAssetFolder_Button"
        FBPostShareURLDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBPostShareURLDeleteSelectedAssetFolder_Button.TabIndex = 27
        FBPostShareURLDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBPostShareURLDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPostShareURLAssetFolderName_TextBox
        ' 
        FBPostShareURLAssetFolderName_TextBox.Location = New Point(62, 360)
        FBPostShareURLAssetFolderName_TextBox.Name = "FBPostShareURLAssetFolderName_TextBox"
        FBPostShareURLAssetFolderName_TextBox.Size = New Size(115, 27)
        FBPostShareURLAssetFolderName_TextBox.TabIndex = 26
        ' 
        ' FBPostShareURLCreateNewAssetFolder_Button
        ' 
        FBPostShareURLCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBPostShareURLCreateNewAssetFolder_Button.Name = "FBPostShareURLCreateNewAssetFolder_Button"
        FBPostShareURLCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBPostShareURLCreateNewAssetFolder_Button.TabIndex = 25
        FBPostShareURLCreateNewAssetFolder_Button.Text = "建立"
        FBPostShareURLCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentAssets_TabPage
        ' 
        FBCommentAssets_TabPage.Controls.Add(Label41)
        FBCommentAssets_TabPage.Controls.Add(Label42)
        FBCommentAssets_TabPage.Controls.Add(Label43)
        FBCommentAssets_TabPage.Controls.Add(FBCommentUploadWaitSeconds_NumericUpDown)
        FBCommentAssets_TabPage.Controls.Add(FBCommentSubmitWaitSeconds_NumericUpDown)
        FBCommentAssets_TabPage.Controls.Add(FBCommentDeselectAllAssetFolderListboxItems_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentDeleteSelectedTextFile_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentNewTextFileName_TextBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentMediaSelector_ListBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentTextFileSelector_ListBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentAssetFolder_ListBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentSaveTextFile_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentCreateNewTextFile_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentDeleteSelectedMedia_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentRevealMediaFoldesrInFileExplorer_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentDeleteSelectedAssetFolder_Button)
        FBCommentAssets_TabPage.Controls.Add(FBCommentAssetFolderName_TextBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentMediaPreviewer_PictureBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentTextFilePreviewer_RichTextBox)
        FBCommentAssets_TabPage.Controls.Add(FBCommentCreateNewAssetFolder_Button)
        FBCommentAssets_TabPage.Location = New Point(4, 28)
        FBCommentAssets_TabPage.Name = "FBCommentAssets_TabPage"
        FBCommentAssets_TabPage.Size = New Size(664, 467)
        FBCommentAssets_TabPage.TabIndex = 4
        FBCommentAssets_TabPage.Text = "留言"
        FBCommentAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label41
        ' 
        Label41.AutoSize = True
        Label41.Location = New Point(6, 364)
        Label41.Name = "Label41"
        Label41.Size = New Size(50, 19)
        Label41.TabIndex = 44
        Label41.Text = "名稱 : "
        ' 
        ' Label42
        ' 
        Label42.AutoSize = True
        Label42.Location = New Point(334, 13)
        Label42.Name = "Label42"
        Label42.Size = New Size(80, 19)
        Label42.TabIndex = 43
        Label42.Text = "送出等待 : "
        ' 
        ' Label43
        ' 
        Label43.AutoSize = True
        Label43.Location = New Point(183, 13)
        Label43.Name = "Label43"
        Label43.Size = New Size(80, 19)
        Label43.TabIndex = 42
        Label43.Text = "上載等待 : "
        ' 
        ' FBCommentUploadWaitSeconds_NumericUpDown
        ' 
        FBCommentUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBCommentUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBCommentUploadWaitSeconds_NumericUpDown.Name = "FBCommentUploadWaitSeconds_NumericUpDown"
        FBCommentUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBCommentUploadWaitSeconds_NumericUpDown.TabIndex = 41
        ' 
        ' FBCommentSubmitWaitSeconds_NumericUpDown
        ' 
        FBCommentSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBCommentSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBCommentSubmitWaitSeconds_NumericUpDown.Name = "FBCommentSubmitWaitSeconds_NumericUpDown"
        FBCommentSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBCommentSubmitWaitSeconds_NumericUpDown.TabIndex = 40
        ' 
        ' FBCommentDeselectAllAssetFolderListboxItems_Button
        ' 
        FBCommentDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBCommentDeselectAllAssetFolderListboxItems_Button.Name = "FBCommentDeselectAllAssetFolderListboxItems_Button"
        FBCommentDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBCommentDeselectAllAssetFolderListboxItems_Button.TabIndex = 39
        FBCommentDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBCommentDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentDeleteSelectedTextFile_Button
        ' 
        FBCommentDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBCommentDeleteSelectedTextFile_Button.Name = "FBCommentDeleteSelectedTextFile_Button"
        FBCommentDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBCommentDeleteSelectedTextFile_Button.TabIndex = 38
        FBCommentDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBCommentDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentNewTextFileName_TextBox
        ' 
        FBCommentNewTextFileName_TextBox.Location = New Point(183, 189)
        FBCommentNewTextFileName_TextBox.Name = "FBCommentNewTextFileName_TextBox"
        FBCommentNewTextFileName_TextBox.Size = New Size(145, 27)
        FBCommentNewTextFileName_TextBox.TabIndex = 37
        ' 
        ' FBCommentMediaSelector_ListBox
        ' 
        FBCommentMediaSelector_ListBox.FormattingEnabled = True
        FBCommentMediaSelector_ListBox.ItemHeight = 19
        FBCommentMediaSelector_ListBox.Location = New Point(183, 224)
        FBCommentMediaSelector_ListBox.Name = "FBCommentMediaSelector_ListBox"
        FBCommentMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCommentMediaSelector_ListBox.Size = New Size(145, 156)
        FBCommentMediaSelector_ListBox.TabIndex = 36
        ' 
        ' FBCommentTextFileSelector_ListBox
        ' 
        FBCommentTextFileSelector_ListBox.FormattingEnabled = True
        FBCommentTextFileSelector_ListBox.ItemHeight = 19
        FBCommentTextFileSelector_ListBox.Location = New Point(183, 46)
        FBCommentTextFileSelector_ListBox.Name = "FBCommentTextFileSelector_ListBox"
        FBCommentTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCommentTextFileSelector_ListBox.Size = New Size(145, 137)
        FBCommentTextFileSelector_ListBox.TabIndex = 35
        ' 
        ' FBCommentAssetFolder_ListBox
        ' 
        FBCommentAssetFolder_ListBox.FormattingEnabled = True
        FBCommentAssetFolder_ListBox.ItemHeight = 19
        FBCommentAssetFolder_ListBox.Location = New Point(6, 8)
        FBCommentAssetFolder_ListBox.Name = "FBCommentAssetFolder_ListBox"
        FBCommentAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCommentAssetFolder_ListBox.Size = New Size(170, 308)
        FBCommentAssetFolder_ListBox.TabIndex = 34
        ' 
        ' FBCommentSaveTextFile_Button
        ' 
        FBCommentSaveTextFile_Button.Location = New Point(534, 189)
        FBCommentSaveTextFile_Button.Name = "FBCommentSaveTextFile_Button"
        FBCommentSaveTextFile_Button.Size = New Size(94, 29)
        FBCommentSaveTextFile_Button.TabIndex = 33
        FBCommentSaveTextFile_Button.Text = "儲存"
        FBCommentSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentCreateNewTextFile_Button
        ' 
        FBCommentCreateNewTextFile_Button.Location = New Point(334, 189)
        FBCommentCreateNewTextFile_Button.Name = "FBCommentCreateNewTextFile_Button"
        FBCommentCreateNewTextFile_Button.Size = New Size(94, 29)
        FBCommentCreateNewTextFile_Button.TabIndex = 32
        FBCommentCreateNewTextFile_Button.Text = "新增文字檔"
        FBCommentCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentDeleteSelectedMedia_Button
        ' 
        FBCommentDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBCommentDeleteSelectedMedia_Button.Name = "FBCommentDeleteSelectedMedia_Button"
        FBCommentDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBCommentDeleteSelectedMedia_Button.TabIndex = 31
        FBCommentDeleteSelectedMedia_Button.Text = "刪除所選"
        FBCommentDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBCommentRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBCommentRevealMediaFoldesrInFileExplorer_Button.Name = "FBCommentRevealMediaFoldesrInFileExplorer_Button"
        FBCommentRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBCommentRevealMediaFoldesrInFileExplorer_Button.TabIndex = 30
        FBCommentRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBCommentRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentDeleteSelectedAssetFolder_Button
        ' 
        FBCommentDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBCommentDeleteSelectedAssetFolder_Button.Name = "FBCommentDeleteSelectedAssetFolder_Button"
        FBCommentDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBCommentDeleteSelectedAssetFolder_Button.TabIndex = 29
        FBCommentDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBCommentDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCommentAssetFolderName_TextBox
        ' 
        FBCommentAssetFolderName_TextBox.Location = New Point(62, 360)
        FBCommentAssetFolderName_TextBox.Name = "FBCommentAssetFolderName_TextBox"
        FBCommentAssetFolderName_TextBox.Size = New Size(115, 27)
        FBCommentAssetFolderName_TextBox.TabIndex = 28
        ' 
        ' FBCommentMediaPreviewer_PictureBox
        ' 
        FBCommentMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBCommentMediaPreviewer_PictureBox.Name = "FBCommentMediaPreviewer_PictureBox"
        FBCommentMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBCommentMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBCommentMediaPreviewer_PictureBox.TabIndex = 27
        FBCommentMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBCommentTextFilePreviewer_RichTextBox
        ' 
        FBCommentTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBCommentTextFilePreviewer_RichTextBox.Name = "FBCommentTextFilePreviewer_RichTextBox"
        FBCommentTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBCommentTextFilePreviewer_RichTextBox.TabIndex = 26
        FBCommentTextFilePreviewer_RichTextBox.Text = ""
        FBCommentTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBCommentCreateNewAssetFolder_Button
        ' 
        FBCommentCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBCommentCreateNewAssetFolder_Button.Name = "FBCommentCreateNewAssetFolder_Button"
        FBCommentCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBCommentCreateNewAssetFolder_Button.TabIndex = 25
        FBCommentCreateNewAssetFolder_Button.Text = "建立"
        FBCommentCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentAssets_TabPage
        ' 
        FBCustomizeCommentAssets_TabPage.Controls.Add(Label47)
        FBCustomizeCommentAssets_TabPage.Controls.Add(Label48)
        FBCustomizeCommentAssets_TabPage.Controls.Add(Label49)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentUploadWaitSeconds_NumericUpDown)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentSubmitWaitSeconds_NumericUpDown)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentDeleteSelectedTextFile_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentNewTextFileName_TextBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentMediaSelector_ListBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentTextFileSelector_ListBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentAssetFolder_ListBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentSaveTextFile_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentCreateNewTextFile_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentDeleteSelectedMedia_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentDeleteSelectedAssetFolder_Button)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentAssetFolderName_TextBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentMediaPreviewer_PictureBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentTextFilePreviewer_RichTextBox)
        FBCustomizeCommentAssets_TabPage.Controls.Add(FBCustomizeCommentCreateNewAssetFolder_Button)
        FBCustomizeCommentAssets_TabPage.Location = New Point(4, 28)
        FBCustomizeCommentAssets_TabPage.Name = "FBCustomizeCommentAssets_TabPage"
        FBCustomizeCommentAssets_TabPage.Size = New Size(664, 467)
        FBCustomizeCommentAssets_TabPage.TabIndex = 5
        FBCustomizeCommentAssets_TabPage.Text = "自訂"
        FBCustomizeCommentAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label47
        ' 
        Label47.AutoSize = True
        Label47.Location = New Point(6, 364)
        Label47.Name = "Label47"
        Label47.Size = New Size(50, 19)
        Label47.TabIndex = 64
        Label47.Text = "名稱 : "
        ' 
        ' Label48
        ' 
        Label48.AutoSize = True
        Label48.Location = New Point(334, 13)
        Label48.Name = "Label48"
        Label48.Size = New Size(80, 19)
        Label48.TabIndex = 63
        Label48.Text = "送出等待 : "
        ' 
        ' Label49
        ' 
        Label49.AutoSize = True
        Label49.Location = New Point(183, 13)
        Label49.Name = "Label49"
        Label49.Size = New Size(80, 19)
        Label49.TabIndex = 62
        Label49.Text = "上載等待 : "
        ' 
        ' FBCustomizeCommentUploadWaitSeconds_NumericUpDown
        ' 
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown.Name = "FBCustomizeCommentUploadWaitSeconds_NumericUpDown"
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBCustomizeCommentUploadWaitSeconds_NumericUpDown.TabIndex = 61
        ' 
        ' FBCustomizeCommentSubmitWaitSeconds_NumericUpDown
        ' 
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown.Name = "FBCustomizeCommentSubmitWaitSeconds_NumericUpDown"
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBCustomizeCommentSubmitWaitSeconds_NumericUpDown.TabIndex = 60
        ' 
        ' FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button
        ' 
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.Name = "FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button"
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.TabIndex = 59
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentDeleteSelectedTextFile_Button
        ' 
        FBCustomizeCommentDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBCustomizeCommentDeleteSelectedTextFile_Button.Name = "FBCustomizeCommentDeleteSelectedTextFile_Button"
        FBCustomizeCommentDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBCustomizeCommentDeleteSelectedTextFile_Button.TabIndex = 58
        FBCustomizeCommentDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBCustomizeCommentDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentNewTextFileName_TextBox
        ' 
        FBCustomizeCommentNewTextFileName_TextBox.Location = New Point(183, 189)
        FBCustomizeCommentNewTextFileName_TextBox.Name = "FBCustomizeCommentNewTextFileName_TextBox"
        FBCustomizeCommentNewTextFileName_TextBox.Size = New Size(145, 27)
        FBCustomizeCommentNewTextFileName_TextBox.TabIndex = 57
        ' 
        ' FBCustomizeCommentMediaSelector_ListBox
        ' 
        FBCustomizeCommentMediaSelector_ListBox.FormattingEnabled = True
        FBCustomizeCommentMediaSelector_ListBox.ItemHeight = 19
        FBCustomizeCommentMediaSelector_ListBox.Location = New Point(183, 224)
        FBCustomizeCommentMediaSelector_ListBox.Name = "FBCustomizeCommentMediaSelector_ListBox"
        FBCustomizeCommentMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCustomizeCommentMediaSelector_ListBox.Size = New Size(145, 156)
        FBCustomizeCommentMediaSelector_ListBox.TabIndex = 56
        ' 
        ' FBCustomizeCommentTextFileSelector_ListBox
        ' 
        FBCustomizeCommentTextFileSelector_ListBox.FormattingEnabled = True
        FBCustomizeCommentTextFileSelector_ListBox.ItemHeight = 19
        FBCustomizeCommentTextFileSelector_ListBox.Location = New Point(183, 46)
        FBCustomizeCommentTextFileSelector_ListBox.Name = "FBCustomizeCommentTextFileSelector_ListBox"
        FBCustomizeCommentTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCustomizeCommentTextFileSelector_ListBox.Size = New Size(145, 137)
        FBCustomizeCommentTextFileSelector_ListBox.TabIndex = 55
        ' 
        ' FBCustomizeCommentAssetFolder_ListBox
        ' 
        FBCustomizeCommentAssetFolder_ListBox.FormattingEnabled = True
        FBCustomizeCommentAssetFolder_ListBox.ItemHeight = 19
        FBCustomizeCommentAssetFolder_ListBox.Location = New Point(6, 8)
        FBCustomizeCommentAssetFolder_ListBox.Name = "FBCustomizeCommentAssetFolder_ListBox"
        FBCustomizeCommentAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBCustomizeCommentAssetFolder_ListBox.Size = New Size(170, 308)
        FBCustomizeCommentAssetFolder_ListBox.TabIndex = 54
        ' 
        ' FBCustomizeCommentSaveTextFile_Button
        ' 
        FBCustomizeCommentSaveTextFile_Button.Location = New Point(534, 189)
        FBCustomizeCommentSaveTextFile_Button.Name = "FBCustomizeCommentSaveTextFile_Button"
        FBCustomizeCommentSaveTextFile_Button.Size = New Size(94, 29)
        FBCustomizeCommentSaveTextFile_Button.TabIndex = 53
        FBCustomizeCommentSaveTextFile_Button.Text = "儲存"
        FBCustomizeCommentSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentCreateNewTextFile_Button
        ' 
        FBCustomizeCommentCreateNewTextFile_Button.Location = New Point(334, 189)
        FBCustomizeCommentCreateNewTextFile_Button.Name = "FBCustomizeCommentCreateNewTextFile_Button"
        FBCustomizeCommentCreateNewTextFile_Button.Size = New Size(94, 29)
        FBCustomizeCommentCreateNewTextFile_Button.TabIndex = 52
        FBCustomizeCommentCreateNewTextFile_Button.Text = "新增文字檔"
        FBCustomizeCommentCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentDeleteSelectedMedia_Button
        ' 
        FBCustomizeCommentDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBCustomizeCommentDeleteSelectedMedia_Button.Name = "FBCustomizeCommentDeleteSelectedMedia_Button"
        FBCustomizeCommentDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBCustomizeCommentDeleteSelectedMedia_Button.TabIndex = 51
        FBCustomizeCommentDeleteSelectedMedia_Button.Text = "刪除所選"
        FBCustomizeCommentDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.Name = "FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button"
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.TabIndex = 50
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentDeleteSelectedAssetFolder_Button
        ' 
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.Name = "FBCustomizeCommentDeleteSelectedAssetFolder_Button"
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.TabIndex = 49
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBCustomizeCommentDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBCustomizeCommentAssetFolderName_TextBox
        ' 
        FBCustomizeCommentAssetFolderName_TextBox.Location = New Point(62, 360)
        FBCustomizeCommentAssetFolderName_TextBox.Name = "FBCustomizeCommentAssetFolderName_TextBox"
        FBCustomizeCommentAssetFolderName_TextBox.Size = New Size(115, 27)
        FBCustomizeCommentAssetFolderName_TextBox.TabIndex = 48
        ' 
        ' FBCustomizeCommentMediaPreviewer_PictureBox
        ' 
        FBCustomizeCommentMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBCustomizeCommentMediaPreviewer_PictureBox.Name = "FBCustomizeCommentMediaPreviewer_PictureBox"
        FBCustomizeCommentMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBCustomizeCommentMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBCustomizeCommentMediaPreviewer_PictureBox.TabIndex = 47
        FBCustomizeCommentMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBCustomizeCommentTextFilePreviewer_RichTextBox
        ' 
        FBCustomizeCommentTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBCustomizeCommentTextFilePreviewer_RichTextBox.Name = "FBCustomizeCommentTextFilePreviewer_RichTextBox"
        FBCustomizeCommentTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBCustomizeCommentTextFilePreviewer_RichTextBox.TabIndex = 46
        FBCustomizeCommentTextFilePreviewer_RichTextBox.Text = ""
        FBCustomizeCommentTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBCustomizeCommentCreateNewAssetFolder_Button
        ' 
        FBCustomizeCommentCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBCustomizeCommentCreateNewAssetFolder_Button.Name = "FBCustomizeCommentCreateNewAssetFolder_Button"
        FBCustomizeCommentCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBCustomizeCommentCreateNewAssetFolder_Button.TabIndex = 45
        FBCustomizeCommentCreateNewAssetFolder_Button.Text = "建立"
        FBCustomizeCommentCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBRespondNotificationsAssets_TabPage
        ' 
        FBRespondNotificationsAssets_TabPage.Controls.Add(Label52)
        FBRespondNotificationsAssets_TabPage.Controls.Add(Label53)
        FBRespondNotificationsAssets_TabPage.Controls.Add(Label54)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseUploadWaitSeconds_NumericUpDown)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseSubmitWaitSeconds_NumericUpDown)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseDeselectAllAssetFolderListboxItems_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseDeleteSelectedTextFile_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseNewTextFileName_TextBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseMediaSelector_ListBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseTextFileSelector_ListBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseAssetFolder_ListBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseSaveTextFile_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseCreateNewTextFile_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseDeleteSelectedMedia_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseRevealMediaFoldesrInFileExplorer_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseDeleteSelectedAssetFolder_Button)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseAssetFolderName_TextBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseMediaPreviewer_PictureBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseTextFilePreviewer_RichTextBox)
        FBRespondNotificationsAssets_TabPage.Controls.Add(FBResponseCreateNewAssetFolder_Button)
        FBRespondNotificationsAssets_TabPage.Location = New Point(4, 28)
        FBRespondNotificationsAssets_TabPage.Name = "FBRespondNotificationsAssets_TabPage"
        FBRespondNotificationsAssets_TabPage.Size = New Size(664, 467)
        FBRespondNotificationsAssets_TabPage.TabIndex = 6
        FBRespondNotificationsAssets_TabPage.Text = "回應"
        FBRespondNotificationsAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label52
        ' 
        Label52.AutoSize = True
        Label52.Location = New Point(6, 364)
        Label52.Name = "Label52"
        Label52.Size = New Size(50, 19)
        Label52.TabIndex = 84
        Label52.Text = "名稱 : "
        ' 
        ' Label53
        ' 
        Label53.AutoSize = True
        Label53.Location = New Point(334, 13)
        Label53.Name = "Label53"
        Label53.Size = New Size(80, 19)
        Label53.TabIndex = 83
        Label53.Text = "送出等待 : "
        ' 
        ' Label54
        ' 
        Label54.AutoSize = True
        Label54.Location = New Point(183, 13)
        Label54.Name = "Label54"
        Label54.Size = New Size(80, 19)
        Label54.TabIndex = 82
        Label54.Text = "上載等待 : "
        ' 
        ' FBResponseUploadWaitSeconds_NumericUpDown
        ' 
        FBResponseUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBResponseUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBResponseUploadWaitSeconds_NumericUpDown.Name = "FBResponseUploadWaitSeconds_NumericUpDown"
        FBResponseUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBResponseUploadWaitSeconds_NumericUpDown.TabIndex = 81
        ' 
        ' FBResponseSubmitWaitSeconds_NumericUpDown
        ' 
        FBResponseSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBResponseSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBResponseSubmitWaitSeconds_NumericUpDown.Name = "FBResponseSubmitWaitSeconds_NumericUpDown"
        FBResponseSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBResponseSubmitWaitSeconds_NumericUpDown.TabIndex = 80
        ' 
        ' FBResponseDeselectAllAssetFolderListboxItems_Button
        ' 
        FBResponseDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBResponseDeselectAllAssetFolderListboxItems_Button.Name = "FBResponseDeselectAllAssetFolderListboxItems_Button"
        FBResponseDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBResponseDeselectAllAssetFolderListboxItems_Button.TabIndex = 79
        FBResponseDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBResponseDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseDeleteSelectedTextFile_Button
        ' 
        FBResponseDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBResponseDeleteSelectedTextFile_Button.Name = "FBResponseDeleteSelectedTextFile_Button"
        FBResponseDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBResponseDeleteSelectedTextFile_Button.TabIndex = 78
        FBResponseDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBResponseDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseNewTextFileName_TextBox
        ' 
        FBResponseNewTextFileName_TextBox.Location = New Point(183, 189)
        FBResponseNewTextFileName_TextBox.Name = "FBResponseNewTextFileName_TextBox"
        FBResponseNewTextFileName_TextBox.Size = New Size(145, 27)
        FBResponseNewTextFileName_TextBox.TabIndex = 77
        ' 
        ' FBResponseMediaSelector_ListBox
        ' 
        FBResponseMediaSelector_ListBox.FormattingEnabled = True
        FBResponseMediaSelector_ListBox.ItemHeight = 19
        FBResponseMediaSelector_ListBox.Location = New Point(183, 224)
        FBResponseMediaSelector_ListBox.Name = "FBResponseMediaSelector_ListBox"
        FBResponseMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBResponseMediaSelector_ListBox.Size = New Size(145, 156)
        FBResponseMediaSelector_ListBox.TabIndex = 76
        ' 
        ' FBResponseTextFileSelector_ListBox
        ' 
        FBResponseTextFileSelector_ListBox.FormattingEnabled = True
        FBResponseTextFileSelector_ListBox.ItemHeight = 19
        FBResponseTextFileSelector_ListBox.Location = New Point(183, 46)
        FBResponseTextFileSelector_ListBox.Name = "FBResponseTextFileSelector_ListBox"
        FBResponseTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBResponseTextFileSelector_ListBox.Size = New Size(145, 137)
        FBResponseTextFileSelector_ListBox.TabIndex = 75
        ' 
        ' FBResponseAssetFolder_ListBox
        ' 
        FBResponseAssetFolder_ListBox.FormattingEnabled = True
        FBResponseAssetFolder_ListBox.ItemHeight = 19
        FBResponseAssetFolder_ListBox.Location = New Point(6, 8)
        FBResponseAssetFolder_ListBox.Name = "FBResponseAssetFolder_ListBox"
        FBResponseAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBResponseAssetFolder_ListBox.Size = New Size(170, 308)
        FBResponseAssetFolder_ListBox.TabIndex = 74
        ' 
        ' FBResponseSaveTextFile_Button
        ' 
        FBResponseSaveTextFile_Button.Location = New Point(534, 189)
        FBResponseSaveTextFile_Button.Name = "FBResponseSaveTextFile_Button"
        FBResponseSaveTextFile_Button.Size = New Size(94, 29)
        FBResponseSaveTextFile_Button.TabIndex = 73
        FBResponseSaveTextFile_Button.Text = "儲存"
        FBResponseSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseCreateNewTextFile_Button
        ' 
        FBResponseCreateNewTextFile_Button.Location = New Point(334, 189)
        FBResponseCreateNewTextFile_Button.Name = "FBResponseCreateNewTextFile_Button"
        FBResponseCreateNewTextFile_Button.Size = New Size(94, 29)
        FBResponseCreateNewTextFile_Button.TabIndex = 72
        FBResponseCreateNewTextFile_Button.Text = "新增文字檔"
        FBResponseCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseDeleteSelectedMedia_Button
        ' 
        FBResponseDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBResponseDeleteSelectedMedia_Button.Name = "FBResponseDeleteSelectedMedia_Button"
        FBResponseDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBResponseDeleteSelectedMedia_Button.TabIndex = 71
        FBResponseDeleteSelectedMedia_Button.Text = "刪除所選"
        FBResponseDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBResponseRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBResponseRevealMediaFoldesrInFileExplorer_Button.Name = "FBResponseRevealMediaFoldesrInFileExplorer_Button"
        FBResponseRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBResponseRevealMediaFoldesrInFileExplorer_Button.TabIndex = 70
        FBResponseRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBResponseRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseDeleteSelectedAssetFolder_Button
        ' 
        FBResponseDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBResponseDeleteSelectedAssetFolder_Button.Name = "FBResponseDeleteSelectedAssetFolder_Button"
        FBResponseDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBResponseDeleteSelectedAssetFolder_Button.TabIndex = 69
        FBResponseDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBResponseDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBResponseAssetFolderName_TextBox
        ' 
        FBResponseAssetFolderName_TextBox.Location = New Point(62, 360)
        FBResponseAssetFolderName_TextBox.Name = "FBResponseAssetFolderName_TextBox"
        FBResponseAssetFolderName_TextBox.Size = New Size(115, 27)
        FBResponseAssetFolderName_TextBox.TabIndex = 68
        ' 
        ' FBResponseMediaPreviewer_PictureBox
        ' 
        FBResponseMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBResponseMediaPreviewer_PictureBox.Name = "FBResponseMediaPreviewer_PictureBox"
        FBResponseMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBResponseMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBResponseMediaPreviewer_PictureBox.TabIndex = 67
        FBResponseMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBResponseTextFilePreviewer_RichTextBox
        ' 
        FBResponseTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBResponseTextFilePreviewer_RichTextBox.Name = "FBResponseTextFilePreviewer_RichTextBox"
        FBResponseTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBResponseTextFilePreviewer_RichTextBox.TabIndex = 66
        FBResponseTextFilePreviewer_RichTextBox.Text = ""
        FBResponseTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBResponseCreateNewAssetFolder_Button
        ' 
        FBResponseCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBResponseCreateNewAssetFolder_Button.Name = "FBResponseCreateNewAssetFolder_Button"
        FBResponseCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBResponseCreateNewAssetFolder_Button.TabIndex = 65
        FBResponseCreateNewAssetFolder_Button.Text = "建立"
        FBResponseCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerAssets_TabPage
        ' 
        FBMessengerAssets_TabPage.Controls.Add(Label58)
        FBMessengerAssets_TabPage.Controls.Add(Label59)
        FBMessengerAssets_TabPage.Controls.Add(Label60)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerUploadWaitSeconds_NumericUpDown)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerSubmitWaitSeconds_NumericUpDown)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerDeselectAllAssetFolderListboxItems_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerDeleteSelectedTextFile_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerNewTextFileName_TextBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerMediaSelector_ListBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerTextFileSelector_ListBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerAssetFolder_ListBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerSaveTextFile_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerCreateNewTextFile_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerDeleteSelectedMedia_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerRevealMediaFoldesrInFileExplorer_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerDeleteSelectedAssetFolder_Button)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerAssetFolderName_TextBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerMediaPreviewer_PictureBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerTextFilePreviewer_RichTextBox)
        FBMessengerAssets_TabPage.Controls.Add(FBMessengerCreateNewAssetFolder_Button)
        FBMessengerAssets_TabPage.Location = New Point(4, 28)
        FBMessengerAssets_TabPage.Name = "FBMessengerAssets_TabPage"
        FBMessengerAssets_TabPage.Padding = New Padding(3)
        FBMessengerAssets_TabPage.Size = New Size(664, 467)
        FBMessengerAssets_TabPage.TabIndex = 1
        FBMessengerAssets_TabPage.Text = "訊息"
        FBMessengerAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label58
        ' 
        Label58.AutoSize = True
        Label58.Location = New Point(6, 364)
        Label58.Name = "Label58"
        Label58.Size = New Size(50, 19)
        Label58.TabIndex = 104
        Label58.Text = "名稱 : "
        ' 
        ' Label59
        ' 
        Label59.AutoSize = True
        Label59.Location = New Point(334, 13)
        Label59.Name = "Label59"
        Label59.Size = New Size(80, 19)
        Label59.TabIndex = 103
        Label59.Text = "送出等待 : "
        ' 
        ' Label60
        ' 
        Label60.AutoSize = True
        Label60.Location = New Point(183, 13)
        Label60.Name = "Label60"
        Label60.Size = New Size(80, 19)
        Label60.TabIndex = 102
        Label60.Text = "上載等待 : "
        ' 
        ' FBMessengerUploadWaitSeconds_NumericUpDown
        ' 
        FBMessengerUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBMessengerUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBMessengerUploadWaitSeconds_NumericUpDown.Name = "FBMessengerUploadWaitSeconds_NumericUpDown"
        FBMessengerUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBMessengerUploadWaitSeconds_NumericUpDown.TabIndex = 101
        ' 
        ' FBMessengerSubmitWaitSeconds_NumericUpDown
        ' 
        FBMessengerSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBMessengerSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBMessengerSubmitWaitSeconds_NumericUpDown.Name = "FBMessengerSubmitWaitSeconds_NumericUpDown"
        FBMessengerSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBMessengerSubmitWaitSeconds_NumericUpDown.TabIndex = 100
        ' 
        ' FBMessengerDeselectAllAssetFolderListboxItems_Button
        ' 
        FBMessengerDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBMessengerDeselectAllAssetFolderListboxItems_Button.Name = "FBMessengerDeselectAllAssetFolderListboxItems_Button"
        FBMessengerDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBMessengerDeselectAllAssetFolderListboxItems_Button.TabIndex = 99
        FBMessengerDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBMessengerDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerDeleteSelectedTextFile_Button
        ' 
        FBMessengerDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBMessengerDeleteSelectedTextFile_Button.Name = "FBMessengerDeleteSelectedTextFile_Button"
        FBMessengerDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBMessengerDeleteSelectedTextFile_Button.TabIndex = 98
        FBMessengerDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBMessengerDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerNewTextFileName_TextBox
        ' 
        FBMessengerNewTextFileName_TextBox.Location = New Point(183, 189)
        FBMessengerNewTextFileName_TextBox.Name = "FBMessengerNewTextFileName_TextBox"
        FBMessengerNewTextFileName_TextBox.Size = New Size(145, 27)
        FBMessengerNewTextFileName_TextBox.TabIndex = 97
        ' 
        ' FBMessengerMediaSelector_ListBox
        ' 
        FBMessengerMediaSelector_ListBox.FormattingEnabled = True
        FBMessengerMediaSelector_ListBox.ItemHeight = 19
        FBMessengerMediaSelector_ListBox.Location = New Point(183, 224)
        FBMessengerMediaSelector_ListBox.Name = "FBMessengerMediaSelector_ListBox"
        FBMessengerMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBMessengerMediaSelector_ListBox.Size = New Size(145, 156)
        FBMessengerMediaSelector_ListBox.TabIndex = 96
        ' 
        ' FBMessengerTextFileSelector_ListBox
        ' 
        FBMessengerTextFileSelector_ListBox.FormattingEnabled = True
        FBMessengerTextFileSelector_ListBox.ItemHeight = 19
        FBMessengerTextFileSelector_ListBox.Location = New Point(183, 46)
        FBMessengerTextFileSelector_ListBox.Name = "FBMessengerTextFileSelector_ListBox"
        FBMessengerTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBMessengerTextFileSelector_ListBox.Size = New Size(145, 137)
        FBMessengerTextFileSelector_ListBox.TabIndex = 95
        ' 
        ' FBMessengerAssetFolder_ListBox
        ' 
        FBMessengerAssetFolder_ListBox.FormattingEnabled = True
        FBMessengerAssetFolder_ListBox.ItemHeight = 19
        FBMessengerAssetFolder_ListBox.Location = New Point(6, 8)
        FBMessengerAssetFolder_ListBox.Name = "FBMessengerAssetFolder_ListBox"
        FBMessengerAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBMessengerAssetFolder_ListBox.Size = New Size(170, 308)
        FBMessengerAssetFolder_ListBox.TabIndex = 94
        ' 
        ' FBMessengerSaveTextFile_Button
        ' 
        FBMessengerSaveTextFile_Button.Location = New Point(534, 189)
        FBMessengerSaveTextFile_Button.Name = "FBMessengerSaveTextFile_Button"
        FBMessengerSaveTextFile_Button.Size = New Size(94, 29)
        FBMessengerSaveTextFile_Button.TabIndex = 93
        FBMessengerSaveTextFile_Button.Text = "儲存"
        FBMessengerSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerCreateNewTextFile_Button
        ' 
        FBMessengerCreateNewTextFile_Button.Location = New Point(334, 189)
        FBMessengerCreateNewTextFile_Button.Name = "FBMessengerCreateNewTextFile_Button"
        FBMessengerCreateNewTextFile_Button.Size = New Size(94, 29)
        FBMessengerCreateNewTextFile_Button.TabIndex = 92
        FBMessengerCreateNewTextFile_Button.Text = "新增文字檔"
        FBMessengerCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerDeleteSelectedMedia_Button
        ' 
        FBMessengerDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBMessengerDeleteSelectedMedia_Button.Name = "FBMessengerDeleteSelectedMedia_Button"
        FBMessengerDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBMessengerDeleteSelectedMedia_Button.TabIndex = 91
        FBMessengerDeleteSelectedMedia_Button.Text = "刪除所選"
        FBMessengerDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.Name = "FBMessengerRevealMediaFoldesrInFileExplorer_Button"
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.TabIndex = 90
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBMessengerRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerDeleteSelectedAssetFolder_Button
        ' 
        FBMessengerDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBMessengerDeleteSelectedAssetFolder_Button.Name = "FBMessengerDeleteSelectedAssetFolder_Button"
        FBMessengerDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBMessengerDeleteSelectedAssetFolder_Button.TabIndex = 89
        FBMessengerDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBMessengerDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBMessengerAssetFolderName_TextBox
        ' 
        FBMessengerAssetFolderName_TextBox.Location = New Point(62, 360)
        FBMessengerAssetFolderName_TextBox.Name = "FBMessengerAssetFolderName_TextBox"
        FBMessengerAssetFolderName_TextBox.Size = New Size(115, 27)
        FBMessengerAssetFolderName_TextBox.TabIndex = 88
        ' 
        ' FBMessengerMediaPreviewer_PictureBox
        ' 
        FBMessengerMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBMessengerMediaPreviewer_PictureBox.Name = "FBMessengerMediaPreviewer_PictureBox"
        FBMessengerMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBMessengerMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBMessengerMediaPreviewer_PictureBox.TabIndex = 87
        FBMessengerMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBMessengerTextFilePreviewer_RichTextBox
        ' 
        FBMessengerTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBMessengerTextFilePreviewer_RichTextBox.Name = "FBMessengerTextFilePreviewer_RichTextBox"
        FBMessengerTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBMessengerTextFilePreviewer_RichTextBox.TabIndex = 86
        FBMessengerTextFilePreviewer_RichTextBox.Text = ""
        FBMessengerTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBMessengerCreateNewAssetFolder_Button
        ' 
        FBMessengerCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBMessengerCreateNewAssetFolder_Button.Name = "FBMessengerCreateNewAssetFolder_Button"
        FBMessengerCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBMessengerCreateNewAssetFolder_Button.TabIndex = 85
        FBMessengerCreateNewAssetFolder_Button.Text = "建立"
        FBMessengerCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryAssets_TabPage
        ' 
        FBStoryAssets_TabPage.Controls.Add(Label61)
        FBStoryAssets_TabPage.Controls.Add(Label62)
        FBStoryAssets_TabPage.Controls.Add(Label63)
        FBStoryAssets_TabPage.Controls.Add(FBStoryUploadWaitSeconds_NumericUpDown)
        FBStoryAssets_TabPage.Controls.Add(FBStorySubmitWaitSeconds_NumericUpDown)
        FBStoryAssets_TabPage.Controls.Add(FBStoryDeselectAllAssetFolderListboxItems_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryDeleteSelectedTextFile_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryNewTextFileName_TextBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryMediaSelector_ListBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryTextFileSelector_ListBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryAssetFolder_ListBox)
        FBStoryAssets_TabPage.Controls.Add(FBStorySaveTextFile_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryCreateNewTextFile_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryDeleteSelectedMedia_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryRevealMediaFoldesrInFileExplorer_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryDeleteSelectedAssetFolder_Button)
        FBStoryAssets_TabPage.Controls.Add(FBStoryAssetFolderName_TextBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryMediaPreviewer_PictureBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryTextFilePreviewer_RichTextBox)
        FBStoryAssets_TabPage.Controls.Add(FBStoryCreateNewAssetFolder_Button)
        FBStoryAssets_TabPage.Location = New Point(4, 28)
        FBStoryAssets_TabPage.Name = "FBStoryAssets_TabPage"
        FBStoryAssets_TabPage.Size = New Size(664, 467)
        FBStoryAssets_TabPage.TabIndex = 7
        FBStoryAssets_TabPage.Text = "限時"
        FBStoryAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label61
        ' 
        Label61.AutoSize = True
        Label61.Location = New Point(6, 364)
        Label61.Name = "Label61"
        Label61.Size = New Size(50, 19)
        Label61.TabIndex = 124
        Label61.Text = "名稱 : "
        ' 
        ' Label62
        ' 
        Label62.AutoSize = True
        Label62.Location = New Point(334, 13)
        Label62.Name = "Label62"
        Label62.Size = New Size(80, 19)
        Label62.TabIndex = 123
        Label62.Text = "送出等待 : "
        ' 
        ' Label63
        ' 
        Label63.AutoSize = True
        Label63.Location = New Point(183, 13)
        Label63.Name = "Label63"
        Label63.Size = New Size(80, 19)
        Label63.TabIndex = 122
        Label63.Text = "上載等待 : "
        ' 
        ' FBStoryUploadWaitSeconds_NumericUpDown
        ' 
        FBStoryUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBStoryUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBStoryUploadWaitSeconds_NumericUpDown.Name = "FBStoryUploadWaitSeconds_NumericUpDown"
        FBStoryUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBStoryUploadWaitSeconds_NumericUpDown.TabIndex = 121
        ' 
        ' FBStorySubmitWaitSeconds_NumericUpDown
        ' 
        FBStorySubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBStorySubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBStorySubmitWaitSeconds_NumericUpDown.Name = "FBStorySubmitWaitSeconds_NumericUpDown"
        FBStorySubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBStorySubmitWaitSeconds_NumericUpDown.TabIndex = 120
        ' 
        ' FBStoryDeselectAllAssetFolderListboxItems_Button
        ' 
        FBStoryDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBStoryDeselectAllAssetFolderListboxItems_Button.Name = "FBStoryDeselectAllAssetFolderListboxItems_Button"
        FBStoryDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBStoryDeselectAllAssetFolderListboxItems_Button.TabIndex = 119
        FBStoryDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBStoryDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryDeleteSelectedTextFile_Button
        ' 
        FBStoryDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBStoryDeleteSelectedTextFile_Button.Name = "FBStoryDeleteSelectedTextFile_Button"
        FBStoryDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBStoryDeleteSelectedTextFile_Button.TabIndex = 118
        FBStoryDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBStoryDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryNewTextFileName_TextBox
        ' 
        FBStoryNewTextFileName_TextBox.Location = New Point(183, 189)
        FBStoryNewTextFileName_TextBox.Name = "FBStoryNewTextFileName_TextBox"
        FBStoryNewTextFileName_TextBox.Size = New Size(145, 27)
        FBStoryNewTextFileName_TextBox.TabIndex = 117
        ' 
        ' FBStoryMediaSelector_ListBox
        ' 
        FBStoryMediaSelector_ListBox.FormattingEnabled = True
        FBStoryMediaSelector_ListBox.ItemHeight = 19
        FBStoryMediaSelector_ListBox.Location = New Point(183, 224)
        FBStoryMediaSelector_ListBox.Name = "FBStoryMediaSelector_ListBox"
        FBStoryMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBStoryMediaSelector_ListBox.Size = New Size(145, 156)
        FBStoryMediaSelector_ListBox.TabIndex = 116
        ' 
        ' FBStoryTextFileSelector_ListBox
        ' 
        FBStoryTextFileSelector_ListBox.FormattingEnabled = True
        FBStoryTextFileSelector_ListBox.ItemHeight = 19
        FBStoryTextFileSelector_ListBox.Location = New Point(183, 46)
        FBStoryTextFileSelector_ListBox.Name = "FBStoryTextFileSelector_ListBox"
        FBStoryTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBStoryTextFileSelector_ListBox.Size = New Size(145, 137)
        FBStoryTextFileSelector_ListBox.TabIndex = 115
        ' 
        ' FBStoryAssetFolder_ListBox
        ' 
        FBStoryAssetFolder_ListBox.FormattingEnabled = True
        FBStoryAssetFolder_ListBox.ItemHeight = 19
        FBStoryAssetFolder_ListBox.Location = New Point(6, 8)
        FBStoryAssetFolder_ListBox.Name = "FBStoryAssetFolder_ListBox"
        FBStoryAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBStoryAssetFolder_ListBox.Size = New Size(170, 308)
        FBStoryAssetFolder_ListBox.TabIndex = 114
        ' 
        ' FBStorySaveTextFile_Button
        ' 
        FBStorySaveTextFile_Button.Location = New Point(534, 189)
        FBStorySaveTextFile_Button.Name = "FBStorySaveTextFile_Button"
        FBStorySaveTextFile_Button.Size = New Size(94, 29)
        FBStorySaveTextFile_Button.TabIndex = 113
        FBStorySaveTextFile_Button.Text = "儲存"
        FBStorySaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryCreateNewTextFile_Button
        ' 
        FBStoryCreateNewTextFile_Button.Location = New Point(334, 189)
        FBStoryCreateNewTextFile_Button.Name = "FBStoryCreateNewTextFile_Button"
        FBStoryCreateNewTextFile_Button.Size = New Size(94, 29)
        FBStoryCreateNewTextFile_Button.TabIndex = 112
        FBStoryCreateNewTextFile_Button.Text = "新增文字檔"
        FBStoryCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryDeleteSelectedMedia_Button
        ' 
        FBStoryDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBStoryDeleteSelectedMedia_Button.Name = "FBStoryDeleteSelectedMedia_Button"
        FBStoryDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBStoryDeleteSelectedMedia_Button.TabIndex = 111
        FBStoryDeleteSelectedMedia_Button.Text = "刪除所選"
        FBStoryDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBStoryRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBStoryRevealMediaFoldesrInFileExplorer_Button.Name = "FBStoryRevealMediaFoldesrInFileExplorer_Button"
        FBStoryRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBStoryRevealMediaFoldesrInFileExplorer_Button.TabIndex = 110
        FBStoryRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBStoryRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryDeleteSelectedAssetFolder_Button
        ' 
        FBStoryDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBStoryDeleteSelectedAssetFolder_Button.Name = "FBStoryDeleteSelectedAssetFolder_Button"
        FBStoryDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBStoryDeleteSelectedAssetFolder_Button.TabIndex = 109
        FBStoryDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBStoryDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBStoryAssetFolderName_TextBox
        ' 
        FBStoryAssetFolderName_TextBox.Location = New Point(62, 360)
        FBStoryAssetFolderName_TextBox.Name = "FBStoryAssetFolderName_TextBox"
        FBStoryAssetFolderName_TextBox.Size = New Size(115, 27)
        FBStoryAssetFolderName_TextBox.TabIndex = 108
        ' 
        ' FBStoryMediaPreviewer_PictureBox
        ' 
        FBStoryMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBStoryMediaPreviewer_PictureBox.Name = "FBStoryMediaPreviewer_PictureBox"
        FBStoryMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBStoryMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBStoryMediaPreviewer_PictureBox.TabIndex = 107
        FBStoryMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBStoryTextFilePreviewer_RichTextBox
        ' 
        FBStoryTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBStoryTextFilePreviewer_RichTextBox.Name = "FBStoryTextFilePreviewer_RichTextBox"
        FBStoryTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBStoryTextFilePreviewer_RichTextBox.TabIndex = 106
        FBStoryTextFilePreviewer_RichTextBox.Text = ""
        FBStoryTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBStoryCreateNewAssetFolder_Button
        ' 
        FBStoryCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBStoryCreateNewAssetFolder_Button.Name = "FBStoryCreateNewAssetFolder_Button"
        FBStoryCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBStoryCreateNewAssetFolder_Button.TabIndex = 105
        FBStoryCreateNewAssetFolder_Button.Text = "建立"
        FBStoryCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostAssets_TabPage
        ' 
        FBPersonalPostAssets_TabPage.Controls.Add(SingleMediaAllowed_CheckBox)
        FBPersonalPostAssets_TabPage.Controls.Add(Label64)
        FBPersonalPostAssets_TabPage.Controls.Add(Label65)
        FBPersonalPostAssets_TabPage.Controls.Add(Label66)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostUploadWaitSeconds_NumericUpDown)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostSubmitWaitSeconds_NumericUpDown)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostDeselectAllAssetFolderListboxItems_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostDeleteSelectedTextFile_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostNewTextFileName_TextBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostMediaSelector_ListBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostTextFileSelector_ListBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostAssetFolder_ListBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostSaveTextFile_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostCreateNewTextFile_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostDeleteSelectedMedia_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostRevealMediaFoldesrInFileExplorer_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostDeleteSelectedAssetFolder_Button)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostAssetFolderName_TextBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostMediaPreviewer_PictureBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostTextFilePreviewer_RichTextBox)
        FBPersonalPostAssets_TabPage.Controls.Add(FBPersonalPostCreateNewAssetFolder_Button)
        FBPersonalPostAssets_TabPage.Location = New Point(4, 28)
        FBPersonalPostAssets_TabPage.Name = "FBPersonalPostAssets_TabPage"
        FBPersonalPostAssets_TabPage.Size = New Size(664, 467)
        FBPersonalPostAssets_TabPage.TabIndex = 8
        FBPersonalPostAssets_TabPage.Text = "個人發帖"
        FBPersonalPostAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' SingleMediaAllowed_CheckBox
        ' 
        SingleMediaAllowed_CheckBox.AutoSize = True
        SingleMediaAllowed_CheckBox.Location = New Point(534, 13)
        SingleMediaAllowed_CheckBox.Name = "SingleMediaAllowed_CheckBox"
        SingleMediaAllowed_CheckBox.Size = New Size(121, 23)
        SingleMediaAllowed_CheckBox.TabIndex = 145
        SingleMediaAllowed_CheckBox.Text = "只發單一圖像"
        SingleMediaAllowed_CheckBox.UseVisualStyleBackColor = True
        ' 
        ' Label64
        ' 
        Label64.AutoSize = True
        Label64.Location = New Point(6, 364)
        Label64.Name = "Label64"
        Label64.Size = New Size(50, 19)
        Label64.TabIndex = 144
        Label64.Text = "名稱 : "
        ' 
        ' Label65
        ' 
        Label65.AutoSize = True
        Label65.Location = New Point(334, 13)
        Label65.Name = "Label65"
        Label65.Size = New Size(80, 19)
        Label65.TabIndex = 143
        Label65.Text = "送出等待 : "
        ' 
        ' Label66
        ' 
        Label66.AutoSize = True
        Label66.Location = New Point(183, 13)
        Label66.Name = "Label66"
        Label66.Size = New Size(80, 19)
        Label66.TabIndex = 142
        Label66.Text = "上載等待 : "
        ' 
        ' FBPersonalPostUploadWaitSeconds_NumericUpDown
        ' 
        FBPersonalPostUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBPersonalPostUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBPersonalPostUploadWaitSeconds_NumericUpDown.Name = "FBPersonalPostUploadWaitSeconds_NumericUpDown"
        FBPersonalPostUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBPersonalPostUploadWaitSeconds_NumericUpDown.TabIndex = 141
        ' 
        ' FBPersonalPostSubmitWaitSeconds_NumericUpDown
        ' 
        FBPersonalPostSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBPersonalPostSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBPersonalPostSubmitWaitSeconds_NumericUpDown.Name = "FBPersonalPostSubmitWaitSeconds_NumericUpDown"
        FBPersonalPostSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBPersonalPostSubmitWaitSeconds_NumericUpDown.TabIndex = 140
        ' 
        ' FBPersonalPostDeselectAllAssetFolderListboxItems_Button
        ' 
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.Name = "FBPersonalPostDeselectAllAssetFolderListboxItems_Button"
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.TabIndex = 139
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBPersonalPostDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostDeleteSelectedTextFile_Button
        ' 
        FBPersonalPostDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBPersonalPostDeleteSelectedTextFile_Button.Name = "FBPersonalPostDeleteSelectedTextFile_Button"
        FBPersonalPostDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBPersonalPostDeleteSelectedTextFile_Button.TabIndex = 138
        FBPersonalPostDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBPersonalPostDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostNewTextFileName_TextBox
        ' 
        FBPersonalPostNewTextFileName_TextBox.Location = New Point(183, 189)
        FBPersonalPostNewTextFileName_TextBox.Name = "FBPersonalPostNewTextFileName_TextBox"
        FBPersonalPostNewTextFileName_TextBox.Size = New Size(145, 27)
        FBPersonalPostNewTextFileName_TextBox.TabIndex = 137
        ' 
        ' FBPersonalPostMediaSelector_ListBox
        ' 
        FBPersonalPostMediaSelector_ListBox.FormattingEnabled = True
        FBPersonalPostMediaSelector_ListBox.ItemHeight = 19
        FBPersonalPostMediaSelector_ListBox.Location = New Point(183, 224)
        FBPersonalPostMediaSelector_ListBox.Name = "FBPersonalPostMediaSelector_ListBox"
        FBPersonalPostMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBPersonalPostMediaSelector_ListBox.Size = New Size(145, 156)
        FBPersonalPostMediaSelector_ListBox.TabIndex = 136
        ' 
        ' FBPersonalPostTextFileSelector_ListBox
        ' 
        FBPersonalPostTextFileSelector_ListBox.FormattingEnabled = True
        FBPersonalPostTextFileSelector_ListBox.ItemHeight = 19
        FBPersonalPostTextFileSelector_ListBox.Location = New Point(183, 46)
        FBPersonalPostTextFileSelector_ListBox.Name = "FBPersonalPostTextFileSelector_ListBox"
        FBPersonalPostTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBPersonalPostTextFileSelector_ListBox.Size = New Size(145, 137)
        FBPersonalPostTextFileSelector_ListBox.TabIndex = 135
        ' 
        ' FBPersonalPostAssetFolder_ListBox
        ' 
        FBPersonalPostAssetFolder_ListBox.FormattingEnabled = True
        FBPersonalPostAssetFolder_ListBox.ItemHeight = 19
        FBPersonalPostAssetFolder_ListBox.Location = New Point(6, 8)
        FBPersonalPostAssetFolder_ListBox.Name = "FBPersonalPostAssetFolder_ListBox"
        FBPersonalPostAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBPersonalPostAssetFolder_ListBox.Size = New Size(170, 308)
        FBPersonalPostAssetFolder_ListBox.TabIndex = 134
        ' 
        ' FBPersonalPostSaveTextFile_Button
        ' 
        FBPersonalPostSaveTextFile_Button.Location = New Point(534, 189)
        FBPersonalPostSaveTextFile_Button.Name = "FBPersonalPostSaveTextFile_Button"
        FBPersonalPostSaveTextFile_Button.Size = New Size(94, 29)
        FBPersonalPostSaveTextFile_Button.TabIndex = 133
        FBPersonalPostSaveTextFile_Button.Text = "儲存"
        FBPersonalPostSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostCreateNewTextFile_Button
        ' 
        FBPersonalPostCreateNewTextFile_Button.Location = New Point(334, 189)
        FBPersonalPostCreateNewTextFile_Button.Name = "FBPersonalPostCreateNewTextFile_Button"
        FBPersonalPostCreateNewTextFile_Button.Size = New Size(94, 29)
        FBPersonalPostCreateNewTextFile_Button.TabIndex = 132
        FBPersonalPostCreateNewTextFile_Button.Text = "新增文字檔"
        FBPersonalPostCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostDeleteSelectedMedia_Button
        ' 
        FBPersonalPostDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBPersonalPostDeleteSelectedMedia_Button.Name = "FBPersonalPostDeleteSelectedMedia_Button"
        FBPersonalPostDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBPersonalPostDeleteSelectedMedia_Button.TabIndex = 131
        FBPersonalPostDeleteSelectedMedia_Button.Text = "刪除所選"
        FBPersonalPostDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.Name = "FBPersonalPostRevealMediaFoldesrInFileExplorer_Button"
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.TabIndex = 130
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBPersonalPostRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostDeleteSelectedAssetFolder_Button
        ' 
        FBPersonalPostDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBPersonalPostDeleteSelectedAssetFolder_Button.Name = "FBPersonalPostDeleteSelectedAssetFolder_Button"
        FBPersonalPostDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBPersonalPostDeleteSelectedAssetFolder_Button.TabIndex = 129
        FBPersonalPostDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBPersonalPostDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBPersonalPostAssetFolderName_TextBox
        ' 
        FBPersonalPostAssetFolderName_TextBox.Location = New Point(62, 360)
        FBPersonalPostAssetFolderName_TextBox.Name = "FBPersonalPostAssetFolderName_TextBox"
        FBPersonalPostAssetFolderName_TextBox.Size = New Size(115, 27)
        FBPersonalPostAssetFolderName_TextBox.TabIndex = 128
        ' 
        ' FBPersonalPostMediaPreviewer_PictureBox
        ' 
        FBPersonalPostMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBPersonalPostMediaPreviewer_PictureBox.Name = "FBPersonalPostMediaPreviewer_PictureBox"
        FBPersonalPostMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBPersonalPostMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBPersonalPostMediaPreviewer_PictureBox.TabIndex = 127
        FBPersonalPostMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBPersonalPostTextFilePreviewer_RichTextBox
        ' 
        FBPersonalPostTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBPersonalPostTextFilePreviewer_RichTextBox.Name = "FBPersonalPostTextFilePreviewer_RichTextBox"
        FBPersonalPostTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBPersonalPostTextFilePreviewer_RichTextBox.TabIndex = 126
        FBPersonalPostTextFilePreviewer_RichTextBox.Text = ""
        FBPersonalPostTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBPersonalPostCreateNewAssetFolder_Button
        ' 
        FBPersonalPostCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBPersonalPostCreateNewAssetFolder_Button.Name = "FBPersonalPostCreateNewAssetFolder_Button"
        FBPersonalPostCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBPersonalPostCreateNewAssetFolder_Button.TabIndex = 125
        FBPersonalPostCreateNewAssetFolder_Button.Text = "建立"
        FBPersonalPostCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsAssets_TabPage
        ' 
        FBReelsAssets_TabPage.Controls.Add(Label67)
        FBReelsAssets_TabPage.Controls.Add(Label68)
        FBReelsAssets_TabPage.Controls.Add(Label69)
        FBReelsAssets_TabPage.Controls.Add(FBReelsUploadWaitSeconds_NumericUpDown)
        FBReelsAssets_TabPage.Controls.Add(FBReelsSubmitWaitSeconds_NumericUpDown)
        FBReelsAssets_TabPage.Controls.Add(FBReelsDeselectAllAssetFolderListboxItems_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsDeleteSelectedTextFile_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsNewTextFileName_TextBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsMediaSelector_ListBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsTextFileSelector_ListBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsAssetFolder_ListBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsSaveTextFile_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsCreateNewTextFile_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsDeleteSelectedMedia_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsRevealMediaFoldesrInFileExplorer_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsDeleteSelectedAssetFolder_Button)
        FBReelsAssets_TabPage.Controls.Add(FBReelsAssetFolderName_TextBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsMediaPreviewer_PictureBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsTextFilePreviewer_RichTextBox)
        FBReelsAssets_TabPage.Controls.Add(FBReelsCreateNewAssetFolder_Button)
        FBReelsAssets_TabPage.Location = New Point(4, 28)
        FBReelsAssets_TabPage.Name = "FBReelsAssets_TabPage"
        FBReelsAssets_TabPage.Size = New Size(664, 467)
        FBReelsAssets_TabPage.TabIndex = 9
        FBReelsAssets_TabPage.Text = "連續短片"
        FBReelsAssets_TabPage.UseVisualStyleBackColor = True
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Location = New Point(6, 364)
        Label67.Name = "Label67"
        Label67.Size = New Size(50, 19)
        Label67.TabIndex = 164
        Label67.Text = "名稱 : "
        ' 
        ' Label68
        ' 
        Label68.AutoSize = True
        Label68.Location = New Point(334, 13)
        Label68.Name = "Label68"
        Label68.Size = New Size(80, 19)
        Label68.TabIndex = 163
        Label68.Text = "送出等待 : "
        ' 
        ' Label69
        ' 
        Label69.AutoSize = True
        Label69.Location = New Point(183, 13)
        Label69.Name = "Label69"
        Label69.Size = New Size(80, 19)
        Label69.TabIndex = 162
        Label69.Text = "上載等待 : "
        ' 
        ' FBReelsUploadWaitSeconds_NumericUpDown
        ' 
        FBReelsUploadWaitSeconds_NumericUpDown.Location = New Point(267, 10)
        FBReelsUploadWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBReelsUploadWaitSeconds_NumericUpDown.Name = "FBReelsUploadWaitSeconds_NumericUpDown"
        FBReelsUploadWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBReelsUploadWaitSeconds_NumericUpDown.TabIndex = 161
        ' 
        ' FBReelsSubmitWaitSeconds_NumericUpDown
        ' 
        FBReelsSubmitWaitSeconds_NumericUpDown.Location = New Point(420, 10)
        FBReelsSubmitWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        FBReelsSubmitWaitSeconds_NumericUpDown.Name = "FBReelsSubmitWaitSeconds_NumericUpDown"
        FBReelsSubmitWaitSeconds_NumericUpDown.Size = New Size(60, 27)
        FBReelsSubmitWaitSeconds_NumericUpDown.TabIndex = 160
        ' 
        ' FBReelsDeselectAllAssetFolderListboxItems_Button
        ' 
        FBReelsDeselectAllAssetFolderListboxItems_Button.Location = New Point(6, 326)
        FBReelsDeselectAllAssetFolderListboxItems_Button.Name = "FBReelsDeselectAllAssetFolderListboxItems_Button"
        FBReelsDeselectAllAssetFolderListboxItems_Button.Size = New Size(170, 29)
        FBReelsDeselectAllAssetFolderListboxItems_Button.TabIndex = 159
        FBReelsDeselectAllAssetFolderListboxItems_Button.Text = "取消選擇"
        FBReelsDeselectAllAssetFolderListboxItems_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsDeleteSelectedTextFile_Button
        ' 
        FBReelsDeleteSelectedTextFile_Button.Location = New Point(435, 189)
        FBReelsDeleteSelectedTextFile_Button.Name = "FBReelsDeleteSelectedTextFile_Button"
        FBReelsDeleteSelectedTextFile_Button.Size = New Size(94, 29)
        FBReelsDeleteSelectedTextFile_Button.TabIndex = 158
        FBReelsDeleteSelectedTextFile_Button.Text = "刪除所選"
        FBReelsDeleteSelectedTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsNewTextFileName_TextBox
        ' 
        FBReelsNewTextFileName_TextBox.Location = New Point(183, 189)
        FBReelsNewTextFileName_TextBox.Name = "FBReelsNewTextFileName_TextBox"
        FBReelsNewTextFileName_TextBox.Size = New Size(145, 27)
        FBReelsNewTextFileName_TextBox.TabIndex = 157
        ' 
        ' FBReelsMediaSelector_ListBox
        ' 
        FBReelsMediaSelector_ListBox.FormattingEnabled = True
        FBReelsMediaSelector_ListBox.ItemHeight = 19
        FBReelsMediaSelector_ListBox.Location = New Point(183, 224)
        FBReelsMediaSelector_ListBox.Name = "FBReelsMediaSelector_ListBox"
        FBReelsMediaSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBReelsMediaSelector_ListBox.Size = New Size(145, 156)
        FBReelsMediaSelector_ListBox.TabIndex = 156
        ' 
        ' FBReelsTextFileSelector_ListBox
        ' 
        FBReelsTextFileSelector_ListBox.FormattingEnabled = True
        FBReelsTextFileSelector_ListBox.ItemHeight = 19
        FBReelsTextFileSelector_ListBox.Location = New Point(183, 46)
        FBReelsTextFileSelector_ListBox.Name = "FBReelsTextFileSelector_ListBox"
        FBReelsTextFileSelector_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBReelsTextFileSelector_ListBox.Size = New Size(145, 137)
        FBReelsTextFileSelector_ListBox.TabIndex = 155
        ' 
        ' FBReelsAssetFolder_ListBox
        ' 
        FBReelsAssetFolder_ListBox.FormattingEnabled = True
        FBReelsAssetFolder_ListBox.ItemHeight = 19
        FBReelsAssetFolder_ListBox.Location = New Point(6, 8)
        FBReelsAssetFolder_ListBox.Name = "FBReelsAssetFolder_ListBox"
        FBReelsAssetFolder_ListBox.SelectionMode = SelectionMode.MultiExtended
        FBReelsAssetFolder_ListBox.Size = New Size(170, 308)
        FBReelsAssetFolder_ListBox.TabIndex = 154
        ' 
        ' FBReelsSaveTextFile_Button
        ' 
        FBReelsSaveTextFile_Button.Location = New Point(534, 189)
        FBReelsSaveTextFile_Button.Name = "FBReelsSaveTextFile_Button"
        FBReelsSaveTextFile_Button.Size = New Size(94, 29)
        FBReelsSaveTextFile_Button.TabIndex = 153
        FBReelsSaveTextFile_Button.Text = "儲存"
        FBReelsSaveTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsCreateNewTextFile_Button
        ' 
        FBReelsCreateNewTextFile_Button.Location = New Point(334, 189)
        FBReelsCreateNewTextFile_Button.Name = "FBReelsCreateNewTextFile_Button"
        FBReelsCreateNewTextFile_Button.Size = New Size(94, 29)
        FBReelsCreateNewTextFile_Button.TabIndex = 152
        FBReelsCreateNewTextFile_Button.Text = "新增文字檔"
        FBReelsCreateNewTextFile_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsDeleteSelectedMedia_Button
        ' 
        FBReelsDeleteSelectedMedia_Button.Location = New Point(183, 429)
        FBReelsDeleteSelectedMedia_Button.Name = "FBReelsDeleteSelectedMedia_Button"
        FBReelsDeleteSelectedMedia_Button.Size = New Size(147, 29)
        FBReelsDeleteSelectedMedia_Button.TabIndex = 151
        FBReelsDeleteSelectedMedia_Button.Text = "刪除所選"
        FBReelsDeleteSelectedMedia_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsRevealMediaFoldesrInFileExplorer_Button
        ' 
        FBReelsRevealMediaFoldesrInFileExplorer_Button.Location = New Point(183, 393)
        FBReelsRevealMediaFoldesrInFileExplorer_Button.Name = "FBReelsRevealMediaFoldesrInFileExplorer_Button"
        FBReelsRevealMediaFoldesrInFileExplorer_Button.Size = New Size(147, 29)
        FBReelsRevealMediaFoldesrInFileExplorer_Button.TabIndex = 150
        FBReelsRevealMediaFoldesrInFileExplorer_Button.Text = "開啟資料夾"
        FBReelsRevealMediaFoldesrInFileExplorer_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsDeleteSelectedAssetFolder_Button
        ' 
        FBReelsDeleteSelectedAssetFolder_Button.Location = New Point(6, 429)
        FBReelsDeleteSelectedAssetFolder_Button.Name = "FBReelsDeleteSelectedAssetFolder_Button"
        FBReelsDeleteSelectedAssetFolder_Button.Size = New Size(170, 29)
        FBReelsDeleteSelectedAssetFolder_Button.TabIndex = 149
        FBReelsDeleteSelectedAssetFolder_Button.Text = "刪除所選"
        FBReelsDeleteSelectedAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' FBReelsAssetFolderName_TextBox
        ' 
        FBReelsAssetFolderName_TextBox.Location = New Point(62, 360)
        FBReelsAssetFolderName_TextBox.Name = "FBReelsAssetFolderName_TextBox"
        FBReelsAssetFolderName_TextBox.Size = New Size(115, 27)
        FBReelsAssetFolderName_TextBox.TabIndex = 148
        ' 
        ' FBReelsMediaPreviewer_PictureBox
        ' 
        FBReelsMediaPreviewer_PictureBox.Location = New Point(334, 224)
        FBReelsMediaPreviewer_PictureBox.Name = "FBReelsMediaPreviewer_PictureBox"
        FBReelsMediaPreviewer_PictureBox.Size = New Size(325, 234)
        FBReelsMediaPreviewer_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
        FBReelsMediaPreviewer_PictureBox.TabIndex = 147
        FBReelsMediaPreviewer_PictureBox.TabStop = False
        ' 
        ' FBReelsTextFilePreviewer_RichTextBox
        ' 
        FBReelsTextFilePreviewer_RichTextBox.Location = New Point(334, 44)
        FBReelsTextFilePreviewer_RichTextBox.Name = "FBReelsTextFilePreviewer_RichTextBox"
        FBReelsTextFilePreviewer_RichTextBox.Size = New Size(325, 140)
        FBReelsTextFilePreviewer_RichTextBox.TabIndex = 146
        FBReelsTextFilePreviewer_RichTextBox.Text = ""
        FBReelsTextFilePreviewer_RichTextBox.WordWrap = False
        ' 
        ' FBReelsCreateNewAssetFolder_Button
        ' 
        FBReelsCreateNewAssetFolder_Button.Location = New Point(6, 393)
        FBReelsCreateNewAssetFolder_Button.Name = "FBReelsCreateNewAssetFolder_Button"
        FBReelsCreateNewAssetFolder_Button.Size = New Size(170, 29)
        FBReelsCreateNewAssetFolder_Button.TabIndex = 145
        FBReelsCreateNewAssetFolder_Button.Text = "建立"
        FBReelsCreateNewAssetFolder_Button.UseVisualStyleBackColor = True
        ' 
        ' DevTool_TabPage
        ' 
        DevTool_TabPage.Controls.Add(DevTool_ClearOutputRichTextBox_Button)
        DevTool_TabPage.Controls.Add(Label73)
        DevTool_TabPage.Controls.Add(DevTool_ClickElementByCssSelector_Button)
        DevTool_TabPage.Controls.Add(DevTool_ResultOutput_RichTextBox)
        DevTool_TabPage.Controls.Add(DevTool_FindElementByCssSelector_Button)
        DevTool_TabPage.Controls.Add(Label72)
        DevTool_TabPage.Controls.Add(DevTool_CssSelectorInput_TextBox)
        DevTool_TabPage.Location = New Point(4, 28)
        DevTool_TabPage.Name = "DevTool_TabPage"
        DevTool_TabPage.Size = New Size(664, 467)
        DevTool_TabPage.TabIndex = 10
        DevTool_TabPage.Text = "開發工具"
        DevTool_TabPage.UseVisualStyleBackColor = True
        ' 
        ' DevTool_ClearOutputRichTextBox_Button
        ' 
        DevTool_ClearOutputRichTextBox_Button.Location = New Point(556, 138)
        DevTool_ClearOutputRichTextBox_Button.Name = "DevTool_ClearOutputRichTextBox_Button"
        DevTool_ClearOutputRichTextBox_Button.Size = New Size(94, 29)
        DevTool_ClearOutputRichTextBox_Button.TabIndex = 6
        DevTool_ClearOutputRichTextBox_Button.Text = "Clear"
        DevTool_ClearOutputRichTextBox_Button.UseVisualStyleBackColor = True
        ' 
        ' Label73
        ' 
        Label73.AutoSize = True
        Label73.Location = New Point(13, 151)
        Label73.Name = "Label73"
        Label73.Size = New Size(69, 19)
        Label73.TabIndex = 5
        Label73.Text = "Output : "
        ' 
        ' DevTool_ClickElementByCssSelector_Button
        ' 
        DevTool_ClickElementByCssSelector_Button.Location = New Point(219, 67)
        DevTool_ClickElementByCssSelector_Button.Name = "DevTool_ClickElementByCssSelector_Button"
        DevTool_ClickElementByCssSelector_Button.Size = New Size(94, 29)
        DevTool_ClickElementByCssSelector_Button.TabIndex = 4
        DevTool_ClickElementByCssSelector_Button.Text = "Click"
        DevTool_ClickElementByCssSelector_Button.UseVisualStyleBackColor = True
        ' 
        ' DevTool_ResultOutput_RichTextBox
        ' 
        DevTool_ResultOutput_RichTextBox.Location = New Point(13, 173)
        DevTool_ResultOutput_RichTextBox.Name = "DevTool_ResultOutput_RichTextBox"
        DevTool_ResultOutput_RichTextBox.Size = New Size(637, 281)
        DevTool_ResultOutput_RichTextBox.TabIndex = 3
        DevTool_ResultOutput_RichTextBox.Text = ""
        ' 
        ' DevTool_FindElementByCssSelector_Button
        ' 
        DevTool_FindElementByCssSelector_Button.Location = New Point(119, 67)
        DevTool_FindElementByCssSelector_Button.Name = "DevTool_FindElementByCssSelector_Button"
        DevTool_FindElementByCssSelector_Button.Size = New Size(94, 29)
        DevTool_FindElementByCssSelector_Button.TabIndex = 2
        DevTool_FindElementByCssSelector_Button.Text = "Find"
        DevTool_FindElementByCssSelector_Button.UseVisualStyleBackColor = True
        ' 
        ' Label72
        ' 
        Label72.AutoSize = True
        Label72.Location = New Point(13, 39)
        Label72.Name = "Label72"
        Label72.Size = New Size(100, 19)
        Label72.TabIndex = 1
        Label72.Text = "CssSelector : "
        ' 
        ' DevTool_CssSelectorInput_TextBox
        ' 
        DevTool_CssSelectorInput_TextBox.Location = New Point(119, 34)
        DevTool_CssSelectorInput_TextBox.Name = "DevTool_CssSelectorInput_TextBox"
        DevTool_CssSelectorInput_TextBox.Size = New Size(531, 27)
        DevTool_CssSelectorInput_TextBox.TabIndex = 0
        ' 
        ' ShowEmojiPicker_Button
        ' 
        ShowEmojiPicker_Button.Location = New Point(1824, 41)
        ShowEmojiPicker_Button.Name = "ShowEmojiPicker_Button"
        ShowEmojiPicker_Button.Size = New Size(24, 71)
        ShowEmojiPicker_Button.TabIndex = 26
        ShowEmojiPicker_Button.Text = "😀"
        ShowEmojiPicker_Button.UseVisualStyleBackColor = True
        ' 
        ' ScriptTask_GroupBox
        ' 
        ScriptTask_GroupBox.Controls.Add(Label55)
        ScriptTask_GroupBox.Controls.Add(CustomizeAction_ComboBox)
        ScriptTask_GroupBox.Controls.Add(CustomizeScriptInsertion_RadioButton)
        ScriptTask_GroupBox.Controls.Add(DefaultScriptInsertion_RadioButton)
        ScriptTask_GroupBox.Controls.Add(SortListviewItemByTime_Button)
        ScriptTask_GroupBox.Controls.Add(ScheduledTimeSorting_DateTimePicker)
        ScriptTask_GroupBox.Controls.Add(SyncTimeToDateTimePicker_Label)
        ScriptTask_GroupBox.Controls.Add(ModifyListviewScheduleTimeTNull_Button)
        ScriptTask_GroupBox.Controls.Add(StopScheduledExecutionScriptQueue_Button)
        ScriptTask_GroupBox.Controls.Add(Label24)
        ScriptTask_GroupBox.Controls.Add(Label25)
        ScriptTask_GroupBox.Controls.Add(ScheduledExecutionMinutes_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ScheduledExecutionHours_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ScheduledExecutionSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ScheduledExecutionScriptQueue_Button)
        ScriptTask_GroupBox.Controls.Add(ExecuteSelectedScriptListviewItem_Button)
        ScriptTask_GroupBox.Controls.Add(ModifySelectedScriptListviewAsset_Button)
        ScriptTask_GroupBox.Controls.Add(ContinueScriptExecution_Button)
        ScriptTask_GroupBox.Controls.Add(PauseScriptExecution_Button)
        ScriptTask_GroupBox.Controls.Add(ModifySelectedScriptListviewWaitTime_Button)
        ScriptTask_GroupBox.Controls.Add(Label20)
        ScriptTask_GroupBox.Controls.Add(ScriptExecutionCount_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(Label19)
        ScriptTask_GroupBox.Controls.Add(ExecutionScriptQueue_Button)
        ScriptTask_GroupBox.Controls.Add(Label18)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitRandomSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ResetScript_Button)
        ScriptTask_GroupBox.Controls.Add(Label17)
        ScriptTask_GroupBox.Controls.Add(Label16)
        ScriptTask_GroupBox.Controls.Add(Label15)
        ScriptTask_GroupBox.Controls.Add(Label14)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitMinutes_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitHours_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(ExecutionWaitSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(InsertToQueueListview_Button)
        ScriptTask_GroupBox.Controls.Add(ModifyListviewScheduleTime_Button)
        ScriptTask_GroupBox.Controls.Add(InsertSchedulerScriptToListview_Button)
        ScriptTask_GroupBox.Controls.Add(Label13)
        ScriptTask_GroupBox.Controls.Add(SchedulerIntervalSeconds_NumericUpDown)
        ScriptTask_GroupBox.Controls.Add(Label12)
        ScriptTask_GroupBox.Controls.Add(Label11)
        ScriptTask_GroupBox.Controls.Add(SchedulerTime_Label)
        ScriptTask_GroupBox.Location = New Point(440, 403)
        ScriptTask_GroupBox.Name = "ScriptTask_GroupBox"
        ScriptTask_GroupBox.Size = New Size(701, 232)
        ScriptTask_GroupBox.TabIndex = 26
        ScriptTask_GroupBox.TabStop = False
        ScriptTask_GroupBox.Text = "腳本任務"
        ' 
        ' Label55
        ' 
        Label55.AutoSize = True
        Label55.Location = New Point(13, 26)
        Label55.Name = "Label55"
        Label55.Size = New Size(80, 19)
        Label55.TabIndex = 44
        Label55.Text = "執行功能 : "
        ' 
        ' CustomizeAction_ComboBox
        ' 
        CustomizeAction_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        CustomizeAction_ComboBox.Enabled = False
        CustomizeAction_ComboBox.FormattingEnabled = True
        CustomizeAction_ComboBox.Items.AddRange(New Object() {"讀取已讀通知", "讀取未讀通知", "已讀全部通知", "順序回應通知", "", "讀取未讀聊天室", "讀取己讀聊天室", "讀取未讀Marketplace", "讀取己讀Marketplace", "讀取未讀陌生訊息", "讀取己讀陌生訊息", "", "聊天室訊息己讀封存", "聊天室訊息未讀封存", "Marketplace室訊息己讀封存", "Marketplace室訊息未讀封存", "順序回覆訊息", "", "個人發帖單圖"})
        CustomizeAction_ComboBox.Location = New Point(291, 21)
        CustomizeAction_ComboBox.Name = "CustomizeAction_ComboBox"
        CustomizeAction_ComboBox.Size = New Size(264, 27)
        CustomizeAction_ComboBox.TabIndex = 43
        ' 
        ' CustomizeScriptInsertion_RadioButton
        ' 
        CustomizeScriptInsertion_RadioButton.AutoSize = True
        CustomizeScriptInsertion_RadioButton.Location = New Point(195, 26)
        CustomizeScriptInsertion_RadioButton.Name = "CustomizeScriptInsertion_RadioButton"
        CustomizeScriptInsertion_RadioButton.Size = New Size(90, 23)
        CustomizeScriptInsertion_RadioButton.TabIndex = 42
        CustomizeScriptInsertion_RadioButton.TabStop = True
        CustomizeScriptInsertion_RadioButton.Text = "自訂功能"
        CustomizeScriptInsertion_RadioButton.UseVisualStyleBackColor = True
        ' 
        ' DefaultScriptInsertion_RadioButton
        ' 
        DefaultScriptInsertion_RadioButton.AutoSize = True
        DefaultScriptInsertion_RadioButton.Checked = True
        DefaultScriptInsertion_RadioButton.Location = New Point(99, 26)
        DefaultScriptInsertion_RadioButton.Name = "DefaultScriptInsertion_RadioButton"
        DefaultScriptInsertion_RadioButton.Size = New Size(90, 23)
        DefaultScriptInsertion_RadioButton.TabIndex = 41
        DefaultScriptInsertion_RadioButton.TabStop = True
        DefaultScriptInsertion_RadioButton.Text = "預設功能"
        DefaultScriptInsertion_RadioButton.UseVisualStyleBackColor = True
        ' 
        ' SortListviewItemByTime_Button
        ' 
        SortListviewItemByTime_Button.Location = New Point(600, 123)
        SortListviewItemByTime_Button.Name = "SortListviewItemByTime_Button"
        SortListviewItemByTime_Button.Size = New Size(94, 29)
        SortListviewItemByTime_Button.TabIndex = 39
        SortListviewItemByTime_Button.Text = "排序"
        SortListviewItemByTime_Button.UseVisualStyleBackColor = True
        ' 
        ' ScheduledTimeSorting_DateTimePicker
        ' 
        ScheduledTimeSorting_DateTimePicker.CustomFormat = "HH:mm:ss"
        ScheduledTimeSorting_DateTimePicker.Format = DateTimePickerFormat.Custom
        ScheduledTimeSorting_DateTimePicker.Location = New Point(490, 125)
        ScheduledTimeSorting_DateTimePicker.Name = "ScheduledTimeSorting_DateTimePicker"
        ScheduledTimeSorting_DateTimePicker.ShowUpDown = True
        ScheduledTimeSorting_DateTimePicker.Size = New Size(106, 27)
        ScheduledTimeSorting_DateTimePicker.TabIndex = 38
        ' 
        ' SyncTimeToDateTimePicker_Label
        ' 
        SyncTimeToDateTimePicker_Label.AutoSize = True
        SyncTimeToDateTimePicker_Label.Cursor = Cursors.Hand
        SyncTimeToDateTimePicker_Label.Location = New Point(414, 130)
        SyncTimeToDateTimePicker_Label.Name = "SyncTimeToDateTimePicker_Label"
        SyncTimeToDateTimePicker_Label.Size = New Size(72, 19)
        SyncTimeToDateTimePicker_Label.TabIndex = 37
        SyncTimeToDateTimePicker_Label.Text = "排序時間:"
        ' 
        ' ModifyListviewScheduleTimeTNull_Button
        ' 
        ModifyListviewScheduleTimeTNull_Button.Location = New Point(627, 53)
        ModifyListviewScheduleTimeTNull_Button.Name = "ModifyListviewScheduleTimeTNull_Button"
        ModifyListviewScheduleTimeTNull_Button.Size = New Size(60, 29)
        ModifyListviewScheduleTimeTNull_Button.TabIndex = 36
        ModifyListviewScheduleTimeTNull_Button.Text = "NULL"
        ModifyListviewScheduleTimeTNull_Button.UseVisualStyleBackColor = True
        ' 
        ' StopScheduledExecutionScriptQueue_Button
        ' 
        StopScheduledExecutionScriptQueue_Button.Location = New Point(315, 125)
        StopScheduledExecutionScriptQueue_Button.Name = "StopScheduledExecutionScriptQueue_Button"
        StopScheduledExecutionScriptQueue_Button.Size = New Size(94, 29)
        StopScheduledExecutionScriptQueue_Button.TabIndex = 35
        StopScheduledExecutionScriptQueue_Button.Text = "停止執行"
        StopScheduledExecutionScriptQueue_Button.UseVisualStyleBackColor = True
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Location = New Point(237, 60)
        Label24.Name = "Label24"
        Label24.Size = New Size(24, 19)
        Label24.TabIndex = 34
        Label24.Text = "分"
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.Location = New Point(151, 60)
        Label25.Name = "Label25"
        Label25.Size = New Size(24, 19)
        Label25.TabIndex = 33
        Label25.Text = "時"
        ' 
        ' ScheduledExecutionMinutes_NumericUpDown
        ' 
        ScheduledExecutionMinutes_NumericUpDown.Location = New Point(180, 55)
        ScheduledExecutionMinutes_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ScheduledExecutionMinutes_NumericUpDown.Name = "ScheduledExecutionMinutes_NumericUpDown"
        ScheduledExecutionMinutes_NumericUpDown.Size = New Size(50, 27)
        ScheduledExecutionMinutes_NumericUpDown.TabIndex = 32
        ' 
        ' ScheduledExecutionHours_NumericUpDown
        ' 
        ScheduledExecutionHours_NumericUpDown.Location = New Point(96, 55)
        ScheduledExecutionHours_NumericUpDown.Name = "ScheduledExecutionHours_NumericUpDown"
        ScheduledExecutionHours_NumericUpDown.Size = New Size(50, 27)
        ScheduledExecutionHours_NumericUpDown.TabIndex = 31
        ' 
        ' ScheduledExecutionSeconds_NumericUpDown
        ' 
        ScheduledExecutionSeconds_NumericUpDown.Location = New Point(267, 55)
        ScheduledExecutionSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ScheduledExecutionSeconds_NumericUpDown.Name = "ScheduledExecutionSeconds_NumericUpDown"
        ScheduledExecutionSeconds_NumericUpDown.Size = New Size(50, 27)
        ScheduledExecutionSeconds_NumericUpDown.TabIndex = 30
        ' 
        ' ScheduledExecutionScriptQueue_Button
        ' 
        ScheduledExecutionScriptQueue_Button.Location = New Point(215, 125)
        ScheduledExecutionScriptQueue_Button.Name = "ScheduledExecutionScriptQueue_Button"
        ScheduledExecutionScriptQueue_Button.Size = New Size(94, 29)
        ScheduledExecutionScriptQueue_Button.TabIndex = 29
        ScheduledExecutionScriptQueue_Button.Text = "定時執行"
        ScheduledExecutionScriptQueue_Button.UseVisualStyleBackColor = True
        ' 
        ' ExecuteSelectedScriptListviewItem_Button
        ' 
        ExecuteSelectedScriptListviewItem_Button.Location = New Point(435, 160)
        ExecuteSelectedScriptListviewItem_Button.Name = "ExecuteSelectedScriptListviewItem_Button"
        ExecuteSelectedScriptListviewItem_Button.Size = New Size(94, 29)
        ExecuteSelectedScriptListviewItem_Button.TabIndex = 28
        ExecuteSelectedScriptListviewItem_Button.Text = "執行所選"
        ExecuteSelectedScriptListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' ModifySelectedScriptListviewAsset_Button
        ' 
        ModifySelectedScriptListviewAsset_Button.Location = New Point(115, 125)
        ModifySelectedScriptListviewAsset_Button.Name = "ModifySelectedScriptListviewAsset_Button"
        ModifySelectedScriptListviewAsset_Button.Size = New Size(94, 29)
        ModifySelectedScriptListviewAsset_Button.TabIndex = 26
        ModifySelectedScriptListviewAsset_Button.Text = "修改資料夾"
        ModifySelectedScriptListviewAsset_Button.UseVisualStyleBackColor = True
        ' 
        ' ContinueScriptExecution_Button
        ' 
        ContinueScriptExecution_Button.Location = New Point(379, 160)
        ContinueScriptExecution_Button.Name = "ContinueScriptExecution_Button"
        ContinueScriptExecution_Button.Size = New Size(50, 29)
        ContinueScriptExecution_Button.TabIndex = 25
        ContinueScriptExecution_Button.Text = "繼續"
        ContinueScriptExecution_Button.UseVisualStyleBackColor = True
        ' 
        ' PauseScriptExecution_Button
        ' 
        PauseScriptExecution_Button.Location = New Point(323, 160)
        PauseScriptExecution_Button.Name = "PauseScriptExecution_Button"
        PauseScriptExecution_Button.Size = New Size(50, 29)
        PauseScriptExecution_Button.TabIndex = 24
        PauseScriptExecution_Button.Text = "暫停"
        PauseScriptExecution_Button.UseVisualStyleBackColor = True
        ' 
        ' ModifySelectedScriptListviewWaitTime_Button
        ' 
        ModifySelectedScriptListviewWaitTime_Button.Location = New Point(13, 125)
        ModifySelectedScriptListviewWaitTime_Button.Name = "ModifySelectedScriptListviewWaitTime_Button"
        ModifySelectedScriptListviewWaitTime_Button.Size = New Size(94, 29)
        ModifySelectedScriptListviewWaitTime_Button.TabIndex = 23
        ModifySelectedScriptListviewWaitTime_Button.Text = "修改時間"
        ModifySelectedScriptListviewWaitTime_Button.UseVisualStyleBackColor = True
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(155, 167)
        Label20.Name = "Label20"
        Label20.Size = New Size(24, 19)
        Label20.TabIndex = 22
        Label20.Text = "次"
        ' 
        ' ScriptExecutionCount_NumericUpDown
        ' 
        ScriptExecutionCount_NumericUpDown.Location = New Point(100, 160)
        ScriptExecutionCount_NumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        ScriptExecutionCount_NumericUpDown.Name = "ScriptExecutionCount_NumericUpDown"
        ScriptExecutionCount_NumericUpDown.Size = New Size(50, 27)
        ScriptExecutionCount_NumericUpDown.TabIndex = 21
        ScriptExecutionCount_NumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(17, 165)
        Label19.Name = "Label19"
        Label19.Size = New Size(76, 19)
        Label19.TabIndex = 20
        Label19.Text = "執行次數 :"
        ' 
        ' ExecutionScriptQueue_Button
        ' 
        ExecutionScriptQueue_Button.BackColor = SystemColors.GradientInactiveCaption
        ExecutionScriptQueue_Button.Location = New Point(185, 158)
        ExecutionScriptQueue_Button.Name = "ExecutionScriptQueue_Button"
        ExecutionScriptQueue_Button.Size = New Size(132, 29)
        ExecutionScriptQueue_Button.TabIndex = 19
        ExecutionScriptQueue_Button.Text = "執行腳本"
        ExecutionScriptQueue_Button.UseVisualStyleBackColor = False
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(353, 93)
        Label18.Name = "Label18"
        Label18.Size = New Size(50, 19)
        Label18.TabIndex = 18
        Label18.Text = "隨機±"
        ' 
        ' ExecutionWaitRandomSeconds_NumericUpDown
        ' 
        ExecutionWaitRandomSeconds_NumericUpDown.Location = New Point(405, 88)
        ExecutionWaitRandomSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitRandomSeconds_NumericUpDown.Name = "ExecutionWaitRandomSeconds_NumericUpDown"
        ExecutionWaitRandomSeconds_NumericUpDown.Size = New Size(54, 27)
        ExecutionWaitRandomSeconds_NumericUpDown.TabIndex = 17
        ' 
        ' ResetScript_Button
        ' 
        ResetScript_Button.Location = New Point(600, 160)
        ResetScript_Button.Name = "ResetScript_Button"
        ResetScript_Button.Size = New Size(94, 29)
        ResetScript_Button.TabIndex = 27
        ResetScript_Button.Text = "重置程式"
        ResetScript_Button.UseVisualStyleBackColor = True
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(465, 93)
        Label17.Name = "Label17"
        Label17.Size = New Size(24, 19)
        Label17.TabIndex = 16
        Label17.Text = "秒"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(323, 93)
        Label16.Name = "Label16"
        Label16.Size = New Size(24, 19)
        Label16.TabIndex = 15
        Label16.Text = "秒"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(237, 93)
        Label15.Name = "Label15"
        Label15.Size = New Size(24, 19)
        Label15.TabIndex = 14
        Label15.Text = "分"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(151, 93)
        Label14.Name = "Label14"
        Label14.Size = New Size(24, 19)
        Label14.TabIndex = 13
        Label14.Text = "時"
        ' 
        ' ExecutionWaitMinutes_NumericUpDown
        ' 
        ExecutionWaitMinutes_NumericUpDown.Location = New Point(180, 88)
        ExecutionWaitMinutes_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitMinutes_NumericUpDown.Name = "ExecutionWaitMinutes_NumericUpDown"
        ExecutionWaitMinutes_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitMinutes_NumericUpDown.TabIndex = 12
        ' 
        ' ExecutionWaitHours_NumericUpDown
        ' 
        ExecutionWaitHours_NumericUpDown.Location = New Point(96, 88)
        ExecutionWaitHours_NumericUpDown.Name = "ExecutionWaitHours_NumericUpDown"
        ExecutionWaitHours_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitHours_NumericUpDown.TabIndex = 11
        ' 
        ' ExecutionWaitSeconds_NumericUpDown
        ' 
        ExecutionWaitSeconds_NumericUpDown.Location = New Point(267, 88)
        ExecutionWaitSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        ExecutionWaitSeconds_NumericUpDown.Name = "ExecutionWaitSeconds_NumericUpDown"
        ExecutionWaitSeconds_NumericUpDown.Size = New Size(50, 27)
        ExecutionWaitSeconds_NumericUpDown.TabIndex = 10
        ' 
        ' InsertToQueueListview_Button
        ' 
        InsertToQueueListview_Button.Location = New Point(495, 86)
        InsertToQueueListview_Button.Name = "InsertToQueueListview_Button"
        InsertToQueueListview_Button.Size = New Size(60, 29)
        InsertToQueueListview_Button.TabIndex = 9
        InsertToQueueListview_Button.Text = "插入"
        InsertToQueueListview_Button.UseVisualStyleBackColor = True
        ' 
        ' ModifyListviewScheduleTime_Button
        ' 
        ModifyListviewScheduleTime_Button.Location = New Point(561, 53)
        ModifyListviewScheduleTime_Button.Name = "ModifyListviewScheduleTime_Button"
        ModifyListviewScheduleTime_Button.Size = New Size(60, 29)
        ModifyListviewScheduleTime_Button.TabIndex = 7
        ModifyListviewScheduleTime_Button.Text = "修改"
        ModifyListviewScheduleTime_Button.UseVisualStyleBackColor = True
        ' 
        ' InsertSchedulerScriptToListview_Button
        ' 
        InsertSchedulerScriptToListview_Button.Location = New Point(495, 53)
        InsertSchedulerScriptToListview_Button.Name = "InsertSchedulerScriptToListview_Button"
        InsertSchedulerScriptToListview_Button.Size = New Size(60, 29)
        InsertSchedulerScriptToListview_Button.TabIndex = 6
        InsertSchedulerScriptToListview_Button.Text = "插入"
        InsertSchedulerScriptToListview_Button.UseVisualStyleBackColor = True
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(465, 60)
        Label13.Name = "Label13"
        Label13.Size = New Size(24, 19)
        Label13.TabIndex = 5
        Label13.Text = "秒"
        ' 
        ' SchedulerIntervalSeconds_NumericUpDown
        ' 
        SchedulerIntervalSeconds_NumericUpDown.Location = New Point(405, 54)
        SchedulerIntervalSeconds_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        SchedulerIntervalSeconds_NumericUpDown.Name = "SchedulerIntervalSeconds_NumericUpDown"
        SchedulerIntervalSeconds_NumericUpDown.Size = New Size(54, 27)
        SchedulerIntervalSeconds_NumericUpDown.TabIndex = 4
        SchedulerIntervalSeconds_NumericUpDown.Value = New Decimal(New Integer() {180, 0, 0, 0})
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(13, 93)
        Label12.Name = "Label12"
        Label12.Size = New Size(76, 19)
        Label12.TabIndex = 2
        Label12.Text = "等待時間 :"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(323, 60)
        Label11.Name = "Label11"
        Label11.Size = New Size(76, 19)
        Label11.TabIndex = 1
        Label11.Text = "相隔時間 :"
        ' 
        ' SchedulerTime_Label
        ' 
        SchedulerTime_Label.AutoSize = True
        SchedulerTime_Label.Cursor = Cursors.Hand
        SchedulerTime_Label.Location = New Point(13, 63)
        SchedulerTime_Label.Name = "SchedulerTime_Label"
        SchedulerTime_Label.Size = New Size(76, 19)
        SchedulerTime_Label.TabIndex = 0
        SchedulerTime_Label.Text = "執行時間 :"
        ' 
        ' userData_ComboBox
        ' 
        userData_ComboBox.FormattingEnabled = True
        userData_ComboBox.Location = New Point(12, 1064)
        userData_ComboBox.Name = "userData_ComboBox"
        userData_ComboBox.Size = New Size(162, 27)
        userData_ComboBox.TabIndex = 27
        ' 
        ' MarkUserDataToSkip_Button
        ' 
        MarkUserDataToSkip_Button.Location = New Point(180, 1064)
        MarkUserDataToSkip_Button.Name = "MarkUserDataToSkip_Button"
        MarkUserDataToSkip_Button.Size = New Size(94, 29)
        MarkUserDataToSkip_Button.TabIndex = 28
        MarkUserDataToSkip_Button.Text = "帳號標註"
        MarkUserDataToSkip_Button.UseVisualStyleBackColor = True
        ' 
        ' UnmarkUserDataToSkip_Button_Button
        ' 
        UnmarkUserDataToSkip_Button_Button.Location = New Point(280, 1064)
        UnmarkUserDataToSkip_Button_Button.Name = "UnmarkUserDataToSkip_Button_Button"
        UnmarkUserDataToSkip_Button_Button.Size = New Size(94, 29)
        UnmarkUserDataToSkip_Button_Button.TabIndex = 29
        UnmarkUserDataToSkip_Button_Button.Text = "取消標註"
        UnmarkUserDataToSkip_Button_Button.UseVisualStyleBackColor = True
        ' 
        ' SaveScriptListViewToCSVFile_Button
        ' 
        SaveScriptListViewToCSVFile_Button.Location = New Point(1047, 1064)
        SaveScriptListViewToCSVFile_Button.Name = "SaveScriptListViewToCSVFile_Button"
        SaveScriptListViewToCSVFile_Button.Size = New Size(94, 29)
        SaveScriptListViewToCSVFile_Button.TabIndex = 30
        SaveScriptListViewToCSVFile_Button.Text = "儲存腳本"
        SaveScriptListViewToCSVFile_Button.UseVisualStyleBackColor = True
        ' 
        ' MarkSelectedScriptListviewItem_Button
        ' 
        MarkSelectedScriptListviewItem_Button.Location = New Point(582, 1065)
        MarkSelectedScriptListviewItem_Button.Name = "MarkSelectedScriptListviewItem_Button"
        MarkSelectedScriptListviewItem_Button.Size = New Size(94, 29)
        MarkSelectedScriptListviewItem_Button.TabIndex = 31
        MarkSelectedScriptListviewItem_Button.Text = "標註所選"
        MarkSelectedScriptListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' UnmarkSelectedScriptListviewItem_Button
        ' 
        UnmarkSelectedScriptListviewItem_Button.Location = New Point(681, 1065)
        UnmarkSelectedScriptListviewItem_Button.Name = "UnmarkSelectedScriptListviewItem_Button"
        UnmarkSelectedScriptListviewItem_Button.Size = New Size(94, 29)
        UnmarkSelectedScriptListviewItem_Button.TabIndex = 32
        UnmarkSelectedScriptListviewItem_Button.Text = "取消標註"
        UnmarkSelectedScriptListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedScriptListviewItem_Button
        ' 
        DeleteSelectedScriptListviewItem_Button.Location = New Point(782, 1065)
        DeleteSelectedScriptListviewItem_Button.Name = "DeleteSelectedScriptListviewItem_Button"
        DeleteSelectedScriptListviewItem_Button.Size = New Size(94, 29)
        DeleteSelectedScriptListviewItem_Button.TabIndex = 34
        DeleteSelectedScriptListviewItem_Button.Text = "刪除所選"
        DeleteSelectedScriptListviewItem_Button.UseVisualStyleBackColor = True
        ' 
        ' DeleteScriptListviewItemByUserData_Button
        ' 
        DeleteScriptListviewItemByUserData_Button.Location = New Point(483, 1064)
        DeleteScriptListviewItemByUserData_Button.Name = "DeleteScriptListviewItemByUserData_Button"
        DeleteScriptListviewItemByUserData_Button.Size = New Size(94, 29)
        DeleteScriptListviewItemByUserData_Button.TabIndex = 35
        DeleteScriptListviewItemByUserData_Button.Text = "帳號刪除"
        DeleteScriptListviewItemByUserData_Button.UseVisualStyleBackColor = True
        ' 
        ' SelectScriptListviewItemsByUserDataButton
        ' 
        SelectScriptListviewItemsByUserDataButton.Location = New Point(381, 1064)
        SelectScriptListviewItemsByUserDataButton.Margin = New Padding(4)
        SelectScriptListviewItemsByUserDataButton.Name = "SelectScriptListviewItemsByUserDataButton"
        SelectScriptListviewItemsByUserDataButton.Size = New Size(96, 29)
        SelectScriptListviewItemsByUserDataButton.TabIndex = 37
        SelectScriptListviewItemsByUserDataButton.Text = "選取"
        SelectScriptListviewItemsByUserDataButton.UseVisualStyleBackColor = True
        ' 
        ' EditScriptFile_Button
        ' 
        EditScriptFile_Button.Location = New Point(947, 1064)
        EditScriptFile_Button.Name = "EditScriptFile_Button"
        EditScriptFile_Button.Size = New Size(94, 29)
        EditScriptFile_Button.TabIndex = 38
        EditScriptFile_Button.Text = "開啟腳本"
        EditScriptFile_Button.UseVisualStyleBackColor = True
        ' 
        ' SwapScriptQueueListViewItems_Button
        ' 
        SwapScriptQueueListViewItems_Button.Location = New Point(12, 606)
        SwapScriptQueueListViewItems_Button.Name = "SwapScriptQueueListViewItems_Button"
        SwapScriptQueueListViewItems_Button.Size = New Size(94, 29)
        SwapScriptQueueListViewItems_Button.TabIndex = 39
        SwapScriptQueueListViewItems_Button.Text = "對調"
        SwapScriptQueueListViewItems_Button.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1858, 1103)
        Controls.Add(SwapScriptQueueListViewItems_Button)
        Controls.Add(EditScriptFile_Button)
        Controls.Add(SelectScriptListviewItemsByUserDataButton)
        Controls.Add(ShowEmojiPicker_Button)
        Controls.Add(DeleteScriptListviewItemByUserData_Button)
        Controls.Add(DeleteSelectedScriptListviewItem_Button)
        Controls.Add(UnmarkSelectedScriptListviewItem_Button)
        Controls.Add(MarkSelectedScriptListviewItem_Button)
        Controls.Add(SaveScriptListViewToCSVFile_Button)
        Controls.Add(UnmarkUserDataToSkip_Button_Button)
        Controls.Add(MarkUserDataToSkip_Button)
        Controls.Add(userData_ComboBox)
        Controls.Add(ScriptTask_GroupBox)
        Controls.Add(Action_TabControl)
        Controls.Add(ScriptQueue_ListView)
        Controls.Add(FBUrlData_TabControl)
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
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(Main_WebView2, ComponentModel.ISupportInitialize).EndInit()
        UserInfo_GroupBox.ResumeLayout(False)
        UserInfo_GroupBox.PerformLayout()
        UserDataFoldListFilter_GroupBox.ResumeLayout(False)
        UserDataFoldListFilter_GroupBox.PerformLayout()
        FBUrlData_TabControl.ResumeLayout(False)
        FBGroupsUrlData_TabPage.ResumeLayout(False)
        FBGroupsUrlData_TabPage.PerformLayout()
        FBActivityLogsUrlData_TabPage.ResumeLayout(False)
        FBActivityLogsUrlData_TabPage.PerformLayout()
        CType(NumberOfActivityLogsPageDropDown_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        FBNotificationsUrlData_TabPage.ResumeLayout(False)
        FBNotificationsUrlData_TabPage.PerformLayout()
        FBMessengerUrlData_TabPage.ResumeLayout(False)
        FBMessengerUrlData_TabPage.PerformLayout()
        FBMediaDownloader_TabPage.ResumeLayout(False)
        FBMediaDownloader_TabPage.PerformLayout()
        CType(FBMediaDownloaderNextMediaCount_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        Action_TabControl.ResumeLayout(False)
        FBPostAssets_TabPage.ResumeLayout(False)
        FBPostAssets_TabPage.PerformLayout()
        CType(FBWritePostUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBWritePostSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(MediaPreview_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBMarketplaceAssets_TabPage.ResumeLayout(False)
        FBMarketplaceAssets_TabPage.PerformLayout()
        CType(FBMarketplaceShareGroupsCount_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMarketplaceUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMarketplaceSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMarketplaceMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMarketplaceProductPrice_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        FBPostShareURLAssets_TabPage.ResumeLayout(False)
        FBPostShareURLAssets_TabPage.PerformLayout()
        CType(FBPostShareURLUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBPostShareURLSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        FBCommentAssets_TabPage.ResumeLayout(False)
        FBCommentAssets_TabPage.PerformLayout()
        CType(FBCommentUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBCommentSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBCommentMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBCustomizeCommentAssets_TabPage.ResumeLayout(False)
        FBCustomizeCommentAssets_TabPage.PerformLayout()
        CType(FBCustomizeCommentUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBCustomizeCommentSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBCustomizeCommentMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBRespondNotificationsAssets_TabPage.ResumeLayout(False)
        FBRespondNotificationsAssets_TabPage.PerformLayout()
        CType(FBResponseUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBResponseSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBResponseMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBMessengerAssets_TabPage.ResumeLayout(False)
        FBMessengerAssets_TabPage.PerformLayout()
        CType(FBMessengerUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMessengerSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBMessengerMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBStoryAssets_TabPage.ResumeLayout(False)
        FBStoryAssets_TabPage.PerformLayout()
        CType(FBStoryUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBStorySubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBStoryMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBPersonalPostAssets_TabPage.ResumeLayout(False)
        FBPersonalPostAssets_TabPage.PerformLayout()
        CType(FBPersonalPostUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBPersonalPostSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBPersonalPostMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        FBReelsAssets_TabPage.ResumeLayout(False)
        FBReelsAssets_TabPage.PerformLayout()
        CType(FBReelsUploadWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBReelsSubmitWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(FBReelsMediaPreviewer_PictureBox, ComponentModel.ISupportInitialize).EndInit()
        DevTool_TabPage.ResumeLayout(False)
        DevTool_TabPage.PerformLayout()
        ScriptTask_GroupBox.ResumeLayout(False)
        ScriptTask_GroupBox.PerformLayout()
        CType(ScheduledExecutionMinutes_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ScheduledExecutionHours_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ScheduledExecutionSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ScriptExecutionCount_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitRandomSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitMinutes_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitHours_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(ExecutionWaitSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        CType(SchedulerIntervalSeconds_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents FBUrlData_TabControl As TabControl
    Friend WithEvents FBGroupsUrlData_TabPage As TabPage
    Friend WithEvents FBActivityLogsUrlData_TabPage As TabPage
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
    Friend WithEvents FBPostAssets_TabPage As TabPage
    Friend WithEvents FBMessengerAssets_TabPage As TabPage
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
    Friend WithEvents SchedulerTime_Label As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents SchedulerIntervalSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents ModifyListviewScheduleTime_Button As Button
    Friend WithEvents InsertSchedulerScriptToListview_Button As Button
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
    Friend WithEvents ScriptExecutionCount_NumericUpDown As NumericUpDown
    Friend WithEvents Label20 As Label
    Friend WithEvents ContinueScriptExecution_Button As Button
    Friend WithEvents PauseScriptExecution_Button As Button
    Friend WithEvents userData_ComboBox As ComboBox
    Friend WithEvents MarkUserDataToSkip_Button As Button
    Friend WithEvents UnmarkUserDataToSkip_Button_Button As Button
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents SaveScriptListViewToCSVFile_Button As Button
    Friend WithEvents MarkSelectedScriptListviewItem_Button As Button
    Friend WithEvents UnmarkSelectedScriptListviewItem_Button As Button
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents DeleteSelectedScriptListviewItem_Button As Button
    Friend WithEvents DeleteScriptListviewItemByUserData_Button As Button
    Friend WithEvents ModifySelectedScriptListviewWaitTime_Button As Button
    Friend WithEvents ModifySelectedScriptListviewAsset_Button As Button
    Friend WithEvents ResetScript_Button As Button
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents Label21 As Label
    Friend WithEvents FBWritePostUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBWritePostSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents ExecuteSelectedScriptListviewItem_Button As Button
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ScheduledExecutionScriptQueue_Button As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents ScheduledExecutionMinutes_NumericUpDown As NumericUpDown
    Friend WithEvents ScheduledExecutionHours_NumericUpDown As NumericUpDown
    Friend WithEvents ScheduledExecutionSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents StopScheduledExecutionScriptQueue_Button As Button
    Friend WithEvents ModifyListviewScheduleTimeTNull_Button As Button
    Friend WithEvents ScheduledTimeSorting_DateTimePicker As DateTimePicker
    Friend WithEvents SyncTimeToDateTimePicker_Label As Label
    Friend WithEvents SortListviewItemByTime_Button As Button
    Friend WithEvents FBMarketplaceAssets_TabPage As TabPage
    Friend WithEvents FBMarkplaceProducts_ListBox As ListBox
    Friend WithEvents Label8 As Label
    Friend WithEvents FBmarketplaceDeselectAllProductFolderListboxItems_Button As Button
    Friend WithEvents FBMarketplaceDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents NewMarketplaceAssetFolderName_TextBox As TextBox
    Friend WithEvents CreateNewMarketplaceAssetFolder_Button As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents FBMarketplaceProductPrice_NumericUpDown As NumericUpDown
    Friend WithEvents FBMarketplaceProductName_TextBox As TextBox
    Friend WithEvents FBMarketplaceSavePruductInfo_Button As Button
    Friend WithEvents FBMarketplaceProductDescription_RichTextBox As RichTextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents FBMarketplaceProductLocation_TextBox As TextBox
    Friend WithEvents FBMarketplaceProductStatus_NumericUpDown As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents FBMarketplaceMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBMarketplaceMediaSelector_ListBox As ListBox
    Friend WithEvents FBMarketplaceDeleteSelectedMedia_Button As Button
    Friend WithEvents ShowEmojiPicker_Button As Button
    Friend WithEvents FBMarketplaceProductTag_TextBox As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents FBMarketplaceHomeDelivery_CheckBox As CheckBox
    Friend WithEvents FBMarketplacePickUp_CheckBox As CheckBox
    Friend WithEvents FBMarketplaceMeetInPerson_CheckBox As CheckBox
    Friend WithEvents FBMarketplaceOnMarketplace_CheckBox As CheckBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents FBMarketplaceUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBMarketplaceSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBMarketplaceShareGroupsCount_NumericUpDown As NumericUpDown
    Friend WithEvents Label36 As Label
    Friend WithEvents RevealFBMarketplaceMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBMarketplaceShareGroupsBySequence_RadioButton As RadioButton
    Friend WithEvents FBMarketplaceShareGroupsByRandom_RadioButton As RadioButton
    Friend WithEvents FBPostShareURLAssets_TabPage As TabPage
    Friend WithEvents Label37 As Label
    Friend WithEvents FBPostShareURLDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBPostShareURLAssetFolder_ListBox As ListBox
    Friend WithEvents FBPostShareURLDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBPostShareURLAssetFolderName_TextBox As TextBox
    Friend WithEvents FBPostShareURLCreateNewAssetFolder_Button As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents FBPostShareURLUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBPostShareURLSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBPostShareURLBaseURL_TextBox As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents FBPostShareURLDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBPostShareURLTextFileName_TextBox As TextBox
    Friend WithEvents FBPostShareURLTextFile_ListBox As ListBox
    Friend WithEvents FBPostShareURLSaveTextFile_Button As Button
    Friend WithEvents FBPostShareURLCreateNewTextFile_Button As Button
    Friend WithEvents FBPostShareURLTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBPostShareURLGetCurrentURL_Button As Button
    Friend WithEvents FBPostShareURLNavigateToURL_Button As Button
    Friend WithEvents SelectScriptListviewItemsByUserDataButton As Button
    Friend WithEvents FBCommentAssets_TabPage As TabPage
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents FBCommentUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBCommentSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBCommentDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBCommentDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBCommentNewTextFileName_TextBox As TextBox
    Friend WithEvents FBCommentMediaSelector_ListBox As ListBox
    Friend WithEvents FBCommentTextFileSelector_ListBox As ListBox
    Friend WithEvents FBCommentAssetFolder_ListBox As ListBox
    Friend WithEvents FBCommentSaveTextFile_Button As Button
    Friend WithEvents FBCommentCreateNewTextFile_Button As Button
    Friend WithEvents FBCommentDeleteSelectedMedia_Button As Button
    Friend WithEvents FBCommentRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBCommentDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBCommentAssetFolderName_TextBox As TextBox
    Friend WithEvents FBCommentMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBCommentTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBCommentCreateNewAssetFolder_Button As Button
    Friend WithEvents NumberOfActivityLogsPageDropDown_NumericUpDown As NumericUpDown
    Friend WithEvents ReadActivityLogs_Button As Button
    Friend WithEvents DeleteSelectedFBActivityLogListviewItems_Button As Button
    Friend WithEvents SaveFBActivityLogListview_Button As Button
    Friend WithEvents EditSelectedFBActivityLogListviewItem_Button As Button
    Friend WithEvents AddItemToFBActivityLogListview_Button As Button
    Friend WithEvents DisplayCurrUrlToFBActivityLogUrl_Button As Button
    Friend WithEvents NavigateToFBActivityLogSelectedGroupURL_Button As Button
    Friend WithEvents FBActivityLogsGroupURL_TextBox As TextBox
    Friend WithEvents FBActivityLogsGroupName_TextBox As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents FBActivityLogs_ListView As ListView
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents Label46 As Label
    Friend WithEvents NavigateToActivityLogsPage_Button As Button
    Friend WithEvents FBCustomizeCommentAssets_TabPage As TabPage
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents FBCustomizeCommentUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBCustomizeCommentSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBCustomizeCommentDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBCustomizeCommentNewTextFileName_TextBox As TextBox
    Friend WithEvents FBCustomizeCommentMediaSelector_ListBox As ListBox
    Friend WithEvents FBCustomizeCommentTextFileSelector_ListBox As ListBox
    Friend WithEvents FBCustomizeCommentAssetFolder_ListBox As ListBox
    Friend WithEvents FBCustomizeCommentSaveTextFile_Button As Button
    Friend WithEvents FBCustomizeCommentCreateNewTextFile_Button As Button
    Friend WithEvents FBCustomizeCommentDeleteSelectedMedia_Button As Button
    Friend WithEvents FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBCustomizeCommentDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBCustomizeCommentAssetFolderName_TextBox As TextBox
    Friend WithEvents FBCustomizeCommentMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBCustomizeCommentTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBCustomizeCommentCreateNewAssetFolder_Button As Button
    Friend WithEvents FBNotificationsUrlData_TabPage As TabPage
    Friend WithEvents DeleteSelectedFBNotificationsListviewItems_Button As Button
    Friend WithEvents SaveFBNotificationsListview_Button As Button
    Friend WithEvents ReadFBNotifications_Button As Button
    Friend WithEvents FBNotificationsEditSelectedListviewItem_Button As Button
    Friend WithEvents FBNotificationsAddItemToListview_Button As Button
    Friend WithEvents FBNotificationsDisplayCurrUrl_Button As Button
    Friend WithEvents FBNotificationsNavigateToSelectedURL_Button As Button
    Friend WithEvents FBNotificationsUrl_TextBox As TextBox
    Friend WithEvents FBNotificationsName_TextBox As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents FBNotificationsData_Listview As ListView
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ReadFBNotifications_CheckBox As CheckBox
    Friend WithEvents UnreadFBNotifications_CheckBox As CheckBox
    Friend WithEvents FBRespondNotificationsAssets_TabPage As TabPage
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents FBResponseUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBResponseSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBResponseDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBResponseDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBResponseNewTextFileName_TextBox As TextBox
    Friend WithEvents FBResponseMediaSelector_ListBox As ListBox
    Friend WithEvents FBResponseTextFileSelector_ListBox As ListBox
    Friend WithEvents FBResponseAssetFolder_ListBox As ListBox
    Friend WithEvents FBResponseSaveTextFile_Button As Button
    Friend WithEvents FBResponseCreateNewTextFile_Button As Button
    Friend WithEvents FBResponseDeleteSelectedMedia_Button As Button
    Friend WithEvents FBResponseRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBResponseDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBResponseAssetFolderName_TextBox As TextBox
    Friend WithEvents FBResponseMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBResponseTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBResponseCreateNewAssetFolder_Button As Button
    Friend WithEvents CustomizeScriptInsertion_RadioButton As RadioButton
    Friend WithEvents DefaultScriptInsertion_RadioButton As RadioButton
    Friend WithEvents CustomizeAction_ComboBox As ComboBox
    Friend WithEvents Label55 As Label
    Friend WithEvents DeselecteAllFBGroups_ListViewItems_Button As Button
    Friend WithEvents DeselectAllFBActivityLogs_ListViewItems_Button As Button
    Friend WithEvents DeselecteAllFBNotificationsData_ListviewItems_Button As Button
    Friend WithEvents FBMessengerUrlData_TabPage As TabPage
    Friend WithEvents FBMessengerMessageSource_ComboBox As ComboBox
    Friend WithEvents FBMessengerReadMessage_Button As Button
    Friend WithEvents DeselecteAllFBMessenger_ListviewItems_Button As Button
    Friend WithEvents FBMessengerReadMessage_CheckBox As CheckBox
    Friend WithEvents FBMessengerUnreadMessage_CheckBox As CheckBox
    Friend WithEvents DeleteSelectedFBMessengerListviewItems_Button As Button
    Friend WithEvents SaveFBMessengerListview_Button As Button
    Friend WithEvents FBMessengerNavigateToMessenger_Button As Button
    Friend WithEvents FBMessengerEditSelectedListviewItem_Button As Button
    Friend WithEvents FBMessengerAddItemToListview_Button As Button
    Friend WithEvents FBMessengerDisplayCurrUrl_Button As Button
    Friend WithEvents FBMessengerNavigateToSelectedURL_Button As Button
    Friend WithEvents FBMessengerUrl_TextBox As TextBox
    Friend WithEvents FBMessengerName_TextBox As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents FBMessengerData_Listview As ListView
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents FBMessengerUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBMessengerSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBMessengerDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBMessengerDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBMessengerNewTextFileName_TextBox As TextBox
    Friend WithEvents FBMessengerMediaSelector_ListBox As ListBox
    Friend WithEvents FBMessengerTextFileSelector_ListBox As ListBox
    Friend WithEvents FBMessengerAssetFolder_ListBox As ListBox
    Friend WithEvents FBMessengerSaveTextFile_Button As Button
    Friend WithEvents FBMessengerCreateNewTextFile_Button As Button
    Friend WithEvents FBMessengerDeleteSelectedMedia_Button As Button
    Friend WithEvents FBMessengerRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBMessengerDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBMessengerAssetFolderName_TextBox As TextBox
    Friend WithEvents FBMessengerMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBMessengerTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBMessengerCreateNewAssetFolder_Button As Button
    Friend WithEvents FBStoryAssets_TabPage As TabPage
    Friend WithEvents Label61 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents FBStoryUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBStorySubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBStoryDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBStoryDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBStoryNewTextFileName_TextBox As TextBox
    Friend WithEvents FBStoryMediaSelector_ListBox As ListBox
    Friend WithEvents FBStoryTextFileSelector_ListBox As ListBox
    Friend WithEvents FBStoryAssetFolder_ListBox As ListBox
    Friend WithEvents FBStorySaveTextFile_Button As Button
    Friend WithEvents FBStoryCreateNewTextFile_Button As Button
    Friend WithEvents FBStoryDeleteSelectedMedia_Button As Button
    Friend WithEvents FBStoryRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBStoryDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBStoryAssetFolderName_TextBox As TextBox
    Friend WithEvents FBStoryMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBStoryTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBStoryCreateNewAssetFolder_Button As Button
    Friend WithEvents FBPersonalPostAssets_TabPage As TabPage
    Friend WithEvents Label64 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents FBPersonalPostUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBPersonalPostSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBPersonalPostDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBPersonalPostDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBPersonalPostNewTextFileName_TextBox As TextBox
    Friend WithEvents FBPersonalPostMediaSelector_ListBox As ListBox
    Friend WithEvents FBPersonalPostTextFileSelector_ListBox As ListBox
    Friend WithEvents FBPersonalPostAssetFolder_ListBox As ListBox
    Friend WithEvents FBPersonalPostSaveTextFile_Button As Button
    Friend WithEvents FBPersonalPostCreateNewTextFile_Button As Button
    Friend WithEvents FBPersonalPostDeleteSelectedMedia_Button As Button
    Friend WithEvents FBPersonalPostRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBPersonalPostDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBPersonalPostAssetFolderName_TextBox As TextBox
    Friend WithEvents FBPersonalPostMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBPersonalPostTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBPersonalPostCreateNewAssetFolder_Button As Button
    Friend WithEvents EditScriptFile_Button As Button
    Friend WithEvents FBReelsAssets_TabPage As TabPage
    Friend WithEvents Label67 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents FBReelsUploadWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBReelsSubmitWaitSeconds_NumericUpDown As NumericUpDown
    Friend WithEvents FBReelsDeselectAllAssetFolderListboxItems_Button As Button
    Friend WithEvents FBReelsDeleteSelectedTextFile_Button As Button
    Friend WithEvents FBReelsNewTextFileName_TextBox As TextBox
    Friend WithEvents FBReelsMediaSelector_ListBox As ListBox
    Friend WithEvents FBReelsTextFileSelector_ListBox As ListBox
    Friend WithEvents FBReelsAssetFolder_ListBox As ListBox
    Friend WithEvents FBReelsSaveTextFile_Button As Button
    Friend WithEvents FBReelsCreateNewTextFile_Button As Button
    Friend WithEvents FBReelsDeleteSelectedMedia_Button As Button
    Friend WithEvents FBReelsRevealMediaFoldesrInFileExplorer_Button As Button
    Friend WithEvents FBReelsDeleteSelectedAssetFolder_Button As Button
    Friend WithEvents FBReelsAssetFolderName_TextBox As TextBox
    Friend WithEvents FBReelsMediaPreviewer_PictureBox As PictureBox
    Friend WithEvents FBReelsTextFilePreviewer_RichTextBox As RichTextBox
    Friend WithEvents FBReelsCreateNewAssetFolder_Button As Button
    Friend WithEvents FBMediaDownloaderDownloadMediaResources_Button As Button
    Friend WithEvents FBMediaDownloaderRevealDownloadMediaFolder_Button As Button
    Friend WithEvents SingleMediaAllowed_CheckBox As CheckBox
    Friend WithEvents FBMediaDownloaderUrls_ListView As ListView
    Friend WithEvents FBMediaDownloaderNavigateToUrl_Button As Button
    Friend WithEvents FBImageDownloadUrl_TextBox As TextBox
    Friend WithEvents Label70 As Label
    Friend WithEvents FBImageDownloadGetMediaResourcesUrl_Button As Button
    Friend WithEvents FBMediaDownloaderNextMediaCount_NumericUpDown As NumericUpDown
    Friend WithEvents Label71 As Label
    Friend WithEvents FBMediaDownloaderGetUrl_Button As Button
    Friend WithEvents FBMediaDownloader_TabPage As TabPage
    Friend WithEvents MediaResourceUrl_ColumnHeader As ColumnHeader
    Friend WithEvents DevTool_TabPage As TabPage
    Friend WithEvents Label72 As Label
    Friend WithEvents DevTool_CssSelectorInput_TextBox As TextBox
    Friend WithEvents DevTool_ClickElementByCssSelector_Button As Button
    Friend WithEvents DevTool_ResultOutput_RichTextBox As RichTextBox
    Friend WithEvents DevTool_FindElementByCssSelector_Button As Button
    Friend WithEvents Label73 As Label
    Friend WithEvents DevTool_ClearOutputRichTextBox_Button As Button
    Friend WithEvents SwapScriptQueueListViewItems_Button As Button

End Class
