using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FF RID: 1023
	[DataContract]
	public class GetWindowBoundsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x06001DD9 RID: 7641 RVA: 0x0002215C File Offset: 0x0002035C
		// (set) Token: 0x06001DDA RID: 7642 RVA: 0x00022164 File Offset: 0x00020364
		[DataMember]
		internal Bounds bounds { get; set; }

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06001DDB RID: 7643 RVA: 0x0002216D File Offset: 0x0002036D
		public Bounds Bounds
		{
			get
			{
				return this.bounds;
			}
		}
	}
}
