using System;
using System.Collections.ObjectModel;

namespace ThankYou.UIData
{
	// Token: 0x02000016 RID: 22
	public class ThankYouModel
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003437 File Offset: 0x00001637
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000343F File Offset: 0x0000163F
		public MainData MainDetail { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003448 File Offset: 0x00001648
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00003450 File Offset: 0x00001650
		public StartData StartDetail { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003459 File Offset: 0x00001659
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00003461 File Offset: 0x00001661
		public ObservableCollection<Offer> Offers { get; set; }
	}
}
