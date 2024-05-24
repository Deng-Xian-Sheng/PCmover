using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C4 RID: 2244
	public class PieSeriesElement : SeriesElement
	{
		// Token: 0x06005BE7 RID: 23527 RVA: 0x00340AD2 File Offset: 0x0033FAD2
		public PieSeriesElement(float value1)
		{
			this.a = value1;
		}

		// Token: 0x06005BE8 RID: 23528 RVA: 0x00340B05 File Offset: 0x0033FB05
		public PieSeriesElement(float value1, string name)
		{
			base.a(name);
			this.a = value1;
		}

		// Token: 0x06005BE9 RID: 23529 RVA: 0x00340B40 File Offset: 0x0033FB40
		public PieSeriesElement(float value1, string name, Color color) : base(name, color, null)
		{
			this.a = value1;
		}

		// Token: 0x06005BEA RID: 23530 RVA: 0x00340B76 File Offset: 0x0033FB76
		public PieSeriesElement(float value1, string name, Color color, Legend legend) : base(name, color, legend)
		{
			this.a = value1;
		}

		// Token: 0x06005BEB RID: 23531 RVA: 0x00340BAD File Offset: 0x0033FBAD
		public PieSeriesElement(float value1, ScalarDataLabel scalarDataLabel)
		{
			this.c = scalarDataLabel;
			this.a = value1;
		}

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x06005BEC RID: 23532 RVA: 0x00340BE8 File Offset: 0x0033FBE8
		// (set) Token: 0x06005BED RID: 23533 RVA: 0x00340C00 File Offset: 0x0033FC00
		public float Value
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

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x06005BEE RID: 23534 RVA: 0x00340C0C File Offset: 0x0033FC0C
		// (set) Token: 0x06005BEF RID: 23535 RVA: 0x00340C24 File Offset: 0x0033FC24
		public float BorderWidth
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06005BF0 RID: 23536 RVA: 0x00340C30 File Offset: 0x0033FC30
		// (set) Token: 0x06005BF1 RID: 23537 RVA: 0x00340C48 File Offset: 0x0033FC48
		public Color BorderColor
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06005BF2 RID: 23538 RVA: 0x00340C54 File Offset: 0x0033FC54
		// (set) Token: 0x06005BF3 RID: 23539 RVA: 0x00340C6C File Offset: 0x0033FC6C
		public float ExplodeLength
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06005BF4 RID: 23540 RVA: 0x00340C78 File Offset: 0x0033FC78
		// (set) Token: 0x06005BF5 RID: 23541 RVA: 0x00340C90 File Offset: 0x0033FC90
		public ScalarDataLabel DataLabel
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

		// Token: 0x06005BF6 RID: 23542 RVA: 0x00340C9C File Offset: 0x0033FC9C
		internal PieSeries a()
		{
			return this.b;
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x00340CB4 File Offset: 0x0033FCB4
		internal void a(PieSeries A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005BF8 RID: 23544 RVA: 0x00340CC0 File Offset: 0x0033FCC0
		internal float b()
		{
			return this.j;
		}

		// Token: 0x06005BF9 RID: 23545 RVA: 0x00340CD8 File Offset: 0x0033FCD8
		internal float c()
		{
			return this.k;
		}

		// Token: 0x06005BFA RID: 23546 RVA: 0x00340CF0 File Offset: 0x0033FCF0
		internal float a(float A_0)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num2 = this.b.XOffset;
			float num3 = this.b.YOffset;
			float radius = this.b.Radius;
			double num4 = (double)(num / 2f + A_0) * 3.141592653589793 / 180.0;
			float result = A_0 + num;
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(num4);
				num3 += this.f * (float)Math.Sin(num4);
			}
			if (this.c == null && this.b.DataLabel != null)
			{
				this.c = this.b.DataLabel;
			}
			if (this.c != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.c.Prefix);
				if (this.c.ShowValue)
				{
					stringBuilder.Append(this.a.ToString(this.b.ValueFormat));
				}
				if (this.c.ShowPercentage)
				{
					if (this.c.ShowValue)
					{
						stringBuilder.Append(this.c.Separator);
					}
					if (this.b.PercentageFormat.IndexOf('%') != -1)
					{
						stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a()).ToString(this.b.PercentageFormat));
					}
					else
					{
						stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a() * 100f).ToString(this.b.PercentageFormat));
					}
				}
				if (this.c.ShowElement)
				{
					if (this.c.ShowValue || this.c.ShowPercentage)
					{
						stringBuilder.Append(this.c.Separator);
					}
					stringBuilder.Append(" " + base.Name.Trim());
				}
				stringBuilder.Append(this.c.Suffix);
				this.c.a(this.b.PlotArea.Chart);
				string text = stringBuilder.ToString().Trim();
				float num5 = this.c.Font.GetTextWidth(text, this.c.FontSize);
				TextLineList textLines = this.c.Font.GetTextLines(text.ToCharArray(), num5, float.MaxValue, this.c.FontSize);
				float textHeight = textLines.GetTextHeight();
				this.l = num5;
				this.m = textHeight;
				this.p = text;
				double val = 0.0;
				double val2 = 0.0;
				double num6;
				double num7;
				if (this.b.DataLabelPosition == ScalarDataLabelPosition.OutsideWithConnectors)
				{
					num6 = (double)num2 + (double)(10f + radius) * Math.Cos(num4);
					if (num6 > (double)num2)
					{
						num6 = (double)(num2 + (radius + 10f) * (float)Math.Cos(0.0));
					}
					else
					{
						num6 = (double)(num2 + (radius + 10f) * (float)Math.Cos(3.141592653589793));
					}
					num7 = (double)num3 + (double)(10f + radius) * Math.Sin(num4);
				}
				else if (this.b.DataLabelPosition == ScalarDataLabelPosition.Outside)
				{
					num6 = (double)num2 + (double)(3f + radius) * Math.Cos(num4);
					num7 = (double)num3 + (double)(3f + radius) * Math.Sin(num4);
				}
				else
				{
					num6 = (double)num2 + (double)(radius / 2f) * Math.Cos(num4);
					num7 = (double)num3 + (double)(radius / 2f) * Math.Sin(num4);
					num5 /= 2f;
				}
				if (num6 >= (double)num2)
				{
					if (num6 + (double)num5 > (double)(this.b.X + this.b.Width))
					{
						val = num6 + (double)num5 - (double)(this.b.X + this.b.Width);
					}
				}
				else
				{
					num6 -= (double)num5;
					if (num6 < (double)this.b.X)
					{
						val = (double)this.b.X - num6;
					}
				}
				if (num7 <= (double)num3)
				{
					if (num7 - (double)textHeight < (double)this.b.Y)
					{
						val2 = (double)this.b.Y - (num7 - (double)textHeight);
					}
				}
				else
				{
					num7 += (double)this.c.FontSize * Math.Sin(num4);
					if (num7 > (double)(this.b.Y + this.b.Height))
					{
						val2 = num7 - (double)(this.b.Y + this.b.Height);
					}
				}
				this.j = (float)Math.Max(val, val2);
			}
			return result;
		}

		// Token: 0x06005BFB RID: 23547 RVA: 0x003412C0 File Offset: 0x003402C0
		internal float d()
		{
			return this.l;
		}

		// Token: 0x06005BFC RID: 23548 RVA: 0x003412D8 File Offset: 0x003402D8
		internal void b(float A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06005BFD RID: 23549 RVA: 0x003412E4 File Offset: 0x003402E4
		internal float e()
		{
			return this.m;
		}

		// Token: 0x06005BFE RID: 23550 RVA: 0x003412FC File Offset: 0x003402FC
		internal void c(float A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06005BFF RID: 23551 RVA: 0x00341308 File Offset: 0x00340308
		internal float f()
		{
			return this.n;
		}

		// Token: 0x06005C00 RID: 23552 RVA: 0x00341320 File Offset: 0x00340320
		internal void d(float A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06005C01 RID: 23553 RVA: 0x0034132C File Offset: 0x0034032C
		internal float g()
		{
			return this.o;
		}

		// Token: 0x06005C02 RID: 23554 RVA: 0x00341344 File Offset: 0x00340344
		internal void e(float A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06005C03 RID: 23555 RVA: 0x00341350 File Offset: 0x00340350
		internal float a(float A_0, float A_1, float A_2)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num2 = this.b.XOffset;
			float radius = this.b.Radius;
			double num3 = (double)(num / 2f + A_0) * 3.141592653589793 / 180.0;
			float result = A_0 + num;
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(num3);
			}
			this.n = (float)((double)num2 + (double)(10f + radius) * Math.Cos(num3));
			if (this.n < num2)
			{
				this.n = A_1 - this.l;
			}
			else
			{
				this.n = A_2;
			}
			return result;
		}

		// Token: 0x06005C04 RID: 23556 RVA: 0x00341434 File Offset: 0x00340434
		internal float h()
		{
			return this.q;
		}

		// Token: 0x06005C05 RID: 23557 RVA: 0x0034144C File Offset: 0x0034044C
		internal float f(float A_0)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num2 = this.b.XOffset;
			float num3 = this.b.YOffset;
			float radius = this.b.Radius;
			double num4 = (double)(num / 2f + A_0) * 3.141592653589793 / 180.0;
			float result = A_0 + num;
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(num4);
				num3 += this.f * (float)Math.Sin(num4);
			}
			this.q = (float)((double)num3 + (double)radius * Math.Sin(num4));
			this.n = (float)((double)num2 + (double)(10f + radius) * Math.Cos(num4));
			this.o = (float)((double)num3 + (double)(10f + radius) * Math.Sin(num4));
			if (this.n < num2)
			{
				this.n -= this.l;
			}
			if (this.o > num3)
			{
				this.o += (float)((double)this.m * Math.Sin(num4));
			}
			else if (this.o == num3)
			{
				this.o += (float)((double)this.m * Math.Sin(num4)) / 2f;
			}
			this.o -= this.m;
			return result;
		}

		// Token: 0x06005C06 RID: 23558 RVA: 0x003415F4 File Offset: 0x003405F4
		internal float g(float A_0)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num2 = this.b.XOffset;
			float num3 = this.b.YOffset;
			float radius = this.b.Radius;
			double num4 = (double)(num / 2f + A_0) * 3.141592653589793 / 180.0;
			float result = A_0 + num;
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(num4);
				num3 += this.f * (float)Math.Sin(num4);
			}
			this.q = (float)((double)num3 + (double)radius * Math.Sin(num4));
			this.n = (float)((double)num2 + (double)radius * Math.Cos(num4));
			this.o = (float)((double)num3 + (double)radius * Math.Sin(num4));
			if (this.n < num2)
			{
				this.n -= 10f;
				this.n -= this.l;
			}
			else
			{
				this.n += 10f;
			}
			this.o -= this.m / 2f;
			return result;
		}

		// Token: 0x06005C07 RID: 23559 RVA: 0x00341758 File Offset: 0x00340758
		internal float h(float A_0)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num2 = this.b.XOffset;
			float num3 = this.b.YOffset;
			float radius = this.b.Radius;
			double num4 = (double)(num / 2f + A_0) * 3.141592653589793 / 180.0;
			float num5 = A_0 + num;
			double num6 = (double)A_0 * 3.141592653589793 / 180.0;
			double num7 = (double)num5 * 3.141592653589793 / 180.0;
			double num8 = Math.Sin(num6);
			double num9 = Math.Sin(num7);
			double num10 = Math.Cos(num6);
			double num11 = Math.Cos(num7);
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(num4);
				num3 += this.f * (float)Math.Sin(num4);
			}
			double num12 = (double)num2 + (double)radius * num10;
			double num13 = (double)num3 + (double)radius * num8;
			double num14 = (double)num2 + (double)radius * num11;
			double num15 = (double)num3 + (double)radius * num9;
			double num16 = (double)(num / 4f + A_0) * 3.141592653589793 / 180.0;
			double num17 = (double)(num * 0f + A_0) * 3.141592653589793 / 180.0;
			double num18 = Math.Sin(num16);
			double num19 = Math.Cos(num16);
			double num20 = Math.Sin(num17);
			double num21 = Math.Cos(num17);
			double num22 = (double)num2 + (double)radius * num19;
			double num23 = (double)num3 + (double)radius * num18;
			double num24 = (double)num2 + (double)radius * num21;
			double num25 = (double)num3 + (double)radius * num20;
			double num26 = 0.0;
			double num27 = 0.0;
			if (num12 > (double)(this.b.X + this.b.Width))
			{
				num26 = num12 - (double)(this.b.X + this.b.Width);
			}
			else if (num12 < (double)this.b.X)
			{
				num26 = (double)this.b.X - num12;
			}
			if (num13 < (double)this.b.Y)
			{
				num27 = (double)this.b.Y - num13;
			}
			else if (num13 > (double)(this.b.Y + this.b.Height))
			{
				num27 = num13 - (double)(this.b.Y + this.b.Height);
			}
			double num28 = 0.0;
			double num29 = 0.0;
			if (num14 > (double)(this.b.X + this.b.Width))
			{
				num28 = num14 - (double)(this.b.X + this.b.Width);
			}
			else if (num14 < (double)this.b.X)
			{
				num28 = (double)this.b.X - num14;
			}
			if (num15 < (double)this.b.Y)
			{
				num29 = (double)this.b.Y - num15;
			}
			else if (num15 > (double)(this.b.Y + this.b.Height))
			{
				num29 = num15 - (double)(this.b.Y + this.b.Height);
			}
			double num30 = 0.0;
			double num31 = 0.0;
			if (num22 > (double)(this.b.X + this.b.Width))
			{
				num30 = num22 - (double)(this.b.X + this.b.Width);
			}
			else if (num22 < (double)this.b.X)
			{
				num30 = (double)this.b.X - num22;
			}
			if (num23 < (double)this.b.Y)
			{
				num31 = (double)this.b.Y - num23;
			}
			else if (num23 > (double)(this.b.Y + this.b.Height))
			{
				num31 = num23 - (double)(this.b.Y + this.b.Height);
			}
			double num32 = 0.0;
			double num33 = 0.0;
			if (num24 > (double)(this.b.X + this.b.Width))
			{
				num32 = num24 - (double)(this.b.X + this.b.Width);
			}
			else if (num24 < (double)this.b.X)
			{
				num32 = (double)this.b.X - num24;
			}
			if (num25 < (double)this.b.Y)
			{
				num33 = (double)this.b.Y - num25;
			}
			else if (num25 > (double)(this.b.Y + this.b.Height))
			{
				num33 = num25 - (double)(this.b.Y + this.b.Height);
			}
			double[] array = new double[]
			{
				num26,
				num28,
				num30,
				num32,
				num27,
				num29,
				num31,
				num33
			};
			Array.Sort<double>(array);
			this.k = (float)array[array.Length - 1];
			return num5;
		}

		// Token: 0x06005C08 RID: 23560 RVA: 0x00341D5C File Offset: 0x00340D5C
		internal float a(PageWriter A_0, float A_1)
		{
			float num = 0f;
			float num2 = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			float num3 = this.b.XOffset;
			float num4 = this.b.YOffset;
			float radius = this.b.Radius;
			double num5 = Math.Asin((double)(this.e / (radius - this.e))) * 57.29577951308232;
			double num6 = Math.Asin((double)(this.e / 2f / (radius - this.e / 2f))) * 57.29577951308232;
			double num7 = (double)(num2 / 2f + A_1) * 3.141592653589793 / 180.0;
			this.i = num7;
			if (this.f > 0f)
			{
				num3 += this.f * (float)Math.Cos(num7);
				num4 += this.f * (float)Math.Sin(num7);
			}
			this.g = num3;
			this.h = num4;
			double num8 = (double)num3;
			double num9 = (double)num4;
			double num10 = (double)num3;
			double num11 = (double)num4;
			double num12 = this.a(this.e / 2f, num2);
			if (num6 <= (double)(num2 / 2f) && num12 <= (double)(radius / 5f))
			{
				num10 += num12 * Math.Cos(num7);
				num11 += num12 * Math.Sin(num7);
			}
			double num13 = this.a(this.e, num2);
			if (num5 <= (double)(num2 / 2f) && num13 <= (double)(radius / 5f))
			{
				num8 += num13 * Math.Cos(num7);
				num9 += num13 * Math.Sin(num7);
			}
			A_0.SetGraphicsMode();
			if (num2 > 90f)
			{
				float num14 = A_1;
				if (this.e > 0f && num6 <= (double)(num2 / 2f) && num12 <= (double)(radius / 5f))
				{
					A_0.SetLineWidth(this.e);
					A_0.SetStrokeColor(this.d);
					A_0.SetLineStyle(LineStyle.Solid);
					A_0.SetLineCap(LineCap.Butt);
					A_0.SetLineJoin(LineJoin.Miter);
					A_0.SetMiterLimit(2f);
					int num15 = (int)(((double)num2 - 2.0 * num6) / 90.0);
					if (num15 == 0)
					{
						num15 = 1;
					}
					float num16 = num2 / (float)(num15 + 1);
					for (int i = 0; i <= num15; i++)
					{
						num = num16 + A_1;
						double a_;
						double a_2;
						if (i == 0)
						{
							a_ = ((double)A_1 + num6) * 3.141592653589793 / 180.0;
							a_2 = (double)num * 3.141592653589793 / 180.0;
						}
						else if (i == num15)
						{
							a_ = (double)A_1 * 3.141592653589793 / 180.0;
							a_2 = ((double)num - num6) * 3.141592653589793 / 180.0;
						}
						else
						{
							a_ = (double)A_1 * 3.141592653589793 / 180.0;
							a_2 = (double)num * 3.141592653589793 / 180.0;
						}
						this.a(A_0, radius - this.e / 2f, num3, num4, a_, a_2, i, num10, num11);
						A_1 += num16;
					}
					A_0.Write_s_();
				}
				else if (this.e > 0f)
				{
					A_1 = num14;
					int num15 = (int)(num2 / 90f);
					float num16 = num2 / (float)(num15 + 1);
					A_0.SetFillColor(this.d);
					for (int i = 0; i <= num15; i++)
					{
						num = num16 + A_1;
						double a_ = (double)A_1 * 3.141592653589793 / 180.0;
						double a_2 = (double)num * 3.141592653589793 / 180.0;
						this.a(A_0, radius, num3, num4, a_, a_2, i, num10, num11);
						A_1 += num16;
					}
					A_0.Write_f();
				}
				if (num5 <= (double)(num2 / 2f) && num6 <= (double)(num2 / 2f))
				{
					A_1 = num14;
					int num15 = (int)(((double)num2 - 2.0 * num5) / 90.0);
					if (num15 == 0)
					{
						num15 = 1;
					}
					float num16 = num2 / (float)(num15 + 1);
					A_0.SetFillColor(base.Color);
					for (int i = 0; i <= num15; i++)
					{
						num = num16 + A_1;
						double a_;
						double a_2;
						if (i == 0)
						{
							a_ = ((double)A_1 + num5) * 3.141592653589793 / 180.0;
							a_2 = (double)num * 3.141592653589793 / 180.0;
						}
						else if (i == num15)
						{
							a_ = (double)A_1 * 3.141592653589793 / 180.0;
							a_2 = ((double)num - num5) * 3.141592653589793 / 180.0;
						}
						else
						{
							a_ = (double)A_1 * 3.141592653589793 / 180.0;
							a_2 = (double)num * 3.141592653589793 / 180.0;
						}
						this.a(A_0, radius - this.e, num3, num4, a_, a_2, i, num8, num9);
						A_1 += num16;
					}
					A_0.Write_f();
				}
			}
			else
			{
				num = num2 + A_1;
				if (this.e > 0f && num6 <= (double)(num2 / 2f) && num12 <= (double)(radius / 5f))
				{
					A_0.SetLineWidth(this.e);
					A_0.SetStrokeColor(this.d);
					A_0.SetLineStyle(LineStyle.Solid);
					A_0.SetLineCap(LineCap.Butt);
					A_0.SetLineJoin(LineJoin.Miter);
					A_0.SetMiterLimit(100f);
					double a_ = ((double)A_1 + num6) * 3.141592653589793 / 180.0;
					double a_2 = ((double)num - num6) * 3.141592653589793 / 180.0;
					this.a(A_0, radius - this.e / 2f, num3, num4, a_, a_2, 0, num10, num11);
					A_0.Write_s_();
				}
				else if (this.e > 0f && num2 > 0f)
				{
					A_0.SetFillColor(this.d);
					double a_ = (double)A_1 * 3.141592653589793 / 180.0;
					double a_2 = (double)num * 3.141592653589793 / 180.0;
					this.a(A_0, radius, num3, num4, a_, a_2, 0, num10, num11);
					A_0.Write_f();
				}
				if (num5 <= (double)(num2 / 2f) && num2 > 0f && num6 <= (double)(num2 / 2f))
				{
					A_0.SetFillColor(base.Color);
					double a_ = ((double)A_1 + num5) * 3.141592653589793 / 180.0;
					double a_2 = ((double)num - num5) * 3.141592653589793 / 180.0;
					this.a(A_0, radius - this.e, num3, num4, a_, a_2, 0, num8, num9);
					A_0.Write_f();
				}
			}
			return num;
		}

		// Token: 0x06005C09 RID: 23561 RVA: 0x0034253C File Offset: 0x0034153C
		internal void a(PageWriter A_0, float A_1, float A_2, float A_3, double A_4, double A_5, int A_6, double A_7, double A_8)
		{
			double num = 1.3333333333333333 * Math.Tan((A_5 - A_4) / 4.0);
			double num2 = Math.Sin(A_4);
			double num3 = Math.Sin(A_5);
			double num4 = Math.Cos(A_4);
			double num5 = Math.Cos(A_5);
			double num6 = (double)A_2 + (double)A_1 * num4;
			double num7 = (double)A_3 + (double)A_1 * num2;
			double num8 = (double)A_2 + (double)A_1 * num5;
			double num9 = (double)A_3 + (double)A_1 * num3;
			double num10 = (double)A_2 + (double)A_1 * (num4 - num * num2);
			double num11 = (double)A_3 + (double)A_1 * (num2 + num * num4);
			double num12 = (double)A_2 + (double)A_1 * (num5 + num * num3);
			double num13 = (double)A_3 + (double)A_1 * (num3 - num * num5);
			if (A_6 == 0)
			{
				A_0.Write_m_((float)A_7, (float)A_8);
				A_0.Write_l_((float)num6, (float)num7);
			}
			A_0.Write_c((float)num10, (float)num11, (float)num12, (float)num13, (float)num8, (float)num9);
		}

		// Token: 0x06005C0A RID: 23562 RVA: 0x0034262C File Offset: 0x0034162C
		internal float b(PageWriter A_0, float A_1)
		{
			float num = Math.Abs(this.a) / this.b.Elements.a() * 360f;
			if (this.c == null && this.b.DataLabel != null)
			{
				this.c = this.b.DataLabel;
			}
			float num2 = this.b.XOffset;
			float num3 = this.b.YOffset;
			if (this.f > 0f)
			{
				num2 += this.f * (float)Math.Cos(this.i);
				num3 += this.f * (float)Math.Sin(this.i);
			}
			if (this.c != null)
			{
				if (this.p == null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(this.c.Prefix);
					if (this.c.ShowValue)
					{
						stringBuilder.Append(this.a.ToString(this.b.ValueFormat));
					}
					if (this.c.ShowPercentage)
					{
						if (this.c.ShowValue)
						{
							stringBuilder.Append(this.c.Separator);
						}
						if (this.b.PercentageFormat.IndexOf('%') != -1)
						{
							stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a()).ToString(this.b.PercentageFormat));
						}
						else
						{
							stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a() * 100f).ToString(this.b.PercentageFormat));
						}
					}
					if (this.c.ShowElement)
					{
						if (this.c.ShowValue || this.c.ShowPercentage)
						{
							stringBuilder.Append(this.c.Separator);
						}
						stringBuilder.Append(" " + base.Name.Trim());
					}
					stringBuilder.Append(this.c.Suffix);
					this.p = stringBuilder.ToString().Trim();
				}
				this.c.a(this.b.PlotArea.Chart);
				float textWidth = this.c.Font.GetTextWidth(this.p, this.c.FontSize);
				TextLineList textLines = this.c.Font.GetTextLines(this.p.ToCharArray(), textWidth, float.MaxValue, this.c.FontSize);
				this.c.a(A_0, this.n, this.o, textLines);
				float num4 = (float)((double)num2 + (double)this.b.Radius * Math.Cos(this.i));
				float num5 = (float)((double)num3 + (double)this.b.Radius * Math.Sin(this.i));
				A_0.SetGraphicsMode();
				A_0.SetStrokeColor(RgbColor.Black);
				float xoffset = this.b.XOffset;
				float yoffset = this.b.YOffset;
				float num6 = (yoffset - num5) / (xoffset - num4);
				if (num4 < num2)
				{
					this.n += this.l;
				}
				A_0.Write_m_(num4, num5);
				float num7 = this.o + this.m / 2f;
				float num8 = Math.Abs((num7 - num5) / num6 + num4);
				if (num4 < num2)
				{
					if (num8 > this.n && num8 < num4)
					{
						A_0.Write_l_(num8, num7);
					}
				}
				if (num4 > num2)
				{
					if (num8 > num4 && num8 < this.n)
					{
						A_0.Write_l_(num8, num7);
					}
				}
				A_0.Write_l_(this.n, num7);
			}
			return A_1 + num;
		}

		// Token: 0x06005C0B RID: 23563 RVA: 0x00342AC8 File Offset: 0x00341AC8
		internal void a(PageWriter A_0)
		{
			if (this.c == null && this.b.DataLabel != null)
			{
				this.c = this.b.DataLabel;
			}
			if (this.c != null)
			{
				if (this.p == null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(this.c.Prefix);
					if (this.c.ShowValue)
					{
						stringBuilder.Append(this.a.ToString(this.b.ValueFormat));
					}
					if (this.c.ShowPercentage)
					{
						if (this.c.ShowValue)
						{
							stringBuilder.Append(this.c.Separator);
						}
						if (this.b.PercentageFormat.IndexOf('%') != -1)
						{
							stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a()).ToString(this.b.PercentageFormat));
						}
						else
						{
							stringBuilder.Append(" " + (Math.Abs(this.a) / this.b.Elements.a() * 100f).ToString(this.b.PercentageFormat));
						}
					}
					if (this.c.ShowElement)
					{
						if (this.c.ShowValue || this.c.ShowPercentage)
						{
							stringBuilder.Append(this.c.Separator);
						}
						stringBuilder.Append(" " + base.Name.Trim());
					}
					stringBuilder.Append(this.c.Suffix);
					this.p = stringBuilder.ToString().Trim();
				}
				this.c.a(this.b.PlotArea.Chart);
				float textWidth = this.c.Font.GetTextWidth(this.p, this.c.FontSize);
				TextLineList textLines = this.c.Font.GetTextLines(this.p.ToCharArray(), textWidth, float.MaxValue, this.c.FontSize);
				float textHeight = textLines.GetTextHeight();
				double num;
				double num2;
				if (this.b.DataLabelPosition == ScalarDataLabelPosition.Outside)
				{
					num = (double)this.g + (double)(3f + this.b.Radius) * Math.Cos(this.i);
					num2 = (double)this.h + (double)(3f + this.b.Radius) * Math.Sin(this.i);
					if (num < (double)this.g)
					{
						num -= (double)textWidth;
					}
				}
				else
				{
					num = (double)this.g + (double)(this.b.Radius / 10f) * 6.67 * Math.Cos(this.i);
					num2 = (double)this.h + (double)(this.b.Radius / 10f) * 6.67 * Math.Sin(this.i);
					num -= (double)(textWidth / 2f);
				}
				if (this.b.DataLabelPosition == ScalarDataLabelPosition.Outside)
				{
					if (num2 > (double)this.h)
					{
						num2 += (double)textHeight * Math.Sin(this.i);
					}
					else if (num2 == (double)this.h)
					{
						num2 += (double)textHeight * Math.Sin(this.i) / 2.0;
					}
				}
				if (this.b.DataLabelPosition == ScalarDataLabelPosition.Inside)
				{
					this.c.a(A_0, (float)num, (float)num2 - textHeight / 2f, textLines);
				}
				else
				{
					this.c.a(A_0, (float)num, (float)num2 - textHeight, textLines);
				}
			}
		}

		// Token: 0x06005C0C RID: 23564 RVA: 0x00342F28 File Offset: 0x00341F28
		private double a(float A_0, float A_1)
		{
			return (double)A_0 / Math.Sin((double)A_1 * 0.017453292519943295 / 2.0);
		}

		// Token: 0x04002FCA RID: 12234
		private new float a;

		// Token: 0x04002FCB RID: 12235
		private PieSeries b;

		// Token: 0x04002FCC RID: 12236
		private ScalarDataLabel c;

		// Token: 0x04002FCD RID: 12237
		private Color d;

		// Token: 0x04002FCE RID: 12238
		private float e;

		// Token: 0x04002FCF RID: 12239
		private float f;

		// Token: 0x04002FD0 RID: 12240
		private float g;

		// Token: 0x04002FD1 RID: 12241
		private float h;

		// Token: 0x04002FD2 RID: 12242
		private double i;

		// Token: 0x04002FD3 RID: 12243
		private float j;

		// Token: 0x04002FD4 RID: 12244
		private float k;

		// Token: 0x04002FD5 RID: 12245
		private float l = 0f;

		// Token: 0x04002FD6 RID: 12246
		private float m = 0f;

		// Token: 0x04002FD7 RID: 12247
		private float n;

		// Token: 0x04002FD8 RID: 12248
		private float o;

		// Token: 0x04002FD9 RID: 12249
		private string p;

		// Token: 0x04002FDA RID: 12250
		private float q = 0f;
	}
}
