using System;

namespace System.Runtime.Remoting.Proxies
{
	// Token: 0x020007FF RID: 2047
	internal struct MessageData
	{
		// Token: 0x04002831 RID: 10289
		internal IntPtr pFrame;

		// Token: 0x04002832 RID: 10290
		internal IntPtr pMethodDesc;

		// Token: 0x04002833 RID: 10291
		internal IntPtr pDelegateMD;

		// Token: 0x04002834 RID: 10292
		internal IntPtr pSig;

		// Token: 0x04002835 RID: 10293
		internal IntPtr thGoverningType;

		// Token: 0x04002836 RID: 10294
		internal int iFlags;
	}
}
