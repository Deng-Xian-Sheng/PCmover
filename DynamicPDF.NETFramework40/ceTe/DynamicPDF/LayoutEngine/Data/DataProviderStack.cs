using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000943 RID: 2371
	public class DataProviderStack
	{
		// Token: 0x0600603A RID: 24634 RVA: 0x003601BC File Offset: 0x0035F1BC
		internal DataProviderStack(DocumentLayout A_0, LayoutData A_1)
		{
			this.a = A_0;
			this.b = (this.c = new aio(A_1));
		}

		// Token: 0x0600603B RID: 24635 RVA: 0x003601F0 File Offset: 0x0035F1F0
		internal DataProvider a()
		{
			return this.b.a();
		}

		// Token: 0x0600603C RID: 24636 RVA: 0x00360210 File Offset: 0x0035F210
		internal DataProvider b()
		{
			return this.c.a();
		}

		// Token: 0x17000A48 RID: 2632
		public object this[string dataName]
		{
			get
			{
				return this.a(dataName);
			}
		}

		// Token: 0x0600603E RID: 24638 RVA: 0x0036024C File Offset: 0x0035F24C
		internal object a(string A_0)
		{
			if (!this.c.a().mq(A_0))
			{
				for (aio aio = this.c.c(); aio != null; aio = aio.c())
				{
					if (aio.a().mq(A_0))
					{
						return aio.a()[A_0];
					}
				}
				throw new LayoutEngineException("Layout data for " + A_0 + " could not be retrieved because data by that name doesn't exist.");
			}
			return this.c.a()[A_0];
		}

		// Token: 0x0600603F RID: 24639 RVA: 0x003602E4 File Offset: 0x0035F2E4
		internal ReportData c()
		{
			return this.c.b();
		}

		// Token: 0x06006040 RID: 24640 RVA: 0x00360304 File Offset: 0x0035F304
		internal void a(string A_0, string A_1, LayoutWriter A_2)
		{
			ReportData reportData = this.c.a().ms(A_0, A_1, A_2);
			if (reportData != null)
			{
				reportData.a(this.a.a(A_0));
				aio aio = new aio(reportData, this.c);
				this.c = aio;
			}
		}

		// Token: 0x06006041 RID: 24641 RVA: 0x0036035C File Offset: 0x0035F35C
		internal void d()
		{
			if (this.c() != null)
			{
				this.c().mr();
			}
			this.c = this.c.c();
		}

		// Token: 0x04003185 RID: 12677
		private DocumentLayout a;

		// Token: 0x04003186 RID: 12678
		private aio b;

		// Token: 0x04003187 RID: 12679
		private aio c;
	}
}
