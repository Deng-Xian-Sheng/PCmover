using System;

namespace zz93
{
	// Token: 0x02000478 RID: 1144
	internal class adv
	{
		// Token: 0x06002F5F RID: 12127 RVA: 0x001ADB34 File Offset: 0x001ACB34
		internal adv(adw A_0, int A_1, ref int A_2)
		{
			A_2 += 4;
			ushort num = (ushort)A_0.e(A_2);
			A_2 += 2;
			if (num >> 8 == 0)
			{
				A_2 = this.a(A_0, A_1, A_2);
				return;
			}
			throw new Exception("Kerning format not supported");
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x001ADB90 File Offset: 0x001ACB90
		private int a(adw A_0, int A_1, int A_2)
		{
			ushort num = (ushort)A_0.e(A_2);
			A_2 += 8;
			if (num > 0)
			{
				this.a = new adu[(int)num];
			}
			for (int i = 0; i < (int)num; i++)
			{
				this.a[i] = new adu(A_0, A_1, ref A_2);
			}
			return A_2;
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x001ADBF4 File Offset: 0x001ACBF4
		internal adu[] a()
		{
			return this.a;
		}

		// Token: 0x0400168F RID: 5775
		private adu[] a = null;
	}
}
