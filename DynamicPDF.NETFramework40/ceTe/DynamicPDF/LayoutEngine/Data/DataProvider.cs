using System;
using System.Collections;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000927 RID: 2343
	public abstract class DataProvider
	{
		// Token: 0x17000A20 RID: 2592
		public abstract object this[string dataName]
		{
			get;
		}

		// Token: 0x06005F6B RID: 24427
		internal abstract bool mq(string A_0);

		// Token: 0x06005F6C RID: 24428 RVA: 0x0035D6C8 File Offset: 0x0035C6C8
		internal virtual ReportData ms(string A_0, string A_1, LayoutWriter A_2)
		{
			object obj;
			if (A_1 == null || A_1 == string.Empty || !this.mq(A_1))
			{
				obj = A_2.DocumentLayout.a(A_0, A_1, A_2);
			}
			else
			{
				obj = this[A_1];
			}
			ReportData result;
			if (obj == null)
			{
				result = null;
			}
			else if (obj is ReportData)
			{
				result = (ReportData)obj;
			}
			else if (obj is IEnumerable)
			{
				result = new EnumerableReportData((IEnumerable)obj);
			}
			else
			{
				result = new EnumerableReportData(new object[]
				{
					obj
				});
			}
			return result;
		}
	}
}
