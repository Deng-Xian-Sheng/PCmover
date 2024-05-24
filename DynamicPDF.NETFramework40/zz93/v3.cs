using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200034A RID: 842
	internal class v3 : vr
	{
		// Token: 0x060023E5 RID: 9189 RVA: 0x00153848 File Offset: 0x00152848
		internal v3(wd A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 12721448)
				{
					switch (num)
					{
					case 56:
						this.e = x5.a(A_0.ar());
						break;
					case 57:
						this.f = x5.a(A_0.ar());
						break;
					default:
						if (num != 2660)
						{
							if (num != 12721448)
							{
								goto IL_11B;
							}
							string filePath = A_0.a7();
							this.g = ImageData.GetImage(filePath);
						}
						else
						{
							this.a = A_0.a8();
						}
						break;
					}
				}
				else if (num <= 565869349)
				{
					if (num != 565398289)
					{
						if (num != 565869349)
						{
							goto IL_11B;
						}
						this.b = A_0.ar();
					}
					else
					{
						this.h = A_0.a8();
					}
				}
				else if (num != 680958428)
				{
					if (num != 933645608)
					{
						goto IL_11B;
					}
					this.d = x5.a(A_0.ar());
				}
				else
				{
					this.c = x5.a(A_0.ar());
				}
				continue;
				IL_11B:
				throw new DplxParseException("An image element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060023E6 RID: 9190 RVA: 0x001539A4 File Offset: 0x001529A4
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060023E7 RID: 9191 RVA: 0x001539BC File Offset: 0x001529BC
		internal override ReportElement fz(rm A_0)
		{
			return new Image(A_0, this);
		}

		// Token: 0x060023E8 RID: 9192 RVA: 0x001539D8 File Offset: 0x001529D8
		internal float a()
		{
			return this.b;
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x001539F0 File Offset: 0x001529F0
		internal x5 b()
		{
			return this.c;
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x00153A08 File Offset: 0x00152A08
		internal x5 c()
		{
			return this.d;
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x00153A20 File Offset: 0x00152A20
		internal x5 d()
		{
			return this.e;
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x00153A38 File Offset: 0x00152A38
		internal x5 e()
		{
			return this.f;
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x00153A50 File Offset: 0x00152A50
		internal ImageData f()
		{
			return this.g;
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x00153A68 File Offset: 0x00152A68
		internal string g()
		{
			return this.h;
		}

		// Token: 0x04000F7D RID: 3965
		private string a;

		// Token: 0x04000F7E RID: 3966
		private float b;

		// Token: 0x04000F7F RID: 3967
		private x5 c;

		// Token: 0x04000F80 RID: 3968
		private x5 d;

		// Token: 0x04000F81 RID: 3969
		private x5 e;

		// Token: 0x04000F82 RID: 3970
		private x5 f;

		// Token: 0x04000F83 RID: 3971
		private ImageData g = null;

		// Token: 0x04000F84 RID: 3972
		private string h = null;
	}
}
