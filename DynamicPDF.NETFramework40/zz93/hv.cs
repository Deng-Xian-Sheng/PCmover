using System;

namespace zz93
{
	// Token: 0x0200013B RID: 315
	internal class hv : fd
	{
		// Token: 0x06000BF4 RID: 3060 RVA: 0x0008FAA0 File Offset: 0x0008EAA0
		internal hv(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0008FAB4 File Offset: 0x0008EAB4
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

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0008FBC8 File Offset: 0x0008EBC8
		internal af9 a()
		{
			return this.a;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0008FBE0 File Offset: 0x0008EBE0
		internal override int cv()
		{
			return 663292235;
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0008FBF8 File Offset: 0x0008EBF8
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x0400063F RID: 1599
		private new af9 a;
	}
}
