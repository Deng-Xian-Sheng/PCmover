using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000087 RID: 135
	public interface ITransferrableContainer : ITransferrable
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000388 RID: 904
		// (set) Token: 0x06000389 RID: 905
		string FullPath { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600038A RID: 906
		// (set) Token: 0x0600038B RID: 907
		ulong NumContainers { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600038C RID: 908
		// (set) Token: 0x0600038D RID: 909
		ulong NumItems { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600038E RID: 910
		// (set) Token: 0x0600038F RID: 911
		ulong TotalSize { get; set; }
	}
}
