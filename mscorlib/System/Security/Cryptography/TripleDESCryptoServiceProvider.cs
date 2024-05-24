using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x020002A2 RID: 674
	[ComVisible(true)]
	public sealed class TripleDESCryptoServiceProvider : TripleDES
	{
		// Token: 0x060023AE RID: 9134 RVA: 0x00080D8D File Offset: 0x0007EF8D
		[SecuritySafeCritical]
		public TripleDESCryptoServiceProvider()
		{
			if (!Utils.HasAlgorithm(26115, 0))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_AlgorithmNotAvailable"));
			}
			this.FeedbackSizeValue = 8;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x00080DB9 File Offset: 0x0007EFB9
		[SecuritySafeCritical]
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			if (TripleDES.IsWeakKey(rgbKey))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKey_Weak"), "TripleDES");
			}
			return this._NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.FeedbackSizeValue, CryptoAPITransformMode.Encrypt);
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x00080DED File Offset: 0x0007EFED
		[SecuritySafeCritical]
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			if (TripleDES.IsWeakKey(rgbKey))
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKey_Weak"), "TripleDES");
			}
			return this._NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.FeedbackSizeValue, CryptoAPITransformMode.Decrypt);
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x00080E24 File Offset: 0x0007F024
		public override void GenerateKey()
		{
			this.KeyValue = new byte[this.KeySizeValue / 8];
			Utils.StaticRandomNumberGenerator.GetBytes(this.KeyValue);
			while (TripleDES.IsWeakKey(this.KeyValue))
			{
				Utils.StaticRandomNumberGenerator.GetBytes(this.KeyValue);
			}
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x00080E73 File Offset: 0x0007F073
		public override void GenerateIV()
		{
			this.IVValue = new byte[8];
			Utils.StaticRandomNumberGenerator.GetBytes(this.IVValue);
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x00080E94 File Offset: 0x0007F094
		[SecurityCritical]
		private ICryptoTransform _NewEncryptor(byte[] rgbKey, CipherMode mode, byte[] rgbIV, int feedbackSize, CryptoAPITransformMode encryptMode)
		{
			int num = 0;
			int[] array = new int[10];
			object[] array2 = new object[10];
			int algid = 26115;
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
			if (rgbKey.Length == 16)
			{
				algid = 26121;
			}
			return new CryptoAPITransform(algid, num, array, array2, rgbKey, this.PaddingValue, mode, this.BlockSizeValue, feedbackSize, false, encryptMode);
		}
	}
}
