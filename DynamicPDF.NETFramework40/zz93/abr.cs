using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000429 RID: 1065
	internal class abr : c8
	{
		// Token: 0x06002C42 RID: 11330 RVA: 0x001962F3 File Offset: 0x001952F3
		internal abr(abd A_0) : base(A_0)
		{
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x00196308 File Offset: 0x00195308
		internal override Resource h3()
		{
			if (this.a == null)
			{
				this.a = this.a();
			}
			return this.a;
		}

		// Token: 0x06002C44 RID: 11332 RVA: 0x0019633C File Offset: 0x0019533C
		private abn a()
		{
			if (base.c() is abj)
			{
				abj abj = (abj)base.c();
				abk abk = abj.l();
				while (abk != null)
				{
					if (abk.a().j8() == 5479461)
					{
						int num = ((abu)abk.c()).j8();
						if (num != 1768372)
						{
							return new abn(base.c());
						}
						return new abo(abj);
					}
					else
					{
						abk = abk.d();
					}
				}
			}
			return new abn(base.c());
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x001963E8 File Offset: 0x001953E8
		internal override void bw(DocumentWriter A_0)
		{
			if (this.a == null)
			{
				this.a = new abn(base.c());
			}
			A_0.WriteReference(this.a);
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x00196424 File Offset: 0x00195424
		internal override void bv(DocumentWriter A_0)
		{
			if (this.a == null)
			{
				this.a = new abn(base.c());
			}
			A_0.WriteReferenceShallow(this.a);
		}

		// Token: 0x040014D5 RID: 5333
		private Resource a = null;
	}
}
