using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x02000198 RID: 408
	internal class kg
	{
		// Token: 0x06000E11 RID: 3601 RVA: 0x0009DDA8 File Offset: 0x0009CDA8
		internal kg(char[] A_0, HtmlArea A_1)
		{
			this.a = A_0;
			this.p = this.a.Length;
			this.l = A_1;
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x0009DE64 File Offset: 0x0009CE64
		internal bool t()
		{
			return this.d;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0009DE7C File Offset: 0x0009CE7C
		internal void b(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x0009DE88 File Offset: 0x0009CE88
		internal bool u()
		{
			return this.e;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x0009DEA0 File Offset: 0x0009CEA0
		internal void c(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x0009DEAC File Offset: 0x0009CEAC
		internal int v()
		{
			return this.c;
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x0009DEC4 File Offset: 0x0009CEC4
		internal int w()
		{
			return this.b;
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x0009DEDC File Offset: 0x0009CEDC
		internal void b(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x0009DEE8 File Offset: 0x0009CEE8
		internal char[] x()
		{
			return this.a;
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x0009DF00 File Offset: 0x0009CF00
		internal void a(char[] A_0)
		{
			this.a = A_0;
			this.p = this.a.Length;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x0009DF18 File Offset: 0x0009CF18
		internal HtmlArea y()
		{
			return this.l;
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x0009DF30 File Offset: 0x0009CF30
		internal bool z()
		{
			return this.m;
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x0009DF48 File Offset: 0x0009CF48
		internal void d(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x0009DF54 File Offset: 0x0009CF54
		internal bool aa()
		{
			return this.f;
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x0009DF6C File Offset: 0x0009CF6C
		internal void e(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x0009DF78 File Offset: 0x0009CF78
		internal bool ab()
		{
			return this.h;
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x0009DF90 File Offset: 0x0009CF90
		internal void f(bool A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x0009DF9C File Offset: 0x0009CF9C
		internal bool ac()
		{
			return this.o;
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x0009DFB4 File Offset: 0x0009CFB4
		internal void g(bool A_0)
		{
			this.o = A_0;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x0009DFC0 File Offset: 0x0009CFC0
		internal int ad()
		{
			return this.i;
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x0009DFD8 File Offset: 0x0009CFD8
		internal void c(int A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x0009DFE4 File Offset: 0x0009CFE4
		internal int ae()
		{
			return this.q;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x0009DFFC File Offset: 0x0009CFFC
		internal bool af()
		{
			return this.b >= this.p;
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x0009E028 File Offset: 0x0009D028
		internal int ag()
		{
			return this.j;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x0009E040 File Offset: 0x0009D040
		internal void d(int A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0009E04C File Offset: 0x0009D04C
		internal bool ah()
		{
			return this.n;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0009E064 File Offset: 0x0009D064
		internal void h(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0009E070 File Offset: 0x0009D070
		private int a(int A_0)
		{
			int i = A_0 - 1;
			int num = 0;
			while (i < this.p)
			{
				if (this.a[i] > ' ')
				{
					return num;
				}
				num++;
				i--;
			}
			return num;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x0009E0BC File Offset: 0x0009D0BC
		private bool s()
		{
			int num = this.b;
			if (num < this.p && this.a[num] == '<')
			{
				num++;
				while (num < this.p && this.a[num] != '>')
				{
					num++;
				}
				if (num < this.p && this.a[num] == '>')
				{
					num++;
				}
			}
			while (num < this.p && this.a[num] != '<')
			{
				bool result;
				if (this.a[num] > ' ')
				{
					result = false;
				}
				else
				{
					if (this.a[num] != '\r' || this.a[num + 1] != '\n')
					{
						num++;
						continue;
					}
					result = true;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x0009E1B0 File Offset: 0x0009D1B0
		private void r()
		{
			if (this.b + 1 < this.p && this.a[this.b] == '<' && this.a[this.b + 1] == '!')
			{
				this.m();
			}
			else if (this.o())
			{
				this.n();
			}
			else
			{
				this.f = true;
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x0009E230 File Offset: 0x0009D230
		private bool q()
		{
			return this.a(this.a[this.b]) || this.p() || this.a[this.b] == '-' || this.a[this.b] == '_' || this.a[this.b] == ':' || this.a[this.b] == '.';
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x0009E2A8 File Offset: 0x0009D2A8
		private bool p()
		{
			return this.a[this.b] >= '0' && this.a[this.b] <= '9';
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x0009E2E4 File Offset: 0x0009D2E4
		private bool a(char A_0)
		{
			return (A_0 >= 'a' && A_0 <= 'z') || (A_0 >= 'A' && A_0 <= 'Z');
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x0009E318 File Offset: 0x0009D318
		private bool o()
		{
			return this.a[this.b] == '<' && this.b + 1 < this.p && (this.a[this.b + 1] == '/' || (this.a[this.b + 1] > ' ' && this.a[this.b + 1] != '>' && this.a[this.b + 1] != '<'));
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0009E3A8 File Offset: 0x0009D3A8
		private void n()
		{
			this.b++;
			if ((this.b < this.p && this.a[this.b] != '<') || this.a[this.b] != '>')
			{
				if (this.a[this.b] == '/')
				{
					this.d = false;
					this.e = true;
					this.b++;
				}
				else
				{
					this.d = true;
					this.e = false;
				}
				this.e();
			}
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x0009E450 File Offset: 0x0009D450
		private void m()
		{
			bool a_ = false;
			if (this.a(ref a_))
			{
				this.h();
				this.a(a_);
			}
			else if (this.i())
			{
				this.h();
				this.g();
			}
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x0009E4A0 File Offset: 0x0009D4A0
		private bool l()
		{
			bool flag = false;
			return this.o() || this.a(ref flag) || this.i();
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x0009E4D4 File Offset: 0x0009D4D4
		private bool k()
		{
			return this.a[this.b] == '&' && this.b + 1 < this.p && this.a[this.b + 1] > ' ' && this.a[this.b + 1] != '&' && this.a[this.b + 1] != '<';
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0009E548 File Offset: 0x0009D548
		private bool a(pm A_0, bool A_1)
		{
			this.b++;
			bool flag = true;
			int num = this.b;
			int num2 = 0;
			bool a_ = false;
			while (this.b < this.p && this.a[this.b] != ';')
			{
				this.b++;
				num2++;
			}
			if (this.a[num] == '#')
			{
				int i = num + 1;
				int num3 = i + num2 - 1;
				int num4 = 0;
				if (this.a[i] == 'x' || this.a[i] == 'X')
				{
					i++;
					while (i < num3)
					{
						if (this.a[i] >= '0' && this.a[i] <= '9')
						{
							num4 = (num4 << 4 | (int)(this.a[i++] - '0'));
						}
						else if (this.a[i] >= 'A' && this.a[i] <= 'F')
						{
							num4 = (num4 << 4 | (int)(this.a[i++] - '7'));
						}
						else if (this.a[i] >= 'a' && this.a[i] <= 'f')
						{
							num4 = (num4 << 4 | (int)(this.a[i++] - 'W'));
						}
					}
					this.a[this.b] = (char)num4;
				}
				else
				{
					while (i < num3)
					{
						if (this.a[i] >= '0' && this.a[i] <= '9')
						{
							num4 = num4 * 10 + (int)this.a[i] - 48;
						}
						i++;
					}
					this.a[this.b] = (char)num4;
				}
				if (flag)
				{
					int num5 = num4;
					if (num5 <= 8736)
					{
						if (num5 <= 8629)
						{
							if (num5 <= 8472)
							{
								if (num5 != 8465 && num5 != 8472)
								{
									goto IL_3F9;
								}
							}
							else if (num5 != 8476 && num5 != 8501 && num5 != 8629)
							{
								goto IL_3F9;
							}
						}
						else if (num5 <= 8715)
						{
							switch (num5)
							{
							case 8656:
							case 8657:
							case 8658:
							case 8659:
							case 8660:
								break;
							default:
								switch (num5)
								{
								case 8704:
								case 8707:
								case 8709:
								case 8711:
								case 8712:
								case 8713:
								case 8715:
									break;
								case 8705:
								case 8706:
								case 8708:
								case 8710:
								case 8714:
									goto IL_3F9;
								default:
									goto IL_3F9;
								}
								break;
							}
						}
						else if (num5 != 8727 && num5 != 8733 && num5 != 8736)
						{
							goto IL_3F9;
						}
					}
					else if (num5 <= 8839)
					{
						if (num5 <= 8756)
						{
							switch (num5)
							{
							case 8743:
							case 8744:
							case 8746:
								break;
							case 8745:
								goto IL_3F9;
							default:
								if (num5 != 8756)
								{
									goto IL_3F9;
								}
								break;
							}
						}
						else if (num5 != 8764 && num5 != 8773)
						{
							switch (num5)
							{
							case 8834:
							case 8835:
							case 8836:
							case 8838:
							case 8839:
								break;
							case 8837:
								goto IL_3F9;
							default:
								goto IL_3F9;
							}
						}
					}
					else if (num5 <= 8869)
					{
						switch (num5)
						{
						case 8853:
						case 8855:
							break;
						case 8854:
							goto IL_3F9;
						default:
							if (num5 != 8869)
							{
								goto IL_3F9;
							}
							break;
						}
					}
					else if (num5 != 8901)
					{
						switch (num5)
						{
						case 8968:
						case 8969:
						case 8970:
						case 8971:
							break;
						default:
							switch (num5)
							{
							case 9001:
							case 9002:
								break;
							default:
								goto IL_3F9;
							}
							break;
						}
					}
					a_ = true;
					IL_3F9:;
				}
			}
			else
			{
				int num6 = this.a(num, num2);
				int num5 = num6;
				if (num5 <= 22368331)
				{
					if (num5 <= 2234592)
					{
						if (num5 <= 87008)
						{
							if (num5 <= 1945)
							{
								if (num5 <= 993)
								{
									if (num5 <= 549)
									{
										if (num5 == 523)
										{
											this.a[this.b] = '≥';
											goto IL_2981;
										}
										if (num5 == 549)
										{
											this.a[this.b] = '≠';
											goto IL_2981;
										}
									}
									else
									{
										if (num5 == 552)
										{
											this.a[this.b] = '≤';
											goto IL_2981;
										}
										if (num5 == 980)
										{
											if (this.a[num] == 'Z')
											{
												this.a[this.b] = 'Ξ';
											}
											else
											{
												this.a[this.b] = 'ξ';
											}
											goto IL_2981;
										}
										if (num5 == 993)
										{
											if (this.a[num] == 'Z')
											{
												this.a[this.b] = 'Π';
											}
											else
											{
												this.a[this.b] = 'π';
											}
											goto IL_2981;
										}
									}
								}
								else if (num5 <= 1370)
								{
									if (num5 == 997)
									{
										this.a[this.b] = '∋';
										a_ = true;
										goto IL_2981;
									}
									if (num5 == 1370)
									{
										this.a[this.b] = '™';
										goto IL_2981;
									}
								}
								else
								{
									if (num5 == 1675)
									{
										this.a[this.b] = '>';
										goto IL_2981;
									}
									if (num5 == 1704)
									{
										this.a[this.b] = '<';
										goto IL_2981;
									}
									if (num5 == 1945)
									{
										this.a[this.b] = '∨';
										a_ = true;
										goto IL_2981;
									}
								}
							}
							else if (num5 <= 45621)
							{
								if (num5 <= 2277)
								{
									if (num5 == 2261)
									{
										if (this.a[num] == 'Z')
										{
											this.a[this.b] = 'Μ';
										}
										else
										{
											this.a[this.b] = 'μ';
										}
										goto IL_2981;
									}
									if (num5 == 2277)
									{
										if (this.a[num] == 'Z')
										{
											this.a[this.b] = 'Ν';
										}
										else
										{
											this.a[this.b] = 'ν';
										}
										goto IL_2981;
									}
								}
								else
								{
									if (num5 == 5768)
									{
										if (this.a[num] == 'E')
										{
											this.a[this.b] = 'Η';
										}
										else
										{
											this.a[this.b] = 'η';
										}
										goto IL_2981;
									}
									if (num5 == 45598)
									{
										this.a[this.b] = '®';
										goto IL_2981;
									}
									if (num5 == 45621)
									{
										this.a[this.b] = '°';
										goto IL_2981;
									}
								}
							}
							else if (num5 <= 64453)
							{
								if (num5 == 47425)
								{
									this.a[this.b] = '∠';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 63521)
								{
									if (this.a[num] == 'P')
									{
										this.a[this.b] = 'Ψ';
									}
									else
									{
										this.a[this.b] = 'ψ';
									}
									goto IL_2981;
								}
								if (num5 == 64453)
								{
									if (this.a[num] == 'C')
									{
										this.a[this.b] = 'Χ';
									}
									else
									{
										this.a[this.b] = 'χ';
									}
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 64481)
								{
									if (this.a[num] == 'P')
									{
										this.a[this.b] = 'Φ';
									}
									else
									{
										this.a[this.b] = 'φ';
									}
									goto IL_2981;
								}
								if (num5 == 67176)
								{
									this.a[this.b] = '◊';
									goto IL_2981;
								}
								if (num5 == 87008)
								{
									this.a[this.b] = '∼';
									a_ = true;
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 143450)
						{
							if (num5 <= 108879)
							{
								if (num5 <= 95201)
								{
									if (num5 == 88288)
									{
										this.a[this.b] = '∑';
										goto IL_2981;
									}
									if (num5 == 95201)
									{
										this.a[this.b] = 'ϖ';
										goto IL_2981;
									}
								}
								else
								{
									if (num5 == 105438)
									{
										if (this.a[num] == 'Z')
										{
											this.a[this.b] = 'Ρ';
										}
										else
										{
											this.a[this.b] = 'ρ';
										}
										goto IL_2981;
									}
									if (num5 == 108133)
									{
										this.a[this.b] = '¬';
										goto IL_2981;
									}
									if (num5 == 108879)
									{
										this.a[this.b] = '∫';
										goto IL_2981;
									}
								}
							}
							else if (num5 <= 136513)
							{
								if (num5 == 135237)
								{
									this.a[this.b] = '∩';
									goto IL_2981;
								}
								if (num5 == 136513)
								{
									this.a[this.b] = '&';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 137413)
								{
									this.a[this.b] = '∪';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 137440)
								{
									this.a[this.b] = '⊃';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 143450)
								{
									if (this.a[num] == 'T')
									{
										this.a[this.b] = 'Τ';
									}
									else
									{
										this.a[this.b] = 'τ';
									}
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 219457)
						{
							if (num5 <= 165219)
							{
								if (num5 == 152106)
								{
									this.a[this.b] = '¥';
									goto IL_2981;
								}
								if (num5 == 165219)
								{
									this.a[this.b] = '¨';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 175072)
								{
									this.a[this.b] = '­';
									goto IL_2981;
								}
								if (num5 == 194184)
								{
									if (this.a[num] == 'E')
									{
										this.a[this.b] = 'Ð';
									}
									else
									{
										this.a[this.b] = 'ð';
									}
									goto IL_2981;
								}
								if (num5 == 219457)
								{
									this.a[this.b] = '∧';
									a_ = true;
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 369209)
						{
							if (num5 == 235744)
							{
								this.a[this.b] = '⊂';
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 369168)
							{
								if (this.a[num] == 'Z')
								{
									this.a[this.b] = 'Ζ';
								}
								else
								{
									this.a[this.b] = 'ζ';
								}
								goto IL_2981;
							}
							if (num5 == 369209)
							{
								if (this.a[num] == 'B')
								{
									this.a[this.b] = 'Β';
								}
								else
								{
									this.a[this.b] = 'β';
								}
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 370255)
							{
								if (this.a[num] == 'I')
								{
									this.a[this.b] = 'Ι';
								}
								else
								{
									this.a[this.b] = 'ι';
								}
								goto IL_2981;
							}
							if (num5 == 385121)
							{
								this.a[this.b] = '¶';
								goto IL_2981;
							}
							if (num5 == 2234592)
							{
								this.a[this.b] = '⊇';
								a_ = true;
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 8755105)
					{
						if (num5 <= 6920412)
						{
							if (num5 <= 3036741)
							{
								if (num5 <= 2758880)
								{
									if (num5 == 2332896)
									{
										this.a[this.b] = '⊆';
										a_ = true;
										goto IL_2981;
									}
									if (num5 == 2758880)
									{
										this.a[this.b] = '³';
										goto IL_2981;
									}
								}
								else
								{
									if (num5 == 3035230)
									{
										this.a[this.b] = '〉';
										a_ = true;
										goto IL_2981;
									}
									if (num5 == 3035240)
									{
										this.a[this.b] = '〈';
										a_ = true;
										goto IL_2981;
									}
									if (num5 == 3036741)
									{
										this.a[this.b] = '≅';
										a_ = true;
										goto IL_2981;
									}
								}
							}
							else if (num5 <= 5724057)
							{
								if (num5 == 3545312)
								{
									this.a[this.b] = '¹';
									goto IL_2981;
								}
								if (num5 == 5724057)
								{
									this.a[this.b] = 'º';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 6678728)
								{
									this.a[this.b] = '€';
									goto IL_2981;
								}
								if (num5 == 6836768)
								{
									this.a[this.b] = '§';
									goto IL_2981;
								}
								if (num5 == 6920412)
								{
									this.a[this.b] = '"';
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 7987294)
						{
							if (num5 <= 6938721)
							{
								if (num5 == 6921568)
								{
									this.a[this.b] = '⋅';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 6938721)
								{
									this.a[this.b] = '∂';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 6967813)
								{
									this.a[this.b] = '¢';
									goto IL_2981;
								}
								if (num5 == 7884885)
								{
									this.a[this.b] = '¯';
									goto IL_2981;
								}
								if (num5 == 7987294)
								{
									if (num + 1 < this.a.Length && this.a[num] == 'r' && this.a[num + 1] == 'A')
									{
										this.a[this.b] = '⇒';
									}
									else
									{
										this.a[this.b] = '→';
									}
									a_ = true;
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 7987311)
						{
							if (num5 == 7987299)
							{
								if (num + 1 < this.a.Length && this.a[num] == 'u' && this.a[num + 1] == 'A')
								{
									this.a[this.b] = '⇑';
								}
								else
								{
									this.a[this.b] = '↑';
								}
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 7987304)
							{
								if (num + 1 < this.a.Length && this.a[num] == 'l' && this.a[num + 1] == 'A')
								{
									this.a[this.b] = '⇐';
								}
								else
								{
									this.a[this.b] = '←';
								}
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 7987311)
							{
								if (num + 1 < this.a.Length && this.a[num] == 'h' && this.a[num + 1] == 'A')
								{
									this.a[this.b] = '⇔';
								}
								else
								{
									this.a[this.b] = '↔';
								}
								a_ = true;
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 7987317)
							{
								if (num + 1 < this.a.Length && this.a[num] == 'd' && this.a[num + 1] == 'A')
								{
									this.a[this.b] = '⇓';
								}
								else
								{
									this.a[this.b] = '↓';
								}
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 8493121)
							{
								this.a[this.b] = '\'';
								goto IL_2981;
							}
							if (num5 == 8755105)
							{
								this.a[this.b] = '∝';
								a_ = true;
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 10574058)
					{
						if (num5 <= 10574017)
						{
							if (num5 <= 8785509)
							{
								if (num5 == 8774177)
								{
									this.a[this.b] = '⊥';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 8785509)
								{
									this.a[this.b] = '\u00a0';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 9762831)
								{
									this.a[this.b] = '∈';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 10490398)
								{
									this.a[this.b] = 'ℜ';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 10574017)
								{
									if (this.a[num] == 'A')
									{
										this.a[this.b] = 'Ä';
									}
									else
									{
										this.a[this.b] = 'ä';
									}
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 10574031)
						{
							if (num5 == 10574024)
							{
								if (this.a[num] == 'E')
								{
									this.a[this.b] = 'Ë';
								}
								else
								{
									this.a[this.b] = 'ë';
								}
								goto IL_2981;
							}
							if (num5 == 10574031)
							{
								if (this.a[num] == 'I')
								{
									this.a[this.b] = 'Ï';
								}
								else
								{
									this.a[this.b] = 'ï';
								}
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 10574041)
							{
								if (this.a[num] == 'O')
								{
									this.a[this.b] = 'Ö';
								}
								else
								{
									this.a[this.b] = 'ö';
								}
								goto IL_2981;
							}
							if (num5 == 10574051)
							{
								if (this.a[num] == 'U')
								{
									this.a[this.b] = 'Ü';
								}
								else
								{
									this.a[this.b] = 'ü';
								}
								goto IL_2981;
							}
							if (num5 == 10574058)
							{
								this.a[this.b] = 'ÿ';
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 13326233)
					{
						if (num5 <= 11146821)
						{
							if (num5 == 10651897)
							{
								this.a[this.b] = '•';
								goto IL_2981;
							}
							if (num5 == 11146821)
							{
								this.a[this.b] = '©';
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 12720352)
							{
								this.a[this.b] = '²';
								goto IL_2981;
							}
							if (num5 == 13212018)
							{
								this.a[this.b] = 'ƒ';
								goto IL_2981;
							}
							if (num5 == 13326233)
							{
								this.a[this.b] = 'ª';
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 19694937)
					{
						if (num5 == 13997985)
						{
							this.a[this.b] = '∏';
							goto IL_2981;
						}
						if (num5 == 15087653)
						{
							this.a[this.b] = '⊄';
							a_ = true;
							goto IL_2981;
						}
						if (num5 == 19694937)
						{
							if (this.a[num] == 'O')
							{
								this.a[this.b] = 'Ω';
							}
							else
							{
								this.a[this.b] = 'ω';
							}
							goto IL_2981;
						}
					}
					else
					{
						if (num5 == 22328196)
						{
							this.a[this.b] = 'ς';
							goto IL_2981;
						}
						if (num5 == 22328288)
						{
							if (this.a[num] == 'S')
							{
								this.a[this.b] = 'Σ';
							}
							else
							{
								this.a[this.b] = 'σ';
							}
							goto IL_2981;
						}
						if (num5 == 22368331)
						{
							if (this.a[num] == 'G')
							{
								this.a[this.b] = 'Γ';
							}
							else
							{
								this.a[this.b] = 'γ';
							}
							goto IL_2981;
						}
					}
				}
				else if (num5 <= 428720232)
				{
					if (num5 <= 148117402)
					{
						if (num5 <= 91812168)
						{
							if (num5 <= 27496549)
							{
								if (num5 <= 23740058)
								{
									if (num5 == 23628762)
									{
										if (this.a[num] == 'Z')
										{
											this.a[this.b] = 'Θ';
										}
										else
										{
											this.a[this.b] = 'θ';
										}
										goto IL_2981;
									}
									if (num5 == 23740058)
									{
										this.a[this.b] = 'Ϗ';
										goto IL_2981;
									}
								}
								else
								{
									if (num5 == 23757365)
									{
										if (this.a[num] == 'D')
										{
											this.a[this.b] = 'Δ';
										}
										else
										{
											this.a[this.b] = 'δ';
										}
										goto IL_2981;
									}
									if (num5 == 25563218)
									{
										if (this.a[num] == 'K')
										{
											this.a[this.b] = 'Κ';
										}
										else
										{
											this.a[this.b] = 'κ';
										}
										goto IL_2981;
									}
									if (num5 == 27496549)
									{
										this.a[this.b] = '∇';
										a_ = true;
										goto IL_2981;
									}
								}
							}
							else if (num5 <= 31815557)
							{
								if (num5 == 29235713)
								{
									if (this.a[num] == 'A')
									{
										this.a[this.b] = 'Α';
									}
									else
									{
										this.a[this.b] = 'α';
									}
									goto IL_2981;
								}
								if (num5 == 31815557)
								{
									this.a[this.b] = '¦';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 88035422)
								{
									this.a[this.b] = '√';
									goto IL_2981;
								}
								if (num5 == 91812161)
								{
									if (this.a[num] == 'A')
									{
										this.a[this.b] = 'Â';
									}
									else
									{
										this.a[this.b] = 'â';
									}
									goto IL_2981;
								}
								if (num5 == 91812168)
								{
									if (this.a[num] == 'E')
									{
										this.a[this.b] = 'Ê';
									}
									else
									{
										this.a[this.b] = 'ê';
									}
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 139785945)
						{
							if (num5 <= 91812185)
							{
								if (num5 == 91812175)
								{
									if (this.a[num] == 'I')
									{
										this.a[this.b] = 'Î';
									}
									else
									{
										this.a[this.b] = 'î';
									}
									goto IL_2981;
								}
								if (num5 == 91812185)
								{
									if (this.a[num] == 'O')
									{
										this.a[this.b] = 'Ô';
									}
									else
									{
										this.a[this.b] = 'ô';
									}
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 91812195)
								{
									if (this.a[num] == 'U')
									{
										this.a[this.b] = 'Û';
									}
									else
									{
										this.a[this.b] = 'û';
									}
									goto IL_2981;
								}
								if (num5 == 137106767)
								{
									this.a[this.b] = 'ℑ';
									a_ = true;
									goto IL_2981;
								}
								if (num5 == 139785945)
								{
									this.a[this.b] = '⊗';
									a_ = true;
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 142117810)
						{
							if (num5 == 139786145)
							{
								if (this.a[num] == 'P')
								{
									this.a[this.b] = '″';
								}
								else
								{
									this.a[this.b] = '′';
								}
								goto IL_2981;
							}
							if (num5 == 141177153)
							{
								this.a[this.b] = '´';
								goto IL_2981;
							}
							if (num5 == 142117810)
							{
								this.a[this.b] = '∴';
								a_ = true;
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 142207119)
							{
								this.a[this.b] = '¤';
								goto IL_2981;
							}
							if (num5 == 143981081)
							{
								this.a[this.b] = '‾';
								goto IL_2981;
							}
							if (num5 == 148117402)
							{
								this.a[this.b] = '™';
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 360856171)
					{
						if (num5 <= 194312065)
						{
							if (num5 <= 169088986)
							{
								if (num5 == 148117536)
								{
									this.a[this.b] = '♠';
									goto IL_2981;
								}
								if (num5 == 169088986)
								{
									this.a[this.b] = '¾';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 188645889)
								{
									if (this.a[num] == 'A')
									{
										this.a[this.b] = 'Æ';
									}
									else
									{
										this.a[this.b] = 'æ';
									}
									goto IL_2981;
								}
								if (num5 == 188646432)
								{
									this.a[this.b] = 'ß';
									goto IL_2981;
								}
								if (num5 == 194312065)
								{
									if (this.a[num] == 'A')
									{
										this.a[this.b] = 'Å';
									}
									else
									{
										this.a[this.b] = 'å';
									}
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 219420634)
						{
							if (num5 == 219420626)
							{
								this.a[this.b] = '½';
								goto IL_2981;
							}
							if (num5 == 219420634)
							{
								this.a[this.b] = '¼';
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 262308461)
							{
								this.a[this.b] = '…';
								goto IL_2981;
							}
							if (num5 == 265584917)
							{
								if (this.a[num] == 'C')
								{
									this.a[this.b] = 'Ç';
								}
								else
								{
									this.a[this.b] = 'ç';
								}
								goto IL_2981;
							}
							if (num5 == 360856171)
							{
								this.a[this.b] = '±';
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 386261747)
					{
						if (num5 <= 386261713)
						{
							if (num5 == 386261705)
							{
								if (this.a[num] == 'O')
								{
									this.a[this.b] = 'Ò';
								}
								else
								{
									this.a[this.b] = 'ò';
								}
								goto IL_2981;
							}
							if (num5 == 386261713)
							{
								if (this.a[num] == 'A')
								{
									this.a[this.b] = 'À';
								}
								else
								{
									this.a[this.b] = 'à';
								}
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 386261720)
							{
								if (this.a[num] == 'E')
								{
									this.a[this.b] = 'È';
								}
								else
								{
									this.a[this.b] = 'è';
								}
								goto IL_2981;
							}
							if (num5 == 386261727)
							{
								if (this.a[num] == 'I')
								{
									this.a[this.b] = 'Ì';
								}
								else
								{
									this.a[this.b] = 'ì';
								}
								goto IL_2981;
							}
							if (num5 == 386261747)
							{
								if (this.a[num] == 'U')
								{
									this.a[this.b] = 'Ù';
								}
								else
								{
									this.a[this.b] = 'ù';
								}
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 426151074)
					{
						if (num5 == 389953288)
						{
							this.a[this.b] = '≡';
							goto IL_2981;
						}
						if (num5 == 426151060)
						{
							this.a[this.b] = '⌊';
							a_ = true;
							goto IL_2981;
						}
						if (num5 == 426151074)
						{
							this.a[this.b] = '⌋';
							a_ = true;
							goto IL_2981;
						}
					}
					else
					{
						if (num5 == 427316181)
						{
							this.a[this.b] = 'µ';
							goto IL_2981;
						}
						if (num5 == 428720222)
						{
							this.a[this.b] = '»';
							goto IL_2981;
						}
						if (num5 == 428720232)
						{
							this.a[this.b] = '«';
							goto IL_2981;
						}
					}
				}
				else if (num5 <= 546198485)
				{
					if (num5 <= 445403231)
					{
						if (num5 <= 444076655)
						{
							if (num5 <= 428723550)
							{
								if (num5 == 428722206)
								{
									this.a[this.b] = '\'';
									goto IL_2981;
								}
								if (num5 == 428723550)
								{
									this.a[this.b] = '”';
									goto IL_2981;
								}
							}
							else
							{
								if (num5 == 428723560)
								{
									this.a[this.b] = '“';
									goto IL_2981;
								}
								if (num5 == 433542113)
								{
									this.a[this.b] = '·';
									goto IL_2981;
								}
								if (num5 == 444076655)
								{
									this.a[this.b] = '♥';
									goto IL_2981;
								}
							}
						}
						else if (num5 <= 445403209)
						{
							if (num5 == 444658952)
							{
								this.a[this.b] = '∃';
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 445403209)
							{
								if (this.a[num] == 'O')
								{
									this.a[this.b] = 'Ó';
								}
								else
								{
									this.a[this.b] = 'ó';
								}
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 445403217)
							{
								if (this.a[num] == 'A')
								{
									this.a[this.b] = 'Á';
								}
								else
								{
									this.a[this.b] = 'á';
								}
								goto IL_2981;
							}
							if (num5 == 445403224)
							{
								if (this.a[num] == 'E')
								{
									this.a[this.b] = 'É';
								}
								else
								{
									this.a[this.b] = 'é';
								}
								goto IL_2981;
							}
							if (num5 == 445403231)
							{
								if (this.a[num] == 'I')
								{
									this.a[this.b] = 'Í';
								}
								else
								{
									this.a[this.b] = 'í';
								}
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 511186821)
					{
						if (num5 <= 445403258)
						{
							if (num5 == 445403251)
							{
								if (this.a[num] == 'U')
								{
									this.a[this.b] = 'Ú';
								}
								else
								{
									this.a[this.b] = 'ú';
								}
								goto IL_2981;
							}
							if (num5 == 445403258)
							{
								if (this.a[num] == 'Y')
								{
									this.a[this.b] = 'Ý';
								}
								else
								{
									this.a[this.b] = 'ý';
								}
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 504686571)
							{
								if (this.a[num] == 'Z')
								{
									this.a[this.b] = 'Ο';
								}
								else
								{
									this.a[this.b] = 'ο';
								}
								goto IL_2981;
							}
							if (num5 == 505475684)
							{
								this.a[this.b] = '℘';
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 511186821)
							{
								this.a[this.b] = '↵';
								a_ = true;
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 539055066)
					{
						if (num5 == 537290332)
						{
							this.a[this.b] = '∗';
							a_ = true;
							goto IL_2981;
						}
						if (num5 == 537299015)
						{
							if (this.a[num] == 'O')
							{
								this.a[this.b] = 'Ø';
							}
							else
							{
								this.a[this.b] = 'ø';
							}
							goto IL_2981;
						}
						if (num5 == 539055066)
						{
							this.a[this.b] = '×';
							goto IL_2981;
						}
					}
					else
					{
						if (num5 == 539113275)
						{
							this.a[this.b] = '¿';
							goto IL_2981;
						}
						if (num5 == 542381045)
						{
							this.a[this.b] = '♦';
							goto IL_2981;
						}
						if (num5 == 546198485)
						{
							this.a[this.b] = '−';
							goto IL_2981;
						}
					}
				}
				else if (num5 <= 675053928)
				{
					if (num5 <= 624797285)
					{
						if (num5 <= 550013525)
						{
							if (num5 == 546211929)
							{
								this.a[this.b] = '⊕';
								a_ = true;
								goto IL_2981;
							}
							if (num5 == 550013525)
							{
								this.a[this.b] = 'ℵ';
								a_ = true;
								goto IL_2981;
							}
						}
						else
						{
							if (num5 == 551959045)
							{
								this.a[this.b] = '♣';
								goto IL_2981;
							}
							if (num5 == 559327233)
							{
								this.a[this.b] = '≈';
								goto IL_2981;
							}
							if (num5 == 624797285)
							{
								this.a[this.b] = '∉';
								a_ = true;
								goto IL_2981;
							}
						}
					}
					else if (num5 <= 671475234)
					{
						if (num5 == 624896335)
						{
							this.a[this.b] = '∞';
							goto IL_2981;
						}
						if (num5 == 628726746)
						{
							if (this.a[num] == 'T')
							{
								this.a[this.b] = 'Þ';
							}
							else
							{
								this.a[this.b] = 'þ';
							}
							goto IL_2981;
						}
						if (num5 == 671475234)
						{
							this.a[this.b] = '∀';
							a_ = true;
							goto IL_2981;
						}
					}
					else
					{
						if (num5 == 672481807)
						{
							this.a[this.b] = '¡';
							goto IL_2981;
						}
						if (num5 == 675053918)
						{
							this.a[this.b] = '⌉';
							a_ = true;
							goto IL_2981;
						}
						if (num5 == 675053928)
						{
							this.a[this.b] = '⌈';
							a_ = true;
							goto IL_2981;
						}
					}
				}
				else if (num5 <= 711595336)
				{
					if (num5 <= 675158778)
					{
						if (num5 == 675158737)
						{
							if (this.a[num] == 'U')
							{
								this.a[this.b] = 'Υ';
							}
							else
							{
								this.a[this.b] = 'υ';
							}
							goto IL_2981;
						}
						if (num5 == 675158778)
						{
							if (this.a[num] == 'D')
							{
								this.a[this.b] = 'Ε';
							}
							else
							{
								this.a[this.b] = 'ε';
							}
							goto IL_2981;
						}
					}
					else
					{
						if (num5 == 675238405)
						{
							this.a[this.b] = '¸';
							goto IL_2981;
						}
						if (num5 == 679483314)
						{
							this.a[this.b] = '⁄';
							goto IL_2981;
						}
						if (num5 == 711595336)
						{
							this.a[this.b] = '∅';
							a_ = true;
							goto IL_2981;
						}
					}
				}
				else if (num5 <= 899741321)
				{
					if (num5 == 792594531)
					{
						this.a[this.b] = 'ϒ';
						goto IL_2981;
					}
					if (num5 == 899036769)
					{
						this.a[this.b] = '£';
						goto IL_2981;
					}
					if (num5 == 899741321)
					{
						if (this.a[num] == 'O')
						{
							this.a[this.b] = 'Õ';
						}
						else
						{
							this.a[this.b] = 'õ';
						}
						goto IL_2981;
					}
				}
				else
				{
					if (num5 == 899741329)
					{
						if (this.a[num] == 'A')
						{
							this.a[this.b] = 'Ã';
						}
						else
						{
							this.a[this.b] = 'ã';
						}
						goto IL_2981;
					}
					if (num5 == 899741365)
					{
						if (this.a[num] == 'N')
						{
							this.a[this.b] = 'Ñ';
						}
						else
						{
							this.a[this.b] = 'ñ';
						}
						goto IL_2981;
					}
					if (num5 == 904220778)
					{
						if (this.a[num] == 'Z')
						{
							this.a[this.b] = 'Λ';
						}
						else
						{
							this.a[this.b] = 'λ';
						}
						goto IL_2981;
					}
				}
				if (ki.b.ContainsKey(num6))
				{
					this.b++;
					num2++;
					A_1 = false;
				}
				else
				{
					flag = false;
				}
				IL_2981:;
			}
			if (!flag)
			{
				this.b -= num2 + 1;
			}
			else
			{
				int num7 = this.b - (num2 + 1);
				char[] array = new char[this.p - num2 - 1];
				Array.Copy(this.a, 0, array, 0, num7);
				Array.Copy(this.a, this.b, array, num7, this.p - this.b);
				Array.Copy(array, 0, this.a, 0, array.Length);
				this.p = array.Length;
				this.b = num7;
				if (A_1)
				{
					num = this.b;
					int num8 = 1;
					if (this.b > 1 && this.a[this.b - 1] == ' ')
					{
						if (this.t)
						{
							num8++;
							num = this.b - 1;
						}
					}
					A_0.a(a_);
					A_0.b(true);
					qd qd = new qd(this.a, num, num8, A_0.m());
					qd.d(a_);
					A_0.cg().a(qd);
					this.t = true;
					this.b++;
				}
			}
			return flag;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x000A102C File Offset: 0x000A002C
		private bool a(ref bool A_0)
		{
			bool result = false;
			if (this.b + 3 < this.p && this.a[this.b] == '<' && this.a[this.b + 1] == '!' && this.a[this.b + 2] == '-' && this.a[this.b + 3] == '-')
			{
				result = true;
				A_0 = true;
				this.b += 4;
			}
			else if (this.b + 2 < this.p && this.a[this.b] == '<' && this.a[this.b + 1] == '!' && this.a[this.b + 2] == '-')
			{
				result = true;
				this.b += 3;
			}
			return result;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x000A112C File Offset: 0x000A012C
		private void j()
		{
			while (this.b < this.p && (this.a[this.b] != '>' & !this.e))
			{
				this.b++;
			}
			if (this.b < this.p && this.a[this.b] == '>')
			{
				this.b++;
			}
			if (this.d && this.e)
			{
				this.d = false;
				this.e = false;
			}
			else if (this.d)
			{
				this.d = false;
			}
			else if (this.e)
			{
				this.e = false;
			}
			else if (this.f)
			{
				this.f = false;
			}
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x000A1228 File Offset: 0x000A0228
		private bool i()
		{
			return this.b + 2 < this.p && this.a[this.b] == '<' && this.a[this.b + 1] == '!' && this.a[this.b + 2] != '-';
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x000A128C File Offset: 0x000A028C
		private void h()
		{
			this.c = 0;
			this.d = false;
			this.e = false;
			this.f = false;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x000A12AC File Offset: 0x000A02AC
		private void a(bool A_0)
		{
			bool flag = true;
			while (flag)
			{
				while (this.b < this.p && this.a[this.b] != '-')
				{
					this.b++;
				}
				if (this.b + 2 < this.p && this.a[this.b + 1] == '-' && this.a[this.b + 2] == '>')
				{
					this.b += 3;
					flag = false;
				}
				else if (!A_0 && this.b + 2 < this.p && this.a[this.b + 1] == '!' && this.a[this.b + 2] == '>')
				{
					this.b += 3;
					flag = false;
				}
				else if (!A_0 && this.b + 1 < this.p && this.a[this.b + 1] == '>')
				{
					this.b += 2;
					flag = false;
				}
				else if (this.b < this.p)
				{
					this.b++;
				}
				else
				{
					flag = false;
				}
			}
			this.ak();
			this.m();
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000A143C File Offset: 0x000A043C
		private void g()
		{
			while (this.b < this.p && this.a[this.b] != '>')
			{
				this.b++;
			}
			this.b++;
			this.ak();
			this.m();
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000A14A0 File Offset: 0x000A04A0
		private int f()
		{
			int num = 0;
			while (this.b < this.p && this.a[this.b] > ' ' && this.a[this.b] != '>' && this.a[this.b] != '/')
			{
				this.b++;
				num++;
			}
			this.b -= num;
			return num;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000A1528 File Offset: 0x000A0528
		private int e()
		{
			int a_ = this.b;
			int num = 0;
			this.q = 0;
			int result;
			if (this.a[this.b] != '?')
			{
				while (this.b < this.p && this.a[this.b] > ' ' && this.a[this.b] != '>' && this.a[this.b] != '/')
				{
					this.b++;
					num++;
				}
				this.c = this.a(a_, num);
				result = (this.q = num);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x000A15E4 File Offset: 0x000A05E4
		private int a(int A_0, int A_1)
		{
			this.r = A_0;
			this.s = A_1;
			for (int i = 0; i < A_1; i++)
			{
				this.g.b(this.a[A_0 + i]);
			}
			int result = this.g.b();
			this.g.a();
			return result;
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x000A1648 File Offset: 0x000A0648
		private string d()
		{
			int num = 0;
			this.ak();
			int startIndex = this.b;
			while (this.b < this.p && this.a[this.b] != ';' && this.a[this.b] != '<')
			{
				this.b++;
				num++;
			}
			if (this.a[this.b] == ';')
			{
				this.b++;
			}
			string result;
			if (num > 0)
			{
				result = new string(this.a, startIndex, num);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x000A1700 File Offset: 0x000A0700
		private void c()
		{
			int num = this.b;
			while (num < this.p && this.a[num] != '}')
			{
				num++;
			}
			num++;
			this.b = num;
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x000A1748 File Offset: 0x000A0748
		private void b()
		{
			int num = 0;
			char c = this.a[this.b];
			if (c == ' ')
			{
				while (this.b < this.p && this.a[this.b] == ' ')
				{
					this.b++;
					num++;
				}
				if (num > 1)
				{
					num--;
					int num2 = this.b - num;
					char[] array = new char[this.p - num];
					Array.Copy(this.a, 0, array, 0, num2);
					Array.Copy(this.a, this.b, array, num2, this.p - this.b);
					Array.Copy(array, 0, this.a, 0, array.Length);
					this.p = array.Length;
					this.b = num2;
				}
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x000A1830 File Offset: 0x000A0830
		private void a()
		{
			int num = 0;
			while (this.b < this.p && this.a[this.b] < ' ')
			{
				this.b++;
				num++;
			}
			int num2 = this.b - num;
			if (num > 0)
			{
				num--;
				char[] array = new char[this.p - num];
				Array.Copy(this.a, 0, array, 0, num2);
				array[num2] = ' ';
				num2++;
				Array.Copy(this.a, this.b, array, num2, this.p - this.b);
				Array.Copy(array, 0, this.a, 0, array.Length);
				this.p = array.Length;
				this.b = num2 - 1;
			}
			if (this.b - 1 > 0 && this.a[this.b - 1] == ' ')
			{
				this.b--;
				this.b();
			}
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x000A1948 File Offset: 0x000A0948
		private void a(int A_0, int A_1, d3 A_2)
		{
			if (A_1 > 0 && A_2.k() != null)
			{
				A_2.a(new qd(this.a, A_0, A_1, A_2.k().b()));
			}
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x000A198C File Offset: 0x000A098C
		private void a(int A_0, int A_1, d3 A_2, bool A_3)
		{
			if (A_1 > 0 && A_2.k() != null)
			{
				pa pa = new pa(this.a, A_0, A_1, A_2.k().b());
				pa.d6(A_3);
				A_2.a(pa);
			}
			else if (this.j > 0 && this.k)
			{
				pa pa = new pa(this.a, 0, 0, null);
				pa.d6(A_3);
				A_2.a(pa);
				this.k = false;
			}
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x000A1A24 File Offset: 0x000A0A24
		internal void ai()
		{
			if (!this.e)
			{
				if (this.b < this.p && this.a[this.b] > ' ')
				{
					this.r();
				}
				else if (this.h)
				{
					if (this.b + 2 < this.p && this.a[this.b] == '\r' && this.a[this.b + 1] == '\n')
					{
						this.b += 2;
						this.k = true;
						this.f = true;
					}
					else if (this.a[this.b] == '\n')
					{
						this.b++;
						this.f = true;
						this.k = true;
					}
					else if (this.a[this.b] == '\t' || this.a[this.b] == ' ')
					{
						this.f = true;
						this.k = false;
					}
					else if (this.a[this.b] == '\r')
					{
						this.b++;
					}
				}
				else
				{
					this.ak();
				}
			}
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x000A1B9C File Offset: 0x000A0B9C
		internal bool aj()
		{
			while (this.b < this.p && (this.a[this.b] < '!' || this.a[this.b] == '\'' || this.a[this.b] == '"' || this.a[this.b] == ';'))
			{
				this.b++;
			}
			bool result;
			if (this.b >= this.p)
			{
				result = true;
			}
			else if (this.a[this.b] == '/')
			{
				this.b++;
				this.ak();
				if (this.a[this.b] == '>')
				{
					this.e = true;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = (this.a[this.b] == '>');
			}
			return result;
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x000A1CAC File Offset: 0x000A0CAC
		internal void ak()
		{
			while (this.b < this.p && this.a[this.b] <= ' ')
			{
				this.b++;
			}
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x000A1CF8 File Offset: 0x000A0CF8
		internal int al()
		{
			int num = 0;
			while (this.b < this.p && this.a[this.b] < '!')
			{
				this.b++;
			}
			int a_ = this.b;
			while (this.b < this.p && this.a[this.b] > ' ' && (this.a[this.b] != '=' & this.a[this.b] != '>'))
			{
				this.b++;
				num++;
			}
			return this.a(a_, num);
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x000A1DBC File Offset: 0x000A0DBC
		internal string[] am()
		{
			while (this.b < this.p && this.a[this.b] != '=')
			{
				this.b++;
			}
			string[] result;
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				this.ak();
				char[] array = new char[255];
				int num = 0;
				if (this.a[this.b] == '"')
				{
					this.b++;
					while (this.b < this.p && this.a[this.b] != '"')
					{
						if (num == array.Length)
						{
							char[] array2 = new char[array.Length * 2];
							Array.Copy(array, 0, array2, 0, array.Length);
							array = array2;
						}
						if (this.k())
						{
							this.a(null, false);
							array[num] = this.a[this.b];
						}
						else if (this.a[this.b] == '\n')
						{
							this.b++;
						}
						else if (this.a[this.b] == '\r' || this.a[this.b] == '\t' || this.a[this.b] == '\u0011')
						{
							array[num] = ' ';
						}
						else
						{
							array[num] = this.a[this.b];
						}
						num++;
						this.b++;
					}
					result = new string(array, 0, num).Trim().Split(new char[]
					{
						' '
					});
				}
				else if (this.a[this.b] == '\'')
				{
					this.b++;
					while (this.b < this.p && this.a[this.b] != '\'')
					{
						if (this.k())
						{
							this.a(null, false);
							array[num] = this.a[this.b];
						}
						else if (this.a[this.b] == '\n')
						{
							this.b++;
						}
						else if (this.a[this.b] == '\r' || this.a[this.b] == '\t' || this.a[this.b] == '\u0011')
						{
							array[num] = ' ';
						}
						else
						{
							array[num] = this.a[this.b];
						}
						num++;
						this.b++;
					}
					result = new string(array, 0, num).Trim().Split(new char[]
					{
						' '
					});
				}
				else
				{
					while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '/' && this.a[this.b] != '>')
					{
						if (this.k())
						{
							this.a(null, false);
							array[num] = this.a[this.b];
						}
						else if (this.a[this.b] == '\n')
						{
							this.b++;
						}
						else if (this.a[this.b] == '\r' || this.a[this.b] == '\t' || this.a[this.b] == '\u0011')
						{
							array[num] = ' ';
						}
						else
						{
							array[num] = this.a[this.b];
						}
						num++;
						this.b++;
					}
					result = new string(array, 0, num).Trim().Split(new char[]
					{
						' '
					});
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x000A2264 File Offset: 0x000A1264
		internal string an()
		{
			while (this.b < this.p && this.a[this.b] != '=')
			{
				this.b++;
			}
			string result;
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				this.ak();
				int num = 0;
				if (this.a[this.b] == '"')
				{
					this.b++;
					if (!this.a(this.a[this.b]))
					{
						while (this.b < this.p && this.a[this.b] != '"')
						{
							this.b++;
						}
						result = null;
					}
					else
					{
						int startIndex = this.b;
						bool flag = true;
						while (this.b < this.p && this.a[this.b] != '"')
						{
							if (!this.q())
							{
								flag = false;
							}
							this.b++;
							num++;
						}
						if (flag)
						{
							result = new string(this.a, startIndex, num);
						}
						else
						{
							result = null;
						}
					}
				}
				else if (this.a[this.b] == '\'')
				{
					this.b++;
					if (!this.a(this.a[this.b]))
					{
						while (this.b < this.p && this.a[this.b] != '\'')
						{
							this.b++;
						}
						result = null;
					}
					else
					{
						int startIndex = this.b;
						bool flag = true;
						while (this.b < this.p && this.a[this.b] != '\'')
						{
							if (!this.q())
							{
								flag = false;
							}
							this.b++;
							num++;
						}
						if (flag)
						{
							result = new string(this.a, startIndex, num);
						}
						else
						{
							result = null;
						}
					}
				}
				else if (!this.a(this.a[this.b]))
				{
					while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '/' && this.a[this.b] != '>')
					{
						this.b++;
					}
					result = null;
				}
				else
				{
					int startIndex = this.b;
					bool flag = true;
					while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '/' && this.a[this.b] != '>')
					{
						if (!this.q())
						{
							flag = false;
						}
						this.b++;
						num++;
					}
					if (flag)
					{
						result = new string(this.a, startIndex, num);
					}
					else
					{
						result = null;
					}
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x000A2624 File Offset: 0x000A1624
		internal string ao()
		{
			while (this.b < this.p && (this.a[this.b] != '=' & this.a[this.b] != '>'))
			{
				this.b++;
			}
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				this.ak();
				int num = 0;
				if (this.a[this.b] == '"')
				{
					this.b++;
					int startIndex = this.b;
					while (this.b < this.p && this.a[this.b] != '"')
					{
						this.b++;
						num++;
					}
					if (num > 0)
					{
						return new string(this.a, startIndex, num);
					}
				}
				else
				{
					int startIndex;
					if (this.a[this.b] == '\'')
					{
						this.b++;
						startIndex = this.b;
						while (this.b < this.p && this.a[this.b] != '\'')
						{
							this.b++;
							num++;
						}
						return new string(this.a, startIndex, num);
					}
					startIndex = this.b;
					bool flag = false;
					while (this.b < this.p)
					{
						char c = this.a[this.b];
						if (c <= '\r')
						{
							if (c != '\n' && c != '\r')
							{
								goto IL_200;
							}
							goto IL_1FC;
						}
						else
						{
							if (c != ' ' && c != '/' && c != '>')
							{
								goto IL_200;
							}
							goto IL_1FC;
						}
						IL_214:
						if (flag)
						{
							break;
						}
						continue;
						IL_1FC:
						flag = true;
						goto IL_214;
						IL_200:
						this.b++;
						num++;
						goto IL_214;
					}
					return new string(this.a, startIndex, num);
				}
			}
			return null;
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x000A287C File Offset: 0x000A187C
		internal string ap()
		{
			while (this.b < this.p && (this.a[this.b] != '=' & this.a[this.b] != '>'))
			{
				this.b++;
			}
			this.b++;
			this.ak();
			int num = 0;
			if (this.a[this.b] == '"')
			{
				this.b++;
			}
			int startIndex = this.b;
			bool flag = false;
			while (this.b < this.p && !flag)
			{
				char c = this.a[this.b];
				if (c <= '\r')
				{
					if (c != '\n' && c != '\r')
					{
						goto IL_E2;
					}
					goto IL_DE;
				}
				else
				{
					switch (c)
					{
					case ' ':
					case '"':
						goto IL_DE;
					case '!':
						goto IL_E2;
					default:
						if (c != '>')
						{
							goto IL_E2;
						}
						goto IL_DE;
					}
				}
				continue;
				IL_DE:
				flag = true;
				continue;
				IL_E2:
				this.b++;
				num++;
			}
			string result;
			if (num > 0)
			{
				result = new string(this.a, startIndex, num);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x000A29C0 File Offset: 0x000A19C0
		internal string aq()
		{
			while (this.b < this.p && this.a[this.b] != '=')
			{
				this.b++;
			}
			string result;
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				this.ak();
				int num = 0;
				if (this.a[this.b] == '"')
				{
					this.b++;
					int startIndex = this.b;
					while (this.b < this.p && this.a[this.b] != '"')
					{
						if (this.k())
						{
							this.a(null, false);
						}
						this.b++;
						num++;
					}
					result = new string(this.a, startIndex, num);
				}
				else if (this.a[this.b] == '\'')
				{
					this.b++;
					int startIndex = this.b;
					while (this.b < this.p && this.a[this.b] != '\'')
					{
						if (this.k())
						{
							this.a(null, false);
						}
						this.b++;
						num++;
					}
					result = new string(this.a, startIndex, num);
				}
				else
				{
					int startIndex = this.b;
					while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '>')
					{
						if (this.k())
						{
							this.a(null, false);
						}
						this.b++;
						num++;
					}
					result = new string(this.a, startIndex, num);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x000A2C10 File Offset: 0x000A1C10
		internal float ar()
		{
			return float.Parse(this.ao());
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000A2C30 File Offset: 0x000A1C30
		internal int @as()
		{
			string text = this.ao();
			int maxValue = int.MaxValue;
			int result;
			if (text != null && int.TryParse(text, out maxValue))
			{
				result = maxValue;
			}
			else
			{
				result = maxValue;
			}
			return result;
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x000A2C6C File Offset: 0x000A1C6C
		internal void at()
		{
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				if (this.a[this.b] == '"')
				{
					this.b++;
					while (this.b < this.p && this.a[this.b] != '"')
					{
						this.b++;
					}
				}
				else if (this.a[this.b] == '\'')
				{
					this.b++;
					while (this.b < this.p && this.a[this.b] != '\'')
					{
						this.b++;
					}
				}
				else
				{
					while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '/' && this.a[this.b] != '>')
					{
						this.b++;
					}
				}
			}
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x000A2DE4 File Offset: 0x000A1DE4
		internal string au()
		{
			while (this.b < this.p && this.a[this.b] != '=')
			{
				this.b++;
			}
			if (this.b + 2 < this.p && this.a[this.b] == '=')
			{
				this.b++;
				this.ak();
				int length = 0;
				if (this.a[this.b] == '"')
				{
					this.b++;
					int num = this.b;
					int i = num;
					int num2 = 0;
					int num3 = 0;
					while (i < this.p)
					{
						if (this.a[i] == '"')
						{
							num2 = i;
							i++;
							num3++;
						}
						else
						{
							i++;
							num3++;
						}
						if (i < this.p && (this.a[i] == '=' || this.a[i] == '>') && num2 != 0)
						{
							length = num2 - num;
							this.b = num2;
							break;
						}
					}
					return new string(this.a, num, length);
				}
			}
			return null;
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x000A2F4C File Offset: 0x000A1F4C
		internal ij a(char[] A_0, int A_1, int A_2)
		{
			ij result;
			if (A_2 > 0)
			{
				result = new ij(A_0, A_1, A_2);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x000A2F78 File Offset: 0x000A1F78
		internal string av()
		{
			this.ax();
			StringBuilder stringBuilder = new StringBuilder();
			while (this.b < this.p)
			{
				if (this.a[this.b] == '<' && this.a[this.b + 1] == '/')
				{
					int startIndex = this.b;
					int num = 0;
					this.b += 2;
					int num2 = this.f();
					this.e();
					if (this.c == 144810970)
					{
						break;
					}
					num += num2 + 2;
					stringBuilder.Append(this.a, startIndex, num);
				}
				else
				{
					if (this.k())
					{
						this.a(null, false);
					}
					if (this.a[this.b] == ' ')
					{
						this.ak();
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(' ');
						}
					}
					else
					{
						stringBuilder.Append(this.a[this.b]);
						this.b++;
					}
				}
			}
			this.ax();
			return stringBuilder.ToString();
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x000A30CC File Offset: 0x000A20CC
		internal gi a(ref List<string> A_0)
		{
			this.j();
			int num = this.b;
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			bool flag2 = false;
			while (this.b < this.p)
			{
				if (this.a[this.b] == '<' && this.a[this.b + 1] == '/')
				{
					this.b += 2;
					num3 = this.f();
					this.e();
					if (this.c == 144877216)
					{
						flag = true;
						break;
					}
					num2 += num3 + 2;
				}
				else if (this.a[this.b] == '<' && this.a[this.b + 1] == '!' && this.a[this.b + 2] == '-' && this.a[this.b + 3] == '-')
				{
					this.b += 4;
				}
				else if (this.a[this.b] == '-' && this.a[this.b + 1] == '-' && this.a[this.b + 2] == '>')
				{
					this.b += 3;
				}
				else if (this.a[this.b] == '/' && this.a[this.b + 1] == '/')
				{
					this.b += 2;
				}
				else
				{
					char c = this.a[this.b];
					if (c <= '.')
					{
						if (c != '#' && c != '.')
						{
							goto IL_4C6;
						}
						goto IL_1DF;
					}
					else
					{
						if (c == ':')
						{
							goto IL_1DF;
						}
						if (c != '@')
						{
							if (c != '[')
							{
								goto IL_4C6;
							}
							goto IL_1DF;
						}
						else
						{
							this.ak();
							int num4 = num;
							num = this.b;
							int num5 = 0;
							while (this.b < this.p && this.a[this.b] != ' ' && this.a[this.b] != '{')
							{
								num5++;
								this.b++;
							}
							this.ak();
							string text = new string(this.a, num, num5).Trim();
							string text2 = string.Empty;
							if (string.Compare(text, "@import", false) == 0)
							{
								text2 = this.aw();
								text2 = n9.b(text2.Trim(), this.l.c().AbsolutePath);
								string text3 = this.d();
								if (text3 == null)
								{
									text3 = "print";
								}
								else
								{
									string[] array = text3.Split(new char[]
									{
										','
									});
									for (int i = 0; i < array.Length; i++)
									{
										if (Regex.IsMatch(array[i], "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)", RegexOptions.IgnoreCase))
										{
											text3 = "print";
											break;
										}
									}
								}
								if ((text3.Equals("") || text3.Equals("print")) && !text2.Equals(""))
								{
									A_0.Add(text2);
								}
								else
								{
									num2 = 0;
									this.ak();
								}
							}
							else if (string.Compare(text, "@font-face", false) == 0)
							{
								this.c();
								flag2 = true;
								num = num4;
							}
							else if (text.Equals("@media") || text.Equals("@MEDIA"))
							{
								if (num2 == 0)
								{
									num = this.b;
								}
								int num6 = 0;
								bool flag3 = false;
								while (this.b < this.a.Length && !flag3)
								{
									switch (this.a[this.b])
									{
									case '{':
										num6++;
										num2++;
										this.b++;
										break;
									case '|':
										goto IL_484;
									case '}':
										num6--;
										if (num6 == 0)
										{
											flag3 = true;
										}
										num2++;
										this.b++;
										break;
									default:
										goto IL_484;
									}
									continue;
									IL_484:
									num2++;
									this.b++;
								}
								num = num4;
							}
							else
							{
								num = num4;
							}
						}
					}
					continue;
					IL_4C6:
					num2++;
					this.b++;
					continue;
					IL_1DF:
					if (num2 == 0)
					{
						num = this.b;
					}
					num2++;
					this.b++;
				}
			}
			gi result;
			if (flag)
			{
				if (num2 > 0)
				{
					if (!flag2)
					{
						result = new gi(this.a, num, this.b - (num3 + 2) - num);
					}
					else
					{
						result = new gi(this.a, num, num2);
					}
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x000A3628 File Offset: 0x000A2628
		internal string aw()
		{
			this.ak();
			bool flag = false;
			bool flag2 = false;
			while (this.b < this.p && !flag)
			{
				char c = this.a[this.b];
				if (c != '"')
				{
					if (c != '(')
					{
						this.b++;
					}
					else
					{
						this.b++;
						if (this.b < this.p && this.a[this.b] == '"')
						{
							flag2 = true;
						}
						flag = true;
					}
				}
				else
				{
					flag2 = true;
					flag = true;
				}
			}
			this.ak();
			int startIndex = this.b;
			int num = 0;
			flag = false;
			while (this.b < this.p && !flag)
			{
				char c = this.a[this.b];
				if (c != '"')
				{
					if (c != ')')
					{
						if (c != '<')
						{
							this.b++;
							num++;
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						this.b++;
						flag = true;
					}
				}
				else
				{
					this.b++;
					startIndex = this.b;
					if (flag2)
					{
						while (this.b < this.p && this.a[this.b] != '"')
						{
							this.b++;
							num++;
						}
						this.ak();
						if (this.b < this.p && this.a[this.b] == '"')
						{
							this.b++;
						}
						if (this.b < this.p && this.a[this.b] == ')')
						{
							this.b++;
						}
					}
					else if (this.b < this.p && this.a[this.b] == ')')
					{
						this.b++;
					}
					flag = true;
				}
			}
			if (this.b < this.p && this.a[this.b] == ';')
			{
				this.b++;
			}
			this.ak();
			return new string(this.a, startIndex, num);
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x000A38E0 File Offset: 0x000A28E0
		internal int e(int A_0)
		{
			while (A_0 + 1 < this.p && this.a[A_0] != '*' && this.a[A_0 + 1] != '/')
			{
				if (A_0 + 2 < this.p && this.a[A_0] == '-' && this.a[A_0 + 1] == '-' && this.a[A_0 + 2] == '>')
				{
					break;
				}
				A_0++;
			}
			A_0 += 2;
			return A_0;
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x000A397C File Offset: 0x000A297C
		internal void ax()
		{
			bool flag = false;
			if (!this.a(ref flag))
			{
				while (this.b < this.p && (this.a[this.b] != '>' & !this.e))
				{
					this.b++;
				}
				if (this.b < this.p && this.a[this.b] == '>')
				{
					this.b++;
				}
			}
			if (this.d && this.e)
			{
				this.d = false;
				this.e = false;
			}
			else if (this.d)
			{
				this.d = false;
			}
			else if (this.e)
			{
				this.e = false;
			}
			else if (this.f)
			{
				this.f = false;
			}
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000A3A88 File Offset: 0x000A2A88
		internal void ay()
		{
			if (this.b < this.p && this.a[this.b] != '<')
			{
				while (this.b < this.p && this.a[this.b] != '>')
				{
					this.b++;
				}
				this.b++;
			}
			if (this.d)
			{
				this.d = false;
			}
			else if (this.e)
			{
				this.e = false;
			}
			else if (this.f)
			{
				this.f = false;
			}
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x000A3B48 File Offset: 0x000A2B48
		internal void a(d3 A_0)
		{
			int a_ = this.b;
			int num = 0;
			pm pm = new pm();
			bool flag = false;
			bool flag2 = false;
			while (this.b < this.p && !this.l())
			{
				if (this.k())
				{
					flag2 = this.a(pm);
					if (flag2)
					{
						if (this.a[this.b] < ' ')
						{
							this.a();
						}
						break;
					}
				}
				if (this.a[this.b] == ' ')
				{
					this.b();
					num++;
				}
				else if (this.a[this.b] < ' ')
				{
					this.a();
				}
				else
				{
					this.b++;
					num++;
				}
			}
			if (this.c != 557703508)
			{
				if (num >= 1)
				{
					this.a(a_, num, A_0);
				}
				else if (!flag2)
				{
					if (this.b - 1 < this.p && this.a[this.b - 1] > ' ')
					{
						this.a(a_, num, A_0);
					}
				}
				if (pm.cg().h() > 0 && !flag)
				{
					A_0.i().Add(pm);
				}
				if (!flag2)
				{
					this.t = false;
				}
			}
			this.f = false;
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x000A3CF8 File Offset: 0x000A2CF8
		private bool a(pm A_0)
		{
			int num = this.b;
			return this.a(A_0, true);
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x000A3D1C File Offset: 0x000A2D1C
		internal void b(d3 A_0)
		{
			int a_ = this.b;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			pm pm = new pm();
			if (this.j > 0 && this.k)
			{
				em a_2 = new em(1977);
				A_0.a(new el(a_2));
				this.k = false;
			}
			else
			{
				this.k = false;
				if (this.b >= 0 && this.b - 1 < this.p)
				{
					char c = this.a[this.b - 1];
					if (c == ' ')
					{
						a_ = this.b - 1;
						num++;
					}
				}
				while (this.b + 1 < this.p && !this.l())
				{
					if (this.k())
					{
						flag2 = this.a(pm);
						if (flag2)
						{
							break;
						}
					}
					if (this.a[this.b] == '\r' && this.a[this.b + 1] == '\n')
					{
						this.b += 2;
						flag = true;
						break;
					}
					if (this.a[this.b] == '\n')
					{
						flag = true;
						this.b++;
						break;
					}
					this.b++;
					num++;
				}
				if (num >= 1)
				{
					this.j++;
					this.a(a_, num, A_0, flag);
				}
				else if (num == 1 && flag)
				{
					if (this.b - 3 < this.p && (this.a[this.b - 2] >= ' ' || this.a[this.b - 3] >= ' '))
					{
						this.a(a_, num, A_0, flag);
					}
				}
				else if (!flag2 && this.b - 1 < this.p)
				{
					if (this.a[this.b - 1] >= ' ')
					{
						this.a(a_, num, A_0, flag);
					}
					else if (this.a[this.b - 1] == '\n' && num == 0)
					{
						this.k = true;
						this.a(a_, num, A_0, flag);
					}
				}
				if (pm.cg().h() > 0)
				{
					A_0.i().Add(pm);
				}
			}
			this.f = false;
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x000A3FFC File Offset: 0x000A2FFC
		internal void c(d3 A_0)
		{
			int a_ = this.b;
			int num = 0;
			bool flag = false;
			pm a_2 = new pm();
			if (this.j > 0 && this.k)
			{
				this.a(a_, 0, A_0, true);
				this.k = false;
			}
			else
			{
				this.k = false;
				if (this.b >= 0 && this.b - 1 < this.p && this.a[this.b - 1] == ' ')
				{
					a_ = this.b - 1;
					num++;
				}
				bool flag2 = false;
				while (this.b + 1 < this.p)
				{
					int num2 = 0;
					if (this.l())
					{
						int num3 = this.b;
						this.n();
						if (this.e)
						{
							if (this.c != 23684646)
							{
								num2 = this.b - num3;
							}
							else
							{
								this.e = true;
								flag2 = true;
							}
						}
						else
						{
							num2 = this.b - num3;
						}
					}
					if (flag2)
					{
						break;
					}
					if (this.k())
					{
						this.a(a_2);
						if (this.b >= this.p || this.a[this.b] <= ' ')
						{
							break;
						}
					}
					if (this.a[this.b] == '\r' && this.a[this.b + 1] == '\n')
					{
						this.b += 2;
						flag = true;
						break;
					}
					if (this.a[this.b] == '\n')
					{
						break;
					}
					this.b++;
					num++;
					num += num2;
				}
				if (num > 1)
				{
					this.j++;
					this.a(a_, num, A_0, flag);
				}
				else if (num == 1 && flag)
				{
					if (this.b - 3 < this.p && this.a[this.b - 3] >= ' ')
					{
						this.a(a_, num, A_0, flag);
					}
				}
				else if (this.b - 1 < this.p)
				{
					if (this.a[this.b - 1] > ' ')
					{
						if (num == 0)
						{
							this.k = true;
						}
						this.a(a_, num, A_0, flag);
					}
					else if (this.a[this.b - 1] == '\n' && num == 0)
					{
						this.k = true;
						this.a(a_, num, A_0, flag);
					}
				}
			}
			this.f = false;
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x000A4320 File Offset: 0x000A3320
		internal void az()
		{
			int num = 0;
			while (this.b < this.p && !this.l())
			{
				if (this.k())
				{
					this.a(null, false);
					if (this.b >= this.p || this.a[this.b] <= ' ')
					{
						break;
					}
				}
				if (this.a[this.b] == ' ')
				{
					this.b();
					num++;
				}
				else if (this.a[this.b] < ' ')
				{
					this.a();
				}
				else
				{
					this.b++;
					num++;
				}
			}
			this.f = false;
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x000A4404 File Offset: 0x000A3404
		internal void f(int A_0)
		{
			this.b = A_0;
			if (this.d)
			{
				this.d = false;
			}
			else if (this.e)
			{
				this.e = false;
			}
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x000A4444 File Offset: 0x000A3444
		internal void a(d3 A_0, bool A_1)
		{
			int num = 0;
			if (A_1)
			{
				if (this.b < this.p && this.a[this.b] == '>')
				{
					this.b++;
				}
				while (this.b < this.p && this.a[this.b] != '<')
				{
					if (this.a[this.b] > ' ')
					{
						break;
					}
					num++;
					this.b++;
				}
			}
			if (num >= 1)
			{
				A_0.a(new pl());
			}
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x000A450C File Offset: 0x000A350C
		internal void g(int A_0)
		{
			bool flag = false;
			while (this.b < this.p && !flag)
			{
				char c = this.a[this.b];
				if (c != '<')
				{
					if (c != '?')
					{
						this.b++;
					}
					else
					{
						this.b++;
						if (A_0 == 0)
						{
							while (this.b < this.p && this.a[this.b] != '?')
							{
								this.b++;
							}
							if (this.b + 1 < this.p && this.a[this.b] == '?' && this.a[this.b + 1] == '>')
							{
								this.b++;
								flag = true;
							}
						}
					}
				}
				else if (this.o())
				{
					if (this.b + 1 < this.a.Length && this.a[this.b + 1] == '/')
					{
						this.n();
						if (this.e && A_0 == this.c)
						{
							flag = true;
						}
						else
						{
							this.b++;
						}
					}
					else
					{
						this.b++;
					}
				}
				else
				{
					this.b++;
				}
			}
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x000A46B8 File Offset: 0x000A36B8
		internal string a0()
		{
			return new string(this.a, this.r, this.s);
		}

		// Token: 0x04000703 RID: 1795
		private char[] a = null;

		// Token: 0x04000704 RID: 1796
		private int b = 0;

		// Token: 0x04000705 RID: 1797
		private int c = 0;

		// Token: 0x04000706 RID: 1798
		private bool d = false;

		// Token: 0x04000707 RID: 1799
		private bool e = false;

		// Token: 0x04000708 RID: 1800
		private bool f = false;

		// Token: 0x04000709 RID: 1801
		private kb g = new kb();

		// Token: 0x0400070A RID: 1802
		private bool h = false;

		// Token: 0x0400070B RID: 1803
		private int i = 1;

		// Token: 0x0400070C RID: 1804
		private int j = 0;

		// Token: 0x0400070D RID: 1805
		private bool k = false;

		// Token: 0x0400070E RID: 1806
		private HtmlArea l;

		// Token: 0x0400070F RID: 1807
		private bool m = true;

		// Token: 0x04000710 RID: 1808
		private bool n = false;

		// Token: 0x04000711 RID: 1809
		private bool o = false;

		// Token: 0x04000712 RID: 1810
		private int p = 0;

		// Token: 0x04000713 RID: 1811
		private int q = 0;

		// Token: 0x04000714 RID: 1812
		private int r = 0;

		// Token: 0x04000715 RID: 1813
		private int s = 0;

		// Token: 0x04000716 RID: 1814
		private bool t = false;
	}
}
