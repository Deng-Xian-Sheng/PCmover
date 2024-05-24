using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000358 RID: 856
	internal class wh : vv
	{
		// Token: 0x060024D9 RID: 9433 RVA: 0x0015B318 File Offset: 0x0015A318
		internal wh(string A_0, wd A_1) : base(A_0)
		{
			while (A_1.y())
			{
				if (A_1.u() != 806379807)
				{
					throw new DplxParseException("A Reference query element contains an invalid attribute.");
				}
				this.a = A_1.a8();
			}
			if (!A_1.z())
			{
				A_1.aa();
				A_1.aa();
			}
			A_1.aa();
			A_1.aa();
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x0015B398 File Offset: 0x0015A398
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x0015B3B0 File Offset: 0x0015A3B0
		internal override Query f1()
		{
			return new ReferenceQuery(this);
		}

		// Token: 0x04001007 RID: 4103
		private new string a;
	}
}
