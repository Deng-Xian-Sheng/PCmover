using System;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006E9 RID: 1769
	public class PdfOutline
	{
		// Token: 0x06004447 RID: 17479 RVA: 0x00233597 File Offset: 0x00232597
		internal PdfOutline(PdfDocument A_0, ab3 A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06004448 RID: 17480 RVA: 0x002335D8 File Offset: 0x002325D8
		public PdfOutlineList ChildOutlines
		{
			get
			{
				if (!this.c)
				{
					this.d = new PdfOutlineList(this.a, this.b.f());
					this.c = true;
				}
				return this.d;
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06004449 RID: 17481 RVA: 0x00233620 File Offset: 0x00232620
		public string Text
		{
			get
			{
				return this.b.d().kf();
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x0600444A RID: 17482 RVA: 0x00233644 File Offset: 0x00232644
		public TextStyle Style
		{
			get
			{
				return this.b.b();
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x0600444B RID: 17483 RVA: 0x00233664 File Offset: 0x00232664
		public bool Expanded
		{
			get
			{
				return this.b.c();
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600444C RID: 17484 RVA: 0x00233684 File Offset: 0x00232684
		public RgbColor Color
		{
			get
			{
				if (this.f == null)
				{
					this.f = this.b.h();
				}
				return this.f;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600444D RID: 17485 RVA: 0x002336C0 File Offset: 0x002326C0
		public Action Action
		{
			get
			{
				if (this.g == null)
				{
					this.g = this.b.i();
				}
				return this.g;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600444E RID: 17486 RVA: 0x002336FC File Offset: 0x002326FC
		public int TargetPageNumber
		{
			get
			{
				if (this.e == -2147483648)
				{
					this.e = this.a();
				}
				return this.e;
			}
		}

		// Token: 0x0600444F RID: 17487 RVA: 0x00233734 File Offset: 0x00232734
		internal ab3 b()
		{
			return this.b;
		}

		// Token: 0x06004450 RID: 17488 RVA: 0x0023374C File Offset: 0x0023274C
		private int a()
		{
			abd abd = this.b.j();
			if (abd != null)
			{
				if (abd.hy() == ag9.e)
				{
					abe abe = (abe)abd;
					if (abe.a(0).hy() == ag9.j)
					{
						ab6 a_ = (ab6)abe.a(0);
						aba aba = this.a.f().k8();
						PdfPage pdfPage = this.a.m().b(a_).h();
						int result = pdfPage.e() + 1;
						aba.lr();
						return result;
					}
				}
				else if (abd.hy() == ag9.c)
				{
					return this.a.a((ab7)abd);
				}
			}
			return -1;
		}

		// Token: 0x04002624 RID: 9764
		private PdfDocument a;

		// Token: 0x04002625 RID: 9765
		private ab3 b;

		// Token: 0x04002626 RID: 9766
		private bool c = false;

		// Token: 0x04002627 RID: 9767
		private PdfOutlineList d = null;

		// Token: 0x04002628 RID: 9768
		private int e = int.MinValue;

		// Token: 0x04002629 RID: 9769
		private RgbColor f = null;

		// Token: 0x0400262A RID: 9770
		private Action g = null;
	}
}
