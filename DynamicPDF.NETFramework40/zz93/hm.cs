using System;

namespace zz93
{
	// Token: 0x02000132 RID: 306
	internal class hm : fd
	{
		// Token: 0x06000BA6 RID: 2982 RVA: 0x0008DA50 File Offset: 0x0008CA50
		internal hm(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0008DA64 File Offset: 0x0008CA64
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

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0008DB74 File Offset: 0x0008CB74
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0008DB8C File Offset: 0x0008CB8C
		internal override int cv()
		{
			return 7021096;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0008DBA4 File Offset: 0x0008CBA4
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000630 RID: 1584
		private new f9 a;
	}
}
