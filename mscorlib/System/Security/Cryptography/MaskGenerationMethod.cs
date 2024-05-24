using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000272 RID: 626
	[ComVisible(true)]
	public abstract class MaskGenerationMethod
	{
		// Token: 0x0600222C RID: 8748
		[ComVisible(true)]
		public abstract byte[] GenerateMask(byte[] rgbSeed, int cbReturn);
	}
}
