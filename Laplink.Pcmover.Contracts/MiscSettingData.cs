using System;
using System.Xml.Serialization;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004C RID: 76
	public class MiscSettingData
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00003293 File Offset: 0x00001493
		// (set) Token: 0x0600021E RID: 542 RVA: 0x0000329B File Offset: 0x0000149B
		[XmlAttribute]
		public string Name { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600021F RID: 543 RVA: 0x000032A4 File Offset: 0x000014A4
		// (set) Token: 0x06000220 RID: 544 RVA: 0x000032AC File Offset: 0x000014AC
		[XmlAttribute]
		public string Text { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000221 RID: 545 RVA: 0x000032B5 File Offset: 0x000014B5
		// (set) Token: 0x06000222 RID: 546 RVA: 0x000032BD File Offset: 0x000014BD
		public string Help { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000223 RID: 547 RVA: 0x000032C6 File Offset: 0x000014C6
		// (set) Token: 0x06000224 RID: 548 RVA: 0x000032CE File Offset: 0x000014CE
		[XmlAttribute]
		public bool Selected { get; set; }
	}
}
