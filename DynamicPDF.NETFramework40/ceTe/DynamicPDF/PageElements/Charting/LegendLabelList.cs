using System;
using System.Collections;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A8 RID: 1960
	public class LegendLabelList
	{
		// Token: 0x06004F51 RID: 20305 RVA: 0x0027B0F2 File Offset: 0x0027A0F2
		internal LegendLabelList()
		{
			this.a = new ArrayList();
		}

		// Token: 0x06004F52 RID: 20306 RVA: 0x0027B108 File Offset: 0x0027A108
		internal void a(LegendLabel A_0)
		{
			this.a.Add(A_0);
		}

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06004F53 RID: 20307 RVA: 0x0027B118 File Offset: 0x0027A118
		public int Count
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.Count;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x1700067E RID: 1662
		public LegendLabel this[int index]
		{
			get
			{
				LegendLabel result;
				if (this.Count > 0 && index <= this.Count)
				{
					result = (LegendLabel)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x04002AE0 RID: 10976
		private ArrayList a;
	}
}
