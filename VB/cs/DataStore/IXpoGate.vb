Imports Microsoft.VisualBasic
Imports DevExpress.Xpo.DB
Imports System.ServiceModel
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB.Exceptions

Namespace DXSample.DataStore
	<ServiceContractAttribute(Namespace := "http://devexpress.example.com", ConfigurationName := "IXpoGate")> _
	Public Interface IXpoGate
		<ServiceKnownType(GetType(DeleteStatement)), ServiceKnownType(GetType(InsertStatement)), ServiceKnownType(GetType(UpdateStatement)), ServiceKnownType(GetType(AggregateOperand)), ServiceKnownType(GetType(BetweenOperator)), ServiceKnownType(GetType(BinaryOperator)), ServiceKnownType(GetType(ContainsOperator)), ServiceKnownType(GetType(FunctionOperator)), ServiceKnownType(GetType(GroupOperator)), ServiceKnownType(GetType(InOperator)), ServiceKnownType(GetType(NotOperator)), ServiceKnownType(GetType(NullOperator)), ServiceKnownType(GetType(OperandProperty)), ServiceKnownType(GetType(OperandValue)), ServiceKnownType(GetType(ParameterValue)), ServiceKnownType(GetType(QueryOperand)), ServiceKnownType(GetType(UnaryOperator)), ServiceKnownType(GetType(JoinOperand)), ServiceKnownType(GetType(OperandParameter)), ServiceKnownType(GetType(QuerySubQueryContainer)), OperationContract(Action := "http://devexpress.example.com/IXpoGate/ModifyData", ReplyAction := "http://devexpress.example.com/IXpoGate/ModifyDataResponse"), FaultContract(GetType(LockingException), Action := "http://devexpress.example.com/IXpoGate/ModifyDataLockingExceptionFault", Name := "LockingException", Namespace := "http://schemas.datacontract.org/2004/07/DevExpress.Xpo.DB.Exceptions")> _
		Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult

		<OperationContract(Action := "http://devexpress.example.com/IXpoGate/NotifyDirtyTables", ReplyAction := "http://devexpress.example.com/IXpoGate/NotifyDirtyTablesResponse")> _
		Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ByVal dirtyTablesNames() As String) As DataCacheResult

		<OperationContract(Action := "http://devexpress.example.com/IXpoGate/ProcessCookie", ReplyAction := "http://devexpress.example.com/IXpoGate/ProcessCookieResponse")> _
		Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult

		<ServiceKnownType(GetType(AggregateOperand)), ServiceKnownType(GetType(BetweenOperator)), ServiceKnownType(GetType(BinaryOperator)), ServiceKnownType(GetType(ContainsOperator)), ServiceKnownType(GetType(FunctionOperator)), ServiceKnownType(GetType(GroupOperator)), ServiceKnownType(GetType(InOperator)), ServiceKnownType(GetType(NotOperator)), ServiceKnownType(GetType(NullOperator)), ServiceKnownType(GetType(OperandProperty)), ServiceKnownType(GetType(OperandValue)), ServiceKnownType(GetType(ParameterValue)), ServiceKnownType(GetType(QueryOperand)), ServiceKnownType(GetType(UnaryOperator)), ServiceKnownType(GetType(JoinOperand)), ServiceKnownType(GetType(OperandParameter)), ServiceKnownType(GetType(QuerySubQueryContainer)), OperationContract(Action := "http://devexpress.example.com/IXpoGate/SelectData", ReplyAction := "http://devexpress.example.com/IXpoGate/SelectDataResponse")> _
		Function SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult
	End Interface
End Namespace