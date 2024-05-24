using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000D0 RID: 208
	public interface IJavascriptObjectRepositoryInternal : IJavascriptObjectRepository, IDisposable
	{
		// Token: 0x06000610 RID: 1552
		TryCallMethodResult TryCallMethod(long objectId, string name, object[] parameters);

		// Token: 0x06000611 RID: 1553
		Task<TryCallMethodResult> TryCallMethodAsync(long objectId, string name, object[] parameters);

		// Token: 0x06000612 RID: 1554
		bool TryGetProperty(long objectId, string name, out object result, out string exception);

		// Token: 0x06000613 RID: 1555
		bool TrySetProperty(long objectId, string name, object value, out string exception);

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000614 RID: 1556
		// (set) Token: 0x06000615 RID: 1557
		bool IsBrowserInitialized { get; set; }

		// Token: 0x06000616 RID: 1558
		List<JavascriptObject> GetObjects(List<string> names = null);

		// Token: 0x06000617 RID: 1559
		List<JavascriptObject> GetLegacyBoundObjects();

		// Token: 0x06000618 RID: 1560
		void ObjectsBound(List<Tuple<string, bool, bool>> objs);
	}
}
