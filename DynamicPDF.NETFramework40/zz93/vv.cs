using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000342 RID: 834
	internal abstract class vv
	{
		// Token: 0x060023AA RID: 9130 RVA: 0x00151FA0 File Offset: 0x00150FA0
		internal vv(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x00151FB4 File Offset: 0x00150FB4
		internal static vv c(wd A_0)
		{
			string a_ = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					throw new DplxParseException("A query element contains an invalid attribute.");
				}
				a_ = A_0.a8();
			}
			if (!A_0.z())
			{
				A_0.aa();
				int num = A_0.x();
				if (num <= 667614665)
				{
					if (num == 212076)
					{
						return new wl(a_, A_0);
					}
					if (num == 554747455)
					{
						return new vw(a_, A_0);
					}
					if (num == 667614665)
					{
						return new v0(a_, A_0);
					}
				}
				else
				{
					if (num == 836132025)
					{
						return new vw(a_, A_0);
					}
					if (num == 838893975)
					{
						throw new DplxParseException("SubReport does not support ReferenceQuery");
					}
					if (num == 839027683)
					{
						return new wm(a_, A_0);
					}
				}
				throw new DplxParseException("A query element does not contain a valid child element.");
			}
			return new vw(a_, A_0);
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x001520A8 File Offset: 0x001510A8
		internal static vv b(wd A_0)
		{
			string a_ = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					throw new DplxParseException("A query element contains an invalid attribute.");
				}
				a_ = A_0.a8();
			}
			if (!A_0.z())
			{
				A_0.aa();
				int num = A_0.x();
				if (num <= 554747455)
				{
					if (num == 212076)
					{
						return new wl(a_, A_0);
					}
					if (num == 554747455)
					{
						return new vw(a_, A_0);
					}
				}
				else
				{
					if (num == 836132025)
					{
						return new vw(a_, A_0);
					}
					if (num == 838893975)
					{
						return new wh(a_, A_0);
					}
					if (num == 839027683)
					{
						return new wm(a_, A_0);
					}
				}
				throw new DplxParseException("A query element does not contain a valid child element.");
			}
			return new vw(a_, A_0);
		}

		// Token: 0x060023AD RID: 9133 RVA: 0x00152188 File Offset: 0x00151188
		internal static vv a(wd A_0)
		{
			string a_ = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 2660)
				{
					throw new DplxParseException("A query element contains an invalid attribute.");
				}
				a_ = A_0.a8();
			}
			if (!A_0.z())
			{
				A_0.aa();
				int num = A_0.x();
				if (num <= 554747455)
				{
					if (num == 212076)
					{
						return new wl(a_, A_0);
					}
					if (num == 554747455)
					{
						return new vw(a_, A_0);
					}
				}
				else
				{
					if (num == 836132025)
					{
						return new vw(a_, A_0);
					}
					if (num == 839027683)
					{
						return new wm(a_, A_0);
					}
				}
				throw new DplxParseException("A query element does not contain a valid child element.");
			}
			return new vw(a_, A_0);
		}

		// Token: 0x060023AE RID: 9134
		internal abstract Query f1();

		// Token: 0x060023AF RID: 9135 RVA: 0x00152254 File Offset: 0x00151254
		internal string f()
		{
			return this.a;
		}

		// Token: 0x04000F5D RID: 3933
		private string a;
	}
}
