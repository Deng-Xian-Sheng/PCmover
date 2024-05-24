using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x0200004C RID: 76
	public class SafeRegionHandle : ZeroInvalidHandle
	{
		// Token: 0x060001E9 RID: 489 RVA: 0x000070B4 File Offset: 0x000052B4
		protected override bool ReleaseHandle()
		{
			return CoreNativeMethods.DeleteObject(this.handle);
		}
	}
}
