using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000273 RID: 627
	[DataContract]
	public class CaptureScreenshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x00015F49 File Offset: 0x00014149
		// (set) Token: 0x060011B5 RID: 4533 RVA: 0x00015F51 File Offset: 0x00014151
		[DataMember]
		internal string data { get; set; }

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x00015F5A File Offset: 0x0001415A
		public byte[] Data
		{
			get
			{
				return base.Convert(this.data);
			}
		}
	}
}
