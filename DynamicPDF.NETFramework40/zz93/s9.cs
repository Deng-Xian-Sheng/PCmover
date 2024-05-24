using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002E2 RID: 738
	internal class s9 : sy
	{
		// Token: 0x0600211F RID: 8479 RVA: 0x00142F14 File Offset: 0x00141F14
		internal s9(w5 A_0)
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
				throw new DplxParseException("Invalid Mean function detected.");
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

		// Token: 0x06002120 RID: 8480 RVA: 0x00143030 File Offset: 0x00142030
		internal override s1 fn()
		{
			return new ta(this.a);
		}

		// Token: 0x06002121 RID: 8481 RVA: 0x00143050 File Offset: 0x00142050
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'a' || A_0[A_1 + 2] == 'A') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1] == 'M' || A_0[A_1] == 'm');
		}

		// Token: 0x04000E82 RID: 3714
		private new q7 a;
	}
}
