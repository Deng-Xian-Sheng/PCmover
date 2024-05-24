using System;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200032A RID: 810
	internal class u9 : q8
	{
		// Token: 0x06002326 RID: 8998 RVA: 0x0014F014 File Offset: 0x0014E014
		internal u9(w5 A_0)
		{
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() != '"')
			{
				throw new DplxParseException("Invalid ReportParameters variable detected.");
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

		// Token: 0x06002327 RID: 8999 RVA: 0x0014F0D8 File Offset: 0x0014E0D8
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			string text = A_0.Parameters[this.a].ToString();
			if (text != null)
			{
				A_1.a(text);
			}
		}

		// Token: 0x06002328 RID: 9000 RVA: 0x0014F110 File Offset: 0x0014E110
		internal override bool eq(LayoutWriter A_0)
		{
			return A_0.Parameters[this.a] == null;
		}

		// Token: 0x06002329 RID: 9001 RVA: 0x0014F138 File Offset: 0x0014E138
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return A_0.Parameters[this.a] == null;
		}

		// Token: 0x0600232A RID: 9002 RVA: 0x0014F160 File Offset: 0x0014E160
		internal override object es(LayoutWriter A_0)
		{
			return A_0.Parameters[this.a];
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x0014F184 File Offset: 0x0014E184
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return A_0.Parameters[this.a];
		}

		// Token: 0x0600232C RID: 9004 RVA: 0x0014F1A7 File Offset: 0x0014E1A7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
		}

		// Token: 0x0600232D RID: 9005 RVA: 0x0014F1AC File Offset: 0x0014E1AC
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
			string text = DocumentLayout.ConnectionStrings[new string(A_0, num, A_1 - num)].ToString();
			if (text != null)
			{
				A_2.Append(text);
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

		// Token: 0x0600232E RID: 9006 RVA: 0x0014F288 File Offset: 0x0014E288
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 10 && (A_0[A_1] == 'P' || A_0[A_1] == 'p') && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 'a' || A_0[A_1 + 3] == 'A') && (A_0[A_1 + 4] == 'm' || A_0[A_1 + 4] == 'M') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E') && (A_0[A_1 + 8] == 'r' || A_0[A_1 + 8] == 'R') && (A_0[A_1 + 9] == 's' || A_0[A_1 + 9] == 'S');
		}

		// Token: 0x04000F14 RID: 3860
		private new string a;
	}
}
