using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x0200033F RID: 831
	public enum KeyType
	{
		// Token: 0x04000D6C RID: 3436
		[EnumMember(Value = "number")]
		Number,
		// Token: 0x04000D6D RID: 3437
		[EnumMember(Value = "string")]
		String,
		// Token: 0x04000D6E RID: 3438
		[EnumMember(Value = "date")]
		Date,
		// Token: 0x04000D6F RID: 3439
		[EnumMember(Value = "array")]
		Array
	}
}
