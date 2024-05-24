using System;
using System.Collections;

namespace zz93
{
	// Token: 0x0200003E RID: 62
	internal class a7
	{
		// Token: 0x06000257 RID: 599 RVA: 0x0003B8B0 File Offset: 0x0003A8B0
		internal a7(string A_0, bool A_1, a8 A_2)
		{
			this.a = A_0;
			this.d = A_2;
			if (A_1)
			{
				this.g();
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0003B8EC File Offset: 0x0003A8EC
		internal string h()
		{
			return this.a;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0003B904 File Offset: 0x0003A904
		internal int i()
		{
			int num = 0;
			num += this.a.Length * 14;
			if (this.d == a8.a)
			{
				num += 19;
			}
			else if (this.d == a8.b)
			{
				num += 8;
			}
			return num;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0003B958 File Offset: 0x0003A958
		internal BitArray j()
		{
			this.b = new BitArray(this.i(), true);
			this.c();
			foreach (char c in this.a)
			{
				this.a((byte)c);
			}
			this.d();
			return this.b;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0003B9C0 File Offset: 0x0003A9C0
		private void g()
		{
			int num = 0;
			for (int i = this.a.Length - 1; i >= 0; i--)
			{
				if ((byte)this.a[i] < 48 || (byte)this.a[i] > 57)
				{
					throw new ap("Invalid Code 2 of 5 barcode character, allows only digits");
				}
				if (i % 2 == 0)
				{
					num += int.Parse(this.a[i].ToString()) * 3;
				}
				else
				{
					num += int.Parse(this.a[i].ToString());
				}
			}
			int num2 = (num % 10 > 0) ? (10 - num % 10) : 0;
			this.a += num2.ToString();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0003BAA8 File Offset: 0x0003AAA8
		private void a(byte A_0)
		{
			switch (A_0)
			{
			case 48:
				this.f();
				this.f();
				this.e();
				this.e();
				this.f();
				break;
			case 49:
				this.e();
				this.f();
				this.f();
				this.f();
				this.e();
				break;
			case 50:
				this.f();
				this.e();
				this.f();
				this.f();
				this.e();
				break;
			case 51:
				this.e();
				this.e();
				this.f();
				this.f();
				this.f();
				break;
			case 52:
				this.f();
				this.f();
				this.e();
				this.f();
				this.e();
				break;
			case 53:
				this.e();
				this.f();
				this.e();
				this.f();
				this.f();
				break;
			case 54:
				this.f();
				this.e();
				this.e();
				this.f();
				this.f();
				break;
			case 55:
				this.f();
				this.f();
				this.f();
				this.e();
				this.e();
				break;
			case 56:
				this.e();
				this.f();
				this.f();
				this.e();
				this.f();
				break;
			case 57:
				this.f();
				this.e();
				this.f();
				this.e();
				this.f();
				break;
			default:
				throw new ap("Invalid Code 2 of 5 barcode character.");
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0003BC7D File Offset: 0x0003AC7D
		private void f()
		{
			this.a();
			this.b();
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0003BC90 File Offset: 0x0003AC90
		private void e()
		{
			for (int i = 0; i < 3; i++)
			{
				this.a();
			}
			this.b();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0003BCBC File Offset: 0x0003ACBC
		private void d()
		{
			switch (this.d)
			{
			case a8.a:
				this.e();
				this.f();
				this.a();
				this.a();
				this.a();
				break;
			case a8.b:
				this.a();
				this.a();
				this.b();
				this.a();
				break;
			default:
				throw new an("Wrong type for Standard25 barcode.");
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0003BD30 File Offset: 0x0003AD30
		private void c()
		{
			switch (this.d)
			{
			case a8.a:
				this.e();
				this.e();
				this.f();
				break;
			case a8.b:
				this.f();
				this.f();
				break;
			default:
				throw new an("Wrong type for Standard25 barcode.");
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0003BD87 File Offset: 0x0003AD87
		private void b()
		{
			this.b[this.c] = true;
			this.c++;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0003BDAB File Offset: 0x0003ADAB
		private void a()
		{
			this.b[this.c] = false;
			this.c++;
		}

		// Token: 0x04000196 RID: 406
		private string a;

		// Token: 0x04000197 RID: 407
		private BitArray b;

		// Token: 0x04000198 RID: 408
		private int c;

		// Token: 0x04000199 RID: 409
		private a8 d = a8.a;
	}
}
