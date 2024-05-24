using System;

namespace zz93
{
	// Token: 0x02000133 RID: 307
	internal class hn : fd
	{
		// Token: 0x06000BAB RID: 2987 RVA: 0x0008DBBC File Offset: 0x0008CBBC
		internal hn(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0008DBD0 File Offset: 0x0008CBD0
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

		// Token: 0x06000BAD RID: 2989 RVA: 0x0008DCC0 File Offset: 0x0008CCC0
		internal gm a()
		{
			return this.a;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0008DCD8 File Offset: 0x0008CCD8
		internal override int cv()
		{
			return 587060291;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0008DCF0 File Offset: 0x0008CCF0
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000631 RID: 1585
		private new gm a;
	}
}
