using System;
using System.Runtime.InteropServices;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x0200004A RID: 74
	public abstract class ZeroInvalidHandle : SafeHandle
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x0000704A File Offset: 0x0000524A
		protected ZeroInvalidHandle() : base(IntPtr.Zero, true)
		{
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000705C File Offset: 0x0000525C
		public override bool IsInvalid
		{
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}
	}
}
