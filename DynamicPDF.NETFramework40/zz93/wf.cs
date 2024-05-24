using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000356 RID: 854
	internal class wf : vr
	{
		// Token: 0x060024B3 RID: 9395 RVA: 0x0015A9D8 File Offset: 0x001599D8
		internal wf(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 648436516)
				{
					if (num <= 72417669)
					{
						if (num <= 2660)
						{
							switch (num)
							{
							case 56:
								this.t = x5.a(A_0.ar());
								break;
							case 57:
								this.u = x5.a(A_0.ar());
								break;
							default:
								if (num != 2660)
								{
									goto IL_344;
								}
								this.a = A_0.a8();
								break;
							}
						}
						else if (num != 10156980)
						{
							if (num != 23405387)
							{
								if (num != 72417669)
								{
									goto IL_344;
								}
								this.c = A_0.av();
							}
							else
							{
								this.e = A_0.av();
							}
						}
						else
						{
							this.g = A_0.an();
						}
					}
					else if (num <= 189632562)
					{
						if (num != 121954641)
						{
							if (num != 189632562)
							{
								goto IL_344;
							}
							this.o = A_0.a8();
						}
						else
						{
							this.f = A_0.av();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							if (num != 648436516)
							{
								goto IL_344;
							}
							this.p = A_0.a0();
						}
						else
						{
							this.q = A_0.ar();
						}
					}
					else
					{
						this.b = A_0.ai();
					}
				}
				else if (num <= 847648829)
				{
					if (num <= 680958428)
					{
						if (num != 649884598)
						{
							if (num != 680958428)
							{
								goto IL_344;
							}
							this.r = x5.a(A_0.ar());
						}
						else
						{
							this.h = A_0.ar();
						}
					}
					else if (num != 747796954)
					{
						if (num != 748032654)
						{
							if (num != 847648829)
							{
								goto IL_344;
							}
							this.k = A_0.ar();
						}
						else
						{
							this.i = A_0.ar();
						}
					}
					else
					{
						this.j = A_0.ar();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 858022136)
					{
						if (num != 875120369)
						{
							goto IL_344;
						}
						this.l = A_0.ad();
					}
					else
					{
						this.d = A_0.av();
					}
				}
				else if (num != 889770711)
				{
					if (num != 906414665)
					{
						if (num != 933645608)
						{
							goto IL_344;
						}
						this.s = x5.a(A_0.ar());
					}
					else
					{
						this.n = A_0.aq();
					}
				}
				else
				{
					this.m = A_0.av();
				}
				continue;
				IL_344:
				throw new DplxParseException("A recordBox element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x0015AD60 File Offset: 0x00159D60
		internal override ReportElement fz(rm A_0)
		{
			return new RecordBox(A_0, this);
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x0015AD7C File Offset: 0x00159D7C
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x0015AD94 File Offset: 0x00159D94
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x0015ADAC File Offset: 0x00159DAC
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x0015ADC4 File Offset: 0x00159DC4
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x0015ADDC File Offset: 0x00159DDC
		internal bool d()
		{
			return this.e;
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x0015ADF4 File Offset: 0x00159DF4
		internal bool e()
		{
			return this.f;
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x0015AE0C File Offset: 0x00159E0C
		internal Font f()
		{
			return this.g;
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x0015AE24 File Offset: 0x00159E24
		internal float g()
		{
			return this.h;
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x0015AE3C File Offset: 0x00159E3C
		internal float h()
		{
			return this.i;
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x0015AE54 File Offset: 0x00159E54
		internal float i()
		{
			return this.j;
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x0015AE6C File Offset: 0x00159E6C
		internal float j()
		{
			return this.k;
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x0015AE84 File Offset: 0x00159E84
		internal Color k()
		{
			return this.l;
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x0015AE9C File Offset: 0x00159E9C
		internal bool l()
		{
			return this.m;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x0015AEB4 File Offset: 0x00159EB4
		internal VAlign m()
		{
			return this.n;
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x0015AECC File Offset: 0x00159ECC
		internal string n()
		{
			return this.o;
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x0015AEE4 File Offset: 0x00159EE4
		internal vk o()
		{
			return this.p;
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x0015AEFC File Offset: 0x00159EFC
		internal float p()
		{
			return this.q;
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x0015AF14 File Offset: 0x00159F14
		internal x5 q()
		{
			return this.r;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x0015AF2C File Offset: 0x00159F2C
		internal x5 r()
		{
			return this.s;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x0015AF44 File Offset: 0x00159F44
		internal x5 s()
		{
			return this.t;
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x0015AF5C File Offset: 0x00159F5C
		internal x5 t()
		{
			return this.u;
		}

		// Token: 0x04000FE6 RID: 4070
		private string a;

		// Token: 0x04000FE7 RID: 4071
		private TextAlign b = TextAlign.Left;

		// Token: 0x04000FE8 RID: 4072
		private bool c = true;

		// Token: 0x04000FE9 RID: 4073
		private bool d = true;

		// Token: 0x04000FEA RID: 4074
		private bool e = false;

		// Token: 0x04000FEB RID: 4075
		private bool f = false;

		// Token: 0x04000FEC RID: 4076
		private Font g = Font.Helvetica;

		// Token: 0x04000FED RID: 4077
		private float h = 12f;

		// Token: 0x04000FEE RID: 4078
		private float i = 14f;

		// Token: 0x04000FEF RID: 4079
		private float j = 0f;

		// Token: 0x04000FF0 RID: 4080
		private float k = 0f;

		// Token: 0x04000FF1 RID: 4081
		private Color l = Grayscale.Black;

		// Token: 0x04000FF2 RID: 4082
		private bool m = false;

		// Token: 0x04000FF3 RID: 4083
		private VAlign n = VAlign.Top;

		// Token: 0x04000FF4 RID: 4084
		private string o = null;

		// Token: 0x04000FF5 RID: 4085
		private vk p;

		// Token: 0x04000FF6 RID: 4086
		private float q = 0f;

		// Token: 0x04000FF7 RID: 4087
		private x5 r;

		// Token: 0x04000FF8 RID: 4088
		private x5 s;

		// Token: 0x04000FF9 RID: 4089
		private x5 t;

		// Token: 0x04000FFA RID: 4090
		private x5 u;
	}
}
