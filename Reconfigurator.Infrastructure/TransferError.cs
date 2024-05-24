using System;
using System.IO;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x0200000B RID: 11
	public class TransferError
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000023D8 File Offset: 0x000005D8
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000023E0 File Offset: 0x000005E0
		public ErrorType ErrorType { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000023E9 File Offset: 0x000005E9
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000023F1 File Offset: 0x000005F1
		public ErrorResult ErrorResult { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000023FA File Offset: 0x000005FA
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002402 File Offset: 0x00000602
		public string Title { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000240B File Offset: 0x0000060B
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002413 File Offset: 0x00000613
		public FolderToMove Source { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000241C File Offset: 0x0000061C
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002424 File Offset: 0x00000624
		public DirectoryInfo Destination { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000242D File Offset: 0x0000062D
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002435 File Offset: 0x00000635
		public string ErrorText { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002B RID: 43 RVA: 0x0000243E File Offset: 0x0000063E
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002446 File Offset: 0x00000646
		public bool ShowReplace { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000244F File Offset: 0x0000064F
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002457 File Offset: 0x00000657
		public bool ShowSkip { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002460 File Offset: 0x00000660
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002468 File Offset: 0x00000668
		public bool ShowCancel { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002471 File Offset: 0x00000671
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002479 File Offset: 0x00000679
		public bool ShowContinue { get; set; }

		// Token: 0x06000033 RID: 51 RVA: 0x00002482 File Offset: 0x00000682
		public TransferError()
		{
			this.ShowReplace = false;
			this.ShowSkip = false;
			this.ShowCancel = false;
			this.ShowContinue = false;
		}

		// Token: 0x04000026 RID: 38
		public MoveLibraryData Library;
	}
}
