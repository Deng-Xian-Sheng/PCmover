using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000043 RID: 67
	internal class bc : ac
	{
		// Token: 0x06000277 RID: 631 RVA: 0x0003D1E8 File Offset: 0x0003C1E8
		internal bc(string A_0)
		{
			if (A_0.Length < 11 || A_0.Length > 12)
			{
				throw new ap("UPC Version A value must be 11 or 12 characters long.");
			}
			if (A_0.Length == 11)
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

		// Token: 0x06000278 RID: 632 RVA: 0x0003D280 File Offset: 0x0003C280
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0003D298 File Offset: 0x0003C298
		internal static float c()
		{
			return 110f;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0003D2B0 File Offset: 0x0003C2B0
		internal static float b()
		{
			return 133f;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0003D2C8 File Offset: 0x0003C2C8
		internal static float a()
		{
			return 160f;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0003D2E0 File Offset: 0x0003C2E0
		internal BitArray a(BitArray A_0)
		{
			BitArray bitArray = new BitArray(95, true);
			for (int i = 0; i < 10; i++)
			{
				bitArray[i] = A_0[i];
			}
			for (int i = 10; i < 45; i++)
			{
				bitArray[i] = true;
			}
			for (int i = 45; i < 50; i++)
			{
				bitArray[i] = A_0[i];
			}
			for (int i = 50; i < 85; i++)
			{
				bitArray[i] = true;
			}
			for (int i = 85; i < 95; i++)
			{
				bitArray[i] = A_0[i];
			}
			return bitArray;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0003D3A0 File Offset: 0x0003C3A0
		internal BitArray b(BitArray A_0)
		{
			BitArray bitArray = new BitArray(95, true);
			for (int i = 0; i < 10; i++)
			{
				bitArray[i] = true;
			}
			for (int i = 10; i < 45; i++)
			{
				bitArray[i] = A_0[i];
			}
			for (int i = 45; i < 50; i++)
			{
				bitArray[i] = true;
			}
			for (int i = 50; i < 85; i++)
			{
				bitArray[i] = A_0[i];
			}
			for (int i = 85; i < 95; i++)
			{
				bitArray[i] = true;
			}
			return bitArray;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0003D45C File Offset: 0x0003C45C
		internal BitArray e()
		{
			base.a(1);
			base.b(1);
			base.a(1);
			base.a(this.a[0]);
			for (int i = 1; i < 6; i++)
			{
				base.a(this.a[i]);
			}
			base.b(1);
			base.a(1);
			base.b(1);
			base.a(1);
			base.b(1);
			for (int i = 6; i < 11; i++)
			{
				base.c(this.a[i]);
			}
			base.c(this.a[11]);
			base.a(1);
			base.b(1);
			base.a(1);
			return base.f();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0003D530 File Offset: 0x0003C530
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

		// Token: 0x040001A9 RID: 425
		private new char[] a;
	}
}
