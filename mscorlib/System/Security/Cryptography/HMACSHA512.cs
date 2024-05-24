using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000267 RID: 615
	[ComVisible(true)]
	public class HMACSHA512 : HMAC
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x00077C68 File Offset: 0x00075E68
		public HMACSHA512() : this(Utils.GenerateRandom(128))
		{
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x00077C7C File Offset: 0x00075E7C
		[SecuritySafeCritical]
		public HMACSHA512(byte[] key)
		{
			this.m_hashName = "SHA512";
			this.HashSizeValue = 512;
			base.BlockSizeValue = this.BlockSize;
			if (base.GetType() == typeof(HMACSHA512) && !this.m_useLegacyBlockSize)
			{
				this.m_impl = new NativeHmac(CapiNative.AlgorithmID.Sha512);
			}
			else
			{
				this.m_hash1 = this.InstantiateHash();
				this.m_hash2 = this.InstantiateHash();
			}
			base.InitializeKey(key);
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x060021CE RID: 8654 RVA: 0x00077D0C File Offset: 0x00075F0C
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

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x060021CF RID: 8655 RVA: 0x00077D1E File Offset: 0x00075F1E
		// (set) Token: 0x060021D0 RID: 8656 RVA: 0x00077D28 File Offset: 0x00075F28
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

		// Token: 0x060021D1 RID: 8657 RVA: 0x00077DAC File Offset: 0x00075FAC
		internal sealed override HashAlgorithm InstantiateHash()
		{
			return HMAC.GetHashAlgorithmWithFipsFallback(() => new SHA512Managed(), () => HashAlgorithm.Create("System.Security.Cryptography.SHA512CryptoServiceProvider"));
		}

		// Token: 0x04000C4F RID: 3151
		private bool m_useLegacyBlockSize = Utils._ProduceLegacyHmacValues();
	}
}
