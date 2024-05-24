using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200025A RID: 602
	[ComVisible(true)]
	public abstract class DeriveBytes : IDisposable
	{
		// Token: 0x06002162 RID: 8546
		public abstract byte[] GetBytes(int cb);

		// Token: 0x06002163 RID: 8547
		public abstract void Reset();

		// Token: 0x06002164 RID: 8548 RVA: 0x00076385 File Offset: 0x00074585
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002165 RID: 8549 RVA: 0x00076394 File Offset: 0x00074594
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
