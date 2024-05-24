using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200026D RID: 621
	[ComVisible(true)]
	public abstract class KeyedHashAlgorithm : HashAlgorithm
	{
		// Token: 0x06002207 RID: 8711 RVA: 0x00078630 File Offset: 0x00076830
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.KeyValue != null)
				{
					Array.Clear(this.KeyValue, 0, this.KeyValue.Length);
				}
				this.KeyValue = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06002208 RID: 8712 RVA: 0x0007865F File Offset: 0x0007685F
		// (set) Token: 0x06002209 RID: 8713 RVA: 0x00078671 File Offset: 0x00076871
		public virtual byte[] Key
		{
			get
			{
				return (byte[])this.KeyValue.Clone();
			}
			set
			{
				if (this.State != 0)
				{
					throw new CryptographicException(Environment.GetResourceString("Cryptography_HashKeySet"));
				}
				this.KeyValue = (byte[])value.Clone();
			}
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x0007869C File Offset: 0x0007689C
		public new static KeyedHashAlgorithm Create()
		{
			return KeyedHashAlgorithm.Create("System.Security.Cryptography.KeyedHashAlgorithm");
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x000786A8 File Offset: 0x000768A8
		public new static KeyedHashAlgorithm Create(string algName)
		{
			return (KeyedHashAlgorithm)CryptoConfig.CreateFromName(algName);
		}

		// Token: 0x04000C5A RID: 3162
		protected byte[] KeyValue;
	}
}
