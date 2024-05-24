using System;
using ceTe.DynamicPDF.LayoutEngine.Data;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x0200059C RID: 1436
	public abstract class LayoutWriter
	{
		// Token: 0x0600391E RID: 14622
		internal abstract void m3();

		// Token: 0x0600391F RID: 14623
		internal abstract alr nc();

		// Token: 0x06003920 RID: 14624
		internal abstract aie m4();

		// Token: 0x06003921 RID: 14625
		internal abstract aig m5();

		// Token: 0x06003922 RID: 14626
		internal abstract float na();

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06003923 RID: 14627
		public abstract DataProviderStack Data { get; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06003924 RID: 14628
		public abstract Document Document { get; }

		// Token: 0x06003925 RID: 14629
		internal abstract anf m6();

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06003926 RID: 14630
		public abstract DocumentLayout DocumentLayout { get; }

		// Token: 0x06003927 RID: 14631
		internal abstract void m9();

		// Token: 0x06003928 RID: 14632
		internal abstract AlternateRow m7();

		// Token: 0x06003929 RID: 14633
		internal abstract void m8(AlternateRow A_0);

		// Token: 0x0600392A RID: 14634
		internal abstract am5 nb();

		// Token: 0x0600392B RID: 14635 RVA: 0x001EA714 File Offset: 0x001E9714
		internal bool f()
		{
			return this.a;
		}

		// Token: 0x0600392C RID: 14636 RVA: 0x001EA72C File Offset: 0x001E972C
		internal void a(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x04001B37 RID: 6967
		private bool a = false;
	}
}
