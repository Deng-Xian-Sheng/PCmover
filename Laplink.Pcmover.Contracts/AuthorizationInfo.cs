using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000060 RID: 96
	public class AuthorizationInfo
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x0000394C File Offset: 0x00001B4C
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00003954 File Offset: 0x00001B54
		public bool IsAuthorized { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000395D File Offset: 0x00001B5D
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00003965 File Offset: 0x00001B65
		public string SerialNumber { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000396E File Offset: 0x00001B6E
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00003976 File Offset: 0x00001B76
		public string SessionCode { get; set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000397F File Offset: 0x00001B7F
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x00003987 File Offset: 0x00001B87
		public bool IsPreValidated { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x00003990 File Offset: 0x00001B90
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x00003998 File Offset: 0x00001B98
		public string WebValidatorShortcut { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060002AA RID: 682 RVA: 0x000039A1 File Offset: 0x00001BA1
		// (set) Token: 0x060002AB RID: 683 RVA: 0x000039A9 File Offset: 0x00001BA9
		public string WebValidatorQrCodeUrl { get; set; }
	}
}
