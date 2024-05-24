using System;
using System.IO;

namespace zz93
{
	// Token: 0x020003C2 RID: 962
	internal class y5
	{
		// Token: 0x060028A2 RID: 10402 RVA: 0x0017884B File Offset: 0x0017784B
		internal y5() : this(4096)
		{
		}

		// Token: 0x060028A3 RID: 10403 RVA: 0x0017885B File Offset: 0x0017785B
		internal y5(int A_0)
		{
			this.a = new byte[A_0];
		}

		// Token: 0x060028A4 RID: 10404 RVA: 0x00178874 File Offset: 0x00177874
		internal void a()
		{
			this.b = (this.c = (this.e = 0));
		}

		// Token: 0x060028A5 RID: 10405 RVA: 0x0017889C File Offset: 0x0017789C
		internal void a(int A_0)
		{
			this.a[this.c++] = (byte)A_0;
			this.a[this.c++] = (byte)(A_0 >> 8);
		}

		// Token: 0x060028A6 RID: 10406 RVA: 0x001788E0 File Offset: 0x001778E0
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			Array.Copy(A_0, A_1, this.a, this.c, A_2);
			this.c += A_2;
		}

		// Token: 0x060028A7 RID: 10407 RVA: 0x00178908 File Offset: 0x00177908
		internal int b()
		{
			return this.e;
		}

		// Token: 0x060028A8 RID: 10408 RVA: 0x00178920 File Offset: 0x00177920
		internal void c()
		{
			if (this.e > 0)
			{
				this.a[this.c++] = (byte)this.d;
				if (this.e > 8)
				{
					this.a[this.c++] = (byte)(this.d >> 8);
				}
			}
			this.d = 0U;
			this.e = 0;
		}

		// Token: 0x060028A9 RID: 10409 RVA: 0x001789A0 File Offset: 0x001779A0
		internal void a(int A_0, int A_1)
		{
			this.d |= (uint)((uint)A_0 << this.e);
			this.e += A_1;
			if (this.e >= 16)
			{
				this.a[this.c++] = (byte)this.d;
				this.a[this.c++] = (byte)(this.d >> 8);
				this.d >>= 16;
				this.e -= 16;
			}
		}

		// Token: 0x060028AA RID: 10410 RVA: 0x00178A44 File Offset: 0x00177A44
		internal void b(int A_0)
		{
			this.a[this.c++] = (byte)(A_0 >> 8);
			this.a[this.c++] = (byte)A_0;
		}

		// Token: 0x060028AB RID: 10411 RVA: 0x00178A88 File Offset: 0x00177A88
		internal bool d()
		{
			return this.c == 0;
		}

		// Token: 0x060028AC RID: 10412 RVA: 0x00178AA4 File Offset: 0x00177AA4
		internal int b(byte[] A_0, int A_1, int A_2)
		{
			if (this.e >= 8)
			{
				this.a[this.c++] = (byte)this.d;
				this.d >>= 8;
				this.e -= 8;
			}
			if (A_2 > this.c - this.b)
			{
				A_2 = this.c - this.b;
				Array.Copy(this.a, this.b, A_0, A_1, A_2);
				this.b = 0;
				this.c = 0;
			}
			else
			{
				Array.Copy(this.a, this.b, A_0, A_1, A_2);
				this.b += A_2;
			}
			return A_2;
		}

		// Token: 0x060028AD RID: 10413 RVA: 0x00178B74 File Offset: 0x00177B74
		internal int a(Stream A_0, int A_1)
		{
			if (this.e >= 8)
			{
				this.a[this.c++] = (byte)this.d;
				this.d >>= 8;
				this.e -= 8;
			}
			if (A_1 > this.c - this.b)
			{
				A_1 = this.c - this.b;
				A_0.Write(this.a, this.b, A_1);
				this.b = 0;
				this.c = 0;
			}
			else
			{
				A_0.Write(this.a, this.b, A_1);
				this.b += A_1;
			}
			return A_1;
		}

		// Token: 0x04001227 RID: 4647
		protected byte[] a;

		// Token: 0x04001228 RID: 4648
		private int b;

		// Token: 0x04001229 RID: 4649
		private int c;

		// Token: 0x0400122A RID: 4650
		private uint d;

		// Token: 0x0400122B RID: 4651
		private int e;
	}
}
