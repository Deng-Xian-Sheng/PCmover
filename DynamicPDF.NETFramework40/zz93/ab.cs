using System;
using System.Collections;

namespace zz93
{
	// Token: 0x0200001E RID: 30
	internal class ab
	{
		// Token: 0x0600012A RID: 298 RVA: 0x00025A28 File Offset: 0x00024A28
		internal ab(string A_0)
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
					throw new ap("Invalid Leitcode character, allows only digits");
				}
			}
			if (this.a.Length != 14)
			{
				int num = 0;
				for (int j = 0; j < this.a.Length; j++)
				{
					if (j % 2 == 0)
					{
						num += int.Parse(this.a[j].ToString()) * 4;
					}
					else
					{
						num += int.Parse(this.a[j].ToString()) * 9;
					}
				}
				int num2 = (num % 10 > 0) ? (10 - num % 10) : 0;
				this.a += num2.ToString();
			}
			if (this.a.Length > 14)
			{
				throw new ap("Invalid Leitcode character, allows only 13 or 14 digits");
			}
			this.b = new am(this.a, 0f, 1f);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00025BB8 File Offset: 0x00024BB8
		internal int a()
		{
			return (int)this.b.e();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00025BD8 File Offset: 0x00024BD8
		internal BitArray b()
		{
			return this.b.d();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00025BF8 File Offset: 0x00024BF8
		internal string c()
		{
			return string.Concat(new string[]
			{
				this.a.Substring(0, 5),
				".",
				this.a.Substring(5, 3),
				".",
				this.a.Substring(8, 3),
				".",
				this.a.Substring(11, 2),
				" ",
				this.a.Substring(13)
			});
		}

		// Token: 0x040000B4 RID: 180
		private string a;

		// Token: 0x040000B5 RID: 181
		private am b;
	}
}
