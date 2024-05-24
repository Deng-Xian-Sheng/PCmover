using System;

namespace System.Threading
{
	// Token: 0x020004E7 RID: 1255
	internal interface IAsyncLocalValueMap
	{
		// Token: 0x06003B7F RID: 15231
		bool TryGetValue(IAsyncLocal key, out object value);

		// Token: 0x06003B80 RID: 15232
		IAsyncLocalValueMap Set(IAsyncLocal key, object value, bool treatNullValueAsNonexistent);
	}
}
