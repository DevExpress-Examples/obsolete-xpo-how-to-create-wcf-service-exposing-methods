<!-- default file list -->
*Files to look at*:

* [Program.cs](./CS/Client/Program.cs) (VB: [Program.vb](./VB/Client/Program.vb))
* [CachingWCFServiceDataStore.cs](./CS/DataStore/CachingWCFServiceDataStore.cs) (VB: [CachingWCFServiceDataStore.vb](./VB/DataStore/CachingWCFServiceDataStore.vb))
* [CriteriaPatcher.cs](./CS/DataStore/CriteriaPatcher.cs) (VB: [CriteriaPatcher.vb](./VB/DataStore/CriteriaPatcher.vb))
* [IXpoGate.cs](./CS/DataStore/IXpoGate.cs) (VB: [IXpoGate.vb](./VB/DataStore/IXpoGate.vb))
* [IXpoGate.cs](./CS/Service/IXpoGate.cs) (VB: [IXpoGate.vb](./VB/Service/IXpoGate.vb))
* [XpoGate.svc.cs](./CS/Service/XpoGate.svc.cs) (VB: [XpoGate.svc.vb](./VB/Service/XpoGate.svc.vb))
<!-- default file list end -->
# OBSOLETE - How to create WCF service exposing methods necessary to implement the ICacheToCahceCommunicationCore interface


<p><strong>This example is obsolete:</strong> Use proprietary <a href="http://documentation.devexpress.com/#XPO/clsDevExpressXpoDBCachedDataStoreServicetopic"><u>CachedDataStoreService</u></a> and <a href="http://documentation.devexpress.com/#XPO/clsDevExpressXpoDBCachedDataStoreClienttopic"><u>CachedDataStoreClient</u></a> classes. See <a href="http://documentation.devexpress.com/#XPO/CustomDocument10018"><u>Transferring Data via WCF Services</u></a> help topic for more details.<br />
___________________________________________________________________________________________________________________________________________________________________</p><p>To take advantage of Data Layer Caching feature, WCF service should expose these four methods:</p>

```cs
DataCacheModificationResult ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements); <newline/>
DataCacheResult NotifyDirtyTables(DataCacheCookie cookie, params string[] dirtyTablesNames); <newline/>
DataCacheResult ProcessCookie(DataCacheCookie cookie); <newline/>
DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement[] selects);
```



```vb
DataCacheModificationResult ModifyData(DataCacheCookie cookie, ModificationStatement() dmlStatements)<newline/>
DataCacheResult NotifyDirtyTables(DataCacheCookie cookie, params String() dirtyTablesNames)<newline/>
DataCacheResult ProcessCookie(DataCacheCookie cookie)<newline/>
DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement() selects)
```

<p>In addition, it is necessary to add to service known types for SelectData and ModifyData methods for all classes listed in the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressDataFilteringCriteriaOperatorHierarchyTopic"><u>CriteriaOperator Hierarchy</u></a> document. All classes listed in the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXpoDBModificationStatementHierarchyTopic"><u>ModificationStatement Hierarchy</u></a> document should be added to service known types for the ModifyData method. In addition add the QuerySubQueryContainer class to service known types.</p><p>To support the Optimistic Concurrency Control feature, it is necessary to pass the LockingException exception to the client, when it is thrown within the ModifyData method. For this purpose, the FaultContractAttribute attribute should be applied to the ModifyData method, and the LockingException should be specified as the detail type.</p><p>Taking all the above into account, the service contract should look as demonstrated in the code below:</p>

