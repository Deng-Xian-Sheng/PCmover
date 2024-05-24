using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x0200035D RID: 861
	internal class wm : vv
	{
		// Token: 0x060024F8 RID: 9464 RVA: 0x0015BC08 File Offset: 0x0015AC08
		internal wm(string A_0, wd A_1) : base(A_0)
		{
			while (A_1.y())
			{
				int num = A_1.u();
				if (num <= 331307522)
				{
					if (num != 12196709)
					{
						if (num != 331307522)
						{
							goto IL_7E;
						}
						this.a = A_1.a4();
					}
					else
					{
						this.c = A_1.a8();
					}
				}
				else if (num != 372779846)
				{
					if (num != 920977973)
					{
						goto IL_7E;
					}
					this.d = A_1.a8();
				}
				else
				{
					this.b = A_1.am();
				}
				continue;
				IL_7E:
				throw new DplxParseException("A stored procedure query element contains an invalid attribute.");
			}
			if (!A_1.z())
			{
				A_1.aa();
				if (A_1.x() == 806379807)
				{
					this.e = new wb();
					while (A_1.x() == 806379807)
					{
						this.e.a(new wa(A_1));
						A_1.aa();
					}
				}
				A_1.aa();
			}
			A_1.aa();
			A_1.aa();
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x0015BD24 File Offset: 0x0015AD24
		internal override Query f1()
		{
			return new StoredProcedureQuery(this);
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x0015BD3C File Offset: 0x0015AD3C
		internal string a()
		{
			return this.c;
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x0015BD54 File Offset: 0x0015AD54
		internal wb b()
		{
			return this.e;
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x0015BD6C File Offset: 0x0015AD6C
		internal string c()
		{
			return this.a;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x0015BD84 File Offset: 0x0015AD84
		internal ProviderType d()
		{
			return this.b;
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x0015BD9C File Offset: 0x0015AD9C
		internal string e()
		{
			return this.d;
		}

		// Token: 0x0400101C RID: 4124
		private new string a;

		// Token: 0x0400101D RID: 4125
		private new ProviderType b;

		// Token: 0x0400101E RID: 4126
		private new string c;

		// Token: 0x0400101F RID: 4127
		private string d;

		// Token: 0x04001020 RID: 4128
		private wb e = null;
	}
}
