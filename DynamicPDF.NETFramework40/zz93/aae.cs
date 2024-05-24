using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020003EF RID: 1007
	internal class aae
	{
		// Token: 0x06002A0F RID: 10767 RVA: 0x00187629 File Offset: 0x00186629
		private aae()
		{
		}

		// Token: 0x06002A10 RID: 10768 RVA: 0x00187634 File Offset: 0x00186634
		static aae()
		{
			aae.a = new DateTime(1899, 12, 31).AddDays((double)((Document.ProductBuild - 10003) / 7 + 39499));
			try
			{
				aae.j[0] = (byte)(Document.ProductVersion.Major & 63);
				aae.j[1] = (byte)(Document.ProductVersion.Minor & 63);
				aae.j[2] = (byte)Document.ProductVersion.Revision;
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				if (appSettings != null)
				{
					string[] allKeys = appSettings.AllKeys;
					for (int i = 0; i < allKeys.Length; i++)
					{
						if (allKeys[i].Length > 25 && allKeys[i].ToLower().Substring(0, 26) == "dynamicpdf.subscriptionkey")
						{
							string text = appSettings[allKeys[i]];
							if (text != null && text != string.Empty)
							{
								aae.g(text);
							}
						}
						if (allKeys[i].Length > 14 && allKeys[i].ToLower().Substring(0, 15) == "cete.licensekey")
						{
							string text2 = appSettings[allKeys[i]];
							if (text2 != null && text2 != string.Empty)
							{
								string[] array = text2.Split(new char[]
								{
									':'
								});
								for (int j = 0; j < array.Length; j++)
								{
									aae.e(array[j]);
								}
							}
						}
						if (allKeys[i].Length > 24 && allKeys[i].ToLower().Substring(0, 25) == "cete.evaluationlicensekey")
						{
							string text3 = appSettings[allKeys[i]];
							if (text3 != null && text3 != string.Empty)
							{
								string[] array = text3.Split(new char[]
								{
									':'
								});
								for (int j = 0; j < array.Length; j++)
								{
									aae.e(array[j]);
								}
							}
						}
						if (allKeys[i].Length > 20 && allKeys[i].ToLower().Substring(0, 21) == "cete.serverlicensekey")
						{
							string text4 = appSettings[allKeys[i]];
							if (text4 != null && text4 != string.Empty)
							{
								string[] array = text4.Split(new char[]
								{
									':'
								});
								for (int j = 0; j < array.Length; j++)
								{
									aae.e(array[j]);
								}
							}
						}
						if (allKeys[i].Length > 23 && allKeys[i].ToLower().Substring(0, 24) == "cete.developerlicensekey")
						{
							string text5 = appSettings[allKeys[i]];
							if (text5 != null && text5 != string.Empty)
							{
								string[] array = text5.Split(new char[]
								{
									':'
								});
								for (int j = 0; j < array.Length; j++)
								{
									aae.e(array[j]);
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			aae.a();
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x00187A50 File Offset: 0x00186A50
		internal static bool g(string A_0)
		{
			A_0 = A_0.Trim();
			if (A_0.Length != 110)
			{
				throw new GeneratorException("Invalid subscription key format");
			}
			byte[] bytes = Encoding.ASCII.GetBytes(A_0.Substring(0, 24));
			byte[] a_ = Convert.FromBase64String(A_0.Substring(24, 86) + "==");
			bool result;
			if (aag.d().a(bytes, a_))
			{
				int year = Convert.ToInt32(A_0.Substring(14, 2)) + 2000;
				int month = Convert.ToInt32(A_0.Substring(16, 2));
				int day = Convert.ToInt32(A_0.Substring(18, 2));
				DateTime dateTime = new DateTime(year, month, day);
				if (A_0[6] == 'E' && A_0[7] == 'V' && A_0[8] == 'A' && A_0[9] == 'L' && char.IsDigit(A_0[10]) && char.IsDigit(A_0[11]))
				{
					aae.c++;
					int num = (int)((A_0[10] - '0') * '\n' + A_0[11] - '0');
					DateTime t = dateTime.AddDays((double)(num + 1));
					if (DateTime.Now < dateTime || DateTime.Now > t)
					{
						return false;
					}
					aae.f(A_0.Substring(20, 4));
				}
				else
				{
					aae.d++;
					if (dateTime < aae.a)
					{
						return false;
					}
					aae.f(A_0.Substring(20, 4));
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x00187C18 File Offset: 0x00186C18
		internal static void f(string A_0)
		{
			byte[] array = Convert.FromBase64String(A_0);
			aae.b |= (int)(array[0] ^ 34);
		}

		// Token: 0x06002A13 RID: 10771 RVA: 0x00187C40 File Offset: 0x00186C40
		internal static bool e(string A_0)
		{
			A_0 = A_0.Trim();
			bool result;
			if (A_0.Length == 110)
			{
				result = aae.g(A_0);
			}
			else
			{
				if (A_0.Length != 100 && A_0.Length != 102)
				{
					throw new GeneratorException("Invalid license key format");
				}
				if (A_0[5] != 'N')
				{
					result = false;
				}
				else
				{
					char c = A_0[7];
					switch (c)
					{
					case 'D':
						aae.f++;
						result = aae.a(A_0);
						break;
					case 'E':
						aae.c++;
						result = aae.c(A_0);
						break;
					default:
						if (c != 'M')
						{
							if (c != 'S')
							{
								throw new GeneratorException("Invalid license key format");
							}
							aae.e++;
							result = aae.b(A_0);
						}
						else
						{
							aae.g++;
							result = aae.a(A_0);
						}
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x00187D38 File Offset: 0x00186D38
		private static bool d(string A_0)
		{
			string text = A_0.Substring(0, 3);
			if (text != null)
			{
				if (!(text == "GEN"))
				{
					if (!(text == "MER"))
					{
						if (!(text == "RPT"))
						{
							if (text == "DPS")
							{
								char c = A_0[6];
								if (c == 'E')
								{
									aae.b |= 127;
									return true;
								}
								if (c == 'P')
								{
									aae.b |= 45;
									return true;
								}
							}
						}
						else
						{
							char c = A_0[6];
							if (c == 'E')
							{
								aae.b |= 99;
								return true;
							}
							if (c == 'P')
							{
								aae.b |= 33;
								return true;
							}
						}
					}
					else
					{
						char c = A_0[6];
						if (c == 'E')
						{
							aae.b |= 31;
							return true;
						}
						if (c == 'P')
						{
							aae.b |= 13;
							return true;
						}
						if (c == 'S')
						{
							aae.b |= 4;
							return true;
						}
					}
				}
				else
				{
					char c = A_0[6];
					if (c == 'E')
					{
						aae.b |= 3;
						return true;
					}
					if (c == 'P')
					{
						aae.b |= 1;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x00187E9C File Offset: 0x00186E9C
		private static bool c(string A_0)
		{
			byte[] a_ = null;
			byte[] a_2 = null;
			try
			{
				int num = Convert.ToInt32(A_0.Substring(3, 2));
				if (num >= 10 && num < 20)
				{
					num *= 10;
				}
				if (num < 100)
				{
					return false;
				}
				a_ = Encoding.ASCII.GetBytes(A_0.Substring(0, 14));
				a_2 = Convert.FromBase64String(A_0.Substring(14, 86) + "==");
			}
			catch (Exception)
			{
				throw new GeneratorException("Invalid Evaluation license key format");
			}
			return aag.c().a(a_, a_2) && aae.a(a_) && aae.d(A_0);
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x00187F6C File Offset: 0x00186F6C
		private static bool b(string A_0)
		{
			byte[] a_ = null;
			byte[] a_2 = null;
			if (A_0.Length == 100)
			{
				string str;
				try
				{
					str = Environment.MachineName.ToUpper();
				}
				catch (Exception)
				{
					str = "NAMENOTAVAILABLE";
				}
				try
				{
					int num = Convert.ToInt32(A_0.Substring(3, 2));
					if (num >= 10 && num < 20)
					{
						num *= 10;
					}
					if (num < 100)
					{
						return false;
					}
					a_ = Encoding.ASCII.GetBytes(A_0.Substring(0, 14) + str);
					a_2 = Convert.FromBase64String(A_0.Substring(14, 86) + "==");
				}
				catch (Exception)
				{
					throw new GeneratorException("Invalid server license key format");
				}
			}
			else
			{
				if (A_0.Length != 102 || A_0[15] != '$' || A_0[14] != 'V')
				{
					return false;
				}
				try
				{
					int num = Convert.ToInt32(A_0.Substring(3, 2));
					if (num >= 10 && num < 20)
					{
						num *= 10;
					}
					if (num < 100)
					{
						return false;
					}
					a_ = Encoding.ASCII.GetBytes(A_0.Substring(0, 16));
					a_2 = Convert.FromBase64String(A_0.Substring(16, 86) + "==");
				}
				catch (Exception)
				{
					throw new GeneratorException("Invalid server license key format");
				}
			}
			return aag.b().a(a_, a_2) && aae.d(A_0);
		}

		// Token: 0x06002A17 RID: 10775 RVA: 0x00188148 File Offset: 0x00187148
		private static bool a(string A_0)
		{
			byte[] a_ = null;
			byte[] a_2 = null;
			try
			{
				int num = Convert.ToInt32(A_0.Substring(3, 2));
				if (num >= 10 && num < 20)
				{
					num *= 10;
				}
				if (num < 100)
				{
					return false;
				}
				a_ = Encoding.ASCII.GetBytes(A_0.Substring(0, 14));
				a_2 = Convert.FromBase64String(A_0.Substring(14, 86) + "==");
			}
			catch (Exception)
			{
				throw new GeneratorException("Invalid Developer license key format");
			}
			return aag.a().a(a_, a_2) && aae.d(A_0);
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x0018820C File Offset: 0x0018720C
		private static bool a(byte[] A_0)
		{
			int num = (int)(A_0[8] % 16);
			num = (num << 4 | (int)(A_0[9] % 16));
			num = (num << 4 | (int)(A_0[10] % 16));
			num = (num << 4 | (int)(A_0[11] % 16));
			num = (num << 4 | (int)(A_0[12] % 16));
			num = (num << 4 | (int)(A_0[13] % 16));
			DateTime t = aae.i.AddDays((double)(num / 457));
			DateTime t2 = t.AddDays((double)(num % 457));
			DateTime now = DateTime.Now;
			return t < now && now < t2;
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x001882A0 File Offset: 0x001872A0
		private static void a()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (aae.h != assemblies.Length)
			{
				foreach (Assembly assembly in assemblies)
				{
					if (!assembly.IsDynamic)
					{
						if (!(assembly is AssemblyBuilder))
						{
							try
							{
								foreach (string text in assembly.GetManifestResourceNames())
								{
									if (text.ToLower().EndsWith(".csl3") || text.ToLower().EndsWith(".csl4"))
									{
										using (Stream manifestResourceStream = assembly.GetManifestResourceStream(text))
										{
											if (manifestResourceStream != null)
											{
												using (StreamReader streamReader = new StreamReader(manifestResourceStream))
												{
													manifestResourceStream.Position = 0L;
													string a_ = streamReader.ReadToEnd();
													int num = 0;
													string a_2 = aae.c(a_, ref num);
													while (a_2 != string.Empty)
													{
														aae.e(a_2);
														a_2 = aae.c(a_, ref num);
													}
												}
											}
										}
									}
								}
							}
							catch
							{
							}
						}
					}
				}
				aae.h = assemblies.Length;
			}
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x00188460 File Offset: 0x00187460
		private static string c(string A_0, ref int A_1)
		{
			aae.b(A_0, ref A_1);
			string result;
			if (A_1 + 100 <= A_0.Length)
			{
				if (A_1 + 110 <= A_0.Length && A_0[A_1 + 100] > ' ')
				{
					string text = A_0.Substring(A_1, 110);
					A_1 += 110;
					result = text;
				}
				else
				{
					string text = A_0.Substring(A_1, 100);
					A_1 += 100;
					result = text;
				}
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x001884E8 File Offset: 0x001874E8
		private static void b(string A_0, ref int A_1)
		{
			while (A_1 < A_0.Length && (A_0[A_1] <= ' ' || A_0[A_1] == ':'))
			{
				A_1++;
			}
			if (A_1 < A_0.Length && (A_0[A_1] == '\'' || A_0[A_1] == '/'))
			{
				aae.a(A_0, ref A_1);
			}
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x00188568 File Offset: 0x00187568
		private static void a(string A_0, ref int A_1)
		{
			while (A_1 < A_0.Length && A_0[A_1] != '\r')
			{
				A_1++;
			}
			aae.b(A_0, ref A_1);
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x001885A8 File Offset: 0x001875A8
		internal static bool c(int A_0)
		{
			aae.a();
			return (A_0 & aae.b) == A_0;
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x001885CC File Offset: 0x001875CC
		internal static string b(int A_0)
		{
			int num = aae.c + aae.e + aae.f + aae.g;
			byte[] array = new byte[12];
			aae.j.CopyTo(array, 0);
			if (num > 254)
			{
				array[3] = byte.MaxValue;
			}
			else
			{
				array[3] = (byte)num;
			}
			array[4] = (byte)(aae.b >> 24 & 255);
			array[5] = (byte)(aae.b >> 16 & 255);
			array[6] = (byte)(aae.b >> 8 & 255);
			array[7] = (byte)(aae.b & 255);
			array[8] = (byte)(A_0 >> 24 & 255);
			array[9] = (byte)(A_0 >> 16 & 255);
			array[10] = (byte)(A_0 >> 8 & 255);
			array[11] = (byte)(A_0 & 255);
			for (int i = 0; i < 12; i++)
			{
				byte[] array2 = array;
				int num2 = i;
				array2[num2] ^= aae.k[i];
			}
			return Convert.ToBase64String(array).Replace("+", "(").Replace("/", ")");
		}

		// Token: 0x06002A1F RID: 10783 RVA: 0x001886F8 File Offset: 0x001876F8
		internal static string a(int A_0)
		{
			string text = "[" + A_0.ToString() + ":" + aae.b.ToString();
			if (aae.d > 0)
			{
				text = text + ":u" + aae.d.ToString();
			}
			if (aae.c > 0)
			{
				text = text + ":e" + aae.c.ToString();
			}
			if (aae.e > 0)
			{
				text = text + ":s" + aae.e.ToString();
			}
			if (aae.f > 0)
			{
				text = text + ":d" + aae.f.ToString();
			}
			if (aae.g > 0)
			{
				text = text + ":m" + aae.g.ToString();
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				":v",
				Document.ProductVersion.Major.ToString(),
				".",
				Document.ProductVersion.Minor.ToString()
			});
			return text + "]";
		}

		// Token: 0x04001349 RID: 4937
		private static DateTime a;

		// Token: 0x0400134A RID: 4938
		private static int b = 0;

		// Token: 0x0400134B RID: 4939
		private static int c = 0;

		// Token: 0x0400134C RID: 4940
		private static int d = 0;

		// Token: 0x0400134D RID: 4941
		private static int e = 0;

		// Token: 0x0400134E RID: 4942
		private static int f = 0;

		// Token: 0x0400134F RID: 4943
		private static int g = 0;

		// Token: 0x04001350 RID: 4944
		private static int h = 0;

		// Token: 0x04001351 RID: 4945
		private static DateTime i = new DateTime(2000, 1, 1, 0, 0, 0);

		// Token: 0x04001352 RID: 4946
		private static byte[] j = new byte[3];

		// Token: 0x04001353 RID: 4947
		private static byte[] k = new byte[]
		{
			72,
			225,
			13,
			115,
			98,
			43,
			196,
			87,
			180,
			156,
			138,
			219
		};
	}
}
