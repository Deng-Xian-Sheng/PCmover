using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000312 RID: 786
	[DataContract]
	public class GetDOMCountersResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x0001B20B File Offset: 0x0001940B
		// (set) Token: 0x0600171A RID: 5914 RVA: 0x0001B213 File Offset: 0x00019413
		[DataMember]
		internal int documents { get; set; }

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x0001B21C File Offset: 0x0001941C
		public int Documents
		{
			get
			{
				return this.documents;
			}
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0001B224 File Offset: 0x00019424
		// (set) Token: 0x0600171D RID: 5917 RVA: 0x0001B22C File Offset: 0x0001942C
		[DataMember]
		internal int nodes { get; set; }

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0001B235 File Offset: 0x00019435
		public int Nodes
		{
			get
			{
				return this.nodes;
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x0600171F RID: 5919 RVA: 0x0001B23D File Offset: 0x0001943D
		// (set) Token: 0x06001720 RID: 5920 RVA: 0x0001B245 File Offset: 0x00019445
		[DataMember]
		internal int jsEventListeners { get; set; }

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x0001B24E File Offset: 0x0001944E
		public int JsEventListeners
		{
			get
			{
				return this.jsEventListeners;
			}
		}
	}
}
