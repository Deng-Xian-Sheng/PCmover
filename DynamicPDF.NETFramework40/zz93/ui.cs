using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200030F RID: 783
	internal class ui : rc
	{
		// Token: 0x0600226D RID: 8813 RVA: 0x0014ADAC File Offset: 0x00149DAC
		internal ui(w5 A_0)
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
				throw new DplxParseException("Invalid Less Than Equal function detected.");
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
				throw new DplxParseException("Invalid Less Than Equal function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x0014AE8C File Offset: 0x00149E8C
		internal ui(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x0014AEF4 File Offset: 0x00149EF4
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x0014AF24 File Offset: 0x00149F24
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x0014AF58 File Offset: 0x00149F58
		internal override bool ee(LayoutWriter A_0)
		{
			return decimal.Compare(this.a.ei(A_0), this.b.ei(A_0)) <= 0;
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x0014AF90 File Offset: 0x00149F90
		internal override bool ef(LayoutWriter A_0, vi A_1)
		{
			return decimal.Compare(this.a.ej(A_0, A_1), this.b.ej(A_0, A_1)) <= 0;
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x0014AFC7 File Offset: 0x00149FC7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x0014AFE8 File Offset: 0x00149FE8
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 't' || A_0[A_1 + 1] == 'T') && (A_0[A_1 + 2] == 'e' || A_0[A_1 + 2] == 'E') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x04000EDF RID: 3807
		private new q7 a;

		// Token: 0x04000EE0 RID: 3808
		private new q7 b;
	}
}
