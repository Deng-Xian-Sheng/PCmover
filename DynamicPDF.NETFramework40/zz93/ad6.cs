using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000483 RID: 1155
	internal class ad6 : adx
	{
		// Token: 0x06002FAA RID: 12202 RVA: 0x001AF684 File Offset: 0x001AE684
		public ad6(ushort A_0, Stream A_1, byte[] A_2, int A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (ushort num = 0; num < A_0; num += 1)
			{
				base.a()[(int)num] = base.e((int)(num * 2)) * 2;
			}
		}

		// Token: 0x06002FAB RID: 12203 RVA: 0x001AF6C4 File Offset: 0x001AE6C4
		internal override void jp(ad8 A_0, bool A_1)
		{
			if (A_1)
			{
				A_0.b();
				int num = (A_0.d().Length + 1) * 2;
				A_0.a(8, num);
				A_0.b(num);
				int num2 = A_0.f();
				int num3 = A_0.e() - 2;
				A_0.c(num3, num2 / 2);
				num3 -= 2;
				for (int i = A_0.d().Length - 1; i >= 0; i--)
				{
					if (num2 != A_0.d()[i] && A_0.d()[i] >= 0)
					{
						num2 = A_0.d()[i];
					}
					A_0.c(num3, num2 / 2);
					num3 -= 2;
				}
				A_0.b();
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
