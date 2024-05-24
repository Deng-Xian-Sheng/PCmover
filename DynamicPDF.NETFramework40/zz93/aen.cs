using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000494 RID: 1172
	internal class aen : aei
	{
		// Token: 0x0600305B RID: 12379
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBGlyphInfo")]
		private static extern int a([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x0600305C RID: 12380 RVA: 0x001B1BF0 File Offset: 0x001B0BF0
		[SecurityCritical]
		internal override int jt([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return aen.a(A_0, A_1);
		}

		// Token: 0x0600305D RID: 12381
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBPosInfo")]
		private static extern int a([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x0600305E RID: 12382 RVA: 0x001B1C0C File Offset: 0x001B0C0C
		[SecurityCritical]
		internal override int ju([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return aen.a(A_0, A_1);
		}

		// Token: 0x0600305F RID: 12383
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBBufferLength")]
		private static extern int c(IntPtr A_0);

		// Token: 0x06003060 RID: 12384 RVA: 0x001B1C28 File Offset: 0x001B0C28
		[SecurityCritical]
		internal override int jv(IntPtr A_0)
		{
			return aen.c(A_0);
		}

		// Token: 0x06003061 RID: 12385
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "ProcessHBString")]
		private static extern IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x06003062 RID: 12386 RVA: 0x001B1C40 File Offset: 0x001B0C40
		[SecurityCritical]
		internal override IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return aen.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003063 RID: 12387
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateHBFont")]
		private static extern IntPtr a(IntPtr A_0, uint A_1);

		// Token: 0x06003064 RID: 12388 RVA: 0x001B1C5C File Offset: 0x001B0C5C
		[SecurityCritical]
		internal override IntPtr jx(IntPtr A_0, uint A_1)
		{
			return aen.a(A_0, A_1);
		}

		// Token: 0x06003065 RID: 12389
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBBuffer")]
		private static extern IntPtr b(IntPtr A_0);

		// Token: 0x06003066 RID: 12390 RVA: 0x001B1C78 File Offset: 0x001B0C78
		[SecurityCritical]
		internal override IntPtr jy(IntPtr A_0)
		{
			return aen.b(A_0);
		}

		// Token: 0x06003067 RID: 12391
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBFont")]
		private static extern IntPtr a(IntPtr A_0);

		// Token: 0x06003068 RID: 12392 RVA: 0x001B1C90 File Offset: 0x001B0C90
		[SecurityCritical]
		internal override IntPtr jz(IntPtr A_0)
		{
			return aen.a(A_0);
		}

		// Token: 0x040016EF RID: 5871
		private const string a = "DPDFToolkitOneNative";
	}
}
