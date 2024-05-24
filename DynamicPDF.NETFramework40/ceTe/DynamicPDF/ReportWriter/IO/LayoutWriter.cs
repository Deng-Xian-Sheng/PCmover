using System;
using ceTe.DynamicPDF.ReportWriter.Data;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.IO
{
	// Token: 0x0200029F RID: 671
	public abstract class LayoutWriter
	{
		// Token: 0x06001DE4 RID: 7652 RVA: 0x0012DCB0 File Offset: 0x0012CCB0
		internal LayoutWriter()
		{
		}

		// Token: 0x06001DE5 RID: 7653
		internal abstract void e0();

		// Token: 0x06001DE6 RID: 7654
		internal abstract wu ez();

		// Token: 0x06001DE7 RID: 7655
		internal abstract tl e1();

		// Token: 0x06001DE8 RID: 7656
		internal abstract tm e2();

		// Token: 0x06001DE9 RID: 7657
		internal abstract float e6();

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06001DEA RID: 7658
		public abstract RecordSetStack RecordSets { get; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06001DEB RID: 7659
		public abstract Document Document { get; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06001DEC RID: 7660
		public abstract ParameterDictionary Parameters { get; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06001DED RID: 7661
		public abstract DocumentLayout DocumentLayout { get; }

		// Token: 0x06001DEE RID: 7662
		internal abstract void e3();

		// Token: 0x06001DEF RID: 7663
		internal abstract AlternateRow e4();

		// Token: 0x06001DF0 RID: 7664
		internal abstract void e5(AlternateRow A_0);

		// Token: 0x06001DF1 RID: 7665
		internal abstract xv e7();

		// Token: 0x06001DF2 RID: 7666 RVA: 0x0012DCC4 File Offset: 0x0012CCC4
		internal bool f()
		{
			return this.a;
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x0012DCDC File Offset: 0x0012CCDC
		internal void a(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x04000D45 RID: 3397
		private bool a = false;
	}
}
