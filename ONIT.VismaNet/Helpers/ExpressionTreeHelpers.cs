using System;
using System.Linq.Expressions;
using ONIT.VismaNetApi.Exceptions;

namespace ONIT.VismaNetApi.Helpers
{
    internal class ExpressionTreeHelpers
    {
        internal static bool DoAssertations(BinaryExpression be, Type declaringType, string memberName)
        {
            if (ExpressionTreeHelpers.IsSpecificMemberExpression(be.Left, declaringType, memberName) &&
                ExpressionTreeHelpers.IsSpecificMemberExpression(be.Right, declaringType, memberName))
                throw new Exception("Cannot have 'member' == 'member' in an expression!");

            return (ExpressionTreeHelpers.IsSpecificMemberExpression(be.Left, declaringType, memberName) ||
                    ExpressionTreeHelpers.IsSpecificMemberExpression(be.Right, declaringType, memberName));
        }

        internal static bool IsMemberEqualsValueExpression(Expression exp, Type declaringType, string memberName)
        {
            if (exp.NodeType != ExpressionType.Equal)
                return false;
            return DoAssertations((BinaryExpression)exp, declaringType, memberName);
        }

        internal static bool IsMemberAndAlsoValueExpression(Expression exp, Type declaringType, string memberName)
        {
            if (exp.NodeType != ExpressionType.AndAlso)
                return false;
            return DoAssertations((BinaryExpression)exp, declaringType, memberName);
        }

        internal static bool IsSpecificMemberExpression(Expression exp, Type declaringType, string memberName)
        {
            return ((exp is MemberExpression) &&
                    (((MemberExpression)exp).Member.DeclaringType == declaringType) &&
                    (((MemberExpression)exp).Member.Name == memberName));
        }

        internal static string GetDeclaringTypeMemberName(BinaryExpression be, Type memberDeclaringType)
        {
            if (be.Left.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression me = (MemberExpression)be.Left;

                if (me.Member.DeclaringType == memberDeclaringType)
                {
                    return me.Member.Name;
                }
                Console.WriteLine("Håndterer ikke {0}", me.Member.DeclaringType);
            }
            else if (be.Right.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression me = (MemberExpression)be.Right;

                if (me.Member.DeclaringType == memberDeclaringType)
                {
                    return me.Member.Name;
                }
                Console.WriteLine("Håndterer ikke {0}", me.Member.DeclaringType);
            }
            else if (be.Left.NodeType == ExpressionType.Call)
            {
                MethodCallExpression me = (MethodCallExpression) be.Left;
                if (me.Arguments.Count > 0)
                    return string.Format("{0}", me.Arguments[0]).Trim(new char[]{ '"' });
                return null;
            }
            else if (be.Left.NodeType == ExpressionType.Convert)
            {
                var me = (UnaryExpression) be.Left;
                var methodCall = (MethodCallExpression) me.Operand;
                if (methodCall.Arguments.Count > 0)
                    return string.Format("{0}", methodCall.Arguments[0]).Trim(new char[] { '"' });
                
                return null;
            }

            throw new InvalidQueryException(string.Format("Cannot cope with {0} or {1}", be.Left.NodeType, be.Right.NodeType));
        }

        private const ExpressionType ValuableNodeTypes = ExpressionType.Equal | ExpressionType.AndAlso;

        internal static T GetValueFromEqualsExpression<T>(BinaryExpression be, Type memberDeclaringType, string memberName)
        {
            if (!ValuableNodeTypes.HasFlag(be.NodeType))
                throw new Exception("There is a bug in this program.");

            if (be.Left.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression me = (MemberExpression)be.Left;

                if (me.Member.DeclaringType == memberDeclaringType && me.Member.Name == memberName)
                {
                    return GetValueFromExpression<T>(be.Right);
                }
            }
            else if (be.Right.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression me = (MemberExpression)be.Right;

                if (me.Member.DeclaringType == memberDeclaringType && me.Member.Name == memberName)
                {
                    return GetValueFromExpression<T>(be.Left);
                }
            } else if (be.Right.NodeType == ExpressionType.Constant)
            {
                var ce = (ConstantExpression)be.Right;
                    return (T) ce.Value;
                
            } 

            // We should have returned by now. 
            //throw new Exception("There is a bug in this program.");
            return default(T);
        }

        internal static T GetValueFromExpression<T>(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Constant)
            {
                 return (T) (((ConstantExpression) expression).Value);
            }
            else
                throw new InvalidQueryException(
                    String.Format("The expression type {0} is not supported to obtain a value.", expression.NodeType));
        }
    }
}