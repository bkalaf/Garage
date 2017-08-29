
Partial Class MVRUploadsaspx
    Inherits System.Web.UI.UserControl
    'Implements ISubscriber
    Dim strName As String = "MVR Uploads"

    Dim Valid As Boolean = False
    Sub Update()
        '   i()
        If upl1.FileName.ToString().Contains("pdf") And upl2.FileName.ToString().Contains("pdf") And upl3.FileName.ToString().Contains("pdf") And upl4.FileName.ToString().Contains("pdf") And upl5.FileName.ToString().Contains("pdf") Then
            Valid = True
        End If

    End Sub

End Class
