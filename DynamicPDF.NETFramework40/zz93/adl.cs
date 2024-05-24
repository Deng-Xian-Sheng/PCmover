using System;

namespace zz93
{
	// Token: 0x0200046E RID: 1134
	internal class adl
	{
		// Token: 0x06002F1F RID: 12063 RVA: 0x001AC8FE File Offset: 0x001AB8FE
		internal adl(ushort A_0, byte A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002F20 RID: 12064 RVA: 0x001AC918 File Offset: 0x001AB918
		internal ushort a()
		{
			return this.a;
		}

		// Token: 0x06002F21 RID: 12065 RVA: 0x001AC930 File Offset: 0x001AB930
		internal byte b()
		{
			return this.b;
		}

		// Token: 0x06002F22 RID: 12066 RVA: 0x001AC948 File Offset: 0x001AB948
		internal void a(byte A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04001668 RID: 5736
		private ushort a;

		// Token: 0x04001669 RID: 5737
		private byte b;
	}
}
