﻿Imports System.Data
Imports System.Windows.Forms

Public Class frmDepartamentosListar

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        carregagrid()
    End Sub

    Public Sub carregagrid()

        Dim dtDepartamentos As DataTable = Dados.ListarDepartamentos()
        Me.dgvDepartamentos.DataSource = dtDepartamentos
    End Sub
    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If Me.dgvDepartamentos.SelectedRows.Count = 0 Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idDepartamento As Integer = CInt(drv("ID"))

        Dim dlgResult As DialogResult =
            MessageBox.Show(Me, $"Confirma a exclusão do Departamento nº {idDepartamento} ?",
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgResult <> DialogResult.Yes Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim sucesso As Boolean = Dados.ExcluirDepartamento(idDepartamento)

        If sucesso Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If Me.dgvDepartamentos.SelectedRows.Count = 0 Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idDepartamento As Integer = CInt(drv("ID"))

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim frm As New frmDepartamentoEditar()
        frm.AbrirDespartamento(idDepartamento)

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Dim frm As New frmDepartamentoEditar()

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult <> DialogResult.OK Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click

        Dim frm As New frmDepartamentosRelatorio()
        frm.ShowDialog()

    End Sub


    Private Sub dgvDepartamentos_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDepartamentos.CellMouseDoubleClick
        If Me.dgvDepartamentos.SelectedRows.Count = 0 Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idDepartamento As Integer = CInt(drv("ID"))

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim frm As New frmDepartamentoEditar()
        frm.AbrirDespartamento(idDepartamento)

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If
    End Sub
End Class
