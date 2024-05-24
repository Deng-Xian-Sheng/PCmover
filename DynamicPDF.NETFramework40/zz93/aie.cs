using System;
using System.Collections.Specialized;
using System.Reflection;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200051E RID: 1310
	[DefaultMember("Item")]
	internal class aie
	{
		// Token: 0x06003501 RID: 13569 RVA: 0x001D3B7C File Offset: 0x001D2B7C
		internal aie(DocumentLayoutPartList A_0)
		{
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_0[i].m2())
				{
					if (this.a == null)
					{
						this.a = new HybridDictionary(A_0[i].m1().a());
					}
					this.a(A_0[i].m1());
				}
			}
		}

		// Token: 0x06003502 RID: 13570 RVA: 0x001D3C08 File Offset: 0x001D2C08
		private void a(akm A_0)
		{
			for (akm.a a = A_0.b(); a != null; a = a.b)
			{
				for (ahs.a a2 = a.a.a(); a2 != null; a2 = a2.b)
				{
					this.a.Add(a2.a, a2.a.md());
				}
			}
		}

		// Token: 0x06003503 RID: 13571 RVA: 0x001D3C74 File Offset: 0x001D2C74
		internal ahu a(ahr A_0)
		{
			return (ahu)this.a[A_0];
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x001D3C97 File Offset: 0x001D2C97
		internal void a(ahr A_0, ahu A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x06003505 RID: 13573 RVA: 0x001D3CA8 File Offset: 0x001D2CA8
		internal void b(ahr A_0)
		{
			this.a[A_0] = A_0.md();
		}

		// Token: 0x04001995 RID: 6549
		private HybridDictionary a = null;
	}
}
