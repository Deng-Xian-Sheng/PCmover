using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000290 RID: 656
	internal class q9 : q8
	{
		// Token: 0x06001D6E RID: 7534 RVA: 0x0012BA30 File Offset: 0x0012AA30
		internal q9(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.a = A_0.h();
			}
			else
			{
				this.a = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid And function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.b = A_0.h();
			}
			else
			{
				this.b = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid And function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x0012BB10 File Offset: 0x0012AB10
		internal q9(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x0012BB78 File Offset: 0x0012AB78
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x0012BBA8 File Offset: 0x0012ABA8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x0012BBDC File Offset: 0x0012ABDC
		internal override object es(LayoutWriter A_0)
		{
			object obj = this.a.es(A_0);
			object obj2 = this.b.es(A_0);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) & Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) & Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x0012BC50 File Offset: 0x0012AC50
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object obj = this.a.et(A_0, A_1);
			object obj2 = this.b.et(A_0, A_1);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) & Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) & Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x0012BCC3 File Offset: 0x0012ACC3
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x0012BCE4 File Offset: 0x0012ACE4
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'n' || A_0[A_1 + 1] == 'N') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x04000D31 RID: 3377
		private new q7 a;

		// Token: 0x04000D32 RID: 3378
		private new q7 b;
	}
}
