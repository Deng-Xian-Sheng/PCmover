using System;
using System.Threading;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200096C RID: 2412
	public class RecordBox : LayoutElement
	{
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060061C1 RID: 25025 RVA: 0x00364090 File Offset: 0x00363090
		// (remove) Token: 0x060061C2 RID: 25026 RVA: 0x003640CC File Offset: 0x003630CC
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.z;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.z, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.z;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.z, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060061C3 RID: 25027 RVA: 0x00364108 File Offset: 0x00363108
		// (remove) Token: 0x060061C4 RID: 25028 RVA: 0x00364144 File Offset: 0x00363144
		public event RecordBoxLaidOutEventHandler LaidOut
		{
			add
			{
				RecordBoxLaidOutEventHandler recordBoxLaidOutEventHandler = this.aa;
				RecordBoxLaidOutEventHandler recordBoxLaidOutEventHandler2;
				do
				{
					recordBoxLaidOutEventHandler2 = recordBoxLaidOutEventHandler;
					RecordBoxLaidOutEventHandler value2 = (RecordBoxLaidOutEventHandler)Delegate.Combine(recordBoxLaidOutEventHandler2, value);
					recordBoxLaidOutEventHandler = Interlocked.CompareExchange<RecordBoxLaidOutEventHandler>(ref this.aa, value2, recordBoxLaidOutEventHandler2);
				}
				while (recordBoxLaidOutEventHandler != recordBoxLaidOutEventHandler2);
			}
			remove
			{
				RecordBoxLaidOutEventHandler recordBoxLaidOutEventHandler = this.aa;
				RecordBoxLaidOutEventHandler recordBoxLaidOutEventHandler2;
				do
				{
					recordBoxLaidOutEventHandler2 = recordBoxLaidOutEventHandler;
					RecordBoxLaidOutEventHandler value2 = (RecordBoxLaidOutEventHandler)Delegate.Remove(recordBoxLaidOutEventHandler2, value);
					recordBoxLaidOutEventHandler = Interlocked.CompareExchange<RecordBoxLaidOutEventHandler>(ref this.aa, value2, recordBoxLaidOutEventHandler2);
				}
				while (recordBoxLaidOutEventHandler != recordBoxLaidOutEventHandler2);
			}
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060061C5 RID: 25029 RVA: 0x00364180 File Offset: 0x00363180
		// (remove) Token: 0x060061C6 RID: 25030 RVA: 0x003641BC File Offset: 0x003631BC
		public event TextSettingEventHandler TextSetting
		{
			add
			{
				TextSettingEventHandler textSettingEventHandler = this.ab;
				TextSettingEventHandler textSettingEventHandler2;
				do
				{
					textSettingEventHandler2 = textSettingEventHandler;
					TextSettingEventHandler value2 = (TextSettingEventHandler)Delegate.Combine(textSettingEventHandler2, value);
					textSettingEventHandler = Interlocked.CompareExchange<TextSettingEventHandler>(ref this.ab, value2, textSettingEventHandler2);
				}
				while (textSettingEventHandler != textSettingEventHandler2);
			}
			remove
			{
				TextSettingEventHandler textSettingEventHandler = this.ab;
				TextSettingEventHandler textSettingEventHandler2;
				do
				{
					textSettingEventHandler2 = textSettingEventHandler;
					TextSettingEventHandler value2 = (TextSettingEventHandler)Delegate.Remove(textSettingEventHandler2, value);
					textSettingEventHandler = Interlocked.CompareExchange<TextSettingEventHandler>(ref this.ab, value2, textSettingEventHandler2);
				}
				while (textSettingEventHandler != textSettingEventHandler2);
			}
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060061C7 RID: 25031 RVA: 0x003641F8 File Offset: 0x003631F8
		// (remove) Token: 0x060061C8 RID: 25032 RVA: 0x00364234 File Offset: 0x00363234
		public event TextSetEventHandler TextSet
		{
			add
			{
				TextSetEventHandler textSetEventHandler = this.ac;
				TextSetEventHandler textSetEventHandler2;
				do
				{
					textSetEventHandler2 = textSetEventHandler;
					TextSetEventHandler value2 = (TextSetEventHandler)Delegate.Combine(textSetEventHandler2, value);
					textSetEventHandler = Interlocked.CompareExchange<TextSetEventHandler>(ref this.ac, value2, textSetEventHandler2);
				}
				while (textSetEventHandler != textSetEventHandler2);
			}
			remove
			{
				TextSetEventHandler textSetEventHandler = this.ac;
				TextSetEventHandler textSetEventHandler2;
				do
				{
					textSetEventHandler2 = textSetEventHandler;
					TextSetEventHandler value2 = (TextSetEventHandler)Delegate.Remove(textSetEventHandler2, value);
					textSetEventHandler = Interlocked.CompareExchange<TextSetEventHandler>(ref this.ac, value2, textSetEventHandler2);
				}
				while (textSetEventHandler != textSetEventHandler2);
			}
		}

		// Token: 0x060061C9 RID: 25033 RVA: 0x00364270 File Offset: 0x00363270
		internal RecordBox(alo A_0, alf A_1)
		{
			this.a = A_1.a();
			this.b = A_1.c();
			this.c = A_1.d();
			this.d = A_1.f();
			this.e = A_1.l();
			this.f = A_1.g();
			this.g = A_1.h();
			this.h = A_1.i();
			this.i = A_1.j();
			this.j = A_1.k();
			this.k = A_1.m();
			this.n = A_1.n();
			this.o = A_1.o();
			this.p = A_1.p();
			this.q = A_1.e();
			this.r = A_1.b();
			this.u = A_1.s();
			this.v = A_1.t();
			this.t = A_1.r();
			this.s = A_1.q();
			if (this.q.c())
			{
				A_0.b().m1().a(this.q.d());
			}
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			this.y = A_0;
			if (A_0.c())
			{
				if (A_0 is SubReport && this.q.c())
				{
					this.q.d().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x060061CA RID: 25034 RVA: 0x00364434 File Offset: 0x00363434
		internal override void nu(aml A_0, LayoutWriter A_1)
		{
			if (this.z != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.z(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			LayoutTextArea layoutTextArea;
			if (this.q.c())
			{
				layoutTextArea = new am9(this, string.Empty);
				A_0.a(layoutTextArea);
				if (this.d)
				{
					A_0.a().a(layoutTextArea);
				}
				IFormatProvider formatProvider = this.x;
				if (formatProvider == null)
				{
					formatProvider = A_1.DocumentLayout.FormatProvider;
				}
				akk akk = new akk();
				this.q.a().mc(A_1, akk, layoutTextArea);
				if (this.q.d().c())
				{
					if (this.q.d().d() == null)
					{
						((Report)this.y).h().f().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
					}
					else
					{
						((SubReport)this.y).h().f().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
					}
				}
				else if (this.y is FixedPage)
				{
					((FixedPage)this.y).g().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
				}
				else
				{
					((al2)A_1).m5().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
				}
				akk.a();
			}
			else
			{
				object obj = this.q.a().ma(A_1);
				if (obj == null)
				{
					return;
				}
				string text;
				if (this.p != null && this.p.Length > 0)
				{
					if (obj is IFormattable)
					{
						IFormattable formattable = (IFormattable)obj;
						if (this.x == null)
						{
							text = formattable.ToString(this.p, A_1.DocumentLayout.FormatProvider);
						}
						else
						{
							text = formattable.ToString(this.p, this.x);
						}
					}
					else
					{
						text = obj.ToString();
					}
				}
				else
				{
					text = obj.ToString();
				}
				if (this.ab != null)
				{
					TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(text);
					this.ab(this, textSettingEventArgs);
					text = textSettingEventArgs.Text;
				}
				layoutTextArea = new am9(this, text);
				if (this.ac != null)
				{
					TextSetEventArgs textSetEventArgs = new TextSetEventArgs(text, layoutTextArea);
					this.ac(this, textSetEventArgs);
				}
				A_0.a(layoutTextArea);
				if (this.d)
				{
					A_0.a().a(layoutTextArea);
				}
			}
			if (this.aa != null)
			{
				RecordBoxLaidOutEventArgs recordBoxLaidOutEventArgs = new RecordBoxLaidOutEventArgs(A_1, layoutTextArea);
				this.aa(this, recordBoxLaidOutEventArgs);
			}
		}

		// Token: 0x060061CB RID: 25035 RVA: 0x00364798 File Offset: 0x00363798
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.z != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.z(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			LayoutTextArea layoutTextArea;
			if (this.q.c())
			{
				layoutTextArea = new am9(this, string.Empty);
				A_0.a(layoutTextArea);
				IFormatProvider formatProvider = this.x;
				if (formatProvider == null)
				{
					formatProvider = A_1.DocumentLayout.FormatProvider;
				}
				akk akk = new akk();
				this.q.a().mc(A_1, akk, layoutTextArea);
				if (this.q.d().c())
				{
					if (this.q.d().d() == null)
					{
						((Report)this.y).h().f().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
					}
					else
					{
						((SubReport)this.y).h().f().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
					}
				}
				else if (this.y is FixedPage)
				{
					((FixedPage)this.y).g().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
				}
				else
				{
					((al2)A_1).m5().a(new ako(layoutTextArea, akk, this.q, formatProvider, this.p));
				}
				akk.a();
			}
			else
			{
				object obj = this.q.a().ma(A_1);
				if (obj == null)
				{
					return;
				}
				string text;
				if (this.p != null && this.p.Length > 0)
				{
					if (obj is IFormattable)
					{
						IFormattable formattable = (IFormattable)obj;
						if (this.x == null)
						{
							text = formattable.ToString(this.p, A_1.DocumentLayout.FormatProvider);
						}
						else
						{
							text = formattable.ToString(this.p, this.x);
						}
					}
					else
					{
						text = obj.ToString();
					}
				}
				else
				{
					text = obj.ToString();
				}
				if (this.ab != null)
				{
					TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(text);
					this.ab(this, textSettingEventArgs);
					text = textSettingEventArgs.Text;
				}
				layoutTextArea = new am9(this, text);
				if (this.ac != null)
				{
					TextSetEventArgs textSetEventArgs = new TextSetEventArgs(text, layoutTextArea);
					this.ac(this, textSetEventArgs);
				}
				A_0.a(layoutTextArea);
			}
			if (this.aa != null)
			{
				RecordBoxLaidOutEventArgs recordBoxLaidOutEventArgs = new RecordBoxLaidOutEventArgs(A_1, layoutTextArea);
				this.aa(this, recordBoxLaidOutEventArgs);
			}
		}

		// Token: 0x060061CC RID: 25036 RVA: 0x00364AC0 File Offset: 0x00363AC0
		internal char[] a(char[] A_0)
		{
			char[] result;
			if (this.ab == null)
			{
				result = A_0;
			}
			else
			{
				TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(new string(A_0));
				this.ab(this, textSettingEventArgs);
				result = textSettingEventArgs.Text.ToCharArray();
			}
			return result;
		}

		// Token: 0x060061CD RID: 25037 RVA: 0x00364B0C File Offset: 0x00363B0C
		internal void a(char[] A_0, LayoutTextArea A_1)
		{
			if (this.ac != null)
			{
				TextSetEventArgs textSetEventArgs = new TextSetEventArgs(new string(A_0), A_1);
				this.ac(this, textSetEventArgs);
			}
		}

		// Token: 0x060061CE RID: 25038 RVA: 0x00364B44 File Offset: 0x00363B44
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x060061CF RID: 25039 RVA: 0x00364B58 File Offset: 0x00363B58
		internal override short nw()
		{
			return this.w;
		}

		// Token: 0x060061D0 RID: 25040 RVA: 0x00364B70 File Offset: 0x00363B70
		internal override void nx(short A_0)
		{
			this.w = A_0;
		}

		// Token: 0x060061D1 RID: 25041 RVA: 0x00364B7C File Offset: 0x00363B7C
		internal override x5 ny()
		{
			return this.v;
		}

		// Token: 0x060061D2 RID: 25042 RVA: 0x00364B94 File Offset: 0x00363B94
		internal override x5 nz()
		{
			return x5.f(this.v, this.s);
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x060061D3 RID: 25043 RVA: 0x00364BB8 File Offset: 0x00363BB8
		// (set) Token: 0x060061D4 RID: 25044 RVA: 0x00364BD0 File Offset: 0x00363BD0
		public TextAlign Align
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

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x060061D5 RID: 25045 RVA: 0x00364BDC File Offset: 0x00363BDC
		// (set) Token: 0x060061D6 RID: 25046 RVA: 0x00364BF4 File Offset: 0x00363BF4
		public bool AutoLeading
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

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x060061D7 RID: 25047 RVA: 0x00364C00 File Offset: 0x00363C00
		// (set) Token: 0x060061D8 RID: 25048 RVA: 0x00364C18 File Offset: 0x00363C18
		public bool CleanParagraphBreaks
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x060061D9 RID: 25049 RVA: 0x00364C24 File Offset: 0x00363C24
		// (set) Token: 0x060061DA RID: 25050 RVA: 0x00364C3C File Offset: 0x00363C3C
		public bool Expandable
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

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x060061DB RID: 25051 RVA: 0x00364C48 File Offset: 0x00363C48
		// (set) Token: 0x060061DC RID: 25052 RVA: 0x00364C60 File Offset: 0x00363C60
		public bool Splittable
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x060061DD RID: 25053 RVA: 0x00364C6C File Offset: 0x00363C6C
		// (set) Token: 0x060061DE RID: 25054 RVA: 0x00364C84 File Offset: 0x00363C84
		public Font Font
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x060061DF RID: 25055 RVA: 0x00364C90 File Offset: 0x00363C90
		// (set) Token: 0x060061E0 RID: 25056 RVA: 0x00364CA8 File Offset: 0x00363CA8
		public float FontSize
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x060061E1 RID: 25057 RVA: 0x00364CB4 File Offset: 0x00363CB4
		// (set) Token: 0x060061E2 RID: 25058 RVA: 0x00364CCC File Offset: 0x00363CCC
		public float Leading
		{
			get
			{
				return this.h;
			}
			set
			{
				this.b = false;
				this.h = value;
			}
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x060061E3 RID: 25059 RVA: 0x00364CE0 File Offset: 0x00363CE0
		// (set) Token: 0x060061E4 RID: 25060 RVA: 0x00364CF8 File Offset: 0x00363CF8
		public float ParagraphIndent
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

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x060061E5 RID: 25061 RVA: 0x00364D04 File Offset: 0x00363D04
		// (set) Token: 0x060061E6 RID: 25062 RVA: 0x00364D1C File Offset: 0x00363D1C
		public float ParagraphSpacing
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

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x060061E7 RID: 25063 RVA: 0x00364D28 File Offset: 0x00363D28
		// (set) Token: 0x060061E8 RID: 25064 RVA: 0x00364D40 File Offset: 0x00363D40
		public Color TextColor
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x060061E9 RID: 25065 RVA: 0x00364D4C File Offset: 0x00363D4C
		// (set) Token: 0x060061EA RID: 25066 RVA: 0x00364D64 File Offset: 0x00363D64
		public Color TextOutlineColor
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x060061EB RID: 25067 RVA: 0x00364D70 File Offset: 0x00363D70
		// (set) Token: 0x060061EC RID: 25068 RVA: 0x00364D88 File Offset: 0x00363D88
		public float TextOutlineWidth
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x060061ED RID: 25069 RVA: 0x00364D94 File Offset: 0x00363D94
		// (set) Token: 0x060061EE RID: 25070 RVA: 0x00364DAC File Offset: 0x00363DAC
		public bool Underline
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x060061EF RID: 25071 RVA: 0x00364DB8 File Offset: 0x00363DB8
		// (set) Token: 0x060061F0 RID: 25072 RVA: 0x00364DD0 File Offset: 0x00363DD0
		public VAlign VAlign
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x060061F1 RID: 25073 RVA: 0x00364DDC File Offset: 0x00363DDC
		// (set) Token: 0x060061F2 RID: 25074 RVA: 0x00364DF4 File Offset: 0x00363DF4
		public string DataFormat
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x060061F3 RID: 25075 RVA: 0x00364E00 File Offset: 0x00363E00
		// (set) Token: 0x060061F4 RID: 25076 RVA: 0x00364E1D File Offset: 0x00363E1D
		public string DataName
		{
			get
			{
				return this.q.b();
			}
			set
			{
				this.q = new akn(value);
			}
		}

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x060061F5 RID: 25077 RVA: 0x00364E2C File Offset: 0x00363E2C
		// (set) Token: 0x060061F6 RID: 25078 RVA: 0x00364E44 File Offset: 0x00363E44
		public float Angle
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x060061F7 RID: 25079 RVA: 0x00364E50 File Offset: 0x00363E50
		// (set) Token: 0x060061F8 RID: 25080 RVA: 0x00364E6E File Offset: 0x00363E6E
		public float Height
		{
			get
			{
				return x5.b(this.s);
			}
			set
			{
				this.s = x5.a(value);
			}
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x060061F9 RID: 25081 RVA: 0x00364E80 File Offset: 0x00363E80
		// (set) Token: 0x060061FA RID: 25082 RVA: 0x00364E9E File Offset: 0x00363E9E
		public float Width
		{
			get
			{
				return x5.b(this.t);
			}
			set
			{
				this.t = x5.a(value);
			}
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x060061FB RID: 25083 RVA: 0x00364EB0 File Offset: 0x00363EB0
		// (set) Token: 0x060061FC RID: 25084 RVA: 0x00364ECE File Offset: 0x00363ECE
		public float X
		{
			get
			{
				return x5.b(this.u);
			}
			set
			{
				this.u = x5.a(value);
			}
		}

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x060061FD RID: 25085 RVA: 0x00364EE0 File Offset: 0x00363EE0
		// (set) Token: 0x060061FE RID: 25086 RVA: 0x00364EFE File Offset: 0x00363EFE
		public float Y
		{
			get
			{
				return x5.b(this.v);
			}
			set
			{
				this.v = x5.a(value);
			}
		}

		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x060061FF RID: 25087 RVA: 0x00364F10 File Offset: 0x00363F10
		// (set) Token: 0x06006200 RID: 25088 RVA: 0x00364F28 File Offset: 0x00363F28
		public IFormatProvider FormatProvider
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x0400325E RID: 12894
		private TextAlign a;

		// Token: 0x0400325F RID: 12895
		private bool b;

		// Token: 0x04003260 RID: 12896
		private bool c;

		// Token: 0x04003261 RID: 12897
		private bool d;

		// Token: 0x04003262 RID: 12898
		private bool e;

		// Token: 0x04003263 RID: 12899
		private Font f;

		// Token: 0x04003264 RID: 12900
		private float g;

		// Token: 0x04003265 RID: 12901
		private float h;

		// Token: 0x04003266 RID: 12902
		private float i;

		// Token: 0x04003267 RID: 12903
		private float j;

		// Token: 0x04003268 RID: 12904
		private Color k;

		// Token: 0x04003269 RID: 12905
		private Color l;

		// Token: 0x0400326A RID: 12906
		private float m = 1f;

		// Token: 0x0400326B RID: 12907
		private bool n;

		// Token: 0x0400326C RID: 12908
		private VAlign o;

		// Token: 0x0400326D RID: 12909
		private string p;

		// Token: 0x0400326E RID: 12910
		private akn q;

		// Token: 0x0400326F RID: 12911
		private float r;

		// Token: 0x04003270 RID: 12912
		private x5 s;

		// Token: 0x04003271 RID: 12913
		private x5 t;

		// Token: 0x04003272 RID: 12914
		private x5 u;

		// Token: 0x04003273 RID: 12915
		private x5 v;

		// Token: 0x04003274 RID: 12916
		private short w = short.MinValue;

		// Token: 0x04003275 RID: 12917
		private IFormatProvider x;

		// Token: 0x04003276 RID: 12918
		private alo y;

		// Token: 0x04003277 RID: 12919
		private LayingOutEventHandler z;

		// Token: 0x04003278 RID: 12920
		private RecordBoxLaidOutEventHandler aa;

		// Token: 0x04003279 RID: 12921
		private TextSettingEventHandler ab;

		// Token: 0x0400327A RID: 12922
		private TextSetEventHandler ac;
	}
}
