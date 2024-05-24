using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E8 RID: 744
	[DataContract]
	public class RequestWillBeSentEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000199A4 File Offset: 0x00017BA4
		// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000199AC File Offset: 0x00017BAC
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x060015A8 RID: 5544 RVA: 0x000199B5 File Offset: 0x00017BB5
		// (set) Token: 0x060015A9 RID: 5545 RVA: 0x000199BD File Offset: 0x00017BBD
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; private set; }

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x060015AA RID: 5546 RVA: 0x000199C6 File Offset: 0x00017BC6
		// (set) Token: 0x060015AB RID: 5547 RVA: 0x000199CE File Offset: 0x00017BCE
		[DataMember(Name = "documentURL", IsRequired = true)]
		public string DocumentURL { get; private set; }

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x060015AC RID: 5548 RVA: 0x000199D7 File Offset: 0x00017BD7
		// (set) Token: 0x060015AD RID: 5549 RVA: 0x000199DF File Offset: 0x00017BDF
		[DataMember(Name = "request", IsRequired = true)]
		public Request Request { get; private set; }

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x060015AE RID: 5550 RVA: 0x000199E8 File Offset: 0x00017BE8
		// (set) Token: 0x060015AF RID: 5551 RVA: 0x000199F0 File Offset: 0x00017BF0
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x000199F9 File Offset: 0x00017BF9
		// (set) Token: 0x060015B1 RID: 5553 RVA: 0x00019A01 File Offset: 0x00017C01
		[DataMember(Name = "wallTime", IsRequired = true)]
		public double WallTime { get; private set; }

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x060015B2 RID: 5554 RVA: 0x00019A0A File Offset: 0x00017C0A
		// (set) Token: 0x060015B3 RID: 5555 RVA: 0x00019A12 File Offset: 0x00017C12
		[DataMember(Name = "initiator", IsRequired = true)]
		public Initiator Initiator { get; private set; }

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x060015B4 RID: 5556 RVA: 0x00019A1B File Offset: 0x00017C1B
		// (set) Token: 0x060015B5 RID: 5557 RVA: 0x00019A23 File Offset: 0x00017C23
		[DataMember(Name = "redirectHasExtraInfo", IsRequired = true)]
		public bool RedirectHasExtraInfo { get; private set; }

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x00019A2C File Offset: 0x00017C2C
		// (set) Token: 0x060015B7 RID: 5559 RVA: 0x00019A34 File Offset: 0x00017C34
		[DataMember(Name = "redirectResponse", IsRequired = false)]
		public Response RedirectResponse { get; private set; }

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x060015B8 RID: 5560 RVA: 0x00019A3D File Offset: 0x00017C3D
		// (set) Token: 0x060015B9 RID: 5561 RVA: 0x00019A59 File Offset: 0x00017C59
		public ResourceType? Type
		{
			get
			{
				return (ResourceType?)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType?), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x00019A6C File Offset: 0x00017C6C
		// (set) Token: 0x060015BB RID: 5563 RVA: 0x00019A74 File Offset: 0x00017C74
		[DataMember(Name = "type", IsRequired = false)]
		internal string type { get; private set; }

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x00019A7D File Offset: 0x00017C7D
		// (set) Token: 0x060015BD RID: 5565 RVA: 0x00019A85 File Offset: 0x00017C85
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; private set; }

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x060015BE RID: 5566 RVA: 0x00019A8E File Offset: 0x00017C8E
		// (set) Token: 0x060015BF RID: 5567 RVA: 0x00019A96 File Offset: 0x00017C96
		[DataMember(Name = "hasUserGesture", IsRequired = false)]
		public bool? HasUserGesture { get; private set; }
	}
}
