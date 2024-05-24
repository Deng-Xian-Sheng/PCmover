using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x0200043D RID: 1085
	[DataContract]
	public class ResolveAnimationResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06001F7E RID: 8062 RVA: 0x000237B0 File Offset: 0x000219B0
		// (set) Token: 0x06001F7F RID: 8063 RVA: 0x000237B8 File Offset: 0x000219B8
		[DataMember]
		internal RemoteObject remoteObject { get; set; }

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x06001F80 RID: 8064 RVA: 0x000237C1 File Offset: 0x000219C1
		public RemoteObject RemoteObject
		{
			get
			{
				return this.remoteObject;
			}
		}
	}
}
