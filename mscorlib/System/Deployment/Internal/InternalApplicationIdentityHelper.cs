using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal
{
	// Token: 0x0200066B RID: 1643
	[ComVisible(false)]
	public static class InternalApplicationIdentityHelper
	{
		// Token: 0x06004F0F RID: 20239 RVA: 0x0011C26C File Offset: 0x0011A46C
		[SecurityCritical]
		public static object GetInternalAppId(ApplicationIdentity id)
		{
			return id.Identity;
		}
	}
}
