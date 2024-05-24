using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013B RID: 315
	[DataContract]
	public class CallArgument : DevToolsDomainEntityBase
	{
		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0000E36E File Offset: 0x0000C56E
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x0000E376 File Offset: 0x0000C576
		[DataMember(Name = "value", IsRequired = false)]
		public object Value { get; set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0000E37F File Offset: 0x0000C57F
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x0000E387 File Offset: 0x0000C587
		[DataMember(Name = "unserializableValue", IsRequired = false)]
		public string UnserializableValue { get; set; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0000E390 File Offset: 0x0000C590
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x0000E398 File Offset: 0x0000C598
		[DataMember(Name = "objectId", IsRequired = false)]
		public string ObjectId { get; set; }
	}
}
