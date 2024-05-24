using System;
using System.Text;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007CD RID: 1997
	public class NumericXAxis : XAxis
	{
		// Token: 0x06005145 RID: 20805 RVA: 0x0028760E File Offset: 0x0028660E
		public NumericXAxis() : this(0f)
		{
		}

		// Token: 0x06005146 RID: 20806 RVA: 0x0028761E File Offset: 0x0028661E
		public NumericXAxis(float offset) : base(offset)
		{
			this.h = new NumericXAxisLabelList();
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06005147 RID: 20807 RVA: 0x0028765C File Offset: 0x0028665C
		// (set) Token: 0x06005148 RID: 20808 RVA: 0x00287674 File Offset: 0x00286674
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

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06005149 RID: 20809 RVA: 0x00287680 File Offset: 0x00286680
		// (set) Token: 0x0600514A RID: 20810 RVA: 0x00287698 File Offset: 0x00286698
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

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x0600514B RID: 20811 RVA: 0x002876A4 File Offset: 0x002866A4
		// (set) Token: 0x0600514C RID: 20812 RVA: 0x002876BC File Offset: 0x002866BC
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

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x0600514D RID: 20813 RVA: 0x002876C8 File Offset: 0x002866C8
		public NumericXAxisLabelList Labels
		{
			get
			{
				return (NumericXAxisLabelList)this.h;
			}
		}

		// Token: 0x0600514E RID: 20814 RVA: 0x002876E8 File Offset: 0x002866E8
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
					NumericXAxisLabelList a_ = new NumericXAxisLabelList();
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

		// Token: 0x0600514F RID: 20815 RVA: 0x002877B0 File Offset: 0x002867B0
		private void a(NumericXAxisLabelList A_0, float A_1)
		{
			if (this.i != null)
			{
				A_0.Add(new NumericXAxisLabel(A_1.ToString(this.i), A_1));
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
					A_0.Add(new NumericXAxisLabel(A_1.ToString(stringBuilder.ToString()), A_1));
				}
			}
			else
			{
				A_0.Add(new NumericXAxisLabel(A_1.ToString("0.##"), A_1));
			}
		}

		// Token: 0x06005150 RID: 20816 RVA: 0x002878D8 File Offset: 0x002868D8
		internal override void iv(XYSeries A_0)
		{
			if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).ie();
				((StackedSeries)A_0).id();
			}
			if (A_0 is XYScatterSeries)
			{
				if (this.l > A_0.iz())
				{
					this.l = A_0.iz();
				}
				if (this.m < A_0.ig())
				{
					this.m = A_0.ig();
				}
			}
			else
			{
				if (this.l > A_0.p())
				{
					this.l = A_0.p();
				}
				if (this.m < A_0.o())
				{
					this.m = A_0.o();
				}
			}
		}

		// Token: 0x06005151 RID: 20817 RVA: 0x002879AC File Offset: 0x002869AC
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
				if (!this.d)
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
					this.d = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.c)
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
					this.c = true;
				}
			}
			else if (this.b == -3.4028235E+38f && this.a != -3.4028235E+38f)
			{
				this.l = this.a;
				this.a(1);
				if (!this.d)
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
					this.d = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.c)
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
					this.c = true;
				}
			}
			else if (this.b != -3.4028235E+38f && this.a == -3.4028235E+38f)
			{
				this.m = this.b;
				this.a(2);
				if (!this.d)
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
					this.d = true;
				}
				if (!this.p)
				{
					base.d(this.m - this.l);
				}
				if (!this.c)
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
					this.c = true;
				}
			}
		}

		// Token: 0x06005152 RID: 20818 RVA: 0x0028801C File Offset: 0x0028701C
		private void a(int A_0)
		{
			switch (A_0)
			{
			case 0:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericXAxisLabel numericXAxisLabel = (NumericXAxisLabel)this.h.a(i);
					if (numericXAxisLabel.Value < this.l)
					{
						this.l = numericXAxisLabel.Value;
					}
					if (numericXAxisLabel.Value > this.m)
					{
						this.m = numericXAxisLabel.Value;
					}
				}
				break;
			case 1:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericXAxisLabel numericXAxisLabel = (NumericXAxisLabel)this.h.a(i);
					if (numericXAxisLabel.Value > this.m)
					{
						this.m = numericXAxisLabel.Value;
					}
				}
				break;
			case 2:
				for (int i = 0; i < this.h.Count; i++)
				{
					NumericXAxisLabel numericXAxisLabel = (NumericXAxisLabel)this.h.a(i);
					if (numericXAxisLabel.Value < this.l)
					{
						this.l = numericXAxisLabel.Value;
					}
				}
				break;
			}
		}

		// Token: 0x04002B96 RID: 11158
		private new float a = float.MinValue;

		// Token: 0x04002B97 RID: 11159
		private new float b = float.MinValue;

		// Token: 0x04002B98 RID: 11160
		private new bool c = false;

		// Token: 0x04002B99 RID: 11161
		private new bool d = false;
	}
}
