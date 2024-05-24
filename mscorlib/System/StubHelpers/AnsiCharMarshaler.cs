using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System.StubHelpers
{
	// Token: 0x0200058B RID: 1419
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class AnsiCharMarshaler
	{
		// Token: 0x060042BC RID: 17084 RVA: 0x000F90B0 File Offset: 0x000F72B0
		[SecurityCritical]
		internal unsafe static byte[] DoAnsiConversion(string str, bool fBestFit, bool fThrowOnUnmappableChar, out int cbLength)
		{
			byte[] array = new byte[(str.Length + 1) * Marshal.SystemMaxDBCSCharSize];
			byte[] array2;
			byte* pbNativeBuffer;
			if ((array2 = array) == null || array2.Length == 0)
			{
				pbNativeBuffer = null;
			}
			else
			{
				pbNativeBuffer = &array2[0];
			}
			cbLength = str.ConvertToAnsi(pbNativeBuffer, array.Length, fBestFit, fThrowOnUnmappableChar);
			array2 = null;
			return array;
		}

		// Token: 0x060042BD RID: 17085 RVA: 0x000F90FC File Offset: 0x000F72FC
		[SecurityCritical]
		internal unsafe static byte ConvertToNative(char managedChar, bool fBestFit, bool fThrowOnUnmappableChar)
		{
			int num = 2 * Marshal.SystemMaxDBCSCharSize;
			byte* ptr = stackalloc byte[(UIntPtr)num];
			int num2 = managedChar.ToString().ConvertToAnsi(ptr, num, fBestFit, fThrowOnUnmappableChar);
			return *ptr;
		}

		// Token: 0x060042BE RID: 17086 RVA: 0x000F912C File Offset: 0x000F732C
		internal static char ConvertToManaged(byte nativeChar)
		{
			byte[] bytes = new byte[]
			{
				nativeChar
			};
			string @string = Encoding.Default.GetString(bytes);
			return @string[0];
		}
	}
}
