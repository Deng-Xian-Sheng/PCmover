using System;

namespace Prism
{
	// Token: 0x02000002 RID: 2
	public interface IActiveAware
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		// (set) Token: 0x06000002 RID: 2
		bool IsActive { get; set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000003 RID: 3
		// (remove) Token: 0x06000004 RID: 4
		event EventHandler IsActiveChanged;
	}
}
