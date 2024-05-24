using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004FB RID: 1275
	internal class ahg
	{
		// Token: 0x06003403 RID: 13315 RVA: 0x001CDA6A File Offset: 0x001CCA6A
		internal ahg(abt A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x001CDAA8 File Offset: 0x001CCAA8
		internal int a(agv A_0, abi A_1)
		{
			afj afj = A_0.lm(A_1);
			this.a(afj.l());
			this.a(A_0.lp(), afj);
			return this.b;
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x001CDAE4 File Offset: 0x001CCAE4
		private void a(aba A_0, afj A_1)
		{
			byte[] array = A_1.j3();
			ag7 ag = null;
			if (A_1.b())
			{
				if (this.f >= 10)
				{
					ag = new aha(array, 0, array.Length, this.a, this.d, this.e);
				}
				if (this.f == 2)
				{
					ag = new ahe(array, 0, array.Length, this.a, this.d, this.e);
				}
				if (this.f == 1)
				{
					ag = new ag8(array, 0, array.Length, this.a, this.d, this.e);
				}
			}
			else if (!A_1.d() && !A_1.c())
			{
				ag = new ahf(array, 0, this.a, this.d, this.e);
			}
			if (ag == null)
			{
				throw new PdfParsingException("Invalid XRef Stream Filter Specified.");
			}
			ag.a(A_0, this.c);
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x001CDBEC File Offset: 0x001CCBEC
		private void a(abk A_0)
		{
			for (abk abk = A_0; abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 4914164)
				{
					if (num <= 580)
					{
						if (num != 23)
						{
							if (num == 580)
							{
								this.c.c(abk.c());
							}
						}
						else
						{
							this.e = (abe)abk.c();
						}
					}
					else if (num != 2550191)
					{
						if (num != 4401526)
						{
							if (num == 4914164)
							{
								this.c.a((ab6)abk.c());
							}
						}
						else
						{
							this.b = ((abw)abk.c()).kd();
						}
					}
					else
					{
						this.c.b(abk.c());
					}
				}
				else if (num <= 96088205)
				{
					if (num != 5152421)
					{
						if (num == 96088205)
						{
							this.c.a(abk.c());
						}
					}
					else
					{
						this.a = ((abw)abk.c()).kd();
					}
				}
				else if (num != 163203448)
				{
					if (num != 407524542)
					{
						if (num == 567551866)
						{
							this.a((abj)abk.c());
						}
					}
					else
					{
						this.g = ((abw)abk.c()).kd();
					}
				}
				else
				{
					this.d = (abe)abk.c();
				}
			}
		}

		// Token: 0x06003407 RID: 13319 RVA: 0x001CDD98 File Offset: 0x001CCD98
		private void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 272962267)
				{
					this.f = ((abw)abk.c()).kd();
					break;
				}
			}
		}

		// Token: 0x06003408 RID: 13320 RVA: 0x001CDDF8 File Offset: 0x001CCDF8
		internal int a()
		{
			return this.g;
		}

		// Token: 0x04001920 RID: 6432
		private int a = -1;

		// Token: 0x04001921 RID: 6433
		private int b = -1;

		// Token: 0x04001922 RID: 6434
		private abt c;

		// Token: 0x04001923 RID: 6435
		private abe d = null;

		// Token: 0x04001924 RID: 6436
		private abe e = null;

		// Token: 0x04001925 RID: 6437
		private int f = 1;

		// Token: 0x04001926 RID: 6438
		private int g = -1;
	}
}
