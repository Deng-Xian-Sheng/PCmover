using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200034B RID: 843
	internal class v4 : vr
	{
		// Token: 0x060023EF RID: 9199 RVA: 0x00153A80 File Offset: 0x00152A80
		internal v4(wd A_0)
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
							this.l = x5.a(A_0.ar());
							break;
						case 57:
							this.m = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								if (num != 10156980)
								{
									goto IL_1E6;
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
					else if (num != 13786676)
					{
						if (num != 565352942)
						{
							if (num != 565869349)
							{
								goto IL_1E6;
							}
							this.i = A_0.ar();
						}
						else
						{
							this.b = A_0.ai();
						}
					}
					else
					{
						this.e = A_0.a8();
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
								goto IL_1E6;
							}
							this.f = A_0.ad();
						}
						else
						{
							this.j = x5.a(A_0.ar());
						}
					}
					else
					{
						this.d = A_0.ar();
					}
				}
				else if (num != 889770711)
				{
					if (num != 906414665)
					{
						if (num != 933645608)
						{
							goto IL_1E6;
						}
						this.k = x5.a(A_0.ar());
					}
					else
					{
						this.h = A_0.aq();
					}
				}
				else
				{
					this.g = A_0.av();
				}
				continue;
				IL_1E6:
				throw new DplxParseException("A label element contains an invalid attribute.");
			}
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x00153C90 File Offset: 0x00152C90
		internal override ReportElement fz(rm A_0)
		{
			return new Label(A_0, this);
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x00153CAC File Offset: 0x00152CAC
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x00153CC4 File Offset: 0x00152CC4
		internal TextAlign a()
		{
			return this.b;
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x00153CDC File Offset: 0x00152CDC
		internal Font b()
		{
			return this.c;
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x00153CF4 File Offset: 0x00152CF4
		internal float c()
		{
			return this.d;
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x00153D0C File Offset: 0x00152D0C
		internal string d()
		{
			return this.e;
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x00153D24 File Offset: 0x00152D24
		internal Color e()
		{
			return this.f;
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x00153D3C File Offset: 0x00152D3C
		internal bool f()
		{
			return this.g;
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x00153D54 File Offset: 0x00152D54
		internal VAlign g()
		{
			return this.h;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x00153D6C File Offset: 0x00152D6C
		internal float h()
		{
			return this.i;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x00153D84 File Offset: 0x00152D84
		internal x5 i()
		{
			return this.j;
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x00153D9C File Offset: 0x00152D9C
		internal x5 j()
		{
			return this.k;
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x00153DB4 File Offset: 0x00152DB4
		internal x5 k()
		{
			return this.l;
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x00153DCC File Offset: 0x00152DCC
		internal x5 l()
		{
			return this.m;
		}

		// Token: 0x04000F85 RID: 3973
		private string a;

		// Token: 0x04000F86 RID: 3974
		private TextAlign b = TextAlign.Left;

		// Token: 0x04000F87 RID: 3975
		private Font c = Font.Helvetica;

		// Token: 0x04000F88 RID: 3976
		private float d = 12f;

		// Token: 0x04000F89 RID: 3977
		private string e;

		// Token: 0x04000F8A RID: 3978
		private Color f = Grayscale.Black;

		// Token: 0x04000F8B RID: 3979
		private bool g = false;

		// Token: 0x04000F8C RID: 3980
		private VAlign h = VAlign.Top;

		// Token: 0x04000F8D RID: 3981
		private float i = 0f;

		// Token: 0x04000F8E RID: 3982
		private x5 j;

		// Token: 0x04000F8F RID: 3983
		private x5 k;

		// Token: 0x04000F90 RID: 3984
		private x5 l;

		// Token: 0x04000F91 RID: 3985
		private x5 m;
	}
}
