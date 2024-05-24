using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Threading
{
	// Token: 0x020004FE RID: 1278
	[TypeForwardedFrom("System.Core, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[Serializable]
	public class LockRecursionException : Exception
	{
		// Token: 0x06003C56 RID: 15446 RVA: 0x000E4215 File Offset: 0x000E2415
		[__DynamicallyInvokable]
		public LockRecursionException()
		{
		}

		// Token: 0x06003C57 RID: 15447 RVA: 0x000E421D File Offset: 0x000E241D
		[__DynamicallyInvokable]
		public LockRecursionException(string message) : base(message)
		{
		}

		// Token: 0x06003C58 RID: 15448 RVA: 0x000E4226 File Offset: 0x000E2426
		protected LockRecursionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06003C59 RID: 15449 RVA: 0x000E4230 File Offset: 0x000E2430
		[__DynamicallyInvokable]
		public LockRecursionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
