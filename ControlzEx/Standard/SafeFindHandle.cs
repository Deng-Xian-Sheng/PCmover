using System;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Standard
{
	// Token: 0x02000056 RID: 86
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00003626 File Offset: 0x00001826
		[SecurityCritical]
		private SafeFindHandle() : base(true)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000084B2 File Offset: 0x000066B2
		protected override bool ReleaseHandle()
		{
			return NativeMethods.FindClose(this.handle);
		}
	}
}
