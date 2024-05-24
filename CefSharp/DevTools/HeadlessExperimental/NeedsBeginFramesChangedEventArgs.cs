using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeadlessExperimental
{
	// Token: 0x0200034C RID: 844
	[DataContract]
	public class NeedsBeginFramesChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x0600187D RID: 6269 RVA: 0x0001CF89 File Offset: 0x0001B189
		// (set) Token: 0x0600187E RID: 6270 RVA: 0x0001CF91 File Offset: 0x0001B191
		[DataMember(Name = "needsBeginFrames", IsRequired = true)]
		public bool NeedsBeginFrames { get; private set; }
	}
}
