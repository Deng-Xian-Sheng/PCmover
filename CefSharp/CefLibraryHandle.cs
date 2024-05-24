using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CefSharp
{
	// Token: 0x0200001A RID: 26
	public class CefLibraryHandle : SafeHandle
	{
		// Token: 0x0600006C RID: 108 RVA: 0x000026C8 File Offset: 0x000008C8
		public CefLibraryHandle(string path) : base(IntPtr.Zero, true)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException("NotFound", path);
			}
			IntPtr handle = CefLibraryHandle.LoadLibraryEx(path, IntPtr.Zero, CefLibraryHandle.LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);
			base.SetHandle(handle);
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002709 File Offset: 0x00000909
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000271B File Offset: 0x0000091B
		protected override bool ReleaseHandle()
		{
			return CefLibraryHandle.FreeLibrary(this.handle);
		}

		// Token: 0x0600006F RID: 111
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, CefLibraryHandle.LoadLibraryFlags dwFlags);

		// Token: 0x06000070 RID: 112
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeLibrary(IntPtr hModule);

		// Token: 0x02000458 RID: 1112
		[Flags]
		private enum LoadLibraryFlags : uint
		{
			// Token: 0x04001187 RID: 4487
			DONT_RESOLVE_DLL_REFERENCES = 1U,
			// Token: 0x04001188 RID: 4488
			LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16U,
			// Token: 0x04001189 RID: 4489
			LOAD_LIBRARY_AS_DATAFILE = 2U,
			// Token: 0x0400118A RID: 4490
			LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 64U,
			// Token: 0x0400118B RID: 4491
			LOAD_LIBRARY_AS_IMAGE_RESOURCE = 32U,
			// Token: 0x0400118C RID: 4492
			LOAD_WITH_ALTERED_SEARCH_PATH = 8U
		}
	}
}
