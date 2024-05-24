using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000207 RID: 519
	[DataContract]
	public class GetUsageAndQuotaResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x00013CBC File Offset: 0x00011EBC
		// (set) Token: 0x06000EDA RID: 3802 RVA: 0x00013CC4 File Offset: 0x00011EC4
		[DataMember]
		internal double usage { get; set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x00013CCD File Offset: 0x00011ECD
		public double Usage
		{
			get
			{
				return this.usage;
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x00013CD5 File Offset: 0x00011ED5
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x00013CDD File Offset: 0x00011EDD
		[DataMember]
		internal double quota { get; set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x00013CE6 File Offset: 0x00011EE6
		public double Quota
		{
			get
			{
				return this.quota;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x00013CEE File Offset: 0x00011EEE
		// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x00013CF6 File Offset: 0x00011EF6
		[DataMember]
		internal bool overrideActive { get; set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x00013CFF File Offset: 0x00011EFF
		public bool OverrideActive
		{
			get
			{
				return this.overrideActive;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x00013D07 File Offset: 0x00011F07
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x00013D0F File Offset: 0x00011F0F
		[DataMember]
		internal IList<UsageForType> usageBreakdown { get; set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x00013D18 File Offset: 0x00011F18
		public IList<UsageForType> UsageBreakdown
		{
			get
			{
				return this.usageBreakdown;
			}
		}
	}
}
