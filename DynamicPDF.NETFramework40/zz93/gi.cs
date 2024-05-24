using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace zz93
{
	// Token: 0x0200010A RID: 266
	internal class gi
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x00084F5C File Offset: 0x00083F5C
		internal gi()
		{
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00084FDC File Offset: 0x00083FDC
		internal gi(char[] A_0, int A_1, int A_2)
		{
			this.b = A_0;
			this.c = A_1;
			this.d = A_1 + A_2;
			this.e = A_1;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0008507C File Offset: 0x0008407C
		internal bool m()
		{
			return this.e < this.d;
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0008509C File Offset: 0x0008409C
		internal char[] n()
		{
			return this.b;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000850B4 File Offset: 0x000840B4
		internal h7[] o()
		{
			return this.h;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x000850CC File Offset: 0x000840CC
		internal void a(h7[] A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x000850D8 File Offset: 0x000840D8
		internal h7[] p()
		{
			return this.i;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x000850F0 File Offset: 0x000840F0
		internal void b(h7[] A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000850FC File Offset: 0x000840FC
		internal bool q()
		{
			return this.e < this.b.Length && this.b[this.e] == '}';
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00085134 File Offset: 0x00084134
		internal bool r()
		{
			return this.m;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0008514C File Offset: 0x0008414C
		internal bool s()
		{
			return this.n;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00085164 File Offset: 0x00084164
		internal bool t()
		{
			return this.o;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0008517C File Offset: 0x0008417C
		internal bool u()
		{
			return this.p;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00085194 File Offset: 0x00084194
		internal void a(ic A_0)
		{
			this.b = A_0.a();
			this.c = A_0.b();
			this.d = A_0.b() + A_0.c();
			this.e = this.c;
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x000851CE File Offset: 0x000841CE
		internal void a(char[] A_0, int A_1, int A_2)
		{
			this.b = A_0;
			this.c = A_1;
			this.d = A_1 + A_2;
			this.e = A_1;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x000851F0 File Offset: 0x000841F0
		internal h7[] a(out bool A_0)
		{
			uint num = 0U;
			string text = string.Empty;
			string text2 = string.Empty;
			A_0 = false;
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
			{
				this.c();
			}
			h7[] result;
			if (this.j())
			{
				this.i();
				result = null;
			}
			else
			{
				if (this.e + 3 < this.b.Length && this.b[this.e] == '<' && this.b[this.e + 1] == '!' && this.b[this.e + 2] == '-' && this.b[this.e + 3] == '-')
				{
					this.e += 4;
				}
				this.ag();
				if (this.e < this.b.Length)
				{
					char c = this.b[this.e];
					if (c != '<')
					{
						if (c != '}')
						{
							List<h7> list = new List<h7>();
							int num2 = 0;
							ie ie = ie.d;
							bool flag = true;
							while (this.e < this.b.Length && (this.b[this.e] != '{' & this.b[this.e] != '}'))
							{
								if (num2 != 0)
								{
									if (ie != ie.d)
									{
										if (flag)
										{
											list[list.Count - 1] = new h8(list[list.Count - 1].b(), list[list.Count - 1].c(), ie.d);
											flag = false;
											A_0 = true;
										}
										list.Add(new h8(num2, num, ie));
										ie = ie.d;
									}
									else
									{
										flag = true;
										list.Add(new h7(num2, num));
									}
								}
								c = this.b[this.e];
								if (c <= ' ')
								{
									switch (c)
									{
									case '\t':
									case '\n':
										break;
									default:
										if (c != ' ')
										{
											goto IL_652;
										}
										break;
									}
									ie = ie.c;
									this.e++;
								}
								else
								{
									switch (c)
									{
									case '+':
										ie = ie.a;
										this.e++;
										break;
									case ',':
										this.e++;
										break;
									default:
										switch (c)
										{
										case '>':
											ie = ie.b;
											this.e++;
											break;
										case '@':
											this.e++;
											text = this.ah();
											if (text.ToLower().Equals("media"))
											{
												this.ag();
												while (this.b[this.e] != '{')
												{
													text2 += this.b[this.e];
													this.e++;
												}
												string pattern = ",|and";
												string[] array = Regex.Split(text2, pattern);
												for (int i = 0; i < array.Length; i++)
												{
													if (Regex.IsMatch(array[i], "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)", RegexOptions.IgnoreCase))
													{
														this.ag();
														if (this.b[this.e] == '{')
														{
															this.e++;
															this.ag();
															return this.a(out A_0);
														}
													}
												}
												this.k();
												return null;
											}
											if (text.Equals("charset"))
											{
												if (this.e < this.b.Length && (this.b[this.e] == '"' || this.b[this.e] == '\''))
												{
													this.e++;
													while (this.e < this.b.Length)
													{
														if (this.b[this.e] == '"' || this.b[this.e] == '\'')
														{
															break;
														}
														this.e++;
													}
													if (this.e < this.b.Length && (this.b[this.e] == '"' || this.b[this.e] == '\''))
													{
														this.e++;
														if (this.e < this.b.Length && this.b[this.e] == ';')
														{
															this.e++;
														}
													}
													return null;
												}
											}
											else
											{
												if (text.Equals("import"))
												{
													this.ap();
													if (this.e < this.b.Length && this.b[this.e] == ';')
													{
														this.e++;
													}
													return null;
												}
												if (!text.Equals("page"))
												{
													this.ap();
													if (this.e < this.b.Length && this.b[this.e] == ';')
													{
														this.e++;
													}
													return null;
												}
												this.ap();
												if (this.e < this.b.Length && this.b[this.e] == ';')
												{
													this.e++;
												}
											}
											break;
										}
										break;
									}
								}
								IL_652:
								this.ag();
								num = 0U;
								num2 = this.a(ref num);
								if (num2 != 62)
								{
									num += 1U;
								}
								if (num2 == 0)
								{
									list.Clear();
									break;
								}
								this.af();
							}
							if (num2 != 0)
							{
								if (ie != ie.d)
								{
									if (flag)
									{
										list[list.Count - 1] = new h8(list[list.Count - 1].b(), list[list.Count - 1].c(), ie.d);
										A_0 = true;
									}
									list.Add(new h8(num2, num, ie));
								}
								else
								{
									list.Add(new h7(num2, num));
								}
							}
							if (this.a5())
							{
								result = list.ToArray();
							}
							else
							{
								this.ao();
								result = null;
							}
						}
						else
						{
							this.e++;
							result = null;
						}
					}
					else
					{
						this.e++;
						result = null;
					}
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x000859A0 File Offset: 0x000849A0
		private int a(ref uint A_0)
		{
			A_0 = 0U;
			int num = 0;
			this.c = this.e;
			while (this.e < this.b.Length && this.b[this.e] != '{')
			{
				char c = this.b[this.e];
				if (c <= '.')
				{
					if (c != '#')
					{
						switch (c)
						{
						case '+':
						case ',':
							goto IL_5F;
						case '.':
							if (!this.n)
							{
								this.n = true;
							}
							A_0 += 10U;
							break;
						}
					}
					else
					{
						if (!this.o)
						{
							this.o = true;
						}
						A_0 += 100U;
					}
				}
				else if (c != ':')
				{
					if (c == '>')
					{
						goto IL_5F;
					}
					if (c == '[')
					{
						if (!this.m)
						{
							this.m = true;
						}
						A_0 = 10U;
					}
				}
				else
				{
					if (!this.p)
					{
						this.p = true;
					}
					A_0 = 1U;
				}
				if (this.b[this.e] < '!')
				{
					break;
				}
				num++;
				this.e++;
				continue;
				IL_5F:
				return this.b(this.c, num);
			}
			if (num != 0)
			{
				return this.b(this.c, num);
			}
			return 0;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00085B04 File Offset: 0x00084B04
		private bool b(int A_0)
		{
			return (A_0 != 0 && this.b[this.e - 1] != ' ' && this.b[this.e + 1] != ' ') || (A_0 == 0 && this.b[this.e + 1] != ' ');
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00085B74 File Offset: 0x00084B74
		private int a(int A_0, int A_1)
		{
			while (this.e < this.b.Length && this.b[this.e] != '{')
			{
				if (this.b[this.e] < '!' || this.b[this.e] == ',' || this.b[this.e] == '+' || this.b[this.e] == '>')
				{
					return this.b(A_0, A_1);
				}
				A_1++;
				this.e++;
			}
			if (A_1 != 0)
			{
				return this.b(A_0, A_1);
			}
			return 0;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x00085C40 File Offset: 0x00084C40
		private int l()
		{
			int num = 0;
			this.c = this.e;
			while (this.e < this.b.Length && (this.b[this.e] != '{' & this.b[this.e] != ']'))
			{
				if (this.b[this.e] <= ' ' || this.b[this.e] == '"' || this.b[this.e] == '\'' || this.b[this.e] == '=' || this.b[this.e] == ']')
				{
					this.e++;
				}
				else
				{
					num++;
					this.e++;
				}
			}
			int result;
			if (num != 0)
			{
				result = this.b(this.c, num);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00085D48 File Offset: 0x00084D48
		private void k()
		{
			bool flag = false;
			int num = 0;
			while (this.e < this.b.Length && this.b[this.e] != '{')
			{
				this.e++;
			}
			while (this.e < this.b.Length && !flag)
			{
				if (this.b[this.e] == '{')
				{
					num++;
				}
				if (this.b[this.e] == '}')
				{
					num--;
				}
				this.e++;
				if (num == 0)
				{
					flag = true;
					this.ag();
				}
			}
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00085E14 File Offset: 0x00084E14
		private bool j()
		{
			bool result = false;
			if (this.e + 3 < this.b.Length && this.b[this.e] == '<' && this.b[this.e + 1] == '!' && this.b[this.e + 2] == '-' && this.b[this.e + 3] == '-')
			{
				result = true;
				this.e += 4;
			}
			else if (this.e + 2 < this.b.Length && this.b[this.e] == '-' && this.b[this.e + 1] == '-' && this.b[this.e + 2] == '>')
			{
				result = false;
				this.e += 3;
			}
			return result;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00085F10 File Offset: 0x00084F10
		private void i()
		{
			bool flag = true;
			while (flag)
			{
				while (this.e < this.b.Length && this.b[this.e] != '-')
				{
					this.e++;
				}
				if (this.e + 2 < this.b.Length && this.b[this.e + 1] == '-' && this.b[this.e + 2] == '>')
				{
					this.e += 3;
					flag = false;
				}
				else if (this.e < this.b.Length)
				{
					this.e++;
				}
				else
				{
					flag = false;
				}
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00085FF4 File Offset: 0x00084FF4
		private string h()
		{
			this.c = this.e;
			int num = 0;
			while (this.e < this.b.Length && (this.b[this.e] != '{' & this.b[this.e] != ','))
			{
				if (this.b[this.e] == ' ' || this.b[this.e] == '\r' || this.b[this.e] == '\n' || this.b[this.e] == '\t')
				{
					this.e++;
				}
				else
				{
					num++;
					this.e++;
				}
			}
			string result;
			if (this.e < this.b.Length && this.b[this.e] == ',')
			{
				result = this.b(this.c, num).ToString();
				this.e++;
				this.ag();
			}
			else
			{
				result = this.b(this.c, num).ToString();
			}
			return result;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00086148 File Offset: 0x00085148
		internal int v()
		{
			int num = 0;
			if (this.e < this.b.Length && this.b[this.e] == '{')
			{
				this.e++;
			}
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
			{
				this.c();
			}
			this.c = this.e;
			while (this.e < this.b.Length && (this.b[this.e] != ':' & this.b[this.e] != '='))
			{
				if (this.b[this.e] == ' ' || this.b[this.e] == '\t' || (this.b[this.e] == '-' && this.a(this.b(this.c, num)) && !this.f()))
				{
					int num2 = this.g();
					num += num2;
					this.e += num2;
					int result;
					if (this.e())
					{
						if (num == 0)
						{
							continue;
						}
						result = this.b(this.c, num);
					}
					else
					{
						result = 0;
					}
					return result;
				}
				num++;
				this.e++;
			}
			if (num != 0)
			{
				return this.b(this.c, num);
			}
			return 0;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00086310 File Offset: 0x00085310
		private int g()
		{
			int num = this.e;
			int startIndex = num;
			int num2 = 0;
			if (this.b[num] == '-')
			{
				num2++;
				num++;
				while (num < this.b.Length && this.b[num] != ':')
				{
					num2++;
					num++;
				}
				string strA = new string(this.b, startIndex, num2);
				if (string.Compare(strA, "-stretch", true) == 0 || string.Compare(strA, "-size-adjust", true) == 0)
				{
					return num2;
				}
			}
			return 0;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x000863BC File Offset: 0x000853BC
		private bool f()
		{
			int num = this.e;
			int num2 = 0;
			if (num < this.b.Length && this.b[num] == '-')
			{
				num++;
			}
			int a_ = num;
			while (num < this.b.Length && (this.b[num] != ':' & this.b[num] != '='))
			{
				if (this.b[num] <= ' ')
				{
					num++;
				}
				else
				{
					num2++;
					num++;
				}
			}
			bool result;
			if (num2 != 0)
			{
				int num3 = this.b(a_, num2);
				result = (num3 == 27497991 || num3 == 252976554);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00086490 File Offset: 0x00085490
		private bool a(int A_0)
		{
			if (A_0 <= 148235845)
			{
				if (A_0 != 6947816 && A_0 != 6968946 && A_0 != 148235845)
				{
					goto IL_43;
				}
			}
			else if (A_0 != 254664735 && A_0 != 265770411 && A_0 != 1617181893)
			{
				goto IL_43;
			}
			return true;
			IL_43:
			return false;
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x000864E8 File Offset: 0x000854E8
		private bool e()
		{
			while (this.e < this.b.Length)
			{
				bool result;
				if (this.b[this.e] == ':' || this.b[this.e] == '=' || this.b[this.e] == '-')
				{
					result = true;
				}
				else
				{
					if (this.b[this.e] != ';' && this.b[this.e] != '"' && this.b[this.e] != '\'' && this.b[this.e] != '{' && this.b[this.e] != '}')
					{
						this.e++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x000865D0 File Offset: 0x000855D0
		internal void w()
		{
			this.ag();
			if (this.e < this.b.Length && (this.b[this.e] == ',' || this.b[this.e] == '+' || this.b[this.e] == '>'))
			{
				this.e++;
			}
			this.ag();
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0008664C File Offset: 0x0008564C
		internal bool x()
		{
			return this.e < this.b.Length && this.b[this.e] == '-';
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00086690 File Offset: 0x00085690
		internal int y()
		{
			int num = 0;
			if (this.e < this.b.Length && this.b[this.e] == '-')
			{
				this.e++;
			}
			this.c = this.e;
			while (this.e < this.b.Length && (this.b[this.e] != ':' & this.b[this.e] != '='))
			{
				if (this.b[this.e] == ' ' || this.b[this.e] == '\t')
				{
					int result;
					if (this.e())
					{
						result = this.b(this.c, num);
					}
					else
					{
						result = 0;
					}
					return result;
				}
				num++;
				this.e++;
			}
			if (num != 0)
			{
				return this.b(this.c, num);
			}
			return 0;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x000867B0 File Offset: 0x000857B0
		internal int z()
		{
			int result;
			if (this.e < this.b.Length && this.b[this.e] == '{')
			{
				result = this.e;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x000867F8 File Offset: 0x000857F8
		internal int aa()
		{
			int num = 0;
			bool flag = false;
			if (this.e < this.b.Length && this.b[this.e] == '{')
			{
				this.e++;
			}
			while (this.e < this.b.Length && this.b[this.e] != '}' && this.b[this.e] != '<')
			{
				int result;
				if (this.b[this.e] == '{' && flag)
				{
					while (this.e < this.b.Length && this.b[this.e] != '}')
					{
						this.e++;
					}
					result = num;
				}
				else
				{
					if (this.b[this.e] != '{' || flag)
					{
						if (this.b[this.e] == ':')
						{
							flag = false;
						}
						else if (this.b[this.e] == ';')
						{
							num = this.e;
							flag = true;
						}
						this.e++;
						continue;
					}
					this.ar();
					result = num;
				}
				return result;
			}
			if (this.e < this.b.Length && (this.b[this.e] == '}' || this.b[this.e] == '<'))
			{
				return this.e;
			}
			return -1;
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x000869B4 File Offset: 0x000859B4
		internal bool ab()
		{
			int num = this.e;
			int num2 = 0;
			while (num < this.b.Length && (this.b[num] != ';' & this.b[num] != '}'))
			{
				if (this.b[num] == '!')
				{
					num++;
					while (num < this.b.Length && this.b[num] <= ' ')
					{
						num++;
					}
					int startIndex = num;
					num2 = 0;
					while (num < this.b.Length && (this.b[num] != ';' & this.b[num] != '}'))
					{
						if (this.b[num] <= ' ')
						{
							num++;
						}
						else
						{
							num++;
							num2++;
						}
					}
					if (string.Compare(new string(this.b, startIndex, num2), "important", true) == 0)
					{
						return true;
					}
				}
				num++;
				num2++;
			}
			return false;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00086AE8 File Offset: 0x00085AE8
		internal bool ac()
		{
			if (this.e < this.b.Length && this.b[this.e] == ',')
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && this.b[this.e] != '{' && this.b[this.e] != '<';
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00086B8C File Offset: 0x00085B8C
		internal bool ad()
		{
			if (this.e < this.b.Length && this.b[this.e] == ';')
			{
				this.e++;
			}
			this.ag();
			bool result;
			if (this.e < this.b.Length && this.b[this.e] != '}')
			{
				result = true;
			}
			else
			{
				if (this.e < this.b.Length && this.b[this.e] == '}')
				{
					this.e++;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00086C4C File Offset: 0x00085C4C
		internal bool ae()
		{
			if (this.e < this.d && this.b[this.e] == ';')
			{
				this.e++;
			}
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
			{
				this.c();
			}
			bool result;
			if (this.e < this.b.Length && this.b[this.e] == '}')
			{
				this.e++;
				result = (this.e < this.d);
			}
			else
			{
				result = (this.e < this.d);
			}
			return result;
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00086D44 File Offset: 0x00085D44
		private int d()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = this.e;
			int result;
			if (num4 < this.b.Length && this.b[num4] == '{')
			{
				result = num;
			}
			else
			{
				while (num4 < this.b.Length && this.b[num4] != '{')
				{
					if (this.b[num4] == '&' || this.b[num4] == '}' || this.b[num4] == ';' || this.b[num4] == '>' || this.b[num4] == '<')
					{
						return 0;
					}
					if (this.b[num4] == ',')
					{
						num++;
						num4++;
						num2 = 0;
						num3 = 0;
					}
					else
					{
						if (this.b[num4] > ' ')
						{
							num2++;
						}
						else
						{
							num3++;
						}
						num4++;
					}
				}
				if (num2 > 0)
				{
					num++;
				}
				else
				{
					num = 0;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00086E74 File Offset: 0x00085E74
		private int a(ref bool A_0, ref bool A_1)
		{
			int num = 0;
			int num2 = 0;
			int num3 = this.e;
			int result;
			if (num3 < this.b.Length && this.b[num3] == '{')
			{
				result = num;
			}
			else
			{
				while (num3 < this.b.Length && this.b[num3] != '{')
				{
					char c = this.b[num3];
					if (c > ' ')
					{
						if (c <= ',')
						{
							if (c != '&')
							{
								switch (c)
								{
								case '+':
									goto IL_BB;
								case ',':
									num++;
									num3++;
									num2 = 0;
									while (num3 < this.b.Length && this.b[num3] == ' ')
									{
										num3++;
									}
									A_1 = true;
									continue;
								default:
									goto IL_1F3;
								}
							}
						}
						else
						{
							switch (c)
							{
							case ';':
							case '<':
								break;
							case '=':
								goto IL_1F3;
							case '>':
								goto IL_BB;
							default:
								if (c != '}')
								{
									goto IL_1F3;
								}
								break;
							}
						}
						return num;
					}
					if (c != '\n' && c != '\r')
					{
						if (c != ' ')
						{
							goto IL_1F3;
						}
						goto IL_BB;
					}
					else
					{
						while (num3 < this.b.Length && this.b[num3] <= ' ')
						{
							num3++;
						}
						if (num2 > 0)
						{
							num++;
						}
						num2 = 0;
					}
					continue;
					IL_BB:
					num++;
					while (num3 < this.b.Length && this.b[num3] == ' ')
					{
						num3++;
					}
					if (num3 < this.b.Length)
					{
						c = this.b[num3];
						if (c == '+' || c == '>')
						{
							num3++;
						}
					}
					while (num3 < this.b.Length && this.b[num3] <= ' ')
					{
						num3++;
					}
					if (this.b[num3] == '{')
					{
						if (!A_0)
						{
							A_0 = false;
						}
						num2 = 0;
					}
					else
					{
						A_0 = true;
					}
					continue;
					IL_1F3:
					if (this.b[num3] > ' ')
					{
						num2++;
					}
					num3++;
				}
				if (A_0 && num2 > 0)
				{
					num++;
				}
				else if (num2 > 0)
				{
					num++;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x000870EC File Offset: 0x000860EC
		private void c()
		{
			bool flag = false;
			this.e += 2;
			while (this.e < this.b.Length && !flag)
			{
				if (this.b[this.e] == '*' & this.b[this.e + 1] == '/')
				{
					flag = true;
				}
				else
				{
					this.e++;
				}
			}
			if (this.e < this.b.Length && this.b[this.e] == '*' && this.b[this.e + 1] == '/')
			{
				this.e += 2;
			}
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
			{
				this.c();
			}
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0008720C File Offset: 0x0008620C
		internal void af()
		{
			if (this.e < this.b.Length && this.b[this.e] < '!')
			{
				int num = this.e;
				this.ag();
				if (this.e + 1 < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
				{
					this.c();
				}
				if (this.b[this.e] != ',' && this.b[this.e] != '>' && this.b[this.e] != '+' && this.b[this.e] != '{' && this.b[this.e] != '}')
				{
					this.e = num;
				}
			}
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0008730C File Offset: 0x0008630C
		internal void ag()
		{
			while (this.e < this.b.Length && (this.b[this.e] == ' ' || this.b[this.e] == '\n' || this.b[this.e] == '\r' || this.b[this.e] == '\t'))
			{
				this.e++;
			}
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0008738C File Offset: 0x0008638C
		internal string ah()
		{
			int num = 0;
			int startIndex = this.a();
			while (this.e < this.b.Length && (this.b[this.e] != '}' & this.b[this.e] != '/' & this.b[this.e] != '<' & this.b[this.e] != ';'))
			{
				string result;
				if (this.e + 2 < this.b.Length && this.b[this.e] == 'u' && this.b[this.e + 1] == 'r' && this.b[this.e + 2] == 'l')
				{
					result = this.at();
				}
				else
				{
					if (this.e + 1 >= this.b.Length || (this.b[this.e] != ' ' && this.b[this.e] != ';'))
					{
						if (this.b[this.e] == '!')
						{
							this.b();
						}
						else if (this.b[this.e] < ' ' || this.b[this.e] == '"' || this.b[this.e] == '\'')
						{
							this.e++;
						}
						else
						{
							num++;
							this.e++;
						}
						continue;
					}
					this.b();
					if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
					{
						this.c();
					}
					else if (this.e < this.b.Length && this.b[this.e] == '/')
					{
						this.e++;
					}
					result = new string(this.b, startIndex, num);
				}
				return result;
			}
			if (num != 0)
			{
				return new string(this.b, startIndex, num);
			}
			return null;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00087608 File Offset: 0x00086608
		internal string ai()
		{
			int num = 0;
			int startIndex = this.a();
			while (this.e < this.b.Length && this.b[this.e] != '}' && this.b[this.e] != ';' && this.b[this.e] != '<')
			{
				if (this.b[this.e] == '!')
				{
					this.b();
				}
				else if (this.b[this.e] < ' ' || this.b[this.e] == '"' || this.b[this.e] == '\'')
				{
					this.e++;
				}
				else
				{
					num++;
					this.e++;
				}
			}
			string result;
			if (num != 0)
			{
				result = new string(this.b, startIndex, num);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00087720 File Offset: 0x00086720
		internal int aj()
		{
			int num = 0;
			int a_ = this.a();
			while (this.e < this.b.Length && (this.b[this.e] != ';' & this.b[this.e] != '}'))
			{
				if (this.b[this.e] == ' ')
				{
					this.b();
					return this.b(a_, num);
				}
				if (this.b[this.e] == '!')
				{
					this.b();
				}
				else if (this.b[this.e] < ' ' || this.b[this.e] == '"' || this.b[this.e] == '\'')
				{
					this.e++;
				}
				else
				{
					num++;
					this.e++;
				}
			}
			if (num != 0)
			{
				return this.b(a_, num);
			}
			return 0;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00087858 File Offset: 0x00086858
		internal string ak()
		{
			int num = 0;
			int startIndex = this.a();
			while (this.e < this.b.Length && (this.b[this.e] != '}' & this.b[this.e] != ';'))
			{
				if (this.b[this.e] == '!')
				{
					this.b();
				}
				else
				{
					num++;
					this.e++;
				}
			}
			string result;
			if (num != 0)
			{
				result = new string(this.b, startIndex, num);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00087908 File Offset: 0x00086908
		internal bool al()
		{
			this.ag();
			return this.e < this.b.Length && (this.b[this.e] == '"' || this.b[this.e] == '\'');
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0008795C File Offset: 0x0008695C
		internal bool am()
		{
			if (this.e < this.b.Length && this.b[this.e] == ':')
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && (this.b[this.e] == 'r' || this.b[this.e] == 'R') && (this.b[this.e + 1] == 'e' || this.b[this.e + 1] == 'E') && (this.b[this.e + 2] == 'c' || this.b[this.e + 2] == 'C') && (this.b[this.e + 3] == 't' || this.b[this.e + 3] == 'T');
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00087A6C File Offset: 0x00086A6C
		internal string[] an()
		{
			string[] array = new string[4];
			int num = 0;
			int num2 = 0;
			int startIndex = this.a();
			while (this.e < this.b.Length && this.b[this.e] != ')')
			{
				if (this.b[this.e] == '(')
				{
					this.e++;
					this.ag();
					startIndex = this.e;
					while (this.e < this.b.Length && this.b[this.e] != ')')
					{
						if (this.b[this.e] == ' ' || this.b[this.e] == ',')
						{
							this.e++;
							array[num] = new string(this.b, startIndex, num2);
							this.ag();
							startIndex = this.e;
							num2 = 0;
							num++;
						}
						else
						{
							this.e++;
							num2++;
						}
					}
				}
				else
				{
					this.e++;
				}
			}
			if (num2 > 1 && num <= 4)
			{
				array[num] = new string(this.b, startIndex, num2);
				num++;
			}
			if (this.e < this.b.Length && this.b[this.e] == ')')
			{
				this.e++;
			}
			this.b();
			string[] result;
			if (num == 4)
			{
				result = array;
			}
			else
			{
				array = new string[]
				{
					"0px",
					"0px",
					"0px",
					"0px"
				};
				result = array;
			}
			return result;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00087C74 File Offset: 0x00086C74
		internal void ao()
		{
			while (this.e < this.b.Length && (this.b[this.e] != ';' & this.b[this.e] != '}'))
			{
				this.e++;
			}
			if (this.e < this.b.Length && this.b[this.e] == '}')
			{
				this.e++;
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x00087D0D File Offset: 0x00086D0D
		internal void ap()
		{
			this.ao();
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00087D18 File Offset: 0x00086D18
		internal void aq()
		{
			int num = 0;
			bool flag = false;
			while (this.e < this.b.Length && !flag)
			{
				switch (this.b[this.e])
				{
				case '{':
					num++;
					this.e++;
					break;
				case '|':
					goto IL_62;
				case '}':
					num--;
					this.e++;
					if (num == 0)
					{
						flag = true;
					}
					break;
				default:
					goto IL_62;
				}
				continue;
				IL_62:
				this.e++;
			}
			if (this.e < this.b.Length && this.b[this.e] == '}')
			{
				this.e++;
			}
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00087DF4 File Offset: 0x00086DF4
		internal void ar()
		{
			while (this.e < this.b.Length)
			{
				this.e++;
			}
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00087E28 File Offset: 0x00086E28
		private void b()
		{
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '!')
			{
				while (this.e < this.b.Length && (this.b[this.e] != ';' & this.b[this.e] != '}'))
				{
					this.e++;
				}
			}
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00087EBC File Offset: 0x00086EBC
		internal bool @as()
		{
			int i = this.e;
			int num = 0;
			if (i < this.b.Length && (this.b[i] == ':' || this.b[i] == '='))
			{
				i++;
				num++;
			}
			while (i < this.b.Length)
			{
				if (i + 2 < this.b.Length && this.b[i] == ':' && this.b[i + 1] == '/' && this.b[i + 2] == '/')
				{
					i += 2;
				}
				else if (i + 1 < this.b.Length && this.b[i] == ':' && (this.b[i + 1] == '\\' || this.b[i + 1] == '/'))
				{
					i++;
				}
				else if (this.b[i] == ':' || this.b[i] == '=')
				{
					num++;
				}
				else
				{
					if (this.b[i] == ';' || this.b[i] == '}' || this.b[i] == '<')
					{
						return true;
					}
					if (i + 3 < this.b.Length && this.b[i] == 'd' && this.b[i + 1] == 'a' && this.b[i + 2] == 't' && this.b[i + 3] == 'a')
					{
						return true;
					}
				}
				i++;
				if (num != 2)
				{
					continue;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00088090 File Offset: 0x00087090
		internal string at()
		{
			int num = 0;
			while (this.e < this.b.Length && this.b[this.e] != '}')
			{
				if (this.b[this.e] == '(')
				{
					this.e++;
					this.ag();
					if (this.e < this.b.Length && (this.b[this.e] == '\'' || this.b[this.e] == '"'))
					{
						this.e++;
					}
					int startIndex = this.e;
					while (this.e < this.b.Length && this.b[this.e] != ')' && this.b[this.e] != '<')
					{
						if (this.b[this.e] == '\'' || this.b[this.e] == '"')
						{
							this.e++;
							this.ag();
						}
						else if (this.b[this.e] < ' ')
						{
							this.e++;
						}
						else
						{
							num++;
							this.e++;
						}
					}
					if (this.e < this.b.Length && this.b[this.e] == ')')
					{
						this.e++;
					}
					this.b();
					return new string(this.b, startIndex, num);
				}
				this.e++;
			}
			return null;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0008828C File Offset: 0x0008728C
		internal string au()
		{
			int num = 0;
			if (this.e < this.b.Length && (this.b[this.e] == ':' || this.b[this.e] == '='))
			{
				this.e++;
			}
			this.ag();
			int startIndex = this.e;
			while (this.e < this.b.Length && this.b[this.e] != '}')
			{
				if (this.b[this.e] == ';' || this.b[this.e] == ' ')
				{
					this.b();
					string result;
					if (num != 0)
					{
						result = new string(this.b, startIndex, num);
					}
					else
					{
						result = null;
					}
					return result;
				}
				if (this.b[this.e] == '!')
				{
					this.b();
				}
				else if (this.b[this.e] == '\r' || this.b[this.e] == '\n' || this.b[this.e] == '\t')
				{
					this.e++;
				}
				else
				{
					num++;
					this.e++;
				}
			}
			if (num != 0)
			{
				return new string(this.b, startIndex, num);
			}
			return null;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0008842C File Offset: 0x0008742C
		internal bool av()
		{
			if (this.e < this.b.Length && this.b[this.e] == '}')
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && this.b[this.e] > ' ';
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x000884A4 File Offset: 0x000874A4
		private int a()
		{
			if (this.e < this.b.Length && (this.b[this.e] == ':' || this.b[this.e] == ',' || this.b[this.e] == '='))
			{
				this.e++;
			}
			this.ag();
			if (this.e < this.b.Length && this.b[this.e] == '/' && this.b[this.e + 1] == '*')
			{
				this.c();
			}
			if (this.e < this.b.Length && (this.b[this.e] == '"' || this.b[this.e] == '\''))
			{
				this.e++;
			}
			return this.e;
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x000885BC File Offset: 0x000875BC
		internal bool aw()
		{
			if (this.e < this.b.Length && (this.b[this.e] == ':' || this.b[this.e] == '='))
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && this.b[this.e] != ';' && this.b[this.e] != '}' && this.b[this.e] != '<' && this.b[this.e] > ' ';
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0008867C File Offset: 0x0008767C
		internal bool ax()
		{
			if (this.e < this.b.Length && (this.b[this.e] == ':' || this.b[this.e] == '=' || this.b[this.e] == '/'))
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && ((this.b[this.e] >= '0' && this.b[this.e] <= '9') || this.b[this.e] == '+' || this.b[this.e] == '-' || this.b[this.e] == '.');
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x00088778 File Offset: 0x00087778
		internal bool ay()
		{
			if (this.e < this.b.Length && (this.b[this.e] == '=' || this.b[this.e] == ':' || this.b[this.e] == '/'))
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && this.b[this.e] >= '0' && this.b[this.e] <= '9';
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00088828 File Offset: 0x00087828
		internal bool az()
		{
			if (this.e < this.b.Length && (this.b[this.e] == ':' || this.b[this.e] == '/'))
			{
				this.e++;
			}
			this.ag();
			return this.e + 1 < this.b.Length && this.b[this.e] == '-' && this.b[this.e + 1] >= '0' && this.b[this.e + 1] <= '9';
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x000888E0 File Offset: 0x000878E0
		internal bool a0()
		{
			this.ag();
			bool result;
			if (this.e < this.b.Length)
			{
				if (this.b[this.e] == '/')
				{
					this.e++;
				}
				result = ((this.b[this.e] >= 'A' && this.b[this.e] <= 'Z') || (this.b[this.e] >= 'a' && this.b[this.e] <= 'z') || this.b[this.e] == '#' || this.b[this.e] == '"' || this.b[this.e] == '\'' || (this.b[this.e] >= '0' && this.b[this.e] <= '9') || this.b[this.e] == '-' || this.b[this.e] == '.' || this.b[this.e] == '+');
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00088A20 File Offset: 0x00087A20
		internal int a1()
		{
			return Convert.ToInt32(this.au());
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00088A40 File Offset: 0x00087A40
		internal float a2()
		{
			return float.Parse(this.au());
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00088A60 File Offset: 0x00087A60
		internal bool a3()
		{
			this.ag();
			bool result;
			if (this.e < this.b.Length && this.b[this.e] == ',' && this.b[this.e] != ';')
			{
				this.e++;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00088AC8 File Offset: 0x00087AC8
		internal bool a4()
		{
			this.ag();
			return this.e >= this.b.Length || this.b[this.e] == '/';
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00088B08 File Offset: 0x00087B08
		internal bool a5()
		{
			int num = this.e;
			if (num < this.b.Length && this.b[num] == '{')
			{
				num++;
			}
			bool result;
			if (num < this.b.Length)
			{
				while (num < this.b.Length && this.b[num] <= ' ')
				{
					num++;
				}
				result = (num >= this.b.Length || (this.b[num] != '}' && this.b[num] != '{' && this.b[num] != ';' && this.b[num] != ':'));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00088BD8 File Offset: 0x00087BD8
		internal bool a6()
		{
			return this.aw();
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00088BFC File Offset: 0x00087BFC
		internal bool c(int A_0)
		{
			if (A_0 <= 445130693)
			{
				if (A_0 <= 189525969)
				{
					if (A_0 <= 8714757)
					{
						if (A_0 <= 6947816)
						{
							if (A_0 != 136794 && A_0 != 6947816)
							{
								goto IL_297;
							}
						}
						else if (A_0 != 6968946 && A_0 != 7021096 && A_0 != 8714757)
						{
							goto IL_297;
						}
					}
					else if (A_0 <= 67814465)
					{
						if (A_0 != 31536467 && A_0 != 40160150 && A_0 != 67814465)
						{
							goto IL_297;
						}
					}
					else if (A_0 != 136941815 && A_0 != 148235845 && A_0 != 189525969)
					{
						goto IL_297;
					}
				}
				else if (A_0 <= 272801619)
				{
					if (A_0 <= 202920309)
					{
						if (A_0 != 200780672 && A_0 != 202920309)
						{
							goto IL_297;
						}
					}
					else if (A_0 != 254664735 && A_0 != 265770411 && A_0 != 272801619)
					{
						goto IL_297;
					}
				}
				else if (A_0 <= 426354259)
				{
					if (A_0 != 275611842 && A_0 != 397142149 && A_0 != 426354259)
					{
						goto IL_297;
					}
				}
				else if (A_0 != 436574770 && A_0 != 440052479 && A_0 != 445130693)
				{
					goto IL_297;
				}
			}
			else if (A_0 <= 795562982)
			{
				if (A_0 <= 587060291)
				{
					if (A_0 <= 448574430)
					{
						if (A_0 != 445330501 && A_0 != 448574430)
						{
							goto IL_297;
						}
					}
					else if (A_0 != 503613957 && A_0 != 510035525 && A_0 != 587060291)
					{
						goto IL_297;
					}
				}
				else if (A_0 <= 663362251)
				{
					if (A_0 != 633671921 && A_0 != 663292235 && A_0 != 663362251)
					{
						goto IL_297;
					}
				}
				else if (A_0 != 679876343 && A_0 != 791474715 && A_0 != 795562982)
				{
					goto IL_297;
				}
			}
			else if (A_0 <= 1652275116)
			{
				if (A_0 <= 1005822593)
				{
					if (A_0 != 847005961 && A_0 != 898954496 && A_0 != 1005822593)
					{
						goto IL_297;
					}
				}
				else if (A_0 != 1352615981 && A_0 != 1617181893 && A_0 != 1652275116)
				{
					goto IL_297;
				}
			}
			else if (A_0 <= 1982853278)
			{
				if (A_0 != 1688661191 && A_0 != 1844443081 && A_0 != 1982853278)
				{
					goto IL_297;
				}
			}
			else if (A_0 != 1982903832 && A_0 != 2066421648 && A_0 != 2098498396)
			{
				goto IL_297;
			}
			return true;
			IL_297:
			return false;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x00088EA8 File Offset: 0x00087EA8
		internal i4 a(string A_0)
		{
			float a_ = 0f;
			i2 a_2 = i2.a;
			int num = A_0.IndexOfAny(new char[]
			{
				'%',
				'p',
				'P',
				'i',
				'I',
				'e',
				'E',
				'c',
				'C',
				'm',
				'M',
				'r',
				'R'
			});
			if (num > 0)
			{
				bool flag = float.TryParse(A_0.Substring(0, num), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out a_);
				if (flag)
				{
					int num2 = this.a(A_0.Substring(num), 0, A_0.Substring(num).Length);
					if (num2 <= 1349)
					{
						if (num2 <= 353)
						{
							if (num2 != 62)
							{
								if (num2 == 353)
								{
									a_2 = i2.g;
								}
							}
							else
							{
								a_2 = i2.b;
							}
						}
						else if (num2 != 1288)
						{
							if (num2 != 1313)
							{
								if (num2 == 1349)
								{
									a_2 = i2.e;
								}
							}
							else
							{
								a_2 = i2.c;
							}
						}
						else
						{
							a_2 = i2.h;
						}
					}
					else
					{
						if (num2 <= 1365)
						{
							if (num2 != 1352)
							{
								if (num2 != 1365)
								{
									goto IL_113;
								}
								a_2 = i2.k;
								goto IL_113;
							}
						}
						else
						{
							if (num2 == 1697)
							{
								a_2 = i2.d;
								goto IL_113;
							}
							if (num2 == 2383)
							{
								a_2 = i2.i;
								goto IL_113;
							}
							if (num2 != 86558)
							{
								goto IL_113;
							}
						}
						a_2 = i2.f;
					}
					IL_113:;
				}
			}
			else
			{
				float num3 = 0f;
				if (float.TryParse(A_0, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num3))
				{
					a_ = num3;
				}
				else
				{
					a_ = num3;
				}
			}
			return new i4(a_2, a_);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x00089004 File Offset: 0x00088004
		internal ft b(string A_0)
		{
			int num = this.a(A_0, 0, A_0.Length);
			if (num <= 146669599)
			{
				if (num <= 137319390)
				{
					if (num == 2250341)
					{
						return ft.a;
					}
					if (num == 137319390)
					{
						return ft.e;
					}
				}
				else
				{
					if (num == 141141535)
					{
						return ft.f;
					}
					if (num == 142715117)
					{
						return ft.d;
					}
					if (num == 146669599)
					{
						return ft.g;
					}
				}
			}
			else if (num <= 392533915)
			{
				if (num == 148329381)
				{
					return ft.j;
				}
				if (num == 392533915)
				{
					return ft.c;
				}
			}
			else
			{
				if (num == 438438223)
				{
					return ft.b;
				}
				if (num == 686175845)
				{
					return ft.i;
				}
				if (num == 893290080)
				{
					return ft.h;
				}
			}
			return ft.a;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x000890C0 File Offset: 0x000880C0
		internal bool c(string A_0)
		{
			bool result;
			if (A_0 != null)
			{
				int num = this.a(A_0, 0, A_0.Length);
				if (num <= 303365082)
				{
					if (num != 9763802 && num != 303365082)
					{
						goto IL_49;
					}
				}
				else if (num != 505607249 && num != 591352383)
				{
					goto IL_49;
				}
				return true;
				IL_49:
				result = false;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00089120 File Offset: 0x00088120
		internal bool d(string A_0)
		{
			bool result;
			if (A_0 != null)
			{
				int num = this.a(A_0, 0, A_0.Length);
				if (num <= 146669599)
				{
					if (num <= 137319390)
					{
						if (num != 2250341 && num != 137319390)
						{
							goto IL_98;
						}
					}
					else if (num != 141141535 && num != 142715117 && num != 146669599)
					{
						goto IL_98;
					}
				}
				else if (num <= 438438223)
				{
					if (num != 148329381 && num != 392533915 && num != 438438223)
					{
						goto IL_98;
					}
				}
				else if (num != 505607249 && num != 686175845 && num != 893290080)
				{
					goto IL_98;
				}
				return true;
				IL_98:
				result = false;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x000891D0 File Offset: 0x000881D0
		internal h2 e(string A_0)
		{
			int num = this.a(A_0, 0, A_0.Length);
			h2 result;
			if (num != 9763802)
			{
				if (num != 303365082)
				{
					if (num != 591352383)
					{
						if (A_0[0] == '+')
						{
							string a_ = A_0.Substring(1, A_0.Length - 1);
							result = new h2(this.a(a_));
						}
						else if (A_0[0] == '-')
						{
							result = new h2(new i4(i2.c, 0f));
						}
						else
						{
							result = new h2(new i4(i2.c, 1f));
						}
					}
					else
					{
						result = new h2(new i4(i2.c, 3f));
					}
				}
				else
				{
					result = new h2(new i4(i2.c, 5f));
				}
			}
			else
			{
				result = new h2(new i4(i2.c, 1f));
			}
			return result;
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x000892B0 File Offset: 0x000882B0
		internal fc[] a7()
		{
			this.f = 0;
			this.g = 0;
			while (this.e < this.d)
			{
				while (this.e < this.b.Length && this.b[this.e] == ';')
				{
					this.e++;
				}
				int num = this.v();
				if (num != 0)
				{
					if (this.c(num) && this.@as())
					{
						if (this.ab())
						{
							fc fc = fc.a(this.l, this.g, num);
							if (fc == null)
							{
								fc = new fc(num, fd.a(num, this));
								if (this.g >= this.l.Length)
								{
									this.l = this.a(this.l);
								}
								this.l[this.g] = fc;
								this.g++;
							}
							else
							{
								fc.b().cw(this);
							}
							this.l = this.a(this.l, fc, ref this.g);
						}
						else
						{
							fc fc = fc.a(this.k, this.f, num);
							if (fc == null)
							{
								fc = new fc(num, fd.a(num, this));
								if (this.f >= this.k.Length)
								{
									this.k = this.a(this.k);
								}
								this.k[this.f] = fc;
								this.f++;
							}
							else
							{
								fc.b().cw(this);
							}
							this.k = this.a(this.k, fc, ref this.f);
						}
					}
					else
					{
						this.ap();
					}
				}
				else
				{
					this.ao();
				}
			}
			return this.a(this.k, this.l);
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x000894D0 File Offset: 0x000884D0
		internal fc[] a(fc[] A_0, fc[] A_1)
		{
			fc[] array;
			if (this.g > 0)
			{
				array = new fc[this.f + this.g + 1];
				Array.Copy(A_0, 0, array, 0, this.f);
				Array.Copy(A_1, 0, array, this.f, this.g);
				array[array.Length - 1] = new fc(1210592242, new af7(this.f));
			}
			else
			{
				array = new fc[this.f];
				Array.Copy(A_0, 0, array, 0, this.f);
			}
			return array;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00089570 File Offset: 0x00088570
		private fc[] a(fc[] A_0, fc A_1, ref int A_2)
		{
			int num = A_1.a();
			if (num != 6968946)
			{
				if (num == 1652275116)
				{
					fc fc = fc.a(A_0, A_2, 6968946);
					if (fc != null)
					{
						int num2 = ((hd)fc.b()).c();
						((hd)fc.b()).a(num2, ((ho)A_1.b()).a());
					}
				}
			}
			else
			{
				int num2 = ((hd)A_1.b()).c();
				if (num2 > -1)
				{
					fc fc2 = fc.a(A_0, A_2, 1652275116);
					if (fc2 == null)
					{
						ho ho = new ho();
						ho.a((afz)((hd)A_1.b()).a()[num2].b());
						fc2 = new fc(1652275116, ho);
						if (A_2 >= A_0.Length)
						{
							A_0 = this.a(A_0);
						}
						A_0[A_2] = fc2;
						A_2++;
					}
					else
					{
						((ho)fc2.b()).a((afz)((hd)A_1.b()).a()[num2].b());
					}
				}
			}
			return A_0;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x000896CC File Offset: 0x000886CC
		private int a(int A_0, fc[] A_1)
		{
			int i;
			for (i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return i;
				}
			}
			return i;
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0008970C File Offset: 0x0008870C
		private bool a(int A_0, int A_1, fb<fn>[] A_2)
		{
			for (int i = 0; i < A_1; i++)
			{
				if (A_2[i].a() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0008974C File Offset: 0x0008874C
		private fc[] a(fc[] A_0)
		{
			fc[] array = new fc[A_0.Length + 1];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			A_0 = array;
			return A_0;
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0008977C File Offset: 0x0008877C
		private fc[] a(fc[] A_0, int A_1)
		{
			fc[] array = new fc[A_0.Length + A_1];
			Array.Copy(A_0, 0, array, 0, A_0.Length);
			A_0 = array;
			return A_0;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x000897AC File Offset: 0x000887AC
		internal bool a8()
		{
			if (this.e < this.b.Length && this.b[this.e] == ':')
			{
				this.e++;
			}
			this.ag();
			return this.e < this.b.Length && (this.b[this.e] == 'r' || this.b[this.e] == 'R') && (this.b[this.e + 1] == 'G' || this.b[this.e + 1] == 'g') && (this.b[this.e + 2] == 'b' || this.b[this.e + 2] == 'B');
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00089894 File Offset: 0x00088894
		internal string a9()
		{
			int num = 0;
			this.c = this.e;
			while (this.e < this.b.Length && (this.b[this.e] != ';' & this.b[this.e] != '}'))
			{
				if (this.b[this.e] == ')')
				{
					num++;
					this.e++;
					break;
				}
				num++;
				this.e++;
			}
			if (this.e < this.b.Length)
			{
				if (this.b[this.e] == ' ' || this.b[this.e] == ';')
				{
					this.b();
					if (this.e < this.b.Length && this.b[this.e] == '/')
					{
						this.e++;
					}
				}
				else if (this.b[this.e] == '!')
				{
					this.b();
				}
			}
			return new string(this.b, this.c, num);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00089A00 File Offset: 0x00088A00
		internal bool f(string A_0)
		{
			int num = 0;
			int num2 = 0;
			foreach (char c in A_0)
			{
				char c2 = c;
				if (c2 != '%')
				{
					if (c2 == '.')
					{
						num2++;
					}
				}
				else
				{
					num++;
				}
			}
			return (num == 0 && (num2 == 0 || num2 == 3)) || num == 3;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00089A80 File Offset: 0x00088A80
		internal bool ba()
		{
			if (this.e < this.b.Length && this.b[this.e] == ':')
			{
				this.e++;
			}
			this.ag();
			int num = this.e;
			int num2 = 0;
			while (num + num2 < this.b.Length && ((this.b[num + num2] >= 'a' && this.b[num + num2] <= 'z') || (this.b[num + num2] >= 'A' && this.b[num + num2] <= 'Z')))
			{
				num2++;
			}
			string text = new string(this.b, num, num2);
			string text2 = text.ToLower();
			if (text2 != null)
			{
				if (text2 == "top" || text2 == "right" || text2 == "center" || text2 == "bottom" || text2 == "left")
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00089BA8 File Offset: 0x00088BA8
		internal int b(int A_0, int A_1)
		{
			for (int i = 0; i < A_1; i++)
			{
				this.j.b(this.b[A_0 + i]);
			}
			int result = this.j.b();
			this.j.a();
			return result;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00089BFC File Offset: 0x00088BFC
		internal int a(string A_0, int A_1, int A_2)
		{
			for (int i = 0; i < A_2; i++)
			{
				this.j.b(A_0[A_1 + i]);
			}
			int result = this.j.b();
			this.j.a();
			return result;
		}

		// Token: 0x0400057D RID: 1405
		private const string a = "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)";

		// Token: 0x0400057E RID: 1406
		private char[] b = null;

		// Token: 0x0400057F RID: 1407
		private int c = 0;

		// Token: 0x04000580 RID: 1408
		private int d = 0;

		// Token: 0x04000581 RID: 1409
		private int e = 0;

		// Token: 0x04000582 RID: 1410
		private int f;

		// Token: 0x04000583 RID: 1411
		private int g;

		// Token: 0x04000584 RID: 1412
		private h7[] h = null;

		// Token: 0x04000585 RID: 1413
		private h7[] i = null;

		// Token: 0x04000586 RID: 1414
		private hg j = new hg();

		// Token: 0x04000587 RID: 1415
		private fc[] k = new fc[1];

		// Token: 0x04000588 RID: 1416
		private fc[] l = new fc[1];

		// Token: 0x04000589 RID: 1417
		private bool m = false;

		// Token: 0x0400058A RID: 1418
		private bool n = false;

		// Token: 0x0400058B RID: 1419
		private bool o = false;

		// Token: 0x0400058C RID: 1420
		private bool p = false;
	}
}
