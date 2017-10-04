using System;
using System.Linq.Expressions;

namespace ONIT.VismaNetApi.Helpers
{
    internal class InnermostOrderByFinder : ExpressionVisitor
    {
        private MethodCallExpression innermostOrderByExpression;

        public MethodCallExpression GetInnermostOrderBy(Expression expression)
        {
            Visit(expression);
            return innermostOrderByExpression;
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            Console.WriteLine(expression.Method.Name);
            if (expression.Method.Name == "OrderBy")
                innermostOrderByExpression = expression;

            Visit(expression.Arguments[0]);

            return expression;
        }
    }
}