using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Page;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x020002A1 RID: 673
	[DataContract]
	public class ScreenshotRequestedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x000179A2 File Offset: 0x00015BA2
		// (set) Token: 0x06001336 RID: 4918 RVA: 0x000179AA File Offset: 0x00015BAA
		[DataMember(Name = "viewport", IsRequired = true)]
		public Viewport Viewport { get; private set; }
	}
}
