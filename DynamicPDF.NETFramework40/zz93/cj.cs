using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000073 RID: 115
	internal class cj
	{
		// Token: 0x060004B2 RID: 1202 RVA: 0x0004EB6C File Offset: 0x0004DB6C
		internal cj(AutoGradient A_0, AutoGradient A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0004EBDC File Offset: 0x0004DBDC
		internal void a(PageWriter A_0)
		{
			if (this.i)
			{
				if (this.a != null)
				{
					this.a.a();
					this.a.DrawFill(A_0);
					if (this.a == this.b)
					{
						this.b.DrawFill(A_0);
					}
					else if (this.b != null)
					{
						this.b.a();
						this.b.DrawStroke(A_0);
					}
				}
				else if (this.b != null)
				{
					this.b.a();
					this.b.DrawStroke(A_0);
				}
				this.i = false;
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0004ECA4 File Offset: 0x0004DCA4
		private void a(float A_0, float A_1)
		{
			if (A_0 > this.e)
			{
				this.e = A_0;
			}
			if (A_0 < this.f)
			{
				this.f = A_0;
			}
			if (A_1 > this.h)
			{
				this.h = A_1;
			}
			if (A_1 < this.g)
			{
				this.g = A_1;
			}
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0004ED0E File Offset: 0x0004DD0E
		internal void b(float A_0, float A_1)
		{
			this.a(A_0, A_1);
			this.c(A_0, A_1);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0004ED23 File Offset: 0x0004DD23
		internal void a()
		{
			this.e = float.MinValue;
			this.f = float.MaxValue;
			this.g = float.MaxValue;
			this.h = float.MinValue;
			this.i = true;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0004ED59 File Offset: 0x0004DD59
		internal void b(AutoGradient A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0004ED63 File Offset: 0x0004DD63
		internal void c(AutoGradient A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0004ED70 File Offset: 0x0004DD70
		internal cj b()
		{
			cj result;
			if (this.b == null)
			{
				result = null;
			}
			else
			{
				this.a = null;
				result = this;
			}
			return result;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0004EDA0 File Offset: 0x0004DDA0
		internal cj c()
		{
			cj result;
			if (this.a == null)
			{
				result = null;
			}
			else
			{
				this.b = null;
				result = this;
			}
			return result;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0004EDD0 File Offset: 0x0004DDD0
		internal void d()
		{
			if (this.a != null)
			{
				this.a(this.a);
			}
			this.a();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0004EE04 File Offset: 0x0004DE04
		internal void e()
		{
			if (this.b != null)
			{
				this.a(this.b);
			}
			this.a();
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0004EE38 File Offset: 0x0004DE38
		internal void f()
		{
			if (this.a != null)
			{
				this.a(this.a);
				if (this.b != null && this.a != this.b)
				{
					this.a(this.b);
				}
			}
			else if (this.b != null)
			{
				this.a(this.b);
			}
			this.a();
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0004EEB4 File Offset: 0x0004DEB4
		internal void c(float A_0, float A_1)
		{
			this.c = A_0;
			this.d = A_1;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0004EEC8 File Offset: 0x0004DEC8
		internal void a(float A_0, float A_1, float A_2, float A_3, float A_4, float A_5)
		{
			this.a(this.b(this.c, A_0, A_2, A_4), this.b(this.d, A_1, A_3, A_5));
			this.a(this.a(this.c, A_0, A_2, A_4), this.a(this.d, A_1, A_3, A_5));
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0004EF28 File Offset: 0x0004DF28
		private float b(float A_0, float A_1, float A_2, float A_3)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = float.MinValue;
			for (float num4 = 0f; num4 <= 1f; num4 += 0.05f)
			{
				float num5 = this.a(num4, A_0, A_1, A_2, A_3);
				if (num3 < num5)
				{
					num2 = num4;
					num3 = num5;
				}
			}
			if (num3 < A_3)
			{
				num3 = A_3;
				num2 = 1f;
			}
			float num6 = 0.025f;
			while (num < 8f)
			{
				float num7 = num2 - num6;
				float num8 = num2 + num6;
				if (num2 == 0f)
				{
					float num9 = this.a(num8, A_0, A_1, A_2, A_3);
					if (num3 < num9)
					{
						num3 = num9;
						num2 = num8;
					}
				}
				else if (num2 == 1f)
				{
					float num10 = this.a(num7, A_0, A_1, A_2, A_3);
					if (num3 < num10)
					{
						num3 = num10;
						num2 = num7;
					}
				}
				else if (num8 < 1f && num7 > 0f)
				{
					float num9 = this.a(num8, A_0, A_1, A_2, A_3);
					float num10 = this.a(num7, A_0, A_1, A_2, A_3);
					float num11 = Math.Max(num9, num10);
					if (num3 < num11)
					{
						num3 = num11;
						if (num11 == num9)
						{
							num2 = num8;
						}
						else if (num11 == num10)
						{
							num2 = num7;
						}
					}
				}
				num6 /= 2f;
				num += 1f;
			}
			return num3;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0004F0F0 File Offset: 0x0004E0F0
		private float a(float A_0, float A_1, float A_2, float A_3)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = float.MaxValue;
			for (float num4 = 0f; num4 <= 1f; num4 += 0.05f)
			{
				float num5 = this.a(num4, A_0, A_1, A_2, A_3);
				if (num3 > num5)
				{
					num2 = num4;
					num3 = num5;
				}
			}
			if (num3 > A_3)
			{
				num3 = A_3;
				num2 = 1f;
			}
			float num6 = 0.025f;
			while (num < 8f)
			{
				float num7 = num2 - num6;
				float num8 = num2 + num6;
				if (num2 == 0f)
				{
					float num9 = this.a(num8, A_0, A_1, A_2, A_3);
					if (num3 > num9)
					{
						num3 = num9;
						num2 = num8;
					}
				}
				else if (num2 == 1f)
				{
					float num10 = this.a(num7, A_0, A_1, A_2, A_3);
					if (num3 > num10)
					{
						num3 = num10;
						num2 = num7;
					}
				}
				else if (num8 < 1f && num7 > 0f)
				{
					float num9 = this.a(num8, A_0, A_1, A_2, A_3);
					float num10 = this.a(num7, A_0, A_1, A_2, A_3);
					float num11 = Math.Min(num9, num10);
					if (num3 > num11)
					{
						num3 = num11;
						if (num11 == num9)
						{
							num2 = num8;
						}
						else if (num11 == num10)
						{
							num2 = num7;
						}
					}
				}
				num6 /= 2f;
				num += 1f;
			}
			return num3;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0004F2B8 File Offset: 0x0004E2B8
		private float a(float A_0, float A_1, float A_2, float A_3, float A_4)
		{
			return (1f - A_0) * (1f - A_0) * (1f - A_0) * A_1 + 3f * A_0 * ((1f - A_0) * (1f - A_0)) * A_2 + 3f * (A_0 * A_0) * (1f - A_0) * A_3 + A_0 * A_0 * A_0 * A_4;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0004F31C File Offset: 0x0004E31C
		private void a(AutoGradient A_0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = (double)(this.e - this.f);
			double num6 = (double)(this.h - this.g);
			if (num5 == 0.0 || num6 == 0.0)
			{
				num = (double)this.f;
				num2 = (double)this.e;
				num3 = (double)this.g;
				num4 = (double)this.h;
				A_0.b().b((float)num, (float)num3, (float)num2, (float)num4);
			}
			else
			{
				float num7 = A_0.Angle;
				if (num7 < -360f || num7 > 360f)
				{
					num7 %= 360f;
				}
				if (num7 < 0f)
				{
					num7 += 360f;
				}
				double num8 = (double)this.f;
				double num9 = (double)this.g;
				double num10 = num8 + num5;
				double num11 = num9 + num6;
				double num12 = num8 + num5 / 2.0;
				double num13 = num9 + num6 / 2.0;
				double num14 = num6 / num5;
				double num15 = Math.Atan(num14) * 57.29577951308232;
				if (num7 > 0f && num7 < 90f)
				{
					double num16 = (double)num7 * 0.017453292519943295;
					if ((double)num7 > num15)
					{
						double num17 = Math.Abs(num6 / Math.Tan(num16)) / 2.0;
						num = num12 + num17;
						num3 = num9;
						num2 = num12 - num17;
						num4 = num11;
					}
					else
					{
						num = num10;
						double num17 = Math.Abs(num5 * Math.Tan(num16)) / 2.0;
						num3 = num13 - num17;
						num2 = num8;
						num4 = num13 + num17;
					}
				}
				if (num7 > 180f && num7 < 270f)
				{
					double num18 = (double)(num7 - 180f);
					double num16 = num18 * 0.017453292519943295;
					if (num18 > num15)
					{
						double num17 = Math.Abs(num6 / Math.Tan(num16)) / 2.0;
						num = num12 - num17;
						num3 = num11;
						num2 = num12 + num17;
						num4 = num9;
					}
					else
					{
						num = num8;
						double num17 = Math.Abs(num5 * Math.Tan(num16)) / 2.0;
						num3 = num13 + num17;
						num2 = num10;
						num4 = num13 - num17;
					}
				}
				if (num7 > 270f && num7 < 360f)
				{
					double num18 = (double)(360f - num7);
					double num16 = num18 * 0.017453292519943295;
					if (num18 > num15)
					{
						double num17 = Math.Abs(num6 / Math.Tan(num16)) / 2.0;
						num = num12 + num17;
						num3 = num11;
						num2 = num12 - num17;
						num4 = num9;
					}
					else
					{
						num = num10;
						double num17 = Math.Abs(num5 * Math.Tan(num16)) / 2.0;
						num3 = num13 + num17;
						num2 = num8;
						num4 = num13 - num17;
					}
				}
				if (num7 > 90f && num7 < 180f)
				{
					double num18 = (double)(180f - num7);
					double num16 = num18 * 0.017453292519943295;
					if (num18 > num15)
					{
						num3 = num9;
						double num17 = Math.Abs(num6 / Math.Tan(num16)) / 2.0;
						num4 = num11;
						num = num12 - num17;
						num2 = num12 + num17;
					}
					else
					{
						double num17 = Math.Abs(num5 * Math.Tan(num16)) / 2.0;
						num = num8;
						num3 = num13 - num17;
						num2 = num10;
						num4 = num13 + num17;
					}
				}
				if (num7 == 0f || num7 == 360f)
				{
					num = num10;
					num2 = num8;
					num3 = num13;
					num4 = num13;
				}
				else if (num7 == 90f)
				{
					num = num12;
					num2 = num12;
					num3 = num9;
					num4 = num11;
				}
				else if (num7 == 180f)
				{
					num = num8;
					num2 = num10;
					num3 = num11;
					num4 = num11;
				}
				else if (num7 == 270f)
				{
					num = num12;
					num2 = num12;
					num3 = num11;
					num4 = num9;
				}
				A_0.b().b((float)num, (float)num3, (float)num2, (float)num4);
			}
		}

		// Token: 0x040002C4 RID: 708
		private AutoGradient a;

		// Token: 0x040002C5 RID: 709
		private AutoGradient b;

		// Token: 0x040002C6 RID: 710
		private float c = 0f;

		// Token: 0x040002C7 RID: 711
		private float d = 0f;

		// Token: 0x040002C8 RID: 712
		private float e = float.MinValue;

		// Token: 0x040002C9 RID: 713
		private float f = float.MaxValue;

		// Token: 0x040002CA RID: 714
		private float g = float.MaxValue;

		// Token: 0x040002CB RID: 715
		private float h = float.MinValue;

		// Token: 0x040002CC RID: 716
		private bool i = false;
	}
}
