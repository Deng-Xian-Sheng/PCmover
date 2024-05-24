using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D7 RID: 727
	[DataContract]
	public class ClientSecurityState : DevToolsDomainEntityBase
	{
		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06001500 RID: 5376 RVA: 0x000192DE File Offset: 0x000174DE
		// (set) Token: 0x06001501 RID: 5377 RVA: 0x000192E6 File Offset: 0x000174E6
		[DataMember(Name = "initiatorIsSecureContext", IsRequired = true)]
		public bool InitiatorIsSecureContext { get; set; }

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06001502 RID: 5378 RVA: 0x000192EF File Offset: 0x000174EF
		// (set) Token: 0x06001503 RID: 5379 RVA: 0x0001930B File Offset: 0x0001750B
		public IPAddressSpace InitiatorIPAddressSpace
		{
			get
			{
				return (IPAddressSpace)DevToolsDomainEntityBase.StringToEnum(typeof(IPAddressSpace), this.initiatorIPAddressSpace);
			}
			set
			{
				this.initiatorIPAddressSpace = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06001504 RID: 5380 RVA: 0x0001931E File Offset: 0x0001751E
		// (set) Token: 0x06001505 RID: 5381 RVA: 0x00019326 File Offset: 0x00017526
		[DataMember(Name = "initiatorIPAddressSpace", IsRequired = true)]
		internal string initiatorIPAddressSpace { get; set; }

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06001506 RID: 5382 RVA: 0x0001932F File Offset: 0x0001752F
		// (set) Token: 0x06001507 RID: 5383 RVA: 0x0001934B File Offset: 0x0001754B
		public PrivateNetworkRequestPolicy PrivateNetworkRequestPolicy
		{
			get
			{
				return (PrivateNetworkRequestPolicy)DevToolsDomainEntityBase.StringToEnum(typeof(PrivateNetworkRequestPolicy), this.privateNetworkRequestPolicy);
			}
			set
			{
				this.privateNetworkRequestPolicy = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x06001508 RID: 5384 RVA: 0x0001935E File Offset: 0x0001755E
		// (set) Token: 0x06001509 RID: 5385 RVA: 0x00019366 File Offset: 0x00017566
		[DataMember(Name = "privateNetworkRequestPolicy", IsRequired = true)]
		internal string privateNetworkRequestPolicy { get; set; }
	}
}
