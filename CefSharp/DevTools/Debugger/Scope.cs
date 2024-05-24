using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000178 RID: 376
	[DataContract]
	public class Scope : DevToolsDomainEntityBase
	{
		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00010094 File Offset: 0x0000E294
		// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x000100B0 File Offset: 0x0000E2B0
		public ScopeType Type
		{
			get
			{
				return (ScopeType)DevToolsDomainEntityBase.StringToEnum(typeof(ScopeType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x000100C3 File Offset: 0x0000E2C3
		// (set) Token: 0x06000AE7 RID: 2791 RVA: 0x000100CB File Offset: 0x0000E2CB
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x000100D4 File Offset: 0x0000E2D4
		// (set) Token: 0x06000AE9 RID: 2793 RVA: 0x000100DC File Offset: 0x0000E2DC
		[DataMember(Name = "object", IsRequired = true)]
		public RemoteObject Object { get; set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x000100E5 File Offset: 0x0000E2E5
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x000100ED File Offset: 0x0000E2ED
		[DataMember(Name = "name", IsRequired = false)]
		public string Name { get; set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x000100F6 File Offset: 0x0000E2F6
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x000100FE File Offset: 0x0000E2FE
		[DataMember(Name = "startLocation", IsRequired = false)]
		public Location StartLocation { get; set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x00010107 File Offset: 0x0000E307
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x0001010F File Offset: 0x0000E30F
		[DataMember(Name = "endLocation", IsRequired = false)]
		public Location EndLocation { get; set; }
	}
}
