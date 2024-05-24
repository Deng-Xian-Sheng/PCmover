using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000041 RID: 65
	internal class ba : ac
	{
		// Token: 0x06000265 RID: 613 RVA: 0x0003BEDC File Offset: 0x0003AEDC
		internal BitArray a(char[] A_0)
		{
			if (A_0.Length != 5)
			{
				throw new ap("Invalid supplement value, it may be of 5 digits only.");
			}
			base.c(1);
			base.b(1);
			base.c(2);
			switch (base.c(A_0))
			{
			case 0:
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 1:
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.e(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 2:
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.e(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 3:
				base.e(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.e(A_0[4]);
				break;
			case 4:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				base.b(1);
				base.c(1);
				base.e(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 5:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.e(A_0[2]);
				base.b(1);
				base.c(1);
				base.e(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 6:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.e(A_0[3]);
				base.b(1);
				base.c(1);
				base.e(A_0[4]);
				break;
			case 7:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.e(A_0[3]);
				base.b(1);
				base.c(1);
				base.d(A_0[4]);
				break;
			case 8:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.e(A_0[1]);
				base.b(1);
				base.c(1);
				base.d(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.e(A_0[4]);
				break;
			default:
				base.d(A_0[0]);
				base.b(1);
				base.c(1);
				base.d(A_0[1]);
				base.b(1);
				base.c(1);
				base.e(A_0[2]);
				base.b(1);
				base.c(1);
				base.d(A_0[3]);
				base.b(1);
				base.c(1);
				base.e(A_0[4]);
				break;
			}
			return base.f();
		}
	}
}
