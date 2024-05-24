using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000285 RID: 645
	internal class qy
	{
		// Token: 0x06001CA5 RID: 7333 RVA: 0x00125954 File Offset: 0x00124954
		internal qy()
		{
			this.s = new Border(this);
			this.s.Width = new float?(1f);
			this.s.LineStyle = LineStyle.Solid;
			this.s.Color = Grayscale.Black;
			this.b.a(this);
			this.a.a(this);
			this.t = new CellDefault(this);
			this.t.Border.Width = new float?(1f);
			this.t.Border.Color = Grayscale.Black;
			this.t.Border.LineStyle = LineStyle.Solid;
			this.t.Padding.Value = new float?(2f);
			this.t.Align = new TextAlign?(TextAlign.Left);
			this.t.VAlign = new VAlign?(VAlign.Top);
			this.t.Font = Font.Helvetica;
			this.t.FontSize = new float?(12f);
			this.t.TextColor = Grayscale.Black;
			this.t.RightToLeft = new bool?(false);
			this.t.Underline = new bool?(false);
			this.t.Leading = null;
			this.t.AutoLeading = new bool?(true);
			this.t.ParagraphIndent = new float?(0f);
			this.t.ParagraphSpacing = new float?(0f);
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x00125C00 File Offset: 0x00124C00
		internal bool b()
		{
			return this.z;
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00125C18 File Offset: 0x00124C18
		internal Column2List c()
		{
			return this.a;
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x00125C30 File Offset: 0x00124C30
		internal Row2List d()
		{
			return this.b;
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x00125C48 File Offset: 0x00124C48
		internal Cell2[,] e()
		{
			return this.c;
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x00125C60 File Offset: 0x00124C60
		internal int f()
		{
			return this.d;
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x00125C78 File Offset: 0x00124C78
		internal void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x00125C84 File Offset: 0x00124C84
		internal int g()
		{
			return this.e;
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x00125C9C File Offset: 0x00124C9C
		internal int h()
		{
			return this.g;
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x00125CB4 File Offset: 0x00124CB4
		internal void c(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x00125CC0 File Offset: 0x00124CC0
		internal int i()
		{
			return this.h;
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x00125CD8 File Offset: 0x00124CD8
		internal bool j()
		{
			return this.j;
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x00125CF0 File Offset: 0x00124CF0
		internal void a(bool A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x00125CFC File Offset: 0x00124CFC
		internal bool k()
		{
			return this.k;
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x00125D14 File Offset: 0x00124D14
		internal void b(bool A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x00125D20 File Offset: 0x00124D20
		internal bool l()
		{
			return this.l;
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x00125D38 File Offset: 0x00124D38
		internal void c(bool A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x00125D44 File Offset: 0x00124D44
		internal bool m()
		{
			return this.m;
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x00125D5C File Offset: 0x00124D5C
		internal void d(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06001CB8 RID: 7352 RVA: 0x00125D66 File Offset: 0x00124D66
		internal void e(bool A_0)
		{
			this.p = A_0;
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x00125D70 File Offset: 0x00124D70
		internal void f(bool A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x00125D7C File Offset: 0x00124D7C
		internal Border n()
		{
			return this.s;
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x00125D94 File Offset: 0x00124D94
		internal float o()
		{
			return this.r;
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x00125DAC File Offset: 0x00124DAC
		internal void a(float A_0)
		{
			this.r = A_0;
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x00125DB8 File Offset: 0x00124DB8
		internal CellDefault p()
		{
			if (this.t == null)
			{
				this.t = new CellDefault(this);
			}
			return this.t;
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x00125DEC File Offset: 0x00124DEC
		internal bool q()
		{
			return this.u;
		}

		// Token: 0x06001CBF RID: 7359 RVA: 0x00125E04 File Offset: 0x00124E04
		internal void g(bool A_0)
		{
			this.u = A_0;
		}

		// Token: 0x06001CC0 RID: 7360 RVA: 0x00125E10 File Offset: 0x00124E10
		internal bool r()
		{
			return this.v;
		}

		// Token: 0x06001CC1 RID: 7361 RVA: 0x00125E28 File Offset: 0x00124E28
		internal void h(bool A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x00125E34 File Offset: 0x00124E34
		internal float s()
		{
			if (this.p)
			{
				if (this.n)
				{
					this.ab();
				}
				this.y();
			}
			return this.i;
		}

		// Token: 0x06001CC3 RID: 7363 RVA: 0x00125E78 File Offset: 0x00124E78
		internal float t()
		{
			if (this.q)
			{
				if (this.o)
				{
					this.aa();
				}
				this.z();
			}
			return this.f;
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x00125EBC File Offset: 0x00124EBC
		internal du[,] u()
		{
			return this.x;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x00125ED4 File Offset: 0x00124ED4
		internal void a(du[,] A_0)
		{
			this.x = A_0;
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x00125EE0 File Offset: 0x00124EE0
		internal bool v()
		{
			return this.y;
		}

		// Token: 0x06001CC7 RID: 7367 RVA: 0x00125EF8 File Offset: 0x00124EF8
		internal void i(bool A_0)
		{
			this.y = A_0;
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x00125F04 File Offset: 0x00124F04
		internal int? w()
		{
			return this.aa;
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x00125F1C File Offset: 0x00124F1C
		internal int? x()
		{
			return this.ab;
		}

		// Token: 0x06001CCA RID: 7370 RVA: 0x00125F34 File Offset: 0x00124F34
		internal void j(bool A_0)
		{
			this.ac = A_0;
		}

		// Token: 0x06001CCB RID: 7371 RVA: 0x00125F40 File Offset: 0x00124F40
		internal void y()
		{
			float num = 0f;
			int i;
			for (i = 0; i < this.g; i++)
			{
				if (i >= this.b.Count)
				{
					break;
				}
				num += this.d(i);
				i += this.b[i].a() - 1;
			}
			this.i = num;
			this.h = i;
			this.p = false;
		}

		// Token: 0x06001CCC RID: 7372 RVA: 0x00125FBC File Offset: 0x00124FBC
		internal void z()
		{
			float num = 0f;
			int i;
			for (i = 0; i < this.d; i++)
			{
				if (i >= this.a.Count)
				{
					break;
				}
				num += this.e(i);
				i += this.a[i].b() - 1;
			}
			this.f = num;
			this.e = i;
			this.q = false;
		}

		// Token: 0x06001CCD RID: 7373 RVA: 0x00126038 File Offset: 0x00125038
		internal void aa()
		{
			for (int i = 0; i < this.b.Count; i++)
			{
				Row2 row = this.b[i];
				row.a(1);
				int num = i;
				for (int j = i; j <= i; j++)
				{
					foreach (object obj in this.b[j].Cells)
					{
						Cell2 cell = (Cell2)obj;
						if (cell != null && cell.t() != -1)
						{
							int num2 = cell.RowSpan;
							if (j - 1 + num2 > this.b.Count - 1)
							{
								while (j - 1 + num2 > this.b.Count - 1)
								{
									num2--;
								}
							}
							if (j - num + num2 > row.a())
							{
								row.a(j - num + num2);
								if (num + row.a() - 1 > i)
								{
									i = num + row.a() - 1;
								}
							}
						}
					}
				}
				if (i > num)
				{
					int num3 = row.a() - 1;
					for (int j = num + 1; j <= i; j++)
					{
						this.b[j].a(num3--);
					}
				}
			}
			this.o = false;
		}

		// Token: 0x06001CCE RID: 7374 RVA: 0x0012620C File Offset: 0x0012520C
		internal void ab()
		{
			for (int i = 0; i <= this.a.Count - 1; i++)
			{
				Column2 column = this.a[i];
				column.a(1);
				int num = i;
				for (int j = i; j <= i; j++)
				{
					for (int k = 0; k < this.b.Count; k++)
					{
						Cell2 cell = this.c[j, k];
						if (cell != null && cell.t() != -1 && cell.t() == j && cell.u() == k)
						{
							int num2 = cell.ColumnSpan;
							if (j - 1 + num2 > this.a.Count - 1)
							{
								while (j - 1 + num2 > this.a.Count - 1)
								{
									num2--;
								}
							}
							if (j - num + num2 > column.b())
							{
								column.a(j - num + num2);
								if (column.b() - 1 > i)
								{
									i = column.b() - 1;
								}
							}
						}
					}
				}
				if (i > num)
				{
					int num3 = column.b() - 1;
					for (int j = num + 1; j <= i; j++)
					{
						this.a[j].a(num3--);
					}
				}
			}
			this.n = false;
		}

		// Token: 0x06001CCF RID: 7375 RVA: 0x001263C4 File Offset: 0x001253C4
		internal void ac()
		{
			int num = 0;
			this.c = new Cell2[this.a.Count, this.b.Count];
			foreach (object obj in this.b)
			{
				Row2 row = (Row2)obj;
				row.b(num++, this.c);
			}
			this.m = false;
			this.ae();
		}

		// Token: 0x06001CD0 RID: 7376 RVA: 0x0012646C File Offset: 0x0012546C
		internal void ad()
		{
			this.ae();
			int num = 0;
			foreach (object obj in this.b)
			{
				Row2 row = (Row2)obj;
				row.b();
			}
			foreach (object obj2 in this.b)
			{
				Row2 row = (Row2)obj2;
				row.b(num++);
			}
			this.l = false;
		}

		// Token: 0x06001CD1 RID: 7377 RVA: 0x00126544 File Offset: 0x00125544
		internal int a(int A_0, float A_1, Row2 A_2, int? A_3, ref int? A_4)
		{
			this.ae = A_1;
			int num;
			if (A_2 == null)
			{
				this.ad = false;
				if (this.m)
				{
					this.ac();
				}
				if (!this.ac)
				{
					this.f(A_0);
				}
				num = this.b(A_0, A_1, ref A_4);
				this.z = true;
			}
			else
			{
				if (!this.ac)
				{
					A_2.b(A_2.ActualRowHeight);
				}
				this.z = false;
				float num2 = 0f;
				num = this.a(A_2, A_1, A_3.Value, ref num2);
				bool flag = false;
				if (num > A_3)
				{
					if (this.g(this.b[num]))
					{
						int result = num;
						num = this.e(this.b[num]);
						if (num < 0)
						{
							return result;
						}
					}
				}
				else if (this.g(A_2))
				{
					if (A_2.Cells.Count > 0)
					{
						num = this.e(A_2);
					}
					else
					{
						num++;
					}
					if (num == this.b.Count)
					{
						this.y = false;
						return num - 1;
					}
				}
				if (!this.z)
				{
					if (!this.y && num2 < A_1)
					{
						this.z = true;
						if (num == this.b.Count)
						{
							this.z = false;
							return num - 1;
						}
						this.ad = true;
						if (A_2.Cells.Count > 0)
						{
							return this.a(num, A_1 - num2, ref A_4);
						}
						num = this.b(num, A_1, ref A_4);
						flag = true;
					}
					else
					{
						this.z = false;
					}
					this.ad = false;
				}
				else if (!this.y && num2 < A_1)
				{
					if (num == this.b.Count)
					{
						return num - 1;
					}
					this.ad = true;
					num = this.b(num, A_1 - num2, ref A_4);
					this.ad = false;
					flag = true;
				}
				if (this.z && !this.y && !flag)
				{
					return num - 1;
				}
			}
			int result2;
			if (num == this.b.Count)
			{
				this.y = false;
				result2 = num - 1;
			}
			else
			{
				result2 = num;
			}
			return result2;
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x00126818 File Offset: 0x00125818
		internal int a(Row2 A_0, float A_1, int A_2, ref float A_3)
		{
			this.ae = A_1;
			this.y = false;
			this.j = false;
			float num = 0f;
			float num2 = 0f;
			num += this.i;
			bool flag = true;
			int? num3 = this.b(A_0, A_2);
			int result;
			if (num3 == null)
			{
				num += A_0.g();
				if (num > A_1 + 0.001f)
				{
					this.y = true;
					int? num4 = null;
					if (this.a(A_0))
					{
						this.a(A_0, num - A_0.g(), A_1, true, A_2, ref flag);
					}
					else if (this.a(A_0, ref num4, ref num2))
					{
						A_0.b(num2);
						if (num2 == 0f)
						{
							this.a(num2, A_0, A_1 - this.i);
						}
						else
						{
							this.a(num2, A_0, A_1);
						}
					}
				}
				else
				{
					for (int i = 0; i < A_0.Cells.Count; i++)
					{
						if (A_0.Cells[i] != null)
						{
							A_0.Cells[i].c(true);
							if (A_0.Cells[i].o() != null)
							{
								A_0.Cells[i].d(A_0.Cells[i].o().Count);
							}
						}
					}
					A_3 = num;
				}
				result = A_2;
			}
			else
			{
				this.z = true;
				num += this.c(A_0, num3.Value);
				if (num > A_1 + 0.001f)
				{
					int? num5 = null;
					int num6 = this.a(A_0, A_2, A_1, this.i, ref num5);
					A_3 = num;
					result = num6;
				}
				else
				{
					A_3 = num;
					result = this.f(A_0);
				}
			}
			return result;
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x00126A20 File Offset: 0x00125A20
		internal int a(int A_0, float A_1, ref int? A_2)
		{
			this.y = false;
			this.j = false;
			float num = 0f;
			bool flag = true;
			int i = A_0;
			int num2 = 0;
			int? num3 = null;
			while (i < this.b.Count)
			{
				num += this.d(i);
				int result;
				if (num > A_1 + 0.001f)
				{
					if (this.a(this.b[i]))
					{
						if (this.b[i].a() > 1)
						{
							this.y = true;
							num3 = new int?(this.a(i, A_1, num - this.d(i), false, ref A_2));
							if (num3 != null)
							{
								result = num3.Value;
							}
							else
							{
								this.z = false;
								result = i;
							}
						}
						else
						{
							i = this.a(this.b[i], num - this.d(i), A_1, false, i, ref flag);
							if (!flag)
							{
								if (A_0 == i)
								{
									this.z = false;
								}
								result = i - 1;
							}
							else
							{
								this.y = true;
								num2++;
								result = i;
							}
						}
					}
					else
					{
						if (num2 == 0)
						{
							this.z = false;
						}
						result = i - 1;
					}
				}
				else
				{
					if (num != A_1)
					{
						num2++;
						i = i + this.b[i].a() - 1;
						i++;
						continue;
					}
					num2++;
					result = i + this.b[i].a() - 1;
				}
				return result;
			}
			if (i == A_0)
			{
				this.z = false;
			}
			return i - 1;
		}

		// Token: 0x06001CD4 RID: 7380 RVA: 0x00126BF8 File Offset: 0x00125BF8
		internal int b(int A_0, float A_1, ref int? A_2)
		{
			this.ae = A_1;
			this.y = false;
			this.z = true;
			this.aa = null;
			int? num = null;
			this.ab = null;
			if (this.m)
			{
				this.ac();
			}
			if (this.l)
			{
				this.ad();
			}
			this.j = false;
			float num2 = 0f;
			if (this.p)
			{
				if (this.n)
				{
					this.ab();
				}
				this.y();
			}
			if (!this.ad || this.g > 0)
			{
				num2 += this.i;
			}
			A_1 -= this.o() * 2f;
			float a_ = 0f;
			bool flag = true;
			int result;
			if (this.g > 0 && A_0 == 0)
			{
				int i = this.h;
				while (i < this.b.Count)
				{
					num2 += this.d(i);
					if (num2 > A_1 + 0.001f)
					{
						if (i != this.h)
						{
							if (this.b[i].a() > 1)
							{
								if (this.a(this.b[i]))
								{
									this.y = true;
									num = new int?(this.a(i, A_1, num2 - this.d(i), false, ref A_2));
									if (num != null)
									{
										return num.Value;
									}
								}
							}
							else if (this.a(this.b[i]))
							{
								i = this.a(this.b[i], num2 - this.d(i) - this.i, A_1 - this.i, false, i, ref flag);
								if (!flag)
								{
									return i - 1;
								}
								this.y = true;
								return i;
							}
							return i - 1;
						}
						if (this.b[i].a() > 1)
						{
							this.y = true;
							num = new int?(this.a(i, A_1, num2 - this.d(i), true, ref A_2));
							if (num != null)
							{
								return num.Value;
							}
						}
						if (this.a(this.b[i]))
						{
							i = this.a(this.b[i], num2 - this.d(i) - this.i, A_1 - this.i, true, i, ref flag);
							if (!flag)
							{
								return i - 1;
							}
							this.y = true;
							return i;
						}
						else
						{
							if (this.a(ref a_, i))
							{
								this.a(a_, this.b[i], A_1);
								if (!this.g(this.b[i]))
								{
									this.y = true;
								}
								else
								{
									this.y = false;
								}
								return this.a(this.b[i], i);
							}
							return i + this.b[i].a() - 1;
						}
					}
					else
					{
						if (num2 == A_1)
						{
							return i + this.b[i].a() - 1;
						}
						i = i + this.b[i].a() - 1;
						i++;
					}
				}
				result = i - 1;
			}
			else
			{
				int i = A_0;
				while (i < this.b.Count)
				{
					num2 += this.d(i);
					if (num2 > A_1 + 0.001f)
					{
						if (i == A_0 && !this.ad)
						{
							if (this.b[i].a() > 1)
							{
								this.y = true;
								num = new int?(this.a(i, A_1, num2 - this.d(i), true, ref A_2));
								if (num != null)
								{
									return num.Value;
								}
							}
							if (this.a(this.b[i]))
							{
								i = this.a(this.b[i], num2 - this.d(i), A_1, true, i, ref flag);
								this.y = true;
								return i;
							}
							if (this.a(ref a_, i))
							{
								this.a(a_, this.b[i], A_1);
								if (!this.g(this.b[i]))
								{
									this.y = true;
								}
								else
								{
									this.y = false;
								}
								return this.a(this.b[i], i);
							}
							return i + this.b[i].a() - 1;
						}
						else
						{
							if (this.a(this.b[i]))
							{
								if (this.b[i].a() > 1)
								{
									this.y = true;
									num = new int?(this.a(i, A_1, num2 - this.d(i), false, ref A_2));
									if (num != null)
									{
										return num.Value;
									}
								}
								else
								{
									i = this.a(this.b[i], num2 - this.d(i), A_1, false, i, ref flag);
									if (!flag)
									{
										return i - 1;
									}
									this.y = true;
									A_1 -= this.o();
									return i;
								}
							}
							if (this.ad)
							{
								return i;
							}
							return i - 1;
						}
					}
					else
					{
						if (num2 == A_1)
						{
							return i + this.b[i].a() - 1;
						}
						i = i + this.b[i].a() - 1;
						i++;
					}
				}
				result = i - 1;
			}
			return result;
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x001272AC File Offset: 0x001262AC
		internal float d(int A_0)
		{
			if (this.o)
			{
				this.aa();
			}
			float num = 0f;
			int num2 = this.b[A_0].a();
			for (int i = A_0; i < A_0 + num2; i++)
			{
				num += this.b[i].ActualRowHeight;
			}
			return num;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x00127318 File Offset: 0x00126318
		internal int a(int A_0, float A_1)
		{
			if (this.m)
			{
				this.ac();
			}
			if (this.l)
			{
				this.ad();
			}
			this.k = false;
			float num = 0f;
			if (this.q)
			{
				if (this.o)
				{
					this.aa();
				}
				this.z();
			}
			num += this.f;
			int result;
			if (this.d > 0 && A_0 == 0)
			{
				int i = this.e;
				while (i < this.a.Count)
				{
					num += this.e(i) + this.r;
					if (num > A_1 + 0.001f)
					{
						if (i == this.e)
						{
							return i + (this.a[i].b() - 1);
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
						{
							return i + this.a[i].b() - 1;
						}
						i = i + this.a[i].b() - 1;
						i++;
					}
				}
				result = i - 1;
			}
			else
			{
				int i = A_0;
				while (i < this.a.Count)
				{
					num += this.e(i) + this.r;
					if (num > A_1 + 0.001f)
					{
						if (i == A_0)
						{
							return i + (this.a[i].b() - 1);
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
						{
							return i + this.a[i].b() - 1;
						}
						i = i + this.a[i].b() - 1;
						i++;
					}
				}
				result = i - 1;
			}
			return result;
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x00127520 File Offset: 0x00126520
		internal float e(int A_0)
		{
			if (this.n)
			{
				this.ab();
			}
			float num = 0f;
			int num2 = this.a[A_0].b();
			for (int i = A_0; i < A_0 + num2; i++)
			{
				num += this.a[i].Width;
			}
			return num;
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x0012758C File Offset: 0x0012658C
		internal void ae()
		{
			if (this.x == null)
			{
				this.a();
				this.af();
				this.w = null;
			}
		}

		// Token: 0x06001CD9 RID: 7385 RVA: 0x001275C4 File Offset: 0x001265C4
		internal void af()
		{
			this.x = new du[this.a.Count, this.b.Count];
			for (int i = 0; i < this.c().Count; i++)
			{
				for (int j = 0; j < this.d().Count; j++)
				{
					if (this.c[i, j] != null)
					{
						if (this.c[i, j].n() == null && this.c[i, j].l() == null && this.c[i, j].m() == null && this.b[j].d() == null)
						{
							this.x[i, j] = this.w[i];
						}
						else
						{
							this.x[i, j] = new du();
							this.x[i, j].a(qy.a(this.w[i].a(), (this.b[j].d() == null) ? null : this.b[j].d().a(), this.c[i, j].n()));
							this.x[i, j].a(qy.a(this.w[i].c(), (this.b[j].d() == null) ? null : this.b[j].d().b(), this.c[i, j].m()));
							this.x[i, j].a(qy.a(this.w[i].b(), (this.b[j].d() == null) ? null : this.b[j].d().c(), this.c[i, j].l()));
						}
					}
				}
			}
		}

		// Token: 0x06001CDA RID: 7386 RVA: 0x00127810 File Offset: 0x00126810
		internal bool g(Row2 A_0)
		{
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].Splittable && !A_0.Cells[i].k())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001CDB RID: 7387 RVA: 0x00127870 File Offset: 0x00126870
		internal qy ag()
		{
			qy qy = new qy();
			for (int i = 0; i < this.a.Count; i++)
			{
				qy.a.a(this.a[i].a(qy));
			}
			for (int i = 0; i < this.b.Count; i++)
			{
				qy.b.a(this.b[i].a(qy));
			}
			qy.d = this.d;
			qy.e = this.e;
			qy.f = this.f;
			qy.g = this.g;
			qy.h = this.h;
			qy.i = this.i;
			qy.j = this.j;
			qy.k = this.k;
			qy.l = this.l;
			qy.m = this.m;
			qy.n = this.n;
			qy.o = this.o;
			qy.p = this.p;
			qy.q = this.q;
			qy.r = this.r;
			qy.s = this.s.a(qy);
			qy.t.a(this.t.a().m());
			qy.t.a(this.t.c().a(qy));
			qy.t.a(this.t.b().b(qy));
			qy.u = this.u;
			qy.v = this.v;
			qy.y = this.y;
			qy.z = this.z;
			qy.aa = this.aa;
			qy.ab = this.ab;
			qy.ac = this.ac;
			qy.ad = this.ad;
			qy.ae = this.ae;
			return qy;
		}

		// Token: 0x06001CDC RID: 7388 RVA: 0x00127A88 File Offset: 0x00126A88
		internal void f(int A_0)
		{
			this.ae();
			int num = A_0;
			for (int i = A_0; i < this.b.Count; i++)
			{
				this.b[i].b();
			}
			for (int i = A_0; i < this.b.Count; i++)
			{
				this.b[i].b(num++);
			}
			this.l = false;
		}

		// Token: 0x06001CDD RID: 7389 RVA: 0x00127B08 File Offset: 0x00126B08
		private int f(Row2 A_0)
		{
			int num = -1;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].u() + A_0.Cells[i].RowSpan - 1 > num)
				{
					num = A_0.Cells[i].RowSpan + A_0.Cells[i].u() - 1;
				}
			}
			return num;
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x00127B90 File Offset: 0x00126B90
		private int a(Row2 A_0, int A_1, float A_2, float A_3, ref int? A_4)
		{
			int num = A_1;
			float num2 = 0f;
			bool flag = false;
			float num3 = A_3 + A_0.g();
			if (num3 < A_2)
			{
				for (int i = A_1 + 1; i < A_1 + 1 + this.b[A_1 + 1].a(); i++)
				{
					if (num3 + this.b[i].ActualRowHeight > A_2)
					{
						break;
					}
					num3 += this.b[i].ActualRowHeight;
					num = i;
				}
			}
			else
			{
				num = A_1;
			}
			if (A_1 == num)
			{
				if (this.a(A_0))
				{
					A_1 = this.a(A_0, A_3, A_2, true, A_1, ref flag);
					this.y = true;
					this.z = false;
					return A_1;
				}
				if (this.a(A_0, ref this.aa, A_1, ref num2))
				{
					if (this.aa == null && num2 == 0f)
					{
						num2 = this.d(A_0);
					}
					A_0.b(num2);
					this.a(num2, A_0, A_2 - A_3);
					this.y = true;
					this.z = false;
					return A_1;
				}
				num = A_1 + 1;
			}
			int num4 = num;
			for (int i = A_1 + 1; i <= num; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 > num && !this.b[i].Cells[j].Splittable)
						{
							num = this.b[i].Cells[j].RowSpan + i - 1;
							if (num >= this.b.Count - 1)
							{
								num = this.b.Count - 1;
								i = num + 1;
								this.y = false;
								break;
							}
						}
					}
				}
			}
			int result;
			if (num4 == num || num < A_0.a())
			{
				for (int i = A_1 + 1; i <= num; i++)
				{
					for (int j = 0; j < this.b[i].Cells.Count; j++)
					{
						if (this.b[i].Cells[j].ColumnIndex != -1)
						{
							if (this.b[i].Cells[j].RowSpan + i - 1 > num && this.b[i].Cells[j].Splittable)
							{
								if (A_4 == null)
								{
									A_4 = new int?(i);
								}
								num2 = this.a(i, num);
								this.b[i].Cells[j].a(num2, A_2 - A_3, false);
								this.b[i].Cells[j].a(new float?(num2));
							}
						}
					}
				}
				if (num == A_1)
				{
					this.z = false;
				}
				result = num;
			}
			else
			{
				result = A_1 + this.b[A_1].a() - 1;
			}
			return result;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x00127FB8 File Offset: 0x00126FB8
		private float c(Row2 A_0, int A_1)
		{
			float num = 0f;
			num += A_0.g();
			int num2 = -1;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].u() > num2)
				{
					num2 = A_0.Cells[i].u();
				}
			}
			for (int i = num2; i < num2 + A_1; i++)
			{
				num += this.b[i].ActualRowHeight + this.r;
			}
			return num;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x0012805C File Offset: 0x0012705C
		private int? b(Row2 A_0, int A_1)
		{
			int num = 0;
			int num2 = A_1;
			Row2 row = A_0;
			for (int i = num2; i <= num2; i++)
			{
				int num3 = num2;
				for (int j = 0; j < row.Cells.Count; j++)
				{
					if (row.Cells[j].RowSpan > 1 && row.Cells[j].RowSpan + row.Cells[j].u() > num3)
					{
						int num4 = row.Cells[j].RowSpan + row.Cells[j].u() - 1 - num3;
						if (num < num4)
						{
							num = num4;
						}
						num2 = num3 + num;
					}
				}
				if (num2 >= this.b.Count)
				{
					num2 = this.b.Count - 1;
				}
				if (num2 > A_1)
				{
					row = this.b[num2];
				}
				if (i == num2)
				{
					break;
				}
			}
			int? result;
			if (num2 > A_1)
			{
				result = new int?(num2 - A_1);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x001281C8 File Offset: 0x001271C8
		private bool a(ref float A_0, int A_1)
		{
			float num = 0f;
			float num2 = 0f;
			A_0 = this.d(this.b[A_1]);
			this.b[A_1].b(A_0);
			for (int i = 0; i < this.b[A_1].Cells.Count; i++)
			{
				if (this.b[A_1].Cells[i].Splittable)
				{
					float num3 = this.b[A_1].Cells[i].d();
					if (num3 >= num)
					{
						num = num3;
					}
				}
				else
				{
					float num4 = this.b[A_1].Cells[i].d();
					if (num4 >= num2)
					{
						num2 = num4;
					}
				}
			}
			bool result;
			if (num2 >= num)
			{
				A_0 = num2;
				this.b[A_1].b(A_0);
				result = false;
			}
			else if (num > num2)
			{
				if (num2 >= this.ae)
				{
					A_0 = num2;
					this.b[A_1].b(A_0);
					result = true;
				}
				else
				{
					A_0 = this.ae;
					this.b[A_1].b(A_0);
					result = true;
				}
			}
			else
			{
				A_0 = 0f;
				if (A_0 == 0f)
				{
					result = true;
				}
				else
				{
					for (int i = 0; i < this.b[A_1].Cells.Count; i++)
					{
						if (this.b[A_1].Cells[i].Splittable)
						{
							if (A_0 <= this.b[A_1].Cells[i].d())
							{
								return true;
							}
						}
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x00128404 File Offset: 0x00127404
		private int a(int A_0, float A_1, float A_2, bool A_3, ref int? A_4)
		{
			float num = A_2;
			int? num2 = null;
			int num3 = A_0;
			for (int i = A_0; i < A_0 + this.b[A_0].a(); i++)
			{
				if (num + this.b[i].ActualRowHeight > A_1)
				{
					break;
				}
				num += this.b[i].ActualRowHeight;
				num3 = i + 1;
			}
			if (A_0 == num3)
			{
				num2 = this.a(A_0, A_1, A_2, A_3);
				if (num2 != null)
				{
					return num2.Value;
				}
			}
			int num4 = num3;
			if (this.d(num3, A_0))
			{
				if (this.b[num4].Cells.Count != 0)
				{
					return this.c(A_0, num3, ref A_4, A_1 - A_2);
				}
				num2 = this.a(A_0, num4, A_1 - A_2, ref A_4);
				if (num2 != null)
				{
					return num2.Value;
				}
			}
			else
			{
				if (num4 > A_0)
				{
					num4--;
				}
				if (this.b[num4].Cells.Count == 0)
				{
					num2 = this.a(A_0, num4, A_1 - A_2, ref A_4);
					if (num2 != null)
					{
						return num2.Value;
					}
				}
				else
				{
					num2 = this.a(A_0, A_1, A_2, num4, ref A_4);
					if (num2 != null)
					{
						return num2.Value;
					}
				}
			}
			num3 = this.e(A_0, num3);
			num4 = num3;
			if (num3 < A_0 + this.b[A_0].a() - 1)
			{
				if (this.b[num4].Cells.Count == 0)
				{
					num2 = this.a(A_0, num4, A_1 - A_2, ref A_4);
					if (num2 != null)
					{
						return num2.Value;
					}
				}
				else
				{
					num2 = this.a(A_0, A_1 - A_2, num4, ref A_4);
					if (num2 != null)
					{
						return num2.Value;
					}
				}
			}
			return A_0 + this.b[A_0].a() - 1;
		}

		// Token: 0x06001CE3 RID: 7395 RVA: 0x0012869C File Offset: 0x0012769C
		private int? a(int A_0, int A_1, float A_2, ref int? A_3)
		{
			int? a_ = null;
			while (A_1 >= A_0)
			{
				a_ = this.a(A_0, A_1, ref A_3, A_2);
				if (a_ != null)
				{
					this.y = true;
					a_ = new int?(this.a(a_, A_1));
					return new int?(a_.Value);
				}
				A_1--;
			}
			return null;
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x00128714 File Offset: 0x00127714
		private int e(int A_0, int A_1)
		{
			for (int i = A_0; i <= A_1; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 >= A_1 && !this.b[i].Cells[j].Splittable)
						{
							A_1 = this.b[i].Cells[j].RowSpan + i - 1;
							if (A_1 >= this.b.Count - 1)
							{
								A_1 = this.b.Count - 1;
								i = A_1 + 1;
								this.y = false;
								break;
							}
						}
					}
				}
			}
			return A_1;
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x00128834 File Offset: 0x00127834
		private int? a(int A_0, float A_1, int A_2, ref int? A_3)
		{
			int? num = null;
			while (A_2 >= A_0)
			{
				num = this.b(A_0, A_2, ref A_3, A_1);
				if (num != null)
				{
					this.y = true;
					num = new int?(this.a(num, A_2));
					if (num > A_0)
					{
						for (int num2 = A_0; num2 < num; num2++)
						{
							this.b[num2].a(false);
						}
					}
					return new int?(num.Value);
				}
				A_2--;
			}
			return null;
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x00128918 File Offset: 0x00127918
		private int? a(int A_0, float A_1, float A_2, int A_3, ref int? A_4)
		{
			int? num = null;
			while (A_3 >= A_0)
			{
				if (this.c(A_3, A_0))
				{
					num = this.b(A_0, A_3, ref A_4, A_1 - A_2);
					if (num != null)
					{
						this.y = true;
						num = new int?(this.a(num, A_3));
						if (num > A_0)
						{
							for (int num2 = A_0; num2 < num; num2++)
							{
								this.b[num2].a(false);
							}
						}
						return new int?(num.Value);
					}
				}
				A_3--;
			}
			return null;
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x00128A18 File Offset: 0x00127A18
		private int? a(int A_0, float A_1, float A_2, bool A_3)
		{
			float num = 0f;
			bool flag = false;
			int? result;
			if (this.a(this.b[A_0]))
			{
				A_0 = this.a(this.b[A_0], A_2, A_1, A_3, A_0, ref flag);
				if (!flag)
				{
					if (!A_3)
					{
						result = new int?(A_0 - 1);
					}
					else
					{
						result = null;
					}
				}
				else
				{
					this.y = true;
					result = new int?(A_0);
				}
			}
			else if (this.a(this.b[A_0], ref this.aa, A_0, ref num))
			{
				if (this.aa == null && num == 0f)
				{
					num = this.d(this.b[A_0]);
				}
				this.b[A_0].b(num);
				this.a(num, this.b[A_0], A_1 - A_2);
				this.y = true;
				result = new int?(this.a(this.b[A_0], A_0));
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x00128B54 File Offset: 0x00127B54
		private bool d(int A_0, int A_1)
		{
			for (int i = A_1; i < A_0; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 >= A_0 && !this.b[i].Cells[j].Splittable)
						{
							return false;
						}
					}
				}
			}
			for (int j = 0; j < this.b[A_0].Cells.Count; j++)
			{
				if (this.b[A_0].Cells[j].ColumnIndex != -1)
				{
					if (this.b[A_0].Cells[j].RowSpan + A_0 - 1 >= A_0 && !this.b[A_0].Cells[j].Splittable)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x00128CB8 File Offset: 0x00127CB8
		private bool c(int A_0, int A_1)
		{
			for (int i = A_1; i < A_0; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 >= A_0 && !this.b[i].Cells[j].Splittable)
						{
							return false;
						}
					}
				}
			}
			for (int j = 0; j < this.b[A_0].Cells.Count; j++)
			{
				if (this.b[A_0].Cells[j].ColumnIndex != -1)
				{
					if (this.b[A_0].Cells[j].RowSpan + A_0 - 1 > A_0 && !this.b[A_0].Cells[j].Splittable)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x00128E1C File Offset: 0x00127E1C
		private int a(int? A_0, int A_1)
		{
			int num = A_0.Value;
			for (int i = 0; i < this.b[A_0.Value].Cells.Count; i++)
			{
				float num2 = this.b[A_0.Value].g();
				if (this.b[A_0.Value].Cells[i].e() && this.b[A_0.Value].Cells[i].RowSpan + this.b[A_0.Value].Cells[i].u() - 1 > A_0.Value && num2 > this.b[A_0.Value].ActualRowHeight)
				{
					num2 -= this.b[A_0.Value].ActualRowHeight;
					for (int j = A_0.Value; j <= A_1; j++)
					{
						if (num2 < this.b[j].ActualRowHeight || this.a(j))
						{
							i = this.b[A_0.Value].Cells.Count;
							break;
						}
						num2 -= this.b[j].ActualRowHeight;
						this.b[j].b(this.b[i].ActualRowHeight);
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00128FE8 File Offset: 0x00127FE8
		private bool a(int A_0)
		{
			for (int i = 0; i < this.b[A_0].Cells.Count; i++)
			{
				if (this.b[A_0].Cells[i].RowSpan > 1)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x0012904C File Offset: 0x0012804C
		private int c(int A_0, int A_1, ref int? A_2, float A_3)
		{
			float num = 0f;
			bool flag = false;
			for (int i = A_0; i < A_1; i++)
			{
				num += this.b[A_0].ActualRowHeight + this.r;
			}
			num -= this.r;
			this.a(this.b[A_1], num, A_3, false, A_1, ref flag);
			this.y = true;
			int? num2 = null;
			for (int i = A_0; i < A_1; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 >= A_1 && this.b[i].Cells[j].Splittable)
						{
							if (A_2 == null)
							{
								A_2 = new int?(i);
							}
							float a_;
							if (!flag)
							{
								a_ = this.b(i, A_1 - 1);
							}
							else
							{
								a_ = this.b(i, A_1);
							}
							this.b[i].Cells[j].a(a_, A_3, false);
							if (num2 == null || num2 < i)
							{
								num2 = new int?(i);
							}
						}
					}
				}
			}
			int result;
			if (!flag)
			{
				result = A_1 - 1;
			}
			else
			{
				result = A_1;
			}
			return result;
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x0012923C File Offset: 0x0012823C
		private float b(int A_0, int A_1)
		{
			float num = 0f;
			for (int i = A_0; i < A_1; i++)
			{
				num += this.b[i].f();
			}
			return num + this.b[A_1].g();
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x00129290 File Offset: 0x00128290
		private int? b(int A_0, int A_1, ref int? A_2, float A_3)
		{
			int? num = null;
			for (int i = A_0; i <= A_1; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 >= A_1 && this.b[i].Cells[j].Splittable)
						{
							if (A_2 == null)
							{
								A_2 = new int?(i);
							}
							float a_ = this.a(i, A_1);
							this.b[i].Cells[j].a(a_, A_3, false);
							if (num == null || num < i)
							{
								num = new int?(i);
							}
						}
					}
				}
			}
			return new int?(A_1);
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x001293FC File Offset: 0x001283FC
		private int? a(int A_0, int A_1, ref int? A_2, float A_3)
		{
			int? num = null;
			for (int i = A_0; i <= A_1; i++)
			{
				for (int j = 0; j < this.b[i].Cells.Count; j++)
				{
					if (this.b[i].Cells[j].ColumnIndex != -1)
					{
						if (this.b[i].Cells[j].RowSpan + i - 1 > A_1 && this.b[i].Cells[j].Splittable)
						{
							if (A_2 == null)
							{
								A_2 = new int?(i);
							}
							float a_ = this.a(i, A_1);
							this.b[i].Cells[j].a(a_, A_3, false);
							if (num == null || num < i)
							{
								num = new int?(i);
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x00129560 File Offset: 0x00128560
		private float a(int A_0, int A_1)
		{
			float num = 0f;
			for (int i = A_0; i <= A_1; i++)
			{
				num += this.b[i].f();
			}
			return num;
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x001295A4 File Offset: 0x001285A4
		private int a(Row2 A_0, int A_1)
		{
			int num = int.MaxValue;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (!A_0.Cells[i].Splittable)
				{
					if (num > A_0.Cells[i].RowSpan)
					{
						num = A_0.Cells[i].RowSpan;
					}
				}
			}
			return A_1 + num - 1;
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x00129624 File Offset: 0x00128624
		private int e(Row2 A_0)
		{
			int num = int.MinValue;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (num < A_0.Cells[i].u())
				{
					num = A_0.Cells[i].u();
				}
			}
			int result;
			if (num >= 0)
			{
				result = num + 1;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x00129694 File Offset: 0x00128694
		private float d(Row2 A_0)
		{
			float num = 0f;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].ColumnIndex != -1)
				{
					if ((!A_0.Cells[i].Splittable && A_0.Cells[i].Text != null) || A_0.Cells[i].Element != null)
					{
						float num2 = A_0.Cells[i].d();
						if (num < num2)
						{
							num = num2;
						}
					}
				}
				if ((A_0.Cells[i].Text == null && A_0.Cells[i].Element == null) || A_0.Cells[i].ColumnIndex == -1)
				{
					A_0.Cells[i].c(true);
				}
			}
			return num;
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x001297B4 File Offset: 0x001287B4
		private int c(Row2 A_0)
		{
			int num = 1;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (!A_0.Cells[i].Splittable && A_0.Cells[i].RowSpan > num)
				{
					num = A_0.Cells[i].RowSpan;
				}
			}
			return num;
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x0012982C File Offset: 0x0012882C
		private bool a(Row2 A_0, ref int? A_1, int A_2, ref float A_3)
		{
			bool flag = false;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].Splittable)
				{
					flag = true;
					break;
				}
			}
			bool result;
			if (!flag)
			{
				result = flag;
			}
			else if (!this.b(A_0))
			{
				result = false;
			}
			else
			{
				bool flag2 = false;
				if (this.a(A_0, ref A_1, ref A_3))
				{
					result = true;
				}
				else
				{
					for (int i = 0; i < A_0.Cells.Count; i++)
					{
						float num = 0f;
						if (A_0.Cells[i].Splittable)
						{
							if (!flag2)
							{
								if (A_0.Cells[i].RowSpan == A_1 || (A_0.Cells[i].RowSpan > A_1 && A_1 > 1))
								{
									this.ab = new int?(A_0.Cells[i].RowSpan);
									int num2 = A_2;
									for (;;)
									{
										int num3 = num2;
										if (!(num3 < A_2 + A_1))
										{
											break;
										}
										this.b[num2].b();
										num2++;
									}
									A_0.c(A_2);
									num2 = A_2;
									for (;;)
									{
										int num3 = num2;
										if (!(num3 < A_2 + A_1))
										{
											break;
										}
										num += this.b[num2].g() + this.r;
										num2++;
									}
									num -= this.r;
									if (A_0.Cells[i].d() > num)
									{
										A_3 = num;
										return true;
									}
								}
							}
						}
					}
					if (!flag2)
					{
						result = flag2;
					}
					else
					{
						A_3 = 0f;
						int i = A_2;
						for (;;)
						{
							int num3 = i;
							if (!(num3 < A_2 + A_1))
							{
								break;
							}
							A_3 += this.b[i].g();
							i++;
						}
						for (i = 0; i < A_0.Cells.Count; i++)
						{
							if (A_0.Cells[i].Splittable)
							{
								if (A_0.Cells[i].RowSpan == A_1 && A_0.Cells[i].d() > A_3)
								{
									return true;
								}
								if (A_0.Cells[i].d() > A_3)
								{
									return true;
								}
							}
						}
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x00129C4C File Offset: 0x00128C4C
		private bool b(Row2 A_0)
		{
			int num = 0;
			int i;
			for (i = 0; i < A_0.Cells.Count; i++)
			{
				if (!A_0.Cells[i].Splittable && num < A_0.Cells[i].RowSpan)
				{
					num = A_0.Cells[i].RowSpan;
				}
			}
			bool result = false;
			i = 0;
			while (i < A_0.Cells.Count)
			{
				if (A_0.Cells[i].Splittable)
				{
					if (A_0.Cells[i].RowSpan > num)
					{
						return true;
					}
					if (A_0.Cells[i].RowSpan == num)
					{
						result = true;
						break;
					}
					if (A_0.Cells[i].RowSpan < num)
					{
					}
				}
				IL_F0:
				i++;
				continue;
				goto IL_F0;
			}
			return result;
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x00129D6C File Offset: 0x00128D6C
		private bool a(Row2 A_0, ref int? A_1, ref float A_2)
		{
			A_1 = new int?(0);
			float num = 0f;
			float num2 = 0f;
			A_2 = this.d(A_0);
			A_0.b(A_2);
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].Splittable)
				{
					float num3 = A_0.Cells[i].d();
					if (num3 >= num)
					{
						num = num3;
					}
				}
				else
				{
					float num4 = A_0.Cells[i].d();
					if (num4 >= num2)
					{
						num2 = num4;
					}
				}
			}
			bool result;
			if (num2 >= num)
			{
				A_2 = num2;
				A_0.b(A_2);
				result = false;
			}
			else if (num > num2)
			{
				if (num2 >= this.ae)
				{
					A_2 = num2;
					A_0.b(A_2);
					result = true;
				}
				else
				{
					A_2 = this.ae;
					A_0.b(A_2);
					result = true;
				}
			}
			else
			{
				A_2 = 0f;
				if (A_2 == 0f)
				{
					result = true;
				}
				else
				{
					int i = 0;
					while (i < A_0.Cells.Count)
					{
						if (A_0.Cells[i].Splittable)
						{
							if (!(A_0.Cells[i].RowSpan < A_1))
							{
								if (A_0.Cells[i].RowSpan == A_1)
								{
									if (A_1 == 1)
									{
										if (A_2 <= A_0.Cells[i].d())
										{
											return true;
										}
									}
								}
								else if (A_0.Cells[i].RowSpan > A_1 && A_1 == 1)
								{
									return true;
								}
							}
						}
						IL_2A2:
						i++;
						continue;
						goto IL_2A2;
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x0012A040 File Offset: 0x00129040
		private bool a(Row2 A_0)
		{
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (!A_0.Cells[i].Splittable)
				{
					return false;
				}
			}
			return A_0.Cells.Count != 0;
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x0012A0A4 File Offset: 0x001290A4
		private void a(float A_0, Row2 A_1, float A_2)
		{
			bool a_ = true;
			for (int i = 0; i < A_1.Cells.Count; i++)
			{
				if (A_1.Cells[i].ColumnIndex != -1)
				{
					if (A_1.Cells[i].Splittable)
					{
						if (A_1.Cells[i].o() != null)
						{
							A_1.Cells[i].a(A_0, A_2, a_);
							A_1.Cells[i].b(true);
							if (A_1.Cells[i].j() != A_1.Cells[i].o().Count)
							{
								A_1.Cells[i].c(false);
							}
							a_ = false;
						}
						else if (A_1.Cells[i].Element != null)
						{
							float num = A_1.Cells[i].d();
							A_1.Cells[i].b(true);
							if (A_1.g() < num)
							{
								A_1.b(num);
							}
							else
							{
								A_1.Cells[i].c(true);
							}
						}
					}
					if (A_1.Cells[i].Element == null && A_1.Cells[i].o() == null)
					{
						A_1.Cells[i].c(true);
					}
				}
				else
				{
					A_1.Cells[i].c(true);
				}
			}
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x0012A264 File Offset: 0x00129264
		private int a(Row2 A_0, float A_1, float A_2, bool A_3, int A_4, ref bool A_5)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].ColumnIndex != -1)
				{
					if (A_0.Cells[i].Text != null)
					{
						num2 = A_0.Cells[i].a(A_1, A_2, A_3, ref A_5);
						if (!A_5)
						{
							return A_4;
						}
						A_0.Cells[i].b(true);
						if (A_0.Cells[i].j() != A_0.Cells[i].o().Count)
						{
							A_0.Cells[i].c(false);
						}
					}
					else if (A_0.Cells[i].Element != null)
					{
						num2 = A_0.Cells[i].d();
						A_0.Cells[i].b(true);
						A_0.Cells[i].c(true);
					}
					if (num < num2)
					{
						num = num2;
					}
					if (A_0.Cells[i].Text == null && A_0.Cells[i].Element == null)
					{
						A_0.Cells[i].c(true);
					}
				}
				else
				{
					A_0.Cells[i].c(true);
				}
			}
			bool a_ = true;
			if (A_3 || num != 0f)
			{
				for (int i = 0; i < A_0.Cells.Count; i++)
				{
					if (A_0.Cells[i].ColumnIndex != -1)
					{
						if (A_0.Cells[i].Text != null && A_0.Cells[i].h() < num)
						{
							A_0.Cells[i].c(0);
							A_0.Cells[i].a(num, A_2, a_);
							a_ = false;
						}
					}
				}
				A_0.b(num);
				return A_4;
			}
			return A_4;
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x0012A4F4 File Offset: 0x001294F4
		private void a()
		{
			du du = new du();
			du.a(this.t.a().a(true));
			du.a(this.t.Border.a(true));
			du.a(this.t.Padding.a(true));
			this.w = new du[this.c().Count];
			for (int i = 0; i < this.c().Count; i++)
			{
				if (this.c()[i].a() == null)
				{
					this.w[i] = du;
				}
				else
				{
					this.w[i] = new du();
					this.w[i].a(qy.a(this.a[i].a().a(), du.a()));
					this.w[i].a(this.a(this.a[i].a().b(), du.c()));
					this.w[i].a(this.a(this.a[i].a().c(), du.b()));
				}
			}
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x0012A654 File Offset: 0x00129654
		private Border a(Border A_0, Border A_1)
		{
			Border result;
			if (A_0 == null)
			{
				result = A_1;
			}
			else
			{
				result = new Border(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x0012A680 File Offset: 0x00129680
		private CellPadding a(CellPadding A_0, CellPadding A_1)
		{
			CellPadding result;
			if (A_0 == null)
			{
				result = A_1;
			}
			else
			{
				result = new CellPadding(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06001CFE RID: 7422 RVA: 0x0012A6B0 File Offset: 0x001296B0
		private static q1 a(q1 A_0, q1 A_1)
		{
			q1 result;
			if (A_0 == null)
			{
				result = A_1;
			}
			else
			{
				result = new q1(A_0, A_1);
			}
			return result;
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x0012A6DC File Offset: 0x001296DC
		private static Border a(Border A_0, Border A_1, Border A_2)
		{
			Border result;
			if (A_2 == null && A_1 == null)
			{
				result = A_0;
			}
			else if (A_2 == null)
			{
				result = new Border(A_1, A_0);
			}
			else if (A_1 == null)
			{
				result = new Border(A_2, A_0);
			}
			else
			{
				Border border = new Border(A_2, A_1);
				border.a(A_0);
				result = border;
			}
			return result;
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x0012A744 File Offset: 0x00129744
		private static CellPadding a(CellPadding A_0, CellPadding A_1, CellPadding A_2)
		{
			CellPadding result;
			if (A_2 == null && A_1 == null)
			{
				result = A_0;
			}
			else if (A_2 == null)
			{
				result = new CellPadding(A_1, A_0);
			}
			else if (A_1 == null)
			{
				result = new CellPadding(A_2, A_0);
			}
			else
			{
				CellPadding cellPadding = new CellPadding(A_2, A_1);
				cellPadding.a(A_0);
				result = cellPadding;
			}
			return result;
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x0012A7BC File Offset: 0x001297BC
		private static q1 a(q1 A_0, q1 A_1, q1 A_2)
		{
			q1 result;
			if (A_2 == null && A_1 == null)
			{
				result = A_0;
			}
			else if (A_2 == null)
			{
				result = new q1(A_1, A_0);
			}
			else if (A_1 == null)
			{
				result = new q1(A_2, A_0);
			}
			else
			{
				q1 q = new q1(A_2, A_1);
				q.a(A_0);
				result = q;
			}
			return result;
		}

		// Token: 0x04000CF3 RID: 3315
		private Column2List a = new Column2List();

		// Token: 0x04000CF4 RID: 3316
		private Row2List b = new Row2List();

		// Token: 0x04000CF5 RID: 3317
		private Cell2[,] c = null;

		// Token: 0x04000CF6 RID: 3318
		private int d = 0;

		// Token: 0x04000CF7 RID: 3319
		private int e = 0;

		// Token: 0x04000CF8 RID: 3320
		private float f = 0f;

		// Token: 0x04000CF9 RID: 3321
		private int g = 0;

		// Token: 0x04000CFA RID: 3322
		private int h = 0;

		// Token: 0x04000CFB RID: 3323
		private float i = 0f;

		// Token: 0x04000CFC RID: 3324
		private bool j = true;

		// Token: 0x04000CFD RID: 3325
		private bool k = true;

		// Token: 0x04000CFE RID: 3326
		private bool l = true;

		// Token: 0x04000CFF RID: 3327
		private bool m = true;

		// Token: 0x04000D00 RID: 3328
		private bool n = true;

		// Token: 0x04000D01 RID: 3329
		private bool o = true;

		// Token: 0x04000D02 RID: 3330
		private bool p = true;

		// Token: 0x04000D03 RID: 3331
		private bool q = true;

		// Token: 0x04000D04 RID: 3332
		private float r = 0f;

		// Token: 0x04000D05 RID: 3333
		private Border s;

		// Token: 0x04000D06 RID: 3334
		private CellDefault t = null;

		// Token: 0x04000D07 RID: 3335
		private bool u = true;

		// Token: 0x04000D08 RID: 3336
		private bool v = true;

		// Token: 0x04000D09 RID: 3337
		private du[] w = null;

		// Token: 0x04000D0A RID: 3338
		private du[,] x = null;

		// Token: 0x04000D0B RID: 3339
		private bool y = false;

		// Token: 0x04000D0C RID: 3340
		private bool z = true;

		// Token: 0x04000D0D RID: 3341
		private int? aa = null;

		// Token: 0x04000D0E RID: 3342
		private int? ab = null;

		// Token: 0x04000D0F RID: 3343
		private bool ac = true;

		// Token: 0x04000D10 RID: 3344
		private bool ad = false;

		// Token: 0x04000D11 RID: 3345
		private float ae = 0f;
	}
}
