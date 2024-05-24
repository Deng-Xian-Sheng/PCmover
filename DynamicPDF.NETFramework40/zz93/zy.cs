using System;
using System.IO;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020003DF RID: 991
	internal class zy
	{
		// Token: 0x06002985 RID: 10629 RVA: 0x00184700 File Offset: 0x00183700
		internal zy()
		{
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x00184740 File Offset: 0x00183740
		internal void a(int A_0)
		{
			this.c[this.f] = (byte)(A_0 >> 24);
			this.c();
			this.c[this.f] = (byte)(A_0 >> 16);
			this.c();
			this.c[this.f] = (byte)(A_0 >> 8);
			this.c();
			this.c[this.f] = (byte)A_0;
			this.c();
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x001847AE File Offset: 0x001837AE
		internal void b(int A_0)
		{
			this.c[this.f] = (byte)(A_0 >> 8);
			this.c();
			this.c[this.f] = (byte)A_0;
			this.c();
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x001847E0 File Offset: 0x001837E0
		internal int d()
		{
			return this.h + this.f;
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x00184800 File Offset: 0x00183800
		internal void c(int A_0)
		{
			for (int i = 0; i < A_0; i++)
			{
				this.c();
			}
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x00184828 File Offset: 0x00183828
		private void c()
		{
			this.f++;
			if (this.f == this.c.Length)
			{
				if (this.e == this.d.Length)
				{
					byte[][] array = new byte[this.d.Length * 3][];
					this.d.CopyTo(array, 0);
					this.d = array;
				}
				this.h += this.c.Length;
				this.d[this.e++] = this.c;
				this.c = new byte[this.c.Length + 64];
				this.f = 0;
			}
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x001848F0 File Offset: 0x001838F0
		internal void e()
		{
			if (this.g != 0)
			{
				this.g = 0;
				this.c();
			}
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x0018491C File Offset: 0x0018391C
		internal int a(int A_0, int A_1)
		{
			return this.d(A_1 - A_0);
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x00184938 File Offset: 0x00183938
		internal int d(int A_0)
		{
			int result;
			if (A_0 < 1)
			{
				result = 0;
			}
			else if (A_0 < 2)
			{
				result = 1;
			}
			else if (A_0 < 4)
			{
				result = 2;
			}
			else if (A_0 < 8)
			{
				result = 3;
			}
			else if (A_0 < 16)
			{
				result = 4;
			}
			else if (A_0 < 32)
			{
				result = 5;
			}
			else if (A_0 < 64)
			{
				result = 6;
			}
			else if (A_0 < 128)
			{
				result = 7;
			}
			else if (A_0 < 256)
			{
				result = 8;
			}
			else if (A_0 < 512)
			{
				result = 9;
			}
			else if (A_0 < 1024)
			{
				result = 10;
			}
			else if (A_0 < 2048)
			{
				result = 11;
			}
			else if (A_0 < 4096)
			{
				result = 12;
			}
			else if (A_0 < 8192)
			{
				result = 13;
			}
			else if (A_0 < 16384)
			{
				result = 14;
			}
			else if (A_0 < 32768)
			{
				result = 15;
			}
			else if (A_0 < 65536)
			{
				result = 16;
			}
			else if (A_0 < 131072)
			{
				result = 17;
			}
			else if (A_0 < 262144)
			{
				result = 18;
			}
			else if (A_0 < 524288)
			{
				result = 19;
			}
			else if (A_0 < 1048576)
			{
				result = 20;
			}
			else if (A_0 < 2097152)
			{
				result = 21;
			}
			else if (A_0 < 4194304)
			{
				result = 22;
			}
			else if (A_0 < 8388608)
			{
				result = 23;
			}
			else if (A_0 < 16777216)
			{
				result = 24;
			}
			else if (A_0 < 33554432)
			{
				result = 25;
			}
			else if (A_0 < 67108864)
			{
				result = 26;
			}
			else if (A_0 < 134217728)
			{
				result = 27;
			}
			else if (A_0 < 268435456)
			{
				result = 28;
			}
			else if (A_0 < 536870912)
			{
				result = 29;
			}
			else if (A_0 < 1073741824)
			{
				result = 30;
			}
			else
			{
				if (A_0 > 2147483647)
				{
					throw new GeneratorException("Lineraization differance range is too large.");
				}
				result = 31;
			}
			return result;
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x00184BFC File Offset: 0x00183BFC
		internal void b(int A_0, int A_1)
		{
			int num;
			switch (A_1)
			{
			case 0:
				return;
			case 1:
				num = 1;
				break;
			case 2:
				num = 2;
				break;
			case 3:
				num = 4;
				break;
			case 4:
				num = 8;
				break;
			case 5:
				num = 16;
				break;
			case 6:
				num = 32;
				break;
			case 7:
				num = 64;
				break;
			case 8:
				num = 128;
				break;
			case 9:
				num = 256;
				break;
			case 10:
				num = 512;
				break;
			case 11:
				num = 1024;
				break;
			case 12:
				num = 2048;
				break;
			case 13:
				num = 4096;
				break;
			case 14:
				num = 8192;
				break;
			case 15:
				num = 16384;
				break;
			case 16:
				num = 32768;
				break;
			case 17:
				num = 65536;
				break;
			case 18:
				num = 131072;
				break;
			case 19:
				num = 262144;
				break;
			case 20:
				num = 524288;
				break;
			case 21:
				num = 1048576;
				break;
			case 22:
				num = 2097152;
				break;
			case 23:
				num = 4194304;
				break;
			case 24:
				num = 8388608;
				break;
			case 25:
				num = 16777216;
				break;
			case 26:
				num = 33554432;
				break;
			case 27:
				num = 67108864;
				break;
			case 28:
				num = 134217728;
				break;
			case 29:
				num = 268435456;
				break;
			case 30:
				num = 536870912;
				break;
			case 31:
				num = 1073741824;
				break;
			default:
				throw new GeneratorException("Invalid Hint Table Bits Length.");
			}
			for (int i = 0; i < A_1; i++)
			{
				int num2 = A_0 - num;
				if (num2 >= 0)
				{
					A_0 = num2;
					this.b();
				}
				else
				{
					this.a();
				}
				num /= 2;
			}
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x00184DF4 File Offset: 0x00183DF4
		private void b()
		{
			switch (this.g)
			{
			case 0:
			{
				byte[] array = this.c;
				int num = this.f;
				array[num] |= 128;
				this.g++;
				break;
			}
			case 1:
			{
				byte[] array2 = this.c;
				int num2 = this.f;
				array2[num2] |= 64;
				this.g++;
				break;
			}
			case 2:
			{
				byte[] array3 = this.c;
				int num3 = this.f;
				array3[num3] |= 32;
				this.g++;
				break;
			}
			case 3:
			{
				byte[] array4 = this.c;
				int num4 = this.f;
				array4[num4] |= 16;
				this.g++;
				break;
			}
			case 4:
			{
				byte[] array5 = this.c;
				int num5 = this.f;
				array5[num5] |= 8;
				this.g++;
				break;
			}
			case 5:
			{
				byte[] array6 = this.c;
				int num6 = this.f;
				array6[num6] |= 4;
				this.g++;
				break;
			}
			case 6:
			{
				byte[] array7 = this.c;
				int num7 = this.f;
				array7[num7] |= 2;
				this.g++;
				break;
			}
			default:
			{
				byte[] array8 = this.c;
				int num8 = this.f;
				array8[num8] |= 1;
				this.g = 0;
				this.c();
				break;
			}
			}
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x00184FC0 File Offset: 0x00183FC0
		private void a()
		{
			this.g++;
			if (this.g == 8)
			{
				this.g = 0;
				this.c();
			}
		}

		// Token: 0x06002991 RID: 10641 RVA: 0x00184FFC File Offset: 0x00183FFC
		internal void a(Stream A_0)
		{
			for (int i = 0; i < this.e; i++)
			{
				A_0.Write(this.d[i], 0, this.d[i].Length);
			}
			A_0.Write(this.c, 0, this.f);
		}

		// Token: 0x040012E6 RID: 4838
		private const int a = 64;

		// Token: 0x040012E7 RID: 4839
		private const int b = 64;

		// Token: 0x040012E8 RID: 4840
		private byte[] c = new byte[64];

		// Token: 0x040012E9 RID: 4841
		private byte[][] d = new byte[3][];

		// Token: 0x040012EA RID: 4842
		private int e = 0;

		// Token: 0x040012EB RID: 4843
		private int f = 0;

		// Token: 0x040012EC RID: 4844
		private int g = 0;

		// Token: 0x040012ED RID: 4845
		private int h = 0;
	}
}
