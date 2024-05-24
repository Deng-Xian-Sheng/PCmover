using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000290 RID: 656
	[ComVisible(true)]
	public abstract class SHA1 : HashAlgorithm
	{
		// Token: 0x0600234E RID: 9038 RVA: 0x00080225 File Offset: 0x0007E425
		protected SHA1()
		{
			this.HashSizeValue = 160;
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x00080238 File Offset: 0x0007E438
		public new static SHA1 Create()
		{
			return SHA1.Create("System.Security.Cryptography.SHA1");
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x00080244 File Offset: 0x0007E444
		public new static SHA1 Create(string hashName)
		{
			return (SHA1)CryptoConfig.CreateFromName(hashName);
		}
	}
}
