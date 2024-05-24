using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003EA RID: 1002
	[DataContract]
	public class SetRuleSelectorResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06001D44 RID: 7492 RVA: 0x00021696 File Offset: 0x0001F896
		// (set) Token: 0x06001D45 RID: 7493 RVA: 0x0002169E File Offset: 0x0001F89E
		[DataMember]
		internal SelectorList selectorList { get; set; }

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06001D46 RID: 7494 RVA: 0x000216A7 File Offset: 0x0001F8A7
		public SelectorList SelectorList
		{
			get
			{
				return this.selectorList;
			}
		}
	}
}
