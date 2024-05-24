using System;
using System.Security.Permissions;

namespace System.Security
{
	// Token: 0x020001F0 RID: 496
	[SecurityCritical]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	public abstract class SecurityState
	{
		// Token: 0x06001E03 RID: 7683 RVA: 0x00068C78 File Offset: 0x00066E78
		[SecurityCritical]
		public bool IsStateAvailable()
		{
			AppDomainManager currentAppDomainManager = AppDomainManager.CurrentAppDomainManager;
			return currentAppDomainManager != null && currentAppDomainManager.CheckSecuritySettings(this);
		}

		// Token: 0x06001E04 RID: 7684
		public abstract void EnsureState();
	}
}
