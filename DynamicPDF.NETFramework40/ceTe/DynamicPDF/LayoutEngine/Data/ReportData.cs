using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x0200093E RID: 2366
	public abstract class ReportData : DataProvider
	{
		// Token: 0x06006017 RID: 24599 RVA: 0x0035FD98 File Offset: 0x0035ED98
		internal void a(ain A_0)
		{
			if (this.a != null)
			{
				throw new LayoutEngineException("Report data is already associated with a query.");
			}
			this.a = A_0;
		}

		// Token: 0x06006018 RID: 24600
		internal abstract void mn();

		// Token: 0x06006019 RID: 24601
		internal abstract void mo();

		// Token: 0x0600601A RID: 24602
		internal abstract bool mp(LayoutWriter A_0);

		// Token: 0x0600601B RID: 24603 RVA: 0x0035FDC8 File Offset: 0x0035EDC8
		internal ain a()
		{
			return this.a;
		}

		// Token: 0x0600601C RID: 24604 RVA: 0x0035FDE0 File Offset: 0x0035EDE0
		internal virtual void mr()
		{
		}

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x0600601D RID: 24605
		public abstract bool HasData { get; }

		// Token: 0x04003177 RID: 12663
		private ain a;
	}
}
