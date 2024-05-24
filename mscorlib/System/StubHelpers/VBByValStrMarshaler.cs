using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;

namespace System.StubHelpers
{
	// Token: 0x02000590 RID: 1424
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class VBByValStrMarshaler
	{
		// Token: 0x060042CA RID: 17098 RVA: 0x000F94E4 File Offset: 0x000F76E4
		[SecurityCritical]
		internal unsafe static IntPtr ConvertToNative(string strManaged, bool fBestFit, bool fThrowOnUnmappableChar, ref int cch)
		{
			if (strManaged == null)
			{
				return IntPtr.Zero;
			}
			cch = strManaged.Length;
			StubHelpers.CheckStringLength(cch);
			int cb = 4 + (cch + 1) * Marshal.SystemMaxDBCSCharSize;
			byte* ptr = (byte*)((void*)Marshal.AllocCoTaskMem(cb));
			int* ptr2 = (int*)ptr;
			ptr += 4;
			if (cch == 0)
			{
				*ptr = 0;
				*ptr2 = 0;
			}
			else
			{
				int num;
				byte[] src = AnsiCharMarshaler.DoAnsiConversion(strManaged, fBestFit, fThrowOnUnmappableChar, out num);
				Buffer.Memcpy(ptr, 0, src, 0, num);
				ptr[num] = 0;
				*ptr2 = num;
			}
			return new IntPtr((void*)ptr);
		}

		// Token: 0x060042CB RID: 17099 RVA: 0x000F9559 File Offset: 0x000F7759
		[SecurityCritical]
		internal unsafe static string ConvertToManaged(IntPtr pNative, int cch)
		{
			if (IntPtr.Zero == pNative)
			{
				return null;
			}
			return new string((sbyte*)((void*)pNative), 0, cch);
		}

		// Token: 0x060042CC RID: 17100 RVA: 0x000F9577 File Offset: 0x000F7777
		[SecurityCritical]
		internal static void ClearNative(IntPtr pNative)
		{
			if (IntPtr.Zero != pNative)
			{
				Win32Native.CoTaskMemFree((IntPtr)((long)pNative - 4L));
			}
		}
	}
}
