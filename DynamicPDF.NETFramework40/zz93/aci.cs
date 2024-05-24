using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000444 RID: 1092
	internal class aci
	{
		// Token: 0x06002D12 RID: 11538 RVA: 0x0019A560 File Offset: 0x00199560
		internal aci(string A_0) : this(aci.a(A_0))
		{
		}

		// Token: 0x06002D13 RID: 11539 RVA: 0x0019A571 File Offset: 0x00199571
		internal aci(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002D14 RID: 11540 RVA: 0x0019A58C File Offset: 0x0019958C
		public override int GetHashCode()
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < this.a.Length; i++)
			{
				num2 <<= 6;
				num2 |= (int)(this.a[i] % 64);
				if (i % 5 == 4)
				{
					num ^= num2;
					num2 = num >> 2;
				}
			}
			if (i % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x06002D15 RID: 11541 RVA: 0x0019A5FC File Offset: 0x001995FC
		public override bool Equals(object compareTo)
		{
			bool result;
			if (compareTo is aci)
			{
				byte[] array = ((aci)compareTo).a;
				if (this.a.Length != array.Length)
				{
					result = false;
				}
				else
				{
					for (int i = 0; i < this.a.Length; i++)
					{
						if (this.a[i] != array[i])
						{
							return false;
						}
					}
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x0019A674 File Offset: 0x00199674
		internal aci a(int A_0)
		{
			int num = this.a.Length;
			int num2;
			if (A_0 < 10)
			{
				num++;
				num2 = 1;
			}
			else if (A_0 < 100)
			{
				num += 2;
				num2 = 10;
			}
			else if (A_0 < 1000)
			{
				num += 3;
				num2 = 100;
			}
			else if (A_0 < 10000)
			{
				num += 4;
				num2 = 1000;
			}
			else if (A_0 < 100000)
			{
				num += 5;
				num2 = 10000;
			}
			else if (A_0 < 1000000)
			{
				num += 6;
				num2 = 100000;
			}
			else
			{
				if (A_0 >= 10000000)
				{
					throw new Exception("New name cannot be created. Too many entries.");
				}
				num += 7;
				num2 = 1000000;
			}
			byte[] array = new byte[num];
			this.a.CopyTo(array, 0);
			if (A_0 < 10)
			{
				array[this.a.Length] = (byte)(48 + A_0);
			}
			else
			{
				int i = this.a.Length;
				while (i < array.Length)
				{
					int num3 = A_0 / num2;
					array[i++] = (byte)(48 + num3);
					A_0 -= num3 * num2;
					num2 /= 10;
				}
			}
			return new aci(array);
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x0019A7E4 File Offset: 0x001997E4
		internal string a()
		{
			return ab2.a(this.a);
		}

		// Token: 0x06002D18 RID: 11544 RVA: 0x0019A804 File Offset: 0x00199804
		internal virtual void a(DocumentWriter A_0)
		{
			if (this.b)
			{
				A_0.ah(this.a, true);
			}
			else
			{
				A_0.WriteText(this.a);
			}
		}

		// Token: 0x06002D19 RID: 11545 RVA: 0x0019A83C File Offset: 0x0019983C
		internal bool a(aci A_0)
		{
			byte[] array = A_0.a;
			int i = 0;
			while (i < this.a.Length)
			{
				bool result;
				if (i == array.Length)
				{
					result = true;
				}
				else if (this.a[i] < array[i])
				{
					result = true;
				}
				else
				{
					if (this.a[i] <= array[i])
					{
						i++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return this.a.Length < array.Length;
		}

		// Token: 0x06002D1A RID: 11546 RVA: 0x0019A8BC File Offset: 0x001998BC
		internal static byte[] a(string A_0)
		{
			byte[] array = new byte[A_0.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = aci.b(A_0[i]);
			}
			return array;
		}

		// Token: 0x06002D1B RID: 11547 RVA: 0x0019A8FC File Offset: 0x001998FC
		private static byte b(char A_0)
		{
			byte result;
			if (A_0 < ' ')
			{
				result = 46;
			}
			else if (A_0 < '\u00a0')
			{
				result = (byte)A_0;
			}
			else if (A_0 < '¡')
			{
				result = 46;
			}
			else if (A_0 < '­')
			{
				result = (byte)A_0;
			}
			else if (A_0 < '®')
			{
				result = 46;
			}
			else if (A_0 < 'Ā')
			{
				result = (byte)A_0;
			}
			else
			{
				result = aci.a(A_0);
			}
			return result;
		}

		// Token: 0x06002D1C RID: 11548 RVA: 0x0019A98C File Offset: 0x0019998C
		private static byte a(char A_0)
		{
			if (A_0 <= 'ˇ')
			{
				if (A_0 <= 'š')
				{
					if (A_0 <= 'ł')
					{
						if (A_0 == 'ı')
						{
							return 154;
						}
						switch (A_0)
						{
						case 'Ł':
							return 149;
						case 'ł':
							return 155;
						}
					}
					else
					{
						switch (A_0)
						{
						case 'Œ':
							return 150;
						case 'œ':
							return 156;
						default:
							switch (A_0)
							{
							case 'Š':
								return 151;
							case 'š':
								return 157;
							}
							break;
						}
					}
				}
				else if (A_0 <= 'ž')
				{
					if (A_0 == 'Ÿ')
					{
						return 152;
					}
					switch (A_0)
					{
					case 'Ž':
						return 153;
					case 'ž':
						return 158;
					}
				}
				else
				{
					if (A_0 == 'ƒ')
					{
						return 134;
					}
					switch (A_0)
					{
					case 'ˆ':
						return 26;
					case 'ˇ':
						return 25;
					}
				}
			}
			else if (A_0 <= '›')
			{
				if (A_0 <= '…')
				{
					switch (A_0)
					{
					case '˘':
						return 24;
					case '˙':
						return 27;
					case '˚':
						return 30;
					case '˛':
						return 29;
					case '˜':
						return 31;
					case '˝':
						return 28;
					default:
						switch (A_0)
						{
						case '–':
							return 133;
						case '—':
							return 132;
						case '‘':
							return 143;
						case '’':
							return 144;
						case '‚':
							return 145;
						case '“':
							return 141;
						case '”':
							return 142;
						case '„':
							return 140;
						case '†':
							return 129;
						case '‡':
							return 130;
						case '•':
							return 128;
						case '…':
							return 131;
						}
						break;
					}
				}
				else
				{
					if (A_0 == '‰')
					{
						return 139;
					}
					switch (A_0)
					{
					case '‹':
						return 136;
					case '›':
						return 137;
					}
				}
			}
			else if (A_0 <= '€')
			{
				if (A_0 == '⁄')
				{
					return 135;
				}
				if (A_0 == '€')
				{
					return 160;
				}
			}
			else
			{
				if (A_0 == '™')
				{
					return 146;
				}
				if (A_0 == '−')
				{
					return 138;
				}
				switch (A_0)
				{
				case 'ﬁ':
					return 147;
				case 'ﬂ':
					return 148;
				}
			}
			return 46;
		}

		// Token: 0x06002D1D RID: 11549 RVA: 0x0019ACE0 File Offset: 0x00199CE0
		internal bool b()
		{
			return this.b;
		}

		// Token: 0x06002D1E RID: 11550 RVA: 0x0019ACF8 File Offset: 0x00199CF8
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002D1F RID: 11551 RVA: 0x0019AD04 File Offset: 0x00199D04
		internal byte[] c()
		{
			return this.a;
		}

		// Token: 0x04001551 RID: 5457
		private byte[] a;

		// Token: 0x04001552 RID: 5458
		private bool b = false;
	}
}
