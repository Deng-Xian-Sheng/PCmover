using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000431 RID: 1073
	internal class abz
	{
		// Token: 0x06002C85 RID: 11397 RVA: 0x00196FB4 File Offset: 0x00195FB4
		internal abz(abw A_0, abj A_1)
		{
			this.a = A_0.kd();
			for (abk abk = A_1.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 16)
				{
					if (num != 19)
					{
						if (num == 1268)
						{
							this.d = ((abw)abk.c()).kd();
						}
					}
					else
					{
						this.b = this.a((abu)abk.c());
					}
				}
				else
				{
					this.c = ((ab7)abk.c()).kf();
				}
			}
		}

		// Token: 0x06002C86 RID: 11398 RVA: 0x00197075 File Offset: 0x00196075
		internal void a(Section A_0, int A_1)
		{
			A_0.NumberingStyle = this.b;
			A_0.Prefix = this.c;
			A_0.StartingPageNumber = A_1 + this.d;
		}

		// Token: 0x06002C87 RID: 11399 RVA: 0x001970A4 File Offset: 0x001960A4
		internal Section a(int A_0)
		{
			return new Section(this.a + A_0, this.b, this.c, this.d + A_0);
		}

		// Token: 0x06002C88 RID: 11400 RVA: 0x001970D8 File Offset: 0x001960D8
		internal int a()
		{
			return this.a;
		}

		// Token: 0x06002C89 RID: 11401 RVA: 0x001970F0 File Offset: 0x001960F0
		private NumberingStyle a(abu A_0)
		{
			int num = A_0.j8();
			if (num <= 4)
			{
				if (num == 1)
				{
					return NumberingStyle.AlphabeticUpperCase;
				}
				if (num == 4)
				{
					return NumberingStyle.Numeric;
				}
			}
			else
			{
				if (num == 18)
				{
					return NumberingStyle.RomanUpperCase;
				}
				if (num == 33)
				{
					return NumberingStyle.AlphabeticLowerCase;
				}
				if (num == 50)
				{
					return NumberingStyle.RomanLowerCase;
				}
			}
			return NumberingStyle.None;
		}

		// Token: 0x040014EC RID: 5356
		private int a;

		// Token: 0x040014ED RID: 5357
		private NumberingStyle b = NumberingStyle.None;

		// Token: 0x040014EE RID: 5358
		private string c = string.Empty;

		// Token: 0x040014EF RID: 5359
		private int d = 1;
	}
}
