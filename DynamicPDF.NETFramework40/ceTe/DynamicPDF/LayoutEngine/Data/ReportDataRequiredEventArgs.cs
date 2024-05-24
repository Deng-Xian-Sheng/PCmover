using System;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x0200093D RID: 2365
	public class ReportDataRequiredEventArgs : EventArgs
	{
		// Token: 0x06006011 RID: 24593 RVA: 0x0035FD04 File Offset: 0x0035ED04
		internal ReportDataRequiredEventArgs(string A_0, string A_1, DataProviderStack A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x06006012 RID: 24594 RVA: 0x0035FD2C File Offset: 0x0035ED2C
		public DataProviderStack Data
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x06006013 RID: 24595 RVA: 0x0035FD44 File Offset: 0x0035ED44
		// (set) Token: 0x06006014 RID: 24596 RVA: 0x0035FD5C File Offset: 0x0035ED5C
		public ReportData ReportData
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06006015 RID: 24597 RVA: 0x0035FD68 File Offset: 0x0035ED68
		public string ElementId
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06006016 RID: 24598 RVA: 0x0035FD80 File Offset: 0x0035ED80
		public string DataName
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003173 RID: 12659
		private string a;

		// Token: 0x04003174 RID: 12660
		private string b;

		// Token: 0x04003175 RID: 12661
		private DataProviderStack c;

		// Token: 0x04003176 RID: 12662
		private ReportData d = null;
	}
}
