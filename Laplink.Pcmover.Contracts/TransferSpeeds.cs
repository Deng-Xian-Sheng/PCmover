using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200008E RID: 142
	public class TransferSpeeds
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00004584 File Offset: 0x00002784
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x0000458C File Offset: 0x0000278C
		public ulong RemoteSpeed { get; set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00004595 File Offset: 0x00002795
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x0000459D File Offset: 0x0000279D
		public ulong LocalSpeed { get; set; }
	}
}
