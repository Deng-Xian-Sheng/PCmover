using System;

namespace zz93
{
	// Token: 0x020004F2 RID: 1266
	internal abstract class ag7
	{
		// Token: 0x060033C6 RID: 13254 RVA: 0x001CB980 File Offset: 0x001CA980
		internal ag7(int A_0, abe A_1, abe A_2, int A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = ((abw)A_2.a(0)).kd();
			this.d = ((abw)A_2.a(1)).kd();
			this.e = ((abw)A_2.a(2)).kd();
			this.f = A_3;
			this.g = A_3 + this.c;
			this.h = this.g + this.d;
			this.j = this.h + this.e;
		}

		// Token: 0x060033C7 RID: 13255
		protected abstract byte[] ls();

		// Token: 0x060033C8 RID: 13256 RVA: 0x001CBA30 File Offset: 0x001CAA30
		internal void a(aba A_0, abt A_1)
		{
			int i = 0;
			if (this.b == null)
			{
				A_1.a((long)this.a);
				for (int j = 0; j < this.a; j++)
				{
					this.a(A_0, j, A_1);
				}
			}
			else
			{
				while (i < this.b.a())
				{
					int num = ((abw)this.b.a(i++)).kd();
					int num2 = ((abw)this.b.a(i++)).kd() + num - 1;
					A_1.a((long)num2);
					for (int j = num; j <= num2; j++)
					{
						this.a(A_0, j, A_1);
					}
				}
			}
		}

		// Token: 0x060033C9 RID: 13257 RVA: 0x001CBB08 File Offset: 0x001CAB08
		private void a(aba A_0, int A_1, abt A_2)
		{
			this.i = this.ls();
			int num = this.c();
			long num2 = this.b();
			int a_ = this.a();
			switch (num)
			{
			case 1:
			{
				ab9 a_2 = new ab9(A_0, A_1, num2);
				A_2.a(a_2, (long)A_1);
				break;
			}
			case 2:
			{
				abh a_3 = new abh(A_0, A_1, (int)num2, a_);
				A_2.a(a_3, (long)A_1);
				break;
			}
			}
		}

		// Token: 0x060033CA RID: 13258 RVA: 0x001CBB7C File Offset: 0x001CAB7C
		private int c()
		{
			int result;
			if (this.c == 0)
			{
				result = 1;
			}
			else
			{
				result = this.b(this.f, this.c);
			}
			return result;
		}

		// Token: 0x060033CB RID: 13259 RVA: 0x001CBBB4 File Offset: 0x001CABB4
		private long b()
		{
			return this.a(this.g, this.d);
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x001CBBD8 File Offset: 0x001CABD8
		private int a()
		{
			int result;
			if (this.e == 0)
			{
				result = 0;
			}
			else
			{
				result = this.b(this.h, this.e);
			}
			return result;
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x001CBC10 File Offset: 0x001CAC10
		private int b(int A_0, int A_1)
		{
			int num = A_0 + A_1;
			int num2 = (int)this.i[A_0++];
			while (A_0 < num)
			{
				num2 = (num2 << 8 | (int)this.i[A_0++]);
			}
			return num2;
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x001CBC54 File Offset: 0x001CAC54
		private long a(int A_0, int A_1)
		{
			int num = A_0 + A_1;
			long num2 = (long)this.i[A_0++];
			while (A_0 < num)
			{
				num2 = (num2 << 8 | (long)((ulong)this.i[A_0++]));
			}
			return num2;
		}

		// Token: 0x060033CF RID: 13263 RVA: 0x001CBC9C File Offset: 0x001CAC9C
		protected int d()
		{
			return this.j;
		}

		// Token: 0x040018B1 RID: 6321
		private int a;

		// Token: 0x040018B2 RID: 6322
		private abe b;

		// Token: 0x040018B3 RID: 6323
		private int c;

		// Token: 0x040018B4 RID: 6324
		private int d;

		// Token: 0x040018B5 RID: 6325
		private int e;

		// Token: 0x040018B6 RID: 6326
		private int f;

		// Token: 0x040018B7 RID: 6327
		private int g;

		// Token: 0x040018B8 RID: 6328
		private int h;

		// Token: 0x040018B9 RID: 6329
		private byte[] i = null;

		// Token: 0x040018BA RID: 6330
		private int j;
	}
}
