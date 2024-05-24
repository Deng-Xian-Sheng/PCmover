using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000262 RID: 610
	[DataContract]
	public class FrameScheduledNavigationEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001147 RID: 4423 RVA: 0x00015B59 File Offset: 0x00013D59
		// (set) Token: 0x06001148 RID: 4424 RVA: 0x00015B61 File Offset: 0x00013D61
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001149 RID: 4425 RVA: 0x00015B6A File Offset: 0x00013D6A
		// (set) Token: 0x0600114A RID: 4426 RVA: 0x00015B72 File Offset: 0x00013D72
		[DataMember(Name = "delay", IsRequired = true)]
		public double Delay { get; private set; }

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x00015B7B File Offset: 0x00013D7B
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x00015B97 File Offset: 0x00013D97
		public ClientNavigationReason Reason
		{
			get
			{
				return (ClientNavigationReason)DevToolsDomainEventArgsBase.StringToEnum(typeof(ClientNavigationReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x00015BAA File Offset: 0x00013DAA
		// (set) Token: 0x0600114E RID: 4430 RVA: 0x00015BB2 File Offset: 0x00013DB2
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; private set; }

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x0600114F RID: 4431 RVA: 0x00015BBB File Offset: 0x00013DBB
		// (set) Token: 0x06001150 RID: 4432 RVA: 0x00015BC3 File Offset: 0x00013DC3
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }
	}
}
