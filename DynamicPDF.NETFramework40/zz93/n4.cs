using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200021E RID: 542
	internal class n4
	{
		// Token: 0x0600196B RID: 6507 RVA: 0x0010B2B0 File Offset: 0x0010A2B0
		internal static x5 a(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6)
		{
			float num = 0f;
			float num2 = 0f;
			int i = A_1;
			while (i < A_1 + A_2)
			{
				char c = A_0[i];
				if (c != ' ')
				{
					num += (float)A_5.GetGlyphWidth(A_0[i]);
					num2 += A_4;
					i++;
				}
				else
				{
					num += (float)A_5.GetGlyphWidth(A_0[i]);
					num2 += A_3 + A_4;
					i++;
				}
			}
			return x5.a(num2 + (num * A_6 / 1000f + 0.001f));
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x0010B33C File Offset: 0x0010A33C
		internal static x5 a(afr A_0, int A_1, ref int A_2, float A_3, float A_4, Font A_5, float A_6, bool A_7)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			bool flag = false;
			for (int i = 0; i < A_0.b().Length; i++)
			{
				agd agd = A_0.b()[i];
				l2 l = A_0.c()[i];
				int j = A_0.e()[i];
				if (A_7)
				{
					A_1 = j;
					j = ((j < agd.a()) ? j : 0);
				}
				while (j < agd.a())
				{
					char c = agd.b(agd.a(j).a());
					if (c != ' ')
					{
						if (!flag)
						{
							if (j - A_1 > 0 && j < agd.a())
							{
								num3 += (float)((int)l.e().jf(agd.a(j)) + agd.a(j).e());
							}
							else
							{
								num3 = (float)l.e().jf(agd.a(j));
							}
						}
						else if (j < agd.a() - 1)
						{
							num3 += (float)((int)l.e().jf(agd.a(j)) + agd.a(j).e());
						}
						else
						{
							num3 = (float)l.e().jf(agd.a(j));
						}
						num += A_4;
					}
					else
					{
						num3 = num3 * A_6 / 1000f;
						num += num3;
						float num4 = (float)l.e().jf(agd.a(j)) * A_6 / 1000f;
						num += num4;
						num += A_3 + A_4;
						num3 = 0f;
					}
					j++;
				}
				if (num3 > 0f)
				{
					num3 = num3 * A_6 / 1000f;
					num += num3;
				}
				A_2 = agd.a();
			}
			return x5.a(num2 + num + 0.001f);
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x0010B57C File Offset: 0x0010A57C
		internal static x5 a(Font A_0, float A_1, x5? A_2, mw A_3)
		{
			x5 result;
			if (A_2 == null)
			{
				result = x5.a(A_0.GetDefaultLeading(A_1));
			}
			else if (A_3 != mw.d)
			{
				result = A_2.Value;
			}
			else
			{
				result = x5.a(A_1 * x5.b(A_2.Value));
			}
			return result;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x0010B5D4 File Offset: 0x0010A5D4
		internal static int a(char[] A_0, int A_1, int A_2)
		{
			int num = 0;
			bool flag = false;
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				char c = A_0[i];
				if (c == ' ')
				{
					num++;
					flag = true;
				}
			}
			if (!flag)
			{
				num++;
			}
			return num;
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x0010B624 File Offset: 0x0010A624
		internal static kz a(n3 A_0, nn A_1, x5 A_2, bool A_3, ref bool A_4, int A_5)
		{
			agd agd = null;
			int num = 0;
			int num2 = 0;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			l2 l = null;
			int num6 = -1;
			bool flag = false;
			x5 x = x5.c();
			bool flag2 = false;
			bool flag3 = false;
			x5 x2 = x5.c();
			x5 x3 = x5.c();
			if (A_0 != null)
			{
				agd = A_0.u().b()[A_5];
				num = A_0.u().e()[A_5];
				num2 = num + agd.a();
				l = A_0.u().c()[A_5];
				num4 = x5.b(A_0.bd());
				num3 = x5.b(A_0.be());
				num5 = x5.b(A_0.l());
				if (!A_3)
				{
					if (A_0.by() == 1 && A_0.bz() == 1)
					{
						char c = agd.b(agd.a(num).a());
						if (num < agd.a() && c == ' ')
						{
							A_0.c(A_0.h() + 1);
							A_0.h(A_0.ba() - 1);
							num++;
							num2 = agd.a() - 1;
						}
					}
				}
				num6 = A_0.bo();
				flag = A_0.v();
				if (A_0.dr().dg() == 23684646)
				{
					flag3 = true;
				}
			}
			else if (A_1 != null)
			{
				agd = A_1.a().u().b()[A_5];
				num = A_1.a().u().e()[A_5];
				num2 = agd.a();
				l = A_1.a().u().c()[A_5];
				num4 = x5.b(A_1.a().bd());
				num3 = x5.b(A_1.a().be());
				num5 = x5.b(A_1.a().l());
				if (!A_3 && num < agd.a())
				{
					char c = agd.b(agd.a(num).a());
					if (c == ' ')
					{
						A_1.a(A_1.b() + 1);
						A_1.h(A_1.ba() - 1);
						num++;
						A_1.a().u().e()[A_5] = num;
						num2 = agd.a() - 1;
						A_1.a().u().f()[A_5]--;
					}
				}
				num6 = A_1.bo();
				flag = A_1.g();
				if (A_1.dr().dg() == 23684646)
				{
					flag3 = true;
				}
			}
			int num7 = 0;
			int i = num;
			int num8 = 0;
			int num9 = 0;
			x5 x4 = x5.c();
			x5 x5 = x5.c();
			x5 x6 = x5.c();
			x5 x7 = x5.c();
			bool flag4 = false;
			bool flag5 = false;
			while (i < num2)
			{
				char c = agd.b(agd.a(i).a());
				while (i < num2 && ((c == '\0' || c > ' ') & c != '-' & !n4.a(agd, i, num7)))
				{
					if (!flag5)
					{
						if (i - num > 0 && i < agd.a())
						{
							x4 = x5.f(x4, x5.a((float)((int)l.e().jf(agd.a(i)) + agd.a(i).e())));
						}
						else
						{
							x4 = x5.f(x4, x5.a((float)l.e().jf(agd.a(i))));
						}
					}
					else if (i < agd.a() - 1)
					{
						x4 = x5.f(x4, x5.a((float)((int)l.e().jf(agd.a(i)) + agd.a(i).e())));
					}
					else
					{
						x4 = x5.f(x4, x5.a((float)l.e().jf(agd.a(i))));
					}
					num7++;
					i++;
					if (i < num2)
					{
						c = agd.b(agd.a(i).a());
					}
					if (flag3)
					{
						x3 = x5.a(x5.b(x4) * num5 / 1000f + 0.001f);
						if (x5.a(x3, A_2))
						{
							flag4 = true;
							num7--;
							break;
						}
						x2 = x3;
					}
				}
				if (flag3)
				{
					x4 = x2;
				}
				else
				{
					x4 = x5.a(x5.b(x4) * num5 / 1000f + 0.001f);
				}
				char c2 = c;
				if (c2 <= '-')
				{
					switch (c2)
					{
					case ' ':
						break;
					case '!':
						goto IL_731;
					case '"':
						goto IL_60A;
					default:
						switch (c2)
						{
						case '\'':
						case '(':
						case ')':
							goto IL_60A;
						case '*':
						case '+':
						case ',':
							goto IL_731;
						case '-':
							break;
						default:
							goto IL_731;
						}
						break;
					}
					if (i < agd.a())
					{
						x6 = x5.a((float)l.e().jf(agd.a(i)));
						x6 = x5.a(x5.b(x6) * num5 / 1000f);
						x6 = x5.f(x6, x5.a(num3 + num4));
						x = x6;
						x5 = x4;
						num7++;
						i++;
						x4 = x5.c();
					}
					else
					{
						x5 = x4;
						x4 = x5.c();
					}
				}
				else if (c2 != '<')
				{
					switch (c2)
					{
					case '[':
					case ']':
						goto IL_60A;
					case '\\':
						goto IL_731;
					default:
						switch (c2)
						{
						case '{':
						case '}':
							goto IL_60A;
						case '|':
							goto IL_731;
						default:
							goto IL_731;
						}
						break;
					}
				}
				else
				{
					flag4 = true;
					x5 = x4;
					num8++;
					if (x5.b(x5.f(x5, x7), A_2))
					{
						x7 = x5.f(x7, x5);
						num9 += num7;
					}
					i++;
					x4 = x5.c();
				}
				IL_744:
				x5 = x5.f(x5, x5.a((float)(num7 - 1) * num4));
				if (!flag4 && x5.b(x5.f(x5, x7), A_2))
				{
					num9 += num7;
					x7 = x5.f(x7, x5);
					if (x5.b(x5.f(x7, x6), A_2))
					{
						x7 = x5.f(x7, x6);
					}
					else
					{
						num9--;
						flag2 = true;
					}
					num7 = 0;
					x6 = x5.c();
					x5 = x5.c();
					num8++;
					continue;
				}
				kz result;
				if ((num8 == 0 || num8 == 1) && x5.c(x5, A_2))
				{
					if (x5.b(x5.e(x5, x6), A_2))
					{
						if (A_0 != null)
						{
							if (num9 != 0)
							{
								A_0.h(num9);
								A_0.l(x7);
							}
							else
							{
								A_0.h(num7 - 1);
								A_0.l(x5.e(x5, x6));
							}
							A_0.i(num8);
							if (num9 > 0)
							{
								num = num9;
							}
							else if (num7 > 0)
							{
								if (num == 0)
								{
									num = num7 - 1;
								}
								else
								{
									num = num + num7 - 1;
								}
							}
							nn nn = new nn(A_0, true, A_5, num);
							A_4 = true;
							result = nn;
						}
						else
						{
							if (num9 != 0)
							{
								A_1.a().u().f()[A_5] = num9;
								A_1.h(num9);
								A_1.l(x7);
							}
							else
							{
								A_1.a().u().f()[A_5] = num7;
								A_1.h(num7 - 1);
								A_1.l(x5.e(x5, x6));
							}
							A_1.i(num8);
							if (num9 > 0)
							{
								num += num9;
							}
							else if (num7 > 0)
							{
								if (num == 0)
								{
									num = num7 - 1;
								}
								else
								{
									num = num + num7 - 1;
								}
							}
							nn nn = new nn(A_1, A_5, num);
							A_4 = true;
							result = nn;
						}
					}
					else if (A_0 != null)
					{
						if (x5.h(A_0.aw(), x5.c()) && A_0.bz() == 1)
						{
							if (x5.c(A_0.b2(), A_2))
							{
								A_0.aj(true);
								return null;
							}
						}
						if (x5.c(A_0.b2(), A_2))
						{
							result = A_0;
						}
						else
						{
							if (num9 != 0)
							{
								A_0.h(num9);
								A_0.u().f()[A_5] = num9;
								A_0.l(x7);
							}
							else if (num7 != 0)
							{
								A_0.h(num7);
								A_0.u().f()[A_5] = num7;
								A_0.l(x5);
							}
							A_0.i(num8);
							if (num9 > 0)
							{
								num = num9;
							}
							else if (num7 > 0)
							{
								num = num7;
							}
							if (x5.c(A_0.aq(), A_0.bm()))
							{
								A_0.aj(true);
								nn nn = new nn(A_0, true, A_5, num);
								A_4 = true;
								result = nn;
							}
							else
							{
								nn nn = new nn(A_0, true, A_5, num);
								A_4 = true;
								result = nn;
							}
						}
					}
					else
					{
						if (A_1 != null)
						{
							if (x5.h(A_1.aw(), x5.c()) && A_1.bz() == 1)
							{
								if (x5.c(A_1.b2(), A_2))
								{
									A_1.aj(true);
									return null;
								}
							}
							if (x5.c(A_1.b2(), A_2))
							{
								return A_1;
							}
							if (num9 != 0)
							{
								A_1.a().u().f()[A_5] = num9;
								A_1.h(num9);
								A_1.l(x7);
							}
							A_1.i(num8);
							if (x5.c(A_1.aq(), A_1.bm()))
							{
								A_1.aj(true);
							}
							else
							{
								if (x5.c(x6, x5.c()))
								{
									A_1.h((num7 > 0) ? (num7 - 1) : num9);
									A_1.l(x5.e(x5, x6));
									A_1.a().u().f()[A_5] = A_1.ba();
									return null;
								}
								A_1.a().u().f()[A_5] = num7;
								A_1.h(num7);
								A_1.c(num7);
								A_1.l(x5);
								if (num9 > 0)
								{
									num += num9;
								}
								else if (num7 > 0)
								{
									if (x5.c(x5, A_2) && x5.c(x5, A_1.bm()))
									{
										num += num7 - 1;
									}
									else if (num == 0)
									{
										num = num7 - 1;
									}
									else
									{
										num = num2 - num7;
									}
								}
								nn nn = new nn(A_1, A_5, num);
								A_4 = true;
								return nn;
							}
						}
						result = null;
					}
				}
				else
				{
					if (x5.c(x, x5.c()) && !flag2)
					{
						x7 = x5.e(x7, x);
						if (num9 > 0)
						{
							num9--;
						}
						else if (num7 > 0)
						{
							num7--;
						}
					}
					bool flag6 = false;
					if (A_0 != null)
					{
						if (num9 != 0)
						{
							if (num9 < agd.a())
							{
								flag6 = true;
							}
							A_0.u().f()[A_5] = num9;
							A_0.l(x7);
						}
						else
						{
							if (num7 < agd.a())
							{
								flag6 = true;
								if (x5.c(x5, A_2))
								{
									if (x5.b(x5.e(x5, x6), A_2))
									{
										num7--;
										x5 = x5.e(x5, x6);
									}
								}
							}
							A_0.u().f()[A_5] = num7;
							A_0.h(num7);
							A_0.e(num7);
							A_0.l(x5);
						}
						A_0.i(num8);
						if (flag6)
						{
							if (num9 > 0)
							{
								num = num9;
							}
							else if (num7 > 0)
							{
								num = num7;
							}
							nn nn = new nn(A_0, true, A_5, num);
							nn.h(num2 - num);
							nn.c(num9);
							A_4 = true;
							result = nn;
						}
						else
						{
							result = null;
						}
					}
					else
					{
						if (num9 != 0)
						{
							if (num9 < agd.a())
							{
								flag6 = true;
							}
							A_1.a().u().f()[A_5] = num9;
							A_1.h(num9);
							A_1.c(num9);
							A_1.l(x7);
						}
						else
						{
							if (num7 < agd.a())
							{
								flag6 = true;
							}
							if (x5.c(x5, A_2))
							{
								if (x5.b(x5.e(x5, x6), A_2))
								{
									num7--;
									x5 = x5.e(x5, x6);
								}
							}
							A_1.a().u().f()[A_5] = num7;
							A_1.h(num7);
							A_1.l(x5);
						}
						A_1.i(num8);
						if (flag6)
						{
							if (num9 > 0)
							{
								num += num9;
							}
							else if (num7 > 0)
							{
								num += num7;
							}
							nn nn = new nn(A_1, A_5, num);
							A_4 = true;
							result = nn;
						}
						else
						{
							result = null;
						}
					}
				}
				return result;
				IL_60A:
				if (i < agd.a())
				{
					if (flag && i == num6)
					{
						flag4 = true;
						x5 = x4;
						if (x5.b(x5.f(x5, x7), A_2))
						{
							x7 = x5.f(x7, x5);
							num9 += num7;
						}
						i++;
						x4 = x5.c();
					}
					else
					{
						x5 a_ = x5.a((float)l.e().jf(agd.a(i)));
						x4 = x5.f(x4, x5.a(x5.b(a_) * num5 / 1000f + 0.001f));
						x5 = x4;
						i++;
						x4 = x5.c();
						num7++;
					}
				}
				else
				{
					x5 = x4;
					x4 = x5.c();
				}
				goto IL_744;
				IL_731:
				i++;
				x5 = x4;
				x4 = x5.c();
				goto IL_744;
			}
			if (num2 < agd.a() && agd.a(num2).a() == 32)
			{
				if (A_0 != null)
				{
					A_0.f(true);
				}
			}
			if (A_0 != null)
			{
				A_0.h(num9);
				A_0.l(x7);
				A_0.i(num8);
			}
			if (A_1 != null)
			{
				A_1.h(num9);
				A_1.l(x7);
				A_1.i(num8);
			}
			return null;
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x0010C698 File Offset: 0x0010B698
		internal static x5 a(Font A_0)
		{
			return x5.a(A_0.GetDefaultLeading(12f));
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x0010C6BC File Offset: 0x0010B6BC
		internal static x5 a(char[] A_0, Font A_1, x5 A_2)
		{
			float num = 0f;
			int i = 0;
			while (i < 1)
			{
				char c = A_0[i];
				if (c != ' ')
				{
					i++;
				}
				else
				{
					num += (float)A_1.GetGlyphWidth(A_0[i]);
					i++;
				}
			}
			return x5.a(num * x5.b(A_2) / 1000f + 0.001f);
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x0010C724 File Offset: 0x0010B724
		internal static bool a(char A_0, int A_1, int A_2)
		{
			if (A_0 <= ')')
			{
				if (A_0 != '"')
				{
					switch (A_0)
					{
					case '\'':
					case '(':
					case ')':
						break;
					default:
						goto IL_6A;
					}
				}
			}
			else
			{
				switch (A_0)
				{
				case '[':
				case ']':
					break;
				case '\\':
					goto IL_6A;
				default:
					switch (A_0)
					{
					case '{':
					case '}':
						break;
					case '|':
						goto IL_6A;
					default:
						goto IL_6A;
					}
					break;
				}
			}
			return A_2 == 0 && A_1 > 1;
			IL_6A:
			return false;
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x0010C7A4 File Offset: 0x0010B7A4
		internal static bool a(agd A_0, int A_1, int A_2)
		{
			bool flag = false;
			bool flag2 = false;
			if (A_1 < A_0.a())
			{
				char a_ = A_0.b(A_0.a(A_1).a());
				flag = n4.a(a_, A_1, A_2);
				while (!flag2 && flag)
				{
					A_1++;
					if (A_1 < A_0.a())
					{
						a_ = A_0.b(A_0.a(A_1).a());
						flag = n4.a(a_, A_1, A_2);
						if (!flag)
						{
							flag2 = true;
						}
					}
					else
					{
						flag2 = true;
					}
				}
			}
			return flag;
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x0010C844 File Offset: 0x0010B844
		internal static bool a(char A_0)
		{
			if (A_0 <= ')')
			{
				if (A_0 != '"')
				{
					switch (A_0)
					{
					case '\'':
					case '(':
					case ')':
						break;
					default:
						goto IL_54;
					}
				}
			}
			else
			{
				switch (A_0)
				{
				case '[':
				case ']':
					break;
				case '\\':
					goto IL_54;
				default:
					switch (A_0)
					{
					case '{':
					case '}':
						break;
					case '|':
						goto IL_54;
					default:
						goto IL_54;
					}
					break;
				}
			}
			return true;
			IL_54:
			return false;
		}
	}
}
