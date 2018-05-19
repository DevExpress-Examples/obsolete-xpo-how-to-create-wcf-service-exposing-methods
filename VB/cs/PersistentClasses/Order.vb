Imports Microsoft.VisualBasic
Imports DevExpress.Xpo
Imports System

Namespace DXSample.PersistentClasses
	Public Class Order
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fOrderName As String
		Public Property OrderName() As String
			Get
				Return fOrderName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("OrderName", fOrderName, value)
			End Set
		End Property

		Private fOrderDate As DateTime
		Public Property OrderDate() As DateTime
			Get
				Return fOrderDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("OrderDate", fOrderDate, value)
			End Set
		End Property

		Private fCustomer As Customer
		<Association("Customer-Orders")> _
		Public Property Customer() As Customer
			Get
				Return fCustomer
			End Get
			Set(ByVal value As Customer)
				SetPropertyValue(Of Customer)("Customer", fCustomer, value)
			End Set
		End Property
	End Class
End Namespace