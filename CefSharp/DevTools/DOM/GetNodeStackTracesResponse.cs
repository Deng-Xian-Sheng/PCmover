using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A8 RID: 936
	[DataContract]
	public class GetNodeStackTracesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06001B38 RID: 6968 RVA: 0x0001F447 File Offset: 0x0001D647
		// (set) Token: 0x06001B39 RID: 6969 RVA: 0x0001F44F File Offset: 0x0001D64F
		[DataMember]
		internal StackTrace creation { get; set; }

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06001B3A RID: 6970 RVA: 0x0001F458 File Offset: 0x0001D658
		public StackTrace Creation
		{
			get
			{
				return this.creation;
			}
		}
	}
}
