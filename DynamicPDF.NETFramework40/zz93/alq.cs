using System;

namespace zz93
{
	// Token: 0x0200059A RID: 1434
	internal class alq
	{
		// Token: 0x06003907 RID: 14599 RVA: 0x001EA33A File Offset: 0x001E933A
		internal alq(int A_0)
		{
			this.a = new char[A_0][];
			this.b = new int[A_0];
			this.c = new int[A_0];
		}

		// Token: 0x06003908 RID: 14600 RVA: 0x001EA36C File Offset: 0x001E936C
		internal void a(string A_0)
		{
			char[] array = A_0.ToCharArray();
			this.a[this.d] = array;
			this.b[this.d] = 0;
			this.c[this.d++] = array.Length;
			this.e += array.Length;
		}

		// Token: 0x06003909 RID: 14601 RVA: 0x001EA3C8 File Offset: 0x001E93C8
		internal void a(char[] A_0, int A_1, int A_2)
		{
			this.a[this.d] = A_0;
			this.b[this.d] = A_1;
			this.c[this.d++] = A_2;
			this.e += A_2;
		}

		// Token: 0x0600390A RID: 14602 RVA: 0x001EA41C File Offset: 0x001E941C
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

		// Token: 0x0600390B RID: 14603 RVA: 0x001EA484 File Offset: 0x001E9484
		internal int b()
		{
			return this.d;
		}

		// Token: 0x0600390C RID: 14604 RVA: 0x001EA49C File Offset: 0x001E949C
		internal void a(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x04001B2B RID: 6955
		private char[][] a;

		// Token: 0x04001B2C RID: 6956
		private int[] b;

		// Token: 0x04001B2D RID: 6957
		private int[] c;

		// Token: 0x04001B2E RID: 6958
		private int d;

		// Token: 0x04001B2F RID: 6959
		private int e;
	}
}
