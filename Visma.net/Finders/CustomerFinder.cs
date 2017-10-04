using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using ONIT.VismaNetApi.Helpers;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Finders
{
    public class CustomerFinder : ExpressionVisitor
    {
        private readonly Expression expression;
        
        private List<string> _urlParams;
        
        public CustomerFinder(Expression exp)
        {
            expression = exp;
        }

        public IEnumerable<string> UrlParams
        {
            get
            {
                if (_urlParams == null)
                {
                    _urlParams = new List<string>();
                    Visit(expression);
                }
                return _urlParams;
            }
        }

        protected override Expression VisitBinary(BinaryExpression be)
        {
            if (be.NodeType == ExpressionType.Equal || be.NodeType == ExpressionType.GreaterThan || be.NodeType == ExpressionType.LessThan)
            {
                _urlParams.Add(be.ToQueryStringEquals<Customer>());
                return be;
            }

            if (be.NodeType == ExpressionType.AndAlso)
            {
                var queryString = string.Format("{0}&{1}", 
                    ((BinaryExpression) be.Left).ToQueryStringEquals<Customer>(),
                    ((BinaryExpression) be.Right).ToQueryStringEquals<Customer>());
                _urlParams.Add(queryString);                  
                return be;
            }
            
#if DEBUG
            Console.WriteLine("{0} {1} {2}", be.NodeType, be.Left.NodeType, be.Right.NodeType);
#endif
            return base.VisitBinary(be);
        }
    } 

    public static class BinaryExpressionExtentions
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string ToQueryStringEquals<T>(this BinaryExpression be, string addon = "")
        {
            if (be.Left.NodeType == ExpressionType.Equal && be.Right.NodeType == ExpressionType.Equal)
            {
                return string.Format("{0}&{1}", ToQueryStringEquals<T>((BinaryExpression) be.Left),
                    ToQueryStringEquals<T>((BinaryExpression) be.Right));
            }
            var membername = ExpressionTreeHelpers.GetDeclaringTypeMemberName(be, typeof(T));
            var value = ExpressionTreeHelpers.GetValueFromEqualsExpression<object>(be, typeof (T), membername);
            if (value is DateTime)
                value = ((DateTime)value).ToString(DateTimeFormat);

            var membervalue = string.Format("{0}{1}", value, addon);
            if (membername.Equals("customerCd"))
                return string.Format("/{0}", Uri.EscapeUriString(membervalue));
            return string.Format("{0}={1}", Uri.EscapeDataString(membername), Uri.EscapeDataString(membervalue));
        }
    }
}