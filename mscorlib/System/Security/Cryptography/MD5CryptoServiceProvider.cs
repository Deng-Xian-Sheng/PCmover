using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000271 RID: 625
	[ComVisible(true)]
	public sealed class MD5CryptoServiceProvider : MD5
	{
		// Token: 0x06002227 RID: 8743 RVA: 0x00078BE1 File Offset: 0x00076DE1
		[SecuritySafeCritical]
		public MD5CryptoServiceProvider()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			this._safeHashHandle = Utils.CreateHash(Utils.StaticProvHandle, 32771);
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x00078C1C File Offset: 0x00076E1C
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			if (this._safeHashHandle != null && !this._safeHashHandle.IsClosed)
			{
				this._safeHashHandle.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x00078C45 File Offset: 0x00076E45
		[SecuritySafeCritical]
		public override void Initialize()
		{
			if (this._safeHashHandle != null && !this._safeHashHandle.IsClosed)
			{
				this._safeHashHandle.Dispose();
			}
			this._safeHashHandle = Utils.CreateHash(Utils.StaticProvHandle, 32771);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x00078C7C File Offset: 0x00076E7C
		[SecuritySafeCritical]
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			Utils.HashData(this._safeHashHandle, rgb, ibStart, cbSize);
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x00078C8C File Offset: 0x00076E8C
		[SecuritySafeCritical]
		protected override byte[] HashFinal()
		{
			return Utils.EndHash(this._safeHashHandle);
		}

		// Token: 0x04000C65 RID: 3173
		[SecurityCritical]
		private SafeHashHandle _safeHashHandle;
	}
}
