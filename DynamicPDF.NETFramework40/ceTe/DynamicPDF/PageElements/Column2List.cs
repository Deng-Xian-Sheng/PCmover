using System;
using System.Collections;
using System.Collections.Generic;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070B RID: 1803
	public class Column2List : IEnumerable
	{
		// Token: 0x06004704 RID: 18180 RVA: 0x00245BB2 File Offset: 0x00244BB2
		internal Column2List()
		{
		}

		// Token: 0x06004705 RID: 18181 RVA: 0x00245BC8 File Offset: 0x00244BC8
		internal void a(qy A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004706 RID: 18182 RVA: 0x00245BD2 File Offset: 0x00244BD2
		internal void a(Column2 A_0)
		{
			this.a.Add(A_0);
		}

		// Token: 0x06004707 RID: 18183 RVA: 0x00245BE4 File Offset: 0x00244BE4
		public Column2 Add(float width)
		{
			Column2 column = new Column2(this.b, width);
			this.a.Add(column);
			this.b.a(true);
			this.b.c(true);
			this.b.d(true);
			this.b.b(true);
			return column;
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06004708 RID: 18184 RVA: 0x00245C48 File Offset: 0x00244C48
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x17000480 RID: 1152
		public Column2 this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x0600470A RID: 18186 RVA: 0x00245C88 File Offset: 0x00244C88
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x04002718 RID: 10008
		private List<Column2> a = new List<Column2>();

		// Token: 0x04002719 RID: 10009
		private qy b;
	}
}
