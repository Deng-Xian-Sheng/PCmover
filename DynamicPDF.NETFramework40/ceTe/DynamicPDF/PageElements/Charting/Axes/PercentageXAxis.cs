using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D3 RID: 2003
	public class PercentageXAxis : XAxis
	{
		// Token: 0x0600516F RID: 20847 RVA: 0x00288DFA File Offset: 0x00287DFA
		public PercentageXAxis() : this(0f)
		{
		}

		// Token: 0x06005170 RID: 20848 RVA: 0x00288E0A File Offset: 0x00287E0A
		public PercentageXAxis(float offset) : base(offset)
		{
			this.h = new PercentageXAxisLabelList();
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06005171 RID: 20849 RVA: 0x00288E38 File Offset: 0x00287E38
		// (set) Token: 0x06005172 RID: 20850 RVA: 0x00288E50 File Offset: 0x00287E50
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

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06005173 RID: 20851 RVA: 0x00288E5C File Offset: 0x00287E5C
		// (set) Token: 0x06005174 RID: 20852 RVA: 0x00288E74 File Offset: 0x00287E74
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

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06005175 RID: 20853 RVA: 0x00288E80 File Offset: 0x00287E80
		// (set) Token: 0x06005176 RID: 20854 RVA: 0x00288E98 File Offset: 0x00287E98
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

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06005177 RID: 20855 RVA: 0x00288EA4 File Offset: 0x00287EA4
		public PercentageXAxisLabelList Labels
		{
			get
			{
				return (PercentageXAxisLabelList)this.h;
			}
		}

		// Token: 0x06005178 RID: 20856 RVA: 0x00288EC4 File Offset: 0x00287EC4
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

		// Token: 0x06005179 RID: 20857 RVA: 0x00288F1C File Offset: 0x00287F1C
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
					PercentageXAxisLabelList percentageXAxisLabelList = new PercentageXAxisLabelList();
					for (float num = this.l; num <= this.m; num += base.t())
					{
						if (base.LabelFormat != null)
						{
							if (base.LabelFormat.IndexOf('%') != -1)
							{
								percentageXAxisLabelList.Add(new PercentageXAxisLabel(num.ToString(base.LabelFormat), num));
							}
							else
							{
								percentageXAxisLabelList.Add(new PercentageXAxisLabel(num.ToString(base.LabelFormat), num));
							}
						}
						else
						{
							percentageXAxisLabelList.Add(new PercentageXAxisLabel(num.ToString("0.##'%"), num));
						}
					}
					base.b(percentageXAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x0600517A RID: 20858 RVA: 0x00289038 File Offset: 0x00288038
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

		// Token: 0x0600517B RID: 20859 RVA: 0x002891D0 File Offset: 0x002881D0
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				PercentageXAxisLabel percentageXAxisLabel = (PercentageXAxisLabel)this.h.a(i);
				if (percentageXAxisLabel.Value < this.l)
				{
					this.l = percentageXAxisLabel.Value;
				}
				if (percentageXAxisLabel.Value > this.m)
				{
					this.m = percentageXAxisLabel.Value;
				}
			}
		}

		// Token: 0x04002BA0 RID: 11168
		private new float a = float.MinValue;

		// Token: 0x04002BA1 RID: 11169
		private new float b = float.MinValue;
	}
}
