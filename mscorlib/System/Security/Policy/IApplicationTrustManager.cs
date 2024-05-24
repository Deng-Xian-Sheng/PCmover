using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x0200035A RID: 858
	[ComVisible(true)]
	public interface IApplicationTrustManager : ISecurityEncodable
	{
		// Token: 0x06002A76 RID: 10870
		ApplicationTrust DetermineApplicationTrust(ActivationContext activationContext, TrustManagerContext context);
	}
}
