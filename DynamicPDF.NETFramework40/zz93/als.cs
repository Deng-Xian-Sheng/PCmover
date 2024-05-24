using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;

namespace zz93
{
	// Token: 0x0200059D RID: 1437
	internal class als : LayoutWriter
	{
		// Token: 0x0600392E RID: 14638 RVA: 0x001EA746 File Offset: 0x001E9746
		internal als(FixedPage A_0, alr A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x0600392F RID: 14639 RVA: 0x001EA760 File Offset: 0x001E9760
		internal override alr nc()
		{
			return this.b;
		}

		// Token: 0x06003930 RID: 14640 RVA: 0x001EA778 File Offset: 0x001E9778
		internal override void m3()
		{
			amj amj = new amj();
			if (this.a.f() != null)
			{
				this.a.f().a(amj, this);
			}
			ahs ahs = this.a.c();
			if (ahs != null && ahs.b() > 0)
			{
				ahs.b(this);
			}
			amp amp;
			if (this.a.Template == null)
			{
				amp = new amq(this.a, amj);
			}
			else
			{
				amp = new ams(this.a, amj);
			}
			amp.a(true);
			this.Document.Pages.Add(amp);
		}

		// Token: 0x06003931 RID: 14641 RVA: 0x001EA830 File Offset: 0x001E9830
		internal override aie m4()
		{
			return this.b.m4();
		}

		// Token: 0x06003932 RID: 14642 RVA: 0x001EA850 File Offset: 0x001E9850
		internal override aig m5()
		{
			return this.b.m5();
		}

		// Token: 0x06003933 RID: 14643 RVA: 0x001EA870 File Offset: 0x001E9870
		public override DataProviderStack get_Data()
		{
			return this.b.Data;
		}

		// Token: 0x06003934 RID: 14644 RVA: 0x001EA890 File Offset: 0x001E9890
		public override Document get_Document()
		{
			return this.b.Document;
		}

		// Token: 0x06003935 RID: 14645 RVA: 0x001EA8B0 File Offset: 0x001E98B0
		internal override anf m6()
		{
			return this.b.m6();
		}

		// Token: 0x06003936 RID: 14646 RVA: 0x001EA8D0 File Offset: 0x001E98D0
		public override DocumentLayout get_DocumentLayout()
		{
			return this.b.DocumentLayout;
		}

		// Token: 0x06003937 RID: 14647 RVA: 0x001EA8ED File Offset: 0x001E98ED
		internal override void m9()
		{
		}

		// Token: 0x06003938 RID: 14648 RVA: 0x001EA8F0 File Offset: 0x001E98F0
		internal override AlternateRow m7()
		{
			return AlternateRow.Odd;
		}

		// Token: 0x06003939 RID: 14649 RVA: 0x001EA903 File Offset: 0x001E9903
		internal override void m8(AlternateRow A_0)
		{
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x001EA908 File Offset: 0x001E9908
		internal override float na()
		{
			return this.a.d().Body.Width;
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x001EA92F File Offset: 0x001E992F
		internal override am5 nb()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x04001B38 RID: 6968
		private FixedPage a;

		// Token: 0x04001B39 RID: 6969
		private alr b;
	}
}
