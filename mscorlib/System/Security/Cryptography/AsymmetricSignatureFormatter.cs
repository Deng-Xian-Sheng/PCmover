using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200024D RID: 589
	[ComVisible(true)]
	public abstract class AsymmetricSignatureFormatter
	{
		// Token: 0x060020EE RID: 8430
		public abstract void SetKey(AsymmetricAlgorithm key);

		// Token: 0x060020EF RID: 8431
		public abstract void SetHashAlgorithm(string strName);

		// Token: 0x060020F0 RID: 8432 RVA: 0x00072CEA File Offset: 0x00070EEA
		public virtual byte[] CreateSignature(HashAlgorithm hash)
		{
			if (hash == null)
			{
				throw new ArgumentNullException("hash");
			}
			this.SetHashAlgorithm(hash.ToString());
			return this.CreateSignature(hash.Hash);
		}

		// Token: 0x060020F1 RID: 8433
		public abstract byte[] CreateSignature(byte[] rgbHash);
	}
}
