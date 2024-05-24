using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeadlessExperimental
{
	// Token: 0x0200034D RID: 845
	[DataContract]
	public class BeginFrameResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x0001CFA2 File Offset: 0x0001B1A2
		// (set) Token: 0x06001881 RID: 6273 RVA: 0x0001CFAA File Offset: 0x0001B1AA
		[DataMember]
		internal bool hasDamage { get; set; }

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x06001882 RID: 6274 RVA: 0x0001CFB3 File Offset: 0x0001B1B3
		public bool HasDamage
		{
			get
			{
				return this.hasDamage;
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x06001883 RID: 6275 RVA: 0x0001CFBB File Offset: 0x0001B1BB
		// (set) Token: 0x06001884 RID: 6276 RVA: 0x0001CFC3 File Offset: 0x0001B1C3
		[DataMember]
		internal string screenshotData { get; set; }

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x06001885 RID: 6277 RVA: 0x0001CFCC File Offset: 0x0001B1CC
		public byte[] ScreenshotData
		{
			get
			{
				return base.Convert(this.screenshotData);
			}
		}
	}
}
