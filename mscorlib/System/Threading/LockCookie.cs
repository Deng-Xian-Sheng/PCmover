using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	// Token: 0x020004FD RID: 1277
	[ComVisible(true)]
	public struct LockCookie
	{
		// Token: 0x06003C51 RID: 15441 RVA: 0x000E418E File Offset: 0x000E238E
		public override int GetHashCode()
		{
			return this._dwFlags + this._dwWriterSeqNum + this._wReaderAndWriterLevel + this._dwThreadID;
		}

		// Token: 0x06003C52 RID: 15442 RVA: 0x000E41AB File Offset: 0x000E23AB
		public override bool Equals(object obj)
		{
			return obj is LockCookie && this.Equals((LockCookie)obj);
		}

		// Token: 0x06003C53 RID: 15443 RVA: 0x000E41C3 File Offset: 0x000E23C3
		public bool Equals(LockCookie obj)
		{
			return obj._dwFlags == this._dwFlags && obj._dwWriterSeqNum == this._dwWriterSeqNum && obj._wReaderAndWriterLevel == this._wReaderAndWriterLevel && obj._dwThreadID == this._dwThreadID;
		}

		// Token: 0x06003C54 RID: 15444 RVA: 0x000E41FF File Offset: 0x000E23FF
		public static bool operator ==(LockCookie a, LockCookie b)
		{
			return a.Equals(b);
		}

		// Token: 0x06003C55 RID: 15445 RVA: 0x000E4209 File Offset: 0x000E2409
		public static bool operator !=(LockCookie a, LockCookie b)
		{
			return !(a == b);
		}

		// Token: 0x04001998 RID: 6552
		private int _dwFlags;

		// Token: 0x04001999 RID: 6553
		private int _dwWriterSeqNum;

		// Token: 0x0400199A RID: 6554
		private int _wReaderAndWriterLevel;

		// Token: 0x0400199B RID: 6555
		private int _dwThreadID;
	}
}
