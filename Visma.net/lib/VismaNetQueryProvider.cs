using System;
using System.Linq;
using System.Linq.Expressions;
using ONIT.VismaNetApi.Helpers;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
    public class VismaNetQueryProvider : IQueryProvider
    {
        private readonly VismaNetAuthorization _auth;
        
        public VismaNetQueryProvider(VismaNetAuthorization auth)
        {
            _auth = auth;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(QueryableVismaNetCustomerData<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        // Queryable's collection-returning standard query operators call this method. 
        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return new QueryableVismaNetCustomerData<TResult>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return VismaNetCustomerQueryContext.Execute(expression, false, _auth); 
        }

        // Queryable's "single value" standard query operators call this method.
        // It is also called from QueryableTerraServerData.GetEnumerator(). 
        public TResult Execute<TResult>(Expression expression)
        {
            bool IsEnumerable = (typeof(TResult).Name == "IEnumerable`1");

            return (TResult) VismaNetCustomerQueryContext.Execute(expression, IsEnumerable, _auth);
        }
    }
}

