using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000286 RID: 646
	[ComVisible(true)]
	public class RSAPKCS1KeyExchangeFormatter : AsymmetricKeyExchangeFormatter
	{
		// Token: 0x06002309 RID: 8969 RVA: 0x0007DDE4 File Offset: 0x0007BFE4
		public RSAPKCS1KeyExchangeFormatter()
		{
		}

		// Token: 0x0600230A RID: 8970 RVA: 0x0007DDEC File Offset: 0x0007BFEC
		public RSAPKCS1KeyExchangeFormatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x0600230B RID: 8971 RVA: 0x0007DE0E File Offset: 0x0007C00E
		public override string Parameters
		{
			get
			{
				return "<enc:KeyEncryptionMethod enc:Algorithm=\"http://www.microsoft.com/xml/security/algorithm/PKCS1-v1.5-KeyEx\" xmlns:enc=\"http://www.microsoft.com/xml/security/encryption/v1.0\" />";
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x0600230C RID: 8972 RVA: 0x0007DE15 File Offset: 0x0007C015
		// (set) Token: 0x0600230D RID: 8973 RVA: 0x0007DE1D File Offset: 0x0007C01D
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

		// Token: 0x0600230E RID: 8974 RVA: 0x0007DE26 File Offset: 0x0007C026
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesEncrypt = null;
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x0007DE50 File Offset: 0x0007C050
		public override byte[] CreateKeyExchange(byte[] rgbData)
		{
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			byte[] result;
			if (this.OverridesEncrypt)
			{
				result = this._rsaKey.Encrypt(rgbData, RSAEncryptionPadding.Pkcs1);
			}
			else
			{
				int num = this._rsaKey.KeySize / 8;
				if (rgbData.Length + 11 > num)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_Padding_EncDataTooBig", new object[]
					{
						num - 11
					}));
				}
				byte[] array = new byte[num];
				if (this.RngValue == null)
				{
					this.RngValue = RandomNumberGenerator.Create();
				}
				this.Rng.GetNonZeroBytes(array);
				array[0] = 0;
				array[1] = 2;
				array[num - rgbData.Length - 1] = 0;
				Buffer.InternalBlockCopy(rgbData, 0, array, num - rgbData.Length, rgbData.Length);
				result = this._rsaKey.EncryptValue(array);
			}
			return result;
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x0007DF23 File Offset: 0x0007C123
		public override byte[] CreateKeyExchange(byte[] rgbData, Type symAlgType)
		{
			return this.CreateKeyExchange(rgbData);
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06002311 RID: 8977 RVA: 0x0007DF2C File Offset: 0x0007C12C
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

		// Token: 0x04000CB8 RID: 3256
		private RandomNumberGenerator RngValue;

		// Token: 0x04000CB9 RID: 3257
		private RSA _rsaKey;

		// Token: 0x04000CBA RID: 3258
		private bool? _rsaOverridesEncrypt;
	}
}
