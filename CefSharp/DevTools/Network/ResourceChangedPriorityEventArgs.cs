using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002E9 RID: 745
	[DataContract]
	public class ResourceChangedPriorityEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x060015C1 RID: 5569 RVA: 0x00019AA7 File Offset: 0x00017CA7
		// (set) Token: 0x060015C2 RID: 5570 RVA: 0x00019AAF File Offset: 0x00017CAF
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x060015C3 RID: 5571 RVA: 0x00019AB8 File Offset: 0x00017CB8
		// (set) Token: 0x060015C4 RID: 5572 RVA: 0x00019AD4 File Offset: 0x00017CD4
		public ResourcePriority NewPriority
		{
			get
			{
				return (ResourcePriority)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourcePriority), this.newPriority);
			}
			set
			{
				this.newPriority = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x060015C5 RID: 5573 RVA: 0x00019AE7 File Offset: 0x00017CE7
		// (set) Token: 0x060015C6 RID: 5574 RVA: 0x00019AEF File Offset: 0x00017CEF
		[DataMember(Name = "newPriority", IsRequired = true)]
		internal string newPriority { get; private set; }

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x060015C7 RID: 5575 RVA: 0x00019AF8 File Offset: 0x00017CF8
		// (set) Token: 0x060015C8 RID: 5576 RVA: 0x00019B00 File Offset: 0x00017D00
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }
	}
}
