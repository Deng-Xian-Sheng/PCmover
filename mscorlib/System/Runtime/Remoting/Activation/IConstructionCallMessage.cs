using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x0200089A RID: 2202
	[ComVisible(true)]
	public interface IConstructionCallMessage : IMethodCallMessage, IMethodMessage, IMessage
	{
		// Token: 0x17001008 RID: 4104
		// (get) Token: 0x06005D27 RID: 23847
		// (set) Token: 0x06005D28 RID: 23848
		IActivator Activator { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17001009 RID: 4105
		// (get) Token: 0x06005D29 RID: 23849
		object[] CallSiteActivationAttributes { [SecurityCritical] get; }

		// Token: 0x1700100A RID: 4106
		// (get) Token: 0x06005D2A RID: 23850
		string ActivationTypeName { [SecurityCritical] get; }

		// Token: 0x1700100B RID: 4107
		// (get) Token: 0x06005D2B RID: 23851
		Type ActivationType { [SecurityCritical] get; }

		// Token: 0x1700100C RID: 4108
		// (get) Token: 0x06005D2C RID: 23852
		IList ContextProperties { [SecurityCritical] get; }
	}
}
