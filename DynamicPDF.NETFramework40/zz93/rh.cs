using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000298 RID: 664
	internal class rh : q8
	{
		// Token: 0x06001DB6 RID: 7606 RVA: 0x0012CC20 File Offset: 0x0012BC20
		internal rh(w5 A_0)
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
			if (A_0.c() != ')')
			{
				throw new DplxParseException("Invalid Tilde function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x0012CCA2 File Offset: 0x0012BCA2
		internal rh(ArrayList A_0)
		{
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x0012CCD8 File Offset: 0x0012BCD8
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0);
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x0012CCF8 File Offset: 0x0012BCF8
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1);
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x0012CD18 File Offset: 0x0012BD18
		internal override object es(LayoutWriter A_0)
		{
			object value = this.a.es(A_0);
			return ~Convert.ToInt64(value);
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0012CD44 File Offset: 0x0012BD44
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object value = this.a.et(A_0, A_1);
			return ~Convert.ToInt64(value);
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0012CD70 File Offset: 0x0012BD70
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x0012CD84 File Offset: 0x0012BD84
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 5 && (A_0[A_1 + 2] == 'l' || A_0[A_1 + 2] == 'L') && (A_0[A_1 + 1] == 'i' || A_0[A_1 + 1] == 'I') && (A_0[A_1 + 3] == 'd' || A_0[A_1 + 3] == 'D') && (A_0[A_1 + 4] == 'e' || A_0[A_1 + 4] == 'E') && (A_0[A_1] == 'T' || A_0[A_1] == 't');
		}

		// Token: 0x04000D3C RID: 3388
		private new q7 a;
	}
}
