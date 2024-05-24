using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004ED RID: 1261
	internal class ag2 : abu
	{
		// Token: 0x06003394 RID: 13204 RVA: 0x001CA29C File Offset: 0x001C929C
		internal ag2(agt A_0, int A_1, short A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06003395 RID: 13205 RVA: 0x001CA2C4 File Offset: 0x001C92C4
		internal override int j7(aba A_0)
		{
			return (int)((this.a.a()[this.b + 1] - 48) * 10 + this.a.a()[this.b + 3] - 48);
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x001CA308 File Offset: 0x001C9308
		internal override int j8()
		{
			if (this.d == -1)
			{
				this.ka();
			}
			return this.d;
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x001CA338 File Offset: 0x001C9338
		internal override string j9()
		{
			return this.a(this.b + 1, (int)(this.c - 1));
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x001CA360 File Offset: 0x001C9360
		private string a(int A_0, int A_1)
		{
			return ab2.a(this.a.a(), A_0, A_1);
		}

		// Token: 0x06003399 RID: 13209 RVA: 0x001CA386 File Offset: 0x001C9386
		internal override void ka()
		{
			this.d = this.a(this.b + 1);
		}

		// Token: 0x0600339A RID: 13210 RVA: 0x001CA3A0 File Offset: 0x001C93A0
		internal int a(int A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (ags.a(this.a.b(A_0)))
			{
				num2 <<= 6;
				num2 |= (int)(this.a.b(A_0) % 64);
				if (num3 % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				A_0++;
				num3++;
			}
			if (num3 % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x0600339B RID: 13211 RVA: 0x001CA41C File Offset: 0x001C941C
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteName(this.a.a(), this.b, (int)this.c);
			}
		}

		// Token: 0x0600339C RID: 13212 RVA: 0x001CA458 File Offset: 0x001C9458
		internal override int kb(int A_0)
		{
			int num = this.c(this.b);
			int result;
			if (num > A_0)
			{
				result = num;
			}
			else
			{
				result = A_0;
			}
			return result;
		}

		// Token: 0x0600339D RID: 13213 RVA: 0x001CA488 File Offset: 0x001C9488
		internal override int kc()
		{
			return this.b(this.b + 1);
		}

		// Token: 0x0600339E RID: 13214 RVA: 0x001CA4A8 File Offset: 0x001C94A8
		internal int b(int A_0)
		{
			int num = 0;
			while (this.a.b(A_0) == 48)
			{
				A_0++;
			}
			while (ags.d(this.a.b(A_0)))
			{
				num = num * 10 + (int)this.a.b(A_0) - 48;
				A_0++;
			}
			int result;
			if (!ags.a(this.a.b(A_0)))
			{
				result = num;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x001CA528 File Offset: 0x001C9528
		internal int c(int A_0)
		{
			if (ags.d(this.a.b(A_0 + 2)))
			{
				byte b = this.a.b(A_0 + 1);
				if (b <= 77)
				{
					switch (b)
					{
					case 67:
						break;
					case 68:
					case 69:
						goto IL_7D;
					case 70:
						break;
					case 71:
						break;
					default:
						if (b != 77)
						{
							goto IL_7D;
						}
						break;
					}
				}
				else if (b != 80)
				{
					if (b != 83)
					{
						if (b != 88)
						{
							goto IL_7D;
						}
					}
				}
				return this.b(A_0 + 2);
				IL_7D:;
			}
			return -1;
		}

		// Token: 0x04001897 RID: 6295
		private new agt a;

		// Token: 0x04001898 RID: 6296
		private int b;

		// Token: 0x04001899 RID: 6297
		private short c;

		// Token: 0x0400189A RID: 6298
		private int d = -1;
	}
}
