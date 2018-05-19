Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo.DB
Imports System.Diagnostics
Imports System.ServiceModel
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.Xpo.DB.Exceptions
Imports System.ServiceModel.Channels

Namespace DXSample.DataStore
	<DebuggerStepThrough> _
	Partial Public Class CachingWCFServiceDataStore
		Inherits ClientBase(Of IXpoGate)
		Implements ICachedDataStore

		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal endpointConfigurationName As String)
			MyBase.New(endpointConfigurationName)
		End Sub

		Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
			MyBase.New(endpointConfigurationName, remoteAddress)
		End Sub

		Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As EndpointAddress)
			MyBase.New(endpointConfigurationName, remoteAddress)
		End Sub

		Public Sub New(ByVal binding As Binding, ByVal remoteAddress As EndpointAddress)
			MyBase.New(binding, remoteAddress)
		End Sub

		Private Shared Sub PatchParameters(ByVal statements() As JoinNode)
			For Each statement As JoinNode In statements
				statement.Condition = CriteriaPatcher.Patch(statement.Condition)
			Next statement
		End Sub

		#Region "ICacheToCacheCommunicationCore Members"

		Private Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements ICacheToCacheCommunicationCore.ModifyData
			Try
				PatchParameters(dmlStatements)
				Return Channel.ModifyData(cookie, dmlStatements)
			Catch ex As FaultException(Of LockingException)
				Throw ex.Detail
			End Try
		End Function

		Private Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult Implements ICacheToCacheCommunicationCore.NotifyDirtyTables
			Return Channel.NotifyDirtyTables(cookie, dirtyTablesNames)
		End Function

		Private Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult Implements ICacheToCacheCommunicationCore.ProcessCookie
			Return Channel.ProcessCookie(cookie)
		End Function

		Private Function ICacheToCacheCommunicationCore_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements ICacheToCacheCommunicationCore.SelectData
			PatchParameters(selects)
			Return Channel.SelectData(cookie, selects)
		End Function

		Private Function ICacheToCacheCommunicationCore_UpdateSchema(ByVal cookie As DataCacheCookie, ByVal tables() As DBTable, ByVal dontCreateIfFirstTableNotExist As Boolean) As DataCacheUpdateSchemaResult Implements ICacheToCacheCommunicationCore.UpdateSchema
			Throw New NotSupportedException("Database schema modifications not allowed")
		End Function

		#End Region

		#Region "IDataStore Members"

		Private ReadOnly Property IDataStore_AutoCreateOption() As AutoCreateOption Implements IDataStore.AutoCreateOption
			Get
				Return AutoCreateOption.SchemaAlreadyExists
			End Get
		End Property

		Private Function ModifyData(ParamArray ByVal dmlStatements() As ModificationStatement) As ModificationResult Implements IDataStore.ModifyData
			Try
				Return Channel.ModifyData(DataCacheCookie.Empty, dmlStatements).ModificationResult
			Catch ex As FaultException(Of LockingException)
				Throw ex.Detail
			End Try
		End Function

		Private Function SelectData(ParamArray ByVal selects() As SelectStatement) As SelectedData Implements IDataStore.SelectData
			Return Channel.SelectData(DataCacheCookie.Empty, selects).SelectedData
		End Function

		Private Function IDataStore_UpdateSchema(ByVal dontCreateIfFirstTableNotExist As Boolean, ParamArray ByVal tables() As DBTable) As UpdateSchemaResult Implements IDataStore.UpdateSchema
			Throw New NotSupportedException("Database schema modifications not allowed")
		End Function

		#End Region
	End Class
End Namespace
