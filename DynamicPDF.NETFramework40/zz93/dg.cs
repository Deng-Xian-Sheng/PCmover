using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000099 RID: 153
	internal class dg
	{
		// Token: 0x0600076A RID: 1898 RVA: 0x0006941C File Offset: 0x0006841C
		internal dg(int A_0)
		{
			this.a = new df[A_0];
			for (int i = 0; i < A_0; i++)
			{
				this.a[i] = new df();
			}
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00069480 File Offset: 0x00068480
		internal void a(string[] A_0, abj A_1, aba A_2, int A_3)
		{
			if (A_1 != null)
			{
				this.d = A_3;
				this.a(A_1, A_2, A_0);
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000694AC File Offset: 0x000684AC
		internal string a(int A_0, float A_1, float A_2, float A_3, float A_4)
		{
			float num = 0f;
			float num2 = 0f;
			float a_ = 0f;
			float a_2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float? num5 = null;
			float? num6 = null;
			StringBuilder stringBuilder = new StringBuilder();
			float num7 = 0f;
			float num8 = 12f;
			float num9 = 0f;
			string text = "";
			bool flag = false;
			bool flag2 = false;
			if (A_1 == -1f && A_3 == -1f && A_2 == -1f && A_4 == -1f)
			{
				flag = true;
				flag2 = true;
			}
			for (int i = 0; i < this.a[A_0].a().Count; i++)
			{
				string text2 = null;
				de de = this.a[A_0].a()[i];
				Font font = null;
				num5 = de.d();
				bool flag3 = de.c() == num2;
				float? num10 = de.d();
				float num11 = num;
				if ((flag3 & (num10.GetValueOrDefault() == num11 && num10 != null)) && !flag2)
				{
					num10 = num6;
					num11 = num3;
					num6 = ((num10 != null) ? new float?(num10.GetValueOrDefault() + num11) : null);
				}
				else
				{
					num6 = new float?(de.c());
				}
				float num12 = de.l();
				float num13 = de.m();
				float num14 = de.n();
				float num15 = 0f;
				float num16 = 0f;
				string text3 = de.g() + "-" + A_0.ToString();
				if (this.c[text3] == null)
				{
					if (de.o() != null)
					{
						text3 = de.g() + "-" + de.o() + A_0.ToString();
					}
				}
				if (this.c[text3] != null)
				{
					if (de.h() > 1f)
					{
						num8 = de.h();
					}
					if (this.b[this.c[text3]] != null)
					{
						font = ((c1)this.b[this.c[text3]]).b1();
						num15 = font.GetAscender(num8);
						num16 = font.GetDescender(num8);
						text2 = ((c1)this.b[this.c[text3]]).bx(de);
						if (text2 != null)
						{
							num4 = num3;
							num3 = font.GetTextWidth(text2, num8);
							if (num12 < 0f)
							{
								num3 -= num12 / 100f;
							}
							if (num13 != 0f)
							{
								if (text2.Length > 1)
								{
									num3 += num13 * (float)text2.Length;
								}
							}
							num7 = font.GetTextWidth(" ", num8);
							if (num14 != 0f)
							{
								for (int j = 0; j < text2.Length; j++)
								{
									if (text2[j] == ' ')
									{
										num3 += num14;
									}
								}
							}
						}
					}
				}
				if (!flag)
				{
					num10 = num6;
					bool flag4 = num10.GetValueOrDefault() >= A_1 && num10 != null;
					num10 = num6;
					bool flag5 = flag4 & (num10.GetValueOrDefault() <= A_3 && num10 != null);
					num10 = de.d();
					bool flag6 = flag5 & (num10.GetValueOrDefault() <= A_2 && num10 != null);
					num10 = de.d();
					if (flag6 & (num10.GetValueOrDefault() >= A_4 && num10 != null))
					{
						flag = true;
					}
					else
					{
						num10 = num6;
						bool flag7 = num10.GetValueOrDefault() < A_1 && num10 != null;
						num10 = num6;
						num11 = num3;
						num10 = ((num10 != null) ? new float?(num10.GetValueOrDefault() + num11) : null);
						bool flag8 = flag7 & (num10.GetValueOrDefault() > A_1 && num10 != null);
						num10 = de.d();
						bool flag9 = flag8 & (num10.GetValueOrDefault() <= A_2 && num10 != null);
						num10 = de.d();
						if (flag9 & (num10.GetValueOrDefault() >= A_4 && num10 != null))
						{
							flag = true;
						}
						else
						{
							bool flag10;
							if (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] != ' ' && stringBuilder[stringBuilder.Length - 1] != '\n' && stringBuilder[stringBuilder.Length - 1] != '\r')
							{
								num10 = de.d();
								num11 = num9;
								flag10 = (num10.GetValueOrDefault() != num11 || num10 == null);
							}
							else
							{
								flag10 = true;
							}
							if (!flag10)
							{
								flag = true;
							}
						}
					}
					num10 = de.d();
					num11 = num;
					if (num10.GetValueOrDefault() == num11 && num10 != null && de.c() != num2)
					{
						text = "";
					}
					num10 = de.d();
					bool flag11 = num10.GetValueOrDefault() <= A_2 && num10 != null;
					num10 = de.d();
					if ((flag11 & (num10.GetValueOrDefault() >= A_4 && num10 != null)) && !flag)
					{
						if (text == "" || de.c() != num2)
						{
							text = text2;
						}
						else if (text2.Contains(" ") && de.c() == num2)
						{
							int num17 = text2.LastIndexOf(" ");
							text = text2.Substring(num17 + 1);
						}
						else
						{
							text += text2;
						}
						if (de.l() < -num7)
						{
							text = "";
						}
					}
				}
				if (flag)
				{
					float? num18 = num6;
					if (stringBuilder.Length == 0)
					{
						if (!flag2)
						{
							if (text != "" && de.c() == num2)
							{
								text2 = text + text2;
								num10 = num18;
								num11 = font.GetTextWidth(text.ToCharArray(), num8);
								num18 = ((num10 != null) ? new float?(num10.GetValueOrDefault() - num11) : null);
							}
							text2 = this.a(de, text2, num18, A_1, A_3, A_2, A_4, num8, font);
							text = "";
							if (text2 != string.Empty)
							{
								if (num5 != null && num5.Value != 0f)
								{
									num9 = num5.Value;
								}
							}
						}
						stringBuilder.Append(text2);
						if (num7 != 0.001f && de.l() / 100f < -num7 && stringBuilder[stringBuilder.Length - 1] != ' ')
						{
							stringBuilder.Append(' ');
						}
					}
					else
					{
						if (num5 != null && num9 != num5.Value)
						{
							if (this.c[text3] != null && this.b[this.c[text3]] != null)
							{
								bool flag12 = this.a(num5.Value, text2, num9, a_, a_2, de, text3, ref stringBuilder);
								if (flag12)
								{
									num10 = num6;
									num11 = num4 + num2 + num7;
									bool flag13;
									if (num10.GetValueOrDefault() <= num11 || num10 == null)
									{
										num10 = num6;
										num11 = num2;
										flag13 = (num10.GetValueOrDefault() > num11 || num10 == null);
									}
									else
									{
										flag13 = false;
									}
									if (!flag13)
									{
										if (stringBuilder[stringBuilder.Length - 1] != ' ')
										{
											stringBuilder.Append(' ');
										}
									}
								}
								else if (text2 != "")
								{
									stringBuilder.Append(Environment.NewLine);
								}
							}
						}
						else
						{
							if (de.a() || num4 + num2 + num7 <= 0f)
							{
								if (!de.a())
								{
									goto IL_9F3;
								}
								num10 = num6;
								num11 = num2;
								if (num10.GetValueOrDefault() != num11 || num10 == null)
								{
									goto IL_9F3;
								}
								bool flag14 = !flag2;
								IL_9F4:
								if (!flag14)
								{
									num3 += num4;
									goto IL_A04;
								}
								goto IL_A04;
								IL_9F3:
								flag14 = true;
								goto IL_9F4;
							}
							num10 = num6;
							num11 = num4 + num2 + num7;
							bool flag15;
							if (num10.GetValueOrDefault() <= num11 || num10 == null)
							{
								num10 = num6;
								num11 = num2;
								flag15 = (num10.GetValueOrDefault() > num11 || num10 == null);
							}
							else
							{
								flag15 = false;
							}
							if (!flag15)
							{
								if (stringBuilder[stringBuilder.Length - 1] != ' ')
								{
									stringBuilder.Append(' ');
								}
							}
						}
						IL_A04:
						if ((stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] != '\n') || text2 != " ")
						{
							if (text2 == "\r" && (stringBuilder[stringBuilder.Length - 1] == '\n' || stringBuilder[stringBuilder.Length - 1] == '\t' || stringBuilder[stringBuilder.Length - 1] == ' '))
							{
								stringBuilder.Append('\t');
							}
							else
							{
								if (!flag2)
								{
									if (text != "" && de.c() == num2)
									{
										text2 = text + text2;
										num10 = num18;
										num11 = font.GetTextWidth(text.ToCharArray(), num8);
										num18 = ((num10 != null) ? new float?(num10.GetValueOrDefault() - num11) : null);
									}
									text2 = this.a(de, text2, num18, A_1, A_3, A_2, A_4, num8, font);
									text = "";
									if (text2 != string.Empty)
									{
										if (num5 != null && num5.Value != 0f)
										{
											num9 = num5.Value;
										}
									}
								}
								stringBuilder.Append(text2);
								if (num7 != 0.001f && de.l() / 100f < -num7 && stringBuilder[stringBuilder.Length - 1] != ' ')
								{
									stringBuilder.Append(' ');
								}
							}
						}
					}
				}
				if (this.c[text3] != null && this.b[this.c[text3]] != null)
				{
					if (text2 != string.Empty)
					{
						if (num5 != null && num5.Value != 0f)
						{
							num = num5.Value;
							if (flag2)
							{
								num9 = num5.Value;
							}
							else
							{
								flag = false;
							}
						}
						a_ = num15;
						a_2 = num16;
						num2 = de.c();
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0006A168 File Offset: 0x00069168
		internal df[] a()
		{
			return this.a;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0006A180 File Offset: 0x00069180
		private float? a(float? A_0, float A_1, float A_2, de A_3)
		{
			if (A_3.j())
			{
				if (A_3.e() != null)
				{
					float? num = A_0;
					bool flag;
					if (num.GetValueOrDefault() > 0f && num != null)
					{
						num = A_3.e();
						flag = (num.GetValueOrDefault() != -1f || num == null);
					}
					else
					{
						flag = true;
					}
					if (!flag)
					{
						num = A_0;
						A_0 = ((num != null) ? new float?(num.GetValueOrDefault() - A_2) : null);
					}
					else
					{
						num = A_0;
						float value = A_3.e().Value;
						A_0 = ((num != null) ? new float?(num.GetValueOrDefault() - value) : null);
					}
				}
				else
				{
					float? num = A_0;
					if (num.GetValueOrDefault() < 0f && num != null)
					{
						num = A_0;
						A_0 = ((num != null) ? new float?(num.GetValueOrDefault() - A_2) : null);
					}
					else
					{
						num = A_0;
						A_0 = ((num != null) ? new float?(num.GetValueOrDefault() + A_2) : null);
					}
				}
			}
			if (A_3.k())
			{
				float? num2;
				if (A_3.d() == null)
				{
					num2 = new float?(A_1);
				}
				else
				{
					float? num = A_0;
					num2 = ((num != null) ? new float?(num.GetValueOrDefault() + A_1) : null);
				}
				A_0 = num2;
			}
			return A_0;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0006A344 File Offset: 0x00069344
		private bool a(float A_0, string A_1, float A_2, float A_3, float A_4, de A_5, string A_6, ref StringBuilder A_7)
		{
			float fontSize = 12f;
			if (A_5.h() > 1f)
			{
				fontSize = A_5.h();
			}
			float ascender = ((c1)this.b[this.c[A_6]]).b1().GetAscender(fontSize);
			float descender = ((c1)this.b[this.c[A_6]]).b1().GetDescender(fontSize);
			float num = A_0 + ascender * 0.45f;
			bool result;
			if (A_0 == 0f || (int)A_0 == (int)A_2)
			{
				result = true;
			}
			else
			{
				if (A_7.Length != 0)
				{
					if (ascender > A_3 && (double)((int)(A_2 + descender)) <= Math.Round((double)num) && num - (A_2 + descender) <= ascender)
					{
						return true;
					}
					if (A_2 < A_0 && (int)(A_2 + A_3) >= (int)A_0 && (int)(A_0 + descender) <= (int)(A_2 + A_3))
					{
						return true;
					}
					if (A_2 > A_0 && ((int)(A_2 + A_4 / 2f) <= (int)A_0 || (int)(A_0 + ascender / 2f) >= (int)A_2))
					{
						return true;
					}
					if (A_1 != string.Empty || (A_1 == " " && !A_5.i()))
					{
						return false;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0006A4DC File Offset: 0x000694DC
		private void a(abj A_0, aba A_1, string[] A_2)
		{
			abk abk = A_0.l();
			string text = null;
			int num = 0;
			while (abk != null)
			{
				abj abj = null;
				if (abk.c().hy() == ag9.j)
				{
					abj = (abj)abk.c().h6();
					text = A_2[num];
					num++;
				}
				if (abj != null)
				{
					if (!this.b.ContainsKey(text))
					{
						ag0 ag = abj.n();
						if (ag == ag0.d)
						{
							goto IL_AD;
						}
						if (ag != ag0.i)
						{
							switch (ag)
							{
							case ag0.e:
							{
								dj dj = new dj();
								dj.b(abk);
								this.b.Add(text, dj);
								break;
							}
							case ag0.f:
								goto IL_AD;
							case ag0.h:
							{
								dl dl = new dl();
								dl.a(abk);
								this.b.Add(text, dl);
								break;
							}
							}
						}
						else
						{
							di di = new di();
							di.a(abk);
							this.b.Add(text, di);
						}
						goto IL_132;
						IL_AD:
						dk dk = new dk();
						dk.a(abk);
						this.b.Add(text, dk);
					}
					IL_132:
					if (!this.c.ContainsKey(abk.a().j9() + "-" + this.d.ToString()))
					{
						this.c.Add(abk.a().j9() + "-" + this.d.ToString(), text);
					}
				}
				abk = abk.d();
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0006A694 File Offset: 0x00069694
		internal void a(List<string> A_0, abj A_1, string A_2, int A_3)
		{
			abk abk = A_1.l();
			string text = null;
			int num = 0;
			while (abk != null)
			{
				abj abj = null;
				if (abk.c().hy() == ag9.j)
				{
					abj = (abj)abk.c().h6();
					text = A_0[num];
					num++;
				}
				if (abj != null)
				{
					if (!this.b.ContainsKey(text))
					{
						ag0 ag = abj.n();
						if (ag == ag0.d)
						{
							goto IL_B7;
						}
						if (ag != ag0.i)
						{
							switch (ag)
							{
							case ag0.e:
							{
								dj dj = new dj();
								dj.b(abk);
								this.b.Add(text, dj);
								break;
							}
							case ag0.f:
								goto IL_B7;
							case ag0.h:
							{
								dl dl = new dl();
								dl.a(abk);
								this.b.Add(text, dl);
								break;
							}
							}
						}
						else
						{
							di di = new di();
							di.a(abk);
							this.b.Add(text, di);
						}
						goto IL_13C;
						IL_B7:
						dk dk = new dk();
						dk.a(abk);
						this.b.Add(text, dk);
					}
					IL_13C:
					if (!this.c.ContainsKey(abk.a().j9() + "-" + A_2 + A_3.ToString()))
					{
						this.c.Add(abk.a().j9() + "-" + A_2 + A_3.ToString(), text);
					}
				}
				abk = abk.d();
			}
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0006A850 File Offset: 0x00069850
		internal Hashtable b()
		{
			return this.b;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0006A868 File Offset: 0x00069868
		internal Hashtable c()
		{
			return this.c;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0006A880 File Offset: 0x00069880
		private string a(de A_0, string A_1, float? A_2, float A_3, float A_4, float A_5, float A_6, float A_7, Font A_8)
		{
			bool flag = true;
			float? num = new float?(0f);
			float? num2;
			float num4;
			for (;;)
			{
				num2 = A_2;
				if (num2.GetValueOrDefault() >= A_3 || num2 == null || !flag)
				{
					break;
				}
				if (A_1.IndexOf(' ') >= 0)
				{
					int num3 = A_1.IndexOf(' ');
					string text = A_1.Substring(0, num3 + 1);
					num2 = A_2;
					num4 = A_8.GetTextWidth(text, A_7);
					num = ((num2 != null) ? new float?(num2.GetValueOrDefault() + num4) : null);
					num2 = num;
					if (num2.GetValueOrDefault() < A_3 && num2 != null)
					{
						A_1 = A_1.Substring(num3 + 1, A_1.Length - num3 - 1);
						num2 = A_2;
						num4 = A_8.GetTextWidth(text, A_7);
						A_2 = ((num2 != null) ? new float?(num2.GetValueOrDefault() + num4) : null);
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			float num5 = A_8.GetTextWidth(A_1, A_7);
			num5 += -A_0.l() / 100f;
			flag = true;
			num2 = A_2;
			num4 = num5;
			num2 = ((num2 != null) ? new float?(num2.GetValueOrDefault() + num4) : null);
			if (num2.GetValueOrDefault() > A_4 && num2 != null)
			{
				string text = "";
				for (;;)
				{
					num2 = A_2;
					if ((num2.GetValueOrDefault() >= A_4 || num2 == null) && !flag)
					{
						break;
					}
					if (A_1.IndexOf(' ') >= 0)
					{
						int num3 = A_1.IndexOf(' ');
						text += A_1.Substring(0, num3 + 1);
						string text2 = A_1.Substring(0, num3 + 1);
						A_1 = A_1.Substring(num3 + 1, A_1.Length - num3 - 1);
						num2 = A_2;
						num4 = A_8.GetTextWidth(text2, A_7);
						A_2 = ((num2 != null) ? new float?(num2.GetValueOrDefault() + num4) : null);
						flag = false;
					}
					else
					{
						text += A_1;
						A_1 = "";
						num2 = A_2;
						num4 = A_8.GetTextWidth(text, A_7);
						A_2 = ((num2 != null) ? new float?(num2.GetValueOrDefault() + num4) : null);
						flag = false;
					}
				}
				A_1 = text;
			}
			return A_1;
		}

		// Token: 0x040003EC RID: 1004
		private df[] a = null;

		// Token: 0x040003ED RID: 1005
		private Hashtable b = new Hashtable();

		// Token: 0x040003EE RID: 1006
		private Hashtable c = new Hashtable();

		// Token: 0x040003EF RID: 1007
		private int d = 0;
	}
}
