using System;
using DevExpress.Xpo.DB;
using System.ServiceModel;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB.Exceptions;

namespace DXSample.Service {
    [ServiceContract(Namespace="http://devexpress.example.com")]
    public interface IXpoGate {
        [OperationContract, FaultContract(typeof(LockingException))]
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
        DataCacheModificationResult ModifyData(DataCacheCookie cookie, ModificationStatement[] dmlStatements);
        [OperationContract]
        DataCacheResult NotifyDirtyTables(DataCacheCookie cookie, params string[] dirtyTablesNames);
        [OperationContract]
        DataCacheResult ProcessCookie(DataCacheCookie cookie);
        [OperationContract]
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
        DataCacheSelectDataResult SelectData(DataCacheCookie cookie, SelectStatement[] selects);
    }
}
