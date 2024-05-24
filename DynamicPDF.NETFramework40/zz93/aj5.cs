using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200055D RID: 1373
	internal class aj5 : aij
	{
		// Token: 0x060036E6 RID: 14054 RVA: 0x001DCA70 File Offset: 0x001DBA70
		internal aj5(al5 A_0)
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
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Subtract function detected.");
			}
			A_0.a(A_0.d() + 1);
			A_0.p();
			if (A_0.v())
			{
				this.b = A_0.g();
			}
			else
			{
				this.b = A_0.f();
			}
			A_0.p();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Subtract function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x060036E7 RID: 14055 RVA: 0x001DCB50 File Offset: 0x001DBB50
		internal aj5(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x001DCBB8 File Offset: 0x001DBBB8
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x060036E9 RID: 14057 RVA: 0x001DCBE8 File Offset: 0x001DBBE8
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x060036EA RID: 14058 RVA: 0x001DCC1C File Offset: 0x001DBC1C
		internal override decimal l7(LayoutWriter A_0)
		{
			return decimal.Subtract(this.a.l7(A_0), this.b.l7(A_0));
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x001DCC4C File Offset: 0x001DBC4C
		internal override decimal lz(LayoutWriter A_0, akk A_1)
		{
			return decimal.Subtract(this.a.lz(A_0, A_1), this.b.lz(A_0, A_1));
		}

		// Token: 0x060036EC RID: 14060 RVA: 0x001DCC7D File Offset: 0x001DBC7D
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x060036ED RID: 14061 RVA: 0x001DCCA0 File Offset: 0x001DBCA0
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 8 && (A_0[A_1 + 4] == 'r' || A_0[A_1 + 4] == 'R') && (A_0[A_1 + 5] == 'a' || A_0[A_1 + 5] == 'A') && (A_0[A_1 + 6] == 'c' || A_0[A_1 + 6] == 'C') && (A_0[A_1 + 7] == 't' || A_0[A_1 + 7] == 'T') && (A_0[A_1] == 'S' || A_0[A_1] == 's') && (A_0[A_1 + 1] == 'u' || A_0[A_1 + 1] == 'U') && (A_0[A_1 + 2] == 'b' || A_0[A_1 + 2] == 'B') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T');
		}

		// Token: 0x04001A08 RID: 6664
		private new ahq a;

		// Token: 0x04001A09 RID: 6665
		private new ahq b;
	}
}
