using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000284 RID: 644
	[ComVisible(true)]
	public class RSAOAEPKeyExchangeFormatter : AsymmetricKeyExchangeFormatter
	{
		// Token: 0x060022F5 RID: 8949 RVA: 0x0007DB24 File Offset: 0x0007BD24
		public RSAOAEPKeyExchangeFormatter()
		{
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x0007DB2C File Offset: 0x0007BD2C
		public RSAOAEPKeyExchangeFormatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060022F7 RID: 8951 RVA: 0x0007DB4E File Offset: 0x0007BD4E
		// (set) Token: 0x060022F8 RID: 8952 RVA: 0x0007DB6A File Offset: 0x0007BD6A
		public byte[] Parameter
		{
			get
			{
				if (this.ParameterValue != null)
				{
					return (byte[])this.ParameterValue.Clone();
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					this.ParameterValue = (byte[])value.Clone();
					return;
				}
				this.ParameterValue = null;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060022F9 RID: 8953 RVA: 0x0007DB88 File Offset: 0x0007BD88
		public override string Parameters
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060022FA RID: 8954 RVA: 0x0007DB8B File Offset: 0x0007BD8B
		// (set) Token: 0x060022FB RID: 8955 RVA: 0x0007DB93 File Offset: 0x0007BD93
		public RandomNumberGenerator Rng
		{
			get
			{
				return this.RngValue;
			}
			set
			{
				this.RngValue = value;
			}
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x0007DB9C File Offset: 0x0007BD9C
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesEncrypt = null;
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x0007DBC4 File Offset: 0x0007BDC4
		[SecuritySafeCritical]
		public override byte[] CreateKeyExchange(byte[] rgbData)
		{
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			if (this.OverridesEncrypt)
			{
				return this._rsaKey.Encrypt(rgbData, RSAEncryptionPadding.OaepSHA1);
			}
			return Utils.RsaOaepEncrypt(this._rsaKey, SHA1.Create(), new PKCS1MaskGenerationMethod(), RandomNumberGenerator.Create(), rgbData);
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x0007DC1E File Offset: 0x0007BE1E
		public override byte[] CreateKeyExchange(byte[] rgbData, Type symAlgType)
		{
			return this.CreateKeyExchange(rgbData);
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060022FF RID: 8959 RVA: 0x0007DC28 File Offset: 0x0007BE28
		private bool OverridesEncrypt
		{
			get
			{
				if (this._rsaOverridesEncrypt == null)
				{
					this._rsaOverridesEncrypt = new bool?(Utils.DoesRsaKeyOverride(this._rsaKey, "Encrypt", new Type[]
					{
						typeof(byte[]),
						typeof(RSAEncryptionPadding)
					}));
				}
				return this._rsaOverridesEncrypt.Value;
			}
		}

		// Token: 0x04000CB1 RID: 3249
		private byte[] ParameterValue;

		// Token: 0x04000CB2 RID: 3250
		private RSA _rsaKey;

		// Token: 0x04000CB3 RID: 3251
		private bool? _rsaOverridesEncrypt;

		// Token: 0x04000CB4 RID: 3252
		private RandomNumberGenerator RngValue;
	}
}
