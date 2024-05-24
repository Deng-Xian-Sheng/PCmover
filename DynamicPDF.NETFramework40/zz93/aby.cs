using System;

namespace zz93
{
	// Token: 0x02000430 RID: 1072
	internal class aby
	{
		// Token: 0x06002C7E RID: 11390 RVA: 0x00196D19 File Offset: 0x00195D19
		internal aby(abd A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002C7F RID: 11391 RVA: 0x00196D2C File Offset: 0x00195D2C
		private void a()
		{
			if (this.b == null)
			{
				if (this.a != null && this.a.hy() != ag9.i)
				{
					if (this.a.hy() == ag9.e)
					{
						this.a((abe)this.a);
					}
					else
					{
						this.a((ab6)this.a);
					}
				}
			}
		}

		// Token: 0x06002C80 RID: 11392 RVA: 0x00196DAC File Offset: 0x00195DAC
		private void a(abe A_0)
		{
			byte[][] array = new byte[A_0.a()][];
			int num = 0;
			for (int i = 0; i < A_0.a(); i++)
			{
				afj afj = this.b((ab6)A_0.a(i));
				byte[] array2 = afj.j4();
				array[i] = array2;
				num += array2.Length;
			}
			this.b = new byte[num + A_0.a()];
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				Array.Copy(array[j], 0, this.b, num2, array[j].Length);
				num2 += array[j].Length;
				this.b[num2++] = 10;
			}
		}

		// Token: 0x06002C81 RID: 11393 RVA: 0x00196E6C File Offset: 0x00195E6C
		private afj b(ab6 A_0)
		{
			afj result;
			if (A_0 != null)
			{
				result = A_0.b().m().b(A_0).ia();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002C82 RID: 11394 RVA: 0x00196EA0 File Offset: 0x00195EA0
		private void a(ab6 A_0)
		{
			afj afj = this.b(A_0);
			if (afj != null)
			{
				this.b = afj.j4();
			}
		}

		// Token: 0x06002C83 RID: 11395 RVA: 0x00196ECC File Offset: 0x00195ECC
		internal byte[] b()
		{
			byte[] result;
			if (this.c != null)
			{
				result = this.c;
			}
			else
			{
				this.a();
				if (this.b != null)
				{
					aax aax = new aax();
					aax.a(this.b, 0, this.b.Length);
					aax.b();
					byte[] array = new byte[(int)((float)this.b.Length * 1.002f + 12f)];
					int num = aax.a(array);
					this.c = new byte[num];
					Array.Copy(array, 0, this.c, 0, num);
				}
				result = this.c;
			}
			return result;
		}

		// Token: 0x06002C84 RID: 11396 RVA: 0x00196F7C File Offset: 0x00195F7C
		internal byte[] c()
		{
			byte[] result;
			if (this.b != null)
			{
				result = this.b;
			}
			else
			{
				this.a();
				result = this.b;
			}
			return result;
		}

		// Token: 0x040014E9 RID: 5353
		private abd a;

		// Token: 0x040014EA RID: 5354
		private byte[] b;

		// Token: 0x040014EB RID: 5355
		private byte[] c;
	}
}
