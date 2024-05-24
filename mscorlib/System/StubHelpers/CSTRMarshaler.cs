using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;

namespace System.StubHelpers
{
	// Token: 0x0200058C RID: 1420
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class CSTRMarshaler
	{
		// Token: 0x060042BF RID: 17087 RVA: 0x000F9158 File Offset: 0x000F7358
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
			if (ptr != null || Marshal.SystemMaxDBCSCharSize == 1)
			{
				num = (strManaged.Length + 1) * Marshal.SystemMaxDBCSCharSize;
				if (ptr == null)
				{
					ptr = (byte*)((void*)Marshal.AllocCoTaskMem(num + 1));
				}
				num = strManaged.ConvertToAnsi(ptr, num + 1, (flags & 255) != 0, flags >> 8 != 0);
			}
			else
			{
				byte[] src = AnsiCharMarshaler.DoAnsiConversion(strManaged, (flags & 255) != 0, flags >> 8 != 0, out num);
				ptr = (byte*)((void*)Marshal.AllocCoTaskMem(num + 2));
				Buffer.Memcpy(ptr, 0, src, 0, num);
			}
			ptr[num] = 0;
			ptr[num + 1] = 0;
			return (IntPtr)((void*)ptr);
		}

		// Token: 0x060042C0 RID: 17088 RVA: 0x000F920F File Offset: 0x000F740F
		[SecurityCritical]
		internal unsafe static string ConvertToManaged(IntPtr cstr)
		{
			if (IntPtr.Zero == cstr)
			{
				return null;
			}
			return new string((sbyte*)((void*)cstr));
		}

		// Token: 0x060042C1 RID: 17089 RVA: 0x000F922B File Offset: 0x000F742B
		[SecurityCritical]
		internal static void ClearNative(IntPtr pNative)
		{
			Win32Native.CoTaskMemFree(pNative);
		}
	}
}