```cs
[ServiceContract(Namespace="http://devexpress.example.com")]<newline/>
public interface IXpoGate {<newline/>
   [OperationContract, FaultContract(typeof(LockingException))]<newline/>
   [ServiceKnownType(typeof(DeleteStatement))]<newline/>
   [ServiceKnownType(typeof(InsertStatement))]<newline/>
   [ServiceKnownType(typeof(UpdateStatement))]<newline/>
   [ServiceKnownType(typeof(AggregateOperand))]<newline/>
   [ServiceKnownType(typeof(BetweenOperator))]<newline/>
   [ServiceKnownType(typeof(BinaryOperator))]<newline/>
   [ServiceKnownType(typeof(ContainsOperator))]<newline/>
   [ServiceKnownType(typeof(FunctionOperator))]<newline/>
   [ServiceKnownType(typeof(GroupOperator))]<newline/>
   [ServiceKnownType(typeof(InOperator))]<newline/>
   [ServiceKnownType(typeof(NotOperator))]<newline/>
   [ServiceKnownType(typeof(NullOperator))]<newline/>
   [ServiceKnownType(typeof(OperandProperty))]<newline/>
   [ServiceKnownType(typeof(OperandValue))]<newline/>
   [ServiceKnownType(typeof(ParameterValue))]<newline/>
   [ServiceKnownType(typeof(QueryOperand))]<newline/>
   [ServiceKnownType(typeof(UnaryOperator))]<newline/>
   [ServiceKnownType(typeof(JoinOperand))]<newline/>
   [ServiceKnownType(typeof(OperandParameter))]<newline/>
   [ServiceKnownType(typeof(QuerySubQueryContainer))]<newline/>
   DataCacheModificationResult ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements);<newline/>
   [OperationContract]<newline/>
   DataCacheResult NotifyDirtyTables(DataCacheCookie cookie, params string[] dirtyTablesNames);<newline/>
   [OperationContract]<newline/>
   DataCacheResult ProcessCookie(DataCacheCookie cookie);<newline/>
   [OperationContract]<newline/>
   [ServiceKnownType(typeof(AggregateOperand))]<newline/>
   [ServiceKnownType(typeof(BetweenOperator))]<newline/>
   [ServiceKnownType(typeof(BinaryOperator))]<newline/>
   [ServiceKnownType(typeof(ContainsOperator))]<newline/>
   [ServiceKnownType(typeof(FunctionOperator))]<newline/>
   [ServiceKnownType(typeof(GroupOperator))]<newline/>
   [ServiceKnownType(typeof(InOperator))]<newline/>
   [ServiceKnownType(typeof(NotOperator))]<newline/>
   [ServiceKnownType(typeof(NullOperator))]<newline/>
   [ServiceKnownType(typeof(OperandProperty))]<newline/>
   [ServiceKnownType(typeof(OperandValue))]<newline/>
   [ServiceKnownType(typeof(ParameterValue))]<newline/>
   [ServiceKnownType(typeof(QueryOperand))]<newline/>
   [ServiceKnownType(typeof(UnaryOperator))]<newline/>
   [ServiceKnownType(typeof(JoinOperand))]<newline/>
   [ServiceKnownType(typeof(OperandParameter))]<newline/>
   [ServiceKnownType(typeof(QuerySubQueryContainer))]<newline/>
   DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement[] selects);<newline/>
}
```



```vb
<ServiceContract(Namespace:="http://devexpress.example.com")> _<newline/>
Public Interface IXpoGate<newline/>
<OperationContract, FaultContract(GetType(LockingException)), ServiceKnownType(GetType(DeleteStatement)), _<newline/>
ServiceKnownType(GetType(InsertStatement)), _<newline/>
ServiceKnownType(GetType(UpdateStatement)), _<newline/>
ServiceKnownType(GetType(AggregateOperand)), _<newline/>
ServiceKnownType(GetType(BetweenOperator)), _<newline/>
ServiceKnownType(GetType(BinaryOperator)), _<newline/>
ServiceKnownType(GetType(ContainsOperator)), _<newline/>
ServiceKnownType(GetType(FunctionOperator)), _<newline/>
ServiceKnownType(GetType(GroupOperator)), _<newline/>
ServiceKnownType(GetType(InOperator)), _<newline/>
ServiceKnownType(GetType(NotOperator)), _<newline/>
ServiceKnownType(GetType(NullOperator)), _<newline/>
ServiceKnownType(GetType(OperandProperty)), _<newline/>
ServiceKnownType(GetType(OperandValue)), _<newline/>
ServiceKnownType(GetType(ParameterValue)), _<newline/>
ServiceKnownType(GetType(QueryOperand)), _<newline/>
ServiceKnownType(GetType(UnaryOperator)), _<newline/>
ServiceKnownType(GetType(JoinOperand)), _<newline/>
ServiceKnownType(GetType(QuerySubQueryContainer)), _<newline/>
ServiceKnownType(GetType(OperandParameter))> _<newline/>
Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult<newline/>
<OperationContract> _<newline/>
Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult<newline/>
<OperationContract> _<newline/>
Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult<newline/>
<OperationContract, _<newline/>
ServiceKnownType(GetType(AggregateOperand)), _<newline/>
ServiceKnownType(GetType(BetweenOperator)), _<newline/>
ServiceKnownType(GetType(BinaryOperator)), _<newline/>
ServiceKnownType(GetType(ContainsOperator)), _<newline/>
ServiceKnownType(GetType(FunctionOperator)), _<newline/>
ServiceKnownType(GetType(GroupOperator)), _<newline/>
ServiceKnownType(GetType(InOperator)), _<newline/>
ServiceKnownType(GetType(NotOperator)), _<newline/>
ServiceKnownType(GetType(NullOperator)), _<newline/>
ServiceKnownType(GetType(OperandProperty)), _<newline/>
ServiceKnownType(GetType(OperandValue)), _<newline/>
ServiceKnownType(GetType(ParameterValue)), _<newline/>
ServiceKnownType(GetType(QueryOperand)), _<newline/>
ServiceKnownType(GetType(UnaryOperator)), _<newline/>
ServiceKnownType(GetType(JoinOperand)), _<newline/>
ServiceKnownType(GetType(QuerySubQueryContainer)), _<newline/>
ServiceKnownType(GetType(OperandParameter))> _<newline/>
Function SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult<newline/>
End Interface
```

