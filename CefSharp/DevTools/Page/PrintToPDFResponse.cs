using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000280 RID: 640
	[DataContract]
	public class PrintToPDFResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x0600120F RID: 4623 RVA: 0x00016247 File Offset: 0x00014447
		// (set) Token: 0x06001210 RID: 4624 RVA: 0x0001624F File Offset: 0x0001444F
		[DataMember]
		internal string data { get; set; }

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06001211 RID: 4625 RVA: 0x00016258 File Offset: 0x00014458
		public byte[] Data
		{
			get
			{
				return base.Convert(this.data);
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06001212 RID: 4626 RVA: 0x00016266 File Offset: 0x00014466
		// (set) Token: 0x06001213 RID: 4627 RVA: 0x0001626E File Offset: 0x0001446E
		[DataMember]
		internal string stream { get; set; }

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06001214 RID: 4628 RVA: 0x00016277 File Offset: 0x00014477
		public string Stream
		{
			get
			{
				return this.stream;
			}
		}
	}
}
