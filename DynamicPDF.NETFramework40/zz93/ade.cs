using System;

namespace zz93
{
	// Token: 0x02000467 RID: 1127
	internal class ade
	{
		// Token: 0x06002EE5 RID: 12005 RVA: 0x001AAA08 File Offset: 0x001A9A08
		internal ade(byte A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002EE6 RID: 12006 RVA: 0x001AAA30 File Offset: 0x001A9A30
		internal void a(adf A_0)
		{
			adf[] array = new adf[this.d + 1];
			this.c.CopyTo(array, 0);
			this.c = array;
			this.c[this.d++] = A_0;
		}

		// Token: 0x06002EE7 RID: 12007 RVA: 0x001AAA7C File Offset: 0x001A9A7C
		internal void a(add A_0)
		{
			A_0.a(this.a);
			if (this.a == 0)
			{
				for (int i = 0; i < this.b.Length; i++)
				{
					A_0.b((int)this.b[i]);
				}
			}
			else if (this.a == 1)
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					A_0.b((int)this.c[i].a());
					A_0.a((byte)this.c[i].b());
				}
			}
			else
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					A_0.b((int)this.c[i].a());
					A_0.b((int)this.c[i].b());
				}
			}
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x001AAB70 File Offset: 0x001A9B70
		internal int a()
		{
			int result;
			if (this.a == 0 && this.b != null)
			{
				result = this.b.Length * 2 + 1;
			}
			else if ((this.a == 1 || this.a == 2) && this.c != null)
			{
				if (this.a == 1)
				{
					result = this.c.Length * 3 + 1;
				}
				else
				{
					result = this.c.Length * 4 + 1;
				}
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06002EE9 RID: 12009 RVA: 0x001AAC00 File Offset: 0x001A9C00
		internal int b()
		{
			int num = 0;
			if (this.a == 0)
			{
				if (this.b != null)
				{
					for (int i = 0; i < this.b.Length; i++)
					{
						if (num < (int)this.b[i])
						{
							num = (int)this.b[i];
						}
					}
				}
			}
			else if (this.c != null)
			{
				for (int i = 0; i < this.c.Length; i++)
				{
					if (num < (int)(this.c[i].a() + this.c[i].b()))
					{
						num = (int)(this.c[i].a() + this.c[i].b());
					}
				}
			}
			return num;
		}

		// Token: 0x06002EEA RID: 12010 RVA: 0x001AACD9 File Offset: 0x001A9CD9
		internal void a(byte A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002EEB RID: 12011 RVA: 0x001AACE4 File Offset: 0x001A9CE4
		internal int c()
		{
			return this.d;
		}

		// Token: 0x06002EEC RID: 12012 RVA: 0x001AACFC File Offset: 0x001A9CFC
		internal ushort[] d()
		{
			return this.b;
		}

		// Token: 0x06002EED RID: 12013 RVA: 0x001AAD14 File Offset: 0x001A9D14
		internal void a(ushort[] A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002EEE RID: 12014 RVA: 0x001AAD20 File Offset: 0x001A9D20
		internal adf[] e()
		{
			return this.c;
		}

		// Token: 0x0400164B RID: 5707
		private byte a;

		// Token: 0x0400164C RID: 5708
		private ushort[] b;

		// Token: 0x0400164D RID: 5709
		private adf[] c = new adf[0];

		// Token: 0x0400164E RID: 5710
		private int d = 0;
	}
}
