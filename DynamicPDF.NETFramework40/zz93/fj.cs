using System;

namespace zz93
{
	// Token: 0x020000E7 RID: 231
	internal class fj : fd
	{
		// Token: 0x06000A45 RID: 2629 RVA: 0x0008425B File Offset: 0x0008325B
		internal fj(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00084270 File Offset: 0x00083270
		internal f9 a()
		{
			return this.a;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00084288 File Offset: 0x00083288
		internal void a(f9 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00084294 File Offset: 0x00083294
		internal override int cv()
		{
			return 426354259;
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x000842AC File Offset: 0x000832AC
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000842C4 File Offset: 0x000832C4
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

		// Token: 0x04000513 RID: 1299
		private new f9 a;
	}
}
