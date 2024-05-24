using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000279 RID: 633
	[ComVisible(true)]
	public abstract class RIPEMD160 : HashAlgorithm
	{
		// Token: 0x06002278 RID: 8824 RVA: 0x0007A150 File Offset: 0x00078350
		protected RIPEMD160()
		{
			this.HashSizeValue = 160;
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x0007A163 File Offset: 0x00078363
		public new static RIPEMD160 Create()
		{
			return RIPEMD160.Create("System.Security.Cryptography.RIPEMD160");
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x0007A16F File Offset: 0x0007836F
		public new static RIPEMD160 Create(string hashName)
		{
			return (RIPEMD160)CryptoConfig.CreateFromName(hashName);
		}
	}
}
