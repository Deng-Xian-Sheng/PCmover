using System;

namespace zz93
{
	// Token: 0x02000162 RID: 354
	internal class iy : fd
	{
		// Token: 0x06000D0B RID: 3339 RVA: 0x00096308 File Offset: 0x00095308
		internal iy()
		{
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x00096313 File Offset: 0x00095313
		internal iy(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x00096328 File Offset: 0x00095328
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string text = A_0.au().Trim();
				if (text != null)
				{
					i4 a_ = A_0.a(text);
					this.a = new af9(m4.a(new h2(a_)));
					if (a_.b() == i2.b)
					{
						this.a.a(true);
						this.a.a(a_.b());
					}
					else
					{
						this.a.a(a_.b());
					}
				}
			}
			else
			{
				string text = A_0.au().Trim();
				if (string.Compare(text, "inherit", true) == 0)
				{
					this.a = new af9(x5.a(0f));
					this.a.d(true);
				}
				else
				{
					this.a = new af9(x5.a(0f));
				}
			}
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0009642C File Offset: 0x0009542C
		internal af9 a()
		{
			return this.a;
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00096444 File Offset: 0x00095444
		internal override int cv()
		{
			return 1982853278;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0009645C File Offset: 0x0009545C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006AC RID: 1708
		private new af9 a;
	}
}
