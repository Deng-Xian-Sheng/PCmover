using System;
using CefSharp.Event;
using CefSharp.JavascriptBinding;

namespace CefSharp
{
	// Token: 0x0200006F RID: 111
	public interface IJavascriptObjectRepository : IDisposable
	{
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600028D RID: 653
		JavascriptBindingSettings Settings { get; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600028E RID: 654
		// (set) Token: 0x0600028F RID: 655
		IJavascriptNameConverter NameConverter { get; set; }

		// Token: 0x06000290 RID: 656
		void Register(string name, object objectToBind, bool isAsync, BindingOptions options = null);

		// Token: 0x06000291 RID: 657
		void UnRegisterAll();

		// Token: 0x06000292 RID: 658
		bool UnRegister(string name);

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000293 RID: 659
		bool HasBoundObjects { get; }

		// Token: 0x06000294 RID: 660
		bool IsBound(string name);

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000295 RID: 661
		// (remove) Token: 0x06000296 RID: 662
		event EventHandler<JavascriptBindingEventArgs> ResolveObject;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000297 RID: 663
		// (remove) Token: 0x06000298 RID: 664
		event EventHandler<JavascriptBindingCompleteEventArgs> ObjectBoundInJavascript;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000299 RID: 665
		// (remove) Token: 0x0600029A RID: 666
		event EventHandler<JavascriptBindingMultipleCompleteEventArgs> ObjectsBoundInJavascript;
	}
}
