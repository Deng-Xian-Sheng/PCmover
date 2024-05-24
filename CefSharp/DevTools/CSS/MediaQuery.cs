using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CD RID: 973
	[DataContract]
	public class MediaQuery : DevToolsDomainEntityBase
	{
		// Token: 0x17000A49 RID: 2633
		// (get) Token: 0x06001C88 RID: 7304 RVA: 0x00021054 File Offset: 0x0001F254
		// (set) Token: 0x06001C89 RID: 7305 RVA: 0x0002105C File Offset: 0x0001F25C
		[DataMember(Name = "expressions", IsRequired = true)]
		public IList<MediaQueryExpression> Expressions { get; set; }

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x06001C8A RID: 7306 RVA: 0x00021065 File Offset: 0x0001F265
		// (set) Token: 0x06001C8B RID: 7307 RVA: 0x0002106D File Offset: 0x0001F26D
		[DataMember(Name = "active", IsRequired = true)]
		public bool Active { get; set; }
	}
}
