using System;
using System.Threading;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000970 RID: 2416
	public class Symbol : LayoutElement
	{
		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0600625A RID: 25178 RVA: 0x00365FAC File Offset: 0x00364FAC
		// (remove) Token: 0x0600625B RID: 25179 RVA: 0x00365FE8 File Offset: 0x00364FE8
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.n;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.n, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.n;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.n, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600625C RID: 25180 RVA: 0x00366024 File Offset: 0x00365024
		// (remove) Token: 0x0600625D RID: 25181 RVA: 0x00366060 File Offset: 0x00365060
		public event SymbolLaidOutEventHandler LaidOut
		{
			add
			{
				SymbolLaidOutEventHandler symbolLaidOutEventHandler = this.o;
				SymbolLaidOutEventHandler symbolLaidOutEventHandler2;
				do
				{
					symbolLaidOutEventHandler2 = symbolLaidOutEventHandler;
					SymbolLaidOutEventHandler value2 = (SymbolLaidOutEventHandler)Delegate.Combine(symbolLaidOutEventHandler2, value);
					symbolLaidOutEventHandler = Interlocked.CompareExchange<SymbolLaidOutEventHandler>(ref this.o, value2, symbolLaidOutEventHandler2);
				}
				while (symbolLaidOutEventHandler != symbolLaidOutEventHandler2);
			}
			remove
			{
				SymbolLaidOutEventHandler symbolLaidOutEventHandler = this.o;
				SymbolLaidOutEventHandler symbolLaidOutEventHandler2;
				do
				{
					symbolLaidOutEventHandler2 = symbolLaidOutEventHandler;
					SymbolLaidOutEventHandler value2 = (SymbolLaidOutEventHandler)Delegate.Remove(symbolLaidOutEventHandler2, value);
					symbolLaidOutEventHandler = Interlocked.CompareExchange<SymbolLaidOutEventHandler>(ref this.o, value2, symbolLaidOutEventHandler2);
				}
				while (symbolLaidOutEventHandler != symbolLaidOutEventHandler2);
			}
		}

		// Token: 0x0600625E RID: 25182 RVA: 0x0036609C File Offset: 0x0036509C
		internal Symbol(alo A_0, all A_1)
		{
			this.g = A_1.i();
			this.h = A_1.j();
			this.f = A_1.h();
			this.e = A_1.g();
			this.b = A_1.e();
			this.d = A_1.f();
			this.j = A_1.a();
			this.k = A_1.c();
			this.i = A_1.b();
			this.a = A_1.d();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (this.k != null && ((anh)this.k.a()).a())
			{
				A_0.b().m1().a(((anh)this.k.a()).b());
			}
			if (A_0.c())
			{
				this.m = A_0;
				if (A_0 is SubReport && ((anh)this.k.a()).a())
				{
					((anh)this.k.a()).b().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x0600625F RID: 25183 RVA: 0x00366244 File Offset: 0x00365244
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			bool flag = true;
			if (this.n != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.n(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			this.c = this.a();
			am4 am = new am4(this.c, x5.b(this.g), x5.b(this.h), x5.b(this.f), x5.b(this.e), this.a, this.b, TextAlign.Center, this.d, flag);
			am.VAlign = VAlign.Center;
			am.a(this.l);
			A_0.a(am);
			if (this.k != null)
			{
				anh anh = (anh)this.k.a();
				if (anh.a())
				{
					akk a_ = new akk();
					anh.mc(A_1, a_, am);
					if (anh.b().c())
					{
						if (this.m == null)
						{
							throw new LayoutEngineException("Page Aggregate Functions are not allowed in this context.");
						}
						if (anh.b().d() == null)
						{
							((Report)this.m).h().f().a(new aii(am, a_, this.k));
						}
						else
						{
							((SubReport)this.m).h().f().a(new aii(am, a_, this.k));
						}
					}
					else
					{
						A_1.m5().a(new aii(am, a_, this.k));
					}
				}
				else if (!(this.k.b() == ""))
				{
					flag = this.k.a(A_1);
				}
			}
			am.a(flag);
			if (this.o != null)
			{
				SymbolLaidOutEventArgs symbolLaidOutEventArgs = new SymbolLaidOutEventArgs(A_1, am);
				this.o(this, symbolLaidOutEventArgs);
			}
		}

		// Token: 0x06006260 RID: 25184 RVA: 0x00366474 File Offset: 0x00365474
		private char[] a()
		{
			char[] array = new char[1];
			if (this.i == SymbolType.Custom)
			{
				array = this.j.ToCharArray();
			}
			else
			{
				this.a = Font.ZapfDingbats;
				switch (this.i)
				{
				case SymbolType.Check1:
					array[0] = '3';
					return array;
				case SymbolType.Check2:
					array[0] = '4';
					return array;
				case SymbolType.Circle:
					array[0] = 'l';
					return array;
				case SymbolType.Square:
					array[0] = 'n';
					return array;
				case SymbolType.X1:
					array[0] = '5';
					return array;
				case SymbolType.X2:
					array[0] = '6';
					return array;
				case SymbolType.X3:
					array[0] = '7';
					return array;
				case SymbolType.X4:
					array[0] = '8';
					return array;
				}
			}
			return array;
		}

		// Token: 0x06006261 RID: 25185 RVA: 0x00366538 File Offset: 0x00365538
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x06006262 RID: 25186 RVA: 0x0036654C File Offset: 0x0036554C
		internal override short nw()
		{
			return this.l;
		}

		// Token: 0x06006263 RID: 25187 RVA: 0x00366564 File Offset: 0x00365564
		internal override void nx(short A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06006264 RID: 25188 RVA: 0x00366570 File Offset: 0x00365570
		internal override x5 ny()
		{
			return this.h;
		}

		// Token: 0x06006265 RID: 25189 RVA: 0x00366588 File Offset: 0x00365588
		internal override x5 nz()
		{
			return x5.f(this.h, this.e);
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06006266 RID: 25190 RVA: 0x003665AC File Offset: 0x003655AC
		// (set) Token: 0x06006267 RID: 25191 RVA: 0x003665C4 File Offset: 0x003655C4
		public Font Font
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x06006268 RID: 25192 RVA: 0x003665D0 File Offset: 0x003655D0
		// (set) Token: 0x06006269 RID: 25193 RVA: 0x003665E8 File Offset: 0x003655E8
		public string CustomCharacter
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x0600626A RID: 25194 RVA: 0x003665F4 File Offset: 0x003655F4
		// (set) Token: 0x0600626B RID: 25195 RVA: 0x00366611 File Offset: 0x00365611
		public string VisibilityCondition
		{
			get
			{
				return this.k.b();
			}
			set
			{
				this.k = new ahm(value);
			}
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x0600626C RID: 25196 RVA: 0x00366620 File Offset: 0x00365620
		// (set) Token: 0x0600626D RID: 25197 RVA: 0x00366638 File Offset: 0x00365638
		public SymbolType SymbolType
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x0600626E RID: 25198 RVA: 0x00366644 File Offset: 0x00365644
		// (set) Token: 0x0600626F RID: 25199 RVA: 0x0036665C File Offset: 0x0036565C
		public float Size
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06006270 RID: 25200 RVA: 0x00366668 File Offset: 0x00365668
		// (set) Token: 0x06006271 RID: 25201 RVA: 0x00366680 File Offset: 0x00365680
		public Color Color
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06006272 RID: 25202 RVA: 0x0036668C File Offset: 0x0036568C
		// (set) Token: 0x06006273 RID: 25203 RVA: 0x003666AA File Offset: 0x003656AA
		public float Height
		{
			get
			{
				return x5.b(this.e);
			}
			set
			{
				this.e = x5.a(value);
			}
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06006274 RID: 25204 RVA: 0x003666BC File Offset: 0x003656BC
		// (set) Token: 0x06006275 RID: 25205 RVA: 0x003666DA File Offset: 0x003656DA
		public float Width
		{
			get
			{
				return x5.b(this.f);
			}
			set
			{
				this.f = x5.a(value);
			}
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06006276 RID: 25206 RVA: 0x003666EC File Offset: 0x003656EC
		// (set) Token: 0x06006277 RID: 25207 RVA: 0x0036670A File Offset: 0x0036570A
		public float X
		{
			get
			{
				return x5.b(this.g);
			}
			set
			{
				this.g = x5.a(value);
			}
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06006278 RID: 25208 RVA: 0x0036671C File Offset: 0x0036571C
		// (set) Token: 0x06006279 RID: 25209 RVA: 0x0036673A File Offset: 0x0036573A
		public float Y
		{
			get
			{
				return x5.b(this.h);
			}
			set
			{
				this.h = x5.a(value);
			}
		}

		// Token: 0x040032A3 RID: 12963
		private Font a = Font.ZapfDingbats;

		// Token: 0x040032A4 RID: 12964
		private float b = 12f;

		// Token: 0x040032A5 RID: 12965
		private char[] c;

		// Token: 0x040032A6 RID: 12966
		private Color d = Grayscale.Black;

		// Token: 0x040032A7 RID: 12967
		private x5 e;

		// Token: 0x040032A8 RID: 12968
		private x5 f;

		// Token: 0x040032A9 RID: 12969
		private x5 g;

		// Token: 0x040032AA RID: 12970
		private x5 h;

		// Token: 0x040032AB RID: 12971
		private SymbolType i = SymbolType.Check1;

		// Token: 0x040032AC RID: 12972
		private string j = "A";

		// Token: 0x040032AD RID: 12973
		private ahm k;

		// Token: 0x040032AE RID: 12974
		private short l = short.MinValue;

		// Token: 0x040032AF RID: 12975
		private alo m;

		// Token: 0x040032B0 RID: 12976
		private LayingOutEventHandler n;

		// Token: 0x040032B1 RID: 12977
		private SymbolLaidOutEventHandler o;
	}
}
