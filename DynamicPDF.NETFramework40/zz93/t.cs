using System;

namespace zz93
{
	// Token: 0x02000016 RID: 22
	internal class t : r
	{
		// Token: 0x060000E4 RID: 228 RVA: 0x000206DA File Offset: 0x0001F6DA
		internal t(int A_0, bool A_1, bool A_2, bool A_3) : base(A_0, 1, A_2, A_1, A_3)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000206EC File Offset: 0x0001F6EC
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
							goto IL_201;
						}
						if (A_0[i] == 126 && i < A_0.Length - 1 && A_0[i + 1] == 50 && i + 7 <= A_0.Length)
						{
							base.a(A_0, i + 2, i + 8, A_2);
							i += 7;
							goto IL_201;
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
					else if (A_0[i] >= 0 && A_0[i] <= 127)
					{
						A_2.a(A_0[i] + 1);
					}
					else
					{
						if (A_0[i] <= 127 || A_0[i] > 255)
						{
							throw new ap("Invalid barcode value.");
						}
						A_2.a(235);
						A_2.a(A_0[i] - 128 + 1);
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
				IL_201:
				i++;
				continue;
				goto IL_201;
			}
			if (base.e())
			{
				A_2 = base.b(A_2);
			}
			return A_2;
		}
	}
}
