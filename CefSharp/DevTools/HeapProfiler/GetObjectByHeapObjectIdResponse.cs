using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x0200016F RID: 367
	[DataContract]
	public class GetObjectByHeapObjectIdResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x0000FB59 File Offset: 0x0000DD59
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x0000FB61 File Offset: 0x0000DD61
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x0000FB6A File Offset: 0x0000DD6A
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
