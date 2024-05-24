using System;

namespace zz93
{
	// Token: 0x02000037 RID: 55
	internal class a0 : az
	{
		// Token: 0x06000229 RID: 553 RVA: 0x00032B27 File Offset: 0x00031B27
		internal a0(int A_0, int A_1) : base(A_0, A_1)
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00032B34 File Offset: 0x00031B34
		internal short[] a(byte[] A_0, int A_1)
		{
			int num = 0;
			int num2 = A_0.Length;
			int num3;
			if (A_1 <= 8)
			{
				num3 = 9;
			}
			else if (A_1 >= 9 && A_1 <= 25)
			{
				num3 = 11;
			}
			else
			{
				num3 = 13;
			}
			int num4;
			if (num2 % 2 == 0)
			{
				num4 = num2 / 2 + 2;
			}
			else
			{
				num4 = num2 / 2 + 3;
			}
			int[] array;
			byte[] array2;
			if (base.a() == 0)
			{
				num4++;
				array = new int[num4];
				array2 = new byte[num4];
				array[num] = 5;
				array2[num] = 4;
				num++;
			}
			else if (base.a() == 1)
			{
				num4++;
				array = new int[num4];
				array2 = new byte[num4];
				array[num] = 9;
				array2[num] = 4;
				num++;
			}
			else
			{
				array = new int[num4];
				array2 = new byte[num4];
			}
			num2 = A_0.Length;
			array[num] = 2;
			array2[num] = 4;
			num++;
			array[num] = num2;
			array2[num] = (byte)num3;
			num++;
			int num5 = 0;
			foreach (byte b in A_0)
			{
				sbyte b2 = 0;
				if (b >= 48 && b < 58)
				{
					b2 = (sbyte)(b - 48);
				}
				else if (b >= 65 && b < 91)
				{
					b2 = (sbyte)(b - 55);
				}
				else
				{
					byte b3 = b;
					if (b3 != 32)
					{
						switch (b3)
						{
						case 36:
							b2 = 37;
							break;
						case 37:
							b2 = 38;
							break;
						case 38:
						case 39:
						case 40:
						case 41:
						case 44:
							break;
						case 42:
							b2 = 39;
							break;
						case 43:
							b2 = 40;
							break;
						case 45:
							b2 = 41;
							break;
						case 46:
							b2 = 42;
							break;
						case 47:
							b2 = 43;
							break;
						default:
							if (b3 == 58)
							{
								b2 = 44;
							}
							break;
						}
					}
					else
					{
						b2 = 36;
					}
				}
				if (num5 % 2 == 0)
				{
					array[num] = (int)b2;
					array2[num] = 6;
				}
				else
				{
					array[num] = array[num] * 45 + (int)b2;
					array2[num] = 11;
					if (num5 < num2 - 1)
					{
						num++;
					}
				}
				num5++;
			}
			num++;
			int[] a_ = base.a(array, array2);
			return base.c(a_);
		}
	}
}
