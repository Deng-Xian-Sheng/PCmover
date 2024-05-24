using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000094 RID: 148
	internal class db
	{
		// Token: 0x0600072C RID: 1836 RVA: 0x000622A0 File Offset: 0x000612A0
		internal db(abe A_0)
		{
			this.a = new da[A_0.a()];
			for (int i = 0; i < A_0.a(); i++)
			{
				if (A_0.a(i).hy() == ag9.j)
				{
					this.a[i] = ((ab6)A_0.a(i)).a().g();
				}
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00062318 File Offset: 0x00061318
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteName(66);
			A_0.WriteArrayOpen();
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i] != null)
				{
					this.a[i].a().e().bw(A_0);
				}
			}
			A_0.WriteArrayClose();
		}

		// Token: 0x040003D3 RID: 979
		private da[] a;
	}
}
