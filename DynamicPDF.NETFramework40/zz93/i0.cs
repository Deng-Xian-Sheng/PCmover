using System;

namespace zz93
{
	// Token: 0x02000164 RID: 356
	internal class i0 : fd
	{
		// Token: 0x06000D16 RID: 3350 RVA: 0x0009657C File Offset: 0x0009557C
		internal i0(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x00096590 File Offset: 0x00095590
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

		// Token: 0x06000D18 RID: 3352 RVA: 0x000966A0 File Offset: 0x000956A0
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x000966B8 File Offset: 0x000956B8
		internal override int cv()
		{
			return 136794;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000966D0 File Offset: 0x000956D0
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x040006AE RID: 1710
		private new f9 a;
	}
}
