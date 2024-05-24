using System;
using System.Collections;
using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000089 RID: 137
	internal class c2 : Font
	{
		// Token: 0x0600063F RID: 1599 RVA: 0x0005BB28 File Offset: 0x0005AB28
		internal c2(abd A_0) : base(Encoder.Unicode)
		{
			this.e = A_0;
			this.e();
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0005BBC8 File Offset: 0x0005ABC8
		public override short get_Descender()
		{
			short descender;
			if (this.j != null)
			{
				descender = this.j.Descender;
			}
			else
			{
				descender = this.c;
			}
			return descender;
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0005BBFC File Offset: 0x0005ABFC
		public override short get_Ascender()
		{
			short ascender;
			if (this.j != null)
			{
				ascender = this.j.Ascender;
			}
			else
			{
				ascender = this.b;
			}
			return ascender;
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0005BC30 File Offset: 0x0005AC30
		internal override short bc()
		{
			return 0;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0005BC44 File Offset: 0x0005AC44
		internal override short bd()
		{
			return 0;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0005BC58 File Offset: 0x0005AC58
		internal override short be()
		{
			return 0;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0005BC6C File Offset: 0x0005AC6C
		internal override short bf()
		{
			return 0;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0005BC80 File Offset: 0x0005AC80
		public override LineBreaker get_LineBreaker()
		{
			LineBreaker result;
			if (this.j != null)
			{
				result = this.j.LineBreaker;
			}
			else
			{
				result = LineBreaker.Default;
			}
			return result;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0005BCB4 File Offset: 0x0005ACB4
		public override string get_Name()
		{
			string result;
			if (this.d != null && this.d != string.Empty)
			{
				result = this.d;
			}
			else if (this.j != null)
			{
				result = this.j.Name;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0005BD14 File Offset: 0x0005AD14
		public override short get_LineGap()
		{
			short lineGap;
			if (this.j != null)
			{
				lineGap = this.j.LineGap;
			}
			else
			{
				lineGap = base.LineGap;
			}
			return lineGap;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0005BD48 File Offset: 0x0005AD48
		internal override string bg()
		{
			string name;
			if (this.l != null && this.l != string.Empty)
			{
				name = this.l;
			}
			else
			{
				name = this.Name;
			}
			return name;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0005BD8C File Offset: 0x0005AD8C
		internal override short bh()
		{
			short result;
			if (this.j != null)
			{
				result = this.j.bh();
			}
			else
			{
				result = this.Ascender;
			}
			return result;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0005BDC0 File Offset: 0x0005ADC0
		internal override short bi()
		{
			short result;
			if (this.j != null)
			{
				result = this.j.bi();
			}
			else
			{
				result = this.Descender;
			}
			return result;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0005BDF4 File Offset: 0x0005ADF4
		internal override void bj(DocumentWriter A_0)
		{
			if (this.a() != null)
			{
				abg abg = this.a().b().m().b((long)this.a().c());
				abg.a(A_0);
			}
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0005BE3C File Offset: 0x0005AE3C
		public override short GetGlyphWidth(char glyph)
		{
			short result = 0;
			if (this.a != null && (int)glyph >= this.h && (int)glyph <= this.i)
			{
				result = this.a[(int)glyph - this.h];
			}
			else if (this.j != null)
			{
				result = this.j.GetGlyphWidth(glyph);
			}
			return result;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0005BEA3 File Offset: 0x0005AEA3
		public override void Draw(DocumentWriter writer)
		{
			this.e.hz(writer);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0005BEB4 File Offset: 0x0005AEB4
		private new void e()
		{
			this.c();
			if (!this.o)
			{
				if (this.m.Count == 0)
				{
					this.n = false;
					string text = string.Empty;
					if (this.l != string.Empty)
					{
						if (this.l.IndexOf("+") > 0)
						{
							text = this.l.Substring(this.l.IndexOf("+") + 1, this.l.Length - (this.l.IndexOf("+") + 1));
						}
						else
						{
							text = this.l;
						}
					}
					text = text.Replace(",", string.Empty);
					text = text.Replace("-", string.Empty);
					this.j = r8.b(text, false);
					if (this.j == null && this.a == null)
					{
						this.n = false;
					}
				}
			}
			else
			{
				this.n = false;
			}
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0005BFD4 File Offset: 0x0005AFD4
		private new void c()
		{
			abj abj = (abj)this.e.h6();
			if (abj != null)
			{
				this.d(abj);
				if (abj.n() != ag0.e && this.g != null)
				{
					this.a(this.g);
					this.m.Add(this.e);
				}
				else if (abj.n() == ag0.f)
				{
					this.m.Add(this.e);
				}
			}
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0005C070 File Offset: 0x0005B070
		private new void d(abj A_0)
		{
			abj abj = null;
			abj abj2 = null;
			abj abj3 = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 111780998)
				{
					if (num <= 42320626)
					{
						if (num != 3808101)
						{
							if (num == 42320626)
							{
								this.l = ((abu)abk.c()).j9();
							}
						}
						else
						{
							this.d = ((abu)abk.c()).j9();
							if (this.d.IndexOf('+') > 0)
							{
								this.d = null;
							}
						}
					}
					else if (num != 95985731)
					{
						if (num == 111780998)
						{
							this.h = ((abw)abk.c()).kd();
						}
					}
					else
					{
						if (abk.c().hy() == ag9.d)
						{
							this.f = ((abu)abk.c()).j9();
						}
						else if (abk.c().hy() == ag9.g)
						{
							abj2 = (abj)abk.c();
						}
						else if (abk.c().hy() == ag9.j)
						{
							abd abd = abk.c().h6();
							if (abd.hy() == ag9.g)
							{
								abj2 = (abj)abd;
							}
							else if (abd is afl)
							{
								this.f = ((afl)abd).j9();
							}
						}
						if (abj2 != null)
						{
							this.a(abj2);
						}
						else if (this.f == "WinAnsiEncoding")
						{
							base.a(Encoder.Latin1);
						}
					}
				}
				else if (num <= 396774683)
				{
					if (num != 210089329)
					{
						if (num == 396774683)
						{
							abe abe;
							if (abk.c().hy() == ag9.j)
							{
								abe = (abe)abk.c().h6();
							}
							else
							{
								abe = (abe)abk.c();
							}
							this.a = new short[abe.a()];
							for (int i = 0; i < abe.a(); i++)
							{
								this.a[i] = (short)((abw)abe.a(i)).kd();
							}
						}
					}
					else
					{
						this.i = ((abw)abk.c()).kd();
					}
				}
				else if (num != 598973023)
				{
					if (num == 750505570)
					{
						abe abe2 = (abe)abk.c().h6();
						abj3 = (abj)abe2.a(0).h6();
					}
				}
				else
				{
					abj = (abj)abk.c().h6();
					if (abj != null)
					{
						this.a(abj);
					}
				}
			}
			if (abj3 != null)
			{
				this.c(abj3);
			}
			if (abj != null)
			{
				this.b(abj);
			}
			if (this.f == "MacRomanEncoding")
			{
				base.a(Encoder.a());
			}
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0005C414 File Offset: 0x0005B414
		private new void c(abj A_0)
		{
			abj abj = null;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 42320626)
				{
					if (num == 598973023)
					{
						abj = (abj)abk.c().h6();
					}
				}
				else
				{
					this.l = ((abu)abk.c()).j9();
					this.d = this.l;
					if (this.d.IndexOf('+') > 0)
					{
						this.d = null;
					}
				}
			}
			if (abj != null)
			{
				this.b(abj);
			}
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0005C4C8 File Offset: 0x0005B4C8
		private new void b(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 77017937)
				{
					if (num != 30292314)
					{
						if (num != 60954087)
						{
							if (num == 77017937)
							{
								this.c = (short)((abw)abk.c()).kd();
							}
						}
					}
					else
					{
						this.b = (short)((abw)abk.c()).kd();
					}
				}
				else if (num <= 113014307)
				{
					switch (num)
					{
					case 102245492:
						if (abk.c().hy() == ag9.j && !this.k.Equals("Type0"))
						{
							this.g = (afj)abk.c().h6();
						}
						break;
					case 102245493:
						if (abk.c().hy() == ag9.j && !this.k.Equals("Type0"))
						{
							this.g = (afj)abk.c().h6();
						}
						break;
					default:
						if (num == 113014307)
						{
							this.o = true;
						}
						break;
					}
				}
				else if (num != 113047147)
				{
					if (num != 654865983)
					{
					}
				}
				else
				{
					this.d = ((abu)abk.c()).j9();
					if (this.d.IndexOf('+') > 0)
					{
						this.d = null;
					}
				}
			}
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0005C67C File Offset: 0x0005B67C
		private new void a(afj A_0)
		{
			if (this.j == null)
			{
				if (A_0.n() == ag0.g)
				{
					this.o = true;
				}
				else if (!(this.l != string.Empty) || this.l.IndexOf('+') <= 0)
				{
					byte[] buffer = A_0.j4();
					MemoryStream reader = new MemoryStream(buffer);
					this.j = new OpenTypeFont(reader, this.LineBreaker);
				}
			}
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0005C70C File Offset: 0x0005B70C
		internal new bool f()
		{
			return this.n;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0005C724 File Offset: 0x0005B724
		private new ab6 a()
		{
			return (ab6)this.e;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0005C744 File Offset: 0x0005B744
		internal new Font i()
		{
			return this.j;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0005C75C File Offset: 0x0005B75C
		internal override bool bk()
		{
			return true;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0005C770 File Offset: 0x0005B770
		private new void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num == 738839499)
				{
					if (abk.c().hy() == ag9.d)
					{
						this.f = ((abu)abk.c()).j9();
					}
					else if (abk.c().hy() == ag9.g)
					{
						abj a_ = (abj)abk.c();
						this.a(a_);
					}
				}
			}
		}

		// Token: 0x0400034B RID: 843
		private new short[] a = null;

		// Token: 0x0400034C RID: 844
		private new short b = 0;

		// Token: 0x0400034D RID: 845
		private new short c = 0;

		// Token: 0x0400034E RID: 846
		private new string d = null;

		// Token: 0x0400034F RID: 847
		private new abd e = null;

		// Token: 0x04000350 RID: 848
		private new string f = null;

		// Token: 0x04000351 RID: 849
		private new afj g = null;

		// Token: 0x04000352 RID: 850
		private new int h = 0;

		// Token: 0x04000353 RID: 851
		private new int i = 0;

		// Token: 0x04000354 RID: 852
		private new Font j = null;

		// Token: 0x04000355 RID: 853
		private new string k = string.Empty;

		// Token: 0x04000356 RID: 854
		private new string l = string.Empty;

		// Token: 0x04000357 RID: 855
		private new ArrayList m = new ArrayList();

		// Token: 0x04000358 RID: 856
		private new bool n = true;

		// Token: 0x04000359 RID: 857
		private new bool o = false;
	}
}
