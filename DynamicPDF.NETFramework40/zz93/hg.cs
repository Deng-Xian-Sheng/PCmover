using System;

namespace zz93
{
	// Token: 0x0200012C RID: 300
	internal class hg
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x0008C444 File Offset: 0x0008B444
		internal hg()
		{
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0008C46C File Offset: 0x0008B46C
		private int a(char A_0)
		{
			switch (A_0)
			{
			case '-':
				return 60;
			case '0':
				return 45;
			case '1':
				return 13;
			case '2':
				return 48;
			case '3':
				return 10;
			case '4':
				return 52;
			case '5':
				return 6;
			case '6':
				return 55;
			case '7':
				return 3;
			case '8':
				return 58;
			case '9':
				return 0;
			case 'A':
				return 1;
			case 'B':
				return 57;
			case 'C':
				return 5;
			case 'D':
				return 53;
			case 'E':
				return 8;
			case 'F':
				return 50;
			case 'G':
				return 11;
			case 'H':
				return 47;
			case 'I':
				return 15;
			case 'J':
				return 43;
			case 'K':
				return 18;
			case 'L':
				return 40;
			case 'M':
				return 21;
			case 'N':
				return 37;
			case 'O':
				return 25;
			case 'P':
				return 33;
			case 'Q':
				return 28;
			case 'R':
				return 30;
			case 'S':
				return 32;
			case 'T':
				return 26;
			case 'U':
				return 35;
			case 'V':
				return 23;
			case 'W':
				return 38;
			case 'X':
				return 20;
			case 'Y':
				return 42;
			case 'Z':
				return 16;
			case 'a':
				return 1;
			case 'b':
				return 57;
			case 'c':
				return 5;
			case 'd':
				return 53;
			case 'e':
				return 8;
			case 'f':
				return 50;
			case 'g':
				return 11;
			case 'h':
				return 47;
			case 'i':
				return 15;
			case 'j':
				return 43;
			case 'k':
				return 18;
			case 'l':
				return 40;
			case 'm':
				return 21;
			case 'n':
				return 37;
			case 'o':
				return 25;
			case 'p':
				return 33;
			case 'q':
				return 28;
			case 'r':
				return 30;
			case 's':
				return 32;
			case 't':
				return 26;
			case 'u':
				return 35;
			case 'v':
				return 23;
			case 'w':
				return 38;
			case 'x':
				return 20;
			case 'y':
				return 42;
			case 'z':
				return 16;
			}
			return 62;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0008C769 File Offset: 0x0008B769
		internal void a()
		{
			this.a = 0;
			this.b = 0;
			this.c = 0;
			this.d = false;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0008C788 File Offset: 0x0008B788
		internal int b()
		{
			int result;
			if (this.d)
			{
				result = (this.b ^ this.a << 1);
			}
			else
			{
				result = (this.b ^ this.a);
			}
			return result;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0008C7C8 File Offset: 0x0008B7C8
		internal void b(char A_0)
		{
			if (this.c == 30)
			{
				if (this.d)
				{
					this.b ^= this.a << 1;
				}
				else
				{
					this.b ^= this.a;
				}
				this.a = this.a(A_0);
				this.c = 6;
				this.d = !this.d;
			}
			else
			{
				this.a ^= this.a(A_0) << this.c;
				this.c += 6;
			}
		}

		// Token: 0x0400061E RID: 1566
		private int a = 0;

		// Token: 0x0400061F RID: 1567
		private int b = 0;

		// Token: 0x04000620 RID: 1568
		private int c = 0;

		// Token: 0x04000621 RID: 1569
		private bool d = false;
	}
}
