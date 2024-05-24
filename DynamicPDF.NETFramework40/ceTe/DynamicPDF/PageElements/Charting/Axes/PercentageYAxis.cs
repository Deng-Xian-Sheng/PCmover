using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D6 RID: 2006
	public class PercentageYAxis : YAxis
	{
		// Token: 0x06005183 RID: 20867 RVA: 0x00289322 File Offset: 0x00288322
		public PercentageYAxis() : this(0f)
		{
		}

		// Token: 0x06005184 RID: 20868 RVA: 0x00289332 File Offset: 0x00288332
		public PercentageYAxis(float offset) : base(offset)
		{
			this.h = new PercentageYAxisLabelList();
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06005185 RID: 20869 RVA: 0x00289360 File Offset: 0x00288360
		// (set) Token: 0x06005186 RID: 20870 RVA: 0x00289378 File Offset: 0x00288378
		public float Min
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06005187 RID: 20871 RVA: 0x00289384 File Offset: 0x00288384
		// (set) Token: 0x06005188 RID: 20872 RVA: 0x0028939C File Offset: 0x0028839C
		public float Interval
		{
			get
			{
				return base.t();
			}
			set
			{
				base.c(value);
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06005189 RID: 20873 RVA: 0x002893A8 File Offset: 0x002883A8
		// (set) Token: 0x0600518A RID: 20874 RVA: 0x002893C0 File Offset: 0x002883C0
		public float Max
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

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x0600518B RID: 20875 RVA: 0x002893CC File Offset: 0x002883CC
		public PercentageYAxisLabelList Labels
		{
			get
			{
				return (PercentageYAxisLabelList)this.h;
			}
		}

		// Token: 0x0600518C RID: 20876 RVA: 0x002893EC File Offset: 0x002883EC
		internal override void iv(XYSeries A_0)
		{
			if (A_0 is Stacked100PercentSeries)
			{
				((Stacked100PercentSeries)A_0).@if();
			}
			if (this.l > A_0.p())
			{
				this.l = A_0.p();
			}
			this.m = 100f;
		}

		// Token: 0x0600518D RID: 20877 RVA: 0x00289444 File Offset: 0x00288444
		internal override void iw()
		{
			this.b();
			if (this.h.Visible)
			{
				if (this.h.AutoLabels)
				{
					if (this.m < this.l)
					{
						throw new GeneratorException("Axis Minimum value can't be greater than axis maximum value");
					}
					PercentageYAxisLabelList percentageYAxisLabelList = new PercentageYAxisLabelList();
					for (float num = this.l; num <= this.m; num += base.t())
					{
						if (base.LabelFormat != null)
						{
							if (base.LabelFormat.IndexOf('%') != -1)
							{
								percentageYAxisLabelList.Add(new PercentageYAxisLabel(num.ToString(base.LabelFormat), num));
							}
							else
							{
								percentageYAxisLabelList.Add(new PercentageYAxisLabel(num.ToString(base.LabelFormat), num));
							}
						}
						else
						{
							percentageYAxisLabelList.Add(new PercentageYAxisLabel(num.ToString("0.##'%"), num));
						}
					}
					base.b(percentageYAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x0600518E RID: 20878 RVA: 0x00289560 File Offset: 0x00288560
		private void b()
		{
			if (this.m == -3.4028235E+38f && this.l == 3.4028235E+38f)
			{
				this.m = 100f;
				this.l = 0f;
			}
			if (this.a != this.b)
			{
				this.l = this.a;
				this.m = this.b;
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
			}
			else
			{
				this.m = 100f;
				this.a();
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (this.m > 100f && this.m % base.t() != 0f)
				{
					this.m += base.t() - Math.Abs(this.m % base.t());
				}
				if (this.l % base.t() != 0f)
				{
					if (this.l < 0f)
					{
						this.l += -(base.t() - Math.Abs(this.l % base.t()));
					}
					else
					{
						this.l += -Math.Abs(this.l % base.t());
					}
				}
			}
		}

		// Token: 0x0600518F RID: 20879 RVA: 0x002896F8 File Offset: 0x002886F8
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				PercentageYAxisLabel percentageYAxisLabel = (PercentageYAxisLabel)this.h.a(i);
				if (percentageYAxisLabel.Value < this.l)
				{
					this.l = percentageYAxisLabel.Value;
				}
				if (percentageYAxisLabel.Value > this.m)
				{
					this.m = percentageYAxisLabel.Value;
				}
			}
		}

		// Token: 0x04002BA3 RID: 11171
		private new float a = float.MinValue;

		// Token: 0x04002BA4 RID: 11172
		private new float b = float.MinValue;
	}
}
