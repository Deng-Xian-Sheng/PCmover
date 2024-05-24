using System;
using System.Security;

namespace System.Runtime.Remoting.Proxies
{
	// Token: 0x02000803 RID: 2051
	internal sealed class __TransparentProxy
	{
		// Token: 0x06005868 RID: 22632 RVA: 0x00137DC5 File Offset: 0x00135FC5
		private __TransparentProxy()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Constructor"));
		}

		// Token: 0x0400284A RID: 10314
		[SecurityCritical]
		private RealProxy _rp;

		// Token: 0x0400284B RID: 10315
		private object _stubData;

		// Token: 0x0400284C RID: 10316
		private IntPtr _pMT;

		// Token: 0x0400284D RID: 10317
		private IntPtr _pInterfaceMT;

		// Token: 0x0400284E RID: 10318
		private IntPtr _stub;
	}
}
