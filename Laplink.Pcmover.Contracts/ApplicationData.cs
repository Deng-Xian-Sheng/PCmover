using System;
using System.Drawing;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200000E RID: 14
	public class ApplicationData
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000025A6 File Offset: 0x000007A6
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000025AE File Offset: 0x000007AE
		public string AppId { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000025B7 File Offset: 0x000007B7
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000025BF File Offset: 0x000007BF
		public string User { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000025C8 File Offset: 0x000007C8
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000025D0 File Offset: 0x000007D0
		public ulong Id { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000025D9 File Offset: 0x000007D9
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000025E1 File Offset: 0x000007E1
		public bool Selected { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000025EA File Offset: 0x000007EA
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000025F2 File Offset: 0x000007F2
		public string Name { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000025FB File Offset: 0x000007FB
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002603 File Offset: 0x00000803
		public string Publisher { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000260C File Offset: 0x0000080C
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002614 File Offset: 0x00000814
		public Bitmap Bitmap { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000261D File Offset: 0x0000081D
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002625 File Offset: 0x00000825
		public TransferSafety Safety { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000262E File Offset: 0x0000082E
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002636 File Offset: 0x00000836
		public string Message { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000263F File Offset: 0x0000083F
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002647 File Offset: 0x00000847
		public SelectedReason Reason { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002650 File Offset: 0x00000850
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002658 File Offset: 0x00000858
		public bool DefaultSelected { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002661 File Offset: 0x00000861
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002669 File Offset: 0x00000869
		public bool IsDisplayable { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002672 File Offset: 0x00000872
		// (set) Token: 0x06000046 RID: 70 RVA: 0x0000267A File Offset: 0x0000087A
		public bool IsMatching { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002683 File Offset: 0x00000883
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000268B File Offset: 0x0000088B
		public bool IsComponent { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002694 File Offset: 0x00000894
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000269C File Offset: 0x0000089C
		public bool IsModifiable { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000026A5 File Offset: 0x000008A5
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000026AD File Offset: 0x000008AD
		public ulong AppDiskSpace { get; set; }
	}
}
