using System;

namespace System.Security.Util
{
	// Token: 0x0200037E RID: 894
	internal struct TokenBasedSetEnumerator
	{
		// Token: 0x06002C70 RID: 11376 RVA: 0x000A5F13 File Offset: 0x000A4113
		public bool MoveNext()
		{
			return this._tb != null && this._tb.MoveNext(ref this);
		}

		// Token: 0x06002C71 RID: 11377 RVA: 0x000A5F2B File Offset: 0x000A412B
		public void Reset()
		{
			this.Index = -1;
			this.Current = null;
		}

		// Token: 0x06002C72 RID: 11378 RVA: 0x000A5F3B File Offset: 0x000A413B
		public TokenBasedSetEnumerator(TokenBasedSet tb)
		{
			this.Index = -1;
			this.Current = null;
			this._tb = tb;
		}

		// Token: 0x040011D1 RID: 4561
		public object Current;

		// Token: 0x040011D2 RID: 4562
		public int Index;

		// Token: 0x040011D3 RID: 4563
		private TokenBasedSet _tb;
	}
}