<p>The implementation of the WCF service is very simple. The interaction with the database will be done using any <a href="http://documentation.devexpress.com/#XPO/CustomDocument2114"><u>native</u></a> or custom connection provider. It is better to share a single instance of the connection provider between multiple users, because each connection provider opens its own connection to the database. The connection provider should be used through the DataCacheRoot class to enable Data Layer Caching.</p>

```cs
dataStore = new DataCacheRoot(XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None));
```



```vb
dataStore = New DataCacheRoot(XpoDefault.GetConnectionProvider(conn, AutoCreateOption.None))
```

<p>Service methods will invoke corresponding methods of the connection provider:</p>

```cs
DataCacheSelectDataResult IXpoGate.SelectData(DataCacheCookie cookie, SelectStatement[] selects) {<newline/>
   return dataStore.SelectData(cookie, selects);<newline/>
}
```



```vb
Private Function IXpoGate_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements IXpoGate.SelectData<newline/>
Return dataStore.SelectData(cookie, selects)<newline/>
End Function
```

<p>The ModifyData method should catch the LockingException, and pass it to the client inside the FaultException.</p>

```cs
DataCacheModificationResult IXpoGate.ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements) {<newline/>
   try {<newline/>
       return dataStore.ModifyData(cookie, dmlStatements);<newline/>
   } catch (LockingException ex) {<newline/>
       throw new FaultException<LockingException>(ex);<newline/>
   }<newline/>
}
```



```vb
Private Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements IXpoGate.ModifyData<newline/>
Try<newline/>
Return dataStore.ModifyData(cookie, dmlStatements)<newline/>
Catch ex As LockingException<newline/>
Throw New FaultException(Of LockingException)(ex)<newline/>
End Try<newline/>
End Function
```

<p>The server side is done, and now it is time to write a client that can communicate with our service. There are many approaches for writing a WCF client. In this example, we will use the <a href="http://msdn.microsoft.com/en-us/library/aa347733.aspx"><u>SvcUtil</u></a> tool to generate the client proxy class from metadata document published by our service.</p><p>The SvcUtil generates two files: one contains the code of the WCF client and some proxy classes used for data transfer, and the configuration file. The configuration file can be modified, but we leave it as is in this example. But, the code file should be modified.</p><p>Feel free to delete all proxy classes, because the corresponding classes from the DevExpress.Data and DevExpress.Xpo libraries will be used. Only the interface and client class are necessary from this file. In the interface, it is necessary to add the same service known types for the SelectData and ModifyData methods, as were added to corresponding service methods.</p><p>In the client class, feel free to remove the implementation of the interface, because it is enough to pass the interface as a generic parameter. Instead, our client implements the ICachedDataStore interface. Again, the implementation is very simple.</p>

```cs
DataCacheSelectDataResult ICacheToCacheCommunicationCore.SelectData(DataCacheCookie cookie, SelectStatement[] selects) {<newline/>
   return Channel.SelectData(cookie, selects);<newline/>
}
```



```vb
Private Function ICacheToCacheCommunicationCore_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements ICacheToCacheCommunicationCore.SelectData<newline/>
Return Channel.SelectData(cookie, selects)<newline/>
End Function
```

<p>The main thing here is to not forget to properly handle the LockingException within the ModifyData method.</p>

```cs
DataCacheModificationResult ICacheToCacheCommunicationCore.ModifyData(DataCacheCookie cookie, <newline/>
   ModificationStatement[] dmlStatements) {<newline/>
   try {<newline/>
       return Channel.ModifyData(cookie, dmlStatements);<newline/>
   } catch (FaultException<LockingException> ex) {<newline/>
       throw ex.Detail;<newline/>
   }<newline/>
}
```



```vb
Private Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements ICacheToCacheCommunicationCore.ModifyData<newline/>
Try<newline/>
Return Channel.ModifyData(cookie, dmlStatements)<newline/>
Catch LockingException ex As FaultException(Of)<newline/>
Throw ex.Detail<newline/>
End Try<newline/>
End Function
```

