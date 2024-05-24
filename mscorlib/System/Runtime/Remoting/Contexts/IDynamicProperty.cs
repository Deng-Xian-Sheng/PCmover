using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000816 RID: 2070
	[ComVisible(true)]
	public interface IDynamicProperty
	{
		// Token: 0x17000EBC RID: 3772
		// (get) Token: 0x060058DA RID: 22746
		string Name { [SecurityCritical] get; }
	}
}
