using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200073D RID: 1853
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use Row2 class instead.", false)]
	public class Row
	{
		// Token: 0x06004AD3 RID: 19155 RVA: 0x00261128 File Offset: 0x00260128
		internal int a()
		{
			return this.o;
		}

		// Token: 0x06004AD4 RID: 19156 RVA: 0x00261140 File Offset: 0x00260140
		internal void a(int A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06004AD5 RID: 19157 RVA: 0x0026114C File Offset: 0x0026014C
		internal Row(acy A_0, float A_1, Font A_2, float A_3, Color A_4, Color A_5)
		{
			if (A_1 <= 0f)
			{
				A_1 = 0f;
				this.l = false;
			}
			this.a = A_1;
			this.b = A_1;
			this.c = A_0;
			this.g = A_2;
			this.h = A_3;
			this.e = A_4;
			this.f = A_5;
			this.d = new CellList(this, A_0.a.Count);
		}

		// Token: 0x06004AD6 RID: 19158 RVA: 0x002611F8 File Offset: 0x002601F8
		internal void a(acx A_0, bool A_1, int A_2)
		{
			if (A_0.d().a().k > 0 && A_0.d().d() > 0)
			{
				int num = A_0.d().a().k - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					if (i >= A_0.d().a().a.Count)
					{
						break;
					}
					A_0.d().a().b(num2);
					num2 += A_0.d().a().a[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					Cell cell = A_0.d().a().c[i, A_2];
					if (cell != null && cell.k() != -1 && cell.k() == i && cell.l() == A_2)
					{
						if (!A_1)
						{
							cell.a(A_0);
						}
						else
						{
							cell.b(A_0);
						}
					}
					else if (cell != null && cell.k() != -1)
					{
						if (cell.l() != A_2)
						{
							A_0.a(A_0.a() + this.c.a[i].Width);
						}
					}
				}
			}
			for (int i = A_0.d().d(); i <= A_0.d().e(); i++)
			{
				Cell cell = A_0.d().a().c[i, A_2];
				if (cell != null && cell.k() != -1 && cell.k() == i && cell.l() == A_2)
				{
					if (!A_1)
					{
						cell.a(A_0);
					}
					else
					{
						cell.b(A_0);
					}
				}
				else if (cell != null && cell.k() != -1)
				{
					if (cell.l() != A_2)
					{
						A_0.a(A_0.a() + this.c.a[i].Width);
					}
				}
			}
			A_0.b(A_0.b() + this.b);
			A_0.a(A_0.d().X);
		}

		// Token: 0x06004AD7 RID: 19159 RVA: 0x00261484 File Offset: 0x00260484
		internal void a(acx A_0, bool A_1, int A_2, StructureElement A_3)
		{
			StructureElement structureElement = null;
			TagOptions tagOptions = null;
			if (A_1)
			{
				PageWriter pageWriter = A_0.c();
				if (pageWriter.Document.Tag != null)
				{
					if (this.m == null)
					{
						structureElement = new StructureElement(TagType.TableRow);
						structureElement.a(false);
						structureElement.Parent = A_3;
						structureElement.Order = this.n;
						pageWriter.Document.j().e(structureElement);
					}
					else if (this.m.g())
					{
						structureElement = (StructureElement)this.m;
						if (!structureElement.u())
						{
							if (structureElement.Parent == null)
							{
								structureElement.Parent = A_3;
							}
							if (A_0.d().Tag == null)
							{
								A_0.d().Tag = A_3;
							}
							pageWriter.Document.j().e(structureElement);
							structureElement.a(A_0, this);
						}
						else if (((StructureElement)this.m).o() != null && ((StructureElement)this.m).o().Count > 0)
						{
							structureElement.a(A_0, this);
						}
					}
					else
					{
						pageWriter.SetTextMode();
						((Artifact)this.Tag).a(pageWriter, null, this, A_0);
						tagOptions = pageWriter.Document.Tag;
						pageWriter.Document.Tag = null;
					}
					if (this.c.k > 0)
					{
						this.c.aa = false;
					}
				}
			}
			if (A_0.d().a().k > 0 && A_0.d().d() > 0)
			{
				int num = A_0.d().a().k - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i;
					if (i >= A_0.d().a().a.Count)
					{
						break;
					}
					A_0.d().a().b(num2);
					num2 += A_0.d().a().a[num2].a() - 1;
					if (num2 > num)
					{
						num = num2;
					}
					Cell cell = A_0.d().a().c[i, A_2];
					if (cell != null && cell.k() != -1 && cell.k() == i && cell.l() == A_2)
					{
						if (!A_1)
						{
							cell.a(A_0);
						}
						else
						{
							cell.a(A_0, structureElement);
						}
					}
					else if (cell != null && cell.k() != -1)
					{
						if (cell.l() != A_2)
						{
							A_0.a(A_0.a() + this.c.a[i].Width);
						}
					}
				}
			}
			for (int i = A_0.d().d(); i <= A_0.d().e(); i++)
			{
				if (A_0.c().Document.Tag != null)
				{
					if (!this.c.aa && A_1)
					{
						if (this.c.k - i <= 0)
						{
							this.c.aa = true;
						}
					}
				}
				Cell cell = A_0.d().a().c[i, A_2];
				if (cell != null && cell.k() != -1 && cell.k() == i && cell.l() == A_2)
				{
					if (!A_1)
					{
						cell.a(A_0);
					}
					else
					{
						cell.a(A_0, structureElement);
					}
				}
				else if (cell != null && cell.k() != -1)
				{
					if (cell.l() != A_2)
					{
						A_0.a(A_0.a() + this.c.a[i].Width);
					}
				}
			}
			A_0.b(A_0.b() + this.b);
			A_0.a(A_0.d().X);
			if (A_1 && tagOptions != null && this.m != null && !this.m.g())
			{
				Tag.a(A_0.c());
				A_0.c().Document.Tag = tagOptions;
			}
		}

		// Token: 0x06004AD8 RID: 19160 RVA: 0x00261998 File Offset: 0x00260998
		internal void b()
		{
			this.b = this.a;
			foreach (object obj in this.d)
			{
				Cell cell = (Cell)obj;
				if (cell != null && cell.k() != -1)
				{
					if (cell.RowSpan == 1)
					{
						float num = cell.a(true);
						if (num > this.b)
						{
							this.b = num;
						}
					}
				}
			}
		}

		// Token: 0x06004AD9 RID: 19161 RVA: 0x00261A50 File Offset: 0x00260A50
		internal void b(int A_0)
		{
			foreach (object obj in this.d)
			{
				Cell cell = (Cell)obj;
				if (cell != null && cell.k() != -1)
				{
					if (cell.RowSpan == 1)
					{
						float num = cell.a(false);
						if (num > this.b)
						{
							this.b = num;
						}
					}
					else
					{
						float num = cell.a(true);
						float num2 = 0f;
						float num3 = 0f;
						bool flag = this.a(cell, A_0, ref num2, ref num3);
						if (num > num2)
						{
							float num4 = num - num2;
							if (flag)
							{
								for (int i = A_0; i < A_0 + cell.RowSpan; i++)
								{
									if (i < this.c.b.Count)
									{
										Row row = this.c.b[i];
										row.a(row.d() + this.c.b[i].d() / num2 * num4);
									}
								}
							}
							else
							{
								for (int i = A_0; i < A_0 + cell.RowSpan; i++)
								{
									if (i < this.c.b.Count && !this.c.b[i].e())
									{
										Row row2 = this.c.b[i];
										row2.a(row2.d() + this.c.b[i].d() / num3 * num4);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06004ADA RID: 19162 RVA: 0x00261C80 File Offset: 0x00260C80
		internal void b(int A_0, Cell[,] A_1)
		{
			foreach (object obj in this.d)
			{
				Cell cell = (Cell)obj;
				if (cell != null)
				{
					int i = this.a(A_0, A_1);
					if (i == -1)
					{
						cell.a(-1);
						cell.b(-1);
					}
					else
					{
						if (cell.RowSpan == 1 && cell.ColumnSpan == 1)
						{
							cell.a(i);
							cell.b(A_0);
							A_1[i, A_0] = cell;
						}
						else if (cell.RowSpan > 1 || cell.ColumnSpan > 1)
						{
							cell.a(i);
							cell.b(A_0);
							int num = i;
							while (i < num + cell.ColumnSpan)
							{
								if (i < this.c.a.Count)
								{
									for (int j = A_0; j < A_0 + cell.RowSpan; j++)
									{
										if (j < this.c.b.Count)
										{
											A_1[i, j] = cell;
										}
									}
								}
								i++;
							}
						}
						cell.i();
					}
				}
			}
		}

		// Token: 0x06004ADB RID: 19163 RVA: 0x00261E2C File Offset: 0x00260E2C
		private bool a(Cell A_0, int A_1, ref float A_2, ref float A_3)
		{
			for (int i = A_1; i < A_1 + A_0.RowSpan; i++)
			{
				if (i < this.c.b.Count)
				{
					A_2 += this.c.b[i].d();
					if (!this.c.b[i].e())
					{
						A_3 += this.c.b[i].d();
					}
				}
			}
			return A_3 == 0f || A_3 == A_2;
		}

		// Token: 0x06004ADC RID: 19164 RVA: 0x00261EEC File Offset: 0x00260EEC
		private int a(int A_0, Cell[,] A_1)
		{
			int num = 0;
			while (A_1[num, A_0] != null)
			{
				num++;
				if (num == this.c.a.Count)
				{
					return -1;
				}
			}
			return num;
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06004ADD RID: 19165 RVA: 0x00261F3C File Offset: 0x00260F3C
		// (set) Token: 0x06004ADE RID: 19166 RVA: 0x00261F54 File Offset: 0x00260F54
		public Font Font
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
				this.c.s = true;
				this.c.u = true;
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06004ADF RID: 19167 RVA: 0x00261F78 File Offset: 0x00260F78
		// (set) Token: 0x06004AE0 RID: 19168 RVA: 0x00261F90 File Offset: 0x00260F90
		public float FontSize
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
				this.c.s = true;
				this.c.u = true;
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06004AE1 RID: 19169 RVA: 0x00261FB4 File Offset: 0x00260FB4
		// (set) Token: 0x06004AE2 RID: 19170 RVA: 0x00261FCC File Offset: 0x00260FCC
		public Color TextColor
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

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06004AE3 RID: 19171 RVA: 0x00261FD8 File Offset: 0x00260FD8
		// (set) Token: 0x06004AE4 RID: 19172 RVA: 0x00261FF0 File Offset: 0x00260FF0
		public Color BackgroundColor
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

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06004AE5 RID: 19173 RVA: 0x00261FFC File Offset: 0x00260FFC
		// (set) Token: 0x06004AE6 RID: 19174 RVA: 0x00262014 File Offset: 0x00261014
		public CellAlign Align
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06004AE7 RID: 19175 RVA: 0x00262020 File Offset: 0x00261020
		// (set) Token: 0x06004AE8 RID: 19176 RVA: 0x00262038 File Offset: 0x00261038
		public CellVAlign VAlign
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06004AE9 RID: 19177 RVA: 0x00262044 File Offset: 0x00261044
		// (set) Token: 0x06004AEA RID: 19178 RVA: 0x0026205C File Offset: 0x0026105C
		public float Padding
		{
			get
			{
				return this.i;
			}
			set
			{
				if (value <= 0f)
				{
					this.i = 0f;
				}
				else
				{
					this.i = value;
				}
				this.c.s = true;
				this.c.u = true;
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06004AEB RID: 19179 RVA: 0x002620A4 File Offset: 0x002610A4
		// (set) Token: 0x06004AEC RID: 19180 RVA: 0x002620BC File Offset: 0x002610BC
		public float Height
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.c.s = true;
				this.c.u = true;
				this.l = true;
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06004AED RID: 19181 RVA: 0x002620E8 File Offset: 0x002610E8
		public CellList Cells
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06004AEE RID: 19182 RVA: 0x00262100 File Offset: 0x00261100
		public float ActualRowHeight
		{
			get
			{
				if (this.c.u)
				{
					if (this.c.v)
					{
						this.c.g();
					}
					this.c.h();
				}
				return this.b;
			}
		}

		// Token: 0x06004AEF RID: 19183 RVA: 0x00262158 File Offset: 0x00261158
		internal acy c()
		{
			return this.c;
		}

		// Token: 0x06004AF0 RID: 19184 RVA: 0x00262170 File Offset: 0x00261170
		internal float d()
		{
			return this.b;
		}

		// Token: 0x06004AF1 RID: 19185 RVA: 0x00262188 File Offset: 0x00261188
		internal void a(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004AF2 RID: 19186 RVA: 0x00262194 File Offset: 0x00261194
		internal bool e()
		{
			return this.l;
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06004AF3 RID: 19187 RVA: 0x002621AC File Offset: 0x002611AC
		// (set) Token: 0x06004AF4 RID: 19188 RVA: 0x002621C4 File Offset: 0x002611C4
		public Tag Tag
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06004AF5 RID: 19189 RVA: 0x002621D0 File Offset: 0x002611D0
		// (set) Token: 0x06004AF6 RID: 19190 RVA: 0x002621E8 File Offset: 0x002611E8
		public int TagOrder
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x04002897 RID: 10391
		private float a;

		// Token: 0x04002898 RID: 10392
		private float b;

		// Token: 0x04002899 RID: 10393
		private acy c;

		// Token: 0x0400289A RID: 10394
		private CellList d;

		// Token: 0x0400289B RID: 10395
		private Color e;

		// Token: 0x0400289C RID: 10396
		private Color f;

		// Token: 0x0400289D RID: 10397
		private Font g;

		// Token: 0x0400289E RID: 10398
		private float h;

		// Token: 0x0400289F RID: 10399
		private float i = float.MinValue;

		// Token: 0x040028A0 RID: 10400
		private CellAlign j = CellAlign.Inherit;

		// Token: 0x040028A1 RID: 10401
		private CellVAlign k = CellVAlign.Inherit;

		// Token: 0x040028A2 RID: 10402
		private bool l = true;

		// Token: 0x040028A3 RID: 10403
		private Tag m;

		// Token: 0x040028A4 RID: 10404
		private int n = 0;

		// Token: 0x040028A5 RID: 10405
		private int o = 1;
	}
}
