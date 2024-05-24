using System;

namespace System.Numerics.Hashing
{
	// Token: 0x02000388 RID: 904
	internal static class HashHelpers
	{
		// Token: 0x06002CD5 RID: 11477 RVA: 0x000A9114 File Offset: 0x000A7314
		public static int Combine(int h1, int h2)
		{
			uint num = (uint)(h1 << 5 | (int)((uint)h1 >> 27));
			return (int)(num + (uint)h1 ^ (uint)h2);
		}
	}
}
