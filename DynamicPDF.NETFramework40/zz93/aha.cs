using System;

namespace zz93
{
	// Token: 0x020004F5 RID: 1269
	internal class aha : ag7
	{
		// Token: 0x060033D2 RID: 13266 RVA: 0x001CBD28 File Offset: 0x001CAD28
		internal aha(byte[] A_0, int A_1, int A_2, int A_3, abe A_4, abe A_5) : base(A_3, A_4, A_5, 1)
		{
			this.b = new byte[base.d()];
			this.a = new byte[base.d()];
			this.c = new aa4();
			this.c.a(A_0, A_1, A_2);
		}

		// Token: 0x060033D3 RID: 13267 RVA: 0x001CBD84 File Offset: 0x001CAD84
		protected override byte[] ls()
		{
			this.c.b(this.b, 0, this.b.Length);
			switch (this.b[0])
			{
			case 1:
				for (int i = 2; i < this.b.Length; i++)
				{
					byte[] array = this.b;
					int num = i;
					array[num] += this.b[i - 1];
				}
				break;
			case 2:
				for (int i = 1; i < this.b.Length; i++)
				{
					byte[] array2 = this.b;
					int num2 = i;
					array2[num2] += this.a[i];
				}
				break;
			case 3:
			{
				int i = 2;
				byte[] array3 = this.b;
				int num3 = 1;
				array3[num3] += this.a[1] / 2;
				while (i < this.b.Length)
				{
					byte[] array4 = this.b;
					int num4 = i;
					array4[num4] += (this.a[i] + this.b[i - 1]) / 2;
					i++;
				}
				break;
			}
			case 4:
			{
				int i = 2;
				byte[] array5 = this.b;
				int num5 = 1;
				array5[num5] += this.a(0, this.a[1], 0);
				while (i < this.b.Length)
				{
					byte[] array6 = this.b;
					int num6 = i;
					array6[num6] += this.a(this.b[i - 1], this.a[i], this.a[i - 1]);
					i++;
				}
				break;
			}
			}
			byte[] array7 = this.a;
			this.a = this.b;
			this.b = array7;
			return this.a;
		}

		// Token: 0x060033D4 RID: 13268 RVA: 0x001CBF74 File Offset: 0x001CAF74
		private byte a(byte A_0, byte A_1, byte A_2)
		{
			int num = (int)(A_0 + A_1 - A_2);
			int num2 = Math.Abs(num - (int)A_0);
			int num3 = Math.Abs(num - (int)A_1);
			int num4 = Math.Abs(num - (int)A_2);
			byte result;
			if (num2 <= num3 && num2 <= num4)
			{
				result = A_0;
			}
			else if (num3 <= num4)
			{
				result = A_1;
			}
			else
			{
				result = A_2;
			}
			return result;
		}

		// Token: 0x040018C8 RID: 6344
		private new byte[] a;

		// Token: 0x040018C9 RID: 6345
		private byte[] b;

		// Token: 0x040018CA RID: 6346
		private aa4 c;
	}
}
