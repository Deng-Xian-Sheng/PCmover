using System;
using System.Collections.Specialized;
using System.Reflection;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002EE RID: 750
	[DefaultMember("Item")]
	internal class tl
	{
		// Token: 0x0600216A RID: 8554 RVA: 0x00145AA8 File Offset: 0x00144AA8
		internal tl(DocumentLayoutPartList A_0)
		{
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_0[i].ey())
				{
					if (this.a == null)
					{
						this.a = new HybridDictionary(A_0[i].ex().a());
					}
					this.a(A_0[i].ex());
				}
			}
		}

		// Token: 0x0600216B RID: 8555 RVA: 0x00145B34 File Offset: 0x00144B34
		private void a(vj A_0)
		{
			for (vj.a a = A_0.b(); a != null; a = a.b)
			{
				for (sz.a a2 = a.a.a(); a2 != null; a2 = a2.b)
				{
					this.a.Add(a2.a, a2.a.fn());
				}
			}
		}

		// Token: 0x0600216C RID: 8556 RVA: 0x00145BA0 File Offset: 0x00144BA0
		internal s1 a(sy A_0)
		{
			return (s1)this.a[A_0];
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x00145BC3 File Offset: 0x00144BC3
		internal void a(sy A_0, s1 A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x00145BD4 File Offset: 0x00144BD4
		internal void b(sy A_0)
		{
			this.a[A_0] = A_0.fn();
		}

		// Token: 0x04000EA4 RID: 3748
		private HybridDictionary a = null;
	}
}
