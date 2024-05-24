using System;

namespace PCmover.Infrastructure
{
	// Token: 0x0200000F RID: 15
	public interface IUpgradeToUiPolicy
	{
		// Token: 0x06000065 RID: 101
		void Upgrade(DefaultPolicy policy);

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000066 RID: 102
		// (set) Token: 0x06000067 RID: 103
		int NumUpgradedItems { get; set; }
	}
}
