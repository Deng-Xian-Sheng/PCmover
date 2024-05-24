using System;

namespace zz93
{
	// Token: 0x020003DC RID: 988
	internal class zv
	{
		// Token: 0x06002965 RID: 10597 RVA: 0x0018396C File Offset: 0x0018296C
		internal zv()
		{
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x0018397E File Offset: 0x0018297E
		protected void a(byte[] A_0)
		{
			Array.Copy(A_0, 0, this.r, this.s, A_0.Length);
			this.s += A_0.Length;
		}

		// Token: 0x06002967 RID: 10599 RVA: 0x001839A8 File Offset: 0x001829A8
		protected void b(byte[] A_0)
		{
			this.r[this.s++] = 47;
			Array.Copy(A_0, 0, this.r, this.s, A_0.Length);
			this.s += A_0.Length;
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x001839F8 File Offset: 0x001829F8
		protected void c(byte A_0)
		{
			this.r[this.s++] = 47;
			this.r[this.s++] = A_0;
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x00183A3C File Offset: 0x00182A3C
		protected int c(int A_0)
		{
			int result;
			if (A_0 < 10)
			{
				result = 1;
			}
			else if (A_0 < 100)
			{
				result = 2;
			}
			else if (A_0 < 1000)
			{
				result = 3;
			}
			else if (A_0 < 10000)
			{
				result = 4;
			}
			else if (A_0 < 100000)
			{
				result = 5;
			}
			else if (A_0 < 1000000)
			{
				result = 6;
			}
			else if (A_0 < 10000000)
			{
				result = 7;
			}
			else if (A_0 < 100000000)
			{
				result = 8;
			}
			else if (A_0 < 1000000000)
			{
				result = 9;
			}
			else
			{
				result = 10;
			}
			return result;
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x00183AFC File Offset: 0x00182AFC
		protected void d()
		{
			this.r[this.s++] = 32;
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x00183B24 File Offset: 0x00182B24
		protected void e()
		{
			this.r[this.s++] = 10;
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x00183B4C File Offset: 0x00182B4C
		protected void f()
		{
			this.r[this.s++] = 62;
			this.r[this.s++] = 62;
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x00183B90 File Offset: 0x00182B90
		protected void g()
		{
			this.r[this.s++] = 60;
			this.r[this.s++] = 60;
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x00183BD4 File Offset: 0x00182BD4
		protected void h()
		{
			this.r[this.s++] = 93;
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x00183BFC File Offset: 0x00182BFC
		protected void i()
		{
			this.r[this.s++] = 91;
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x00183C24 File Offset: 0x00182C24
		protected void d(int A_0)
		{
			this.f(A_0);
			this.a(zv.a);
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x00183C3B File Offset: 0x00182C3B
		protected void j()
		{
			this.a(zv.c);
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x00183C4C File Offset: 0x00182C4C
		protected void e(int A_0)
		{
			for (int i = 1000000000; i >= 1; i /= 10)
			{
				int num = (int)((byte)(A_0 / i));
				this.r[this.s++] = (byte)(num + 48);
				A_0 -= num * i;
			}
			this.a(zv.g);
		}

		// Token: 0x06002973 RID: 10611 RVA: 0x00183CAC File Offset: 0x00182CAC
		protected void f(int A_0)
		{
			int i;
			if (A_0 < 10)
			{
				i = 1;
			}
			else if (A_0 < 100)
			{
				i = 10;
			}
			else if (A_0 < 1000)
			{
				i = 100;
			}
			else if (A_0 < 10000)
			{
				i = 1000;
			}
			else if (A_0 < 1000000)
			{
				i = 100000;
			}
			else
			{
				i = 1000000000;
			}
			bool flag = false;
			while (i >= 1)
			{
				int num = (int)((byte)(A_0 / i));
				if (flag || num > 0)
				{
					this.r[this.s++] = (byte)(num + 48);
					flag = true;
				}
				A_0 -= num * i;
				i /= 10;
			}
			if (!flag)
			{
				this.r[this.s++] = 48;
			}
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x00183D9C File Offset: 0x00182D9C
		protected void c(byte[] A_0)
		{
			this.r[this.s++] = 60;
			for (int i = 0; i < A_0.Length; i++)
			{
				this.b(A_0[i]);
			}
			this.r[this.s++] = 62;
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x00183DFC File Offset: 0x00182DFC
		private void b(byte A_0)
		{
			this.a(A_0 / 16);
			this.a(A_0 % 16);
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x00183E18 File Offset: 0x00182E18
		private void a(byte A_0)
		{
			if (A_0 < 10)
			{
				this.r[this.s++] = A_0 + 48;
			}
			else
			{
				this.r[this.s++] = A_0 + 87;
			}
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x00183E72 File Offset: 0x00182E72
		protected void a(zz A_0)
		{
			A_0.a(this.r, this.s);
			this.s += A_0.e();
			this.a(zv.b);
		}

		// Token: 0x040012BF RID: 4799
		protected internal static byte[] a = new byte[]
		{
			32,
			48,
			32,
			111,
			98,
			106,
			10
		};

		// Token: 0x040012C0 RID: 4800
		protected internal static byte[] b = new byte[]
		{
			32,
			48,
			32,
			82
		};

		// Token: 0x040012C1 RID: 4801
		protected internal static byte[] c = new byte[]
		{
			10,
			101,
			110,
			100,
			111,
			98,
			106,
			10
		};

		// Token: 0x040012C2 RID: 4802
		protected internal static byte[] d = new byte[]
		{
			120,
			114,
			101,
			102,
			10
		};

		// Token: 0x040012C3 RID: 4803
		protected internal static byte[] e = new byte[]
		{
			120,
			114,
			101,
			102,
			10,
			48,
			32
		};

		// Token: 0x040012C4 RID: 4804
		protected internal static byte[] f = new byte[]
		{
			10,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			48,
			32,
			54,
			53,
			53,
			51,
			53,
			32,
			102,
			32,
			10
		};

		// Token: 0x040012C5 RID: 4805
		protected internal static byte[] g = new byte[]
		{
			32,
			48,
			48,
			48,
			48,
			48,
			32,
			110,
			32,
			10
		};

		// Token: 0x040012C6 RID: 4806
		protected internal static byte[] h = new byte[]
		{
			10,
			37,
			37,
			69,
			79,
			70,
			10
		};

		// Token: 0x040012C7 RID: 4807
		protected internal static byte[] i = new byte[]
		{
			116,
			114,
			97,
			105,
			108,
			101,
			114,
			10
		};

		// Token: 0x040012C8 RID: 4808
		protected internal static byte[] j = new byte[]
		{
			83,
			105,
			122,
			101
		};

		// Token: 0x040012C9 RID: 4809
		protected internal static byte[] k = new byte[]
		{
			82,
			111,
			111,
			116
		};

		// Token: 0x040012CA RID: 4810
		protected internal static byte[] l = new byte[]
		{
			69,
			110,
			99,
			114,
			121,
			112,
			116
		};

		// Token: 0x040012CB RID: 4811
		protected internal static byte[] m = new byte[]
		{
			73,
			68
		};

		// Token: 0x040012CC RID: 4812
		protected internal static byte[] n = new byte[]
		{
			73,
			110,
			102,
			111
		};

		// Token: 0x040012CD RID: 4813
		protected internal static byte[] o = new byte[]
		{
			80,
			114,
			101,
			118
		};

		// Token: 0x040012CE RID: 4814
		protected internal static byte[] p = new byte[]
		{
			10,
			115,
			116,
			97,
			114,
			116,
			120,
			114,
			101,
			102,
			10
		};

		// Token: 0x040012CF RID: 4815
		protected internal static byte[] q = new byte[]
		{
			76,
			105,
			110,
			101,
			97,
			114,
			105,
			122,
			101,
			100
		};

		// Token: 0x040012D0 RID: 4816
		protected internal byte[] r;

		// Token: 0x040012D1 RID: 4817
		protected internal int s = 0;
	}
}
