using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x0200043C RID: 1084
	internal class aca
	{
		// Token: 0x06002CD2 RID: 11474 RVA: 0x001985C0 File Offset: 0x001975C0
		internal aca()
		{
			this.a = new ab9[this.c];
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x001985EC File Offset: 0x001975EC
		internal void a(ab9 A_0)
		{
			if (A_0 != null)
			{
				if (this.b == this.a.Length)
				{
					ab9[] array = new ab9[this.c];
					this.a.CopyTo(array, 0);
					this.a = array;
				}
				this.a[this.b++] = A_0;
			}
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x0019865C File Offset: 0x0019765C
		internal void a(List<long> A_0)
		{
			this.a(this.a, 0L, (long)(this.b - 1));
			int num = A_0.Count - 1;
			long num2 = A_0[num--];
			long num3 = 0L;
			long num4 = A_0[num];
			for (int i = this.b - 1; i >= 0; i--)
			{
				if (this.a[i].a() <= num4 && num >= 0)
				{
					num2 = num4;
					num--;
					if (num >= 0)
					{
						num4 = A_0[num];
					}
				}
				if (this.a[i].a() > 0L && num2 == this.a[i].a())
				{
					num2 = num3;
				}
				this.a[i].a(num2);
				num3 = num2;
				num2 = this.a[i].a();
			}
		}

		// Token: 0x06002CD5 RID: 11477 RVA: 0x00198758 File Offset: 0x00197758
		private void a(ab9[] A_0, long A_1, long A_2)
		{
			if (A_2 > A_1)
			{
				long num = A_1;
				long num2 = A_2;
				long num3 = (A_1 + A_2) / 2L;
				long num4 = A_0[(int)(checked((IntPtr)num3))].a();
				while (num <= num2)
				{
					while (A_0[(int)(checked((IntPtr)num))].a() < num4 && num < A_2)
					{
						num += 1L;
					}
					while (num4 < A_0[(int)(checked((IntPtr)num2))].a() && num2 > A_1)
					{
						num2 -= 1L;
					}
					if (num <= num2)
					{
						checked
						{
							ab9 ab = A_0[(int)((IntPtr)num)];
							A_0[(int)((IntPtr)num)] = A_0[(int)((IntPtr)num2)];
							A_0[(int)((IntPtr)num2)] = ab;
						}
						num += 1L;
						num2 -= 1L;
					}
				}
				if (A_1 < num2)
				{
					this.a(A_0, A_1, num2);
				}
				if (num < A_2)
				{
					this.a(A_0, num, A_2);
				}
			}
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x00198838 File Offset: 0x00197838
		internal void a(int A_0)
		{
			if (A_0 > this.c)
			{
				this.c = A_0;
			}
		}

		// Token: 0x0400150F RID: 5391
		private ab9[] a;

		// Token: 0x04001510 RID: 5392
		private int b = 0;

		// Token: 0x04001511 RID: 5393
		private int c = 8;
	}
}
