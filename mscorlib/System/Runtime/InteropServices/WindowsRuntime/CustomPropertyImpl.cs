using System;
using System.Globalization;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A10 RID: 2576
	internal sealed class CustomPropertyImpl : ICustomProperty
	{
		// Token: 0x060065A8 RID: 26024 RVA: 0x001598F8 File Offset: 0x00157AF8
		public CustomPropertyImpl(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
			{
				throw new ArgumentNullException("propertyInfo");
			}
			this.m_property = propertyInfo;
		}

		// Token: 0x17001177 RID: 4471
		// (get) Token: 0x060065A9 RID: 26025 RVA: 0x0015991B File Offset: 0x00157B1B
		public string Name
		{
			get
			{
				return this.m_property.Name;
			}
		}

		// Token: 0x17001178 RID: 4472
		// (get) Token: 0x060065AA RID: 26026 RVA: 0x00159928 File Offset: 0x00157B28
		public bool CanRead
		{
			get
			{
				return this.m_property.GetGetMethod() != null;
			}
		}

		// Token: 0x17001179 RID: 4473
		// (get) Token: 0x060065AB RID: 26027 RVA: 0x0015993B File Offset: 0x00157B3B
		public bool CanWrite
		{
			get
			{
				return this.m_property.GetSetMethod() != null;
			}
		}

		// Token: 0x060065AC RID: 26028 RVA: 0x0015994E File Offset: 0x00157B4E
		public object GetValue(object target)
		{
			return this.InvokeInternal(target, null, true);
		}

		// Token: 0x060065AD RID: 26029 RVA: 0x00159959 File Offset: 0x00157B59
		public object GetValue(object target, object indexValue)
		{
			return this.InvokeInternal(target, new object[]
			{
				indexValue
			}, true);
		}

		// Token: 0x060065AE RID: 26030 RVA: 0x0015996D File Offset: 0x00157B6D
		public void SetValue(object target, object value)
		{
			this.InvokeInternal(target, new object[]
			{
				value
			}, false);
		}

		// Token: 0x060065AF RID: 26031 RVA: 0x00159982 File Offset: 0x00157B82
		public void SetValue(object target, object value, object indexValue)
		{
			this.InvokeInternal(target, new object[]
			{
				indexValue,
				value
			}, false);
		}

		// Token: 0x060065B0 RID: 26032 RVA: 0x0015999C File Offset: 0x00157B9C
		[SecuritySafeCritical]
		private object InvokeInternal(object target, object[] args, bool getValue)
		{
			IGetProxyTarget getProxyTarget = target as IGetProxyTarget;
			if (getProxyTarget != null)
			{
				target = getProxyTarget.GetTarget();
			}
			MethodInfo methodInfo = getValue ? this.m_property.GetGetMethod(true) : this.m_property.GetSetMethod(true);
			if (methodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString(getValue ? "Arg_GetMethNotFnd" : "Arg_SetMethNotFnd"));
			}
			if (!methodInfo.IsPublic)
			{
				throw new MethodAccessException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_MethodAccessException_WithMethodName"), methodInfo.ToString(), methodInfo.DeclaringType.FullName));
			}
			RuntimeMethodInfo runtimeMethodInfo = methodInfo as RuntimeMethodInfo;
			if (runtimeMethodInfo == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeMethodInfo"));
			}
			return runtimeMethodInfo.UnsafeInvoke(target, BindingFlags.Default, null, args, null);
		}

		// Token: 0x1700117A RID: 4474
		// (get) Token: 0x060065B1 RID: 26033 RVA: 0x00159A5A File Offset: 0x00157C5A
		public Type Type
		{
			get
			{
				return this.m_property.PropertyType;
			}
		}

		// Token: 0x04002D3C RID: 11580
		private PropertyInfo m_property;
	}
}
