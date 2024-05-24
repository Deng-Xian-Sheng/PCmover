using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002DE RID: 734
	internal class s5 : sy
	{
		// Token: 0x06002109 RID: 8457 RVA: 0x001425A4 File Offset: 0x001415A4
		internal s5(w5 A_0)
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
				throw new DplxParseException("Invalid Last function detected.");
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

		// Token: 0x0600210A RID: 8458 RVA: 0x0014269C File Offset: 0x0014169C
		internal override s1 fn()
		{
			return new s6(this.a);
		}

		// Token: 0x0600210B RID: 8459 RVA: 0x001426BC File Offset: 0x001416BC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'a' || A_0[A_1 + 1] == 'A') && (A_0[A_1 + 2] == 's' || A_0[A_1 + 2] == 'S') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04000E78 RID: 3704
		private new q7 a;
	}
}
