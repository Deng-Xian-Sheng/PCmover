using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000296 RID: 662
	internal class rf : q8
	{
		// Token: 0x06001DA8 RID: 7592 RVA: 0x0012C764 File Offset: 0x0012B764
		internal rf(w5 A_0)
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
				throw new DplxParseException("Invalid Or function detected.");
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
				throw new DplxParseException("Invalid Or function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x0012C844 File Offset: 0x0012B844
		internal rf(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x0012C8AC File Offset: 0x0012B8AC
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x0012C8DC File Offset: 0x0012B8DC
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001DAC RID: 7596 RVA: 0x0012C910 File Offset: 0x0012B910
		internal override object es(LayoutWriter A_0)
		{
			object obj = this.a.es(A_0);
			object obj2 = this.b.es(A_0);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) | Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) | Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001DAD RID: 7597 RVA: 0x0012C984 File Offset: 0x0012B984
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object obj = this.a.et(A_0, A_1);
			object obj2 = this.b.et(A_0, A_1);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) | Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) | Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x0012C9F7 File Offset: 0x0012B9F7
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x0012CA18 File Offset: 0x0012BA18
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1] == 'O' || A_0[A_1] == 'o') && (A_0[A_1 + 1] == 'r' || A_0[A_1 + 1] == 'R');
		}

		// Token: 0x04000D38 RID: 3384
		private new q7 a;

		// Token: 0x04000D39 RID: 3385
		private new q7 b;
	}
}
