using System;

namespace zz93
{
	// Token: 0x02000366 RID: 870
	internal class wt
	{
		// Token: 0x06002535 RID: 9525 RVA: 0x0015CD26 File Offset: 0x0015BD26
		internal wt(int A_0)
		{
			this.a = new char[A_0][];
			this.b = new int[A_0];
			this.c = new int[A_0];
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x0015CD58 File Offset: 0x0015BD58
		internal void a(string A_0)
		{
			char[] array = A_0.ToCharArray();
			this.a[this.d] = array;
			this.b[this.d] = 0;
			this.c[this.d++] = array.Length;
			this.e += array.Length;
		}

		// Token: 0x06002537 RID: 9527 RVA: 0x0015CDB4 File Offset: 0x0015BDB4
		internal void a(char[] A_0, int A_1, int A_2)
		{
			this.a[this.d] = A_0;
			this.b[this.d] = A_1;
			this.c[this.d++] = A_2;
			this.e += A_2;
		}

		// Token: 0x06002538 RID: 9528 RVA: 0x0015CE08 File Offset: 0x0015BE08
		internal char[] a()
		{
			char[] array = new char[this.e];
			int num = 0;
			for (int i = 0; i < this.d; i++)
			{
				Array.Copy(this.a[i], this.b[i], array, num, this.c[i]);
				num += this.c[i];
			}
			return array;
		}

		// Token: 0x06002539 RID: 9529 RVA: 0x0015CE70 File Offset: 0x0015BE70
		internal int b()
		{
			return this.d;
		}

		// Token: 0x0600253A RID: 9530 RVA: 0x0015CE88 File Offset: 0x0015BE88
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x0400104D RID: 4173
		private char[][] a;

		// Token: 0x0400104E RID: 4174
		private int[] b;

		// Token: 0x0400104F RID: 4175
		private int[] c;

		// Token: 0x04001050 RID: 4176
		private int d;

		// Token: 0x04001051 RID: 4177
		private int e;
	}
}
