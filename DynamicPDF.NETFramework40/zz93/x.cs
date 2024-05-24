using System;

namespace zz93
{
	// Token: 0x0200001A RID: 26
	internal class x : r
	{
		// Token: 0x0600011E RID: 286 RVA: 0x000249BE File Offset: 0x000239BE
		internal x(int A_0, bool A_1, bool A_2, bool A_3) : base(A_0, 1, A_2, A_1, A_3)
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000249D0 File Offset: 0x000239D0
		internal i a(byte[] A_0, bool A_1, i A_2)
		{
			int i = 0;
			while (i < A_0.Length)
			{
				int num = 1;
				if (A_1 && A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
				{
					num = 4;
				}
				if (!base.d() || A_2.a() + num <= base.c() - 4)
				{
					if (A_1)
					{
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 49)
						{
							A_2.a(232);
							i++;
							goto IL_1C7;
						}
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
						{
							base.a(A_0, i + 2, i + 8, A_2);
							i += 7;
							goto IL_1C7;
						}
					}
					if (A_0[i] > 47 && A_0[i] < 58 && i < A_0.Length - 1 && A_0[i + 1] > 47 && A_0[i + 1] < 58)
					{
						int num2 = (int)(A_0[i] - 48);
						num2 *= 10;
						i++;
						num2 += (int)(A_0[i] - 48);
						A_2.a((byte)(num2 + 130));
					}
					else
					{
						if (A_0[i] <= 47 || A_0[i] >= 58)
						{
							throw new ap("Invalid barcode value");
						}
						A_2.a(A_0[i] + 1);
					}
				}
				else
				{
					if (A_2.a() == 0)
					{
						throw new ao("Invalid symbol size for overflow.");
					}
					A_2 = base.a(A_2);
					i--;
				}
				IL_1C7:
				i++;
				continue;
				goto IL_1C7;
			}
			if (base.e())
			{
				A_2 = base.b(A_2);
			}
			return A_2;
		}
	}
}
