using System;
using System.Collections;

namespace zz93
{
	// Token: 0x020003A9 RID: 937
	internal class yj
	{
		// Token: 0x060027C5 RID: 10181 RVA: 0x0016C37C File Offset: 0x0016B37C
		internal yj(ye A_0, uint A_1)
		{
			this.a = A_1;
			this.c = A_0;
			this.b = A_0.gt(A_1);
			this.d = A_0.a(A_1 + 2U, (int)(this.b * 12));
			this.a();
			this.b();
		}

		// Token: 0x060027C6 RID: 10182 RVA: 0x0016C3E4 File Offset: 0x0016B3E4
		internal void b()
		{
			uint num = this.e;
			for (int i = 1; i < (int)this.b; i++)
			{
				uint num2 = (uint)this.c.gv(this.d, (uint)(12 * i));
				if (num2 < num)
				{
					this.c();
					break;
				}
				num = num2;
			}
		}

		// Token: 0x060027C7 RID: 10183 RVA: 0x0016C440 File Offset: 0x0016B440
		internal void c()
		{
			this.g = new Hashtable((int)this.b);
			for (ushort num = 0; num < this.b; num += 1)
			{
				uint num2 = (uint)this.c.gv(this.d, (uint)(num * 12));
				this.g.Add(num2, num);
			}
		}

		// Token: 0x060027C8 RID: 10184 RVA: 0x0016C4A8 File Offset: 0x0016B4A8
		internal yj d()
		{
			uint num = this.c.gu((uint)((ulong)(this.a + 2U) + (ulong)((long)(this.b * 12))));
			yj result;
			if (num == 0U || (ulong)num >= (ulong)this.c.a().Length || this.c.gt(num) <= 0)
			{
				result = null;
			}
			else
			{
				result = new yj(this.c, num);
			}
			return result;
		}

		// Token: 0x060027C9 RID: 10185 RVA: 0x0016C519 File Offset: 0x0016B519
		private void a()
		{
			this.f = 0;
			this.e = (uint)this.c.gv(this.d, 0U);
		}

		// Token: 0x060027CA RID: 10186 RVA: 0x0016C53C File Offset: 0x0016B53C
		internal bool a(uint A_0)
		{
			object obj = this.g[A_0];
			bool result;
			if (obj == null)
			{
				result = false;
			}
			else
			{
				this.f = (ushort)obj;
				this.e = A_0;
				result = true;
			}
			return result;
		}

		// Token: 0x060027CB RID: 10187 RVA: 0x0016C584 File Offset: 0x0016B584
		internal bool b(uint A_0)
		{
			bool result;
			if (this.g != null)
			{
				result = this.a(A_0);
			}
			else
			{
				while (this.e < A_0 && this.f < this.b - 1)
				{
					this.f += 1;
					this.e = (uint)this.c.gv(this.d, (uint)(this.f * 12));
				}
				result = (this.e == A_0);
			}
			return result;
		}

