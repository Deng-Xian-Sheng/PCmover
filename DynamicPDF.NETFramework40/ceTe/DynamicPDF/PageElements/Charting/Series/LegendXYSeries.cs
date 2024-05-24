using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000880 RID: 2176
	public abstract class LegendXYSeries : XYSeries
	{
		// Token: 0x060058A8 RID: 22696 RVA: 0x0033767B File Offset: 0x0033667B
		internal LegendXYSeries(string A_0, XAxis A_1, YAxis A_2, Color A_3) : base(A_1, A_2)
		{
			this.a = A_0;
			this.b = A_3;
		}

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x060058A9 RID: 22697 RVA: 0x00337698 File Offset: 0x00336698
		public string Name
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x060058AA RID: 22698 RVA: 0x003376B0 File Offset: 0x003366B0
		// (set) Token: 0x060058AB RID: 22699 RVA: 0x003376C8 File Offset: 0x003366C8
		public Color Color
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x060058AC RID: 22700 RVA: 0x003376D2 File Offset: 0x003366D2
		internal void a(LegendLabel A_0)
		{
			this.c = A_0;
		}

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x060058AD RID: 22701 RVA: 0x003376DC File Offset: 0x003366DC
		public LegendLabel LegendLabel
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x04002F16 RID: 12054
		private new string a;

		// Token: 0x04002F17 RID: 12055
		private new Color b;

		// Token: 0x04002F18 RID: 12056
		private LegendLabel c;
	}
}
