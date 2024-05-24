using System;
using System.Collections;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005AA RID: 1450
	internal class al5
	{
		// Token: 0x06003995 RID: 14741 RVA: 0x001EFE24 File Offset: 0x001EEE24
		internal al5(ald A_0, char[] A_1, int A_2, int A_3)
		{
			this.f = A_0.v();
			this.e = true;
			this.g = A_0.bb();
			this.a = A_1;
			this.b = A_2;
			this.c = A_3;
		}

		// Token: 0x06003996 RID: 14742 RVA: 0x001EFE76 File Offset: 0x001EEE76
		internal al5(char[] A_0, int A_1, int A_2)
		{
			this.f = null;
			this.e = false;
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06003997 RID: 14743 RVA: 0x001EFEAC File Offset: 0x001EEEAC
		internal string a()
		{
			return this.f;
		}

		// Token: 0x06003998 RID: 14744 RVA: 0x001EFEC4 File Offset: 0x001EEEC4
		internal char b()
		{
			return this.a[this.b];
		}

		// Token: 0x06003999 RID: 14745 RVA: 0x001EFEE4 File Offset: 0x001EEEE4
		internal char[] c()
		{
			return this.a;
		}

		// Token: 0x0600399A RID: 14746 RVA: 0x001EFEFC File Offset: 0x001EEEFC
		internal int d()
		{
			return this.b;
		}

		// Token: 0x0600399B RID: 14747 RVA: 0x001EFF14 File Offset: 0x001EEF14
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x0600399C RID: 14748 RVA: 0x001EFF1E File Offset: 0x001EEF1E
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600399D RID: 14749 RVA: 0x001EFF28 File Offset: 0x001EEF28
		internal ahs e()
		{
			return this.d;
		}

		// Token: 0x0600399E RID: 14750 RVA: 0x001EFF40 File Offset: 0x001EEF40
		internal ahq f()
		{
			char c = this.a[this.b];
			ahq result;
			if (c != '"')
			{
				if (c != '[')
				{
					if (this.o())
					{
						result = new aik(this);
					}
					else
					{
						int num = this.b;
						while (this.b < this.c && (al5.c(this.a[this.b]) || al5.a(this.a[this.b])))
						{
							this.b++;
						}
						int num2 = this.b - num;
						if (this.b == this.c)
						{
							result = new aiu(new string(this.a, num, num2));
						}
						else
						{
							c = this.a[this.b];
							if (c != '(')
							{
								if (c != '.')
								{
									if (c != '[')
									{
										result = new aiu(new string(this.a, num, num2));
									}
									else
									{
										result = this.b(num, num2);
									}
								}
								else
								{
									result = this.c(num, num2);
								}
							}
							else
							{
								result = this.a(num, num2);
							}
						}
					}
				}
				else
				{
					this.b++;
					int num3 = this.b;
					while (this.a[this.b] != ']')
					{
						this.b++;
					}
					int length = this.b - num3;
					this.b++;
					result = new aiu(new string(this.a, num3, length));
				}
			}
			else
			{
				result = new aim(this);
			}
			return result;
		}

		// Token: 0x0600399F RID: 14751 RVA: 0x001F00F4 File Offset: 0x001EF0F4
		internal bool b(bool A_0)
		{
			int i = this.b;
			bool result = false;
			bool flag = i == 0;
			if (A_0)
			{
				while (this.a[i] != '#')
				{
					if (this.a[i] == '[')
					{
						while (this.a[i] != ']')
						{
							i++;
						}
						i++;
					}
					else if (this.a[i] == '"')
					{
						i++;
						while (this.a[i] != '"')
						{
							i++;
						}
						i++;
					}
					else
					{
						if (al5.a(flag ? ' ' : this.a[i - 1], this.a[i]))
						{
							result = true;
							break;
						}
						i++;
					}
				}
			}
			else
			{
				while (i < this.c)
				{
					if (this.a[i] == '[')
					{
						while (this.a[i] != ']')
						{
							i++;
						}
						i++;
					}
					else if (this.a[i] == '"')
					{
						i++;
						while (this.a[i] != '"')
						{
							i++;
						}
						i++;
					}
					else
					{
						if (al5.a(flag ? ' ' : this.a[i - 1], this.a[i]))
						{
							result = true;
							break;
						}
						i++;
					}
				}
			}
			return result;
		}

		// Token: 0x060039A0 RID: 14752 RVA: 0x001F02AC File Offset: 0x001EF2AC
		internal static bool a(char A_0, char A_1)
		{
			return (!al5.c(A_0) || A_1 != '(') && A_1 != ')' && akj.b(A_1);
		}

		// Token: 0x060039A1 RID: 14753 RVA: 0x001F02E8 File Offset: 0x001EF2E8
		internal ahq c(bool A_0)
		{
			int num = this.b;
			if (A_0)
			{
				while (this.a[num] != '#')
				{
					num++;
				}
			}
			else
			{
				num = this.c;
			}
			char[] array = new char[num - this.b];
			Array.Copy(this.a, this.b, array, 0, array.Length);
			this.b = num;
			akj akj = new akj();
			array = akj.b(array);
			al5 al = new al5(array, 0, array.Length - 1);
			al.e = this.e;
			al.f = this.f;
			al.g = this.g;
			al.d = this.d;
			al.h = true;
			ahq result = al.g();
			this.d = al.d;
			return result;
		}

		// Token: 0x060039A2 RID: 14754 RVA: 0x001F03CC File Offset: 0x001EF3CC
		internal ahq g()
		{
			ArrayList arrayList = new ArrayList(3);
			while (this.b <= this.c && this.a[this.b] != ',' && this.a[this.b] != ')')
			{
				this.p();
				if (this.d(this.a[this.b]))
				{
					arrayList.Add(this.a(arrayList));
				}
				else
				{
					arrayList.Add(this.f());
				}
				if (this.b + 1 == this.a.Length)
				{
					break;
				}
			}
			return (ahq)arrayList[arrayList.Count - 1];
		}

		// Token: 0x060039A3 RID: 14755 RVA: 0x001F049C File Offset: 0x001EF49C
		internal bool d(char A_0)
		{
			if (A_0 <= '/')
			{
				if (A_0 == '!')
				{
					return true;
				}
				switch (A_0)
				{
				case '%':
					return true;
				case '&':
					return true;
				case '*':
					return true;
				case '+':
					return true;
				case '-':
					return true;
				case '/':
					return true;
				}
			}
			else
			{
				switch (A_0)
				{
				case '<':
					return true;
				case '=':
					return true;
				case '>':
					return true;
				default:
					switch (A_0)
					{
					case '^':
						return true;
					case '_':
						return true;
					default:
						switch (A_0)
						{
						case '|':
							return true;
						case '~':
							return true;
						}
						break;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x060039A4 RID: 14756 RVA: 0x001F056C File Offset: 0x001EF56C
		internal ahq a(ArrayList A_0)
		{
			ahq result = null;
			char c = this.a[this.b];
			if (c <= '/')
			{
				if (c != '!')
				{
					switch (c)
					{
					case '%':
						result = new ajk(A_0);
						this.b++;
						break;
					case '&':
						result = new aix(A_0);
						this.b++;
						break;
					case '*':
						result = new ajm(A_0);
						this.b++;
						break;
					case '+':
						result = new ajs(A_0);
						this.b++;
						break;
					case '-':
						result = new aj5(A_0);
						this.b++;
						break;
					case '/':
						result = new ai5(A_0);
						this.b++;
						break;
					}
				}
				else if (this.b != this.c && this.a[++this.b] == '=')
				{
					result = new ajo(A_0);
					this.b++;
				}
				else
				{
					result = new ajp(A_0);
				}
			}
			else
			{
				switch (c)
				{
				case '<':
					if (this.b != this.c && this.a[++this.b] == '=')
					{
						result = new ajh(A_0);
						this.b++;
					}
					else
					{
						result = new aji(A_0);
					}
					break;
				case '=':
					result = new ai6(A_0);
					this.b++;
					this.b++;
					break;
				case '>':
					if (this.b != this.c && this.a[++this.b] == '=')
					{
						result = new aja(A_0);
						this.b++;
					}
					else
					{
						result = new ajb(A_0);
					}
					break;
				default:
					switch (c)
					{
					case '^':
						result = new akb(A_0);
						this.b++;
						break;
					case '_':
						result = new ajn(A_0);
						this.b++;
						break;
					default:
						switch (c)
						{
						case '|':
							result = new ajq(A_0);
							this.b++;
							break;
						case '~':
							result = new aj6(A_0);
							this.b++;
							break;
						}
						break;
					}
					break;
				}
			}
			return result;
		}

		// Token: 0x060039A5 RID: 14757 RVA: 0x001F084C File Offset: 0x001EF84C
		internal ahq h()
		{
			int num = this.b;
			bool a_ = true;
			int num2 = 0;
			if (this.b < this.c)
			{
				while (this.a[this.b] != '#')
				{
					this.b++;
					if (this.b > this.c)
					{
						break;
					}
				}
				num2 = this.b;
				this.b = num;
			}
			if ((this.a[num - 1] == '#' || this.a[num - 1] == ' ') && this.a[num2] == '#')
			{
				while (this.a[this.b] != '#')
				{
					if (!this.o() && this.a[this.b] != ' ')
					{
						a_ = false;
					}
					this.a(this.d() + 1);
				}
			}
			else
			{
				while (this.b < this.c)
				{
					if (!this.o() && this.a[this.b] != ' ')
					{
						a_ = false;
					}
					this.a(this.d() + 1);
				}
			}
			return new aiu(new string(this.a, num, this.b - num), a_);
		}

		// Token: 0x060039A6 RID: 14758 RVA: 0x001F09C8 File Offset: 0x001EF9C8
		internal ahq i()
		{
			char c = this.a[this.b];
			ahq result;
			if (c != '"')
			{
				result = new anh(this.a, this.b, this.c);
			}
			else
			{
				result = new anh(this.a, this.b, this.c);
			}
			return result;
		}

		// Token: 0x060039A7 RID: 14759 RVA: 0x001F0A20 File Offset: 0x001EFA20
		internal string b(int A_0)
		{
			return new string(this.a, A_0, this.c - A_0);
		}

		// Token: 0x060039A8 RID: 14760 RVA: 0x001F0A48 File Offset: 0x001EFA48
		private int d(int A_0, int A_1)
		{
			int num = 0;
			int num2 = 0;
			int i;
			for (i = 0; i < A_1; i++)
			{
				num2 <<= 5;
				num2 |= (int)(this.a[A_0 + i] % ' ');
				if (i % 6 == 5)
				{
					num ^= num2;
					num2 = 0;
				}
			}
			if (i % 6 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x060039A9 RID: 14761 RVA: 0x001F0AB0 File Offset: 0x001EFAB0
		internal int j()
		{
			this.p();
			int num = this.b;
			while (al5.c(this.a[this.b]))
			{
				this.b++;
			}
			int num2 = this.b;
			this.p();
			return this.d(num, num2 - num);
		}

		// Token: 0x060039AA RID: 14762 RVA: 0x001F0B10 File Offset: 0x001EFB10
		internal string k()
		{
			this.p();
			int num = this.b;
			while (al5.c(this.a[this.b]))
			{
				this.b++;
			}
			int num2 = this.b;
			this.p();
			return new string(this.a, num, num2 - num);
		}

		// Token: 0x060039AB RID: 14763 RVA: 0x001F0B74 File Offset: 0x001EFB74
		internal int l()
		{
			this.p();
			int num = (int)(this.a[this.b] - '0');
			this.b++;
			while (al5.b(this.a[this.b]))
			{
				num *= 10;
				num += (int)(this.a[this.b] - '0');
				this.b++;
			}
			this.p();
			return num;
		}

		// Token: 0x060039AC RID: 14764 RVA: 0x001F0BF4 File Offset: 0x001EFBF4
		private ahq c(int A_0, int A_1)
		{
			string a_ = new string(this.a, A_0, A_1);
			A_0 = ++this.b;
			while (this.b < this.c && (al5.c(this.a[this.b]) || al5.a(this.a[this.b]) || this.a[this.b] == '.'))
			{
				this.b++;
			}
			string a_2 = new string(this.a, A_0, this.b - A_0);
			return new akp(a_, a_2);
		}

		// Token: 0x060039AD RID: 14765 RVA: 0x001F0CA8 File Offset: 0x001EFCA8
		internal ahq m()
		{
			this.b++;
			this.p();
			int num = this.b;
			while (al5.c(this.a[this.b]))
			{
				this.b++;
			}
			int num2 = this.b - num;
			if (this.a[this.b] == '[')
			{
			}
			throw new DlexParseException("Invalid Report variable.");
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x001F0D28 File Offset: 0x001EFD28
		private ahq b(int A_0, int A_1)
		{
			ahq result;
			if (akd.a(this.a, A_0, A_1))
			{
				result = new akd(this);
			}
			else
			{
				result = new ake(new string(this.a, A_0, A_1), this);
			}
			return result;
		}

		// Token: 0x060039AF RID: 14767 RVA: 0x001F0D6C File Offset: 0x001EFD6C
		private ahq a(int A_0, int A_1)
		{
			ahq result;
			if (ai0.a(this.a, A_0, A_1))
			{
				result = new ai0(this);
			}
			else if (ai8.a(this.a, A_0, A_1))
			{
				result = new ai8(this);
			}
			else if (aiw.a(this.a, A_0, A_1))
			{
				result = new aiw(this);
			}
			else if (ajm.a(this.a, A_0, A_1))
			{
				result = new ajm(this);
			}
			else if (aj5.a(this.a, A_0, A_1))
			{
				result = new aj5(this);
			}
			else if (ai5.a(this.a, A_0, A_1))
			{
				result = new ai5(this);
			}
			else if (ajf.a(this.a, A_0, A_1))
			{
				result = new ajf(this);
			}
			else if (ajy.a(this.a, A_0, A_1))
			{
				result = new ajy(this);
			}
			else if (aiz.a(this.a, A_0, A_1))
			{
				result = new aiz(this);
			}
			else if (aj4.a(this.a, A_0, A_1))
			{
				result = new aj4(this);
			}
			else if (ajg.a(this.a, A_0, A_1))
			{
				result = new ajg(this);
			}
			else if (aj9.a(this.a, A_0, A_1))
			{
				result = new aj9(this);
			}
			else if (aj8.a(this.a, A_0, A_1))
			{
				result = new aj8(this);
			}
			else if (aj7.a(this.a, A_0, A_1))
			{
				result = new aj7(this);
			}
			else if (aj3.a(this.a, A_0, A_1))
			{
				result = new aj3(this);
			}
			else if (ajx.a(this.a, A_0, A_1))
			{
				result = new ajx(this);
			}
			else if (aj2.a(this.a, A_0, A_1))
			{
				result = new aj2(this);
			}
			else if (ajt.a(this.a, A_0, A_1))
			{
				result = new ajt(this);
			}
			else if (ai7.a(this.a, A_0, A_1))
			{
				result = new ai7(this);
			}
			else if (aiy.a(this.a, A_0, A_1))
			{
				result = new aiy(this);
			}
			else if (ajn.a(this.a, A_0, A_1))
			{
				result = new ajn(this);
			}
			else if (ajz.a(this.a, A_0, A_1))
			{
				result = new ajz(this);
			}
			else if (aiv.a(this.a, A_0, A_1))
			{
				result = new aiv(this);
			}
			else if (aj1.a(this.a, A_0, A_1))
			{
				result = new aj1(this);
			}
			else if (akc.a(this.a, A_0, A_1))
			{
				result = new akc(this);
			}
			else if (ajl.a(this.a, A_0, A_1))
			{
				result = new ajl(this);
			}
			else if (ai4.a(this.a, A_0, A_1))
			{
				result = new ai4(this);
			}
			else if (ajc.a(this.a, A_0, A_1))
			{
				result = new ajc(this);
			}
			else if (ajj.a(this.a, A_0, A_1))
			{
				result = new ajj(this);
			}
			else if (aj0.a(this.a, A_0, A_1))
			{
				result = new aj0(this);
			}
			else if (aka.a(this.a, A_0, A_1))
			{
				result = new aka(this);
			}
			else if (ai1.a(this.a, A_0, A_1))
			{
				result = new ai1(this);
			}
			else if (ai2.a(this.a, A_0, A_1))
			{
				result = new ai2(this);
			}
			else if (ajb.a(this.a, A_0, A_1))
			{
				result = new ajb(this);
			}
			else if (aji.a(this.a, A_0, A_1))
			{
				result = new aji(this);
			}
			else if (ai6.a(this.a, A_0, A_1))
			{
				result = new ai6(this);
			}
			else if (aja.a(this.a, A_0, A_1))
			{
				result = new aja(this);
			}
			else if (ajh.a(this.a, A_0, A_1))
			{
				result = new ajh(this);
			}
			else if (aje.a(this.a, A_0, A_1))
			{
				result = new aje(this);
			}
			else if (ajd.a(this.a, A_0, A_1))
			{
				result = new ajd(this);
			}
			else if (ajw.a(this.a, A_0, A_1))
			{
				result = new ajw(this);
			}
			else if (ajr.a(this.a, A_0, A_1))
			{
				result = new ajr(this);
			}
			else if (aju.a(this.a, A_0, A_1))
			{
				result = new aju(this);
			}
			else if (ai9.a(this.a, A_0, A_1))
			{
				result = new ai9(this);
			}
			else if (aix.a(this.a, A_0, A_1))
			{
				result = new aix(this);
			}
			else if (ajk.a(this.a, A_0, A_1))
			{
				result = new ajk(this);
			}
			else if (ajo.a(this.a, A_0, A_1))
			{
				result = new ajo(this);
			}
			else if (ajp.a(this.a, A_0, A_1))
			{
				result = new ajp(this);
			}
			else if (ajq.a(this.a, A_0, A_1))
			{
				result = new ajq(this);
			}
			else if (aj6.a(this.a, A_0, A_1))
			{
				result = new aj6(this);
			}
			else if (akb.a(this.a, A_0, A_1))
			{
				result = new akb(this);
			}
			else
			{
				if (!this.e)
				{
					throw new DlexParseException("Aggregate functions are not allowed in this context.");
				}
				if (aic.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new aic(this);
				}
				else if (aht.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new aht(this);
				}
				else if (ah2.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ah2(this);
				}
				else if (ahw.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ahw(this);
				}
				else if (ahy.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ahy(this);
				}
				else if (ah4.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ah4(this);
				}
				else if (ah8.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ah8(this);
				}
				else if (ah0.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ah0(this);
				}
				else if (ah6.a(this.a, A_0, A_1))
				{
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new ah6(this);
				}
				else
				{
					if (!aia.a(this.a, A_0, A_1))
					{
						throw new DlexParseException("Invalid function.");
					}
					if (this.d == null)
					{
						this.d = new ahs();
					}
					result = new aia(this);
				}
			}
			return result;
		}

		// Token: 0x060039B0 RID: 14768 RVA: 0x001F167E File Offset: 0x001F067E
		internal void n()
		{
			this.b++;
		}

		// Token: 0x060039B1 RID: 14769 RVA: 0x001F1690 File Offset: 0x001F0690
		internal bool o()
		{
			return al5.b(this.a[this.b]);
		}

		// Token: 0x060039B2 RID: 14770 RVA: 0x001F16B4 File Offset: 0x001F06B4
		private static bool c(char A_0)
		{
			return A_0 <= 'z' && (A_0 >= 'a' || (A_0 <= 'Z' && (A_0 >= 'A' || (A_0 <= '9' && A_0 >= '0'))));
		}

		// Token: 0x060039B3 RID: 14771 RVA: 0x001F1720 File Offset: 0x001F0720
		private static bool b(char A_0)
		{
			return A_0 <= '9' && A_0 >= '0';
		}

		// Token: 0x060039B4 RID: 14772 RVA: 0x001F1750 File Offset: 0x001F0750
		private static bool a(char A_0)
		{
			return A_0 == '_';
		}

		// Token: 0x060039B5 RID: 14773 RVA: 0x001F1774 File Offset: 0x001F0774
		internal void p()
		{
			while (this.a[this.b] <= ' ')
			{
				this.b++;
			}
		}

		// Token: 0x060039B6 RID: 14774 RVA: 0x001F17AC File Offset: 0x001F07AC
		internal void q()
		{
			while (this.a[this.b] != '"')
			{
				this.b++;
			}
		}

		// Token: 0x060039B7 RID: 14775 RVA: 0x001F17E4 File Offset: 0x001F07E4
		internal void r()
		{
			while (this.a[this.b] != ']')
			{
				this.b++;
			}
		}

		// Token: 0x060039B8 RID: 14776 RVA: 0x001F181C File Offset: 0x001F081C
		internal void s()
		{
			while (this.a[this.b] != '.')
			{
				this.b++;
			}
		}

		// Token: 0x060039B9 RID: 14777 RVA: 0x001F1854 File Offset: 0x001F0854
		internal bool t()
		{
			return this.b < this.c;
		}

		// Token: 0x060039BA RID: 14778 RVA: 0x001F1874 File Offset: 0x001F0874
		internal bool u()
		{
			return this.b >= this.c;
		}

		// Token: 0x060039BB RID: 14779 RVA: 0x001F1898 File Offset: 0x001F0898
		internal bool v()
		{
			return this.h;
		}

		// Token: 0x060039BC RID: 14780 RVA: 0x001F18B0 File Offset: 0x001F08B0
		internal char c(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060039BD RID: 14781 RVA: 0x001F18CC File Offset: 0x001F08CC
		internal int w()
		{
			return this.c;
		}

		// Token: 0x060039BE RID: 14782 RVA: 0x001F18E4 File Offset: 0x001F08E4
		internal bool x()
		{
			return this.g;
		}

		// Token: 0x060039BF RID: 14783 RVA: 0x001F18FC File Offset: 0x001F08FC
		internal void d(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x04001B71 RID: 7025
		private char[] a;

		// Token: 0x04001B72 RID: 7026
		private int b;

		// Token: 0x04001B73 RID: 7027
		private int c;

		// Token: 0x04001B74 RID: 7028
		private ahs d;

		// Token: 0x04001B75 RID: 7029
		private bool e;

		// Token: 0x04001B76 RID: 7030
		private string f;

		// Token: 0x04001B77 RID: 7031
		private bool g;

		// Token: 0x04001B78 RID: 7032
		private bool h = false;
	}
}
