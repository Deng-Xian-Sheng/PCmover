using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200041A RID: 1050
	internal class abc : c8
	{
		// Token: 0x06002BC4 RID: 11204 RVA: 0x001940DD File Offset: 0x001930DD
		internal abc(acb A_0) : base(A_0.f())
		{
			this.a = A_0;
		}

		// Token: 0x06002BC5 RID: 11205 RVA: 0x001940F8 File Offset: 0x001930F8
		internal override abp hx()
		{
			return this.a;
		}

		// Token: 0x06002BC6 RID: 11206 RVA: 0x00194110 File Offset: 0x00193110
		internal override void bw(DocumentWriter A_0)
		{
			if (A_0.q() != null)
			{
				this.a.b(A_0);
			}
			else if (this.a.g())
			{
				this.a.c(A_0);
			}
			else
			{
				A_0.WriteNull();
			}
		}

		// Token: 0x0400149D RID: 5277
		private acb a;
	}
}
