using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006A3 RID: 1699
	public class OutlineList : IEnumerable
	{
		// Token: 0x0600407B RID: 16507 RVA: 0x00221F07 File Offset: 0x00220F07
		internal OutlineList()
		{
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600407C RID: 16508 RVA: 0x00221F2C File Offset: 0x00220F2C
		public int Count
		{
			get
			{
				return this.b.Count;
			}
		}

		// Token: 0x17000271 RID: 625
		public Outline this[int index]
		{
			get
			{
				return (Outline)this.b[index];
			}
		}

		// Token: 0x0600407E RID: 16510 RVA: 0x00221F70 File Offset: 0x00220F70
		public Outline Add(string text)
		{
			return this.Add(text, null);
		}

		// Token: 0x0600407F RID: 16511 RVA: 0x00221F8C File Offset: 0x00220F8C
		public Outline Add(string text, Action action)
		{
			Outline outline = new Outline(text, action);
			this.a(outline);
			return outline;
		}

		// Token: 0x06004080 RID: 16512 RVA: 0x00221FB0 File Offset: 0x00220FB0
		public Outline Add(PdfOutline outline)
		{
			return this.Add(outline, true);
		}

		// Token: 0x06004081 RID: 16513 RVA: 0x00221FCC File Offset: 0x00220FCC
		public Outline Add(PdfOutline outline, bool addChildOutline)
		{
			this.a = true;
			ab3 ab = outline.b();
			aat aat = new aat(ab);
			this.a(aat);
			if (addChildOutline && ab.f() != null)
			{
				aat.ChildOutlines.Add(outline.ChildOutlines);
			}
			return aat;
		}

		// Token: 0x06004082 RID: 16514 RVA: 0x00222024 File Offset: 0x00221024
		public void Add(PdfOutlineList outlines)
		{
			this.a = true;
			for (int i = 0; i < outlines.Count; i++)
			{
				this.Add(outlines[i], true);
			}
		}

		// Token: 0x06004083 RID: 16515 RVA: 0x00222060 File Offset: 0x00221060
		public IEnumerator GetEnumerator()
		{
			return this.b.GetEnumerator();
		}

		// Token: 0x06004084 RID: 16516 RVA: 0x00222080 File Offset: 0x00221080
		internal bool a()
		{
			return this.a;
		}

		// Token: 0x06004085 RID: 16517 RVA: 0x00222098 File Offset: 0x00221098
		internal int b()
		{
			return this.c;
		}

		// Token: 0x06004086 RID: 16518 RVA: 0x002220B0 File Offset: 0x002210B0
		internal void a(DocumentWriter A_0)
		{
			foreach (object obj in this.b)
			{
				Outline outline = (Outline)obj;
				outline.a(A_0);
			}
		}

		// Token: 0x06004087 RID: 16519 RVA: 0x00222118 File Offset: 0x00221118
		internal void a(ref int A_0)
		{
			this.c = A_0;
			foreach (object obj in this.b)
			{
				Outline outline = (Outline)obj;
				outline.a(ref A_0);
			}
		}

		// Token: 0x06004088 RID: 16520 RVA: 0x00222188 File Offset: 0x00221188
		internal void a(b3 A_0)
		{
			foreach (object obj in this.b)
			{
				Outline outline = (Outline)obj;
				outline.a(A_0);
			}
		}

		// Token: 0x06004089 RID: 16521 RVA: 0x002221F0 File Offset: 0x002211F0
		internal int c()
		{
			int num = 0;
			foreach (object obj in this.b)
			{
				Outline outline = (Outline)obj;
				num += outline.b();
			}
			return num;
		}

		// Token: 0x0600408A RID: 16522 RVA: 0x00222268 File Offset: 0x00221268
		internal void a(ab3 A_0)
		{
			aat aat = new aat(A_0);
			this.a(aat);
			if (A_0.f() != null)
			{
				aat.ChildOutlines.a(A_0.f());
			}
			for (ab3 ab = A_0.g(); ab != null; ab = ab.g())
			{
				aat aat2 = new aat(ab);
				this.a(aat2);
				if (ab.f() != null)
				{
					aat2.ChildOutlines.a(ab.f());
				}
			}
		}

		// Token: 0x0600408B RID: 16523 RVA: 0x002222F1 File Offset: 0x002212F1
		private void a(Outline A_0)
		{
			this.a = true;
			A_0.a(this, this.b.Count);
			this.b.Add(A_0);
		}

		// Token: 0x0600408C RID: 16524 RVA: 0x0022231B File Offset: 0x0022131B
		private void a(aat A_0)
		{
			A_0.a(this, this.b.Count);
			this.b.Add(A_0);
		}

		// Token: 0x040023CD RID: 9165
		private bool a = false;

		// Token: 0x040023CE RID: 9166
		private ArrayList b = new ArrayList();

		// Token: 0x040023CF RID: 9167
		private int c = 0;
	}
}
