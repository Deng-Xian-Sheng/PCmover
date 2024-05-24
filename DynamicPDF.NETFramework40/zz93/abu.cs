using System;
using System.Text;

namespace zz93
{
	// Token: 0x0200042C RID: 1068
	internal abstract class abu : abd
	{
		// Token: 0x06002C69 RID: 11369 RVA: 0x00196BB4 File Offset: 0x00195BB4
		internal abu()
		{
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x00196BC0 File Offset: 0x00195BC0
		internal override ag9 hy()
		{
			return ag9.d;
		}

		// Token: 0x06002C6B RID: 11371
		internal abstract int j8();

		// Token: 0x06002C6C RID: 11372
		internal abstract void ka();

		// Token: 0x06002C6D RID: 11373
		internal abstract string j9();

		// Token: 0x06002C6E RID: 11374
		internal abstract int kb(int A_0);

		// Token: 0x06002C6F RID: 11375
		internal abstract int kc();

		// Token: 0x06002C70 RID: 11376
		internal abstract int j7(aba A_0);

		// Token: 0x06002C71 RID: 11377 RVA: 0x00196BD4 File Offset: 0x00195BD4
		internal static int a(string A_0)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(A_0);
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < bytes.Length; i++)
			{
				num2 <<= 6;
				num2 |= (int)(bytes[i] % 64);
				if (i % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
			}
			if (i % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}
	}
}
