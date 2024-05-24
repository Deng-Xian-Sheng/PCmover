using System;

namespace zz93
{
	// Token: 0x0200014B RID: 331
	internal class ib : fd
	{
		// Token: 0x06000C4F RID: 3151 RVA: 0x000914A1 File Offset: 0x000904A1
		internal ib(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000914B4 File Offset: 0x000904B4
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string text = A_0.au().Trim();
				i4 a_ = A_0.a(text);
				this.a = new f9(m4.a(new h2(a_)));
				this.a.a(a_.b());
				if (a_.b() == i2.b)
				{
					this.a.a(true);
				}
			}
			else
			{
				string text = A_0.ah();
				this.a = new f9(x5.a(0f));
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "inherit")
						{
							this.a.d(true);
							goto IL_ED;
						}
						if (text2 == "auto")
						{
							this.a.b(true);
							goto IL_ED;
						}
					}
					this.a.b(true);
					IL_ED:;
				}
				else
				{
					this.a.b(true);
				}
			}
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x000915C4 File Offset: 0x000905C4
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x000915DC File Offset: 0x000905DC
		internal void a(f9 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x000915E8 File Offset: 0x000905E8
		internal override int cv()
		{
			return 448574430;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00091600 File Offset: 0x00090600
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000657 RID: 1623
		private new f9 a;
	}
}
