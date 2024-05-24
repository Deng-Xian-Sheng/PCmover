using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x02000035 RID: 53
	internal class ay
	{
		// Token: 0x0600021B RID: 539 RVA: 0x000322D4 File Offset: 0x000312D4
		internal ay(string A_0, float A_1, int A_2)
		{
			this.d = A_0.Replace(" ", "");
			this.d = this.d.Replace("-", "");
			this.e = A_1;
			this.f = (k)A_2;
			switch (this.f)
			{
			case k.a:
				break;
			case k.b:
				goto IL_E1;
			case k.c:
				if (this.d.Length != 5 && this.d.Length != 9 && this.d.Length != 11)
				{
					goto IL_E1;
				}
				break;
			default:
				goto IL_E1;
			}
			this.g = new byte[this.d.Length + 1];
			Encoding.ASCII.GetBytes(this.d).CopyTo(this.g, 0);
			this.a(this.g);
			return;
			IL_E1:
			this.g = Encoding.ASCII.GetBytes(this.d);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000323DC File Offset: 0x000313DC
		internal float d()
		{
			return ((float)this.c() - 0.5f) * this.e;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00032404 File Offset: 0x00031404
		internal float e()
		{
			return (float)(this.c() * 2 - 1) * this.e;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00032428 File Offset: 0x00031428
		internal BitArray f()
		{
			this.a = new BitArray(this.c() * 3, true);
			this.c = this.g.Length;
			this.b();
			foreach (byte a_ in this.g)
			{
				this.a(a_);
			}
			this.b();
			return this.a(this.a);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000324A8 File Offset: 0x000314A8
		private int c()
		{
			int num = this.g.Length;
			num *= 5;
			return num + 2;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000324CC File Offset: 0x000314CC
		private BitArray a(BitArray A_0)
		{
			int num = (this.c * 5 + 2) * 2 - 1;
			BitArray bitArray = new BitArray(this.b * 2 - 3);
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			BitArray bitArray2 = new BitArray(this.b * 2 - 3);
			int num5 = this.b / 3;
			for (int i = 0; i < num5 * 2 - 1; i++)
			{
				if (i % 2 == 0)
				{
					for (int j = 0; j < 3; j++)
					{
						bitArray2[num4] = A_0[num3];
						num3++;
						num4++;
					}
				}
				else
				{
					for (int j = 0; j < 3; j++)
					{
						bitArray2[num4] = true;
						num4++;
						this.b++;
					}
				}
			}
			for (int k = 0; k < this.b / num; k++)
			{
				int num6 = k;
				for (int j = 0; j < num; j++)
				{
					bitArray[num2] = bitArray2[num6];
					num2++;
					num6 += this.b / num;
				}
			}
			return bitArray;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00032624 File Offset: 0x00031624
		private void a(byte A_0)
		{
			switch (A_0)
			{
			case 48:
				this.b();
				this.b();
				this.a();
				this.a();
				this.a();
				break;
			case 49:
				this.a();
				this.a();
				this.a();
				this.b();
				this.b();
				break;
			case 50:
				this.a();
				this.a();
				this.b();
				this.a();
				this.b();
				break;
			case 51:
				this.a();
				this.a();
				this.b();
				this.b();
				this.a();
				break;
			case 52:
				this.a();
				this.b();
				this.a();
				this.a();
				this.b();
				break;
			case 53:
				this.a();
				this.b();
				this.a();
				this.b();
				this.a();
				break;
			case 54:
				this.a();
				this.b();
				this.b();
				this.a();
				this.a();
				break;
			case 55:
				this.b();
				this.a();
				this.a();
				this.a();
				this.b();
				break;
			case 56:
				this.b();
				this.a();
				this.a();
				this.b();
				this.a();
				break;
			case 57:
				this.b();
				this.a();
				this.b();
				this.a();
				this.a();
				break;
			default:
				throw new ap("Invalid Postnet character.");
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000327FC File Offset: 0x000317FC
		private void b()
		{
			for (int i = 0; i < 3; i++)
			{
				this.a[this.b] = false;
				this.b++;
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00032840 File Offset: 0x00031840
		private void a()
		{
			for (int i = 0; i < 2; i++)
			{
				this.a[this.b] = true;
				this.b++;
			}
			for (int i = 0; i < 1; i++)
			{
				this.a[this.b] = false;
				this.b++;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000328B4 File Offset: 0x000318B4
		private void a(byte[] A_0)
		{
			int num = 0;
			int i;
			for (i = 0; i < A_0.Length - 1; i++)
			{
				num += (int)(A_0[i] - 48);
			}
			A_0[i] = (byte)(58 - num % 10);
			if (A_0[i] == 58)
			{
				A_0[i] = 48;
			}
		}

		// Token: 0x0400016F RID: 367
		private BitArray a;

		// Token: 0x04000170 RID: 368
		private int b;

		// Token: 0x04000171 RID: 369
		private int c;

		// Token: 0x04000172 RID: 370
		private string d;

		// Token: 0x04000173 RID: 371
		private float e;

		// Token: 0x04000174 RID: 372
		private k f;

		// Token: 0x04000175 RID: 373
		private byte[] g;
	}
}
