using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007DF RID: 2015
	public class YAxisTickMarks : TickMarks
	{
		// Token: 0x060051AC RID: 20908 RVA: 0x0028A836 File Offset: 0x00289836
		public YAxisTickMarks()
		{
		}

		// Token: 0x060051AD RID: 20909 RVA: 0x0028A848 File Offset: 0x00289848
		public YAxisTickMarks(float interval) : base(interval)
		{
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x060051AE RID: 20910 RVA: 0x0028A85C File Offset: 0x0028985C
		// (set) Token: 0x060051AF RID: 20911 RVA: 0x0028A874 File Offset: 0x00289874
		public YAxisTickMarksPosition Position
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

		// Token: 0x060051B0 RID: 20912 RVA: 0x0028A880 File Offset: 0x00289880
		internal float a(YAxisAnchorType A_0)
		{
			float result = 0f;
			if (A_0 == YAxisAnchorType.Left)
			{
				switch (this.a)
				{
				case YAxisTickMarksPosition.Right:
					result = 0f;
					break;
				case YAxisTickMarksPosition.Left:
					result = base.Length;
					break;
				case YAxisTickMarksPosition.Across:
					result = base.Length / 2f;
					break;
				}
			}
			else if (A_0 == YAxisAnchorType.Right || A_0 == YAxisAnchorType.Floating)
			{
				switch (this.a)
				{
				case YAxisTickMarksPosition.Right:
					result = base.Length;
					break;
				case YAxisTickMarksPosition.Left:
					result = 0f;
					break;
				case YAxisTickMarksPosition.Across:
					result = base.Length / 2f;
					break;
				}
			}
			return result;
		}

		// Token: 0x060051B1 RID: 20913 RVA: 0x0028A934 File Offset: 0x00289934
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2, int A_3, ack A_4)
		{
			this.a(A_2, A_4);
			switch (A_2.AnchorType)
			{
			case YAxisAnchorType.Left:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.c(A_1, A_2), this.d(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.c(A_1, A_2), this.d(A_1, A_2));
					break;
				}
				break;
			case YAxisAnchorType.Right:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.b(A_1, A_2), this.d(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.b(A_1, A_2), this.d(A_1, A_2));
					break;
				}
				break;
			case YAxisAnchorType.Floating:
				switch (A_4)
				{
				case ack.a:
					this.b(A_0, A_2, A_3, this.a(A_1, A_2), this.d(A_1, A_2));
					break;
				case ack.b:
					this.a(A_0, A_2, A_3, this.a(A_1, A_2), this.d(A_1, A_2));
					break;
				}
				break;
			}
		}

		// Token: 0x060051B2 RID: 20914 RVA: 0x0028AA5C File Offset: 0x00289A5C
		private void a(YAxis A_0, ack A_1)
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

		// Token: 0x060051B3 RID: 20915 RVA: 0x0028AB1C File Offset: 0x00289B1C
		private float d(PlotArea A_0, YAxis A_1)
		{
			return A_0.Y + A_0.Height - A_1.g() * A_1.s();
		}

		// Token: 0x060051B4 RID: 20916 RVA: 0x0028AB4C File Offset: 0x00289B4C
		private float c(PlotArea A_0, YAxis A_1)
		{
			return A_0.X + A_1.Offset;
		}

		// Token: 0x060051B5 RID: 20917 RVA: 0x0028AB6C File Offset: 0x00289B6C
		private float b(PlotArea A_0, YAxis A_1)
		{
			return A_0.X + A_0.Width + A_1.Offset;
		}

		// Token: 0x060051B6 RID: 20918 RVA: 0x0028AB94 File Offset: 0x00289B94
		private float a(PlotArea A_0, YAxis A_1)
		{
			return A_0.X + A_1.Offset * (A_0.i().g() / A_0.i().t()) + A_0.j().h() * A_0.i().g() + A_0.i().s() * A_0.i().g();
		}

		// Token: 0x060051B7 RID: 20919 RVA: 0x0028ABFC File Offset: 0x00289BFC
		private void b(PageWriter A_0, YAxis A_1, int A_2, float A_3, float A_4)
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
			if (this.a == YAxisTickMarksPosition.Automatic)
			{
				if (A_1.AnchorType == YAxisAnchorType.Right)
				{
					this.a = YAxisTickMarksPosition.Right;
				}
				else if (A_1.AnchorType == YAxisAnchorType.Left || A_1.AnchorType == YAxisAnchorType.Floating)
				{
					this.a = YAxisTickMarksPosition.Left;
				}
			}
			if (base.LineStyle != LineStyle.None)
			{
				switch (this.a)
				{
				case YAxisTickMarksPosition.Right:
				{
					int num5 = 0;
					while ((float)num5 < (float)A_2 * num2 - (float)num)
					{
						base.a(A_0, A_3 - num4, A_4 - num3 * (float)num5, A_3 + base.Length, A_4 - num3 * (float)num5);
						num5++;
					}
					break;
				}
				case YAxisTickMarksPosition.Left:
				{
					int num5 = 0;
					while ((float)num5 < (float)A_2 * num2 - (float)num)
					{
						base.a(A_0, A_3 + num4, A_4 - num3 * (float)num5, A_3 - base.Length, A_4 - num3 * (float)num5);
						num5++;
					}
					break;
				}
				case YAxisTickMarksPosition.Across:
				{
					int num5 = 0;
					while ((float)num5 < (float)A_2 * num2 - (float)num)
					{
						base.a(A_0, A_3 - base.Length / 2f, A_4 - num3 * (float)num5, A_3 + base.Length / 2f, A_4 - num3 * (float)num5);
						num5++;
					}
					break;
				}
				}
				A_0.Write_S();
			}
		}

		// Token: 0x060051B8 RID: 20920 RVA: 0x0028ADCC File Offset: 0x00289DCC
		private void a(PageWriter A_0, YAxis A_1, int A_2, float A_3, float A_4)
		{
			int num = 0;
			int num2 = 1;
			int num3 = 1;
			float num4 = 0f;
			float num5 = A_1.t() / base.Interval;
			float num6 = A_1.g() / num5;
			if (num5 > 1f)
			{
				num = (int)(num5 - 1f);
			}
			float num7 = A_1.LineWidth / 2f;
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
			if (this.a == YAxisTickMarksPosition.Automatic)
			{
				if (A_1.AnchorType == YAxisAnchorType.Right)
				{
					this.a = YAxisTickMarksPosition.Right;
				}
				else if (A_1.AnchorType == YAxisAnchorType.Left || A_1.AnchorType == YAxisAnchorType.Floating)
				{
					this.a = YAxisTickMarksPosition.Left;
				}
			}
			if (base.LineStyle != LineStyle.None)
			{
				switch (this.a)
				{
				case YAxisTickMarksPosition.Right:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 - num7, A_4 - num6 * (float)num8, A_3 + base.Length, A_4 - num6 * (float)num8);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 - num7, A_4 - num6 * (float)num8, A_3 + base.Length, A_4 - num6 * (float)num8);
						}
						num8++;
					}
					break;
				}
				case YAxisTickMarksPosition.Left:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 + num7, A_4 - num6 * (float)num8, A_3 - base.Length, A_4 - num6 * (float)num8);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 + num7, A_4 - num6 * (float)num8, A_3 - base.Length, A_4 - num6 * (float)num8);
						}
						num8++;
					}
					break;
				}
				case YAxisTickMarksPosition.Across:
				{
					int num8 = num3;
					while ((float)num8 < (float)A_2 * num5 - (float)num2 - (float)num)
					{
						if (num4 != 0f && base.Interval * (float)num8 % num4 != 0f)
						{
							base.a(A_0, A_3 + base.Length / 2f, A_4 - num6 * (float)num8, A_3 - base.Length / 2f, A_4 - num6 * (float)num8);
						}
						else if (num4 == 0f)
						{
							base.a(A_0, A_3 + base.Length / 2f, A_4 - num6 * (float)num8, A_3 - base.Length / 2f, A_4 - num6 * (float)num8);
						}
						num8++;
					}
					break;
				}
				}
				A_0.Write_S();
			}
		}

		// Token: 0x04002BB4 RID: 11188
		private new YAxisTickMarksPosition a = YAxisTickMarksPosition.Automatic;
	}
}
