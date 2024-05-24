using System;

namespace zz93
{
	// Token: 0x02000596 RID: 1430
	internal class aln
	{
		// Token: 0x060038F3 RID: 14579 RVA: 0x001EA180 File Offset: 0x001E9180
		internal aln()
		{
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x001EA18C File Offset: 0x001E918C
		internal void a(ru A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new aln.a(A_0));
			}
			else
			{
				aln.a a;
				this.b.a(a = new aln.a(A_0));
				this.b = a;
			}
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x001EA1E0 File Offset: 0x001E91E0
		internal bool a()
		{
			return this.a != null;
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x001EA200 File Offset: 0x001E9200
		internal void a(acm A_0)
		{
			for (aln.a a = this.a; a != null; a = a.b())
			{
				a.a().a(A_0);
			}
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x001EA238 File Offset: 0x001E9238
		internal static void a(amg A_0)
		{
			for (aml aml = (aml)A_0.e(); aml != null; aml = (aml)aml.e())
			{
				for (aln.a a = aml.a().a; a != null; a = a.b())
				{
					if (a.a() is am1)
					{
						am1 am = (am1)a.a();
						if (am.gg())
						{
							amg amg = am.e();
							if (amg != null)
							{
								aln.a(amg);
							}
						}
						am.b();
					}
				}
			}
		}

		// Token: 0x04001B27 RID: 6951
		private aln.a a;

		// Token: 0x04001B28 RID: 6952
		private aln.a b;

		// Token: 0x02000597 RID: 1431
		private class a
		{
			// Token: 0x060038F8 RID: 14584 RVA: 0x001EA2EE File Offset: 0x001E92EE
			internal a(ru A_0)
			{
				this.a = A_0;
			}

			// Token: 0x060038F9 RID: 14585 RVA: 0x001EA300 File Offset: 0x001E9300
			internal ru a()
			{
				return this.a;
			}

			// Token: 0x060038FA RID: 14586 RVA: 0x001EA318 File Offset: 0x001E9318
			internal aln.a b()
			{
				return this.b;
			}

			// Token: 0x060038FB RID: 14587 RVA: 0x001EA330 File Offset: 0x001E9330
			internal void a(aln.a A_0)
			{
				this.b = A_0;
			}

			// Token: 0x04001B29 RID: 6953
			private ru a;

			// Token: 0x04001B2A RID: 6954
			private aln.a b;
		}
	}
}
