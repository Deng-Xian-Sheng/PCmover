using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000277 RID: 631
	[ComVisible(true)]
	public sealed class RC2CryptoServiceProvider : RC2
	{
		// Token: 0x06002259 RID: 8793 RVA: 0x00079858 File Offset: 0x00077A58
		[SecuritySafeCritical]
		public RC2CryptoServiceProvider()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			if (!Utils.HasAlgorithm(26114, 0))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_AlgorithmNotAvailable"));
			}
			this.LegalKeySizesValue = RC2CryptoServiceProvider.s_legalKeySizes;
			this.FeedbackSizeValue = 8;
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x0600225A RID: 8794 RVA: 0x000798B8 File Offset: 0x00077AB8
		// (set) Token: 0x0600225B RID: 8795 RVA: 0x000798C0 File Offset: 0x00077AC0
		public override int EffectiveKeySize
		{
			get
			{
				return this.KeySizeValue;
			}
			set
			{
				if (value != this.KeySizeValue)
				{
					throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_RC2_EKSKS2"));
				}
			}
		}

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x0600225C RID: 8796 RVA: 0x000798DB File Offset: 0x00077ADB
		// (set) Token: 0x0600225D RID: 8797 RVA: 0x000798E3 File Offset: 0x00077AE3
		[ComVisible(false)]
		public bool UseSalt
		{
			get
			{
				return this.m_use40bitSalt;
			}
			set
			{
				this.m_use40bitSalt = value;
			}
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x000798EC File Offset: 0x00077AEC
		[SecuritySafeCritical]
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this._NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.EffectiveKeySizeValue, this.FeedbackSizeValue, CryptoAPITransformMode.Encrypt);
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x00079909 File Offset: 0x00077B09
		[SecuritySafeCritical]
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this._NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.EffectiveKeySizeValue, this.FeedbackSizeValue, CryptoAPITransformMode.Decrypt);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x00079926 File Offset: 0x00077B26
		public override void GenerateKey()
		{
			this.KeyValue = new byte[this.KeySizeValue / 8];
			Utils.StaticRandomNumberGenerator.GetBytes(this.KeyValue);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x0007994B File Offset: 0x00077B4B
		public override void GenerateIV()
		{
			this.IVValue = new byte[8];
			Utils.StaticRandomNumberGenerator.GetBytes(this.IVValue);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x0007996C File Offset: 0x00077B6C
		[SecurityCritical]
		private ICryptoTransform _NewEncryptor(byte[] rgbKey, CipherMode mode, byte[] rgbIV, int effectiveKeySize, int feedbackSize, CryptoAPITransformMode encryptMode)
		{
			int num = 0;
			int[] array = new int[10];
			object[] array2 = new object[10];
			if (mode == CipherMode.OFB)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_OFBNotSupported"));
			}
			if (mode == CipherMode.CFB && feedbackSize != 8)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_CFBSizeNotSupported"));
			}
			if (rgbKey == null)
			{
				rgbKey = new byte[this.KeySizeValue / 8];
				Utils.StaticRandomNumberGenerator.GetBytes(rgbKey);
			}
			int num2 = rgbKey.Length * 8;
			if (!base.ValidKeySize(num2))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
			}
			array[num] = 19;
			if (this.EffectiveKeySizeValue == 0)
			{
				array2[num] = num2;
			}
			else
			{
				array2[num] = effectiveKeySize;
			}
			num++;
			if (mode != CipherMode.CBC)
			{
				array[num] = 4;
				array2[num] = mode;
				num++;
			}
			if (mode != CipherMode.ECB)
			{
				if (rgbIV == null)
				{
					rgbIV = new byte[8];
					Utils.StaticRandomNumberGenerator.GetBytes(rgbIV);
				}
				if (rgbIV.Length < 8)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidIVSize"));
				}
				array[num] = 1;
				array2[num] = rgbIV;
				num++;
			}
			if (mode == CipherMode.OFB || mode == CipherMode.CFB)
			{
				array[num] = 5;
				array2[num] = feedbackSize;
				num++;
			}
			if (!Utils.HasAlgorithm(26114, num2))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_AlgKeySizeNotAvailable", new object[]
				{
					num2
				}));
			}
			return new CryptoAPITransform(26114, num, array, array2, rgbKey, this.PaddingValue, mode, this.BlockSizeValue, feedbackSize, this.m_use40bitSalt, encryptMode);
		}

		// Token: 0x04000C78 RID: 3192
		private bool m_use40bitSalt;

		// Token: 0x04000C79 RID: 3193
		private static KeySizes[] s_legalKeySizes = new KeySizes[]
		{
			new KeySizes(40, 128, 8)
		};
	}
}
