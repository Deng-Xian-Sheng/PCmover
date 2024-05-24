using System;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Native
{
	// Token: 0x0200000D RID: 13
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
	public sealed class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00003626 File Offset: 0x00001826
		private SafeLibraryHandle() : base(true)
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000362F File Offset: 0x0000182F
		protected override bool ReleaseHandle()
		{
			return UnsafeNativeMethods.FreeLibrary(this.handle);
		}
	}
}
