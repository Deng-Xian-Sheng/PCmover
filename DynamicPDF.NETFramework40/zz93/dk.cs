using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200009D RID: 157
	internal class dk : c1
	{
		// Token: 0x0600079B RID: 1947 RVA: 0x0006D928 File Offset: 0x0006C928
		internal void a(abk A_0)
		{
			abj abj = null;
			if (A_0.c().hy() == ag9.j)
			{
				abj = (abj)A_0.c().h6();
			}
			abk abk = abj.l();
			string text = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num <= 95985731)
				{
					if (num != 42320626)
					{
						if (num == 95985731)
						{
							if (abk.c().hy() == ag9.d)
							{
								this.f = ((abu)abk.c()).j9();
								if (this.f.Equals(base.a()) || this.f.Equals(base.b()))
								{
									this.a = true;
								}
							}
							else
							{
								abd abd = abk.c().h6();
								if (abd.hy() == ag9.g)
								{
									abj abj2 = (abj)abk.c().h6();
									if (abj2 != null)
									{
										this.a(abj2);
									}
								}
								else
								{
									if (abd is afl)
									{
										this.f = ((afl)abd).j9();
									}
									else if (abd.hy() == ag9.d)
									{
										this.f = ((abu)abd).j9();
									}
									if (this.f.Equals(base.a()) || this.f.Equals(base.b()))
									{
										this.a = true;
									}
								}
							}
						}
					}
					else if (abk.c().hy() == ag9.d)
					{
						text = ((abu)abk.c()).j9();
						this.a(abj, text);
					}
				}
				else if (num != 338928268)
				{
					if (num == 598973023)
					{
						abj abj3 = (abj)abk.c().h6();
						if (abj3 != null)
						{
							this.a(abj3);
						}
					}
				}
				else if (abk.c().hy() == ag9.j)
				{
					abj abj4 = (abj)abk.c().h6();
					this.b = true;
					this.a = false;
					this.d = new dh(((afj)abj4).j4());
				}
				abk = abk.d();
			}
			if (!this.a && !this.b)
			{
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "Symbol"))
					{
						if (text2 == "ZapfDingbats")
						{
							this.f = "ZapfDingBatsEncoding";
							this.h = new dd(text);
						}
					}
					else
					{
						this.f = "SymbolEncoding";
						this.h = new dd(text);
					}
				}
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0006DC4C File Offset: 0x0006CC4C
		internal override string bx(de A_0)
		{
			Encoding encoding = ae5.a(1252);
			byte[] array = base.a(A_0.b());
			int num = 1;
			if (A_0.i())
			{
				num = 0;
				array = base.b(array);
			}
			string result;
			if (this.a && !this.b)
			{
				int num2 = num;
				if (num2 != 0)
				{
					if (this.e)
					{
						result = this.c.a(encoding.GetString(A_0.b()));
					}
					else if (this.f.Equals(base.b()))
					{
						result = base.b(encoding.GetString(A_0.b()));
					}
					else
					{
						result = base.c(encoding.GetString(A_0.b()));
					}
				}
				else if (this.e)
				{
					result = this.c.a(array);
				}
				else if (this.f.Equals(base.b()))
				{
					result = base.c(array);
				}
				else
				{
					result = encoding.GetString(array);
				}
			}
			else if (this.b)
			{
				A_0.a(array);
				result = this.d.a(A_0, this);
			}
			else if (this.f != null && (this.f.Equals("SymbolEncoding") || this.f.Equals("ZapfDingBatsEncoding")))
			{
				result = this.h.a(array);
			}
			else
			{
				result = encoding.GetString(array);
			}
			return result;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0006DDFC File Offset: 0x0006CDFC
		internal override char? by(byte A_0)
		{
			char? result;
			if (this.e)
			{
				result = new char?(this.c.a(A_0));
			}
			else if (this.a)
			{
				result = new char?((char)A_0);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0006DE50 File Offset: 0x0006CE50
		private void a(abj A_0)
		{
			abk abk = A_0.l();
			Hashtable hashtable = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num != 738839499)
				{
					if (num == 909148531)
					{
						if (hashtable == null)
						{
							hashtable = new Hashtable();
						}
						abe abe = (abe)abk.c().h6();
						this.e = true;
						int i = 0;
						int num2 = 0;
						while (i < abe.a())
						{
							if (abe.a(i).hy() == ag9.b)
							{
								hashtable.Add(((abw)abe.a(i)).kd(), ((abu)abe.a(i + 1)).j9());
								num2 = ((abw)abe.a(i)).kd();
								i += 2;
							}
							else
							{
								hashtable.Add(num2 + 1, ((abu)abe.a(i)).j9());
								num2++;
								i++;
							}
						}
						this.a = true;
					}
				}
				else if (abk.c().hy() == ag9.d)
				{
					this.f = ((abu)abk.c()).j9();
					if (this.f.Equals(base.a()) || this.f.Equals(base.b()))
					{
						this.a = true;
					}
				}
				abk = abk.d();
			}
			if (hashtable != null)
			{
				this.c = new c0(hashtable, this.f);
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0006E018 File Offset: 0x0006D018
		private void a(abd A_0, string A_1)
		{
			if (A_1.Contains("+"))
			{
				A_1 = A_1.Substring(A_1.IndexOf('+') + 1);
			}
			string text = A_1;
			switch (text)
			{
			case "Helvetica":
				this.g = Font.Helvetica;
				return;
			case "Helvetica-Bold":
				this.g = Font.HelveticaBold;
				return;
			case "Helvetica-BoldOblique":
				this.g = Font.HelveticaBoldOblique;
				return;
			case "Helvetica-Oblique":
				this.g = Font.HelveticaOblique;
				return;
			case "Times-Roman":
				this.g = Font.TimesRoman;
				return;
			case "Times-Bold":
				this.g = Font.TimesBold;
				return;
			case "Times-BoldItalic":
				this.g = Font.TimesBoldItalic;
				return;
			case "Times-Italic":
				this.g = Font.TimesItalic;
				return;
			case "Courier":
				this.g = Font.Courier;
				return;
			case "Courier-Bold":
				this.g = Font.CourierBold;
				return;
			case "Courier-BoldOblique":
				this.g = Font.CourierBoldOblique;
				return;
			case "Courier-Oblique":
				this.g = Font.CourierOblique;
				return;
			case "Symbol":
				this.g = Font.Symbol;
				return;
			case "ZapfDingbats":
				this.g = Font.ZapfDingbats;
				return;
			}
			this.g = new c2(A_0);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0006E248 File Offset: 0x0006D248
		internal override bool bz()
		{
			return this.a;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0006E260 File Offset: 0x0006D260
		internal override bool b0()
		{
			return this.b;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0006E278 File Offset: 0x0006D278
		internal override Font b1()
		{
			Font result;
			if (this.g != null)
			{
				result = this.g;
			}
			else
			{
				result = base.b1();
			}
			return result;
		}

		// Token: 0x04000406 RID: 1030
		private new bool a = false;

		// Token: 0x04000407 RID: 1031
		private new bool b = false;

		// Token: 0x04000408 RID: 1032
		private new c0 c = null;

		// Token: 0x04000409 RID: 1033
		private dh d = null;

		// Token: 0x0400040A RID: 1034
		private bool e = false;

		// Token: 0x0400040B RID: 1035
		private string f = null;

		// Token: 0x0400040C RID: 1036
		private Font g = null;

		// Token: 0x0400040D RID: 1037
		private dd h = null;
	}
}
