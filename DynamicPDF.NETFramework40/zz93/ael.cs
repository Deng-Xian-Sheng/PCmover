using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000492 RID: 1170
	internal class ael : aei
	{
		// Token: 0x0600303D RID: 12349
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBGlyphInfo")]
		private static extern int a([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x0600303E RID: 12350 RVA: 0x001B1A70 File Offset: 0x001B0A70
		[SecurityCritical]
		internal override int jt([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return ael.a(A_0, A_1);
		}

		// Token: 0x0600303F RID: 12351
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBPosInfo")]
		private static extern int a([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x06003040 RID: 12352 RVA: 0x001B1A8C File Offset: 0x001B0A8C
		[SecurityCritical]
		internal override int ju([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return ael.a(A_0, A_1);
		}

		// Token: 0x06003041 RID: 12353
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBBufferLength")]
		private static extern int c(IntPtr A_0);

		// Token: 0x06003042 RID: 12354 RVA: 0x001B1AA8 File Offset: 0x001B0AA8
		[SecurityCritical]
		internal override int jv(IntPtr A_0)
		{
			return ael.c(A_0);
		}

		// Token: 0x06003043 RID: 12355
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "ProcessHBString")]
		private static extern IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x06003044 RID: 12356 RVA: 0x001B1AC0 File Offset: 0x001B0AC0
		[SecurityCritical]
		internal override IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return ael.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003045 RID: 12357
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateHBFont")]
		private static extern IntPtr a(IntPtr A_0, uint A_1);

		// Token: 0x06003046 RID: 12358 RVA: 0x001B1ADC File Offset: 0x001B0ADC
		[SecurityCritical]
		internal override IntPtr jx(IntPtr A_0, uint A_1)
		{
			return ael.a(A_0, A_1);
		}

		// Token: 0x06003047 RID: 12359
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBBuffer")]
		private static extern IntPtr b(IntPtr A_0);

		// Token: 0x06003048 RID: 12360 RVA: 0x001B1AF8 File Offset: 0x001B0AF8
		[SecurityCritical]
		internal override IntPtr jy(IntPtr A_0)
		{
			return ael.b(A_0);
		}

		// Token: 0x06003049 RID: 12361
		[SecurityCritical]
		[DllImport("DPDFNative_x64", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBFont")]
		private static extern IntPtr a(IntPtr A_0);

		// Token: 0x0600304A RID: 12362 RVA: 0x001B1B10 File Offset: 0x001B0B10
		[SecurityCritical]
		internal override IntPtr jz(IntPtr A_0)
		{
			return ael.a(A_0);
		}

		// Token: 0x040016ED RID: 5869
		private const string a = "DPDFNative_x64";
	}
}
