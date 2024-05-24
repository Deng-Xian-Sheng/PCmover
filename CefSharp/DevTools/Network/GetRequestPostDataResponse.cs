using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000305 RID: 773
	[DataContract]
	public class GetRequestPostDataResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06001687 RID: 5767 RVA: 0x0001A1C0 File Offset: 0x000183C0
		// (set) Token: 0x06001688 RID: 5768 RVA: 0x0001A1C8 File Offset: 0x000183C8
		[DataMember]
		internal string postData { get; set; }

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06001689 RID: 5769 RVA: 0x0001A1D1 File Offset: 0x000183D1
		public string PostData
		{
			get
			{
				return this.postData;
			}
		}
	}
}