		// Token: 0x060027CC RID: 10188 RVA: 0x0016C60C File Offset: 0x0016B60C
		internal bool c(uint A_0)
		{
			bool result;
			if (this.g != null)
			{
				result = this.a(A_0);
			}
			else
			{
				while (this.e > A_0 && this.f > 0)
				{
					this.f -= 1;
					this.e = (uint)this.c.gv(this.d, (uint)(this.f * 12));
				}
				result = (this.e == A_0);
			}
			return result;
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x0016C68C File Offset: 0x0016B68C
		internal ushort e()
		{
			return this.c.gv(this.d, (uint)(this.f * 12 + 8));
		}

		// Token: 0x060027CE RID: 10190 RVA: 0x0016C6BC File Offset: 0x0016B6BC
		internal uint f()
		{
			ushort num = this.g();
			uint result;
			if (num == 3)
			{
				result = (uint)this.e();
			}
			else
			{
				result = this.i();
			}
			return result;
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x0016C6F0 File Offset: 0x0016B6F0
		internal ushort g()
		{
			return this.c.gv(this.d, (uint)(this.f * 12 + 2));
		}

		// Token: 0x060027D0 RID: 10192 RVA: 0x0016C720 File Offset: 0x0016B720
		internal uint h()
		{
			return this.c.gw(this.d, (uint)(this.f * 12 + 4));
		}

		// Token: 0x060027D1 RID: 10193 RVA: 0x0016C750 File Offset: 0x0016B750
		internal uint i()
		{
			return this.c.gw(this.d, (uint)(this.f * 12 + 8));
		}

		// Token: 0x060027D2 RID: 10194 RVA: 0x0016C780 File Offset: 0x0016B780
		internal float j()
		{
			byte[] array = new byte[8];
			this.a(this.i(), array, 0, 8);
			uint num = this.c.gw(array, 4U);
			float result;
			if (num == 0U)
			{
				result = 0f;
			}
			else
			{
				uint num2 = this.c.gw(array, 0U);
				if (num2 == 0U)
				{
					result = 0f;
				}
				else
				{
					result = num2 / num;
				}
			}
			return result;
		}

		// Token: 0x060027D3 RID: 10195 RVA: 0x0016C7F4 File Offset: 0x0016B7F4
		internal uint[] k()
		{
			ushort num = this.g();
			uint[] result;
			if (num == 3)
			{
				result = this.l();
			}
			else
			{
				result = this.o();
			}
			return result;
		}

		// Token: 0x060027D4 RID: 10196 RVA: 0x0016C827 File Offset: 0x0016B827
		internal void a(uint A_0, byte[] A_1, int A_2, int A_3)
		{
			this.c.a(A_0, A_1, A_2, A_3);
		}

		// Token: 0x060027D5 RID: 10197 RVA: 0x0016C83C File Offset: 0x0016B83C
		internal uint[] l()
		{
			uint num = this.h();
			uint[] array = new uint[num];
			if (num <= 2U)
			{
				array[0] = (uint)this.e();
				if (num == 2U)
				{
					array[1] = (uint)this.c.gv(this.d, (uint)(this.f * 12 + 10));
				}
			}
			else
			{
				byte[] a_ = this.c.a(this.i(), num * 2U);
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					array[num2] = (uint)this.c.gv(a_, (uint)(num2 * 2));
					num2++;
				}
			}
			return array;
		}

		// Token: 0x060027D6 RID: 10198 RVA: 0x0016C8E4 File Offset: 0x0016B8E4
		internal byte[] m()
		{
			uint a_ = this.h();
			return this.c.a(this.i(), a_);
		}

		// Token: 0x060027D7 RID: 10199 RVA: 0x0016C914 File Offset: 0x0016B914
		internal byte[] n()
		{
			uint num = this.h();
			uint num2 = 0U;
			uint num3 = num / 3U * 2U;
			uint num4 = num3 * 2U;
			if (this.c is yp)
			{
				num2 += 1U;
				num3 += 1U;
				num4 += 1U;
			}
			byte[] array = new byte[num];
			byte[] array2 = this.c.a(this.i(), num * 2U);
			int num5 = 0;
			while ((long)num5 < (long)((ulong)num))
			{
				array[num5++] = array2[(int)((UIntPtr)num2)];
				array[num5++] = array2[(int)((UIntPtr)num3)];
				array[num5++] = array2[(int)((UIntPtr)num4)];
				num2 += 2U;
				num3 += 2U;
				num4 += 2U;
			}
			return array;
		}

		// Token: 0x060027D8 RID: 10200 RVA: 0x0016C9D0 File Offset: 0x0016B9D0
		internal uint[] o()
		{
			int num = (int)this.h();
			uint[] array = new uint[num];
			if (num == 1)
			{
				array[0] = this.i();
			}
			else
			{
				byte[] a_ = this.c.a(this.i(), (uint)(num * 4));
				for (int i = 0; i < num; i++)
				{
					array[i] = this.c.gw(a_, (uint)(i * 4));
				}
			}
			return array;
		}

		// Token: 0x060027D9 RID: 10201 RVA: 0x0016CA4C File Offset: 0x0016BA4C
		internal int p()
		{
			return (int)this.c.a().Length;
		}

		// Token: 0x060027DA RID: 10202 RVA: 0x0016CA70 File Offset: 0x0016BA70
		internal int d(uint A_0)
		{
			int result = 0;
			uint num = (uint)this.c.gt(A_0);
			byte[] array = this.c.a(A_0 + 2U, num * 12U);
			for (int i = 0; i < array.Length; i += 12)
			{
				if (array[i] == 1 && array[i + 1] == 160)
				{
					result = ((int)array[i + 8] | (int)array[i + 9] << 8);
					break;
				}
				if (array[i] == 160 && array[i + 1] == 1)
				{
					result = ((int)array[i + 8] << 8 | (int)array[i + 9]);
					break;
				}
			}
			return result;
		}

		// Token: 0x0400114C RID: 4428
		private uint a;

		// Token: 0x0400114D RID: 4429
		private ushort b;

		// Token: 0x0400114E RID: 4430
		private ye c;

		// Token: 0x0400114F RID: 4431
		private byte[] d = null;

		// Token: 0x04001150 RID: 4432
		private uint e;

		// Token: 0x04001151 RID: 4433
		private ushort f;

		// Token: 0x04001152 RID: 4434
		private Hashtable g = null;
	}
}
