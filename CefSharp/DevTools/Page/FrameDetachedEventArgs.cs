using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025E RID: 606
	[DataContract]
	public class FrameDetachedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001129 RID: 4393 RVA: 0x000159E4 File Offset: 0x00013BE4
		// (set) Token: 0x0600112A RID: 4394 RVA: 0x000159EC File Offset: 0x00013BEC
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x0600112B RID: 4395 RVA: 0x000159F5 File Offset: 0x00013BF5
		// (set) Token: 0x0600112C RID: 4396 RVA: 0x00015A11 File Offset: 0x00013C11
		public FrameDetachedReason Reason
		{
			get
			{
				return (FrameDetachedReason)DevToolsDomainEventArgsBase.StringToEnum(typeof(FrameDetachedReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x0600112D RID: 4397 RVA: 0x00015A24 File Offset: 0x00013C24
		// (set) Token: 0x0600112E RID: 4398 RVA: 0x00015A2C File Offset: 0x00013C2C
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; private set; }
	}
}
