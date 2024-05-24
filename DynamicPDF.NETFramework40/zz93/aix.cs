using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000531 RID: 1329
	internal class aix : ait
	{
		// Token: 0x0600359B RID: 13723 RVA: 0x001D574C File Offset: 0x001D474C
		internal aix(al5 A_0)
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
				throw new DlexParseException("Invalid And function detected.");
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
				throw new DlexParseException("Invalid And function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x0600359C RID: 13724 RVA: 0x001D582C File Offset: 0x001D482C
		internal aix(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x0600359D RID: 13725 RVA: 0x001D5894 File Offset: 0x001D4894
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x0600359E RID: 13726 RVA: 0x001D58C4 File Offset: 0x001D48C4
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x0600359F RID: 13727 RVA: 0x001D58F8 File Offset: 0x001D48F8
		internal override object ma(LayoutWriter A_0)
		{
			object obj = this.a.ma(A_0);
			object obj2 = this.b.ma(A_0);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) & Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) & Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x060035A0 RID: 13728 RVA: 0x001D596C File Offset: 0x001D496C
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object obj = this.a.l2(A_0, A_1);
			object obj2 = this.b.l2(A_0, A_1);
			object result;
			if (obj is bool && obj2 is bool)
			{
				result = (Convert.ToBoolean(obj) & Convert.ToBoolean(obj2));
			}
			else
			{
				result = (Convert.ToInt64(obj) & Convert.ToInt64(obj2));
			}
			return result;
		}

		// Token: 0x060035A1 RID: 13729 RVA: 0x001D59DF File Offset: 0x001D49DF
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x060035A2 RID: 13730 RVA: 0x001D5A00 File Offset: 0x001D4A00
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'n' || A_0[A_1 + 1] == 'N') && (A_0[A_1 + 2] == 'd' || A_0[A_1 + 2] == 'D') && (A_0[A_1] == 'A' || A_0[A_1] == 'a');
		}

		// Token: 0x040019AD RID: 6573
		private new ahq a;

		// Token: 0x040019AE RID: 6574
		private new ahq b;
	}
}
