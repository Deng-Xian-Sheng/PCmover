using System;

namespace zz93
{
	// Token: 0x02000397 RID: 919
	internal class x2
	{
		// Token: 0x06002746 RID: 10054 RVA: 0x0016A359 File Offset: 0x00169359
		internal x2()
		{
		}

		// Token: 0x06002747 RID: 10055 RVA: 0x0016A38C File Offset: 0x0016938C
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

		// Token: 0x06002748 RID: 10056 RVA: 0x0016A3F8 File Offset: 0x001693F8
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06002749 RID: 10057 RVA: 0x0016A410 File Offset: 0x00169410
		internal bool b()
		{
			return this.c < this.b;
		}

		// Token: 0x0600274A RID: 10058 RVA: 0x0016A430 File Offset: 0x00169430
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

		// Token: 0x0600274B RID: 10059 RVA: 0x0016A49D File Offset: 0x0016949D
		internal void d()
		{
			this.c = this.d;
		}

		// Token: 0x0600274C RID: 10060 RVA: 0x0016A4AC File Offset: 0x001694AC
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

		// Token: 0x0600274D RID: 10061 RVA: 0x0016A500 File Offset: 0x00169500
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

		// Token: 0x0600274E RID: 10062 RVA: 0x0016A634 File Offset: 0x00169634
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

		// Token: 0x0600274F RID: 10063 RVA: 0x0016A6F0 File Offset: 0x001696F0
		internal void d(x5 A_0)
		{
			for (int i = this.c; i < this.b; i++)
			{
				x5[] array = this.a;
				int num = i;
				array[num] = x5.e(array[num], A_0);
			}
		}

		// Token: 0x06002750 RID: 10064 RVA: 0x0016A738 File Offset: 0x00169738
		internal void a(acm A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				x5[] array = this.a;
				int num = i;
				array[num] = x5.f(array[num], A_0.a().a(this.a[i]));
			}
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x0016A798 File Offset: 0x00169798
		internal void e()
		{
			if (!this.e)
			{
				this.a(0, this.b - 1);
				this.e = true;
			}
		}

		// Token: 0x06002752 RID: 10066 RVA: 0x0016A7CC File Offset: 0x001697CC
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

		// Token: 0x04001107 RID: 4359
		private x5[] a = new x5[2];

		// Token: 0x04001108 RID: 4360
		private int b = 0;

		// Token: 0x04001109 RID: 4361
		private int c = 0;

		// Token: 0x0400110A RID: 4362
		private int d = 0;

		// Token: 0x0400110B RID: 4363
		private bool e = false;
	}
}
