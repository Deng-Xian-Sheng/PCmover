using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Standard
{
	// Token: 0x02000058 RID: 88
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public sealed class SafeHBITMAP : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x06000178 RID: 376 RVA: 0x00003626 File Offset: 0x00001826
		private SafeHBITMAP() : base(true)
		{
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000866D File Offset: 0x0000686D
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			return NativeMethods.DeleteObject(this.handle);
		}
	}
}
