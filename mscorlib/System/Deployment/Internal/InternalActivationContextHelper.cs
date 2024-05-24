using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal
{
	// Token: 0x0200066C RID: 1644
	[ComVisible(false)]
	public static class InternalActivationContextHelper
	{
		// Token: 0x06004F10 RID: 20240 RVA: 0x0011C274 File Offset: 0x0011A474
		[SecuritySafeCritical]
		public static object GetActivationContextData(ActivationContext appInfo)
		{
			return appInfo.ActivationContextData;
		}

		// Token: 0x06004F11 RID: 20241 RVA: 0x0011C27C File Offset: 0x0011A47C
		[SecuritySafeCritical]
		public static object GetApplicationComponentManifest(ActivationContext appInfo)
		{
			return appInfo.ApplicationComponentManifest;
		}

		// Token: 0x06004F12 RID: 20242 RVA: 0x0011C284 File Offset: 0x0011A484
		[SecuritySafeCritical]
		public static object GetDeploymentComponentManifest(ActivationContext appInfo)
		{
			return appInfo.DeploymentComponentManifest;
		}

		// Token: 0x06004F13 RID: 20243 RVA: 0x0011C28C File Offset: 0x0011A48C
		public static void PrepareForExecution(ActivationContext appInfo)
		{
			appInfo.PrepareForExecution();
		}

		// Token: 0x06004F14 RID: 20244 RVA: 0x0011C294 File Offset: 0x0011A494
		public static bool IsFirstRun(ActivationContext appInfo)
		{
			return appInfo.LastApplicationStateResult == ActivationContext.ApplicationStateDisposition.RunningFirstTime;
		}

		// Token: 0x06004F15 RID: 20245 RVA: 0x0011C2A3 File Offset: 0x0011A4A3
		public static byte[] GetApplicationManifestBytes(ActivationContext appInfo)
		{
			if (appInfo == null)
			{
				throw new ArgumentNullException("appInfo");
			}
			return appInfo.GetApplicationManifestBytes();
		}

		// Token: 0x06004F16 RID: 20246 RVA: 0x0011C2B9 File Offset: 0x0011A4B9
		public static byte[] GetDeploymentManifestBytes(ActivationContext appInfo)
		{
			if (appInfo == null)
			{
				throw new ArgumentNullException("appInfo");
			}
			return appInfo.GetDeploymentManifestBytes();
		}
	}
}
