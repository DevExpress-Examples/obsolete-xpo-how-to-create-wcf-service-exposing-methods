Imports Microsoft.VisualBasic
Imports DevExpress.Data.Filtering
Imports System
Imports DevExpress.Xpo.DB

Namespace DXSample.DataStore
	Public Class CriteriaPatcher
		Implements IQueryCriteriaVisitor
		Private Sub New()
		End Sub

		''' <summary>
		''' This method is used to get rid of values (such as DBNull) that are not
		''' known at the server side
		''' </summary>
		''' <param name="param">The value sent by the client to the server</param>
		''' <returns>The replacement value if the original value cannot be sent,
		''' or the original value otherwize.</returns>
		Protected Overridable Function PatchNonSerializableParameters(ByVal param As Object) As Object
			Return If(param Is DBNull.Value, Nothing, param)
		End Function

		Private Function PatchOperands(ByVal operands As CriteriaOperatorCollection) As CriteriaOperatorCollection
			Dim result As New CriteriaOperatorCollection()
			For Each operand As CriteriaOperator In operands
				result.Add(CType(operand.Accept(Me), CriteriaOperator))
			Next operand
			Return result
		End Function

		Public Shared Function Patch(ByVal expression As CriteriaOperator) As CriteriaOperator
			Return If(Equals(expression, Nothing), Nothing, CType(expression.Accept(New CriteriaPatcher()), CriteriaOperator))
		End Function

		#Region "ICriteriaVisitor Members"

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As FunctionOperator) As Object Implements ICriteriaVisitor.Visit
			Return New FunctionOperator(theOperator.OperatorType, PatchOperands(theOperator.Operands))
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperand As OperandValue) As Object Implements ICriteriaVisitor.Visit
			Return New OperandValue(PatchNonSerializableParameters(theOperand.Value))
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As GroupOperator) As Object Implements ICriteriaVisitor.Visit
			Return New GroupOperator(theOperator.OperatorType, PatchOperands(theOperator.Operands))
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As InOperator) As Object Implements ICriteriaVisitor.Visit
			Return New InOperator(CType(theOperator.LeftOperand.Accept(Me), CriteriaOperator), PatchOperands(theOperator.Operands))
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As UnaryOperator) As Object Implements ICriteriaVisitor.Visit
			Return New UnaryOperator(theOperator.OperatorType, CType(theOperator.Operand.Accept(Me), CriteriaOperator))
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As BinaryOperator) As Object Implements ICriteriaVisitor.Visit
			Return New BinaryOperator(CType(theOperator.LeftOperand.Accept(Me), CriteriaOperator), CType(theOperator.RightOperand.Accept(Me), CriteriaOperator), theOperator.OperatorType)
		End Function

		Private Function ICriteriaVisitor_Visit(ByVal theOperator As BetweenOperator) As Object Implements ICriteriaVisitor.Visit
			Return New BetweenOperator(CType(theOperator.TestExpression.Accept(Me), CriteriaOperator), CType(theOperator.BeginExpression.Accept(Me), CriteriaOperator), CType(theOperator.EndExpression.Accept(Me), CriteriaOperator))
		End Function

		#End Region

		#Region "IQueryCriteriaVisitor Members"

		Private Function IQueryCriteriaVisitor_Visit(ByVal theOperand As QuerySubQueryContainer) As Object Implements IQueryCriteriaVisitor.Visit
			Return New QuerySubQueryContainer(theOperand.Node, CType(theOperand.AggregateProperty.Accept(Me), CriteriaOperator), theOperand.AggregateType)
		End Function

		Private Function IQueryCriteriaVisitor_Visit(ByVal theOperand As QueryOperand) As Object Implements IQueryCriteriaVisitor.Visit
			Return theOperand
		End Function

		#End Region
	End Class
End Namespace
