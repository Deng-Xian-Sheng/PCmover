using System;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200035E RID: 862
	internal class wn : vr
	{
		// Token: 0x060024FF RID: 9471 RVA: 0x0015BDB4 File Offset: 0x0015ADB4
		internal wn(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 227335798)
				{
					switch (num)
					{
					case 56:
						this.b = x5.a(A_0.ar());
						break;
					case 57:
						this.c = x5.a(A_0.ar());
						break;
					default:
						if (num != 2660)
						{
							if (num != 227335798)
							{
								goto IL_16D;
							}
							rk rk = (rk)A_0.aw();
							if (rk != rk.a)
							{
								if (rk != rk.b)
								{
									if (rk != rk.c)
									{
									}
									this.l = rk.c;
								}
								else
								{
									this.l = rk.b;
								}
							}
							else
							{
								this.l = rk.a;
							}
						}
						else
						{
							this.a = A_0.a8();
						}
						break;
					}
				}
				else if (num <= 322039639)
				{
					if (num != 234053289)
					{
						if (num != 322039639)
						{
							goto IL_16D;
						}
						this.k = A_0.ar();
					}
					else
					{
						this.j = A_0.ar();
					}
				}
				else if (num != 599705310)
				{
					if (num != 933645608)
					{
						goto IL_16D;
					}
					this.d = x5.a(A_0.ar());
				}
				else
				{
					this.i = A_0.@as();
				}
				continue;
				IL_16D:
				throw new DplxParseException("A subReport element contains an invalid attribute.");
			}
			A_0.aa();
			if (A_0.x() == 836132025)
			{
				this.h = vv.c(A_0);
				A_0.aa();
			}
			if (A_0.x() != 680925463)
			{
				throw new DplxParseException("A Sub Report's header element was not found.");
			}
			this.e = new v2(A_0);
			A_0.aa();
			if (A_0.x() != 613894213)
			{
				throw new DplxParseException("A Sub Report's detail element was not found.");
			}
			this.f = new vo(A_0);
			A_0.aa();
			if (A_0.x() != 650050839)
			{
				throw new DplxParseException("A Sub Report's footer element was not found.");
			}
			this.g = new vy(A_0);
			A_0.aa();
			if (A_0.z())
			{
				A_0.aa();
				return;
			}
			throw new DplxParseException("A Sub Report was not closed properly.");
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x0015C028 File Offset: 0x0015B028
		internal override ReportElement fz(rm A_0)
		{
			return new SubReport(A_0, this);
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x0015C044 File Offset: 0x0015B044
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x0015C05C File Offset: 0x0015B05C
		internal x5 a()
		{
			return this.b;
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x0015C074 File Offset: 0x0015B074
		internal vv b()
		{
			return this.h;
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x0015C08C File Offset: 0x0015B08C
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x0015C0A4 File Offset: 0x0015B0A4
		internal x5 d()
		{
			return this.d;
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x0015C0BC File Offset: 0x0015B0BC
		internal v2 e()
		{
			return this.e;
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x0015C0D4 File Offset: 0x0015B0D4
		internal vy f()
		{
			return this.g;
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x0015C0EC File Offset: 0x0015B0EC
		internal vo g()
		{
			return this.f;
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x0015C104 File Offset: 0x0015B104
		internal int h()
		{
			return this.i;
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x0015C11C File Offset: 0x0015B11C
		internal x5 i()
		{
			return x5.a(this.j);
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x0015C13C File Offset: 0x0015B13C
		internal x5 j()
		{
			return x5.a(this.k);
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x0015C15C File Offset: 0x0015B15C
		internal rk k()
		{
			return this.l;
		}

		// Token: 0x04001021 RID: 4129
		private string a;

		// Token: 0x04001022 RID: 4130
		private x5 b;

		// Token: 0x04001023 RID: 4131
		private x5 c;

		// Token: 0x04001024 RID: 4132
		private x5 d;

		// Token: 0x04001025 RID: 4133
		private v2 e;

		// Token: 0x04001026 RID: 4134
		private vo f;

		// Token: 0x04001027 RID: 4135
		private vy g;

		// Token: 0x04001028 RID: 4136
		private vv h;

		// Token: 0x04001029 RID: 4137
		private int i = 1;

		// Token: 0x0400102A RID: 4138
		private float j = 0f;

		// Token: 0x0400102B RID: 4139
		private float k = 0f;

		// Token: 0x0400102C RID: 4140
		private rk l = rk.b;
	}
}
