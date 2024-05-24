using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000294 RID: 660
	[ComVisible(true)]
	public class SHA256Managed : SHA256
	{
		// Token: 0x0600235E RID: 9054 RVA: 0x000803C7 File Offset: 0x0007E5C7
		public SHA256Managed()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			this._impl = (SHA256)CryptoConfig.CreateFromName("System.Security.Cryptography.SHA256Cng");
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x00080402 File Offset: 0x0007E602
		public override void Initialize()
		{
			this._impl.Initialize();
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x0008040F File Offset: 0x0007E60F
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			this._impl.TransformBlock(rgb, ibStart, cbSize, null, 0);
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x00080422 File Offset: 0x0007E622
		protected override byte[] HashFinal()
		{
			this._impl.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			return this._impl.Hash;
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x00080442 File Offset: 0x0007E642
		protected override void Dispose(bool disposing)
		{
			this._impl.Dispose();
			base.Dispose(disposing);
		}

		// Token: 0x04000CE0 RID: 3296
		private SHA256 _impl;
	}
}
