using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000283 RID: 643
	[ComVisible(true)]
	public class RSAOAEPKeyExchangeDeformatter : AsymmetricKeyExchangeDeformatter
	{
		// Token: 0x060022EE RID: 8942 RVA: 0x0007DA15 File Offset: 0x0007BC15
		public RSAOAEPKeyExchangeDeformatter()
		{
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x0007DA1D File Offset: 0x0007BC1D
		public RSAOAEPKeyExchangeDeformatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060022F0 RID: 8944 RVA: 0x0007DA3F File Offset: 0x0007BC3F
		// (set) Token: 0x060022F1 RID: 8945 RVA: 0x0007DA42 File Offset: 0x0007BC42
		public override string Parameters
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x0007DA44 File Offset: 0x0007BC44
		[SecuritySafeCritical]
		public override byte[] DecryptKeyExchange(byte[] rgbData)
		{
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			if (this.OverridesDecrypt)
			{
				return this._rsaKey.Decrypt(rgbData, RSAEncryptionPadding.OaepSHA1);
			}
			return Utils.RsaOaepDecrypt(this._rsaKey, SHA1.Create(), new PKCS1MaskGenerationMethod(), rgbData);
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x0007DA99 File Offset: 0x0007BC99
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesDecrypt = null;
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060022F4 RID: 8948 RVA: 0x0007DAC4 File Offset: 0x0007BCC4
		private bool OverridesDecrypt
		{
			get
			{
				if (this._rsaOverridesDecrypt == null)
				{
					this._rsaOverridesDecrypt = new bool?(Utils.DoesRsaKeyOverride(this._rsaKey, "Decrypt", new Type[]
					{
						typeof(byte[]),
						typeof(RSAEncryptionPadding)
					}));
				}
				return this._rsaOverridesDecrypt.Value;
			}
		}

		// Token: 0x04000CAF RID: 3247
		private RSA _rsaKey;

		// Token: 0x04000CB0 RID: 3248
		private bool? _rsaOverridesDecrypt;
	}
}
