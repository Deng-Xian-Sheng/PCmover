using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x0200004B RID: 75
	public class SafeIconHandle : ZeroInvalidHandle
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00007080 File Offset: 0x00005280
		protected override bool ReleaseHandle()
		{
			return CoreNativeMethods.DestroyIcon(this.handle);
		}
	}
}
