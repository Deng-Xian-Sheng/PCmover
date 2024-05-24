using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003E0 RID: 992
	internal class zz
	{
		// Token: 0x06002992 RID: 10642 RVA: 0x00185050 File Offset: 0x00184050
		internal zz(int A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06002993 RID: 10643 RVA: 0x001850E0 File Offset: 0x001840E0
		internal void a(b3 A_0, int A_1)
		{
			this.j = A_1;
			A_0.a(10);
			this.m = A_0.h();
			this.n = A_0.g();
			A_0.b(A_1);
			this.o = A_0.g() - this.n;
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x00185131 File Offset: 0x00184131
		internal void a(b3 A_0)
		{
			this.q.a(A_0, this.j);
		}

		// Token: 0x06002995 RID: 10645 RVA: 0x00185148 File Offset: 0x00184148
		internal int a()
		{
			return this.s;
		}

		// Token: 0x06002996 RID: 10646 RVA: 0x00185160 File Offset: 0x00184160
		internal int b()
		{
			return this.j;
		}

		// Token: 0x06002997 RID: 10647 RVA: 0x00185178 File Offset: 0x00184178
		internal virtual int c()
		{
			return this.r;
		}

		// Token: 0x06002998 RID: 10648 RVA: 0x00185190 File Offset: 0x00184190
		internal virtual void a(int A_0)
		{
			this.r = A_0;
		}

		// Token: 0x06002999 RID: 10649 RVA: 0x0018519C File Offset: 0x0018419C
		internal int d()
		{
			this.s = this.o + 15 + this.q.a();
			return this.s;
		}

		// Token: 0x0600299A RID: 10650 RVA: 0x001851D0 File Offset: 0x001841D0
		internal int e()
		{
			return this.o;
		}

		// Token: 0x0600299B RID: 10651 RVA: 0x001851E8 File Offset: 0x001841E8
		internal int f()
		{
			int result;
			if (this.c)
			{
				result = 0;
			}
			else
			{
				this.c = true;
				int num = this.q.c();
				result = num;
			}
			return result;
		}

		// Token: 0x0600299C RID: 10652 RVA: 0x00185220 File Offset: 0x00184220
		internal int g()
		{
			int result;
			if (this.d)
			{
				result = 0;
			}
			else
			{
				this.d = true;
				int num = this.q.d();
				if (this.p >= 2147483544)
				{
					num++;
				}
				this.d = false;
				result = num;
			}
			return result;
		}

		// Token: 0x0600299D RID: 10653 RVA: 0x00185274 File Offset: 0x00184274
		internal void a(zy A_0, int A_1, aaa A_2)
		{
			if (!this.e)
			{
				this.e = true;
				if (this.p >= 2147483544)
				{
					A_0.b(A_2.a(this.j), A_1);
				}
				this.q.a(A_0, A_1, A_2);
				this.e = false;
			}
		}

		// Token: 0x0600299E RID: 10654 RVA: 0x001852D4 File Offset: 0x001842D4
		internal void a(zy A_0)
		{
			if (!this.f)
			{
				this.f = true;
				if (this.p >= 2147483544)
				{
					A_0.b(0, 2);
				}
				this.q.a(A_0);
				this.f = false;
			}
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x00185328 File Offset: 0x00184328
		internal int h()
		{
			int result;
			if (this.i)
			{
				result = 0;
			}
			else
			{
				this.i = true;
				int num = this.q.e();
				result = num;
			}
			return result;
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x00185360 File Offset: 0x00184360
		internal void i()
		{
			if (!this.h)
			{
				this.h = true;
				int num = this.p;
				this.p = int.MaxValue;
				if (num != this.p)
				{
					this.q.b();
					this.h = false;
				}
			}
		}

		// Token: 0x060029A1 RID: 10657 RVA: 0x001853B8 File Offset: 0x001843B8
		internal void b(int A_0)
		{
			if (!this.g)
			{
				this.g = true;
				if (this.p != 2147483647)
				{
					int num = this.p;
					if (this.p > 2147483544)
					{
						this.p = A_0;
					}
					else if (this.p < 2147483544 && this.p != A_0)
					{
						this.p = 2147483544;
					}
					if (num != this.p)
					{
						this.q.a(A_0);
					}
					this.g = false;
				}
			}
		}

		// Token: 0x060029A2 RID: 10658 RVA: 0x0018546C File Offset: 0x0018446C
		internal bool a(zz A_0)
		{
			bool result;
			if (this.p < A_0.p)
			{
				result = true;
			}
			else if (this.p > A_0.p)
			{
				result = false;
			}
			else if (this.l == A_0.l)
			{
				result = (this.k < A_0.k);
			}
			else
			{
				result = (this.l < A_0.l);
			}
			return result;
		}

		// Token: 0x060029A3 RID: 10659 RVA: 0x001854E4 File Offset: 0x001844E4
		internal int j()
		{
			return this.p;
		}

		// Token: 0x060029A4 RID: 10660 RVA: 0x001854FC File Offset: 0x001844FC
		internal void c(int A_0)
		{
			this.p = A_0;
		}

		// Token: 0x060029A5 RID: 10661 RVA: 0x00185508 File Offset: 0x00184508
		internal byte k()
		{
			return this.l;
		}

		// Token: 0x060029A6 RID: 10662 RVA: 0x00185520 File Offset: 0x00184520
		internal void a(byte A_0)
		{
			this.l = A_0;
		}

		// Token: 0x060029A7 RID: 10663 RVA: 0x0018552C File Offset: 0x0018452C
		internal z2 l()
		{
			return this.q;
		}

		// Token: 0x060029A8 RID: 10664 RVA: 0x00185544 File Offset: 0x00184544
		internal void a(Stream A_0)
		{
			this.b(A_0);
			A_0.Write(zz.a, 0, 7);
			this.q.a(A_0);
			A_0.Write(zz.b, 0, 8);
		}

		// Token: 0x060029A9 RID: 10665 RVA: 0x00185578 File Offset: 0x00184578
		internal void b(Stream A_0)
		{
			A_0.Write(this.m, this.n, this.o);
		}

		// Token: 0x060029AA RID: 10666 RVA: 0x00185594 File Offset: 0x00184594
		internal void a(byte[] A_0, int A_1)
		{
			Array.Copy(this.m, this.n, A_0, A_1, this.o);
		}

		// Token: 0x040012EE RID: 4846
		private static byte[] a = new byte[]
		{
			32,
			48,
			32,
			111,
			98,
			106,
			10
		};

		// Token: 0x040012EF RID: 4847
		private static byte[] b = new byte[]
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

		// Token: 0x040012F0 RID: 4848
		private bool c = false;

		// Token: 0x040012F1 RID: 4849
		private bool d = false;

		// Token: 0x040012F2 RID: 4850
		private bool e = false;

		// Token: 0x040012F3 RID: 4851
		private bool f = false;

		// Token: 0x040012F4 RID: 4852
		private bool g = false;

		// Token: 0x040012F5 RID: 4853
		private bool h = false;

		// Token: 0x040012F6 RID: 4854
		private bool i = false;

		// Token: 0x040012F7 RID: 4855
		private int j = -1;

		// Token: 0x040012F8 RID: 4856
		private int k;

		// Token: 0x040012F9 RID: 4857
		private byte l = 64;

		// Token: 0x040012FA RID: 4858
		private byte[] m;

		// Token: 0x040012FB RID: 4859
		private int n = 0;

		// Token: 0x040012FC RID: 4860
		private int o = 0;

		// Token: 0x040012FD RID: 4861
		private int p = int.MinValue;

		// Token: 0x040012FE RID: 4862
		private z2 q = new z2();

		// Token: 0x040012FF RID: 4863
		private int r = 0;

		// Token: 0x04001300 RID: 4864
		private int s = 0;
	}
}
