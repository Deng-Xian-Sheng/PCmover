using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x0200006C RID: 108
	public interface IExtension
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000261 RID: 609
		string Identifier { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000262 RID: 610
		string Path { get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000263 RID: 611
		IDictionary<string, IValue> Manifest { get; }

		// Token: 0x06000264 RID: 612
		bool IsSame(IExtension that);

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000265 RID: 613
		IRequestContext LoaderContext { get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000266 RID: 614
		bool IsLoaded { get; }

		// Token: 0x06000267 RID: 615
		void Unload();
	}
}
