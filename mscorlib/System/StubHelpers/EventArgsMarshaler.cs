﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x0200059B RID: 1435
	[FriendAccessAllowed]
	internal static class EventArgsMarshaler
	{
		// Token: 0x060042E8 RID: 17128 RVA: 0x000F9790 File Offset: 0x000F7990
		[SecurityCritical]
		[FriendAccessAllowed]
		internal static IntPtr CreateNativeNCCEventArgsInstance(int action, object newItems, object oldItems, int newIndex, int oldIndex)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			RuntimeHelpers.PrepareConstrainedRegions();
			IntPtr result;
			try
			{
				if (newItems != null)
				{
					intPtr = Marshal.GetComInterfaceForObject(newItems, typeof(IBindableVector));
				}
				if (oldItems != null)
				{
					intPtr2 = Marshal.GetComInterfaceForObject(oldItems, typeof(IBindableVector));
				}
				result = EventArgsMarshaler.CreateNativeNCCEventArgsInstanceHelper(action, intPtr, intPtr2, newIndex, oldIndex);
			}
			finally
			{
				if (!intPtr2.IsNull())
				{
					Marshal.Release(intPtr2);
				}
				if (!intPtr.IsNull())
				{
					Marshal.Release(intPtr);
				}
			}
			return result;
		}

		// Token: 0x060042E9 RID: 17129
		[SecurityCritical]
		[FriendAccessAllowed]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall")]
		internal static extern IntPtr CreateNativePCEventArgsInstance([MarshalAs(UnmanagedType.HString)] string name);

		// Token: 0x060042EA RID: 17130
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall")]
		internal static extern IntPtr CreateNativeNCCEventArgsInstanceHelper(int action, IntPtr newItem, IntPtr oldItem, int newIndex, int oldIndex);
	}
}
