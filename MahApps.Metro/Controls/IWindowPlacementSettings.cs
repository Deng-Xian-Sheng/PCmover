using System;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200009D RID: 157
	public interface IWindowPlacementSettings
	{
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600088B RID: 2187
		// (set) Token: 0x0600088C RID: 2188
		WINDOWPLACEMENT Placement { get; set; }

		// Token: 0x0600088D RID: 2189
		void Reload();

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600088E RID: 2190
		// (set) Token: 0x0600088F RID: 2191
		bool UpgradeSettings { get; set; }

		// Token: 0x06000890 RID: 2192
		void Upgrade();

		// Token: 0x06000891 RID: 2193
		void Save();
	}
}
