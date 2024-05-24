using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000930 RID: 2352
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class OptionalAttribute : Attribute
	{
		// Token: 0x0600602F RID: 24623 RVA: 0x0014BA2F File Offset: 0x00149C2F
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			if (!parameter.IsOptional)
			{
				return null;
			}
			return new OptionalAttribute();
		}

		// Token: 0x06006030 RID: 24624 RVA: 0x0014BA40 File Offset: 0x00149C40
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return parameter.IsOptional;
		}

		// Token: 0x06006031 RID: 24625 RVA: 0x0014BA48 File Offset: 0x00149C48
		[__DynamicallyInvokable]
		public OptionalAttribute()
		{
		}
	}
}
