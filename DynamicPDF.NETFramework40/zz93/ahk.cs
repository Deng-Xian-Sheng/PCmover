using System;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020004FF RID: 1279
	internal struct ahk
	{
		// Token: 0x06003412 RID: 13330 RVA: 0x001CE088 File Offset: 0x001CD088
		internal ahk(int A_0, int A_1, char A_2, ahj A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = ahk.a(A_2);
			this.d = A_3;
			this.e = 0;
			this.f = '0';
		}

		// Token: 0x06003413 RID: 13331 RVA: 0x001CE0BC File Offset: 0x001CD0BC
		internal ahk(int A_0, int A_1, char A_2, ahj A_3, int A_4, char A_5)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = ahk.a(A_2);
			if (this.c == NumberingType.Numeric && A_5 == ' ')
			{
				this.f = '0';
			}
			else
			{
				this.f = A_5;
			}
			this.d = A_3;
			this.e = A_4;
		}

		// Token: 0x06003414 RID: 13332 RVA: 0x001CE121 File Offset: 0x001CD121
		internal ahk(int A_0, int A_1, NumberingType A_2, ahj A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.e = 0;
			this.f = '0';
		}

		// Token: 0x06003415 RID: 13333 RVA: 0x001CE150 File Offset: 0x001CD150
		internal ahk(int A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = NumberingType.None;
			this.d = ahj.f;
			this.e = 0;
			this.f = '0';
		}

		// Token: 0x06003416 RID: 13334 RVA: 0x001CE17E File Offset: 0x001CD17E
		internal ahk(int A_0, int A_1, NumberingType A_2, ahj A_3, int A_4, char A_5)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.e = A_4;
			this.f = A_5;
		}

		// Token: 0x06003417 RID: 13335 RVA: 0x001CE1B0 File Offset: 0x001CD1B0
		private static NumberingType a(char A_0)
		{
			if (A_0 <= 'B')
			{
				if (A_0 == '1')
				{
					return NumberingType.Numeric;
				}
				switch (A_0)
				{
				case 'A':
					return NumberingType.AlphabeticUpperCase;
				case 'B':
					return NumberingType.ShortenedAlphabeticUpperCase;
				}
			}
			else
			{
				if (A_0 == 'I')
				{
					return NumberingType.RomanUpperCase;
				}
				switch (A_0)
				{
				case 'a':
					return NumberingType.AlphabeticLowerCase;
				case 'b':
					return NumberingType.ShortenedAlphabeticLowerCase;
				default:
					if (A_0 == 'i')
					{
						return NumberingType.RomanLowerCase;
					}
					break;
				}
			}
			return NumberingType.Numeric;
		}

		// Token: 0x04001934 RID: 6452
		internal int a;

		// Token: 0x04001935 RID: 6453
		internal int b;

		// Token: 0x04001936 RID: 6454
		internal NumberingType c;

		// Token: 0x04001937 RID: 6455
		internal ahj d;

		// Token: 0x04001938 RID: 6456
		internal int e;

		// Token: 0x04001939 RID: 6457
		internal char f;
	}
}
