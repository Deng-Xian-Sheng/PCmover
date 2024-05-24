using System;

namespace zz93
{
	// Token: 0x02000527 RID: 1319
	internal sealed class ain
	{
		// Token: 0x06003545 RID: 13637 RVA: 0x001D44F7 File Offset: 0x001D34F7
		internal ain(string A_0)
		{
			this.a = A_0 + "^ForQuery";
		}

		// Token: 0x06003546 RID: 13638 RVA: 0x001D451C File Offset: 0x001D351C
		internal bool a()
		{
			return this.b != null && this.b.b() >= 1;
		}

		// Token: 0x06003547 RID: 13639 RVA: 0x001D454C File Offset: 0x001D354C
		internal ahs b()
		{
			if (this.b == null)
			{
				this.b = new ahs();
			}
			return this.b;
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x001D4581 File Offset: 0x001D3581
		internal void a(ahs A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003549 RID: 13641 RVA: 0x001D458C File Offset: 0x001D358C
		internal string c()
		{
			return this.a.Replace("^ForQuery", "");
		}

		// Token: 0x0600354A RID: 13642 RVA: 0x001D45B4 File Offset: 0x001D35B4
		internal string d()
		{
			return this.a;
		}

		// Token: 0x0400199E RID: 6558
		private string a;

		// Token: 0x0400199F RID: 6559
		private ahs b = null;
	}
}
