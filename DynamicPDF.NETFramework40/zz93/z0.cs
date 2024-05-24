using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x020003E1 RID: 993
	[DefaultMember("Item")]
	internal class z0
	{
		// Token: 0x060029AC RID: 10668 RVA: 0x001855DF File Offset: 0x001845DF
		internal z0(int A_0)
		{
			this.a = new zz[A_0 * 4 + 10];
		}

		// Token: 0x060029AD RID: 10669 RVA: 0x00185604 File Offset: 0x00184604
		internal zz a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x00185620 File Offset: 0x00184620
		internal zz b(int A_0)
		{
			if (A_0 >= this.b)
			{
				this.b = A_0 + 1;
			}
			if (A_0 >= this.a.Length)
			{
				int num = this.a.Length * 2;
				while (A_0 >= num)
				{
					num *= 2;
				}
				zz[] array = new zz[num];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			if (this.a[A_0] == null)
			{
				this.a[A_0] = new zz(A_0);
			}
			return this.a[A_0];
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x001856BC File Offset: 0x001846BC
		internal z4 a(b3 A_0)
		{
			zz[] array = new zz[this.b];
			Array.Copy(this.a, 0, array, 0, this.b);
			this.a(array, 0, this.b - 1);
			return new z4(A_0, array);
		}

		// Token: 0x060029B0 RID: 10672 RVA: 0x00185708 File Offset: 0x00184708
		private void a(zz[] A_0, int A_1, int A_2)
		{
			if (A_2 > A_1)
			{
				int i = A_1;
				int num = A_2;
				int num2 = (A_1 + A_2) / 2;
				zz zz = A_0[num2];
				while (i <= num)
				{
					while (A_0[i].a(zz) && i < A_2)
					{
						i++;
					}
					while (zz.a(A_0[num]) && num > A_1)
					{
						num--;
					}
					if (i <= num)
					{
						zz zz2 = A_0[i];
						A_0[i] = A_0[num];
						A_0[num] = zz2;
						i++;
						num--;
					}
				}
				if (A_1 < num)
				{
					this.a(A_0, A_1, num);
				}
				if (i < A_2)
				{
					this.a(A_0, i, A_2);
				}
			}
		}

		// Token: 0x04001301 RID: 4865
		private zz[] a;

		// Token: 0x04001302 RID: 4866
		private int b = 0;
	}
}
