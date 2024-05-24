using System;
using System.Linq.Expressions;
using System.Reflection;
using Prism.Properties;

namespace Prism.Mvvm
{
	// Token: 0x02000006 RID: 6
	public static class PropertySupport
	{
		// Token: 0x06000025 RID: 37 RVA: 0x000023D4 File Offset: 0x000005D4
		public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}
			return PropertySupport.ExtractPropertyNameFromLambda(propertyExpression);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000023EC File Offset: 0x000005EC
		internal static string ExtractPropertyNameFromLambda(LambdaExpression expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			MemberExpression memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException(Resources.PropertySupport_NotMemberAccessExpression_Exception, "expression");
			}
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				throw new ArgumentException(Resources.PropertySupport_ExpressionNotProperty_Exception, "expression");
			}
			if (propertyInfo.GetMethod.IsStatic)
			{
				throw new ArgumentException(Resources.PropertySupport_StaticExpression_Exception, "expression");
			}
			return memberExpression.Member.Name;
		}
	}
}
