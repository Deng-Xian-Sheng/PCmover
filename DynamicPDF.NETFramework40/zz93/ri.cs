using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000299 RID: 665
	internal class ri : q8
	{
		// Token: 0x06001DBE RID: 7614 RVA: 0x0012CDF8 File Offset: 0x0012BDF8
		internal ri(w5 A_0)
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
				throw new DplxParseException("Invalid Xor function detected.");
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
				throw new DplxParseException("Invalid Xor function detected.");
			}
			A_0.a(A_0.e() + 1);
		}

		// Token: 0x06001DBF RID: 7615 RVA: 0x0012CED8 File Offset: 0x0012BED8
		internal ri(ArrayList A_0)
		{
			this.b = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (q7)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x0012CF40 File Offset: 0x0012BF40
		internal override bool eq(LayoutWriter A_0)
		{
			return this.a.eq(A_0) || this.b.eq(A_0);
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x0012CF70 File Offset: 0x0012BF70
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return this.a.er(A_0, A_1) || this.b.er(A_0, A_1);
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x0012CFA4 File Offset: 0x0012BFA4
		internal override object es(LayoutWriter A_0)
		{
			object obj = this.a.es(A_0);
			object obj2 = this.b.es(A_0);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) ^ Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) ^ Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x0012D018 File Offset: 0x0012C018
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object obj = this.a.et(A_0, A_1);
			object obj2 = this.b.et(A_0, A_1);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) ^ Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) ^ Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x0012D08B File Offset: 0x0012C08B
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			this.a.eu(A_0, A_1, A_2);
			this.b.eu(A_0, A_1, A_2);
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x0012D0AC File Offset: 0x0012C0AC
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1] == 'X' || A_0[A_1] == 'x');
		}

		// Token: 0x04000D3D RID: 3389
		private new q7 a;

		// Token: 0x04000D3E RID: 3390
		private new q7 b;
	}
}
