using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200029E RID: 670
	internal class rn : LayoutWriter
	{
		// Token: 0x06001DD6 RID: 7638 RVA: 0x0012DA3A File Offset: 0x0012CA3A
		internal rn(FixedPage A_0, wu A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x0012DA54 File Offset: 0x0012CA54
		internal override wu ez()
		{
			return this.b;
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x0012DA6C File Offset: 0x0012CA6C
		internal override void e0()
		{
			RecordSet recordSet;
			if (this.a.e() != null)
			{
				recordSet = this.a.e().e(this);
				this.b.RecordSets.a(recordSet);
				recordSet.Query.e().a(this.b);
			}
			else
			{
				recordSet = null;
			}
			xf xf = new xf();
			if (this.a.g() != null)
			{
				this.a.g().a(xf, this);
			}
			sz sz = this.a.c();
			if (sz != null && sz.b() > 0)
			{
				sz.b(this);
			}
			rs rs;
			if (this.a.Template == null)
			{
				rs = new rt(this.a, xf);
			}
			else
			{
				rs = new rx(this.a, xf);
			}
			rs.a(true);
			this.Document.Pages.Add(rs);
			if (recordSet != null)
			{
				recordSet.eb();
				this.b.RecordSets.a();
			}
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x0012DBA4 File Offset: 0x0012CBA4
		internal override tl e1()
		{
			return this.b.e1();
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x0012DBC4 File Offset: 0x0012CBC4
		internal override tm e2()
		{
			return this.b.e2();
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x0012DBE4 File Offset: 0x0012CBE4
		public override RecordSetStack get_RecordSets()
		{
			return this.b.RecordSets;
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x0012DC04 File Offset: 0x0012CC04
		public override Document get_Document()
		{
			return this.b.Document;
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x0012DC24 File Offset: 0x0012CC24
		public override ParameterDictionary get_Parameters()
		{
			return this.b.Parameters;
		}

		// Token: 0x06001DDE RID: 7646 RVA: 0x0012DC44 File Offset: 0x0012CC44
		public override DocumentLayout get_DocumentLayout()
		{
			return this.b.DocumentLayout;
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x0012DC61 File Offset: 0x0012CC61
		internal override void e3()
		{
		}

		// Token: 0x06001DE0 RID: 7648 RVA: 0x0012DC64 File Offset: 0x0012CC64
		internal override AlternateRow e4()
		{
			return AlternateRow.Odd;
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x0012DC77 File Offset: 0x0012CC77
		internal override void e5(AlternateRow A_0)
		{
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x0012DC7C File Offset: 0x0012CC7C
		internal override float e6()
		{
			return this.a.d().Body.Width;
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x0012DCA3 File Offset: 0x0012CCA3
		internal override xv e7()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x04000D43 RID: 3395
		private FixedPage a;

		// Token: 0x04000D44 RID: 3396
		private wu b;
	}
}
