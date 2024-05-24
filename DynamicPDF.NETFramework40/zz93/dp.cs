using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020000A2 RID: 162
	internal class dp
	{
		// Token: 0x060007C0 RID: 1984 RVA: 0x0006F592 File Offset: 0x0006E592
		internal dp()
		{
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0006F5A8 File Offset: 0x0006E5A8
		internal void a(abe A_0)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				if (this.a == null)
				{
					this.a = new ArrayList();
				}
				this.a.Add((ab6)A_0.a(i));
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0006F600 File Offset: 0x0006E600
		internal void a(DocumentWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				((ab6)this.a[i]).hz(A_0);
			}
		}

		// Token: 0x04000439 RID: 1081
		private ArrayList a = new ArrayList();
	}
}
