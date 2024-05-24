using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000285 RID: 645
	[ComVisible(true)]
	public class RSAPKCS1KeyExchangeDeformatter : AsymmetricKeyExchangeDeformatter
	{
		// Token: 0x06002300 RID: 8960 RVA: 0x0007DC88 File Offset: 0x0007BE88
		public RSAPKCS1KeyExchangeDeformatter()
		{
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x0007DC90 File Offset: 0x0007BE90
		public RSAPKCS1KeyExchangeDeformatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06002302 RID: 8962 RVA: 0x0007DCB2 File Offset: 0x0007BEB2
		// (set) Token: 0x06002303 RID: 8963 RVA: 0x0007DCBA File Offset: 0x0007BEBA
		public RandomNumberGenerator RNG
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

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06002304 RID: 8964 RVA: 0x0007DCC3 File Offset: 0x0007BEC3
		// (set) Token: 0x06002305 RID: 8965 RVA: 0x0007DCC6 File Offset: 0x0007BEC6
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

		// Token: 0x06002306 RID: 8966 RVA: 0x0007DCC8 File Offset: 0x0007BEC8
		public override byte[] DecryptKeyExchange(byte[] rgbIn)
		{
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			byte[] array;
			if (this.OverridesDecrypt)
			{
				array = this._rsaKey.Decrypt(rgbIn, RSAEncryptionPadding.Pkcs1);
			}
			else
			{
				byte[] array2 = this._rsaKey.DecryptValue(rgbIn);
				int num = 2;
				while (num < array2.Length && array2[num] != 0)
				{
					num++;
				}
				if (num >= array2.Length)
				{
					throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_PKCS1Decoding"));
				}
				num++;
				array = new byte[array2.Length - num];
				Buffer.InternalBlockCopy(array2, num, array, 0, array.Length);
			}
			return array;
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x0007DD5B File Offset: 0x0007BF5B
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesDecrypt = null;
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06002308 RID: 8968 RVA: 0x0007DD84 File Offset: 0x0007BF84
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

		// Token: 0x04000CB5 RID: 3253
		private RSA _rsaKey;

		// Token: 0x04000CB6 RID: 3254
		private bool? _rsaOverridesDecrypt;

		// Token: 0x04000CB7 RID: 3255
		private RandomNumberGenerator RngValue;
	}
}
