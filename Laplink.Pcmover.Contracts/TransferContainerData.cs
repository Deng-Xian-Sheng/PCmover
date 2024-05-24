using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000077 RID: 119
	public class TransferContainerData : ContainerData
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00003F4F File Offset: 0x0000214F
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00003F57 File Offset: 0x00002157
		public TransferStatus Status { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00003F60 File Offset: 0x00002160
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00003F68 File Offset: 0x00002168
		public IEnumerable<TransferStatus> ContainersStatus { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00003F71 File Offset: 0x00002171
		// (set) Token: 0x06000339 RID: 825 RVA: 0x00003F79 File Offset: 0x00002179
		public IEnumerable<TransferStatus> ItemsStatus { get; set; }
	}
}
