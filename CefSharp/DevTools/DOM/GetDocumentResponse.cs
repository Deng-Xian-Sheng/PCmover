using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039A RID: 922
	[DataContract]
	public class GetDocumentResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06001AF7 RID: 6903 RVA: 0x0001F22E File Offset: 0x0001D42E
		// (set) Token: 0x06001AF8 RID: 6904 RVA: 0x0001F236 File Offset: 0x0001D436
		[DataMember]
		internal Node root { get; set; }

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06001AF9 RID: 6905 RVA: 0x0001F23F File Offset: 0x0001D43F
		public Node Root
		{
			get
			{
				return this.root;
			}
		}
	}
}
