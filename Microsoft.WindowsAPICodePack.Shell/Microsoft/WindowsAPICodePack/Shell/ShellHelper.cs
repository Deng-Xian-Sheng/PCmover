using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000013 RID: 19
	internal static class ShellHelper
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00004414 File Offset: 0x00002614
		internal static string GetParsingName(IShellItem shellItem)
		{
			string result;
			if (shellItem == null)
			{
				result = null;
			}
			else
			{
				string text = null;
				IntPtr zero = IntPtr.Zero;
				HResult displayName = shellItem.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.DesktopAbsoluteParsing, out zero);
				if (displayName != HResult.Ok && displayName != HResult.InvalidArguments)
				{
					throw new ShellException(LocalizedMessages.ShellHelperGetParsingNameFailed, displayName);
				}
				if (zero != IntPtr.Zero)
				{
					text = Marshal.PtrToStringAuto(zero);
					Marshal.FreeCoTaskMem(zero);
					zero = IntPtr.Zero;
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000449C File Offset: 0x0000269C
		internal static string GetAbsolutePath(string path)
		{
			string result;
			if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
			{
				result = path;
			}
			else
			{
				result = Path.GetFullPath(path);
			}
			return result;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000044C8 File Offset: 0x000026C8
		internal static string GetItemType(IShellItem2 shellItem)
		{
			if (shellItem != null)
			{
				string result = null;
				HResult @string = shellItem.GetString(ref ShellHelper.ItemTypePropertyKey, out result);
				if (@string == HResult.Ok)
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004508 File Offset: 0x00002708
		internal static IntPtr PidlFromParsingName(string name)
		{
			IntPtr intPtr;
			ShellNativeMethods.ShellFileGetAttributesOptions shellFileGetAttributesOptions;
			int result = ShellNativeMethods.SHParseDisplayName(name, IntPtr.Zero, out intPtr, (ShellNativeMethods.ShellFileGetAttributesOptions)0, out shellFileGetAttributesOptions);
			return CoreErrorHelper.Succeeded(result) ? intPtr : IntPtr.Zero;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000453C File Offset: 0x0000273C
		internal static IntPtr PidlFromShellItem(IShellItem nativeShellItem)
		{
			IntPtr iunknownForObject = Marshal.GetIUnknownForObject(nativeShellItem);
			return ShellHelper.PidlFromUnknown(iunknownForObject);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000455C File Offset: 0x0000275C
		internal static IntPtr PidlFromUnknown(IntPtr unknown)
		{
			IntPtr intPtr;
			int result = ShellNativeMethods.SHGetIDListFromObject(unknown, out intPtr);
			return CoreErrorHelper.Succeeded(result) ? intPtr : IntPtr.Zero;
		}

		// Token: 0x04000027 RID: 39
		internal static PropertyKey ItemTypePropertyKey = new PropertyKey(new Guid("28636AA6-953D-11D2-B5D6-00C04FD918D0"), 11);
	}
}
