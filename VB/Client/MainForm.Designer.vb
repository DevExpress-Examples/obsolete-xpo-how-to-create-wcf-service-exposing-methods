Imports Microsoft.VisualBasic
Imports System
Namespace DXSample.Client
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim dataGridViewCellStyle2 As New System.Windows.Forms.DataGridViewCellStyle()
			Me.uow = New DevExpress.Xpo.UnitOfWork()
			Me.dataGridView1 = New System.Windows.Forms.DataGridView()
			Me.nameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.xpCollection1 = New DevExpress.Xpo.XPCollection()
			Me.dataGridView2 = New System.Windows.Forms.DataGridView()
			Me.orderNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.orderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button1 = New System.Windows.Forms.Button()
			CType(Me.uow, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.splitContainer1.Panel1.SuspendLayout()
			Me.splitContainer1.Panel2.SuspendLayout()
			Me.splitContainer1.SuspendLayout()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' dataGridView1
			' 
			Me.dataGridView1.AutoGenerateColumns = False
			Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.nameDataGridViewTextBoxColumn, Me.ageDataGridViewTextBoxColumn})
			Me.dataGridView1.DataSource = Me.xpCollection1
			Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
			Me.dataGridView1.Name = "dataGridView1"
			Me.dataGridView1.Size = New System.Drawing.Size(244, 238)
			Me.dataGridView1.TabIndex = 0
			' 
			' nameDataGridViewTextBoxColumn
			' 
			Me.nameDataGridViewTextBoxColumn.DataPropertyName = "Name"
			Me.nameDataGridViewTextBoxColumn.HeaderText = "Name"
			Me.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn"
			' 
			' ageDataGridViewTextBoxColumn
			' 
			Me.ageDataGridViewTextBoxColumn.DataPropertyName = "Age"
			Me.ageDataGridViewTextBoxColumn.HeaderText = "Age"
			Me.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn"
			' 
			' xpCollection1
			' 
			Me.xpCollection1.DeleteObjectOnRemove = True
			Me.xpCollection1.DisplayableProperties = "Name;Age;Orders"
			Me.xpCollection1.ObjectType = GetType(DXSample.PersistentClasses.Customer)
			Me.xpCollection1.Session = Me.uow
			' 
			' dataGridView2
			' 
			Me.dataGridView2.AutoGenerateColumns = False
			Me.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.orderNameDataGridViewTextBoxColumn, Me.orderDateDataGridViewTextBoxColumn})
			Me.dataGridView2.DataMember = "Orders"
			Me.dataGridView2.DataSource = Me.xpCollection1
			Me.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dataGridView2.Location = New System.Drawing.Point(0, 0)
			Me.dataGridView2.Name = "dataGridView2"
			Me.dataGridView2.Size = New System.Drawing.Size(246, 238)
			Me.dataGridView2.TabIndex = 1
'			Me.dataGridView2.DefaultValuesNeeded += New System.Windows.Forms.DataGridViewRowEventHandler(Me.dataGridView2_DefaultValuesNeeded);
			' 
			' orderNameDataGridViewTextBoxColumn
			' 
			Me.orderNameDataGridViewTextBoxColumn.DataPropertyName = "OrderName"
			Me.orderNameDataGridViewTextBoxColumn.HeaderText = "Order Name"
			Me.orderNameDataGridViewTextBoxColumn.Name = "orderNameDataGridViewTextBoxColumn"
			' 
			' orderDateDataGridViewTextBoxColumn
			' 
			Me.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate"
			dataGridViewCellStyle2.Format = "d"
			dataGridViewCellStyle2.NullValue = Nothing
			Me.orderDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2
			Me.orderDateDataGridViewTextBoxColumn.HeaderText = "Order Date"
			Me.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn"
			Me.orderDateDataGridViewTextBoxColumn.ReadOnly = True
			' 
			' dataGridViewTextBoxColumn1
			' 
			Me.dataGridViewTextBoxColumn1.DataPropertyName = "This"
			Me.dataGridViewTextBoxColumn1.HeaderText = "This"
			Me.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1"
			Me.dataGridViewTextBoxColumn1.ReadOnly = True
			' 
			' splitContainer1
			' 
			Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
			Me.splitContainer1.Name = "splitContainer1"
			' 
			' splitContainer1.Panel1
			' 
			Me.splitContainer1.Panel1.Controls.Add(Me.dataGridView1)
			' 
			' splitContainer1.Panel2
			' 
			Me.splitContainer1.Panel2.Controls.Add(Me.dataGridView2)
			Me.splitContainer1.Size = New System.Drawing.Size(494, 238)
			Me.splitContainer1.SplitterDistance = 244
			Me.splitContainer1.TabIndex = 2
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.button2)
			Me.panel1.Controls.Add(Me.button1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 238)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(494, 30)
			Me.panel1.TabIndex = 1
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(84, 3)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(75, 23)
			Me.button2.TabIndex = 2
			Me.button2.Text = "Reload"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(3, 3)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(75, 23)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Update"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(494, 268)
			Me.Controls.Add(Me.splitContainer1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "MainForm"
			Me.Text = "Dx Sample"
			CType(Me.uow, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.splitContainer1.Panel1.ResumeLayout(False)
			Me.splitContainer1.Panel2.ResumeLayout(False)
			Me.splitContainer1.ResumeLayout(False)
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private xpCollection1 As DevExpress.Xpo.XPCollection
		Private uow As DevExpress.Xpo.UnitOfWork
		Private dataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
		Private dataGridView1 As System.Windows.Forms.DataGridView
		Private nameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
		Private ageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
		Private WithEvents dataGridView2 As System.Windows.Forms.DataGridView
		Private splitContainer1 As System.Windows.Forms.SplitContainer
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents button2 As System.Windows.Forms.Button
		Private WithEvents button1 As System.Windows.Forms.Button
		Private orderNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
		Private orderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

	End Class
End Namespace