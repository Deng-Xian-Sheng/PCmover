using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000354 RID: 852
	internal class wd
	{
		// Token: 0x06002444 RID: 9284 RVA: 0x001556EC File Offset: 0x001546EC
		internal wd(Stream A_0, DplxFile A_1)
		{
			this.a = A_1;
			this.d = new char[A_0.Length];
			this.c = new StreamReader(A_0, Encoding.UTF8);
			this.c.ReadBlock(this.d, 0, this.d.Length);
			this.a9();
			this.ab();
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x00155794 File Offset: 0x00154794
		internal wd(byte[] A_0, DplxFile A_1)
		{
			this.a = A_1;
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			this.d = utf8Encoding.GetChars(A_0);
			A_0 = null;
			this.a9();
			this.ab();
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x00155814 File Offset: 0x00154814
		internal DplxFile t()
		{
			return this.a;
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x0015582C File Offset: 0x0015482C
		internal int u()
		{
			return this.h;
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x00155844 File Offset: 0x00154844
		internal string v()
		{
			return this.j;
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x0015585C File Offset: 0x0015485C
		internal void a(string A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x00155868 File Offset: 0x00154868
		internal string w()
		{
			return this.k;
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x00155880 File Offset: 0x00154880
		internal void b(string A_0)
		{
			this.k = A_0;
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x0015588C File Offset: 0x0015488C
		internal int x()
		{
			return this.e;
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001558A4 File Offset: 0x001548A4
		internal bool y()
		{
			return this.f;
		}

		// Token: 0x0600244E RID: 9294 RVA: 0x001558BC File Offset: 0x001548BC
		internal bool z()
		{
			return this.g;
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001558D4 File Offset: 0x001548D4
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
						this.a9();
					}
				}
			}
			else
			{
				this.ab();
			}
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x00155988 File Offset: 0x00154988
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
				this.a9();
				this.f = true;
				if (this.r(this.d[this.b]))
				{
					this.i();
				}
			}
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x00155A40 File Offset: 0x00154A40
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
			this.a9();
			this.aa();
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x00155B0C File Offset: 0x00154B0C
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002453 RID: 9299 RVA: 0x00155BF4 File Offset: 0x00154BF4
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x00155CDC File Offset: 0x00154CDC
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x00155DC4 File Offset: 0x00154DC4
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x00155EAC File Offset: 0x00154EAC
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x00155F94 File Offset: 0x00154F94
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x0015607C File Offset: 0x0015507C
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00156164 File Offset: 0x00155164
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x0015624C File Offset: 0x0015524C
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x00156334 File Offset: 0x00155334
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x0015641C File Offset: 0x0015541C
		internal Font an()
		{
			string text = this.a8();
			Font font = this.a.b()[text];
			if (font == null)
			{
				throw new DplxParseException("Invalid font name specified. " + text + " is an invalid name.");
			}
			return font;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x0015646C File Offset: 0x0015546C
		internal FontFamily ao()
		{
			string text = this.a8();
			FontFamily fontFamily = this.a.c()[text];
			if (fontFamily == null)
			{
				throw new DplxParseException("Invalid font family name specified. " + text + " is an invalid name.");
			}
			return fontFamily;
		}

		// Token: 0x0600245E RID: 9310 RVA: 0x001564BC File Offset: 0x001554BC
		internal FontFamilyList ap()
		{
			return this.a.c();
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x001564DC File Offset: 0x001554DC
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001565C4 File Offset: 0x001555C4
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
				this.a9();
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
				this.a9();
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

		// Token: 0x06002461 RID: 9313 RVA: 0x00156758 File Offset: 0x00155758
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
			this.a9();
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

		// Token: 0x06002462 RID: 9314 RVA: 0x00156838 File Offset: 0x00155838
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
			this.a9();
			this.aa();
			if (num > 255)
			{
				throw new DplxParseException("Invalid unsignedByte value. The value is greater than 255.");
			}
			return (byte)num;
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x001568F4 File Offset: 0x001558F4
		private bool s()
		{
			return this.d[this.b] >= '0' && this.d[this.b] <= '9';
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x00156930 File Offset: 0x00155930
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x00156A18 File Offset: 0x00155A18
		internal bool av()
		{
			bool result = true;
			if (this.d[this.b] == '"')
			{
				this.b++;
				this.a9();
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
				this.a9();
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x00156B34 File Offset: 0x00155B34
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
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x00156C1C File Offset: 0x00155C1C
		internal tu ax()
		{
			this.i = false;
			this.r();
			tu result;
			if (!this.g)
			{
				int a_ = this.b;
				int a_2 = this.c();
				tu tu = new tu(this, this.d, a_, a_2);
				this.i = true;
				this.aa();
				this.aa();
				result = tu;
			}
			else
			{
				this.i = true;
				this.a9();
				result = null;
			}
			return result;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x00156C90 File Offset: 0x00155C90
		internal bool ay()
		{
			return this.d[this.b + 1] == '#';
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x00156CB8 File Offset: 0x00155CB8
		internal w6 az()
		{
			w6 result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = w6.a(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = w6.a(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600246A RID: 9322 RVA: 0x00156D70 File Offset: 0x00155D70
		internal vk a0()
		{
			vk result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				this.a9();
				int num = this.b;
				int num2 = this.a('"');
				if (num == num2)
				{
					num--;
				}
				result = new vk(this, this.d, num, num2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int num = this.b;
				int num2 = this.a('"');
				result = new vk(this, this.d, num, num2);
			}
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600246B RID: 9323 RVA: 0x00156E44 File Offset: 0x00155E44
		internal vd a1()
		{
			vd result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new vd(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new vd(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x00156EFC File Offset: 0x00155EFC
		internal sv a2()
		{
			sv result = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new sv(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				result = new sv(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x00156FB4 File Offset: 0x00155FB4
		internal vd a3()
		{
			vd result = null;
			if (this.d[this.b] == '"')
			{
				this.b += 2;
				int a_ = this.b;
				int a_2 = this.a('"') - 1;
				result = new vd(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b += 2;
				int a_ = this.b;
				int a_2 = this.a('"') - 1;
				result = new vd(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return result;
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x00157070 File Offset: 0x00156070
		internal string a4()
		{
			ts ts = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				ts = new ts(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				ts = new ts(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return ts.b();
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x0015712C File Offset: 0x0015612C
		internal string a5()
		{
			tt tt = null;
			if (this.d[this.b] == '"')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				tt = new tt(this.d, a_, a_2);
			}
			else if (this.d[this.b] == '\'')
			{
				this.b++;
				int a_ = this.b;
				int a_2 = this.a('"');
				tt = new tt(this.d, a_, a_2);
			}
			this.a9();
			this.aa();
			return tt.b();
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x001571E8 File Offset: 0x001561E8
		internal string a6()
		{
			string text = this.a8();
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

		// Token: 0x06002471 RID: 9329 RVA: 0x00157224 File Offset: 0x00156224
		internal string a7()
		{
			string text = this.a8();
			if (text == null || text == string.Empty)
			{
				throw new DplxParseException("Image path not specified.");
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

		// Token: 0x06002472 RID: 9330 RVA: 0x00157284 File Offset: 0x00156284
		internal string a8()
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
			this.a9();
			this.aa();
			return text;
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x00157404 File Offset: 0x00156404
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

		// Token: 0x06002474 RID: 9332 RVA: 0x00157710 File Offset: 0x00156710
		private void r()
		{
			while (this.f)
			{
				this.aa();
			}
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x00157734 File Offset: 0x00156734
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

		// Token: 0x06002476 RID: 9334 RVA: 0x0015777C File Offset: 0x0015677C
		private void p()
		{
			this.b += 2;
			while (this.d[this.b] != '?' && this.d[this.b + 1] != '>')
			{
				this.b++;
			}
			this.b += 2;
			this.a9();
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x001577EC File Offset: 0x001567EC
		private void o()
		{
			this.b += 4;
			while (this.d[this.b] != '-' || this.d[this.b + 1] != '-' || this.d[this.b + 2] != '>')
			{
				this.b++;
			}
			this.b += 3;
			this.a9();
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x00157870 File Offset: 0x00156870
		private bool n()
		{
			return this.d[this.b] == '<' && (this.r(this.d[this.b + 1]) || (this.d[this.b + 1] == '/' && this.r(this.d[this.b + 2])));
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001578E0 File Offset: 0x001568E0
		private bool r(char A_0)
		{
			return (A_0 >= 'a' && A_0 <= 'z') || (A_0 >= 'A' && A_0 <= 'Z') || A_0 == ':' || A_0 == '_';
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x00157914 File Offset: 0x00156914
		private bool m()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '?';
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x00157950 File Offset: 0x00156950
		private bool l()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '!' && this.d[this.b + 2] == '-' && this.d[this.b + 3] == '-';
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001579B0 File Offset: 0x001569B0
		internal void a9()
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

		// Token: 0x0600247D RID: 9341 RVA: 0x00157A04 File Offset: 0x00156A04
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

		// Token: 0x0600247E RID: 9342 RVA: 0x00157A8C File Offset: 0x00156A8C
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

		// Token: 0x0600247F RID: 9343 RVA: 0x00157B3C File Offset: 0x00156B3C
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
			this.a9();
			this.b++;
			this.a9();
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x00157BF8 File Offset: 0x00156BF8
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

		// Token: 0x06002481 RID: 9345 RVA: 0x00157C80 File Offset: 0x00156C80
		private LineStyle p(char A_0)
		{
			LineStyle result;
			if (this.d[this.b] == '[')
			{
				this.b++;
				ArrayList arrayList = new ArrayList(2);
				while (this.d[this.b] != ']')
				{
					arrayList.Add(this.ba());
					if (this.d[this.b] == ',')
					{
						this.b++;
					}
				}
				if (this.s())
				{
					result = new LineStyle((float[])arrayList.ToArray(typeof(float)), this.ba());
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

		// Token: 0x06002482 RID: 9346 RVA: 0x00157D6C File Offset: 0x00156D6C
		internal float ba()
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

		// Token: 0x06002483 RID: 9347 RVA: 0x00157E60 File Offset: 0x00156E60
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

		// Token: 0x06002484 RID: 9348 RVA: 0x001580A0 File Offset: 0x001570A0
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

		// Token: 0x06002485 RID: 9349 RVA: 0x001581A4 File Offset: 0x001571A4
		private byte g()
		{
			return (byte)(wd.n(this.d[this.b++]) << 4 | wd.n(this.d[this.b++]));
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x001581F4 File Offset: 0x001571F4
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

		// Token: 0x06002487 RID: 9351 RVA: 0x0015822C File Offset: 0x0015722C
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
			throw new DplxParseException("Invalid named color attribute value specified.");
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001591D0 File Offset: 0x001581D0
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
			throw new DplxParseException("Invalid lineStyle attribute value specified.");
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x00159250 File Offset: 0x00158250
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
						throw new DplxParseException("Invalid leadingType attribute value specified.");
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

		// Token: 0x0600248A RID: 9354 RVA: 0x00159298 File Offset: 0x00158298
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
						throw new DplxParseException("Invalid align lineCap value specified.");
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

		// Token: 0x0600248B RID: 9355 RVA: 0x001592E0 File Offset: 0x001582E0
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
			throw new DplxParseException("Invalid textAlign attribute value specified.");
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x0015937C File Offset: 0x0015837C
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
			throw new DplxParseException("Invalid textAlign attribute value specified.");
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001593E8 File Offset: 0x001583E8
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
			throw new DplxParseException("Invalid parameterType attribute value specified.");
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x0015991C File Offset: 0x0015891C
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
			throw new DplxParseException("Invalid parameterDirection attribute value specified.");
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x0015997C File Offset: 0x0015897C
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
						throw new DplxParseException("Invalid alternateRow attribute value specified.");
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

		// Token: 0x06002490 RID: 9360 RVA: 0x001599C4 File Offset: 0x001589C4
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
			throw new DplxParseException("Invalid providerType attribute value specified.");
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x00159A24 File Offset: 0x00158A24
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
						throw new DplxParseException("Invalid vAlign attribute value specified.");
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

		// Token: 0x06002492 RID: 9362 RVA: 0x00159A6C File Offset: 0x00158A6C
		private PageOrientation b(char A_0)
		{
			int num = this.q(A_0);
			PageOrientation result;
			if (num != 738784534)
			{
				if (num != 817706822)
				{
					throw new DplxParseException("Invalid pageOrientation attribute value specified.");
				}
				result = PageOrientation.Portrait;
			}
			else
			{
				result = PageOrientation.Landscape;
			}
			return result;
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x00159AA8 File Offset: 0x00158AA8
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
				this.d[num++] = this.bb();
				while (this.d[this.b] != A_0)
				{
					while (this.d[this.b] != '&' && this.d[this.b] != A_0)
					{
						this.d[num++] = this.d[this.b++];
					}
					if (this.d[this.b] == '&')
					{
						this.d[num++] = this.bb();
					}
				}
				this.b++;
				result = num;
			}
			return result;
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x00159BF0 File Offset: 0x00158BF0
		private bool f()
		{
			return this.d[this.b] == '<' && this.d[this.b + 1] == '!' && this.d[this.b + 2] == '[' && this.d[this.b + 3] == 'C' && this.d[this.b + 4] == 'D' && this.d[this.b + 5] == 'A' && this.d[this.b + 6] == 'T' && this.d[this.b + 7] == 'A' && this.d[this.b + 8] == '[';
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x00159CB8 File Offset: 0x00158CB8
		private bool e()
		{
			return this.d[this.b + 1] == '!' && this.d[this.b + 2] == '[' && this.d[this.b + 3] == 'C' && this.d[this.b + 4] == 'D' && this.d[this.b + 5] == 'A' && this.d[this.b + 6] == 'T' && this.d[this.b + 7] == 'A' && this.d[this.b + 8] == '[';
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x00159D6C File Offset: 0x00158D6C
		private bool d()
		{
			return this.d[this.b] == ']' && this.d[this.b + 1] == ']' && this.d[this.b + 2] == '>';
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x00159DBC File Offset: 0x00158DBC
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
					this.d[num++] = this.bb();
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
						this.d[num++] = this.bb();
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x00159FF8 File Offset: 0x00158FF8
		internal char bb()
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
					throw new DplxParseException("Invalid entity detected.");
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

		// Token: 0x06002499 RID: 9369 RVA: 0x0015A29C File Offset: 0x0015929C
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

		// Token: 0x0600249A RID: 9370 RVA: 0x0015A32C File Offset: 0x0015932C
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

		// Token: 0x0600249B RID: 9371 RVA: 0x0015A448 File Offset: 0x00159448
		internal bool bc()
		{
			return this.l;
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x0015A460 File Offset: 0x00159460
		internal void a(bool A_0)
		{
			this.l = A_0;
		}

		// Token: 0x04000FC6 RID: 4038
		private DplxFile a;

		// Token: 0x04000FC7 RID: 4039
		private int b = 0;

		// Token: 0x04000FC8 RID: 4040
		private StreamReader c;

		// Token: 0x04000FC9 RID: 4041
		private char[] d;

		// Token: 0x04000FCA RID: 4042
		private int e = 0;

		// Token: 0x04000FCB RID: 4043
		private bool f = false;

		// Token: 0x04000FCC RID: 4044
		private bool g = false;

		// Token: 0x04000FCD RID: 4045
		private int h = 0;

		// Token: 0x04000FCE RID: 4046
		private bool i = true;

		// Token: 0x04000FCF RID: 4047
		private string j = null;

		// Token: 0x04000FD0 RID: 4048
		private string k = null;

		// Token: 0x04000FD1 RID: 4049
		private bool l = true;
	}
}
