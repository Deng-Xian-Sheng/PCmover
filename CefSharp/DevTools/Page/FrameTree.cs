using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000240 RID: 576
	[DataContract]
	public class FrameTree : DevToolsDomainEntityBase
	{
		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06001089 RID: 4233 RVA: 0x00015426 File Offset: 0x00013626
		// (set) Token: 0x0600108A RID: 4234 RVA: 0x0001542E File Offset: 0x0001362E
		[DataMember(Name = "frame", IsRequired = true)]
		public Frame Frame { get; set; }

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x0600108B RID: 4235 RVA: 0x00015437 File Offset: 0x00013637
		// (set) Token: 0x0600108C RID: 4236 RVA: 0x0001543F File Offset: 0x0001363F
		[DataMember(Name = "childFrames", IsRequired = false)]
		public IList<FrameTree> ChildFrames { get; set; }
	}
}
