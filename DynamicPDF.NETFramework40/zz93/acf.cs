using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000441 RID: 1089
	internal class acf
	{
		// Token: 0x06002D02 RID: 11522 RVA: 0x00199F15 File Offset: 0x00198F15
		internal acf(PdfDocument A_0, abj A_1, acf A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002D03 RID: 11523 RVA: 0x00199F44 File Offset: 0x00198F44
		private void a()
		{
			if (!this.d)
			{
				if (this.c == null)
				{
					this.f = new acd();
				}
				else
				{
					this.e = this.c.b();
					this.g = this.c.d();
					this.f = this.c.c();
				}
				for (abk abk = this.b.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num <= 227959193)
					{
						if (num != 63633402)
						{
							if (num == 227959193)
							{
								abe abe = (abe)abk.c().h6();
								if (abe != null)
								{
									this.f.b(new ab5(abe));
								}
							}
						}
						else
						{
							abe abe2 = (abe)abk.c().h6();
							if (abe2 != null)
							{
								this.f.c(new ab5(abe2));
							}
						}
					}
					else if (num != 308085382)
					{
						if (num == 314525777)
						{
							this.g = ((abw)abk.c()).kd();
						}
					}
					else
					{
						this.e = new ace((abj)abk.c().h6());
					}
				}
				this.d = true;
			}
		}

		// Token: 0x06002D04 RID: 11524 RVA: 0x0019A0C4 File Offset: 0x001990C4
		internal ace b()
		{
			this.a();
			ace result;
			if (this.e == null)
			{
				result = null;
			}
			else
			{
				result = this.e;
			}
			return result;
		}

		// Token: 0x06002D05 RID: 11525 RVA: 0x0019A0F8 File Offset: 0x001990F8
		internal acd c()
		{
			this.a();
			acd result;
			if (this.f == null)
			{
				result = null;
			}
			else
			{
				result = this.f.a();
			}
			return result;
		}

		// Token: 0x06002D06 RID: 11526 RVA: 0x0019A130 File Offset: 0x00199130
		internal int d()
		{
			this.a();
			return this.g;
		}

		// Token: 0x06002D07 RID: 11527 RVA: 0x0019A150 File Offset: 0x00199150
		internal PdfDocument e()
		{
			return this.a;
		}

		// Token: 0x04001547 RID: 5447
		private PdfDocument a;

		// Token: 0x04001548 RID: 5448
		private abj b;

		// Token: 0x04001549 RID: 5449
		private acf c;

		// Token: 0x0400154A RID: 5450
		private bool d = false;

		// Token: 0x0400154B RID: 5451
		private ace e;

		// Token: 0x0400154C RID: 5452
		private acd f;

		// Token: 0x0400154D RID: 5453
		private int g = 0;
	}
}
