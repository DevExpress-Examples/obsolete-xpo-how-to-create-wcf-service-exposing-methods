using DevExpress.Xpo.DB;
using System.ServiceModel;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB.Exceptions;

namespace DXSample.DataStore {
    [ServiceContractAttribute(Namespace = "http://devexpress.example.com", ConfigurationName = "IXpoGate")]
    public interface IXpoGate {
        [ServiceKnownType(typeof(DeleteStatement))]
        [ServiceKnownType(typeof(InsertStatement))]
        [ServiceKnownType(typeof(UpdateStatement))]
        [ServiceKnownType(typeof(AggregateOperand))]
        [ServiceKnownType(typeof(BetweenOperator))]
        [ServiceKnownType(typeof(BinaryOperator))]
        [ServiceKnownType(typeof(ContainsOperator))]
        [ServiceKnownType(typeof(FunctionOperator))]
        [ServiceKnownType(typeof(GroupOperator))]
        [ServiceKnownType(typeof(InOperator))]
        [ServiceKnownType(typeof(NotOperator))]
        [ServiceKnownType(typeof(NullOperator))]
        [ServiceKnownType(typeof(OperandProperty))]
        [ServiceKnownType(typeof(OperandValue))]
        [ServiceKnownType(typeof(ParameterValue))]
        [ServiceKnownType(typeof(QueryOperand))]
        [ServiceKnownType(typeof(UnaryOperator))]
        [ServiceKnownType(typeof(JoinOperand))]
        [ServiceKnownType(typeof(OperandParameter))]
        [ServiceKnownType(typeof(QuerySubQueryContainer))]
        [ServiceKnownType(typeof(ConstantValue))]
        [OperationContract(Action = "http://devexpress.example.com/IXpoGate/ModifyData",
            ReplyAction = "http://devexpress.example.com/IXpoGate/ModifyDataResponse")]
        [FaultContract(typeof(LockingException), Action = "http://devexpress.example.com/IXpoGate/ModifyDataLockingExceptionFault",
            Name = "LockingException", Namespace = "http://schemas.datacontract.org/2004/07/DevExpress.Xpo.DB.Exceptions")]
        DataCacheModificationResult ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements);

        [OperationContract(Action = "http://devexpress.example.com/IXpoGate/NotifyDirtyTables", 
            ReplyAction = "http://devexpress.example.com/IXpoGate/NotifyDirtyTablesResponse")]
        DataCacheResult NotifyDirtyTables(DataCacheCookie cookie, string[] dirtyTablesNames);

        [OperationContract(Action = "http://devexpress.example.com/IXpoGate/ProcessCookie", 
            ReplyAction = "http://devexpress.example.com/IXpoGate/ProcessCookieResponse")]
        DataCacheResult ProcessCookie(DataCacheCookie cookie);

        [ServiceKnownType(typeof(AggregateOperand))]
        [ServiceKnownType(typeof(BetweenOperator))]
        [ServiceKnownType(typeof(BinaryOperator))]
        [ServiceKnownType(typeof(ContainsOperator))]
        [ServiceKnownType(typeof(FunctionOperator))]
        [ServiceKnownType(typeof(GroupOperator))]
        [ServiceKnownType(typeof(InOperator))]
        [ServiceKnownType(typeof(NotOperator))]
        [ServiceKnownType(typeof(NullOperator))]
        [ServiceKnownType(typeof(OperandProperty))]
        [ServiceKnownType(typeof(OperandValue))]
        [ServiceKnownType(typeof(ParameterValue))]
        [ServiceKnownType(typeof(QueryOperand))]
        [ServiceKnownType(typeof(UnaryOperator))]
        [ServiceKnownType(typeof(JoinOperand))]
        [ServiceKnownType(typeof(OperandParameter))]
        [ServiceKnownType(typeof(QuerySubQueryContainer))]
        [ServiceKnownType(typeof(ConstantValue))]
        [OperationContract(Action = "http://devexpress.example.com/IXpoGate/SelectData",
            ReplyAction = "http://devexpress.example.com/IXpoGate/SelectDataResponse")]
        DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement[] selects);
    }
}