using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200008C RID: 140
	internal class c4 : cx
	{
		// Token: 0x060006AF RID: 1711 RVA: 0x0005D67E File Offset: 0x0005C67E
		internal c4(ab6 A_0, abd A_1) : base(0, 0, 0, 0)
		{
			this.b = A_0;
			this.a = A_1;
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0005D6B0 File Offset: 0x0005C6B0
		internal override void a9(DocumentWriter A_0, int A_1)
		{
			if (this.a != null)
			{
				if (this.b != null && this.b.a() != null)
				{
					PdfPage a_ = this.b.a().h();
					int num = A_0.b(a_);
					for (int i = 0; i < A_0.Document.Pages.Count; i++)
					{
						if (num == A_0.GetPageObject(i + 1))
						{
							base.a6(i);
							break;
						}
					}
				}
				this.a.hz(A_0);
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0005D758 File Offset: 0x0005C758
		internal override bool bn()
		{
			return this.c;
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0005D770 File Offset: 0x0005C770
		internal override void bo(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0005D77C File Offset: 0x0005C77C
		internal override ab6 bl()
		{
			return this.b;
		}

		// Token: 0x0400038F RID: 911
		private abd a = null;

		// Token: 0x04000390 RID: 912
		private ab6 b = null;

		// Token: 0x04000391 RID: 913
		private bool c = false;
	}
}
