using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007DE RID: 2014
	public class YAxisGridLines : GridLines
	{
		// Token: 0x060051A8 RID: 20904 RVA: 0x0028A489 File Offset: 0x00289489
		public YAxisGridLines()
		{
		}

		// Token: 0x060051A9 RID: 20905 RVA: 0x0028A494 File Offset: 0x00289494
		public YAxisGridLines(float interval) : base(interval)
		{
		}

		// Token: 0x060051AA RID: 20906 RVA: 0x0028A4A0 File Offset: 0x002894A0
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2, int A_3, ack A_4)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.a(A_2, A_4);
			float num4 = A_2.t() / base.Interval;
			float num5 = A_2.g() / num4;
			float num6 = A_1.Y + A_1.Height - A_2.g() * A_2.s();
			if (base.LineStyle != LineStyle.None)
			{
				base.a(A_0);
				switch (A_4)
				{
				case ack.a:
				{
					if (num4 > 1f)
					{
						num = (int)(num4 - 1f);
					}
					if (A_2.s() == 0f)
					{
						if (A_1.XAxes.b())
						{
							num3 = 1;
						}
						if (A_1.XAxes.c() && A_2.m % A_2.g == 0f)
						{
							num2 = 1;
						}
					}
					int num7 = num3;
					while ((float)num7 < (float)A_3 * num4 - (float)num2 - (float)num)
					{
						if (num5 * (float)num7 <= (float)(A_3 - 1) * A_2.g())
						{
							base.a(A_0, A_1.X, num6 - num5 * (float)num7, A_1.X + A_1.Width, num6 - num5 * (float)num7);
						}
						num7++;
					}
					A_0.Write_S();
					break;
				}
				case ack.b:
				{
					float num8 = 0f;
					if (num4 > 1f)
					{
						num = (int)(num4 - 1f);
					}
					if (A_2.MajorGridLines != null)
					{
						num8 = A_2.MajorGridLines.Interval;
						num2 = 1;
						num3 = 1;
					}
					else if (A_2.s() == 0f)
					{
						if (A_1.XAxes.b())
						{
							num3 = 1;
						}
						if (A_1.XAxes.c())
						{
							num2 = 1;
						}
					}
					int num7 = num3;
					while ((float)num7 < (float)A_3 * num4 - (float)num2 - (float)num)
					{
						if (num5 * (float)num7 <= (float)(A_3 - 1) * A_2.g() && num8 != 0f && base.Interval * (float)num7 % num8 != 0f)
						{
							base.a(A_0, A_1.X, num6 - num5 * (float)num7, A_1.X + A_1.Width, num6 - num5 * (float)num7);
						}
						else if (num8 == 0f && num5 * (float)num7 <= (float)(A_3 - 1) * A_2.g())
						{
							base.a(A_0, A_1.X, num6 - num5 * (float)num7, A_1.X + A_1.Width, num6 - num5 * (float)num7);
						}
						num7++;
					}
					A_0.Write_S();
					break;
				}
				}
			}
		}

		// Token: 0x060051AB RID: 20907 RVA: 0x0028A794 File Offset: 0x00289794
		private void a(YAxis A_0, ack A_1)
		{
			if (base.LineStyle == null)
			{
				base.LineStyle = A_0.LineStyle;
			}
			if (base.Color == null)
			{
				base.Color = A_0.LineColor;
			}
			if (base.Interval <= 0f && A_1 == ack.a)
			{
				base.Interval = A_0.t();
			}
			else if (base.Interval <= 0f && A_1 == ack.b)
			{
				base.Interval = A_0.t() / 2f;
			}
		}
	}
}
