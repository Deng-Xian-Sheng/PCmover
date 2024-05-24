using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000355 RID: 853
	internal class we : vr
	{
		// Token: 0x0600249D RID: 9373 RVA: 0x0015A46C File Offset: 0x0015946C
		internal we(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 649884598)
				{
					if (num <= 23405387)
					{
						if (num <= 2660)
						{
							switch (num)
							{
							case 56:
								this.s = x5.a(A_0.ar());
								break;
							case 57:
								this.t = x5.a(A_0.ar());
								break;
							default:
								if (num != 2660)
								{
									goto IL_305;
								}
								this.a = A_0.a8();
								break;
							}
						}
						else if (num != 10156980)
						{
							if (num != 23405387)
							{
								goto IL_305;
							}
							this.e = A_0.av();
						}
						else
						{
							this.g = A_0.an();
						}
					}
					else if (num <= 121954641)
					{
						if (num != 72417669)
						{
							if (num != 121954641)
							{
								goto IL_305;
							}
							this.f = A_0.av();
						}
						else
						{
							this.c = A_0.av();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							if (num != 649884598)
							{
								goto IL_305;
							}
							this.h = A_0.ar();
						}
						else
						{
							this.p = A_0.ar();
						}
					}
					else
					{
						this.b = A_0.ai();
					}
				}
				else if (num <= 847648829)
				{
					if (num <= 747796954)
					{
						if (num != 680958428)
						{
							if (num != 747796954)
							{
								goto IL_305;
							}
							this.j = A_0.ar();
						}
						else
						{
							this.q = x5.a(A_0.ar());
						}
					}
					else if (num != 748032654)
					{
						if (num != 847648829)
						{
							goto IL_305;
						}
						this.k = A_0.ar();
					}
					else
					{
						this.i = A_0.ar();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 858022136)
					{
						if (num != 875120369)
						{
							goto IL_305;
						}
						this.m = A_0.ad();
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
							goto IL_305;
						}
						this.r = x5.a(A_0.ar());
					}
					else
					{
						this.o = A_0.aq();
					}
				}
				else
				{
					this.n = A_0.av();
				}
				continue;
				IL_305:
				throw new DplxParseException("A recordArea element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				if (A_0.x() == 13786676)
				{
					this.l = A_0.ax();
					A_0.aa();
				}
				A_0.aa();
			}
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x0015A7DC File Offset: 0x001597DC
		internal override ReportElement fz(rm A_0)
		{
			return new RecordArea(A_0, this);
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x0015A7F8 File Offset: 0x001597F8
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x0015A810 File Offset: 0x00159810
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x0015A828 File Offset: 0x00159828
		internal bool b()
		{
			return this.c;
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x0015A840 File Offset: 0x00159840
		internal bool c()
		{
			return this.d;
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x0015A858 File Offset: 0x00159858
		internal bool d()
		{
			return this.e;
		}

		// Token: 0x060024A4 RID: 9380 RVA: 0x0015A870 File Offset: 0x00159870
		internal bool e()
		{
			return this.f;
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x0015A888 File Offset: 0x00159888
		internal Font f()
		{
			return this.g;
		}

		// Token: 0x060024A6 RID: 9382 RVA: 0x0015A8A0 File Offset: 0x001598A0
		internal float g()
		{
			return this.h;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x0015A8B8 File Offset: 0x001598B8
		internal float h()
		{
			return this.i;
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x0015A8D0 File Offset: 0x001598D0
		internal float i()
		{
			return this.j;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x0015A8E8 File Offset: 0x001598E8
		internal float j()
		{
			return this.k;
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x0015A900 File Offset: 0x00159900
		internal tu k()
		{
			return this.l;
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x0015A918 File Offset: 0x00159918
		internal Color l()
		{
			return this.m;
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x0015A930 File Offset: 0x00159930
		internal bool m()
		{
			return this.n;
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x0015A948 File Offset: 0x00159948
		internal VAlign n()
		{
			return this.o;
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x0015A960 File Offset: 0x00159960
		internal float o()
		{
			return this.p;
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x0015A978 File Offset: 0x00159978
		internal x5 p()
		{
			return this.q;
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x0015A990 File Offset: 0x00159990
		internal x5 q()
		{
			return this.r;
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x0015A9A8 File Offset: 0x001599A8
		internal x5 r()
		{
			return this.s;
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x0015A9C0 File Offset: 0x001599C0
		internal x5 s()
		{
			return this.t;
		}

		// Token: 0x04000FD2 RID: 4050
		private string a;

		// Token: 0x04000FD3 RID: 4051
		private TextAlign b = TextAlign.Left;

		// Token: 0x04000FD4 RID: 4052
		private bool c = true;

		// Token: 0x04000FD5 RID: 4053
		private bool d = true;

		// Token: 0x04000FD6 RID: 4054
		private bool e = false;

		// Token: 0x04000FD7 RID: 4055
		private bool f = false;

		// Token: 0x04000FD8 RID: 4056
		private Font g = Font.Helvetica;

		// Token: 0x04000FD9 RID: 4057
		private float h = 12f;

		// Token: 0x04000FDA RID: 4058
		private float i = 14f;

		// Token: 0x04000FDB RID: 4059
		private float j = 0f;

		// Token: 0x04000FDC RID: 4060
		private float k = 0f;

		// Token: 0x04000FDD RID: 4061
		private tu l;

		// Token: 0x04000FDE RID: 4062
		private Color m = Grayscale.Black;

		// Token: 0x04000FDF RID: 4063
		private bool n = false;

		// Token: 0x04000FE0 RID: 4064
		private VAlign o = VAlign.Top;

		// Token: 0x04000FE1 RID: 4065
		private float p = 0f;

		// Token: 0x04000FE2 RID: 4066
		private x5 q;

		// Token: 0x04000FE3 RID: 4067
		private x5 r;

		// Token: 0x04000FE4 RID: 4068
		private x5 s;

		// Token: 0x04000FE5 RID: 4069
		private x5 t;
	}
}
