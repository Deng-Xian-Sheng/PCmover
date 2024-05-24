using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200013A RID: 314
	internal static class TaskbarNativeMethods
	{
		// Token: 0x06000DA1 RID: 3489
		[DllImport("shell32.dll")]
		internal static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

		// Token: 0x06000DA2 RID: 3490
		[DllImport("shell32.dll")]
		internal static extern void GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] out string AppID);

		// Token: 0x06000DA3 RID: 3491
		[DllImport("shell32.dll")]
		internal static extern void SHAddToRecentDocs(ShellAddToRecentDocs flags, [MarshalAs(UnmanagedType.LPWStr)] string path);

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00032EC3 File Offset: 0x000310C3
		internal static void SHAddToRecentDocs(string path)
		{
			TaskbarNativeMethods.SHAddToRecentDocs(ShellAddToRecentDocs.PathW, path);
		}

		// Token: 0x06000DA5 RID: 3493
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern uint RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

		// Token: 0x06000DA6 RID: 3494
		[DllImport("shell32.dll")]
		public static extern int SHGetPropertyStoreForWindow(IntPtr hwnd, ref Guid iid, [MarshalAs(UnmanagedType.Interface)] out IPropertyStore propertyStore);

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00032ECE File Offset: 0x000310CE
		internal static void SetWindowAppId(IntPtr hwnd, string appId)
		{
			TaskbarNativeMethods.SetWindowProperty(hwnd, SystemProperties.System.AppUserModel.ID, appId);
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00032EE0 File Offset: 0x000310E0
		internal static void SetWindowProperty(IntPtr hwnd, PropertyKey propkey, string value)
		{
			IPropertyStore windowPropertyStore = TaskbarNativeMethods.GetWindowPropertyStore(hwnd);
			using (PropVariant propVariant = new PropVariant(value))
			{
				HResult result = windowPropertyStore.SetValue(ref propkey, propVariant);
				if (!CoreErrorHelper.Succeeded(result))
				{
					throw new ShellException(result);
				}
			}
			Marshal.ReleaseComObject(windowPropertyStore);
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00032F44 File Offset: 0x00031144
		internal static IPropertyStore GetWindowPropertyStore(IntPtr hwnd)
		{
			Guid guid = new Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99");
			IPropertyStore result;
			int num = TaskbarNativeMethods.SHGetPropertyStoreForWindow(hwnd, ref guid, out result);
			if (num != 0)
			{
				throw Marshal.GetExceptionForHR(num);
			}
			return result;
		}

		// Token: 0x04000559 RID: 1369
		internal const int WmCommand = 273;

		// Token: 0x0400055A RID: 1370
		internal const uint WmDwmSendIconThumbnail = 803U;

		// Token: 0x0400055B RID: 1371
		internal const uint WmDwmSendIconicLivePreviewBitmap = 806U;

		// Token: 0x0400055C RID: 1372
		internal static readonly uint WmTaskbarButtonCreated = TaskbarNativeMethods.RegisterWindowMessage("TaskbarButtonCreated");

		// Token: 0x0200013B RID: 315
		internal static class TaskbarGuids
		{
			// Token: 0x0400055D RID: 1373
			internal static Guid IObjectArray = new Guid("92CA9DCD-5622-4BBA-A805-5E9F541BD8C9");

			// Token: 0x0400055E RID: 1374
			internal static Guid IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
		}
	}
}
