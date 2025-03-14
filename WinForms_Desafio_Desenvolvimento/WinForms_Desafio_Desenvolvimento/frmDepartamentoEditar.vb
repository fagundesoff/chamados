Public Class frmDepartamentoEditar

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


    End Sub
    Public Sub AbrirDespartamento(ByVal idDespartamento As Integer)

        Dim drDespartamento As DataRow = Dados.ObterDepartamento(idDespartamento)

        Me.txtID.Text = CInt(drDespartamento("ID")).ToString()
        Me.txtDescricao.Text = CStr(drDespartamento("Descricao"))


    End Sub
    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim ID As Integer = Integer.Parse(Me.txtID.Text)
        Dim Assunto As String = Me.txtDescricao.Text

        Dim sucesso As Boolean = Dados.GravaDepartamento(ID, Assunto)

        If Not sucesso Then

            MessageBox.Show(Me, "Falha ao gravar o Departamento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel

        Else
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If


    End Sub

End Class