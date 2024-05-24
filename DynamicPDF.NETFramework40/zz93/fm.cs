using System;

namespace zz93
{
	// Token: 0x020000EA RID: 234
	internal class fm : fd
	{
		// Token: 0x06000A56 RID: 2646 RVA: 0x000845EC File Offset: 0x000835EC
		internal fm(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00084600 File Offset: 0x00083600
		internal override void cw(gi A_0)
		{
			if (A_0.am())
			{
				this.a = new fb<fo>[4];
				string[] array = A_0.an();
				this.a[0] = new fb<fo>(136794, new fo(m4.a(new h2(A_0.a(array[0])))));
				this.a[1] = new fb<fo>(448574430, new fo(m4.a(new h2(A_0.a(array[1])))));
				this.a[2] = new fb<fo>(426354259, new fo(m4.a(new h2(A_0.a(array[2])))));
				this.a[3] = new fb<fo>(7021096, new fo(m4.a(new h2(A_0.a(array[3])))));
			}
			else if (string.Compare(A_0.ah(), "auto", true) == 0)
			{
				string text = A_0.ah();
				fo fo = new fo(x5.a(0f));
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (!(text2 == "auto"))
						{
							if (text2 == "inherit")
							{
								fo.d(true);
								this.a[0] = new fb<fo>(136794, fo);
								this.a[1] = new fb<fo>(448574430, fo);
								this.a[2] = new fb<fo>(426354259, fo);
								this.a[3] = new fb<fo>(7021096, fo);
							}
						}
						else
						{
							fo.a(true);
							this.a[0] = new fb<fo>(136794, fo);
							this.a[1] = new fb<fo>(448574430, fo);
							this.a[2] = new fb<fo>(426354259, fo);
							this.a[3] = new fb<fo>(7021096, fo);
						}
					}
				}
				else
				{
					A_0.ao();
				}
			}
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0008487C File Offset: 0x0008387C
		internal fb<fo>[] a()
		{
			return this.a;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00084894 File Offset: 0x00083894
		internal override int cv()
		{
			return 8714757;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x000848AB File Offset: 0x000838AB
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x04000516 RID: 1302
		private new fb<fo>[] a;
	}
}
