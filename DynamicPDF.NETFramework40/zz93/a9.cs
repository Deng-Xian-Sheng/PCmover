using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000040 RID: 64
	internal class a9 : ac
	{
		// Token: 0x06000263 RID: 611 RVA: 0x0003BDD0 File Offset: 0x0003ADD0
		internal BitArray a(char[] A_0)
		{
			if (A_0.Length != 2)
			{
				throw new ap("Invalid supplement value, it may be of 2 digits only.");
			}
			base.c(1);
			base.b(1);
			base.c(2);
			switch (((A_0[0] - '0') * '\n' + A_0[1] - '0') % '\u0004')
			{
			case '\0':
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				break;
			case '\u0001':
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				break;
			case '\u0002':
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				break;
			default:
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				break;
			}
			return base.f();
		}
	}
}
