using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000563 RID: 1379
	internal class akb : ait
	{
		// Token: 0x06003712 RID: 14098 RVA: 0x001DD698 File Offset: 0x001DC698
		internal akb(al5 A_0)
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
				throw new DlexParseException("Invalid Xor function detected.");
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
				throw new DlexParseException("Invalid Xor function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003713 RID: 14099 RVA: 0x001DD778 File Offset: 0x001DC778
		internal akb(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003714 RID: 14100 RVA: 0x001DD7E0 File Offset: 0x001DC7E0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003715 RID: 14101 RVA: 0x001DD810 File Offset: 0x001DC810
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003716 RID: 14102 RVA: 0x001DD844 File Offset: 0x001DC844
		internal override object ma(LayoutWriter A_0)
		{
			object obj = this.a.ma(A_0);
			object obj2 = this.b.ma(A_0);
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

		// Token: 0x06003717 RID: 14103 RVA: 0x001DD8B8 File Offset: 0x001DC8B8
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object obj = this.a.l2(A_0, A_1);
			object obj2 = this.b.l2(A_0, A_1);
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

		// Token: 0x06003718 RID: 14104 RVA: 0x001DD92B File Offset: 0x001DC92B
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x001DD94C File Offset: 0x001DC94C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 3 && (A_0[A_1 + 1] == 'o' || A_0[A_1 + 1] == 'O') && (A_0[A_1 + 2] == 'r' || A_0[A_1 + 2] == 'R') && (A_0[A_1] == 'X' || A_0[A_1] == 'x');
		}

		// Token: 0x04001A0F RID: 6671
		private new ahq a;

		// Token: 0x04001A10 RID: 6672
		private new ahq b;
	}
}
