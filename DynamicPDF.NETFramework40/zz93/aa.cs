using System;
using System.Collections;

namespace zz93
{
	// Token: 0x0200001D RID: 29
	internal class aa
	{
		// Token: 0x06000126 RID: 294 RVA: 0x000257C8 File Offset: 0x000247C8
		internal aa(string A_0)
		{
			this.a = A_0;
			while (this.a.Length < 11)
			{
				this.a = "0" + this.a;
			}
			foreach (char c in this.a)
			{
				if (c < '0' || c > '9')
				{
					throw new ap("Invalid Identcode character, allows only digits");
				}
			}
			if (this.a.Length != 12)
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
			if (this.a.Length > 12)
			{
				throw new ap("Invalid Identcode value, allows only 11 or 12 digits");
			}
			this.b = new am(this.a, 0f, 1f);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00025958 File Offset: 0x00024958
		internal int a()
		{
			return (int)this.b.e();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00025978 File Offset: 0x00024978
		internal BitArray b()
		{
			return this.b.d();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00025998 File Offset: 0x00024998
		internal string c()
		{
			return string.Concat(new string[]
			{
				this.a.Substring(0, 2),
				".",
				this.a.Substring(2, 3),
				" ",
				this.a.Substring(5, 3),
				".",
				this.a.Substring(8, 3),
				" ",
				this.a.Substring(11)
			});
		}

		// Token: 0x040000B2 RID: 178
		private string a;

		// Token: 0x040000B3 RID: 179
		private am b;
	}
}
