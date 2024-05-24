using System;

namespace zz93
{
	// Token: 0x02000134 RID: 308
	internal class ho : fd
	{
		// Token: 0x06000BB0 RID: 2992 RVA: 0x0008DD08 File Offset: 0x0008CD08
		internal ho()
		{
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0008DD13 File Offset: 0x0008CD13
		internal ho(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0008DD28 File Offset: 0x0008CD28
		internal override void cw(gi A_0)
		{
			string text = A_0.au();
			if (text != null)
			{
				text.Trim();
				if (char.IsNumber(text[0]) || text[0] == '+' || text[0] == '-')
				{
					i4 a_ = A_0.a(text);
					if (a_.a() < 0f)
					{
						this.a = new afz(x5.a(0f));
					}
					else if (a_.b() != i2.a)
					{
						this.a = new afz(m4.a(new h2(a_)));
						if (a_.b() == i2.b)
						{
							this.a.b(true);
						}
						this.a.a(a_.b());
					}
					else
					{
						this.a = new afz(x5.a(a_.a()));
						this.a.c(true);
					}
				}
				else if (text != null)
				{
					this.a = new afz(x5.a(0f));
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "normal")
						{
							this.a = new afz(x5.a(1f));
							this.a.a(true);
							goto IL_1B0;
						}
						if (text2 == "inherit")
						{
							this.a = new afz(x5.a(1f));
							this.a.d(true);
							goto IL_1B0;
						}
					}
					this.a.a(true);
					IL_1B0:;
				}
			}
			else
			{
				this.a = new afz(x5.a(0f));
				this.a.a(true);
			}
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0008DF10 File Offset: 0x0008CF10
		internal afz a()
		{
			return this.a;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0008DF28 File Offset: 0x0008CF28
		internal void a(afz A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0008DF34 File Offset: 0x0008CF34
		internal override int cv()
		{
			return 1652275116;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0008DF4C File Offset: 0x0008CF4C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000632 RID: 1586
		private new afz a;
	}
}
