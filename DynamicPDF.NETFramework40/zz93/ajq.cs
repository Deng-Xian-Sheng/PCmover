using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200054E RID: 1358
	internal class ajq : ait
	{
		// Token: 0x06003683 RID: 13955 RVA: 0x001DA188 File Offset: 0x001D9188
		internal ajq(al5 A_0)
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
				throw new DlexParseException("Invalid Or function detected.");
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
				throw new DlexParseException("Invalid Or function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x001DA268 File Offset: 0x001D9268
		internal ajq(ArrayList A_0)
		{
			this.b = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			this.a = (ahq)A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x001DA2D0 File Offset: 0x001D92D0
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0) || this.b.l4(A_0);
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x001DA300 File Offset: 0x001D9300
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1) || this.b.lw(A_0, A_1);
		}

		// Token: 0x06003687 RID: 13959 RVA: 0x001DA334 File Offset: 0x001D9334
		internal override object ma(LayoutWriter A_0)
		{
			object obj = this.a.ma(A_0);
			object obj2 = this.b.ma(A_0);
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

		// Token: 0x06003688 RID: 13960 RVA: 0x001DA3A8 File Offset: 0x001D93A8
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object obj = this.a.l2(A_0, A_1);
			object obj2 = this.b.l2(A_0, A_1);
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

		// Token: 0x06003689 RID: 13961 RVA: 0x001DA41B File Offset: 0x001D941B
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
			this.b.mc(A_0, A_1, A_2);
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x001DA43C File Offset: 0x001D943C
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 2 && (A_0[A_1] == 'O' || A_0[A_1] == 'o') && (A_0[A_1 + 1] == 'r' || A_0[A_1 + 1] == 'R');
		}

		// Token: 0x040019E0 RID: 6624
		private new ahq a;

		// Token: 0x040019E1 RID: 6625
		private new ahq b;
	}
}
