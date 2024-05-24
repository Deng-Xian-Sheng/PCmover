using System;
using System.Collections;
using System.Collections.Generic;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000708 RID: 1800
	public class Cell2List : IEnumerable
	{
		// Token: 0x060046DE RID: 18142 RVA: 0x00244FF9 File Offset: 0x00243FF9
		internal Cell2List(Row2 A_0, int A_1)
		{
			this.e = A_0;
			this.c = new List<Cell2>(A_1);
		}

		// Token: 0x060046DF RID: 18143 RVA: 0x00245020 File Offset: 0x00244020
		public Cell2 Add(string text)
		{
			return this.Add(text, null, null, null, null, 1, 1);
		}

		// Token: 0x060046E0 RID: 18144 RVA: 0x00245048 File Offset: 0x00244048
		public Cell2 Add(string text, int colSpan)
		{
			return this.Add(text, null, null, null, null, colSpan, 1);
		}

		// Token: 0x060046E1 RID: 18145 RVA: 0x00245070 File Offset: 0x00244070
		public Cell2 Add(string text, Font font, float? fontSize)
		{
			return this.Add(text, font, fontSize, null, null, 1, 1);
		}

		// Token: 0x060046E2 RID: 18146 RVA: 0x00245090 File Offset: 0x00244090
		public Cell2 Add(string text, Font font, float? fontSize, int colSpan)
		{
			return this.Add(text, font, fontSize, null, null, colSpan, 1);
		}

		// Token: 0x060046E3 RID: 18147 RVA: 0x002450B0 File Offset: 0x002440B0
		public Cell2 Add(string text, Font font, float? fontSize, int colSpan, int rowSpan)
		{
			return this.Add(text, font, fontSize, null, null, colSpan, rowSpan);
		}

		// Token: 0x060046E4 RID: 18148 RVA: 0x002450D4 File Offset: 0x002440D4
		public Cell2 Add(string text, int colSpan, int rowSpan)
		{
			return this.Add(text, null, null, null, null, colSpan, rowSpan);
		}

		// Token: 0x060046E5 RID: 18149 RVA: 0x002450FC File Offset: 0x002440FC
		public Cell2 Add(string text, Font font, float? fontSize, Color textColor, Color backColor, int colSpan)
		{
			return this.Add(text, font, fontSize, textColor, backColor, colSpan, 1);
		}

		// Token: 0x060046E6 RID: 18150 RVA: 0x00245120 File Offset: 0x00244120
		public Cell2 Add(string text, Font font, float? fontSize, Color textColor, Color backColor, int colSpan, int rowSpan)
		{
			if (colSpan <= 0)
			{
				colSpan = 1;
			}
			if (this.d == this.c.Count)
			{
				if (this.e.e().c().Count > this.c.Count)
				{
					Cell2[] array = new Cell2[this.e.e().c().Count];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
				else
				{
					Cell2[] array = new Cell2[this.c.Count * 2];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
			}
			Cell2 cell = new Cell2(this.e, text, font, fontSize, textColor, backColor, colSpan, rowSpan);
			this.c[this.d] = cell;
			this.d++;
			this.e.e().d(true);
			this.e.e().c(true);
			this.e.e().a(true);
			this.e.e().b(true);
			this.e.e().a(null);
			return cell;
		}

		// Token: 0x060046E7 RID: 18151 RVA: 0x00245284 File Offset: 0x00244284
		public Cell2 Add(PageElement element)
		{
			return this.Add(element, 1, 1);
		}

		// Token: 0x060046E8 RID: 18152 RVA: 0x002452A0 File Offset: 0x002442A0
		public Cell2 Add(PageElement element, int colSpan)
		{
			return this.Add(element, colSpan, 1);
		}

		// Token: 0x060046E9 RID: 18153 RVA: 0x002452BC File Offset: 0x002442BC
		public Cell2 Add(PageElement element, int colSpan, int rowSpan)
		{
			if (colSpan <= 0)
			{
				colSpan = 1;
			}
			if (this.d == this.c.Count)
			{
				if (this.e.e().c().Count > this.c.Count)
				{
					Cell2[] array = new Cell2[this.e.e().c().Count];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
				else
				{
					Cell2[] array = new Cell2[this.c.Count * 2];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
			}
			Cell2 cell = new Cell2(this.e, element, colSpan, rowSpan);
			this.c[this.d] = cell;
			this.d++;
			this.e.e().d(true);
			this.e.e().c(true);
			this.e.e().a(true);
			this.e.e().b(true);
			this.e.e().a(null);
			return cell;
		}

		// Token: 0x060046EA RID: 18154 RVA: 0x00245414 File Offset: 0x00244414
		internal Cell2 a(Cell2 A_0, bool A_1)
		{
			if (this.d == this.c.Count)
			{
				if (this.e.e().c().Count > this.c.Count)
				{
					Cell2[] array = new Cell2[this.e.e().c().Count];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
				else
				{
					Cell2[] array = new Cell2[this.c.Count * 2];
					this.c.CopyTo(array, 0);
					this.c = new List<Cell2>(array);
				}
			}
			Cell2 cell;
			if (A_1)
			{
				if (A_0.Element != null)
				{
					cell = new Cell2(this.e, null, A_0.ColumnSpan, A_0.RowSpan);
				}
				else
				{
					cell = new Cell2(this.e, null, null, null, null, A_0.BackgroundColor, A_0.ColumnSpan, A_0.RowSpan);
				}
			}
			else if (A_0.Element == null)
			{
				cell = new Cell2(this.e, A_0.Text, A_0.Font, A_0.FontSize, A_0.TextColor, A_0.BackgroundColor, A_0.ColumnSpan, A_0.RowSpan);
			}
			else
			{
				cell = new Cell2(this.e, A_0.Element, A_0.ColumnSpan, A_0.RowSpan);
			}
			cell.e(A_0.ColumnIndex);
			cell.f(A_0.u());
			cell.b(A_0.Width);
			cell.Splittable = A_0.Splittable;
			cell.b(A_0.e());
			cell.c(A_0.k());
			this.c[this.d] = cell;
			this.d++;
			return cell;
		}

		// Token: 0x060046EB RID: 18155 RVA: 0x00245610 File Offset: 0x00244610
		public IEnumerator GetEnumerator()
		{
			Cell2[] array = new Cell2[this.c.Count];
			this.c.CopyTo(array, 0);
			return array.GetEnumerator();
		}

		// Token: 0x17000478 RID: 1144
		public Cell2 this[int index]
		{
			get
			{
				return this.c[index];
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x060046ED RID: 18157 RVA: 0x00245668 File Offset: 0x00244668
		public int Count
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x060046EE RID: 18158 RVA: 0x00245680 File Offset: 0x00244680
		internal void a(Cell2 A_0)
		{
			this.c.Add(A_0);
			this.d++;
		}

		// Token: 0x0400270B RID: 9995
		private const int a = 1;

		// Token: 0x0400270C RID: 9996
		private const int b = 1;

		// Token: 0x0400270D RID: 9997
		private List<Cell2> c;

		// Token: 0x0400270E RID: 9998
		private int d = 0;

		// Token: 0x0400270F RID: 9999
		private Row2 e;
	}
}
