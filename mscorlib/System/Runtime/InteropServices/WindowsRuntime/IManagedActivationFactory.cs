using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009F0 RID: 2544
	[Guid("60D27C8D-5F61-4CCE-B751-690FAE66AA53")]
	[ComImport]
	internal interface IManagedActivationFactory
	{
		// Token: 0x060064B8 RID: 25784
		void RunClassConstructor();
	}
}
