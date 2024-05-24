using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000802 RID: 2050
	public class GroupByQuery : Query
	{
		// Token: 0x06005337 RID: 21303 RVA: 0x002912DF File Offset: 0x002902DF
		internal GroupByQuery(v0 A_0) : base(A_0.f())
		{
			this.a = A_0.a();
		}

		// Token: 0x06005338 RID: 21304 RVA: 0x00291314 File Offset: 0x00290314
		protected override RecordSet GetRecordSet(LayoutWriter writer)
		{
			if (base.e() != null)
			{
				for (sz.a a = base.e().a(); a != null; a = a.b)
				{
					writer.RecordSets.Current.Query.e().a(a.a);
				}
				base.a(null);
			}
			return writer.RecordSets.Current;
		}

		// Token: 0x06005339 RID: 21305 RVA: 0x0029138C File Offset: 0x0029038C
		internal vd a()
		{
			return this.a;
		}

		// Token: 0x0600533A RID: 21306 RVA: 0x002913A4 File Offset: 0x002903A4
		internal bool b()
		{
			return this.b;
		}

		// Token: 0x0600533B RID: 21307 RVA: 0x002913BC File Offset: 0x002903BC
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600533C RID: 21308 RVA: 0x002913C8 File Offset: 0x002903C8
		internal bool c()
		{
			return this.c;
		}

		// Token: 0x0600533D RID: 21309 RVA: 0x002913E0 File Offset: 0x002903E0
		internal void b(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x04002C6C RID: 11372
		private new vd a = null;

		// Token: 0x04002C6D RID: 11373
		private bool b = false;

		// Token: 0x04002C6E RID: 11374
		private bool c = false;
	}
}
