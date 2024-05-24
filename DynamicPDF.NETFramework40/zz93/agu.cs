using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004E5 RID: 1253
	internal class agu : aba
	{
		// Token: 0x06003304 RID: 13060 RVA: 0x001C6361 File Offset: 0x001C5361
		internal agu(PdfDocument A_0, byte[] A_1) : base(A_0)
		{
			this.b = A_1;
			this.c = A_1.Length;
			this.d = new agt(this, A_1);
		}

		// Token: 0x06003305 RID: 13061 RVA: 0x001C638C File Offset: 0x001C538C
		internal override void lb()
		{
			agw agw = new agw(this);
			agw.le();
		}

		// Token: 0x06003306 RID: 13062 RVA: 0x001C63A8 File Offset: 0x001C53A8
		internal agt a()
		{
			return this.d;
		}

		// Token: 0x06003307 RID: 13063 RVA: 0x001C63C0 File Offset: 0x001C53C0
		internal override agu lc()
		{
			return this;
		}

		// Token: 0x06003308 RID: 13064 RVA: 0x001C63D4 File Offset: 0x001C53D4
		internal ab8 a(long A_0, abt A_1, abi A_2)
		{
			int num = (int)A_0;
			while (this.b[num] != 60)
			{
				num++;
			}
			abj a_ = this.d.b(ref num, A_2, 0);
			ab8 ab = new ab8();
			ab.a(a_, A_1);
			return ab;
		}

		// Token: 0x06003309 RID: 13065 RVA: 0x001C6424 File Offset: 0x001C5424
		internal afj a(long A_0, abi A_1)
		{
			int num = (int)A_0;
			while (this.b[num] != 60)
			{
				num++;
			}
			return (afj)this.d.b(ref num, A_1, int.MaxValue);
		}

		// Token: 0x0600330A RID: 13066 RVA: 0x001C646C File Offset: 0x001C546C
		internal override abd ld(ab9 A_0)
		{
			int num = (int)A_0.a();
			abd result = null;
			if (base.af().g() == null)
			{
				while (this.b[num] != 106)
				{
					num++;
				}
				num++;
				num = this.c(num);
				result = this.d.a(ref num, new abi(base.af()), (int)A_0.c());
			}
			else if (A_0.c() > 0L)
			{
				while (this.b[num] < 48)
				{
					num++;
				}
				num = this.a(num);
				while (this.b[num] < 48)
				{
					num++;
				}
				int num2 = 0;
				while (ags.d(this.b[num]))
				{
					num2 *= 10;
					num2 += (int)(this.b[num++] - 48);
				}
				num = this.c(num);
				while (this.b[num] != 106)
				{
					num++;
				}
				num++;
				abm a_ = new abm(base.af(), (long)A_0.l(), num2);
				result = this.d.a(ref num, a_, (int)A_0.c());
			}
			return result;
		}

		// Token: 0x0600330B RID: 13067 RVA: 0x001C65C4 File Offset: 0x001C55C4
		internal int b()
		{
			return this.c;
		}

		// Token: 0x0600330C RID: 13068 RVA: 0x001C65DC File Offset: 0x001C55DC
		internal byte[] c()
		{
			return this.b;
		}

		// Token: 0x0600330D RID: 13069 RVA: 0x001C65F4 File Offset: 0x001C55F4
		internal int b(int A_0)
		{
			int num = 0;
			while (this.b[A_0] == 48)
			{
				A_0++;
			}
			while (ags.d(this.b[A_0]))
			{
				num = num * 10 + (int)this.b[A_0] - 48;
				A_0++;
			}
			return num;
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x001C6650 File Offset: 0x001C5650
		private int a(int A_0)
		{
			while (ags.d(this.b[A_0]))
			{
				A_0++;
			}
			return A_0;
		}

		// Token: 0x0600330F RID: 13071 RVA: 0x001C667C File Offset: 0x001C567C
		internal int c(int A_0)
		{
			while (this.b[A_0] <= 32)
			{
				A_0++;
			}
			int result;
			if (this.b[A_0] == 37)
			{
				A_0++;
				while (this.b[A_0] != 10 && this.b[A_0] != 13)
				{
					A_0++;
				}
				result = this.c(A_0);
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x04001868 RID: 6248
		private const int a = 256;

		// Token: 0x04001869 RID: 6249
		private byte[] b;

		// Token: 0x0400186A RID: 6250
		private int c;

		// Token: 0x0400186B RID: 6251
		private agt d;
	}
}
