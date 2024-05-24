using System;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006EA RID: 1770
	public class PdfOutlineList
	{
		// Token: 0x06004451 RID: 17489 RVA: 0x00233830 File Offset: 0x00232830
		internal PdfOutlineList(PdfDocument A_0, ab3 A_1)
		{
			for (ab3 ab = A_1; ab != null; ab = ab.g())
			{
				this.a(A_0, ab);
			}
		}

		// Token: 0x170003B9 RID: 953
		public PdfOutline this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06004453 RID: 17491 RVA: 0x00233894 File Offset: 0x00232894
		public int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06004454 RID: 17492 RVA: 0x002338AC File Offset: 0x002328AC
		private void a(PdfDocument A_0, ab3 A_1)
		{
			if (this.a == null)
			{
				this.a = new PdfOutline[4];
			}
			else if (this.b == this.a.Length)
			{
				PdfOutline[] array = this.a;
				this.a = new PdfOutline[this.b * 2];
				array.CopyTo(this.a, 0);
			}
			this.a[this.b++] = new PdfOutline(A_0, A_1);
		}

		// Token: 0x0400262B RID: 9771
		private PdfOutline[] a = null;

		// Token: 0x0400262C RID: 9772
		private int b = 0;
	}
}
