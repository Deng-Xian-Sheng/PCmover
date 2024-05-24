using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000276 RID: 630
	[ComVisible(true)]
	public abstract class RC2 : SymmetricAlgorithm
	{
		// Token: 0x06002251 RID: 8785 RVA: 0x00079724 File Offset: 0x00077924
		protected RC2()
		{
			this.KeySizeValue = 128;
			this.BlockSizeValue = 64;
			this.FeedbackSizeValue = this.BlockSizeValue;
			this.LegalBlockSizesValue = RC2.s_legalBlockSizes;
			this.LegalKeySizesValue = RC2.s_legalKeySizes;
		}

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06002252 RID: 8786 RVA: 0x00079761 File Offset: 0x00077961
		// (set) Token: 0x06002253 RID: 8787 RVA: 0x00079778 File Offset: 0x00077978
		public virtual int EffectiveKeySize
		{
			get
			{
				if (this.EffectiveKeySizeValue == 0)
				{
					return this.KeySizeValue;
				}
				return this.EffectiveKeySizeValue;
			}
			set
			{
				if (value > this.KeySizeValue)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_RC2_EKSKS"));
				}
				if (value == 0)
				{
					this.EffectiveKeySizeValue = value;
					return;
				}
				if (value < 40)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_RC2_EKS40"));
				}
				if (base.ValidKeySize(value))
				{
					this.EffectiveKeySizeValue = value;
					return;
				}
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
			}
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06002254 RID: 8788 RVA: 0x000797DE File Offset: 0x000779DE
		// (set) Token: 0x06002255 RID: 8789 RVA: 0x000797E6 File Offset: 0x000779E6
		public override int KeySize
		{
			get
			{
				return this.KeySizeValue;
			}
			set
			{
				if (value < this.EffectiveKeySizeValue)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_RC2_EKSKS"));
				}
				base.KeySize = value;
			}
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x00079808 File Offset: 0x00077A08
		public new static RC2 Create()
		{
			return RC2.Create("System.Security.Cryptography.RC2");
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x00079814 File Offset: 0x00077A14
		public new static RC2 Create(string AlgName)
		{
			return (RC2)CryptoConfig.CreateFromName(AlgName);
		}

		// Token: 0x04000C75 RID: 3189
		protected int EffectiveKeySizeValue;

		// Token: 0x04000C76 RID: 3190
		private static KeySizes[] s_legalBlockSizes = new KeySizes[]
		{
			new KeySizes(64, 64, 0)
		};

		// Token: 0x04000C77 RID: 3191
		private static KeySizes[] s_legalKeySizes = new KeySizes[]
		{
			new KeySizes(40, 1024, 8)
		};
	}
}
