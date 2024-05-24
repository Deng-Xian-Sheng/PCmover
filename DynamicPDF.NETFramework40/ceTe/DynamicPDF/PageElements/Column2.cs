using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070A RID: 1802
	public class Column2
	{
		// Token: 0x060046FC RID: 18172 RVA: 0x002459F5 File Offset: 0x002449F5
		internal Column2()
		{
		}

		// Token: 0x060046FD RID: 18173 RVA: 0x00245A07 File Offset: 0x00244A07
		internal Column2(qy A_0, float A_1)
		{
			this.b = A_0;
			this.a = A_1;
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x060046FE RID: 18174 RVA: 0x00245A28 File Offset: 0x00244A28
		public float Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x060046FF RID: 18175 RVA: 0x00245A40 File Offset: 0x00244A40
		public CellDefault CellDefault
		{
			get
			{
				if (this.d == null)
				{
					this.d = new CellDefault(this.b);
				}
				return this.d;
			}
		}

		// Token: 0x06004700 RID: 18176 RVA: 0x00245A7C File Offset: 0x00244A7C
		internal CellDefault a()
		{
			return this.d;
		}

		// Token: 0x06004701 RID: 18177 RVA: 0x00245A94 File Offset: 0x00244A94
		internal int b()
		{
			return this.c;
		}

		// Token: 0x06004702 RID: 18178 RVA: 0x00245AAC File Offset: 0x00244AAC
		internal void a(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06004703 RID: 18179 RVA: 0x00245AB8 File Offset: 0x00244AB8
		internal Column2 a(qy A_0)
		{
			Column2 column = new Column2();
			column.a = this.a;
			column.b = A_0;
			column.c = this.c;
			column.d = new CellDefault(A_0);
			if (this.d != null && this.d.a() != null)
			{
				column.d.a(this.d.a().m());
			}
			if (this.d != null && this.d.b() != null)
			{
				column.d.a(this.d.b().b(A_0));
			}
			if (this.d != null && this.d.c() != null)
			{
				column.d.a(this.d.c().a(A_0));
			}
			return column;
		}

		// Token: 0x04002714 RID: 10004
		private float a;

		// Token: 0x04002715 RID: 10005
		private qy b;

		// Token: 0x04002716 RID: 10006
		private int c = 1;

		// Token: 0x04002717 RID: 10007
		private CellDefault d;
	}
}
