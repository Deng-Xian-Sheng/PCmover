using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000296 RID: 662
	[ComVisible(true)]
	public class SHA384Managed : SHA384
	{
		// Token: 0x06002366 RID: 9062 RVA: 0x00080482 File Offset: 0x0007E682
		public SHA384Managed()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			this._impl = (SHA384)CryptoConfig.CreateFromName("System.Security.Cryptography.SHA384Cng");
		}

		// Token: 0x06002367 RID: 9063 RVA: 0x000804BD File Offset: 0x0007E6BD
		public override void Initialize()
		{
			this._impl.Initialize();
		}

		// Token: 0x06002368 RID: 9064 RVA: 0x000804CA File Offset: 0x0007E6CA
		[SecuritySafeCritical]
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			this._impl.TransformBlock(rgb, ibStart, cbSize, null, 0);
		}

		// Token: 0x06002369 RID: 9065 RVA: 0x000804DD File Offset: 0x0007E6DD
		[SecuritySafeCritical]
		protected override byte[] HashFinal()
		{
			this._impl.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			return this._impl.Hash;
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x000804FD File Offset: 0x0007E6FD
		protected override void Dispose(bool disposing)
		{
			this._impl.Dispose();
			base.Dispose(disposing);
		}

		// Token: 0x04000CE1 RID: 3297
		private SHA384 _impl;
	}
}
