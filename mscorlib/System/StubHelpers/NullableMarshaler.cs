using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005A1 RID: 1441
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
	internal static class NullableMarshaler
	{
		// Token: 0x0600431B RID: 17179 RVA: 0x000F9FD0 File Offset: 0x000F81D0
		[SecurityCritical]
		internal static IntPtr ConvertToNative<T>(ref T? pManaged) where T : struct
		{
			if (pManaged != null)
			{
				object o = IReferenceFactory.CreateIReference(pManaged);
				return Marshal.GetComInterfaceForObject(o, typeof(IReference<T>));
			}
			return IntPtr.Zero;
		}

		// Token: 0x0600431C RID: 17180 RVA: 0x000FA00C File Offset: 0x000F820C
		[SecurityCritical]
		internal static void ConvertToManagedRetVoid<T>(IntPtr pNative, ref T? retObj) where T : struct
		{
			retObj = NullableMarshaler.ConvertToManaged<T>(pNative);
		}

		// Token: 0x0600431D RID: 17181 RVA: 0x000FA01C File Offset: 0x000F821C
		[SecurityCritical]
		internal static T? ConvertToManaged<T>(IntPtr pNative) where T : struct
		{
			if (pNative != IntPtr.Zero)
			{
				object wrapper = InterfaceMarshaler.ConvertToManagedWithoutUnboxing(pNative);
				return (T?)CLRIReferenceImpl<T>.UnboxHelper(wrapper);
			}
			return null;
		}
	}
}
