using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000298 RID: 664
	[ComVisible(true)]
	public class SHA512Managed : SHA512
	{
		// Token: 0x0600236E RID: 9070 RVA: 0x0008053D File Offset: 0x0007E73D
		public SHA512Managed()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			this._impl = (SHA512)CryptoConfig.CreateFromName("System.Security.Cryptography.SHA512Cng");
		}

		// Token: 0x0600236F RID: 9071 RVA: 0x00080578 File Offset: 0x0007E778
		public override void Initialize()
		{
			this._impl.Initialize();
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x00080585 File Offset: 0x0007E785
		[SecuritySafeCritical]
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			this._impl.TransformBlock(rgb, ibStart, cbSize, null, 0);
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x00080598 File Offset: 0x0007E798
		[SecuritySafeCritical]
		protected override byte[] HashFinal()
		{
			this._impl.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			return this._impl.Hash;
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x000805B8 File Offset: 0x0007E7B8
		protected override void Dispose(bool disposing)
		{
			this._impl.Dispose();
			base.Dispose(disposing);
		}

		// Token: 0x04000CE2 RID: 3298
		private SHA512 _impl;
	}
}
