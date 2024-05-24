using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000270 RID: 624
	[ComVisible(true)]
	public abstract class MD5 : HashAlgorithm
	{
		// Token: 0x06002224 RID: 8740 RVA: 0x00078BB5 File Offset: 0x00076DB5
		protected MD5()
		{
			this.HashSizeValue = 128;
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x00078BC8 File Offset: 0x00076DC8
		public new static MD5 Create()
		{
			return MD5.Create("System.Security.Cryptography.MD5");
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x00078BD4 File Offset: 0x00076DD4
		public new static MD5 Create(string algName)
		{
			return (MD5)CryptoConfig.CreateFromName(algName);
		}
	}
}
