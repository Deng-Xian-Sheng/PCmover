using System;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020001DD RID: 477
	internal class mb : OperatorWriter
	{
		// Token: 0x0600144D RID: 5197 RVA: 0x000E1484 File Offset: 0x000E0484
		internal mb(k0 A_0, PageWriter A_1) : base(A_1.DocumentWriter, A_1.DocumentWriter.v(), new ck(x5.b(A_0.aq()), x5.b(A_0.ar())))
		{
			this.k = A_0;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x000E14F8 File Offset: 0x000E04F8
		private new float f()
		{
			return (float)this.g.e().bh();
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x000E151C File Offset: 0x000E051C
		private new float e()
		{
			return (float)this.g.e().bi();
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x000E1540 File Offset: 0x000E0540
		private new void a(x5 A_0)
		{
			x5 a_ = this.k.aq();
			switch (((n5)this.k.db()).r())
			{
			case gn.b:
			{
				x5 x = x5.e(x5.e(a_, this.k.aa()), A_0);
				if (x5.c(x, x5.c()))
				{
					this.i = x5.f(this.i, x);
				}
				break;
			}
			case gn.c:
				if (x5.c(a_, A_0))
				{
					x5 x = x5.e(x5.e(a_, this.k.aa()), A_0);
					if (x5.c(x, x5.c()))
					{
						x = x5.a(x, 2);
						this.i = x5.f(this.i, x);
					}
				}
				break;
			}
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x000E1624 File Offset: 0x000E0624
		private new void a(ms A_0)
		{
			mr mr = A_0.l().a();
			x5 a_ = this.i;
			n3 n = null;
			x5 a_2 = A_0.ag();
			while (mr != null && mr.b() != null)
			{
				switch (mr.b().dg())
				{
				case 100:
					n = (n3)mr.b();
					break;
				case 101:
				case 102:
				{
					nn nn = (nn)mr.b();
					n = nn.a();
					break;
				}
				}
				a_ = x5.f(a_, n.an());
				for (int i = 0; i < n.u().b().Length; i++)
				{
					agd agd = n.u().b()[i];
					if (agd != null)
					{
						l2 l = n.u().c()[i];
						int a_3 = n.u().e()[i];
						int a_4 = n.u().f()[i];
						n5 n2 = (n5)this.k.db();
						if (base.DocumentWriter.ah().ContainsKey(l.d()))
						{
							l = base.DocumentWriter.ah()[l.d()];
						}
						else
						{
							base.DocumentWriter.ah().Add(l.d(), l);
						}
						this.g = l;
						this.h = x5.b(n2.a().i());
						Color fillColor = n2.j();
						float characterSpacing = x5.b(n2.f().Value);
						float a_5 = x5.b(n2.k().Value);
						base.Write_BT();
						base.SetFont(this.g.e(), this.h);
						base.SetFillColor(fillColor);
						base.SetCharacterSpacing(characterSpacing);
						base.Write_Tm(x5.b(a_), x5.b(a_2));
						base.a(agd, a_3, a_4, false, a_5);
					}
				}
				mr = mr.c();
			}
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x000E1876 File Offset: 0x000E0876
		private new void c()
		{
			base.Write_ET();
			base.Write_Q();
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x000E1888 File Offset: 0x000E0888
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(mb.f);
			A_0.WriteArrayOpen();
			A_0.WriteNumber1();
			A_0.WriteNumber0();
			A_0.WriteNumber0();
			A_0.WriteNumber1();
			A_0.WriteNumber0();
			A_0.WriteNumber0();
			A_0.WriteArrayClose();
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x000E18DC File Offset: 0x000E08DC
		private new void a()
		{
			base.Write_q_();
			this.Write_re(x5.b(this.i), x5.b(this.j), x5.b(this.k.c5().am().Value), x5.b(this.k.c5().v().Value));
			base.Write_W();
			base.Write_n();
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x000E195C File Offset: 0x000E095C
		private new void a(lk A_0, x5 A_1, x5 A_2)
		{
			x5 a_ = x5.e(this.k.aq(), A_1);
			x5 a_2 = x5.e(this.k.ar(), A_2);
			this.k.a(this, x5.c(), x5.c(), a_, a_2);
			if (A_0.c().o() != ft.a)
			{
				this.i = x5.f(this.i, A_0.c().n());
			}
			if (A_0.g())
			{
				this.i = x5.f(this.i, A_0.f().d());
			}
			this.j = x5.f(this.j, A_0.f().a());
			if (A_0.d() && A_0.c().g() != ft.a)
			{
				this.j = x5.f(this.j, A_0.c().f());
			}
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x000E1A54 File Offset: 0x000E0A54
		internal new void i()
		{
			lk lk = this.k.c5();
			x5 a_ = x5.f(lk.e().d(), lk.e().b());
			x5 a_2 = x5.f(lk.e().a(), lk.e().c());
			this.a(lk, a_, a_2);
			if (this.k.n() != null)
			{
				mu mu = this.k.n().c();
				if (mu != null)
				{
					if (mu.a().l() != null)
					{
						if (mu.a().l().a().b().dg() == 102)
						{
							mu = mu.b();
						}
					}
				}
				if (mu != null)
				{
					bool a_3 = false;
					if (!this.k.b7() && !this.k.c3())
					{
						a_3 = true;
					}
					this.a();
					x5 x = this.i;
					x5 a_4 = x5.c();
					while (mu != null && mu.a() != null)
					{
						ms ms = mu.a();
						if (ms.l() != null)
						{
							a_4 = ms.n();
							ms ms2 = ms;
							ms2.o(x5.f(ms2.ag(), a_4));
							ms.b(this.k);
							ms.g(a_3);
							this.a(ms.r());
							this.a(ms);
							this.i = x;
						}
						mu = mu.b();
					}
					this.c();
				}
			}
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x000E1C19 File Offset: 0x000E0C19
		public override void Write_Do(Resource xObject)
		{
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x000E1C1C File Offset: 0x000E0C1C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.f);
			writer.WriteName(mb.a);
			writer.WriteDictionaryOpen();
			writer.WriteName(mb.b);
			writer.WriteArrayOpen();
			writer.WriteName(mb.c);
			writer.WriteName(mb.d);
			writer.WriteArrayClose();
			if (this.g != null)
			{
				writer.WriteName(Resource.i);
				writer.WriteDictionaryOpen();
				writer.WriteName(this.g.e().bg());
				this.g.e().bj(writer);
				writer.WriteDictionaryClose();
			}
			writer.WriteDictionaryClose();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(mb.e);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber(x5.b(this.k.aq()));
			writer.WriteNumber(x5.b(this.k.ar()));
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

		// Token: 0x06001459 RID: 5209 RVA: 0x000E1DCC File Offset: 0x000E0DCC
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

		// Token: 0x0400099E RID: 2462
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

		// Token: 0x0400099F RID: 2463
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

		// Token: 0x040009A0 RID: 2464
		private new static byte[] c = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x040009A1 RID: 2465
		private new static byte[] d = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x040009A2 RID: 2466
		private new static byte[] e = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x040009A3 RID: 2467
		private new static byte[] f = new byte[]
		{
			77,
			97,
			116,
			114,
			105,
			120
		};

		// Token: 0x040009A4 RID: 2468
		private new l2 g = null;

		// Token: 0x040009A5 RID: 2469
		private new float h = 0f;

		// Token: 0x040009A6 RID: 2470
		private new x5 i = x5.c();

		// Token: 0x040009A7 RID: 2471
		private x5 j = x5.c();

		// Token: 0x040009A8 RID: 2472
		private k0 k;
	}
}
