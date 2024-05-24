﻿using System;
using System.Runtime.CompilerServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000248 RID: 584
	[TypeForwardedFrom("System.Core, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	public abstract class Aes : SymmetricAlgorithm
	{
		// Token: 0x060020CD RID: 8397 RVA: 0x00072AEC File Offset: 0x00070CEC
		protected Aes()
		{
			this.LegalBlockSizesValue = Aes.s_legalBlockSizes;
			this.LegalKeySizesValue = Aes.s_legalKeySizes;
			this.BlockSizeValue = 128;
			this.FeedbackSizeValue = 8;
			this.KeySizeValue = 256;
			this.ModeValue = CipherMode.CBC;
		}

		// Token: 0x060020CE RID: 8398 RVA: 0x00072B39 File Offset: 0x00070D39
		public new static Aes Create()
		{
			return Aes.Create("AES");
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x00072B45 File Offset: 0x00070D45
		public new static Aes Create(string algorithmName)
		{
			if (algorithmName == null)
			{
				throw new ArgumentNullException("algorithmName");
			}
			return CryptoConfig.CreateFromName(algorithmName) as Aes;
		}

		// Token: 0x04000BE6 RID: 3046
		private static KeySizes[] s_legalBlockSizes = new KeySizes[]
		{
			new KeySizes(128, 128, 0)
		};

		// Token: 0x04000BE7 RID: 3047
		private static KeySizes[] s_legalKeySizes = new KeySizes[]
		{
			new KeySizes(128, 256, 64)
		};
	}
}
