using DevExpress.Data.Filtering;
using System;
using DevExpress.Xpo.DB;

namespace DXSample.DataStore {
    public class CriteriaPatcher :IQueryCriteriaVisitor {
        CriteriaPatcher() { }

        /// <summary>
        /// This method is used to get rid of values (such as DBNull) that are not
        /// known at the server side
        /// </summary>
        /// <param name="param">The value sent by the client to the server</param>
        /// <returns>The replacement value if the original value cannot be sent,
        /// or the original value otherwize.</returns>
        protected virtual object PatchNonSerializableParameters(object param) {
            return param == DBNull.Value ? null : param;
        }

        CriteriaOperatorCollection PatchOperands(CriteriaOperatorCollection operands) {
            CriteriaOperatorCollection result = new CriteriaOperatorCollection();
            foreach (CriteriaOperator operand in operands)
                result.Add((CriteriaOperator)operand.Accept(this));
            return result;
        }

        public static CriteriaOperator Patch(CriteriaOperator expression) {
            return Equals(expression, null) ? null : (CriteriaOperator)expression.Accept(new CriteriaPatcher());
        }

        #region ICriteriaVisitor Members

        object ICriteriaVisitor.Visit(FunctionOperator theOperator) {
            return new FunctionOperator(theOperator.OperatorType, PatchOperands(theOperator.Operands));
        }

        object ICriteriaVisitor.Visit(OperandValue theOperand) {
            return new OperandValue(PatchNonSerializableParameters(theOperand.Value));
        }

        object ICriteriaVisitor.Visit(GroupOperator theOperator) {
            return new GroupOperator(theOperator.OperatorType, PatchOperands(theOperator.Operands));
        }

        object ICriteriaVisitor.Visit(InOperator theOperator) {
            return new InOperator((CriteriaOperator)theOperator.LeftOperand.Accept(this),
                PatchOperands(theOperator.Operands));
        }

        object ICriteriaVisitor.Visit(UnaryOperator theOperator) {
            return new UnaryOperator(theOperator.OperatorType, (CriteriaOperator)theOperator.Operand.Accept(this));
        }

        object ICriteriaVisitor.Visit(BinaryOperator theOperator) {
            return new BinaryOperator((CriteriaOperator)theOperator.LeftOperand.Accept(this),
                (CriteriaOperator)theOperator.RightOperand.Accept(this), theOperator.OperatorType);
        }

        object ICriteriaVisitor.Visit(BetweenOperator theOperator) {
            return new BetweenOperator((CriteriaOperator)theOperator.TestExpression.Accept(this),
                (CriteriaOperator)theOperator.BeginExpression.Accept(this), (CriteriaOperator)theOperator.EndExpression.Accept(this));
        }

        #endregion

        #region IQueryCriteriaVisitor Members

        object IQueryCriteriaVisitor.Visit(QuerySubQueryContainer theOperand) {
            return new QuerySubQueryContainer(theOperand.Node, (CriteriaOperator)theOperand.AggregateProperty.Accept(this),
                theOperand.AggregateType);
        }

        object IQueryCriteriaVisitor.Visit(QueryOperand theOperand) {
            return theOperand;
        }

        #endregion
    }
}
