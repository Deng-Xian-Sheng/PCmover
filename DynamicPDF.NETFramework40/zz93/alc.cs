using System;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x0200058B RID: 1419
	internal class alc : akt
	{
		// Token: 0x0600381E RID: 14366 RVA: 0x001E32B4 File Offset: 0x001E22B4
		internal alc(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 2660)
				{
					switch (num)
					{
					case 56:
						this.d = x5.a(A_0.ar());
						break;
					case 57:
						this.e = x5.a(A_0.ar());
						break;
					default:
						if (num != 2660)
						{
							goto IL_A8;
						}
						this.a = A_0.a7();
						break;
					}
				}
				else if (num != 680958428)
				{
					if (num != 933645608)
					{
						goto IL_A8;
					}
					this.c = x5.a(A_0.ar());
				}
				else
				{
					this.b = x5.a(A_0.ar());
				}
				continue;
				IL_A8:
				throw new DlexParseException("A placeHolder element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600381F RID: 14367 RVA: 0x001E33A0 File Offset: 0x001E23A0
		internal override LayoutElement mt(alo A_0)
		{
			return new PlaceHolder(A_0, this);
		}

		// Token: 0x06003820 RID: 14368 RVA: 0x001E33BC File Offset: 0x001E23BC
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x06003821 RID: 14369 RVA: 0x001E33D4 File Offset: 0x001E23D4
		internal x5 a()
		{
			return this.d;
		}

		// Token: 0x06003822 RID: 14370 RVA: 0x001E33EC File Offset: 0x001E23EC
		internal x5 b()
		{
			return this.e;
		}

		// Token: 0x06003823 RID: 14371 RVA: 0x001E3404 File Offset: 0x001E2404
		internal x5 c()
		{
			return this.c;
		}

		// Token: 0x06003824 RID: 14372 RVA: 0x001E341C File Offset: 0x001E241C
		internal x5 d()
		{
			return this.b;
		}

		// Token: 0x04001AB3 RID: 6835
		private string a;

		// Token: 0x04001AB4 RID: 6836
		private x5 b;

		// Token: 0x04001AB5 RID: 6837
		private x5 c;

		// Token: 0x04001AB6 RID: 6838
		private x5 d;

		// Token: 0x04001AB7 RID: 6839
		private x5 e;
	}
}
