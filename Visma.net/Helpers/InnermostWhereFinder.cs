using System.Linq.Expressions;

namespace ONIT.VismaNetApi.Helpers
{
    internal class InnermostWhereFinder : ExpressionVisitor
    {
        private MethodCallExpression innermostWhereExpression;

        public MethodCallExpression GetInnermostWhere(Expression expression)
        {
            Visit(expression);
            return innermostWhereExpression;
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            if (expression.Method.Name == "Where" || expression.Method.Name == "FirstOrDefault" || expression.Method.Name == "First")
                innermostWhereExpression = expression;

            Visit(expression.Arguments[0]);

            return expression;
        }
    }
}