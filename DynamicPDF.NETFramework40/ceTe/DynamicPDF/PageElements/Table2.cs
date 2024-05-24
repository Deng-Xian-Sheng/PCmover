using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070E RID: 1806
	public class Table2 : RotatingPageElement, IArea, ICoordinate
	{
		// Token: 0x06004750 RID: 18256 RVA: 0x0024C4FC File Offset: 0x0024B4FC
		public Table2(float x, float y, float width, float height) : this(x, y, width, height, null, null, null, null)
		{
		}

		// Token: 0x06004751 RID: 18257 RVA: 0x0024C524 File Offset: 0x0024B524
		public Table2(float x, float y, float width, float height, Font font, float? fontSize) : this(x, y, width, height, font, fontSize, null, null)
		{
		}

		// Token: 0x06004752 RID: 18258 RVA: 0x0024C548 File Offset: 0x0024B548
		public Table2(float x, float y, float width, float height, Font font, float? fontSize, Color textColor, Color backColor)
		{
			this.g = true;
			this.h = true;
			this.i = null;
			this.j = true;
			this.k = null;
			this.l = null;
			this.m = false;
			this.n = null;
			this.o = null;
			this.p = null;
			base..ctor(x, y, height);
			this.b = width;
			this.a = new qy();
			if (font != null)
			{
				this.a.p().Font = font;
			}
			if (fontSize != null)
			{
				this.a.p().FontSize = fontSize;
			}
			if (textColor != null)
			{
				this.a.p().TextColor = textColor;
			}
			if (backColor != null)
			{
				this.a.p().BackgroundColor = backColor;
			}
			this.c = 0;
			this.e = 0;
		}

		// Token: 0x06004753 RID: 18259 RVA: 0x0024C64C File Offset: 0x0024B64C
		internal Table2(Table2 A_0, int A_1, int A_2, float A_3, float A_4, float A_5, float A_6)
		{
			this.g = true;
			this.h = true;
			this.i = null;
			this.j = true;
			this.k = null;
			this.l = null;
			this.m = false;
			this.n = null;
			this.o = null;
			this.p = null;
			base..ctor(A_3, A_4, A_6);
			this.b = A_5;
			this.c = A_1;
			this.e = A_2;
			this.a = A_0.a.ag();
			this.a.ac();
		}

		// Token: 0x06004754 RID: 18260 RVA: 0x0024C6F0 File Offset: 0x0024B6F0
		internal Table2(Table2 A_0, int A_1, int A_2, float A_3, float A_4, float A_5, float A_6, bool A_7, Row2 A_8)
		{
			this.g = true;
			this.h = true;
			this.i = null;
			this.j = true;
			this.k = null;
			this.l = null;
			this.m = false;
			this.n = null;
			this.o = null;
			this.p = null;
			base..ctor(A_3, A_4, A_6);
			this.b = A_5;
			this.c = A_1;
			this.e = A_2;
			this.a = A_0.a.ag();
			this.a.ac();
			if (A_7)
			{
				if (A_8 == null)
				{
					this.a(this.Rows[A_1], this, A_1);
				}
				else
				{
					this.a(A_8, this, A_1);
				}
				this.l = new int?(A_1);
			}
			else
			{
				A_8 = null;
			}
		}

		// Token: 0x06004755 RID: 18261 RVA: 0x0024C7E0 File Offset: 0x0024B7E0
		internal Table2(Table2 A_0, int A_1, int A_2, float A_3, float A_4, float A_5, float A_6, int A_7, int A_8)
		{
			this.g = true;
			this.h = true;
			this.i = null;
			this.j = true;
			this.k = null;
			this.l = null;
			this.m = false;
			this.n = null;
			this.o = null;
			this.p = null;
			base..ctor(A_3, A_4, A_6);
			this.b = A_5;
			this.c = A_1;
			this.e = A_2;
			this.a = A_0.a.ag();
			this.a.ac();
			this.a(A_1, this, A_7, A_8);
		}

		// Token: 0x06004756 RID: 18262 RVA: 0x0024C894 File Offset: 0x0024B894
		internal Table2(Table2 A_0, int A_1, int A_2, float A_3, float A_4, float A_5, float A_6, int A_7)
		{
			this.g = true;
			this.h = true;
			this.i = null;
			this.j = true;
			this.k = null;
			this.l = null;
			this.m = false;
			this.n = null;
			this.o = null;
			this.p = null;
			base..ctor(A_3, A_4, A_6);
			this.b = A_5;
			this.c = A_1;
			this.e = A_2;
			this.a = A_0.a.ag();
			this.a.ac();
			this.a(A_1, this, A_7);
		}

		// Token: 0x06004757 RID: 18263 RVA: 0x0024C944 File Offset: 0x0024B944
		public Table2 GetOverflowRows()
		{
			return this.GetOverflowRows(this.X, this.Y, this.b, this.Height);
		}

		// Token: 0x06004758 RID: 18264 RVA: 0x0024C974 File Offset: 0x0024B974
		public Table2 GetOverflowRows(float x, float y)
		{
			return this.GetOverflowRows(x, y, this.b, this.Height);
		}

		// Token: 0x06004759 RID: 18265 RVA: 0x0024C99C File Offset: 0x0024B99C
		public Table2 GetOverflowRows(float x, float y, float width, float height)
		{
			Table2 result;
			if (this.a.d().Count == 0)
			{
				result = null;
			}
			else
			{
				if (this.g || this.a.j())
				{
					this.o = null;
					this.l = this.a();
					this.d = this.a.a(this.c, this.Height, this.k, this.l, ref this.o);
					this.g = false;
					this.j = this.a.b();
					this.a.j(false);
				}
				if (this.a.v())
				{
					this.a.j(true);
					Table2 table = this.a(x, y, width, height);
					if (this.p == null)
					{
						this.p = this;
						table.p = this;
					}
					else
					{
						table.p = this.p;
					}
					result = table;
				}
				else if (this.d == this.a.d().Count - 1)
				{
					result = null;
				}
				else
				{
					this.a.j(true);
					Table2 table = new Table2(this, this.d + 1, this.e, x, y, width, height);
					table.Tag = this.Tag;
					table.TagOrder = this.TagOrder;
					this.a.i(false);
					if (this.p == null)
					{
						this.p = this;
						table.p = this;
					}
					else
					{
						table.p = this.p;
					}
					result = table;
				}
			}
			return result;
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x0600475A RID: 18266 RVA: 0x0024CB6C File Offset: 0x0024BB6C
		public int VisibleStartRow
		{
			get
			{
				return this.c + 1;
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x0600475B RID: 18267 RVA: 0x0024CB88 File Offset: 0x0024BB88
		public int VisibleStartColumn
		{
			get
			{
				return this.e + 1;
			}
		}

		// Token: 0x0600475C RID: 18268 RVA: 0x0024CBA4 File Offset: 0x0024BBA4
		private Table2 a(float A_0, float A_1, float A_2, float A_3)
		{
			bool flag = false;
			Row2 a_ = null;
			Table2 table = null;
			if (this.a.v())
			{
				this.a(true);
				if (this.j)
				{
					if (this.a.x() != null && this.a.w() != null)
					{
						this.n = this.a.w();
						table = new Table2(this, this.d, this.e, A_0, A_1, A_2, A_3, this.a.w().Value, this.a.x().Value);
					}
					else if (this.o == null)
					{
						if (!this.a.g(this.Rows[this.d]))
						{
							if (this.l >= this.d)
							{
								a_ = this.k;
							}
							flag = true;
						}
						else if (this.d == this.a.d().Count)
						{
							return null;
						}
						if (!flag)
						{
							table = new Table2(this, this.d + 1, this.e, A_0, A_1, A_2, A_3, flag, a_);
						}
						else
						{
							table = new Table2(this, this.d, this.e, A_0, A_1, A_2, A_3, flag, a_);
						}
					}
					else if (this.a(this.o.Value))
					{
						if (this.d + 1 >= this.Rows.Count)
						{
							return null;
						}
						if (this.a.g(this.Rows[this.d]))
						{
							table = new Table2(this, this.d + 1, this.e, A_0, A_1, A_2, A_3);
						}
						else
						{
							table = new Table2(this, this.d, this.e, A_0, A_1, A_2, A_3);
						}
					}
					else if (this.a.g(this.Rows[this.d]))
					{
						table = new Table2(this, this.d + 1, this.e, A_0, A_1, A_2, A_3, this.o.Value);
					}
					else
					{
						table = new Table2(this, this.d, this.e, A_0, A_1, A_2, A_3, this.o.Value);
					}
				}
				else
				{
					if (!this.a.g(this.k))
					{
						a_ = this.k;
						flag = true;
					}
					else if (this.d == this.a.d().Count)
					{
						return null;
					}
					table = new Table2(this, this.d, this.e, A_0, A_1, A_2, A_3, flag, a_);
				}
			}
			table.Tag = this.Tag;
			table.TagOrder = this.TagOrder;
			this.a.i(false);
			return table;
		}

		// Token: 0x0600475D RID: 18269 RVA: 0x0024CF0C File Offset: 0x0024BF0C
		public Table2 GetOverflowColumns()
		{
			return this.GetOverflowColumns(this.X, this.Y, this.b, this.Height);
		}

		// Token: 0x0600475E RID: 18270 RVA: 0x0024CF3C File Offset: 0x0024BF3C
		public Table2 GetOverflowColumns(float x, float y)
		{
			return this.GetOverflowColumns(x, y, this.b, this.Height);
		}

		// Token: 0x0600475F RID: 18271 RVA: 0x0024CF64 File Offset: 0x0024BF64
		public Table2 GetOverflowColumns(float x, float y, float width, float height)
		{
			Table2 result;
			if (this.a.c().Count == 0)
			{
				result = null;
			}
			else
			{
				if (this.h || this.a.k())
				{
					this.f = this.a.a(this.e, this.b);
					this.h = false;
				}
				if (this.f == this.a.c().Count - 1)
				{
					result = null;
				}
				else
				{
					Table2 table = new Table2(this, this.c, this.f + 1, x, y, width, height);
					table.Tag = this.Tag;
					table.TagOrder = this.TagOrder;
					if (this.p == null)
					{
						this.p = this;
						table.p = this;
					}
					else
					{
						table.p = this.p;
					}
					result = table;
				}
			}
			return result;
		}

		// Token: 0x06004760 RID: 18272 RVA: 0x0024D068 File Offset: 0x0024C068
		public float GetVisibleWidth()
		{
			if (this.h || this.a.k())
			{
				this.f = this.a.a(this.e, this.b);
				this.h = false;
			}
			float num = 0f;
			if (this.a.f() > 0 && this.e > 0)
			{
				num += this.a.t() + this.CellSpacing;
			}
			for (int i = this.e; i <= this.f; i++)
			{
				num += this.a.c()[i].Width + this.CellSpacing;
			}
			return num + this.CellSpacing;
		}

		// Token: 0x06004761 RID: 18273 RVA: 0x0024D144 File Offset: 0x0024C144
		public float GetVisibleHeight()
		{
			if (this.g || this.a.j())
			{
				this.o = null;
				this.l = this.a();
				this.d = this.a.a(this.c, this.Height, this.k, this.l, ref this.o);
				this.g = false;
				this.j = this.a.b();
				this.a.j(false);
				if (this.a.v())
				{
					this.a(true);
				}
			}
			float num = 0f;
			if (this.a.h() > 0 && this.c > 0)
			{
				num += this.a.s() + this.CellSpacing;
			}
			if (this.k != null)
			{
				num += this.k.g() + this.CellSpacing;
			}
			float? num2 = null;
			if (this.j)
			{
				if (this.e() != null || this.c())
				{
					if (this.n == null)
					{
						if (this.d == this.a.d().Count)
						{
							for (int i = this.c; i < this.d; i++)
							{
								num += this.a.d()[i].g() + this.CellSpacing;
							}
						}
						else
						{
							for (int i = this.c; i < this.d; i++)
							{
								if (this.l != i)
								{
									num += this.a.d()[i].g() + this.CellSpacing;
								}
							}
							if (this.d >= this.c)
							{
								num2 = this.b(this.Rows[this.d]);
								bool flag;
								if (num2 != null)
								{
									float? num3 = num2;
									float num4 = this.a.d()[this.d].g();
									flag = (num3.GetValueOrDefault() <= num4 || num3 == null);
								}
								else
								{
									flag = true;
								}
								if (!flag)
								{
									num += num2.Value + this.CellSpacing;
								}
								else
								{
									num += this.a.d()[this.d].g() + this.CellSpacing;
								}
							}
						}
					}
					else
					{
						int i = this.c;
						for (;;)
						{
							int num5 = i;
							if (!(num5 < this.d + this.n))
							{
								break;
							}
							num += this.a.d()[i].g() + this.CellSpacing;
							i++;
						}
					}
				}
				else
				{
					for (int i = this.c; i <= this.d; i++)
					{
						num += this.a.d()[i].f() + this.CellSpacing;
					}
				}
			}
			return num + this.CellSpacing;
		}

		// Token: 0x06004762 RID: 18274 RVA: 0x0024D51C File Offset: 0x0024C51C
		public float GetRequiredWidth()
		{
			float num = 0f;
			if (this.a.f() > 0 && this.e > 0)
			{
				num += this.a.t();
			}
			for (int i = this.e; i <= this.a.c().Count - 1; i++)
			{
				num += this.a.c()[i].Width;
			}
			return num;
		}

		// Token: 0x06004763 RID: 18275 RVA: 0x0024D5A8 File Offset: 0x0024C5A8
		public float GetRequiredHeight()
		{
			float num = 0f;
			if (this.a.h() > 0 && this.c > 0)
			{
				num += this.a.s();
			}
			if (this.k != null)
			{
				num += this.k.g() + this.CellSpacing;
			}
			for (int i = this.c; i <= this.a.d().Count - 1; i++)
			{
				if (this.l != i)
				{
					num += this.a.d()[i].ActualRowHeight + this.CellSpacing;
				}
			}
			num += this.CellSpacing;
			return num + 0.001f;
		}

		// Token: 0x06004764 RID: 18276 RVA: 0x0024D698 File Offset: 0x0024C698
		public bool HasOverflowRows()
		{
			if (this.g || this.a.j())
			{
				this.o = null;
				this.l = this.a();
				this.d = this.a.a(this.c, this.Height, this.k, this.l, ref this.o);
				this.g = false;
				this.j = this.a.b();
				this.a.j(false);
				if (this.a.v())
				{
					this.a(true);
				}
			}
			return this.d != this.a.d().Count - 1 || this.a.v();
		}

		// Token: 0x06004765 RID: 18277 RVA: 0x0024D78C File Offset: 0x0024C78C
		public bool HasOverflowColumns()
		{
			if (this.h || this.a.k())
			{
				this.f = this.a.a(this.e, this.b);
				this.h = false;
			}
			return this.f != this.a.c().Count - 1;
		}

		// Token: 0x06004766 RID: 18278 RVA: 0x0024D808 File Offset: 0x0024C808
		public int GetVisibleRowCount()
		{
			if (this.g || this.a.j())
			{
				this.o = null;
				this.l = this.a();
				this.d = this.a.a(this.c, this.Height, this.k, this.l, ref this.o);
				this.g = false;
				this.j = this.a.b();
				this.a.j(false);
				if (this.a.v())
				{
					this.a(true);
				}
			}
			int result;
			if (this.c > 0 && this.a.h() > 0)
			{
				result = this.d - this.c + this.a.i() + 1;
			}
			else
			{
				result = this.d - this.c + 1;
			}
			return result;
		}

		// Token: 0x06004767 RID: 18279 RVA: 0x0024D914 File Offset: 0x0024C914
		public int GetVisibleColumnCount()
		{
			if (this.h || this.a.k())
			{
				this.f = this.a.a(this.e, this.b);
				this.h = false;
			}
			int result;
			if (this.e > 0 && this.a.f() > 0)
			{
				result = this.f - this.e + this.a.g() + 1;
			}
			else
			{
				result = this.f - this.e + 1;
			}
			return result;
		}

		// Token: 0x06004768 RID: 18280 RVA: 0x0024D9BC File Offset: 0x0024C9BC
		public void SetOverflowTableHeaderRowTags(Tag[] overflowTableHeaderRowTags)
		{
			for (int i = 0; i < this.RepeatColumnHeaderCount; i++)
			{
				if (i < overflowTableHeaderRowTags.Length)
				{
					this.b().d()[i].Tag = overflowTableHeaderRowTags[i];
				}
			}
		}

		// Token: 0x06004769 RID: 18281 RVA: 0x0024DA0C File Offset: 0x0024CA0C
		public void SetOverflowTableHeaderRowCellsTags(Tag[] overflowTableHeaderRowCellsTags)
		{
			int num = 0;
			int visibleColumnCount = this.GetVisibleColumnCount();
			for (int i = 0; i < this.RepeatColumnHeaderCount; i++)
			{
				for (int j = this.i(); j < this.i() + visibleColumnCount; j++)
				{
					if (num < overflowTableHeaderRowCellsTags.Length)
					{
						this.b().d()[i].Cells[j].Tag = overflowTableHeaderRowCellsTags[num++];
					}
				}
			}
		}

		// Token: 0x0600476A RID: 18282 RVA: 0x0024DA98 File Offset: 0x0024CA98
		public void SetOverflowTableHeaderColumnCellsTags(Tag[] overflowTableHeaderColumnCellsTags)
		{
			int num = 0;
			int visibleRowCount = this.GetVisibleRowCount();
			for (int i = this.g(); i < this.g() + visibleRowCount; i++)
			{
				for (int j = 0; j < this.RepeatRowHeaderCount; j++)
				{
					if (num < overflowTableHeaderColumnCellsTags.Length)
					{
						this.b().d()[i].Cells[j].Tag = overflowTableHeaderColumnCellsTags[num++];
					}
				}
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x0600476B RID: 18283 RVA: 0x0024DB24 File Offset: 0x0024CB24
		// (set) Token: 0x0600476C RID: 18284 RVA: 0x0024DB3C File Offset: 0x0024CB3C
		public float Width
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				this.a.b(true);
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x0600476D RID: 18285 RVA: 0x0024DB54 File Offset: 0x0024CB54
		// (set) Token: 0x0600476E RID: 18286 RVA: 0x0024DB6C File Offset: 0x0024CB6C
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (base.Height != value)
				{
					base.Height = value;
					this.a.a(true);
				}
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x0600476F RID: 18287 RVA: 0x0024DBA0 File Offset: 0x0024CBA0
		public Row2List Rows
		{
			get
			{
				return this.a.d();
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06004770 RID: 18288 RVA: 0x0024DBC0 File Offset: 0x0024CBC0
		public Column2List Columns
		{
			get
			{
				return this.a.c();
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06004771 RID: 18289 RVA: 0x0024DBE0 File Offset: 0x0024CBE0
		public CellDefault CellDefault
		{
			get
			{
				return this.a.p();
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06004772 RID: 18290 RVA: 0x0024DC00 File Offset: 0x0024CC00
		// (set) Token: 0x06004773 RID: 18291 RVA: 0x0024DC20 File Offset: 0x0024CC20
		public int RepeatRowHeaderCount
		{
			get
			{
				return this.a.f();
			}
			set
			{
				if (value <= 0)
				{
					this.a.b(0);
				}
				else
				{
					this.a.b(value);
				}
				this.a.b(true);
				this.a.f(true);
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06004774 RID: 18292 RVA: 0x0024DC6C File Offset: 0x0024CC6C
		// (set) Token: 0x06004775 RID: 18293 RVA: 0x0024DC8C File Offset: 0x0024CC8C
		public int RepeatColumnHeaderCount
		{
			get
			{
				return this.a.h();
			}
			set
			{
				if (value <= 0)
				{
					this.a.c(0);
				}
				else
				{
					this.a.c(value);
				}
				this.a.a(true);
				this.a.e(true);
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06004776 RID: 18294 RVA: 0x0024DCD8 File Offset: 0x0024CCD8
		// (set) Token: 0x06004777 RID: 18295 RVA: 0x0024DCF8 File Offset: 0x0024CCF8
		public float CellSpacing
		{
			get
			{
				return this.a.o();
			}
			set
			{
				if (value <= 0f)
				{
					this.a.a(0f);
				}
				else
				{
					this.a.a(value);
				}
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06004778 RID: 18296 RVA: 0x0024DD34 File Offset: 0x0024CD34
		public Border Border
		{
			get
			{
				return this.a.n();
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06004779 RID: 18297 RVA: 0x0024DD54 File Offset: 0x0024CD54
		// (set) Token: 0x0600477A RID: 18298 RVA: 0x0024DD6C File Offset: 0x0024CD6C
		public Color BackgroundColor
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x0600477B RID: 18299 RVA: 0x0024DD78 File Offset: 0x0024CD78
		protected override void DrawRotated(PageWriter writer)
		{
			writer.SetGraphicsMode();
			writer.SetLineCap(LineCap.Butt);
			if (writer.Document.Tag != null)
			{
				this.b(writer);
			}
			else
			{
				if (!this.a.m())
				{
					this.a.ae();
				}
				q0 q = new q0(this, writer);
				if (this.g || this.a.j())
				{
					if (this.Rows.Count > 0 && this.Rows[this.c].c() && this.d == 0 && this.g)
					{
						this.d = this.a.a(this.c, this.Height, this.k, new int?(this.c), ref this.o);
					}
					else
					{
						this.d = this.a.b(this.c, this.Height, ref this.o);
					}
					this.g = false;
					this.j = this.a.b();
					if (this.a.v())
					{
						this.a(true);
					}
				}
				if (this.h || this.a.k())
				{
					this.f = this.a.a(this.e, this.b);
					this.h = false;
				}
				float visibleWidth = this.GetVisibleWidth();
				float visibleHeight = this.GetVisibleHeight();
				if (this.i != null)
				{
					writer.SetFillColor(this.i);
					float num = (this.Border.Left.Width != null) ? this.Border.Left.Width.Value : 0f;
					float num2 = (this.Border.Top.Width != null) ? this.Border.Top.Width.Value : 0f;
					writer.Write_re(base.X + num, base.Y + num2, visibleWidth, visibleHeight);
					writer.Write_f();
				}
				bool flag = true;
				float a_ = this.Y;
				if (this.k != null)
				{
					this.a.d().a(q, false);
					if (this.k.Cells.Count > 0)
					{
						this.k.b(q, false, this.l.Value, this.k);
					}
					q.a(this.X);
					q.b(this.Y);
					this.a.d().a(q, true);
					if (this.k.Cells.Count > 0)
					{
						this.k.b(q, true, this.l.Value, this.k);
					}
					flag = false;
					a_ = q.b();
				}
				int num3 = -1;
				if (this.j)
				{
					if (this.k != null)
					{
						if (this.l == this.c)
						{
							for (int i = 0; i < this.k.Cells.Count; i++)
							{
								if (num3 < this.k.Cells[i].u())
								{
									num3 = this.k.Cells[i].u();
								}
							}
							if (this.k.Cells.Count > 0)
							{
								this.c = num3 + 1;
							}
							else
							{
								this.c = this.l.Value + 1;
							}
						}
					}
					this.a.d().a(q, false, visibleWidth, visibleHeight, this, flag);
					q.a(this.X);
					if (this.k == null)
					{
						q.b(this.Y);
					}
					else
					{
						q.b(a_);
					}
					this.a.d().a(q, true, visibleWidth, visibleHeight, this, flag);
				}
				if (this.CellSpacing > 0f || !flag)
				{
					this.a(writer);
				}
			}
		}

		// Token: 0x0600477C RID: 18300 RVA: 0x0024E25C File Offset: 0x0024D25C
		private void b(PageWriter A_0)
		{
			TagOptions tag = null;
			if (this.Tag != null && !this.Tag.g())
			{
				this.Tag.e(A_0, this);
				tag = A_0.Document.Tag;
				A_0.Document.Tag = null;
			}
			if (!this.a.m())
			{
				this.a.ae();
			}
			if (this.g || this.a.j())
			{
				if (this.Rows.Count > 0 && this.Rows[this.c].c() && this.d == 0 && this.g)
				{
					this.d = this.a.a(this.c, this.Height, this.k, new int?(this.c), ref this.o);
				}
				else
				{
					this.d = this.a.b(this.c, this.Height, ref this.o);
				}
				this.g = false;
				this.j = this.a.b();
				if (this.a.v())
				{
					this.a(true);
				}
			}
			if (this.h || this.a.k())
			{
				this.f = this.a.a(this.e, this.b);
				this.h = false;
			}
			q0 q = new q0(this, A_0);
			if (A_0.Document.Tag != null)
			{
				A_0.SetGraphicsMode();
				Artifact.a(A_0);
			}
			float visibleWidth = this.GetVisibleWidth();
			float visibleHeight = this.GetVisibleHeight();
			if (this.i != null)
			{
				A_0.SetGraphicsMode();
				A_0.SetFillColor(this.i);
				float num = (this.Border.Left.Width != null) ? this.Border.Left.Width.Value : 0f;
				float num2 = (this.Border.Top.Width != null) ? this.Border.Top.Width.Value : 0f;
				A_0.Write_re(base.X + num, base.Y + num2, visibleWidth, visibleHeight);
				A_0.Write_f();
			}
			bool flag = true;
			float a_ = this.Y;
			if (this.k != null)
			{
				this.a.d().b(q, false);
				this.k.a(q, false, this.l.Value, null, this.k);
				q.a(this.X);
				q.b(this.Y);
				if (A_0.Document.Tag != null)
				{
					Tag.a(A_0);
				}
				this.a.d().b(q, true);
				PageWriter pageWriter = q.c();
				StructureElement structureElement = null;
				if (pageWriter.Document.Tag != null)
				{
					if (q.d().Tag == null)
					{
						if (q.d().p != null && q.d().p.Tag != null)
						{
							structureElement = (StructureElement)q.d().p.Tag;
						}
						else
						{
							structureElement = new StructureElement(TagType.Table);
							if (q.d().p != null)
							{
								q.d().p.Tag = structureElement;
							}
						}
					}
					else
					{
						structureElement = (StructureElement)q.d().Tag;
					}
					if (A_0.k() != null)
					{
						structureElement.Parent = A_0.k();
					}
					if (this.a.h() > 0)
					{
						this.a.h(false);
					}
				}
				this.k.a(q, true, this.l.Value, structureElement, this.k);
				flag = false;
				a_ = q.b();
			}
			int num3 = -1;
			if (this.j)
			{
				if (this.k != null)
				{
					if (this.l == this.c)
					{
						for (int i = 0; i < this.k.Cells.Count; i++)
						{
							if (num3 < this.k.Cells[i].u())
							{
								num3 = this.k.Cells[i].u();
							}
						}
						if (this.k.Cells.Count > 0)
						{
							this.c = num3 + 1;
						}
						else
						{
							this.c = this.l.Value + 1;
						}
					}
				}
				this.a.d().b(q, false, visibleWidth, visibleHeight, this, flag);
				q.a(this.X);
				if (this.k == null)
				{
					q.b(this.Y);
				}
				else
				{
					q.b(a_);
				}
				if (A_0.Document.Tag != null)
				{
					Tag.a(A_0);
				}
				this.a.d().b(q, true, visibleWidth, visibleHeight, this, flag);
			}
			if (this.CellSpacing > 0f || !flag)
			{
				this.a(A_0);
			}
			if (this.Tag != null && !this.Tag.g())
			{
				Tag.a(A_0);
				A_0.Document.Tag = tag;
			}
		}

		// Token: 0x0600477D RID: 18301 RVA: 0x0024E8C0 File Offset: 0x0024D8C0
		private bool a(int A_0)
		{
			for (int i = A_0; i <= this.d; i++)
			{
				for (int j = 0; j < this.Rows[i].Cells.Count; j++)
				{
					if (this.Rows[i].Cells[j].ColumnIndex != -1 && this.Rows[i].Cells[j].Text != null)
					{
						if (this.Rows[i].Cells[j].j() != this.Rows[i].Cells[j].o().Count)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600477E RID: 18302 RVA: 0x0024E9B0 File Offset: 0x0024D9B0
		private int? a()
		{
			int num = int.MinValue;
			int? result;
			if (this.k != null)
			{
				for (int i = 0; i < this.k.Cells.Count; i++)
				{
					if (num < this.k.Cells[i].u() && (this.k.Cells[i].Element != null || this.k.Cells[i].o() != null || this.k.Cells[i].v()))
					{
						num = this.k.Cells[i].u();
					}
				}
				if (num < 0)
				{
					result = new int?(this.c);
				}
				else
				{
					result = new int?(num);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600477F RID: 18303 RVA: 0x0024EAB8 File Offset: 0x0024DAB8
		private float? b(Row2 A_0)
		{
			float num = 0f;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].h() != 0f && num < A_0.Cells[i].h())
				{
					num = A_0.Cells[i].h();
				}
			}
			float? result;
			if (num != 0f)
			{
				result = new float?(num);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06004780 RID: 18304 RVA: 0x0024EB54 File Offset: 0x0024DB54
		private void a(Row2 A_0, Table2 A_1, int A_2)
		{
			float num = 0f;
			A_1.c(new Row2(this.a, A_0.Height, A_0.d()));
			int count = A_0.Cells.Count;
			for (int i = 0; i < count; i++)
			{
				if (A_0.Cells[i].ColumnIndex != -1)
				{
					if (A_0.Cells[i].Element == null)
					{
						if (A_0.Cells[i].o() == null || A_0.Cells[i].j() == A_0.Cells[i].o().Count)
						{
							if (A_0.c())
							{
								A_1.e().Cells.a(A_0.Cells[i], true);
							}
							else
							{
								A_1.e().Cells.a(A_0.Cells[i], false);
							}
						}
						else
						{
							A_1.e().Cells.a(A_0.Cells[i], false);
							int index = A_1.e().Cells.Count - 1;
							if (A_1.e().Cells[index].Text != null || A_0.Cells[i].o() != null)
							{
								A_0.Cells[i].o().Height = A_0.Cells[i].o().i()[A_0.Cells[i].j()].YOffset;
								A_1.e().Cells[index].a(A_0.Cells[i].o().GetOverflow(A_0.Cells[i].o().Width, A_1.Height));
								float num2 = A_1.e().Cells[index].a(true);
								if (num < num2)
								{
									num = num2;
								}
							}
						}
					}
					else
					{
						A_1.e().Cells.a(A_0.Cells[i], true);
					}
				}
			}
			A_1.e().b(num);
			A_1.e().a(num);
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			for (int i = 0; i < A_1.k.Cells.Count; i++)
			{
				if (A_1.k.Cells[i].Element != null || A_1.k.Cells[i].o() != null)
				{
					num3++;
					num5 = A_1.k.Cells[i].u();
					if (num4 < A_1.k.Cells[i].RowSpan)
					{
						num4 = A_1.k.Cells[i].RowSpan;
					}
				}
			}
			bool flag = true;
			if (num3 == 1 && num4 > 1 && A_2 + 1 <= this.Rows.Count - 1 && num5 + num4 - 1 >= A_2 + 1)
			{
				for (int i = 0; i < A_1.k.Cells.Count; i++)
				{
					if (A_1.k.Cells[i].Text == null && A_1.k.Cells[i].Element == null)
					{
						if (A_1.k.Cells[i].u() == A_2 + 1)
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					this.a(A_1.e(), A_2 + 1, true);
					A_1.c = this.a(A_1.e());
				}
			}
			else if (num3 == 1 && num4 > 1)
			{
				for (int i = 0; i < A_1.e().Cells.Count; i++)
				{
					flag = (A_1.e().Cells[i].Text != null || A_1.e().Cells[i].Element != null);
				}
				if (flag && A_2 + 1 <= this.Rows.Count - 1)
				{
					A_2--;
					this.a(A_1.e(), A_2 + 1, false);
					A_1.c = this.a(A_1.e());
				}
			}
		}

		// Token: 0x06004781 RID: 18305 RVA: 0x0024F0B4 File Offset: 0x0024E0B4
		private void a(Row2 A_0, int A_1, bool A_2)
		{
			float num = 0f;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (A_0.Cells[i].Text == null && A_0.Cells[i].Element == null)
				{
					for (int j = 0; j < this.Rows[A_1].Cells.Count; j++)
					{
						if (this.Rows[A_1].Cells[j].t() == A_0.Cells[i].t())
						{
							if (this.Rows[A_1].Cells[j].Text != null)
							{
								if (!A_2)
								{
									A_0.Cells[i].a(null);
								}
								else
								{
									A_0.Cells[i].a(this.Rows[A_1].Cells[j].o());
								}
								A_0.Cells[i].a(this.Rows[A_1].Cells[j].ColumnSpan);
								A_0.Cells[i].b(this.Rows[A_1].Cells[j].RowSpan);
								A_0.Cells[i].d(true);
							}
							else if (this.Rows[A_1].Cells[j].Element != null)
							{
								A_0.Cells[i].a(this.Rows[A_1].Cells[j].Element);
							}
							A_0.Cells[i].Splittable = this.Rows[A_1].Cells[j].Splittable;
							A_0.Cells[i].b(this.Rows[A_1].Cells[j].e());
							A_0.Cells[i].f(this.Rows[A_1].Cells[j].u());
							float num2 = A_0.Cells[i].a(true);
							if (num < num2)
							{
								num = num2;
							}
							break;
						}
					}
				}
			}
			if (num > 0f && A_0.g() < num)
			{
				A_0.b(num);
				A_0.a(num);
			}
		}

		// Token: 0x06004782 RID: 18306 RVA: 0x0024F3B4 File Offset: 0x0024E3B4
		private void a(int A_0, Table2 A_1, int A_2, int A_3)
		{
			float num = 0f;
			Row2 row = this.Rows[A_0];
			A_1.c(new Row2(this.a, row.Height, row.d()));
			int count = row.Cells.Count;
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				if (row.Cells[i].ColumnIndex != -1)
				{
					if (row.Cells[i].Element == null)
					{
						if (row.Cells[i].o() == null || row.Cells[i].j() == row.Cells[i].o().Count)
						{
							A_1.e().Cells.a(row.Cells[i], true);
						}
						else
						{
							A_1.e().Cells.a(row.Cells[i], false);
							int index = A_1.e().Cells.Count - 1;
							if (A_1.e().Cells[index].Text != null)
							{
								this.e().Cells[i].o().Height = this.e().Cells[i].o().i()[this.e().Cells[i].j()].YOffset;
								A_1.e().Cells[index].a(this.e().Cells[i].o().GetOverflow(this.b, A_1.Height));
								float num3 = A_1.e().Cells[index].a(true);
								if (num < num3)
								{
									num = num3;
								}
								if (num2 < A_1.e().Cells[index].RowSpan)
								{
									num2 = A_1.e().Cells[index].RowSpan;
								}
							}
						}
					}
					else
					{
						A_1.e().Cells.a(row.Cells[i], true);
					}
				}
				else
				{
					A_1.e().Cells.a(row.Cells[i], true);
				}
			}
			A_1.e().b(num);
			A_1.e().a(num);
			if (A_3 > A_2)
			{
				this.b(A_0, A_1, A_2);
			}
			for (int i = 0; i < A_1.e().Cells.Count; i++)
			{
				if (A_1.e().Cells[i].Text == null && A_1.e().Cells[i].Element == null)
				{
					A_1.e().Cells[i].f(A_0 + A_2 - 1);
				}
			}
		}

		// Token: 0x06004783 RID: 18307 RVA: 0x0024F730 File Offset: 0x0024E730
		private void b(int A_0, Table2 A_1, int A_2)
		{
			float num = 0f;
			if (A_0 + A_2 < this.Rows.Count)
			{
				Row2 row = this.Rows[A_0 + A_2];
				int count = row.Cells.Count;
				for (int i = 0; i < count; i++)
				{
					int j = 0;
					if (row.Cells[i].ColumnIndex != -1)
					{
						if (row.Cells[i].Element == null && row.Cells[i].o() != null)
						{
							while (j < A_1.e().Cells.Count)
							{
								if (A_1.e().Cells[j].t() == row.Cells[i].t())
								{
									A_1.e().Cells[j].a(row.Cells[i].o());
									A_1.e().Cells[j].f(row.Cells[i].u());
									A_1.e().Cells[j].a(row.Cells[i].ColumnSpan);
									A_1.e().Cells[j].b(row.Cells[i].RowSpan);
									A_1.e().Cells[j].b(row.Cells[i].Width);
									A_1.e().Cells[j].Splittable = row.Cells[i].Splittable;
									A_1.e().Cells[j].b(row.Cells[i].e());
									A_1.e().Cells[j].c(row.Cells[i].k());
									break;
								}
								j++;
							}
							if (A_1.e().Cells[j].Text != null)
							{
								float num2 = A_1.e().Cells[j].a(true);
								if (num < num2)
								{
									num = num2;
								}
							}
						}
					}
				}
			}
			if (num > 0f && num > A_1.e().g())
			{
				A_1.e().b(num);
				A_1.e().a(num);
			}
		}

		// Token: 0x06004784 RID: 18308 RVA: 0x0024FA40 File Offset: 0x0024EA40
		private void a(int A_0, Table2 A_1, int A_2)
		{
			float num = 0f;
			Row2 row = this.Rows[A_0];
			Row2 row2 = this.Rows[A_2];
			A_1.c(new Row2(this.a, row.Height, row.d()));
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			for (int i = 0; i < this.a.c().Count; i++)
			{
				if (row.Cells.Count > num3 && row.Cells[num3].ColumnIndex != -1)
				{
					if (row.Cells[num3].t() == i)
					{
						A_1.e().Cells.a(row.Cells[num3], false);
						int index = A_1.e().Cells.Count - 1;
						if (A_1.e().Cells[index].Text != null)
						{
							float num4;
							if (row.Cells[num3].j() < row.Cells[num3].o().Count && row.Cells[num3].j() > row.Cells[num3].i())
							{
								row2.Cells[i].o().Height = row2.Cells[i].o().i()[row2.Cells[i].j()].YOffset;
								A_1.e().Cells[index].a(row2.Cells[i].o().GetOverflow(row2.Cells[i].o().Width, A_1.Height));
								num4 = A_1.e().Cells[index].a(true);
							}
							else
							{
								num4 = A_1.e().Cells[index].a(true);
							}
							if (num < num4)
							{
								num = num4;
								if (A_1.e().Cells[index].RowSpan > 1 && !flag && A_1.e().Cells[index].RowSpan + A_1.e().Cells[index].u() <= A_0)
								{
									flag = true;
								}
							}
							if (num2 < A_1.e().Cells[index].RowSpan)
							{
								num2 = A_1.e().Cells[index].RowSpan;
							}
						}
						num3++;
					}
					else if (row.Cells[num3].t() != i)
					{
						int index;
						for (int j = 0; j < row2.Cells.Count; j++)
						{
							if (i == row2.Cells[j].t())
							{
								A_1.e().Cells.a(row2.Cells[j], false);
								index = A_1.e().Cells.Count - 1;
								if (A_1.e().Cells[index].Text != null)
								{
									if (row2.Cells[i].j() < row2.Cells[i].o().Count)
									{
										row2.Cells[i].o().Height = row2.Cells[i].o().i()[row2.Cells[i].j()].YOffset;
										A_1.e().Cells[index].a(row2.Cells[i].o().GetOverflow(row2.Cells[i].o().Width, A_1.Height));
										float num4 = A_1.e().Cells[index].a(true);
									}
									else
									{
										A_1.e().Cells[index].a(null);
										A_1.e().Cells[index].c(true);
									}
								}
								break;
							}
							if (j == 0 && row2.Cells[j].t() > i)
							{
								A_1.e().Cells.a(this.a.e()[i, A_2], false);
								index = A_1.e().Cells.Count - 1;
								if (A_1.e().Cells[index].Text != null)
								{
									if (this.a.e()[i, A_2].j() < this.a.e()[i, A_2].o().Count)
									{
										row2.Cells[i].o().Height = row2.Cells[i].o().i()[row2.Cells[i].j()].YOffset;
										A_1.e().Cells[index].a(row2.Cells[i].o().GetOverflow(row2.Cells[i].o().Width, A_1.Height));
										float num4 = A_1.e().Cells[index].a(true);
									}
									else
									{
										A_1.e().Cells[index].a(null);
										A_1.e().Cells[index].c(true);
									}
								}
								break;
							}
						}
						index = A_1.e().Cells.Count - 1;
						if (A_1.e().Cells[index].Text != null)
						{
							float num4 = A_1.e().Cells[index].a(true);
							if (num < num4)
							{
								num = num4;
								if (A_1.e().Cells[index].RowSpan > 1 && !flag && A_1.e().Cells[index].RowSpan + A_1.e().Cells[index].u() <= A_0)
								{
									flag = true;
								}
							}
							if (num2 < A_2 + A_1.e().Cells[index].RowSpan - 1)
							{
								num2 = A_1.e().Cells[index].RowSpan;
							}
						}
						row2 = this.Rows[A_2];
					}
				}
				else
				{
					int index;
					for (int j = 0; j < row2.Cells.Count; j++)
					{
						if (i == row2.Cells[j].t())
						{
							A_1.e().Cells.a(row2.Cells[j], false);
							index = A_1.e().Cells.Count - 1;
							if (A_1.e().Cells[index].Text != null)
							{
								if (row2.Cells[j].j() < row2.Cells[j].o().Count)
								{
									row2.Cells[i].o().Height = row2.Cells[i].o().i()[row2.Cells[i].j()].YOffset;
									A_1.e().Cells[index].a(row2.Cells[i].o().GetOverflow(row2.Cells[i].o().Width, A_1.Height));
									float num4 = A_1.e().Cells[index].a(true);
								}
								else
								{
									A_1.e().Cells[index].a(null);
									A_1.e().Cells[index].c(true);
								}
							}
							break;
						}
						if (j == 0 && row2.Cells[j].t() > i)
						{
							A_1.e().Cells.a(this.a.e()[i, A_2], false);
							index = A_1.e().Cells.Count - 1;
							if (A_1.e().Cells[index].Text != null)
							{
								if (this.a.e()[i, A_2].j() < this.a.e()[i, A_2].o().Count)
								{
									row2.Cells[i].o().Height = row2.Cells[i].o().i()[row2.Cells[i].j()].YOffset;
									A_1.e().Cells[index].a(row2.Cells[i].o().GetOverflow(row2.Cells[i].o().Width, A_1.Height));
									float num4 = A_1.e().Cells[index].a(true);
								}
								else
								{
									A_1.e().Cells[index].a(null);
									A_1.e().Cells[index].c(true);
								}
							}
							break;
						}
					}
					index = A_1.e().Cells.Count - 1;
					if (A_1.e().Cells[index].o() != null)
					{
						float num4 = A_1.e().Cells[index].a(true);
						if (num < num4)
						{
							num = num4;
							if (A_1.e().Cells[index].RowSpan > 1 && !flag && A_1.e().Cells[index].RowSpan + A_1.e().Cells[index].u() <= A_0)
							{
								flag = true;
							}
						}
						if (num2 < A_2 + A_1.e().Cells[index].RowSpan - 1)
						{
							num2 = A_1.e().Cells[index].RowSpan;
						}
					}
					row2 = this.Rows[A_2];
				}
			}
			if (num == 0f)
			{
				A_1.k = null;
			}
			else if (flag)
			{
				A_1.e().b(row.g());
				A_1.e().b(row.f());
			}
			else
			{
				A_1.e().b(num);
				A_1.e().a(num);
			}
		}

		// Token: 0x06004785 RID: 18309 RVA: 0x002506EC File Offset: 0x0024F6EC
		private int a(Row2 A_0)
		{
			int num = -1;
			for (int i = 0; i < A_0.Cells.Count; i++)
			{
				if (num < A_0.Cells[i].u())
				{
					num = A_0.Cells[i].u();
				}
			}
			return num + 1;
		}

		// Token: 0x06004786 RID: 18310 RVA: 0x0025074C File Offset: 0x0024F74C
		private void a(PageWriter A_0)
		{
			A_0.SetGraphicsMode();
			if (A_0.Document.Tag != null)
			{
				Artifact.a(A_0);
			}
			float num = this.Border.Top.Width.Value;
			float num2 = this.Border.Bottom.Width.Value;
			float num3 = this.Border.Left.Width.Value;
			float num4 = this.Border.Right.Width.Value;
			Color color = this.Border.Left.Color;
			Color color2 = this.Border.Right.Color;
			Color color3 = this.Border.Top.Color;
			Color color4 = this.Border.Bottom.Color;
			float num5 = this.GetVisibleWidth() + num4;
			float num6 = this.GetVisibleHeight() + num2;
			if (num == num2 && num2 == num3 && num3 == num4 && color3.Equals(color4) && color4.Equals(color) && color.Equals(color2) && this.Border.Top.LineStyle.Equals(this.Border.Bottom.LineStyle) && this.Border.Bottom.LineStyle.Equals(this.Border.Left.LineStyle) && this.Border.Left.LineStyle.Equals(this.Border.Right.LineStyle))
			{
				if (!this.Border.Left.LineStyle.Equals(LineStyle.None) && num3 != 0f)
				{
					A_0.SetStrokeColor(color);
					A_0.SetLineWidth(num3);
					A_0.SetLineStyle(this.Border.Left.LineStyle);
					A_0.Write_re(base.X + num3 / 2f, base.Y + num / 2f, num5, num6);
					A_0.Write_s_();
				}
			}
			else
			{
				if (!this.Border.Left.LineStyle.Equals(LineStyle.None) && num3 != 0f)
				{
					A_0.SetStrokeColor(color);
					A_0.SetLineWidth(num3);
					A_0.SetLineStyle(this.Border.Left.LineStyle);
					A_0.Write_m_(base.X + num3 / 2f, base.Y);
					A_0.Write_l_(base.X + num3 / 2f, base.Y + num6);
					A_0.Write_S();
				}
				if (!this.Border.Right.LineStyle.Equals(LineStyle.None) && num4 != 0f)
				{
					A_0.SetStrokeColor(color2);
					A_0.SetLineWidth(num4);
					A_0.SetLineStyle(this.Border.Right.LineStyle);
					A_0.Write_m_(base.X + num5, base.Y);
					A_0.Write_l_(base.X + num5, base.Y + num6);
					A_0.Write_S();
				}
				if (!this.Border.Top.LineStyle.Equals(LineStyle.None) && num != 0f)
				{
					A_0.SetStrokeColor(color3);
					A_0.SetLineWidth(num);
					A_0.SetLineStyle(this.Border.Top.LineStyle);
					A_0.Write_m_(base.X, base.Y + num / 2f);
					A_0.Write_l_(base.X + num5 + num4 / 2f, base.Y + num / 2f);
					A_0.Write_S();
				}
				if (!this.Border.Bottom.LineStyle.Equals(LineStyle.None) && num2 != 0f)
				{
					A_0.SetStrokeColor(color4);
					A_0.SetLineWidth(num2);
					A_0.SetLineStyle(this.Border.Bottom.LineStyle);
					A_0.Write_m_(base.X, base.Y + num6 + num / 2f);
					A_0.Write_l_(base.X + num5 + num4 / 2f, base.Y + num6 + num / 2f);
					A_0.Write_S();
				}
			}
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06004787 RID: 18311 RVA: 0x00250C20 File Offset: 0x0024FC20
		internal qy b()
		{
			return this.a;
		}

		// Token: 0x06004788 RID: 18312 RVA: 0x00250C38 File Offset: 0x0024FC38
		internal bool c()
		{
			return this.m;
		}

		// Token: 0x06004789 RID: 18313 RVA: 0x00250C50 File Offset: 0x0024FC50
		internal void a(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x0600478A RID: 18314 RVA: 0x00250C5C File Offset: 0x0024FC5C
		internal bool d()
		{
			return this.j;
		}

		// Token: 0x0600478B RID: 18315 RVA: 0x00250C74 File Offset: 0x0024FC74
		internal Row2 e()
		{
			return this.k;
		}

		// Token: 0x0600478C RID: 18316 RVA: 0x00250C8C File Offset: 0x0024FC8C
		internal void c(Row2 A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600478D RID: 18317 RVA: 0x00250C98 File Offset: 0x0024FC98
		internal int? f()
		{
			return this.n;
		}

		// Token: 0x0600478E RID: 18318 RVA: 0x00250CB0 File Offset: 0x0024FCB0
		internal int g()
		{
			return this.c;
		}

		// Token: 0x0600478F RID: 18319 RVA: 0x00250CC8 File Offset: 0x0024FCC8
		internal int h()
		{
			return this.d;
		}

		// Token: 0x06004790 RID: 18320 RVA: 0x00250CE0 File Offset: 0x0024FCE0
		internal int i()
		{
			return this.e;
		}

		// Token: 0x06004791 RID: 18321 RVA: 0x00250CF8 File Offset: 0x0024FCF8
		internal int j()
		{
			return this.f;
		}

		// Token: 0x06004792 RID: 18322 RVA: 0x00250D10 File Offset: 0x0024FD10
		internal override byte cb()
		{
			return 80;
		}

		// Token: 0x06004793 RID: 18323 RVA: 0x00250D24 File Offset: 0x0024FD24
		internal Table2 k()
		{
			return this.p;
		}

		// Token: 0x06004794 RID: 18324 RVA: 0x00250D3C File Offset: 0x0024FD3C
		internal void a(Table2 A_0)
		{
			this.p = A_0;
		}

		// Token: 0x0400272A RID: 10026
		private new qy a;

		// Token: 0x0400272B RID: 10027
		private float b;

		// Token: 0x0400272C RID: 10028
		private int c;

		// Token: 0x0400272D RID: 10029
		private new int d;

		// Token: 0x0400272E RID: 10030
		private int e;

		// Token: 0x0400272F RID: 10031
		private int f;

		// Token: 0x04002730 RID: 10032
		private bool g;

		// Token: 0x04002731 RID: 10033
		private bool h;

		// Token: 0x04002732 RID: 10034
		private Color i;

		// Token: 0x04002733 RID: 10035
		private bool j;

		// Token: 0x04002734 RID: 10036
		private Row2 k;

		// Token: 0x04002735 RID: 10037
		private int? l;

		// Token: 0x04002736 RID: 10038
		private bool m;

		// Token: 0x04002737 RID: 10039
		private int? n;

		// Token: 0x04002738 RID: 10040
		private new int? o;

		// Token: 0x04002739 RID: 10041
		private Table2 p;
	}
}
