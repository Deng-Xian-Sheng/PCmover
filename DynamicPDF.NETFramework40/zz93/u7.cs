using System;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000328 RID: 808
	internal class u7 : q8
	{
		// Token: 0x0600231B RID: 8987 RVA: 0x0014EA6C File Offset: 0x0014DA6C
		internal u7(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != '"')
			{
				throw new DplxParseException("Invalid NetAppSettings variable detected.");
			}
			A_0.a(A_0.e() + 1);
			int num = A_0.e();
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

		// Token: 0x0600231C RID: 8988 RVA: 0x0014EB30 File Offset: 0x0014DB30
		internal override bool eq(LayoutWriter A_0)
		{
			return DocumentLayout.AppSettings[this.a] == null;
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x0014EB58 File Offset: 0x0014DB58
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return DocumentLayout.AppSettings[this.a] == null;
		}

		// Token: 0x0600231E RID: 8990 RVA: 0x0014EB80 File Offset: 0x0014DB80
		internal override object es(LayoutWriter A_0)
		{
			return DocumentLayout.AppSettings[this.a];
		}

		// Token: 0x0600231F RID: 8991 RVA: 0x0014EBA4 File Offset: 0x0014DBA4
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return DocumentLayout.AppSettings[this.a];
		}

		// Token: 0x06002320 RID: 8992 RVA: 0x0014EBC6 File Offset: 0x0014DBC6
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x06002321 RID: 8993 RVA: 0x0014EBCC File Offset: 0x0014DBCC
		internal static int a(char[] A_0, int A_1, StringBuilder A_2)
		{
			A_1++;
			while (A_0[A_1] <= ' ')
			{
				A_1++;
			}
			if (A_0[A_1] != '"')
			{
				throw new DplxParseException("Invalid NetAppSettings variable detected.");
			}
			A_1++;
			int num = A_1;
			while (A_0[A_1] != '"')
			{
				A_1++;
			}
			string key = new string(A_0, num, A_1 - num);
			object obj = DocumentLayout.AppSettings[key];
			if (obj != null)
			{
				A_2.Append(obj.ToString());
			}
			A_1++;
			while (A_0[A_1] <= ' ')
			{
				A_1++;
			}
			if (A_0[A_1] != ']')
			{
				throw new DplxParseException("Invalid NetAppSettings variable detected.");
			}
			A_1++;
			while (A_0[A_1] <= ' ')
			{
				A_1++;
			}
			return A_1;
		}

		// Token: 0x06002322 RID: 8994 RVA: 0x0014ECB8 File Offset: 0x0014DCB8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 11 && (A_0[A_1 + 5] == 't' || A_0[A_1 + 5] == 'T') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'i' || A_0[A_1 + 7] == 'I') && (A_0[A_1 + 8] == 'n' || A_0[A_1 + 8] == 'N') && (A_0[A_1 + 9] == 'g' || A_0[A_1 + 9] == 'G') && (A_0[A_1 + 10] == 's' || A_0[A_1 + 10] == 'S') && (A_0[A_1] == 'A' || A_0[A_1] == 'a') && (A_0[A_1 + 1] == 'p' || A_0[A_1 + 1] == 'P') && (A_0[A_1 + 2] == 'p' || A_0[A_1 + 2] == 'P') && (A_0[A_1 + 3] == 'S' || A_0[A_1 + 3] == 's') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E');
		}

		// Token: 0x04000F13 RID: 3859
		private new string a;
	}
}
