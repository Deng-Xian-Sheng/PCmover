using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200047B RID: 1147
	internal class ady : adx
	{
		// Token: 0x06002F67 RID: 12135 RVA: 0x001ADCD0 File Offset: 0x001ACCD0
		internal ady(ushort A_0, Stream A_1, byte[] A_2, int A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (ushort num = 0; num < A_0; num += 1)
			{
				base.a()[(int)num] = base.d((int)(num * 4));
			}
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x001ADD10 File Offset: 0x001ACD10
		internal override void jp(ad8 A_0, bool A_1)
		{
			if (A_1)
			{
				A_0.b();
				int num = (A_0.d().Length + 1) * 4;
				A_0.a(8, num);
				A_0.b(num);
				int num2 = A_0.f();
				int num3 = A_0.e() - 4;
				A_0.b(num3, num2);
				num3 -= 4;
				for (int i = A_0.d().Length - 1; i >= 0; i--)
				{
					if (num2 != A_0.d()[i] && A_0.d()[i] >= 0)
					{
						num2 = A_0.d()[i];
					}
					A_0.b(num3, num2);
					num3 -= 4;
				}
			}
			else
			{
				A_0.b();
				A_0.a(8, base.p().Length);
				A_0.a(base.p());
			}
		}
	}
}
