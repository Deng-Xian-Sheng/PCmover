using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000593 RID: 1427
	internal class alk : akt
	{
		// Token: 0x060038D0 RID: 14544 RVA: 0x001E9714 File Offset: 0x001E8714
		internal alk(ald A_0)
		{
			string a_ = A_0.v();
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 234053289)
				{
					if (num <= 2660)
					{
						switch (num)
						{
						case 56:
							this.c = x5.a(A_0.ar());
							break;
						case 57:
							this.d = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								goto IL_1CD;
							}
							this.a = A_0.a7();
							A_0.a(this.a);
							break;
						}
					}
					else if (num != 227335798)
					{
						if (num != 234053289)
						{
							goto IL_1CD;
						}
						this.j = A_0.ar();
					}
					else
					{
						akq akq = (akq)A_0.aw();
						if (akq != akq.a)
						{
							if (akq != akq.b)
							{
								if (akq != akq.c)
								{
								}
								this.l = akq.c;
							}
							else
							{
								this.l = akq.b;
							}
						}
						else
						{
							this.l = akq.a;
						}
					}
				}
				else if (num <= 599705310)
				{
					if (num != 322039639)
					{
						if (num != 599705310)
						{
							goto IL_1CD;
						}
						this.i = A_0.@as();
					}
					else
					{
						this.k = A_0.ar();
					}
				}
				else if (num != 612717355)
				{
					if (num != 667614665)
					{
						if (num != 933645608)
						{
							goto IL_1CD;
						}
						this.e = x5.a(A_0.ar());
					}
					else
					{
						this.m = A_0.a1();
					}
				}
				else
				{
					this.b = A_0.a7();
				}
				continue;
				IL_1CD:
				throw new DlexParseException("A subReport element contains an invalid attribute.");
			}
			A_0.aa();
			if (A_0.x() != 680925463)
			{
				throw new DlexParseException("A Sub Report's header element was not found.");
			}
			this.f = new ak4(A_0);
			A_0.aa();
			if (A_0.x() != 613894213)
			{
				throw new DlexParseException("A Sub Report's detail element was not found.");
			}
			this.g = new akx(A_0);
			A_0.aa();
			if (A_0.x() != 650050839)
			{
				throw new DlexParseException("A Sub Report's footer element was not found.");
			}
			this.h = new ak1(A_0);
			A_0.aa();
			A_0.a(a_);
			if (A_0.z())
			{
				A_0.aa();
				return;
			}
			throw new DlexParseException("A Sub Report was not closed properly.");
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x001E99C8 File Offset: 0x001E89C8
		internal override LayoutElement mt(alo A_0)
		{
			return new SubReport(A_0, this);
		}

		// Token: 0x060038D2 RID: 14546 RVA: 0x001E99E4 File Offset: 0x001E89E4
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060038D3 RID: 14547 RVA: 0x001E99FC File Offset: 0x001E89FC
		internal x5 a()
		{
			return this.c;
		}

		// Token: 0x060038D4 RID: 14548 RVA: 0x001E9A14 File Offset: 0x001E8A14
		internal x5 b()
		{
			return this.d;
		}

		// Token: 0x060038D5 RID: 14549 RVA: 0x001E9A2C File Offset: 0x001E8A2C
		internal x5 c()
		{
			return this.e;
		}

		// Token: 0x060038D6 RID: 14550 RVA: 0x001E9A44 File Offset: 0x001E8A44
		internal ak4 d()
		{
			return this.f;
		}

		// Token: 0x060038D7 RID: 14551 RVA: 0x001E9A5C File Offset: 0x001E8A5C
		internal ak1 e()
		{
			return this.h;
		}

		// Token: 0x060038D8 RID: 14552 RVA: 0x001E9A74 File Offset: 0x001E8A74
		internal akx f()
		{
			return this.g;
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x001E9A8C File Offset: 0x001E8A8C
		internal string g()
		{
			return this.b;
		}

		// Token: 0x060038DA RID: 14554 RVA: 0x001E9AA4 File Offset: 0x001E8AA4
		internal int h()
		{
			return this.i;
		}

		// Token: 0x060038DB RID: 14555 RVA: 0x001E9ABC File Offset: 0x001E8ABC
		internal x5 i()
		{
			return x5.a(this.j);
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x001E9ADC File Offset: 0x001E8ADC
		internal x5 j()
		{
			return x5.a(this.k);
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x001E9AFC File Offset: 0x001E8AFC
		internal akq k()
		{
			return this.l;
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x001E9B14 File Offset: 0x001E8B14
		internal akg l()
		{
			return this.m;
		}

		// Token: 0x04001B0A RID: 6922
		private string a;

		// Token: 0x04001B0B RID: 6923
		private string b = null;

		// Token: 0x04001B0C RID: 6924
		private x5 c;

		// Token: 0x04001B0D RID: 6925
		private x5 d;

		// Token: 0x04001B0E RID: 6926
		private x5 e;

		// Token: 0x04001B0F RID: 6927
		private ak4 f;

		// Token: 0x04001B10 RID: 6928
		private akx g;

		// Token: 0x04001B11 RID: 6929
		private ak1 h;

		// Token: 0x04001B12 RID: 6930
		private int i = 1;

		// Token: 0x04001B13 RID: 6931
		private float j = 0f;

		// Token: 0x04001B14 RID: 6932
		private float k = 0f;

		// Token: 0x04001B15 RID: 6933
		private akq l = akq.b;

		// Token: 0x04001B16 RID: 6934
		private akg m;
	}
}
