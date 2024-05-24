using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E3 RID: 995
	[DataContract]
	public class GetPlatformFontsForNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A96 RID: 2710
		// (get) Token: 0x06001D28 RID: 7464 RVA: 0x000215AF File Offset: 0x0001F7AF
		// (set) Token: 0x06001D29 RID: 7465 RVA: 0x000215B7 File Offset: 0x0001F7B7
		[DataMember]
		internal IList<PlatformFontUsage> fonts { get; set; }

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x06001D2A RID: 7466 RVA: 0x000215C0 File Offset: 0x0001F7C0
		public IList<PlatformFontUsage> Fonts
		{
			get
			{
				return this.fonts;
			}
		}
	}
}
