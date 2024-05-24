using System;

namespace zz93
{
	// Token: 0x0200016F RID: 367
	internal class jb : fd
	{
		// Token: 0x06000D52 RID: 3410 RVA: 0x0009831C File Offset: 0x0009731C
		internal jb(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00098330 File Offset: 0x00097330
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string text = A_0.au().Trim();
				i4 a_ = A_0.a(text);
				this.a = new gm(m4.a(new h2(a_)));
				this.a.a(a_.b());
			}
			else
			{
				string text = A_0.ah();
				this.a = new gm(x5.a(0f));
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "inherit")
						{
							this.a.d(true);
							goto IL_CD;
						}
						if (text2 == "normal")
						{
							this.a.a(true);
							goto IL_CD;
						}
					}
					this.a.a(true);
					IL_CD:;
				}
				else
				{
					this.a.a(true);
				}
			}
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00098420 File Offset: 0x00097420
		internal gm a()
		{
			return this.a;
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00098438 File Offset: 0x00097438
		internal override int cv()
		{
			return 587060291;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x00098450 File Offset: 0x00097450
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006CA RID: 1738
		private new gm a;
	}
}
