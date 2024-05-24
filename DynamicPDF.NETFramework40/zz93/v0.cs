using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000347 RID: 839
	internal class v0 : vv
	{
		// Token: 0x060023D4 RID: 9172 RVA: 0x00153110 File Offset: 0x00152110
		internal v0(string A_0, wd A_1) : base(A_0)
		{
			if (A_1.u() == 648436516)
			{
				this.a = A_1.a1();
				A_1.aa();
				A_1.aa();
				return;
			}
			throw new DplxParseException("A Group By query element contains an invalid attribute.");
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x00153168 File Offset: 0x00152168
		internal vd a()
		{
			return this.a;
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x00153180 File Offset: 0x00152180
		internal override Query f1()
		{
			return new GroupByQuery(this);
		}

		// Token: 0x04000F74 RID: 3956
		private new vd a;
	}
}
