using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002E0 RID: 736
	internal class s7 : sy
	{
		// Token: 0x06002114 RID: 8468 RVA: 0x0014297C File Offset: 0x0014197C
		internal s7(w5 A_0)
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
				throw new DplxParseException("Invalid Max function detected.");
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

		// Token: 0x06002115 RID: 8469 RVA: 0x00142A98 File Offset: 0x00141A98
		internal override s1 fn()
		{
			return new s8(this.a);
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x00142AB8 File Offset: 0x00141AB8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 'x' || A_0[A_1 + 2] == 'X') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000E7D RID: 3709
		private new q7 a;
	}
}
