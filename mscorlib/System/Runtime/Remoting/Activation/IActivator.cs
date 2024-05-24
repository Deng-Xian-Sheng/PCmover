using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x02000898 RID: 2200
	[ComVisible(true)]
	public interface IActivator
	{
		// Token: 0x17001006 RID: 4102
		// (get) Token: 0x06005D23 RID: 23843
		// (set) Token: 0x06005D24 RID: 23844
		IActivator NextActivator { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x06005D25 RID: 23845
		[SecurityCritical]
		IConstructionReturnMessage Activate(IConstructionCallMessage msg);

		// Token: 0x17001007 RID: 4103
		// (get) Token: 0x06005D26 RID: 23846
		ActivatorLevel Level { [SecurityCritical] get; }
	}
}
