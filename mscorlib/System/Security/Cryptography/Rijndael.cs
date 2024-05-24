using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000289 RID: 649
	[ComVisible(true)]
	public abstract class Rijndael : SymmetricAlgorithm
	{
		// Token: 0x0600231E RID: 8990 RVA: 0x0007E2D9 File Offset: 0x0007C4D9
		protected Rijndael()
		{
			this.KeySizeValue = 256;
			this.BlockSizeValue = 128;
			this.FeedbackSizeValue = this.BlockSizeValue;
			this.LegalBlockSizesValue = Rijndael.s_legalBlockSizes;
			this.LegalKeySizesValue = Rijndael.s_legalKeySizes;
		}

		// Token: 0x0600231F RID: 8991 RVA: 0x0007E319 File Offset: 0x0007C519
		public new static Rijndael Create()
		{
			return Rijndael.Create("System.Security.Cryptography.Rijndael");
		}

		// Token: 0x06002320 RID: 8992 RVA: 0x0007E325 File Offset: 0x0007C525
		public new static Rijndael Create(string algName)
		{
			return (Rijndael)CryptoConfig.CreateFromName(algName);
		}

		// Token: 0x04000CC1 RID: 3265
		private static KeySizes[] s_legalBlockSizes = new KeySizes[]
		{
			new KeySizes(128, 256, 64)
		};

		// Token: 0x04000CC2 RID: 3266
		private static KeySizes[] s_legalKeySizes = new KeySizes[]
		{
			new KeySizes(128, 256, 64)
		};
	}
}
