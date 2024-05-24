using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x0200035C RID: 860
	internal class wl : vv
	{
		// Token: 0x060024F3 RID: 9459 RVA: 0x0015BB14 File Offset: 0x0015AB14
		internal wl(string A_0, wd A_1) : base(A_0)
		{
			while (A_1.y())
			{
				int num = A_1.u();
				if (num != 331307522)
				{
					if (num != 372779846)
					{
						throw new DplxParseException("A SQL query element contains an invalid attribute.");
					}
					this.b = A_1.am();
				}
				else
				{
					this.a = A_1.a4();
				}
			}
			if (!A_1.z())
			{
				this.c = A_1.ax();
			}
			A_1.aa();
			A_1.aa();
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x0015BBA8 File Offset: 0x0015ABA8
		internal override Query f1()
		{
			return new SqlQuery(this);
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x0015BBC0 File Offset: 0x0015ABC0
		internal tu a()
		{
			return this.c;
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x0015BBD8 File Offset: 0x0015ABD8
		internal string b()
		{
			return this.a;
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x0015BBF0 File Offset: 0x0015ABF0
		internal ProviderType c()
		{
			return this.b;
		}

		// Token: 0x04001019 RID: 4121
		private new string a;

		// Token: 0x0400101A RID: 4122
		private new ProviderType b;

		// Token: 0x0400101B RID: 4123
		private new tu c = null;
	}
}