<p>The ICachedDataStore interface inherits some methods from the IDataStore interface. When implementing these methods, use the DataCacheCookie.Empty constant when the cookie parameter is required.</p>

```cs
SelectedData IDataStore.SelectData(params SelectStatement[] selects) {<newline/>
   return Channel.SelectData(DataCacheCookie.Empty, selects).SelectedData;<newline/>
}
```



```vb
Private Function SelectData(ParamArray ByVal selects() As SelectStatement) As SelectedData Implements IDataStore.SelectData<newline/>
Return Channel.SelectData(DataCacheCookie.Empty, selects).SelectedData<newline/>
End Function
```

<p> </p><p>Sometimes, filter parameters that come from the client application might not be of the type that is known by the server (for example, the DBNull type). It is possible to verify conditions passed to the SelectData and ModifyData methods, and replace an illegal value with an alternative value. You can create a simple CriteriaPatcher class using the approach described in the <a href="https://www.devexpress.com/Support/Center/p/E3396">How to delete all criteria corresponding to a particular field from CriteriaOperator</a> example. Here is a code snippet demonstrating how to use the CriteriaPatcher class in the SelectData and Modify data methods:</p><br />


```cs
static void PatchParameters(JoinNode[] statements) {<newline/>
   foreach (JoinNode statement in statements)<newline/>
       statement.Condition = CriteriaPatcher.Patch(statement.Condition);<newline/>
} <newline/>
DataCacheModificationResult ICacheToCacheCommunicationCore.ModifyData(DataCacheCookie cookie, <newline/>
	ModificationStatement[] dmlStatements) {<newline/>
	try {<newline/>
		PatchParameters(dmlStatements);<newline/>
		return Channel.ModifyData(cookie, dmlStatements);<newline/>
	} catch (FaultException<LockingException> ex) {<newline/>
		throw ex.Detail;<newline/>
	}<newline/>
} <newline/>
DataCacheSelectDataResult ICacheToCacheCommunicationCore.SelectData(DataCacheCookie cookie, SelectStatement[] selects) {<newline/>
	PatchParameters(selects);<newline/>
	return Channel.SelectData(cookie, selects);<newline/>
}
```

<p> </p>

```vb
Shared Sub PatchParameters(ByVal statements() As JoinNode)<newline/>
	For Each statement As JoinNode In statements<newline/>
		statement.Condition = CriteriaPatcher.Patch(statement.Condition)<newline/>
	Next statement<newline/>
End Sub <newline/>
Private Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult Implements ICacheToCacheCommunicationCore.ModifyData<newline/>
	Try<newline/>
		PatchParameters(dmlStatements)<newline/>
		Return Channel.ModifyData(cookie, dmlStatements)<newline/>
	Catch LockingException ex As FaultException(Of)<newline/>
		Throw ex.Detail<newline/>
	End Try<newline/>
End Function <newline/>
Private Function ICacheToCacheCommunicationCore_SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult Implements ICacheToCacheCommunicationCore.SelectData<newline/>
	PatchParameters(selects)<newline/>
	Return Channel.SelectData(cookie, selects)<newline/>
End Function
```

<p> </p><p>Usually, WCF service clients are not allowed to modify database schema for security reasons. Therefore, we suggest not implementing the UpdateSchema, and throw the exception.</p>

```cs
UpdateSchemaResult IDataStore.UpdateSchema(bool dontCreateIfFirstTableNotExist, params DBTable[] tables) {<newline/>
   throw new NotSupportedException("Database schema modifications not allowed");<newline/>
}
```



```vb
Private Function IDataStore_UpdateSchema(ByVal dontCreateIfFirstTableNotExist As Boolean, ParamArray ByVal tables() As DBTable) As UpdateSchemaResult Implements IDataStore.UpdateSchema<newline/>
Throw New NotSupportedException("Database schema modifications not allowed")<newline/>
End Function
```

<p>To guarantee that XPO never invokes the UpdateSchema method internally, the AutoCreateOption property should return the AutoCreateOption.SchemaAlreadyExists value:</p>

```cs
AutoCreateOption IDataStore.AutoCreateOption {<newline/>
   get { return AutoCreateOption.SchemaAlreadyExists; }<newline/>
}
```



```vb
Private ReadOnly Property IDataStore_AutoCreateOption() As AutoCreateOption Implements IDataStore.AutoCreateOption<newline/>
Get<newline/>
Return AutoCreateOption.SchemaAlreadyExists<newline/>
End Get<newline/>
End Property
```

<p>That is there is to XPO and WCF services.</p>

<br/>


