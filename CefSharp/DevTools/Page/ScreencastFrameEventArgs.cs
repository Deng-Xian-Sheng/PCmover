using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026E RID: 622
	[DataContract]
	public class ScreencastFrameEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06001198 RID: 4504 RVA: 0x00015E5E File Offset: 0x0001405E
		// (set) Token: 0x06001199 RID: 4505 RVA: 0x00015E66 File Offset: 0x00014066
		[DataMember(Name = "data", IsRequired = true)]
		public byte[] Data { get; private set; }

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x0600119A RID: 4506 RVA: 0x00015E6F File Offset: 0x0001406F
		// (set) Token: 0x0600119B RID: 4507 RVA: 0x00015E77 File Offset: 0x00014077
		[DataMember(Name = "metadata", IsRequired = true)]
		public ScreencastFrameMetadata Metadata { get; private set; }

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x0600119C RID: 4508 RVA: 0x00015E80 File Offset: 0x00014080
		// (set) Token: 0x0600119D RID: 4509 RVA: 0x00015E88 File Offset: 0x00014088
		[DataMember(Name = "sessionId", IsRequired = true)]
		public int SessionId { get; private set; }
	}
}
