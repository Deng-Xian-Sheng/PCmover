using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000384 RID: 900
	[DataContract]
	public class ShapeOutsideInfo : DevToolsDomainEntityBase
	{
		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x06001A87 RID: 6791 RVA: 0x0001EE84 File Offset: 0x0001D084
		// (set) Token: 0x06001A88 RID: 6792 RVA: 0x0001EE8C File Offset: 0x0001D08C
		[DataMember(Name = "bounds", IsRequired = true)]
		public double[] Bounds { get; set; }

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x06001A89 RID: 6793 RVA: 0x0001EE95 File Offset: 0x0001D095
		// (set) Token: 0x06001A8A RID: 6794 RVA: 0x0001EE9D File Offset: 0x0001D09D
		[DataMember(Name = "shape", IsRequired = true)]
		public object[] Shape { get; set; }

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x06001A8B RID: 6795 RVA: 0x0001EEA6 File Offset: 0x0001D0A6
		// (set) Token: 0x06001A8C RID: 6796 RVA: 0x0001EEAE File Offset: 0x0001D0AE
		[DataMember(Name = "marginShape", IsRequired = true)]
		public object[] MarginShape { get; set; }
	}
}
