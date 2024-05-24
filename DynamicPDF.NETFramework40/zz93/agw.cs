using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004E7 RID: 1255
	internal class agw : agv
	{
		// Token: 0x0600331D RID: 13085 RVA: 0x001C66FE File Offset: 0x001C56FE
		internal agw(agu A_0)
		{
			this.a = A_0;
			this.c = A_0.c();
		}

		// Token: 0x0600331E RID: 13086 RVA: 0x001C671C File Offset: 0x001C571C
		internal override void le()
		{
			this.a.af().a(this.a());
			this.b();
			this.a.af().m().a(this);
		}

		// Token: 0x0600331F RID: 13087 RVA: 0x001C6754 File Offset: 0x001C5754
		internal override bool lf()
		{
			return ags.d(this.c[this.b]);
		}

		// Token: 0x06003320 RID: 13088 RVA: 0x001C6778 File Offset: 0x001C5778
		internal override long lg(bool A_0)
		{
			long result;
			if (this.c[this.b + 17] != 110)
			{
				if (!A_0)
				{
					this.lh();
				}
				result = -1L;
			}
			else
			{
				long num = 0L;
				int num2 = this.b + 19;
				while (this.c[this.b] == 48)
				{
					this.b++;
				}
				while (this.c[this.b] >= 48 && this.c[this.b] <= 57)
				{
					num = num * 10L + (long)((ulong)this.c[this.b]) - 48L;
					this.b++;
				}
				this.b = num2;
				while (this.c[this.b] < 48)
				{
					this.b++;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06003321 RID: 13089 RVA: 0x001C6870 File Offset: 0x001C5870
		internal override void lh()
		{
			this.b += 19;
			while (this.c[this.b] < 48)
			{
				this.b++;
			}
		}

		// Token: 0x06003322 RID: 13090 RVA: 0x001C68B2 File Offset: 0x001C58B2
		internal override void li()
		{
			this.b += 4;
		}

		// Token: 0x06003323 RID: 13091 RVA: 0x001C68C3 File Offset: 0x001C58C3
		internal override void lj(long A_0)
		{
			this.b = (int)A_0;
			this.a.af().m().b().Add(A_0);
			this.b = this.a.c(this.b);
		}

		// Token: 0x06003324 RID: 13092 RVA: 0x001C6904 File Offset: 0x001C5904
		internal override bool lk()
		{
			return this.c[this.b] >= 48 && this.c[this.b] <= 57;
		}

		// Token: 0x06003325 RID: 13093 RVA: 0x001C6940 File Offset: 0x001C5940
		internal override ab8 ll(abt A_0, abi A_1)
		{
			return this.a.a((long)this.b, A_0, A_1);
		}

		// Token: 0x06003326 RID: 13094 RVA: 0x001C6968 File Offset: 0x001C5968
		internal override afj lm(abi A_0)
		{
			return this.a.a((long)this.b, A_0);
		}

		// Token: 0x06003327 RID: 13095 RVA: 0x001C6990 File Offset: 0x001C5990
		internal override int ln()
		{
			int num = 0;
			while (this.c[this.b] < 33)
			{
				this.b++;
			}
			while (this.c[this.b] == 48)
			{
				this.b++;
			}
			while (this.c[this.b] >= 48 && this.c[this.b] <= 57)
			{
				num = num * 10 + (int)this.c[this.b] - 48;
				this.b++;
			}
			return num;
		}

		// Token: 0x06003328 RID: 13096 RVA: 0x001C6A48 File Offset: 0x001C5A48
		internal override void lo()
		{
			while (this.c[this.b] <= 32)
			{
				this.b++;
			}
		}

		// Token: 0x06003329 RID: 13097 RVA: 0x001C6A80 File Offset: 0x001C5A80
		internal override aba lp()
		{
			return this.a;
		}

		// Token: 0x0600332A RID: 13098 RVA: 0x001C6A98 File Offset: 0x001C5A98
		private void b()
		{
			int num = this.c.Length - 5;
			while ((this.c[num] != 37 || this.c[num + 1] != 37 || this.c[num + 2] != 69 || this.c[num + 3] != 79 || this.c[num + 4] != 70) && num > 10)
			{
				num--;
			}
			if (num == 10)
			{
				throw new PdfParsingException("Invalid PDF File. %%EOF not found.");
			}
			num -= 12;
			while ((this.c[num] != 115 || this.c[num + 1] != 116 || this.c[num + 2] != 97 || this.c[num + 3] != 114 || this.c[num + 4] != 116 || this.c[num + 5] != 120 || this.c[num + 6] != 114 || this.c[num + 7] != 101 || this.c[num + 8] != 102) && num > 5)
			{
				num--;
			}
			if (num == 10)
			{
				throw new PdfParsingException("Invalid PDF File. Cross-reference table not found.");
			}
			this.a.af().m().b().Add((long)num);
			num += 9;
			num = this.a.c(num);
			int num2 = this.a.b(num);
			this.lj((long)num2);
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x001C6C14 File Offset: 0x001C5C14
		private int a()
		{
			int result;
			if (this.c[0] == 37 && this.c[1] == 80 && this.c[2] == 68 && this.c[3] == 70 && this.c[4] == 45 && this.c[6] == 46)
			{
				result = (int)((this.c[5] - 48) * 10 + this.c[7] - 48);
			}
			else
			{
				result = 14;
			}
			return result;
		}

		// Token: 0x0400186C RID: 6252
		private agu a;

		// Token: 0x0400186D RID: 6253
		private int b;

		// Token: 0x0400186E RID: 6254
		private byte[] c;
	}
}
