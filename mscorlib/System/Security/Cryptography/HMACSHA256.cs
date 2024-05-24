using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000265 RID: 613
	[ComVisible(true)]
	public class HMACSHA256 : HMAC
	{
		// Token: 0x060021C3 RID: 8643 RVA: 0x00077A01 File Offset: 0x00075C01
		public HMACSHA256() : this(Utils.GenerateRandom(64))
		{
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x00077A10 File Offset: 0x00075C10
		public HMACSHA256(byte[] key)
		{
			this.m_hashName = "SHA256";
			this.HashSizeValue = 256;
			if (base.GetType() == typeof(HMACSHA256))
			{
				this.m_impl = new NativeHmac(CapiNative.AlgorithmID.Sha256);
			}
			else
			{
				this.m_hash1 = this.InstantiateHash();
				this.m_hash2 = this.InstantiateHash();
			}
			base.InitializeKey(key);
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x00077A84 File Offset: 0x00075C84
		internal sealed override HashAlgorithm InstantiateHash()
		{
			return HMAC.GetHashAlgorithmWithFipsFallback(() => new SHA256Managed(), () => HashAlgorithm.Create("System.Security.Cryptography.SHA256CryptoServiceProvider"));
		}
	}
}
