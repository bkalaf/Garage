Namespace UserControls947
    Partial Public Class HeaderControl
        Inherits System.Web.UI.UserControl
        Private _title As String
        Private strFor As String

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


            TitleLabel.Text = _title ' "Commercial Transportation Quote Sheet
            lblFor.Text = strFor
        End Sub
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property
        Public Property AvailableFor() As String
            Get
                Return strFor
            End Get
            Set(ByVal value As String)
                strFor = value
            End Set
        End Property
    End Class
End Namespace

