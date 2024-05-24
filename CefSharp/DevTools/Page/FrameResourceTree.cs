using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023F RID: 575
	[DataContract]
	public class FrameResourceTree : DevToolsDomainEntityBase
	{
		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001082 RID: 4226 RVA: 0x000153EB File Offset: 0x000135EB
		// (set) Token: 0x06001083 RID: 4227 RVA: 0x000153F3 File Offset: 0x000135F3
		[DataMember(Name = "frame", IsRequired = true)]
		public Frame Frame { get; set; }

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x000153FC File Offset: 0x000135FC
		// (set) Token: 0x06001085 RID: 4229 RVA: 0x00015404 File Offset: 0x00013604
		[DataMember(Name = "childFrames", IsRequired = false)]
		public IList<FrameResourceTree> ChildFrames { get; set; }

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06001086 RID: 4230 RVA: 0x0001540D File Offset: 0x0001360D
		// (set) Token: 0x06001087 RID: 4231 RVA: 0x00015415 File Offset: 0x00013615
		[DataMember(Name = "resources", IsRequired = true)]
		public IList<FrameResource> Resources { get; set; }
	}
}
