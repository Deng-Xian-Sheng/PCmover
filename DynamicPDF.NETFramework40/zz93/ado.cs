using System;

namespace zz93
{
	// Token: 0x02000471 RID: 1137
	internal class ado
	{
		// Token: 0x06002F2A RID: 12074 RVA: 0x001ACD68 File Offset: 0x001ABD68
		internal ado(adn A_0, char A_1, int A_2)
		{
			this.g = A_0;
			this.a = (ushort)A_1;
			this.b = A_2;
			this.e = (short)A_0.e(A_2);
			int num = A_2 + 10;
			if (this.a())
			{
				this.d = new char[2];
				short num2 = 1;
				short num3 = 8;
				short num4 = 32;
				short num5 = 64;
				short num6 = 128;
				short num7;
				do
				{
					num7 = (short)A_0.e(num);
					short num8 = (short)A_0.e(num + 2);
					this.a((char)num8);
					if ((num7 & num2) == num2)
					{
						num += 8;
					}
					else
					{
						num += 6;
					}
					if ((num7 & num3) == num3)
					{
						num += 2;
					}
					else if ((num7 & num5) == num5)
					{
						num += 4;
					}
					else if ((num7 & num6) == num6)
					{
						num += 8;
					}
				}
				while ((num7 & num4) == num4);
			}
		}

		// Token: 0x06002F2B RID: 12075 RVA: 0x001ACE7C File Offset: 0x001ABE7C
		private void a(char A_0)
		{
			if ((int)this.f >= this.d.Length)
			{
				char[] array = new char[this.d.Length * 2];
				this.d.CopyTo(array, 0);
				this.d = array;
			}
			char[] array2 = this.d;
			short num;
			this.f = (num = this.f) + 1;
			array2[(int)num] = A_0;
		}

		// Token: 0x06002F2C RID: 12076 RVA: 0x001ACEE0 File Offset: 0x001ABEE0
		internal bool a()
		{
			return this.e < 0;
		}

		// Token: 0x06002F2D RID: 12077 RVA: 0x001ACEFC File Offset: 0x001ABEFC
		internal void a(bool[] A_0)
		{
			for (int i = 0; i < (int)this.f; i++)
			{
				ado ado = this.g.a()[(int)this.d[i]];
				A_0[(int)this.d[i]] = true;
				ado.a(A_0);
			}
		}

		// Token: 0x06002F2E RID: 12078 RVA: 0x001ACF4C File Offset: 0x001ABF4C
		internal ushort b()
		{
			return this.a;
		}

		// Token: 0x06002F2F RID: 12079 RVA: 0x001ACF64 File Offset: 0x001ABF64
		internal int c()
		{
			return this.b;
		}

		// Token: 0x06002F30 RID: 12080 RVA: 0x001ACF7C File Offset: 0x001ABF7C
		internal int d()
		{
			return this.c;
		}

		// Token: 0x06002F31 RID: 12081 RVA: 0x001ACF94 File Offset: 0x001ABF94
		internal void a(int A_0)
		{
			this.c = A_0 - this.b;
		}

		// Token: 0x0400166F RID: 5743
		private ushort a;

		// Token: 0x04001670 RID: 5744
		private int b;

		// Token: 0x04001671 RID: 5745
		private int c;

		// Token: 0x04001672 RID: 5746
		private char[] d;

		// Token: 0x04001673 RID: 5747
		private short e;

		// Token: 0x04001674 RID: 5748
		private short f = 0;

		// Token: 0x04001675 RID: 5749
		private adn g;
	}
}
