using System;
using System.Collections.Generic;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020001D5 RID: 469
	internal class l5
	{
		// Token: 0x06001401 RID: 5121 RVA: 0x000DF37C File Offset: 0x000DE37C
		internal l5()
		{
			using (MemoryStream memoryStream = new MemoryStream((byte[])Document.a.GetObject("LiberationSans_Regular")))
			{
				OpenTypeFont a_ = new OpenTypeFont(memoryStream, LineBreaker.Latin, GlobalSettings.a());
				int a_2 = l5.a("LiberationSans_Regular");
				this.c = new l2(a_2, a_, "LiberationSans_Regular");
			}
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x000DF454 File Offset: 0x000DE454
		internal static void a(ij A_0)
		{
			int hashCode = A_0.GetHashCode();
			lock (l5.g)
			{
				try
				{
					if (l5.f.ContainsKey(hashCode))
					{
						List<int> list = l5.f[hashCode];
						for (int i = 0; i < list.Count; i++)
						{
							int key = list[i];
							if (l5.e.ContainsKey(key))
							{
								l2 l = l5.e[key].b();
								l.b(l.g() - 1);
								if (l5.e[key].b().g() == 0)
								{
									l5.e.Remove(key);
								}
							}
						}
						l5.f.Remove(hashCode);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x000DF574 File Offset: 0x000DE574
		private void a(l2 A_0, ij A_1)
		{
			lock (l5.g)
			{
				try
				{
					this.a(A_0);
					if (!A_1.r().Contains(A_0.d()))
					{
						A_0.a(true);
						A_1.r().Add(A_0.d());
						if (!l5.f.ContainsKey(this.d))
						{
							l5.f.Add(this.d, A_1.r());
						}
						else
						{
							l5.f[this.d] = A_1.r();
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x000DF650 File Offset: 0x000DE650
		private l2 a(int A_0, ij A_1)
		{
			l2 l = null;
			lock (l5.g)
			{
				try
				{
					if (l5.e.ContainsKey(A_0))
					{
						l5.e[A_0].a(DateTime.Now.Ticks);
						l = l5.e[A_0].b();
						if (!l5.f.ContainsKey(this.d))
						{
							foreach (int key in l5.e.Keys)
							{
								l5.e[key].b().a(false);
							}
							if (!A_1.r().Contains(A_0))
							{
								A_1.r().Add(A_0);
								l2 l2 = l;
								l2.b(l2.g() + 1);
								l.a(true);
							}
							l5.f.Add(this.d, A_1.r());
						}
						else if (!l.h())
						{
							A_1.r().Add(A_0);
							l2 l3 = l;
							l3.b(l3.g() + 1);
							l.a(true);
						}
					}
					else
					{
						this.a(l);
					}
				}
				catch (Exception)
				{
				}
			}
			return l;
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x000DF830 File Offset: 0x000DE830
		private void a(l2 A_0)
		{
			ob value = new ob(A_0, DateTime.Now.Ticks);
			l5.e.Add(A_0.d(), value);
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x000DF864 File Offset: 0x000DE864
		private Font a(string A_0, int A_1, string A_2)
		{
			A_0 = A_0.ToLower();
			Font font = null;
			string text = A_0;
			if (text != null)
			{
				if (text == "serif")
				{
					for (int i = 0; i < l5.i.Length; i++)
					{
						font = r8.a(l5.i[i], A_1, A_2, GlobalSettings.a());
						if (font != null)
						{
							break;
						}
					}
					return font;
				}
				if (text == "sans-serif")
				{
					for (int i = 0; i < l5.j.Length; i++)
					{
						font = r8.a(l5.j[i], A_1, A_2, GlobalSettings.a());
						if (font != null)
						{
							break;
						}
					}
					return font;
				}
				if (text == "cursive")
				{
					for (int i = 0; i < l5.k.Length; i++)
					{
						font = r8.a(l5.k[i], A_1, A_2, GlobalSettings.a());
						if (font != null)
						{
							break;
						}
					}
					return font;
				}
				if (text == "fantasy")
				{
					for (int i = 0; i < l5.l.Length; i++)
					{
						font = r8.a(l5.l[i], A_1, A_2, GlobalSettings.a());
						if (font != null)
						{
							break;
						}
					}
					return font;
				}
				if (text == "monospace")
				{
					for (int i = 0; i < this.m.Length; i++)
					{
						font = r8.a(this.m[i], A_1, A_2, GlobalSettings.a());
						if (font != null)
						{
							break;
						}
					}
					return font;
				}
			}
			font = r8.a(A_0, A_1, A_2, GlobalSettings.a());
			return font;
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x000DFA20 File Offset: 0x000DEA20
		internal l2 a()
		{
			return this.c;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x000DFA38 File Offset: 0x000DEA38
		internal l2 b()
		{
			return this.h;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x000DFA50 File Offset: 0x000DEA50
		internal static int a(string A_0)
		{
			char[] array = A_0.ToCharArray();
			kb kb = new kb();
			foreach (char a_ in array)
			{
				kb.b(a_);
			}
			return kb.b();
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x000DFAA4 File Offset: 0x000DEAA4
		internal l2 a(n5 A_0, ij A_1)
		{
			this.d = A_1.GetHashCode();
			string text = A_0.a().n();
			int num = (int)A_0.a().h();
			int a_ = 0;
			string text2;
			if (A_0.a().f() == f4.a)
			{
				text2 = "normal";
			}
			else if (A_0.a().f() == f4.b)
			{
				text2 = "italic";
			}
			else
			{
				text2 = "oblique";
			}
			int num2 = text.IndexOfAny(new char[]
			{
				'"',
				'\''
			});
			if (num2 > 0)
			{
				text = text.Remove(num2, 1);
			}
			byte b = (text.IndexOf(',') > 0) ? 1 : 0;
			string[] array = null;
			int i = 0;
			if (b == 1)
			{
				array = text.Split(new char[]
				{
					','
				});
				while (i < array.Length)
				{
					if (!A_0.ad().Contains(array[i]))
					{
						A_0.ad().Add(array[i]);
					}
					i++;
				}
			}
			else if (!A_0.ad().Contains(text))
			{
				A_0.ad().Add(text);
			}
			string text3 = text.Replace(" ", "") + num + text2;
			a_ = l5.a(text3.ToUpper());
			this.a = a_;
			l2 l = this.a(a_, A_1);
			if (l == null)
			{
				if (array == null)
				{
					Font font = this.a(text, num, text2);
					if (font != null)
					{
						l = new l2(a_, font, text3);
						this.a(l, A_1);
					}
				}
				else
				{
					for (i = 0; i < array.Length; i++)
					{
						array[i] = array[i].Trim(new char[]
						{
							' ',
							'"'
						});
						text3 = array[i].Replace(" ", "") + num + text2;
						int a_2 = l5.a(text3.ToUpper());
						this.b = a_2;
						l = this.a(a_2, A_1);
						if (l == null)
						{
							Font font = this.a(array[i], num, text2);
							if (font != null)
							{
								l = new l2(a_2, font, text3);
								this.a(l, A_1);
								string text4 = array[i].ToLower().Trim();
								if (text4 != "sans-serif" && text4 != "serif" && text4 != "cursive" && text4 != "fantasy" && text4 != "monospace")
								{
									break;
								}
							}
						}
						else
						{
							string text4 = array[i].ToLower().Trim();
							if (text4 != "sans-serif" && text4 != "serif" && text4 != "cursive" && text4 != "fantasy" && text4 != "monospace")
							{
								break;
							}
						}
					}
				}
				if (text == "DejaVuSans")
				{
					using (MemoryStream memoryStream = new MemoryStream((byte[])Document.a.GetObject("DejaVuSans")))
					{
						OpenTypeFont a_3 = new OpenTypeFont(memoryStream, LineBreaker.Latin, GlobalSettings.a());
						text3 = "DejaVuSans" + num + text2;
						a_ = l5.a(text3.ToUpper());
						this.h = new l2(a_, a_3, "DejaVuSans");
						if (this.a(a_, A_1) == null)
						{
							this.a(this.h, A_1);
						}
					}
				}
				if (l == null)
				{
					text = "Arial";
					Font font = r8.a(text, num, text2, GlobalSettings.a());
					if (font != null)
					{
						l = new l2(a_, font, text);
						this.a(l, A_1);
					}
					else
					{
						l = this.a();
					}
				}
			}
			return l;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x000DFF5C File Offset: 0x000DEF5C
		internal l2 a(string A_0, n5 A_1, ij A_2)
		{
			int num = (int)A_1.a().h();
			string text;
			if (A_1.a().f() == f4.a)
			{
				text = "normal";
			}
			else if (A_1.a().f() == f4.b)
			{
				text = "italic";
			}
			else
			{
				text = "oblique";
			}
			string text2 = A_0.Replace(" ", "") + num + text;
			int a_ = l5.a(text2.ToUpper());
			this.a = a_;
			l2 l = this.a(a_, A_2);
			if (l == null)
			{
				Font font = this.a(A_0, num, text);
				if (font != null)
				{
					l = new l2(a_, font, text2);
					this.a(l, A_2);
				}
			}
			return l;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x000E004C File Offset: 0x000DF04C
		internal int c()
		{
			return this.a;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x000E0064 File Offset: 0x000DF064
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x000E0070 File Offset: 0x000DF070
		internal int d()
		{
			return this.b;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x000E0088 File Offset: 0x000DF088
		internal void b(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04000969 RID: 2409
		private int a = 0;

		// Token: 0x0400096A RID: 2410
		private int b = 0;

		// Token: 0x0400096B RID: 2411
		private l2 c;

		// Token: 0x0400096C RID: 2412
		private int d = 0;

		// Token: 0x0400096D RID: 2413
		private static Dictionary<int, ob> e = new Dictionary<int, ob>();

		// Token: 0x0400096E RID: 2414
		private static Dictionary<int, List<int>> f = new Dictionary<int, List<int>>();

		// Token: 0x0400096F RID: 2415
		private static object g = new object();

		// Token: 0x04000970 RID: 2416
		private l2 h;

		// Token: 0x04000971 RID: 2417
		private static readonly string[] i = new string[]
		{
			"Times New Roman",
			"Cambria",
			"Constantia",
			"Georgia",
			"Palatino Linotype",
			"Times",
			"Bookman",
			"New Century Schoolbook",
			"Bodoni MT",
			"Garamond",
			"Liberation Serif"
		};

		// Token: 0x04000972 RID: 2418
		private static readonly string[] j = new string[]
		{
			"Arial",
			"Arial Black",
			"Arial Narrow",
			"Calibri",
			"Candara",
			"Corbel",
			"Helvetica",
			"Impact",
			"Microsoft Sans Serif",
			"Tahoma",
			"Trebuchet MS",
			"Verdana",
			"Gill sans",
			"Lucida Sans Unicode",
			"Heisei Kaku Gothic W5",
			"Liberation Sans"
		};

		// Token: 0x04000973 RID: 2419
		private static readonly string[] k = new string[]
		{
			"Comic Sans MS",
			"Zapf Chancery",
			"Parkavenue",
			"Florence"
		};

		// Token: 0x04000974 RID: 2420
		private static readonly string[] l = new string[]
		{
			"Cottonwood",
			"cottonwoodthin",
			"Critter2",
			"Critter1",
			"Agency FB",
			"Studz",
			"Impact"
		};

		// Token: 0x04000975 RID: 2421
		private string[] m = new string[]
		{
			"Courier New",
			"Andale Mono",
			"Consolas",
			"Courier",
			"Lucida Console",
			"Liberation Mono"
		};
	}
}
