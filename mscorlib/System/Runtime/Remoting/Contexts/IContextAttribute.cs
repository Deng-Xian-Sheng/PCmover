using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080B RID: 2059
	[ComVisible(true)]
	public interface IContextAttribute
	{
		// Token: 0x060058B9 RID: 22713
		[SecurityCritical]
		bool IsContextOK(Context ctx, IConstructionCallMessage msg);

		// Token: 0x060058BA RID: 22714
		[SecurityCritical]
		void GetPropertiesForNewContext(IConstructionCallMessage msg);
	}
}
