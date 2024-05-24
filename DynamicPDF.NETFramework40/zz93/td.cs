using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002E6 RID: 742
	internal class td : sy
	{
		// Token: 0x06002138 RID: 8504 RVA: 0x00143FE4 File Offset: 0x00142FE4
		internal td(w5 A_0)
		{
			A_0.a(false);
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.c() == '*')
			{
				this.a = null;
				A_0.o();
			}
			else if (A_0.w())
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
				throw new DplxParseException("Invalid Min function detected.");
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

		// Token: 0x06002139 RID: 8505 RVA: 0x00144100 File Offset: 0x00143100
		internal override s1 fn()
		{
			return new te(this.a);
		}

		// Token: 0x0600213A RID: 8506 RVA: 0x00144120 File Offset: 0x00143120
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'n' || A_0[A_1 + 2] == 'N') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000E8E RID: 3726
		private new q7 a;
	}
}
