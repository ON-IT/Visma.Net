using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ONIT.VismaNetApi.Finders;
using ONIT.VismaNetApi.Helpers;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
    class VismaNetQueryContext
    {
        // Executes the expression tree that is passed to it. 
        internal static object Execute(Expression expression, bool IsEnumerable, VismaNetAuthorization auth)
        {
            // The expression must represent a query over the data source. 
            if (!IsQueryOverDataSource(expression))
                throw new InvalidProgramException("No query over the data source was specified.");

            // Find the call to Where() and get the lambda expression predicate.
            InnermostWhereFinder whereFinder = new InnermostWhereFinder();
            MethodCallExpression whereExpression = whereFinder.GetInnermostWhere(expression);

            var orderBy = GetOrderByExpression(expression);
            var numberToRead = GetTakeExpression(expression);

            LambdaExpression lambdaExpression;
            IEnumerable<CustomerInvoice> customers = null;
            if (whereExpression != null && whereExpression.Arguments.Count > 1)
            {
                lambdaExpression = (LambdaExpression) ((UnaryExpression) (whereExpression.Arguments[1])).Operand;

                // Send the lambda expression through the partial evaluator.
                lambdaExpression = (LambdaExpression) Evaluator.PartialEval(lambdaExpression);

                // Get the place name(s) to query the Web service with.
                var cf = new CustomerFinder(lambdaExpression.Body);
                if (whereExpression.Method.Name.StartsWith("First"))
                {
                    numberToRead = 1;
                }
                // Call the Web service and get the results.
               // customers = VismaNetApiHelper.FindCustomers(cf.UrlParams, auth, orderBy: orderBy, numberToRead: numberToRead);
            }
            else
            {
               // customers = VismaNetApiHelper.FindCustomers(null, auth, orderBy: orderBy, numberToRead: numberToRead); // Return all customers
            }

            // Copy the IEnumerable places to an IQueryable.
            IQueryable<CustomerInvoice> queryableInvoices = customers.AsQueryable<CustomerInvoice>();
            
            // Copy the expression tree that was passed in, changing only the first 
            // argument of the innermost MethodCallExpression.
            var treeCopier = new ExpressionTreeModifier<CustomerInvoice>(queryableInvoices);
            Expression newExpressionTree = treeCopier.Visit(expression);

         //   // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods. 
           // if (IsEnumerable)
                return queryableInvoices.Provider.CreateQuery(newExpressionTree);
           // else
             //   return queryableCustomers.Provider.Execute(newExpressionTree);
        }

        private static string GetOrderByExpression(Expression expression)
        {
            InnermostOrderByFinder orderByFinder = new InnermostOrderByFinder();
            MethodCallExpression orderByExpression = orderByFinder.GetInnermostOrderBy(expression);

            string orderBy = null;

            if (orderByExpression != null)
            {
                var orderByLambdaExpression = (LambdaExpression) ((UnaryExpression) (orderByExpression.Arguments[1])).Operand;
                orderByLambdaExpression = (LambdaExpression) Evaluator.PartialEval(orderByLambdaExpression);
                if (orderByLambdaExpression.Body.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpression = (MemberExpression) orderByLambdaExpression.Body;
                    orderBy = memberExpression.Member.Name;
                }
            }
            return orderBy;
        }

        private static int GetTakeExpression(Expression expression)
        {
            InnermostTakeFinder takeFinder = new InnermostTakeFinder();
            MethodCallExpression takeExpression = takeFinder.GetInnermostTake(expression);

            if (takeExpression != null)
            {
                var takeLambdaExpression = (ConstantExpression)(takeExpression.Arguments[1]);
                if(takeLambdaExpression.Value is int)
                    return (int)takeLambdaExpression.Value;
            }
            return 0;
        }

        private static bool IsQueryOverDataSource(Expression expression)
        {
            // If expression represents an unqueried IQueryable data source instance, 
            // expression is of type ConstantExpression, not MethodCallExpression. 
            return (expression is MethodCallExpression);
        }
    }
}