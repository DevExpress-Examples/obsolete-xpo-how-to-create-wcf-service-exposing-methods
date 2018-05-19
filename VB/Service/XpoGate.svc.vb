Imports Microsoft.VisualBasic
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.ServiceModel
Imports System.Configuration
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.Xpo.DB.Exceptions
Imports System

Namespace DXSample.Service
	Public Class XpoGate
		Implements IXpoGate
		Private Shared dataStore As ICacheToCacheCommunicationCore

		Shared Sub New()
			Dim conn As String = ConfigurationManager.ConnectionStrings("XpoConnection").ConnectionString
			dataStore = New DataCacheRoot(XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None))
		End Sub

		#Region "IXpoGate Members"

		Private Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements IXpoGate.ModifyData
			Try
				Return dataStore.ModifyData(cookie, dmlStatements)
			Catch ex As LockingException
				Throw New FaultException(Of LockingException)(ex)
			End Try
		End Function

		Private Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult Implements IXpoGate.NotifyDirtyTables
			Return dataStore.NotifyDirtyTables(cookie, dirtyTablesNames)
		End Function

		Private Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult Implements IXpoGate.ProcessCookie
			Return dataStore.ProcessCookie(cookie)
		End Function

		Private Function IXpoGate_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements IXpoGate.SelectData
			Return dataStore.SelectData(cookie, selects)
		End Function

		#End Region
	End Class
End Namespace
