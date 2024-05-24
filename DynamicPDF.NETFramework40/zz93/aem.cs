using System;
using System.Runtime.InteropServices;
using System.Security;

namespace zz93
{
	// Token: 0x02000493 RID: 1171
	internal class aem : aei
	{
		// Token: 0x0600304C RID: 12364
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBGlyphInfo")]
		private static extern int a([In] [Out] aeg[] A_0, IntPtr A_1);

		// Token: 0x0600304D RID: 12365 RVA: 0x001B1B30 File Offset: 0x001B0B30
		[SecurityCritical]
		internal override int jt([In] [Out] aeg[] A_0, IntPtr A_1)
		{
			return aem.a(A_0, A_1);
		}

		// Token: 0x0600304E RID: 12366
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBPosInfo")]
		private static extern int a([In] [Out] aeh[] A_0, IntPtr A_1);

		// Token: 0x0600304F RID: 12367 RVA: 0x001B1B4C File Offset: 0x001B0B4C
		[SecurityCritical]
		internal override int ju([In] [Out] aeh[] A_0, IntPtr A_1)
		{
			return aem.a(A_0, A_1);
		}

		// Token: 0x06003050 RID: 12368
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHBBufferLength")]
		private static extern int c(IntPtr A_0);

		// Token: 0x06003051 RID: 12369 RVA: 0x001B1B68 File Offset: 0x001B0B68
		[SecurityCritical]
		internal override int jv(IntPtr A_0)
		{
			return aem.c(A_0);
		}

		// Token: 0x06003052 RID: 12370
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "ProcessHBString")]
		private static extern IntPtr a(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3);

		// Token: 0x06003053 RID: 12371 RVA: 0x001B1B80 File Offset: 0x001B0B80
		[SecurityCritical]
		internal override IntPtr jw(IntPtr A_0, uint A_1, IntPtr A_2, uint A_3)
		{
			return aem.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06003054 RID: 12372
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateHBFont")]
		private static extern IntPtr a(IntPtr A_0, uint A_1);

		// Token: 0x06003055 RID: 12373 RVA: 0x001B1B9C File Offset: 0x001B0B9C
		[SecurityCritical]
		internal override IntPtr jx(IntPtr A_0, uint A_1)
		{
			return aem.a(A_0, A_1);
		}

		// Token: 0x06003056 RID: 12374
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBBuffer")]
		private static extern IntPtr b(IntPtr A_0);

		// Token: 0x06003057 RID: 12375 RVA: 0x001B1BB8 File Offset: 0x001B0BB8
		[SecurityCritical]
		internal override IntPtr jy(IntPtr A_0)
		{
			return aem.b(A_0);
		}

		// Token: 0x06003058 RID: 12376
		[SecurityCritical]
		[DllImport("DPDFToolkitOneNative_ARM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DestroyHBFont")]
		private static extern IntPtr a(IntPtr A_0);

		// Token: 0x06003059 RID: 12377 RVA: 0x001B1BD0 File Offset: 0x001B0BD0
		[SecurityCritical]
		internal override IntPtr jz(IntPtr A_0)
		{
			return aem.a(A_0);
		}

		// Token: 0x040016EE RID: 5870
		private const string a = "DPDFToolkitOneNative_ARM";
	}
}
