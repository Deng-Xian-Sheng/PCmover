using System;
using System.Collections;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000077 RID: 119
	internal class cm : OperatorWriter
	{
		// Token: 0x060004ED RID: 1261 RVA: 0x000500B0 File Offset: 0x0004F0B0
		internal cm(FormField A_0, float A_1, float A_2, DocumentWriter A_3, zh A_4) : base(A_3, A_4, new ck(A_1, A_2))
		{
			this.n = A_0;
			this.l = A_1;
			this.m = A_2;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00050104 File Offset: 0x0004F104
		internal FormField k()
		{
			return this.n;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0005011C File Offset: 0x0004F11C
		internal new void a(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00050128 File Offset: 0x0004F128
		protected internal int l()
		{
			return this.k;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00050140 File Offset: 0x0004F140
		protected internal new void b(Font A_0)
		{
			this.j = A_0;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0005014C File Offset: 0x0004F14C
		internal Font[] m()
		{
			return this.s;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00050164 File Offset: 0x0004F164
		internal new void a(Font[] A_0)
		{
			this.s = A_0;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00050170 File Offset: 0x0004F170
		public override void Write_Do(Resource xObject)
		{
			if (this.o == null)
			{
				this.o = new PageXObjectList();
			}
			br br = base.s().b(17);
			this.o.Add(xObject, this);
			br.a(32);
			br.a(68);
			br.a(111);
			br.a(10);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000501DC File Offset: 0x0004F1DC
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.f);
			this.a(writer);
			writer.WriteName(cm.a);
			writer.WriteDictionaryOpen();
			if (this.o != null)
			{
				this.o.a(writer);
			}
			if (writer.Document.d().Output != FormOutput.Retain || this.k().Output == FormFieldOutput.Flatten)
			{
				if (this.p != null)
				{
					this.p.b(writer);
				}
				if (this.q != null)
				{
					this.q.b(writer);
				}
				if (this.r != null)
				{
					this.r.b(writer);
				}
			}
			writer.WriteName(cm.b);
			writer.WriteArrayOpen();
			writer.WriteName(cm.c);
			if (this.o != null || this.p != null)
			{
				writer.WriteName(cm.h);
			}
			if (this.i)
			{
				writer.WriteName(cm.d);
				writer.WriteArrayClose();
				writer.WriteName(Resource.i);
				writer.WriteDictionaryOpen();
				if (this.s == null)
				{
					writer.WriteName(this.j.bg());
					this.j.bj(writer);
				}
				else if (writer.Document.d().Output == FormOutput.Retain && this.k().Output != FormFieldOutput.Flatten)
				{
					for (int i = 0; i < this.s.Length; i++)
					{
						if (this.s[i] != null)
						{
							writer.WriteName(this.s[i].bg());
							this.s[i].bj(writer);
						}
					}
				}
				else
				{
					for (int i = 0; i < this.s.Length; i++)
					{
						if (this.s[i] != null)
						{
							writer.WriteName(this.s[i].j());
							this.s[i].bj(writer);
						}
					}
				}
				writer.WriteDictionaryClose();
				writer.WriteDictionaryClose();
			}
			else
			{
				writer.WriteArrayClose();
				writer.WriteDictionaryClose();
			}
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(cm.e);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber(this.l);
			writer.WriteNumber(this.m);
			writer.WriteArrayClose();
			writer.WriteName(cm.f);
			writer.WriteNumber1();
			if (base.t().o())
			{
				writer.WriteName(Resource.c);
				writer.WriteName(Resource.d);
			}
			writer.WriteName(Resource.e);
			writer.ai(base.t().s());
			writer.WriteDictionaryClose();
			writer.ac(base.t());
			writer.WriteEndObject();
			base.a(null);
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00050540 File Offset: 0x0004F540
		public override void Write_Tf(Font font, float fontSize)
		{
			if (font is IFontSubsettable)
			{
				base.DocumentWriter.SetFontSubsetter((IFontSubsettable)font);
			}
			string text = "/" + font.bg();
			byte[] array = new byte[text.Length];
			br br = base.s().b(array.Length + 15);
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

		// Token: 0x060004F7 RID: 1271 RVA: 0x00050614 File Offset: 0x0004F614
		public void n()
		{
			br br = base.s().b(8);
			br.a(47);
			br.a(84);
			br.a(120);
			br.a(32);
			br.a(66);
			br.a(77);
			br.a(67);
			br.a(10);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00050678 File Offset: 0x0004F678
		public void o()
		{
			br br = base.s().b(4);
			br.a(69);
			br.a(77);
			br.a(67);
			br.a(10);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000506B8 File Offset: 0x0004F6B8
		protected internal new void a(BorderStyle A_0)
		{
			this.k = A_0.b();
			if (A_0.b() > 1)
			{
				base.Write_w_((float)A_0.b());
			}
			float a_ = this.l;
			float a_2 = this.m;
			int num = A_0.a();
			switch (num)
			{
			case 66:
				this.Write_g_(new Grayscale(1f));
				this.b(a_, a_2);
				break;
			case 67:
				break;
			case 68:
				base.Write_d(3, 0);
				break;
			default:
				if (num != 73)
				{
					if (num == 85)
					{
						this.a(a_, a_2);
					}
				}
				else
				{
					this.Write_g_(new Grayscale(0.501953f));
					this.b(a_, a_2);
				}
				break;
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00050778 File Offset: 0x0004F778
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteName(cm.g);
			A_0.WriteArrayOpen();
			int num = this.n.Rotate % 360;
			if (num != 90)
			{
				if (num != 180)
				{
					if (num != 270)
					{
						A_0.WriteNumber1();
						A_0.WriteNumber0();
						A_0.WriteNumber0();
						A_0.WriteNumber1();
						A_0.WriteNumber0();
						A_0.WriteNumber0();
					}
					else
					{
						A_0.WriteNumber0();
						A_0.WriteNumberNeg1();
						A_0.WriteNumber1();
						A_0.WriteNumber0();
						A_0.WriteNumber0();
						A_0.WriteNumber(this.l);
					}
				}
				else
				{
					A_0.WriteNumberNeg1();
					A_0.WriteNumber0();
					A_0.WriteNumber0();
					A_0.WriteNumberNeg1();
					A_0.WriteNumber(this.l);
					A_0.WriteNumber(this.m);
				}
			}
			else
			{
				A_0.WriteNumber0();
				A_0.WriteNumber1();
				A_0.WriteNumberNeg1();
				A_0.WriteNumber0();
				A_0.WriteNumber(this.m);
				A_0.WriteNumber0();
			}
			A_0.WriteArrayClose();
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00050898 File Offset: 0x0004F898
		private new void b(float A_0, float A_1)
		{
			float num = (float)this.k().BorderStyle.b();
			this.Write_m_(num, A_1 - num);
			this.Write_l_(num, num);
			this.Write_l_(A_0 - num, num);
			this.Write_l_(A_0 - num * 2f, num * 2f);
			this.Write_l_(num * 2f, num * 2f);
			this.Write_l_(num * 2f, A_1 - num * 2f);
			this.Write_f();
			if (this.k().BackgroundColor != null)
			{
				float a_ = this.k().BackgroundColor.R - 0.25f;
				float a_2 = this.k().BackgroundColor.G - 0.25f;
				float a_3 = this.k().BackgroundColor.B - 0.25f;
				base.e(a_, a_2, a_3);
			}
			else
			{
				this.Write_g_(new Grayscale(0.75293f));
			}
			this.Write_m_(A_0 - num, num);
			this.Write_l_(A_0 - num, A_1 - num);
			this.Write_l_(num, A_1 - num);
			this.Write_l_(num * 2f, A_1 - num * 2f);
			this.Write_l_(A_0 - num * 2f, A_1 - num * 2f);
			this.Write_l_(A_0 - num * 2f, num * 2f);
			this.Write_f();
			num += 2f;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00050A14 File Offset: 0x0004FA14
		private new void a(float A_0, float A_1)
		{
			this.Write_m_(0f, A_1 - 0.5f);
			this.Write_l_(A_0, A_1 - 0.5f);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00050A3C File Offset: 0x0004FA3C
		internal new void a(afj A_0)
		{
			if (A_0 != null)
			{
				abj abj = A_0.g(308085382);
				if (abj == null)
				{
					ab6 ab = A_0.h(308085382);
					if (ab != null)
					{
						abg abg = ab.b().m().b((long)ab.c());
						abj = (abj)abg.h0();
					}
				}
				if (abj != null)
				{
					byte[] a_ = A_0.j4();
					this.a(abj, a_);
					this.c(abj, A_0);
					this.b(abj, A_0);
					this.a(abj, A_0);
				}
			}
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00050AE8 File Offset: 0x0004FAE8
		private new void a(abj A_0, byte[] A_1)
		{
			ArrayList arrayList = new ArrayList();
			abj abj = A_0.g(1768372);
			abk abk = null;
			if (abj == null)
			{
				ab6 ab = A_0.h(1768372);
				if (ab != null)
				{
					abg abg = ab.b().m().b((long)ab.c());
					abj = (abj)abg.h0();
				}
			}
			if (abj != null)
			{
				abk = abj.l();
			}
			while (abk != null)
			{
				if (abk.c().hy() == ag9.j)
				{
					string text = abk.a().j9();
					if (this.a(text, A_1))
					{
						c2 c;
						if (!A_0.k().b().i().TryGetValue(text + ((ab6)abk.c()).c(), out c))
						{
							c = new c2(abk.c());
							c.d(text);
							A_0.k().b().i().Add(text + ((ab6)abk.c()).c(), c);
						}
						arrayList.Add(c);
					}
				}
				abk = abk.d();
			}
			if (arrayList.Count != 0)
			{
				Font[] array = new Font[arrayList.Count];
				int num = 0;
				foreach (object obj in arrayList)
				{
					Font font = (Font)obj;
					array[num] = font;
					num++;
				}
				this.a(true);
				this.a(array);
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00050CF4 File Offset: 0x0004FCF4
		internal void p()
		{
			Font[] array = new Font[1];
			if (this.m() != null)
			{
				array[0] = ((this.m()[1] != null) ? this.m()[1] : ((this.m()[0] != null) ? this.m()[0] : this.n.Font));
			}
			else if (this.n.Font != null)
			{
				array[0] = this.n.Font;
			}
			else
			{
				array[0] = base.Document.d().SubstituteFont;
			}
			array[0].d(array[0].bg());
			this.a(true);
			this.a(array);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00050DAC File Offset: 0x0004FDAC
		private new void c(abj A_0, afj A_1)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			abj abj = A_0.g(276615959);
			abk abk = null;
			if (abj != null)
			{
				abk = abj.l();
			}
			while (abk != null)
			{
				if (abk.c().hy() == ag9.j)
				{
					abg abg = A_1.k().b().m().b((long)((ab6)abk.c()).c());
					if (abg == null)
					{
						continue;
					}
					arrayList.Add(abg);
					arrayList2.Add(abk.a().j9());
				}
				abk = abk.d();
			}
			if (arrayList.Count != 0)
			{
				this.q = new bt(arrayList, arrayList2);
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00050E94 File Offset: 0x0004FE94
		private new void b(abj A_0, afj A_1)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			abj abj = A_0.g(87121142);
			abk abk = null;
			if (abj != null)
			{
				abk = abj.l();
			}
			while (abk != null)
			{
				if (abk.c().hy() == ag9.j)
				{
					abg abg = A_1.k().b().m().b((long)((ab6)abk.c()).c());
					if (abg == null)
					{
						continue;
					}
					arrayList.Add(abg);
					arrayList2.Add(abk.a().j9());
				}
				abk = abk.d();
			}
			if (arrayList.Count != 0)
			{
				this.r = new bu(arrayList, arrayList2);
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00050F7C File Offset: 0x0004FF7C
		private new void a(abj A_0, afj A_1)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			abj abj = A_0.g(406725201);
			abk abk = null;
			if (abj != null)
			{
				abk = abj.l();
			}
			while (abk != null)
			{
				if (abk.c().hy() == ag9.j)
				{
					abg abg = A_1.k().b().m().b((long)((ab6)abk.c()).c());
					if (abg == null)
					{
						continue;
					}
					arrayList.Add(abg);
					arrayList2.Add(abk.a().j9());
				}
				abk = abk.d();
			}
			if (arrayList.Count != 0)
			{
				this.p = new ci(arrayList, arrayList2);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00051064 File Offset: 0x00050064
		private new bool a(string A_0, byte[] A_1)
		{
			A_0 = "/" + A_0 + " ";
			return Encoding.ASCII.GetString(A_1).Contains(A_0);
		}

		// Token: 0x040002E7 RID: 743
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

		// Token: 0x040002E8 RID: 744
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

		// Token: 0x040002E9 RID: 745
		private new static byte[] c = new byte[]
		{
			80,
			68,
			70
		};

		// Token: 0x040002EA RID: 746
		private new static byte[] d = new byte[]
		{
			84,
			101,
			120,
			116
		};

		// Token: 0x040002EB RID: 747
		private new static byte[] e = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x040002EC RID: 748
		private new static byte[] f = new byte[]
		{
			70,
			111,
			114,
			109,
			84,
			121,
			112,
			101
		};

		// Token: 0x040002ED RID: 749
		private new static byte[] g = new byte[]
		{
			77,
			97,
			116,
			114,
			105,
			120
		};

		// Token: 0x040002EE RID: 750
		private new static byte[] h = new byte[]
		{
			73,
			109,
			97,
			103,
			101,
			67,
			47,
			73,
			109,
			97,
			103,
			101,
			73,
			47,
			73,
			109,
			97,
			103,
			101,
			66
		};

		// Token: 0x040002EF RID: 751
		private new bool i;

		// Token: 0x040002F0 RID: 752
		private Font j = null;

		// Token: 0x040002F1 RID: 753
		private int k;

		// Token: 0x040002F2 RID: 754
		protected readonly float l = 0f;

		// Token: 0x040002F3 RID: 755
		protected readonly float m = 0f;

		// Token: 0x040002F4 RID: 756
		private FormField n;

		// Token: 0x040002F5 RID: 757
		private PageXObjectList o;

		// Token: 0x040002F6 RID: 758
		private ci p;

		// Token: 0x040002F7 RID: 759
		private bt q;

		// Token: 0x040002F8 RID: 760
		private bu r;

		// Token: 0x040002F9 RID: 761
		private Font[] s;
	}
}
