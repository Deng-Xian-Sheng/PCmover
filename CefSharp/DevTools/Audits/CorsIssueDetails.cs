using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000420 RID: 1056
	[DataContract]
	public class CorsIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x06001EAF RID: 7855 RVA: 0x00022EFF File Offset: 0x000210FF
		// (set) Token: 0x06001EB0 RID: 7856 RVA: 0x00022F07 File Offset: 0x00021107
		[DataMember(Name = "corsErrorStatus", IsRequired = true)]
		public CorsErrorStatus CorsErrorStatus { get; set; }

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x06001EB1 RID: 7857 RVA: 0x00022F10 File Offset: 0x00021110
		// (set) Token: 0x06001EB2 RID: 7858 RVA: 0x00022F18 File Offset: 0x00021118
		[DataMember(Name = "isWarning", IsRequired = true)]
		public bool IsWarning { get; set; }

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x06001EB3 RID: 7859 RVA: 0x00022F21 File Offset: 0x00021121
		// (set) Token: 0x06001EB4 RID: 7860 RVA: 0x00022F29 File Offset: 0x00021129
		[DataMember(Name = "request", IsRequired = true)]
		public AffectedRequest Request { get; set; }

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x06001EB5 RID: 7861 RVA: 0x00022F32 File Offset: 0x00021132
		// (set) Token: 0x06001EB6 RID: 7862 RVA: 0x00022F3A File Offset: 0x0002113A
		[DataMember(Name = "location", IsRequired = false)]
		public SourceCodeLocation Location { get; set; }

		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x06001EB7 RID: 7863 RVA: 0x00022F43 File Offset: 0x00021143
		// (set) Token: 0x06001EB8 RID: 7864 RVA: 0x00022F4B File Offset: 0x0002114B
		[DataMember(Name = "initiatorOrigin", IsRequired = false)]
		public string InitiatorOrigin { get; set; }

		// Token: 0x17000B34 RID: 2868
		// (get) Token: 0x06001EB9 RID: 7865 RVA: 0x00022F54 File Offset: 0x00021154
		// (set) Token: 0x06001EBA RID: 7866 RVA: 0x00022F70 File Offset: 0x00021170
		public IPAddressSpace? ResourceIPAddressSpace
		{
			get
			{
				return (IPAddressSpace?)DevToolsDomainEntityBase.StringToEnum(typeof(IPAddressSpace?), this.resourceIPAddressSpace);
			}
			set
			{
				this.resourceIPAddressSpace = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B35 RID: 2869
		// (get) Token: 0x06001EBB RID: 7867 RVA: 0x00022F83 File Offset: 0x00021183
		// (set) Token: 0x06001EBC RID: 7868 RVA: 0x00022F8B File Offset: 0x0002118B
		[DataMember(Name = "resourceIPAddressSpace", IsRequired = false)]
		internal string resourceIPAddressSpace { get; set; }

		// Token: 0x17000B36 RID: 2870
		// (get) Token: 0x06001EBD RID: 7869 RVA: 0x00022F94 File Offset: 0x00021194
		// (set) Token: 0x06001EBE RID: 7870 RVA: 0x00022F9C File Offset: 0x0002119C
		[DataMember(Name = "clientSecurityState", IsRequired = false)]
		public ClientSecurityState ClientSecurityState { get; set; }
	}
}
