using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x02000595 RID: 1429
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class HStringMarshaler
	{
		// Token: 0x060042D5 RID: 17109 RVA: 0x000F9688 File Offset: 0x000F7888
		[SecurityCritical]
		internal unsafe static IntPtr ConvertToNative(string managed)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			if (managed == null)
			{
				throw new ArgumentNullException();
			}
			IntPtr result;
			int errorCode = UnsafeNativeMethods.WindowsCreateString(managed, managed.Length, &result);
			Marshal.ThrowExceptionForHR(errorCode, new IntPtr(-1));
			return result;
		}

		// Token: 0x060042D6 RID: 17110 RVA: 0x000F96D4 File Offset: 0x000F78D4
		[SecurityCritical]
		internal unsafe static IntPtr ConvertToNativeReference(string managed, [Out] HSTRING_HEADER* hstringHeader)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			if (managed == null)
			{
				throw new ArgumentNullException();
			}
			char* ptr = managed;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			IntPtr result;
			int errorCode = UnsafeNativeMethods.WindowsCreateStringReference(ptr, managed.Length, hstringHeader, &result);
			Marshal.ThrowExceptionForHR(errorCode, new IntPtr(-1));
			return result;
		}

		// Token: 0x060042D7 RID: 17111 RVA: 0x000F972F File Offset: 0x000F792F
		[SecurityCritical]
		internal static string ConvertToManaged(IntPtr hstring)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			return WindowsRuntimeMarshal.HStringToString(hstring);
		}

		// Token: 0x060042D8 RID: 17112 RVA: 0x000F974E File Offset: 0x000F794E
		[SecurityCritical]
		internal static void ClearNative(IntPtr hstring)
		{
			if (hstring != IntPtr.Zero)
			{
				UnsafeNativeMethods.WindowsDeleteString(hstring);
			}
		}
	}
}
