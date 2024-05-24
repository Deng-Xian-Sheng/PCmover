using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000291 RID: 657
	[ComVisible(true)]
	public sealed class SHA1CryptoServiceProvider : SHA1
	{
		// Token: 0x06002351 RID: 9041 RVA: 0x00080251 File Offset: 0x0007E451
		[SecuritySafeCritical]
		public SHA1CryptoServiceProvider()
		{
			this._safeHashHandle = Utils.CreateHash(Utils.StaticProvHandle, 32772);
		}

		// Token: 0x06002352 RID: 9042 RVA: 0x0008026E File Offset: 0x0007E46E
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			if (this._safeHashHandle != null && !this._safeHashHandle.IsClosed)
			{
				this._safeHashHandle.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002353 RID: 9043 RVA: 0x00080297 File Offset: 0x0007E497
		[SecuritySafeCritical]
		public override void Initialize()
		{
			if (this._safeHashHandle != null && !this._safeHashHandle.IsClosed)
			{
				this._safeHashHandle.Dispose();
			}
			this._safeHashHandle = Utils.CreateHash(Utils.StaticProvHandle, 32772);
		}

		// Token: 0x06002354 RID: 9044 RVA: 0x000802CE File Offset: 0x0007E4CE
		[SecuritySafeCritical]
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			Utils.HashData(this._safeHashHandle, rgb, ibStart, cbSize);
		}

		// Token: 0x06002355 RID: 9045 RVA: 0x000802DE File Offset: 0x0007E4DE
		[SecuritySafeCritical]
		protected override byte[] HashFinal()
		{
			return Utils.EndHash(this._safeHashHandle);
		}

		// Token: 0x04000CDE RID: 3294
		[SecurityCritical]
		private SafeHashHandle _safeHashHandle;
	}
}
