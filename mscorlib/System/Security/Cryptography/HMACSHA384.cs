using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000266 RID: 614
	[ComVisible(true)]
	public class HMACSHA384 : HMAC
	{
		// Token: 0x060021C6 RID: 8646 RVA: 0x00077AD4 File Offset: 0x00075CD4
		public HMACSHA384() : this(Utils.GenerateRandom(128))
		{
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x00077AE8 File Offset: 0x00075CE8
		[SecuritySafeCritical]
		public HMACSHA384(byte[] key)
		{
			this.m_hashName = "SHA384";
			this.HashSizeValue = 384;
			base.BlockSizeValue = this.BlockSize;
			if (base.GetType() == typeof(HMACSHA384) && !this.m_useLegacyBlockSize)
			{
				this.m_impl = new NativeHmac(CapiNative.AlgorithmID.Sha384);
			}
			else
			{
				this.m_hash1 = this.InstantiateHash();
				this.m_hash2 = this.InstantiateHash();
			}
			base.InitializeKey(key);
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060021C8 RID: 8648 RVA: 0x00077B78 File Offset: 0x00075D78
		private int BlockSize
		{
			get
			{
				if (!this.m_useLegacyBlockSize)
				{
					return 128;
				}
				return 64;
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060021C9 RID: 8649 RVA: 0x00077B8A File Offset: 0x00075D8A
		// (set) Token: 0x060021CA RID: 8650 RVA: 0x00077B94 File Offset: 0x00075D94
		public bool ProduceLegacyHmacValues
		{
			get
			{
				return this.m_useLegacyBlockSize;
			}
			set
			{
				this.m_useLegacyBlockSize = value;
				if (this.m_impl != null && value)
				{
					if (this.m_hashing)
					{
						throw new CryptographicException(Environment.GetResourceString("Cryptography_HashNameSet"));
					}
					this.m_impl.Dispose();
					this.m_impl = null;
					this.m_hash1 = this.InstantiateHash();
					this.m_hash2 = this.InstantiateHash();
				}
				base.BlockSizeValue = this.BlockSize;
				if (this.m_impl == null)
				{
					base.InitializeKey(this.KeyValue);
				}
			}
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x00077C18 File Offset: 0x00075E18
		internal sealed override HashAlgorithm InstantiateHash()
		{
			return HMAC.GetHashAlgorithmWithFipsFallback(() => new SHA384Managed(), () => HashAlgorithm.Create("System.Security.Cryptography.SHA384CryptoServiceProvider"));
		}

		// Token: 0x04000C4E RID: 3150
		private bool m_useLegacyBlockSize = Utils._ProduceLegacyHmacValues();
	}
}
