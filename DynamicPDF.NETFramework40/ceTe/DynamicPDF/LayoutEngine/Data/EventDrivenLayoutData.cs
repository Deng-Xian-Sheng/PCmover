using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000940 RID: 2368
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use the ceTe.DynamicPDF.LayoutEngine.DocumentLayout's ReportDataRequired event instead.", false)]
	public class EventDrivenLayoutData : LayoutData
	{
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06006029 RID: 24617 RVA: 0x00360000 File Offset: 0x0035F000
		// (remove) Token: 0x0600602A RID: 24618 RVA: 0x0036003C File Offset: 0x0035F03C
		public event ReportDataRequestedEventHandler ReportDataRequested
		{
			add
			{
				ReportDataRequestedEventHandler reportDataRequestedEventHandler = this.b;
				ReportDataRequestedEventHandler reportDataRequestedEventHandler2;
				do
				{
					reportDataRequestedEventHandler2 = reportDataRequestedEventHandler;
					ReportDataRequestedEventHandler value2 = (ReportDataRequestedEventHandler)Delegate.Combine(reportDataRequestedEventHandler2, value);
					reportDataRequestedEventHandler = Interlocked.CompareExchange<ReportDataRequestedEventHandler>(ref this.b, value2, reportDataRequestedEventHandler2);
				}
				while (reportDataRequestedEventHandler != reportDataRequestedEventHandler2);
			}
			remove
			{
				ReportDataRequestedEventHandler reportDataRequestedEventHandler = this.b;
				ReportDataRequestedEventHandler reportDataRequestedEventHandler2;
				do
				{
					reportDataRequestedEventHandler2 = reportDataRequestedEventHandler;
					ReportDataRequestedEventHandler value2 = (ReportDataRequestedEventHandler)Delegate.Remove(reportDataRequestedEventHandler2, value);
					reportDataRequestedEventHandler = Interlocked.CompareExchange<ReportDataRequestedEventHandler>(ref this.b, value2, reportDataRequestedEventHandler2);
				}
				while (reportDataRequestedEventHandler != reportDataRequestedEventHandler2);
			}
		}

		// Token: 0x17000A43 RID: 2627
		public override object this[string key]
		{
			get
			{
				return this.a[key];
			}
		}

		// Token: 0x0600602D RID: 24621 RVA: 0x003600B0 File Offset: 0x0035F0B0
		internal override bool mq(string A_0)
		{
			return this.a.Contains(A_0);
		}

		// Token: 0x0600602E RID: 24622 RVA: 0x003600CE File Offset: 0x0035F0CE
		public new void Add(string key, object value)
		{
			this.a.Add(key, value);
		}

		// Token: 0x0600602F RID: 24623 RVA: 0x003600E0 File Offset: 0x0035F0E0
		internal override ReportData ms(string A_0, string A_1, LayoutWriter A_2)
		{
			ReportData result;
			if (this.b != null)
			{
				ReportDataRequestedEventArgs reportDataRequestedEventArgs = new ReportDataRequestedEventArgs(A_0, A_1, A_2.Data);
				this.b(this, reportDataRequestedEventArgs);
				result = reportDataRequestedEventArgs.ReportData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0400317F RID: 12671
		private HybridDictionary a = new HybridDictionary(true);

		// Token: 0x04003180 RID: 12672
		private ReportDataRequestedEventHandler b;
	}
}
