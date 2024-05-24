using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Log
{
	// Token: 0x0200031A RID: 794
	[DataContract]
	public class LogEntry : DevToolsDomainEntityBase
	{
		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x0600173A RID: 5946 RVA: 0x0001B488 File Offset: 0x00019688
		// (set) Token: 0x0600173B RID: 5947 RVA: 0x0001B4A4 File Offset: 0x000196A4
		public LogEntrySource Source
		{
			get
			{
				return (LogEntrySource)DevToolsDomainEntityBase.StringToEnum(typeof(LogEntrySource), this.source);
			}
			set
			{
				this.source = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0001B4B7 File Offset: 0x000196B7
		// (set) Token: 0x0600173D RID: 5949 RVA: 0x0001B4BF File Offset: 0x000196BF
		[DataMember(Name = "source", IsRequired = true)]
		internal string source { get; set; }

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0001B4C8 File Offset: 0x000196C8
		// (set) Token: 0x0600173F RID: 5951 RVA: 0x0001B4E4 File Offset: 0x000196E4
		public LogEntryLevel Level
		{
			get
			{
				return (LogEntryLevel)DevToolsDomainEntityBase.StringToEnum(typeof(LogEntryLevel), this.level);
			}
			set
			{
				this.level = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06001740 RID: 5952 RVA: 0x0001B4F7 File Offset: 0x000196F7
		// (set) Token: 0x06001741 RID: 5953 RVA: 0x0001B4FF File Offset: 0x000196FF
		[DataMember(Name = "level", IsRequired = true)]
		internal string level { get; set; }

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x0001B508 File Offset: 0x00019708
		// (set) Token: 0x06001743 RID: 5955 RVA: 0x0001B510 File Offset: 0x00019710
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x0001B519 File Offset: 0x00019719
		// (set) Token: 0x06001745 RID: 5957 RVA: 0x0001B535 File Offset: 0x00019735
		public LogEntryCategory? Category
		{
			get
			{
				return (LogEntryCategory?)DevToolsDomainEntityBase.StringToEnum(typeof(LogEntryCategory?), this.category);
			}
			set
			{
				this.category = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x0001B548 File Offset: 0x00019748
		// (set) Token: 0x06001747 RID: 5959 RVA: 0x0001B550 File Offset: 0x00019750
		[DataMember(Name = "category", IsRequired = false)]
		internal string category { get; set; }

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06001748 RID: 5960 RVA: 0x0001B559 File Offset: 0x00019759
		// (set) Token: 0x06001749 RID: 5961 RVA: 0x0001B561 File Offset: 0x00019761
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; set; }

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x0001B56A File Offset: 0x0001976A
		// (set) Token: 0x0600174B RID: 5963 RVA: 0x0001B572 File Offset: 0x00019772
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x0001B57B File Offset: 0x0001977B
		// (set) Token: 0x0600174D RID: 5965 RVA: 0x0001B583 File Offset: 0x00019783
		[DataMember(Name = "lineNumber", IsRequired = false)]
		public int? LineNumber { get; set; }

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x0600174E RID: 5966 RVA: 0x0001B58C File Offset: 0x0001978C
		// (set) Token: 0x0600174F RID: 5967 RVA: 0x0001B594 File Offset: 0x00019794
		[DataMember(Name = "stackTrace", IsRequired = false)]
		public StackTrace StackTrace { get; set; }

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06001750 RID: 5968 RVA: 0x0001B59D File Offset: 0x0001979D
		// (set) Token: 0x06001751 RID: 5969 RVA: 0x0001B5A5 File Offset: 0x000197A5
		[DataMember(Name = "networkRequestId", IsRequired = false)]
		public string NetworkRequestId { get; set; }

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06001752 RID: 5970 RVA: 0x0001B5AE File Offset: 0x000197AE
		// (set) Token: 0x06001753 RID: 5971 RVA: 0x0001B5B6 File Offset: 0x000197B6
		[DataMember(Name = "workerId", IsRequired = false)]
		public string WorkerId { get; set; }

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06001754 RID: 5972 RVA: 0x0001B5BF File Offset: 0x000197BF
		// (set) Token: 0x06001755 RID: 5973 RVA: 0x0001B5C7 File Offset: 0x000197C7
		[DataMember(Name = "args", IsRequired = false)]
		public IList<RemoteObject> Args { get; set; }
	}
}
