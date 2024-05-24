using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000297 RID: 663
	internal class rg : q8
	{
		// Token: 0x06001DB0 RID: 7600 RVA: 0x0012CA58 File Offset: 0x0012BA58
		internal rg(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x0012CAC0 File Offset: 0x0012BAC0
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x0012CAF0 File Offset: 0x0012BAF0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x0012CB24 File Offset: 0x0012BB24
		internal override object es(LayoutWriter A_0)
		{
			object obj = this.a.es(A_0);
			object obj2 = this.b.es(A_0);
			object result;
			if (obj is string || obj2 is string)
			{
				result = obj + obj2;
			}
			else
			{
				result = decimal.Add(q7.e(obj), q7.e(obj2));
			}
			return result;
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x0012CB90 File Offset: 0x0012BB90
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object obj = this.a.et(A_0, A_1);
			object obj2 = this.b.et(A_0, A_1);
			object result;
			if (obj is string || obj2 is string)
			{
				result = obj + obj2;
			}
			else
			{
				result = decimal.Add(q7.e(obj), q7.e(obj2));
			}
			return result;
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x0012CBFC File Offset: 0x0012BBFC
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x04000D3A RID: 3386
		private new q7 a;

		// Token: 0x04000D3B RID: 3387
		private new q7 b;
	}
}
