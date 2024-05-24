using System;
using System.Collections;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000363 RID: 867
	internal class wr
	{
		// Token: 0x06002529 RID: 9513 RVA: 0x0015CAD1 File Offset: 0x0015BAD1
		private wr()
		{
		}

		// Token: 0x0600252A RID: 9514 RVA: 0x0015CADC File Offset: 0x0015BADC
		internal static DocumentLayout a(DplxWebForm A_0)
		{
			Type baseType = A_0.GetType().BaseType;
			wq wq = (wq)wr.a[baseType];
			if (wq == null)
			{
				string a_ = A_0.Server.MapPath(A_0.Request.ServerVariables["SCRIPT_NAME"]) + ".dplx";
				wq = new wq(a_, baseType);
				wr.a[baseType] = wq;
			}
			return wq.a(A_0);
		}

		// Token: 0x04001048 RID: 4168
		private static Hashtable a = new Hashtable();
	}
}
