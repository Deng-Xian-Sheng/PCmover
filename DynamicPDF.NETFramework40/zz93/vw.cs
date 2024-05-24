using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000343 RID: 835
	internal class vw : vv
	{
		// Token: 0x060023B0 RID: 9136 RVA: 0x0015226C File Offset: 0x0015126C
		internal vw(string A_0, wd A_1) : base(A_0)
		{
			if (A_1.x() == 554747455)
			{
				while (A_1.y())
				{
					int num = A_1.u();
					if (num != 331307522)
					{
						throw new DplxParseException("A EventDriven query element contains an invalid attribute.");
					}
					this.b = A_1.a4();
				}
				this.a = A_1.ax();
				A_1.aa();
				A_1.aa();
			}
			else if (A_1.x() == 836132025)
			{
				A_1.aa();
			}
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x00152314 File Offset: 0x00151314
		internal override Query f1()
		{
			return new EventDrivenQuery(this);
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x0015232C File Offset: 0x0015132C
		public tu a()
		{
			return this.a;
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x00152344 File Offset: 0x00151344
		internal string b()
		{
			return this.b;
		}

		// Token: 0x04000F5E RID: 3934
		private new tu a = null;

		// Token: 0x04000F5F RID: 3935
		private new string b;
	}
}
