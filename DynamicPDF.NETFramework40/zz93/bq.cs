using System;
using System.IO;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000052 RID: 82
	internal class bq : bp
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x0003E35B File Offset: 0x0003D35B
		internal bq(br A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0003E37C File Offset: 0x0003D37C
		internal override bool o()
		{
			return false;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0003E390 File Offset: 0x0003D390
		internal override void p(Stream A_0)
		{
			if (this.a.b() - this.b >= this.c)
			{
				A_0.Write(this.a.a(), this.b, this.c);
			}
			else
			{
				int num = this.a.b() - this.b;
				A_0.Write(this.a.a(), this.b, num);
				br br = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (br.b() < num2)
					{
						num2 = br.b();
					}
					A_0.Write(br.a(), 0, num2);
					num += num2;
					br = br.c();
				}
				while (num < this.c);
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0003E468 File Offset: 0x0003D468
		internal override void q(Stream A_0, Encrypter A_1)
		{
			if (this.a.b() - this.b >= this.c)
			{
				A_1.Encrypt(A_0, this.a.a(), this.b, this.c);
			}
			else if (A_1 is bz || A_1 is b0)
			{
				byte[] array = new byte[this.c];
				int num = this.a.b() - this.b;
				Array.Copy(this.a.a(), this.b, array, 0, num);
				br br = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (br.b() < num2)
					{
						num2 = br.b();
					}
					Array.Copy(br.a(), 0, array, num, num2);
					num += num2;
					br = br.c();
				}
				while (num < this.c);
				A_1.Encrypt(A_0, array, 0, this.c);
			}
			else
			{
				int num = this.a.b() - this.b;
				A_1.Encrypt(A_0, this.a.a(), this.b, num);
				br br = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (br.b() < num2)
					{
						num2 = br.b();
					}
					A_1.Encrypt(A_0, br.a(), 0, num2);
					num += num2;
					br = br.c();
				}
				while (num < this.c);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0003E614 File Offset: 0x0003D614
		internal override void r(byte[] A_0, int A_1)
		{
			if (this.a.b() - this.b >= this.c)
			{
				Array.Copy(this.a.a(), this.b, A_0, A_1, this.c);
				A_1 += this.c;
			}
			else
			{
				int num = this.a.b() - this.b;
				Array.Copy(this.a.a(), this.b, A_0, A_1, num);
				A_1 += num;
				br br = this.a.c();
				do
				{
					int num2 = this.c - num;
					if (br.b() < num2)
					{
						num2 = br.b();
					}
					Array.Copy(br.a(), 0, A_0, A_1, num2);
					A_1 += num2;
					num += num2;
					br = br.c();
				}
				while (num < this.c);
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0003E704 File Offset: 0x0003D704
		internal br a()
		{
			return this.a;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0003E71C File Offset: 0x0003D71C
		internal int b()
		{
			return this.b;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0003E734 File Offset: 0x0003D734
		internal override int s()
		{
			return this.c;
		}

		// Token: 0x040001EE RID: 494
		private br a;

		// Token: 0x040001EF RID: 495
		private int b;

		// Token: 0x040001F0 RID: 496
		private int c;
	}
}
