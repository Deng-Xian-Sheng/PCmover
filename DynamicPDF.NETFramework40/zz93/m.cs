using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x0200000F RID: 15
	internal class m
	{
		// Token: 0x0600009C RID: 156 RVA: 0x0001CC19 File Offset: 0x0001BC19
		internal m(string A_0)
		{
			this.a = A_0;
			this.d();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0001CC34 File Offset: 0x0001BC34
		internal byte[] e()
		{
			return this.b;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0001CC4C File Offset: 0x0001BC4C
		internal BitArray f()
		{
			if (this.a.Length > 41)
			{
				throw new ap("Text length cannot exceed 41.");
			}
			this.c = new BitArray(this.g(), true);
			this.a();
			this.c();
			foreach (byte a_ in this.b)
			{
				this.a(a_);
				this.c();
			}
			this.a();
			return this.c;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0001CCE0 File Offset: 0x0001BCE0
		internal int g()
		{
			int num = 0;
			foreach (byte b in this.b)
			{
				if (b == 45 || b == 48 || b == 57)
				{
					num += 6;
				}
				else
				{
					num += 7;
				}
				num++;
			}
			num += 14;
			return num + 1;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0001CD50 File Offset: 0x0001BD50
		private void d()
		{
			bool flag = false;
			this.b = new byte[this.a.Length + 1];
			Encoding.ASCII.GetBytes(this.a).CopyTo(this.b, 0);
			this.b(this.b, ref flag);
			if (this.b.Length >= 10 || flag)
			{
				byte[] array = new byte[this.b.Length + 1];
				this.b.CopyTo(array, 0);
				this.a(array, ref flag);
				this.b = new byte[array.Length];
				array.CopyTo(this.b, 0);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0001CE04 File Offset: 0x0001BE04
		private void a(byte A_0)
		{
			switch (A_0)
			{
			case 45:
				this.b();
				this.c();
				this.b();
				this.b();
				this.c();
				this.b();
				return;
			case 48:
				this.b();
				this.c();
				this.b();
				this.c();
				this.b();
				this.b();
				return;
			case 49:
				this.b();
				this.b();
				this.c();
				this.b();
				this.c();
				this.b();
				this.b();
				return;
			case 50:
				this.b();
				this.c();
				this.c();
				this.b();
				this.c();
				this.b();
				this.b();
				return;
			case 51:
				this.b();
				this.b();
				this.c();
				this.c();
				this.b();
				this.c();
				this.b();
				return;
			case 52:
				this.b();
				this.c();
				this.b();
				this.b();
				this.c();
				this.b();
				this.b();
				return;
			case 53:
				this.b();
				this.b();
				this.c();
				this.b();
				this.b();
				this.c();
				this.b();
				return;
			case 54:
				this.b();
				this.c();
				this.c();
				this.b();
				this.b();
				this.c();
				this.b();
				return;
			case 55:
				this.b();
				this.c();
				this.b();
				this.c();
				this.c();
				this.b();
				this.b();
				return;
			case 56:
				this.b();
				this.b();
				this.c();
				this.b();
				this.c();
				this.c();
				this.b();
				return;
			case 57:
				this.b();
				this.b();
				this.c();
				this.b();
				this.c();
				this.b();
				return;
			}
			throw new ap("Invalid Code11 barcode characters.");
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0001D095 File Offset: 0x0001C095
		private void c()
		{
			this.c[this.d] = true;
			this.d++;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0001D0B9 File Offset: 0x0001C0B9
		private void b()
		{
			this.c[this.d] = false;
			this.d++;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0001D0DD File Offset: 0x0001C0DD
		private void a()
		{
			this.b();
			this.c();
			this.b();
			this.b();
			this.c();
			this.c();
			this.b();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0001D111 File Offset: 0x0001C111
		private void b(byte[] A_0, ref bool A_1)
		{
			A_0[A_0.Length - 1] = this.a(A_0, 10, ref A_1);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0001D125 File Offset: 0x0001C125
		private void a(byte[] A_0, ref bool A_1)
		{
			A_0[A_0.Length - 1] = this.a(A_0, 9, ref A_1);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0001D13C File Offset: 0x0001C13C
		private byte a(byte[] A_0, int A_1, ref bool A_2)
		{
			int num = 0;
			int num2 = 1;
			for (int i = A_0.Length - 2; i >= 0; i--)
			{
				if (num2 > A_1)
				{
					num2 = 1;
				}
				if (A_0[i] == 45)
				{
					num += 10 * num2;
				}
				else
				{
					num += (int)(A_0[i] - 48) * num2;
				}
				num2++;
			}
			int num3 = num % 11;
			byte b = (byte)(num3 + 48);
			byte result;
			if (b < 48 || b > 57)
			{
				A_2 = true;
				result = 45;
			}
			else
			{
				result = (byte)(num3 + 48);
			}
			return result;
		}

		// Token: 0x04000067 RID: 103
		private string a;

		// Token: 0x04000068 RID: 104
		private byte[] b;

		// Token: 0x04000069 RID: 105
		private BitArray c;

		// Token: 0x0400006A RID: 106
		private int d;
	}
}
