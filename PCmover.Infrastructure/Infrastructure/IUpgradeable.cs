using System;

namespace PCmover.Infrastructure
{
	// Token: 0x0200000E RID: 14
	public interface IUpgradeable
	{
		// Token: 0x06000062 RID: 98
		void Upgrade(EnginePolicy enginePolicy);

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000063 RID: 99
		// (set) Token: 0x06000064 RID: 100
		int NumUpgradedItems { get; set; }
	}
}
