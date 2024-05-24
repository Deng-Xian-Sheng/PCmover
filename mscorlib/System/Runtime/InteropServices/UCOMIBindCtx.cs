using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200097A RID: 2426
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IBindCtx instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("0000000e-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIBindCtx
	{
		// Token: 0x06006271 RID: 25201
		void RegisterObjectBound([MarshalAs(UnmanagedType.Interface)] object punk);

		// Token: 0x06006272 RID: 25202
		void RevokeObjectBound([MarshalAs(UnmanagedType.Interface)] object punk);

		// Token: 0x06006273 RID: 25203
		void ReleaseBoundObjects();

		// Token: 0x06006274 RID: 25204
		void SetBindOptions([In] ref BIND_OPTS pbindopts);

		// Token: 0x06006275 RID: 25205
		void GetBindOptions(ref BIND_OPTS pbindopts);

		// Token: 0x06006276 RID: 25206
		void GetRunningObjectTable(out UCOMIRunningObjectTable pprot);

		// Token: 0x06006277 RID: 25207
		void RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] object punk);

		// Token: 0x06006278 RID: 25208
		void GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

		// Token: 0x06006279 RID: 25209
		void EnumObjectParam(out UCOMIEnumString ppenum);

		// Token: 0x0600627A RID: 25210
		void RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
	}
}
