using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.Win32;

namespace System.StubHelpers
{
	// Token: 0x0200058D RID: 1421
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class UTF8Marshaler
	{
		// Token: 0x060042C2 RID: 17090 RVA: 0x000F9234 File Offset: 0x000F7434
		[SecurityCritical]
		internal unsafe static IntPtr ConvertToNative(int flags, string strManaged, IntPtr pNativeBuffer)
		{
			if (strManaged == null)
			{
				return IntPtr.Zero;
			}
			StubHelpers.CheckStringLength(strManaged.Length);
			byte* ptr = (byte*)((void*)pNativeBuffer);
			int num;
			if (ptr != null)
			{
				num = (strManaged.Length + 1) * 3;
				num = strManaged.GetBytesFromEncoding(ptr, num, Encoding.UTF8);
			}
			else
			{
				num = Encoding.UTF8.GetByteCount(strManaged);
				ptr = (byte*)((void*)Marshal.AllocCoTaskMem(num + 1));
				strManaged.GetBytesFromEncoding(ptr, num, Encoding.UTF8);
			}
			ptr[num] = 0;
			return (IntPtr)((void*)ptr);
		}

		// Token: 0x060042C3 RID: 17091 RVA: 0x000F92B0 File Offset: 0x000F74B0
		[SecurityCritical]
		internal unsafe static string ConvertToManaged(IntPtr cstr)
		{
			if (IntPtr.Zero == cstr)
			{
				return null;
			}
			int byteLength = StubHelpers.strlen((sbyte*)((void*)cstr));
			return string.CreateStringFromEncoding((byte*)((void*)cstr), byteLength, Encoding.UTF8);
		}

		// Token: 0x060042C4 RID: 17092 RVA: 0x000F92E9 File Offset: 0x000F74E9
		[SecurityCritical]
		internal static void ClearNative(IntPtr pNative)
		{
			if (pNative != IntPtr.Zero)
			{
				Win32Native.CoTaskMemFree(pNative);
			}
		}

		// Token: 0x04001BCF RID: 7119
		private const int MAX_UTF8_CHAR_SIZE = 3;
	}
}
