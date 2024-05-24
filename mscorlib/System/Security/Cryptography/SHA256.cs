using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000293 RID: 659
	[ComVisible(true)]
	public abstract class SHA256 : HashAlgorithm
	{
		// Token: 0x0600235B RID: 9051 RVA: 0x0008039B File Offset: 0x0007E59B
		protected SHA256()
		{
			this.HashSizeValue = 256;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x000803AE File Offset: 0x0007E5AE
		public new static SHA256 Create()
		{
			return SHA256.Create("System.Security.Cryptography.SHA256");
		}

		// Token: 0x0600235D RID: 9053 RVA: 0x000803BA File Offset: 0x0007E5BA
		public new static SHA256 Create(string hashName)
		{
			return (SHA256)CryptoConfig.CreateFromName(hashName);
		}
	}
}
