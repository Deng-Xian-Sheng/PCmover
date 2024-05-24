using System;

namespace ControlzEx.Standard
{
	// Token: 0x020000BA RID: 186
	internal static class ShellUtil
	{
		// Token: 0x0600037A RID: 890 RVA: 0x000098BF File Offset: 0x00007ABF
		public static string GetPathFromShellItem(IShellItem item)
		{
			return item.GetDisplayName((SIGDN)2147647488U);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000098CC File Offset: 0x00007ACC
		public static IShellItem2 GetShellItemForPath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			Guid guid = new Guid("7e9fb0d3-919f-4307-ab2e-9b1860310c93");
			object obj;
			HRESULT hrLeft = NativeMethods.SHCreateItemFromParsingName(path, null, ref guid, out obj);
			if (hrLeft == (HRESULT)Win32Error.ERROR_FILE_NOT_FOUND || hrLeft == (HRESULT)Win32Error.ERROR_PATH_NOT_FOUND)
			{
				hrLeft = HRESULT.S_OK;
				obj = null;
			}
			hrLeft.ThrowIfFailed();
			return (IShellItem2)obj;
		}
	}
}
