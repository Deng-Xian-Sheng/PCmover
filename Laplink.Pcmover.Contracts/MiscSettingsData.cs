using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200004E RID: 78
	public class MiscSettingsData
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600022D RID: 557 RVA: 0x0000330A File Offset: 0x0000150A
		// (set) Token: 0x0600022E RID: 558 RVA: 0x00003312 File Offset: 0x00001512
		public IEnumerable<MiscSettingsGroupData> Groups { get; set; }
	}
}
