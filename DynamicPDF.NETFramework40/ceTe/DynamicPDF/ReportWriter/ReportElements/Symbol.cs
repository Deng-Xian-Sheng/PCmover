using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000852 RID: 2130
	public class Symbol : ReportElement
	{
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x0600565F RID: 22111 RVA: 0x0029A5B8 File Offset: 0x002995B8
		// (remove) Token: 0x06005660 RID: 22112 RVA: 0x0029A5F4 File Offset: 0x002995F4
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

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06005661 RID: 22113 RVA: 0x0029A630 File Offset: 0x00299630
		// (remove) Token: 0x06005662 RID: 22114 RVA: 0x0029A66C File Offset: 0x0029966C
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

		// Token: 0x06005663 RID: 22115 RVA: 0x0029A6A8 File Offset: 0x002996A8
		internal Symbol(rm A_0, wo A_1)
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
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (this.k != null && ((x4)this.k.a()).a())
			{
				A_0.b().ex().a(((x4)this.k.a()).b());
			}
			if (A_0.c())
			{
				this.m = A_0;
				if (A_0 is SubReport && ((x4)this.k.a()).a())
				{
					((x4)this.k.a()).b().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005664 RID: 22116 RVA: 0x0029A850 File Offset: 0x00299850
		internal override void fi(xf A_0, LayoutWriter A_1)
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
			rz rz = new rz(this.c, x5.b(this.g), x5.b(this.h), x5.b(this.f), x5.b(this.e), this.a, this.b, TextAlign.Center, this.d, flag);
			rz.VAlign = VAlign.Center;
			rz.a(this.l);
			A_0.a(rz);
			if (this.k != null)
			{
				x4 x = (x4)this.k.a();
				if (x.a())
				{
					vi a_ = new vi();
					x.eu(A_1, a_, rz);
					if (x.b().c())
					{
						if (this.m == null)
						{
							throw new ReportWriterException("Page Aggregate Functions are not allowed in this context.");
						}
						if (x.b().d() == null)
						{
							((Report)this.m).f().f().a(new q5(rz, a_, this.k));
						}
						else
						{
							((SubReport)this.m).f().f().a(new q5(rz, a_, this.k));
						}
					}
					else
					{
						A_1.e2().a(new q5(rz, a_, this.k));
					}
				}
				else if (!(this.k.b() == ""))
				{
					flag = this.k.a(A_1);
				}
			}
			rz.a(flag);
			if (this.o != null)
			{
				SymbolLaidOutEventArgs symbolLaidOutEventArgs = new SymbolLaidOutEventArgs(A_1, rz);
				this.o(this, symbolLaidOutEventArgs);
			}
		}

		// Token: 0x06005665 RID: 22117 RVA: 0x0029AA80 File Offset: 0x00299A80
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

		// Token: 0x06005666 RID: 22118 RVA: 0x0029AB44 File Offset: 0x00299B44
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005667 RID: 22119 RVA: 0x0029AB58 File Offset: 0x00299B58
		internal override short gk()
		{
			return this.l;
		}

		// Token: 0x06005668 RID: 22120 RVA: 0x0029AB70 File Offset: 0x00299B70
		internal override void gl(short A_0)
		{
			this.l = A_0;
		}

		// Token: 0x06005669 RID: 22121 RVA: 0x0029AB7C File Offset: 0x00299B7C
		internal override x5 gm()
		{
			return this.h;
		}

		// Token: 0x0600566A RID: 22122 RVA: 0x0029AB94 File Offset: 0x00299B94
		internal override x5 gn()
		{
			return x5.f(this.h, this.e);
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x0600566B RID: 22123 RVA: 0x0029ABB8 File Offset: 0x00299BB8
		// (set) Token: 0x0600566C RID: 22124 RVA: 0x0029ABD0 File Offset: 0x00299BD0
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

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x0600566D RID: 22125 RVA: 0x0029ABDC File Offset: 0x00299BDC
		// (set) Token: 0x0600566E RID: 22126 RVA: 0x0029ABF4 File Offset: 0x00299BF4
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

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x0600566F RID: 22127 RVA: 0x0029AC00 File Offset: 0x00299C00
		// (set) Token: 0x06005670 RID: 22128 RVA: 0x0029AC1D File Offset: 0x00299C1D
		public string VisibilityCondition
		{
			get
			{
				return this.k.b();
			}
			set
			{
				this.k = new sv(value);
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06005671 RID: 22129 RVA: 0x0029AC2C File Offset: 0x00299C2C
		// (set) Token: 0x06005672 RID: 22130 RVA: 0x0029AC44 File Offset: 0x00299C44
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

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06005673 RID: 22131 RVA: 0x0029AC50 File Offset: 0x00299C50
		// (set) Token: 0x06005674 RID: 22132 RVA: 0x0029AC68 File Offset: 0x00299C68
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

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x06005675 RID: 22133 RVA: 0x0029AC74 File Offset: 0x00299C74
		// (set) Token: 0x06005676 RID: 22134 RVA: 0x0029AC8C File Offset: 0x00299C8C
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

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x06005677 RID: 22135 RVA: 0x0029AC98 File Offset: 0x00299C98
		// (set) Token: 0x06005678 RID: 22136 RVA: 0x0029ACB6 File Offset: 0x00299CB6
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

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06005679 RID: 22137 RVA: 0x0029ACC8 File Offset: 0x00299CC8
		// (set) Token: 0x0600567A RID: 22138 RVA: 0x0029ACE6 File Offset: 0x00299CE6
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

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x0600567B RID: 22139 RVA: 0x0029ACF8 File Offset: 0x00299CF8
		// (set) Token: 0x0600567C RID: 22140 RVA: 0x0029AD16 File Offset: 0x00299D16
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

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x0600567D RID: 22141 RVA: 0x0029AD28 File Offset: 0x00299D28
		// (set) Token: 0x0600567E RID: 22142 RVA: 0x0029AD46 File Offset: 0x00299D46
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

		// Token: 0x04002E06 RID: 11782
		private Font a = Font.ZapfDingbats;

		// Token: 0x04002E07 RID: 11783
		private float b = 12f;

		// Token: 0x04002E08 RID: 11784
		private char[] c;

		// Token: 0x04002E09 RID: 11785
		private Color d = Grayscale.Black;

		// Token: 0x04002E0A RID: 11786
		private x5 e;

		// Token: 0x04002E0B RID: 11787
		private x5 f;

		// Token: 0x04002E0C RID: 11788
		private x5 g;

		// Token: 0x04002E0D RID: 11789
		private x5 h;

		// Token: 0x04002E0E RID: 11790
		private SymbolType i = SymbolType.Check1;

		// Token: 0x04002E0F RID: 11791
		private string j = "A";

		// Token: 0x04002E10 RID: 11792
		private sv k;

		// Token: 0x04002E11 RID: 11793
		private short l = short.MinValue;

		// Token: 0x04002E12 RID: 11794
		private rm m;

		// Token: 0x04002E13 RID: 11795
		private LayingOutEventHandler n;

		// Token: 0x04002E14 RID: 11796
		private SymbolLaidOutEventHandler o;
	}
}
