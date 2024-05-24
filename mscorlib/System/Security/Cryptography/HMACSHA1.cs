using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000264 RID: 612
	[ComVisible(true)]
	public class HMACSHA1 : HMAC
	{
		// Token: 0x060021BF RID: 8639 RVA: 0x00077954 File Offset: 0x00075B54
		public HMACSHA1() : this(Utils.GenerateRandom(64))
		{
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x00077963 File Offset: 0x00075B63
		public HMACSHA1(byte[] key) : this(key, false)
		{
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x00077970 File Offset: 0x00075B70
		public HMACSHA1(byte[] key, bool useManagedSha1)
		{
			this.m_hashName = "SHA1";
			this.HashSizeValue = 160;
			if (base.GetType() == typeof(HMACSHA1))
			{
				this.m_impl = new NativeHmac(CapiNative.AlgorithmID.Sha1);
			}
			else if (useManagedSha1)
			{
				this.m_hash1 = new SHA1Managed();
				this.m_hash2 = new SHA1Managed();
			}
			else
			{
				this.m_hash1 = new SHA1CryptoServiceProvider();
				this.m_hash2 = new SHA1CryptoServiceProvider();
			}
			base.InitializeKey(key);
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x000779FA File Offset: 0x00075BFA
		internal sealed override HashAlgorithm InstantiateHash()
		{
			return new SHA1CryptoServiceProvider();
		}
	}
}
