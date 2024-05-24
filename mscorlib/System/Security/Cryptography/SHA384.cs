using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000295 RID: 661
	[ComVisible(true)]
	public abstract class SHA384 : HashAlgorithm
	{
		// Token: 0x06002363 RID: 9059 RVA: 0x00080456 File Offset: 0x0007E656
		protected SHA384()
		{
			this.HashSizeValue = 384;
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x00080469 File Offset: 0x0007E669
		public new static SHA384 Create()
		{
			return SHA384.Create("System.Security.Cryptography.SHA384");
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x00080475 File Offset: 0x0007E675
		public new static SHA384 Create(string hashName)
		{
			return (SHA384)CryptoConfig.CreateFromName(hashName);
		}
	}
}
