using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004F1 RID: 1265
	internal class ag6 : abs
	{
		// Token: 0x060033BE RID: 13246 RVA: 0x001CB6E8 File Offset: 0x001CA6E8
		internal ag6(PdfDocument A_0, afj A_1) : base(A_0)
		{
			this.a = A_1;
			for (abk abk = A_1.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 14)
				{
					if (num == 111619316)
					{
						this.d = ((abw)abk.c()).kd();
					}
				}
				else
				{
					this.c = ((abw)abk.c()).kd();
				}
			}
			this.e = new int[this.c];
			this.f = A_1.j5();
			this.b = new agu(A_0, this.f);
			this.c();
		}

		// Token: 0x060033BF RID: 13247 RVA: 0x001CB7C0 File Offset: 0x001CA7C0
		internal override aba h4()
		{
			return this.b;
		}

		// Token: 0x060033C0 RID: 13248 RVA: 0x001CB7D8 File Offset: 0x001CA7D8
		internal override void h5(aba A_0)
		{
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x001CB7DC File Offset: 0x001CA7DC
		internal afj d()
		{
			return this.a;
		}

		// Token: 0x060033C2 RID: 13250 RVA: 0x001CB7F4 File Offset: 0x001CA7F4
		internal abd a(abi A_0, int A_1)
		{
			int num = this.e[A_1] + this.d;
			return this.b.a().a(ref num, A_0, false);
		}

		// Token: 0x060033C3 RID: 13251 RVA: 0x001CB82C File Offset: 0x001CA82C
		private void c()
		{
			for (int i = 0; i < this.e.Length; i++)
			{
				this.a();
				this.e[i] = this.b();
			}
		}

		// Token: 0x060033C4 RID: 13252 RVA: 0x001CB868 File Offset: 0x001CA868
		private int b()
		{
			int num = 0;
			while (this.f[this.g] == 48)
			{
				this.g++;
			}
			while (this.f[this.g] >= 48 && this.f[this.g] <= 57)
			{
				num = num * 10 + (int)this.f[this.g] - 48;
				this.g++;
			}
			while (this.f[this.g] <= 32)
			{
				this.g++;
			}
			return num;
		}

		// Token: 0x060033C5 RID: 13253 RVA: 0x001CB920 File Offset: 0x001CA920
		private void a()
		{
			while (this.f[this.g] >= 48)
			{
				this.g++;
			}
			while (this.f[this.g] <= 32)
			{
				this.g++;
			}
		}

		// Token: 0x040018AA RID: 6314
		private afj a;

		// Token: 0x040018AB RID: 6315
		private agu b;

		// Token: 0x040018AC RID: 6316
		private int c = 0;

		// Token: 0x040018AD RID: 6317
		private int d = -1;

		// Token: 0x040018AE RID: 6318
		private int[] e = null;

		// Token: 0x040018AF RID: 6319
		private byte[] f;

		// Token: 0x040018B0 RID: 6320
		private int g = 0;
	}
}
