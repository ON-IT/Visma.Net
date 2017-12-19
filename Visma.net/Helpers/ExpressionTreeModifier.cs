using System.Linq;
using System.Linq.Expressions;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Helpers
{
    internal class ExpressionTreeModifier<T> : ExpressionVisitor
    {
        private IQueryable<T> queryableCustomers;

        internal ExpressionTreeModifier(IQueryable<T> customers)
        {
            this.queryableCustomers = customers;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            // Replace the constant QueryableTerraServerData arg with the queryable Place collection. 
            if (c.Type == typeof(QueryableVismaNetCustomerData<T>))
                return Expression.Constant(this.queryableCustomers);
            else
                return c;
        }
    }
}