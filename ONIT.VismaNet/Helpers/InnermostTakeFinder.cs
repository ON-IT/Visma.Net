using System;
using System.Linq.Expressions;

namespace ONIT.VismaNetApi.Helpers
{
    internal class InnermostTakeFinder : ExpressionVisitor
    {
        private MethodCallExpression innermostTakeExpression;

        public MethodCallExpression GetInnermostTake(Expression expression)
        {
            Visit(expression);
            return innermostTakeExpression;
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            Console.WriteLine(expression.Method.Name);
            if (expression.Method.Name == "Take")
                innermostTakeExpression = expression;

            Visit(expression.Arguments[0]);

            return expression;
        }
    }
}