using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000310 RID: 784
	internal class uj : rc
	{
		// Token: 0x06002275 RID: 8821 RVA: 0x0014B038 File Offset: 0x0014A038
		internal uj(w5 A_0)
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
				throw new DplxParseException("Invalid Less Than function detected.");
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
				throw new DplxParseException("Invalid Less Than function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x0014B118 File Offset: 0x0014A118
		internal uj(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x0014B180 File Offset: 0x0014A180
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x0014B1B0 File Offset: 0x0014A1B0
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x0014B1E4 File Offset: 0x0014A1E4
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) < 0;
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x0014B218 File Offset: 0x0014A218
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) < 0;
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x0014B24C File Offset: 0x0014A24C
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x0014B270 File Offset: 0x0014A270
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04000EE1 RID: 3809
		private new q7 a;

		// Token: 0x04000EE2 RID: 3810
		private new q7 b;
	}
}
