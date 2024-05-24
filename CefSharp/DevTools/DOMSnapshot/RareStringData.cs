using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036F RID: 879
	[DataContract]
	public class RareStringData : DevToolsDomainEntityBase
	{
		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x0600198B RID: 6539 RVA: 0x0001E2BC File Offset: 0x0001C4BC
		// (set) Token: 0x0600198C RID: 6540 RVA: 0x0001E2C4 File Offset: 0x0001C4C4
		[DataMember(Name = "index", IsRequired = true)]
		public int[] Index { get; set; }

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x0600198D RID: 6541 RVA: 0x0001E2CD File Offset: 0x0001C4CD
		// (set) Token: 0x0600198E RID: 6542 RVA: 0x0001E2D5 File Offset: 0x0001C4D5
		[DataMember(Name = "value", IsRequired = true)]
		public int[] Value { get; set; }
	}
}
