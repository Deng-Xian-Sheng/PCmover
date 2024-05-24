using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x0200030B RID: 779
	[DataContract]
	public class LoadNetworkResourceResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x060016A2 RID: 5794 RVA: 0x0001A29F File Offset: 0x0001849F
		// (set) Token: 0x060016A3 RID: 5795 RVA: 0x0001A2A7 File Offset: 0x000184A7
		[DataMember]
		internal LoadNetworkResourcePageResult resource { get; set; }

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0001A2B0 File Offset: 0x000184B0
		public LoadNetworkResourcePageResult Resource
		{
			get
			{
				return this.resource;
			}
		}
	}
}
