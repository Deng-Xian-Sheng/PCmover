using System;
using System.Text;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002F5 RID: 757
	internal class ts
	{
		// Token: 0x060021A5 RID: 8613 RVA: 0x0014634A File Offset: 0x0014534A
		internal ts(char[] A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.d = A_2;
		}

		// Token: 0x060021A6 RID: 8614 RVA: 0x0014636C File Offset: 0x0014536C
		internal string b()
		{
			this.c = this.b;
			while (this.c < this.d && this.a[this.c] != '#')
			{
				this.c++;
			}
			string result;
			if (this.a[this.c] != '#')
			{
				result = new string(this.a, this.b, this.d - this.b);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder(this.d - this.b);
				stringBuilder.Append(this.a, this.b, this.c - this.b);
				this.a(stringBuilder);
				this.c++;
				int num = this.c;
				while (this.c < this.d)
				{
					if (this.a[this.c] == '#')
					{
						if (this.c > num)
						{
							stringBuilder.Append(this.a, num, this.c - num);
						}
						this.a(stringBuilder);
						this.c++;
						num = this.c;
					}
					else
					{
						this.c++;
					}
				}
				if (this.c > num)
				{
					stringBuilder.Append(this.a, num, this.c - num);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x060021A7 RID: 8615 RVA: 0x00146508 File Offset: 0x00145508
		private void a(StringBuilder A_0)
		{
			this.c++;
			this.a();
			if (this.c + 10 > this.d)
			{
				throw new DplxParseException("Invalid variable in a connection string.");
			}
			if ((this.a[this.c] == 'G' || this.a[this.c] == 'g') && (this.a[this.c + 1] == 'l' || this.a[this.c + 1] == 'L') && (this.a[this.c + 2] == 'o' || this.a[this.c + 2] == 'O') && (this.a[this.c + 3] == 'b' || this.a[this.c + 3] == 'B') && (this.a[this.c + 4] == 'a' || this.a[this.c + 4] == 'A') && (this.a[this.c + 5] == 'l' || this.a[this.c + 5] == 'L') && this.a[this.c + 6] == '.')
			{
				this.c += 7;
				this.a();
				int num = this.c;
				while (ts.a(this.a[this.c]))
				{
					this.c++;
				}
				int a_ = this.c - num;
				if (this.a[this.c] != '[')
				{
					throw new DplxParseException("Invalid variable in a connection string.");
				}
				if (u7.a(this.a, num, a_))
				{
					this.c = u7.a(this.a, this.c, A_0);
				}
				else
				{
					if (!u8.a(this.a, num, a_))
					{
						throw new DplxParseException("Invalid variable in a document string.");
					}
					this.c = u8.a(this.a, this.c, A_0);
				}
			}
			else
			{
				int num = this.c;
				while (ts.a(this.a[this.c]))
				{
					this.c++;
				}
				int a_ = this.c - num;
				if (!u9.a(this.a, num, a_))
				{
					throw new DplxParseException("Invalid variable in a connection string.");
				}
				this.c = u9.a(this.a, this.c, A_0);
			}
		}

		// Token: 0x060021A8 RID: 8616 RVA: 0x001467AC File Offset: 0x001457AC
		private static bool a(char A_0)
		{
			return A_0 <= 'z' && (A_0 >= 'a' || (A_0 <= 'Z' && (A_0 >= 'A' || (A_0 <= '9' && A_0 >= '0'))));
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x00146818 File Offset: 0x00145818
		private void a()
		{
			while (this.a[this.c] <= ' ')
			{
				this.c++;
			}
		}

		// Token: 0x04000EA9 RID: 3753
		private char[] a;

		// Token: 0x04000EAA RID: 3754
		private int b;

		// Token: 0x04000EAB RID: 3755
		private int c;

		// Token: 0x04000EAC RID: 3756
		private int d;
	}
}
