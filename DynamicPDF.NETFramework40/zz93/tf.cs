using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002E8 RID: 744
	internal class tf : sy
	{
		// Token: 0x06002143 RID: 8515 RVA: 0x0014457C File Offset: 0x0014357C
		internal tf(w5 A_0)
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
				throw new DplxParseException("Invalid Mode function detected.");
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

		// Token: 0x06002144 RID: 8516 RVA: 0x00144674 File Offset: 0x00143674
		internal override s1 fn()
		{
			return new tg(this.a);
		}

		// Token: 0x06002145 RID: 8517 RVA: 0x00144694 File Offset: 0x00143694
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000E93 RID: 3731
		private new q7 a;
	}
}
