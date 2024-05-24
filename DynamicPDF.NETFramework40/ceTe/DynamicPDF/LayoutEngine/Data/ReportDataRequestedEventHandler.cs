using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000941 RID: 2369
	// (Invoke) Token: 0x06006031 RID: 24625
	[Obsolete("This delegate is obsolete. Use the ceTe.DynamicPDF.LayoutEngine.DocumentLayout's ReportDataRequired event instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ReportDataRequestedEventHandler(object sender, ReportDataRequestedEventArgs args);
}
