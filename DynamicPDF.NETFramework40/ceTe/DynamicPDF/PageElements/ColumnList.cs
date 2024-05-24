using System;
using System.Collections;
using System.ComponentModel;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000722 RID: 1826
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use Column2List class instead.", false)]
	public class ColumnList : IEnumerable
	{
		// Token: 0x060048E3 RID: 18659 RVA: 0x00258CDA File Offset: 0x00257CDA
		internal ColumnList()
		{
		}

		// Token: 0x060048E4 RID: 18660 RVA: 0x00258CF0 File Offset: 0x00257CF0
		internal void a(acy A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060048E5 RID: 18661 RVA: 0x00258CFC File Offset: 0x00257CFC
		public Column Add(float width)
		{
			Column column = new Column(width);
			this.a.Add(column);
			this.b.s = true;
			this.b.u = true;
			this.b.v = true;
			this.b.t = true;
			return column;
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060048E6 RID: 18662 RVA: 0x00258D54 File Offset: 0x00257D54
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x170004D6 RID: 1238
		public Column this[int index]
		{
			get
			{
				return (Column)this.a[index];
			}
		}

		// Token: 0x060048E8 RID: 18664 RVA: 0x00258D98 File Offset: 0x00257D98
		public IEnumerator GetEnumerator()
		{
			return this.a.GetEnumerator();
		}

		// Token: 0x040027CA RID: 10186
		private ArrayList a = new ArrayList();

		// Token: 0x040027CB RID: 10187
		private acy b;
	}
}
