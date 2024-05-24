using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x02000039 RID: 57
	internal class a2
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00032ED4 File Offset: 0x00031ED4
		internal BitArray a(string A_0, byte[] A_1, int A_2, int A_3, int A_4, int A_5)
		{
			this.q = A_2;
			this.p = A_3;
			this.e = A_5;
			this.c = A_0;
			this.d = A_1;
			this.t = A_4;
			this.n = this.j[A_2, A_3];
			this.m = this.i[A_2] - this.n;
			this.r = (int)a2.h[A_2];
			short[] a_ = this.d();
			short[] a_2 = this.d(a_);
			short[] a_3 = this.c(a_2);
			return this.a(a_3);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00032F6C File Offset: 0x00031F6C
		internal int a(char[] A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (char c in A_0)
			{
				if (c >= '0' && c <= '9')
				{
					num++;
				}
				else if (c >= 'A' && c <= 'Z')
				{
					num2++;
				}
				else if (c == ' ' || c == '$' || c == '%' || c == '*' || c == '+' || c == '-' || c == '.' || c == '/' || c == ':' || c == '\0')
				{
					num2++;
				}
				else if ((c >= '\u3000' && c < '滌') || (c >= '漾' && c <= '熙'))
				{
					num4++;
				}
				else
				{
					num3++;
				}
				if (num3 > 0)
				{
					break;
				}
				if (num4 > 0 && (num2 > 0 || num > 0))
				{
					break;
				}
			}
			int result;
			if (num3 > 0 || (num4 > 0 && (num2 > 0 || num > 0)))
			{
				result = 2;
			}
			else if (num2 > 0)
			{
				result = 1;
			}
			else if (num4 > 0)
			{
				result = 3;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000330FC File Offset: 0x000320FC
		internal int a(int A_0, int A_1, int A_2)
		{
			if (A_1 == 2)
			{
				switch (A_2)
				{
				case 0:
					if (A_0 < 17)
					{
						this.u = 0;
					}
					else if (A_0 < 32)
					{
						this.u = 1;
					}
					else if (A_0 < 53)
					{
						this.u = 2;
					}
					else if (A_0 < 78)
					{
						this.u = 3;
					}
					else if (A_0 < 106)
					{
						this.u = 4;
					}
					else if (A_0 < 134)
					{
						this.u = 5;
					}
					else if (A_0 < 154)
					{
						this.u = 6;
					}
					else if (A_0 < 192)
					{
						this.u = 7;
					}
					else if (A_0 < 230)
					{
						this.u = 8;
					}
					else if (A_0 < 271)
					{
						this.u = 9;
					}
					else if (A_0 < 321)
					{
						this.u = 10;
					}
					else if (A_0 < 367)
					{
						this.u = 11;
					}
					else if (A_0 < 425)
					{
						this.u = 12;
					}
					else if (A_0 <= 458)
					{
						this.u = 13;
					}
					else if (A_0 < 520)
					{
						this.u = 14;
					}
					else if (A_0 < 586)
					{
						this.u = 15;
					}
					else if (A_0 < 644)
					{
						this.u = 16;
					}
					else if (A_0 < 718)
					{
						this.u = 17;
					}
					else if (A_0 < 792)
					{
						this.u = 18;
					}
					else if (A_0 < 858)
					{
						this.u = 19;
					}
					else if (A_0 < 929)
					{
						this.u = 20;
					}
					else if (A_0 < 1003)
					{
						this.u = 21;
					}
					else if (A_0 < 1091)
					{
						this.u = 22;
					}
					else if (A_0 < 1171)
					{
						this.u = 23;
					}
					else if (A_0 < 1273)
					{
						this.u = 24;
					}
					else if (A_0 < 1367)
					{
						this.u = 25;
					}
					else if (A_0 < 1465)
					{
						this.u = 26;
					}
					else if (A_0 < 1528)
					{
						this.u = 27;
					}
					else if (A_0 < 1628)
					{
						this.u = 28;
					}
					else if (A_0 < 1732)
					{
						this.u = 29;
					}
					else if (A_0 < 1840)
					{
						this.u = 30;
					}
					else if (A_0 < 1952)
					{
						this.u = 31;
					}
					else if (A_0 < 2068)
					{
						this.u = 32;
					}
					else if (A_0 < 2188)
					{
						this.u = 33;
					}
					else if (A_0 < 2303)
					{
						this.u = 34;
					}
					else if (A_0 < 2431)
					{
						this.u = 35;
					}
					else if (A_0 < 2563)
					{
						this.u = 36;
					}
					else if (A_0 < 2699)
					{
						this.u = 37;
					}
					else if (A_0 < 2809)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 2953)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 1:
					if (A_0 < 14)
					{
						this.u = 0;
					}
					else if (A_0 < 26)
					{
						this.u = 1;
					}
					else if (A_0 < 42)
					{
						this.u = 2;
					}
					else if (A_0 < 62)
					{
						this.u = 3;
					}
					else if (A_0 < 84)
					{
						this.u = 4;
					}
					else if (A_0 < 106)
					{
						this.u = 5;
					}
					else if (A_0 < 122)
					{
						this.u = 6;
					}
					else if (A_0 < 152)
					{
						this.u = 7;
					}
					else if (A_0 < 180)
					{
						this.u = 8;
					}
					else if (A_0 < 213)
					{
						this.u = 9;
					}
					else if (A_0 < 251)
					{
						this.u = 10;
					}
					else if (A_0 < 287)
					{
						this.u = 11;
					}
					else if (A_0 < 331)
					{
						this.u = 12;
					}
					else if (A_0 < 362)
					{
						this.u = 13;
					}
					else if (A_0 < 412)
					{
						this.u = 14;
					}
					else if (A_0 < 450)
					{
						this.u = 15;
					}
					else if (A_0 < 504)
					{
						this.u = 16;
					}
					else if (A_0 < 560)
					{
						this.u = 17;
					}
					else if (A_0 < 624)
					{
						this.u = 18;
					}
					else if (A_0 < 666)
					{
						this.u = 19;
					}
					else if (A_0 < 711)
					{
						this.u = 20;
					}
					else if (A_0 < 779)
					{
						this.u = 21;
					}
					else if (A_0 < 857)
					{
						this.u = 22;
					}
					else if (A_0 < 911)
					{
						this.u = 23;
					}
					else if (A_0 < 997)
					{
						this.u = 24;
					}
					else if (A_0 < 1059)
					{
						this.u = 25;
					}
					else if (A_0 < 1125)
					{
						this.u = 26;
					}
					else if (A_0 < 1190)
					{
						this.u = 27;
					}
					else if (A_0 < 1264)
					{
						this.u = 28;
					}
					else if (A_0 < 1370)
					{
						this.u = 29;
					}
					else if (A_0 < 1452)
					{
						this.u = 30;
					}
					else if (A_0 < 1538)
					{
						this.u = 31;
					}
					else if (A_0 < 1628)
					{
						this.u = 32;
					}
					else if (A_0 < 1722)
					{
						this.u = 33;
					}
					else if (A_0 < 1809)
					{
						this.u = 34;
					}
					else if (A_0 < 1911)
					{
						this.u = 35;
					}
					else if (A_0 < 1989)
					{
						this.u = 36;
					}
					else if (A_0 < 2099)
					{
						this.u = 37;
					}
					else if (A_0 < 2213)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 2331)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 2:
					if (A_0 < 11)
					{
						this.u = 0;
					}
					else if (A_0 < 20)
					{
						this.u = 1;
					}
					else if (A_0 < 32)
					{
						this.u = 2;
					}
					else if (A_0 < 46)
					{
						this.u = 3;
					}
					else if (A_0 < 60)
					{
						this.u = 4;
					}
					else if (A_0 < 74)
					{
						this.u = 5;
					}
					else if (A_0 < 86)
					{
						this.u = 6;
					}
					else if (A_0 < 108)
					{
						this.u = 7;
					}
					else if (A_0 < 130)
					{
						this.u = 8;
					}
					else if (A_0 < 151)
					{
						this.u = 9;
					}
					else if (A_0 < 177)
					{
						this.u = 10;
					}
					else if (A_0 < 203)
					{
						this.u = 11;
					}
					else if (A_0 < 241)
					{
						this.u = 12;
					}
					else if (A_0 < 258)
					{
						this.u = 13;
					}
					else if (A_0 < 292)
					{
						this.u = 14;
					}
					else if (A_0 < 322)
					{
						this.u = 15;
					}
					else if (A_0 < 364)
					{
						this.u = 16;
					}
					else if (A_0 < 394)
					{
						this.u = 17;
					}
					else if (A_0 < 442)
					{
						this.u = 18;
					}
					else if (A_0 < 482)
					{
						this.u = 19;
					}
					else if (A_0 < 509)
					{
						this.u = 20;
					}
					else if (A_0 < 565)
					{
						this.u = 21;
					}
					else if (A_0 < 611)
					{
						this.u = 22;
					}
					else if (A_0 < 661)
					{
						this.u = 23;
					}
					else if (A_0 < 715)
					{
						this.u = 24;
					}
					else if (A_0 < 751)
					{
						this.u = 25;
					}
					else if (A_0 < 805)
					{
						this.u = 26;
					}
					else if (A_0 < 868)
					{
						this.u = 27;
					}
					else if (A_0 < 908)
					{
						this.u = 28;
					}
					else if (A_0 < 982)
					{
						this.u = 29;
					}
					else if (A_0 < 1030)
					{
						this.u = 30;
					}
					else if (A_0 < 1112)
					{
						this.u = 31;
					}
					else if (A_0 < 1168)
					{
						this.u = 32;
					}
					else if (A_0 < 1228)
					{
						this.u = 33;
					}
					else if (A_0 < 1283)
					{
						this.u = 34;
					}
					else if (A_0 < 1351)
					{
						this.u = 35;
					}
					else if (A_0 < 1423)
					{
						this.u = 36;
					}
					else if (A_0 < 1499)
					{
						this.u = 37;
					}
					else if (A_0 < 1579)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1663)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 3:
					if (A_0 < 7)
					{
						this.u = 0;
					}
					else if (A_0 < 14)
					{
						this.u = 1;
					}
					else if (A_0 < 24)
					{
						this.u = 2;
					}
					else if (A_0 < 34)
					{
						this.u = 3;
					}
					else if (A_0 < 44)
					{
						this.u = 4;
					}
					else if (A_0 < 58)
					{
						this.u = 5;
					}
					else if (A_0 < 64)
					{
						this.u = 6;
					}
					else if (A_0 < 84)
					{
						this.u = 7;
					}
					else if (A_0 < 98)
					{
						this.u = 8;
					}
					else if (A_0 < 119)
					{
						this.u = 9;
					}
					else if (A_0 < 137)
					{
						this.u = 10;
					}
					else if (A_0 < 155)
					{
						this.u = 11;
					}
					else if (A_0 < 177)
					{
						this.u = 12;
					}
					else if (A_0 < 194)
					{
						this.u = 13;
					}
					else if (A_0 < 220)
					{
						this.u = 14;
					}
					else if (A_0 < 250)
					{
						this.u = 15;
					}
					else if (A_0 < 280)
					{
						this.u = 16;
					}
					else if (A_0 < 310)
					{
						this.u = 17;
					}
					else if (A_0 < 338)
					{
						this.u = 18;
					}
					else if (A_0 < 382)
					{
						this.u = 19;
					}
					else if (A_0 < 403)
					{
						this.u = 20;
					}
					else if (A_0 < 439)
					{
						this.u = 21;
					}
					else if (A_0 < 461)
					{
						this.u = 22;
					}
					else if (A_0 < 511)
					{
						this.u = 23;
					}
					else if (A_0 < 535)
					{
						this.u = 24;
					}
					else if (A_0 < 593)
					{
						this.u = 25;
					}
					else if (A_0 < 625)
					{
						this.u = 26;
					}
					else if (A_0 < 658)
					{
						this.u = 27;
					}
					else if (A_0 < 698)
					{
						this.u = 28;
					}
					else if (A_0 < 742)
					{
						this.u = 29;
					}
					else if (A_0 < 790)
					{
						this.u = 30;
					}
					else if (A_0 < 842)
					{
						this.u = 31;
					}
					else if (A_0 < 898)
					{
						this.u = 32;
					}
					else if (A_0 < 958)
					{
						this.u = 33;
					}
					else if (A_0 < 983)
					{
						this.u = 34;
					}
					else if (A_0 < 1051)
					{
						this.u = 35;
					}
					else if (A_0 < 1093)
					{
						this.u = 36;
					}
					else if (A_0 < 1139)
					{
						this.u = 37;
					}
					else if (A_0 < 1219)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1273)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				}
			}
			else if (A_1 == 1)
			{
				switch (A_2)
				{
				case 0:
					if (A_0 < 25)
					{
						this.u = 0;
					}
					else if (A_0 < 47)
					{
						this.u = 1;
					}
					else if (A_0 < 77)
					{
						this.u = 2;
					}
					else if (A_0 < 114)
					{
						this.u = 3;
					}
					else if (A_0 < 154)
					{
						this.u = 4;
					}
					else if (A_0 < 195)
					{
						this.u = 5;
					}
					else if (A_0 < 224)
					{
						this.u = 6;
					}
					else if (A_0 < 279)
					{
						this.u = 7;
					}
					else if (A_0 < 335)
					{
						this.u = 8;
					}
					else if (A_0 < 395)
					{
						this.u = 9;
					}
					else if (A_0 < 468)
					{
						this.u = 10;
					}
					else if (A_0 < 535)
					{
						this.u = 11;
					}
					else if (A_0 < 619)
					{
						this.u = 12;
					}
					else if (A_0 < 667)
					{
						this.u = 13;
					}
					else if (A_0 < 758)
					{
						this.u = 14;
					}
					else if (A_0 < 854)
					{
						this.u = 15;
					}
					else if (A_0 < 938)
					{
						this.u = 16;
					}
					else if (A_0 < 1046)
					{
						this.u = 17;
					}
					else if (A_0 < 1153)
					{
						this.u = 18;
					}
					else if (A_0 < 1249)
					{
						this.u = 19;
					}
					else if (A_0 < 1352)
					{
						this.u = 20;
					}
					else if (A_0 < 1460)
					{
						this.u = 21;
					}
					else if (A_0 < 1588)
					{
						this.u = 22;
					}
					else if (A_0 < 1704)
					{
						this.u = 23;
					}
					else if (A_0 < 1853)
					{
						this.u = 24;
					}
					else if (A_0 < 1990)
					{
						this.u = 25;
					}
					else if (A_0 < 2132)
					{
						this.u = 26;
					}
					else if (A_0 < 2223)
					{
						this.u = 27;
					}
					else if (A_0 < 2369)
					{
						this.u = 28;
					}
					else if (A_0 < 2520)
					{
						this.u = 29;
					}
					else if (A_0 < 2677)
					{
						this.u = 30;
					}
					else if (A_0 < 2840)
					{
						this.u = 31;
					}
					else if (A_0 < 3009)
					{
						this.u = 32;
					}
					else if (A_0 < 3183)
					{
						this.u = 33;
					}
					else if (A_0 < 3351)
					{
						this.u = 34;
					}
					else if (A_0 < 3537)
					{
						this.u = 35;
					}
					else if (A_0 < 3729)
					{
						this.u = 36;
					}
					else if (A_0 < 3927)
					{
						this.u = 37;
					}
					else if (A_0 < 4087)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 4296)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 1:
					if (A_0 < 20)
					{
						this.u = 0;
					}
					else if (A_0 < 38)
					{
						this.u = 1;
					}
					else if (A_0 < 61)
					{
						this.u = 2;
					}
					else if (A_0 < 90)
					{
						this.u = 3;
					}
					else if (A_0 < 122)
					{
						this.u = 4;
					}
					else if (A_0 < 154)
					{
						this.u = 5;
					}
					else if (A_0 < 178)
					{
						this.u = 6;
					}
					else if (A_0 < 221)
					{
						this.u = 7;
					}
					else if (A_0 < 262)
					{
						this.u = 8;
					}
					else if (A_0 < 311)
					{
						this.u = 9;
					}
					else if (A_0 < 366)
					{
						this.u = 10;
					}
					else if (A_0 < 419)
					{
						this.u = 11;
					}
					else if (A_0 < 483)
					{
						this.u = 12;
					}
					else if (A_0 < 528)
					{
						this.u = 13;
					}
					else if (A_0 < 600)
					{
						this.u = 14;
					}
					else if (A_0 < 656)
					{
						this.u = 15;
					}
					else if (A_0 < 734)
					{
						this.u = 16;
					}
					else if (A_0 < 816)
					{
						this.u = 17;
					}
					else if (A_0 < 909)
					{
						this.u = 18;
					}
					else if (A_0 < 970)
					{
						this.u = 19;
					}
					else if (A_0 < 1035)
					{
						this.u = 20;
					}
					else if (A_0 < 1134)
					{
						this.u = 21;
					}
					else if (A_0 < 1248)
					{
						this.u = 22;
					}
					else if (A_0 < 1326)
					{
						this.u = 23;
					}
					else if (A_0 < 1451)
					{
						this.u = 24;
					}
					else if (A_0 < 1542)
					{
						this.u = 25;
					}
					else if (A_0 < 1637)
					{
						this.u = 26;
					}
					else if (A_0 < 1732)
					{
						this.u = 27;
					}
					else if (A_0 < 1839)
					{
						this.u = 28;
					}
					else if (A_0 < 1994)
					{
						this.u = 29;
					}
					else if (A_0 < 2113)
					{
						this.u = 30;
					}
					else if (A_0 < 2238)
					{
						this.u = 31;
					}
					else if (A_0 < 2369)
					{
						this.u = 32;
					}
					else if (A_0 < 2506)
					{
						this.u = 33;
					}
					else if (A_0 < 2632)
					{
						this.u = 34;
					}
					else if (A_0 < 2780)
					{
						this.u = 35;
					}
					else if (A_0 < 2894)
					{
						this.u = 36;
					}
					else if (A_0 < 3054)
					{
						this.u = 37;
					}
					else if (A_0 < 3220)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 3391)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 2:
					if (A_0 < 16)
					{
						this.u = 0;
					}
					else if (A_0 < 29)
					{
						this.u = 1;
					}
					else if (A_0 < 47)
					{
						this.u = 2;
					}
					else if (A_0 < 67)
					{
						this.u = 3;
					}
					else if (A_0 < 87)
					{
						this.u = 4;
					}
					else if (A_0 < 108)
					{
						this.u = 5;
					}
					else if (A_0 < 125)
					{
						this.u = 6;
					}
					else if (A_0 < 157)
					{
						this.u = 7;
					}
					else if (A_0 < 189)
					{
						this.u = 8;
					}
					else if (A_0 < 221)
					{
						this.u = 9;
					}
					else if (A_0 < 259)
					{
						this.u = 10;
					}
					else if (A_0 < 296)
					{
						this.u = 11;
					}
					else if (A_0 < 352)
					{
						this.u = 12;
					}
					else if (A_0 < 376)
					{
						this.u = 13;
					}
					else if (A_0 < 426)
					{
						this.u = 14;
					}
					else if (A_0 < 470)
					{
						this.u = 15;
					}
					else if (A_0 < 531)
					{
						this.u = 16;
					}
					else if (A_0 < 574)
					{
						this.u = 17;
					}
					else if (A_0 < 644)
					{
						this.u = 18;
					}
					else if (A_0 < 702)
					{
						this.u = 19;
					}
					else if (A_0 < 742)
					{
						this.u = 20;
					}
					else if (A_0 < 823)
					{
						this.u = 21;
					}
					else if (A_0 < 890)
					{
						this.u = 22;
					}
					else if (A_0 < 963)
					{
						this.u = 23;
					}
					else if (A_0 < 1041)
					{
						this.u = 24;
					}
					else if (A_0 < 1094)
					{
						this.u = 25;
					}
					else if (A_0 < 1172)
					{
						this.u = 26;
					}
					else if (A_0 < 1263)
					{
						this.u = 27;
					}
					else if (A_0 < 1322)
					{
						this.u = 28;
					}
					else if (A_0 < 1429)
					{
						this.u = 29;
					}
					else if (A_0 < 1499)
					{
						this.u = 30;
					}
					else if (A_0 < 1618)
					{
						this.u = 31;
					}
					else if (A_0 < 1700)
					{
						this.u = 32;
					}
					else if (A_0 < 1787)
					{
						this.u = 33;
					}
					else if (A_0 < 1867)
					{
						this.u = 34;
					}
					else if (A_0 < 1966)
					{
						this.u = 35;
					}
					else if (A_0 < 2071)
					{
						this.u = 36;
					}
					else if (A_0 < 2181)
					{
						this.u = 37;
					}
					else if (A_0 < 2298)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 2420)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 3:
					if (A_0 < 10)
					{
						this.u = 0;
					}
					else if (A_0 < 20)
					{
						this.u = 1;
					}
					else if (A_0 < 35)
					{
						this.u = 2;
					}
					else if (A_0 < 50)
					{
						this.u = 3;
					}
					else if (A_0 < 64)
					{
						this.u = 4;
					}
					else if (A_0 < 84)
					{
						this.u = 5;
					}
					else if (A_0 < 93)
					{
						this.u = 6;
					}
					else if (A_0 < 122)
					{
						this.u = 7;
					}
					else if (A_0 < 143)
					{
						this.u = 8;
					}
					else if (A_0 < 174)
					{
						this.u = 9;
					}
					else if (A_0 < 200)
					{
						this.u = 10;
					}
					else if (A_0 < 227)
					{
						this.u = 11;
					}
					else if (A_0 < 259)
					{
						this.u = 12;
					}
					else if (A_0 < 283)
					{
						this.u = 13;
					}
					else if (A_0 < 321)
					{
						this.u = 14;
					}
					else if (A_0 < 365)
					{
						this.u = 15;
					}
					else if (A_0 < 408)
					{
						this.u = 16;
					}
					else if (A_0 < 452)
					{
						this.u = 17;
					}
					else if (A_0 < 493)
					{
						this.u = 18;
					}
					else if (A_0 < 557)
					{
						this.u = 19;
					}
					else if (A_0 < 587)
					{
						this.u = 20;
					}
					else if (A_0 < 640)
					{
						this.u = 21;
					}
					else if (A_0 < 672)
					{
						this.u = 22;
					}
					else if (A_0 < 744)
					{
						this.u = 23;
					}
					else if (A_0 < 779)
					{
						this.u = 24;
					}
					else if (A_0 < 864)
					{
						this.u = 25;
					}
					else if (A_0 < 910)
					{
						this.u = 26;
					}
					else if (A_0 < 958)
					{
						this.u = 27;
					}
					else if (A_0 < 1016)
					{
						this.u = 28;
					}
					else if (A_0 < 1080)
					{
						this.u = 29;
					}
					else if (A_0 < 1150)
					{
						this.u = 30;
					}
					else if (A_0 < 1226)
					{
						this.u = 31;
					}
					else if (A_0 < 1307)
					{
						this.u = 32;
					}
					else if (A_0 < 1394)
					{
						this.u = 33;
					}
					else if (A_0 < 1431)
					{
						this.u = 34;
					}
					else if (A_0 < 1530)
					{
						this.u = 35;
					}
					else if (A_0 < 1591)
					{
						this.u = 36;
					}
					else if (A_0 < 1658)
					{
						this.u = 37;
					}
					else if (A_0 < 1774)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1852)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				}
			}
			else if (A_1 == 0)
			{
				switch (A_2)
				{
				case 0:
					if (A_0 < 40)
					{
						this.u = 0;
					}
					else if (A_0 < 76)
					{
						this.u = 1;
					}
					else if (A_0 < 126)
					{
						this.u = 2;
					}
					else if (A_0 < 186)
					{
						this.u = 3;
					}
					else if (A_0 < 254)
					{
						this.u = 4;
					}
					else if (A_0 < 321)
					{
						this.u = 5;
					}
					else if (A_0 < 369)
					{
						this.u = 6;
					}
					else if (A_0 < 460)
					{
						this.u = 7;
					}
					else if (A_0 < 551)
					{
						this.u = 8;
					}
					else if (A_0 < 651)
					{
						this.u = 9;
					}
					else if (A_0 < 771)
					{
						this.u = 10;
					}
					else if (A_0 < 882)
					{
						this.u = 11;
					}
					else if (A_0 < 1021)
					{
						this.u = 12;
					}
					else if (A_0 < 1100)
					{
						this.u = 13;
					}
					else if (A_0 < 1249)
					{
						this.u = 14;
					}
					else if (A_0 < 1407)
					{
						this.u = 15;
					}
					else if (A_0 < 1547)
					{
						this.u = 16;
					}
					else if (A_0 < 1724)
					{
						this.u = 17;
					}
					else if (A_0 < 1902)
					{
						this.u = 18;
					}
					else if (A_0 < 2060)
					{
						this.u = 19;
					}
					else if (A_0 < 2231)
					{
						this.u = 20;
					}
					else if (A_0 < 2408)
					{
						this.u = 21;
					}
					else if (A_0 < 2619)
					{
						this.u = 22;
					}
					else if (A_0 < 2811)
					{
						this.u = 23;
					}
					else if (A_0 < 3056)
					{
						this.u = 24;
					}
					else if (A_0 < 3282)
					{
						this.u = 25;
					}
					else if (A_0 < 3516)
					{
						this.u = 26;
					}
					else if (A_0 < 3668)
					{
						this.u = 27;
					}
					else if (A_0 < 3908)
					{
						this.u = 28;
					}
					else if (A_0 < 4157)
					{
						this.u = 29;
					}
					else if (A_0 < 4416)
					{
						this.u = 30;
					}
					else if (A_0 < 4685)
					{
						this.u = 31;
					}
					else if (A_0 < 4964)
					{
						this.u = 32;
					}
					else if (A_0 < 5252)
					{
						this.u = 33;
					}
					else if (A_0 < 5528)
					{
						this.u = 34;
					}
					else if (A_0 < 5835)
					{
						this.u = 35;
					}
					else if (A_0 < 6152)
					{
						this.u = 36;
					}
					else if (A_0 < 6478)
					{
						this.u = 37;
					}
					else if (A_0 < 6742)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 7088)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 1:
					if (A_0 < 33)
					{
						this.u = 0;
					}
					else if (A_0 < 62)
					{
						this.u = 1;
					}
					else if (A_0 < 100)
					{
						this.u = 2;
					}
					else if (A_0 < 148)
					{
						this.u = 3;
					}
					else if (A_0 < 201)
					{
						this.u = 4;
					}
					else if (A_0 < 254)
					{
						this.u = 5;
					}
					else if (A_0 < 292)
					{
						this.u = 6;
					}
					else if (A_0 < 364)
					{
						this.u = 7;
					}
					else if (A_0 < 431)
					{
						this.u = 8;
					}
					else if (A_0 < 512)
					{
						this.u = 9;
					}
					else if (A_0 < 603)
					{
						this.u = 10;
					}
					else if (A_0 < 690)
					{
						this.u = 11;
					}
					else if (A_0 < 795)
					{
						this.u = 12;
					}
					else if (A_0 < 870)
					{
						this.u = 13;
					}
					else if (A_0 < 990)
					{
						this.u = 14;
					}
					else if (A_0 < 1081)
					{
						this.u = 15;
					}
					else if (A_0 < 1211)
					{
						this.u = 16;
					}
					else if (A_0 < 1345)
					{
						this.u = 17;
					}
					else if (A_0 < 1499)
					{
						this.u = 18;
					}
					else if (A_0 < 1599)
					{
						this.u = 19;
					}
					else if (A_0 < 1707)
					{
						this.u = 20;
					}
					else if (A_0 < 1871)
					{
						this.u = 21;
					}
					else if (A_0 < 2058)
					{
						this.u = 22;
					}
					else if (A_0 < 2187)
					{
						this.u = 23;
					}
					else if (A_0 < 2394)
					{
						this.u = 24;
					}
					else if (A_0 < 2543)
					{
						this.u = 25;
					}
					else if (A_0 < 2700)
					{
						this.u = 26;
					}
					else if (A_0 < 2856)
					{
						this.u = 27;
					}
					else if (A_0 < 3034)
					{
						this.u = 28;
					}
					else if (A_0 < 3288)
					{
						this.u = 29;
					}
					else if (A_0 < 3485)
					{
						this.u = 30;
					}
					else if (A_0 < 3692)
					{
						this.u = 31;
					}
					else if (A_0 < 3908)
					{
						this.u = 32;
					}
					else if (A_0 < 4133)
					{
						this.u = 33;
					}
					else if (A_0 < 4342)
					{
						this.u = 34;
					}
					else if (A_0 < 4587)
					{
						this.u = 35;
					}
					else if (A_0 < 4774)
					{
						this.u = 36;
					}
					else if (A_0 < 5038)
					{
						this.u = 37;
					}
					else if (A_0 < 5312)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 5595)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 2:
					if (A_0 < 26)
					{
						this.u = 0;
					}
					else if (A_0 < 47)
					{
						this.u = 1;
					}
					else if (A_0 < 76)
					{
						this.u = 2;
					}
					else if (A_0 < 110)
					{
						this.u = 3;
					}
					else if (A_0 < 143)
					{
						this.u = 4;
					}
					else if (A_0 < 177)
					{
						this.u = 5;
					}
					else if (A_0 < 206)
					{
						this.u = 6;
					}
					else if (A_0 < 258)
					{
						this.u = 7;
					}
					else if (A_0 < 311)
					{
						this.u = 8;
					}
					else if (A_0 < 363)
					{
						this.u = 9;
					}
					else if (A_0 < 426)
					{
						this.u = 10;
					}
					else if (A_0 < 488)
					{
						this.u = 11;
					}
					else if (A_0 < 579)
					{
						this.u = 12;
					}
					else if (A_0 < 620)
					{
						this.u = 13;
					}
					else if (A_0 < 702)
					{
						this.u = 14;
					}
					else if (A_0 < 774)
					{
						this.u = 15;
					}
					else if (A_0 < 875)
					{
						this.u = 16;
					}
					else if (A_0 < 947)
					{
						this.u = 17;
					}
					else if (A_0 < 1062)
					{
						this.u = 18;
					}
					else if (A_0 < 1158)
					{
						this.u = 19;
					}
					else if (A_0 < 1223)
					{
						this.u = 20;
					}
					else if (A_0 < 1357)
					{
						this.u = 21;
					}
					else if (A_0 < 1467)
					{
						this.u = 22;
					}
					else if (A_0 < 1587)
					{
						this.u = 23;
					}
					else if (A_0 < 1717)
					{
						this.u = 24;
					}
					else if (A_0 < 1803)
					{
						this.u = 25;
					}
					else if (A_0 < 1932)
					{
						this.u = 26;
					}
					else if (A_0 < 2084)
					{
						this.u = 27;
					}
					else if (A_0 < 2180)
					{
						this.u = 28;
					}
					else if (A_0 < 2357)
					{
						this.u = 29;
					}
					else if (A_0 < 2472)
					{
						this.u = 30;
					}
					else if (A_0 < 2669)
					{
						this.u = 31;
					}
					else if (A_0 < 2804)
					{
						this.u = 32;
					}
					else if (A_0 < 2948)
					{
						this.u = 33;
					}
					else if (A_0 < 3080)
					{
						this.u = 34;
					}
					else if (A_0 < 3243)
					{
						this.u = 35;
					}
					else if (A_0 < 3416)
					{
						this.u = 36;
					}
					else if (A_0 < 3598)
					{
						this.u = 37;
					}
					else if (A_0 < 3790)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 3992)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 3:
					if (A_0 < 16)
					{
						this.u = 0;
					}
					else if (A_0 < 33)
					{
						this.u = 1;
					}
					else if (A_0 < 57)
					{
						this.u = 2;
					}
					else if (A_0 < 81)
					{
						this.u = 3;
					}
					else if (A_0 < 105)
					{
						this.u = 4;
					}
					else if (A_0 < 138)
					{
						this.u = 5;
					}
					else if (A_0 < 153)
					{
						this.u = 6;
					}
					else if (A_0 < 201)
					{
						this.u = 7;
					}
					else if (A_0 < 234)
					{
						this.u = 8;
					}
					else if (A_0 < 287)
					{
						this.u = 9;
					}
					else if (A_0 < 330)
					{
						this.u = 10;
					}
					else if (A_0 < 373)
					{
						this.u = 11;
					}
					else if (A_0 < 426)
					{
						this.u = 12;
					}
					else if (A_0 < 467)
					{
						this.u = 13;
					}
					else if (A_0 < 529)
					{
						this.u = 14;
					}
					else if (A_0 < 601)
					{
						this.u = 15;
					}
					else if (A_0 < 673)
					{
						this.u = 16;
					}
					else if (A_0 < 745)
					{
						this.u = 17;
					}
					else if (A_0 < 812)
					{
						this.u = 18;
					}
					else if (A_0 < 918)
					{
						this.u = 19;
					}
					else if (A_0 < 968)
					{
						this.u = 20;
					}
					else if (A_0 < 1055)
					{
						this.u = 21;
					}
					else if (A_0 < 1107)
					{
						this.u = 22;
					}
					else if (A_0 < 1227)
					{
						this.u = 23;
					}
					else if (A_0 < 1285)
					{
						this.u = 24;
					}
					else if (A_0 < 1424)
					{
						this.u = 25;
					}
					else if (A_0 < 1500)
					{
						this.u = 26;
					}
					else if (A_0 < 1580)
					{
						this.u = 27;
					}
					else if (A_0 < 1676)
					{
						this.u = 28;
					}
					else if (A_0 < 1781)
					{
						this.u = 29;
					}
					else if (A_0 < 1896)
					{
						this.u = 30;
					}
					else if (A_0 < 2021)
					{
						this.u = 31;
					}
					else if (A_0 < 2156)
					{
						this.u = 32;
					}
					else if (A_0 < 2300)
					{
						this.u = 33;
					}
					else if (A_0 < 2360)
					{
						this.u = 34;
					}
					else if (A_0 < 2523)
					{
						this.u = 35;
					}
					else if (A_0 < 2624)
					{
						this.u = 36;
					}
					else if (A_0 < 2734)
					{
						this.u = 37;
					}
					else if (A_0 < 2926)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 3056)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				}
			}
			else if (A_1 == 3)
			{
				switch (A_2)
				{
				case 0:
					if (A_0 < 10)
					{
						this.u = 0;
					}
					else if (A_0 < 20)
					{
						this.u = 1;
					}
					else if (A_0 < 32)
					{
						this.u = 2;
					}
					else if (A_0 < 48)
					{
						this.u = 3;
					}
					else if (A_0 < 65)
					{
						this.u = 4;
					}
					else if (A_0 < 82)
					{
						this.u = 5;
					}
					else if (A_0 < 95)
					{
						this.u = 6;
					}
					else if (A_0 < 118)
					{
						this.u = 7;
					}
					else if (A_0 < 141)
					{
						this.u = 8;
					}
					else if (A_0 < 167)
					{
						this.u = 9;
					}
					else if (A_0 < 198)
					{
						this.u = 10;
					}
					else if (A_0 < 226)
					{
						this.u = 11;
					}
					else if (A_0 < 262)
					{
						this.u = 12;
					}
					else if (A_0 < 282)
					{
						this.u = 13;
					}
					else if (A_0 < 320)
					{
						this.u = 14;
					}
					else if (A_0 < 361)
					{
						this.u = 15;
					}
					else if (A_0 < 397)
					{
						this.u = 16;
					}
					else if (A_0 < 442)
					{
						this.u = 17;
					}
					else if (A_0 < 488)
					{
						this.u = 18;
					}
					else if (A_0 < 528)
					{
						this.u = 19;
					}
					else if (A_0 < 572)
					{
						this.u = 20;
					}
					else if (A_0 < 618)
					{
						this.u = 21;
					}
					else if (A_0 < 672)
					{
						this.u = 22;
					}
					else if (A_0 < 721)
					{
						this.u = 23;
					}
					else if (A_0 < 784)
					{
						this.u = 24;
					}
					else if (A_0 < 842)
					{
						this.u = 25;
					}
					else if (A_0 < 902)
					{
						this.u = 26;
					}
					else if (A_0 < 940)
					{
						this.u = 27;
					}
					else if (A_0 < 1002)
					{
						this.u = 28;
					}
					else if (A_0 < 1066)
					{
						this.u = 29;
					}
					else if (A_0 < 1132)
					{
						this.u = 30;
					}
					else if (A_0 < 1201)
					{
						this.u = 31;
					}
					else if (A_0 < 1273)
					{
						this.u = 32;
					}
					else if (A_0 < 1347)
					{
						this.u = 33;
					}
					else if (A_0 < 1417)
					{
						this.u = 34;
					}
					else if (A_0 < 1496)
					{
						this.u = 35;
					}
					else if (A_0 < 1577)
					{
						this.u = 36;
					}
					else if (A_0 < 1661)
					{
						this.u = 37;
					}
					else if (A_0 < 1729)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1817)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 1:
					if (A_0 < 8)
					{
						this.u = 0;
					}
					else if (A_0 < 16)
					{
						this.u = 1;
					}
					else if (A_0 < 26)
					{
						this.u = 2;
					}
					else if (A_0 < 38)
					{
						this.u = 3;
					}
					else if (A_0 < 52)
					{
						this.u = 4;
					}
					else if (A_0 < 65)
					{
						this.u = 5;
					}
					else if (A_0 < 75)
					{
						this.u = 6;
					}
					else if (A_0 < 93)
					{
						this.u = 7;
					}
					else if (A_0 < 111)
					{
						this.u = 8;
					}
					else if (A_0 < 131)
					{
						this.u = 9;
					}
					else if (A_0 < 155)
					{
						this.u = 10;
					}
					else if (A_0 < 177)
					{
						this.u = 11;
					}
					else if (A_0 < 204)
					{
						this.u = 12;
					}
					else if (A_0 < 223)
					{
						this.u = 13;
					}
					else if (A_0 < 254)
					{
						this.u = 14;
					}
					else if (A_0 < 277)
					{
						this.u = 15;
					}
					else if (A_0 < 310)
					{
						this.u = 16;
					}
					else if (A_0 < 345)
					{
						this.u = 17;
					}
					else if (A_0 < 384)
					{
						this.u = 18;
					}
					else if (A_0 < 410)
					{
						this.u = 19;
					}
					else if (A_0 < 438)
					{
						this.u = 20;
					}
					else if (A_0 < 480)
					{
						this.u = 21;
					}
					else if (A_0 < 528)
					{
						this.u = 22;
					}
					else if (A_0 < 561)
					{
						this.u = 23;
					}
					else if (A_0 < 614)
					{
						this.u = 24;
					}
					else if (A_0 < 652)
					{
						this.u = 25;
					}
					else if (A_0 < 692)
					{
						this.u = 26;
					}
					else if (A_0 < 732)
					{
						this.u = 27;
					}
					else if (A_0 < 778)
					{
						this.u = 28;
					}
					else if (A_0 < 843)
					{
						this.u = 29;
					}
					else if (A_0 < 894)
					{
						this.u = 30;
					}
					else if (A_0 < 947)
					{
						this.u = 31;
					}
					else if (A_0 < 1002)
					{
						this.u = 32;
					}
					else if (A_0 < 1060)
					{
						this.u = 33;
					}
					else if (A_0 < 1113)
					{
						this.u = 34;
					}
					else if (A_0 < 1176)
					{
						this.u = 35;
					}
					else if (A_0 < 1224)
					{
						this.u = 36;
					}
					else if (A_0 < 1292)
					{
						this.u = 37;
					}
					else if (A_0 < 1362)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1435)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 2:
					if (A_0 < 7)
					{
						this.u = 0;
					}
					else if (A_0 < 12)
					{
						this.u = 1;
					}
					else if (A_0 < 20)
					{
						this.u = 2;
					}
					else if (A_0 < 28)
					{
						this.u = 3;
					}
					else if (A_0 < 37)
					{
						this.u = 4;
					}
					else if (A_0 < 45)
					{
						this.u = 5;
					}
					else if (A_0 < 53)
					{
						this.u = 6;
					}
					else if (A_0 < 66)
					{
						this.u = 7;
					}
					else if (A_0 < 80)
					{
						this.u = 8;
					}
					else if (A_0 < 93)
					{
						this.u = 9;
					}
					else if (A_0 < 109)
					{
						this.u = 10;
					}
					else if (A_0 < 125)
					{
						this.u = 11;
					}
					else if (A_0 < 149)
					{
						this.u = 12;
					}
					else if (A_0 < 159)
					{
						this.u = 13;
					}
					else if (A_0 < 180)
					{
						this.u = 14;
					}
					else if (A_0 < 198)
					{
						this.u = 15;
					}
					else if (A_0 < 224)
					{
						this.u = 16;
					}
					else if (A_0 < 243)
					{
						this.u = 17;
					}
					else if (A_0 < 272)
					{
						this.u = 18;
					}
					else if (A_0 < 297)
					{
						this.u = 19;
					}
					else if (A_0 < 314)
					{
						this.u = 20;
					}
					else if (A_0 < 348)
					{
						this.u = 21;
					}
					else if (A_0 < 376)
					{
						this.u = 22;
					}
					else if (A_0 < 407)
					{
						this.u = 23;
					}
					else if (A_0 < 440)
					{
						this.u = 24;
					}
					else if (A_0 < 462)
					{
						this.u = 25;
					}
					else if (A_0 < 496)
					{
						this.u = 26;
					}
					else if (A_0 < 534)
					{
						this.u = 27;
					}
					else if (A_0 < 559)
					{
						this.u = 28;
					}
					else if (A_0 < 604)
					{
						this.u = 29;
					}
					else if (A_0 < 634)
					{
						this.u = 30;
					}
					else if (A_0 < 684)
					{
						this.u = 31;
					}
					else if (A_0 < 719)
					{
						this.u = 32;
					}
					else if (A_0 < 756)
					{
						this.u = 33;
					}
					else if (A_0 < 790)
					{
						this.u = 34;
					}
					else if (A_0 < 832)
					{
						this.u = 35;
					}
					else if (A_0 < 876)
					{
						this.u = 36;
					}
					else if (A_0 < 923)
					{
						this.u = 37;
					}
					else if (A_0 < 972)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 1024)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				case 3:
					if (A_0 < 4)
					{
						this.u = 0;
					}
					else if (A_0 < 8)
					{
						this.u = 1;
					}
					else if (A_0 < 15)
					{
						this.u = 2;
					}
					else if (A_0 < 21)
					{
						this.u = 3;
					}
					else if (A_0 < 27)
					{
						this.u = 4;
					}
					else if (A_0 < 36)
					{
						this.u = 5;
					}
					else if (A_0 < 39)
					{
						this.u = 6;
					}
					else if (A_0 < 52)
					{
						this.u = 7;
					}
					else if (A_0 < 60)
					{
						this.u = 8;
					}
					else if (A_0 < 74)
					{
						this.u = 9;
					}
					else if (A_0 < 85)
					{
						this.u = 10;
					}
					else if (A_0 < 96)
					{
						this.u = 11;
					}
					else if (A_0 < 109)
					{
						this.u = 12;
					}
					else if (A_0 < 120)
					{
						this.u = 13;
					}
					else if (A_0 < 136)
					{
						this.u = 14;
					}
					else if (A_0 < 154)
					{
						this.u = 15;
					}
					else if (A_0 < 173)
					{
						this.u = 16;
					}
					else if (A_0 < 191)
					{
						this.u = 17;
					}
					else if (A_0 < 208)
					{
						this.u = 18;
					}
					else if (A_0 < 235)
					{
						this.u = 19;
					}
					else if (A_0 < 248)
					{
						this.u = 20;
					}
					else if (A_0 < 270)
					{
						this.u = 21;
					}
					else if (A_0 < 284)
					{
						this.u = 22;
					}
					else if (A_0 < 315)
					{
						this.u = 23;
					}
					else if (A_0 < 330)
					{
						this.u = 24;
					}
					else if (A_0 < 365)
					{
						this.u = 25;
					}
					else if (A_0 < 385)
					{
						this.u = 26;
					}
					else if (A_0 < 405)
					{
						this.u = 27;
					}
					else if (A_0 < 430)
					{
						this.u = 28;
					}
					else if (A_0 < 457)
					{
						this.u = 29;
					}
					else if (A_0 < 486)
					{
						this.u = 30;
					}
					else if (A_0 < 518)
					{
						this.u = 31;
					}
					else if (A_0 < 553)
					{
						this.u = 32;
					}
					else if (A_0 < 590)
					{
						this.u = 33;
					}
					else if (A_0 < 605)
					{
						this.u = 34;
					}
					else if (A_0 < 647)
					{
						this.u = 35;
					}
					else if (A_0 < 673)
					{
						this.u = 36;
					}
					else if (A_0 < 701)
					{
						this.u = 37;
					}
					else if (A_0 < 750)
					{
						this.u = 38;
					}
					else
					{
						if (A_0 >= 784)
						{
							throw new ao("Data exceeds the capacity of QR code.");
						}
						this.u = 39;
					}
					break;
				}
			}
			return this.u;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000375F4 File Offset: 0x000365F4
		internal byte c(int A_0)
		{
			return a2.h[A_0];
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00037610 File Offset: 0x00036610
		private short[] d()
		{
			short[] result = new short[0];
			if (!this.a(this.c))
			{
				throw new ap("Invalid character for the selected Encoding.");
			}
			switch (this.e)
			{
			case 0:
			{
				a4 a = new a4(this.m, this.t);
				result = a.a(Encoding.ASCII.GetBytes(this.c), this.q);
				break;
			}
			case 1:
			{
				a0 a2 = new a0(this.m, this.t);
				result = a2.a(Encoding.ASCII.GetBytes(this.c), this.q);
				break;
			}
			case 2:
			{
				a1 a3 = new a1(this.m, this.t);
				result = a3.a(this.d, this.q);
				break;
			}
			case 3:
			{
				a3 a4 = new a3(this.m, this.t);
				Encoding encoding = ae5.a(932);
				result = a4.a(encoding.GetBytes(this.c), this.q, this.c.Length);
				break;
			}
			}
			return result;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00037744 File Offset: 0x00036744
		private bool a(string A_0)
		{
			switch (this.e)
			{
			case 0:
				foreach (char c in A_0)
				{
					if (c < '0' || c > '9')
					{
						return false;
					}
				}
				break;
			case 1:
				foreach (char c in A_0)
				{
					if ((c < '0' || c > '9') && (c < 'A' || c > 'Z') && c != ' ' && c != '$' && c != '%' && c != '*' && c != '+' && c != '-' && c != '.' && c != '/' && c != ':' && c != '\0')
					{
						return false;
					}
				}
				break;
			case 3:
				foreach (char c in A_0)
				{
					if ((c < '\u3000' || c >= '滌') && (c < '漾' || c > '級'))
					{
						return false;
					}
				}
				break;
			}
			return true;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000378A4 File Offset: 0x000368A4
		private short[] d(short[] A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = this.k[this.q, this.p, 0];
			int num4 = this.k[this.q, this.p, 1];
			int num5 = this.m / (num3 + num4);
			int num6 = 0;
			if (num4 != 0)
			{
				num6 = this.m / (num3 + num4) + 1;
			}
			int num7 = this.n / (num3 + num4);
			short[,] array = new short[num3, num5];
			short[,] array2 = new short[num4, num6];
			short[,] array3 = new short[num3 + num4, num7];
			for (int i = 0; i < num3; i++)
			{
				short[] array4 = new short[num5];
				for (int j = 0; j < num5; j++)
				{
					array4[j] = A_0[num++];
				}
				short[] array5 = new short[num5 + num7 + 1];
				Array.Copy(array4, array5, num5);
				short[] array6 = this.a(array5, num5, num7);
				for (int j = 0; j < num5; j++)
				{
					array[i, j] = array6[j];
				}
				for (int j = 0; j < num7; j++)
				{
					array3[i, j] = array6[j + num5];
				}
			}
			for (int i = 0; i < num4; i++)
			{
				short[] array4 = new short[num6];
				for (int j = 0; j < num6; j++)
				{
					if (num == A_0.Length)
					{
						break;
					}
					array4[j] = A_0[num++];
				}
				short[] array5 = new short[num6 + num7 + 1];
				Array.Copy(array4, array5, num6);
				short[] array6 = this.a(array5, num6, num7);
				for (int j = 0; j < num6; j++)
				{
					array2[i, j] = array6[j];
				}
				for (int j = 0; j < num7; j++)
				{
					array3[i + num3, j] = array6[j + num6];
				}
			}
			short[] array7 = new short[this.m + this.n + 1];
			for (int j = 0; j < num5 + 1; j++)
			{
				for (int k = 0; k < num3; k++)
				{
					if (j == num5)
					{
						break;
					}
					array7[num2] = array[k, j];
					num2++;
				}
				for (int k = 0; k < num4; k++)
				{
					array7[num2] = array2[k, j];
					num2++;
				}
			}
			for (int j = 0; j < num7; j++)
			{
				for (int k = 0; k < num3 + num4; k++)
				{
					array7[num2] = array3[k, j];
					num2++;
				}
			}
			array7[num2] = 0;
			return array7;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00037BCC File Offset: 0x00036BCC
		private short[] c(short[] A_0)
		{
			short[] array = new short[(A_0.Length - 1) * 8];
			int num = 0;
			for (int i = 0; i < A_0.Length - 1; i++)
			{
				short num2 = A_0[i];
				int num3 = 8;
				short[] array2 = new short[8];
				while (num2 > 0)
				{
					short num4 = num2 % 2;
					array2[--num3] = num4;
					num2 /= 2;
				}
				for (int j = 0; j < 8; j++)
				{
					array[num] = array2[j];
					num++;
				}
			}
			return array;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00037C64 File Offset: 0x00036C64
		private short[] a(short[] A_0, int A_1, int A_2)
		{
			short[] array = new short[A_2 + 1];
			array = this.b(A_2);
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				A_0[i] = 0;
			}
			for (int i = 0; i < A_1; i++)
			{
				int a_ = (int)(A_0[A_1] ^ A_0[i]);
				for (int j = 0; j < A_2; j++)
				{
					A_0[A_1 + j] = (short)((int)A_0[A_1 + j + 1] ^ this.a(a_, array[A_2 - j - 1], ref a2.f, ref a2.g));
				}
			}
			return A_0;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00037CF8 File Offset: 0x00036CF8
		private int a(int A_0, short A_1, ref short[] A_2, ref byte[] A_3)
		{
			int result;
			if (!Convert.ToBoolean(A_0) || !Convert.ToBoolean(A_1))
			{
				result = 0;
			}
			else
			{
				result = (int)A_3[(int)((A_2[A_0] + A_2[(int)A_1]) % 255)];
			}
			return result;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00037D38 File Offset: 0x00036D38
		private short[] b(int A_0)
		{
			short[] result = new short[A_0 + 1];
			switch (A_0)
			{
			case 2:
				result = new short[]
				{
					2,
					3,
					1
				};
				break;
			case 5:
				result = new short[]
				{
					116,
					147,
					63,
					198,
					31,
					1
				};
				break;
			case 6:
				result = new short[]
				{
					127,
					38,
					227,
					32,
					218,
					248,
					1
				};
				break;
			case 7:
				result = new short[]
				{
					117,
					68,
					11,
					164,
					154,
					122,
					127,
					1
				};
				break;
			case 10:
				result = new short[]
				{
					193,
					157,
					113,
					95,
					94,
					199,
					111,
					159,
					194,
					216,
					1
				};
				break;
			case 13:
				result = new short[]
				{
					120,
					132,
					83,
					43,
					46,
					13,
					52,
					17,
					177,
					17,
					227,
					73,
					137,
					1
				};
				break;
			case 14:
				result = new short[]
				{
					163,
					234,
					210,
					166,
					127,
					195,
					158,
					43,
					151,
					174,
					70,
					114,
					54,
					14,
					1
				};
				break;
			case 15:
				result = new short[]
				{
					26,
					134,
					32,
					151,
					132,
					139,
					105,
					105,
					10,
					74,
					112,
					163,
					111,
					196,
					29,
					1
				};
				break;
			case 16:
				result = new short[]
				{
					59,
					36,
					50,
					98,
					229,
					41,
					65,
					163,
					8,
					30,
					209,
					68,
					189,
					104,
					13,
					59,
					1
				};
				break;
			case 17:
				result = new short[]
				{
					79,
					99,
					125,
					53,
					85,
					134,
					143,
					41,
					249,
					83,
					197,
					22,
					119,
					120,
					83,
					66,
					119,
					1
				};
				break;
			case 18:
				result = new short[]
				{
					146,
					217,
					67,
					32,
					75,
					173,
					82,
					73,
					220,
					240,
					215,
					199,
					175,
					149,
					113,
					183,
					251,
					239,
					1
				};
				break;
			case 20:
				result = new short[]
				{
					174,
					165,
					121,
					121,
					198,
					228,
					22,
					187,
					36,
					69,
					150,
					112,
					220,
					6,
					99,
					111,
					5,
					240,
					185,
					152,
					1
				};
				break;
			case 22:
				result = new short[]
				{
					245,
					145,
					26,
					230,
					218,
					86,
					253,
					67,
					123,
					29,
					137,
					28,
					40,
					69,
					189,
					19,
					244,
					182,
					176,
					131,
					179,
					89,
					1
				};
				break;
			case 24:
				result = new short[]
				{
					117,
					144,
					217,
					127,
					247,
					237,
					1,
					206,
					43,
					61,
					72,
					130,
					73,
					229,
					150,
					115,
					102,
					216,
					237,
					178,
					70,
					169,
					118,
					122,
					1
				};
				break;
			case 26:
				result = new short[]
				{
					94,
					43,
					77,
					146,
					144,
					70,
					68,
					135,
					42,
					233,
					117,
					209,
					40,
					145,
					24,
					206,
					56,
					77,
					152,
					199,
					98,
					136,
					4,
					183,
					51,
					246,
					1
				};
				break;
			case 28:
				result = new short[]
				{
					197,
					58,
					74,
					176,
					147,
					121,
					100,
					181,
					127,
					233,
					119,
					117,
					56,
					247,
					12,
					167,
					41,
					100,
					174,
					103,
					150,
					208,
					251,
					18,
					13,
					28,
					9,
					252,
					1
				};
				break;
			case 30:
				result = new short[]
				{
					150,
					130,
					106,
					11,
					195,
					216,
					74,
					228,
					46,
					18,
					25,
					72,
					246,
					181,
					51,
					138,
					217,
					22,
					177,
					103,
					70,
					5,
					98,
					75,
					192,
					195,
					73,
					77,
					246,
					212,
					1
				};
				break;
			case 32:
				result = new short[]
				{
					88,
					172,
					55,
					142,
					20,
					253,
					138,
					24,
					185,
					179,
					47,
					148,
					228,
					253,
					55,
					59,
					12,
					225,
					197,
					176,
					157,
					33,
					33,
					162,
					194,
					16,
					126,
					54,
					174,
					52,
					64,
					116,
					1
				};
				break;
			case 34:
				result = new short[]
				{
					10,
					23,
					222,
					67,
					135,
					126,
					23,
					196,
					111,
					62,
					94,
					93,
					136,
					43,
					22,
					122,
					183,
					105,
					51,
					99,
					132,
					177,
					25,
					31,
					113,
					26,
					90,
					208,
					117,
					6,
					113,
					154,
					60,
					206,
					1
				};
				break;
			case 36:
				result = new short[]
				{
					210,
					59,
					96,
					243,
					31,
					216,
					237,
					200,
					118,
					137,
					59,
					219,
					26,
					89,
					127,
					74,
					43,
					161,
					45,
					104,
					11,
					27,
					31,
					73,
					126,
					124,
					73,
					185,
					251,
					207,
					192,
					123,
					76,
					67,
					196,
					28,
					1
				};
				break;
			case 40:
				result = new short[0];
				break;
			case 42:
				result = new short[]
				{
					174,
					217,
					5,
					237,
					50,
					191,
					179,
					197,
					56,
					142,
					139,
					14,
					242,
					34,
					53,
					9,
					34,
					78,
					66,
					92,
					38,
					41,
					217,
					52,
					165,
					29,
					244,
					107,
					103,
					65,
					69,
					176,
					105,
					8,
					245,
					158,
					45,
					3,
					244,
					69,
					136,
					108,
					1
				};
				break;
			case 44:
				result = new short[0];
				break;
			case 46:
				result = new short[]
				{
					38,
					211,
					90,
					9,
					112,
					119,
					18,
					213,
					3,
					20,
					241,
					147,
					233,
					54,
					29,
					251,
					13,
					202,
					88,
					185,
					217,
					16,
					2,
					37,
					178,
					229,
					195,
					169,
					76,
					105,
					238,
					23,
					31,
					80,
					32,
					225,
					134,
					220,
					124,
					112,
					18,
					71,
					129,
					254,
					113,
					129,
					1
				};
				break;
			case 48:
				result = new short[]
				{
					208,
					78,
					53,
					99,
					5,
					107,
					144,
					113,
					232,
					65,
					11,
					132,
					228,
					131,
					117,
					163,
					149,
					59,
					85,
					226,
					83,
					104,
					167,
					98,
					230,
					169,
					206,
					69,
					45,
					124,
					197,
					159,
					161,
					171,
					111,
					44,
					68,
					53,
					223,
					216,
					143,
					185,
					154,
					178,
					46,
					200,
					3,
					61,
					1
				};
				break;
			case 50:
				result = new short[]
				{
					167,
					109,
					247,
					239,
					215,
					151,
					255,
					235,
					62,
					61,
					47,
					151,
					190,
					31,
					157,
					87,
					181,
					60,
					15,
					176,
					239,
					176,
					230,
					46,
					162,
					102,
					230,
					157,
					135,
					159,
					36,
					224,
					176,
					100,
					206,
					162,
					8,
					156,
					25,
					224,
					134,
					162,
					159,
					199,
					58,
					198,
					209,
					213,
					51,
					247,
					1
				};
				break;
			case 52:
				result = new short[]
				{
					10,
					248,
					142,
					22,
					39,
					34,
					172,
					28,
					176,
					53,
					175,
					177,
					30,
					234,
					118,
					235,
					243,
					17,
					31,
					151,
					190,
					210,
					113,
					174,
					225,
					142,
					218,
					224,
					176,
					74,
					77,
					210,
					19,
					234,
					239,
					170,
					243,
					149,
					90,
					151,
					204,
					177,
					159,
					130,
					225,
					216,
					172,
					5,
					110,
					177,
					5,
					248,
					1
				};
				break;
			case 54:
				result = new short[]
				{
					228,
					192,
					30,
					7,
					192,
					34,
					210,
					146,
					29,
					235,
					56,
					133,
					253,
					239,
					208,
					59,
					119,
					236,
					3,
					197,
					240,
					123,
					255,
					11,
					142,
					156,
					233,
					20,
					130,
					149,
					226,
					6,
					145,
					189,
					43,
					162,
					105,
					68,
					36,
					54,
					149,
					11,
					5,
					193,
					190,
					159,
					117,
					31,
					69,
					89,
					127,
					56,
					6,
					196,
					1
				};
				break;
			case 56:
				result = new short[]
				{
					116,
					111,
					180,
					166,
					112,
					57,
					170,
					131,
					200,
					12,
					111,
					99,
					201,
					217,
					83,
					73,
					151,
					34,
					149,
					22,
					214,
					116,
					24,
					174,
					241,
					219,
					54,
					98,
					42,
					204,
					66,
					205,
					162,
					215,
					81,
					169,
					114,
					142,
					168,
					64,
					122,
					112,
					56,
					37,
					99,
					27,
					163,
					4,
					248,
					129,
					195,
					198,
					213,
					104,
					59,
					1
				};
				break;
			case 58:
				result = new short[]
				{
					197,
					82,
					51,
					243,
					42,
					115,
					161,
					212,
					48,
					237,
					233,
					83,
					218,
					204,
					77,
					48,
					43,
					23,
					64,
					249,
					44,
					236,
					96,
					143,
					201,
					51,
					145,
					190,
					42,
					71,
					214,
					83,
					54,
					73,
					27,
					130,
					21,
					227,
					139,
					57,
					168,
					89,
					176,
					216,
					160,
					235,
					55,
					28,
					98,
					173,
					104,
					222,
					12,
					97,
					131,
					6,
					248,
					211,
					1
				};
				break;
			case 60:
				result = new short[]
				{
					44,
					39,
					128,
					225,
					76,
					162,
					12,
					94,
					172,
					174,
					68,
					190,
					127,
					50,
					3,
					107,
					49,
					96,
					151,
					232,
					177,
					118,
					162,
					230,
					140,
					11,
					148,
					74,
					211,
					230,
					189,
					34,
					86,
					124,
					186,
					7,
					167,
					4,
					131,
					17,
					64,
					204,
					49,
					24,
					59,
					86,
					34,
					178,
					193,
					88,
					141,
					172,
					141,
					125,
					21,
					58,
					205,
					6,
					132,
					104,
					1
				};
				break;
			case 62:
				result = new short[0];
				break;
			case 64:
				result = new short[0];
				break;
			case 66:
				result = new short[]
				{
					26,
					193,
					182,
					184,
					3,
					179,
					52,
					194,
					154,
					30,
					211,
					252,
					5,
					52,
					247,
					78,
					60,
					155,
					102,
					44,
					71,
					253,
					127,
					161,
					84,
					118,
					106,
					203,
					206,
					60,
					57,
					238,
					128,
					226,
					141,
					229,
					249,
					101,
					212,
					34,
					226,
					206,
					153,
					171,
					158,
					190,
					246,
					226,
					179,
					141,
					131,
					66,
					152,
					231,
					239,
					135,
					237,
					159,
					10,
					191,
					79,
					150,
					138,
					199,
					32,
					1
				};
				break;
			case 68:
				result = new short[]
				{
					11,
					99,
					29,
					32,
					8,
					204,
					149,
					34,
					12,
					235,
					11,
					119,
					7,
					255,
					239,
					211,
					157,
					80,
					4,
					199,
					36,
					63,
					88,
					158,
					51,
					212,
					219,
					20,
					245,
					226,
					175,
					14,
					20,
					144,
					225,
					230,
					246,
					71,
					107,
					38,
					107,
					182,
					170,
					224,
					172,
					145,
					112,
					185,
					20,
					109,
					167,
					174,
					85,
					119,
					142,
					157,
					230,
					223,
					94,
					60,
					182,
					18,
					39,
					9,
					115,
					131,
					1
				};
				break;
			}
			return result;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0003816C File Offset: 0x0003716C
		private short[,] b(short[] A_0)
		{
			short[,] array = new short[this.o, 2];
			int num = 0;
			int num2 = this.r - 1;
			int num3 = this.r - 1;
			bool flag = true;
			int num4 = 1;
			int num5 = this.r - 9;
			short[,] array2 = new short[this.r, this.r];
			int num6 = num2;
			if (this.q != 0)
			{
				array = this.c();
			}
			do
			{
				for (int i = num3; i > num3 - 2; i--)
				{
					if (num6 != 6)
					{
						bool flag2 = false;
						if (this.q != 0)
						{
							for (int j = 0; j < this.o; j++)
							{
								int num7 = (int)array[j, 0];
								int num8 = (int)array[j, 1];
								if (num6 >= num7 - 2 && num6 <= num7 + 2 && i >= num8 - 2 && i <= num8 + 2)
								{
									flag2 = !flag2;
									break;
								}
							}
						}
						if (this.q > 5)
						{
							if (num6 <= 5 && (i == this.r - 11 || i == this.r - 10 || i == this.r - 9))
							{
								goto IL_1BC;
							}
							if ((num6 == this.r - 11 || num6 == this.r - 10 || num6 == this.r - 9) && i <= 5)
							{
								goto IL_1BC;
							}
						}
						if (num == A_0.Length)
						{
							break;
						}
						if (!flag2)
						{
							array2[num6, i] = A_0[num];
							num++;
						}
					}
					IL_1BC:;
				}
				if (num4++ % num5 == 0)
				{
					num3 -= 2;
					flag = !flag;
					if (num3 == this.r - 9)
					{
						num4 = 1;
						num5 = this.r;
					}
					if (num3 == 8)
					{
						num4 = 1;
						num5 = this.r - 17;
						num6 -= 8;
					}
					if (num3 == 6)
					{
						num3--;
					}
				}
				else if (flag)
				{
					num6--;
				}
				else
				{
					num6++;
				}
			}
			while (num3 > 0);
			return array2;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00038400 File Offset: 0x00037400
		private BitArray a(short[] A_0)
		{
			short[,] array = new short[this.r, this.r];
			short[,] array2 = this.b(A_0);
			int a_ = this.a(array2);
			for (int i = 0; i < this.r; i++)
			{
				for (int j = 0; j < this.r; j++)
				{
					switch (a_)
					{
					case 0:
						if ((i + j) % 2 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 1:
						if (i % 2 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 2:
						if (j % 3 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 3:
						if ((i + j) % 3 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 4:
						if ((i / 2 + j / 3) % 2 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 5:
						if (i * j % 2 + i * j % 3 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 6:
						if ((i * j % 2 + i * j % 3) % 2 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					case 7:
						if (((i + j) % 2 + i * j % 3) % 2 == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
						break;
					}
				}
			}
			this.s = new short[this.r, this.r];
			for (int i = 0; i < this.r; i++)
			{
				for (int j = 0; j < this.r; j++)
				{
					this.s[i, j] = (array2[i, j] ^ array[i, j]);
				}
			}
			short[] array3 = this.a(a_);
			this.a();
			int num = 0;
			for (int i = this.r - 1; i >= this.r - 8; i--)
			{
				int j = 8;
				if (i == this.r - 8)
				{
					this.s[i, j] = 1;
				}
				else
				{
					this.s[i, j] = array3[num];
					num++;
				}
			}
			for (int j = this.r - 8; j <= this.r - 1; j++)
			{
				int i = 8;
				this.s[i, j] = array3[num];
				num++;
			}
			num--;
			for (int i = 0; i <= 8; i++)
			{
				int j = 8;
				if (i == 6)
				{
					this.s[i, j] = 1;
				}
				else
				{
					this.s[i, j] = array3[num];
					num--;
				}
			}
			for (int j = 7; j >= 0; j--)
			{
				int i = 8;
				if (j == 6)
				{
					this.s[i, j] = 1;
				}
				else
				{
					this.s[i, j] = array3[num];
					num--;
				}
			}
			for (int j = 9; j < this.r - 8; j++)
			{
				if (j % 2 == 1)
				{
					this.s[6, j] = 0;
				}
				else
				{
					this.s[6, j] = 1;
				}
			}
			for (int i = 9; i < this.r - 8; i++)
			{
				if (i % 2 == 1)
				{
					this.s[i, 6] = 0;
				}
				else
				{
					this.s[i, 6] = 1;
				}
			}
			BitArray bitArray = new BitArray(this.r * this.r);
			num = 0;
			for (int i = 0; i < this.r; i++)
			{
				for (int j = 0; j < this.r; j++)
				{
					if (this.s[i, j] == 1)
					{
						bitArray[num++] = false;
					}
					else
					{
						bitArray[num++] = true;
					}
				}
			}
			return bitArray;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00038930 File Offset: 0x00037930
		private int a(short[,] A_0)
		{
			int result = 0;
			short[,] array = new short[this.r, this.r];
			int num = -1;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < this.r; j++)
				{
					for (int k = 0; k < this.r; k++)
					{
						switch (i)
						{
						case 0:
							if ((j + k) % 2 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 1:
							if (j % 2 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 2:
							if (k % 3 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 3:
							if ((j + k) % 3 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 4:
							if ((j / 2 + k / 3) % 2 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 5:
							if (j * k % 2 + j * k % 3 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 6:
							if ((j * k % 2 + j * k % 3) % 2 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						case 7:
							if (((j + k) % 2 + j * k % 3) % 2 == 0)
							{
								array[j, k] = 1;
							}
							else
							{
								array[j, k] = 0;
							}
							break;
						}
					}
				}
				this.s = new short[this.r, this.r];
				for (int j = 0; j < this.r; j++)
				{
					for (int k = 0; k < this.r; k++)
					{
						this.s[j, k] = (A_0[j, k] ^ array[j, k]);
					}
				}
				int num2 = 0;
				int num3 = 0;
				int num4 = -1;
				for (int j = 0; j < this.r; j++)
				{
					for (int k = 0; k < this.r; k++)
					{
						int num5 = (int)this.s[j, k];
						if (num5 == num4)
						{
							num3++;
							if (num3 == 5)
							{
								num2 += 3;
							}
							else if (num3 > 5)
							{
								num2++;
							}
						}
						else
						{
							num3 = 1;
							num4 = num5;
						}
					}
					num3 = 0;
				}
				num3 = 0;
				num4 = -1;
				for (int j = 0; j < this.r; j++)
				{
					for (int k = 0; k < this.r; k++)
					{
						int num5 = (int)this.s[k, j];
						if (num5 == num4)
						{
							num3++;
							if (num3 == 5)
							{
								num2 += 3;
							}
							else if (num3 > 5)
							{
								num2++;
							}
						}
						else
						{
							num3 = 1;
							num4 = num5;
						}
					}
					num3 = 0;
				}
				for (int l = 0; l < this.r - 1; l++)
				{
					for (int m = 0; m < this.r - 1; m++)
					{
						int num6 = (int)this.s[l, m];
						if (num6 == (int)this.s[l, m + 1] && num6 == (int)this.s[l + 1, m] && num6 == (int)this.s[l + 1, m + 1])
						{
							num2 += 3;
						}
					}
				}
				for (int l = 0; l < this.r; l++)
				{
					for (int m = 0; m < this.r; m++)
					{
						if (m + 6 < this.r && this.s[l, m] == 1 && this.s[l, m + 1] == 0 && this.s[l, m + 2] == 1 && this.s[l, m + 3] == 1 && this.s[l, m + 4] == 1 && this.s[l, m + 5] == 0 && this.s[l, m + 6] == 1 && ((m + 10 < this.r && this.s[l, m + 7] == 0 && this.s[l, m + 8] == 0 && this.s[l, m + 9] == 0 && this.s[l, m + 10] == 0) || (m - 4 >= 0 && this.s[l, m - 1] == 0 && this.s[l, m - 2] == 0 && this.s[l, m - 3] == 0 && this.s[l, m - 4] == 0)))
						{
							num2 += 40;
						}
						if (l + 6 < this.r && this.s[l, m] == 1 && this.s[l + 1, m] == 0 && this.s[l + 2, m] == 1 && this.s[l + 3, m] == 1 && this.s[l + 4, m] == 1 && this.s[l + 5, m] == 0 && this.s[l + 6, m] == 1 && ((l + 10 < this.r && this.s[l + 7, m] == 0 && this.s[l + 8, m] == 0 && this.s[l + 9, m] == 0 && this.s[l + 10, m] == 0) || (l - 4 >= 0 && this.s[l - 1, m] == 0 && this.s[l - 2, m] == 0 && this.s[l - 3, m] == 0 && this.s[l - 4, m] == 0)))
						{
							num2 += 40;
						}
					}
				}
				int num7 = 0;
				for (int l = 0; l < this.r; l++)
				{
					for (int m = 0; m < this.r; m++)
					{
						if (this.s[l, m] == 1)
						{
							num7++;
						}
					}
				}
				int num8 = this.r * this.r;
				int num9 = num7 / num8;
				num2 += Math.Abs(num9 * 100 - 50) / 5 * 10;
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
				if (num == -1)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000391EC File Offset: 0x000381EC
		private short[,] c()
		{
			short[] array = a2.l[this.q];
			this.o = array.Length * array.Length - 3;
			short[,] array2 = new short[this.o, 2];
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array2[num, 0] = array[i];
					array2[num, 1] = array[j];
					if (array2[num, 0] > 8 || array2[num, 1] > 8)
					{
						if (array2[num, 0] > 8 || (int)array2[num, 1] < this.r - 8)
						{
							if ((int)array2[num, 0] < this.r - 8 || array2[num, 1] > 8)
							{
								num++;
							}
						}
					}
				}
			}
			return array2;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000392FC File Offset: 0x000382FC
		private short[] a(int A_0)
		{
			short[] result = new short[15];
			switch (this.p)
			{
			case 0:
				switch (A_0)
				{
				case 0:
					result = new short[]
					{
						1,
						1,
						1,
						0,
						1,
						1,
						1,
						1,
						1,
						0,
						0,
						0,
						1,
						0,
						0
					};
					break;
				case 1:
					result = new short[]
					{
						1,
						1,
						1,
						0,
						0,
						1,
						0,
						1,
						1,
						1,
						1,
						0,
						0,
						1,
						1
					};
					break;
				case 2:
					result = new short[]
					{
						1,
						1,
						1,
						1,
						1,
						0,
						1,
						1,
						0,
						1,
						0,
						1,
						0,
						1,
						0
					};
					break;
				case 3:
					result = new short[]
					{
						1,
						1,
						1,
						1,
						0,
						0,
						0,
						1,
						0,
						0,
						1,
						1,
						1,
						0,
						1
					};
					break;
				case 4:
					result = new short[]
					{
						1,
						1,
						0,
						0,
						1,
						1,
						0,
						0,
						0,
						1,
						0,
						1,
						1,
						1,
						1
					};
					break;
				case 5:
					result = new short[]
					{
						1,
						1,
						0,
						0,
						0,
						1,
						1,
						0,
						0,
						0,
						1,
						1,
						0,
						0,
						0
					};
					break;
				case 6:
					result = new short[]
					{
						1,
						1,
						0,
						1,
						1,
						0,
						0,
						0,
						1,
						0,
						0,
						0,
						0,
						0,
						1
					};
					break;
				case 7:
					result = new short[]
					{
						1,
						1,
						0,
						1,
						0,
						0,
						1,
						0,
						1,
						1,
						1,
						0,
						1,
						1,
						0
					};
					break;
				}
				break;
			case 1:
				switch (A_0)
				{
				case 0:
					result = new short[]
					{
						1,
						0,
						1,
						0,
						1,
						0,
						0,
						0,
						0,
						0,
						1,
						0,
						0,
						1,
						0
					};
					break;
				case 1:
					result = new short[]
					{
						1,
						0,
						1,
						0,
						0,
						0,
						1,
						0,
						0,
						1,
						0,
						0,
						1,
						0,
						1
					};
					break;
				case 2:
					result = new short[]
					{
						1,
						0,
						1,
						1,
						1,
						1,
						0,
						0,
						1,
						1,
						1,
						1,
						1,
						0,
						0
					};
					break;
				case 3:
					result = new short[]
					{
						1,
						0,
						1,
						1,
						0,
						1,
						1,
						0,
						1,
						0,
						0,
						1,
						0,
						1,
						1
					};
					break;
				case 4:
					result = new short[]
					{
						1,
						0,
						0,
						0,
						1,
						0,
						1,
						1,
						1,
						1,
						1,
						1,
						0,
						0,
						1
					};
					break;
				case 5:
					result = new short[]
					{
						1,
						0,
						0,
						0,
						0,
						0,
						0,
						1,
						1,
						0,
						0,
						1,
						1,
						1,
						0
					};
					break;
				case 6:
					result = new short[]
					{
						1,
						0,
						0,
						1,
						1,
						1,
						1,
						1,
						0,
						0,
						1,
						0,
						1,
						1,
						1
					};
					break;
				case 7:
					result = new short[]
					{
						1,
						0,
						0,
						1,
						0,
						1,
						0,
						1,
						0,
						1,
						0,
						0,
						0,
						0,
						0
					};
					break;
				}
				break;
			case 2:
				switch (A_0)
				{
				case 0:
					result = new short[]
					{
						0,
						1,
						1,
						0,
						1,
						0,
						1,
						0,
						1,
						0,
						1,
						1,
						1,
						1,
						1
					};
					break;
				case 1:
					result = new short[]
					{
						0,
						1,
						1,
						0,
						0,
						0,
						0,
						0,
						1,
						1,
						0,
						1,
						0,
						0,
						0
					};
					break;
				case 2:
					result = new short[]
					{
						0,
						1,
						1,
						1,
						1,
						1,
						1,
						0,
						0,
						1,
						1,
						0,
						0,
						0,
						1
					};
					break;
				case 3:
					result = new short[]
					{
						0,
						1,
						1,
						1,
						0,
						1,
						0,
						0,
						0,
						0,
						0,
						0,
						1,
						1,
						0
					};
					break;
				case 4:
					result = new short[]
					{
						0,
						1,
						0,
						0,
						1,
						0,
						0,
						1,
						0,
						1,
						1,
						0,
						1,
						0,
						0
					};
					break;
				case 5:
					result = new short[]
					{
						0,
						1,
						0,
						0,
						0,
						0,
						1,
						1,
						0,
						0,
						0,
						0,
						0,
						1,
						1
					};
					break;
				case 6:
					result = new short[]
					{
						0,
						1,
						0,
						1,
						1,
						1,
						0,
						1,
						1,
						0,
						1,
						1,
						0,
						1,
						0
					};
					break;
				case 7:
					result = new short[]
					{
						0,
						1,
						0,
						1,
						0,
						1,
						1,
						1,
						1,
						1,
						0,
						1,
						1,
						0,
						1
					};
					break;
				}
				break;
			case 3:
				switch (A_0)
				{
				case 0:
					result = new short[]
					{
						0,
						0,
						1,
						0,
						1,
						1,
						0,
						1,
						0,
						0,
						0,
						1,
						0,
						0,
						1
					};
					break;
				case 1:
					result = new short[]
					{
						0,
						0,
						1,
						0,
						0,
						1,
						1,
						1,
						0,
						1,
						1,
						1,
						1,
						1,
						0
					};
					break;
				case 2:
					result = new short[]
					{
						0,
						0,
						1,
						1,
						1,
						0,
						0,
						1,
						1,
						1,
						0,
						0,
						1,
						1,
						1
					};
					break;
				case 3:
					result = new short[]
					{
						0,
						0,
						1,
						1,
						0,
						0,
						1,
						1,
						1,
						0,
						1,
						0,
						0,
						0,
						0
					};
					break;
				case 4:
					result = new short[]
					{
						0,
						0,
						0,
						0,
						1,
						1,
						1,
						0,
						1,
						1,
						0,
						0,
						0,
						1,
						0
					};
					break;
				case 5:
					result = new short[]
					{
						0,
						0,
						0,
						0,
						0,
						1,
						0,
						0,
						1,
						0,
						1,
						0,
						1,
						0,
						1
					};
					break;
				case 6:
					result = new short[]
					{
						0,
						0,
						0,
						1,
						1,
						0,
						1,
						0,
						0,
						0,
						0,
						1,
						1,
						0,
						0
					};
					break;
				case 7:
					result = new short[]
					{
						0,
						0,
						0,
						1,
						0,
						0,
						0,
						0,
						0,
						1,
						1,
						1,
						0,
						1,
						1
					};
					break;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000396AC File Offset: 0x000386AC
		private short[] b()
		{
			short[] result = new short[18];
			switch (this.q)
			{
			case 6:
				result = new short[]
				{
					0,
					0,
					0,
					1,
					1,
					1,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					0,
					1,
					0,
					0
				};
				break;
			case 7:
				result = new short[]
				{
					0,
					0,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					0,
					0
				};
				break;
			case 8:
				result = new short[]
				{
					0,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					1
				};
				break;
			case 9:
				result = new short[]
				{
					0,
					0,
					1,
					0,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					0,
					1,
					1
				};
				break;
			case 10:
				result = new short[]
				{
					0,
					0,
					1,
					0,
					1,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					1,
					1,
					0,
					1,
					1,
					0
				};
				break;
			case 11:
				result = new short[]
				{
					0,
					0,
					1,
					1,
					0,
					0,
					0,
					1,
					1,
					1,
					0,
					1,
					1,
					0,
					0,
					0,
					1,
					0
				};
				break;
			case 12:
				result = new short[]
				{
					0,
					0,
					1,
					1,
					0,
					1,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					0,
					0,
					1,
					1,
					1
				};
				break;
			case 13:
				result = new short[]
				{
					0,
					0,
					1,
					1,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					0,
					0,
					0,
					1,
					1,
					0,
					1
				};
				break;
			case 14:
				result = new short[]
				{
					0,
					0,
					1,
					1,
					1,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					0,
					1,
					0,
					0,
					0
				};
				break;
			case 15:
				result = new short[]
				{
					0,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					0,
					0,
					0
				};
				break;
			case 16:
				result = new short[]
				{
					0,
					1,
					0,
					0,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					1,
					0,
					1
				};
				break;
			case 17:
				result = new short[]
				{
					0,
					1,
					0,
					0,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					1
				};
				break;
			case 18:
				result = new short[]
				{
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					0
				};
				break;
			case 19:
				result = new short[]
				{
					0,
					1,
					0,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					0,
					1,
					1,
					0
				};
				break;
			case 20:
				result = new short[]
				{
					0,
					1,
					0,
					1,
					0,
					1,
					0,
					1,
					1,
					0,
					1,
					0,
					0,
					0,
					0,
					0,
					1,
					1
				};
				break;
			case 21:
				result = new short[]
				{
					0,
					1,
					0,
					1,
					1,
					0,
					1,
					0,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					1
				};
				break;
			case 22:
				result = new short[]
				{
					0,
					1,
					0,
					1,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					1,
					1,
					0,
					1,
					1,
					0,
					0
				};
				break;
			case 23:
				result = new short[]
				{
					0,
					1,
					1,
					0,
					0,
					0,
					1,
					1,
					1,
					0,
					1,
					1,
					0,
					0,
					0,
					1,
					0,
					0
				};
				break;
			case 24:
				result = new short[]
				{
					0,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					0,
					1,
					1,
					1,
					1,
					0,
					0,
					0,
					0,
					1
				};
				break;
			case 25:
				result = new short[]
				{
					0,
					1,
					1,
					0,
					1,
					0,
					1,
					1,
					1,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					1,
					1
				};
				break;
			case 26:
				result = new short[]
				{
					0,
					1,
					1,
					0,
					1,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					0,
					0,
					1,
					1,
					1,
					0
				};
				break;
			case 27:
				result = new short[]
				{
					0,
					1,
					1,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					0,
					0,
					0,
					1,
					1,
					0,
					1,
					0
				};
				break;
			case 28:
				result = new short[]
				{
					0,
					1,
					1,
					1,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					1,
					1,
					1,
					1,
					1
				};
				break;
			case 29:
				result = new short[]
				{
					0,
					1,
					1,
					1,
					1,
					0,
					1,
					1,
					0,
					1,
					0,
					1,
					1,
					1,
					0,
					1,
					0,
					1
				};
				break;
			case 30:
				result = new short[]
				{
					0,
					1,
					1,
					1,
					1,
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					0
				};
				break;
			case 31:
				result = new short[]
				{
					1,
					0,
					0,
					0,
					0,
					0,
					1,
					0,
					0,
					1,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					1
				};
				break;
			case 32:
				result = new short[]
				{
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					0,
					0,
					0,
					0
				};
				break;
			case 33:
				result = new short[]
				{
					1,
					0,
					0,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					1,
					0,
					1,
					0
				};
				break;
			case 34:
				result = new short[]
				{
					1,
					0,
					0,
					0,
					1,
					1,
					0,
					1,
					1,
					1,
					1,
					0,
					0,
					1,
					1,
					1,
					1,
					1
				};
				break;
			case 35:
				result = new short[]
				{
					1,
					0,
					0,
					1,
					0,
					0,
					1,
					0,
					1,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1
				};
				break;
			case 36:
				result = new short[]
				{
					1,
					0,
					0,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					0,
					1,
					0,
					1,
					1,
					1,
					0
				};
				break;
			case 37:
				result = new short[]
				{
					1,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					1,
					1,
					0,
					0,
					1,
					0,
					0
				};
				break;
			case 38:
				result = new short[]
				{
					1,
					0,
					0,
					1,
					1,
					1,
					0,
					1,
					0,
					1,
					0,
					1,
					0,
					0,
					0,
					0,
					0,
					1
				};
				break;
			case 39:
				result = new short[]
				{
					1,
					0,
					1,
					0,
					0,
					0,
					1,
					1,
					0,
					0,
					0,
					1,
					1,
					0,
					1,
					0,
					0,
					1
				};
				break;
			}
			return result;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00039A80 File Offset: 0x00038A80
		private void a()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((i == 0 || i == 6) && j != 7)
					{
						this.s[i, j] = 1;
					}
					else if ((i == 1 || i == 5) && (j == 0 || j == 6))
					{
						this.s[i, j] = 1;
					}
					else if ((i == 2 || i == 3 || i == 4) && (j == 0 || j == 2 || j == 3 || j == 4 || j == 6))
					{
						this.s[i, j] = 1;
					}
					else
					{
						this.s[i, j] = 0;
					}
				}
			}
			for (int i = 0; i < 8; i++)
			{
				for (int j = this.r - 8; j < this.r; j++)
				{
					if ((i == 0 || i == 6) && j != this.r - 8)
					{
						this.s[i, j] = 1;
					}
					else if ((i == 1 || i == 5) && (j == this.r - 1 || j == this.r - 7))
					{
						this.s[i, j] = 1;
					}
					else if ((i == 2 || (i == 3 | i == 4)) && (j == this.r - 1 || j == this.r - 3 || j == this.r - 4 || j == this.r - 5 || j == this.r - 7))
					{
						this.s[i, j] = 1;
					}
					else
					{
						this.s[i, j] = 0;
					}
				}
			}
			for (int i = this.r - 8; i < this.r; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if ((i == this.r - 1 || i == this.r - 7) && j != 7)
					{
						this.s[i, j] = 1;
					}
					else if ((i == this.r - 2 || i == this.r - 6) && (j == 0 || j == 6))
					{
						this.s[i, j] = 1;
					}
					else if ((i == this.r - 3 || (i == this.r - 4 | i == this.r - 5)) && (j == 0 || j == 2 || j == 3 || j == 4 || j == 6))
					{
						this.s[i, j] = 1;
					}
					else
					{
						this.s[i, j] = 0;
					}
				}
			}
			short[,] array = new short[this.o, 2];
			if (this.q != 0)
			{
				array = this.c();
				for (int k = 0; k < this.o; k++)
				{
					int num = (int)array[k, 0];
					int num2 = (int)array[k, 1];
					for (int i = num - 2; i <= num + 2; i++)
					{
						for (int j = num2 - 2; j <= num2 + 2; j++)
						{
							if ((i == num - 1 || i == num + 1) & (j == num2 - 1 || j == num2 || j == num2 + 1))
							{
								this.s[i, j] = 0;
							}
							else if (i == num & (j == num2 - 1 || j == num2 + 1))
							{
								this.s[i, j] = 0;
							}
							else
							{
								this.s[i, j] = 1;
							}
						}
					}
				}
			}
			short[] array2 = this.b();
			if (this.q > 5)
			{
				int num3 = 0;
				for (int i = 5; i >= 0; i--)
				{
					for (int j = this.r - 9; j > this.r - 12; j--)
					{
						this.s[i, j] = array2[num3];
						if (num3 == 17)
						{
							break;
						}
						num3++;
					}
				}
				num3 = 0;
				for (int j = 5; j >= 0; j--)
				{
					for (int i = this.r - 9; i > this.r - 12; i--)
					{
						this.s[i, j] = array2[num3];
						if (num3 == 17)
						{
							break;
						}
						num3++;
					}
				}
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0003A038 File Offset: 0x00039038
		// Note: this type is marked as 'beforefieldinit'.
		static a2()
		{
			short[][] array = new short[40][];
			short[][] array2 = array;
			int num = 0;
			short[] array3 = new short[1];
			array2[num] = array3;
			array[1] = new short[]
			{
				6,
				18
			};
			array[2] = new short[]
			{
				6,
				22
			};
			array[3] = new short[]
			{
				6,
				26
			};
			array[4] = new short[]
			{
				6,
				30
			};
			array[5] = new short[]
			{
				6,
				34
			};
			array[6] = new short[]
			{
				6,
				22,
				38
			};
			array[7] = new short[]
			{
				6,
				24,
				42
			};
			array[8] = new short[]
			{
				6,
				26,
				46
			};
			array[9] = new short[]
			{
				6,
				28,
				50
			};
			array[10] = new short[]
			{
				6,
				30,
				54
			};
			array[11] = new short[]
			{
				6,
				32,
				58
			};
			array[12] = new short[]
			{
				6,
				34,
				62
			};
			array[13] = new short[]
			{
				6,
				26,
				46,
				66
			};
			array[14] = new short[]
			{
				6,
				26,
				48,
				70
			};
			array[15] = new short[]
			{
				6,
				26,
				50,
				74
			};
			array[16] = new short[]
			{
				6,
				30,
				54,
				78
			};
			array[17] = new short[]
			{
				6,
				30,
				56,
				82
			};
			array[18] = new short[]
			{
				6,
				30,
				58,
				86
			};
			array[19] = new short[]
			{
				6,
				34,
				62,
				90
			};
			array[20] = new short[]
			{
				6,
				28,
				50,
				72,
				94
			};
			array[21] = new short[]
			{
				6,
				26,
				50,
				74,
				98
			};
			array[22] = new short[]
			{
				6,
				30,
				54,
				78,
				102
			};
			array[23] = new short[]
			{
				6,
				28,
				54,
				80,
				106
			};
			array[24] = new short[]
			{
				6,
				32,
				58,
				84,
				110
			};
			array[25] = new short[]
			{
				6,
				30,
				58,
				86,
				114
			};
			array[26] = new short[]
			{
				6,
				34,
				62,
				90,
				118
			};
			array[27] = new short[]
			{
				6,
				26,
				50,
				74,
				98,
				122
			};
			array[28] = new short[]
			{
				6,
				30,
				54,
				78,
				102,
				126
			};
			array[29] = new short[]
			{
				6,
				26,
				52,
				78,
				104,
				130
			};
			array[30] = new short[]
			{
				6,
				30,
				56,
				82,
				108,
				134
			};
			array[31] = new short[]
			{
				6,
				34,
				60,
				86,
				112,
				138
			};
			array[32] = new short[]
			{
				6,
				30,
				58,
				86,
				114,
				142
			};
			array[33] = new short[]
			{
				6,
				34,
				62,
				90,
				118,
				146
			};
			array[34] = new short[]
			{
				6,
				30,
				54,
				78,
				102,
				126,
				150
			};
			array[35] = new short[]
			{
				6,
				24,
				50,
				76,
				102,
				128,
				154
			};
			array[36] = new short[]
			{
				6,
				28,
				54,
				80,
				106,
				132,
				158
			};
			array[37] = new short[]
			{
				6,
				32,
				58,
				84,
				110,
				136,
				162
			};
			array[38] = new short[]
			{
				6,
				26,
				54,
				82,
				110,
				138,
				166
			};
			array[39] = new short[]
			{
				6,
				30,
				58,
				86,
				114,
				142,
				170
			};
			a2.l = array;
		}

		// Token: 0x04000178 RID: 376
		private const float a = 3f;

		// Token: 0x04000179 RID: 377
		private const int b = 256;

		// Token: 0x0400017A RID: 378
		private string c;

		// Token: 0x0400017B RID: 379
		private byte[] d;

		// Token: 0x0400017C RID: 380
		private int e = 4;

		// Token: 0x0400017D RID: 381
		private static short[] f = new short[]
		{
			-255,
			255,
			1,
			25,
			2,
			50,
			26,
			198,
			3,
			223,
			51,
			238,
			27,
			104,
			199,
			75,
			4,
			100,
			224,
			14,
			52,
			141,
			239,
			129,
			28,
			193,
			105,
			248,
			200,
			8,
			76,
			113,
			5,
			138,
			101,
			47,
			225,
			36,
			15,
			33,
			53,
			147,
			142,
			218,
			240,
			18,
			130,
			69,
			29,
			181,
			194,
			125,
			106,
			39,
			249,
			185,
			201,
			154,
			9,
			120,
			77,
			228,
			114,
			166,
			6,
			191,
			139,
			98,
			102,
			221,
			48,
			253,
			226,
			152,
			37,
			179,
			16,
			145,
			34,
			136,
			54,
			208,
			148,
			206,
			143,
			150,
			219,
			189,
			241,
			210,
			19,
			92,
			131,
			56,
			70,
			64,
			30,
			66,
			182,
			163,
			195,
			72,
			126,
			110,
			107,
			58,
			40,
			84,
			250,
			133,
			186,
			61,
			202,
			94,
			155,
			159,
			10,
			21,
			121,
			43,
			78,
			212,
			229,
			172,
			115,
			243,
			167,
			87,
			7,
			112,
			192,
			247,
			140,
			128,
			99,
			13,
			103,
			74,
			222,
			237,
			49,
			197,
			254,
			24,
			227,
			165,
			153,
			119,
			38,
			184,
			180,
			124,
			17,
			68,
			146,
			217,
			35,
			32,
			137,
			46,
			55,
			63,
			209,
			91,
			149,
			188,
			207,
			205,
			144,
			135,
			151,
			178,
			220,
			252,
			190,
			97,
			242,
			86,
			211,
			171,
			20,
			42,
			93,
			158,
			132,
			60,
			57,
			83,
			71,
			109,
			65,
			162,
			31,
			45,
			67,
			216,
			183,
			123,
			164,
			118,
			196,
			23,
			73,
			236,
			127,
			12,
			111,
			246,
			108,
			161,
			59,
			82,
			41,
			157,
			85,
			170,
			251,
			96,
			134,
			177,
			187,
			204,
			62,
			90,
			203,
			89,
			95,
			176,
			156,
			169,
			160,
			81,
			11,
			245,
			22,
			235,
			122,
			117,
			44,
			215,
			79,
			174,
			213,
			233,
			230,
			231,
			173,
			232,
			116,
			214,
			244,
			234,
			168,
			80,
			88,
			175
		};

		// Token: 0x0400017E RID: 382
		private static byte[] g = new byte[]
		{
			1,
			2,
			4,
			8,
			16,
			32,
			64,
			128,
			29,
			58,
			116,
			232,
			205,
			135,
			19,
			38,
			76,
			152,
			45,
			90,
			180,
			117,
			234,
			201,
			143,
			3,
			6,
			12,
			24,
			48,
			96,
			192,
			157,
			39,
			78,
			156,
			37,
			74,
			148,
			53,
			106,
			212,
			181,
			119,
			238,
			193,
			159,
			35,
			70,
			140,
			5,
			10,
			20,
			40,
			80,
			160,
			93,
			186,
			105,
			210,
			185,
			111,
			222,
			161,
			95,
			190,
			97,
			194,
			153,
			47,
			94,
			188,
			101,
			202,
			137,
			15,
			30,
			60,
			120,
			240,
			253,
			231,
			211,
			187,
			107,
			214,
			177,
			127,
			254,
			225,
			223,
			163,
			91,
			182,
			113,
			226,
			217,
			175,
			67,
			134,
			17,
			34,
			68,
			136,
			13,
			26,
			52,
			104,
			208,
			189,
			103,
			206,
			129,
			31,
			62,
			124,
			248,
			237,
			199,
			147,
			59,
			118,
			236,
			197,
			151,
			51,
			102,
			204,
			133,
			23,
			46,
			92,
			184,
			109,
			218,
			169,
			79,
			158,
			33,
			66,
			132,
			21,
			42,
			84,
			168,
			77,
			154,
			41,
			82,
			164,
			85,
			170,
			73,
			146,
			57,
			114,
			228,
			213,
			183,
			115,
			230,
			209,
			191,
			99,
			198,
			145,
			63,
			126,
			252,
			229,
			215,
			179,
			123,
			246,
			241,
			byte.MaxValue,
			227,
			219,
			171,
			75,
			150,
			49,
			98,
			196,
			149,
			55,
			110,
			220,
			165,
			87,
			174,
			65,
			130,
			25,
			50,
			100,
			200,
			141,
			7,
			14,
			28,
			56,
			112,
			224,
			221,
			167,
			83,
			166,
			81,
			162,
			89,
			178,
			121,
			242,
			249,
			239,
			195,
			155,
			43,
			86,
			172,
			69,
			138,
			9,
			18,
			36,
			72,
			144,
			61,
			122,
			244,
			245,
			247,
			243,
			251,
			235,
			203,
			139,
			11,
			22,
			44,
			88,
			176,
			125,
			250,
			233,
			207,
			131,
			27,
			54,
			108,
			216,
			173,
			71,
			142,
			1
		};

		// Token: 0x0400017F RID: 383
		private static byte[] h = new byte[]
		{
			21,
			25,
			29,
			33,
			37,
			41,
			45,
			49,
			53,
			57,
			61,
			65,
			69,
			73,
			77,
			81,
			85,
			89,
			93,
			97,
			101,
			105,
			109,
			113,
			117,
			121,
			125,
			129,
			133,
			137,
			141,
			145,
			149,
			153,
			157,
			161,
			165,
			169,
			173,
			177
		};

		// Token: 0x04000180 RID: 384
		private int[] i = new int[]
		{
			26,
			44,
			70,
			100,
			134,
			172,
			196,
			242,
			292,
			346,
			404,
			466,
			532,
			581,
			655,
			733,
			815,
			901,
			991,
			1085,
			1156,
			1258,
			1364,
			1474,
			1588,
			1706,
			1828,
			1921,
			2051,
			2185,
			2323,
			2465,
			2611,
			2761,
			2876,
			3034,
			3196,
			3362,
			3532,
			3706
		};

		// Token: 0x04000181 RID: 385
		private int[,] j = new int[,]
		{
			{
				7,
				10,
				13,
				17
			},
			{
				10,
				16,
				22,
				28
			},
			{
				15,
				26,
				36,
				44
			},
			{
				20,
				36,
				52,
				64
			},
			{
				26,
				48,
				72,
				88
			},
			{
				36,
				64,
				96,
				112
			},
			{
				40,
				72,
				108,
				130
			},
			{
				48,
				88,
				132,
				156
			},
			{
				60,
				110,
				160,
				192
			},
			{
				72,
				130,
				192,
				224
			},
			{
				80,
				150,
				224,
				264
			},
			{
				96,
				176,
				260,
				308
			},
			{
				104,
				198,
				288,
				352
			},
			{
				120,
				216,
				320,
				384
			},
			{
				132,
				240,
				360,
				432
			},
			{
				144,
				280,
				408,
				480
			},
			{
				168,
				308,
				448,
				532
			},
			{
				180,
				338,
				504,
				588
			},
			{
				196,
				364,
				546,
				650
			},
			{
				224,
				416,
				600,
				700
			},
			{
				224,
				442,
				644,
				750
			},
			{
				252,
				476,
				690,
				816
			},
			{
				270,
				504,
				750,
				900
			},
			{
				300,
				560,
				810,
				960
			},
			{
				312,
				588,
				870,
				1050
			},
			{
				336,
				644,
				952,
				1110
			},
			{
				360,
				700,
				1020,
				1200
			},
			{
				390,
				728,
				1050,
				1260
			},
			{
				420,
				784,
				1140,
				1350
			},
			{
				450,
				812,
				1200,
				1440
			},
			{
				480,
				868,
				1290,
				1530
			},
			{
				510,
				924,
				1350,
				1620
			},
			{
				540,
				980,
				1440,
				1710
			},
			{
				570,
				1036,
				1530,
				1800
			},
			{
				570,
				1064,
				1590,
				1890
			},
			{
				600,
				1120,
				1680,
				1980
			},
			{
				630,
				1204,
				1770,
				2100
			},
			{
				660,
				1260,
				1860,
				2220
			},
			{
				720,
				1316,
				1950,
				2310
			},
			{
				750,
				1372,
				2040,
				2430
			}
		};

		// Token: 0x04000182 RID: 386
		private int[,,] k = new int[,,]
		{
			{
				{
					1,
					0
				},
				{
					1,
					0
				},
				{
					1,
					0
				},
				{
					1,
					0
				}
			},
			{
				{
					1,
					0
				},
				{
					1,
					0
				},
				{
					1,
					0
				},
				{
					1,
					0
				}
			},
			{
				{
					1,
					0
				},
				{
					1,
					0
				},
				{
					2,
					0
				},
				{
					2,
					0
				}
			},
			{
				{
					1,
					0
				},
				{
					2,
					0
				},
				{
					2,
					0
				},
				{
					4,
					0
				}
			},
			{
				{
					1,
					0
				},
				{
					2,
					0
				},
				{
					2,
					2
				},
				{
					2,
					2
				}
			},
			{
				{
					2,
					0
				},
				{
					4,
					0
				},
				{
					4,
					0
				},
				{
					4,
					0
				}
			},
			{
				{
					2,
					0
				},
				{
					4,
					0
				},
				{
					2,
					4
				},
				{
					4,
					1
				}
			},
			{
				{
					2,
					0
				},
				{
					2,
					2
				},
				{
					4,
					2
				},
				{
					4,
					2
				}
			},
			{
				{
					2,
					0
				},
				{
					3,
					2
				},
				{
					4,
					4
				},
				{
					4,
					4
				}
			},
			{
				{
					2,
					2
				},
				{
					4,
					1
				},
				{
					6,
					2
				},
				{
					6,
					2
				}
			},
			{
				{
					4,
					0
				},
				{
					1,
					4
				},
				{
					4,
					4
				},
				{
					3,
					8
				}
			},
			{
				{
					2,
					2
				},
				{
					6,
					2
				},
				{
					4,
					6
				},
				{
					7,
					4
				}
			},
			{
				{
					4,
					0
				},
				{
					8,
					1
				},
				{
					8,
					4
				},
				{
					12,
					4
				}
			},
			{
				{
					3,
					1
				},
				{
					4,
					5
				},
				{
					11,
					5
				},
				{
					11,
					5
				}
			},
			{
				{
					5,
					1
				},
				{
					5,
					5
				},
				{
					5,
					7
				},
				{
					11,
					7
				}
			},
			{
				{
					5,
					1
				},
				{
					7,
					3
				},
				{
					15,
					2
				},
				{
					3,
					13
				}
			},
			{
				{
					1,
					5
				},
				{
					10,
					1
				},
				{
					1,
					15
				},
				{
					2,
					17
				}
			},
			{
				{
					5,
					1
				},
				{
					9,
					4
				},
				{
					17,
					1
				},
				{
					2,
					19
				}
			},
			{
				{
					3,
					4
				},
				{
					3,
					11
				},
				{
					17,
					4
				},
				{
					9,
					16
				}
			},
			{
				{
					3,
					5
				},
				{
					3,
					13
				},
				{
					15,
					5
				},
				{
					15,
					10
				}
			},
			{
				{
					4,
					4
				},
				{
					17,
					0
				},
				{
					17,
					6
				},
				{
					19,
					6
				}
			},
			{
				{
					2,
					7
				},
				{
					17,
					0
				},
				{
					7,
					16
				},
				{
					34,
					0
				}
			},
			{
				{
					4,
					5
				},
				{
					4,
					14
				},
				{
					11,
					14
				},
				{
					16,
					14
				}
			},
			{
				{
					6,
					4
				},
				{
					6,
					14
				},
				{
					11,
					16
				},
				{
					30,
					2
				}
			},
			{
				{
					8,
					4
				},
				{
					8,
					13
				},
				{
					7,
					22
				},
				{
					22,
					13
				}
			},
			{
				{
					10,
					2
				},
				{
					19,
					4
				},
				{
					28,
					6
				},
				{
					33,
					4
				}
			},
			{
				{
					8,
					4
				},
				{
					22,
					3
				},
				{
					8,
					26
				},
				{
					12,
					28
				}
			},
			{
				{
					3,
					10
				},
				{
					3,
					23
				},
				{
					4,
					31
				},
				{
					11,
					31
				}
			},
			{
				{
					7,
					7
				},
				{
					21,
					7
				},
				{
					1,
					37
				},
				{
					19,
					26
				}
			},
			{
				{
					5,
					10
				},
				{
					19,
					10
				},
				{
					15,
					25
				},
				{
					23,
					25
				}
			},
			{
				{
					13,
					3
				},
				{
					2,
					29
				},
				{
					42,
					1
				},
				{
					23,
					28
				}
			},
			{
				{
					17,
					0
				},
				{
					10,
					23
				},
				{
					10,
					35
				},
				{
					19,
					35
				}
			},
			{
				{
					17,
					1
				},
				{
					14,
					21
				},
				{
					29,
					19
				},
				{
					11,
					46
				}
			},
			{
				{
					13,
					6
				},
				{
					14,
					23
				},
				{
					44,
					7
				},
				{
					59,
					1
				}
			},
			{
				{
					12,
					7
				},
				{
					12,
					26
				},
				{
					39,
					14
				},
				{
					22,
					41
				}
			},
			{
				{
					6,
					14
				},
				{
					6,
					34
				},
				{
					46,
					10
				},
				{
					2,
					64
				}
			},
			{
				{
					17,
					4
				},
				{
					29,
					14
				},
				{
					49,
					10
				},
				{
					24,
					46
				}
			},
			{
				{
					4,
					18
				},
				{
					13,
					32
				},
				{
					48,
					14
				},
				{
					42,
					32
				}
			},
			{
				{
					20,
					4
				},
				{
					40,
					7
				},
				{
					43,
					22
				},
				{
					10,
					67
				}
			},
			{
				{
					19,
					6
				},
				{
					18,
					31
				},
				{
					34,
					34
				},
				{
					20,
					61
				}
			}
		};

		// Token: 0x04000183 RID: 387
		private static short[][] l;

		// Token: 0x04000184 RID: 388
		private int m;

		// Token: 0x04000185 RID: 389
		private int n;

		// Token: 0x04000186 RID: 390
		private int o;

		// Token: 0x04000187 RID: 391
		private int p;

		// Token: 0x04000188 RID: 392
		private int q = 40;

		// Token: 0x04000189 RID: 393
		private int r;

		// Token: 0x0400018A RID: 394
		private short[,] s;

		// Token: 0x0400018B RID: 395
		private int t = 2;

		// Token: 0x0400018C RID: 396
		private int u = 40;
	}
}
