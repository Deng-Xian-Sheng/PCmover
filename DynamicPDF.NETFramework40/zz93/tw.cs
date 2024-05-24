using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002F9 RID: 761
	internal class tw : q8
	{
		// Token: 0x060021BE RID: 8638 RVA: 0x0014749B File Offset: 0x0014649B
		internal tw(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001474B4 File Offset: 0x001464B4
		internal tw(string A_0, bool A_1)
		{
			A_0 = A_0.Trim();
			if (A_1)
			{
				this.b = int.Parse(A_0);
			}
			else
			{
				this.a = A_0;
			}
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x001474F8 File Offset: 0x001464F8
		internal override bool eq(LayoutWriter A_0)
		{
			bool result;
			if (this.a == null)
			{
				result = (A_0.RecordSets.Current[this.b] is DBNull || A_0.RecordSets.Current[this.b] == null);
			}
			else
			{
				result = (A_0.RecordSets.Current[this.a] is DBNull || A_0.RecordSets.Current[this.a] == null);
			}
			return result;
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x00147594 File Offset: 0x00146594
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return A_1.b() == null;
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x001475B0 File Offset: 0x001465B0
		internal override object es(LayoutWriter A_0)
		{
			object result;
			if (this.a == null)
			{
				result = A_0.RecordSets.Current[this.b];
			}
			else
			{
				result = A_0.RecordSets.Current[this.a];
			}
			return result;
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x00147604 File Offset: 0x00146604
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			object result;
			if (A_0.f())
			{
				result = A_1.c();
			}
			else
			{
				result = A_1.b();
			}
			return result;
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x00147634 File Offset: 0x00146634
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			if (this.a == null)
			{
				A_1.a(A_0.RecordSets.Current[this.b]);
			}
			else
			{
				A_1.a(A_0.RecordSets.Current[this.a]);
			}
		}

		// Token: 0x04000EB7 RID: 3767
		private new string a;

		// Token: 0x04000EB8 RID: 3768
		private new int b = -1;
	}
}
