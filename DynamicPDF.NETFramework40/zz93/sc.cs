using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002C0 RID: 704
	internal class sc : sa
	{
		// Token: 0x06002049 RID: 8265 RVA: 0x0013EA78 File Offset: 0x0013DA78
		internal sc(Stream A_0, byte[] A_1, int A_2, int A_3) : base(A_0, A_1, A_2)
		{
			if (base.p().Length > 0)
			{
				this.c = base.e(4);
				if (A_3 != -1)
				{
					this.e = (short)((base.f(26) * 1000 + A_3 / 2) / A_3);
					this.f = (short)((base.f(28) * 1000 + A_3 / 2) / A_3);
					this.h = (short)((base.f(10) * 1000 + A_3 / 2) / A_3);
					this.j = (short)((base.f(12) * 1000 + A_3 / 2) / A_3);
					this.l = (short)((base.f(14) * 1000 + A_3 / 2) / A_3);
					this.n = (short)((base.f(16) * 1000 + A_3 / 2) / A_3);
					this.g = (short)((base.f(18) * 1000 + A_3 / 2) / A_3);
					this.i = (short)((base.f(20) * 1000 + A_3 / 2) / A_3);
					this.k = (short)((base.f(22) * 1000 + A_3 / 2) / A_3);
					this.m = (short)((base.f(24) * 1000 + A_3 / 2) / A_3);
				}
				this.b = new byte[10];
				Array.Copy(base.p(), 32, this.b, 0, 10);
				this.d = base.e(62);
				if (base.p().Length > 78)
				{
					int a_ = base.d(78);
					this.a(a_);
					base.o();
				}
			}
		}

		// Token: 0x0600204A RID: 8266 RVA: 0x0013EC84 File Offset: 0x0013DC84
		private void a(int A_0)
		{
			string text = "";
			while (A_0 > 0)
			{
				int num = A_0 % 2;
				text += num;
				A_0 /= 2;
			}
			char[] array = text.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if ((i == 17 || i == 18 || i == 19 || i == 20 || i == 21) && array[i].CompareTo('1') == 0)
				{
					this.a = true;
					break;
				}
			}
		}

		// Token: 0x0600204B RID: 8267 RVA: 0x0013ED1C File Offset: 0x0013DD1C
		internal short a()
		{
			return this.h;
		}

		// Token: 0x0600204C RID: 8268 RVA: 0x0013ED34 File Offset: 0x0013DD34
		internal short b()
		{
			return this.g;
		}

		// Token: 0x0600204D RID: 8269 RVA: 0x0013ED4C File Offset: 0x0013DD4C
		internal short c()
		{
			return this.j;
		}

		// Token: 0x0600204E RID: 8270 RVA: 0x0013ED64 File Offset: 0x0013DD64
		internal short d()
		{
			return this.i;
		}

		// Token: 0x0600204F RID: 8271 RVA: 0x0013ED7C File Offset: 0x0013DD7C
		internal short e()
		{
			return this.l;
		}

		// Token: 0x06002050 RID: 8272 RVA: 0x0013ED94 File Offset: 0x0013DD94
		internal short f()
		{
			return this.k;
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x0013EDAC File Offset: 0x0013DDAC
		internal short g()
		{
			return this.n;
		}

		// Token: 0x06002052 RID: 8274 RVA: 0x0013EDC4 File Offset: 0x0013DDC4
		internal short h()
		{
			return this.m;
		}

		// Token: 0x06002053 RID: 8275 RVA: 0x0013EDDC File Offset: 0x0013DDDC
		internal bool i()
		{
			return this.a;
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x0013EDF4 File Offset: 0x0013DDF4
		internal byte[] j()
		{
			return this.b;
		}

		// Token: 0x06002055 RID: 8277 RVA: 0x0013EE0C File Offset: 0x0013DE0C
		internal int k()
		{
			return this.c;
		}

		// Token: 0x06002056 RID: 8278 RVA: 0x0013EE24 File Offset: 0x0013DE24
		internal int l()
		{
			return this.d;
		}

		// Token: 0x06002057 RID: 8279 RVA: 0x0013EE3C File Offset: 0x0013DE3C
		internal short m()
		{
			return this.e;
		}

		// Token: 0x06002058 RID: 8280 RVA: 0x0013EE54 File Offset: 0x0013DE54
		internal short n()
		{
			return this.f;
		}

		// Token: 0x04000E01 RID: 3585
		private new bool a = false;

		// Token: 0x04000E02 RID: 3586
		private byte[] b;

		// Token: 0x04000E03 RID: 3587
		private int c;

		// Token: 0x04000E04 RID: 3588
		private new int d;

		// Token: 0x04000E05 RID: 3589
		private new short e;

		// Token: 0x04000E06 RID: 3590
		private new short f;

		// Token: 0x04000E07 RID: 3591
		private new short g = -1;

		// Token: 0x04000E08 RID: 3592
		private new short h = -1;

		// Token: 0x04000E09 RID: 3593
		private new short i = -1;

		// Token: 0x04000E0A RID: 3594
		private short j = -1;

		// Token: 0x04000E0B RID: 3595
		private short k = -1;

		// Token: 0x04000E0C RID: 3596
		private short l = -1;

		// Token: 0x04000E0D RID: 3597
		private short m = -1;

		// Token: 0x04000E0E RID: 3598
		private short n = -1;
	}
}
