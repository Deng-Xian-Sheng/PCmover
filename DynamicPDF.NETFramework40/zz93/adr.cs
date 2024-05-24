using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000474 RID: 1140
	internal class adr : sa
	{
		// Token: 0x06002F40 RID: 12096 RVA: 0x001AD250 File Offset: 0x001AC250
		internal adr(int A_0, short A_1, int A_2, Stream A_3, byte[] A_4, int A_5) : base(A_3, A_4, A_5)
		{
			this.a = A_1;
			this.b = A_2;
			this.c = this.a(A_2 - 1);
			this.d = new short[A_0];
			for (int i = 0; i < A_0; i++)
			{
				this.d[i] = this.a(i);
			}
		}

		// Token: 0x06002F41 RID: 12097 RVA: 0x001AD2B6 File Offset: 0x001AC2B6
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(2, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x06002F42 RID: 12098 RVA: 0x001AD2E0 File Offset: 0x001AC2E0
		private short a(int A_0)
		{
			short result;
			if (A_0 >= this.b)
			{
				result = this.c;
			}
			else
			{
				result = (short)((base.e(A_0 * 4) * 1000 + (int)(this.a / 2)) / (int)this.a);
			}
			return result;
		}

		// Token: 0x06002F43 RID: 12099 RVA: 0x001AD328 File Offset: 0x001AC328
		internal short[] a()
		{
			return this.d;
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x001AD340 File Offset: 0x001AC340
		internal int a(int A_0, int A_1)
		{
			int result;
			if (this.d[A_1] > 0)
			{
				result = (A_0 * 1000 + (int)(this.a / 2)) / (int)this.a;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x04001680 RID: 5760
		private new short a;

		// Token: 0x04001681 RID: 5761
		private int b;

		// Token: 0x04001682 RID: 5762
		private short c;

		// Token: 0x04001683 RID: 5763
		private new short[] d;
	}
}
