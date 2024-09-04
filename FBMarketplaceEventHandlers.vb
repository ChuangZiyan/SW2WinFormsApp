Imports System.IO

Public Class FBMarketplaceEventHandlers


    Public Sub CreateNewMarketplaceAssetFolder_Button_Click(sender As Object, e As EventArgs)

        Try
            Dim folderName As String = Form1.NewMarketplaceAssetFolderName_TextBox.Text
            Dim folderPath = Path.Combine(AppInitModule.FBMarketPlaceAssetsDirectory, folderName)

            If Not Directory.Exists(folderPath) And Not folderName.Contains("&"c) Then
                Directory.CreateDirectory(folderPath)

                UpdateMarketplaceAssetsFolderListBox()

                '新增後直接選擇該資料夾
                Form1.MarkplaceProducts_ListBox.SelectedItem = folderName
                'MsgBox("新增成功")
            Else
                MsgBox("無法使用此名稱")
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


    Public Shared Sub UpdateMarketplaceAssetsFolderListBox()
        Try
            Form1.MarkplaceProducts_ListBox.Items.Clear()

            Dim dirs As String() = Directory.GetDirectories(AppInitModule.FBMarketPlaceAssetsDirectory)
            For Each dir As String In dirs
                Form1.MarkplaceProducts_ListBox.Items.Add(Path.GetFileName(dir))
            Next

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub



End Class
