using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x0200059A RID: 1434
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class UriMarshaler
	{
		// Token: 0x060042E5 RID: 17125
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetRawUriFromNative(IntPtr pUri);

		// Token: 0x060042E6 RID: 17126
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern IntPtr CreateNativeUriInstanceHelper(char* rawUri, int strLen);

		// Token: 0x060042E7 RID: 17127 RVA: 0x000F9764 File Offset: 0x000F7964
		[SecurityCritical]
		internal unsafe static IntPtr CreateNativeUriInstance(string rawUri)
		{
			char* ptr = rawUri;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return UriMarshaler.CreateNativeUriInstanceHelper(ptr, rawUri.Length);
		}
	}
}
