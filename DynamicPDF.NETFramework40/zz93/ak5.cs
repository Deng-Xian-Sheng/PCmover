using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x02000584 RID: 1412
	internal class ak5 : akt
	{
		// Token: 0x060037D8 RID: 14296 RVA: 0x001E1F6C File Offset: 0x001E0F6C
		internal ak5(ald A_0)
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
							string filePath = A_0.a6();
							this.g = ImageData.GetImage(filePath);
						}
						else
						{
							this.a = A_0.a7();
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
						this.h = A_0.a7();
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
				throw new DlexParseException("An image element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037D9 RID: 14297 RVA: 0x001E20C8 File Offset: 0x001E10C8
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x001E20E0 File Offset: 0x001E10E0
		internal override LayoutElement mt(alo A_0)
		{
			return new Image(A_0, this);
		}

		// Token: 0x060037DB RID: 14299 RVA: 0x001E20FC File Offset: 0x001E10FC
		internal float a()
		{
			return this.b;
		}

		// Token: 0x060037DC RID: 14300 RVA: 0x001E2114 File Offset: 0x001E1114
		internal x5 b()
		{
			return this.c;
		}

		// Token: 0x060037DD RID: 14301 RVA: 0x001E212C File Offset: 0x001E112C
		internal x5 c()
		{
			return this.d;
		}

		// Token: 0x060037DE RID: 14302 RVA: 0x001E2144 File Offset: 0x001E1144
		internal x5 d()
		{
			return this.e;
		}

		// Token: 0x060037DF RID: 14303 RVA: 0x001E215C File Offset: 0x001E115C
		internal x5 e()
		{
			return this.f;
		}

		// Token: 0x060037E0 RID: 14304 RVA: 0x001E2174 File Offset: 0x001E1174
		internal ImageData f()
		{
			return this.g;
		}

		// Token: 0x060037E1 RID: 14305 RVA: 0x001E218C File Offset: 0x001E118C
		internal string g()
		{
			return this.h;
		}

		// Token: 0x04001A7D RID: 6781
		private string a;

		// Token: 0x04001A7E RID: 6782
		private float b;

		// Token: 0x04001A7F RID: 6783
		private x5 c;

		// Token: 0x04001A80 RID: 6784
		private x5 d;

		// Token: 0x04001A81 RID: 6785
		private x5 e;

		// Token: 0x04001A82 RID: 6786
		private x5 f;

		// Token: 0x04001A83 RID: 6787
		private ImageData g = null;

		// Token: 0x04001A84 RID: 6788
		private string h = null;
	}
}
