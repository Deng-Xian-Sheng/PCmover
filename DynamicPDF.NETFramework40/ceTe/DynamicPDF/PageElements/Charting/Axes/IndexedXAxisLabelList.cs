using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C5 RID: 1989
	public class IndexedXAxisLabelList : XAxisLabelList
	{
		// Token: 0x0600512F RID: 20783 RVA: 0x0028716E File Offset: 0x0028616E
		internal IndexedXAxisLabelList()
		{
		}

		// Token: 0x06005130 RID: 20784 RVA: 0x00287179 File Offset: 0x00286179
		public void Add(IndexedXAxisLabel indexedXAxisLabel)
		{
			base.a(indexedXAxisLabel);
		}

		// Token: 0x170006EC RID: 1772
		public IndexedXAxisLabel this[int value1]
		{
			get
			{
				for (int i = 0; i < base.Count; i++)
				{
					if (base.a(i) is IndexedXAxisLabel)
					{
						IndexedXAxisLabel indexedXAxisLabel = (IndexedXAxisLabel)base.a(i);
						if (indexedXAxisLabel.Value == value1)
						{
							indexedXAxisLabel.a(false);
							return indexedXAxisLabel;
						}
					}
				}
				return null;
			}
		}
	}
}
