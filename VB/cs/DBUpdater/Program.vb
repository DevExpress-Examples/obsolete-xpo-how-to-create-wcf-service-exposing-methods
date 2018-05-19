Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Configuration
Imports DXSample.PersistentClasses

Namespace DXSample.DBUpdater
	Friend NotInheritable Class Program
		Private Sub New()
		End Sub
		Shared Sub Main(ByVal args() As String)
			Dim dal As IDataLayer = XpoDefault.GetDataLayer(ConfigurationManager.ConnectionStrings("XpoConnection").ConnectionString, AutoCreateOption.DatabaseAndSchema)
			Dim uow As New UnitOfWork(dal)
			uow.UpdateSchema(GetType(Customer).Assembly)
			uow.CreateObjectTypeRecords(GetType(Customer).Assembly)
			uow.Delete(New XPCollection(Of Customer)(uow))
			uow.Delete(New XPCollection(Of Order)(uow))
			uow.CommitChanges()
			uow.PurgeDeletedObjects()
			Dim john As New Customer(uow) With {.Name = "John", .Age = 27}
			Dim bob As New Customer(uow) With {.Name = "Bob", .Age = 31}
            Dim TempOrder As Order = New Order(uow) With { _
              .OrderDate = New DateTime(2011, 1, 7), .Customer = john, _
             .OrderName = "Chai"}
            TempOrder = New Order(uow) With { _
                .OrderDate = New DateTime(2011, 1, 8), .Customer = john, _
                .OrderName = "Chang"}
            TempOrder = New Order(uow) With { _
             .OrderDate = New DateTime(2011, 1, 9), .Customer = bob, _
             .OrderName = "Queso Caprale"}
			uow.CommitChanges()
		End Sub
	End Class
End Namespace