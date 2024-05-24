using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088B RID: 2187
	public abstract class Stacked100PercentAreaSeriesElement : Stacked100PercentSeriesElement
	{
		// Token: 0x0600591B RID: 22811 RVA: 0x00339772 File Offset: 0x00338772
		internal Stacked100PercentAreaSeriesElement(string A_0, Color A_1, Marker A_2, Legend A_3) : base(A_0, A_1, A_3)
		{
			this.b = A_2;
		}

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x0600591C RID: 22812 RVA: 0x00339788 File Offset: 0x00338788
		// (set) Token: 0x0600591D RID: 22813 RVA: 0x003397A0 File Offset: 0x003387A0
		public Marker Marker
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

		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x0600591E RID: 22814 RVA: 0x003397AC File Offset: 0x003387AC
		// (set) Token: 0x0600591F RID: 22815 RVA: 0x003397C4 File Offset: 0x003387C4
		public PercentageDataLabel DataLabel
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x06005920 RID: 22816 RVA: 0x003397D0 File Offset: 0x003387D0
		internal Stacked100PercentAreaValueList a()
		{
			return this.a;
		}

		// Token: 0x06005921 RID: 22817 RVA: 0x003397E8 File Offset: 0x003387E8
		internal void a(Stacked100PercentAreaValueList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005922 RID: 22818 RVA: 0x003397F2 File Offset: 0x003387F2
		internal void a(PageWriter A_0, float[] A_1)
		{
			this.a.a(A_0, A_1);
		}

		// Token: 0x06005923 RID: 22819 RVA: 0x00339803 File Offset: 0x00338803
		internal void a(PageWriter A_0, Stacked100PercentAreaSeriesElement A_1, float[] A_2, int A_3, ArrayList A_4)
		{
			this.a.a(A_0, base.PlotArea, A_1, A_2, A_3, A_4);
		}

		// Token: 0x04002F34 RID: 12084
		private new Stacked100PercentAreaValueList a;

		// Token: 0x04002F35 RID: 12085
		private new Marker b;

		// Token: 0x04002F36 RID: 12086
		private PercentageDataLabel c;
	}
}
