using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002EC RID: 748
	internal class tj : sy
	{
		// Token: 0x0600215F RID: 8543 RVA: 0x00145678 File Offset: 0x00144678
		internal tj(w5 A_0)
		{
			A_0.a(false);
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.a = A_0.h();
			}
			else
			{
				this.a = A_0.g();
			}
			A_0.q();
			base.a(A_0);
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Format function detected.");
			}
			A_0.a(A_0.e() + 1);
			if (A_0.y())
			{
				A_0.f().a(this);
			}
			else if (base.b() != "CurrentPage" && base.b() != "PreviousPage")
			{
				A_0.f().a(this);
			}
			A_0.a(true);
		}

		// Token: 0x06002160 RID: 8544 RVA: 0x00145770 File Offset: 0x00144770
		internal override s1 fn()
		{
			return new tk(this.a);
		}

		// Token: 0x06002161 RID: 8545 RVA: 0x00145790 File Offset: 0x00144790
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'm' || A_0[A_1 + 2] == 'M') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000E9F RID: 3743
		private new q7 a;
	}
}
