using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005A6 RID: 1446
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class HResultExceptionMarshaler
	{
		// Token: 0x06004323 RID: 17187 RVA: 0x000FA1A6 File Offset: 0x000F83A6
		internal static int ConvertToNative(Exception ex)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			if (ex == null)
			{
				return 0;
			}
			return ex._HResult;
		}

		// Token: 0x06004324 RID: 17188 RVA: 0x000FA1CC File Offset: 0x000F83CC
		[SecuritySafeCritical]
		internal static Exception ConvertToManaged(int hr)
		{
			if (!Environment.IsWinRTSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
			}
			Exception result = null;
			if (hr < 0)
			{
				result = StubHelpers.InternalGetCOMHRExceptionObject(hr, IntPtr.Zero, null, true);
			}
			return result;
		}
	}
}
