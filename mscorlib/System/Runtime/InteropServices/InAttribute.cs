using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092E RID: 2350
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class InAttribute : Attribute
	{
		// Token: 0x06006029 RID: 24617 RVA: 0x0014B9ED File Offset: 0x00149BED
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			if (!parameter.IsIn)
			{
				return null;
			}
			return new InAttribute();
		}

		// Token: 0x0600602A RID: 24618 RVA: 0x0014B9FE File Offset: 0x00149BFE
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return parameter.IsIn;
		}

		// Token: 0x0600602B RID: 24619 RVA: 0x0014BA06 File Offset: 0x00149C06
		[__DynamicallyInvokable]
		public InAttribute()
		{
		}
	}
}
