using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004D RID: 77
	public class MiscSettingsGroupData
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000226 RID: 550 RVA: 0x000032D7 File Offset: 0x000014D7
		// (set) Token: 0x06000227 RID: 551 RVA: 0x000032DF File Offset: 0x000014DF
		[XmlAttribute]
		public string Name { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000228 RID: 552 RVA: 0x000032E8 File Offset: 0x000014E8
		// (set) Token: 0x06000229 RID: 553 RVA: 0x000032F0 File Offset: 0x000014F0
		[XmlAttribute]
		public string DisplayName { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600022A RID: 554 RVA: 0x000032F9 File Offset: 0x000014F9
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00003301 File Offset: 0x00001501
		public List<MiscSettingData> Settings { get; set; }
	}
}
