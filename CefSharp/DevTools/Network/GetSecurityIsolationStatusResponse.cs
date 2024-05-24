using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x0200030A RID: 778
	[DataContract]
	public class GetSecurityIsolationStatusResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x0600169E RID: 5790 RVA: 0x0001A27E File Offset: 0x0001847E
		// (set) Token: 0x0600169F RID: 5791 RVA: 0x0001A286 File Offset: 0x00018486
		[DataMember]
		internal SecurityIsolationStatus status { get; set; }

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x060016A0 RID: 5792 RVA: 0x0001A28F File Offset: 0x0001848F
		public SecurityIsolationStatus Status
		{
			get
			{
				return this.status;
			}
		}
	}
}
