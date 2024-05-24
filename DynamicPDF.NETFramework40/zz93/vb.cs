using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200032C RID: 812
	internal class vb : q8
	{
		// Token: 0x06002336 RID: 9014 RVA: 0x0014F60C File Offset: 0x0014E60C
		internal vb(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != '"')
			{
				throw new DplxParseException("Invalid Stored Procedure Parameters detected.");
			}
			A_0.a(A_0.e() + 1);
			int num = A_0.e();
			A_0.t();
			this.b = new string(A_0.d(), num, A_0.e() - num);
			A_0.a(A_0.e() + 1);
			num = A_0.e();
			A_0.r();
			this.a = new string(A_0.d(), num, A_0.e() - num);
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != ']')
			{
				throw new DplxParseException("Invalid NetAppSettings variable detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002337 RID: 9015 RVA: 0x0014F705 File Offset: 0x0014E705
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			A_1.a(this.a(A_0).ToString());
		}

		// Token: 0x06002338 RID: 9016 RVA: 0x0014F71C File Offset: 0x0014E71C
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a(A_0) == null;
		}

		// Token: 0x06002339 RID: 9017 RVA: 0x0014F738 File Offset: 0x0014E738
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a(A_0) == null;
		}

		// Token: 0x0600233A RID: 9018 RVA: 0x0014F754 File Offset: 0x0014E754
		internal override object es(LayoutWriter A_0)
		{
			return this.a(A_0);
		}

		// Token: 0x0600233B RID: 9019 RVA: 0x0014F770 File Offset: 0x0014E770
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return this.a(A_0);
		}

		// Token: 0x0600233C RID: 9020 RVA: 0x0014F78C File Offset: 0x0014E78C
		internal object a(LayoutWriter A_0)
		{
			RecordSet recordSet = A_0.RecordSets[this.b];
			if (recordSet == null)
			{
				throw new ReportWriterException("The " + this.b + " recordSet does not exist.");
			}
			return ((DataReaderRecordSet)recordSet).a(this.a);
		}

		// Token: 0x0600233D RID: 9021 RVA: 0x0014F7E7 File Offset: 0x0014E7E7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x0600233E RID: 9022 RVA: 0x0014F7EC File Offset: 0x0014E7EC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 12 && (A_0[A_1] == 's' || A_0[A_1] == 'S') && (A_0[A_1 + 1] == 'p' || A_0[A_1 + 1] == 'P') && (A_0[A_1 + 2] == 'P' || A_0[A_1 + 2] == 'p') && (A_0[A_1 + 3] == 'a' || A_0[A_1 + 3] == 'A') && (A_0[A_1 + 4] == 'r' || A_0[A_1 + 4] == 'R') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'm' || A_0[A_1 + 6] == 'M') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E') && (A_0[A_1 + 8] == 't' || A_0[A_1 + 8] == 'T') && (A_0[A_1 + 9] == 'e' || A_0[A_1 + 9] == 'E') && (A_0[A_1 + 10] == 'r' || A_0[A_1 + 10] == 'R') && (A_0[A_1 + 11] == 's' || A_0[A_1 + 11] == 'S');
		}

		// Token: 0x04000F18 RID: 3864
		private new string a;

		// Token: 0x04000F19 RID: 3865
		private new string b;
	}
}
