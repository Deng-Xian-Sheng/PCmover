using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C5 RID: 2245
	public class PieSeriesElementList
	{
		// Token: 0x06005C0D RID: 23565 RVA: 0x00342F58 File Offset: 0x00341F58
		internal PieSeriesElementList(PieSeries A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x06005C0E RID: 23566 RVA: 0x00342F88 File Offset: 0x00341F88
		public void Add(PieSeriesElement pieSeriesElement)
		{
			if (!this.a.Contains(pieSeriesElement))
			{
				this.a.Add(pieSeriesElement);
				this.c += Math.Abs(pieSeriesElement.Value);
				pieSeriesElement.a(this.b);
				if (pieSeriesElement.Name == null)
				{
					pieSeriesElement.a("Element " + this.d++);
				}
				this.b();
				return;
			}
			throw new GeneratorException("Same PieSeriesElement object can't be added more than once.");
		}

		// Token: 0x06005C0F RID: 23567 RVA: 0x00343028 File Offset: 0x00342028
		public PieSeriesElement Add(float value1)
		{
			PieSeriesElement pieSeriesElement = new PieSeriesElement(value1, "Element " + this.d++);
			this.Add(pieSeriesElement);
			return pieSeriesElement;
		}

		// Token: 0x06005C10 RID: 23568 RVA: 0x0034306C File Offset: 0x0034206C
		public PieSeriesElement Add(float value1, string name)
		{
			PieSeriesElement result;
			if (value1 != 0f)
			{
				PieSeriesElement pieSeriesElement = new PieSeriesElement(value1, name);
				this.Add(pieSeriesElement);
				result = pieSeriesElement;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005C11 RID: 23569 RVA: 0x003430A0 File Offset: 0x003420A0
		public PieSeriesElement[] Add(float[] value1)
		{
			PieSeriesElement[] array = new PieSeriesElement[value1.Length];
			for (int i = 0; i < value1.Length; i++)
			{
				array[i] = new PieSeriesElement(value1[i], "Element " + this.d++);
				this.Add(array[i]);
			}
			return array;
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06005C12 RID: 23570 RVA: 0x00343108 File Offset: 0x00342108
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x17000987 RID: 2439
		public PieSeriesElement this[int index]
		{
			get
			{
				return (PieSeriesElement)this.a[index];
			}
		}

		// Token: 0x06005C14 RID: 23572 RVA: 0x0034314C File Offset: 0x0034214C
		internal float a()
		{
			return this.c;
		}

		// Token: 0x06005C15 RID: 23573 RVA: 0x00343164 File Offset: 0x00342164
		internal void b()
		{
			if (this.b.Legend == null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
					if (pieSeriesElement.Legend != null)
					{
						this.b.Legend = pieSeriesElement.Legend;
						break;
					}
				}
			}
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				if (pieSeriesElement.Legend == null && this.b.Legend != null)
				{
					pieSeriesElement.Legend = this.b.Legend;
				}
				if (pieSeriesElement.PlotArea == null && this.b.PlotArea != null)
				{
					pieSeriesElement.a(this.b.PlotArea);
					this.b.PlotArea.Series.a(pieSeriesElement);
				}
			}
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x00343288 File Offset: 0x00342288
		internal void c()
		{
			this.b.PlotArea.Series.a(0);
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				if (pieSeriesElement.Color == null)
				{
					pieSeriesElement.Color = this.b.PlotArea.Series.n();
				}
			}
			this.b.PlotArea.Series.a(10);
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				if (this.b.BorderWidth > 0f && this.b.BorderColor != null)
				{
					if (pieSeriesElement.BorderWidth <= 0f)
					{
						pieSeriesElement.BorderWidth = this.b.BorderWidth;
					}
					if (pieSeriesElement.BorderColor == null)
					{
						pieSeriesElement.BorderColor = this.b.BorderColor;
					}
				}
				else if (pieSeriesElement.BorderWidth > 0f && pieSeriesElement.BorderColor == null)
				{
					if (this.b.BorderColor != null)
					{
						pieSeriesElement.BorderColor = this.b.BorderColor;
					}
					else
					{
						pieSeriesElement.BorderColor = this.b.PlotArea.Series.n();
					}
				}
			}
		}

		// Token: 0x06005C17 RID: 23575 RVA: 0x0034342C File Offset: 0x0034242C
		internal void d()
		{
			this.k();
			float num = 0f;
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.a(a_);
				if (pieSeriesElement.b() > num)
				{
					num = pieSeriesElement.b();
				}
			}
			if (num > 0f && !this.b.a())
			{
				float num2 = this.b.Radius - num;
				if (num2 > 10f)
				{
					this.b.b(num2);
				}
				else
				{
					this.b.b(10f);
				}
			}
		}

		// Token: 0x06005C18 RID: 23576 RVA: 0x00343510 File Offset: 0x00342510
		internal void e()
		{
			float y = this.b.PlotArea.Y;
			float num = y + this.b.PlotArea.Height;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			int num9 = -1;
			float num10 = 0f;
			float num11 = 0f;
			bool flag = false;
			do
			{
				if (this.e != 0f || this.f != 0f)
				{
					float num12 = y + this.b.PlotArea.Height - 10f;
					float num13 = this.f();
					float num14 = this.g();
					float num15 = Math.Max(num14, num13);
					if (num13 != 0f && num14 == 0f)
					{
						if (num12 > num11)
						{
							float num16 = num12 - num11;
							if (num13 < num16)
							{
								this.b.YOffset += num13;
							}
							else
							{
								this.b.YOffset += num16;
								num15 -= num16;
								if (num15 > 0f && !this.b.a())
								{
									float num17 = this.b.Radius - num15;
									if (num17 > 10f)
									{
										this.b.b(num17);
									}
									else
									{
										this.b.b(10f);
									}
								}
							}
						}
					}
					else if (num14 != 0f && num13 == 0f)
					{
						if (y < num10)
						{
							float num16 = num10 - y;
							if (num14 < num16)
							{
								this.b.YOffset -= num14;
							}
							else
							{
								this.b.YOffset -= num16;
								num15 -= num16;
								if (num15 > 0f && !this.b.a())
								{
									float num17 = this.b.Radius - num15;
									if (num17 > 10f)
									{
										this.b.b(num17);
									}
									else
									{
										this.b.b(10f);
									}
								}
							}
						}
					}
					else if (num15 > 0f && !this.b.a())
					{
						float num16 = this.b.Radius - num15;
						if (num16 > 10f)
						{
							this.b.b(num16);
						}
						else
						{
							this.b.b(10f);
						}
					}
					flag = true;
					this.h();
					num6 = -1;
					num7 = -1;
					num8 = -1;
					num9 = -1;
					num2 = 0;
					num3 = 0;
					num4 = 0;
					num5 = 0;
					this.e = 0f;
					this.f = 0f;
				}
				for (int i = 0; i < this.a.Count; i++)
				{
					PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
					if (pieSeriesElement.f() > this.b.XOffset)
					{
						if (pieSeriesElement.h() < this.b.YOffset)
						{
							if (num9 == -1)
							{
								num9 = i;
							}
							num3++;
						}
						else
						{
							if (num8 == -1)
							{
								num8 = i;
							}
							num5++;
						}
					}
					else if (pieSeriesElement.h() < this.b.YOffset)
					{
						if (num7 == -1)
						{
							num7 = i;
						}
						num2++;
					}
					else
					{
						if (num6 == -1)
						{
							num6 = i;
						}
						num4++;
					}
				}
				float yoffset = this.b.YOffset;
				if (num2 > 0)
				{
					for (int i = num7 + 1; i <= num7 + num2 - 1; i++)
					{
						PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
						PieSeriesElement pieSeriesElement2 = (PieSeriesElement)this.a[i - 1];
						if (i - 1 == num7 && pieSeriesElement2.g() + pieSeriesElement2.e() > yoffset && num4 > 0)
						{
							PieSeriesElement pieSeriesElement3 = (PieSeriesElement)this.a[num6 + num4 - 1];
							if (pieSeriesElement2.g() + pieSeriesElement2.e() > pieSeriesElement3.g())
							{
								pieSeriesElement2.e(yoffset - pieSeriesElement2.e());
							}
						}
						if (pieSeriesElement.g() + pieSeriesElement.e() > pieSeriesElement2.g())
						{
							pieSeriesElement.e(pieSeriesElement2.g() - pieSeriesElement.e());
						}
					}
				}
				if (num4 > 0)
				{
					for (int i = num6 + num4 - 2; i >= num6; i--)
					{
						PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
						PieSeriesElement pieSeriesElement2 = (PieSeriesElement)this.a[i + 1];
						if (i == num6 + num4 - 2 && pieSeriesElement2.g() < yoffset && num7 > 0)
						{
							PieSeriesElement pieSeriesElement4 = (PieSeriesElement)this.a[num7];
							if (pieSeriesElement2.g() < pieSeriesElement4.g() + pieSeriesElement4.e())
							{
								pieSeriesElement2.e(yoffset);
							}
						}
						if (pieSeriesElement.g() < pieSeriesElement2.g() + pieSeriesElement2.e())
						{
							pieSeriesElement.e(pieSeriesElement2.g() + pieSeriesElement2.e());
						}
					}
				}
				float val = 0f;
				float val2 = 0f;
				PieSeriesElement pieSeriesElement5 = null;
				int num18 = num7 + num2 - 1;
				if (num18 >= 0 && num18 < this.a.Count)
				{
					pieSeriesElement5 = (PieSeriesElement)this.a[num18];
				}
				PieSeriesElement pieSeriesElement6 = null;
				if (num6 != -1)
				{
					pieSeriesElement6 = (PieSeriesElement)this.a[num6];
				}
				if (pieSeriesElement5 != null)
				{
					num10 = pieSeriesElement5.g();
					if (pieSeriesElement5.g() < y)
					{
						val = y - pieSeriesElement5.g();
					}
				}
				if (pieSeriesElement6 != null)
				{
					num11 = pieSeriesElement6.g() + pieSeriesElement6.e();
					if (pieSeriesElement6.g() + pieSeriesElement6.e() > num)
					{
						val2 = pieSeriesElement6.g() + pieSeriesElement6.e() - num;
					}
				}
				if (num3 > 0)
				{
					for (int i = num9 + num3 - 2; i >= num9; i--)
					{
						PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
						PieSeriesElement pieSeriesElement2 = (PieSeriesElement)this.a[i + 1];
						if (i == num9 + num3 - 2 && pieSeriesElement2.g() + pieSeriesElement2.e() > yoffset && num8 > 0)
						{
							PieSeriesElement pieSeriesElement3 = (PieSeriesElement)this.a[num8];
							if (pieSeriesElement2.g() + pieSeriesElement2.e() > pieSeriesElement3.g())
							{
								pieSeriesElement2.e(yoffset - pieSeriesElement2.e());
							}
						}
						if (pieSeriesElement.g() + pieSeriesElement.e() > pieSeriesElement2.g())
						{
							pieSeriesElement.e(pieSeriesElement2.g() - pieSeriesElement.e());
						}
					}
				}
				if (num5 > 0)
				{
					for (int i = num8 + 1; i <= num8 + num5 - 1; i++)
					{
						PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
						PieSeriesElement pieSeriesElement2 = (PieSeriesElement)this.a[i - 1];
						if (i == num8 + 1 && pieSeriesElement2.g() < yoffset && num3 > 0)
						{
							PieSeriesElement pieSeriesElement4 = (PieSeriesElement)this.a[num9 + num3 - 1];
							if (pieSeriesElement2.g() < pieSeriesElement4.g() + pieSeriesElement4.e())
							{
								pieSeriesElement2.e(yoffset);
							}
						}
						if (pieSeriesElement.g() < pieSeriesElement2.g() + pieSeriesElement2.e())
						{
							pieSeriesElement.e(pieSeriesElement2.g() + pieSeriesElement2.e());
						}
					}
				}
				float val3 = 0f;
				float val4 = 0f;
				pieSeriesElement5 = null;
				pieSeriesElement6 = null;
				if (num9 != -1)
				{
					pieSeriesElement5 = (PieSeriesElement)this.a[num9];
					if (pieSeriesElement5.g() < y)
					{
						val3 = y - pieSeriesElement5.g();
					}
				}
				num18 = num8 + num5 - 1;
				if (num18 >= 0 && num18 < this.a.Count)
				{
					pieSeriesElement6 = (PieSeriesElement)this.a[num18];
				}
				if (pieSeriesElement6 != null && pieSeriesElement6.g() + pieSeriesElement6.e() > num)
				{
					val4 = pieSeriesElement6.g() + pieSeriesElement6.e() - num;
				}
				this.e = Math.Max(val, val3);
				this.f = Math.Max(val2, val4);
				if (pieSeriesElement5 != null && num10 != 0f && num10 > pieSeriesElement5.g())
				{
					num10 = pieSeriesElement5.g();
				}
				if (pieSeriesElement6 != null && num11 != 0f && num11 < pieSeriesElement6.g() + pieSeriesElement6.e())
				{
					num11 = pieSeriesElement6.g() + pieSeriesElement6.e();
				}
			}
			while ((this.e != 0f || this.f != 0f) && !flag);
		}

		// Token: 0x06005C19 RID: 23577 RVA: 0x00344000 File Offset: 0x00343000
		internal float f()
		{
			return this.e;
		}

		// Token: 0x06005C1A RID: 23578 RVA: 0x00344018 File Offset: 0x00343018
		internal float g()
		{
			return this.f;
		}

		// Token: 0x06005C1B RID: 23579 RVA: 0x00344030 File Offset: 0x00343030
		internal void a(float A_0, float A_1)
		{
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.a(a_, A_0, A_1);
			}
		}

		// Token: 0x06005C1C RID: 23580 RVA: 0x0034408C File Offset: 0x0034308C
		internal void h()
		{
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.f(a_);
			}
		}

		// Token: 0x06005C1D RID: 23581 RVA: 0x003440E4 File Offset: 0x003430E4
		internal void i()
		{
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.g(a_);
			}
		}

		// Token: 0x06005C1E RID: 23582 RVA: 0x0034413C File Offset: 0x0034313C
		internal bool j()
		{
			bool result = false;
			PieSeriesElement a_;
			PieSeriesElement a_2;
			for (int i = 0; i <= this.a.Count - 2; i++)
			{
				a_ = this[i];
				a_2 = this[i + 1];
				if (this.a(a_, a_2))
				{
					result = true;
					break;
				}
			}
			a_ = this[0];
			a_2 = this[this.a.Count - 1];
			if (this.a(a_, a_2))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06005C1F RID: 23583 RVA: 0x003441D0 File Offset: 0x003431D0
		private bool a(PieSeriesElement A_0, PieSeriesElement A_1)
		{
			float num = A_0.f();
			float num2 = A_0.f() + A_0.d();
			float num3 = A_0.g();
			float num4 = A_0.g() + A_0.e();
			float num5 = A_1.f();
			float num6 = A_1.f() + A_1.d();
			float num7 = A_1.g();
			float num8 = A_1.g() + A_1.e();
			return (num > num5 && num < num6 && num4 > num7 && num4 < num8) || (num2 > num5 && num2 < num6 && num4 > num7 && num4 < num8) || (num2 > num5 && num2 < num6 && num3 > num7 && num3 < num8) || (num > num5 && num < num6 && num3 > num7 && num3 < num8) || (num > num5 && num < num6 && object.Equals(num3, num7) && object.Equals(num4, num8)) || (num2 > num5 && num2 < num6 && object.Equals(num3, num7) && object.Equals(num4, num8)) || (num < num5 && num2 > num6 && num3 < num7 && num4 < num8) || (num < num5 && num2 > num6 && num3 > num7 && num4 > num8);
		}

		// Token: 0x06005C20 RID: 23584 RVA: 0x003443B4 File Offset: 0x003433B4
		internal void k()
		{
			float num = 0f;
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.h(a_);
				if (pieSeriesElement.c() > num)
				{
					num = pieSeriesElement.c();
				}
			}
			if (num > 0f)
			{
				this.b.b(this.b.Radius - num);
			}
		}

		// Token: 0x06005C21 RID: 23585 RVA: 0x00344458 File Offset: 0x00343458
		internal void a(PageWriter A_0)
		{
			float a_ = 270f + this.b.StartAngle;
			for (int i = 0; i < this.a.Count; i++)
			{
				PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
				a_ = pieSeriesElement.a(A_0, a_);
			}
		}

		// Token: 0x06005C22 RID: 23586 RVA: 0x003444B4 File Offset: 0x003434B4
		internal void b(PageWriter A_0)
		{
			if (this.b.DataLabelPosition == ScalarDataLabelPosition.OutsideWithConnectors)
			{
				float a_ = 270f + this.b.StartAngle;
				for (int i = 0; i < this.a.Count; i++)
				{
					PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
					a_ = pieSeriesElement.b(A_0, a_);
				}
				A_0.Write_S();
			}
			else
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					PieSeriesElement pieSeriesElement = (PieSeriesElement)this.a[i];
					pieSeriesElement.a(A_0);
				}
			}
		}

		// Token: 0x04002FDB RID: 12251
		private ArrayList a;

		// Token: 0x04002FDC RID: 12252
		private PieSeries b;

		// Token: 0x04002FDD RID: 12253
		private float c = 0f;

		// Token: 0x04002FDE RID: 12254
		private int d = 1;

		// Token: 0x04002FDF RID: 12255
		private float e;

		// Token: 0x04002FE0 RID: 12256
		private float f;
	}
}
