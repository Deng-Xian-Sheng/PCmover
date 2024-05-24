using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007DA RID: 2010
	public class XAxisGridLines : GridLines
	{
		// Token: 0x06005197 RID: 20887 RVA: 0x0028984A File Offset: 0x0028884A
		public XAxisGridLines()
		{
		}

		// Token: 0x06005198 RID: 20888 RVA: 0x00289855 File Offset: 0x00288855
		public XAxisGridLines(float interval) : base(interval)
		{
		}

		// Token: 0x06005199 RID: 20889 RVA: 0x00289864 File Offset: 0x00288864
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2, int A_3, ack A_4)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.a(A_2, A_4);
			float num4 = A_2.t() / base.Interval;
			float num5 = A_2.g() / num4;
			float num6 = A_1.X + A_2.g() * A_2.s();
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
						if (A_1.YAxes.b())
						{
							num3 = 1;
						}
						if (A_1.YAxes.c())
						{
							num2 = 1;
						}
					}
					int num7 = num3;
					while ((float)num7 < (float)A_3 * num4 - (float)num2 - (float)num)
					{
						base.a(A_0, num6 + num5 * (float)num7, A_1.Y + A_1.Height, num6 + num5 * (float)num7, A_1.Y);
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
						if (A_1.YAxes.b())
						{
							num3 = 1;
						}
						if (A_1.YAxes.c())
						{
							num2 = 1;
						}
					}
					int num7 = num3;
					while ((float)num7 < (float)A_3 * num4 - (float)num2 - (float)num)
					{
						if (num8 != 0f && base.Interval * (float)num7 % num8 != 0f)
						{
							base.a(A_0, num6 + num5 * (float)num7, A_1.Y + A_1.Height, num6 + num5 * (float)num7, A_1.Y);
						}
						else if (num8 == 0f)
						{
							base.a(A_0, num6 + num5 * (float)num7, A_1.Y + A_1.Height, num6 + num5 * (float)num7, A_1.Y);
						}
						num7++;
					}
					A_0.Write_S();
					break;
				}
				}
			}
		}

		// Token: 0x0600519A RID: 20890 RVA: 0x00289AF4 File Offset: 0x00288AF4
		private void a(XAxis A_0, ack A_1)
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
