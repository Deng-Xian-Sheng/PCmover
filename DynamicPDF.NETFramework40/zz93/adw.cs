using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000479 RID: 1145
	internal class adw : sa
	{
		// Token: 0x06002F62 RID: 12130 RVA: 0x001ADC0C File Offset: 0x001ACC0C
		internal adw(Stream A_0, byte[] A_1, int A_2, int A_3) : base(A_0, A_1, A_2)
		{
			this.a = (ushort)base.e(2);
			if (this.a > 0)
			{
				this.b = new adv[(int)this.a];
				int num = 4;
				for (int i = 0; i < (int)this.a; i++)
				{
					this.b[i] = new adv(this, A_3, ref num);
				}
			}
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x001ADC84 File Offset: 0x001ACC84
		internal adv[] a()
		{
			return this.b;
		}

		// Token: 0x04001690 RID: 5776
		private new ushort a;

		// Token: 0x04001691 RID: 5777
		private adv[] b;
	}
}
