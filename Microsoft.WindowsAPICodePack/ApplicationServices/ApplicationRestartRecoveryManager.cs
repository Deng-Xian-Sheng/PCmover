using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000002 RID: 2
	public static class ApplicationRestartRecoveryManager
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void RegisterForApplicationRecovery(RecoverySettings settings)
		{
			CoreHelpers.ThrowIfNotVista();
			if (settings == null)
			{
				throw new ArgumentNullException("settings");
			}
			GCHandle value = GCHandle.Alloc(settings.RecoveryData);
			HResult hresult = AppRestartRecoveryNativeMethods.RegisterApplicationRecoveryCallback(AppRestartRecoveryNativeMethods.InternalCallback, (IntPtr)value, settings.PingInterval, 0U);
			if (CoreErrorHelper.Succeeded(hresult))
			{
				return;
			}
			if (hresult == HResult.InvalidArguments)
			{
				throw new ArgumentException(LocalizedMessages.ApplicationRecoveryBadParameters, "settings");
			}
			throw new ApplicationRecoveryException(LocalizedMessages.ApplicationRecoveryFailedToRegister);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020D8 File Offset: 0x000002D8
		public static void UnregisterApplicationRecovery()
		{
			CoreHelpers.ThrowIfNotVista();
			HResult result = AppRestartRecoveryNativeMethods.UnregisterApplicationRecoveryCallback();
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ApplicationRecoveryException(LocalizedMessages.ApplicationRecoveryFailedToUnregister);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002108 File Offset: 0x00000308
		public static void UnregisterApplicationRestart()
		{
			CoreHelpers.ThrowIfNotVista();
			HResult result = AppRestartRecoveryNativeMethods.UnregisterApplicationRestart();
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ApplicationRecoveryException(LocalizedMessages.ApplicationRecoveryFailedToUnregisterForRestart);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002138 File Offset: 0x00000338
		public static bool ApplicationRecoveryInProgress()
		{
			CoreHelpers.ThrowIfNotVista();
			bool result = false;
			HResult result2 = AppRestartRecoveryNativeMethods.ApplicationRecoveryInProgress(out result);
			if (!CoreErrorHelper.Succeeded(result2))
			{
				throw new InvalidOperationException(LocalizedMessages.ApplicationRecoveryMustBeCalledFromCallback);
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002171 File Offset: 0x00000371
		public static void ApplicationRecoveryFinished(bool success)
		{
			CoreHelpers.ThrowIfNotVista();
			AppRestartRecoveryNativeMethods.ApplicationRecoveryFinished(success);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002184 File Offset: 0x00000384
		public static void RegisterForApplicationRestart(RestartSettings settings)
		{
			CoreHelpers.ThrowIfNotVista();
			if (settings == null)
			{
				throw new ArgumentNullException("settings");
			}
			HResult hresult = AppRestartRecoveryNativeMethods.RegisterApplicationRestart(settings.Command, settings.Restrictions);
			if (hresult == HResult.Fail)
			{
				throw new InvalidOperationException(LocalizedMessages.ApplicationRecoveryFailedToRegisterForRestart);
			}
			if (hresult == HResult.InvalidArguments)
			{
				throw new ArgumentException(LocalizedMessages.ApplicationRecoverFailedToRegisterForRestartBadParameters);
			}
		}
	}
}
