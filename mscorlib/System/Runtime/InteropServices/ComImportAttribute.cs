using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092B RID: 2347
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComImportAttribute : Attribute
	{
		// Token: 0x06006021 RID: 24609 RVA: 0x0014B976 File Offset: 0x00149B76
		internal static Attribute GetCustomAttribute(RuntimeType type)
		{
			if ((type.Attributes & TypeAttributes.Import) == TypeAttributes.NotPublic)
			{
				return null;
			}
			return new ComImportAttribute();
		}

		// Token: 0x06006022 RID: 24610 RVA: 0x0014B98D File Offset: 0x00149B8D
		internal static bool IsDefined(RuntimeType type)
		{
			return (type.Attributes & TypeAttributes.Import) > TypeAttributes.NotPublic;
		}

		// Token: 0x06006023 RID: 24611 RVA: 0x0014B99E File Offset: 0x00149B9E
		[__DynamicallyInvokable]
		public ComImportAttribute()
		{
		}
	}
}
