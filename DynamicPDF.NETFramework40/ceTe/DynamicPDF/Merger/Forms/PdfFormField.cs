using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x020006FE RID: 1790
	public class PdfFormField
	{
		// Token: 0x06004598 RID: 17816 RVA: 0x00239DB8 File Offset: 0x00238DB8
		internal PdfFormField(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_3;
			this.d = A_2;
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 278)
				{
					if (num <= 80)
					{
						if (num <= 22)
						{
							if (num != 8)
							{
								switch (num)
								{
								case 16:
									if (abk.c().hy() == ag9.j)
									{
										this.q = (ab6)abk.c();
									}
									abk.a(false);
									break;
								case 17:
									abk.a(false);
									this.v = (abw)abk.c().h6();
									break;
								case 20:
									abk.a(false);
									this.h = (ab7)abk.c();
									this.ai = this.Name;
									break;
								case 22:
									abk.a(false);
									this.k = abk.c().h6();
									break;
								}
							}
						}
						else if (num != 65)
						{
							if (num == 80)
							{
								abk.a(false);
								this.m = (abj)abk.c().h6();
							}
						}
					}
					else if (num <= 147)
					{
						if (num != 83)
						{
							if (num == 147)
							{
								abk.a(false);
								this.s = (abj)abk.c().h6();
							}
						}
						else
						{
							abk.a(false);
							this.n = (abu)abk.c().h6();
						}
					}
					else if (num != 257)
					{
						if (num != 274)
						{
							if (num == 278)
							{
								this.l = abk.c().h6();
							}
						}
						else
						{
							abk.a(false);
							if (abk.c().hy() == ag9.g)
							{
								this.t = new abn(abk.c());
							}
							else if (abk.c().hy() == ag9.j)
							{
								ab6 ab = (ab6)abk.c();
								this.t = ab.b().m().b(ab).d();
							}
						}
					}
					else
					{
						abk.a(false);
						this.u = (ab7)abk.c().h6();
					}
				}
				else if (num <= 3053875)
				{
					if (num <= 843)
					{
						if (num != 422)
						{
							if (num == 843)
							{
								abk.a(false);
								this.r = (abj)abk.c().h6();
							}
						}
						else
						{
							abk.a(false);
							this.p = (abw)abk.c().h6();
							this.ak = this.p.kd();
						}
					}
					else if (num != 1293)
					{
						if (num != 1301)
						{
							if (num == 3053875)
							{
								abk.a(false);
								if (abk.c().hy() != ag9.i)
								{
									this.e = new PdfFormFieldList(A_0, this, (abe)abk.c().h6());
								}
							}
						}
						else
						{
							abk.a(false);
							this.i = (ab7)abk.c().h6();
						}
					}
					else
					{
						abk.a(false);
						this.j = (ab7)abk.c();
					}
				}
				else if (num <= 5479461)
				{
					if (num != 4872436)
					{
						if (num == 5479461)
						{
							if (((abu)abk.c()).j8() == 29027316)
							{
								this.f = true;
							}
						}
					}
					else
					{
						this.o = new ab5((abe)abk.c().h6());
					}
				}
				else if (num != 277293402)
				{
					if (num != 332800284)
					{
						if (num == 663829106)
						{
							this.w = true;
							this.x = ((abw)abk.c()).kd();
							abk.a(false);
						}
					}
					else if (((abu)abk.c()).j8() == 396773841)
					{
						this.g = true;
					}
				}
				else
				{
					abk.a(false);
				}
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06004599 RID: 17817 RVA: 0x0023A374 File Offset: 0x00239374
		public bool HasChildFields
		{
			get
			{
				return this.e != null && this.e.Count > 0;
			}
		}

		// Token: 0x0600459A RID: 17818 RVA: 0x0023A3A0 File Offset: 0x002393A0
		public int GetOriginalPageNumber()
		{
			if (this.f || this.g)
			{
				if (this.q != null)
				{
					PdfPage pdfPage = this.c.k().b().m().b((long)this.q.c()).h();
					return pdfPage.e() + 1;
				}
				PdfPageList pages = this.c.k().b().Pages;
				for (int i = 0; i < pages.Count; i++)
				{
					if (pages[i].j() != null && pages[i].j().a(this))
					{
						return i + 1;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600459B RID: 17819 RVA: 0x0023A484 File Offset: 0x00239484
		public void PositionPageElement(PageElement pageElement, Page page)
		{
			if (pageElement is IArea)
			{
				((IArea)pageElement).Width = this.Width;
				((IArea)pageElement).Height = this.Height;
			}
			if (pageElement is ICoordinate)
			{
				((IArea)pageElement).X = this.GetX(page);
				((IArea)pageElement).Y = this.GetY(page);
			}
		}

		// Token: 0x0600459C RID: 17820 RVA: 0x0023A500 File Offset: 0x00239500
		public float GetX(Page page)
		{
			return this.o.c().ke() - page.Dimensions.Body.Left;
		}

		// Token: 0x0600459D RID: 17821 RVA: 0x0023A534 File Offset: 0x00239534
		public float GetY(Page page)
		{
			return page.Dimensions.Edge.Bottom - this.o.f().ke() - page.Dimensions.TopMargin;
		}

		// Token: 0x0600459E RID: 17822 RVA: 0x0023A574 File Offset: 0x00239574
		public Label CreateLabel(Page page, float xOffset, float yOffset, string text, Font font, float fontSize)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page) + xOffset, this.GetY(page) + yOffset, this.Width, this.Height, font2, fontSize);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x0600459F RID: 17823 RVA: 0x0023A600 File Offset: 0x00239600
		public Label CreateLabel(Page page, float xOffset, float yOffset, string text, Font font, float fontSize, TextAlign align)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page) + xOffset, this.GetY(page) + yOffset, this.Width, this.Height, font2, fontSize, align);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A0 RID: 17824 RVA: 0x0023A68C File Offset: 0x0023968C
		public Label CreateLabel(Page page, float xOffset, float yOffset, string text, Font font, float fontSize, TextAlign align, Color textColor)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page) + xOffset, this.GetY(page) + yOffset, this.Width, this.Height, font2, fontSize, align, textColor);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A1 RID: 17825 RVA: 0x0023A71C File Offset: 0x0023971C
		public Label CreateLabel(Page page, float xOffset, float yOffset, string text)
		{
			float num = this.FontSize;
			if (num <= 0f)
			{
				num = 12f;
			}
			Label label = new Label(text, this.GetX(page) + xOffset, this.GetY(page) + yOffset, this.Width, this.Height, this.Font, num, this.ad(), this.TextColor);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A2 RID: 17826 RVA: 0x0023A790 File Offset: 0x00239790
		public Label CreateLabel(Page page, string text, Font font, float fontSize)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page), this.GetY(page), this.Width, this.Height, font2, fontSize);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A3 RID: 17827 RVA: 0x0023A814 File Offset: 0x00239814
		public Label CreateLabel(Page page, string text, Font font, float fontSize, TextAlign align)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page), this.GetY(page), this.Width, this.Height, font2, fontSize, align);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x0023A89C File Offset: 0x0023989C
		public Label CreateLabel(Page page, string text, Font font, float fontSize, TextAlign align, Color textColor)
		{
			Font font2 = font;
			if (font2 == null)
			{
				font2 = this.Font;
			}
			if (fontSize <= 0f)
			{
				fontSize = this.FontSize;
				if (fontSize <= 0f)
				{
					fontSize = 12f;
				}
			}
			Label label = new Label(text, this.GetX(page), this.GetY(page), this.Width, this.Height, font2, fontSize, align, textColor);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x060045A5 RID: 17829 RVA: 0x0023A924 File Offset: 0x00239924
		public Label CreateLabel(Page page, string text)
		{
			float num = this.FontSize;
			if (num <= 0f)
			{
				num = 12f;
			}
			Label label = new Label(text, this.GetX(page), this.GetY(page), this.Width, this.Height, this.Font, num, this.ad(), this.TextColor);
			page.Elements.Add(label);
			return label;
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060045A6 RID: 17830 RVA: 0x0023A994 File Offset: 0x00239994
		public float Width
		{
			get
			{
				return this.o.e().ke() - this.o.c().ke();
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060045A7 RID: 17831 RVA: 0x0023A9C8 File Offset: 0x002399C8
		public float Height
		{
			get
			{
				return this.o.f().ke() - this.o.d().ke();
			}
		}

		// Token: 0x060045A8 RID: 17832 RVA: 0x0023A9FC File Offset: 0x002399FC
		internal StructureElement g()
		{
			return this.al;
		}

		// Token: 0x060045A9 RID: 17833 RVA: 0x0023AA14 File Offset: 0x00239A14
		internal void a(StructureElement A_0)
		{
			this.al = A_0;
		}

		// Token: 0x060045AA RID: 17834 RVA: 0x0023AA20 File Offset: 0x00239A20
		internal Resource h()
		{
			Resource result;
			if (this.t != null)
			{
				result = this.t;
			}
			else if (this.Parent != null)
			{
				result = this.Parent.h();
			}
			else
			{
				result = this.Form.d();
			}
			return result;
		}

		// Token: 0x060045AB RID: 17835 RVA: 0x0023AA70 File Offset: 0x00239A70
		internal ab7 i()
		{
			ab7 result;
			if (this.u != null)
			{
				result = this.u;
			}
			else if (this.Parent != null)
			{
				result = this.Parent.i();
			}
			else
			{
				result = this.Form.e();
			}
			return result;
		}

		// Token: 0x060045AC RID: 17836 RVA: 0x0023AAC0 File Offset: 0x00239AC0
		internal abw j()
		{
			abw result;
			if (this.v != null)
			{
				result = this.v;
			}
			else if (this.Parent != null)
			{
				result = this.Parent.j();
			}
			else if (this.Form != null)
			{
				result = this.Form.f();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060045AD RID: 17837 RVA: 0x0023AB24 File Offset: 0x00239B24
		internal FormFieldAlign k()
		{
			abw abw = this.j();
			FormFieldAlign result;
			if (abw == null)
			{
				result = FormFieldAlign.Left;
			}
			else
			{
				result = (FormFieldAlign)abw.kd();
			}
			return result;
		}

		// Token: 0x060045AE RID: 17838 RVA: 0x0023AB54 File Offset: 0x00239B54
		internal int l()
		{
			return this.b;
		}

		// Token: 0x060045AF RID: 17839 RVA: 0x0023AB6C File Offset: 0x00239B6C
		internal int m()
		{
			return this.ak;
		}

		// Token: 0x060045B0 RID: 17840 RVA: 0x0023AB84 File Offset: 0x00239B84
		internal abw n()
		{
			return this.p;
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060045B1 RID: 17841 RVA: 0x0023AB9C File Offset: 0x00239B9C
		protected PdfFormField Parent
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060045B2 RID: 17842 RVA: 0x0023ABB4 File Offset: 0x00239BB4
		protected PdfForm Form
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x060045B3 RID: 17843 RVA: 0x0023ABCC File Offset: 0x00239BCC
		public virtual string GetDefaultValue()
		{
			string result;
			if (this.d == null)
			{
				result = string.Empty;
			}
			else
			{
				result = this.d.GetDefaultValue();
			}
			return result;
		}

		// Token: 0x060045B4 RID: 17844 RVA: 0x0023AC04 File Offset: 0x00239C04
		public virtual string GetValue()
		{
			string result;
			if (this.d == null)
			{
				result = string.Empty;
			}
			else
			{
				result = this.d.GetValue();
			}
			return result;
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060045B5 RID: 17845 RVA: 0x0023AC3C File Offset: 0x00239C3C
		public virtual string ExportValue
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060045B6 RID: 17846 RVA: 0x0023AC54 File Offset: 0x00239C54
		public virtual string[] ExportValues
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060045B7 RID: 17847 RVA: 0x0023AC68 File Offset: 0x00239C68
		public PdfFormFieldList ChildFields
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060045B8 RID: 17848 RVA: 0x0023AC80 File Offset: 0x00239C80
		public bool None
		{
			get
			{
				return 0 == 0;
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060045B9 RID: 17849 RVA: 0x0023AC98 File Offset: 0x00239C98
		public bool ReadOnly
		{
			get
			{
				bool result;
				if (this.p == null)
				{
					result = (this.d != null && this.d.ReadOnly);
				}
				else
				{
					result = ((this.ak & 1) == 1);
				}
				return result;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060045BA RID: 17850 RVA: 0x0023ACE8 File Offset: 0x00239CE8
		public bool Required
		{
			get
			{
				bool result;
				if (this.p == null)
				{
					result = (this.d != null && this.d.Required);
				}
				else
				{
					result = ((this.ak & 2) == 2);
				}
				return result;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060045BB RID: 17851 RVA: 0x0023AD38 File Offset: 0x00239D38
		public virtual bool NoExport
		{
			get
			{
				bool result;
				if (this.p == null)
				{
					result = (this.d != null && this.d.NoExport);
				}
				else
				{
					result = ((this.ak & 4) == 4);
				}
				return result;
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060045BC RID: 17852 RVA: 0x0023AD88 File Offset: 0x00239D88
		public virtual bool Multiline
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x060045BD RID: 17853 RVA: 0x0023AD9C File Offset: 0x00239D9C
		public virtual bool Password
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x060045BE RID: 17854 RVA: 0x0023ADB0 File Offset: 0x00239DB0
		public virtual bool Combo
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x060045BF RID: 17855 RVA: 0x0023ADC4 File Offset: 0x00239DC4
		public virtual bool Edit
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x060045C0 RID: 17856 RVA: 0x0023ADD8 File Offset: 0x00239DD8
		public virtual bool Sort
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x060045C1 RID: 17857 RVA: 0x0023ADEC File Offset: 0x00239DEC
		public virtual bool FileSelect
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x060045C2 RID: 17858 RVA: 0x0023AE00 File Offset: 0x00239E00
		public virtual bool MultiSelect
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x0023AE14 File Offset: 0x00239E14
		public virtual bool DoNotSpellCheck
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060045C4 RID: 17860 RVA: 0x0023AE28 File Offset: 0x00239E28
		public virtual bool DoNotScroll
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060045C5 RID: 17861 RVA: 0x0023AE3C File Offset: 0x00239E3C
		public virtual bool Comb
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060045C6 RID: 17862 RVA: 0x0023AE50 File Offset: 0x00239E50
		public virtual bool NoToggleToOff
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060045C7 RID: 17863 RVA: 0x0023AE64 File Offset: 0x00239E64
		public virtual bool Radio
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x060045C8 RID: 17864 RVA: 0x0023AE78 File Offset: 0x00239E78
		public virtual bool Pushbutton
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x060045C9 RID: 17865 RVA: 0x0023AE8C File Offset: 0x00239E8C
		public virtual bool RadiosInUnison
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x060045CA RID: 17866 RVA: 0x0023AEA0 File Offset: 0x00239EA0
		public virtual bool CommitOnSelChange
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x060045CB RID: 17867 RVA: 0x0023AEB4 File Offset: 0x00239EB4
		public virtual bool RichText
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060045CC RID: 17868 RVA: 0x0023AEC8 File Offset: 0x00239EC8
		internal abj o()
		{
			return this.c;
		}

		// Token: 0x060045CD RID: 17869 RVA: 0x0023AEE0 File Offset: 0x00239EE0
		internal ab7 p()
		{
			return this.h;
		}

		// Token: 0x060045CE RID: 17870 RVA: 0x0023AEF8 File Offset: 0x00239EF8
		internal ab7 q()
		{
			return this.i;
		}

		// Token: 0x060045CF RID: 17871 RVA: 0x0023AF10 File Offset: 0x00239F10
		internal ab7 r()
		{
			return this.j;
		}

		// Token: 0x060045D0 RID: 17872 RVA: 0x0023AF28 File Offset: 0x00239F28
		internal abj s()
		{
			return this.m;
		}

		// Token: 0x060045D1 RID: 17873 RVA: 0x0023AF40 File Offset: 0x00239F40
		internal abu t()
		{
			return this.n;
		}

		// Token: 0x060045D2 RID: 17874 RVA: 0x0023AF58 File Offset: 0x00239F58
		internal abd u()
		{
			return this.k;
		}

		// Token: 0x060045D3 RID: 17875 RVA: 0x0023AF70 File Offset: 0x00239F70
		internal abd v()
		{
			return this.l;
		}

		// Token: 0x060045D4 RID: 17876 RVA: 0x0023AF88 File Offset: 0x00239F88
		internal bool w()
		{
			return this.g;
		}

		// Token: 0x060045D5 RID: 17877 RVA: 0x0023AFA0 File Offset: 0x00239FA0
		internal abj x()
		{
			return this.r;
		}

		// Token: 0x060045D6 RID: 17878 RVA: 0x0023AFB8 File Offset: 0x00239FB8
		internal abj y()
		{
			return this.s;
		}

		// Token: 0x060045D7 RID: 17879 RVA: 0x0023AFD0 File Offset: 0x00239FD0
		internal ab5 z()
		{
			return this.o;
		}

		// Token: 0x060045D8 RID: 17880 RVA: 0x0023AFE8 File Offset: 0x00239FE8
		internal ab7 aa()
		{
			return this.u;
		}

		// Token: 0x060045D9 RID: 17881 RVA: 0x0023B000 File Offset: 0x0023A000
		internal bool ab()
		{
			return this.w;
		}

		// Token: 0x060045DA RID: 17882 RVA: 0x0023B018 File Offset: 0x0023A018
		internal int ac()
		{
			return this.x;
		}

		// Token: 0x060045DB RID: 17883 RVA: 0x0023B030 File Offset: 0x0023A030
		internal TextAlign ad()
		{
			TextAlign result;
			switch (this.k())
			{
			case FormFieldAlign.Center:
				result = TextAlign.Center;
				break;
			case FormFieldAlign.Right:
				result = TextAlign.Right;
				break;
			default:
				result = TextAlign.Left;
				break;
			}
			return result;
		}

		// Token: 0x060045DC RID: 17884 RVA: 0x0023B064 File Offset: 0x0023A064
		internal bool ae()
		{
			return this.aj;
		}

		// Token: 0x060045DD RID: 17885 RVA: 0x0023B07C File Offset: 0x0023A07C
		internal void a(bool A_0)
		{
			this.aj = A_0;
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x060045DE RID: 17886 RVA: 0x0023B088 File Offset: 0x0023A088
		[Obsolete("This property is obsolete. Instead use relevant flag name properties present on this class.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public FormFieldFlags Flags
		{
			get
			{
				FormFieldFlags result;
				if (this.p == null)
				{
					if (this.d != null)
					{
						result = this.d.Flags;
					}
					else
					{
						result = FormFieldFlags.None;
					}
				}
				else
				{
					result = (FormFieldFlags)this.p.kd();
				}
				return result;
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060045DF RID: 17887 RVA: 0x0023B0D8 File Offset: 0x0023A0D8
		public string Name
		{
			get
			{
				string result;
				if (this.h == null)
				{
					result = string.Empty;
				}
				else
				{
					result = this.h.kf();
				}
				return result;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060045E0 RID: 17888 RVA: 0x0023B110 File Offset: 0x0023A110
		public string FullName
		{
			get
			{
				string result;
				if (this.d == null)
				{
					result = this.Name;
				}
				else if (this.h == null)
				{
					result = this.d.FullName;
				}
				else
				{
					result = this.d.FullName + '.' + this.Name;
				}
				return result;
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060045E1 RID: 17889 RVA: 0x0023B178 File Offset: 0x0023A178
		public BorderStyle BorderStyle
		{
			get
			{
				if (this.ab == null || !this.y)
				{
					this.b();
				}
				return this.ab;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060045E2 RID: 17890 RVA: 0x0023B1B0 File Offset: 0x0023A1B0
		public DeviceColor BorderColor
		{
			get
			{
				if (this.z == null)
				{
					this.c();
				}
				return this.z;
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060045E3 RID: 17891 RVA: 0x0023B1E0 File Offset: 0x0023A1E0
		public RgbColor BackgroundColor
		{
			get
			{
				if (this.aa == null)
				{
					this.c();
				}
				return this.aa;
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x060045E4 RID: 17892 RVA: 0x0023B210 File Offset: 0x0023A210
		public DeviceColor TextColor
		{
			get
			{
				if (this.ac == null)
				{
					this.a();
				}
				return this.ac;
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060045E5 RID: 17893 RVA: 0x0023B240 File Offset: 0x0023A240
		public int Rotate
		{
			get
			{
				if (this.ad == 0 && !this.ah)
				{
					this.c();
				}
				return this.ad;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060045E6 RID: 17894 RVA: 0x0023B278 File Offset: 0x0023A278
		// (set) Token: 0x060045E7 RID: 17895 RVA: 0x0023B38C File Offset: 0x0023A38C
		public virtual Font Font
		{
			get
			{
				if (this.ae == null || !this.ag)
				{
					this.a();
				}
				if (this.ae == null && this.i() != null)
				{
					string text = this.i().kf();
					int num = text.IndexOf("Tf");
					StringBuilder stringBuilder = new StringBuilder();
					if (num != -1)
					{
						int i;
						for (i = num - 2; i > 0; i--)
						{
							if (text[i] == ' ')
							{
								break;
							}
						}
						while (i > 0)
						{
							if (text[i] == '/')
							{
								break;
							}
							i--;
						}
						i++;
						while (text[i] != ' ')
						{
							stringBuilder.Append(text[i++]);
						}
					}
					this.ae = this.Form.a(stringBuilder.ToString());
				}
				return this.ae;
			}
			set
			{
				this.ae = value;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060045E8 RID: 17896 RVA: 0x0023B398 File Offset: 0x0023A398
		// (set) Token: 0x060045E9 RID: 17897 RVA: 0x0023B3CB File Offset: 0x0023A3CB
		public float FontSize
		{
			get
			{
				if (this.af == -3.4028235E+38f)
				{
					this.a();
				}
				return this.af;
			}
			set
			{
				this.af = value;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060045EA RID: 17898 RVA: 0x0023B3D8 File Offset: 0x0023A3D8
		public Align Align
		{
			get
			{
				Align result;
				switch (this.k())
				{
				case FormFieldAlign.Center:
					result = Align.Center;
					break;
				case FormFieldAlign.Right:
					result = Align.Right;
					break;
				default:
					result = Align.Left;
					break;
				}
				return result;
			}
		}

		// Token: 0x060045EB RID: 17899 RVA: 0x0023B40C File Offset: 0x0023A40C
		internal static PdfFormField a(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3)
		{
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 404)
				{
					abk.a(false);
					int num = ((abu)abk.c()).j8();
					if (num <= 1336)
					{
						if (num == 232)
						{
							return new PdfChoiceField(A_0, A_1, A_2, A_3);
						}
						if (num == 1336)
						{
							return new PdfTextField(A_0, A_1, A_2, A_3);
						}
					}
					else
					{
						if (num == 11566)
						{
							return new PdfButtonField(A_0, A_1, A_2, A_3);
						}
						if (num == 80487)
						{
							return new PdfSignatureField(A_0, A_1, A_2, A_3);
						}
					}
				}
			}
			if (A_2 != null)
			{
				if (A_2 is PdfTextField)
				{
					return new PdfTextField(A_0, A_1, A_2, A_3);
				}
				if (A_2 is PdfButtonField)
				{
					return new PdfButtonField(A_0, A_1, A_2, A_3);
				}
				if (A_2 is PdfChoiceField)
				{
					return new PdfChoiceField(A_0, A_1, A_2, A_3);
				}
				if (A_2 is PdfSignatureField)
				{
					return new PdfSignatureField(A_0, A_1, A_2, A_3);
				}
			}
			return new PdfFormField(A_0, A_1, A_2, A_3);
		}

		// Token: 0x060045EC RID: 17900 RVA: 0x0023B564 File Offset: 0x0023A564
		internal FormField a(FormFieldList A_0, Document A_1)
		{
			FormField result;
			if (this.d == null)
			{
				FormField formField = A_0[this.ai];
				if (formField == null || formField.hb() != this)
				{
					FormField formField2 = this.hm(-1);
					A_0.Add(formField2);
					if (this.Name != formField2.Name)
					{
						this.ai = formField2.Name;
					}
					result = formField2;
				}
				else
				{
					result = formField;
				}
			}
			else
			{
				FormField formField3 = this.d.a(A_0, A_1);
				FormField formField = formField3.ChildFields[this.ai];
				if (formField == null || formField.hb() != this)
				{
					FormField formField2 = this.hm(-1);
					formField3.ChildFields.Add(formField2);
					if (this.Name != formField2.Name)
					{
						this.ai = formField2.Name;
					}
					result = formField2;
				}
				else
				{
					result = formField;
				}
			}
			return result;
		}

		// Token: 0x060045ED RID: 17901 RVA: 0x0023B664 File Offset: 0x0023A664
		internal FormField a(FormFieldList A_0, Document A_1, int A_2)
		{
			FormField result;
			if (this.d == null)
			{
				FormField formField = this.hm(A_2);
				A_0.Add(formField);
				result = formField;
			}
			else
			{
				FormField formField2 = this.d.a(A_0, A_1);
				FormField formField = this.hm(A_2);
				formField2.ChildFields.Add(formField);
				result = formField;
			}
			return result;
		}

		// Token: 0x060045EE RID: 17902 RVA: 0x0023B6C0 File Offset: 0x0023A6C0
		internal virtual FormField hm(int A_0)
		{
			return new aal(this);
		}

		// Token: 0x060045EF RID: 17903 RVA: 0x0023B6D8 File Offset: 0x0023A6D8
		internal void a(DocumentWriter A_0)
		{
			this.c.b(A_0);
		}

		// Token: 0x060045F0 RID: 17904 RVA: 0x0023B6E8 File Offset: 0x0023A6E8
		internal bool af()
		{
			abk abk = this.o().l();
			int num = 0;
			while (abk != null)
			{
				int num2 = abk.a().j8();
				if (num2 != 6)
				{
					abk = abk.d();
				}
				else if (abk.c().hy() == ag9.b)
				{
					num = ((abw)abk.c()).kd();
					abk = null;
				}
			}
			if (num != 0)
			{
				aco aco = (aco)num;
				if ((aco & aco.c) == aco.c || (aco & aco.b) == aco.b || (aco & aco.g) == aco.g)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060045F1 RID: 17905 RVA: 0x0023B798 File Offset: 0x0023A798
		internal afj ag()
		{
			for (abk abk = this.s().l(); abk != null; abk = abk.d())
			{
				if (abk.b())
				{
					if (abk.a().j9() == "N")
					{
						if (abk.c().hy() == ag9.j)
						{
							ab6 ab = (ab6)abk.c();
							abg abg = ab.b().m().b((long)ab.c());
							afj result;
							if (abg == null)
							{
								result = null;
							}
							else
							{
								result = abg.j();
							}
							return result;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060045F2 RID: 17906 RVA: 0x0023B860 File Offset: 0x0023A860
		internal afj c(string A_0)
		{
			abj abj = this.s().g(14);
			abk abk = null;
			if (abj != null)
			{
				abk = abj.l();
			}
			else
			{
				ab6 ab = this.s().h(14);
				if (ab != null)
				{
					abg abg = ab.b().m().b((long)ab.c());
					if (abg == null)
					{
						return null;
					}
					abd abd = abg.h0();
					if (abd.hy() == ag9.h)
					{
						return abg.j();
					}
					abk = ((abj)abd).l();
				}
			}
			while (abk != null)
			{
				if (abk.b())
				{
					if (abk.a().j9() == A_0)
					{
						if (abk.c().hy() == ag9.j)
						{
							ab6 ab = (ab6)abk.c();
							abg abg = ab.b().m().b((long)ab.c());
							if (abg == null)
							{
								return null;
							}
							return abg.j();
						}
					}
				}
				abk = abk.d();
			}
			return null;
		}

		// Token: 0x060045F3 RID: 17907 RVA: 0x0023B9CC File Offset: 0x0023A9CC
		private void c()
		{
			if (this.x() != null)
			{
				for (abk abk = this.x().l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num <= 131)
					{
						if (num != 18)
						{
							if (num != 67)
							{
								if (num == 131)
								{
									abe a_ = (abe)abk.c();
									this.b(a_);
								}
							}
						}
						else
						{
							abw abw = (abw)abk.c();
							this.ad = abw.kd();
							this.ah = true;
						}
					}
					else if (num != 135)
					{
						if (num != 193)
						{
							if (num != 1155)
							{
							}
						}
					}
					else
					{
						abe a_2 = (abe)abk.c();
						this.a(a_2);
					}
				}
			}
		}

		// Token: 0x060045F4 RID: 17908 RVA: 0x0023BABC File Offset: 0x0023AABC
		private void b()
		{
			if (this.y() != null && !this.y)
			{
				abk abk = this.y().l();
				if (this.ab == null)
				{
					this.ab = BorderStyle.Solid;
				}
				while (abk != null)
				{
					int num = abk.a().j8();
					if (num != 19)
					{
						if (num == 23)
						{
							this.a((abw)abk.c());
						}
					}
					else
					{
						this.a((abu)abk.c());
					}
					abk = abk.d();
				}
				this.y = true;
			}
		}

		// Token: 0x060045F5 RID: 17909 RVA: 0x0023BB6C File Offset: 0x0023AB6C
		private void a()
		{
			if (this.i() != null && !this.ag)
			{
				this.ag = true;
				string text = this.i().kf().Trim();
				string a_;
				if (text.IndexOf('/') > 0)
				{
					a_ = text.Substring(text.IndexOf('/')).Trim();
				}
				else
				{
					a_ = text.Substring(0, text.IndexOf("Tf") + 2).Trim();
				}
				string[] array = this.a(a_);
				string text2 = string.Empty;
				if (text.IndexOf('/') > 0)
				{
					text2 = text.Substring(0, text.IndexOf('/') - 1).Trim();
				}
				else
				{
					text2 = text.Substring(text.IndexOf("Tf") + 2);
				}
				string[] array2 = this.a(text2);
				if (this.ae == null)
				{
					string text3 = array[0].Substring(1);
					if (text3.Equals(Font.Courier.FormFontName))
					{
						this.ae = Font.Courier;
					}
					else if (text3.Equals(Font.CourierBold.FormFontName))
					{
						this.ae = Font.CourierBold;
					}
					else if (text3.Equals(Font.CourierBoldOblique.FormFontName))
					{
						this.ae = Font.CourierBoldOblique;
					}
					else if (text3.Equals(Font.CourierOblique.FormFontName))
					{
						this.ae = Font.CourierOblique;
					}
					else if (text3.Equals(Font.Helvetica.FormFontName))
					{
						this.ae = Font.Helvetica;
					}
					else if (text3.Equals(Font.HelveticaBold.FormFontName))
					{
						this.ae = Font.HelveticaBold;
					}
					else if (text3.Equals(Font.HelveticaBoldOblique.FormFontName))
					{
						this.ae = Font.HelveticaBoldOblique;
					}
					else if (text3.Equals(Font.HelveticaOblique.FormFontName))
					{
						this.ae = Font.HelveticaOblique;
					}
					else if (text3.Equals(Font.Symbol.FormFontName))
					{
						this.ae = Font.Symbol;
					}
					else if (text3.Equals(Font.TimesBold.FormFontName))
					{
						this.ae = Font.TimesBold;
					}
					else if (text3.Equals(Font.TimesBoldItalic.FormFontName))
					{
						this.ae = Font.TimesBoldItalic;
					}
					else if (text3.Equals(Font.TimesItalic.FormFontName))
					{
						this.ae = Font.TimesItalic;
					}
					else if (text3.Equals(Font.TimesRoman.FormFontName))
					{
						this.ae = Font.TimesRoman;
					}
					else if (text3.Equals(Font.ZapfDingbats.FormFontName))
					{
						this.ae = Font.ZapfDingbats;
					}
				}
				if (this.af < 0f)
				{
					this.af = float.Parse(array[1], CultureInfo.InvariantCulture);
				}
				if (this.ac == null)
				{
					if (text2.EndsWith("rg"))
					{
						this.ac = new RgbColor(float.Parse(array2[array2.Length - 3], CultureInfo.InvariantCulture), float.Parse(array2[array2.Length - 2], CultureInfo.InvariantCulture), float.Parse(array2[array2.Length - 1], CultureInfo.InvariantCulture));
					}
					else if (text2.EndsWith("g"))
					{
						this.ac = new Grayscale(float.Parse(array2[array2.Length - 1], CultureInfo.InvariantCulture));
					}
					else if (text2.EndsWith("k"))
					{
						this.ac = new CmykColor(float.Parse(array2[array2.Length - 4], CultureInfo.InvariantCulture), float.Parse(array2[array2.Length - 3]), float.Parse(array2[array2.Length - 2], CultureInfo.InvariantCulture), float.Parse(array2[array2.Length - 1], CultureInfo.InvariantCulture));
					}
				}
			}
		}

		// Token: 0x060045F6 RID: 17910 RVA: 0x0023BFE8 File Offset: 0x0023AFE8
		private string[] a(string A_0)
		{
			ArrayList arrayList = new ArrayList();
			string text = A_0.Trim();
			int num;
			do
			{
				num = text.IndexOf(' ');
				if (num > 0)
				{
					string value = text.Substring(0, num);
					arrayList.Add(value);
				}
				text = text.Substring(num + 1, text.Length - (num + 1));
			}
			while (num >= 0 && text != null && text.Length > 1);
			string[] array = new string[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array[i] = arrayList[i].ToString();
			}
			return array;
		}

		// Token: 0x060045F7 RID: 17911 RVA: 0x0023C0A4 File Offset: 0x0023B0A4
		private void b(abe A_0)
		{
			if (this.z == null || this.z == Grayscale.Black)
			{
				if (A_0.a() == 1)
				{
					float num = ((abw)A_0.a(0)).ke();
					this.z = new Grayscale(num);
				}
				else if (A_0.a() == 3)
				{
					float red = ((abw)A_0.a(0)).ke();
					float num = ((abw)A_0.a(1)).ke();
					float blue = ((abw)A_0.a(2)).ke();
					this.z = new RgbColor(red, num, blue);
				}
				else if (A_0.a() == 4)
				{
					float cyan = ((abw)A_0.a(0)).ke();
					float magenta = ((abw)A_0.a(1)).ke();
					float yellow = ((abw)A_0.a(2)).ke();
					float black = ((abw)A_0.a(3)).ke();
					this.z = new CmykColor(cyan, magenta, yellow, black);
				}
				if (this.ab == null)
				{
					this.ab = BorderStyle.Solid;
				}
			}
		}

		// Token: 0x060045F8 RID: 17912 RVA: 0x0023C230 File Offset: 0x0023B230
		private void a(abe A_0)
		{
			if (this.aa == null)
			{
				if (A_0.a() == 3)
				{
					float red = ((abw)A_0.a(0)).ke();
					float green = ((abw)A_0.a(1)).ke();
					float blue = ((abw)A_0.a(2)).ke();
					this.aa = new RgbColor(red, green, blue);
				}
			}
		}

		// Token: 0x060045F9 RID: 17913 RVA: 0x0023C2B8 File Offset: 0x0023B2B8
		private void a(abw A_0)
		{
			if (this.ab.b() == 1)
			{
				if (A_0.kd() == 0)
				{
					this.ab.c();
				}
				else if (A_0.kd() == 1)
				{
					this.ab.SetThin();
				}
				else if (A_0.kd() == 2)
				{
					this.ab.SetMedium();
				}
				else if (A_0.kd() == 3)
				{
					this.ab.SetThick();
				}
			}
		}

		// Token: 0x060045FA RID: 17914 RVA: 0x0023C354 File Offset: 0x0023B354
		private void a(abu A_0)
		{
			int num = A_0.j8();
			switch (num)
			{
			case 2:
				this.ab.a(66);
				break;
			case 3:
				break;
			case 4:
				this.ab.a(68);
				break;
			default:
				if (num != 9)
				{
					switch (num)
					{
					case 19:
						this.ab.a(83);
						break;
					case 21:
						this.ab.a(85);
						break;
					}
				}
				else
				{
					this.ab.a(73);
				}
				break;
			}
		}

		// Token: 0x040026A4 RID: 9892
		private PdfForm a;

		// Token: 0x040026A5 RID: 9893
		private int b;

		// Token: 0x040026A6 RID: 9894
		private abj c;

		// Token: 0x040026A7 RID: 9895
		private PdfFormField d;

		// Token: 0x040026A8 RID: 9896
		private PdfFormFieldList e = null;

		// Token: 0x040026A9 RID: 9897
		private bool f = false;

		// Token: 0x040026AA RID: 9898
		private bool g = false;

		// Token: 0x040026AB RID: 9899
		private ab7 h = null;

		// Token: 0x040026AC RID: 9900
		private ab7 i = null;

		// Token: 0x040026AD RID: 9901
		private ab7 j = null;

		// Token: 0x040026AE RID: 9902
		private abd k = null;

		// Token: 0x040026AF RID: 9903
		private abd l = null;

		// Token: 0x040026B0 RID: 9904
		private abj m = null;

		// Token: 0x040026B1 RID: 9905
		private abu n = null;

		// Token: 0x040026B2 RID: 9906
		private ab5 o = null;

		// Token: 0x040026B3 RID: 9907
		private abw p = null;

		// Token: 0x040026B4 RID: 9908
		private ab6 q = null;

		// Token: 0x040026B5 RID: 9909
		private abj r = null;

		// Token: 0x040026B6 RID: 9910
		private abj s = null;

		// Token: 0x040026B7 RID: 9911
		private Resource t = null;

		// Token: 0x040026B8 RID: 9912
		private ab7 u = null;

		// Token: 0x040026B9 RID: 9913
		private abw v = null;

		// Token: 0x040026BA RID: 9914
		private bool w = false;

		// Token: 0x040026BB RID: 9915
		private int x = -1;

		// Token: 0x040026BC RID: 9916
		private bool y = false;

		// Token: 0x040026BD RID: 9917
		private DeviceColor z = null;

		// Token: 0x040026BE RID: 9918
		private RgbColor aa = null;

		// Token: 0x040026BF RID: 9919
		private BorderStyle ab = null;

		// Token: 0x040026C0 RID: 9920
		private DeviceColor ac = null;

		// Token: 0x040026C1 RID: 9921
		private int ad = 0;

		// Token: 0x040026C2 RID: 9922
		private Font ae = null;

		// Token: 0x040026C3 RID: 9923
		private float af = float.MinValue;

		// Token: 0x040026C4 RID: 9924
		private bool ag = false;

		// Token: 0x040026C5 RID: 9925
		private bool ah = false;

		// Token: 0x040026C6 RID: 9926
		private string ai = null;

		// Token: 0x040026C7 RID: 9927
		private bool aj = true;

		// Token: 0x040026C8 RID: 9928
		private int ak;

		// Token: 0x040026C9 RID: 9929
		private StructureElement al = null;
	}
}
