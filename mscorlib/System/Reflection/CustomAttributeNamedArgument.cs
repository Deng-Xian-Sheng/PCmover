using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005D4 RID: 1492
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct CustomAttributeNamedArgument
	{
		// Token: 0x06004543 RID: 17731 RVA: 0x000FEB7B File Offset: 0x000FCD7B
		public static bool operator ==(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004544 RID: 17732 RVA: 0x000FEB90 File Offset: 0x000FCD90
		public static bool operator !=(CustomAttributeNamedArgument left, CustomAttributeNamedArgument right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x000FEBA8 File Offset: 0x000FCDA8
		public CustomAttributeNamedArgument(MemberInfo memberInfo, object value)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException("memberInfo");
			}
			FieldInfo fieldInfo = memberInfo as FieldInfo;
			PropertyInfo propertyInfo = memberInfo as PropertyInfo;
			Type argumentType;
			if (fieldInfo != null)
			{
				argumentType = fieldInfo.FieldType;
			}
			else
			{
				if (!(propertyInfo != null))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidMemberForNamedArgument"));
				}
				argumentType = propertyInfo.PropertyType;
			}
			this.m_memberInfo = memberInfo;
			this.m_value = new CustomAttributeTypedArgument(argumentType, value);
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x000FEC21 File Offset: 0x000FCE21
		public CustomAttributeNamedArgument(MemberInfo memberInfo, CustomAttributeTypedArgument typedArgument)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException("memberInfo");
			}
			this.m_memberInfo = memberInfo;
			this.m_value = typedArgument;
		}

		// Token: 0x06004547 RID: 17735 RVA: 0x000FEC48 File Offset: 0x000FCE48
		public override string ToString()
		{
			if (this.m_memberInfo == null)
			{
				return base.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "{0} = {1}", this.MemberInfo.Name, this.TypedValue.ToString(this.ArgumentType != typeof(object)));
		}

		// Token: 0x06004548 RID: 17736 RVA: 0x000FECB1 File Offset: 0x000FCEB1
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x000FECC3 File Offset: 0x000FCEC3
		public override bool Equals(object obj)
		{
			return obj == this;
		}

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x0600454A RID: 17738 RVA: 0x000FECD3 File Offset: 0x000FCED3
		internal Type ArgumentType
		{
			get
			{
				if (!(this.m_memberInfo is FieldInfo))
				{
					return ((PropertyInfo)this.m_memberInfo).PropertyType;
				}
				return ((FieldInfo)this.m_memberInfo).FieldType;
			}
		}

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x0600454B RID: 17739 RVA: 0x000FED03 File Offset: 0x000FCF03
		public MemberInfo MemberInfo
		{
			get
			{
				return this.m_memberInfo;
			}
		}

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x0600454C RID: 17740 RVA: 0x000FED0B File Offset: 0x000FCF0B
		[__DynamicallyInvokable]
		public CustomAttributeTypedArgument TypedValue
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x0600454D RID: 17741 RVA: 0x000FED13 File Offset: 0x000FCF13
		[__DynamicallyInvokable]
		public string MemberName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberInfo.Name;
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x0600454E RID: 17742 RVA: 0x000FED20 File Offset: 0x000FCF20
		[__DynamicallyInvokable]
		public bool IsField
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberInfo is FieldInfo;
			}
		}

		// Token: 0x04001C59 RID: 7257
		private MemberInfo m_memberInfo;

		// Token: 0x04001C5A RID: 7258
		private CustomAttributeTypedArgument m_value;
	}
}
