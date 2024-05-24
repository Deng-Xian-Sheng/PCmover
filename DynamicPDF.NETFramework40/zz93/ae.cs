using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000021 RID: 33
	internal class ae : ac
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00026AE8 File Offset: 0x00025AE8
		internal ae(string A_0)
		{
			if (A_0.Length < 7 || A_0.Length > 8)
			{
				throw new ap("EAN 8 value must be 7 or 8 characters long.");
			}
			if (A_0.Length == 7)
			{
				this.a = new char[A_0.Length + 1];
				A_0.ToCharArray().CopyTo(this.a, 0);
				this.a(this.a);
			}
			else
			{
				this.a = A_0.ToCharArray();
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00026B7C File Offset: 0x00025B7C
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00026B94 File Offset: 0x00025B94
		internal static float c()
		{
			return 67f;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00026BAC File Offset: 0x00025BAC
		internal static float b()
		{
			return 97f;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00026BC4 File Offset: 0x00025BC4
		internal static float a()
		{
			return 124f;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00026BDC File Offset: 0x00025BDC
		internal BitArray e()
		{
			base.a(1);
			base.b(1);
			base.a(1);
			for (int i = 0; i < 4; i++)
			{
				base.a(this.a[i]);
			}
			base.b(1);
			base.a(1);
			base.b(1);
			base.a(1);
			base.b(1);
			for (int i = 4; i < 8; i++)
			{
				base.c(this.a[i]);
			}
			base.a(1);
			base.b(1);
			base.a(1);
			return base.f();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00026C90 File Offset: 0x00025C90
		internal BitArray a(BitArray A_0)
		{
			BitArray bitArray = new BitArray(67, true);
			for (int i = 0; i < 67; i++)
			{
				if (i == 0 || i == 2 || i == 32 || i == 34 || i == 64 || i == 66)
				{
					bitArray[i] = A_0[i];
				}
				else
				{
					bitArray[i] = true;
				}
			}
			return bitArray;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00026D04 File Offset: 0x00025D04
		internal BitArray b(BitArray A_0)
		{
			BitArray bitArray = new BitArray(67, true);
			for (int i = 0; i < 67; i++)
			{
				if (i == 0 || i == 2 || i == 32 || i == 34 || i == 64 || i == 66)
				{
					bitArray[i] = true;
				}
				else
				{
					bitArray[i] = A_0[i];
				}
			}
			return bitArray;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00026D78 File Offset: 0x00025D78
		private void a(char[] A_0)
		{
			int num = 0;
			int i;
			for (i = 0; i < A_0.Length - 1; i++)
			{
				if (i % 2 == 0)
				{
					num += (int)((A_0[i] - '0') * '\u0003');
				}
				else
				{
					num += (int)(A_0[i] - '0');
				}
			}
			A_0[i] = (char)(58 - num % 10);
			if (A_0[i] == ':')
			{
				A_0[i] = '0';
			}
		}

		// Token: 0x040000B9 RID: 185
		private new char[] a;
	}
}
