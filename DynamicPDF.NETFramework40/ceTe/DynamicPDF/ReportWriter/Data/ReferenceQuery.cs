using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000808 RID: 2056
	public class ReferenceQuery : Query
	{
		// Token: 0x0600534C RID: 21324 RVA: 0x00291622 File Offset: 0x00290622
		internal ReferenceQuery(wh A_0) : base(A_0.f())
		{
			this.a = A_0.a();
		}

		// Token: 0x0600534D RID: 21325 RVA: 0x00291640 File Offset: 0x00290640
		protected override RecordSet GetRecordSet(LayoutWriter writer)
		{
			RecordSetStack recordSets = writer.RecordSets;
			DataReaderRecordSet dataReaderRecordSet = (DataReaderRecordSet)recordSets.a(0);
			return dataReaderRecordSet.a(this, this.a);
		}

		// Token: 0x04002CB1 RID: 11441
		private new string a;
	}
}
