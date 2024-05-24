using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BB RID: 1979
	public class XAxisLabelList : AxisLabelList
	{
		// Token: 0x060050C5 RID: 20677 RVA: 0x00283C80 File Offset: 0x00282C80
		internal XAxisLabelList()
		{
			this.b = (double)(-(double)this.a) * 0.017453292519943295;
			this.c = (float)Math.Cos(this.b);
			this.d = (float)Math.Sin(this.b);
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060050C6 RID: 20678 RVA: 0x00283CDC File Offset: 0x00282CDC
		// (set) Token: 0x060050C7 RID: 20679 RVA: 0x00283CF4 File Offset: 0x00282CF4
		public int Angle
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				int num = this.a;
				if (num < -360 || num > 360)
				{
					num %= 360;
				}
				if (num < 0)
				{
					num += 360;
				}
				double num2 = (double)(-(double)num) * 0.017453292519943295;
				this.c = (float)Math.Cos(num2);
				this.d = (float)Math.Sin(num2);
			}
		}

		// Token: 0x060050C8 RID: 20680 RVA: 0x00283D70 File Offset: 0x00282D70
		internal override float ix()
		{
			float result = 0f;
			if (base.g() != null && base.h() != null && base.h().Count != 0 && base.g().s() == 0f)
			{
				for (int i = 0; i < base.Count; i++)
				{
					AxisLabel axisLabel = base.a(i);
					if (base.b(axisLabel) == base.g().v())
					{
						result = axisLabel.a(this.a, this.c);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060050C9 RID: 20681 RVA: 0x00283E2C File Offset: 0x00282E2C
		internal float a()
		{
			float result = 0f;
			if (base.g() != null && base.h() != null && base.h().Count != 0 && base.g().s() == 0f)
			{
				for (int i = 0; i < base.Count; i++)
				{
					AxisLabel axisLabel = base.a(i);
					if (base.b(axisLabel) == base.g().v())
					{
						result = axisLabel.a(this.a, this.c);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060050CA RID: 20682 RVA: 0x00283EE8 File Offset: 0x00282EE8
		internal float b()
		{
			float result = 0f;
			if (base.g() != null && base.h() != null && base.h().Count != 0 && base.g().s() == 0f)
			{
				for (int i = 0; i < base.Count; i++)
				{
					AxisLabel axisLabel = base.a(i);
					if (base.c(axisLabel) == base.g().w())
					{
						result = axisLabel.a(this.a, this.c, this.d);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060050CB RID: 20683 RVA: 0x00283FA8 File Offset: 0x00282FA8
		internal float a(float A_0)
		{
			float num = 0f;
			for (int i = 0; i < base.Count; i++)
			{
				AxisLabel axisLabel = base.a(i);
				float num2 = base.d(axisLabel);
				if (num2 != -3.4028235E+38f)
				{
					axisLabel.a(A_0);
					axisLabel.b(base.WrapText, base.f());
					if ((double)num < axisLabel.a(this.c, this.d))
					{
						num = (float)axisLabel.a(this.c, this.d);
					}
				}
			}
			return num;
		}

		// Token: 0x060050CC RID: 20684 RVA: 0x00284058 File Offset: 0x00283058
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2)
		{
			for (int i = 0; i < base.Count; i++)
			{
				XAxisLabel xaxisLabel = (XAxisLabel)base.a(i);
				float a_ = base.d(xaxisLabel);
				xaxisLabel.a(A_0, A_1, A_2, a_, this.a, this.c, this.d, base.WrapText);
			}
		}

		// Token: 0x04002B61 RID: 11105
		private new int a = 0;

		// Token: 0x04002B62 RID: 11106
		private new double b;

		// Token: 0x04002B63 RID: 11107
		private new float c;

		// Token: 0x04002B64 RID: 11108
		private new float d;
	}
}
