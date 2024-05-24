using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200080C RID: 2060
	[ComVisible(true)]
	public interface IContextProperty
	{
		// Token: 0x17000EB8 RID: 3768
		// (get) Token: 0x060058BB RID: 22715
		string Name { [SecurityCritical] get; }

		// Token: 0x060058BC RID: 22716
		[SecurityCritical]
		bool IsNewContextOK(Context newCtx);

		// Token: 0x060058BD RID: 22717
		[SecurityCritical]
		void Freeze(Context newContext);
	}
}
