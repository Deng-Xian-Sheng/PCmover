using System;

namespace zz93
{
	// Token: 0x0200013C RID: 316
	internal class hw : fd
	{
		// Token: 0x06000BF9 RID: 3065 RVA: 0x0008FC10 File Offset: 0x0008EC10
		internal hw(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0008FC24 File Offset: 0x0008EC24
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 148329381)
			{
				if (num2 == 6662337)
				{
					this.a = new aga(g5.a);
					this.a.a(true);
					return;
				}
				if (num2 == 148329381)
				{
					this.a = new aga(g5.b);
					return;
				}
			}
			else
			{
				if (num2 == 505607249)
				{
					this.a = new aga(g5.a);
					this.a.d(true);
					return;
				}
				if (num2 == 677765424)
				{
					this.a = new aga(g5.c);
					return;
				}
				if (num2 == 960366471)
				{
					this.a = new aga(g5.a);
					return;
				}
			}
			this.a = new aga(g5.a);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0008FCE0 File Offset: 0x0008ECE0
		internal aga a()
		{
			return this.a;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0008FCF8 File Offset: 0x0008ECF8
		internal void a(aga A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0008FD04 File Offset: 0x0008ED04
		internal override int cv()
		{
			return 847005961;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0008FD1C File Offset: 0x0008ED1C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000640 RID: 1600
		private new aga a;
	}
}
