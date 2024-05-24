using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Standard
{
	// Token: 0x02000059 RID: 89
	internal sealed class SafeGdiplusStartupToken : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000867A File Offset: 0x0000687A
		private SafeGdiplusStartupToken(IntPtr ptr) : base(true)
		{
			this.handle = ptr;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000868A File Offset: 0x0000688A
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			return NativeMethods.GdiplusShutdown(this.handle) == Status.Ok;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000869C File Offset: 0x0000689C
		public static SafeGdiplusStartupToken Startup()
		{
			IntPtr ptr;
			StartupOutput startupOutput;
			if (NativeMethods.GdiplusStartup(out ptr, new StartupInput(), out startupOutput) == Status.Ok)
			{
				return new SafeGdiplusStartupToken(ptr);
			}
			throw new Exception("Unable to initialize GDI+");
		}
	}
}
