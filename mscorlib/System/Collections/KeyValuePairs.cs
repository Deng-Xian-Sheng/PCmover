using System;
using System.Diagnostics;

namespace System.Collections
{
	// Token: 0x020004A2 RID: 1186
	[DebuggerDisplay("{value}", Name = "[{key}]", Type = "")]
	internal class KeyValuePairs
	{
		// Token: 0x060038C7 RID: 14535 RVA: 0x000D9BD5 File Offset: 0x000D7DD5
		public KeyValuePairs(object key, object value)
		{
			this.value = value;
			this.key = key;
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x060038C8 RID: 14536 RVA: 0x000D9BEB File Offset: 0x000D7DEB
		public object Key
		{
			get
			{
				return this.key;
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x060038C9 RID: 14537 RVA: 0x000D9BF3 File Offset: 0x000D7DF3
		public object Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x040018FB RID: 6395
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object key;

		// Token: 0x040018FC RID: 6396
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object value;
	}
}
