using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004A RID: 74
	public class DriveSpaceData
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000322D File Offset: 0x0000142D
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00003235 File Offset: 0x00001435
		public string Drive { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000323E File Offset: 0x0000143E
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00003246 File Offset: 0x00001446
		public ulong TotalBytes { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000324F File Offset: 0x0000144F
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00003257 File Offset: 0x00001457
		public ulong FreeBytes { get; set; }
	}
}
