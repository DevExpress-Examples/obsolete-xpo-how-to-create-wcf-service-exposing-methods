Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo.DB.Exceptions
Imports DevExpress.Data.Filtering

Namespace DXSample.Client
	Partial Public Class MainForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Try
				uow.CommitChanges()
			Catch e1 As LockingException
				MessageBox.Show(Me, "Data was modified by another user. Please reload data.", "Dx Sample", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			End Try
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			uow.ReloadChangedObjects()
		End Sub

		Private Sub dataGridView2_DefaultValuesNeeded(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles dataGridView2.DefaultValuesNeeded
			e.Row.SetValues(Nothing, DateTime.Now)
		End Sub
	End Class
End Namespace
