using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007DB RID: 2011
	public class XAxisTickMarks : TickMarks
	{
		// Token: 0x0600519B RID: 20891 RVA: 0x00289B96 File Offset: 0x00288B96
		public XAxisTickMarks()
		{
		}

		// Token: 0x0600519C RID: 20892 RVA: 0x00289BA8 File Offset: 0x00288BA8
		public XAxisTickMarks(float interval) : base(interval)
		{
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x0600519D RID: 20893 RVA: 0x00289BBC File Offset: 0x00288BBC
		// (set) Token: 0x0600519E RID: 20894 RVA: 0x00289BD4 File Offset: 0x00288BD4
		public XAxisTickMarksPosition Position
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

		// Token: 0x0600519F RID: 20895 RVA: 0x00289BE0 File Offset: 0x00288BE0
		internal float a(XAxisAnchorType A_0)
		{
			float result = 0f;
			if (A_0 == XAxisAnchorType.Bottom || A_0 == XAxisAnchorType.Floating)
			{
				switch (this.a)
				{
				case XAxisTickMarksPosition.Above:
					result = 0f;
					break;
				case XAxisTickMarksPosition.Below:
					result = base.Length;
					break;
				case XAxisTickMarksPosition.Across:
					result = base.Length / 2f;
					break;
				}
			}
			else if (A_0 == XAxisAnchorType.Top)
			{
				switch (this.a)
				{
				case XAxisTickMarksPosition.Above:
					result = base.Length;
					break;
				case XAxisTickMarksPosition.Below:
					result = 0f;
					break;
				case XAxisTickMarksPosition.Across:
					result = base.Length / 2f;
					break;
				}
			}
			return result;
		}

		// Token: 0x060051A0 RID: 20896 RVA: 0x00289C94 File Offset: 0x00288C94
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2, int A_3, ack A_4)
		{
			this.a(A_2, A_4);
			switch (A_2.AnchorType)
			{
			case XAxisAnchorType.Bottom:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.d(A_1, A_2), this.c(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.d(A_1, A_2), this.c(A_1, A_2));
					break;
				}
				break;
			case XAxisAnchorType.Top:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.d(A_1, A_2), this.b(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.d(A_1, A_2), this.b(A_1, A_2));
					break;
				}
				break;
			case XAxisAnchorType.Floating:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.d(A_1, A_2), this.a(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.d(A_1, A_2), this.a(A_1, A_2));
					break;
				}
				break;
			}
		}

		// Token: 0x060051A1 RID: 20897 RVA: 0x00289DBC File Offset: 0x00288DBC
		private void a(XAxis A_0, ack A_1)
		{
			if (base.LineStyle == null)
			{
				base.LineStyle = A_0.LineStyle;
			}
			if (base.Width <= 0f)
			{
				base.Width = A_0.LineWidth;
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

		// Token: 0x060051A2 RID: 20898 RVA: 0x00289E80 File Offset: 0x00288E80
		private float d(PlotArea A_0, XAxis A_1)
		{
			return A_0.X + A_1.g() * A_1.s();
		}

		// Token: 0x060051A3 RID: 20899 RVA: 0x00289EA8 File Offset: 0x00288EA8
		private float c(PlotArea A_0, XAxis A_1)
		{
			return A_0.Y + A_0.Height - A_1.Offset;
		}

		// Token: 0x060051A4 RID: 20900 RVA: 0x00289ED0 File Offset: 0x00288ED0
		private float b(PlotArea A_0, XAxis A_1)
		{
			return A_0.Y - A_1.Offset;
		}

		// Token: 0x060051A5 RID: 20901 RVA: 0x00289EF0 File Offset: 0x00288EF0
		private float a(PlotArea A_0, XAxis A_1)
		{
			return A_0.Y + A_0.Height - A_1.Offset * (A_0.j().g() / A_0.j().t()) - A_0.j().h() * A_0.j().g() - A_0.j().s() * A_0.j().g();
		}

		// Token: 0x060051A6 RID: 20902 RVA: 0x00289F60 File Offset: 0x00288F60
		private void b(PageWriter A_0, XAxis A_1, int A_2, float A_3, float A_4)
		{
			int num = 0;
			float num2 = A_1.t() / base.Interval;
			float num3 = A_1.g() / num2;
			if (num2 > 1f)
			{
				num = (int)(num2 - 1f);
			}
			float num4 = A_1.LineWidth / 2f;
			base.a(A_0);
			if (this.a == XAxisTickMarksPosition.Automatic)
			{
				if (A_1.AnchorType == XAxisAnchorType.Top)
				{
					this.a = XAxisTickMarksPosition.Above;
				}
				else if (A_1.AnchorType == XAxisAnchorType.Bottom || A_1.AnchorType == XAxisAnchorType.Floating)
				{
					this.a = XAxisTickMarksPosition.Below;
				}
			}
			float num5 = (float)A_2 * num2 - (float)num;
			if (base.LineStyle != LineStyle.None)
			{
				switch (this.a)
				{
				case XAxisTickMarksPosition.Above:
				{
					int num6 = 0;
					while ((float)num6 < num5)
					{
						base.a(A_0, A_3 + num3 * (float)num6, A_4 - base.Length, A_3 + num3 * (float)num6, A_4 + num4);
						num6++;
					}
					break;
				}
				case XAxisTickMarksPosition.Below:
				{
					int num6 = 0;
					while ((float)num6 < num5)
					{
						base.a(A_0, A_3 + num3 * (float)num6, A_4 - num4, A_3 + num3 * (float)num6, A_4 + base.Length);
						num6++;
					}
					break;
				}
				case XAxisTickMarksPosition.Across:
				{
					int num6 = 0;
					while ((float)num6 < num5)
					{
						base.a(A_0, A_3 + num3 * (float)num6, A_4 + base.Length / 2f, A_3 + num3 * (float)num6, A_4 - base.Length / 2f);
						num6++;
					}
					break;
				}
				}
				A_0.Write_S();
			}
		}

		// Token: 0x060051A7 RID: 20903 RVA: 0x0028A12C File Offset: 0x0028912C
		private void a(PageWriter A_0, XAxis A_1, int A_2, float A_3, float A_4)
		{
			int num = 0;
			int num2 = 1;
			int num3 = 1;
			float num4 = 0f;
			float num5 = A_1.t() / base.Interval;
			float num6 = A_1.g() / num5;
			float num7 = A_1.LineWidth / 2f;
			if (num5 > 1f)
			{
				num = (int)(num5 - 1f);
			}
			if (A_1.MajorTickMarks != null)
			{
				num4 = A_1.MajorTickMarks.Interval;
			}
			else
			{
				num2 = 0;
				num3 = 0;
			}
			base.a(A_0);
			if (this.a == XAxisTickMarksPosition.Automatic)
			{
				if (A_1.AnchorType == XAxisAnchorType.Top)
				{
					this.a = XAxisTickMarksPosition.Above;
				}
				else if (A_1.AnchorType == XAxisAnchorType.Bottom || A_1.AnchorType == XAxisAnchorType.Floating)
				{
					this.a = XAxisTickMarksPosition.Below;
				}
			}
			if (base.LineStyle != LineStyle.None)
			{
				switch (this.a)
				{
				case XAxisTickMarksPosition.Above:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 - base.Length, A_3 + num6 * (float)num8, A_4 + num7);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 - base.Length, A_3 + num6 * (float)num8, A_4 + num7);
						}
						num8++;
					}
					break;
				}
				case XAxisTickMarksPosition.Below:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 - num7, A_3 + num6 * (float)num8, A_4 + base.Length);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 - num7, A_3 + num6 * (float)num8, A_4 + base.Length);
						}
						num8++;
					}
					break;
				}
				case XAxisTickMarksPosition.Across:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 + base.Length / 2f, A_3 + num6 * (float)num8, A_4 - base.Length / 2f);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 + num6 * (float)num8, A_4 + base.Length / 2f, A_3 + num6 * (float)num8, A_4 - base.Length / 2f);
						}
						num8++;
					}
					break;
				}
				}
				A_0.Write_S();
			}
		}

		// Token: 0x04002BAA RID: 11178
		private new XAxisTickMarksPosition a = XAxisTickMarksPosition.Automatic;
	}
}
