using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000559 RID: 1369
	internal class aj1 : aiq
	{
		// Token: 0x060036CA RID: 14026 RVA: 0x001DC1F8 File Offset: 0x001DB1F8
		internal aj1(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.a = A_0.g();
			}
			else
			{
				this.a = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Square Root function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036CB RID: 14027 RVA: 0x001DC27C File Offset: 0x001DB27C
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x060036CC RID: 14028 RVA: 0x001DC29C File Offset: 0x001DB29C
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x001DC2BC File Offset: 0x001DB2BC
		internal override double l8(LayoutWriter A_0)
		{
			return Math.Sqrt(this.a.l8(A_0));
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x001DC2E0 File Offset: 0x001DB2E0
		internal override double l0(LayoutWriter A_0, akk A_1)
		{
			return Math.Sqrt(this.a.l0(A_0, A_1));
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x001DC304 File Offset: 0x001DB304
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036D0 RID: 14032 RVA: 0x001DC318 File Offset: 0x001DB318
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'q' || A_0[A_1 + 1] == 'Q') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'S' || A_0[A_1] == 's');
		}

		// Token: 0x04001A01 RID: 6657
		private new ahq a;
	}
}
