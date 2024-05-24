using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005AC RID: 1452
	internal abstract class al7
	{
		// Token: 0x060039C5 RID: 14789 RVA: 0x001F1971 File Offset: 0x001F0971
		internal al7()
		{
		}

		// Token: 0x060039C6 RID: 14790
		internal abstract bool ne(amp A_0, PageWriter A_1);

		// Token: 0x060039C7 RID: 14791
		internal abstract bool ng(amp A_0, DocumentWriter A_1, int A_2);

		// Token: 0x060039C8 RID: 14792 RVA: 0x001F197C File Offset: 0x001F097C
		internal virtual bool nf(am1 A_0, PageWriter A_1)
		{
			return false;
		}

		// Token: 0x060039C9 RID: 14793 RVA: 0x001F1990 File Offset: 0x001F0990
		internal static al7 a(char[] A_0, int A_1, int A_2)
		{
			while (A_0[A_1] <= ' ')
			{
				A_1++;
			}
			if (A_2 - A_1 < 8)
			{
				throw new DlexParseException("Invalid layout condition in a template, header or footer.");
			}
			al7 result;
			if ((A_0[A_1] == 'F' || A_0[A_1] == 'f') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'P' || A_0[A_1 + 5] == 'p') && (A_0[A_1 + 6] == 'a' || A_0[A_1 + 6] == 'A') && (A_0[A_1 + 7] == 'g' || A_0[A_1 + 7] == 'G') && (A_0[A_1 + 8] == 'e' || A_0[A_1 + 8] == 'E') && A_0[A_1 + 9] < 'A')
			{
				result = new amd();
			}
			else if ((A_0[A_1] == 'L' || A_0[A_1] == 'l') && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'P' || A_0[A_1 + 4] == 'p') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E') && A_0[A_1 + 8] < 'A')
			{
				result = new ame();
			}
			else if ((A_0[A_1] == 'M' || A_0[A_1] == 'm') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'd' || A_0[A_1 + 3] == 'D') && (A_0[A_1 + 4] == 'l' || A_0[A_1 + 4] == 'L') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'P' || A_0[A_1 + 6] == 'p') && (A_0[A_1 + 7] == 'a' || A_0[A_1 + 7] == 'A') && (A_0[A_1 + 8] == 'g' || A_0[A_1 + 8] == 'G') && (A_0[A_1 + 9] == 'e' || A_0[A_1 + 9] == 'E') && A_0[A_1 + 10] < 'A')
			{
				result = new amf();
			}
			else
			{
				if ((A_0[A_1] != 'D' && A_0[A_1] != 'd') || (A_0[A_1 + 1] != 'o' && A_0[A_1 + 1] != 'O') || (A_0[A_1 + 2] != 'c' && A_0[A_1 + 2] != 'C') || (A_0[A_1 + 3] != 'u' && A_0[A_1 + 3] != 'U') || (A_0[A_1 + 4] != 'm' && A_0[A_1 + 4] != 'M') || (A_0[A_1 + 5] != 'e' && A_0[A_1 + 5] != 'E') || (A_0[A_1 + 6] != 'n' && A_0[A_1 + 6] != 'N') || (A_0[A_1 + 7] != 't' && A_0[A_1 + 7] != 'T') || A_0[A_1 + 8] != '.')
				{
					throw new DlexParseException("Invalid layout condition in a template, header or footer.");
				}
				result = al7.a(A_0, A_1 + 9);
			}
			return result;
		}

		// Token: 0x060039CA RID: 14794 RVA: 0x001F1CD8 File Offset: 0x001F0CD8
		private static al7 a(char[] A_0, int A_1)
		{
			al7 result;
			if ((A_0[A_1] == 'E' || A_0[A_1] == 'e') && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 'P' || A_0[A_1 + 4] == 'p') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E'))
			{
				result = new al8();
			}
			else
			{
				if ((A_0[A_1] != 'O' && A_0[A_1] != 'o') || (A_0[A_1 + 1] != 'd' && A_0[A_1 + 1] != 'D') || (A_0[A_1 + 2] != 'd' && A_0[A_1 + 2] != 'D') || (A_0[A_1 + 3] != 'P' && A_0[A_1 + 3] != 'p') || (A_0[A_1 + 4] != 'a' && A_0[A_1 + 4] != 'A') || (A_0[A_1 + 5] != 'g' && A_0[A_1 + 5] != 'G') || (A_0[A_1 + 6] != 'e' && A_0[A_1 + 6] != 'E'))
				{
					throw new DlexParseException("Invalid document layout condition.");
				}
				result = new amc();
			}
			return result;
		}
	}
}
