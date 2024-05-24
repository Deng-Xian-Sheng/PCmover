using System;
using System.Collections.Specialized;

namespace CefSharp
{
	// Token: 0x0200007A RID: 122
	public interface IResponse : IDisposable
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600032E RID: 814
		// (set) Token: 0x0600032F RID: 815
		string Charset { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000330 RID: 816
		// (set) Token: 0x06000331 RID: 817
		string MimeType { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000332 RID: 818
		// (set) Token: 0x06000333 RID: 819
		NameValueCollection Headers { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000334 RID: 820
		bool IsReadOnly { get; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000335 RID: 821
		// (set) Token: 0x06000336 RID: 822
		CefErrorCode ErrorCode { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000337 RID: 823
		// (set) Token: 0x06000338 RID: 824
		int StatusCode { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000339 RID: 825
		// (set) Token: 0x0600033A RID: 826
		string StatusText { get; set; }

		// Token: 0x0600033B RID: 827
		string GetHeaderByName(string name);

		// Token: 0x0600033C RID: 828
		void SetHeaderByName(string name, string value, bool overwrite);
	}
}
