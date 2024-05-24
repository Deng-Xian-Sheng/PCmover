using System;
using System.Text;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x020002F6 RID: 758
	internal class tt
	{
		// Token: 0x060021AA RID: 8618 RVA: 0x0014684E File Offset: 0x0014584E
		internal tt(char[] A_0, int A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.d = A_2;
		}

		// Token: 0x060021AB RID: 8619 RVA: 0x00146870 File Offset: 0x00145870
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

		// Token: 0x060021AC RID: 8620 RVA: 0x00146A0C File Offset: 0x00145A0C
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
				while (tt.a(this.a[this.c]))
				{
					this.c++;
				}
				int a_ = this.c - num;
				if (this.a[this.c] != '[')
				{
					throw new DplxParseException("Invalid variable in a connection string.");
				}
				if (!u7.a(this.a, num, a_))
				{
					throw new DplxParseException("Invalid variable in a document string.");
				}
				this.c = u7.a(this.a, this.c, A_0);
			}
			else
			{
				int num = this.c;
				while (tt.a(this.a[this.c]))
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

		// Token: 0x060021AD RID: 8621 RVA: 0x00146C80 File Offset: 0x00145C80
		private static bool a(char A_0)
		{
			return A_0 <= 'z' && (A_0 >= 'a' || (A_0 <= 'Z' && (A_0 >= 'A' || (A_0 <= '9' && A_0 >= '0'))));
		}

		// Token: 0x060021AE RID: 8622 RVA: 0x00146CEC File Offset: 0x00145CEC
		private void a()
		{
			while (this.a[this.c] <= ' ')
			{
				this.c++;
			}
		}

		// Token: 0x04000EAD RID: 3757
		private char[] a;

		// Token: 0x04000EAE RID: 3758
		private int b;

		// Token: 0x04000EAF RID: 3759
		private int c;

		// Token: 0x04000EB0 RID: 3760
		private int d;
	}
}
