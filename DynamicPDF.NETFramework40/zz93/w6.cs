using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000373 RID: 883
	internal abstract class w6
	{
		// Token: 0x060025B7 RID: 9655 RVA: 0x001612BE File Offset: 0x001602BE
		internal w6()
		{
		}

		// Token: 0x060025B8 RID: 9656
		internal abstract bool f3(rs A_0, PageWriter A_1);

		// Token: 0x060025B9 RID: 9657
		internal abstract bool f5(rs A_0, DocumentWriter A_1, int A_2);

		// Token: 0x060025BA RID: 9658 RVA: 0x001612CC File Offset: 0x001602CC
		internal virtual bool f4(xs A_0, PageWriter A_1)
		{
			return false;
		}

		// Token: 0x060025BB RID: 9659 RVA: 0x001612E0 File Offset: 0x001602E0
		internal static w6 a(char[] A_0, int A_1, int A_2)
		{
			while (A_0[A_1] <= ' ')
			{
				A_1++;
			}
			if (A_2 - A_1 < 8)
			{
				throw new DplxParseException("Invalid layout condition in a template, header or footer.");
			}
			w6 result;
			if ((A_0[A_1] == 'F' || A_0[A_1] == 'f') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1 + 5] == 'P' || A_0[A_1 + 5] == 'p') && (A_0[A_1 + 6] == 'a' || A_0[A_1 + 6] == 'A') && (A_0[A_1 + 7] == 'g' || A_0[A_1 + 7] == 'G') && (A_0[A_1 + 8] == 'e' || A_0[A_1 + 8] == 'E') && A_0[A_1 + 9] < 'A')
			{
				result = new w9();
			}
			else if ((A_0[A_1] == 'L' || A_0[A_1] == 'l') && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1 + 4] == 'P' || A_0[A_1 + 4] == 'p') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E') && A_0[A_1 + 8] < 'A')
			{
				result = new xa();
			}
			else if ((A_0[A_1] == 'M' || A_0[A_1] == 'm') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'd' || A_0[A_1 + 3] == 'D') && (A_0[A_1 + 4] == 'l' || A_0[A_1 + 4] == 'L') && (A_0[A_1 + 5] == 'e' || A_0[A_1 + 5] == 'E') && (A_0[A_1 + 6] == 'P' || A_0[A_1 + 6] == 'p') && (A_0[A_1 + 7] == 'a' || A_0[A_1 + 7] == 'A') && (A_0[A_1 + 8] == 'g' || A_0[A_1 + 8] == 'G') && (A_0[A_1 + 9] == 'e' || A_0[A_1 + 9] == 'E') && A_0[A_1 + 10] < 'A')
			{
				result = new xb();
			}
			else
			{
				if ((A_0[A_1] != 'D' && A_0[A_1] != 'd') || (A_0[A_1 + 1] != 'o' && A_0[A_1 + 1] != 'O') || (A_0[A_1 + 2] != 'c' && A_0[A_1 + 2] != 'C') || (A_0[A_1 + 3] != 'u' && A_0[A_1 + 3] != 'U') || (A_0[A_1 + 4] != 'm' && A_0[A_1 + 4] != 'M') || (A_0[A_1 + 5] != 'e' && A_0[A_1 + 5] != 'E') || (A_0[A_1 + 6] != 'n' && A_0[A_1 + 6] != 'N') || (A_0[A_1 + 7] != 't' && A_0[A_1 + 7] != 'T') || A_0[A_1 + 8] != '.')
				{
					throw new DplxParseException("Invalid layout condition in a template, header or footer.");
				}
				result = w6.a(A_0, A_1 + 9);
			}
			return result;
		}

		// Token: 0x060025BC RID: 9660 RVA: 0x00161628 File Offset: 0x00160628
		private static w6 a(char[] A_0, int A_1)
		{
			w6 result;
			if ((A_0[A_1] == 'E' || A_0[A_1] == 'e') && (A_0[A_1 + 1] == 'v' || A_0[A_1 + 1] == 'V') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 'P' || A_0[A_1 + 4] == 'p') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'g' || A_0[A_1 + 6] == 'G') && (A_0[A_1 + 7] == 'e' || A_0[A_1 + 7] == 'E'))
			{
				result = new w7();
			}
			else
			{
				if ((A_0[A_1] != 'O' && A_0[A_1] != 'o') || (A_0[A_1 + 1] != 'd' && A_0[A_1 + 1] != 'D') || (A_0[A_1 + 2] != 'd' && A_0[A_1 + 2] != 'D') || (A_0[A_1 + 3] != 'P' && A_0[A_1 + 3] != 'p') || (A_0[A_1 + 4] != 'a' && A_0[A_1 + 4] != 'A') || (A_0[A_1 + 5] != 'g' && A_0[A_1 + 5] != 'G') || (A_0[A_1 + 6] != 'e' && A_0[A_1 + 6] != 'E'))
				{
					throw new DplxParseException("Invalid document layout condition.");
				}
				result = new w8();
			}
			return result;
		}
	}
}
