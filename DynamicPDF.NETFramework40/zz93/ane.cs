using System;

namespace zz93
{
	// Token: 0x020005D8 RID: 1496
	internal class ane
	{
		// Token: 0x06003B47 RID: 15175 RVA: 0x001FBB42 File Offset: 0x001FAB42
		internal ane()
		{
		}

		// Token: 0x06003B48 RID: 15176 RVA: 0x001FBB78 File Offset: 0x001FAB78
		internal void a(x5 A_0)
		{
			if (this.a.Length == this.b)
			{
				x5[] array = new x5[this.b * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x06003B49 RID: 15177 RVA: 0x001FBBE4 File Offset: 0x001FABE4
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06003B4A RID: 15178 RVA: 0x001FBBFC File Offset: 0x001FABFC
		internal bool b()
		{
			return this.c < this.b;
		}

		// Token: 0x06003B4B RID: 15179 RVA: 0x001FBC1C File Offset: 0x001FAC1C
		internal x5 c()
		{
			if (!this.e)
			{
				this.e();
			}
			this.d = this.c;
			x5 result;
			if (this.c < this.b)
			{
				result = this.a[this.c++];
			}
			else
			{
				result = x5.b();
			}
			return result;
		}

		// Token: 0x06003B4C RID: 15180 RVA: 0x001FBC89 File Offset: 0x001FAC89
		internal void d()
		{
			this.c = this.d;
		}

		// Token: 0x06003B4D RID: 15181 RVA: 0x001FBC98 File Offset: 0x001FAC98
		internal x5 a(x5 A_0, bool A_1)
		{
			this.d = this.c;
			x5 x = this.b(A_0);
			if (x5.h(x, x5.a()) && A_1)
			{
				this.d();
				x = this.c(A_0);
			}
			return x;
		}

		// Token: 0x06003B4E RID: 15182 RVA: 0x001FBCEC File Offset: 0x001FACEC
		internal x5 b(x5 A_0)
		{
			while (this.c < this.b)
			{
				if (x5.b(this.a[this.c], A_0) && x5.a(this.a[this.c], x5.c()))
				{
					if (this.c + 1 >= this.b || !x5.b(this.a[this.c + 1], A_0))
					{
						break;
					}
					this.c++;
				}
				else
				{
					this.c++;
				}
			}
			x5 result;
			if (this.c < this.b && x5.b(this.a[this.c], A_0))
			{
				result = this.a[this.c++];
			}
			else
			{
				result = x5.a();
			}
			return result;
		}

		// Token: 0x06003B4F RID: 15183 RVA: 0x001FBE20 File Offset: 0x001FAE20
		internal x5 c(x5 A_0)
		{
			while (this.c < this.b)
			{
				if (x5.c(this.a[this.c], A_0))
				{
					break;
				}
				this.c++;
			}
			x5 result;
			if (this.c < this.b && x5.c(this.a[this.c], A_0))
			{
				result = this.a[this.c++];
			}
			else
			{
				result = x5.a();
			}
			return result;
		}

		// Token: 0x06003B50 RID: 15184 RVA: 0x001FBEDC File Offset: 0x001FAEDC
		internal void d(x5 A_0)
		{
			for (int i = this.c; i < this.b; i++)
			{
				x5[] array = this.a;
				int num = i;
				array[num] = x5.e(array[num], A_0);
			}
		}

		// Token: 0x06003B51 RID: 15185 RVA: 0x001FBF24 File Offset: 0x001FAF24
		internal void a(acm A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				x5[] array = this.a;
				int num = i;
				array[num] = x5.f(array[num], A_0.a().a(this.a[i]));
			}
		}

		// Token: 0x06003B52 RID: 15186 RVA: 0x001FBF84 File Offset: 0x001FAF84
		internal void e()
		{
			if (!this.e)
			{
				this.a(0, this.b - 1);
				this.e = true;
			}
		}

		// Token: 0x06003B53 RID: 15187 RVA: 0x001FBFB8 File Offset: 0x001FAFB8
		private void a(int A_0, int A_1)
		{
			if (A_1 > A_0)
			{
				int i = A_0;
				int num = A_1;
				int num2 = (A_0 + A_1) / 2;
				x5 x = this.a[num2];
				while (i <= num)
				{
					while (x5.d(this.a[i], x) && i < A_1)
					{
						i++;
					}
					while (x5.d(x, this.a[num]) && num > A_0)
					{
						num--;
					}
					if (i <= num)
					{
						x5 x2 = this.a[i];
						this.a[i] = this.a[num];
						this.a[num] = x2;
						i++;
						num--;
					}
				}
				if (A_0 < num)
				{
					this.a(A_0, num);
				}
				if (i < A_1)
				{
					this.a(i, A_1);
				}
			}
		}

		// Token: 0x04001BEA RID: 7146
		private x5[] a = new x5[2];

		// Token: 0x04001BEB RID: 7147
		private int b = 0;

		// Token: 0x04001BEC RID: 7148
		private int c = 0;

		// Token: 0x04001BED RID: 7149
		private int d = 0;

		// Token: 0x04001BEE RID: 7150
		private bool e = false;
	}
}
