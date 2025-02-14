﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Microsoft.Win32;

namespace System.StubHelpers
{
	// Token: 0x0200058F RID: 1423
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class BSTRMarshaler
	{
		// Token: 0x060042C7 RID: 17095 RVA: 0x000F93C0 File Offset: 0x000F75C0
		[SecurityCritical]
		internal unsafe static IntPtr ConvertToNative(string strManaged, IntPtr pNativeBuffer)
		{
			if (strManaged == null)
			{
				return IntPtr.Zero;
			}
			StubHelpers.CheckStringLength(strManaged.Length);
			byte b;
			bool flag = strManaged.TryGetTrailByte(out b);
			uint num = (uint)(strManaged.Length * 2);
			if (flag)
			{
				num += 1U;
			}
			byte* ptr;
			if (pNativeBuffer != IntPtr.Zero)
			{
				*(int*)pNativeBuffer.ToPointer() = (int)num;
				ptr = (byte*)pNativeBuffer.ToPointer() + 4;
			}
			else
			{
				ptr = (byte*)Win32Native.SysAllocStringByteLen(null, num).ToPointer();
			}
			fixed (string text = strManaged)
			{
				char* ptr2 = text;
				if (ptr2 != null)
				{
					ptr2 += RuntimeHelpers.OffsetToStringData / 2;
				}
				Buffer.Memcpy(ptr, (byte*)ptr2, (strManaged.Length + 1) * 2);
			}
			if (flag)
			{
				ptr[num - 1U] = b;
			}
			return (IntPtr)((void*)ptr);
		}

		// Token: 0x060042C8 RID: 17096 RVA: 0x000F946C File Offset: 0x000F766C
		[SecurityCritical]
		internal unsafe static string ConvertToManaged(IntPtr bstr)
		{
			if (IntPtr.Zero == bstr)
			{
				return null;
			}
			uint num = Win32Native.SysStringByteLen(bstr);
			StubHelpers.CheckStringLength(num);
			string text;
			if (num == 1U)
			{
				text = string.FastAllocateString(0);
			}
			else
			{
				text = new string((char*)((void*)bstr), 0, (int)(num / 2U));
			}
			if ((num & 1U) == 1U)
			{
				text.SetTrailByte(((byte*)bstr.ToPointer())[num - 1U]);
			}
			return text;
		}

		// Token: 0x060042C9 RID: 17097 RVA: 0x000F94CC File Offset: 0x000F76CC
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
