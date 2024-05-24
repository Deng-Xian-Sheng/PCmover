using System;
using System.Collections.Generic;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020002BC RID: 700
	internal abstract class r8
	{
		// Token: 0x06002025 RID: 8229 RVA: 0x0013C580 File Offset: 0x0013B580
		private static void a()
		{
			lock (r8.f)
			{
				if (r8.e)
				{
					string text = (GlobalSettings.PathToFontsResourceDirectory != null && GlobalSettings.PathToFontsResourceDirectory != string.Empty) ? Path.GetFullPath(GlobalSettings.PathToFontsResourceDirectory) : "";
					if (text != null && text != string.Empty)
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						FileInfo[] files = directoryInfo.GetFiles();
						List<FileInfo> list = new List<FileInfo>();
						List<FileInfo> list2 = new List<FileInfo>();
						foreach (FileInfo fileInfo in files)
						{
							if (string.Compare(fileInfo.Extension, ".ttf", true) == 0)
							{
								list.Add(fileInfo);
							}
							if (string.Compare(fileInfo.Extension, ".otf", true) == 0)
							{
								list2.Add(fileInfo);
							}
						}
						string[] array2 = new string[list.Count + list2.Count];
						r7[] array3 = new r7[list.Count + list2.Count];
						r6[] array4 = new r6[list.Count + list2.Count];
						List<string> list3 = new List<string>();
						int num = 0;
						int num2 = 0;
						foreach (FileInfo fileInfo2 in list)
						{
							Stream a_ = new FileStream(fileInfo2.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
							sc sc;
							sb sb = r8.a(a_, out sc);
							if (sb != null && sc != null)
							{
								array2[num2] = fileInfo2.Name;
								r7 r = new r7(sb.a().ToUpper(), sb.b().ToUpper(), num2);
								array3[num2] = r;
								r9 a_2 = new r9(sc.k(), sc.l(), num2);
								r6 r2 = new r6(sb.d().ToUpper(), sb.c().ToUpper(), a_2, sb.b());
								array4[num2] = r2;
								num2++;
							}
							num++;
						}
						foreach (FileInfo fileInfo3 in list2)
						{
							Stream a_ = new FileStream(fileInfo3.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
							sc sc;
							sb sb = r8.a(a_, out sc);
							if (sb != null && sc != null)
							{
								array2[num2] = fileInfo3.Name;
								r7 r = new r7(sb.a().ToUpper(), sb.b().ToUpper(), num2);
								array3[num2] = r;
								r9 a_2 = new r9(sc.k(), sc.l(), num2);
								r6 r2 = new r6(sb.d().ToUpper(), sb.c().ToUpper(), a_2, sb.b());
								array4[num2] = r2;
								num2++;
							}
							num++;
						}
						if (num != num2)
						{
							Array.Resize<string>(ref array2, num2);
							Array.Resize<r7>(ref array3, num2);
							Array.Resize<r6>(ref array4, num2);
						}
						r8.b.AddRange(array2);
						r8.c.AddRange(array3);
						r8.d.AddRange(array4);
					}
					r8.e = false;
				}
			}
			foreach (uint key in r8.h.Keys)
			{
				string text2 = r8.h[key];
				if (r8.g.ContainsKey(key))
				{
					List<string> list4 = r8.g[key];
					if (list4 != null && list4.Count > 2 && list4.Contains(text2))
					{
						int index = list4.IndexOf(text2);
						string value = list4[0];
						list4[0] = text2;
						list4[index] = value;
					}
				}
			}
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x0013CA90 File Offset: 0x0013BA90
		private static sb a(Stream A_0, out sc A_1)
		{
			sb sb = null;
			A_1 = null;
			try
			{
				int num = -1;
				int a_ = -1;
				int num2 = -1;
				adz adz = null;
				A_0.Seek(4L, SeekOrigin.Begin);
				int num3 = A_0.ReadByte() << 8 | A_0.ReadByte();
				if (num3 > 0)
				{
					byte[] array = new byte[num3 * 16];
					A_0.Seek(12L, SeekOrigin.Begin);
					A_0.Read(array, 0, num3 * 16);
					for (int i = 0; i < array.Length; i += 16)
					{
						int num4 = BitConverter.ToInt32(array, i);
						if (num4 <= 1701667182)
						{
							if (num4 != 541476419)
							{
								if (num4 != 841962319)
								{
									if (num4 == 1701667182)
									{
										sb = new sb(A_0, array, i);
									}
								}
								else
								{
									A_1 = new sc(A_0, array, i, -1);
								}
							}
							else
							{
								num2 = i;
							}
						}
						else if (num4 != 1719233639)
						{
							if (num4 != 1885433187)
							{
								if (num4 == 1886937453)
								{
									adz = new adz(A_0, array, i);
								}
							}
							else
							{
								a_ = i;
							}
						}
						else
						{
							num = i;
						}
					}
					if (num != -1)
					{
						ad1 ad = new ad9();
					}
					else if (num2 != -1)
					{
						ad1 ad = new ad3();
					}
					adh adh = new adh(adz.a(), A_0, array, a_);
					if (adh.a() == 1)
					{
						bool flag = false;
						for (int i = 0; i < age.df.Length; i++)
						{
							int num5 = age.df[i].Value.a();
							int num6 = (age.df[i].Value.a() + age.df[i].Value.b()) / 2;
							int num7 = age.df[i].Value.b();
							if (num5 < adh.b().Length && adh.b()[num5] != '\0')
							{
								flag = true;
							}
							if (num6 < adh.b().Length && adh.b()[num6] != '\0')
							{
								flag = true;
							}
							if (num7 < adh.b().Length && adh.b()[num7] != '\0')
							{
								flag = true;
							}
							if (flag)
							{
								List<string> list = new List<string>();
								if (r8.g.ContainsKey(age.df[i].Key))
								{
									if (r8.g[age.df[i].Key] == null)
									{
										list.Add(sb.b());
										r8.g[age.df[i].Key] = list;
									}
									else
									{
										list = r8.g[age.df[i].Key];
										list.Add(sb.b());
									}
								}
								flag = false;
							}
						}
					}
				}
			}
			catch
			{
			}
			return sb;
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x0013CE00 File Offset: 0x0013BE00
		internal static Font c(string A_0, bool A_1)
		{
			Font result;
			if (A_0 == null)
			{
				result = null;
			}
			else if (A_0 == string.Empty || A_0.Length < 1)
			{
				result = null;
			}
			else
			{
				A_0 = A_0.Replace("-", string.Empty);
				A_0 = A_0.Replace(" ", string.Empty);
				if (r8.e)
				{
					r8.a();
				}
				foreach (r7 r in r8.c)
				{
					if (r.b().Equals(A_0.ToUpper()))
					{
						return r8.a(r.c(), A_1);
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x0013CEF8 File Offset: 0x0013BEF8
		private static OpenTypeFont a(int A_0, bool A_1)
		{
			return new OpenTypeFont(r8.b[A_0], A_1);
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x0013CF1C File Offset: 0x0013BF1C
		internal static Font a(string A_0, bool A_1, bool A_2, bool A_3)
		{
			Font result;
			if (A_0 == null)
			{
				result = null;
			}
			else if (A_0 == string.Empty || A_0.Length < 1)
			{
				result = null;
			}
			else
			{
				A_0 = A_0.Replace("-", string.Empty);
				A_0 = A_0.Replace(" ", string.Empty);
				int num = -1;
				if (r8.e)
				{
					r8.a();
				}
				foreach (r7 r in r8.c)
				{
					if (r.a().Equals(A_0.ToUpper()) || r.b().Equals(A_0.ToUpper()))
					{
						num = r.c();
					}
				}
				if (num < 0 || A_1 || A_2)
				{
					foreach (r6 r2 in r8.d)
					{
						if (r2.a().Equals(A_0.ToUpper()) || r2.b().Equals(A_0.ToUpper()))
						{
							if (A_1)
							{
								num = -1;
								if (A_2)
								{
									if (r2.c().a() == 700 && (r2.c().b() == 1 || r2.c().b() == 33 || r2.c().b() == 65))
									{
										num = r2.c().c();
										break;
									}
								}
								else if (r2.c().a() == 700 && r2.c().b() != 1 && r2.c().b() != 33 && r2.c().b() != 65)
								{
									num = r2.c().c();
									break;
								}
							}
							else if (A_2)
							{
								num = -1;
								if ((r2.c().b() == 1 || r2.c().b() == 33 || r2.c().b() == 65) && r2.c().a() != 700)
								{
									num = r2.c().c();
									break;
								}
							}
							else if (r2.c().a() == 400 && r2.c().b() != 1 && r2.c().b() != 33 && r2.c().b() != 65)
							{
								num = r2.c().c();
							}
						}
					}
				}
				if (num >= 0)
				{
					result = r8.a(num, A_3);
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0600202A RID: 8234 RVA: 0x0013D304 File Offset: 0x0013C304
		internal static Font b(string A_0, bool A_1)
		{
			A_0 = A_0.Replace("-", string.Empty);
			A_0 = A_0.Replace(" ", string.Empty);
			Font result = null;
			if (r8.e)
			{
				r8.a();
			}
			for (int i = 0; i < r8.c.Count; i++)
			{
				if (r8.c[i].a().Equals(A_0.ToUpper()) || r8.c[i].b().Equals(A_0.ToUpper()))
				{
					result = r8.a(r8.c[i].c(), A_1);
					break;
				}
			}
			return result;
		}

		// Token: 0x0600202B RID: 8235 RVA: 0x0013D3D8 File Offset: 0x0013C3D8
		internal static Font a(string A_0, bool A_1)
		{
			Font result = null;
			A_0 = A_0.Replace(" ", string.Empty);
			if (r8.e)
			{
				r8.a();
			}
			foreach (r6 r in r8.d)
			{
				if (r.a().Equals(A_0.ToUpper()) || r.d().Equals(A_0.ToUpper()) || r.b().Equals(A_0.ToUpper()))
				{
					result = r8.a(r.c().c(), A_1);
				}
			}
			return result;
		}

		// Token: 0x0600202C RID: 8236 RVA: 0x0013D4B8 File Offset: 0x0013C4B8
		internal static Font a(string A_0, int A_1, string A_2)
		{
			return r8.a(A_0, A_1, A_2, false);
		}

		// Token: 0x0600202D RID: 8237 RVA: 0x0013D4D4 File Offset: 0x0013C4D4
		internal static Font a(string A_0, int A_1, string A_2, bool A_3)
		{
			Font font = r8.a(A_0, A_3);
			Font result;
			if (font == null)
			{
				result = null;
			}
			else
			{
				r6[] a_ = r8.a(A_0);
				byte b = A_2.ToUpper().Equals("NORMAL") ? 0 : 1;
				Font font2;
				if (b == 1)
				{
					font2 = r8.b(a_, A_1, A_3);
					if (font2 == null)
					{
						if (A_1 >= 100 && A_1 <= 500)
						{
							A_1 = 400;
						}
						else if (A_1 >= 600 && A_1 <= 900)
						{
							A_1 = 700;
						}
						font2 = r8.b(a_, A_1, A_3);
					}
				}
				else
				{
					font2 = r8.a(a_, A_1, A_3);
					if (font2 == null)
					{
						if (A_1 >= 100 && A_1 <= 500)
						{
							A_1 = 400;
						}
						else if (A_1 >= 600 && A_1 <= 900)
						{
							A_1 = 700;
						}
						font2 = r8.a(a_, A_1, A_3);
						if (font2 == null)
						{
							font2 = r8.a(a_, A_3);
						}
					}
				}
				if (font2 == null)
				{
					result = font;
				}
				else
				{
					result = font2;
				}
			}
			return result;
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x0013D62C File Offset: 0x0013C62C
		private static r6[] a(string A_0)
		{
			r6[] array = new r6[10];
			A_0 = A_0.Replace(" ", string.Empty);
			if (r8.e)
			{
				r8.a();
			}
			int num = 0;
			for (int i = 0; i < r8.d.Count; i++)
			{
				r6 r = r8.d[i];
				if (r.a().Equals(A_0.ToUpper()) || r.b().Equals(A_0.ToUpper()))
				{
					if (num < array.Length)
					{
						array[num++] = r;
					}
				}
			}
			return array;
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x0013D6F4 File Offset: 0x0013C6F4
		private static Font b(r6[] A_0, int A_1, bool A_2)
		{
			Font result = null;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i].c().b() == 1 || A_0[i].c().b() == 33 || A_0[i].c().b() == 65)
				{
					if (A_0[i].c().a() == A_1)
					{
						result = r8.a(A_0[i].c().c(), A_2);
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x0013D7BC File Offset: 0x0013C7BC
		private static Font a(r6[] A_0, int A_1, bool A_2)
		{
			Font result = null;
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i].c().a() == A_1 && A_0[i].c().b() != 1 && A_0[i].c().b() != 33 && A_0[i].c().b() != 65)
				{
					result = r8.a(A_0[i].c().c(), A_2);
					break;
				}
			}
			return result;
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x0013D878 File Offset: 0x0013C878
		private static Font a(r6[] A_0, bool A_1)
		{
			Font result = null;
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((A_0[i].b() != null || A_0[i].a() != null) && A_0[i].c().b() != 1 && A_0[i].c().b() != 33 && A_0[i].c().b() != 65)
				{
					result = r8.a(A_0[i].c().c(), A_1);
					break;
				}
			}
			return result;
		}

		// Token: 0x04000DED RID: 3565
		internal const string a = "Arial";

		// Token: 0x04000DEE RID: 3566
		private static List<string> b = new List<string>();

		// Token: 0x04000DEF RID: 3567
		private static List<r7> c = new List<r7>();

		// Token: 0x04000DF0 RID: 3568
		private static List<r6> d = new List<r6>();

		// Token: 0x04000DF1 RID: 3569
		private static bool e = true;

		// Token: 0x04000DF2 RID: 3570
		private static object f = new object();

		// Token: 0x04000DF3 RID: 3571
		internal static Dictionary<uint, List<string>> g = new Dictionary<uint, List<string>>
		{
			{
				age.c8,
				null
			},
			{
				age.c2,
				null
			},
			{
				age.c3,
				null
			},
			{
				age.d,
				null
			},
			{
				age.e,
				null
			},
			{
				age.bq,
				null
			},
			{
				age.ba,
				null
			},
			{
				age.br,
				null
			},
			{
				age.cf,
				null
			},
			{
				age.b5,
				null
			},
			{
				age.f,
				null
			},
			{
				age.c9,
				null
			},
			{
				age.aa,
				null
			},
			{
				age.b6,
				null
			},
			{
				age.ab,
				null
			},
			{
				age.a2,
				null
			},
			{
				age.ar,
				null
			},
			{
				age.ac,
				null
			},
			{
				age.bf,
				null
			},
			{
				age.cg,
				null
			},
			{
				age.b8,
				null
			},
			{
				age.bg,
				null
			},
			{
				age.ad,
				null
			},
			{
				age.a,
				null
			},
			{
				age.a3,
				null
			},
			{
				age.bb,
				null
			},
			{
				age.av,
				null
			},
			{
				age.g,
				null
			},
			{
				age.ao,
				null
			},
			{
				age.h,
				null
			},
			{
				age.ch,
				null
			},
			{
				age.bs,
				null
			},
			{
				age.ci,
				null
			},
			{
				age.ae,
				null
			},
			{
				age.i,
				null
			},
			{
				age.a4,
				null
			},
			{
				age.ap,
				null
			},
			{
				age.cj,
				null
			},
			{
				age.j,
				null
			},
			{
				age.k,
				null
			},
			{
				age.l,
				null
			},
			{
				age.n,
				null
			},
			{
				age.m,
				null
			},
			{
				age.@as,
				null
			},
			{
				age.c4,
				null
			},
			{
				age.o,
				null
			},
			{
				age.p,
				null
			},
			{
				age.bt,
				null
			},
			{
				age.b,
				null
			},
			{
				age.bu,
				null
			},
			{
				age.bv,
				null
			},
			{
				age.de,
				null
			},
			{
				age.bw,
				null
			},
			{
				age.bx,
				null
			},
			{
				age.q,
				null
			},
			{
				age.r,
				null
			},
			{
				age.bh,
				null
			},
			{
				age.a5,
				null
			},
			{
				age.af,
				null
			},
			{
				age.ck,
				null
			},
			{
				age.cl,
				null
			},
			{
				age.s,
				null
			},
			{
				age.t,
				null
			},
			{
				age.bi,
				null
			},
			{
				age.aw,
				null
			},
			{
				age.cm,
				null
			},
			{
				age.ax,
				null
			},
			{
				age.by,
				null
			},
			{
				age.bj,
				null
			},
			{
				age.bk,
				null
			},
			{
				age.cn,
				null
			},
			{
				age.u,
				null
			},
			{
				age.b7,
				null
			},
			{
				age.co,
				null
			},
			{
				age.da,
				null
			},
			{
				age.bz,
				null
			},
			{
				age.cp,
				null
			},
			{
				age.b9,
				null
			},
			{
				age.ca,
				null
			},
			{
				age.cb,
				null
			},
			{
				age.cq,
				null
			},
			{
				age.ag,
				null
			},
			{
				age.cr,
				null
			},
			{
				age.c5,
				null
			},
			{
				age.ah,
				null
			},
			{
				age.cs,
				null
			},
			{
				age.dd,
				null
			},
			{
				age.a6,
				null
			},
			{
				age.bc,
				null
			},
			{
				age.ai,
				null
			},
			{
				age.c6,
				null
			},
			{
				age.aq,
				null
			},
			{
				age.ct,
				null
			},
			{
				age.cu,
				null
			},
			{
				age.a7,
				null
			},
			{
				age.b0,
				null
			},
			{
				age.b1,
				null
			},
			{
				age.bl,
				null
			},
			{
				age.v,
				null
			},
			{
				age.db,
				null
			},
			{
				age.ay,
				null
			},
			{
				age.cv,
				null
			},
			{
				age.cw,
				null
			},
			{
				age.cx,
				null
			},
			{
				age.bd,
				null
			},
			{
				age.be,
				null
			},
			{
				age.cy,
				null
			},
			{
				age.bm,
				null
			},
			{
				age.aj,
				null
			},
			{
				age.b2,
				null
			},
			{
				age.bn,
				null
			},
			{
				age.cc,
				null
			},
			{
				age.az,
				null
			},
			{
				age.cz,
				null
			},
			{
				age.c7,
				null
			},
			{
				age.ak,
				null
			},
			{
				age.cd,
				null
			},
			{
				age.bo,
				null
			},
			{
				age.a8,
				null
			},
			{
				age.al,
				null
			},
			{
				age.at,
				null
			},
			{
				age.au,
				null
			},
			{
				age.a0,
				null
			},
			{
				age.b3,
				null
			},
			{
				age.b4,
				null
			},
			{
				age.ce,
				null
			},
			{
				age.w,
				null
			},
			{
				age.dc,
				null
			},
			{
				age.x,
				null
			},
			{
				age.am,
				null
			},
			{
				age.y,
				null
			},
			{
				age.z,
				null
			},
			{
				age.a9,
				null
			},
			{
				age.c0,
				null
			},
			{
				age.a1,
				null
			},
			{
				age.c,
				null
			},
			{
				age.bp,
				null
			},
			{
				age.c1,
				null
			},
			{
				age.an,
				null
			}
		};

		// Token: 0x04000DF4 RID: 3572
		internal static Dictionary<uint, string> h = new Dictionary<uint, string>
		{
			{
				age.t,
				"Arial"
			},
			{
				age.d,
				"Arial"
			},
			{
				age.y,
				"Tahoma"
			},
			{
				age.q,
				"NirmalaUI"
			},
			{
				age.x,
				"NirmalaUI"
			},
			{
				age.w,
				"NirmalaUI"
			},
			{
				age.f,
				"NirmalaUI"
			}
		};
	}
}
