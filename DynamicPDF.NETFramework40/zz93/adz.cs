using System;
using System.IO;

namespace zz93
{
	// Token: 0x0200047C RID: 1148
	internal class adz : sa
	{
		// Token: 0x06002F69 RID: 12137 RVA: 0x001ADDEF File Offset: 0x001ACDEF
		internal adz(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
			this.a = base.e(4);
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x001ADE0A File Offset: 0x001ACE0A
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(5, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x001ADE34 File Offset: 0x001ACE34
		internal int a()
		{
			return this.a;
		}

		// Token: 0x04001693 RID: 5779
		private new int a;
	}
}
