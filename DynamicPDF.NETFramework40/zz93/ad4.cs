using System;
using System.IO;

namespace zz93
{
	// Token: 0x02000481 RID: 1153
	internal class ad4 : sa
	{
		// Token: 0x06002FA4 RID: 12196 RVA: 0x001AF598 File Offset: 0x001AE598
		internal ad4(Stream A_0, byte[] A_1, int A_2, int A_3) : base(A_0, A_1, A_2)
		{
			this.a = base.h(4);
			this.b = (short)(((float)base.i(8) * 1000f + (float)(A_3 / 2)) / (float)A_3);
			this.c = (short)(((float)base.i(10) * 1000f + (float)(A_3 / 2)) / (float)A_3);
			base.o();
		}

		// Token: 0x06002FA5 RID: 12197 RVA: 0x001AF604 File Offset: 0x001AE604
		internal float a()
		{
			return this.a;
		}

		// Token: 0x06002FA6 RID: 12198 RVA: 0x001AF61C File Offset: 0x001AE61C
		internal short b()
		{
			return this.b;
		}

		// Token: 0x06002FA7 RID: 12199 RVA: 0x001AF634 File Offset: 0x001AE634
		internal short c()
		{
			return this.c;
		}

		// Token: 0x040016AD RID: 5805
		private new float a;

		// Token: 0x040016AE RID: 5806
		private short b;

		// Token: 0x040016AF RID: 5807
		private short c;
	}
}
