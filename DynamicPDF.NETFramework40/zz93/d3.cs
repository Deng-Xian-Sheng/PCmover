using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using ceTe.DynamicPDF.PageElements.Html;

namespace zz93
{
	// Token: 0x020000B3 RID: 179
	[DefaultMember("Item")]
	internal class d3
	{
		// Token: 0x06000872 RID: 2162 RVA: 0x0007625C File Offset: 0x0007525C
		internal d3()
		{
			this.f = new p1();
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x000762D8 File Offset: 0x000752D8
		internal d3(kg A_0)
		{
			this.g = A_0;
			this.f = new p1();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0007635C File Offset: 0x0007535C
		internal d3(kg A_0, p1 A_1, ij A_2)
		{
			this.i = A_0.y().c();
			this.g = A_0;
			this.f = A_1;
			this.n = A_2;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000763F4 File Offset: 0x000753F4
		internal dy b(int A_0)
		{
			return this.e[A_0];
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00076412 File Offset: 0x00075412
		internal void a(int A_0, dy A_1)
		{
			this.e[A_0] = A_1;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00076424 File Offset: 0x00075424
		internal int h()
		{
			return this.e.Count;
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00076444 File Offset: 0x00075444
		internal List<dy> i()
		{
			return this.e;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0007645C File Offset: 0x0007545C
		internal HtmlArea j()
		{
			return this.o;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00076474 File Offset: 0x00075474
		internal void a(HtmlArea A_0)
		{
			this.o = A_0;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00076480 File Offset: 0x00075480
		protected internal p1 k()
		{
			return this.f;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00076498 File Offset: 0x00075498
		protected internal void a(p1 A_0)
		{
			this.f = A_0;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000764A4 File Offset: 0x000754A4
		protected internal kg l()
		{
			return this.g;
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x000764BC File Offset: 0x000754BC
		protected internal void b(kg A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x000764C8 File Offset: 0x000754C8
		internal Uri m()
		{
			return this.i;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000764E0 File Offset: 0x000754E0
		internal void a(Uri A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000764EC File Offset: 0x000754EC
		internal string n()
		{
			return this.k;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00076504 File Offset: 0x00075504
		internal void a(string A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00076510 File Offset: 0x00075510
		internal ej o()
		{
			return this.l;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00076528 File Offset: 0x00075528
		internal void a(ej A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00076534 File Offset: 0x00075534
		internal kh p()
		{
			return this.m;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0007654C File Offset: 0x0007554C
		internal void a(kh A_0)
		{
			this.m = A_0;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00076558 File Offset: 0x00075558
		internal ij q()
		{
			return this.n;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00076570 File Offset: 0x00075570
		internal void a(ij A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0007657A File Offset: 0x0007557A
		internal void a(dy A_0)
		{
			this.e.Add(A_0);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0007658A File Offset: 0x0007558A
		internal void a(dy A_0, int A_1)
		{
			this.e.Insert(A_1, A_0);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0007659B File Offset: 0x0007559B
		internal void c(int A_0)
		{
			this.e.RemoveAt(A_0);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000765AC File Offset: 0x000755AC
		private void a(en A_0)
		{
			this.f.a(A_0);
			ek a_ = new ek(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000765E8 File Offset: 0x000755E8
		private void a(ks A_0)
		{
			this.f.a(A_0);
			kt a_ = new kt(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00076624 File Offset: 0x00075624
		private void a(pc A_0)
		{
			this.f.a(A_0);
			pd a_ = new pd(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00076660 File Offset: 0x00075660
		private void a(qs A_0)
		{
			this.f.a(A_0);
			qr a_ = new qr(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0007669C File Offset: 0x0007569C
		private void a(jv A_0)
		{
			this.f.a(A_0);
			ju a_ = new ju(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000766D8 File Offset: 0x000756D8
		private void a(qq A_0)
		{
			this.f.a(A_0);
			p9 a_ = new p9(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00076714 File Offset: 0x00075714
		private void a(ed A_0)
		{
			this.f.a(A_0);
			ec a_ = new ec(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00076750 File Offset: 0x00075750
		private void a(ji A_0)
		{
			this.f.a(A_0);
			jh a_ = new jh(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0007678C File Offset: 0x0007578C
		private void a(jj A_0)
		{
			this.f.a(A_0);
			jg a_ = new jg(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x000767C8 File Offset: 0x000757C8
		private void a(kr A_0)
		{
			this.f.a(A_0);
			kq a_ = new kq(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00076804 File Offset: 0x00075804
		private void a(kv A_0)
		{
			this.f.a(A_0);
			ku a_ = new ku(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00076840 File Offset: 0x00075840
		private void a(pt A_0)
		{
			this.f.a(A_0);
			ps a_ = new ps(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0007687C File Offset: 0x0007587C
		private void a(pv A_0)
		{
			this.f.a(A_0);
			pu a_ = new pu(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x000768B8 File Offset: 0x000758B8
		private void a(qu A_0)
		{
			this.f.a(A_0);
			qt a_ = new qt(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x000768F4 File Offset: 0x000758F4
		private void a(d1 A_0)
		{
			this.f.a(A_0);
			dz a_ = new dz(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00076930 File Offset: 0x00075930
		private void a(e0 A_0)
		{
			this.f.a(A_0);
			ez a_ = new ez(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0007696C File Offset: 0x0007596C
		private void a(e2 A_0)
		{
			this.f.a(A_0);
			e1 a_ = new e1(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000769A8 File Offset: 0x000759A8
		private void a(j0 A_0)
		{
			this.f.a(A_0);
			jz a_ = new jz(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x000769E4 File Offset: 0x000759E4
		private void a(pf A_0)
		{
			this.f.a(A_0);
			pe a_ = new pe(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00076A20 File Offset: 0x00075A20
		private void a(pn A_0)
		{
			this.f.a(A_0);
			pm a_ = new pm(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00076A5C File Offset: 0x00075A5C
		private void a(pk A_0)
		{
			this.f.a(A_0);
			pj a_ = new pj(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00076A98 File Offset: 0x00075A98
		private void a(d6 A_0)
		{
			this.f.a(A_0);
			d5 a_ = new d5(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00076AD4 File Offset: 0x00075AD4
		private void a(pp A_0)
		{
			this.f.a(A_0);
			po a_ = new po(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00076B10 File Offset: 0x00075B10
		private void a(ns A_0)
		{
			this.f.a(A_0);
			po a_ = new po(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00076B4C File Offset: 0x00075B4C
		private void a(pr A_0)
		{
			if (this.f != null)
			{
				this.f.a(A_0);
			}
			pq a_ = new pq(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00076B98 File Offset: 0x00075B98
		private void a(kk A_0)
		{
			if (this.f != null)
			{
				this.a(new kj(A_0, this.f.b()));
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00076BCC File Offset: 0x00075BCC
		private void a(p0 A_0)
		{
			pw a_ = new pw(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00076BFC File Offset: 0x00075BFC
		private void a(jk A_0)
		{
			oi a_ = new oi(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00076C2C File Offset: 0x00075C2C
		private void a(d9 A_0)
		{
			d7 a_ = new d7(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00076C5C File Offset: 0x00075C5C
		private void a(eb A_0)
		{
			if (this.f != null)
			{
				this.f.a(A_0);
			}
			d2 a_ = new d2(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00076CA8 File Offset: 0x00075CA8
		private void g()
		{
			this.f();
			eh eh = new eh(this.l, this.f, this.g, this.n);
			eh.a(this.p());
			this.a(eh);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00076CF0 File Offset: 0x00075CF0
		private void a(eg A_0)
		{
			ee a_ = new ee(A_0, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00076D1F File Offset: 0x00075D1F
		private void a(em A_0)
		{
			this.a(new el(A_0));
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00076D2F File Offset: 0x00075D2F
		private void a(kf A_0)
		{
			this.a(new ke(A_0));
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00076D3F File Offset: 0x00075D3F
		private void a(ey A_0)
		{
			this.a(new ew(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00076D61 File Offset: 0x00075D61
		private void a(jp A_0)
		{
			this.a(new jn(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00076D83 File Offset: 0x00075D83
		private void a(op A_0)
		{
			this.a(new on(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x00076DA5 File Offset: 0x00075DA5
		private void a(j4 A_0)
		{
			this.a(new kc(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00076DC7 File Offset: 0x00075DC7
		private void a(pb A_0)
		{
			this.a(new o5(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00076DE9 File Offset: 0x00075DE9
		private void a(o9 A_0)
		{
			this.a(new o7(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00076E0B File Offset: 0x00075E0B
		private void a(ov A_0)
		{
			this.a(new ot(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00076E2D File Offset: 0x00075E2D
		private void a(j3 A_0)
		{
			this.a(new j1(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00076E4F File Offset: 0x00075E4F
		private void a(kp A_0)
		{
			this.a(new km(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00076E71 File Offset: 0x00075E71
		private void a(qc A_0)
		{
			this.a(new qa(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00076E93 File Offset: 0x00075E93
		private void a(ky A_0)
		{
			this.a(new kw(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00076EB5 File Offset: 0x00075EB5
		private void a(eq A_0)
		{
			this.a(new eo(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00076ED7 File Offset: 0x00075ED7
		private void a(jy A_0)
		{
			this.a(new jw(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00076EF9 File Offset: 0x00075EF9
		private void a(of A_0)
		{
			this.a(new od(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00076F1B File Offset: 0x00075F1B
		private void a(pi A_0)
		{
			this.a(new pg(A_0, this.f, this.g, this.n));
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00076F40 File Offset: 0x00075F40
		internal static Encoding a(kg A_0)
		{
			string text = string.Empty;
			Encoding result = Encoding.UTF8;
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num != 141187855)
				{
					A_0.at();
				}
				else
				{
					string text2 = A_0.ao();
					if (text2 != null)
					{
						if (text2.Contains("charset"))
						{
							int num2 = text2.IndexOf("charset") + 8;
							if (num2 < text2.Length)
							{
								text = text2.Substring(num2, text2.Length - num2);
							}
							if (text != null)
							{
								string text3 = text.ToLower();
								if (text3 == null)
								{
									goto IL_17E;
								}
								if (anl.p0 == null)
								{
									anl.p0 = new Dictionary<string, int>(7)
									{
										{
											"utf-8",
											0
										},
										{
											"iso-8859-1",
											1
										},
										{
											"utf-7",
											2
										},
										{
											"utf-16",
											3
										},
										{
											"unicode",
											4
										},
										{
											"shift_jis",
											5
										},
										{
											"utf-16be",
											6
										}
									};
								}
								int num3;
								if (!anl.p0.TryGetValue(text3, out num3))
								{
									goto IL_17E;
								}
								switch (num3)
								{
								case 0:
									result = Encoding.UTF8;
									break;
								case 1:
									result = ae5.a(1252);
									break;
								case 2:
									result = Encoding.UTF7;
									break;
								case 3:
								case 4:
									result = Encoding.Unicode;
									break;
								case 5:
									result = ae5.a("shift-jis");
									break;
								case 6:
									result = Encoding.BigEndianUnicode;
									break;
								default:
									goto IL_17E;
								}
								continue;
								IL_17E:
								result = ae5.a(1252);
							}
						}
					}
					else
					{
						text = text2;
					}
				}
			}
			A_0.ax();
			return result;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0007710C File Offset: 0x0007610C
		private void f()
		{
			if (this.l == null)
			{
				this.l = new ej(this.g, this.n);
			}
			else
			{
				this.l.a(this.g, this.n);
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00077160 File Offset: 0x00076160
		private void e()
		{
			if (this.m == null)
			{
				this.m = new kh(this.g, this.n);
			}
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00077198 File Offset: 0x00076198
		private void d()
		{
			while (!this.g.aj())
			{
				int num = this.g.al();
				if (num != 13141935)
				{
					this.g.at();
				}
				else
				{
					string uriString = this.g.ao();
					if (uriString != ".")
					{
						this.i = new Uri(uriString);
					}
					this.n.a(this.i);
				}
			}
			this.g.ax();
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0007722C File Offset: 0x0007622C
		private void b(string A_0, string A_1)
		{
			if ((A_0.Equals("") || A_0.Equals("print")) && !A_1.Equals(""))
			{
				if (A_1.Contains("%20"))
				{
					A_1 = A_1.Replace("%20", " ");
				}
				if (A_1.Contains("&#39;"))
				{
					A_1 = A_1.Replace("&#39;", "'");
				}
				Uri uri = null;
				if (this.i != null)
				{
					if (this.i.IsFile)
					{
						uri = n9.a(this.i.AbsolutePath, A_1);
					}
					else
					{
						uri = n9.a(this.i.AbsoluteUri, A_1);
					}
				}
				if (uri != null)
				{
					try
					{
						byte[] array = n9.a(uri);
						if (array != null)
						{
							char[] chars = Encoding.ASCII.GetChars(array);
							if (this.n == null)
							{
								this.n = this.g.a(chars, 0, chars.Length);
							}
							else
							{
								this.n.c(new gi(chars, 0, chars.Length));
							}
						}
						if (this.n != null && array != null)
						{
							if (this.h == null)
							{
								this.h = new h4();
							}
							this.h.a(this.n);
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x000773D8 File Offset: 0x000763D8
		private void c()
		{
			string text = string.Empty;
			string a_ = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			bool flag = false;
			while (!this.g.aj())
			{
				int num = this.g.al();
				if (num <= 2235034)
				{
					if (num != 164382)
					{
						if (num != 2235034)
						{
							goto IL_154;
						}
						text3 = this.g.ap();
						if (text3 == null || text3.Equals("text/css", StringComparison.OrdinalIgnoreCase))
						{
							text3 = "text/css";
						}
					}
					else
					{
						text2 = this.g.ao();
						if (text2 != null && text2.Equals("stylesheet", StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
						}
					}
				}
				else if (num != 13141935)
				{
					if (num != 20926997)
					{
						goto IL_154;
					}
					text = this.g.ao();
					if (text == null)
					{
						text = "print";
					}
					else
					{
						string[] array = text.Split(new char[]
						{
							','
						});
						for (int i = 0; i < array.Length; i++)
						{
							if (Regex.IsMatch(array[i], "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)", RegexOptions.IgnoreCase))
							{
								text = "print";
								break;
							}
						}
					}
				}
				else
				{
					a_ = this.g.ao();
				}
				continue;
				IL_154:
				this.g.at();
			}
			if (flag && (text3.Equals("") || text3.Equals("text/css")))
			{
				this.b(text, a_);
			}
			this.g.ax();
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000775A4 File Offset: 0x000765A4
		private void a(string A_0, string A_1)
		{
			if ((A_0.Equals("") || A_0.Equals("text/css")) && (A_1.Equals("") || A_1.Equals("print")))
			{
				if (this.n == null)
				{
					this.n = new ij();
				}
				List<string> list = new List<string>();
				gi gi = this.g.a(ref list);
				if (gi != null)
				{
					this.n.c(gi);
				}
				for (int i = 0; i < list.Count; i++)
				{
					this.b(A_1, list[i]);
				}
			}
			else
			{
				this.g.g(144877216);
			}
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00077674 File Offset: 0x00076674
		private void b()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			while (!this.g.aj())
			{
				int num = this.g.al();
				if (num != 2235034)
				{
					if (num != 20926997)
					{
						this.g.at();
					}
					else
					{
						text2 = this.g.ao();
						if (text2 == null)
						{
							text2 = "print";
						}
						else
						{
							string[] array = text2.Split(new char[]
							{
								','
							});
							for (int i = 0; i < array.Length; i++)
							{
								if (Regex.IsMatch(array[i], "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)", RegexOptions.IgnoreCase))
								{
									text2 = "print";
									break;
								}
							}
						}
					}
				}
				else
				{
					text = this.g.ap();
					if (text == null || text.Equals("text/css", StringComparison.OrdinalIgnoreCase))
					{
						text = "text/css";
					}
				}
			}
			this.a(text, text2);
			this.g.ax();
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00077798 File Offset: 0x00076798
		private void a()
		{
			string text = this.g.av();
			if (this.k == string.Empty)
			{
				this.k = text;
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000777D0 File Offset: 0x000767D0
		private dy a(int A_0, p1 A_1)
		{
			int num = A_1.a(A_0).cn();
			if (num <= 154805)
			{
				if (num <= 1352)
				{
					if (num <= 28)
					{
						if (num == 1)
						{
							return new d2((eb)A_1.a(A_0), this.g);
						}
						if (num == 15)
						{
							return new kt((ks)A_1.a(A_0));
						}
						if (num == 28)
						{
							return new pd((pc)A_1.a(A_0));
						}
					}
					else
					{
						if (num == 35)
						{
							return new qr((qs)A_1.a(A_0));
						}
						if (num == 57)
						{
							return new ek((en)A_1.a(A_0));
						}
						if (num == 1352)
						{
							return new ju((jv)A_1.a(A_0));
						}
					}
				}
				else if (num <= 122967)
				{
					if (num == 1690)
					{
						return new p9((qq)A_1.a(A_0));
					}
					if (num == 46073)
					{
						return new ec((ed)A_1.a(A_0));
					}
					if (num == 122967)
					{
						return new qt((qu)A_1.a(A_0));
					}
				}
				else
				{
					if (num == 133455)
					{
						return new kq((kr)A_1.a(A_0));
					}
					if (num == 137440)
					{
						return new pu((pv)A_1.a(A_0));
					}
					if (num == 154805)
					{
						return new jg((jj)A_1.a(A_0));
					}
				}
			}
			else if (num <= 6968946)
			{
				if (num <= 235744)
				{
					if (num == 164405)
					{
						return new jh((ji)A_1.a(A_0));
					}
					if (num == 220754)
					{
						return new ku((kv)A_1.a(A_0));
					}
					if (num == 235744)
					{
						return new ps((pt)A_1.a(A_0));
					}
				}
				else
				{
					if (num == 2204613)
					{
						return new ez((e0)A_1.a(A_0));
					}
					if (num == 2315845)
					{
						return new e1((e2)A_1.a(A_0));
					}
					if (num == 6968946)
					{
						return new jz((j0)A_1.a(A_0));
					}
				}
			}
			else if (num <= 9705568)
			{
				if (num == 8101441)
				{
					return new dz((d1)A_1.a(A_0));
				}
				if (num == 8736864)
				{
					return new pe((pf)A_1.a(A_0));
				}
				if (num == 9705568)
				{
					return new pm((pn)A_1.a(A_0));
				}
			}
			else if (num <= 627435190)
			{
				if (num == 306046640)
				{
					return new po((pp)A_1.a(A_0));
				}
				if (num == 627435190)
				{
					return new pq((pr)A_1.a(A_0));
				}
			}
			else
			{
				if (num == 627436437)
				{
					return new d5((d6)A_1.a(A_0));
				}
				if (num == 681579872)
				{
					return new pj((pk)A_1.a(A_0));
				}
			}
			return null;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00077B94 File Offset: 0x00076B94
		private dy a(int A_0)
		{
			int num = this.f.a(A_0).cn();
			if (num <= 154805)
			{
				if (num <= 1352)
				{
					if (num <= 28)
					{
						if (num == 1)
						{
							d2 d = new d2((eb)this.f.a(A_0), this.g);
							d.cg().a(this.g, this.f);
							return d;
						}
						if (num == 15)
						{
							kt kt = new kt((ks)this.f.a(A_0));
							kt.cg().a(this.g, this.f);
							return kt;
						}
						if (num == 28)
						{
							pd pd = new pd((pc)this.f.a(A_0));
							pd.cg().a(this.g, this.f);
							return pd;
						}
					}
					else
					{
						if (num == 35)
						{
							qr qr = new qr((qs)this.f.a(A_0));
							qr.cg().a(this.g, this.f);
							return qr;
						}
						if (num == 57)
						{
							ek ek = new ek((en)this.f.a(A_0));
							ek.cg().a(this.g, this.f);
							return ek;
						}
						if (num == 1352)
						{
							ju ju = new ju((jv)this.f.a(A_0));
							ju.cg().a(this.g, this.f);
							return ju;
						}
					}
				}
				else if (num <= 122967)
				{
					if (num == 1690)
					{
						p9 p = new p9((qq)this.f.a(A_0));
						p.cg().a(this.g, this.f);
						return p;
					}
					if (num == 46073)
					{
						ec ec = new ec((ed)this.f.a(A_0));
						ec.cg().a(this.g, this.f);
						return ec;
					}
					if (num == 122967)
					{
						qt qt = new qt((qu)this.f.a(A_0));
						qt.cg().a(this.g, this.f);
						return qt;
					}
				}
				else
				{
					if (num == 133455)
					{
						kq kq = new kq((kr)this.f.a(A_0));
						kq.cg().a(this.g, this.f);
						return kq;
					}
					if (num == 137440)
					{
						pu pu = new pu((pv)this.f.a(A_0));
						pu.cg().a(this.g, this.f);
						return pu;
					}
					if (num == 154805)
					{
						jg jg = new jg((jj)this.f.a(A_0));
						jg.cg().a(this.g, this.f);
						return jg;
					}
				}
			}
			else if (num <= 6968946)
			{
				if (num <= 235744)
				{
					if (num == 164405)
					{
						jh jh = new jh((ji)this.f.a(A_0));
						jh.cg().a(this.g, this.f);
						return jh;
					}
					if (num == 220754)
					{
						ku ku = new ku((kv)this.f.a(A_0));
						ku.cg().a(this.g, this.f);
						return ku;
					}
					if (num == 235744)
					{
						ps ps = new ps((pt)this.f.a(A_0));
						ps.cg().a(this.g, this.f);
						return ps;
					}
				}
				else
				{
					if (num == 2204613)
					{
						ez ez = new ez((e0)this.f.a(A_0));
						ez.cg().a(this.g, this.f);
						return ez;
					}
					if (num == 2315845)
					{
						e1 e = new e1((e2)this.f.a(A_0));
						e.cg().a(this.g, this.f);
						return e;
					}
					if (num == 6968946)
					{
						jz jz = new jz((j0)this.f.a(A_0));
						jz.cg().a(this.g, this.f);
						return jz;
					}
				}
			}
			else if (num <= 9705568)
			{
				if (num == 8101441)
				{
					dz dz = new dz((d1)this.f.a(A_0));
					dz.cg().a(this.g, this.f);
					return dz;
				}
				if (num == 8736864)
				{
					pe pe = new pe((pf)this.f.a(A_0));
					pe.cg().a(this.g, this.f);
					return pe;
				}
				if (num == 9705568)
				{
					pm pm = new pm((pn)this.f.a(A_0));
					pm.cg().a(this.g, this.f);
					return pm;
				}
			}
			else if (num <= 627435190)
			{
				if (num == 306046640)
				{
					po po = new po((pp)this.f.a(A_0));
					po.cg().a(this.g, this.f);
					return po;
				}
				if (num == 627435190)
				{
					pq pq = new pq((pr)this.f.a(A_0));
					pq.cg().a(this.g, this.f);
					return pq;
				}
			}
			else
			{
				if (num == 627436437)
				{
					d5 d2 = new d5((d6)this.f.a(A_0));
					d2.cg().a(this.g, this.f);
					return d2;
				}
				if (num == 681579872)
				{
					pj pj = new pj((pk)this.f.a(A_0));
					pj.cg().a(this.g, this.f);
					return pj;
				}
			}
			return null;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x000782EC File Offset: 0x000772EC
		protected internal virtual void cq()
		{
			while (!this.g.af())
			{
				this.g.ai();
				if (this.g.t() && !this.g.aa())
				{
					this.cs(this.g.v());
				}
				else if (this.g.u())
				{
					if (this.l().v() == 10573487)
					{
						break;
					}
					if (this.l().v() == 1977)
					{
						this.cs(this.l().v());
					}
					this.d(this.g.v());
				}
				else if (this.g.aa())
				{
					this.r();
				}
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x000783E0 File Offset: 0x000773E0
		protected internal virtual void a(kg A_0, p1 A_1)
		{
			this.g = A_0;
			this.r();
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000783F4 File Offset: 0x000773F4
		protected internal virtual void cs(int A_0)
		{
			if (A_0 <= 2204613)
			{
				if (A_0 <= 2613)
				{
					if (A_0 <= 879)
					{
						if (A_0 <= 35)
						{
							if (A_0 <= 15)
							{
								if (A_0 == 1)
								{
									this.a(new eb(this.g, this.n));
									return;
								}
								if (A_0 == 15)
								{
									this.a(new ks(this.g, this.n));
									return;
								}
							}
							else
							{
								if (A_0 == 28)
								{
									this.a(new pc(this.g, this.n));
									return;
								}
								switch (A_0)
								{
								case 32:
									this.a(new ns(this.g, this.n));
									return;
								case 33:
									this.a(new pb(this.g, this.n));
									return;
								case 35:
									this.a(new qs(this.g, this.n));
									return;
								}
							}
						}
						else if (A_0 <= 431)
						{
							if (A_0 == 57)
							{
								this.a(new en(this.g, this.n));
								return;
							}
							if (A_0 == 431)
							{
								this.a(new j9(this.g, this.n));
								return;
							}
						}
						else
						{
							if (A_0 == 687)
							{
								this.a(new j7(this.g, this.n));
								return;
							}
							if (A_0 == 879)
							{
								this.a(new j5(this.g, this.n));
								return;
							}
						}
					}
					else if (A_0 <= 1717)
					{
						if (A_0 <= 1352)
						{
							if (A_0 == 1000)
							{
								this.a(null, new om(this.g, this.n));
								return;
							}
							if (A_0 == 1352)
							{
								this.a(new jv(this.g, this.n));
								return;
							}
						}
						else
						{
							if (A_0 == 1690)
							{
								this.a(new qq(this.g, this.n));
								return;
							}
							if (A_0 == 1717)
							{
								this.a(null, new jt(this.g, this.n));
								return;
							}
						}
					}
					else if (A_0 <= 1977)
					{
						if (A_0 == 1967)
						{
							this.a(new kf(this.g, this.n));
							return;
						}
						if (A_0 == 1977)
						{
							this.a(new em(this.g, this.n));
							return;
						}
					}
					else
					{
						if (A_0 == 2585)
						{
							this.a(new ox(this.g, this.n));
							return;
						}
						if (A_0 == 2595)
						{
							this.a(new jl(this.g, this.n));
							return;
						}
						if (A_0 == 2613)
						{
							this.a(new jq(this.g, this.n));
							return;
						}
					}
				}
				else if (A_0 <= 122967)
				{
					if (A_0 <= 3567)
					{
						if (A_0 <= 3375)
						{
							if (A_0 == 3119)
							{
								this.a(new j6(this.g, this.n));
								return;
							}
							if (A_0 == 3375)
							{
								this.a(new j8(this.g, this.n));
								return;
							}
						}
						else
						{
							if (A_0 == 3445)
							{
								this.a(null, new jf(this.g, this.n));
								return;
							}
							if (A_0 == 3567)
							{
								this.a(new ka(this.g, this.n));
								return;
							}
						}
					}
					else if (A_0 <= 46073)
					{
						if (A_0 == 34721)
						{
							this.g.f(true);
							this.a(new o9(this.g, this.n));
							this.g.d(0);
							this.g.f(false);
							return;
						}
						if (A_0 == 46073)
						{
							this.a(new ed(this.g, this.n));
							return;
						}
					}
					else
					{
						if (A_0 == 46415)
						{
							this.a(new kk(this.g, this.n));
							return;
						}
						if (A_0 == 95221)
						{
							this.a(new jp(this.g, this.n));
							return;
						}
						if (A_0 == 122967)
						{
							this.a(new qu(this.g, this.n));
							return;
						}
					}
				}
				else if (A_0 <= 154805)
				{
					if (A_0 <= 133455)
					{
						if (A_0 == 123893)
						{
							this.a(new jm(this.g, this.n));
							return;
						}
						if (A_0 == 133455)
						{
							this.a(new kr(this.g, this.n));
							return;
						}
					}
					else
					{
						if (A_0 == 137440)
						{
							this.a(new pv(this.g, this.n));
							return;
						}
						if (A_0 == 154805)
						{
							this.a(new jj(this.g, this.n));
							return;
						}
					}
				}
				else if (A_0 <= 220754)
				{
					if (A_0 == 164405)
					{
						this.a(new ji(this.g, this.n));
						return;
					}
					if (A_0 == 220754)
					{
						this.a(new kv(this.g, this.n));
						return;
					}
				}
				else
				{
					if (A_0 == 235744)
					{
						this.a(new pt(this.g, this.n));
						return;
					}
					if (A_0 == 369173)
					{
						this.g.ax();
						return;
					}
					if (A_0 == 2204613)
					{
						this.a(new e0(this.g, this.n));
						return;
					}
				}
			}
			else if (A_0 <= 139940850)
			{
				if (A_0 <= 8736864)
				{
					if (A_0 <= 5629554)
					{
						if (A_0 <= 2315845)
						{
							if (A_0 == 2228345)
							{
								if (this.i == null)
								{
									this.d();
								}
								else
								{
									this.g.g(2228345);
									this.g.ax();
								}
								return;
							}
							if (A_0 == 2315845)
							{
								this.a(new e2(this.g, this.n));
								return;
							}
						}
						else
						{
							if (A_0 == 4871144)
							{
								this.c();
								return;
							}
							if (A_0 == 5629554)
							{
								this.a(new j3(this.g, this.n));
								return;
							}
						}
					}
					else if (A_0 <= 8099429)
					{
						if (A_0 == 6968946)
						{
							this.a(new j0(this.g, this.n));
							return;
						}
						if (A_0 == 8099429)
						{
							this.f.a(new or(this.g));
							return;
						}
					}
					else
					{
						if (A_0 == 8101441)
						{
							this.a(new d1(this.g, this.n));
							return;
						}
						if (A_0 == 8736864)
						{
							this.a(new pf(this.g, this.n));
							return;
						}
					}
				}
				else if (A_0 <= 11228793)
				{
					if (A_0 <= 9705568)
					{
						if (A_0 == 9327125)
						{
							this.a(new oq(this.g, this.n));
							return;
						}
						if (A_0 == 9705568)
						{
							this.a(new pn(this.g, this.n));
							return;
						}
					}
					else
					{
						if (A_0 == 10573487)
						{
							if (this.l == null)
							{
								this.e();
							}
							else
							{
								this.g.g(10573487);
								this.g.ax();
							}
							return;
						}
						if (A_0 == 11228793)
						{
							this.g();
							return;
						}
					}
				}
				else if (A_0 <= 46574465)
				{
					if (A_0 == 23684646)
					{
						this.a(new qc(this.g, this.n));
						this.g.d(0);
						this.g.f(false);
						return;
					}
					if (A_0 == 46574465)
					{
						this.a(new eg(this.g, this.n));
						return;
					}
				}
				else
				{
					if (A_0 == 86147604)
					{
						this.a(new pi(this.g, this.n));
						return;
					}
					if (A_0 == 86163053)
					{
						this.a(new ov(this.g, this.n));
						return;
					}
					if (A_0 == 139940850)
					{
						this.g.g(139940850);
						return;
					}
				}
			}
			else if (A_0 <= 445520207)
			{
				if (A_0 <= 144877216)
				{
					if (A_0 <= 142298369)
					{
						if (A_0 == 141185593)
						{
							this.a(new ey(this.g, this.n));
							return;
						}
						if (A_0 == 142298369)
						{
							this.a(new d9(this.g, this.n));
							return;
						}
					}
					else
					{
						if (A_0 == 144810970)
						{
							this.a();
							return;
						}
						if (A_0 == 144877216)
						{
							this.b();
							return;
						}
					}
				}
				else if (A_0 <= 306046640)
				{
					if (A_0 == 144937050)
					{
						this.a(new p0(this.g, this.n));
						return;
					}
					if (A_0 == 306046640)
					{
						this.a(new pp(this.g, this.n));
						return;
					}
				}
				else
				{
					if (A_0 == 352709791)
					{
						this.g.g(352709791);
						this.g.ax();
						return;
					}
					if (A_0 == 426354867)
					{
						this.a(new eq(this.g, this.n));
						return;
					}
					if (A_0 == 445520207)
					{
						this.a(new kp(this.g, this.n));
						return;
					}
				}
			}
			else if (A_0 <= 622899778)
			{
				if (A_0 <= 557703508)
				{
					if (A_0 == 504715003)
					{
						this.g.g(504715003);
						this.g.ax();
						return;
					}
					if (A_0 == 557703508)
					{
						this.g.g(557703508);
						this.g.ax();
						return;
					}
				}
				else
				{
					if (A_0 == 594666565)
					{
						this.a(new op(this.g, this.n));
						return;
					}
					if (A_0 == 622899778)
					{
						this.a(new of(this.g, this.n));
						return;
					}
				}
			}
			else if (A_0 <= 627436437)
			{
				if (A_0 == 627435190)
				{
					this.a(new pr(this.g, this.n));
					return;
				}
				if (A_0 == 627436437)
				{
					this.a(new d6(this.g, this.n));
					return;
				}
			}
			else
			{
				if (A_0 == 673419368)
				{
					this.a(new ky(this.g, this.n));
					return;
				}
				if (A_0 == 681579872)
				{
					this.a(new pk(this.g, this.n));
					return;
				}
				if (A_0 == 899925938)
				{
					this.a(new jy(this.g, this.n));
					return;
				}
			}
			this.g.ax();
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00079114 File Offset: 0x00078114
		protected internal void d(int A_0)
		{
			if (this.f != null)
			{
				this.f.b(A_0);
			}
			this.g.ax();
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00079148 File Offset: 0x00078148
		protected internal void r()
		{
			if (!this.g.ab())
			{
				this.g.a(this);
			}
			else
			{
				this.g.b(this);
			}
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00079184 File Offset: 0x00078184
		internal void e(int A_0)
		{
			if (A_0 <= 164405)
			{
				if (A_0 <= 1690)
				{
					if (A_0 <= 28)
					{
						if (A_0 != 1 && A_0 != 15 && A_0 != 28)
						{
							return;
						}
					}
					else if (A_0 <= 57)
					{
						if (A_0 != 35 && A_0 != 57)
						{
							return;
						}
					}
					else if (A_0 != 1352 && A_0 != 1690)
					{
						return;
					}
				}
				else if (A_0 <= 122967)
				{
					if (A_0 != 46073 && A_0 != 46415 && A_0 != 122967)
					{
						return;
					}
				}
				else if (A_0 <= 137440)
				{
					if (A_0 != 133455 && A_0 != 137440)
					{
						return;
					}
				}
				else if (A_0 != 154805 && A_0 != 164405)
				{
					return;
				}
			}
			else if (A_0 <= 8736864)
			{
				if (A_0 <= 2204613)
				{
					if (A_0 != 220754 && A_0 != 235744 && A_0 != 2204613)
					{
						return;
					}
				}
				else if (A_0 <= 6968946)
				{
					if (A_0 != 2315845 && A_0 != 6968946)
					{
						return;
					}
				}
				else if (A_0 != 8101441 && A_0 != 8736864)
				{
					return;
				}
			}
			else if (A_0 <= 445520207)
			{
				if (A_0 <= 86147604)
				{
					if (A_0 != 9705568 && A_0 != 86147604)
					{
						return;
					}
				}
				else if (A_0 != 306046640 && A_0 != 445520207)
				{
					return;
				}
			}
			else if (A_0 <= 627436437)
			{
				if (A_0 != 627435190 && A_0 != 627436437)
				{
					return;
				}
			}
			else if (A_0 != 681579872 && A_0 != 841044683)
			{
				return;
			}
			if (!this.g.ab())
			{
				this.g.a(this, true);
			}
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00079350 File Offset: 0x00078350
		protected internal void a(jk A_0, om A_1)
		{
			og a_ = new og(A_0, A_1, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00079380 File Offset: 0x00078380
		protected internal void a(jk A_0, jt A_1)
		{
			jr a_ = new jr(A_0, A_1, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x000793B0 File Offset: 0x000783B0
		protected internal void a(jk A_0, jf A_1)
		{
			jd a_ = new jd(A_0, A_1, this.f, this.g, this.n);
			this.a(a_);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x000793E0 File Offset: 0x000783E0
		protected internal void s()
		{
			int[] array = new int[]
			{
				2315845,
				9705568,
				8101441,
				2204613,
				220754,
				8736864,
				122967,
				154805,
				627436437,
				841044683
			};
			foreach (int a_ in array)
			{
				if (this.f != null && this.f.e(a_))
				{
					this.f.b(a_);
				}
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00079450 File Offset: 0x00078450
		protected internal void a(p1 A_0, int A_1)
		{
			if (A_0.a() > 0)
			{
				dy dy = this.a(A_0.a() - 1);
				if (dy != null && this.b(A_1, 0))
				{
					dy.cl(false);
				}
				if (dy != null)
				{
					for (int i = A_0.a() - 2; i >= 0; i--)
					{
						dy dy2 = this.a(i, A_0);
						dy2.e(true);
						if (dy2 != null)
						{
							dy2.cg().a(dy);
							if (dy.ch().cn() == 1)
							{
								dy2.cg().b(this.g);
							}
							dy = dy2;
							this.l().ay();
						}
					}
					this.a(dy);
				}
				else
				{
					this.l().ay();
				}
			}
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00079540 File Offset: 0x00078540
		protected bool b(int A_0, int A_1)
		{
			if (A_0 <= 3445)
			{
				if (A_0 <= 1967)
				{
					if (A_0 <= 879)
					{
						if (A_0 <= 431)
						{
							if (A_0 != 33 && A_0 != 431)
							{
								goto IL_214;
							}
						}
						else if (A_0 != 687 && A_0 != 879)
						{
							goto IL_214;
						}
					}
					else if (A_0 <= 1717)
					{
						if (A_0 != 1000 && A_0 != 1717)
						{
							goto IL_214;
						}
					}
					else if (A_0 != 1946 && A_0 != 1967)
					{
						goto IL_214;
					}
				}
				else if (A_0 <= 3034)
				{
					if (A_0 <= 2595)
					{
						if (A_0 != 2585 && A_0 != 2595)
						{
							goto IL_214;
						}
					}
					else if (A_0 != 2613 && A_0 != 3034)
					{
						goto IL_214;
					}
				}
				else if (A_0 <= 3375)
				{
					if (A_0 != 3119 && A_0 != 3375)
					{
						goto IL_214;
					}
				}
				else if (A_0 != 3418 && A_0 != 3445)
				{
					goto IL_214;
				}
			}
			else if (A_0 <= 141185593)
			{
				if (A_0 <= 123893)
				{
					if (A_0 <= 34721)
					{
						if (A_0 != 3567 && A_0 != 34721)
						{
							goto IL_214;
						}
					}
					else if (A_0 != 95221 && A_0 != 123893)
					{
						goto IL_214;
					}
				}
				else if (A_0 <= 5629554)
				{
					if (A_0 != 165445 && A_0 != 5629554)
					{
						goto IL_214;
					}
				}
				else if (A_0 != 9327125 && A_0 != 141185593)
				{
					goto IL_214;
				}
			}
			else if (A_0 <= 442866842)
			{
				if (A_0 <= 144937050)
				{
					if (A_0 != 142298369 && A_0 != 144937050)
					{
						goto IL_214;
					}
				}
				else if (A_0 != 258605815 && A_0 != 442866842)
				{
					goto IL_214;
				}
			}
			else if (A_0 <= 594666565)
			{
				if (A_0 != 506116087 && A_0 != 594666565)
				{
					goto IL_214;
				}
			}
			else if (A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_214;
			}
			if (A_1 != 0)
			{
				this.l().f(A_1);
			}
			return true;
			IL_214:
			return false;
		}

		// Token: 0x04000489 RID: 1161
		internal const string a = "(^\\s*print\\s*$|^\\s*only\\s+print\\s*$|^\\s*all\\s*$)";

		// Token: 0x0400048A RID: 1162
		internal const string b = "text/css";

		// Token: 0x0400048B RID: 1163
		internal const string c = "print";

		// Token: 0x0400048C RID: 1164
		internal const string d = ".css";

		// Token: 0x0400048D RID: 1165
		private List<dy> e = new List<dy>();

		// Token: 0x0400048E RID: 1166
		private p1 f = null;

		// Token: 0x0400048F RID: 1167
		private kg g = null;

		// Token: 0x04000490 RID: 1168
		private h4 h = null;

		// Token: 0x04000491 RID: 1169
		private Uri i = null;

		// Token: 0x04000492 RID: 1170
		private string j = string.Empty;

		// Token: 0x04000493 RID: 1171
		private string k = string.Empty;

		// Token: 0x04000494 RID: 1172
		private ej l = null;

		// Token: 0x04000495 RID: 1173
		private kh m = null;

		// Token: 0x04000496 RID: 1174
		private ij n = null;

		// Token: 0x04000497 RID: 1175
		private HtmlArea o = null;
	}
}
