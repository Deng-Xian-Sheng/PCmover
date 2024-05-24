using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000262 RID: 610
	[ComVisible(true)]
	public class HMACMD5 : HMAC
	{
		// Token: 0x060021BA RID: 8634 RVA: 0x00077884 File Offset: 0x00075A84
		public HMACMD5() : this(Utils.GenerateRandom(64))
		{
		}

		// Token: 0x060021BB RID: 8635 RVA: 0x00077894 File Offset: 0x00075A94
		public HMACMD5(byte[] key)
		{
			this.m_hashName = "MD5";
			this.HashSizeValue = 128;
			if (base.GetType() == typeof(HMACMD5))
			{
				this.m_impl = new NativeHmac(CapiNative.AlgorithmID.Md5);
			}
			else
			{
				this.m_hash1 = new MD5CryptoServiceProvider();
				this.m_hash2 = new MD5CryptoServiceProvider();
			}
			base.InitializeKey(key);
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x00077903 File Offset: 0x00075B03
		internal sealed override HashAlgorithm InstantiateHash()
		{
			return new MD5CryptoServiceProvider();
		}
	}
}
