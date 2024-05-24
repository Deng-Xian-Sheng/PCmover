using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000095 RID: 149
	internal class dc
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x0006237E File Offset: 0x0006137E
		internal dc(string A_0, string A_1, afj A_2)
		{
			this.a = A_0;
			this.a(A_1, A_2);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000623B4 File Offset: 0x000613B4
		private void a(string A_0, afj A_1)
		{
			if (this.a != "Identity-H" && this.a != "Identity-V")
			{
				byte[] bytes;
				if (A_1 == null)
				{
					if (char.IsNumber(this.a[0]))
					{
						this.a = "_" + this.a;
					}
					bytes = (byte[])Document.a.GetObject(this.a.Replace('-', '_'));
				}
				else
				{
					bytes = A_1.j4();
				}
				string @string = Encoding.ASCII.GetString(bytes);
				int num = @string.IndexOf("usecmap");
				string text = null;
				if (num != -1)
				{
					string[] array = @string.Split(new char[]
					{
						'\n'
					});
					foreach (string text2 in array)
					{
						if (text2.EndsWith("usecmap"))
						{
							text = text2.Substring(1, text2.IndexOf(" ") - 1).Trim();
							if (char.IsNumber(text[0]))
							{
								text = "_" + text;
							}
							break;
						}
					}
					byte[] array3 = (byte[])Document.a.GetObject(text.Replace('-', '_'));
					if (array3.Length > 1)
					{
						string string2 = Encoding.ASCII.GetString(array3);
						this.c(string2);
					}
				}
				this.c(@string);
			}
			this.b(A_0);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00062578 File Offset: 0x00061578
		private void c(string A_0)
		{
			int num = A_0.IndexOf("begincodespacerange");
			int num2 = A_0.IndexOf("endcodespacerange");
			if (num != -1 && num2 != -1)
			{
				this.b(A_0, num, num2);
			}
			int num3 = A_0.IndexOf("beginnotdefrange");
			int num4 = A_0.IndexOf("endnotdefrange");
			if (num3 != -1 && num4 != -1)
			{
				this.a(A_0, num3, num4);
			}
			int num5 = -1;
			int num6 = -1;
			do
			{
				num5 = A_0.IndexOf("begincidrange", num5 + 1);
				num6 = A_0.IndexOf("endcidrange", num6 + 1);
				if (num5 != -1 && num6 != -1)
				{
					this.c(num5, num6, A_0);
				}
			}
			while (num5 != -1);
			int num7 = -1;
			int num8 = -1;
			do
			{
				num7 = A_0.IndexOf("begincidchar", num7 + 1);
				num8 = A_0.IndexOf("endcidchar", num8 + 1);
				if (num7 != -1 && num8 != -1)
				{
					this.d(num7, num8, A_0);
				}
			}
			while (num7 != -1);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000626A4 File Offset: 0x000616A4
		private void b(string A_0)
		{
			if (char.IsNumber(A_0[0]))
			{
				A_0 = "_" + A_0;
			}
			string text = A_0 + "-UCS2";
			if (!A_0.EndsWith("Identity"))
			{
				byte[] array = (byte[])Document.a.GetObject(text.Replace('-', '_'));
				if (array.Length > 1)
				{
					string @string = Encoding.ASCII.GetString(array);
					int num = @string.IndexOf("begincodespacerange");
					int num2 = @string.IndexOf("endcodespacerange");
					if (num != -1 && num2 != -1)
					{
						if (this.f == null)
						{
							this.f = new List<string>();
						}
						string text2 = @string.Substring(num + 19, num2 - (num + 19) - 1);
						text2 = text2.Trim();
						string[] array2 = text2.Split(new char[]
						{
							'\n'
						});
						foreach (string item in array2)
						{
							this.f.Add(item);
						}
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
			}
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000628A0 File Offset: 0x000618A0
		private void b(string A_0, int A_1, int A_2)
		{
			if (this.e == null)
			{
				this.e = new List<string>();
			}
			string text = A_0.Substring(A_1 + 19, A_2 - (A_1 + 19) - 1);
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			foreach (string text2 in array)
			{
				this.e.Add(text2.Trim());
			}
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x00062930 File Offset: 0x00061930
		private void a(string A_0, int A_1, int A_2)
		{
			if (this.d == null)
			{
				this.d = new List<string>();
			}
			string text = A_0.Substring(A_1 + 16, A_2 - (A_1 + 16) - 1);
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			foreach (string text2 in array)
			{
				this.d.Add(text2.Trim());
			}
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x000629C0 File Offset: 0x000619C0
		private void d(int A_0, int A_1, string A_2)
		{
			string text = A_2.Substring(A_0 + 12, A_1 - (A_0 + 12) - 1);
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			if (this.b == null)
			{
				this.b = new long[65536];
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
				string[] array2 = array[i].Split(new char[]
				{
					' '
				});
				if (array2.Length >= 2)
				{
					long num = (long)((ulong)Convert.ToUInt32(array2[0].Substring(1, array2[0].Length - 2), 16));
					int num2;
					if (array2[1].StartsWith("<"))
					{
						string text2 = array2[1].Remove(array2[1].IndexOf('<'), 1).Remove(array2[1].IndexOf('>') - 1, 1);
						if (text2.Length < 5)
						{
							num2 = Convert.ToInt32(text2, 16);
						}
						else
						{
							string text3 = Convert.ToInt32(text2.Substring(0, 4), 16).ToString() + Convert.ToInt32(text2.Substring(4, 4), 16).ToString();
							if (text2.Length > 8 && text2.Length < 13)
							{
								text3 += Convert.ToInt32(text2.Substring(8, 4), 16).ToString();
							}
							num2 = Convert.ToInt32(text3);
						}
					}
					else if (array2[1].StartsWith("/") || array2[1].StartsWith("("))
					{
						c0 c = new c0();
						int num3;
						if (array2[1].StartsWith("("))
						{
							num3 = c.b(array2[1].Substring(1, array2[1].LastIndexOf(")") - 1));
						}
						else
						{
							num3 = c.b(array2[1].Substring(1));
						}
						num2 = ((num3 != -1) ? num3 : 0);
					}
					else
					{
						num2 = Convert.ToInt32(array2[1]);
					}
					this.g.Add(num, num2);
				}
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00062C44 File Offset: 0x00061C44
		private void c(int A_0, int A_1, string A_2)
		{
			c0 c = null;
			if (this.b == null)
			{
				this.b = new long[65536];
			}
			string text = A_2.Substring(A_0 + 13, A_1 - (A_0 + 13) - 1).Trim();
			text = text.Trim();
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
				while (array[i].IndexOf("  ") != -1)
				{
					array[i] = array[i].Replace("  ", " ");
				}
				string[] array2;
				if (array[i].Contains(" "))
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
					string value2 = array2[0].Remove(array2[0].IndexOf('<'), 1).Remove(array2[0].IndexOf('>') - 1, 1);
					string value3 = array2[1].Remove(array2[1].IndexOf('<'), 1).Remove(array2[1].IndexOf('>') - 1, 1);
					long num2 = (long)((ulong)Convert.ToUInt32(value2, 16));
					long num3 = (long)((ulong)Convert.ToUInt32(value3, 16));
					array2[2] = array2[2].Trim();
					if (array2[2].StartsWith("["))
					{
						string[] array3 = array2[2].Remove(array2[2].IndexOf('['), 1).Remove(array2[2].IndexOf(']') - 1, 1).Split(new char[]
						{
							' '
						});
						for (long num4 = num2; num4 <= num3; num4 += 1L)
						{
							long num5 = num4;
							checked
							{
								int num6;
								if (array3[(int)((IntPtr)num4)].Length > 10)
								{
									num6 = Convert.ToInt32(Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(1, 4), 16).ToString() + Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(5, 4), 16).ToString() + Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(9, 4), 16).ToString());
								}
								else if (array3[(int)((IntPtr)num4)].Length > 6)
								{
									num6 = Convert.ToInt32(Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(1, 4), 16).ToString() + Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(5, 4), 16).ToString());
								}
								else
								{
									num6 = Convert.ToInt32(array3[(int)((IntPtr)num4)].Substring(1, 4), 16);
								}
								this.g.Add(num5, num6);
							}
						}
					}
					else if (array2[2].StartsWith("<"))
					{
						string value4 = array2[2].Remove(array2[2].IndexOf('<'), 1).Remove(array2[2].IndexOf('>') - 1, 1);
						int num6 = Convert.ToInt32(value4, 16);
						for (long num4 = num2; num4 <= num3; num4 += 1L)
						{
							long num5 = num4;
							this.g.Add(num5, num6);
							num6++;
						}
					}
					else if (array2[2].StartsWith("/") || array2[2].StartsWith("("))
					{
						c = ((c == null) ? new c0() : c);
						int num7 = array2[2].StartsWith("/") ? c.b(array2[2].Substring(1)) : c.b(array2[2].Substring(1, array2[2].LastIndexOf(")") - 1));
						int num6 = (num7 != -1) ? num7 : 0;
						for (long num4 = num2; num4 <= num3; num4 += 1L)
						{
							long num5 = num4;
							this.g.Add(num5, num6);
						}
					}
					else
					{
						int num6 = Convert.ToInt32(array2[2]);
						for (long num4 = num2; num4 <= num3; num4 += 1L)
						{
							long num5 = num4;
							if (this.g.ContainsKey(num5))
							{
								this.g.Remove(num5);
							}
							this.g.Add(num5, num6);
							num6++;
						}
					}
				}
			}
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00063248 File Offset: 0x00062248
		private void b(int A_0, int A_1, string A_2)
		{
			string text = A_2.Substring(A_0 + 11, A_1 - (A_0 + 11) - 1);
			text = text.Trim();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			if (this.c == null)
			{
				this.c = new long[65536];
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
				string[] array2 = array[i].Split(new char[]
				{
					' '
				});
				string[] array3 = new string[array2.Length];
				int num = 0;
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] != "")
					{
						array3[num] = array2[j];
						num++;
					}
				}
				Array.Resize<string>(ref array3, num);
				if (array3.Length >= 2)
				{
					int num2 = Convert.ToInt32(array3[0].Substring(1, array3[0].Length - 2), 16);
					long num3;
					if (array3[1].StartsWith("<"))
					{
						string text2 = array3[1].Remove(array3[1].IndexOf('<'), 1).Remove(array3[1].IndexOf('>') - 1, 1);
						if (text2.Length < 5)
						{
							num3 = (long)Convert.ToInt32(text2, 16);
						}
						else
						{
							string text3 = Convert.ToInt32(text2.Substring(0, 4), 16).ToString() + Convert.ToInt32(text2.Substring(4, 4), 16).ToString();
							if (text2.Length > 8 && text2.Length < 13)
							{
								text3 += Convert.ToInt32(text2.Substring(8, 4), 16).ToString();
							}
							num3 = Convert.ToInt64(text3);
						}
					}
					else if (array3[1].StartsWith("/") || array3[1].StartsWith("("))
					{
						c0 c = new c0();
						if (array3[1].StartsWith("("))
						{
							num3 = (long)c.b(array3[1].Substring(1, array3[1].LastIndexOf(")") - 1));
						}
						else
						{
							num3 = (long)c.b(array3[1].Substring(1));
						}
					}
					else
					{
						num3 = (long)Convert.ToInt32(array3[1]);
					}
					this.c[num2] = num3;
				}
			}
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00063510 File Offset: 0x00062510
		private void a(int A_0, int A_1, string A_2)
		{
			c0 c = null;
			if (this.c == null)
			{
				this.c = new long[65536];
			}
			string text = A_2.Substring(A_0 + 12, A_1 - (A_0 + 12) - 1);
			text = text.Trim();
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
				string[] array2;
				if (array[i].Contains(" "))
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
					string value2 = array2[0].Remove(array2[0].IndexOf('<'), 1).Remove(array2[0].IndexOf('>') - 1, 1);
					string value3 = array2[1].Remove(array2[1].IndexOf('<'), 1).Remove(array2[1].IndexOf('>') - 1, 1);
					int num2 = Convert.ToInt32(value2, 16);
					int num3 = Convert.ToInt32(value3, 16);
					array2[2] = array2[2].Trim();
					if (array2[2].StartsWith("["))
					{
						string[] array3 = array2[2].Remove(array2[2].IndexOf('['), 1).Remove(array2[2].IndexOf(']') - 1, 1).Split(new char[]
						{
							' '
						});
						for (int j = num2; j <= num3; j++)
						{
							int num4 = j;
							long num5;
							if (array3[j].Length > 10)
							{
								num5 = Convert.ToInt64(Convert.ToInt32(array3[j].Substring(1, 4), 16).ToString() + Convert.ToInt32(array3[j].Substring(5, 4), 16).ToString() + Convert.ToInt32(array3[j].Substring(9, 4), 16).ToString());
							}
							else if (array3[j].Length > 6)
							{
								num5 = Convert.ToInt64(Convert.ToInt32(array3[j].Substring(1, 4), 16).ToString() + Convert.ToInt32(array3[j].Substring(5, 4), 16).ToString());
							}
							else
							{
								num5 = Convert.ToInt64(array3[j].Substring(1, 4), 16);
							}
							this.c[num4] = num5;
						}
					}
					else if (array2[2].StartsWith("<"))
					{
						string value4 = array2[2].Remove(array2[2].IndexOf('<'), 1).Remove(array2[2].IndexOf('>') - 1, 1);
						long num5 = Convert.ToInt64(value4, 16);
						for (int j = num2; j <= num3; j++)
						{
							int num4 = j;
							this.c[num4] = num5;
							num5 += 1L;
						}
					}
					else if (array2[2].StartsWith("/") || array2[2].StartsWith("("))
					{
						c = ((c == null) ? new c0() : c);
						long num5 = (long)(array2[2].StartsWith("/") ? c.b(array2[2].Substring(1)) : c.b(array2[2].Substring(1, array2[2].LastIndexOf(")") - 1)));
						for (int j = num2; j <= num3; j++)
						{
							int num4 = j;
							this.c[num4] = num5;
						}
					}
					else
					{
						long num5 = (long)Convert.ToInt32(array2[2]);
						for (int j = num2; j <= num3; j++)
						{
							int num4 = j;
							this.c[num4] = num5;
							num5 += 1L;
						}
					}
				}
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00063A5C File Offset: 0x00062A5C
		private string b(de A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = A_0.b();
			for (int i = 0; i < array.Length; i += 4)
			{
				string value = this.a(array, i, 4);
				int num = Convert.ToInt32(value, 16);
				if (this.a((long)num) != null)
				{
					stringBuilder.Append((char)this.a((long)num).Value);
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00063AF4 File Offset: 0x00062AF4
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

		// Token: 0x0600073A RID: 1850 RVA: 0x00063B38 File Offset: 0x00062B38
		private long? a(long A_0)
		{
			checked
			{
				long? result;
				if (this.c != null && this.c[(int)((IntPtr)A_0)] != 0L)
				{
					result = new long?(this.c[(int)((IntPtr)A_0)]);
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00063B84 File Offset: 0x00062B84
		private List<int> a(byte[] A_0)
		{
			List<int> list = new List<int>();
			List<string> list2 = new List<string>();
			int num = 1;
			for (int i = 0; i < A_0.Length; i++)
			{
				list2.Add(A_0[i].ToString("X2"));
				bool flag = this.a(list2, num);
				if (flag)
				{
					string text = null;
					foreach (string str in list2)
					{
						text += str;
					}
					if (this.g[Convert.ToInt64(text, 16)] != null)
					{
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
					}
					else
					{
						for (int j = 0; j < list2.Count; j++)
						{
							if (this.g[Convert.ToInt64(text, 16)] != null)
							{
								list.Add((int)this.g[Convert.ToInt64(list2[j], 16)]);
							}
						}
					}
					list2 = new List<string>();
					num = 1;
				}
				else
				{
					num++;
				}
				if (num == 5)
				{
					int num2 = num - 1;
					if (this.d != null)
					{
						this.a(list2, ref num2);
					}
					else
					{
						num2 = -1;
					}
					string text = null;
					switch (num2)
					{
					case 2:
						for (int k = 0; k < list2.Count - 2; k++)
						{
							text += list2[k];
						}
						break;
					case 3:
						for (int k = 0; k < list2.Count - 1; k++)
						{
							text += list2[k];
						}
						break;
					case 4:
						foreach (string str in list2)
						{
							text += str;
						}
						break;
					}
					if (text != null)
					{
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
					}
					list2 = new List<string>();
					num = 1;
					i = ((num2 != 0) ? (i - (num - 1 - num2)) : (i - (num - 1 - 1)));
				}
			}
			return list;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00063E64 File Offset: 0x00062E64
		private List<int> a(string A_0)
		{
			List<int> list = new List<int>();
			List<string> list2 = new List<string>();
			int num = 1;
			for (int i = 0; i < A_0.Length; i += 2)
			{
				string item = A_0[i].ToString() + A_0[i + 1].ToString();
				list2.Add(item);
				bool flag = this.a(list2, num);
				if (flag)
				{
					string text = null;
					foreach (string str in list2)
					{
						text += str;
					}
					list.Add((int)this.g[Convert.ToInt64(text, 16)]);
					list2 = new List<string>();
					num = 1;
				}
				else
				{
					num++;
				}
				if (num == 5)
				{
					int num2 = num - 1;
					if (this.d != null)
					{
						this.a(list2, ref num2);
					}
					else
					{
						num2 = -1;
					}
					if (num2 == 0)
					{
						num2 = this.a();
					}
					string text = null;
					switch (num2)
					{
					case 0:
					case 1:
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
						break;
					case 2:
						for (int j = 0; j < list2.Count - 2; j++)
						{
							text += list2[j];
						}
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
						break;
					case 3:
						for (int j = 0; j < list2.Count - 1; j++)
						{
							text += list2[j];
						}
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
						break;
					case 4:
						foreach (string str in list2)
						{
							text += str;
						}
						list.Add((int)this.g[Convert.ToInt64(text, 16)]);
						break;
					}
					list2 = new List<string>();
					i = ((num2 != 0) ? (i - (num - 1 - num2) * 2) : (i - (num - 1 - 1) * 2));
					num = 1;
				}
			}
			return list;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00064154 File Offset: 0x00063154
		private int a()
		{
			int num = 4;
			foreach (string text in this.e)
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				string text2 = array[1].Remove(array[1].IndexOf('<'), 1).Remove(array[1].IndexOf('>') - 1, 1).Trim();
				if (text2.Length / 2 < num)
				{
					num = text2.Length / 2;
				}
			}
			return num;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00064214 File Offset: 0x00063214
		private bool a(List<string> A_0, int A_1)
		{
			foreach (string text in this.e)
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				if (array.Length > 2)
				{
					string[] array2 = new string[2];
					int num = 0;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] != "")
						{
							array2[num] = array[i];
							num++;
						}
					}
					array = array2;
				}
				string text2 = array[0].Remove(array[0].IndexOf('<'), 1).Remove(array[0].IndexOf('>') - 1, 1).Trim();
				string text3 = array[1].Remove(array[1].IndexOf('<'), 1).Remove(array[1].IndexOf('>') - 1, 1).Trim();
				switch (A_1)
				{
				case 1:
					if (text3.Length == 2)
					{
						int num2 = Convert.ToInt32(A_0[0], 16);
						if (num2 >= Convert.ToInt32(text2, 16) && num2 <= Convert.ToInt32(text3, 16))
						{
							return true;
						}
					}
					break;
				case 2:
					if (text3.Length == 4)
					{
						string value = text2.Substring(0, 2);
						string value2 = text2.Substring(2, 2);
						string value3 = text3.Substring(0, 2);
						string value4 = text3.Substring(2, 2);
						int num3 = Convert.ToInt32(A_0[0], 16);
						int num4 = Convert.ToInt32(A_0[1], 16);
						if (num3 >= Convert.ToInt32(value, 16) && num3 <= Convert.ToInt32(value3, 16) && num4 >= Convert.ToInt32(value2, 16) && num4 <= Convert.ToInt32(value4, 16))
						{
							return true;
						}
					}
					break;
				case 3:
					if (text3.Length == 6)
					{
						string value = text2.Substring(0, 2);
						string value2 = text2.Substring(2, 2);
						string value5 = text2.Substring(4, 2);
						string value3 = text3.Substring(0, 2);
						string value4 = text3.Substring(2, 2);
						string value6 = text3.Substring(4, 2);
						int num3 = Convert.ToInt32(A_0[0], 16);
						int num4 = Convert.ToInt32(A_0[1], 16);
						int num5 = Convert.ToInt32(A_0[2], 16);
						if (num3 >= Convert.ToInt32(value, 16) && num3 <= Convert.ToInt32(value3, 16) && num4 >= Convert.ToInt32(value2, 16) && num4 <= Convert.ToInt32(value4, 16) && num5 >= Convert.ToInt32(value5, 16) && num5 <= Convert.ToInt32(value6, 16))
						{
							return true;
						}
					}
					break;
				case 4:
					if (text3.Length == 8)
					{
						string value = text2.Substring(0, 2);
						string value2 = text2.Substring(2, 2);
						string value5 = text2.Substring(4, 2);
						string value7 = text2.Substring(6, 2);
						string value3 = text3.Substring(0, 2);
						string value4 = text3.Substring(2, 2);
						string value6 = text3.Substring(4, 2);
						string value8 = text3.Substring(6, 2);
						int num3 = Convert.ToInt32(A_0[0], 16);
						int num4 = Convert.ToInt32(A_0[1], 16);
						int num5 = Convert.ToInt32(A_0[2], 16);
						if (num3 >= Convert.ToInt32(value, 16) && num3 <= Convert.ToInt32(value3, 16) && num4 >= Convert.ToInt32(value2, 16) && num4 <= Convert.ToInt32(value4, 16) && num5 >= Convert.ToInt32(value5, 16) && num5 <= Convert.ToInt32(value6, 16) && num5 >= Convert.ToInt32(value7, 16) && num5 <= Convert.ToInt32(value8, 16))
						{
							return true;
						}
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00064684 File Offset: 0x00063684
		private bool a(List<string> A_0, ref int A_1)
		{
			foreach (string text in this.d)
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				string text2 = array[0].Remove(array[0].IndexOf('<'), 1).Remove(array[0].IndexOf('>') - 1, 1).Trim();
				string text3 = array[1].Remove(array[1].IndexOf('<'), 1).Remove(array[1].IndexOf('>') - 1, 1).Trim();
				switch (text2.Length)
				{
				case 2:
				{
					int num = Convert.ToInt32(A_0[0], 16);
					if (num >= Convert.ToInt32(text2, 16) && num <= Convert.ToInt32(text3, 16))
					{
						A_1 = 1;
						return true;
					}
					break;
				}
				case 4:
				{
					string value = text2.Substring(0, 2);
					string value2 = text2.Substring(2, 2);
					string value3 = text3.Substring(0, 2);
					string value4 = text3.Substring(2, 2);
					int num2 = Convert.ToInt32(A_0[0], 16);
					int num3 = Convert.ToInt32(A_0[1], 16);
					if (num2 >= Convert.ToInt32(value, 16) && num2 <= Convert.ToInt32(value3, 16) && num3 >= Convert.ToInt32(value2, 16) && num3 <= Convert.ToInt32(value4, 16))
					{
						A_1 = 2;
						return true;
					}
					break;
				}
				case 6:
				{
					string value = text2.Substring(0, 2);
					string value2 = text2.Substring(2, 2);
					string value5 = text2.Substring(4, 2);
					string value3 = text3.Substring(0, 2);
					string value4 = text3.Substring(2, 2);
					string value6 = text3.Substring(4, 2);
					int num2 = Convert.ToInt32(A_0[0], 16);
					int num3 = Convert.ToInt32(A_0[1], 16);
					int num4 = Convert.ToInt32(A_0[2], 16);
					if (num2 >= Convert.ToInt32(value, 16) && num2 <= Convert.ToInt32(value3, 16) && num3 >= Convert.ToInt32(value2, 16) && num3 <= Convert.ToInt32(value4, 16) && num4 >= Convert.ToInt32(value5, 16) && num4 <= Convert.ToInt32(value6, 16))
					{
						A_1 = 3;
						return true;
					}
					break;
				}
				case 8:
				{
					string value = text2.Substring(0, 2);
					string value2 = text2.Substring(2, 2);
					string value5 = text2.Substring(4, 2);
					string value7 = text2.Substring(6, 2);
					string value3 = text3.Substring(0, 2);
					string value4 = text3.Substring(2, 2);
					string value6 = text3.Substring(4, 2);
					string value8 = text3.Substring(6, 2);
					int num2 = Convert.ToInt32(A_0[0], 16);
					int num3 = Convert.ToInt32(A_0[1], 16);
					int num4 = Convert.ToInt32(A_0[2], 16);
					if (num2 > Convert.ToInt32(value, 16) && num2 < Convert.ToInt32(value3, 16) && num3 > Convert.ToInt32(value2, 16) && num3 < Convert.ToInt32(value4, 16) && num4 > Convert.ToInt32(value5, 16) && num4 < Convert.ToInt32(value6, 16) && num4 > Convert.ToInt32(value7, 16) && num4 < Convert.ToInt32(value8, 16))
					{
						A_1 = 4;
						return true;
					}
					break;
				}
				}
			}
			A_1 = 0;
			return false;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00064A58 File Offset: 0x00063A58
		private string a(List<int> A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int num in A_0)
			{
				if (this.a((long)num) != null)
				{
					stringBuilder.Append((char)this.a((long)num).Value);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00064AF0 File Offset: 0x00063AF0
		private string a(de A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = A_0.b();
			for (int i = 0; i < array.Length; i += 2)
			{
				string value = array[i].ToString("X2") + array[i + 1].ToString("X2");
				if (this.a(Convert.ToInt64(value, 16)) != null)
				{
					stringBuilder.Append((char)this.a((long)((ulong)Convert.ToUInt32(value, 16))).Value);
				}
				else
				{
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00064BA8 File Offset: 0x00063BA8
		internal string c(de A_0)
		{
			string result;
			if (this.a != "Identity-H" && this.a != "Identity-V")
			{
				if (A_0.i())
				{
					List<int> a_ = this.a(A_0.b());
					result = this.a(a_);
				}
				else
				{
					Encoding encoding = ae5.a(1252);
					List<int> a_ = this.a(encoding.GetString(A_0.b()));
					result = this.a(a_);
				}
			}
			else if (A_0.i())
			{
				result = this.a(A_0);
			}
			else
			{
				result = this.b(A_0);
			}
			return result;
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00064C58 File Offset: 0x00063C58
		internal char? d(string A_0)
		{
			long a_ = Convert.ToInt64(A_0, 16);
			char? result;
			if (this.a(a_) != null)
			{
				result = new char?((char)this.a(a_).Value);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x040003D4 RID: 980
		private string a = null;

		// Token: 0x040003D5 RID: 981
		private long[] b;

		// Token: 0x040003D6 RID: 982
		private long[] c = null;

		// Token: 0x040003D7 RID: 983
		private List<string> d;

		// Token: 0x040003D8 RID: 984
		private List<string> e;

		// Token: 0x040003D9 RID: 985
		private List<string> f;

		// Token: 0x040003DA RID: 986
		private Hashtable g = new Hashtable();
	}
}
