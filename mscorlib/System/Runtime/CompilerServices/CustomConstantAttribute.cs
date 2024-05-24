using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008AD RID: 2221
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class CustomConstantAttribute : Attribute
	{
		// Token: 0x17001010 RID: 4112
		// (get) Token: 0x06005D93 RID: 23955
		[__DynamicallyInvokable]
		public abstract object Value { [__DynamicallyInvokable] get; }

		// Token: 0x06005D94 RID: 23956 RVA: 0x00149340 File Offset: 0x00147540
		internal static object GetRawConstant(CustomAttributeData attr)
		{
			foreach (CustomAttributeNamedArgument customAttributeNamedArgument in attr.NamedArguments)
			{
				if (customAttributeNamedArgument.MemberInfo.Name.Equals("Value"))
				{
					return customAttributeNamedArgument.TypedValue.Value;
				}
			}
			return DBNull.Value;
		}

		// Token: 0x06005D95 RID: 23957 RVA: 0x001493B8 File Offset: 0x001475B8
		[__DynamicallyInvokable]
		protected CustomConstantAttribute()
		{
		}
	}
}
