using System;
using System.Runtime.Versioning;

namespace System.Collections.Generic
{
	// Token: 0x020004DD RID: 1245
	internal static class IntrospectiveSortUtilities
	{
		// Token: 0x06003B31 RID: 15153 RVA: 0x000E0A50 File Offset: 0x000DEC50
		internal static int FloorLog2(int n)
		{
			int num = 0;
			while (n >= 1)
			{
				num++;
				n /= 2;
			}
			return num;
		}

		// Token: 0x06003B32 RID: 15154 RVA: 0x000E0A6F File Offset: 0x000DEC6F
		internal static void ThrowOrIgnoreBadComparer(object comparer)
		{
			if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_BogusIComparer", new object[]
				{
					comparer
				}));
			}
		}

		// Token: 0x04001959 RID: 6489
		internal const int IntrosortSizeThreshold = 16;

		// Token: 0x0400195A RID: 6490
		internal const int QuickSortDepthThreshold = 32;
	}
}
