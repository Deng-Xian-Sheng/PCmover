using System;

namespace zz93
{
	// Token: 0x0200012D RID: 301
	internal class hh : fd
	{
		// Token: 0x06000B7F RID: 2943 RVA: 0x0008C877 File Offset: 0x0008B877
		internal hh()
		{
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0008C882 File Offset: 0x0008B882
		internal hh(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0008C898 File Offset: 0x0008B898
		internal override void cw(gi A_0)
		{
			string text = A_0.au();
			if (text != null)
			{
				text = text.Trim();
				if (char.IsNumber(text[0]) || text[0] == '+' || text[0] == '-')
				{
					i4 a_ = A_0.a(text);
					this.a = new f9(m4.a(new h2(a_)));
					i2 i = a_.b();
					if (i != i2.b)
					{
						switch (i)
						{
						case i2.f:
						case i2.h:
							this.a.a(a_.b());
							goto IL_D6;
						}
						this.a.a(i2.d);
					}
					else
					{
						this.a.a(true);
						this.a.a(a_.b());
					}
					IL_D6:;
				}
				else
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (!(text2 == "auto"))
						{
							if (text2 == "inherit")
							{
								this.a = new f9(x5.a(0f));
								this.a.d(true);
							}
						}
						else
						{
							this.a = new f9(x5.a(0f));
							this.a.b(true);
						}
					}
				}
			}
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0008C9F8 File Offset: 0x0008B9F8
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0008CA10 File Offset: 0x0008BA10
		internal void a(f9 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0008CA1C File Offset: 0x0008BA1C
		internal override int cv()
		{
			return 791474715;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0008CA34 File Offset: 0x0008BA34
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000622 RID: 1570
		private new f9 a;
	}
}
