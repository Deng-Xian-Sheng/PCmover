using System;
using System.Collections.Generic;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020001DE RID: 478
	internal class mc : OperatorWriter
	{
		// Token: 0x0600145B RID: 5211 RVA: 0x000E1F34 File Offset: 0x000E0F34
		internal mc(k0 A_0, PageWriter A_1) : base(A_1.DocumentWriter, A_1.DocumentWriter.v(), new ck(x5.b(A_0.aq()), x5.b(A_0.ar())))
		{
			this.k = A_0;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x000E1FA0 File Offset: 0x000E0FA0
		private new float c()
		{
			return (float)this.g[0].bh();
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x000E1FC4 File Offset: 0x000E0FC4
		private new float a()
		{
			return (float)this.g[0].bi();
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x000E1FE8 File Offset: 0x000E0FE8
		private new n3 a(kz A_0)
		{
			int num = A_0.dg();
			n3 result;
			if (num != 100)
			{
				if (num != 46415)
				{
					mu mu = ((k0)A_0).n().c();
					while (mu != null && mu.a() != null)
					{
						ms ms = mu.a();
						if (ms.l() != null)
						{
							return this.a(ms.l().a().b());
						}
					}
					result = null;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = (n3)A_0;
			}
			return result;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x000E2080 File Offset: 0x000E1080
		private new void a(ms A_0, lk A_1, x5 A_2)
		{
			mr mr = null;
			if (A_0.l() != null)
			{
				mr = A_0.l().a();
			}
			while (mr != null && mr.b() != null)
			{
				this.j = this.a(mr.b());
				if (this.j != null)
				{
					this.h = x5.f(this.h, this.j.an());
					this.g.Add(this.j.j().e());
					float a_ = x5.b(this.j.l());
					this.a(A_1, a_, A_2, this.g[this.g.Count - 1]);
				}
				mr = mr.c();
			}
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x000E2160 File Offset: 0x000E1160
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(mc.f);
			A_0.WriteArrayOpen();
			A_0.WriteNumber1();
			A_0.WriteNumber0();
			A_0.WriteNumber0();
			A_0.WriteNumber1();
			A_0.WriteNumber0();
			A_0.WriteNumber0();
			A_0.WriteArrayClose();
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x000E21B4 File Offset: 0x000E11B4
		private new void a(lk A_0)
		{
			x5 x = x5.c();
			x5 a_ = x5.f(A_0.e().d(), A_0.e().b());
			if (A_0.c() != null)
			{
				if (A_0.c().o() != ft.a)
				{
					x = x5.f(x, A_0.c().n());
				}
				if (A_0.c().s() != ft.a)
				{
					x = x5.f(x, A_0.c().r());
				}
			}
			if (A_0.g())
			{
				x = x5.f(x, A_0.f().d());
			}
			x = x5.f(x, a_);
			float width = x5.b(x5.e(this.k.aq(), x));
			base.Write_q_();
			this.Write_re(x5.b(this.h), 0f, width, x5.b(this.k.ar()));
			base.Write_W();
			base.Write_n();
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x000E22BC File Offset: 0x000E12BC
		private new void a(ms A_0)
		{
			switch (this.k.dz())
			{
			case ko.a:
			case ko.c:
			case ko.d:
			case ko.e:
			{
				x5 x = A_0.r();
				x5 a_ = this.k.aq();
				switch (((n5)this.k.db()).r())
				{
				case gn.b:
					x = x5.e(x5.e(a_, this.k.aa()), x);
					if (x5.c(x, x5.c()))
					{
						this.h = x5.f(this.h, x);
					}
					break;
				case gn.c:
					if (x5.c(a_, x))
					{
						x = x5.e(x5.e(a_, this.k.aa()), x);
						if (x5.c(x, x5.c()))
						{
							x = x5.a(x, 2);
							this.h = x5.f(this.h, x);
						}
					}
					break;
				}
				break;
			}
			}
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x000E23D8 File Offset: 0x000E13D8
		private new void d(float A_0, float A_1, float A_2)
		{
			n5 n = (n5)this.j.db();
			for (int i = 0; i < n.m().Length; i++)
			{
				switch (n.m()[i])
				{
				case gx.b:
					A_1 += A_2 * 0.2f;
					break;
				case gx.c:
					A_1 -= x5.b(this.j.i()) + A_2 * 0.1f;
					break;
				case gx.d:
					A_1 -= x5.b(this.j.i()) / 2.5f;
					A_1 += A_2 * 0.1f;
					break;
				}
				base.SetGraphicsMode();
				base.SetLineWidth(A_2 * 0.05f);
				base.SetLineCap(LineCap.Butt);
				base.SetStrokeColor(n.j());
				this.Write_m_(A_0, A_1);
				this.Write_l_(A_0 + x5.b(this.j.aq()), A_1);
				this.Write_S();
			}
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x000E24E0 File Offset: 0x000E14E0
		private new void a(lk A_0, x5 A_1, x5 A_2)
		{
			this.i = A_2;
			x5 x = x5.e(this.k.aq(), A_1);
			x5 x2 = x5.e(this.k.ar(), A_2);
			x5 x3 = x;
			x5 x4 = x2;
			x5 a_ = x5.c();
			x5 x5 = x5.c();
			switch (this.k.dz())
			{
			case ko.c:
			case ko.d:
			case ko.e:
			{
				lf lf = A_0.c();
				if (A_0.c().bc())
				{
					x3 = x5.e(x3, x5.f(x5.b(lf.n(), 2), x5.b(lf.r(), 2)));
					x4 = x5.e(x4, x5.f(x5.b(lf.f(), 2), x5.b(lf.j(), 2)));
					a_ = x5.f(a_, x5.b(lf.n(), 2));
					x5 = x5.f(x5, x5.b(lf.f(), 2));
				}
				else
				{
					x3 = x5.e(x3, x5.f(lf.n(), lf.r()));
					x4 = x5.e(x4, x5.f(lf.f(), lf.j()));
					a_ = x5.f(a_, lf.n());
					x5 = x5.f(x5, lf.f());
				}
				break;
			}
			}
			switch (this.k.dz())
			{
			case ko.f:
				this.b(x, x2, A_0);
				break;
			case ko.g:
				this.a(x, x2, A_0);
				break;
			default:
			{
				n5 n = (n5)this.k.db();
				if (n.n().a() != null && x5.b(n.n().a().Value) != 0f)
				{
					float num = x5.b(n.n().a().Value) * x5.b(n.a().i());
					float num2 = (num - x5.b(this.k.a7())) / 2f;
					x5 x6 = x5.e(x5.e(x5.f(this.k.a7(), this.k.ab()), A_0.e().a()), A_0.e().c());
					this.a(a_, x5.a(num2), x3, x6, A_0);
					A_0.c().a(this, x5.c(), x5.a(num2), x, x6);
				}
				else
				{
					this.a(a_, x5, x3, x4, A_0);
					A_0.c().a(this, x5.c(), x5.c(), x, x2);
				}
				if (A_0.c().o() != ft.a)
				{
					this.h = x5.f(this.h, A_0.c().n());
				}
				if (A_0.g())
				{
					this.h = x5.f(this.h, A_0.f().d());
				}
				break;
			}
			}
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x000E2820 File Offset: 0x000E1820
		private new void b(x5 A_0, x5 A_1, lk A_2)
		{
			this.a(x5.c(), x5.c(), A_0, A_1, A_2);
			A_2.c().a(this, x5.c(), x5.c(), A_0, A_1);
			if (A_2.c().o() != ft.a)
			{
				this.h = x5.f(this.h, A_2.c().n());
			}
			if (A_2.g())
			{
				this.h = x5.f(this.h, A_2.f().d());
			}
			if (!((mi)this.k.dr()).b())
			{
				A_2.c().c(Color.d("#BFBFBF"));
				A_2.c().d(Color.d("#BFBFBF"));
				A_2.c().a(Color.d("#BFBFBF"));
				A_2.c().b(Color.d("#BFBFBF"));
				A_2.c().c(x5.a(0.3));
				A_2.c().d(x5.a(0.3));
				A_2.c().a(x5.a(0.3));
				A_2.c().b(x5.a(0.3));
				A_2.c().a(this, x5.a(1.1), x5.a(1f), x5.e(A_0, x5.a(2.2)), x5.e(A_1, x5.a(2f)));
			}
			this.h = x5.f(this.h, x5.a(1.3));
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x000E29F8 File Offset: 0x000E19F8
		private new void a(x5 A_0, x5 A_1, lk A_2)
		{
			float a_ = x5.b(A_2.c().n());
			Color a_2 = A_2.c().m();
			float num = x5.b(A_0);
			float a_3 = x5.b(A_1);
			this.a(num, a_3, A_2);
			this.a(num, a_3, a_2, a_);
			Color a_4 = ((n5)this.k.db()).j();
			Color a_5 = Color.d("#BDC2C7");
			if (((mk)this.k.dr()).b())
			{
				a_5 = Color.d("#9B9B9B");
			}
			else if (((mk)this.k.dr()).c())
			{
				if (num > 20f)
				{
					a_5 = Color.d("black");
				}
				else
				{
					a_5 = Color.d("#14405C");
				}
			}
			this.a(num, a_3, a_5, a_, a_4);
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x000E2AF4 File Offset: 0x000E1AF4
		private new void a(float A_0, float A_1, Color A_2, float A_3)
		{
			float num;
			if (A_1 < A_0)
			{
				num = A_1 / 2f;
			}
			else
			{
				num = A_0 / 2f;
			}
			float num2 = A_0 / 2f + x5.b(this.h) + 0.25f;
			float num3 = A_1 / 2f + x5.b(this.i) - 0.25f;
			if (A_1 < 20f)
			{
				base.SetLineWidth(A_3);
				base.SetStrokeColor(A_2);
				this.c(num2, num3, num);
				this.Write_S();
			}
			else
			{
				num -= 0.5f;
				float num4 = A_1 / 20f;
				base.SetLineWidth(num4);
				base.SetStrokeColor(A_2);
				this.b(num2 + num4 / 4f, num3, num);
				this.Write_S();
				base.ResetDimensions();
				base.SetStrokeColor(RgbColor.White);
				this.a(num2, num3 - num4 / 4f, num);
				this.Write_S();
				base.ResetDimensions();
				base.SetStrokeColor(Color.d("#696969"));
				this.b(num2 + num4 / 4f, num3, num - num4);
				this.Write_S();
				base.ResetDimensions();
				base.SetStrokeColor(Color.d("#E3E3E3"));
				this.a(num2, num3 - num4 / 4f, num - num4);
				this.Write_S();
				this.h = x5.f(this.h, x5.a(0.15));
			}
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x000E2C84 File Offset: 0x000E1C84
		private new void a(float A_0, float A_1, Color A_2, float A_3, Color A_4)
		{
			float num;
			if (A_1 < A_0)
			{
				num = A_1 / 3f - 1f;
			}
			else
			{
				num = A_0 / 3f - 1f;
			}
			float a_ = A_0 / 2f + x5.b(this.h) + 0.25f;
			float num2 = A_1 / 2f + x5.b(this.i) - 0.25f;
			base.SetLineWidth(A_3);
			base.SetStrokeColor(A_2);
			this.c(a_, num2, num);
			this.Write_S();
			num2 -= 0.05f;
			num -= 0.2f;
			if (((mk)this.k.dr()).c())
			{
				base.SetFillColor(A_4);
				this.c(a_, num2, num);
			}
			else
			{
				A_4 = Color.d("#D3D7DA");
				base.SetFillColor(A_4);
				this.b(a_, num2, num);
			}
			this.Write_f();
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x000E2D84 File Offset: 0x000E1D84
		private new void c(float A_0, float A_1, float A_2)
		{
			float num = 0.5522848f;
			this.Write_m_(A_0, A_1 - A_2);
			this.Write_c(A_0 + A_2 * num, A_1 - A_2, A_0 + A_2, A_1 - A_2 * num, A_0 + A_2, A_1);
			this.Write_c(A_0 + A_2, A_1 + A_2 * num, A_0 + A_2 * num, A_1 + A_2, A_0, A_1 + A_2);
			this.Write_c(A_0 - A_2 * num, A_1 + A_2, A_0 - A_2, A_1 + A_2 * num, A_0 - A_2, A_1);
			this.Write_c(A_0 - A_2, A_1 - A_2 * num, A_0 - A_2 * num, A_1 - A_2, A_0, A_1 - A_2);
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x000E2E10 File Offset: 0x000E1E10
		private new void b(float A_0, float A_1, float A_2)
		{
			float num = 0.5522848f;
			base.SetDimensionsSimpleRotate(A_0, A_1, 45f);
			this.Write_m_(A_0, A_1 + A_2);
			this.Write_c(A_0 - A_2 * num, A_1 + A_2, A_0 - A_2, A_1 + A_2 * num, A_0 - A_2, A_1);
			this.Write_c(A_0 - A_2, A_1 - A_2 * num, A_0 - A_2 * num, A_1 - A_2, A_0, A_1 - A_2);
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x000E2E74 File Offset: 0x000E1E74
		private new void a(float A_0, float A_1, float A_2)
		{
			float num = 0.5522848f;
			base.SetDimensionsSimpleRotate(A_0, A_1, 45f);
			this.Write_m_(A_0, A_1 - A_2);
			this.Write_c(A_0 + A_2 * num, A_1 - A_2, A_0 + A_2, A_1 - A_2 * num, A_0 + A_2, A_1);
			this.Write_c(A_0 + A_2, A_1 + A_2 * num, A_0 + A_2 * num, A_1 + A_2, A_0, A_1 + A_2);
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x000E2ED8 File Offset: 0x000E1ED8
		private new void a(float A_0, float A_1, lk A_2)
		{
			switch (A_2.az())
			{
			case g9.b:
			case g9.c:
				break;
			default:
				if (A_2.ay().a() != null)
				{
					float a_;
					if (A_1 < A_0)
					{
						a_ = A_1 / 2f;
					}
					else
					{
						a_ = A_0 / 2f;
					}
					float a_2 = A_0 / 2f + x5.b(this.h) + 0.25f;
					float a_3 = A_1 / 2f + x5.b(this.i) - 0.25f;
					base.SetFillColor(A_2.ay().a());
					this.c(a_2, a_3, a_);
					this.Write_f();
				}
				break;
			}
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x000E2FA0 File Offset: 0x000E1FA0
		private new void a(x5 A_0, x5 A_1, x5 A_2, x5 A_3, lk A_4)
		{
			switch (A_4.az())
			{
			case g9.b:
			case g9.c:
				break;
			default:
				A_4.ay().a(this, A_0, A_1, A_2, A_3);
				if (this.k.w() != null)
				{
					this.k.w().a(A_4, this, A_0, A_1, A_2, A_3);
				}
				break;
			}
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x000E300C File Offset: 0x000E200C
		internal new void e()
		{
			lk lk = this.k.c5();
			x5 a_ = x5.f(lk.e().d(), lk.e().b());
			x5 a_2 = x5.f(lk.e().a(), lk.e().c());
			this.a(lk, a_, a_2);
			if (this.k.dz() != ko.g)
			{
				mu mu = this.k.n().c();
				while (mu != null && mu.a() != null)
				{
					ms ms = mu.a();
					if (ms.l() != null)
					{
						ms.b(this.k);
						if (!this.k.b7() && !this.k.c3())
						{
							ms.g(true);
						}
						switch (this.k.c5().az())
						{
						case g9.b:
						case g9.c:
							ms.m(true);
							break;
						default:
							ms.m(false);
							break;
						}
						if (!(ms.l().a().b() is nk))
						{
							this.j = this.a(ms.l().a().b());
							if (this.j != null)
							{
								this.a(ms);
								this.a(ms, lk, a_2);
							}
						}
					}
					mu = mu.b();
				}
			}
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x000E31B4 File Offset: 0x000E21B4
		internal new void a(lk A_0, float A_1, x5 A_2, Font A_3)
		{
			float num = x5.b(this.j.be());
			float characterSpacing = x5.b(this.j.bd());
			float num2 = (float)(A_3.bh() + A_3.bi()) / 2f * (A_1 / 1000f);
			float num3 = x5.b(x5.e(this.k.ar(), A_2));
			this.i = x5.a(num3 / 2f - num2);
			this.a(A_0);
			this.i = x5.f(this.i, A_2);
			base.Write_BT();
			base.SetFont(A_3, A_1);
			base.SetFillColor(((n5)this.j.db()).j());
			base.Write_Td_(x5.b(this.h), x5.b(this.i));
			base.SetCharacterSpacing(characterSpacing);
			if ((double)num != 0.0)
			{
				base.Write_TJ_Open();
				base.Write_TJ(this.j.d(), this.j.h(), this.j.ba(), num, false);
				base.Write_TJ_Close();
			}
			else
			{
				base.Write_SQuote(this.j.d(), this.j.h(), this.j.ba(), false);
			}
			base.Write_ET();
			base.Write_Q();
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x000E3326 File Offset: 0x000E2326
		public override void Write_Do(Resource xObject)
		{
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x000E332C File Offset: 0x000E232C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.f);
			writer.WriteName(mc.a);
			writer.WriteDictionaryOpen();
			writer.WriteName(mc.b);
			writer.WriteArrayOpen();
			writer.WriteName(mc.c);
			writer.WriteName(mc.d);
			writer.WriteArrayClose();
			writer.WriteName(Resource.i);
			writer.WriteDictionaryOpen();
			foreach (Font font in this.g)
			{
				if (font != null)
				{
					writer.WriteName(font.bg());
					font.bj(writer);
				}
			}
			writer.WriteDictionaryClose();
			writer.WriteDictionaryClose();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(mc.e);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			if (this.k.dz() != ko.g)
			{
				writer.WriteNumber(x5.b(this.k.aq()));
				writer.WriteNumber(x5.b(this.k.ar()));
			}
			else
			{
				writer.WriteNumber(x5.b(this.k.dr().aq()));
				writer.WriteNumber(x5.b(this.k.dr().ar()));
			}
			writer.WriteArrayClose();
			if (base.t().o())
			{
				writer.WriteName(Resource.c);
				writer.WriteName(Resource.d);
			}
			writer.WriteName(Resource.e);
			writer.WriteNumber(base.t().s());
			writer.WriteDictionaryClose();
			writer.ac(base.t());
			writer.WriteEndObject();
			base.a(null);
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x000E355C File Offset: 0x000E255C
		public override void Write_Tf(Font font, float fontSize)
		{
			if (font is IFontSubsettable)
			{
				base.DocumentWriter.SetFontSubsetter((IFontSubsettable)font);
			}
			string text = "/" + font.bg();
			byte[] array = new byte[text.Length];
			br br = base.s().b(array.Length + 10);
			Encoding.ASCII.GetBytes(text, 0, text.Length, array, 0);
			br.a(array);
			br.a(32);
			br.c(fontSize);
			br.a(32);
			br.a(84);
			br.a(102);
			br.a(10);
			base.q().Font = font;
			base.q().FontSize = fontSize;
		}

		// Token: 0x040009A9 RID: 2473
		private new static byte[] a = new byte[]
		{
			82,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			115
		};

		// Token: 0x040009AA RID: 2474
		private new static byte[] b = new byte[]
		{
			80,
			114,
			111,
			99,
			83,
			101,
			116
		};

		// Token: 0x040009AB RID: 2475
		private new static byte[] c = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x040009AC RID: 2476
		private new static byte[] d = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x040009AD RID: 2477
		private new static byte[] e = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x040009AE RID: 2478
		private new static byte[] f = new byte[]
		{
			77,
			97,
			116,
			114,
			105,
			120
		};

		// Token: 0x040009AF RID: 2479
		private new List<Font> g = new List<Font>();

		// Token: 0x040009B0 RID: 2480
		private new x5 h = x5.c();

		// Token: 0x040009B1 RID: 2481
		private new x5 i = x5.c();

		// Token: 0x040009B2 RID: 2482
		private n3 j;

		// Token: 0x040009B3 RID: 2483
		private k0 k;
	}
}
