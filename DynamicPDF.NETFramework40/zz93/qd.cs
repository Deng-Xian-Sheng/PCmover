using System;

namespace zz93
{
	// Token: 0x0200026F RID: 623
	internal class qd : dy
	{
		// Token: 0x06001C04 RID: 7172 RVA: 0x00120F5C File Offset: 0x0011FF5C
		internal qd(char[] A_0, int A_1, int A_2, p1 A_3) : base(A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x00120FBA File Offset: 0x0011FFBA
		internal qd(p1 A_0) : base(A_0)
		{
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x00120FF8 File Offset: 0x0011FFF8
		internal bool a()
		{
			return this.b - 1 >= 0 && this.a[this.b - 1] == ' ';
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x00121030 File Offset: 0x00120030
		internal bool b()
		{
			return this.c - this.b + 1 <= this.a.Length && this.a[this.c - this.b + 1] == ' ';
		}

		// Token: 0x06001C08 RID: 7176 RVA: 0x00121080 File Offset: 0x00120080
		internal char[] c()
		{
			return this.a;
		}

		// Token: 0x06001C09 RID: 7177 RVA: 0x00121098 File Offset: 0x00120098
		internal int d()
		{
			return this.b;
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x001210B0 File Offset: 0x001200B0
		internal int e()
		{
			return this.c;
		}

		// Token: 0x06001C0B RID: 7179 RVA: 0x001210C8 File Offset: 0x001200C8
		internal bool f()
		{
			return this.d;
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x001210E0 File Offset: 0x001200E0
		internal void a(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001C0D RID: 7181 RVA: 0x001210EC File Offset: 0x001200EC
		internal bool g()
		{
			return this.e;
		}

		// Token: 0x06001C0E RID: 7182 RVA: 0x00121104 File Offset: 0x00120104
		internal void b(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x00121110 File Offset: 0x00120110
		internal bool h()
		{
			return this.f;
		}

		// Token: 0x06001C10 RID: 7184 RVA: 0x00121128 File Offset: 0x00120128
		internal void c(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x00121134 File Offset: 0x00120134
		internal bool i()
		{
			return this.g;
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x0012114C File Offset: 0x0012014C
		internal void d(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x00121158 File Offset: 0x00120158
		internal override kz cm(ij A_0, kz A_1)
		{
			if (A_1.b1())
			{
				if (this.a[this.b] == ' ')
				{
					this.b++;
					this.c--;
				}
			}
			else if (this.a())
			{
				this.b--;
				this.c++;
			}
			n3 n = new n3(this.a, this.b, this.c, A_0);
			n.h(this.g);
			n.e(this.f);
			n.j(A_1);
			n.dc(A_1.db());
			return n;
		}

		// Token: 0x04000CA3 RID: 3235
		private new char[] a = null;

		// Token: 0x04000CA4 RID: 3236
		private int b = 0;

		// Token: 0x04000CA5 RID: 3237
		private int c = 0;

		// Token: 0x04000CA6 RID: 3238
		private new bool d = false;

		// Token: 0x04000CA7 RID: 3239
		private new bool e = false;

		// Token: 0x04000CA8 RID: 3240
		private new bool f = false;

		// Token: 0x04000CA9 RID: 3241
		private new bool g = false;
	}
}
