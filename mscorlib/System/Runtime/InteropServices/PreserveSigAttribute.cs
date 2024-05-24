using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092D RID: 2349
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class PreserveSigAttribute : Attribute
	{
		// Token: 0x06006026 RID: 24614 RVA: 0x0014B9BD File Offset: 0x00149BBD
		internal static Attribute GetCustomAttribute(RuntimeMethodInfo method)
		{
			if ((method.GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) == MethodImplAttributes.IL)
			{
				return null;
			}
			return new PreserveSigAttribute();
		}

		// Token: 0x06006027 RID: 24615 RVA: 0x0014B9D4 File Offset: 0x00149BD4
		internal static bool IsDefined(RuntimeMethodInfo method)
		{
			return (method.GetMethodImplementationFlags() & MethodImplAttributes.PreserveSig) > MethodImplAttributes.IL;
		}

		// Token: 0x06006028 RID: 24616 RVA: 0x0014B9E5 File Offset: 0x00149BE5
		[__DynamicallyInvokable]
		public PreserveSigAttribute()
		{
		}
	}
}
