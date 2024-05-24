using System;
using System.Collections.Generic;
using System.Text;

namespace zz93
{
	// Token: 0x0200009A RID: 154
	internal class dh
	{
		// Token: 0x06000775 RID: 1909 RVA: 0x0006AB43 File Offset: 0x00069B43
		internal dh(byte[] A_0)
		{
			this.a(A_0);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0006AB64 File Offset: 0x00069B64
		internal string a(de A_0, c1 A_1)
		{
			string result;
			if (A_0.i())
			{
				result = this.b(A_0.b(), A_1);
			}
			else
			{
				result = this.a(A_0.b(), A_1);
			}
			return result;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0006ABA4 File Offset: 0x00069BA4
		private void a(byte[] A_0)
		{
			string @string = Encoding.ASCII.GetString(A_0);
			int num = @string.IndexOf("begincodespacerange");
			int num2 = @string.IndexOf("endcodespacerange");
			if (num != -1 && num2 != -1)
			{
				this.a(@string, num, num2);
			}
			int num3 = -1;
			int num4 = -1;
			do
			{
				num3 = @string.IndexOf("beginbfrange", num3 + 1);
				num4 = @string.IndexOf("endbfrange", num4 + 1);
				if (num3 != -1 && num4 != -1)
				{
					this.a(num3, num4, @string);
				}
			}
			while (num3 != -1);
			int num5 = -1;
			int num6 = -1;
			do
			{
				num5 = @string.IndexOf("beginbfchar", num5 + 1);
				num6 = @string.IndexOf("endbfchar", num6 + 1);
				if (num5 != -1 && num6 != -1)
				{
					this.b(num5, num6, @string);
				}
			}
			while (num5 != -1);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0006AC9C File Offset: 0x00069C9C
		private void a(string A_0, int A_1, int A_2)
		{
			if (this.b == null)
			{
				this.b = new List<string>();
			}
			string text = A_0.Substring(A_1 + 19, A_2 - (A_1 + 19));
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			foreach (string item in array)
			{
				this.b.Add(item);
			}
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0006AD24 File Offset: 0x00069D24
		private void b(int A_0, int A_1, string A_2)
		{
			string text = A_2.Substring(A_0 + 11, A_1 - (A_0 + 11) - 1);
			if (text != string.Empty)
			{
				text = text.Trim();
				List<string> list = new List<string>();
				list = this.a(text);
				if (this.a == null)
				{
					this.a = new long[65536];
				}
				int i = 0;
				while (i < list.Count)
				{
					list[i] = list[i].Trim();
					string[] array = this.e(list[i]);
					string text2 = array[0].Substring(1, array[0].Length - 2);
					if (text2.Length > 2)
					{
						if (i == list.Count - 1 && this.c)
						{
							if (text2[0] != '0' || text2[1] != '0')
							{
								this.c = false;
							}
						}
						else
						{
							this.c = false;
						}
					}
					if (array.Length >= 2)
					{
						int num = Convert.ToInt32(array[0].Substring(1, array[0].Length - 2), 16);
						long num2;
						if (array[1].StartsWith("<"))
						{
							string text3 = array[1].Remove(array[1].IndexOf('<'), 1).Remove(array[1].IndexOf('>') - 1, 1);
							if (text3.Length < 5)
							{
								num2 = Convert.ToInt64(text3, 16);
							}
							else
							{
								if (this.d == null)
								{
									this.d = new Dictionary<int, string>();
								}
								if (Convert.ToInt32(text3.Substring(0, 4), 16) > 55296)
								{
									goto IL_34F;
								}
								string text4 = Convert.ToInt32(text3.Substring(0, 4), 16).ToString() + Convert.ToInt32(text3.Substring(4, 4), 16).ToString();
								if (text3.Length > 8)
								{
									text4 += Convert.ToInt32(text3.Substring(8, 4), 16).ToString();
								}
								if (text3.Length > 13)
								{
									text4 += Convert.ToInt32(text3.Substring(12, 4), 16).ToString();
								}
								this.d.Add(num, text3);
								num2 = Convert.ToInt64(text4);
							}
						}
						else if (array[1].StartsWith("/") || array[1].StartsWith("("))
						{
							c0 c = new c0();
							if (array[1].StartsWith("("))
							{
								num2 = (long)c.b(array[1].Substring(1, array[1].LastIndexOf(")") - 1));
							}
							else
							{
								num2 = (long)c.b(array[1].Substring(1));
							}
						}
						else
						{
							num2 = Convert.ToInt64(array[1]);
						}
						this.a[num] = num2;
					}
					IL_34F:
					i++;
					continue;
					goto IL_34F;
				}
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0006B098 File Offset: 0x0006A098
		private void a(int A_0, int A_1, string A_2)
		{
			c0 c = null;
			if (this.a == null)
			{
				this.a = new long[65536];
			}
			string text = A_2.Substring(A_0 + 12, A_1 - (A_0 + 12));
			text = text.Trim();
			text = this.d(text);
			if (text != null)
			{
				string[] array = text.Split(new char[]
				{
					'\n'
				});
				if (array == null || array.Length == 1)
				{
					array = text.Split(new char[]
					{
						'\r'
					});
				}
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].Trim();
					string[] array2;
					if (array[i].Contains(" ") && !array[i].Contains("["))
					{
						array2 = array[i].Split(new char[]
						{
							' '
						});
					}
					else
					{
						array2 = new string[3];
						string text2 = array[i].Trim();
						string text3 = text2.Substring(0, 1);
						char value = ' ';
						if (text3 == "(")
						{
							value = ')';
						}
						else if (text3 == "<")
						{
							value = '>';
						}
						array2[0] = text2.Substring(0, text2.IndexOf(value) + 1);
						if (array2[0].Length > 4)
						{
							this.c = false;
						}
						int num = text2.IndexOf(value) + 1;
						array2[1] = text2.Substring(num, text2.IndexOf(value, num) + 1 - num);
						num = text2.IndexOf(value, text2.IndexOf(value) + 1) + 1;
						array2[2] = text2.Substring(num);
					}
					if (array2.Length > 1)
					{
						for (int j = 0; j < array2.Length; j++)
						{
							array2[j] = array2[j].Trim();
						}
						if (array2[0].Length > 4)
						{
							this.c = false;
						}
						string value2 = array2[0].Remove(array2[0].IndexOf('<'), 1).Remove(array2[0].IndexOf('>') - 1, 1);
						string value3 = array2[1].Remove(array2[1].IndexOf('<'), 1).Remove(array2[1].IndexOf('>') - 1, 1);
						int num2 = Convert.ToInt32(value2, 16);
						int num3 = Convert.ToInt32(value3, 16);
						array2[2] = array2[2].Trim();
						if (array2[2].StartsWith("["))
						{
							string[] array3;
							if (array2[2].Contains(" "))
							{
								array3 = array2[2].Remove(array2[2].IndexOf('['), 1).Remove(array2[2].IndexOf(']') - 1, 1).Trim().Split(new char[]
								{
									' '
								});
							}
							else
							{
								string text4 = array2[2].Remove(array2[2].IndexOf('['), 1).Remove(array2[2].IndexOf(']') - 1, 1);
								for (int k = 0; k < text4.Length; k++)
								{
									if (text4[k] == '>' && k != text4.Length - 1)
									{
										text4 = text4.Insert(k + 1, " ");
									}
								}
								array3 = text4.Split(new char[]
								{
									' '
								});
							}
							int num4 = 0;
							for (int j = num2; j <= num3; j++)
							{
								int num5 = j;
								string text5 = Convert.ToInt32(array3[num4].Substring(1, 4), 16).ToString();
								if (array3[num4].Length > 6)
								{
									if (Convert.ToInt32(array3[num4].Substring(1, 4), 16) < 55296)
									{
										if (this.d == null)
										{
											this.d = new Dictionary<int, string>();
										}
										if (array3[num4].Length > 6 && array3[num4].Length < 11)
										{
											text5 += Convert.ToInt32(array3[num4].Substring(5, 4), 16).ToString();
										}
										else if (array3[num4].Length > 10)
										{
											text5 += Convert.ToInt32(array3[num4].Substring(9, 4), 16).ToString();
										}
										this.d.Add(num5, text5);
									}
								}
								this.a[num5] = (long)Convert.ToInt32(text5);
								num4++;
							}
						}
						else if (array2[2].StartsWith("<"))
						{
							string value4 = array2[2].Remove(array2[2].IndexOf('<'), 1).Remove(array2[2].IndexOf('>') - 1, 1);
							long num6 = Convert.ToInt64(value4, 16);
							for (int j = num2; j <= num3; j++)
							{
								int num5 = j;
								this.a[num5] = num6;
								num6 += 1L;
							}
						}
						else if (array2[2].StartsWith("/") || array2[2].StartsWith("("))
						{
							c = ((c == null) ? new c0() : c);
							long num6 = (long)(array2[2].StartsWith("/") ? c.b(array2[2].Substring(1)) : c.b(array2[2].Substring(1, array2[2].LastIndexOf(")") - 1)));
							for (int j = num2; j <= num3; j++)
							{
								int num5 = j;
								this.a[num5] = num6;
							}
						}
						else
						{
							long num6 = Convert.ToInt64(array2[2]);
							for (int j = num2; j <= num3; j++)
							{
								int num5 = j;
								this.a[num5] = num6;
								num6 += 1L;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0006B744 File Offset: 0x0006A744
		private string[] e(string A_0)
		{
			string[] array = new string[]
			{
				A_0.Substring(0, A_0.IndexOf('>') + 1),
				A_0.Substring(A_0.IndexOf('>') + 1).Trim()
			};
			array[1] = array[1].Replace(" ", string.Empty);
			return array;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0006B7A0 File Offset: 0x0006A7A0
		private string d(string A_0)
		{
			int i = 0;
			string text = null;
			while (i < A_0.Length - 1)
			{
				char c = A_0[i];
				char c2 = ' ';
				if (c == '<')
				{
					c2 = '>';
				}
				else if (c == '[')
				{
					c2 = ']';
				}
				if (c2 != ' ')
				{
					while (A_0[i] != c2)
					{
						if (A_0[i] != '\n' && A_0[i] != '\r' && A_0[i] != ' ')
						{
							text += A_0[i];
						}
						i++;
					}
					if (A_0[i] == c2)
					{
						text += A_0[i];
						i++;
					}
				}
				else if (c == '/' && A_0[i + 1] == ' ' && A_0[i + 1] == '\r' && A_0[2] == '\n')
				{
					i++;
				}
				else
				{
					text += A_0[i];
					i++;
				}
			}
			return text;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0006B8F8 File Offset: 0x0006A8F8
		private string b(byte[] A_0, c1 A_1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = this.a();
			if (num > 1 && this.c)
			{
				num = 1;
			}
			switch (num)
			{
			case 1:
				if (this.d == null)
				{
					for (int i = 0; i < A_0.Length; i++)
					{
						if (this.a((int)A_0[i]) != null)
						{
							stringBuilder.Append((char)this.a((int)A_0[i]).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < A_0.Length; i++)
					{
						string a_ = A_0[i].ToString("X2");
						if (this.d.ContainsKey((int)A_0[i]))
						{
							stringBuilder.Append(this.c(a_));
						}
						else if (this.a((int)A_0[i]) != null)
						{
							stringBuilder.Append((char)this.a((int)A_0[i]).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				break;
			case 2:
				if (this.d == null)
				{
					for (int i = 0; i < A_0.Length; i += 2)
					{
						string a_;
						if (i + 1 < A_0.Length)
						{
							a_ = A_0[i].ToString("X2") + A_0[i + 1].ToString("X2");
						}
						else
						{
							a_ = A_0[i].ToString("X2");
						}
						int num3 = this.b(a_);
						if (this.a(num3) != null)
						{
							stringBuilder.Append((char)this.a(num3).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
								i--;
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < A_0.Length; i += 2)
					{
						string a_;
						if (i + 1 < A_0.Length)
						{
							a_ = A_0[i].ToString("X2") + A_0[i + 1].ToString("X2");
						}
						else
						{
							a_ = A_0[i].ToString("X2");
						}
						int num3 = this.b(a_);
						if (this.d.ContainsKey(num3))
						{
							stringBuilder.Append(this.c(a_));
						}
						else if (this.a(num3) != null)
						{
							stringBuilder.Append((char)this.a(num3).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
								i--;
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				break;
			case 3:
				if (this.d == null)
				{
					for (int i = 0; i < A_0.Length; i += 3)
					{
						string a_ = A_0[i].ToString("X2") + A_0[i + 1].ToString("X2") + A_0[i + 2].ToString("X2");
						int num3 = this.b(a_);
						if (this.a(num3) != null)
						{
							stringBuilder.Append((char)this.a(num3).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
								i -= 2;
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < A_0.Length; i += 3)
					{
						string a_ = A_0[i].ToString("X2") + A_0[i + 1].ToString("X2") + A_0[i + 2].ToString("X2");
						int num3 = this.b(a_);
						if (this.d.ContainsKey(num3))
						{
							stringBuilder.Append(this.c(a_));
						}
						else if (this.a(num3) != null)
						{
							stringBuilder.Append((char)this.a(num3).Value);
						}
						else
						{
							char? c = A_1.by(A_0[i]);
							int? num2 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num2 != null)
							{
								stringBuilder.Append(A_1.by(A_0[i]).Value);
								i -= 2;
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				break;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0006BFE8 File Offset: 0x0006AFE8
		private int a()
		{
			int num = 4;
			foreach (string text in this.b)
			{
				string text2;
				if (text.Contains(" "))
				{
					string[] array = text.Split(new char[]
					{
						' '
					});
					text2 = array[1].Remove(array[1].IndexOf('<'), 1).Remove(array[1].IndexOf('>') - 1, 1).Trim();
				}
				else
				{
					int num2 = text.IndexOf('<');
					num2 = text.IndexOf('>');
					text2 = text.Substring(num2 + 2, text.Length - num2 - 3);
				}
				if (text2.Length / 2 < num)
				{
					num = text2.Length / 2;
				}
			}
			return num;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0006C0F8 File Offset: 0x0006B0F8
		private string a(byte[] A_0, c1 A_1)
		{
			string a_ = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			int num = this.a();
			if (num > 1 && this.c)
			{
				num = 1;
			}
			if (this.d == null)
			{
				if (num != 1)
				{
					for (int i = 0; i < A_0.Length; i += 4)
					{
						a_ = this.a(A_0, i, 4);
						int num2 = this.b(a_);
						if (this.a(num2) != null)
						{
							stringBuilder.Append((char)this.a(num2).Value);
						}
						else
						{
							char? c = A_1.b2(a_);
							int? num3 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num3 != null)
							{
								stringBuilder.Append(A_1.b2(a_));
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < A_0.Length; i += 2)
					{
						a_ = this.a(A_0, i, 2);
						int num2 = this.b(a_);
						if (this.a(num2) != null)
						{
							stringBuilder.Append((char)this.a(num2).Value);
						}
						else
						{
							char? c = A_1.b2(a_);
							int? num3 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
							if (num3 != null)
							{
								stringBuilder.Append(A_1.b2(a_));
							}
							else
							{
								stringBuilder.Append(' ');
							}
						}
					}
				}
			}
			else if (num != 1)
			{
				for (int i = 0; i < A_0.Length; i += 4)
				{
					a_ = this.a(A_0, i, 4);
					int num2 = this.b(a_);
					if (this.d.ContainsKey(num2))
					{
						stringBuilder.Append(this.c(a_));
					}
					else if (this.a(num2) != null)
					{
						stringBuilder.Append((char)this.a(num2).Value);
					}
					else
					{
						char? c = A_1.b2(a_);
						int? num3 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
						if (num3 != null)
						{
							stringBuilder.Append(A_1.b2(a_));
						}
						else
						{
							stringBuilder.Append(' ');
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < A_0.Length; i += 2)
				{
					a_ = this.a(A_0, i, 2);
					int num2 = this.b(a_);
					if (this.d.ContainsKey(num2))
					{
						stringBuilder.Append(this.c(a_));
					}
					else if (this.a(num2) != null)
					{
						stringBuilder.Append((char)this.a(num2).Value);
					}
					else
					{
						char? c = A_1.b2(a_);
						int? num3 = (c != null) ? new int?((int)c.GetValueOrDefault()) : null;
						if (num3 != null)
						{
							stringBuilder.Append(A_1.b2(a_));
						}
						else
						{
							stringBuilder.Append(' ');
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0006C4D8 File Offset: 0x0006B4D8
		private int? a(int A_0)
		{
			int? result;
			if (this.a != null && this.a[A_0] != 0L)
			{
				result = new int?((int)this.a[A_0]);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0006C520 File Offset: 0x0006B520
		private string c(string A_0)
		{
			string text = null;
			string text2 = this.d[Convert.ToInt32(A_0, 16)];
			text += (char)Convert.ToInt32(text2.Substring(0, 4), 16);
			if (text2.Length > 4 && text2.Length < 9)
			{
				text += (char)Convert.ToInt32(text2.Substring(4), 16);
			}
			else if (text2.Length > 8 && text2.Length < 13)
			{
				text += (char)Convert.ToInt32(text2.Substring(4, 4), 16);
				text += (char)Convert.ToInt32(text2.Substring(8), 16);
			}
			return text;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0006C5F8 File Offset: 0x0006B5F8
		private string a(byte[] A_0, int A_1, int A_2)
		{
			int num = 0;
			char[] array = new char[A_2];
			for (int i = A_1; i < A_1 + A_2; i++)
			{
				array[num] = (char)A_0[i];
				num++;
			}
			return new string(array);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0006C63C File Offset: 0x0006B63C
		private int b(string A_0)
		{
			return Convert.ToInt32(A_0, 16);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0006C658 File Offset: 0x0006B658
		private List<string> a(string A_0)
		{
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] == '>')
				{
					num++;
					if (num % 2 == 0)
					{
						list.Add(A_0.Substring(num2, i + 1 - num2));
						num2 = i + 1;
						num3++;
					}
				}
			}
			return list;
		}

		// Token: 0x040003F0 RID: 1008
		private long[] a;

		// Token: 0x040003F1 RID: 1009
		private List<string> b = null;

		// Token: 0x040003F2 RID: 1010
		private bool c = true;

		// Token: 0x040003F3 RID: 1011
		private IDictionary<int, string> d;
	}
}
