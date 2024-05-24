using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000044 RID: 68
	internal class bd : ac
	{
		// Token: 0x06000280 RID: 640 RVA: 0x0003D598 File Offset: 0x0003C598
		internal char[] d()
		{
			return this.a;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0003D5B0 File Offset: 0x0003C5B0
		internal static float c()
		{
			return 66f;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0003D5C8 File Offset: 0x0003C5C8
		internal static float b()
		{
			return 90f;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0003D5E0 File Offset: 0x0003C5E0
		internal static float a()
		{
			return 117f;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0003D5F8 File Offset: 0x0003C5F8
		internal bd(string A_0)
		{
			if (A_0.Length < 7 || A_0.Length > 8)
			{
				throw new ap("UPC Version E value must be 7 or 8 characters long.");
			}
			if (A_0.Length == 7)
			{
				this.a = new char[A_0.Length + 1];
				A_0.ToCharArray().CopyTo(this.a, 0);
				this.a(this.a);
			}
			else
			{
				this.a = A_0.ToCharArray();
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0003D68C File Offset: 0x0003C68C
		internal BitArray a(BitArray A_0)
		{
			BitArray bitArray = new BitArray(51, true);
			for (int i = 0; i < 51; i++)
			{
				if (i == 0 || i == 2 || i == 46 || i == 48 || i == 50)
				{
					bitArray[i] = A_0[i];
				}
				else
				{
					bitArray[i] = true;
				}
			}
			return bitArray;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0003D6FC File Offset: 0x0003C6FC
		internal BitArray b(BitArray A_0)
		{
			BitArray bitArray = new BitArray(51, true);
			for (int i = 0; i < 51; i++)
			{
				if (i == 0 || i == 2 || i == 46 || i == 48 || i == 50)
				{
					bitArray[i] = true;
				}
				else
				{
					bitArray[i] = A_0[i];
				}
			}
			return bitArray;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0003D76C File Offset: 0x0003C76C
		internal BitArray e()
		{
			base.a(1);
			base.b(1);
			base.a(1);
			av[] array = this.b(this.a);
			for (int i = 1; i < 7; i++)
			{
				if (array[i - 1] == av.b)
				{
					base.a(this.a[i]);
				}
				else
				{
					base.b(this.a[i]);
				}
			}
			base.b(1);
			base.a(1);
			base.b(1);
			base.a(1);
			base.b(1);
			base.a(1);
			return base.f();
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0003D820 File Offset: 0x0003C820
		private av[] b(char[] A_0)
		{
			av[] result;
			if (A_0[0] == '0')
			{
				switch (A_0[7])
				{
				case '0':
					result = new av[]
					{
						av.a,
						av.a,
						av.a,
						av.b,
						av.b,
						av.b
					};
					break;
				case '1':
					result = new av[]
					{
						av.a,
						av.a,
						av.b,
						av.a,
						av.b,
						av.b
					};
					break;
				case '2':
					result = new av[]
					{
						av.a,
						av.a,
						av.b,
						av.b,
						av.a,
						av.b
					};
					break;
				case '3':
				{
					av[] array = new av[6];
					array[2] = av.b;
					array[3] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				case '4':
					result = new av[]
					{
						av.a,
						av.b,
						av.a,
						av.a,
						av.b,
						av.b
					};
					break;
				case '5':
					result = new av[]
					{
						av.a,
						av.b,
						av.b,
						av.a,
						av.a,
						av.b
					};
					break;
				case '6':
				{
					av[] array = new av[6];
					array[1] = av.b;
					array[2] = av.b;
					array[3] = av.b;
					result = array;
					break;
				}
				case '7':
					result = new av[]
					{
						av.a,
						av.b,
						av.a,
						av.b,
						av.a,
						av.b
					};
					break;
				case '8':
				{
					av[] array = new av[6];
					array[1] = av.b;
					array[3] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				default:
				{
					av[] array = new av[6];
					array[1] = av.b;
					array[2] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				}
			}
			else
			{
				if (A_0[0] != '1')
				{
					throw new ap("Invalid UPC Version E Numbering System. Must be 0 or 1.");
				}
				switch (A_0[7])
				{
				case '0':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[1] = av.b;
					array[2] = av.b;
					result = array;
					break;
				}
				case '1':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[1] = av.b;
					array[3] = av.b;
					result = array;
					break;
				}
				case '2':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[1] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				case '3':
					result = new av[]
					{
						av.b,
						av.b,
						av.a,
						av.a,
						av.a,
						av.b
					};
					break;
				case '4':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[2] = av.b;
					array[3] = av.b;
					result = array;
					break;
				}
				case '5':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[3] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				case '6':
					result = new av[]
					{
						av.b,
						av.a,
						av.a,
						av.a,
						av.b,
						av.b
					};
					break;
				case '7':
				{
					av[] array = new av[6];
					array[0] = av.b;
					array[2] = av.b;
					array[4] = av.b;
					result = array;
					break;
				}
				case '8':
					result = new av[]
					{
						av.b,
						av.a,
						av.b,
						av.a,
						av.a,
						av.b
					};
					break;
				default:
					result = new av[]
					{
						av.b,
						av.a,
						av.a,
						av.b,
						av.a,
						av.b
					};
					break;
				}
			}
			return result;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0003DAC4 File Offset: 0x0003CAC4
		private void a(char[] A_0)
		{
			int num = (int)((A_0[0] - '0') * '\u0003');
			num += (int)(A_0[1] - '0');
			num += (int)((A_0[2] - '0') * '\u0003');
			switch (A_0[6])
			{
			case '0':
				break;
			case '1':
				break;
			case '2':
				break;
			case '3':
				num += (int)(A_0[3] - '0');
				num += (int)(A_0[4] - '0');
				num += (int)((A_0[5] - '0') * '\u0003');
				goto IL_FD;
			case '4':
				num += (int)(A_0[3] - '0');
				num += (int)((A_0[4] - '0') * '\u0003');
				num += (int)((A_0[5] - '0') * '\u0003');
				goto IL_FD;
			case '5':
				goto IL_C8;
			case '6':
				goto IL_C8;
			case '7':
				goto IL_C8;
			case '8':
				goto IL_C8;
			default:
				throw new ap("The 7th digit of the UPC Version E must be a 0 to 8 value.");
			}
			num += (int)(A_0[6] - '0');
			num += (int)((A_0[3] - '0') * '\u0003');
			num += (int)(A_0[4] - '0');
			num += (int)((A_0[5] - '0') * '\u0003');
			goto IL_FD;
			IL_C8:
			num += (int)(A_0[3] - '0');
			num += (int)((A_0[4] - '0') * '\u0003');
			num += (int)(A_0[5] - '0');
			num += (int)((A_0[6] - '0') * '\u0003');
			IL_FD:
			A_0[7] = (char)(58 - num % 10);
			if (A_0[7] == ':')
			{
				A_0[7] = '0';
			}
		}

		// Token: 0x040001AA RID: 426
		private new char[] a;
	}
}
