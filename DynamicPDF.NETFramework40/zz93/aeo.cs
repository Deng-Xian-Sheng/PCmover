using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000495 RID: 1173
	internal class aeo
	{
		// Token: 0x0600306A RID: 12394 RVA: 0x001B1CB0 File Offset: 0x001B0CB0
		internal static void a()
		{
			if (Environment.Is64BitProcess)
			{
				aeo.a = new ael();
			}
			else
			{
				aeo.a = new aek();
			}
		}

		// Token: 0x0600306B RID: 12395 RVA: 0x001B1CE4 File Offset: 0x001B0CE4
		static aeo()
		{
			aeo.a();
		}

		// Token: 0x0600306C RID: 12396 RVA: 0x001B1CF0 File Offset: 0x001B0CF0
		[SecurityCritical]
		internal static int a([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return aeo.a.jt(A_0, A_1);
		}

		// Token: 0x0600306D RID: 12397 RVA: 0x001B1D10 File Offset: 0x001B0D10
		[SecurityCritical]
		internal static int a([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return aeo.a.ju(A_0, A_1);
		}

		// Token: 0x0600306E RID: 12398 RVA: 0x001B1D30 File Offset: 0x001B0D30
		[SecuritySafeCritical]
		internal static int c(IntPtr A_0)
		{
			return aeo.a.jv(A_0);
		}

		// Token: 0x0600306F RID: 12399 RVA: 0x001B1D50 File Offset: 0x001B0D50
		[SecuritySafeCritical]
		internal static IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return aeo.a.jw(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003070 RID: 12400 RVA: 0x001B1D70 File Offset: 0x001B0D70
		[SecuritySafeCritical]
		internal static IntPtr a(IntPtr A_0, uint A_1)
		{
			return aeo.a.jx(A_0, A_1);
		}

		// Token: 0x06003071 RID: 12401 RVA: 0x001B1D90 File Offset: 0x001B0D90
		[SecuritySafeCritical]
		internal static IntPtr b(IntPtr A_0)
		{
			return aeo.a.jy(A_0);
		}

		// Token: 0x06003072 RID: 12402 RVA: 0x001B1DB0 File Offset: 0x001B0DB0
		[SecuritySafeCritical]
		internal static IntPtr a(IntPtr A_0)
		{
			return aeo.a.jz(A_0);
		}

		// Token: 0x040016F0 RID: 5872
		private static aei a;
	}
}
