using System;
using System.Xml.Serialization;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000036 RID: 54
	public class DrivePair
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00002F13 File Offset: 0x00001113
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00002F1B File Offset: 0x0000111B
		[XmlAttribute]
		public string OldDrive { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00002F24 File Offset: 0x00001124
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00002F2C File Offset: 0x0000112C
		[XmlAttribute]
		public string NewDrive { get; set; }
	}
}
