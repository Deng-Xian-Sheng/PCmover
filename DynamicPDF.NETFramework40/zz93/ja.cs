using System;

namespace zz93
{
	// Token: 0x0200016E RID: 366
	internal class ja : fd
	{
		// Token: 0x06000D4B RID: 3403 RVA: 0x00098148 File Offset: 0x00097148
		internal ja()
		{
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00098153 File Offset: 0x00097153
		internal ja(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00098168 File Offset: 0x00097168
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

		// Token: 0x06000D4E RID: 3406 RVA: 0x000982C8 File Offset: 0x000972C8
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x000982E0 File Offset: 0x000972E0
		internal void a(f9 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x000982EC File Offset: 0x000972EC
		internal override int cv()
		{
			return 795562982;
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x00098304 File Offset: 0x00097304
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006C9 RID: 1737
		private new f9 a;
	}
}
