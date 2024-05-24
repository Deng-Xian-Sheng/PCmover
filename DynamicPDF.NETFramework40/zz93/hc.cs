using System;

namespace zz93
{
	// Token: 0x02000128 RID: 296
	internal class hc : fd
	{
		// Token: 0x06000B4E RID: 2894 RVA: 0x0008A86C File Offset: 0x0008986C
		internal hc(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0008A880 File Offset: 0x00089880
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 <= 7021096)
			{
				if (num2 == 2250341)
				{
					this.a = new f0(g3.c);
					this.a.a(true);
					return;
				}
				if (num2 == 7021096)
				{
					this.a = new f0(g3.a);
					return;
				}
			}
			else
			{
				if (num2 == 448574430)
				{
					this.a = new f0(g3.b);
					return;
				}
				if (num2 == 505607249)
				{
					this.a = new f0(g3.c);
					this.a.d(true);
					return;
				}
			}
			this.a = new f0(g3.c);
			this.a.a(true);
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0008A930 File Offset: 0x00089930
		internal f0 a()
		{
			return this.a;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0008A948 File Offset: 0x00089948
		internal override int cv()
		{
			return 436574770;
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0008A960 File Offset: 0x00089960
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000608 RID: 1544
		private new f0 a;
	}
}
