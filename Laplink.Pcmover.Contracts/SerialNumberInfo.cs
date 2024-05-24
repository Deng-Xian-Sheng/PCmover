using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000065 RID: 101
	public class SerialNumberInfo
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00003A24 File Offset: 0x00001C24
		// (set) Token: 0x060002B6 RID: 694 RVA: 0x00003A2C File Offset: 0x00001C2C
		public SerialNumberInfoResult Result { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00003A35 File Offset: 0x00001C35
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x00003A3D File Offset: 0x00001C3D
		public string NormalizedKey { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00003A46 File Offset: 0x00001C46
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00003A4E File Offset: 0x00001C4E
		public int NumLicenses { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00003A57 File Offset: 0x00001C57
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00003A5F File Offset: 0x00001C5F
		public int NumUsed { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060002BD RID: 701 RVA: 0x00003A68 File Offset: 0x00001C68
		// (set) Token: 0x060002BE RID: 702 RVA: 0x00003A70 File Offset: 0x00001C70
		public int LicenseType { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060002BF RID: 703 RVA: 0x00003A79 File Offset: 0x00001C79
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x00003A81 File Offset: 0x00001C81
		public int MatchedType { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00003A8A File Offset: 0x00001C8A
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x00003A92 File Offset: 0x00001C92
		public string EndDate { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00003A9B File Offset: 0x00001C9B
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x00003AA3 File Offset: 0x00001CA3
		public bool Expired { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00003AAC File Offset: 0x00001CAC
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x00003AB4 File Offset: 0x00001CB4
		public string ProxyUrl { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00003ABD File Offset: 0x00001CBD
		public bool IsValid
		{
			get
			{
				return this.Result == SerialNumberInfoResult.ValidSerialNumber && this.NumLicenses > 0 && this.NumUsed <= this.NumLicenses && this.MatchedType != 0 && !this.Expired;
			}
		}
	}
}
