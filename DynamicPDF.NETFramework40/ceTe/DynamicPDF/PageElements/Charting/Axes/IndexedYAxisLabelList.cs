using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C8 RID: 1992
	public class IndexedYAxisLabelList : YAxisLabelList
	{
		// Token: 0x06005142 RID: 20802 RVA: 0x0028758A File Offset: 0x0028658A
		internal IndexedYAxisLabelList()
		{
		}

		// Token: 0x06005143 RID: 20803 RVA: 0x00287595 File Offset: 0x00286595
		public void Add(IndexedYAxisLabel indexedYAxisLabel)
		{
			base.a(indexedYAxisLabel);
		}

		// Token: 0x170006F2 RID: 1778
		public IndexedYAxisLabel this[int value1]
		{
			get
			{
				for (int i = 0; i < base.Count; i++)
				{
					if (base.a(i) is IndexedYAxisLabel)
					{
						IndexedYAxisLabel indexedYAxisLabel = (IndexedYAxisLabel)base.a(i);
						if (indexedYAxisLabel.Value == value1)
						{
							indexedYAxisLabel.a(false);
							return indexedYAxisLabel;
						}
					}
				}
				return null;
			}
		}
	}
}
