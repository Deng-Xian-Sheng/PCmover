using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x02000350 RID: 848
	internal class v9 : vr
	{
		// Token: 0x0600241B RID: 9243 RVA: 0x001547E0 File Offset: 0x001537E0
		internal v9(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 565869349)
				{
					if (num <= 10156980)
					{
						switch (num)
						{
						case 56:
							this.n = x5.a(A_0.ar());
							break;
						case 57:
							this.o = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								if (num != 10156980)
								{
									goto IL_249;
								}
								this.c = A_0.an();
							}
							else
							{
								this.a = A_0.a8();
							}
							break;
						}
					}
					else if (num <= 371015739)
					{
						if (num != 13786676)
						{
							if (num != 371015739)
							{
								goto IL_249;
							}
							this.e = A_0.@as();
						}
						else
						{
							this.g = A_0.a8();
						}
					}
					else if (num != 565352942)
					{
						if (num != 565869349)
						{
							goto IL_249;
						}
						this.k = A_0.ar();
					}
					else
					{
						this.b = A_0.ai();
					}
				}
				else if (num <= 875120369)
				{
					if (num != 649884598)
					{
						if (num != 680958428)
						{
							if (num != 875120369)
							{
								goto IL_249;
							}
							this.h = A_0.ad();
						}
						else
						{
							this.l = x5.a(A_0.ar());
						}
					}
					else
					{
						this.d = A_0.ar();
					}
				}
				else if (num <= 906414665)
				{
					if (num != 889770711)
					{
						if (num != 906414665)
						{
							goto IL_249;
						}
						this.j = A_0.aq();
					}
					else
					{
						this.i = A_0.av();
					}
				}
				else if (num != 933645608)
				{
					if (num != 969890607)
					{
						goto IL_249;
					}
					this.f = A_0.@as();
				}
				else
				{
					this.m = x5.a(A_0.ar());
				}
				continue;
				IL_249:
				throw new DplxParseException("A pageNumberingLabel element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600241C RID: 9244 RVA: 0x00154A6C File Offset: 0x00153A6C
		internal override ReportElement fz(rm A_0)
		{
			return new PageNumberingLabel(A_0, this);
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x00154A88 File Offset: 0x00153A88
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x00154AA0 File Offset: 0x00153AA0
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x0600241F RID: 9247 RVA: 0x00154AB8 File Offset: 0x00153AB8
		internal Font b()
		{
			return this.c;
		}

		// Token: 0x06002420 RID: 9248 RVA: 0x00154AD0 File Offset: 0x00153AD0
		internal float c()
		{
			return this.d;
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x00154AE8 File Offset: 0x00153AE8
		internal string d()
		{
			return this.g;
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x00154B00 File Offset: 0x00153B00
		internal Color e()
		{
			return this.h;
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x00154B18 File Offset: 0x00153B18
		internal bool f()
		{
			return this.i;
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x00154B30 File Offset: 0x00153B30
		internal VAlign g()
		{
			return this.j;
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x00154B48 File Offset: 0x00153B48
		internal float h()
		{
			return this.k;
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x00154B60 File Offset: 0x00153B60
		internal x5 i()
		{
			return this.l;
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x00154B78 File Offset: 0x00153B78
		internal x5 j()
		{
			return this.m;
		}

		// Token: 0x06002428 RID: 9256 RVA: 0x00154B90 File Offset: 0x00153B90
		internal x5 k()
		{
			return this.n;
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x00154BA8 File Offset: 0x00153BA8
		internal x5 l()
		{
			return this.o;
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x00154BC0 File Offset: 0x00153BC0
		internal int m()
		{
			return this.e;
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x00154BD8 File Offset: 0x00153BD8
		internal int n()
		{
			return this.f;
		}

		// Token: 0x04000FA5 RID: 4005
		private string a;

		// Token: 0x04000FA6 RID: 4006
		private TextAlign b = TextAlign.Left;

		// Token: 0x04000FA7 RID: 4007
		private Font c = Font.Helvetica;

		// Token: 0x04000FA8 RID: 4008
		private float d = 12f;

		// Token: 0x04000FA9 RID: 4009
		private int e = 0;

		// Token: 0x04000FAA RID: 4010
		private int f = 0;

		// Token: 0x04000FAB RID: 4011
		private string g;

		// Token: 0x04000FAC RID: 4012
		private Color h = Grayscale.Black;

		// Token: 0x04000FAD RID: 4013
		private bool i = false;

		// Token: 0x04000FAE RID: 4014
		private VAlign j = VAlign.Top;

		// Token: 0x04000FAF RID: 4015
		private float k = 0f;

		// Token: 0x04000FB0 RID: 4016
		private x5 l;

		// Token: 0x04000FB1 RID: 4017
		private x5 m;

		// Token: 0x04000FB2 RID: 4018
		private x5 n;

		// Token: 0x04000FB3 RID: 4019
		private x5 o;
	}
}
