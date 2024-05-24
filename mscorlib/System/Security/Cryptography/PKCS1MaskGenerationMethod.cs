using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000275 RID: 629
	[ComVisible(true)]
	public class PKCS1MaskGenerationMethod : MaskGenerationMethod
	{
		// Token: 0x0600224D RID: 8781 RVA: 0x00079643 File Offset: 0x00077843
		public PKCS1MaskGenerationMethod()
		{
			this.HashNameValue = "SHA1";
		}

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x0600224E RID: 8782 RVA: 0x00079656 File Offset: 0x00077856
		// (set) Token: 0x0600224F RID: 8783 RVA: 0x0007965E File Offset: 0x0007785E
		public string HashName
		{
			get
			{
				return this.HashNameValue;
			}
			set
			{
				this.HashNameValue = value;
				if (this.HashNameValue == null)
				{
					this.HashNameValue = "SHA1";
				}
			}
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x0007967C File Offset: 0x0007787C
		public override byte[] GenerateMask(byte[] rgbSeed, int cbReturn)
		{
			HashAlgorithm hashAlgorithm = (HashAlgorithm)CryptoConfig.CreateFromName(this.HashNameValue);
			byte[] inputBuffer = new byte[4];
			byte[] array = new byte[cbReturn];
			uint num = 0U;
			for (int i = 0; i < array.Length; i += hashAlgorithm.Hash.Length)
			{
				Utils.ConvertIntToByteArray(num++, ref inputBuffer);
				hashAlgorithm.TransformBlock(rgbSeed, 0, rgbSeed.Length, rgbSeed, 0);
				hashAlgorithm.TransformFinalBlock(inputBuffer, 0, 4);
				byte[] hash = hashAlgorithm.Hash;
				hashAlgorithm.Initialize();
				if (array.Length - i > hash.Length)
				{
					Buffer.BlockCopy(hash, 0, array, i, hash.Length);
				}
				else
				{
					Buffer.BlockCopy(hash, 0, array, i, array.Length - i);
				}
			}
			return array;
		}

		// Token: 0x04000C74 RID: 3188
		private string HashNameValue;
	}
}
