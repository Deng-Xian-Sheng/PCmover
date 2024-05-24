using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x0200002F RID: 47
	internal class @as
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0002E360 File Offset: 0x0002D360
		internal @as(string A_0, float A_1, float A_2, int A_3)
		{
			string text = A_0.Replace(" ", "");
			text = text.Replace("-", "");
			this.a = text;
			this.e = A_1;
			this.f = A_2;
			this.g = (at)A_3;
			this.a();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0002E3C8 File Offset: 0x0002D3C8
		internal byte[] c()
		{
			return this.b;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0002E3E0 File Offset: 0x0002D3E0
		internal float d()
		{
			return this.e;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0002E3F8 File Offset: 0x0002D3F8
		internal float e()
		{
			return (float)this.b() * this.f;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0002E418 File Offset: 0x0002D418
		internal BitArray f()
		{
			this.c = new BitArray(this.b(), true);
			this.d(ref this.e);
			foreach (byte a_ in this.b)
			{
				this.a(a_, ref this.e);
			}
			this.a(ref this.e);
			return this.c;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0002E48C File Offset: 0x0002D48C
		private int b()
		{
			return this.b.Length * 12 + 7;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0002E4AC File Offset: 0x0002D4AC
		private void a(byte A_0, ref float A_1)
		{
			switch (A_0)
			{
			case 48:
				this.c(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				break;
			case 49:
				this.c(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				break;
			case 50:
				this.c(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				break;
			case 51:
				this.c(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				break;
			case 52:
				this.c(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				break;
			case 53:
				this.c(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				break;
			case 54:
				this.c(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				this.c(ref A_1);
				break;
			case 55:
				this.c(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				this.b(ref A_1);
				break;
			case 56:
				this.b(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				break;
			case 57:
				this.b(ref A_1);
				this.c(ref A_1);
				this.c(ref A_1);
				this.b(ref A_1);
				break;
			default:
				throw new ap("Invalid MSI barcode character.");
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0002E664 File Offset: 0x0002D664
		private void d(ref float A_0)
		{
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			A_0 += this.f * 3f;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0002E6E8 File Offset: 0x0002D6E8
		private void c(ref float A_0)
		{
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			A_0 += this.f * 3f;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0002E76C File Offset: 0x0002D76C
		private void b(ref float A_0)
		{
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			A_0 += this.f * 3f;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0002E7F0 File Offset: 0x0002D7F0
		private void a(ref float A_0)
		{
			this.c[this.d] = false;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			this.c[this.d] = true;
			this.d++;
			this.c[this.d] = false;
			A_0 += this.f * 3f;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0002E888 File Offset: 0x0002D888
		private void b(byte[] A_0)
		{
			int num = 0;
			bool flag = true;
			for (int i = A_0.Length - 2; i >= 0; i--)
			{
				if (flag)
				{
					int num2 = (int)(A_0[i] - 48);
					num2 *= 2;
					if (num2 >= 10)
					{
						num += num2 % 10;
						num2 /= 10;
						num += num2 % 10;
					}
					else
					{
						num += num2;
					}
					flag = !flag;
				}
				else
				{
					num += (int)(A_0[i] - 48);
					flag = !flag;
				}
			}
			num *= 9;
			num %= 10;
			A_0[A_0.Length - 1] = (byte)(num + 48);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0002E924 File Offset: 0x0002D924
		private void a(byte[] A_0)
		{
			int num = 0;
			int num2 = 2;
			for (int i = A_0.Length - 2; i >= 0; i--)
			{
				if (num2 > 7)
				{
					num2 = 2;
				}
				num += (int)(A_0[i] - 48) * num2;
				num2++;
			}
			int num3 = (11 - num % 11) % 11;
			A_0[A_0.Length - 1] = (byte)(num3 + 48);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0002E988 File Offset: 0x0002D988
		private void a()
		{
			byte[] array = new byte[this.a.Length + 1];
			Encoding.ASCII.GetBytes(this.a).CopyTo(array, 0);
			switch (this.g)
			{
			case at.b:
				this.b = new byte[this.a.Length + 1];
				Encoding.ASCII.GetBytes(this.a).CopyTo(this.b, 0);
				this.b(this.b);
				break;
			case at.c:
				this.b = new byte[this.a.Length + 1];
				Encoding.ASCII.GetBytes(this.a).CopyTo(this.b, 0);
				this.a(this.b);
				break;
			case at.d:
				this.b(array);
				this.b = new byte[array.Length + 1];
				array.CopyTo(this.b, 0);
				this.b(this.b);
				break;
			case at.e:
				this.a(array);
				this.b = new byte[array.Length + 1];
				array.CopyTo(this.b, 0);
				this.b(this.b);
				break;
			default:
				this.b = Encoding.ASCII.GetBytes(this.a);
				break;
			}
		}

		// Token: 0x04000131 RID: 305
		private string a;

		// Token: 0x04000132 RID: 306
		private byte[] b;

		// Token: 0x04000133 RID: 307
		private BitArray c;

		// Token: 0x04000134 RID: 308
		private int d;

		// Token: 0x04000135 RID: 309
		private float e;

		// Token: 0x04000136 RID: 310
		private float f = 1f;

		// Token: 0x04000137 RID: 311
		private at g;
	}
}
