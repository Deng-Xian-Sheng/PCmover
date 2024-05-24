using System;

namespace zz93
{
	// Token: 0x0200012A RID: 298
	internal class he : fd
	{
		// Token: 0x06000B70 RID: 2928 RVA: 0x0008C129 File Offset: 0x0008B129
		internal he(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0008C13C File Offset: 0x0008B13C
		internal override void cw(gi A_0)
		{
			if (A_0.ay())
			{
				string text = A_0.au().Trim();
				this.a = new f2(m4.a(new h2(A_0.a(text))));
			}
			else
			{
				string text = A_0.ah();
				this.a = new f2(x5.a(0f));
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "none")
						{
							this.a.a(true);
							goto IL_B8;
						}
						if (text2 == "inherit")
						{
							this.a.d(true);
							goto IL_B8;
						}
					}
					this.a.a(true);
					IL_B8:;
				}
				else
				{
					this.a.a(true);
				}
			}
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0008C214 File Offset: 0x0008B214
		internal f2 a()
		{
			return this.a;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0008C22C File Offset: 0x0008B22C
		internal override int cv()
		{
			return 1688661191;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0008C244 File Offset: 0x0008B244
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x0400061C RID: 1564
		private new f2 a;
	}
}
