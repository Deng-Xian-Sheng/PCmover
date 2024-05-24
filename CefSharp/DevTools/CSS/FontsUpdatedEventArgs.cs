using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D7 RID: 983
	[DataContract]
	public class FontsUpdatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06001CE4 RID: 7396 RVA: 0x0002137B File Offset: 0x0001F57B
		// (set) Token: 0x06001CE5 RID: 7397 RVA: 0x00021383 File Offset: 0x0001F583
		[DataMember(Name = "font", IsRequired = false)]
		public FontFace Font { get; private set; }
	}
}
