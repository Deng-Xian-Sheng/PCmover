using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092F RID: 2351
	[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class OutAttribute : Attribute
	{
		// Token: 0x0600602C RID: 24620 RVA: 0x0014BA0E File Offset: 0x00149C0E
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			if (!parameter.IsOut)
			{
				return null;
			}
			return new OutAttribute();
		}

		// Token: 0x0600602D RID: 24621 RVA: 0x0014BA1F File Offset: 0x00149C1F
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return parameter.IsOut;
		}

		// Token: 0x0600602E RID: 24622 RVA: 0x0014BA27 File Offset: 0x00149C27
		[__DynamicallyInvokable]
		public OutAttribute()
		{
		}
	}
}
