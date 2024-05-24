using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000081 RID: 129
	public class FileTransferMethodInfo
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600035D RID: 861 RVA: 0x000040A0 File Offset: 0x000022A0
		// (set) Token: 0x0600035E RID: 862 RVA: 0x000040A8 File Offset: 0x000022A8
		public string FileName { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600035F RID: 863 RVA: 0x000040B1 File Offset: 0x000022B1
		// (set) Token: 0x06000360 RID: 864 RVA: 0x000040B9 File Offset: 0x000022B9
		public string AnyMachineName { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000361 RID: 865 RVA: 0x000040C2 File Offset: 0x000022C2
		// (set) Token: 0x06000362 RID: 866 RVA: 0x000040CA File Offset: 0x000022CA
		public bool CanSpan { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000363 RID: 867 RVA: 0x000040D3 File Offset: 0x000022D3
		// (set) Token: 0x06000364 RID: 868 RVA: 0x000040DB File Offset: 0x000022DB
		public bool NotifySpan { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000365 RID: 869 RVA: 0x000040E4 File Offset: 0x000022E4
		// (set) Token: 0x06000366 RID: 870 RVA: 0x000040EC File Offset: 0x000022EC
		public ulong SpanSize { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000367 RID: 871 RVA: 0x000040F5 File Offset: 0x000022F5
		// (set) Token: 0x06000368 RID: 872 RVA: 0x000040FD File Offset: 0x000022FD
		public string CloudToken { get; set; }
	}
}
