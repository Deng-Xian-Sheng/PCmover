using System;
using System.ComponentModel;

namespace Prism.Modularity
{
	// Token: 0x02000061 RID: 97
	public class ModuleDownloadProgressChangedEventArgs : ProgressChangedEventArgs
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x00007B1A File Offset: 0x00005D1A
		public ModuleDownloadProgressChangedEventArgs(ModuleInfo moduleInfo, long bytesReceived, long totalBytesToReceive) : base(ModuleDownloadProgressChangedEventArgs.CalculateProgressPercentage(bytesReceived, totalBytesToReceive), null)
		{
			if (moduleInfo == null)
			{
				throw new ArgumentNullException("moduleInfo");
			}
			this.ModuleInfo = moduleInfo;
			this.BytesReceived = bytesReceived;
			this.TotalBytesToReceive = totalBytesToReceive;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00007B4D File Offset: 0x00005D4D
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x00007B55 File Offset: 0x00005D55
		public ModuleInfo ModuleInfo { get; private set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00007B5E File Offset: 0x00005D5E
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00007B66 File Offset: 0x00005D66
		public long BytesReceived { get; private set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00007B6F File Offset: 0x00005D6F
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00007B77 File Offset: 0x00005D77
		public long TotalBytesToReceive { get; private set; }

		// Token: 0x060002CE RID: 718 RVA: 0x00007B80 File Offset: 0x00005D80
		private static int CalculateProgressPercentage(long bytesReceived, long totalBytesToReceive)
		{
			if (bytesReceived == 0L || totalBytesToReceive == 0L || totalBytesToReceive == -1L)
			{
				return 0;
			}
			return (int)(bytesReceived * 100L / totalBytesToReceive);
		}
	}
}
