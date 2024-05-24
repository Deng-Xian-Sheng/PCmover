using System;
using System.Collections;

namespace zz93
{
	// Token: 0x0200002D RID: 45
	internal class aq
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0002E178 File Offset: 0x0002D178
		internal aq(string A_0)
		{
			this.a = A_0;
			while (this.a.Length < 13)
			{
				this.a = "0" + this.a;
			}
			foreach (char c in this.a)
			{
				if (c < '0' || c > '9')
				{
					throw new ap("Invalid ITF-14 character, allows only digits");
				}
			}
			if (this.a.Length != 14)
			{
				int num = 0;
				for (int j = this.a.Length - 1; j >= 0; j--)
				{
					if (j % 2 == 0)
					{
						num += int.Parse(this.a[j].ToString()) * 3;
					}
					else
					{
						num += int.Parse(this.a[j].ToString());
					}
				}
				int num2 = (num % 10 > 0) ? (10 - num % 10) : 0;
				this.a += num2.ToString();
			}
			if (this.a.Length > 14)
			{
				throw new ap("Invalid ITF-14 character, allows only 13 or 14 digits");
			}
			this.b = new am(this.a, 0f, 1f);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0002E308 File Offset: 0x0002D308
		internal string a()
		{
			return this.a;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0002E320 File Offset: 0x0002D320
		internal int b()
		{
			return (int)this.b.e();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0002E340 File Offset: 0x0002D340
		internal BitArray c()
		{
			return this.b.d();
		}

		// Token: 0x0400012B RID: 299
		private string a;

		// Token: 0x0400012C RID: 300
		private am b;
	}
}
