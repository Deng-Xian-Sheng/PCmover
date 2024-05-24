using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000543 RID: 1347
	internal class ajf : ail
	{
		// Token: 0x0600362F RID: 13871 RVA: 0x001D8AAC File Offset: 0x001D7AAC
		internal ajf(al5 A_0)
		{
			A_0.a(A_0.d() + 1);
			A_0.p();
			this.a = A_0.f();
			A_0.p();
			if (A_0.b() != ',')
			{
				throw new DlexParseException("Invalid Left function detected.");
			}
			A_0.a(A_0.d() + 1);
			this.b = A_0.l();
			if (A_0.b() != ')')
			{
				throw new DlexParseException("Invalid Left function detected.");
			}
			A_0.a(A_0.d() + 1);
		}

		// Token: 0x06003630 RID: 13872 RVA: 0x001D8B48 File Offset: 0x001D7B48
		internal override bool l4(LayoutWriter A_0)
		{
			return this.a.l4(A_0);
		}

		// Token: 0x06003631 RID: 13873 RVA: 0x001D8B68 File Offset: 0x001D7B68
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return this.a.lw(A_0, A_1);
		}

		// Token: 0x06003632 RID: 13874 RVA: 0x001D8B88 File Offset: 0x001D7B88
		internal override string mb(LayoutWriter A_0)
		{
			string text = this.a.mb(A_0);
			string result;
			if (text.Length <= this.b)
			{
				result = text;
			}
			else
			{
				result = text.Substring(0, this.b);
			}
			return result;
		}

		// Token: 0x06003633 RID: 13875 RVA: 0x001D8BCC File Offset: 0x001D7BCC
		internal override string l3(LayoutWriter A_0, akk A_1)
		{
			string text = this.a.l3(A_0, A_1);
			string result;
			if (text.Length <= this.b)
			{
				result = text;
			}
			else
			{
				result = text.Substring(0, this.b);
			}
			return result;
		}

		// Token: 0x06003634 RID: 13876 RVA: 0x001D8C0F File Offset: 0x001D7C0F
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			this.a.mc(A_0, A_1, A_2);
		}

		// Token: 0x06003635 RID: 13877 RVA: 0x001D8C24 File Offset: 0x001D7C24
		internal static bool a(char[] A_0, int A_1, int A_2)
		{
			return A_2 == 4 && (A_0[A_1 + 1] == 'e' || A_0[A_1 + 1] == 'E') && (A_0[A_1 + 2] == 'f' || A_0[A_1 + 2] == 'F') && (A_0[A_1 + 3] == 't' || A_0[A_1 + 3] == 'T') && (A_0[A_1] == 'L' || A_0[A_1] == 'l');
		}

		// Token: 0x040019CF RID: 6607
		private new ahq a;

		// Token: 0x040019D0 RID: 6608
		private new int b;
	}
}
