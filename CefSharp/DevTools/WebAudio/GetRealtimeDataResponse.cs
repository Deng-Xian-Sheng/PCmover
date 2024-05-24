using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BF RID: 447
	[DataContract]
	public class GetRealtimeDataResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x00011E2C File Offset: 0x0001002C
		// (set) Token: 0x06000CE9 RID: 3305 RVA: 0x00011E34 File Offset: 0x00010034
		[DataMember]
		internal ContextRealtimeData realtimeData { get; set; }

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00011E3D File Offset: 0x0001003D
		public ContextRealtimeData RealtimeData
		{
			get
			{
				return this.realtimeData;
			}
		}
	}
}
