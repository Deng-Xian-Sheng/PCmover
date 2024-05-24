using System;
using System.Text;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000329 RID: 809
	internal class u8
	{
		// Token: 0x06002323 RID: 8995 RVA: 0x0014EDAC File Offset: 0x0014DDAC
		private u8()
		{
		}

		// Token: 0x06002324 RID: 8996 RVA: 0x0014EDB8 File Offset: 0x0014DDB8
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

		// Token: 0x06002325 RID: 8997 RVA: 0x0014EE94 File Offset: 0x0014DE94
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 17 && (A_0[A_1 + 5] == 'c' || A_0[A_1 + 5] == 'C') && (A_0[A_1 + 6] == 't' || A_0[A_1 + 6] == 'T') && (A_0[A_1 + 7] == 'i' || A_0[A_1 + 7] == 'I') && (A_0[A_1 + 8] == 'o' || A_0[A_1 + 8] == 'O') && (A_0[A_1 + 9] == 'n' || A_0[A_1 + 9] == 'N') && (A_0[A_1 + 10] == 'S' || A_0[A_1 + 10] == 's') && (A_0[A_1 + 11] == 't' || A_0[A_1 + 11] == 'T') && (A_0[A_1 + 12] == 'r' || A_0[A_1 + 12] == 'R') && (A_0[A_1 + 13] == 'i' || A_0[A_1 + 13] == 'I') && (A_0[A_1 + 14] == 'n' || A_0[A_1 + 14] == 'N') && (A_0[A_1 + 15] == 'g' || A_0[A_1 + 15] == 'G') && (A_0[A_1 + 16] == 's' || A_0[A_1 + 16] == 'S') && (A_0[A_1] == 'C' || A_0[A_1] == 'c') && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E');
		}
	}
}
