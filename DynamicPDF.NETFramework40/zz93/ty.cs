using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002FB RID: 763
	internal class ty : ra
	{
		// Token: 0x060021CC RID: 8652 RVA: 0x00147800 File Offset: 0x00146800
		internal ty(w5 A_0)
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
				throw new DplxParseException("Invalid Add function detected.");
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
				throw new DplxParseException("Invalid Add function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x001478E0 File Offset: 0x001468E0
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x00147910 File Offset: 0x00146910
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x00147944 File Offset: 0x00146944
		internal override decimal ei(LayoutWriter A_0)
		{
			return decimal.Add(this.a.ei(A_0), this.b.ei(A_0));
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x00147974 File Offset: 0x00146974
		internal override decimal ej(LayoutWriter A_0, vi A_1)
		{
			return decimal.Add(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1));
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001479A5 File Offset: 0x001469A5
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001479C8 File Offset: 0x001469C8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'd' || A_0[A_1 + 1] == 'D') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x04000EBA RID: 3770
		private new q7 a;

		// Token: 0x04000EBB RID: 3771
		private new q7 b;
	}
}
