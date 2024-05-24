using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x0200004D RID: 77
	public class SafeWindowHandle : ZeroInvalidHandle
	{
		// Token: 0x060001EB RID: 491 RVA: 0x000070E8 File Offset: 0x000052E8
		protected override bool ReleaseHandle()
		{
			return this.IsInvalid || CoreNativeMethods.DestroyWindow(this.handle) != 0;
		}
	}
}
