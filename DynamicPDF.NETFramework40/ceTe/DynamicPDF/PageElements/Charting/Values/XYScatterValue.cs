using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x02000912 RID: 2322
	public class XYScatterValue
	{
		// Token: 0x06005EC0 RID: 24256 RVA: 0x0035832D File Offset: 0x0035732D
		public XYScatterValue(float yValue, float xValue)
		{
			this.a = yValue;
			this.b = xValue;
		}

		// Token: 0x06005EC1 RID: 24257 RVA: 0x0035834D File Offset: 0x0035734D
		public XYScatterValue(float yValue, float xValue, XYScatterDataLabel dataLabel)
		{
			this.f = dataLabel;
			this.a = yValue;
			this.b = xValue;
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06005EC2 RID: 24258 RVA: 0x00358374 File Offset: 0x00357374
		// (set) Token: 0x06005EC3 RID: 24259 RVA: 0x0035838C File Offset: 0x0035738C
		public XYScatterDataLabel DataLabel
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

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06005EC4 RID: 24260 RVA: 0x00358398 File Offset: 0x00357398
		public float ScatterYValue
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06005EC5 RID: 24261 RVA: 0x003583B0 File Offset: 0x003573B0
		public float ScatterXValue
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06005EC6 RID: 24262 RVA: 0x003583C8 File Offset: 0x003573C8
		internal float a()
		{
			return this.d;
		}

		// Token: 0x06005EC7 RID: 24263 RVA: 0x003583E0 File Offset: 0x003573E0
		internal float b()
		{
			return this.e;
		}

		// Token: 0x06005EC8 RID: 24264 RVA: 0x003583F8 File Offset: 0x003573F8
		internal void a(XYScatterSeries A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005EC9 RID: 24265 RVA: 0x00358404 File Offset: 0x00357404
		private float b(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return (A_5 - A_1) / num + A_0;
		}

		// Token: 0x06005ECA RID: 24266 RVA: 0x0035842C File Offset: 0x0035742C
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			float num = (A_3 - A_1) / (A_2 - A_0);
			return num * A_0 * -1f + num * A_4 + A_1;
		}

		// Token: 0x06005ECB RID: 24267 RVA: 0x0035845C File Offset: 0x0035745C
		internal void a(PageWriter A_0, int A_1, bool A_2, XYScatterValue A_3)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			XAxis xaxis = this.c.m();
			YAxis yaxis = this.c.n();
			float num5 = xaxis.v();
			float num6 = xaxis.w();
			float num7 = yaxis.v();
			float num8 = yaxis.w();
			int num9 = 0;
			PlotArea plotArea = this.c.PlotArea;
			float x = plotArea.X;
			float y = plotArea.Y;
			float width = plotArea.Width;
			float height = plotArea.Height;
			float num10 = (this.b - num5) * xaxis.g() / xaxis.t();
			float num11 = (this.a - num7) * yaxis.g() / yaxis.t();
			float num12 = height + y - num11;
			float num13 = plotArea.X + num10;
			this.d = num12;
			this.e = num13;
			float num14 = (A_3.ScatterXValue - num5) * xaxis.g() / xaxis.t();
			float num15 = (A_3.ScatterYValue - num7) * yaxis.g() / yaxis.t();
			float num16 = height + y - num15;
			float num17 = x + num14;
			A_3.d = num16;
			A_3.e = num17;
			if (A_2 && this.c.LineStyle != LineStyle.None)
			{
				if ((num13 >= x || num17 >= x) && (num13 <= x + width || num17 <= x + plotArea.Width) && (num12 >= plotArea.Y || num16 >= plotArea.Y) && (num12 <= plotArea.Y + plotArea.Height || num16 <= plotArea.Y + plotArea.Height))
				{
					float scatterYValue = A_3.ScatterYValue;
					float scatterXValue = A_3.ScatterXValue;
					if (this.a >= num7 && this.a <= num8 && this.b <= num6 && this.b >= num5 && scatterYValue <= num8 && scatterYValue >= num7 && scatterXValue >= num5 && scatterXValue <= num6)
					{
						num9 = 1;
					}
					else if (this.b > num6 && scatterXValue < num5 && this.a <= num8 && this.a >= num7 && scatterYValue >= num7 && scatterYValue <= num8)
					{
						num9 = 2;
					}
					else if (this.b > num6 && scatterYValue < num7)
					{
						num9 = 3;
					}
					else if (this.b > num6 && scatterYValue > num8)
					{
						num9 = 4;
					}
					else if (this.b > num6 && this.a <= num8 && this.a >= num7 && scatterYValue <= num8 && scatterYValue >= num7 && scatterXValue >= num5 && scatterXValue <= num6)
					{
						num9 = 5;
					}
					else if (this.b < num5 && scatterXValue > num6 && this.a <= num8 && this.a >= num7 && scatterYValue >= num7 && scatterYValue <= num8)
					{
						num9 = 6;
					}
					else if (this.b < num5 && scatterYValue < num7 && this.a >= num7 && this.a <= num8 && scatterXValue <= num6 && scatterXValue >= num5)
					{
						num9 = 7;
					}
					else if (this.b < num5 && scatterYValue > num8)
					{
						num9 = 8;
					}
					else if (this.b < num5 && this.a <= num8 && this.a >= num7 && scatterYValue <= num8 && scatterYValue >= num7 && scatterXValue >= num5 && scatterXValue <= num6)
					{
						num9 = 9;
					}
					else if (this.a < num7 && scatterXValue > num6)
					{
						num9 = 10;
					}
					else if (this.a < num7 && scatterXValue < num5)
					{
						num9 = 11;
					}
					else if (this.a < num7 && scatterYValue > num8 && this.b <= num6 && this.b >= num5 && scatterXValue <= num6 && scatterXValue >= num5)
					{
						num9 = 12;
					}
					else if (this.a < num7 && scatterYValue <= num8 && scatterYValue >= num7 && scatterXValue >= num5 && scatterXValue <= num6)
					{
						num9 = 13;
					}
					else if (this.a > num8 && this.b <= num6 && this.b >= num5 && scatterXValue > num6)
					{
						num9 = 14;
					}
					else if (this.a > num8 && scatterXValue < num5 && this.b <= num6 && this.b >= num5 && scatterYValue <= num8 && scatterYValue >= num7)
					{
						num9 = 15;
					}
					else if (this.a > num8 && scatterYValue < num7 && this.b <= num6 && this.b >= num5 && scatterXValue <= num6 && scatterXValue >= num5)
					{
						num9 = 16;
					}
					else if (this.a > num8 && scatterYValue <= num8 && scatterYValue >= num7 && scatterXValue >= num5 && scatterXValue <= num6)
					{
						num9 = 17;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b <= num6 && this.b >= num7 && scatterXValue > num6 && scatterYValue >= num7 && scatterYValue <= num8)
					{
						num9 = 18;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b <= num6 && this.b >= num5 && scatterXValue < num5 && scatterYValue >= num7 && scatterYValue <= num8)
					{
						num9 = 19;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b <= num6 && this.b >= num5 && scatterYValue > num8)
					{
						num9 = 20;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b <= num6 && this.b >= num5 && scatterYValue < num7)
					{
						num9 = 21;
					}
					else if (this.a > num8 && this.b < num5 && scatterYValue < num7 && scatterXValue > num6)
					{
						num9 = 22;
					}
					else if (this.a > num8 && this.b > num6 && scatterYValue < num7 && scatterXValue < num5)
					{
						num9 = 23;
					}
					else if (scatterYValue > num8 && scatterXValue < num5 && this.a < num7 && this.b > num6)
					{
						num9 = 24;
					}
					else if (scatterYValue > num8 && scatterXValue > num6 && this.a < num7 && this.b < num5)
					{
						num9 = 25;
					}
					else if (this.b <= num6 && this.b >= num5 && this.a < num7 && (scatterXValue > num6 || scatterXValue < num5) && scatterYValue > num8)
					{
						num9 = 26;
					}
					else if (this.b <= num6 && this.b >= num5 && this.a > num8 && (scatterXValue > num6 || scatterXValue < num5) && scatterYValue < num7)
					{
						num9 = 27;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b > num6 && (scatterYValue > num8 || scatterYValue < num7) && scatterXValue < num5)
					{
						num9 = 28;
					}
					else if (this.a <= num8 && this.a >= num7 && this.b < num5 && (scatterYValue > num8 || scatterYValue < num7) && scatterXValue > num6)
					{
						num9 = 29;
					}
					switch (num9)
					{
					case 1:
						if (A_1 == 0)
						{
							A_0.Write_m_(num13, num12);
							A_0.Write_l_(num17, num16);
						}
						else
						{
							A_0.Write_l_(num17, num16);
						}
						break;
					case 2:
						num = x + width;
						num3 = x;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					case 3:
						num = x + width;
						num4 = y + height;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						if (num3 <= x + width && num3 >= x && num2 >= y && num2 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 4:
						num = x + width;
						num4 = y;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						if (num3 <= x + width && num3 >= x && num2 >= y && num2 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 5:
						if (this.a <= num8 && this.a >= num7)
						{
							num = x + width;
							num2 = this.a(num13, num12, num17, num16, num, num2);
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num17, num16);
						}
						break;
					case 6:
						num = x;
						num3 = x + width;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					case 7:
						num = x;
						num4 = y + height;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						if (num3 <= x + width && num3 >= x && num2 >= y && num2 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 8:
						num = x;
						num4 = y;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						if (num3 <= x + width && num3 >= x && num2 >= y && num2 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 9:
						num = x;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num17, num16);
						break;
					case 10:
						num2 = y + height;
						num3 = x + width;
						num = this.b(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						if (num <= x + width && num >= x && num4 >= y && num4 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 11:
						num2 = y + height;
						num3 = x;
						num = this.b(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						if (num <= x + width && num >= x && num4 >= y && num4 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 12:
						num2 = y + height;
						num4 = y;
						num = this.b(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					case 13:
						if (this.b > num6)
						{
							float num18 = x + width;
							float num19 = y + height;
							float num20 = (num19 - num16) / (num18 - num17);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 < num20)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 == num20)
							{
								A_0.Write_m_(num18, num19);
								A_0.Write_l_(num17, num16);
							}
						}
						else if (this.b < num5)
						{
							float num18 = x;
							float num19 = y + height;
							float num20 = (num19 - num16) / (num18 - num17);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 < num20)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 == num20)
							{
								A_0.Write_m_(num18, num19);
								A_0.Write_l_(num17, num16);
							}
						}
						else if (this.b <= num6 && this.b >= num5)
						{
							num2 = y + height;
							num = this.b(num13, num12, num17, num16, num, num2);
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num17, num16);
						}
						break;
					case 14:
						num2 = y;
						num3 = x + width;
						num = this.b(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						if (num <= x + width && num >= x && num4 >= y && num4 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 15:
						num2 = y;
						num3 = x;
						num = this.b(num13, num12, num17, num16, num, num2);
						num4 = this.a(num13, num12, num17, num16, num3, num4);
						if (num <= x + width && num >= x && num4 >= y && num4 <= y + plotArea.Height)
						{
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num3, num4);
						}
						break;
					case 16:
						num2 = y;
						num4 = y + height;
						num = this.b(num13, num12, num17, num16, num, num2);
						num3 = this.b(num13, num12, num17, num16, num3, num4);
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					case 17:
						if (this.b > num6)
						{
							float num18 = x + width;
							float num19 = y;
							float num20 = (num19 - num16) / (num18 - num17);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 < num20)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 == num20)
							{
								A_0.Write_m_(num18, num19);
								A_0.Write_l_(num17, num16);
							}
						}
						else if (this.b < num5)
						{
							float num18 = x;
							float num19 = y;
							float num20 = (num19 - num16) / (num18 - num17);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 < num20)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								A_0.Write_m_(num, num2);
								A_0.Write_l_(num17, num16);
							}
							else if (num21 == num20)
							{
								A_0.Write_m_(num18, num19);
								A_0.Write_l_(num17, num16);
							}
						}
						else if (this.b <= num6 && this.b >= num5)
						{
							num2 = y;
							num = this.b(num13, num12, num17, num16, num, num2);
							A_0.Write_m_(num, num2);
							A_0.Write_l_(num17, num16);
						}
						break;
					case 18:
						num = x + width;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						if (A_1 == 0)
						{
							A_0.Write_m_(num13, num12);
							A_0.Write_l_(num, num2);
						}
						else
						{
							A_0.Write_l_(num, num2);
						}
						break;
					case 19:
						num = x;
						num2 = this.a(num13, num12, num17, num16, num, num2);
						if (A_1 == 0)
						{
							A_0.Write_m_(num13, num12);
							A_0.Write_l_(num, num2);
						}
						else
						{
							A_0.Write_l_(num, num2);
						}
						break;
					case 20:
						if (scatterXValue > num6)
						{
							float num18 = x + width;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 < num20)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 == num20)
							{
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num18, num19);
								}
								else
								{
									A_0.Write_l_(num18, num19);
								}
							}
						}
						else if (scatterXValue < num5)
						{
							float num18 = x;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 < num20)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 == num20)
							{
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num18, num19);
								}
								else
								{
									A_0.Write_l_(num18, num19);
								}
							}
						}
						else if (scatterXValue <= num6 && scatterXValue >= num5)
						{
							num2 = y;
							num = this.b(num13, num12, num17, num16, num, num2);
							if (A_1 == 0)
							{
								A_0.Write_m_(num13, num12);
								A_0.Write_l_(num, num2);
							}
							else
							{
								A_0.Write_l_(num, num2);
							}
						}
						break;
					case 21:
						if (scatterXValue > num6)
						{
							float num18 = x + width;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 < num20)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 == num20)
							{
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num18, num19);
								}
								else
								{
									A_0.Write_l_(num18, num19);
								}
							}
						}
						else if (scatterXValue < num5)
						{
							float num18 = x;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num21 > num20)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 < num20)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num, num2);
								}
								else
								{
									A_0.Write_l_(num, num2);
								}
							}
							else if (num21 == num20)
							{
								if (A_1 == 0)
								{
									A_0.Write_m_(num13, num12);
									A_0.Write_l_(num18, num19);
								}
								else
								{
									A_0.Write_l_(num18, num19);
								}
							}
						}
						else if (scatterXValue <= num6 && scatterXValue >= num5)
						{
							num2 = y + height;
							num = this.b(num13, num12, num17, num16, num, num2);
							if (A_1 == 0)
							{
								A_0.Write_m_(num13, num12);
								A_0.Write_l_(num, num2);
							}
							else
							{
								A_0.Write_l_(num, num2);
							}
						}
						break;
					case 22:
					{
						float num18 = x;
						float num19 = y;
						float num20 = (num19 - num16) / (num18 - num17);
						float num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num = x;
							num2 = this.a(num13, num12, num17, num16, num, num2);
						}
						else if (num20 < num21)
						{
							num2 = y;
							num = this.b(num13, num12, num17, num16, num, num2);
						}
						else if (num21 == num20)
						{
							num = x;
							num2 = y;
						}
						num18 = x + width;
						num19 = y + height;
						num20 = (num19 - num12) / (num18 - num13);
						num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 < num21)
						{
							num4 = y + height;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 == num21)
						{
							num3 = x + width;
							num4 = y + height;
						}
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					}
					case 23:
					{
						float num18 = x;
						float num19 = y + height;
						float num20 = (num19 - num12) / (num18 - num13);
						float num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num2 = y + height;
							num = this.b(num13, num12, num17, num16, num, num2);
						}
						else if (num20 < num21)
						{
							num = x;
							num2 = this.a(num13, num12, num17, num16, num, num2);
						}
						else if (num21 == num20)
						{
							num = x;
							num2 = y + height;
						}
						num18 = x + width;
						num19 = y;
						num20 = (num19 - num16) / (num18 - num17);
						num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num4 = y;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 < num21)
						{
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 == num21)
						{
							num3 = x + width;
							num4 = y;
						}
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					}
					case 24:
					{
						float num18 = x;
						float num19 = y;
						float num20 = (num19 - num12) / (num18 - num13);
						float num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num = x;
							num2 = this.a(num13, num12, num17, num16, num, num2);
						}
						else if (num20 < num21)
						{
							num2 = y;
							num = this.b(num13, num12, num17, num16, num, num2);
						}
						else if (num21 == num20)
						{
							num = x;
							num2 = y;
						}
						num18 = x + width;
						num19 = y + height;
						num20 = (num19 - num16) / (num18 - num17);
						num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 < num21)
						{
							num4 = y + height;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 == num21)
						{
							num3 = x + width;
							num4 = y + height;
						}
						A_0.Write_m_(num3, num4);
						A_0.Write_l_(num, num2);
						break;
					}
					case 25:
					{
						float num18 = x;
						float num19 = y + height;
						float num20 = (num19 - num16) / (num18 - num17);
						float num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num2 = y + height;
							num = this.b(num13, num12, num17, num16, num, num2);
						}
						else if (num20 < num21)
						{
							num = x;
							num2 = this.a(num13, num12, num17, num16, num, num2);
						}
						else if (num21 == num20)
						{
							num = x;
							num2 = y + height;
						}
						num18 = x + width;
						num19 = y;
						num20 = (num19 - num12) / (num18 - num13);
						num21 = (num12 - num16) / (num13 - num17);
						if (num20 > num21)
						{
							num4 = y;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 < num21)
						{
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
						}
						else if (num20 == num21)
						{
							num3 = x + width;
							num4 = y;
						}
						A_0.Write_m_(num, num2);
						A_0.Write_l_(num3, num4);
						break;
					}
					case 26:
						if (scatterXValue > num6)
						{
							float num18 = x + width;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 < num21)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num20 > num21)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x + width;
								num2 = y;
							}
							num4 = y + height;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						else if (scatterXValue < num5)
						{
							float num18 = x;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 < num21)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num20 > num21)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x;
								num2 = y;
							}
							num4 = y + height;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						break;
					case 27:
						if (scatterXValue < num5)
						{
							float num18 = x;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 > num21)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num20 < num21)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x;
								num2 = y + height;
							}
							num4 = y;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						else if (scatterXValue > num6)
						{
							float num18 = x + width;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 > num21)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num20 < num21)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x + width;
								num2 = y + height;
							}
							num4 = y;
							num3 = this.b(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						break;
					case 28:
						if (scatterYValue > num8)
						{
							float num18 = x;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 < num21)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num20 > num21)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x;
								num2 = y;
							}
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						else if (scatterYValue < num7)
						{
							float num18 = x;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 > num21)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num20 < num21)
							{
								num = x;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x;
								num2 = y + height;
							}
							num3 = x + width;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						break;
					case 29:
						if (scatterYValue < num7)
						{
							float num18 = x + width;
							float num19 = y + height;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 > num21)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num20 < num21)
							{
								num2 = y + height;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x + width;
								num2 = y + height;
							}
							num3 = x;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						else if (scatterYValue > num8)
						{
							float num18 = x + width;
							float num19 = y;
							float num20 = (num19 - num12) / (num18 - num13);
							float num21 = (num12 - num16) / (num13 - num17);
							if (num20 < num21)
							{
								num = x + width;
								num2 = this.a(num13, num12, num17, num16, num, num2);
							}
							else if (num20 > num21)
							{
								num2 = y;
								num = this.b(num13, num12, num17, num16, num, num2);
							}
							else if (num21 == num20)
							{
								num = x + width;
								num2 = y;
							}
							num3 = x;
							num4 = this.a(num13, num12, num17, num16, num3, num4);
							A_0.Write_m_(num3, num4);
							A_0.Write_l_(num, num2);
						}
						break;
					}
				}
			}
		}

		// Token: 0x06005ECC RID: 24268 RVA: 0x0035A8A8 File Offset: 0x003598A8
		internal void a(PageWriter A_0, int A_1, bool A_2)
		{
			PlotArea plotArea = this.c.PlotArea;
			XAxis xaxis = this.c.m();
			YAxis yaxis = this.c.n();
			float num = (this.b - xaxis.v()) * xaxis.g() / xaxis.t();
			float num2 = (this.a - yaxis.v()) * yaxis.g() / yaxis.t();
			float y = plotArea.Height + plotArea.Y - num2;
			float x = plotArea.X + num;
			this.d = y;
			this.e = x;
			if (A_2 && this.c.LineStyle != LineStyle.None)
			{
				if (A_1 == 0)
				{
					A_0.Write_m_(x, y);
				}
				else
				{
					A_0.Write_l_(x, y);
				}
			}
		}

		// Token: 0x040030B5 RID: 12469
		private float a;

		// Token: 0x040030B6 RID: 12470
		private float b;

		// Token: 0x040030B7 RID: 12471
		private XYScatterSeries c;

		// Token: 0x040030B8 RID: 12472
		private float d;

		// Token: 0x040030B9 RID: 12473
		private float e;

		// Token: 0x040030BA RID: 12474
		private XYScatterDataLabel f = null;
	}
}
