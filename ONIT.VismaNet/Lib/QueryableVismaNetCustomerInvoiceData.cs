using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
    public class QueryableVismaNetCustomerInvoiceData<TData> : CustomerInvoiceData, IOrderedQueryable<TData>
    {
        #region Constructors

        /// <summary>
        ///     This constructor is called by the client to create the data source.
        /// </summary>
        public QueryableVismaNetCustomerInvoiceData(VismaNetAuthorization auth) : base(auth)
        {
            Provider = new VismaNetQueryProvider(Authorization);
            Expression = Expression.Constant(this);
        }

        /// <summary>
        ///     This constructor is called by Provider.CreateQuery().
        /// </summary>
        /// <param name="expression"></param>
        public QueryableVismaNetCustomerInvoiceData(VismaNetQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof (IQueryable<TData>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            Provider = provider;
            Expression = expression;
        }

        #endregion

        #region Properties

        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }

        public Type ElementType
        {
            get { return typeof (TData); }
        }

        #endregion

        #region Enumerators

        public IEnumerator<TData> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<TData>>(Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<IEnumerable>(Expression)).GetEnumerator();
        }

        #endregion

  
    }
}