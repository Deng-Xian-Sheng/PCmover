using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000205 RID: 517
	[DataContract]
	public class InterestGroupAccessedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x00013C20 File Offset: 0x00011E20
		// (set) Token: 0x06000ECB RID: 3787 RVA: 0x00013C28 File Offset: 0x00011E28
		[DataMember(Name = "accessTime", IsRequired = true)]
		public double AccessTime { get; private set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x00013C31 File Offset: 0x00011E31
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x00013C4D File Offset: 0x00011E4D
		public InterestGroupAccessType Type
		{
			get
			{
				return (InterestGroupAccessType)DevToolsDomainEventArgsBase.StringToEnum(typeof(InterestGroupAccessType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00013C60 File Offset: 0x00011E60
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00013C68 File Offset: 0x00011E68
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00013C71 File Offset: 0x00011E71
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00013C79 File Offset: 0x00011E79
		[DataMember(Name = "ownerOrigin", IsRequired = true)]
		public string OwnerOrigin { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00013C82 File Offset: 0x00011E82
		// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x00013C8A File Offset: 0x00011E8A
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; private set; }
	}
}
