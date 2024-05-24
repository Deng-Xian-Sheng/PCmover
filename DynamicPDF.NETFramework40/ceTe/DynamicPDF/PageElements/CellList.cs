using System;
using System.Collections;
using System.ComponentModel;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200071F RID: 1823
	[Obsolete("This class is obsolete. Use Cell2List class instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CellList : IEnumerable
	{
		// Token: 0x060048B1 RID: 18609 RVA: 0x002581B6 File Offset: 0x002571B6
		internal CellList(Row A_0, int A_1)
		{
			this.e = A_0;
			this.c = new Cell[A_1];
		}

		// Token: 0x060048B2 RID: 18610 RVA: 0x002581DC File Offset: 0x002571DC
		public Cell Add(string text)
		{
			return this.Add(text, null, float.MinValue, null, null, 1, 1);
		}

		// Token: 0x060048B3 RID: 18611 RVA: 0x00258200 File Offset: 0x00257200
		public Cell Add(string text, int colSpan)
		{
			return this.Add(text, null, float.MinValue, null, null, colSpan, 1);
		}

		// Token: 0x060048B4 RID: 18612 RVA: 0x00258224 File Offset: 0x00257224
		public Cell Add(string text, Font font, float size)
		{
			return this.Add(text, font, size, null, null, 1, 1);
		}

		// Token: 0x060048B5 RID: 18613 RVA: 0x00258244 File Offset: 0x00257244
		public Cell Add(string text, Font font, float size, int colSpan)
		{
			return this.Add(text, font, size, null, null, colSpan, 1);
		}

		// Token: 0x060048B6 RID: 18614 RVA: 0x00258264 File Offset: 0x00257264
		public Cell Add(string text, Font font, float size, int colSpan, int rowSpan)
		{
			return this.Add(text, font, size, null, null, colSpan, rowSpan);
		}

		// Token: 0x060048B7 RID: 18615 RVA: 0x00258288 File Offset: 0x00257288
		public Cell Add(string text, int colSpan, int rowSpan)
		{
			return this.Add(text, null, float.MinValue, null, null, colSpan, rowSpan);
		}

		// Token: 0x060048B8 RID: 18616 RVA: 0x002582AC File Offset: 0x002572AC
		public Cell Add(string text, Font font, float size, Color textColor, Color backColor, int colSpan)
		{
			return this.Add(text, font, size, textColor, backColor, colSpan, 1);
		}

		// Token: 0x060048B9 RID: 18617 RVA: 0x002582D0 File Offset: 0x002572D0
		public Cell Add(string text, Font font, float size, Color textColor, Color backColor, int colSpan, int rowSpan)
		{
			if (colSpan <= 0)
			{
				colSpan = 1;
			}
			if (this.d == this.c.Length)
			{
				if (this.e.c().a.Count > this.c.Length)
				{
					Cell[] array = new Cell[this.e.c().a.Count];
					this.c.CopyTo(array, 0);
					this.c = array;
				}
				else
				{
					Cell[] array = new Cell[this.c.Length * 2];
					this.c.CopyTo(array, 0);
					this.c = array;
				}
			}
			Cell cell = new Cell(this.e, text, font, size, textColor, backColor, colSpan, rowSpan);
			this.c[this.d] = cell;
			this.d++;
			this.e.c().v = true;
			this.e.c().u = true;
			this.e.c().s = true;
			this.e.c().t = true;
			return cell;
		}

		// Token: 0x060048BA RID: 18618 RVA: 0x00258404 File Offset: 0x00257404
		public Cell Add(PageElement element)
		{
			return this.Add(element, 1, 1);
		}

		// Token: 0x060048BB RID: 18619 RVA: 0x00258420 File Offset: 0x00257420
		public Cell Add(PageElement element, int colSpan)
		{
			return this.Add(element, colSpan, 1);
		}

		// Token: 0x060048BC RID: 18620 RVA: 0x0025843C File Offset: 0x0025743C
		public Cell Add(PageElement element, int colSpan, int rowSpan)
		{
			if (colSpan <= 0)
			{
				colSpan = 1;
			}
			if (this.d == this.c.Length)
			{
				if (this.e.c().a.Count > this.c.Length)
				{
					Cell[] array = new Cell[this.e.c().a.Count];
					this.c.CopyTo(array, 0);
					this.c = array;
				}
				else
				{
					Cell[] array = new Cell[this.c.Length * 2];
					this.c.CopyTo(array, 0);
					this.c = array;
				}
			}
			Cell cell = new Cell(this.e, element, colSpan, rowSpan);
			this.c[this.d] = cell;
			this.d++;
			this.e.c().v = true;
			this.e.c().u = true;
			this.e.c().s = true;
			this.e.c().t = true;
			return cell;
		}

		// Token: 0x060048BD RID: 18621 RVA: 0x00258568 File Offset: 0x00257568
		public IEnumerator GetEnumerator()
		{
			Cell[] array = new Cell[this.c.Length];
			this.c.CopyTo(array, 0);
			return array.GetEnumerator();
		}

		// Token: 0x170004CA RID: 1226
		public Cell this[int index]
		{
			get
			{
				return this.c[index];
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060048BF RID: 18623 RVA: 0x002585B8 File Offset: 0x002575B8
		public int Count
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x040027B6 RID: 10166
		private const int a = 1;

		// Token: 0x040027B7 RID: 10167
		private const int b = 1;

		// Token: 0x040027B8 RID: 10168
		private Cell[] c;

		// Token: 0x040027B9 RID: 10169
		private int d = 0;

		// Token: 0x040027BA RID: 10170
		private Row e;
	}
}
