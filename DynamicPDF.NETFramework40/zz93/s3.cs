using System;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002DC RID: 732
	internal class s3 : sy
	{
		// Token: 0x060020FE RID: 8446 RVA: 0x00142168 File Offset: 0x00141168
		internal s3(w5 A_0)
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
				throw new DplxParseException("Invalid First function detected.");
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

		// Token: 0x060020FF RID: 8447 RVA: 0x00142260 File Offset: 0x00141260
		internal override s1 fn()
		{
			return new s4(this.a);
		}

		// Token: 0x06002100 RID: 8448 RVA: 0x00142280 File Offset: 0x00141280
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 's' || A_0[A_1 + 3] == 'S') && (A_0[A_1 + 4] == 't' || A_0[A_1 + 4] == 'T') && (A_0[A_1] == 'F' || A_0[A_1] == 'f');
		}

		// Token: 0x04000E72 RID: 3698
		private new q7 a;
	}
}
