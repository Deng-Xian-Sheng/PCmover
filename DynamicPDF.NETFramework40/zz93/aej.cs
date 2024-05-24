using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000490 RID: 1168
	internal class aej : aei
	{
		// Token: 0x0600301F RID: 12319
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBGlyphInfo")]
		private static extern int a([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x06003020 RID: 12320 RVA: 0x001B18F0 File Offset: 0x001B08F0
		[SecurityCritical]
		internal override int jt([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return aej.a(A_0, A_1);
		}

		// Token: 0x06003021 RID: 12321
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBPosInfo")]
		private static extern int a([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x06003022 RID: 12322 RVA: 0x001B190C File Offset: 0x001B090C
		[SecurityCritical]
		internal override int ju([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return aej.a(A_0, A_1);
		}

		// Token: 0x06003023 RID: 12323
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBBufferLength")]
		private static extern int c(IntPtr A_0);

		// Token: 0x06003024 RID: 12324 RVA: 0x001B1928 File Offset: 0x001B0928
		[SecurityCritical]
		internal override int jv(IntPtr A_0)
		{
			return aej.c(A_0);
		}

		// Token: 0x06003025 RID: 12325
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "ProcessHBString")]
		private static extern IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x06003026 RID: 12326 RVA: 0x001B1940 File Offset: 0x001B0940
		[SecurityCritical]
		internal override IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return aej.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003027 RID: 12327
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateHBFont")]
		private static extern IntPtr a(IntPtr A_0, uint A_1);

		// Token: 0x06003028 RID: 12328 RVA: 0x001B195C File Offset: 0x001B095C
		[SecurityCritical]
		internal override IntPtr jx(IntPtr A_0, uint A_1)
		{
			return aej.a(A_0, A_1);
		}

		// Token: 0x06003029 RID: 12329
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBBuffer")]
		private static extern IntPtr b(IntPtr A_0);

		// Token: 0x0600302A RID: 12330 RVA: 0x001B1978 File Offset: 0x001B0978
		[SecurityCritical]
		internal override IntPtr jy(IntPtr A_0)
		{
			return aej.b(A_0);
		}

		// Token: 0x0600302B RID: 12331
		[SecurityCritical]
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBFont")]
		private static extern IntPtr a(IntPtr A_0);

		// Token: 0x0600302C RID: 12332 RVA: 0x001B1990 File Offset: 0x001B0990
		[SecurityCritical]
		internal override IntPtr jz(IntPtr A_0)
		{
			return aej.a(A_0);
		}

		// Token: 0x040016EB RID: 5867
		private const string a = "__Internal";
	}
}
