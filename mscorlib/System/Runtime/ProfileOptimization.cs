using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime
{
	// Token: 0x02000719 RID: 1817
	public static class ProfileOptimization
	{
		// Token: 0x0600512F RID: 20783
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void InternalSetProfileRoot(string directoryPath);

		// Token: 0x06005130 RID: 20784
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void InternalStartProfile(string profile, IntPtr ptrNativeAssemblyLoadContext);

		// Token: 0x06005131 RID: 20785 RVA: 0x0011E5B5 File Offset: 0x0011C7B5
		[SecurityCritical]
		public static void SetProfileRoot(string directoryPath)
		{
			ProfileOptimization.InternalSetProfileRoot(directoryPath);
		}

		// Token: 0x06005132 RID: 20786 RVA: 0x0011E5BD File Offset: 0x0011C7BD
		[SecurityCritical]
		public static void StartProfile(string profile)
		{
			ProfileOptimization.InternalStartProfile(profile, IntPtr.Zero);
		}
	}
}
