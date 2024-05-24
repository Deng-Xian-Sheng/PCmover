using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000297 RID: 663
	[ComVisible(true)]
	public abstract class SHA512 : HashAlgorithm
	{
		// Token: 0x0600236B RID: 9067 RVA: 0x00080511 File Offset: 0x0007E711
		protected SHA512()
		{
			this.HashSizeValue = 512;
		}

		// Token: 0x0600236C RID: 9068 RVA: 0x00080524 File Offset: 0x0007E724
		public new static SHA512 Create()
		{
			return SHA512.Create("System.Security.Cryptography.SHA512");
		}

		// Token: 0x0600236D RID: 9069 RVA: 0x00080530 File Offset: 0x0007E730
		public new static SHA512 Create(string hashName)
		{
			return (SHA512)CryptoConfig.CreateFromName(hashName);
		}
	}
}
