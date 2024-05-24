using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001BA RID: 442
	[DataContract]
	public class AudioParamWillBeDestroyedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x00011C9F File Offset: 0x0000FE9F
		// (set) Token: 0x06000CBA RID: 3258 RVA: 0x00011CA7 File Offset: 0x0000FEA7
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; private set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x00011CB0 File Offset: 0x0000FEB0
		// (set) Token: 0x06000CBC RID: 3260 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		[DataMember(Name = "nodeId", IsRequired = true)]
		public string NodeId { get; private set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00011CC1 File Offset: 0x0000FEC1
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x00011CC9 File Offset: 0x0000FEC9
		[DataMember(Name = "paramId", IsRequired = true)]
		public string ParamId { get; private set; }
	}
}
