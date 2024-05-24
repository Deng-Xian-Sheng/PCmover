using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000304 RID: 772
	internal class t7 : rc
	{
		// Token: 0x06002212 RID: 8722 RVA: 0x00148EC0 File Offset: 0x00147EC0
		internal t7(w5 A_0)
		{
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
			if (A_0.c() != ',')
			{
				throw new DplxParseException("Invalid Equal function detected.");
			}
			A_0.a(A_0.e() + 1);
			A_0.q();
			if (A_0.w())
			{
				this.b = A_0.h();
			}
			else
			{
				this.b = A_0.g();
			}
			A_0.q();
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Equal function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x00148FA0 File Offset: 0x00147FA0
		internal t7(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x00149008 File Offset: 0x00148008
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06002215 RID: 8725 RVA: 0x00149038 File Offset: 0x00148038
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x0014906C File Offset: 0x0014806C
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) == 0;
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001490A0 File Offset: 0x001480A0
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) == 0;
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x001490D4 File Offset: 0x001480D4
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001490F8 File Offset: 0x001480F8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 'q' || A_0[A_1 + 1] == 'Q') && (A_0[A_1] == 'E' || A_0[A_1] == 'e');
		}

		// Token: 0x04000EC8 RID: 3784
		private new q7 a;

		// Token: 0x04000EC9 RID: 3785
		private new q7 b;
	}
}
