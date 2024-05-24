using System;
using System.Threading.Tasks;

namespace CefSharp
{
	// Token: 0x0200006D RID: 109
	public interface IFrame : IDisposable
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000268 RID: 616
		bool IsValid { get; }

		// Token: 0x06000269 RID: 617
		void Undo();

		// Token: 0x0600026A RID: 618
		void Redo();

		// Token: 0x0600026B RID: 619
		void Cut();

		// Token: 0x0600026C RID: 620
		void Copy();

		// Token: 0x0600026D RID: 621
		void Paste();

		// Token: 0x0600026E RID: 622
		void Delete();

		// Token: 0x0600026F RID: 623
		void SelectAll();

		// Token: 0x06000270 RID: 624
		void ViewSource();

		// Token: 0x06000271 RID: 625
		Task<string> GetSourceAsync();

		// Token: 0x06000272 RID: 626
		void GetSource(IStringVisitor visitor);

		// Token: 0x06000273 RID: 627
		Task<string> GetTextAsync();

		// Token: 0x06000274 RID: 628
		void GetText(IStringVisitor visitor);

		// Token: 0x06000275 RID: 629
		void LoadRequest(IRequest request);

		// Token: 0x06000276 RID: 630
		void LoadUrl(string url);

		// Token: 0x06000277 RID: 631
		void ExecuteJavaScriptAsync(string code, string scriptUrl = "about:blank", int startLine = 1);

		// Token: 0x06000278 RID: 632
		Task<JavascriptResponse> EvaluateScriptAsync(string script, string scriptUrl = "about:blank", int startLine = 1, TimeSpan? timeout = null, bool useImmediatelyInvokedFuncExpression = false);

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000279 RID: 633
		bool IsMain { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600027A RID: 634
		bool IsFocused { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600027B RID: 635
		string Name { get; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600027C RID: 636
		long Identifier { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600027D RID: 637
		IFrame Parent { get; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600027E RID: 638
		string Url { get; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600027F RID: 639
		IBrowser Browser { get; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000280 RID: 640
		bool IsDisposed { get; }

		// Token: 0x06000281 RID: 641
		IRequest CreateRequest(bool initializePostData = true);

		// Token: 0x06000282 RID: 642
		IUrlRequest CreateUrlRequest(IRequest request, IUrlRequestClient client);
	}
}
