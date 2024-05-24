using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x0200030A RID: 778
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongNamePublicKeyBlob
	{
		// Token: 0x06002765 RID: 10085 RVA: 0x0008F4A2 File Offset: 0x0008D6A2
		internal StrongNamePublicKeyBlob()
		{
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x0008F4AA File Offset: 0x0008D6AA
		public StrongNamePublicKeyBlob(byte[] publicKey)
		{
			if (publicKey == null)
			{
				throw new ArgumentNullException("PublicKey");
			}
			this.PublicKey = new byte[publicKey.Length];
			Array.Copy(publicKey, 0, this.PublicKey, 0, publicKey.Length);
		}

		// Token: 0x06002767 RID: 10087 RVA: 0x0008F4DF File Offset: 0x0008D6DF
		internal StrongNamePublicKeyBlob(string publicKey)
		{
			this.PublicKey = Hex.DecodeHexString(publicKey);
		}

		// Token: 0x06002768 RID: 10088 RVA: 0x0008F4F4 File Offset: 0x0008D6F4
		private static bool CompareArrays(byte[] first, byte[] second)
		{
			if (first.Length != second.Length)
			{
				return false;
			}
			int num = first.Length;
			for (int i = 0; i < num; i++)
			{
				if (first[i] != second[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002769 RID: 10089 RVA: 0x0008F526 File Offset: 0x0008D726
		internal bool Equals(StrongNamePublicKeyBlob blob)
		{
			return blob != null && StrongNamePublicKeyBlob.CompareArrays(this.PublicKey, blob.PublicKey);
		}

		// Token: 0x0600276A RID: 10090 RVA: 0x0008F53E File Offset: 0x0008D73E
		public override bool Equals(object obj)
		{
			return obj != null && obj is StrongNamePublicKeyBlob && this.Equals((StrongNamePublicKeyBlob)obj);
		}

		// Token: 0x0600276B RID: 10091 RVA: 0x0008F55C File Offset: 0x0008D75C
		private static int GetByteArrayHashCode(byte[] baData)
		{
			if (baData == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < baData.Length; i++)
			{
				num = (num << 8 ^ (int)baData[i] ^ num >> 24);
			}
			return num;
		}

		// Token: 0x0600276C RID: 10092 RVA: 0x0008F58C File Offset: 0x0008D78C
		public override int GetHashCode()
		{
			return StrongNamePublicKeyBlob.GetByteArrayHashCode(this.PublicKey);
		}

		// Token: 0x0600276D RID: 10093 RVA: 0x0008F599 File Offset: 0x0008D799
		public override string ToString()
		{
			return Hex.EncodeHexString(this.PublicKey);
		}

		// Token: 0x04000F42 RID: 3906
		internal byte[] PublicKey;
	}
}
