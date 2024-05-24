using System;

namespace zz93
{
	// Token: 0x020003A2 RID: 930
	internal class yc
	{
		// Token: 0x06002793 RID: 10131 RVA: 0x0016B487 File Offset: 0x0016A487
		internal yc(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002794 RID: 10132 RVA: 0x0016B4B0 File Offset: 0x0016A4B0
		internal int a()
		{
			this.b = this.c + this.d;
			this.b++;
			while (this.a[this.b] == 255 || this.a[this.b] == 0)
			{
				this.b++;
			}
			int result = (int)this.a[this.b++];
			this.c = this.b;
			this.d = this.b();
			return result;
		}

		// Token: 0x06002795 RID: 10133 RVA: 0x0016B554 File Offset: 0x0016A554
		internal int b()
		{
			return (int)this.a[this.b++] << 8 | (int)this.a[this.b++];
		}

		// Token: 0x06002796 RID: 10134 RVA: 0x0016B59C File Offset: 0x0016A59C
		internal byte c()
		{
			return this.a[this.b++];
		}

		// Token: 0x06002797 RID: 10135 RVA: 0x0016B5C6 File Offset: 0x0016A5C6
		internal void a(int A_0)
		{
			this.b += A_0;
		}

		// Token: 0x06002798 RID: 10136 RVA: 0x0016B5D8 File Offset: 0x0016A5D8
		internal int d()
		{
			return (int)this.a[this.b++] << 24 | (int)this.a[this.b++] << 16 | (int)this.a[this.b++] << 8 | (int)this.a[this.b++];
		}

		// Token: 0x06002799 RID: 10137 RVA: 0x0016B658 File Offset: 0x0016A658
		internal int e()
		{
			return (int)this.a[this.b++] | (int)this.a[this.b++] << 8;
		}

		// Token: 0x0600279A RID: 10138 RVA: 0x0016B6A0 File Offset: 0x0016A6A0
		internal int f()
		{
			return (int)this.a[this.b++] | (int)this.a[this.b++] << 8 | (int)this.a[this.b++] << 16 | (int)this.a[this.b++] << 24;
		}

		// Token: 0x0600279B RID: 10139 RVA: 0x0016B720 File Offset: 0x0016A720
		internal byte[] a(uint A_0, bk[] A_1)
		{
			byte[] array = new byte[A_0];
			int num = 0;
			for (int i = 0; i < A_1.Length; i++)
			{
				Array.Copy(this.a, A_1[i].a() + 16, array, num, A_1[i].b() - 16);
				num += A_1[i].b() - 16;
			}
			return array;
		}

		// Token: 0x0600279C RID: 10140 RVA: 0x0016B788 File Offset: 0x0016A788
		internal byte[] a(int A_0, bool A_1)
		{
			int num = this.b;
			this.b += A_0;
			int num2;
			if (A_1)
			{
				num2 = this.e();
			}
			else
			{
				num2 = this.b();
			}
			byte[] array = new byte[num2 * 12];
			Array.Copy(this.a, this.b, array, 0, array.Length);
			this.b = num;
			return array;
		}

		// Token: 0x0600279D RID: 10141 RVA: 0x0016B7F8 File Offset: 0x0016A7F8
		internal int g()
		{
			return this.d;
		}

		// Token: 0x0600279E RID: 10142 RVA: 0x0016B810 File Offset: 0x0016A810
		internal int h()
		{
			return this.c;
		}

		// Token: 0x04001123 RID: 4387
		private byte[] a;

		// Token: 0x04001124 RID: 4388
		private int b = 0;

		// Token: 0x04001125 RID: 4389
		private int c = 2;

		// Token: 0x04001126 RID: 4390
		private int d = 0;
	}
}
