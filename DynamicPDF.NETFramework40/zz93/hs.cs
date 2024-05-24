using System;

namespace zz93
{
	// Token: 0x02000138 RID: 312
	internal class hs : fd
	{
		// Token: 0x06000BE3 RID: 3043 RVA: 0x0008F5C8 File Offset: 0x0008E5C8
		internal hs(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0008F5DC File Offset: 0x0008E5DC
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

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0008F728 File Offset: 0x0008E728
		internal af8 a()
		{
			return this.a;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x0008F740 File Offset: 0x0008E740
		internal void a(af8 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x0008F74C File Offset: 0x0008E74C
		internal override int cv()
		{
			return 445130693;
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x0008F764 File Offset: 0x0008E764
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x0400063C RID: 1596
		private new af8 a;
	}
}
