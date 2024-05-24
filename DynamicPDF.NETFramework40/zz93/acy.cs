using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000456 RID: 1110
	internal class acy
	{
		// Token: 0x06002DCC RID: 11724 RVA: 0x0019F90C File Offset: 0x0019E90C
		internal acy()
		{
			this.b.a(this);
			this.a.a(this);
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x0019FA28 File Offset: 0x0019EA28
		internal float a()
		{
			if (this.y)
			{
				if (this.w)
				{
					this.f();
				}
				this.c();
			}
			return this.p;
		}

		// Token: 0x06002DCE RID: 11726 RVA: 0x0019FA6C File Offset: 0x0019EA6C
		internal float b()
		{
			if (this.z)
			{
				if (this.x)
				{
					this.e();
				}
				this.d();
			}
			return this.m;
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x0019FAB0 File Offset: 0x0019EAB0
		internal void c()
		{
			float num = 0f;
			int i;
			for (i = 0; i < this.n; i++)
			{
				if (i >= this.b.Count)
				{
					break;
				}
				num += this.a(i);
				i += this.b[i].a() - 1;
			}
			this.p = num;
			this.o = i;
			this.y = false;
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x0019FB2C File Offset: 0x0019EB2C
		internal void d()
		{
			float num = 0f;
			int i;
			for (i = 0; i < this.k; i++)
			{
				if (i >= this.a.Count)
				{
					break;
				}
				num += this.b(i);
				i += this.a[i].a() - 1;
			}
			this.m = num;
			this.l = i;
			this.z = false;
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x0019FBA8 File Offset: 0x0019EBA8
		internal void e()
		{
			for (int i = 0; i < this.b.Count; i++)
			{
				Row row = this.b[i];
				row.a(1);
				int num = i;
				for (int j = i; j <= i; j++)
				{
					foreach (object obj in this.b[j].Cells)
					{
						Cell cell = (Cell)obj;
						if (cell != null && cell.k() != -1)
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
			this.x = false;
		}

		// Token: 0x06002DD2 RID: 11730 RVA: 0x0019FD7C File Offset: 0x0019ED7C
		internal void f()
		{
			for (int i = 0; i <= this.a.Count - 1; i++)
			{
				Column column = this.a[i];
				column.a(1);
				int num = i;
				for (int j = i; j <= i; j++)
				{
					for (int k = 0; k < this.b.Count; k++)
					{
						Cell cell = this.c[j, k];
						if (cell != null && cell.k() != -1 && cell.k() == j && cell.l() == k)
						{
							int num2 = cell.ColumnSpan;
							if (j - 1 + num2 > this.a.Count - 1)
							{
								while (j - 1 + num2 > this.a.Count - 1)
								{
									num2--;
								}
							}
							if (j - num + num2 > column.a())
							{
								column.a(j - num + num2);
								if (column.a() - 1 > i)
								{
									i = column.a() - 1;
								}
							}
						}
					}
				}
				if (i > num)
				{
					int num3 = column.a() - 1;
					for (int j = num + 1; j <= i; j++)
					{
						this.a[j].a(num3--);
					}
				}
			}
			this.w = false;
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x0019FF34 File Offset: 0x0019EF34
		internal void g()
		{
			int num = 0;
			this.c = new Cell[this.a.Count, this.b.Count];
			foreach (object obj in this.b)
			{
				Row row = (Row)obj;
				row.b(num++, this.c);
			}
			this.v = false;
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x0019FFD4 File Offset: 0x0019EFD4
		internal void h()
		{
			int num = 0;
			foreach (object obj in this.b)
			{
				Row row = (Row)obj;
				row.b();
			}
			foreach (object obj2 in this.b)
			{
				Row row = (Row)obj2;
				row.b(num++);
			}
			this.u = false;
		}

		// Token: 0x06002DD5 RID: 11733 RVA: 0x001A00A4 File Offset: 0x0019F0A4
		internal int a(int A_0, float A_1)
		{
			if (this.v)
			{
				this.g();
			}
			if (this.u)
			{
				this.h();
			}
			this.s = false;
			float num = 0f;
			if (this.y)
			{
				if (this.w)
				{
					this.f();
				}
				this.c();
			}
			num += this.p;
			int result;
			if (this.n > 0 && A_0 == 0)
			{
				int i = this.o;
				while (i < this.b.Count)
				{
					num += this.a(i);
					if (num > A_1 + 0.001f)
					{
						if (i == this.o)
						{
							return i + this.b[i].a() - 1;
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
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
					num += this.a(i);
					if (num > A_1 + 0.001f)
					{
						if (i == A_0)
						{
							return i + this.b[i].a() - 1;
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
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

		// Token: 0x06002DD6 RID: 11734 RVA: 0x001A029C File Offset: 0x0019F29C
		internal float a(int A_0)
		{
			if (this.x)
			{
				this.e();
			}
			float num = 0f;
			int num2 = this.b[A_0].a();
			for (int i = A_0; i < A_0 + num2; i++)
			{
				num += this.b[i].ActualRowHeight;
			}
			return num;
		}

		// Token: 0x06002DD7 RID: 11735 RVA: 0x001A0308 File Offset: 0x0019F308
		internal int b(int A_0, float A_1)
		{
			if (this.v)
			{
				this.g();
			}
			if (this.u)
			{
				this.h();
			}
			this.t = false;
			float num = 0f;
			if (this.z)
			{
				if (this.x)
				{
					this.e();
				}
				this.d();
			}
			num += this.m;
			int result;
			if (this.k > 0 && A_0 == 0)
			{
				int i = this.l;
				while (i < this.a.Count)
				{
					num += this.b(i);
					if (num > A_1 + 0.001f)
					{
						if (i == this.l)
						{
							return i + (this.a[i].a() - 1);
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
						{
							return i + this.a[i].a() - 1;
						}
						i = i + this.a[i].a() - 1;
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
					num += this.b(i);
					if (num > A_1 + 0.001f)
					{
						if (i == A_0)
						{
							return i + (this.a[i].a() - 1);
						}
						return i - 1;
					}
					else
					{
						if (num == A_1)
						{
							return i + this.a[i].a() - 1;
						}
						i = i + this.a[i].a() - 1;
						i++;
					}
				}
				result = i - 1;
			}
			return result;
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x001A0504 File Offset: 0x0019F504
		internal float b(int A_0)
		{
			if (this.w)
			{
				this.f();
			}
			float num = 0f;
			int num2 = this.a[A_0].a();
			for (int i = A_0; i < A_0 + num2; i++)
			{
				num += this.a[i].Width;
			}
			return num;
		}

		// Token: 0x040015C7 RID: 5575
		internal ColumnList a = new ColumnList();

		// Token: 0x040015C8 RID: 5576
		internal RowList b = new RowList();

		// Token: 0x040015C9 RID: 5577
		internal Cell[,] c = null;

		// Token: 0x040015CA RID: 5578
		internal TextAlign d = TextAlign.Left;

		// Token: 0x040015CB RID: 5579
		internal Color e = null;

		// Token: 0x040015CC RID: 5580
		internal Font f = Font.Helvetica;

		// Token: 0x040015CD RID: 5581
		internal float g = 12f;

		// Token: 0x040015CE RID: 5582
		internal float h = 2f;

		// Token: 0x040015CF RID: 5583
		internal Color i = Grayscale.Black;

		// Token: 0x040015D0 RID: 5584
		internal VAlign j = VAlign.Top;

		// Token: 0x040015D1 RID: 5585
		internal int k = 0;

		// Token: 0x040015D2 RID: 5586
		internal int l = 0;

		// Token: 0x040015D3 RID: 5587
		private float m = 0f;

		// Token: 0x040015D4 RID: 5588
		internal int n = 0;

		// Token: 0x040015D5 RID: 5589
		internal int o = 0;

		// Token: 0x040015D6 RID: 5590
		private float p = 0f;

		// Token: 0x040015D7 RID: 5591
		internal float q = 1f;

		// Token: 0x040015D8 RID: 5592
		internal Color r = Grayscale.Black;

		// Token: 0x040015D9 RID: 5593
		internal bool s = true;

		// Token: 0x040015DA RID: 5594
		internal bool t = true;

		// Token: 0x040015DB RID: 5595
		internal bool u = true;

		// Token: 0x040015DC RID: 5596
		internal bool v = true;

		// Token: 0x040015DD RID: 5597
		internal bool w = true;

		// Token: 0x040015DE RID: 5598
		internal bool x = true;

		// Token: 0x040015DF RID: 5599
		internal bool y = true;

		// Token: 0x040015E0 RID: 5600
		internal bool z = true;

		// Token: 0x040015E1 RID: 5601
		internal bool aa = true;

		// Token: 0x040015E2 RID: 5602
		internal bool ab = true;
	}
}
