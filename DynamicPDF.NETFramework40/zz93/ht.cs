using System;

namespace zz93
{
	// Token: 0x02000139 RID: 313
	internal class ht : fd
	{
		// Token: 0x06000BE9 RID: 3049 RVA: 0x0008F77C File Offset: 0x0008E77C
		internal ht(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x0008F790 File Offset: 0x0008E790
		internal override void cw(gi A_0)
		{
			if (A_0.ax())
			{
				string text = A_0.au().Trim();
				i4 a_ = A_0.a(text);
				this.a = new af8(m4.a(new h2(a_)));
				i2 i = a_.b();
				if (i != i2.b)
				{
					switch (i)
					{
					case i2.f:
					case i2.h:
						this.a.a(a_.b());
						goto IL_A6;
					}
					this.a.a(i2.d);
				}
				else
				{
					this.a.a(true);
					this.a.a(a_.b());
				}
				IL_A6:;
			}
			else
			{
				string text = A_0.ah();
				this.a = new af8(x5.a(0f));
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "none")
						{
							this.a.b(true);
							goto IL_129;
						}
						if (text2 == "inherit")
						{
							this.a.d(true);
							goto IL_129;
						}
					}
					this.a.b(true);
					IL_129:;
				}
				else
				{
					this.a.b(true);
				}
			}
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0008F8DC File Offset: 0x0008E8DC
		internal af8 a()
		{
			return this.a;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0008F8F4 File Offset: 0x0008E8F4
		internal void a(af8 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x0008F900 File Offset: 0x0008E900
		internal override int cv()
		{
			return 663362251;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x0008F918 File Offset: 0x0008E918
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x0400063D RID: 1597
		private new af8 a;
	}
}
