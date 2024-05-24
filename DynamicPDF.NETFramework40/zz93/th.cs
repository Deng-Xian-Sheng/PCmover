using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002EA RID: 746
	internal class th : sy
	{
		// Token: 0x06002151 RID: 8529 RVA: 0x00144E94 File Offset: 0x00143E94
		internal th(w5 A_0)
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
				throw new DplxParseException("Invalid Standard Deviation function detected.");
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

		// Token: 0x06002152 RID: 8530 RVA: 0x00144FB0 File Offset: 0x00143FB0
		internal override s1 fn()
		{
			return new ti(this.a);
		}

		// Token: 0x06002153 RID: 8531 RVA: 0x00144FD0 File Offset: 0x00143FD0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1 + 3] == 'e' || A_0[A_1 + 3] == 'E') && (A_0[A_1 + 4] == 'v' || A_0[A_1 + 4] == 'V') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04000E99 RID: 3737
		private new q7 a;
	}
}
