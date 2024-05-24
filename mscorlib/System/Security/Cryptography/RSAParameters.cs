using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200027B RID: 635
	[ComVisible(true)]
	[Serializable]
	public struct RSAParameters
	{
		// Token: 0x04000C89 RID: 3209
		public byte[] Exponent;

		// Token: 0x04000C8A RID: 3210
		public byte[] Modulus;

		// Token: 0x04000C8B RID: 3211
		[NonSerialized]
		public byte[] P;

		// Token: 0x04000C8C RID: 3212
		[NonSerialized]
		public byte[] Q;

		// Token: 0x04000C8D RID: 3213
		[NonSerialized]
		public byte[] DP;

		// Token: 0x04000C8E RID: 3214
		[NonSerialized]
		public byte[] DQ;

		// Token: 0x04000C8F RID: 3215
		[NonSerialized]
		public byte[] InverseQ;

		// Token: 0x04000C90 RID: 3216
		[NonSerialized]
		public byte[] D;
	}
}
