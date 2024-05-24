using System;

namespace zz93
{
	// Token: 0x02000409 RID: 1033
	internal sealed class aaw : aav
	{
		// Token: 0x06002B3F RID: 11071 RVA: 0x0018F450 File Offset: 0x0018E450
		public long hq()
		{
			return (long)((ulong)this.b);
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x0018F469 File Offset: 0x0018E469
		internal aaw()
		{
			this.hr();
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x0018F47B File Offset: 0x0018E47B
		public void hr()
		{
			this.b = 1U;
		}

		// Token: 0x06002B42 RID: 11074 RVA: 0x0018F488 File Offset: 0x0018E488
		public void hs(int A_0)
		{
			uint num = this.b & 65535U;
			uint num2 = this.b >> 16;
			num = (num + (uint)(A_0 & 255)) % aaw.a;
			num2 = (num + num2) % aaw.a;
			this.b = (num2 << 16) + num;
		}

		// Token: 0x06002B43 RID: 11075 RVA: 0x0018F4D3 File Offset: 0x0018E4D3
		public void ht(byte[] A_0)
		{
			this.hu(A_0, 0, A_0.Length);
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x0018F4E4 File Offset: 0x0018E4E4
		public void hu(byte[] A_0, int A_1, int A_2)
		{
			if (A_0 == null)
			{
				throw new ArgumentNullException("buf");
			}
			if (A_1 < 0 || A_2 < 0 || A_1 + A_2 > A_0.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			uint num = this.b & 65535U;
			uint num2 = this.b >> 16;
			while (A_2 > 0)
			{
				int num3 = 3800;
				if (num3 > A_2)
				{
					num3 = A_2;
				}
				A_2 -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(A_0[A_1++] & byte.MaxValue);
					num2 += num;
				}
				num %= aaw.a;
				num2 %= aaw.a;
			}
			this.b = (num2 << 16 | num);
		}

		// Token: 0x040013E4 RID: 5092
		private static readonly uint a = 65521U;

		// Token: 0x040013E5 RID: 5093
		private uint b;
	}
}
