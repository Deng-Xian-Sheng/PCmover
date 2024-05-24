using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000942 RID: 2370
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use the ceTe.DynamicPDF.LayoutEngine.DocumentLayout's ReportDataRequired event instead.", false)]
	public class ReportDataRequestedEventArgs : EventArgs
	{
		// Token: 0x06006034 RID: 24628 RVA: 0x00360126 File Offset: 0x0035F126
		internal ReportDataRequestedEventArgs(string A_0, string A_1, DataProviderStack A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06006035 RID: 24629 RVA: 0x00360150 File Offset: 0x0035F150
		public DataProviderStack DataProviders
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06006036 RID: 24630 RVA: 0x00360168 File Offset: 0x0035F168
		// (set) Token: 0x06006037 RID: 24631 RVA: 0x00360180 File Offset: 0x0035F180
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

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06006038 RID: 24632 RVA: 0x0036018C File Offset: 0x0035F18C
		public string ElementId
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x06006039 RID: 24633 RVA: 0x003601A4 File Offset: 0x0035F1A4
		public string DataName
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003181 RID: 12673
		private string a;

		// Token: 0x04003182 RID: 12674
		private string b;

		// Token: 0x04003183 RID: 12675
		private DataProviderStack c;

		// Token: 0x04003184 RID: 12676
		private ReportData d = null;
	}
}
