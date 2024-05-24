using System;

namespace zz93
{
	// Token: 0x020003A3 RID: 931
	internal class yd
	{
		// Token: 0x0600279F RID: 10143 RVA: 0x0016B828 File Offset: 0x0016A828
		internal yd(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060027A0 RID: 10144 RVA: 0x0016B850 File Offset: 0x0016A850
		internal int a()
		{
			this.b = this.c + this.d + 12;
			this.c = this.b;
			this.d = this.c();
			return this.c();
		}

		// Token: 0x060027A1 RID: 10145 RVA: 0x0016B898 File Offset: 0x0016A898
		internal int b()
		{
			this.b = 8;
			this.c = this.b;
			this.d = this.c();
			return this.c();
		}

		// Token: 0x060027A2 RID: 10146 RVA: 0x0016B8D0 File Offset: 0x0016A8D0
		internal int c()
		{
			return (int)this.a[this.b++] << 24 | (int)this.a[this.b++] << 16 | (int)this.a[this.b++] << 8 | (int)this.a[this.b++];
		}

		// Token: 0x060027A3 RID: 10147 RVA: 0x0016B950 File Offset: 0x0016A950
		internal byte d()
		{
			return this.a[this.b++];
		}

		// Token: 0x060027A4 RID: 10148 RVA: 0x0016B97C File Offset: 0x0016A97C
		internal byte[] e()
		{
			byte[] array = new byte[this.d];
			Array.Copy(this.a, this.c + 8, array, 0, this.d);
			return array;
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x0016B9B8 File Offset: 0x0016A9B8
		internal byte[] f()
		{
			while (this.a[this.b] != 0 || this.a[this.b + 1] != 0)
			{
				this.b++;
			}
			this.b += 2;
			byte[] array = new byte[this.d + 8 - (this.b - this.c)];
			Array.Copy(this.a, this.b, array, 0, array.Length);
			return array;
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x0016BA48 File Offset: 0x0016AA48
		internal int g()
		{
			return this.b;
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x0016BA60 File Offset: 0x0016AA60
		internal int h()
		{
			return this.d;
		}

		// Token: 0x04001127 RID: 4391
		private byte[] a;

		// Token: 0x04001128 RID: 4392
		private int b = 0;

		// Token: 0x04001129 RID: 4393
		private int c = 0;

		// Token: 0x0400112A RID: 4394
		private int d = 0;
	}
}
