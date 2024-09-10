Imports System.IO
Imports Newtonsoft.Json

Public Class FBMarketplaceEventHandlers


    Public Sub CreateNewMarketplaceAssetFolder_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName As String = Form1.NewMarketplaceAssetFolderName_TextBox.Text
            Dim folderPath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) And Not folderName.Contains("&"c) Then
                Directory.CreateDirectory(folderPath)
                Directory.CreateDirectory(Path.Combine(folderPath, "media"))
                UpdateMarketplaceAssetsFolderListBox()

                '新增後直接選擇該資料夾
                Form1.FBMarkplaceProducts_ListBox.SelectedItem = folderName
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try


    End Sub


    Public Sub RevealFBMarketplaceMediaFoldesrInFileExplorer_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBMarkplaceProducts_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                For Each item In selectedItems
                    Dim folderPath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, item, "media")
                    Process.Start("explorer.exe", folderPath)
                Next
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Shared Sub UpdateMarketplaceAssetsFolderListBox()
        Try
            Form1.FBMarkplaceProducts_ListBox.Items.Clear()

            Dim dirs As String() = Directory.GetDirectories(AppInitModule.FBMarketPlaceAssetsDirectory)
            For Each dir As String In dirs
                Form1.FBMarkplaceProducts_ListBox.Items.Add(Path.GetFileName(dir))
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub



    Public Sub FBMarketplaceSavePruductInfo_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedItems = Form1.FBMarkplaceProducts_ListBox.SelectedItems

            If selectedItems.Count > 0 Then


                Dim product As New FBMarketPlaceProduct() With {
                    .Name = Form1.FBMarketplaceProductName_TextBox.Text,
                    .Price = Form1.FBMarketplaceProductPrice_NumericUpDown.Value,
                    .Description = Form1.FBMarketplaceProductDescription_RichTextBox.Text,
                    .Status = Form1.FBMarketplaceProductStatus_NumericUpDown.Text,
                    .Tags = Split(Form1.FBMarketplaceProductTag_TextBox.Text, ","),
                    .Location = Form1.FBMarketplaceProductLocation_TextBox.Text,
                    .OnMarketplace = Form1.FBMarketplaceOnMarketplace_CheckBox.Checked,
                    .MeetInPerson = Form1.FBMarketplaceMeetInPerson_CheckBox.Checked,
                    .PickUp = Form1.FBMarketplacePickUp_CheckBox.Checked,
                    .HomeDelivery = Form1.FBMarketplaceHomeDelivery_CheckBox.Checked,
                    .NumberOfGroupsShared = Form1.FBMarketplaceShareGroupsCount_NumericUpDown.Value,
                    .RandomShare = Form1.FBMarketplaceShareGroupsByRandom_RadioButton.Checked
                }

                Dim jsonString As String = JsonConvert.SerializeObject(product, Formatting.Indented)

                ' 指定檔案路徑
                Dim filePath As String = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, selectedItems(0), "ProductInformation.json")

                ' 將 JSON 字串寫入檔案
                File.WriteAllText(filePath, jsonString)



                For Each item In selectedItems
                    Dim configFilePath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, item, "MarketplaceWaitSecondsConfig.txt")
                    Dim myConfig As String = Form1.FBMarketplaceUploadWaitSeconds_NumericUpDown.Value & "," & Form1.FBMarketplaceSubmitWaitSeconds_NumericUpDown.Value
                    File.WriteAllText(configFilePath, myConfig)
                Next
            Else
                MsgBox("未選擇資料夾")
            End If


            MsgBox("儲存成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("儲存失敗")
        End Try
    End Sub


    Public Sub MarkplaceProducts_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            ClearFBMarketplaceProductInformation()
            Dim selectedItem = Form1.FBMarkplaceProducts_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                DisplayFBMarketPlaceWaitSeconds(selectedItem)
                DisplayFBMarketplaceProductInformation(selectedItem)
                UpdateFBMarketplaceMediaListbox(selectedItem)
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("讀取商品錯誤")
        End Try

    End Sub

    Private Sub DisplayFBMarketplaceProductInformation(folderName)
        Try
            Dim filePath As String = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName, "ProductInformation.json")

            If File.Exists(filePath) Then
                Dim jsonString As String = File.ReadAllText(filePath)
                Dim product As FBMarketPlaceProduct = JsonConvert.DeserializeObject(Of FBMarketPlaceProduct)(jsonString)

                Form1.FBMarketplaceProductName_TextBox.Text = product.Name
                Form1.FBMarketplaceProductPrice_NumericUpDown.Value = product.Price
                Form1.FBMarketplaceProductDescription_RichTextBox.Text = product.Description
                Form1.FBMarketplaceProductStatus_NumericUpDown.Text = product.Status
                Form1.FBMarketplaceProductLocation_TextBox.Text = product.Location
                Form1.FBMarketplaceProductTag_TextBox.Text = String.Join(",", product.Tags)
                Form1.FBMarketplaceOnMarketplace_CheckBox.Checked = product.OnMarketplace
                Form1.FBMarketplaceMeetInPerson_CheckBox.Checked = product.MeetInPerson
                Form1.FBMarketplacePickUp_CheckBox.Checked = product.PickUp
                Form1.FBMarketplaceHomeDelivery_CheckBox.Checked = product.HomeDelivery
                Form1.FBMarketplaceShareGroupsCount_NumericUpDown.Value = product.NumberOfGroupsShared
                Form1.FBMarketplaceShareGroupsByRandom_RadioButton.Checked = product.RandomShare

            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Shared Function GetProduct(folderName As String) As FBMarketPlaceProduct
        Try
            Dim product As FBMarketPlaceProduct = Nothing
            Dim filePath As String = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName, "ProductInformation.json")

            ' 檢查檔案是否存在
            If File.Exists(filePath) Then
                Dim jsonString As String = File.ReadAllText(filePath)
                product = JsonConvert.DeserializeObject(Of FBMarketPlaceProduct)(jsonString)
            End If
            Return product
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return Nothing
        End Try
    End Function


    Private Sub DisplayFBMarketPlaceWaitSeconds(folderName)
        Try
            Dim configFilePath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName, "MarketplaceWaitSecondsConfig.txt")
            If File.Exists(configFilePath) Then
                Dim myText = File.ReadAllText(configFilePath)
                Form1.FBMarketplaceUploadWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(0))
                Form1.FBMarketplaceSubmitWaitSeconds_NumericUpDown.Value = CInt(Split(myText, ",")(1))

            Else
                File.WriteAllText(configFilePath, "30,30")
                Form1.FBMarketplaceUploadWaitSeconds_NumericUpDown.Value = 30
                Form1.FBMarketplaceSubmitWaitSeconds_NumericUpDown.Value = 30
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Private Sub UpdateFBMarketplaceMediaListbox(folderName)
        Try
            Form1.FBMarketplaceMediaSelector_ListBox.Items.Clear()
            Form1.FBMarketplaceMediaPreviewer_PictureBox.ImageLocation = Nothing
            Dim mediaFolder = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName, "media")
            If Directory.Exists(mediaFolder) Then
                Dim allowedExtension As String() = {".WEBP", ".webp", ".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG"}
                Dim mediaFiles As String() = Directory.GetFiles(mediaFolder)
                For Each file As String In mediaFiles
                    If allowedExtension.Contains(Path.GetExtension(file)) Then
                        Form1.FBMarketplaceMediaSelector_ListBox.Items.Add(Path.GetFileName(file))
                    End If

                Next
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub


    Public Sub FBMarketplaceMediaSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim selectedItem = Form1.FBMarketplaceMediaSelector_ListBox.SelectedItem
            If selectedItem IsNot Nothing Then
                Dim filePath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, Form1.FBMarkplaceProducts_ListBox.SelectedItem, "media", selectedItem)
                Form1.FBMarketplaceMediaPreviewer_PictureBox.ImageLocation = filePath
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub



    Private Sub ClearFBMarketplaceProductInformation()
        Form1.FBMarketplaceProductName_TextBox.Clear()
        Form1.FBMarketplaceProductPrice_NumericUpDown.Value = 0
        Form1.FBMarketplaceProductDescription_RichTextBox.Clear()
        Form1.FBMarketplaceProductStatus_NumericUpDown.Text = ""
        Form1.FBMarketplaceProductLocation_TextBox.Clear()
        Form1.FBMarketplaceProductTag_TextBox.Clear()
        Form1.FBMarketplaceOnMarketplace_CheckBox.Checked = False
        Form1.FBMarketplaceMeetInPerson_CheckBox.Checked = False
        Form1.FBMarketplacePickUp_CheckBox.Checked = False
        Form1.FBMarketplaceHomeDelivery_CheckBox.Checked = False
        Form1.FBMarketplaceMediaPreviewer_PictureBox.ImageLocation = Nothing
        Form1.FBMarketplaceUploadWaitSeconds_NumericUpDown.Value = 0
        Form1.FBMarketplaceSubmitWaitSeconds_NumericUpDown.Value = 0
        Form1.FBMarketplaceMediaSelector_ListBox.Items.Clear()
        Form1.FBMarketplaceShareGroupsCount_NumericUpDown.Value = 0
        Form1.FBMarketplaceShareGroupsByRandom_RadioButton.Checked = False
        Form1.FBMarketplaceShareGroupsBySequence_RadioButton.Checked = True

    End Sub

    Public Sub FBmarketplaceDeselectAllProductFolderListboxItems_Button_Click(sender As Object, e As EventArgs)
        Form1.FBMarkplaceProducts_ListBox.ClearSelected()
        ClearFBMarketplaceProductInformation()
    End Sub


    Public Sub FBMarketplaceShareGroupsBySequence_RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        If Form1.FBMarketplaceShareGroupsBySequence_RadioButton.Checked Then
            Form1.FBMarketplaceShareGroupsByRandom_RadioButton.Checked = False
        End If
    End Sub

    Public Sub FBMarketplaceShareGroupsByRandom_RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        If Form1.FBMarketplaceShareGroupsByRandom_RadioButton.Checked Then
            Form1.FBMarketplaceShareGroupsBySequence_RadioButton.Checked = False
        End If
    End Sub

    Public Sub FBMarketplaceDeleteSelectedAssetFolder_Button_Click(sender As Object, e As EventArgs)
        Try

            Dim selectedItems = Form1.FBMarkplaceProducts_ListBox.SelectedItems

            If selectedItems.Count > 0 Then
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In selectedItems
                        Dim folderPath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdateMarketplaceAssetsFolderListBox()
                    MsgBox("刪除完成")
                End If
            Else
                ' 刪除全部資料夾
                'MsgBox("未選擇要刪除的資料夾")
                ' 刪除所選
                Dim result As DialogResult = MessageBox.Show("確定要刪除全部資料夾嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then

                    For Each item In Form1.FBMarkplaceProducts_ListBox.Items
                        Dim folderPath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, item)
                        Directory.Delete(folderPath, True)
                    Next
                    UpdateMarketplaceAssetsFolderListBox()

                    MsgBox("刪除完成")
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("刪除失敗")
        End Try
    End Sub


    Public Sub FBMarketplaceDeleteSelectedMedia_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim selectedFBMarkplaceProduct = Form1.FBMarkplaceProducts_ListBox.SelectedItem
            If selectedFBMarkplaceProduct IsNot Nothing Then
                Dim selectedItems = Form1.FBMarketplaceMediaSelector_ListBox.SelectedItems
                If selectedItems.Count > 0 Then
                    ' 刪除所選
                    Dim result As DialogResult = MessageBox.Show("確定要刪除檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        For Each item In selectedItems
                            Dim filePath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, Form1.FBMarkplaceProducts_ListBox.SelectedItem, "media", item)
                            File.Delete(filePath)
                        Next
                    End If

                Else
                    ' 刪除全部
                    'MsgBox("未選擇要刪除的檔案")
                    Dim result As DialogResult = MessageBox.Show("確定要刪除全部檔案嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        For Each item In Form1.FBMarketplaceMediaSelector_ListBox.Items
                            Dim filePath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, Form1.FBMarkplaceProducts_ListBox.SelectedItem, "media", item)
                            File.Delete(filePath)
                        Next
                    End If

                End If

                UpdateFBMarketplaceMediaListbox(selectedFBMarkplaceProduct)
            Else
                MsgBox("未選擇資料夾")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Class FBMarketPlaceProduct
        Public Property Name As String
        Public Property Price As Integer
        Public Property Description As String
        Public Property Status As String
        Public Property Tags As String()
        Public Property Location As String
        Public Property Transaction As String()
        Public Property OnMarketplace As Boolean
        Public Property MeetInPerson As Boolean
        Public Property PickUp As Boolean
        Public Property HomeDelivery As Boolean
        Public Property NumberOfGroupsShared As Integer
        Public Property RandomShare As Boolean

    End Class

End Class
