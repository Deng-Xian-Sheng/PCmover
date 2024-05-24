using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000309 RID: 777
	[DataContract]
	public class SetCookieResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x0600169A RID: 5786 RVA: 0x0001A25D File Offset: 0x0001845D
		// (set) Token: 0x0600169B RID: 5787 RVA: 0x0001A265 File Offset: 0x00018465
		[DataMember]
		internal bool success { get; set; }

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x0001A26E File Offset: 0x0001846E
		public bool Success
		{
			get
			{
				return this.success;
			}
		}
	}
}
