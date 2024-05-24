using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F9 RID: 1785
	public class PdfPage
	{
		// Token: 0x06004564 RID: 17764 RVA: 0x00238064 File Offset: 0x00237064
		internal PdfPage(abj A_0, int A_1, acf A_2)
		{
			this.b = A_0;
			this.a = A_1;
			this.g = A_2;
		}

		// Token: 0x06004565 RID: 17765 RVA: 0x00238100 File Offset: 0x00237100
		internal abj a()
		{
			return this.b;
		}

		// Token: 0x06004566 RID: 17766 RVA: 0x00238118 File Offset: 0x00237118
		internal int b()
		{
			return 4;
		}

		// Token: 0x06004567 RID: 17767 RVA: 0x0023812C File Offset: 0x0023712C
		public string GetDictionaryValue(string key)
		{
			int num = abu.a(key);
			for (abk abk = this.b.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == num && abk.a().j9() == key)
				{
					abd abd = abk.c();
					return string.Empty;
				}
			}
			return string.Empty;
		}

		// Token: 0x06004568 RID: 17768 RVA: 0x002381AC File Offset: 0x002371AC
		internal int c()
		{
			return this.u;
		}

		// Token: 0x06004569 RID: 17769 RVA: 0x002381C4 File Offset: 0x002371C4
		internal aby d()
		{
			this.l();
			if (this.j == null)
			{
				this.j = new aby(this.c);
			}
			return this.j;
		}

		// Token: 0x0600456A RID: 17770 RVA: 0x00238208 File Offset: 0x00237208
		public byte[] GetContents()
		{
			byte[] result;
			if (this.d() != null)
			{
				result = this.d().c();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600456B RID: 17771 RVA: 0x00238238 File Offset: 0x00237238
		internal int e()
		{
			return this.a;
		}

		// Token: 0x0600456C RID: 17772 RVA: 0x00238250 File Offset: 0x00237250
		internal db f()
		{
			this.l();
			return this.q;
		}

		// Token: 0x0600456D RID: 17773 RVA: 0x00238270 File Offset: 0x00237270
		internal int g()
		{
			this.l();
			return this.h;
		}

		// Token: 0x0600456E RID: 17774 RVA: 0x00238290 File Offset: 0x00237290
		internal abd h()
		{
			this.l();
			return this.c;
		}

		// Token: 0x0600456F RID: 17775 RVA: 0x002382B0 File Offset: 0x002372B0
		internal acd i()
		{
			this.l();
			return this.e;
		}

		// Token: 0x06004570 RID: 17776 RVA: 0x002382D0 File Offset: 0x002372D0
		public PageDimensions GetDimensions()
		{
			this.l();
			return this.e.b();
		}

		// Token: 0x06004571 RID: 17777 RVA: 0x002382F4 File Offset: 0x002372F4
		internal acc j()
		{
			this.l();
			return this.f;
		}

		// Token: 0x06004572 RID: 17778 RVA: 0x00238314 File Offset: 0x00237314
		internal ace k()
		{
			this.l();
			return this.d;
		}

		// Token: 0x06004573 RID: 17779 RVA: 0x00238334 File Offset: 0x00237334
		internal void l()
		{
			if (!this.i)
			{
				this.d = this.g.b();
				this.h = this.g.d();
				this.e = this.g.c();
				if (this.e == null)
				{
					this.e = new acd();
				}
				for (abk abk = this.b.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num <= 63633402)
					{
						if (num <= 29027271)
						{
							if (num <= 5380275)
							{
								if (num != 2)
								{
									if (num == 5380275)
									{
										this.r = true;
									}
								}
								else
								{
									this.q = new db((abe)abk.c().h6());
									abk.a(false);
								}
							}
							else if (num != 5479461)
							{
								if (num == 29027271)
								{
									abd abd = abk.c().h6();
									if (abd != null)
									{
										if (abd.hy() == ag9.e)
										{
											this.f = new acc(this.b.k().b().m(), (abe)abk.c().h6(), this);
										}
										abk.a(false);
									}
								}
							}
							else
							{
								abk.a(false);
							}
						}
						else if (num <= 45249180)
						{
							if (num != 30097559)
							{
								if (num == 45249180)
								{
									this.e.d(new ab5((abe)abk.c().h6()));
									abk.a(false);
								}
							}
							else
							{
								this.e.f(new ab5((abe)abk.c().h6()));
								abk.a(false);
							}
						}
						else if (num != 62652438)
						{
							if (num == 63633402)
							{
								this.e.c(new ab5((abe)abk.c().h6()));
								abk.a(false);
							}
						}
						else
						{
							this.c = abk.c();
							abd abd2 = this.c.h6();
							if (abd2 != null && abd2.hy() == ag9.e)
							{
								this.c = abd2;
							}
							abk.a(false);
						}
					}
					else if (num <= 308085382)
					{
						if (num <= 227959193)
						{
							if (num != 130743664)
							{
								if (num == 227959193)
								{
									this.e.b(new ab5((abe)abk.c().h6()));
									abk.a(false);
								}
							}
							else if (abk.c().hy() == ag9.g)
							{
								this.t = (abj)abk.c();
							}
						}
						else if (num != 277293402)
						{
							if (num == 308085382)
							{
								this.d = new ace((abj)abk.c().h6());
								abk.a(false);
							}
						}
						else
						{
							abk.a(false);
						}
					}
					else if (num <= 348819642)
					{
						if (num != 314525777)
						{
							if (num == 348819642)
							{
								this.e.e(new ab5((abe)abk.c().h6()));
								abk.a(false);
							}
						}
						else
						{
							this.h = ((abw)abk.c().h6()).kd();
							abk.a(false);
						}
					}
					else if (num != 664001781)
					{
						if (num == 735301909)
						{
							if (abk.c().hy() == ag9.j)
							{
								abd abd3 = abk.c().h6();
								this.e.g(new ab5((abe)abd3));
							}
							else
							{
								this.e.g(new ab5((abe)abk.c()));
							}
							abk.a(false);
						}
					}
					else
					{
						this.l = true;
						this.u = ((abw)abk.c()).kd();
						abk.a(false);
					}
				}
				this.e.c();
				this.i = true;
			}
		}

		// Token: 0x06004574 RID: 17780 RVA: 0x00238800 File Offset: 0x00237800
		internal bool m()
		{
			return this.i;
		}

		// Token: 0x06004575 RID: 17781 RVA: 0x00238818 File Offset: 0x00237818
		internal void a(abe A_0, aba A_1)
		{
			for (int i = 0; i < A_0.a(); i++)
			{
				abj abj = (abj)A_0.a(i).h6();
				for (abk abk = abj.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num == 403)
					{
						abj a_ = (abj)abk.c().h6();
						this.a(a_, A_1);
					}
				}
			}
		}

		// Token: 0x06004576 RID: 17782 RVA: 0x002388A4 File Offset: 0x002378A4
		private void a(abj A_0, aba A_1)
		{
			Attachment item = new Attachment(A_0, A_1);
			this.b.k().b().e().Add(item);
		}

		// Token: 0x06004577 RID: 17783 RVA: 0x002388D8 File Offset: 0x002378D8
		internal bool n()
		{
			return this.r;
		}

		// Token: 0x06004578 RID: 17784 RVA: 0x002388F0 File Offset: 0x002378F0
		internal int o()
		{
			return this.k;
		}

		// Token: 0x06004579 RID: 17785 RVA: 0x00238908 File Offset: 0x00237908
		internal void a(int A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600457A RID: 17786 RVA: 0x00238914 File Offset: 0x00237914
		internal bool p()
		{
			return this.l;
		}

		// Token: 0x0600457B RID: 17787 RVA: 0x0023892C File Offset: 0x0023792C
		internal acf q()
		{
			return this.g;
		}

		// Token: 0x0600457C RID: 17788 RVA: 0x00238944 File Offset: 0x00237944
		internal aba r()
		{
			return this.b.k().b().f().k8();
		}

		// Token: 0x0600457D RID: 17789 RVA: 0x00238970 File Offset: 0x00237970
		internal int s()
		{
			return this.m;
		}

		// Token: 0x0600457E RID: 17790 RVA: 0x00238988 File Offset: 0x00237988
		internal void b(int A_0)
		{
			this.m = A_0;
		}

		// Token: 0x0600457F RID: 17791 RVA: 0x00238994 File Offset: 0x00237994
		internal abj t()
		{
			return this.t;
		}

		// Token: 0x06004580 RID: 17792 RVA: 0x002389AC File Offset: 0x002379AC
		public string GetText()
		{
			dg dg = new dg(1);
			this.a(dg.a()[0]);
			dg.a(this.n, this.k().c(), this.r(), 0);
			if (this.p.Count > 0)
			{
				foreach (object obj in this.p)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					dg.a(this.o, (abj)dictionaryEntry.Value, dictionaryEntry.Key.ToString(), 0);
				}
			}
			byte[] contents = this.GetContents();
			if (contents != null)
			{
				this.a(contents, dg.a()[0], dg.c(), dg.b(), 0, null);
			}
			string text = dg.a(0, -1f, -1f, -1f, -1f);
			string result;
			if (aae.c(13))
			{
				result = text;
			}
			else
			{
				string value = "[DynamicPDF Evaluation] ";
				StringBuilder stringBuilder = new StringBuilder(value);
				stringBuilder.Append(text);
				if (text.Length <= 256)
				{
					stringBuilder.Append(" [Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
				else
				{
					int num = 280;
					stringBuilder.Remove(num, stringBuilder.Length - num);
					stringBuilder.Append(" ....[Text Truncated - Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x06004581 RID: 17793 RVA: 0x00238B68 File Offset: 0x00237B68
		public string GetText(float x, float y, float width, float height)
		{
			dg dg = new dg(1);
			this.a(dg.a()[0]);
			dg.a(this.n, this.k().c(), this.r(), 0);
			if (this.p.Count > 0)
			{
				foreach (object obj in this.p)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					dg.a(this.o, (abj)dictionaryEntry.Value, dictionaryEntry.Key.ToString(), 0);
				}
			}
			byte[] contents = this.GetContents();
			if (contents != null)
			{
				this.a(contents, dg.a()[0], dg.c(), dg.b(), 0, null);
			}
			string text = dg.a(0, this.i().b().aw(x), this.i().b().GetPdfY(y), this.i().b().aw(x + width), this.i().b().GetPdfY(y + height));
			string result;
			if (aae.c(13))
			{
				result = text;
			}
			else
			{
				string value = "[DynamicPDF Evaluation] ";
				StringBuilder stringBuilder = new StringBuilder(value);
				stringBuilder.Append(text);
				if (text.Length <= 256)
				{
					stringBuilder.Append(" [Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
				else
				{
					int num = 280;
					stringBuilder.Remove(num, stringBuilder.Length - num);
					stringBuilder.Append(" ....[Text Truncated - Please purchase a license or contact support for an evaluation license.]");
					result = stringBuilder.ToString();
				}
			}
			return result;
		}

		// Token: 0x06004582 RID: 17794 RVA: 0x00238D58 File Offset: 0x00237D58
		internal void a(df A_0)
		{
			if (this.k() != null)
			{
				if (this.k().c() != null)
				{
					this.a(this.k().c());
				}
				abj abj = this.k().d();
				if (abj != null)
				{
					this.a(this.GetContents(), abj);
				}
			}
		}

		// Token: 0x06004583 RID: 17795 RVA: 0x00238DBC File Offset: 0x00237DBC
		private void a(abj A_0)
		{
			string text = A_0.j();
			if (text != string.Empty)
			{
				if (text[0] == '/')
				{
					text = text.Substring(1).Trim(new char[]
					{
						' ',
						'<',
						'>'
					});
				}
				if (this.n == null && this.k().c() != null)
				{
					this.n = text.Split(new char[]
					{
						'/'
					});
					for (int i = 0; i < this.n.Length; i++)
					{
						this.n[i] = this.n[i].Substring(this.n[i].IndexOf(' ') + 1).Trim();
					}
					if (this.n[this.n.Length - 1] == "")
					{
						Array.Resize<string>(ref this.n, this.n.Length - 1);
					}
				}
				else
				{
					string[] array = text.Split(new char[]
					{
						'/'
					});
					for (int i = 0; i < array.Length; i++)
					{
						string item = array[i].Substring(array[i].IndexOf(' ') + 1).Trim();
						if (!this.o.Contains(item))
						{
							this.o.Add(item);
						}
					}
				}
			}
		}

		// Token: 0x06004584 RID: 17796 RVA: 0x00238F4C File Offset: 0x00237F4C
		private void a(byte[] A_0, abj A_1)
		{
			abj abj = null;
			ace ace = null;
			List<string> list = new List<string>();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] == 68 && A_0[i + 1] == 111 && (i + 2 >= A_0.Length || (A_0[i + 2] == 32 || A_0[i + 2] == 10) || A_0[i + 2] == 13))
				{
					byte[] array = new byte[arrayList.Count];
					arrayList.CopyTo(array);
					Encoding encoding = ae5.a(1252);
					string text = encoding.GetString(array);
					text = text.Trim();
					string[] array2 = text.Substring(text.LastIndexOf(' ') + 1, text.Length - (text.LastIndexOf(' ') + 1)).Split(new char[]
					{
						'\n'
					});
					list.Add(array2[array2.Length - 1]);
					arrayList = new ArrayList();
				}
				else
				{
					arrayList.Add(A_0[i]);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				string text2 = list[i].Substring(list[i].IndexOf('/') + 1);
				abk abk = A_1.l();
				abj abj2 = null;
				while (abk != null)
				{
					if (abk.a().j9().Equals(text2))
					{
						if (abk.c().hy() == ag9.j)
						{
							abj2 = (abj)abk.c().h6();
							break;
						}
					}
					else
					{
						abk = abk.d();
					}
				}
				if (abj2 != null)
				{
					byte[] array3 = null;
					if (abj2 is afj && ((afj)abj2).n() != ag0.c)
					{
						array3 = ((afj)abj2).j4();
					}
					for (abk abk2 = abj2.l(); abk2 != null; abk2 = abk2.d())
					{
						if (abk2.a().j8() == 308085382)
						{
							ace = new ace((abj)abk2.c().h6());
							if (ace != null)
							{
								abj = ace.c();
							}
							break;
						}
					}
					if (abj != null)
					{
						this.a(abj);
					}
					if (((afj)abj2).n() != ag0.c)
					{
						if (((afj)abj2).c() || ((afj)abj2).d() || ((afj)abj2).b() || ((afj)abj2).n() == ag0.b)
						{
							if (!this.s.ContainsKey(text2))
							{
								if (ace != null && ace.d() != null)
								{
									this.a(array3, ace.d());
								}
								if (!this.s.ContainsKey(text2))
								{
									this.s.Add(text2, array3);
									if (abj != null)
									{
										this.p.Add(text2, abj);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06004585 RID: 17797 RVA: 0x002392DC File Offset: 0x002382DC
		internal void a(byte[] A_0, df A_1, Hashtable A_2, Hashtable A_3, int A_4, List<string> A_5)
		{
			if (this.v == null)
			{
				this.v = new afg();
				this.v.a = null;
				this.v.b = null;
				this.v.c = 0f;
				this.v.d = new ArrayList();
				this.v.e = null;
				this.v.f = new Stack();
				this.v.g = new Stack();
				this.v.h = new Stack();
				this.v.i = 0f;
				this.v.d = this.a(this.v.d);
				this.v.e = this.a(ref this.v.d);
			}
			ahb ahb = new ahb(A_0);
			ahc ahc;
			while ((ahc = ahb.g()) != ahc.a)
			{
				ahc ahc2 = ahc;
				if (ahc2 <= ahc.ag)
				{
					if (ahc2 <= ahc.t)
					{
						if (ahc2 != ahc.u)
						{
							if (ahc2 == ahc.t)
							{
								if (this.v.e != null)
								{
									this.v.d = this.a(this.v.d, this.v.e);
								}
								if (this.v.a != null)
								{
									this.v.f.Push(this.v.a);
								}
								if (this.v.i != 0f)
								{
									this.v.g.Push(this.v.i);
								}
								if (this.v.b != null)
								{
									this.v.h.Push(this.v.b);
								}
							}
						}
						else
						{
							this.v.e = this.a(ref this.v.d);
							if (this.v.f.Count > 0)
							{
								this.v.a = new float?((float)this.v.f.Peek());
								this.v.f.Pop();
							}
							if (this.v.g.Count > 0)
							{
								this.v.i = (float)this.v.g.Peek();
								this.v.g.Pop();
							}
							if (this.v.h.Count > 0)
							{
								this.v.b = (string)this.v.h.Peek();
								this.v.h.Pop();
							}
						}
					}
					else if (ahc2 != ahc.af)
					{
						if (ahc2 == ahc.ag)
						{
							string text;
							if (A_5 == null || A_5.Count == 0)
							{
								text = null;
							}
							else
							{
								text = A_5[A_5.Count - 1];
							}
							ahb.a(ref this.v.a, this.v.e, ref this.v.b, ref this.v.c, ref this.v.i, text, A_1);
						}
					}
					else
					{
						ahb.k();
					}
				}
				else if (ahc2 <= ahc.ba)
				{
					if (ahc2 != ahc.an)
					{
						if (ahc2 == ahc.ba)
						{
							this.v.a = ahb.i();
						}
					}
					else
					{
						string text = ahb.h();
						bool flag = true;
						if (A_5 == null)
						{
							A_5 = new List<string>();
						}
						else
						{
							foreach (string text2 in A_5)
							{
								if (text2 == text)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && this.s.ContainsKey(text))
						{
							byte[] a_ = (byte[])this.s[text];
							A_5.Add(text);
							this.a(a_, A_1, A_2, A_3, A_4, A_5);
							A_5.Remove(text);
						}
					}
				}
				else if (ahc2 != ahc.a7)
				{
					if (ahc2 == ahc.ai)
					{
						float[] a_2 = ahb.j();
						this.v.e = ahb.b(a_2, this.v.e);
					}
				}
				else
				{
					this.v.b = ahb.a(ref this.v.c);
					this.v.i = this.v.c;
				}
			}
			if (A_5 == null)
			{
				this.v = null;
			}
		}

		// Token: 0x06004586 RID: 17798 RVA: 0x00239868 File Offset: 0x00238868
		private string a(ref float A_0, string A_1, string A_2, float A_3, string A_4)
		{
			if (A_1 == null)
			{
				A_1 = A_2;
				if (A_4 != null)
				{
					string[] array = A_4.Split(new char[]
					{
						' '
					});
					if (A_0 == 0f)
					{
						A_0 = float.Parse(array[3], CultureInfo.InvariantCulture);
					}
					else if (float.Parse(array[3], CultureInfo.InvariantCulture) > 1f)
					{
						A_0 = float.Parse(array[3], CultureInfo.InvariantCulture);
					}
					else
					{
						A_0 *= float.Parse(array[3], CultureInfo.InvariantCulture);
					}
				}
				else
				{
					A_0 = A_3;
				}
			}
			else if (A_0 == 0f)
			{
				A_0 = A_3;
			}
			return A_1;
		}

		// Token: 0x06004587 RID: 17799 RVA: 0x0023992C File Offset: 0x0023892C
		private ArrayList a(ArrayList A_0)
		{
			float[,] array = new float[3, 3];
			array[0, 0] = 1f;
			array[0, 1] = 0f;
			array[0, 2] = 0f;
			array[1, 0] = 0f;
			array[1, 1] = 1f;
			array[1, 2] = 0f;
			array[2, 0] = 0f;
			array[2, 1] = 0f;
			array[2, 2] = 1f;
			A_0.Add(array);
			return A_0;
		}

		// Token: 0x06004588 RID: 17800 RVA: 0x002399C4 File Offset: 0x002389C4
		private ArrayList a(ArrayList A_0, float[,] A_1)
		{
			A_0.Add(A_1);
			return A_0;
		}

		// Token: 0x06004589 RID: 17801 RVA: 0x002399E0 File Offset: 0x002389E0
		private float[,] a(ref ArrayList A_0)
		{
			float[,] result = (float[,])A_0[A_0.Count - 1];
			A_0.RemoveAt(A_0.Count - 1);
			if (A_0.Count == 0)
			{
				A_0 = this.a(A_0);
			}
			return result;
		}

		// Token: 0x0600458A RID: 17802 RVA: 0x00239A38 File Offset: 0x00238A38
		internal string[] u()
		{
			return this.n;
		}

		// Token: 0x0600458B RID: 17803 RVA: 0x00239A50 File Offset: 0x00238A50
		internal List<string> v()
		{
			return this.o;
		}

		// Token: 0x0600458C RID: 17804 RVA: 0x00239A68 File Offset: 0x00238A68
		internal Hashtable w()
		{
			return this.p;
		}

		// Token: 0x04002687 RID: 9863
		private int a;

		// Token: 0x04002688 RID: 9864
		private abj b;

		// Token: 0x04002689 RID: 9865
		private abd c;

		// Token: 0x0400268A RID: 9866
		private ace d;

		// Token: 0x0400268B RID: 9867
		private acd e;

		// Token: 0x0400268C RID: 9868
		private acc f;

		// Token: 0x0400268D RID: 9869
		private acf g;

		// Token: 0x0400268E RID: 9870
		private int h = 0;

		// Token: 0x0400268F RID: 9871
		private bool i = false;

		// Token: 0x04002690 RID: 9872
		private aby j = null;

		// Token: 0x04002691 RID: 9873
		private int k = -1;

		// Token: 0x04002692 RID: 9874
		private bool l = false;

		// Token: 0x04002693 RID: 9875
		private int m = -1;

		// Token: 0x04002694 RID: 9876
		private string[] n = null;

		// Token: 0x04002695 RID: 9877
		private List<string> o = new List<string>();

		// Token: 0x04002696 RID: 9878
		private Hashtable p = new Hashtable();

		// Token: 0x04002697 RID: 9879
		private db q = null;

		// Token: 0x04002698 RID: 9880
		private bool r = false;

		// Token: 0x04002699 RID: 9881
		private Hashtable s = new Hashtable();

		// Token: 0x0400269A RID: 9882
		private abj t;

		// Token: 0x0400269B RID: 9883
		private int u = -1;

		// Token: 0x0400269C RID: 9884
		private afg v = null;
	}
}
