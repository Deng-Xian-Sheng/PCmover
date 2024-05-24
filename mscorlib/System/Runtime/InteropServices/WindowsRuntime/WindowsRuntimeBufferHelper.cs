﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A13 RID: 2579
	[FriendAccessAllowed]
	internal static class WindowsRuntimeBufferHelper
	{
		// Token: 0x060065B9 RID: 26041
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("QCall")]
		private unsafe static extern void StoreOverlappedPtrInCCW(ObjectHandleOnStack windowsRuntimeBuffer, NativeOverlapped* overlapped);

		// Token: 0x060065BA RID: 26042 RVA: 0x00159B39 File Offset: 0x00157D39
		[FriendAccessAllowed]
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal unsafe static void StoreOverlappedInCCW(object windowsRuntimeBuffer, NativeOverlapped* overlapped)
		{
			WindowsRuntimeBufferHelper.StoreOverlappedPtrInCCW(JitHelpers.GetObjectHandleOnStack<object>(ref windowsRuntimeBuffer), overlapped);
		}
	}
}
