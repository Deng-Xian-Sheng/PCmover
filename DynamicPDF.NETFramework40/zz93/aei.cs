using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x0200048F RID: 1167
	internal abstract class aei
	{
		// Token: 0x06003017 RID: 12311
		[SecurityCritical]
		internal abstract int jt([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x06003018 RID: 12312
		[SecurityCritical]
		internal abstract int ju([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x06003019 RID: 12313
		[SecurityCritical]
		internal abstract int jv(IntPtr A_0);

		// Token: 0x0600301A RID: 12314
		[SecurityCritical]
		internal abstract IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x0600301B RID: 12315
		[SecurityCritical]
		internal abstract IntPtr jx(IntPtr A_0, uint A_1);

		// Token: 0x0600301C RID: 12316
		[SecurityCritical]
		internal abstract IntPtr jy(IntPtr A_0);

		// Token: 0x0600301D RID: 12317
		[SecurityCritical]
		internal abstract IntPtr jz(IntPtr A_0);
	}
}
