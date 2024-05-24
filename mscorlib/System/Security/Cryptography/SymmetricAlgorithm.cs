using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x020002A0 RID: 672
	[ComVisible(true)]
	public abstract class SymmetricAlgorithm : IDisposable
	{
		// Token: 0x06002388 RID: 9096 RVA: 0x000807DA File Offset: 0x0007E9DA
		protected SymmetricAlgorithm()
		{
			this.ModeValue = CipherMode.CBC;
			this.PaddingValue = PaddingMode.PKCS7;
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x000807F0 File Offset: 0x0007E9F0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x000807FF File Offset: 0x0007E9FF
		public void Clear()
		{
			((IDisposable)this).Dispose();
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x00080808 File Offset: 0x0007EA08
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.KeyValue != null)
				{
					Array.Clear(this.KeyValue, 0, this.KeyValue.Length);
					this.KeyValue = null;
				}
				if (this.IVValue != null)
				{
					Array.Clear(this.IVValue, 0, this.IVValue.Length);
					this.IVValue = null;
				}
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x0600238C RID: 9100 RVA: 0x0008085E File Offset: 0x0007EA5E
		// (set) Token: 0x0600238D RID: 9101 RVA: 0x00080868 File Offset: 0x0007EA68
		public virtual int BlockSize
		{
			get
			{
				return this.BlockSizeValue;
			}
			set
			{
				for (int i = 0; i < this.LegalBlockSizesValue.Length; i++)
				{
					if (this.LegalBlockSizesValue[i].SkipSize == 0)
					{
						if (this.LegalBlockSizesValue[i].MinSize == value)
						{
							this.BlockSizeValue = value;
							this.IVValue = null;
							return;
						}
					}
					else
					{
						for (int j = this.LegalBlockSizesValue[i].MinSize; j <= this.LegalBlockSizesValue[i].MaxSize; j += this.LegalBlockSizesValue[i].SkipSize)
						{
							if (j == value)
							{
								if (this.BlockSizeValue != value)
								{
									this.BlockSizeValue = value;
									this.IVValue = null;
								}
								return;
							}
						}
					}
				}
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidBlockSize"));
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x00080914 File Offset: 0x0007EB14
		// (set) Token: 0x0600238F RID: 9103 RVA: 0x0008091C File Offset: 0x0007EB1C
		public virtual int FeedbackSize
		{
			get
			{
				return this.FeedbackSizeValue;
			}
			set
			{
				if (value <= 0 || value > this.BlockSizeValue || value % 8 != 0)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidFeedbackSize"));
				}
				this.FeedbackSizeValue = value;
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06002390 RID: 9104 RVA: 0x00080947 File Offset: 0x0007EB47
		// (set) Token: 0x06002391 RID: 9105 RVA: 0x00080967 File Offset: 0x0007EB67
		public virtual byte[] IV
		{
			get
			{
				if (this.IVValue == null)
				{
					this.GenerateIV();
				}
				return (byte[])this.IVValue.Clone();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != this.BlockSizeValue / 8)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidIVSize"));
				}
				this.IVValue = (byte[])value.Clone();
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06002392 RID: 9106 RVA: 0x000809A5 File Offset: 0x0007EBA5
		// (set) Token: 0x06002393 RID: 9107 RVA: 0x000809C8 File Offset: 0x0007EBC8
		public virtual byte[] Key
		{
			get
			{
				if (this.KeyValue == null)
				{
					this.GenerateKey();
				}
				return (byte[])this.KeyValue.Clone();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!this.ValidKeySize(value.Length * 8))
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
				}
				this.KeyValue = (byte[])value.Clone();
				this.KeySizeValue = value.Length * 8;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06002394 RID: 9108 RVA: 0x00080A1C File Offset: 0x0007EC1C
		public virtual KeySizes[] LegalBlockSizes
		{
			get
			{
				return (KeySizes[])this.LegalBlockSizesValue.Clone();
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06002395 RID: 9109 RVA: 0x00080A2E File Offset: 0x0007EC2E
		public virtual KeySizes[] LegalKeySizes
		{
			get
			{
				return (KeySizes[])this.LegalKeySizesValue.Clone();
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06002396 RID: 9110 RVA: 0x00080A40 File Offset: 0x0007EC40
		// (set) Token: 0x06002397 RID: 9111 RVA: 0x00080A48 File Offset: 0x0007EC48
		public virtual int KeySize
		{
			get
			{
				return this.KeySizeValue;
			}
			set
			{
				if (!this.ValidKeySize(value))
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
				}
				this.KeySizeValue = value;
				this.KeyValue = null;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06002398 RID: 9112 RVA: 0x00080A71 File Offset: 0x0007EC71
		// (set) Token: 0x06002399 RID: 9113 RVA: 0x00080A79 File Offset: 0x0007EC79
		public virtual CipherMode Mode
		{
			get
			{
				return this.ModeValue;
			}
			set
			{
				if (value < CipherMode.CBC || CipherMode.CFB < value)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidCipherMode"));
				}
				this.ModeValue = value;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x00080A9A File Offset: 0x0007EC9A
		// (set) Token: 0x0600239B RID: 9115 RVA: 0x00080AA2 File Offset: 0x0007ECA2
		public virtual PaddingMode Padding
		{
			get
			{
				return this.PaddingValue;
			}
			set
			{
				if (value < PaddingMode.None || PaddingMode.ISO10126 < value)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidPaddingMode"));
				}
				this.PaddingValue = value;
			}
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x00080AC4 File Offset: 0x0007ECC4
		public bool ValidKeySize(int bitLength)
		{
			KeySizes[] legalKeySizes = this.LegalKeySizes;
			if (legalKeySizes == null)
			{
				return false;
			}
			for (int i = 0; i < legalKeySizes.Length; i++)
			{
				if (legalKeySizes[i].SkipSize == 0)
				{
					if (legalKeySizes[i].MinSize == bitLength)
					{
						return true;
					}
				}
				else
				{
					for (int j = legalKeySizes[i].MinSize; j <= legalKeySizes[i].MaxSize; j += legalKeySizes[i].SkipSize)
					{
						if (j == bitLength)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600239D RID: 9117 RVA: 0x00080B2A File Offset: 0x0007ED2A
		public static SymmetricAlgorithm Create()
		{
			return SymmetricAlgorithm.Create("System.Security.Cryptography.SymmetricAlgorithm");
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x00080B36 File Offset: 0x0007ED36
		public static SymmetricAlgorithm Create(string algName)
		{
			return (SymmetricAlgorithm)CryptoConfig.CreateFromName(algName);
		}

		// Token: 0x0600239F RID: 9119 RVA: 0x00080B43 File Offset: 0x0007ED43
		public virtual ICryptoTransform CreateEncryptor()
		{
			return this.CreateEncryptor(this.Key, this.IV);
		}

		// Token: 0x060023A0 RID: 9120
		public abstract ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV);

		// Token: 0x060023A1 RID: 9121 RVA: 0x00080B57 File Offset: 0x0007ED57
		public virtual ICryptoTransform CreateDecryptor()
		{
			return this.CreateDecryptor(this.Key, this.IV);
		}

		// Token: 0x060023A2 RID: 9122
		public abstract ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV);

		// Token: 0x060023A3 RID: 9123
		public abstract void GenerateKey();

		// Token: 0x060023A4 RID: 9124
		public abstract void GenerateIV();

		// Token: 0x04000CE8 RID: 3304
		protected int BlockSizeValue;

		// Token: 0x04000CE9 RID: 3305
		protected int FeedbackSizeValue;

		// Token: 0x04000CEA RID: 3306
		protected byte[] IVValue;

		// Token: 0x04000CEB RID: 3307
		protected byte[] KeyValue;

		// Token: 0x04000CEC RID: 3308
		protected KeySizes[] LegalBlockSizesValue;

		// Token: 0x04000CED RID: 3309
		protected KeySizes[] LegalKeySizesValue;

		// Token: 0x04000CEE RID: 3310
		protected int KeySizeValue;

		// Token: 0x04000CEF RID: 3311
		protected CipherMode ModeValue;

		// Token: 0x04000CF0 RID: 3312
		protected PaddingMode PaddingValue;
	}
}
