using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000491 RID: 1169
	internal class aek : aei
	{
		// Token: 0x0600302E RID: 12334
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBGlyphInfo")]
		private static extern int a([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x0600302F RID: 12335 RVA: 0x001B19B0 File Offset: 0x001B09B0
		[SecurityCritical]
		internal override int jt([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return aek.a(A_0, A_1);
		}

		// Token: 0x06003030 RID: 12336
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBPosInfo")]
		private static extern int a([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x06003031 RID: 12337 RVA: 0x001B19CC File Offset: 0x001B09CC
		[SecurityCritical]
		internal override int ju([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return aek.a(A_0, A_1);
		}

		// Token: 0x06003032 RID: 12338
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBBufferLength")]
		private static extern int c(IntPtr A_0);

		// Token: 0x06003033 RID: 12339 RVA: 0x001B19E8 File Offset: 0x001B09E8
		[SecurityCritical]
		internal override int jv(IntPtr A_0)
		{
			return aek.c(A_0);
		}

		// Token: 0x06003034 RID: 12340
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "ProcessHBString")]
		private static extern IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x06003035 RID: 12341 RVA: 0x001B1A00 File Offset: 0x001B0A00
		[SecurityCritical]
		internal override IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return aek.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003036 RID: 12342
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateHBFont")]
		private static extern IntPtr a(IntPtr A_0, uint A_1);

		// Token: 0x06003037 RID: 12343 RVA: 0x001B1A1C File Offset: 0x001B0A1C
		[SecurityCritical]
		internal override IntPtr jx(IntPtr A_0, uint A_1)
		{
			return aek.a(A_0, A_1);
		}

		// Token: 0x06003038 RID: 12344
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBBuffer")]
		private static extern IntPtr b(IntPtr A_0);

		// Token: 0x06003039 RID: 12345 RVA: 0x001B1A38 File Offset: 0x001B0A38
		[SecurityCritical]
		internal override IntPtr jy(IntPtr A_0)
		{
			return aek.b(A_0);
		}

		// Token: 0x0600303A RID: 12346
		[SecurityCritical]
		[DllImport("DPDFNative_x86", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBFont")]
		private static extern IntPtr a(IntPtr A_0);

		// Token: 0x0600303B RID: 12347 RVA: 0x001B1A50 File Offset: 0x001B0A50
		[SecurityCritical]
		internal override IntPtr jz(IntPtr A_0)
		{
			return aek.a(A_0);
		}

		// Token: 0x040016EC RID: 5868
		private const string a = "DPDFNative_x86";
	}
}
