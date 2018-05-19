Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo.DB
Imports System.ServiceModel
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB.Exceptions

Namespace DXSample.Service
	<ServiceContract(Namespace:="http://devexpress.example.com")> _
	Public Interface IXpoGate
		<OperationContract, FaultContract(GetType(LockingException)), ServiceKnownType(GetType(DeleteStatement)), ServiceKnownType(GetType(InsertStatement)), ServiceKnownType(GetType(UpdateStatement)), ServiceKnownType(GetType(AggregateOperand)), ServiceKnownType(GetType(BetweenOperator)), ServiceKnownType(GetType(BinaryOperator)), ServiceKnownType(GetType(ContainsOperator)), ServiceKnownType(GetType(FunctionOperator)), ServiceKnownType(GetType(GroupOperator)), ServiceKnownType(GetType(InOperator)), ServiceKnownType(GetType(NotOperator)), ServiceKnownType(GetType(NullOperator)), ServiceKnownType(GetType(OperandProperty)), ServiceKnownType(GetType(OperandValue)), ServiceKnownType(GetType(ParameterValue)), ServiceKnownType(GetType(QueryOperand)), ServiceKnownType(GetType(UnaryOperator)), ServiceKnownType(GetType(JoinOperand)), ServiceKnownType(GetType(OperandParameter)), ServiceKnownType(GetType(QuerySubQueryContainer)), ServiceKnownType(GetType(ConstantValue))> _
		Function ModifyData(ByVal cookie As DataCacheCookie, ByVal dmlStatements() As ModificationStatement) As DataCacheModificationResult
		<OperationContract> _
		Function NotifyDirtyTables(ByVal cookie As DataCacheCookie, ParamArray ByVal dirtyTablesNames() As String) As DataCacheResult
		<OperationContract> _
		Function ProcessCookie(ByVal cookie As DataCacheCookie) As DataCacheResult
		<OperationContract, ServiceKnownType(GetType(AggregateOperand)), ServiceKnownType(GetType(BetweenOperator)), ServiceKnownType(GetType(BinaryOperator)), ServiceKnownType(GetType(ContainsOperator)), ServiceKnownType(GetType(FunctionOperator)), ServiceKnownType(GetType(GroupOperator)), ServiceKnownType(GetType(InOperator)), ServiceKnownType(GetType(NotOperator)), ServiceKnownType(GetType(NullOperator)), ServiceKnownType(GetType(OperandProperty)), ServiceKnownType(GetType(OperandValue)), ServiceKnownType(GetType(ParameterValue)), ServiceKnownType(GetType(QueryOperand)), ServiceKnownType(GetType(UnaryOperator)), ServiceKnownType(GetType(JoinOperand)), ServiceKnownType(GetType(OperandParameter)), ServiceKnownType(GetType(QuerySubQueryContainer)), ServiceKnownType(GetType(ConstantValue))> _
		Function SelectData(ByVal cookie As DataCacheCookie, ByVal selects() As SelectStatement) As DataCacheSelectDataResult
	End Interface
End Namespace
