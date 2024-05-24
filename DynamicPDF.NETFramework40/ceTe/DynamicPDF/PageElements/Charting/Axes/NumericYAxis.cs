using System;
using System.Text;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007D0 RID: 2000
	public class NumericYAxis : YAxis
	{
		// Token: 0x0600515A RID: 20826 RVA: 0x00288233 File Offset: 0x00287233
		public NumericYAxis() : this(0f)
		{
		}

		// Token: 0x0600515B RID: 20827 RVA: 0x00288243 File Offset: 0x00287243
		public NumericYAxis(float offset) : base(offset)
		{
			this.h = new NumericYAxisLabelList();
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x0600515C RID: 20828 RVA: 0x00288280 File Offset: 0x00287280
		// (set) Token: 0x0600515D RID: 20829 RVA: 0x00288298 File Offset: 0x00287298
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

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x0600515E RID: 20830 RVA: 0x002882A4 File Offset: 0x002872A4
		// (set) Token: 0x0600515F RID: 20831 RVA: 0x002882BC File Offset: 0x002872BC
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

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06005160 RID: 20832 RVA: 0x002882C8 File Offset: 0x002872C8
		// (set) Token: 0x06005161 RID: 20833 RVA: 0x002882E0 File Offset: 0x002872E0
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

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06005162 RID: 20834 RVA: 0x002882EC File Offset: 0x002872EC
		public NumericYAxisLabelList Labels
		{
			get
			{
				return (NumericYAxisLabelList)this.h;
			}
		}

		// Token: 0x06005163 RID: 20835 RVA: 0x0028830C File Offset: 0x0028730C
		internal override void iw()
		{
			this.a();
			if (this.h.Visible)
			{
				if (this.h.AutoLabels)
				{
					if (this.m < this.l)
					{
						throw new GeneratorException("Axis Minimum value can't be greater than axis maximum value");
					}
					NumericYAxisLabelList a_ = new NumericYAxisLabelList();
					int num = (int)((this.m - this.l) / this.g);
					float num2 = this.l;
					for (int i = 0; i <= num; i++)
					{
						this.a(a_, num2);
						num2 += this.g;
					}
					base.b(a_);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x06005164 RID: 20836 RVA: 0x002883D4 File Offset: 0x002873D4
		private void a(NumericYAxisLabelList A_0, float A_1)
		{
			if (base.LabelFormat != null)
			{
				A_0.Add(new NumericYAxisLabel(A_1.ToString(this.i), A_1));
			}
			else if (this.m - this.l > 0f && this.m - this.l < 1f)
			{
				int num = Convert.ToString(this.m - this.l).Substring(Convert.ToString(this.m - this.l).IndexOf('.') + 1).Length;
				if (num > 5)
				{
					num = 4;
				}
				if (num < 5)
				{
					StringBuilder stringBuilder = new StringBuilder("#.");
					for (int i = 0; i <= num; i++)
					{
						stringBuilder.Append("#");
					}
					A_0.Add(new NumericYAxisLabel(A_1.ToString(stringBuilder.ToString()), A_1));
				}
			}
			else
			{
				A_0.Add(new NumericYAxisLabel(A_1.ToString("0.##"), A_1));
			}
		}

		// Token: 0x06005165 RID: 20837 RVA: 0x002884FC File Offset: 0x002874FC
		internal override void iv(XYSeries A_0)
		{
			if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).ie();
				((StackedSeries)A_0).id();
			}
			if (this.l > A_0.p())
			{
				this.l = A_0.p();
			}
			if (this.m < A_0.o())
			{
				this.m = A_0.o();
			}
		}

		// Token: 0x06005166 RID: 20838 RVA: 0x00288578 File Offset: 0x00287578
		private void a()
		{
			if (this.l == 3.4028235E+38f && this.m == -3.4028235E+38f)
			{
				this.l = 0f;
				this.m = 90f;
			}
			if (this.b != -3.4028235E+38f && this.a != -3.4028235E+38f)
			{
				this.m = this.b;
				this.l = this.a;
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
			}
			else if (this.b == -3.4028235E+38f && this.a == -3.4028235E+38f)
			{
				this.a(0);
				if (!this.c)
				{
					if (this.m == this.l)
					{
						if (this.m > 0f)
						{
							this.l = 0f;
						}
						else if (this.m < 0f)
						{
							this.m = 0f;
						}
					}
					float num = 0.05f * (this.m - this.l);
					if (this.m != 0f)
					{
						this.m += num;
					}
					if (this.l != 0f)
					{
						this.l -= num;
					}
					if (this.l < 0f && this.m < 0f)
					{
						if (Math.Abs(this.m) < 0.8f * Math.Abs(this.l))
						{
							this.m = 0f;
						}
					}
					else if (this.l > 0f && this.m > 0f)
					{
						if (this.l < 0.8f * this.m)
						{
							this.l = 0f;
						}
					}
					this.c = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.d)
				{
					if (this.m % this.g != 0f)
					{
						if (this.m < 0f)
						{
							this.m -= this.m % -this.g;
						}
						else
						{
							this.m += this.g - Math.Abs(this.m % this.g);
						}
					}
					if (this.l % this.g != 0f)
					{
						if (this.l < 0f)
						{
							this.l += -(this.g - Math.Abs(this.l % this.g));
						}
						else
						{
							this.l += -Math.Abs(this.l % this.g);
						}
					}
					this.d = true;
				}
			}
			else if (this.b == -3.4028235E+38f && this.a != -3.4028235E+38f)
			{
				this.l = this.a;
				this.a(1);
				if (!this.c)
				{
					float num = 0.05f * (this.m - this.l);
					if (this.m != 0f)
					{
						this.m += num;
					}
					if (this.l < 0f && this.m < 0f)
					{
						if (Math.Abs(this.m) < 0.8f * Math.Abs(this.l))
						{
							this.m = 0f;
						}
					}
					this.c = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.d)
				{
					if (this.m % this.g != 0f)
					{
						if (this.m < 0f)
						{
							this.m -= this.m % -this.g;
						}
						else
						{
							this.m += this.g - Math.Abs(this.m % this.g);
						}
					}
					this.d = true;
				}
			}
			else if (this.b != -3.4028235E+38f && this.a == -3.4028235E+38f)
			{
				this.m = this.b;
				this.a(2);
				if (!this.c)
				{
					float num = 0.05f * (this.m - this.l);
					if (this.l != 0f)
					{
						this.l -= num;
					}
					else if (this.l > 0f && this.m > 0f)
					{
						if (this.l < 0.8f * this.m)
						{
							this.l = 0f;
						}
					}
					this.c = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.d)
				{
					if (this.l % this.g != 0f)
					{
						if (this.l < 0f)
						{
							this.l += -(this.g - Math.Abs(this.l % this.g));
						}
						else
						{
							this.l += -Math.Abs(this.l % this.g);
						}
					}
					this.d = true;
				}
			}
		}

		// Token: 0x06005167 RID: 20839 RVA: 0x00288BE8 File Offset: 0x00287BE8
		private void a(int A_0)
		{
			switch (A_0)
			{
			case 0:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericYAxisLabel numericYAxisLabel = (NumericYAxisLabel)this.h.a(i);
					if (numericYAxisLabel.Value < this.l)
					{
						this.l = numericYAxisLabel.Value;
					}
					if (numericYAxisLabel.Value > this.m)
					{
						this.m = numericYAxisLabel.Value;
					}
				}
				break;
			case 1:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericYAxisLabel numericYAxisLabel = (NumericYAxisLabel)this.h.a(i);
					if (numericYAxisLabel.Value > this.m)
					{
						this.m = numericYAxisLabel.Value;
					}
				}
				break;
			case 2:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericYAxisLabel numericYAxisLabel = (NumericYAxisLabel)this.h.a(i);
					if (numericYAxisLabel.Value < this.l)
					{
						this.l = numericYAxisLabel.Value;
					}
				}
				break;
			}
		}

		// Token: 0x04002B9B RID: 11163
		private new float a = float.MinValue;

		// Token: 0x04002B9C RID: 11164
		private new float b = float.MinValue;

		// Token: 0x04002B9D RID: 11165
		private new bool c = false;

		// Token: 0x04002B9E RID: 11166
		private new bool d = false;
	}
}
