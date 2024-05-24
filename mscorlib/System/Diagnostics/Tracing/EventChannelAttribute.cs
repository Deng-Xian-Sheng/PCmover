using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000428 RID: 1064
	[AttributeUsage(AttributeTargets.Field)]
	internal class EventChannelAttribute : Attribute
	{
		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06003541 RID: 13633 RVA: 0x000CE6F2 File Offset: 0x000CC8F2
		// (set) Token: 0x06003542 RID: 13634 RVA: 0x000CE6FA File Offset: 0x000CC8FA
		public bool Enabled { get; set; }

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06003543 RID: 13635 RVA: 0x000CE703 File Offset: 0x000CC903
		// (set) Token: 0x06003544 RID: 13636 RVA: 0x000CE70B File Offset: 0x000CC90B
		public EventChannelType EventChannelType { get; set; }
	}
}
