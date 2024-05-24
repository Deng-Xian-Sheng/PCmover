using System;

namespace zz93
{
	// Token: 0x020003BB RID: 955
	internal sealed class yz : yy
	{
		// Token: 0x06002861 RID: 10337 RVA: 0x00175B18 File Offset: 0x00174B18
		public long g1()
		{
			return (long)((ulong)this.b);
		}

		// Token: 0x06002862 RID: 10338 RVA: 0x00175B31 File Offset: 0x00174B31
		internal yz()
		{
			this.g2();
		}

		// Token: 0x06002863 RID: 10339 RVA: 0x00175B43 File Offset: 0x00174B43
		public void g2()
		{
			this.b = 1U;
		}

		// Token: 0x06002864 RID: 10340 RVA: 0x00175B50 File Offset: 0x00174B50
		public void g3(int A_0)
		{
			uint num = this.b & 65535U;
			uint num2 = this.b >> 16;
			num = (num + (uint)(A_0 & 255)) % yz.a;
			num2 = (num + num2) % yz.a;
			this.b = (num2 << 16) + num;
		}

		// Token: 0x06002865 RID: 10341 RVA: 0x00175B9B File Offset: 0x00174B9B
		public void g4(byte[] A_0)
		{
			this.g5(A_0, 0, A_0.Length);
		}

		// Token: 0x06002866 RID: 10342 RVA: 0x00175BAC File Offset: 0x00174BAC
		public void g5(byte[] A_0, int A_1, int A_2)
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
				num %= yz.a;
				num2 %= yz.a;
			}
			this.b = (num2 << 16 | num);
		}

		// Token: 0x040011BD RID: 4541
		private static readonly uint a = 65521U;

		// Token: 0x040011BE RID: 4542
		private uint b;
	}
}
