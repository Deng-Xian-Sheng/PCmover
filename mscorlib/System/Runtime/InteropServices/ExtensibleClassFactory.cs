using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000962 RID: 2402
	[ComVisible(true)]
	public sealed class ExtensibleClassFactory
	{
		// Token: 0x0600621E RID: 25118 RVA: 0x0014F685 File Offset: 0x0014D885
		private ExtensibleClassFactory()
		{
		}

		// Token: 0x0600621F RID: 25119
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void RegisterObjectCreationCallback(ObjectCreationDelegate callback);
	}
}
