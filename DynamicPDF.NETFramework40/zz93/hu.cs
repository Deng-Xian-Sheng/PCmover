using System;

namespace zz93
{
	// Token: 0x0200013A RID: 314
	internal class hu : fd
	{
		// Token: 0x06000BEF RID: 3055 RVA: 0x0008F930 File Offset: 0x0008E930
		internal hu(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0008F944 File Offset: 0x0008E944
		internal override void cw(gi A_0)
		{
			string text = A_0.au().Trim();
			if (char.IsNumber(text[0]) || text[0] == '+' || text[0] == '-')
			{
				i4 a_ = A_0.a(text);
				this.a = new af9(m4.a(new h2(a_)));
				i2 i = a_.b();
				if (i != i2.b)
				{
					switch (i)
					{
					case i2.f:
					case i2.h:
						this.a.a(a_.b());
						goto IL_C8;
					}
					this.a.a(i2.d);
				}
				else
				{
					this.a.a(true);
					this.a.a(a_.b());
				}
				IL_C8:;
			}
			else if (string.Compare(text, "inherit", true) == 0)
			{
				this.a = new af9(x5.a(0f));
				this.a.d(true);
			}
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0008FA58 File Offset: 0x0008EA58
		internal af9 a()
		{
			return this.a;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0008FA70 File Offset: 0x0008EA70
		internal override int cv()
		{
			return 445330501;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0008FA88 File Offset: 0x0008EA88
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x0400063E RID: 1598
		private new af9 a;
	}
}
