using System;
using System.IO;

namespace zz93
{
	// Token: 0x020002CA RID: 714
	internal class sm
	{
		// Token: 0x06002083 RID: 8323 RVA: 0x0013FD73 File Offset: 0x0013ED73
		internal sm(int A_0, Stream A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.a();
		}

		// Token: 0x06002084 RID: 8324 RVA: 0x0013FD94 File Offset: 0x0013ED94
		internal void a()
		{
			byte[] array = new byte[this.a];
			if (this.a > 0)
			{
				for (int i = 0; i < this.a; i++)
				{
					array[i] = (byte)this.b.ReadByte();
				}
				this.c = new sh(array);
			}
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x0013FDF4 File Offset: 0x0013EDF4
		internal long b()
		{
			return this.c.d();
		}

		// Token: 0x04000E33 RID: 3635
		private int a;

		// Token: 0x04000E34 RID: 3636
		private Stream b;

		// Token: 0x04000E35 RID: 3637
		private sh c;
	}
}
