using System;
using System.Text;

namespace zz93
{
	// Token: 0x02000476 RID: 1142
	internal class adt
	{
		// Token: 0x06002F53 RID: 12115 RVA: 0x001AD77C File Offset: 0x001AC77C
		internal adt()
		{
			this.a = new int[256];
			this.b = new byte[1024];
			this.a[this.c++] = 1;
		}

		// Token: 0x06002F54 RID: 12116 RVA: 0x001AD7CC File Offset: 0x001AC7CC
		internal adt(int A_0, int A_1)
		{
			this.a = new int[A_0 + 1];
			this.b = new byte[A_1];
			this.a[this.c++] = 1;
		}

		// Token: 0x06002F55 RID: 12117 RVA: 0x001AD818 File Offset: 0x001AC818
		internal void a(byte[] A_0, int A_1, int A_2)
		{
			this.a(A_2);
			Array.Copy(A_0, A_1, this.b, this.d, A_2);
			this.d += A_2;
			this.a[this.c++] = this.d + 1;
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x001AD871 File Offset: 0x001AC871
		internal void a(string A_0)
		{
			this.a(Encoding.ASCII.GetBytes(A_0), 0, A_0.Length);
		}

		// Token: 0x06002F57 RID: 12119 RVA: 0x001AD890 File Offset: 0x001AC890
		internal ads a()
		{
			ads ads = new ads();
			ads.a((ushort)(this.c - 1));
			if (ads.a() > 0)
			{
				if (this.a[this.c - 1] < 255)
				{
					ads.a(1);
				}
				else if (this.a[this.c - 1] < 65535)
				{
					ads.a(2);
				}
				else if (this.a[this.c - 1] < 1048575)
				{
					ads.a(3);
				}
				else
				{
					ads.a(4);
				}
				ads.a(new byte[this.c * (int)ads.c()]);
				for (int i = 0; i < this.c; i++)
				{
					ads.a(i, this.a[i]);
				}
				ads.b(new byte[this.d]);
				Array.Copy(this.b, 0, ads.d(), 0, this.d);
			}
			return ads;
		}

		// Token: 0x06002F58 RID: 12120 RVA: 0x001AD9B8 File Offset: 0x001AC9B8
		internal int b()
		{
			return this.c - 1;
		}

		// Token: 0x06002F59 RID: 12121 RVA: 0x001AD9D4 File Offset: 0x001AC9D4
		private void a(int A_0)
		{
			if (this.b.Length < this.d + A_0)
			{
				byte[] destinationArray = new byte[this.b.Length * 2 + A_0];
				Array.Copy(this.b, 0, destinationArray, 0, this.b.Length);
				this.b = destinationArray;
			}
			if (this.a.Length <= this.c)
			{
				int[] destinationArray2 = new int[this.a.Length + 256];
				Array.Copy(this.a, 0, destinationArray2, 0, this.c);
				this.a = destinationArray2;
			}
		}

		// Token: 0x04001688 RID: 5768
		private int[] a;

		// Token: 0x04001689 RID: 5769
		private byte[] b;

		// Token: 0x0400168A RID: 5770
		private int c;

		// Token: 0x0400168B RID: 5771
		private int d;
	}
}
