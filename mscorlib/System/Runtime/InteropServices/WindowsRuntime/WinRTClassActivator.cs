using System;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A12 RID: 2578
	internal sealed class WinRTClassActivator : MarshalByRefObject, IWinRTClassActivator
	{
		// Token: 0x060065B4 RID: 26036 RVA: 0x00159A68 File Offset: 0x00157C68
		[SecurityCritical]
		public object ActivateInstance(string activatableClassId)
		{
			ManagedActivationFactory managedActivationFactory = WindowsRuntimeMarshal.GetManagedActivationFactory(this.LoadWinRTType(activatableClassId));
			return managedActivationFactory.ActivateInstance();
		}

		// Token: 0x060065B5 RID: 26037 RVA: 0x00159A88 File Offset: 0x00157C88
		[SecurityCritical]
		public IntPtr GetActivationFactory(string activatableClassId, ref Guid iid)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr result;
			try
			{
				intPtr = WindowsRuntimeMarshal.GetActivationFactoryForType(this.LoadWinRTType(activatableClassId));
				IntPtr zero = IntPtr.Zero;
				int num = Marshal.QueryInterface(intPtr, ref iid, out zero);
				if (num < 0)
				{
					Marshal.ThrowExceptionForHR(num);
				}
				result = zero;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.Release(intPtr);
				}
			}
			return result;
		}

		// Token: 0x060065B6 RID: 26038 RVA: 0x00159AEC File Offset: 0x00157CEC
		private Type LoadWinRTType(string acid)
		{
			Type type = Type.GetType(acid + ", Windows, ContentType=WindowsRuntime");
			if (type == null)
			{
				throw new COMException(-2147221164);
			}
			return type;
		}

		// Token: 0x060065B7 RID: 26039 RVA: 0x00159B1F File Offset: 0x00157D1F
		[SecurityCritical]
		internal IntPtr GetIWinRTClassActivator()
		{
			return Marshal.GetComInterfaceForObject(this, typeof(IWinRTClassActivator));
		}
	}
}
