using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CefSharp
{
	// Token: 0x02000077 RID: 119
	public interface IRequest : IDisposable
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002FF RID: 767
		// (set) Token: 0x06000300 RID: 768
		UrlRequestFlags Flags { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000301 RID: 769
		// (set) Token: 0x06000302 RID: 770
		string Url { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000303 RID: 771
		ulong Identifier { get; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000304 RID: 772
		// (set) Token: 0x06000305 RID: 773
		string Method { get; set; }

		// Token: 0x06000306 RID: 774
		void SetReferrer(string referrerUrl, ReferrerPolicy policy);

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000307 RID: 775
		string ReferrerUrl { get; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000308 RID: 776
		ResourceType ResourceType { get; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000309 RID: 777
		ReferrerPolicy ReferrerPolicy { get; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600030A RID: 778
		// (set) Token: 0x0600030B RID: 779
		NameValueCollection Headers { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600030C RID: 780
		// (set) Token: 0x0600030D RID: 781
		IPostData PostData { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600030E RID: 782
		TransitionType TransitionType { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600030F RID: 783
		bool IsDisposed { get; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000310 RID: 784
		bool IsReadOnly { get; }

		// Token: 0x06000311 RID: 785
		void InitializePostData();

		// Token: 0x06000312 RID: 786
		string GetHeaderByName(string name);

		// Token: 0x06000313 RID: 787
		void SetHeaderByName(string name, string value, bool overwrite);

		// Token: 0x06000314 RID: 788
		[EditorBrowsable(EditorBrowsableState.Never)]
		IRequest UnWrap();
	}
}
