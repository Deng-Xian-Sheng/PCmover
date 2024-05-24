using System;

namespace zz93
{
	// Token: 0x020000E6 RID: 230
	internal class fi : fd
	{
		// Token: 0x06000A3F RID: 2623 RVA: 0x000840AE File Offset: 0x000830AE
		internal fi()
		{
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x000840B9 File Offset: 0x000830B9
		internal fi(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x000840CC File Offset: 0x000830CC
		internal @in a()
		{
			return this.a;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x000840E4 File Offset: 0x000830E4
		internal override int cv()
		{
			return 200780672;
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x000840FC File Offset: 0x000830FC
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00084114 File Offset: 0x00083114
		internal override void cw(gi A_0)
		{
			int num = 0;
			string text = null;
			x5 x = x5.c();
			x5 a_ = x5.c();
			if (A_0.aw())
			{
				text = A_0.au();
				text = text.TrimStart(new char[]
				{
					'+'
				});
				if (text != null && char.IsNumber(text[0]))
				{
					x = m4.a(new h2(A_0.a(text)));
					num++;
				}
				else
				{
					num++;
				}
				while (A_0.a0())
				{
					text = A_0.au();
					if (text != null && char.IsNumber(text[0]))
					{
						a_ = m4.a(new h2(A_0.a(text)));
						num++;
					}
				}
			}
			switch (num)
			{
			case 1:
				if (string.Compare(text, "inherit", true) == 0)
				{
					this.a = new @in(x, a_);
					this.a.d(true);
				}
				else
				{
					a_ = x;
					this.a = new @in(x, a_);
				}
				break;
			case 2:
				this.a = new @in(x, a_);
				break;
			}
		}

		// Token: 0x04000512 RID: 1298
		private new @in a;
	}
}
