using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004EF RID: 1263
	[SecurityCritical]
	internal class SafeCompressedStackHandle : SafeHandle
	{
		// Token: 0x06003BA5 RID: 15269 RVA: 0x000E283D File Offset: 0x000E0A3D
		public SafeCompressedStackHandle() : base(IntPtr.Zero, true)
		{
		}

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06003BA6 RID: 15270 RVA: 0x000E284B File Offset: 0x000E0A4B
		public override bool IsInvalid
		{
			[SecurityCritical]
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x06003BA7 RID: 15271 RVA: 0x000E285D File Offset: 0x000E0A5D
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			CompressedStack.DestroyDelayedCompressedStack(this.handle);
			this.handle = IntPtr.Zero;
			return true;
		}
	}
}
