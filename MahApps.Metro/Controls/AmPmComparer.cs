using System;
using System.Collections.Generic;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000041 RID: 65
	internal class AmPmComparer : IComparer<int>
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x0000BF62 File Offset: 0x0000A162
		public int Compare(int x, int y)
		{
			if (x == 12 && y == 12)
			{
				return 0;
			}
			if (x == 12)
			{
				return -1;
			}
			if (y == 12)
			{
				return 1;
			}
			return x.CompareTo(y);
		}
	}
}
