using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B5 RID: 949
	[DataContract]
	public class DataEntry : DevToolsDomainEntityBase
	{
		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06001BB7 RID: 7095 RVA: 0x00020770 File Offset: 0x0001E970
		// (set) Token: 0x06001BB8 RID: 7096 RVA: 0x00020778 File Offset: 0x0001E978
		[DataMember(Name = "requestURL", IsRequired = true)]
		public string RequestURL { get; set; }

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x00020781 File Offset: 0x0001E981
		// (set) Token: 0x06001BBA RID: 7098 RVA: 0x00020789 File Offset: 0x0001E989
		[DataMember(Name = "requestMethod", IsRequired = true)]
		public string RequestMethod { get; set; }

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06001BBB RID: 7099 RVA: 0x00020792 File Offset: 0x0001E992
		// (set) Token: 0x06001BBC RID: 7100 RVA: 0x0002079A File Offset: 0x0001E99A
		[DataMember(Name = "requestHeaders", IsRequired = true)]
		public IList<Header> RequestHeaders { get; set; }

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06001BBD RID: 7101 RVA: 0x000207A3 File Offset: 0x0001E9A3
		// (set) Token: 0x06001BBE RID: 7102 RVA: 0x000207AB File Offset: 0x0001E9AB
		[DataMember(Name = "responseTime", IsRequired = true)]
		public double ResponseTime { get; set; }

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06001BBF RID: 7103 RVA: 0x000207B4 File Offset: 0x0001E9B4
		// (set) Token: 0x06001BC0 RID: 7104 RVA: 0x000207BC File Offset: 0x0001E9BC
		[DataMember(Name = "responseStatus", IsRequired = true)]
		public int ResponseStatus { get; set; }

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06001BC1 RID: 7105 RVA: 0x000207C5 File Offset: 0x0001E9C5
		// (set) Token: 0x06001BC2 RID: 7106 RVA: 0x000207CD File Offset: 0x0001E9CD
		[DataMember(Name = "responseStatusText", IsRequired = true)]
		public string ResponseStatusText { get; set; }

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06001BC3 RID: 7107 RVA: 0x000207D6 File Offset: 0x0001E9D6
		// (set) Token: 0x06001BC4 RID: 7108 RVA: 0x000207F2 File Offset: 0x0001E9F2
		public CachedResponseType ResponseType
		{
			get
			{
				return (CachedResponseType)DevToolsDomainEntityBase.StringToEnum(typeof(CachedResponseType), this.responseType);
			}
			set
			{
				this.responseType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06001BC5 RID: 7109 RVA: 0x00020805 File Offset: 0x0001EA05
		// (set) Token: 0x06001BC6 RID: 7110 RVA: 0x0002080D File Offset: 0x0001EA0D
		[DataMember(Name = "responseType", IsRequired = true)]
		internal string responseType { get; set; }

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06001BC7 RID: 7111 RVA: 0x00020816 File Offset: 0x0001EA16
		// (set) Token: 0x06001BC8 RID: 7112 RVA: 0x0002081E File Offset: 0x0001EA1E
		[DataMember(Name = "responseHeaders", IsRequired = true)]
		public IList<Header> ResponseHeaders { get; set; }
	}
}
