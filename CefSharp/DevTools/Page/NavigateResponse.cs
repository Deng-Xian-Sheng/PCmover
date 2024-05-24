using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027F RID: 639
	[DataContract]
	public class NavigateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06001205 RID: 4613 RVA: 0x000161F4 File Offset: 0x000143F4
		// (set) Token: 0x06001206 RID: 4614 RVA: 0x000161FC File Offset: 0x000143FC
		[DataMember]
		internal string frameId { get; set; }

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06001207 RID: 4615 RVA: 0x00016205 File Offset: 0x00014405
		public string FrameId
		{
			get
			{
				return this.frameId;
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06001208 RID: 4616 RVA: 0x0001620D File Offset: 0x0001440D
		// (set) Token: 0x06001209 RID: 4617 RVA: 0x00016215 File Offset: 0x00014415
		[DataMember]
		internal string loaderId { get; set; }

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600120A RID: 4618 RVA: 0x0001621E File Offset: 0x0001441E
		public string LoaderId
		{
			get
			{
				return this.loaderId;
			}
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x00016226 File Offset: 0x00014426
		// (set) Token: 0x0600120C RID: 4620 RVA: 0x0001622E File Offset: 0x0001442E
		[DataMember]
		internal string errorText { get; set; }

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x00016237 File Offset: 0x00014437
		public string ErrorText
		{
			get
			{
				return this.errorText;
			}
		}
	}
}
