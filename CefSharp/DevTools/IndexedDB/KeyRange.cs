using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000341 RID: 833
	[DataContract]
	public class KeyRange : DevToolsDomainEntityBase
	{
		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x0600183D RID: 6205 RVA: 0x0001CB16 File Offset: 0x0001AD16
		// (set) Token: 0x0600183E RID: 6206 RVA: 0x0001CB1E File Offset: 0x0001AD1E
		[DataMember(Name = "lower", IsRequired = false)]
		public Key Lower { get; set; }

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x0600183F RID: 6207 RVA: 0x0001CB27 File Offset: 0x0001AD27
		// (set) Token: 0x06001840 RID: 6208 RVA: 0x0001CB2F File Offset: 0x0001AD2F
		[DataMember(Name = "upper", IsRequired = false)]
		public Key Upper { get; set; }

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x06001841 RID: 6209 RVA: 0x0001CB38 File Offset: 0x0001AD38
		// (set) Token: 0x06001842 RID: 6210 RVA: 0x0001CB40 File Offset: 0x0001AD40
		[DataMember(Name = "lowerOpen", IsRequired = true)]
		public bool LowerOpen { get; set; }

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x06001843 RID: 6211 RVA: 0x0001CB49 File Offset: 0x0001AD49
		// (set) Token: 0x06001844 RID: 6212 RVA: 0x0001CB51 File Offset: 0x0001AD51
		[DataMember(Name = "upperOpen", IsRequired = true)]
		public bool UpperOpen { get; set; }
	}
}
