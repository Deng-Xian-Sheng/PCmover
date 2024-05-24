using System;

namespace CefSharp
{
	// Token: 0x02000073 RID: 115
	public interface IPopupFeatures
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002E6 RID: 742
		int? X { get; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002E7 RID: 743
		int? Y { get; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002E8 RID: 744
		int? Width { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002E9 RID: 745
		int? Height { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002EA RID: 746
		bool MenuBarVisible { get; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002EB RID: 747
		bool StatusBarVisible { get; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002EC RID: 748
		bool ToolBarVisible { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002ED RID: 749
		bool ScrollbarsVisible { get; }
	}
}
