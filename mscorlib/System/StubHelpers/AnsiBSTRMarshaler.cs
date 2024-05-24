using System;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Microsoft.Win32;

namespace System.StubHelpers
{
	// Token: 0x02000591 RID: 1425
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class AnsiBSTRMarshaler
	{
		// Token: 0x060042CD RID: 17101 RVA: 0x000F959C File Offset: 0x000F779C
		[SecurityCritical]
		internal static IntPtr ConvertToNative(int flags, string strManaged)
		{
			if (strManaged == null)
			{
				return IntPtr.Zero;
			}
			int length = strManaged.Length;
			StubHelpers.CheckStringLength(length);
			byte[] str = null;
			int len = 0;
			if (length > 0)
			{
				str = AnsiCharMarshaler.DoAnsiConversion(strManaged, (flags & 255) != 0, flags >> 8 != 0, out len);
			}
			return Win32Native.SysAllocStringByteLen(str, (uint)len);
		}

		// Token: 0x060042CE RID: 17102 RVA: 0x000F95E7 File Offset: 0x000F77E7
		[SecurityCritical]
		internal unsafe static string ConvertToManaged(IntPtr bstr)
		{
			if (IntPtr.Zero == bstr)
			{
				return null;
			}
			return new string((sbyte*)((void*)bstr));
		}

		// Token: 0x060042CF RID: 17103 RVA: 0x000F9603 File Offset: 0x000F7803
		[SecurityCritical]
		internal static void ClearNative(IntPtr pNative)
		{
			if (IntPtr.Zero != pNative)
			{
				Win32Native.SysFreeString(pNative);
			}
		}
	}
}
