using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004B RID: 75
	public class MachineDriveInfo
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00003260 File Offset: 0x00001460
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00003268 File Offset: 0x00001468
		public string HardDrives { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00003271 File Offset: 0x00001471
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00003279 File Offset: 0x00001479
		public string UsbDrives { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00003282 File Offset: 0x00001482
		// (set) Token: 0x0600021B RID: 539 RVA: 0x0000328A File Offset: 0x0000148A
		public string VirtualDrives { get; set; }
	}
}
