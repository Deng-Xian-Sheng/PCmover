using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002D9 RID: 729
	internal class s0 : sy
	{
		// Token: 0x060020DD RID: 8413 RVA: 0x001419F0 File Offset: 0x001409F0
		internal s0(w5 A_0)
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

		// Token: 0x060020DE RID: 8414 RVA: 0x00141B0C File Offset: 0x00140B0C
		internal override s1 fn()
		{
			return new s2(this.a);
		}

		// Token: 0x060020DF RID: 8415 RVA: 0x00141B2C File Offset: 0x00140B2C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'u' || A_0[A_1 + 2] == 'U') && (A_0[A_1 + 3] == 'n' || A_0[A_1 + 3] == 'N') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'C' || A_0[A_1] == 'c');
		}

		// Token: 0x04000E68 RID: 3688
		private new q7 a;
	}
}
