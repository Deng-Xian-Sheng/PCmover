using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000359 RID: 857
	[DataContract]
	public class SetVirtualTimePolicyResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x060018BA RID: 6330 RVA: 0x0001D298 File Offset: 0x0001B498
		// (set) Token: 0x060018BB RID: 6331 RVA: 0x0001D2A0 File Offset: 0x0001B4A0
		[DataMember]
		internal double virtualTimeTicksBase { get; set; }

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x060018BC RID: 6332 RVA: 0x0001D2A9 File Offset: 0x0001B4A9
		public double VirtualTimeTicksBase
		{
			get
			{
				return this.virtualTimeTicksBase;
			}
		}
	}
}
