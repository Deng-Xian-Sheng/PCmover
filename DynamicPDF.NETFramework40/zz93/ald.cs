using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;

namespace zz93
{
	// Token: 0x0200058C RID: 1420
	internal class ald
	{
		// Token: 0x06003825 RID: 14373 RVA: 0x001E3434 File Offset: 0x001E2434
		internal ald(Stream A_0, DlexFile A_1)
		{
			this.a = A_1;
			this.d = new char[A_0.Length];
			this.c = new StreamReader(A_0, Encoding.UTF8);
			this.c.ReadBlock(this.d, 0, this.d.Length);
			this.a8();
			this.ab();
		}

		// Token: 0x06003826 RID: 14374 RVA: 0x001E34DC File Offset: 0x001E24DC
		internal ald(byte[] A_0, DlexFile A_1)
		{
			this.a = A_1;
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			this.d = utf8Encoding.GetChars(A_0);
			A_0 = null;
			this.a8();
			this.ab();
		}

		// Token: 0x06003827 RID: 14375 RVA: 0x001E355C File Offset: 0x001E255C
		internal DlexFile t()
		{
			return this.a;
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x001E3574 File Offset: 0x001E2574
		internal int u()
		{
			return this.h;
		}

		// Token: 0x06003829 RID: 14377 RVA: 0x001E358C File Offset: 0x001E258C
		internal string v()
		{
			return this.k;
		}

		// Token: 0x0600382A RID: 14378 RVA: 0x001E35A4 File Offset: 0x001E25A4
		internal void a(string A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600382B RID: 14379 RVA: 0x001E35B0 File Offset: 0x001E25B0
		internal string w()
		{
			return this.j;
		}

		// Token: 0x0600382C RID: 14380 RVA: 0x001E35C8 File Offset: 0x001E25C8
		internal void b(string A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0600382D RID: 14381 RVA: 0x001E35D4 File Offset: 0x001E25D4
		internal int x()
		{
			return this.e;
		}

		// Token: 0x0600382E RID: 14382 RVA: 0x001E35EC File Offset: 0x001E25EC
		internal bool y()
		{
			return this.f;
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x001E3604 File Offset: 0x001E2604
		internal bool z()
		{
			return this.g;
		}

		// Token: 0x06003830 RID: 14384 RVA: 0x001E361C File Offset: 0x001E261C
		internal void aa()
		{
			if (this.f)
			{
				if (this.r(this.d[this.b]))
				{
					this.i();
				}
				else
				{
					this.h = 0;
					if (this.d[this.b] == '/')
					{
						this.g = true;
						this.b++;
					}
					this.b++;
					this.f = false;
					if (this.i)
					{
						this.a8();
					}
				}
			}
			else
			{
				this.ab();
			}
		}

		// Token: 0x06003831 RID: 14385 RVA: 0x001E36D0 File Offset: 0x001E26D0
		internal void ab()
		{
			if (this.d.Length != this.b + 1)
			{
				if (!this.n())
				{
					this.q();
				}
				this.b++;
				if (this.d[this.b] == '/')
				{
					this.g = true;
					this.b++;
				}
				else
				{
					this.g = false;
				}
				this.j();
				this.a8();
				this.f = true;
				if (this.r(this.d[this.b]))
				{
					this.i();
				}
			}
		}

		// Token: 0x06003832 RID: 14386 RVA: 0x001E3788 File Offset: 0x001E2788
		internal void ac()
		{
			if (this.d[this.b] == '"')
			{
				this.b++;
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
			}
			while (this.d[this.b] != '"')
			{
				this.b++;
			}
			this.b++;
			this.a8();
			this.aa();
		}

		// Token: 0x06003833 RID: 14387 RVA: 0x001E3854 File Offset: 0x001E2854
		internal Color ad()
		{
			Color result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.o('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.o('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003834 RID: 14388 RVA: 0x001E393C File Offset: 0x001E293C
		internal LineLeadingType ae()
		{
			LineLeadingType result = LineLeadingType.Auto;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.k('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.k('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003835 RID: 14389 RVA: 0x001E3A24 File Offset: 0x001E2A24
		internal LineCap af()
		{
			LineCap result = LineCap.ProjectedSquare;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.j('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.j('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003836 RID: 14390 RVA: 0x001E3B0C File Offset: 0x001E2B0C
		internal PageOrientation ag()
		{
			PageOrientation result = PageOrientation.Portrait;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.b('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.b('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003837 RID: 14391 RVA: 0x001E3BF4 File Offset: 0x001E2BF4
		internal SymbolType ah()
		{
			SymbolType result = SymbolType.Check1;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.i('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.i('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003838 RID: 14392 RVA: 0x001E3CDC File Offset: 0x001E2CDC
		internal TextAlign ai()
		{
			TextAlign result = TextAlign.Left;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.h('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.h('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003839 RID: 14393 RVA: 0x001E3DC4 File Offset: 0x001E2DC4
		internal ParameterType aj()
		{
			ParameterType result = ParameterType.Int;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.g('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.g('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600383A RID: 14394 RVA: 0x001E3EAC File Offset: 0x001E2EAC
		internal ParameterDirection ak()
		{
			ParameterDirection result = ParameterDirection.Input;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.f('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.f('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600383B RID: 14395 RVA: 0x001E3F94 File Offset: 0x001E2F94
		internal AlternateRow al()
		{
			AlternateRow result = AlternateRow.All;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.e('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.e('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600383C RID: 14396 RVA: 0x001E407C File Offset: 0x001E307C
		internal ProviderType am()
		{
			ProviderType result = ProviderType.MsSql;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.d('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.d('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600383D RID: 14397 RVA: 0x001E4164 File Offset: 0x001E3164
		internal Font an()
		{
			string text = this.a7();
			Font font = this.a.b()[text];
			if (font == null)
			{
				throw new DlexParseException("Invalid font name specified. " + text + " is an invalid name.");
			}
			return font;
		}

		// Token: 0x0600383E RID: 14398 RVA: 0x001E41B4 File Offset: 0x001E31B4
		internal FontFamily ao()
		{
			string text = this.a7();
			FontFamily fontFamily = this.a.c()[text];
			if (fontFamily == null)
			{
				throw new DlexParseException("Invalid font family name specified. " + text + " is an invalid name.");
			}
			return fontFamily;
		}

		// Token: 0x0600383F RID: 14399 RVA: 0x001E4204 File Offset: 0x001E3204
		internal FontFamilyList ap()
		{
			return this.a.c();
		}

		// Token: 0x06003840 RID: 14400 RVA: 0x001E4224 File Offset: 0x001E3224
		internal VAlign aq()
		{
			VAlign result = VAlign.Top;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.c('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.c('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003841 RID: 14401 RVA: 0x001E430C File Offset: 0x001E330C
		internal float ar()
		{
			this.b++;
			int num = 0;
			int num2 = 0;
			bool flag = false;
			if (this.d[this.b] == '-')
			{
				flag = true;
				this.b++;
			}
			while (this.d[this.b] == '0')
			{
				this.b++;
			}
			while (this.s())
			{
				num = num * 10 + (int)this.d[this.b] - 48;
				num2++;
				this.b++;
			}
			float result;
			if (this.d[this.b] == '.')
			{
				this.b++;
				int num3 = 1;
				while (this.s() && num2 < 9)
				{
					num = num * 10 + (int)this.d[this.b] - 48;
					num3 *= 10;
					num2++;
					this.b++;
				}
				this.b++;
				this.a8();
				this.aa();
				if (flag)
				{
					result = -(float)num / (float)num3;
				}
				else
				{
					result = (float)num / (float)num3;
				}
			}
			else
			{
				this.b++;
				this.a8();
				this.aa();
				if (flag)
				{
					result = -(float)num;
				}
				else
				{
					result = (float)num;
				}
			}
			return result;
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x001E44A0 File Offset: 0x001E34A0
		internal int @as()
		{
			this.b++;
			int num = 0;
			int num2 = 0;
			bool flag = false;
			if (this.d[this.b] == '-')
			{
				flag = true;
				this.b++;
			}
			while (this.d[this.b] == '0')
			{
				this.b++;
			}
			while (this.s())
			{
				num = num * 10 + (int)this.d[this.b] - 48;
				num2++;
				this.b++;
			}
			this.b++;
			this.a8();
			this.aa();
			int result;
			if (flag)
			{
				result = -num;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x001E4580 File Offset: 0x001E3580
		internal byte at()
		{
			this.b++;
			int num = 0;
			int num2 = 0;
			while (this.d[this.b] == '0')
			{
				this.b++;
			}
			while (this.s())
			{
				num = num * 10 + (int)this.d[this.b] - 48;
				num2++;
				this.b++;
			}
			this.b++;
			this.a8();
			this.aa();
			if (num > 255)
			{
				throw new DlexParseException("Invalid unsignedByte value. The value is greater than 255.");
			}
			return (byte)num;
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x001E463C File Offset: 0x001E363C
		private bool s()
		{
			return this.d[this.b] >= '0' && this.d[this.b] <= '9';
		}

		// Token: 0x06003845 RID: 14405 RVA: 0x001E4678 File Offset: 0x001E3678
		internal LineStyle au()
		{
			LineStyle result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.p('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.p('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003846 RID: 14406 RVA: 0x001E4760 File Offset: 0x001E3760
		internal bool av()
		{
			bool result = true;
			if (this.d[this.b] == '"')
			{
				this.b++;
				this.a8();
				if (this.d[this.b] == 'f')
				{
					result = false;
				}
				this.b += 4;
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else
			{
				this.b++;
				this.a8();
				if (this.d[this.b] == 'f')
				{
					result = false;
				}
				this.b += 4;
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003847 RID: 14407 RVA: 0x001E487C File Offset: 0x001E387C
		internal int aw()
		{
			int result = -1;
			if (this.d[this.b] == '"')
			{
				this.b++;
				result = this.q('"');
				while (this.d[this.b] != '"')
				{
					this.b++;
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				result = this.q('\'');
				while (this.d[this.b] != '\'')
				{
					this.b++;
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x001E4964 File Offset: 0x001E3964
		internal air ax()
		{
			this.i = false;
			this.r();
			air result;
			if (!this.g)
			{
				int a_ = this.b;
				int a_2 = this.c();
				air air = new air(this, this.d, a_, a_2);
				this.i = true;
				this.aa();
				this.aa();
				result = air;
			}
			else
			{
				this.i = true;
				this.a8();
				result = null;
			}
			return result;
		}

		// Token: 0x06003849 RID: 14409 RVA: 0x001E49D8 File Offset: 0x001E39D8
		internal bool ay()
		{
			return this.d[this.b + 1] == '#';
		}

		// Token: 0x0600384A RID: 14410 RVA: 0x001E4A00 File Offset: 0x001E3A00
		internal al7 az()
		{
			al7 result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = al7.a(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = al7.a(this.d, a_, a_2);
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600384B RID: 14411 RVA: 0x001E4AB8 File Offset: 0x001E3AB8
		internal akn a0()
		{
			akn result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				this.a8();
				int num = this.b;
				int num2 = this.a('"');
				if (num == num2)
				{
					num--;
				}
				result = new akn(this, this.d, num, num2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int num = this.b;
				int num2 = this.a('"');
				result = new akn(this, this.d, num, num2);
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600384C RID: 14412 RVA: 0x001E4B8C File Offset: 0x001E3B8C
		internal akg a1()
		{
			akg result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int num = this.b;
				int num2 = this.a('"');
				if (num2 > num)
				{
					result = new akg(this.d, num, num2);
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int num = this.b;
				int num2 = this.a('"');
				if (num2 > num)
				{
					result = new akg(this.d, num, num2);
				}
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600384D RID: 14413 RVA: 0x001E4C60 File Offset: 0x001E3C60
		internal ahm a2()
		{
			ahm result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new ahm(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new ahm(this.d, a_, a_2);
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600384E RID: 14414 RVA: 0x001E4D18 File Offset: 0x001E3D18
		internal akg a3()
		{
			akg result = null;
			if (this.d[this.b] == '"')
			{
				this.b += 2;
				int a_ = this.b;
				int a_2 = this.a('"') - 1;
				result = new akg(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b += 2;
				int a_ = this.b;
				int a_2 = this.a('"') - 1;
				result = new akg(this.d, a_, a_2);
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x0600384F RID: 14415 RVA: 0x001E4DD4 File Offset: 0x001E3DD4
		internal air a4()
		{
			air result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new air(this, this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new air(this, this.d, a_, a_2);
			}
			this.a8();
			this.aa();
			return result;
		}

		// Token: 0x06003850 RID: 14416 RVA: 0x001E4E8C File Offset: 0x001E3E8C
		internal string a5()
		{
			string text = this.a7();
			string result;
			if (text != string.Empty)
			{
				if (Path.IsPathRooted(text))
				{
					result = text;
				}
				else
				{
					result = Path.Combine(this.a.a(), text);
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003851 RID: 14417 RVA: 0x001E4EE0 File Offset: 0x001E3EE0
		internal string a6()
		{
			string text = this.a7();
			if (text == null || text == string.Empty)
			{
				throw new DlexParseException("Image path not specified.");
			}
			string result;
			if (Path.IsPathRooted(text))
			{
				result = text;
			}
			else
			{
				result = Path.Combine(this.a.a(), text);
			}
			return result;
		}

		// Token: 0x06003852 RID: 14418 RVA: 0x001E4F40 File Offset: 0x001E3F40
		internal string a7()
		{
			string text = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int num = this.b;
				while (this.d[this.b] != '"')
				{
					if (this.d[this.b] == '&')
					{
						text = this.a(num, '"');
					}
					else
					{
						this.b++;
					}
				}
				if (text == null)
				{
					text = new string(this.d, num, this.b - num);
				}
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int num = this.b;
				while (this.d[this.b] != '\'')
				{
					if (this.d[this.b] == '&')
					{
						text = this.a(num, '\'');
					}
					else
					{
						this.b++;
					}
				}
				if (text == null)
				{
					text = new string(this.d, num, this.b - num);
				}
			}
			this.b++;
			this.a8();
			this.aa();
			return text;
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x001E50C0 File Offset: 0x001E40C0
		private string a(int A_0, char A_1)
		{
			int num = this.b;
			do
			{
				if (this.d[this.b] == '&')
				{
					this.b++;
					if (this.d[this.b] == '#')
					{
						this.b++;
						if (this.d[this.b] == 'x')
						{
							this.b++;
							int num2 = 0;
							while (this.d[this.b] != ';')
							{
								if (this.d[this.b] >= '0')
								{
									if (this.d[this.b] <= '9')
									{
										num2 = (num2 << 4 | (int)(this.d[this.b++] - '0'));
									}
									else if (this.d[this.b] >= 'A')
									{
										if (this.d[this.b] <= 'F')
										{
											num2 = (num2 << 4 | (int)(this.d[this.b++] - '7'));
										}
										else if (this.d[this.b] >= 'a')
										{
											if (this.d[this.b] <= 'f')
											{
												num2 = (num2 << 4 | (int)(this.d[this.b++] - 'a'));
											}
										}
									}
								}
							}
							this.d[num++] = (char)num2;
						}
						else
						{
							int num2 = 0;
							while (this.d[this.b] != ';')
							{
								num2 = num2 * 10 + (int)this.d[this.b++] - 48;
							}
							this.d[num++] = (char)num2;
						}
					}
					else
					{
						int num3 = this.k();
						if (num3 <= 2868)
						{
							if (num3 != 2548)
							{
								if (num3 == 2868)
								{
									this.d[num++] = '<';
								}
							}
							else
							{
								this.d[num++] = '>';
							}
						}
						else if (num3 != 138096)
						{
							if (num3 != 8850419)
							{
								if (num3 == 13065204)
								{
									this.d[num++] = '"';
								}
							}
							else
							{
								this.d[num++] = '\'';
							}
						}
						else
						{
							this.d[num++] = '&';
						}
					}
				}
				else
				{
					this.d[num++] = this.d[this.b];
				}
				this.b++;
			}
			while (this.d[this.b] != A_1);
			return new string(this.d, A_0, num - A_0);
		}

		// Token: 0x06003854 RID: 14420 RVA: 0x001E53CC File Offset: 0x001E43CC
		private void r()
		{
			while (this.f)
			{
				this.aa();
			}
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x001E53F0 File Offset: 0x001E43F0
		private void q()
		{
			if (this.m())
			{
				this.p();
			}
			if (this.l())
			{
				this.o();
			}
			if (!this.n())
			{
				this.q();
			}
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x001E5438 File Offset: 0x001E4438
		private void p()
		{
			this.b += 2;
			while (this.d[this.b] != '?' && this.d[this.b + 1] != '>')
			{
				this.b++;
			}
			this.b += 2;
			this.a8();
		}

		// Token: 0x06003857 RID: 14423 RVA: 0x001E54A8 File Offset: 0x001E44A8
		private void o()
		{
			this.b += 4;
			while (this.d[this.b] != '-' || this.d[this.b + 1] != '-' || this.d[this.b + 2] != '>')
			{
				this.b++;
			}
			this.b += 3;
			this.a8();
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x001E552C File Offset: 0x001E452C
		private bool n()
		{
			return this.d[this.b] == '<' && (this.r(this.d[this.b + 1]) || (this.d[this.b + 1] == '/' && this.r(this.d[this.b + 2])));
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x001E559C File Offset: 0x001E459C
		private bool r(char A_0)
		{
			return (A_0 >= 'a' && A_0 <= 'z') || (A_0 >= 'A' && A_0 <= 'Z') || A_0 == ':' || A_0 == '_';
		}

		// Token: 0x0600385A RID: 14426 RVA: 0x001E55D0 File Offset: 0x001E45D0
		private bool m()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '?';
		}

		// Token: 0x0600385B RID: 14427 RVA: 0x001E560C File Offset: 0x001E460C
		private bool l()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '!' && this.d[this.b + 2] == '-' && this.d[this.b + 3] == '-';
		}

		// Token: 0x0600385C RID: 14428 RVA: 0x001E566C File Offset: 0x001E466C
		internal void a8()
		{
			while (this.d[this.b] <= ' ')
			{
				if (this.d.Length == this.b + 1)
				{
					break;
				}
				this.b++;
			}
		}

		// Token: 0x0600385D RID: 14429 RVA: 0x001E56C0 File Offset: 0x001E46C0
		private int k()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (this.d[this.b] != ';')
			{
				num2 <<= 6;
				num2 |= (int)(this.d[this.b++] % '@');
				if (num3 % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				num3++;
			}
			if (num3 % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x0600385E RID: 14430 RVA: 0x001E5748 File Offset: 0x001E4748
		private void j()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (this.d[this.b] > ' ' && this.d[this.b] != '>' && this.d[this.b] != '/')
			{
				num2 <<= 6;
				num2 |= (int)(this.d[this.b++] % '@');
				if (num3 % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				num3++;
			}
			if (num3 % 5 != 0)
			{
				num ^= num2;
			}
			this.e = num;
		}

		// Token: 0x0600385F RID: 14431 RVA: 0x001E57F8 File Offset: 0x001E47F8
		private void i()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (this.d[this.b] > ' ' && this.d[this.b] != '=')
			{
				num2 <<= 6;
				num2 |= (int)(this.d[this.b++] % '@');
				if (num3 % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				num3++;
			}
			if (num3 % 5 != 0)
			{
				num ^= num2;
			}
			this.h = num;
			this.a8();
			this.b++;
			this.a8();
		}

		// Token: 0x06003860 RID: 14432 RVA: 0x001E58B4 File Offset: 0x001E48B4
		private int q(char A_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (this.d[this.b] != A_0)
			{
				num2 <<= 6;
				num2 |= (int)(this.d[this.b++] % '@');
				if (num3 % 5 == 4)
				{
					num ^= num2;
					num2 = 0;
				}
				num3++;
			}
			if (num3 % 5 != 0)
			{
				num ^= num2;
			}
			return num;
		}

		// Token: 0x06003861 RID: 14433 RVA: 0x001E593C File Offset: 0x001E493C
		private LineStyle p(char A_0)
		{
			LineStyle result;
			if (this.d[this.b] == '[')
			{
				this.b++;
				ArrayList arrayList = new ArrayList(2);
				while (this.d[this.b] != ']')
				{
					arrayList.Add(this.a9());
					if (this.d[this.b] == ',')
					{
						this.b++;
					}
				}
				if (this.s())
				{
					result = new LineStyle((float[])arrayList.ToArray(typeof(float)), this.a9());
				}
				else
				{
					result = new LineStyle((float[])arrayList.ToArray(typeof(float)));
				}
			}
			else
			{
				result = this.l(A_0);
			}
			return result;
		}

		// Token: 0x06003862 RID: 14434 RVA: 0x001E5A28 File Offset: 0x001E4A28
		internal float a9()
		{
			int num = 0;
			int num2 = 0;
			while (this.d[this.b] == '0')
			{
				this.b++;
			}
			while (this.s())
			{
				num = num * 10 + (int)this.d[this.b] - 48;
				num2++;
				this.b++;
			}
			float result;
			if (this.d[this.b] == '.')
			{
				this.b++;
				int num3 = 1;
				while (this.s() && num2 < 9)
				{
					num = num * 10 + (int)this.d[this.b] - 48;
					num3 *= 10;
					num2++;
					this.b++;
				}
				result = (float)num / (float)num3;
			}
			else
			{
				result = (float)num;
			}
			return result;
		}

		// Token: 0x06003863 RID: 14435 RVA: 0x001E5B1C File Offset: 0x001E4B1C
		private Color o(char A_0)
		{
			Color result;
			if (this.d[this.b] == '#')
			{
				this.b++;
				result = new RgbColor(this.g(), this.g(), this.g());
			}
			else if (this.d[this.b] == 'r' && this.d[this.b + 1] == 'g' && this.d[this.b + 2] == 'b')
			{
				this.b += 4;
				float red = this.h();
				this.b++;
				float green = this.h();
				this.b++;
				float blue = this.h();
				result = new RgbColor(red, green, blue);
			}
			else if (this.d[this.b] == 'c' && this.d[this.b + 1] == 'm' && this.d[this.b + 2] == 'y' && this.d[this.b + 3] == 'k')
			{
				this.b += 5;
				float cyan = this.h();
				this.b++;
				float magenta = this.h();
				this.b++;
				float yellow = this.h();
				this.b++;
				float black = this.h();
				result = new CmykColor(cyan, magenta, yellow, black);
			}
			else if (this.d[this.b + 4] == '(' && this.d[this.b] == 'g' && this.d[this.b + 1] == 'r' && this.d[this.b + 2] == 'a' && this.d[this.b + 3] == 'y')
			{
				this.b += 5;
				result = new Grayscale(this.h());
			}
			else
			{
				result = this.m(A_0);
			}
			return result;
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x001E5D5C File Offset: 0x001E4D5C
		private float h()
		{
			float result;
			if (this.d[this.b] == '1')
			{
				this.b++;
				while (this.s() || this.d[this.b] == '.')
				{
					this.b++;
				}
				result = 1f;
			}
			else
			{
				int num = 0;
				int num2 = 1;
				while (this.d[this.b] == '0')
				{
					this.b++;
				}
				if (this.d[this.b] == '.')
				{
					this.b++;
					while (this.s())
					{
						num = num * 10 + (int)this.d[this.b++] - 48;
						num2 *= 10;
					}
				}
				result = (float)num / (float)num2;
			}
			return result;
		}

		// Token: 0x06003865 RID: 14437 RVA: 0x001E5E60 File Offset: 0x001E4E60
		private byte g()
		{
			return (byte)(ald.n(this.d[this.b++]) << 4 | ald.n(this.d[this.b++]));
		}

		// Token: 0x06003866 RID: 14438 RVA: 0x001E5EB0 File Offset: 0x001E4EB0
		private static int n(char A_0)
		{
			int result;
			if (A_0 <= '9')
			{
				result = (int)(A_0 - '0');
			}
			else if (A_0 <= 'F')
			{
				result = (int)(A_0 - '7');
			}
			else
			{
				result = (int)(A_0 - 'W');
			}
			return result;
		}

		// Token: 0x06003867 RID: 14439 RVA: 0x001E5EE8 File Offset: 0x001E4EE8
		private Color m(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 612836278)
			{
				if (num <= 219577695)
				{
					if (num <= 13560823)
					{
						if (num <= 10258192)
						{
							if (num <= 1198940)
							{
								if (num <= 215150)
								{
									if (num == 207204)
									{
										return RgbColor.Red;
									}
									if (num == 215150)
									{
										return RgbColor.Tan;
									}
								}
								else
								{
									if (num == 902088)
									{
										return RgbColor.Aquamarine;
									}
									if (num == 1198940)
									{
										return RgbColor.MediumSeaGreen;
									}
								}
							}
							else if (num <= 9096549)
							{
								if (num == 8854881)
								{
									return RgbColor.Aqua;
								}
								if (num == 9096549)
								{
									return RgbColor.Blue;
								}
							}
							else
							{
								if (num == 9410670)
								{
									return RgbColor.Cyan;
								}
								if (num == 10258192)
								{
									return RgbColor.MediumBlue;
								}
							}
						}
						else if (num <= 11705189)
						{
							if (num <= 10430585)
							{
								if (num == 10418980)
								{
									return RgbColor.Gold;
								}
								if (num == 10430585)
								{
									return RgbColor.Gray;
								}
							}
							else
							{
								if (num == 11102457)
								{
									return RgbColor.MediumOrchid;
								}
								if (num == 11705189)
								{
									return RgbColor.Lime;
								}
							}
						}
						else if (num <= 12737717)
						{
							if (num == 12197305)
							{
								return RgbColor.Navy;
							}
							if (num == 12737717)
							{
								return RgbColor.Peru;
							}
						}
						else
						{
							if (num == 12753835)
							{
								return RgbColor.Pink;
							}
							if (num == 12766573)
							{
								return RgbColor.Plum;
							}
							if (num == 13560823)
							{
								return RgbColor.Snow;
							}
						}
					}
					else if (num <= 134393588)
					{
						if (num <= 31056443)
						{
							if (num <= 13966816)
							{
								if (num == 13785196)
								{
									return RgbColor.Teal;
								}
								if (num == 13966816)
								{
									return RgbColor.MediumPurple;
								}
							}
							else
							{
								if (num == 16998168)
								{
									return RgbColor.DarkSeaGreen;
								}
								if (num == 31056443)
								{
									return RgbColor.NavajoWhite;
								}
							}
						}
						else if (num <= 85553496)
						{
							if (num == 45462592)
							{
								return RgbColor.PowderBlue;
							}
							if (num == 85553496)
							{
								return RgbColor.DarkMagenta;
							}
						}
						else
						{
							if (num == 87421245)
							{
								return RgbColor.DarkSalmon;
							}
							if (num == 89082078)
							{
								return RgbColor.PaleTurquoise;
							}
							if (num == 134393588)
							{
								return RgbColor.DarkSlateBlue;
							}
						}
					}
					else if (num <= 168101472)
					{
						if (num <= 135468330)
						{
							if (num == 134433773)
							{
								return RgbColor.DarkSlateGray;
							}
							if (num == 135468330)
							{
								return RgbColor.LavenderBlush;
							}
						}
						else
						{
							if (num == 149560038)
							{
								return RgbColor.DarkOliveGreen;
							}
							if (num == 168101472)
							{
								return RgbColor.MidnightBlue;
							}
						}
					}
					else if (num <= 183269104)
					{
						if (num == 177381483)
						{
							return RgbColor.BlanchedAlmond;
						}
						if (num == 183269104)
						{
							return RgbColor.FloralWhite;
						}
					}
					else
					{
						if (num == 185438242)
						{
							return RgbColor.BlueViolet;
						}
						if (num == 187975757)
						{
							return RgbColor.DarkGoldenRod;
						}
						if (num == 219577695)
						{
							return RgbColor.MediumAquaMarine;
						}
					}
				}
				else if (num <= 565728640)
				{
					if (num <= 338574717)
					{
						if (num <= 259159811)
						{
							if (num <= 243917412)
							{
								if (num == 221897634)
								{
									return RgbColor.DarkViolet;
								}
								if (num == 243917412)
								{
									return RgbColor.YellowGreen;
								}
							}
							else
							{
								if (num == 252354481)
								{
									return RgbColor.CornflowerBlue;
								}
								if (num == 259159811)
								{
									return RgbColor.DeepSkyBlue;
								}
							}
						}
						else if (num <= 290368350)
						{
							if (num == 288702545)
							{
								return RgbColor.Chartreuse;
							}
							if (num == 290368350)
							{
								return RgbColor.DarkTurquoise;
							}
						}
						else
						{
							if (num == 299467273)
							{
								return RgbColor.PapayaWhip;
							}
							if (num == 312475704)
							{
								return RgbColor.ForestGreen;
							}
							if (num == 338574717)
							{
								return RgbColor.AntiqueWhite;
							}
						}
					}
					else if (num <= 378364661)
					{
						if (num <= 369214218)
						{
							if (num == 349963045)
							{
								return RgbColor.SpringGreen;
							}
							if (num == 369214218)
							{
								return RgbColor.DarkOrange;
							}
						}
						else
						{
							if (num == 369729707)
							{
								return RgbColor.DarkOrchid;
							}
							if (num == 378364661)
							{
								return RgbColor.SaddleBrown;
							}
						}
					}
					else if (num <= 423176518)
					{
						if (num == 380929152)
						{
							return RgbColor.DodgerBlue;
						}
						if (num == 423176518)
						{
							return RgbColor.PaleVioletRed;
						}
					}
					else
					{
						if (num == 523611085)
						{
							return RgbColor.PaleGoldenRod;
						}
						if (num == 551584255)
						{
							return RgbColor.LightGoldenRodYellow;
						}
						if (num == 565728640)
						{
							return RgbColor.AliceBlue;
						}
					}
				}
				else if (num <= 599634072)
				{
					if (num <= 581385296)
					{
						if (num <= 579457245)
						{
							if (num == 569072805)
							{
								return RgbColor.Azure;
							}
							if (num == 579457245)
							{
								return RgbColor.BurlyWood;
							}
						}
						else
						{
							if (num == 580295141)
							{
								return RgbColor.Beige;
							}
							if (num == 581385296)
							{
								return RgbColor.Bisque;
							}
						}
					}
					else if (num <= 583728622)
					{
						if (num == 582097131)
						{
							return RgbColor.Black;
						}
						if (num == 583728622)
						{
							return RgbColor.Brown;
						}
					}
					else
					{
						if (num == 588309962)
						{
							return RgbColor.Chocolate;
						}
						if (num == 596411409)
						{
							return RgbColor.CadetBlue;
						}
						if (num == 599634072)
						{
							return RgbColor.Cornsilk;
						}
					}
				}
				else if (num <= 606416930)
				{
					if (num <= 600477853)
					{
						if (num == 599730284)
						{
							return RgbColor.Coral;
						}
						if (num == 600477853)
						{
							return RgbColor.Crimson;
						}
					}
					else
					{
						if (num == 605317056)
						{
							return RgbColor.WhiteSmoke;
						}
						if (num == 606416930)
						{
							return RgbColor.DarkKhaki;
						}
					}
				}
				else if (num <= 612631230)
				{
					if (num == 609055657)
					{
						return RgbColor.DarkGreen;
					}
					if (num == 612631230)
					{
						return RgbColor.DarkGray;
					}
				}
				else
				{
					if (num == 612676269)
					{
						return RgbColor.DarkCyan;
					}
					if (num == 612755367)
					{
						return RgbColor.DarkBlue;
					}
					if (num == 612836278)
					{
						return RgbColor.DarkRed;
					}
				}
			}
			else if (num <= 800213956)
			{
				if (num <= 743252713)
				{
					if (num <= 655124252)
					{
						if (num <= 634539876)
						{
							if (num <= 614914443)
							{
								if (num == 613730235)
								{
									return RgbColor.DeepPink;
								}
								if (num == 614914443)
								{
									return RgbColor.DimGray;
								}
							}
							else
							{
								if (num == 622721277)
								{
									return RgbColor.MediumVioletRed;
								}
								if (num == 634539876)
								{
									return RgbColor.MediumSlateBlue;
								}
							}
						}
						else if (num <= 647348545)
						{
							if (num == 644723113)
							{
								return RgbColor.FireBrick;
							}
							if (num == 647348545)
							{
								return RgbColor.Feldspar;
							}
						}
						else
						{
							if (num == 651571282)
							{
								return RgbColor.Fuchsia;
							}
							if (num == 654828225)
							{
								return RgbColor.GoldenRod;
							}
							if (num == 655124252)
							{
								return RgbColor.Gainsboro;
							}
						}
					}
					else if (num <= 688087813)
					{
						if (num <= 683581454)
						{
							if (num == 667572590)
							{
								return RgbColor.Green;
							}
							if (num == 683581454)
							{
								return RgbColor.HoneyDew;
							}
						}
						else
						{
							if (num == 683626370)
							{
								return RgbColor.HotPink;
							}
							if (num == 688087813)
							{
								return RgbColor.IndianRed;
							}
						}
					}
					else if (num <= 702217401)
					{
						if (num == 700074568)
						{
							return RgbColor.Indigo;
						}
						if (num == 702217401)
						{
							return RgbColor.Ivory;
						}
					}
					else
					{
						if (num == 728507226)
						{
							return RgbColor.LightGreen;
						}
						if (num == 732044009)
						{
							return RgbColor.Khaki;
						}
						if (num == 743252713)
						{
							return RgbColor.LawnGreen;
						}
					}
				}
				else if (num <= 763786319)
				{
					if (num <= 749331034)
					{
						if (num <= 746922012)
						{
							if (num == 745308201)
							{
								return RgbColor.LimeGreen;
							}
							if (num == 746922012)
							{
								return RgbColor.Lavender;
							}
						}
						else
						{
							if (num == 749136238)
							{
								return RgbColor.Linen;
							}
							if (num == 749331034)
							{
								return RgbColor.LightCyan;
							}
						}
					}
					else if (num <= 750342989)
					{
						if (num == 749516625)
						{
							return RgbColor.LightBlue;
						}
						if (num == 750342989)
						{
							return RgbColor.LightGrey;
						}
					}
					else
					{
						if (num == 753197471)
						{
							return RgbColor.LightPink;
						}
						if (num == 762099054)
						{
							return RgbColor.MintCream;
						}
						if (num == 763786319)
						{
							return RgbColor.Magenta;
						}
					}
				}
				else if (num <= 776286999)
				{
					if (num <= 767361679)
					{
						if (num == 763833281)
						{
							return RgbColor.Maroon;
						}
						if (num == 767361679)
						{
							return RgbColor.Moccasin;
						}
					}
					else
					{
						if (num == 770556380)
						{
							return RgbColor.MistyRose;
						}
						if (num == 776286999)
						{
							return RgbColor.MediumSpringGreen;
						}
					}
				}
				else if (num <= 791955878)
				{
					if (num == 790188632)
					{
						return RgbColor.LightCoral;
					}
					if (num == 791955878)
					{
						return RgbColor.LemonChiffon;
					}
				}
				else
				{
					if (num == 794768067)
					{
						return RgbColor.OrangeRed;
					}
					if (num == 799126983)
					{
						return RgbColor.OliveDrab;
					}
					if (num == 800213956)
					{
						return RgbColor.OldLace;
					}
				}
			}
			else if (num <= 867749952)
			{
				if (num <= 846578604)
				{
					if (num <= 805331409)
					{
						if (num <= 801774466)
						{
							if (num == 800234917)
							{
								return RgbColor.Olive;
							}
							if (num == 801774466)
							{
								return RgbColor.Orange;
							}
						}
						else
						{
							if (num == 801782285)
							{
								return RgbColor.Orchid;
							}
							if (num == 805331409)
							{
								return RgbColor.GhostWhite;
							}
						}
					}
					else if (num <= 819282254)
					{
						if (num == 810324009)
						{
							return RgbColor.PaleGreen;
						}
						if (num == 819282254)
						{
							return RgbColor.PeachPuff;
						}
					}
					else
					{
						if (num == 819407881)
						{
							return RgbColor.Purple;
						}
						if (num == 827069655)
						{
							return RgbColor.SandyBrown;
						}
						if (num == 846578604)
						{
							return RgbColor.RosyBrown;
						}
					}
				}
				else if (num <= 865357764)
				{
					if (num <= 864471873)
					{
						if (num == 850744585)
						{
							return RgbColor.RoyalBlue;
						}
						if (num == 864471873)
						{
							return RgbColor.Salmon;
						}
					}
					else
					{
						if (num == 865355932)
						{
							return RgbColor.SeaGreen;
						}
						if (num == 865357764)
						{
							return RgbColor.SeaShell;
						}
					}
				}
				else if (num <= 866569623)
				{
					if (num == 866540431)
					{
						return RgbColor.Sienna;
					}
					if (num == 866569623)
					{
						return RgbColor.Silver;
					}
				}
				else
				{
					if (num == 866989404)
					{
						return RgbColor.SlateGray;
					}
					if (num == 867147209)
					{
						return RgbColor.SkyBlue;
					}
					if (num == 867749952)
					{
						return RgbColor.SlateBlue;
					}
				}
			}
			else if (num <= 933386356)
			{
				if (num <= 884922459)
				{
					if (num <= 879341712)
					{
						if (num == 869831689)
						{
							return RgbColor.SteelBlue;
						}
						if (num == 879341712)
						{
							return RgbColor.Turquoise;
						}
					}
					else
					{
						if (num == 883070929)
						{
							return RgbColor.Thistle;
						}
						if (num == 884922459)
						{
							return RgbColor.Tomato;
						}
					}
				}
				else if (num <= 897288737)
				{
					if (num == 892383532)
					{
						return RgbColor.LightYellow;
					}
					if (num == 897288737)
					{
						return RgbColor.MediumTurquoise;
					}
				}
				else
				{
					if (num == 913822273)
					{
						return RgbColor.VioletRed;
					}
					if (num == 916912913)
					{
						return RgbColor.Violet;
					}
					if (num == 933386356)
					{
						return RgbColor.Wheat;
					}
				}
			}
			else if (num <= 1057613821)
			{
				if (num <= 966183704)
				{
					if (num == 933403941)
					{
						return RgbColor.White;
					}
					if (num == 966183704)
					{
						return RgbColor.Yellow;
					}
				}
				else
				{
					if (num == 1046254198)
					{
						return RgbColor.GreenYellow;
					}
					if (num == 1057613821)
					{
						return RgbColor.LightSkyBlue;
					}
				}
			}
			else if (num <= 1058974324)
			{
				if (num == 1057705832)
				{
					return RgbColor.LightSlateGray;
				}
				if (num == 1058974324)
				{
					return RgbColor.LightSlateBlue;
				}
			}
			else
			{
				if (num == 1059107189)
				{
					return RgbColor.LightSalmon;
				}
				if (num == 1060254376)
				{
					return RgbColor.LightSeaGreen;
				}
				if (num == 1065283133)
				{
					return RgbColor.LightSteelBlue;
				}
			}
			throw new DlexParseException("Invalid named color attribute value specified.");
		}

		// Token: 0x06003868 RID: 14440 RVA: 0x001E6E8C File Offset: 0x001E5E8C
		private LineStyle l(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 9633075)
			{
				if (num == 9575656)
				{
					return LineStyle.Dash;
				}
				if (num == 9633075)
				{
					return LineStyle.Dots;
				}
			}
			else
			{
				if (num == 603984873)
				{
					return LineStyle.DashLarge;
				}
				if (num == 607199551)
				{
					return LineStyle.DashSmall;
				}
				if (num == 868141668)
				{
					return LineStyle.Solid;
				}
			}
			throw new DlexParseException("Invalid lineStyle attribute value specified.");
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x001E6F0C File Offset: 0x001E5F0C
		private LineLeadingType k(char A_0)
		{
			int num = this.q(A_0);
			LineLeadingType result;
			if (num != 8871215)
			{
				if (num != 567330197)
				{
					if (num != 635573197)
					{
						throw new DlexParseException("Invalid leadingType attribute value specified.");
					}
					result = LineLeadingType.Exactly;
				}
				else
				{
					result = LineLeadingType.AtLeast;
				}
			}
			else
			{
				result = LineLeadingType.Auto;
			}
			return result;
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x001E6F54 File Offset: 0x001E5F54
		private LineCap j(char A_0)
		{
			int num = this.q(A_0);
			LineCap result;
			if (num != 9133364)
			{
				if (num != 583974675)
				{
					if (num != 851399360)
					{
						throw new DlexParseException("Invalid align lineCap value specified.");
					}
					result = LineCap.Round;
				}
				else
				{
					result = LineCap.ProjectedSquare;
				}
			}
			else
			{
				result = LineCap.Butt;
			}
			return result;
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x001E6F9C File Offset: 0x001E5F9C
		private SymbolType i(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 597842138)
			{
				switch (num)
				{
				case 3633:
					return SymbolType.X1;
				case 3634:
					return SymbolType.X2;
				case 3635:
					return SymbolType.X3;
				case 3636:
					return SymbolType.X4;
				default:
					switch (num)
					{
					case 597842137:
						return SymbolType.Check2;
					case 597842138:
						return SymbolType.Check1;
					}
					break;
				}
			}
			else
			{
				if (num == 598157513)
				{
					return SymbolType.Circle;
				}
				if (num == 601308418)
				{
					return SymbolType.Custom;
				}
				if (num == 868702295)
				{
					return SymbolType.Square;
				}
			}
			throw new DlexParseException("Invalid textAlign attribute value specified.");
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x001E7038 File Offset: 0x001E6038
		private TextAlign h(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 320438613)
			{
				if (num == 11688372)
				{
					return TextAlign.Left;
				}
				if (num == 320438613)
				{
					return TextAlign.FullJustify;
				}
			}
			else
			{
				if (num == 597093655)
				{
					return TextAlign.Center;
				}
				if (num == 718746768)
				{
					return TextAlign.Justify;
				}
				if (num == 849771060)
				{
					return TextAlign.Right;
				}
			}
			throw new DlexParseException("Invalid textAlign attribute value specified.");
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x001E70A4 File Offset: 0x001E60A4
		private ParameterType g(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 649263220)
			{
				if (num <= 225939788)
				{
					if (num <= 10370323)
					{
						if (num <= 9125170)
						{
							if (num == 141940)
							{
								return ParameterType.Bit;
							}
							if (num == 170932)
							{
								return ParameterType.Int;
							}
							if (num == 9125170)
							{
								return ParameterType.Bstr;
							}
						}
						else if (num <= 9341042)
						{
							if (num == 9149733)
							{
								return ParameterType.Byte;
							}
							if (num == 9341042)
							{
								return ParameterType.Char;
							}
						}
						else
						{
							if (num == 9575717)
							{
								return ParameterType.Date;
							}
							if (num == 10370323)
							{
								return ParameterType.TimestampLocal;
							}
						}
					}
					else if (num <= 13786676)
					{
						if (num == 10443364)
						{
							return ParameterType.Guid;
						}
						if (num == 13260908)
						{
							return ParameterType.Real;
						}
						if (num == 13786676)
						{
							return ParameterType.Text;
						}
					}
					else if (num <= 21365296)
					{
						if (num == 13802341)
						{
							return ParameterType.Time;
						}
						if (num == 21365296)
						{
							return ParameterType.DBTimestamp;
						}
					}
					else
					{
						if (num == 225891269)
						{
							return ParameterType.LongVarChar;
						}
						if (num == 225939788)
						{
							return ParameterType.LongVarWChar;
						}
					}
				}
				else if (num <= 607829836)
				{
					if (num <= 464642426)
					{
						if (num == 454035926)
						{
							return ParameterType.VarNumeric;
						}
						if (num == 455964733)
						{
							return ParameterType.UnsignedInt;
						}
						if (num == 464642426)
						{
							return ParameterType.UnsignedBigInt;
						}
					}
					else if (num <= 582939467)
					{
						if (num == 581333594)
						{
							return ParameterType.BigInt;
						}
						if (num == 582939467)
						{
							return ParameterType.Boolean;
						}
					}
					else
					{
						if (num == 601211996)
						{
							return ParameterType.Currency;
						}
						if (num == 607829836)
						{
							return ParameterType.UniqueIdentifier;
						}
					}
				}
				else if (num <= 612977224)
				{
					if (num == 612749873)
					{
						return ParameterType.DateTime;
					}
					if (num == 612911185)
					{
						return ParameterType.DBDate;
					}
					if (num == 612977224)
					{
						return ParameterType.DBTime;
					}
				}
				else if (num <= 616519817)
				{
					if (num == 613822977)
					{
						return ParameterType.Decimal;
					}
					if (num == 616519817)
					{
						return ParameterType.Double;
					}
				}
				else
				{
					if (num == 648303121)
					{
						return ParameterType.Filetime;
					}
					if (num == 649263220)
					{
						return ParameterType.Float;
					}
				}
			}
			else if (num <= 856399141)
			{
				if (num <= 772704370)
				{
					if (num <= 700140662)
					{
						if (num == 652314386)
						{
							return ParameterType.IntervalDayToSecond;
						}
						if (num == 700137493)
						{
							return ParameterType.Integer;
						}
						if (num == 700140662)
						{
							return ParameterType.Int16;
						}
					}
					else if (num <= 703758462)
					{
						if (num == 700140786)
						{
							return ParameterType.Int32;
						}
						if (num == 703758462)
						{
							return ParameterType.TimestampWithTZ;
						}
					}
					else
					{
						if (num == 767486329)
						{
							return ParameterType.Money;
						}
						if (num == 772704370)
						{
							return ParameterType.NChar;
						}
					}
				}
				else if (num <= 785830673)
				{
					if (num == 777150004)
					{
						return ParameterType.NText;
					}
					if (num == 777557233)
					{
						return ParameterType.NVarChar;
					}
					if (num == 785830673)
					{
						return ParameterType.Numeric;
					}
				}
				else if (num <= 844978951)
				{
					if (num == 785832087)
					{
						return ParameterType.Number;
					}
					if (num == 844978951)
					{
						return ParameterType.RefCursor;
					}
				}
				else
				{
					if (num == 851407460)
					{
						return ParameterType.RowId;
					}
					if (num == 856399141)
					{
						return ParameterType.SByte;
					}
				}
			}
			else if (num <= 902423802)
			{
				if (num <= 880067075)
				{
					if (num == 866576841)
					{
						return ParameterType.Single;
					}
					if (num == 867598488)
					{
						return ParameterType.SmallInt;
					}
					if (num == 880067075)
					{
						return ParameterType.Timestamp;
					}
				}
				else if (num <= 891743489)
				{
					if (num == 883353085)
					{
						return ParameterType.TinyInt;
					}
					if (num == 891743489)
					{
						return ParameterType.UInt32;
					}
				}
				else
				{
					if (num == 891743495)
					{
						return ParameterType.UInt16;
					}
					if (num == 902423802)
					{
						return ParameterType.UnsignedTinyInt;
					}
				}
			}
			else if (num <= 923699314)
			{
				if (num == 914730417)
				{
					return ParameterType.VarWChar;
				}
				if (num == 914827418)
				{
					return ParameterType.VarChar;
				}
				if (num == 923699314)
				{
					return ParameterType.WChar;
				}
			}
			else if (num <= 983547088)
			{
				if (num == 926140701)
				{
					return ParameterType.SmallDateTime;
				}
				if (num == 983547088)
				{
					return ParameterType.UnsignedSmallInt;
				}
			}
			else
			{
				if (num == 1040773717)
				{
					return ParameterType.SmallMoney;
				}
				if (num == 1045047794)
				{
					return ParameterType.IntervalYearToMonth;
				}
			}
			throw new DlexParseException("Invalid parameterType attribute value specified.");
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x001E75D8 File Offset: 0x001E65D8
		private ParameterDirection f(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 644628853)
			{
				if (num == 483219042)
				{
					return ParameterDirection.ReturnValue;
				}
				if (num == 644628853)
				{
					return ParameterDirection.InputOutput;
				}
			}
			else
			{
				if (num == 700124532)
				{
					return ParameterDirection.Input;
				}
				if (num == 802638849)
				{
					return ParameterDirection.Output;
				}
			}
			throw new DlexParseException("Invalid parameterDirection attribute value specified.");
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x001E7638 File Offset: 0x001E6638
		private AlternateRow e(char A_0)
		{
			int num = this.q(A_0);
			AlternateRow result;
			if (num != 138028)
			{
				if (num != 194852)
				{
					if (num != 9922926)
					{
						throw new DlexParseException("Invalid alternateRow attribute value specified.");
					}
					result = AlternateRow.Even;
				}
				else
				{
					result = AlternateRow.Odd;
				}
			}
			else
			{
				result = AlternateRow.All;
			}
			return result;
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x001E7680 File Offset: 0x001E6680
		private ProviderType d(char A_0)
		{
			int num = this.q(A_0);
			if (num <= 768425068)
			{
				if (num == 12470435)
				{
					return ProviderType.Odbc;
				}
				if (num == 768425068)
				{
					return ProviderType.MsSql;
				}
			}
			else
			{
				if (num == 800215330)
				{
					return ProviderType.OleDb;
				}
				if (num == 801773769)
				{
					return ProviderType.Oracle;
				}
			}
			throw new DlexParseException("Invalid providerType attribute value specified.");
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x001E76E0 File Offset: 0x001E66E0
		private VAlign c(char A_0)
		{
			int num = this.q(A_0);
			VAlign result;
			if (num != 216048)
			{
				if (num != 582962434)
				{
					if (num != 597093655)
					{
						throw new DlexParseException("Invalid vAlign attribute value specified.");
					}
					result = VAlign.Center;
				}
				else
				{
					result = VAlign.Bottom;
				}
			}
			else
			{
				result = VAlign.Top;
			}
			return result;
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x001E7728 File Offset: 0x001E6728
		private PageOrientation b(char A_0)
		{
			int num = this.q(A_0);
			PageOrientation result;
			if (num != 738784534)
			{
				if (num != 817706822)
				{
					throw new DlexParseException("Invalid pageOrientation attribute value specified.");
				}
				result = PageOrientation.Portrait;
			}
			else
			{
				result = PageOrientation.Landscape;
			}
			return result;
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x001E7764 File Offset: 0x001E6764
		private int a(char A_0)
		{
			while (this.d[this.b] != '&' && this.d[this.b] != A_0)
			{
				this.b++;
			}
			int result;
			if (this.d[this.b] == A_0)
			{
				result = this.b++;
			}
			else
			{
				int num = this.b;
				this.d[num++] = this.ba();
				while (this.d[this.b] != A_0)
				{
					while (this.d[this.b] != '&' && this.d[this.b] != A_0)
					{
						this.d[num++] = this.d[this.b++];
					}
					if (this.d[this.b] == '&')
					{
						this.d[num++] = this.ba();
					}
				}
				this.b++;
				result = num;
			}
			return result;
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x001E78AC File Offset: 0x001E68AC
		private bool f()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '!' && this.d[this.b + 2] == '[' && this.d[this.b + 3] == 'C' && this.d[this.b + 4] == 'D' && this.d[this.b + 5] == 'A' && this.d[this.b + 6] == 'T' && this.d[this.b + 7] == 'A' && this.d[this.b + 8] == '[';
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x001E7974 File Offset: 0x001E6974
		private bool e()
		{
			return this.d[this.b + 1] == '!' && this.d[this.b + 2] == '[' && this.d[this.b + 3] == 'C' && this.d[this.b + 4] == 'D' && this.d[this.b + 5] == 'A' && this.d[this.b + 6] == 'T' && this.d[this.b + 7] == 'A' && this.d[this.b + 8] == '[';
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x001E7A28 File Offset: 0x001E6A28
		private bool d()
		{
			return this.d[this.b] == ']' && this.d[this.b + 1] == ']' && this.d[this.b + 2] == '>';
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x001E7A78 File Offset: 0x001E6A78
		private int c()
		{
			while (this.d[this.b] != '&' && this.d[this.b] != '<')
			{
				this.b++;
			}
			int result;
			if (this.d[this.b] == '<' && !this.e())
			{
				result = this.b;
			}
			else
			{
				int num = this.b;
				if (this.f())
				{
					this.b += 9;
					int num2 = this.b;
					while (!this.d())
					{
						this.b++;
					}
					int num3 = this.b - num2;
					Array.Copy(this.d, num2, this.d, num, num3);
					num += num3;
					this.b += 3;
				}
				else
				{
					this.d[num++] = this.ba();
				}
				while (this.d[this.b] != '<' || this.f())
				{
					if (this.f())
					{
						this.b += 9;
						int num2 = this.b;
						while (!this.d())
						{
							this.b++;
						}
						int num3 = this.b - num2;
						Array.Copy(this.d, num2, this.d, num, num3);
						num += num3;
						this.b += 3;
					}
					while (this.d[this.b] != '&' && this.d[this.b] != '<')
					{
						this.d[num++] = this.d[this.b++];
					}
					if (this.d[this.b] == '&')
					{
						this.d[num++] = this.ba();
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x001E7CB4 File Offset: 0x001E6CB4
		internal char ba()
		{
			this.b++;
			char result;
			if (this.d[this.b] == 'l' && this.d[this.b + 1] == 't' && this.d[this.b + 2] == ';')
			{
				this.b += 3;
				result = '<';
			}
			else if (this.d[this.b] == 'g' && this.d[this.b + 1] == 't' && this.d[this.b + 2] == ';')
			{
				this.b += 3;
				result = '>';
			}
			else if (this.d[this.b] == 'a' && this.d[this.b + 1] == 'm' && this.d[this.b + 2] == 'p' && this.d[this.b + 3] == ';')
			{
				this.b += 4;
				result = '&';
			}
			else if (this.d[this.b] == 'a' && this.d[this.b + 1] == 'p' && this.d[this.b + 2] == 'o' && this.d[this.b + 3] == 's' && this.d[this.b + 4] == ';')
			{
				this.b += 5;
				result = '\'';
			}
			else if (this.d[this.b] == 'q' && this.d[this.b + 1] == 'u' && this.d[this.b + 2] == 'o' && this.d[this.b + 3] == 't' && this.d[this.b + 4] == ';')
			{
				this.b += 5;
				result = '"';
			}
			else
			{
				if (this.d[this.b] != '#')
				{
					throw new DlexParseException("Invalid entity detected.");
				}
				this.b++;
				if (this.d[this.b] == 'x')
				{
					this.b++;
					result = this.a();
				}
				else
				{
					result = this.b();
				}
			}
			return result;
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x001E7F58 File Offset: 0x001E6F58
		private char b()
		{
			int num = 0;
			while (this.d[this.b] != ';')
			{
				if (this.d[this.b] >= '0' && this.d[this.b] <= '9')
				{
					num = num * 10 + (int)(this.d[this.b] - '0');
				}
				this.b++;
			}
			this.b++;
			return (char)num;
		}

		// Token: 0x0600387A RID: 14458 RVA: 0x001E7FE8 File Offset: 0x001E6FE8
		private char a()
		{
			int num = 0;
			while (this.d[this.b] != ';')
			{
				if (this.d[this.b] >= '0' && this.d[this.b] <= '9')
				{
					num = num * 16 + (int)(this.d[this.b] - '0');
				}
				else if (this.d[this.b] >= 'A' && this.d[this.b] <= 'F')
				{
					num = num * 16 + (int)(this.d[this.b] - '7');
				}
				else if (this.d[this.b] >= 'a' && this.d[this.b] <= 'f')
				{
					num = num * 16 + (int)(this.d[this.b] - 'W');
				}
				this.b++;
			}
			this.b++;
			return (char)num;
		}

		// Token: 0x0600387B RID: 14459 RVA: 0x001E8104 File Offset: 0x001E7104
		internal bool bb()
		{
			return this.l;
		}

		// Token: 0x0600387C RID: 14460 RVA: 0x001E811C File Offset: 0x001E711C
		internal void a(bool A_0)
		{
			this.l = A_0;
		}

		// Token: 0x04001AB8 RID: 6840
		private DlexFile a;

		// Token: 0x04001AB9 RID: 6841
		private int b = 0;

		// Token: 0x04001ABA RID: 6842
		private StreamReader c;

		// Token: 0x04001ABB RID: 6843
		private char[] d;

		// Token: 0x04001ABC RID: 6844
		private int e = 0;

		// Token: 0x04001ABD RID: 6845
		private bool f = false;

		// Token: 0x04001ABE RID: 6846
		private bool g = false;

		// Token: 0x04001ABF RID: 6847
		private int h = 0;

		// Token: 0x04001AC0 RID: 6848
		private bool i = true;

		// Token: 0x04001AC1 RID: 6849
		private string j = null;

		// Token: 0x04001AC2 RID: 6850
		private string k = null;

		// Token: 0x04001AC3 RID: 6851
		private bool l = true;
	}
}
