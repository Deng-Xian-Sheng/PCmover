using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E1 RID: 2529
	[Guid("00000035-0000-0000-C000-000000000046")]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IActivationFactory
	{
		// Token: 0x0600647B RID: 25723
		[__DynamicallyInvokable]
		object ActivateInstance();
	}
}
