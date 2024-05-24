using System;
using System.Threading;
using ceTe.DynamicPDF.LayoutEngine.Layout;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200096B RID: 2411
	public class RecordArea : LayoutElement
	{
		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06006185 RID: 24965 RVA: 0x003632E4 File Offset: 0x003622E4
		// (remove) Token: 0x06006186 RID: 24966 RVA: 0x00363320 File Offset: 0x00362320
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.x;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.x, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.x;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.x, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06006187 RID: 24967 RVA: 0x0036335C File Offset: 0x0036235C
		// (remove) Token: 0x06006188 RID: 24968 RVA: 0x00363398 File Offset: 0x00362398
		public event RecordAreaLaidOutEventHandler LaidOut
		{
			add
			{
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler = this.y;
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler2;
				do
				{
					recordAreaLaidOutEventHandler2 = recordAreaLaidOutEventHandler;
					RecordAreaLaidOutEventHandler value2 = (RecordAreaLaidOutEventHandler)Delegate.Combine(recordAreaLaidOutEventHandler2, value);
					recordAreaLaidOutEventHandler = Interlocked.CompareExchange<RecordAreaLaidOutEventHandler>(ref this.y, value2, recordAreaLaidOutEventHandler2);
				}
				while (recordAreaLaidOutEventHandler != recordAreaLaidOutEventHandler2);
			}
			remove
			{
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler = this.y;
				RecordAreaLaidOutEventHandler recordAreaLaidOutEventHandler2;
				do
				{
					recordAreaLaidOutEventHandler2 = recordAreaLaidOutEventHandler;
					RecordAreaLaidOutEventHandler value2 = (RecordAreaLaidOutEventHandler)Delegate.Remove(recordAreaLaidOutEventHandler2, value);
					recordAreaLaidOutEventHandler = Interlocked.CompareExchange<RecordAreaLaidOutEventHandler>(ref this.y, value2, recordAreaLaidOutEventHandler2);
				}
				while (recordAreaLaidOutEventHandler != recordAreaLaidOutEventHandler2);
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06006189 RID: 24969 RVA: 0x003633D4 File Offset: 0x003623D4
		// (remove) Token: 0x0600618A RID: 24970 RVA: 0x00363410 File Offset: 0x00362410
		public event TextSettingEventHandler TextSetting
		{
			add
			{
				TextSettingEventHandler textSettingEventHandler = this.z;
				TextSettingEventHandler textSettingEventHandler2;
				do
				{
					textSettingEventHandler2 = textSettingEventHandler;
					TextSettingEventHandler value2 = (TextSettingEventHandler)Delegate.Combine(textSettingEventHandler2, value);
					textSettingEventHandler = Interlocked.CompareExchange<TextSettingEventHandler>(ref this.z, value2, textSettingEventHandler2);
				}
				while (textSettingEventHandler != textSettingEventHandler2);
			}
			remove
			{
				TextSettingEventHandler textSettingEventHandler = this.z;
				TextSettingEventHandler textSettingEventHandler2;
				do
				{
					textSettingEventHandler2 = textSettingEventHandler;
					TextSettingEventHandler value2 = (TextSettingEventHandler)Delegate.Remove(textSettingEventHandler2, value);
					textSettingEventHandler = Interlocked.CompareExchange<TextSettingEventHandler>(ref this.z, value2, textSettingEventHandler2);
				}
				while (textSettingEventHandler != textSettingEventHandler2);
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600618B RID: 24971 RVA: 0x0036344C File Offset: 0x0036244C
		// (remove) Token: 0x0600618C RID: 24972 RVA: 0x00363488 File Offset: 0x00362488
		public event TextSetEventHandler TextSet
		{
			add
			{
				TextSetEventHandler textSetEventHandler = this.aa;
				TextSetEventHandler textSetEventHandler2;
				do
				{
					textSetEventHandler2 = textSetEventHandler;
					TextSetEventHandler value2 = (TextSetEventHandler)Delegate.Combine(textSetEventHandler2, value);
					textSetEventHandler = Interlocked.CompareExchange<TextSetEventHandler>(ref this.aa, value2, textSetEventHandler2);
				}
				while (textSetEventHandler != textSetEventHandler2);
			}
			remove
			{
				TextSetEventHandler textSetEventHandler = this.aa;
				TextSetEventHandler textSetEventHandler2;
				do
				{
					textSetEventHandler2 = textSetEventHandler;
					TextSetEventHandler value2 = (TextSetEventHandler)Delegate.Remove(textSetEventHandler2, value);
					textSetEventHandler = Interlocked.CompareExchange<TextSetEventHandler>(ref this.aa, value2, textSetEventHandler2);
				}
				while (textSetEventHandler != textSetEventHandler2);
			}
		}

		// Token: 0x0600618D RID: 24973 RVA: 0x003634C4 File Offset: 0x003624C4
		internal RecordArea(alo A_0, ale A_1)
		{
			this.a = A_1.a();
			this.b = A_1.b();
			this.c = A_1.c();
			this.d = A_1.d();
			this.e = A_1.e();
			this.f = A_1.f();
			this.g = A_1.g();
			this.h = A_1.h();
			this.i = A_1.i();
			this.j = A_1.j();
			this.k = A_1.k();
			this.l = A_1.l();
			this.o = A_1.m();
			this.p = A_1.n();
			this.q = A_1.o();
			this.t = A_1.r();
			this.u = A_1.s();
			this.s = A_1.q();
			this.r = A_1.p();
			if (this.k.d())
			{
				A_0.b().m1().a(this.k.e());
			}
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			this.w = A_0;
			if (A_0.c())
			{
				if (A_0 is SubReport && this.k.d())
				{
					this.k.e().a((SubReport)A_0);
				}
			}
			else
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x0600618E RID: 24974 RVA: 0x0036367C File Offset: 0x0036267C
		internal override void nu(aml A_0, LayoutWriter A_1)
		{
			if (this.k != null)
			{
				if (this.x != null)
				{
					LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
					this.x(this, layingOutEventArgs);
					if (!layingOutEventArgs.Layout)
					{
						return;
					}
				}
				LayoutTextArea layoutTextArea;
				if (this.k.d())
				{
					layoutTextArea = new am8(this, new char[0]);
					A_0.a(layoutTextArea);
					if (this.d)
					{
						A_0.a().a(layoutTextArea);
					}
					akk akk = new akk();
					for (int i = 0; i < this.k.c().a(); i++)
					{
						if (this.k.c().a(i).nd())
						{
							((al6)this.k.c().a(i)).a().mc(A_1, akk, layoutTextArea);
						}
					}
					alq alq = new alq(this.k.c().a());
					this.k.a(A_1, alq);
					if (this.k.e().c())
					{
						if (this.k.e().d() == null)
						{
							((Report)this.w).h().f().a(new ais(layoutTextArea, akk, this.k, alq));
						}
						else
						{
							((SubReport)this.w).h().f().a(new ais(layoutTextArea, akk, this.k, alq));
						}
					}
					else if (this.w is FixedPage)
					{
						((FixedPage)this.w).g().a(new ais(layoutTextArea, akk, this.k, alq));
					}
					else
					{
						((al2)A_1).m5().a(new ais(layoutTextArea, akk, this.k, alq));
					}
					akk.a();
				}
				else
				{
					char[] array = this.k.b(A_1);
					if (this.z != null)
					{
						TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(new string(array));
						this.z(this, textSettingEventArgs);
						array = textSettingEventArgs.Text.ToCharArray();
					}
					layoutTextArea = new am8(this, array);
					if (this.aa != null)
					{
						TextSetEventArgs textSetEventArgs = new TextSetEventArgs(new string(array), layoutTextArea);
						this.aa(this, textSetEventArgs);
					}
					A_0.a(layoutTextArea);
					if (this.d)
					{
						A_0.a().a(layoutTextArea);
					}
				}
				if (this.y != null)
				{
					RecordAreaLaidOutEventArgs recordAreaLaidOutEventArgs = new RecordAreaLaidOutEventArgs(A_1, layoutTextArea);
					this.y(this, recordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600618F RID: 24975 RVA: 0x0036398C File Offset: 0x0036298C
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.k != null)
			{
				if (this.x != null)
				{
					LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
					this.x(this, layingOutEventArgs);
					if (!layingOutEventArgs.Layout)
					{
						return;
					}
				}
				LayoutTextArea layoutTextArea;
				if (this.k.d())
				{
					layoutTextArea = new am8(this, new char[0]);
					A_0.a(layoutTextArea);
					akk akk = new akk();
					for (int i = 0; i < this.k.c().a(); i++)
					{
						if (this.k.c().a(i).nd())
						{
							((al6)this.k.c().a(i)).a().mc(A_1, akk, layoutTextArea);
						}
					}
					alq alq = new alq(this.k.c().a());
					this.k.a(A_1, alq);
					if (this.k.e().c())
					{
						if (this.k.e().d() == null)
						{
							((Report)this.w).h().f().a(new ais(layoutTextArea, akk, this.k, alq));
						}
						else
						{
							((SubReport)this.w).h().f().a(new ais(layoutTextArea, akk, this.k, alq));
						}
					}
					else if (this.w is FixedPage)
					{
						((FixedPage)this.w).g().a(new ais(layoutTextArea, akk, this.k, alq));
					}
					else
					{
						((al2)A_1).m5().a(new ais(layoutTextArea, akk, this.k, alq));
					}
					akk.a();
				}
				else
				{
					char[] array = this.k.b(A_1);
					if (this.z != null)
					{
						TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(new string(array));
						this.z(this, textSettingEventArgs);
						array = textSettingEventArgs.Text.ToCharArray();
					}
					layoutTextArea = new am8(this, array);
					if (this.aa != null)
					{
						TextSetEventArgs textSetEventArgs = new TextSetEventArgs(new string(array), layoutTextArea);
						this.aa(this, textSetEventArgs);
					}
					A_0.a(layoutTextArea);
				}
				if (this.y != null)
				{
					RecordAreaLaidOutEventArgs recordAreaLaidOutEventArgs = new RecordAreaLaidOutEventArgs(A_1, layoutTextArea);
					this.y(this, recordAreaLaidOutEventArgs);
				}
			}
		}

		// Token: 0x06006190 RID: 24976 RVA: 0x00363C64 File Offset: 0x00362C64
		internal char[] a(char[] A_0)
		{
			char[] result;
			if (this.z == null)
			{
				result = A_0;
			}
			else
			{
				TextSettingEventArgs textSettingEventArgs = new TextSettingEventArgs(new string(A_0));
				this.z(this, textSettingEventArgs);
				result = textSettingEventArgs.Text.ToCharArray();
			}
			return result;
		}

		// Token: 0x06006191 RID: 24977 RVA: 0x00363CB0 File Offset: 0x00362CB0
		internal void a(char[] A_0, LayoutTextArea A_1)
		{
			if (this.aa != null)
			{
				TextSetEventArgs textSetEventArgs = new TextSetEventArgs(new string(A_0), A_1);
				this.aa(this, textSetEventArgs);
			}
		}

		// Token: 0x06006192 RID: 24978 RVA: 0x00363CE8 File Offset: 0x00362CE8
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x06006193 RID: 24979 RVA: 0x00363CFC File Offset: 0x00362CFC
		internal override short nw()
		{
			return this.v;
		}

		// Token: 0x06006194 RID: 24980 RVA: 0x00363D14 File Offset: 0x00362D14
		internal override void nx(short A_0)
		{
			this.v = A_0;
		}

		// Token: 0x06006195 RID: 24981 RVA: 0x00363D20 File Offset: 0x00362D20
		internal override x5 ny()
		{
			return this.u;
		}

		// Token: 0x06006196 RID: 24982 RVA: 0x00363D38 File Offset: 0x00362D38
		internal override x5 nz()
		{
			return x5.f(this.u, this.r);
		}

		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06006197 RID: 24983 RVA: 0x00363D5C File Offset: 0x00362D5C
		// (set) Token: 0x06006198 RID: 24984 RVA: 0x00363D74 File Offset: 0x00362D74
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

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06006199 RID: 24985 RVA: 0x00363D80 File Offset: 0x00362D80
		// (set) Token: 0x0600619A RID: 24986 RVA: 0x00363D98 File Offset: 0x00362D98
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

		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x0600619B RID: 24987 RVA: 0x00363DA4 File Offset: 0x00362DA4
		// (set) Token: 0x0600619C RID: 24988 RVA: 0x00363DBC File Offset: 0x00362DBC
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

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x0600619D RID: 24989 RVA: 0x00363DC8 File Offset: 0x00362DC8
		// (set) Token: 0x0600619E RID: 24990 RVA: 0x00363DE0 File Offset: 0x00362DE0
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

		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x0600619F RID: 24991 RVA: 0x00363DEC File Offset: 0x00362DEC
		// (set) Token: 0x060061A0 RID: 24992 RVA: 0x00363E04 File Offset: 0x00362E04
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

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x060061A1 RID: 24993 RVA: 0x00363E10 File Offset: 0x00362E10
		// (set) Token: 0x060061A2 RID: 24994 RVA: 0x00363E28 File Offset: 0x00362E28
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

		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x060061A3 RID: 24995 RVA: 0x00363E34 File Offset: 0x00362E34
		// (set) Token: 0x060061A4 RID: 24996 RVA: 0x00363E4C File Offset: 0x00362E4C
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

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x060061A5 RID: 24997 RVA: 0x00363E58 File Offset: 0x00362E58
		// (set) Token: 0x060061A6 RID: 24998 RVA: 0x00363E70 File Offset: 0x00362E70
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

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x060061A7 RID: 24999 RVA: 0x00363E84 File Offset: 0x00362E84
		// (set) Token: 0x060061A8 RID: 25000 RVA: 0x00363E9C File Offset: 0x00362E9C
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

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x060061A9 RID: 25001 RVA: 0x00363EA8 File Offset: 0x00362EA8
		// (set) Token: 0x060061AA RID: 25002 RVA: 0x00363EC0 File Offset: 0x00362EC0
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

		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x060061AB RID: 25003 RVA: 0x00363ECC File Offset: 0x00362ECC
		// (set) Token: 0x060061AC RID: 25004 RVA: 0x00363EE9 File Offset: 0x00362EE9
		public string Text
		{
			get
			{
				return this.k.ToString();
			}
			set
			{
				this.k = new air(value);
			}
		}

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x060061AD RID: 25005 RVA: 0x00363EF8 File Offset: 0x00362EF8
		// (set) Token: 0x060061AE RID: 25006 RVA: 0x00363F10 File Offset: 0x00362F10
		public Color TextColor
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

		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x060061AF RID: 25007 RVA: 0x00363F1C File Offset: 0x00362F1C
		// (set) Token: 0x060061B0 RID: 25008 RVA: 0x00363F34 File Offset: 0x00362F34
		public Color TextOutlineColor
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

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x060061B1 RID: 25009 RVA: 0x00363F40 File Offset: 0x00362F40
		// (set) Token: 0x060061B2 RID: 25010 RVA: 0x00363F58 File Offset: 0x00362F58
		public float TextOutlineWidth
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

		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x060061B3 RID: 25011 RVA: 0x00363F64 File Offset: 0x00362F64
		// (set) Token: 0x060061B4 RID: 25012 RVA: 0x00363F7C File Offset: 0x00362F7C
		public bool Underline
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

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x060061B5 RID: 25013 RVA: 0x00363F88 File Offset: 0x00362F88
		// (set) Token: 0x060061B6 RID: 25014 RVA: 0x00363FA0 File Offset: 0x00362FA0
		public VAlign VAlign
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

		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x060061B7 RID: 25015 RVA: 0x00363FAC File Offset: 0x00362FAC
		// (set) Token: 0x060061B8 RID: 25016 RVA: 0x00363FC4 File Offset: 0x00362FC4
		public float Angle
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x060061B9 RID: 25017 RVA: 0x00363FD0 File Offset: 0x00362FD0
		// (set) Token: 0x060061BA RID: 25018 RVA: 0x00363FEE File Offset: 0x00362FEE
		public float Height
		{
			get
			{
				return x5.b(this.r);
			}
			set
			{
				this.r = x5.a(value);
			}
		}

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x060061BB RID: 25019 RVA: 0x00364000 File Offset: 0x00363000
		// (set) Token: 0x060061BC RID: 25020 RVA: 0x0036401E File Offset: 0x0036301E
		public float Width
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

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x060061BD RID: 25021 RVA: 0x00364030 File Offset: 0x00363030
		// (set) Token: 0x060061BE RID: 25022 RVA: 0x0036404E File Offset: 0x0036304E
		public float X
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

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x060061BF RID: 25023 RVA: 0x00364060 File Offset: 0x00363060
		// (set) Token: 0x060061C0 RID: 25024 RVA: 0x0036407E File Offset: 0x0036307E
		public float Y
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

		// Token: 0x04003243 RID: 12867
		private TextAlign a;

		// Token: 0x04003244 RID: 12868
		private bool b;

		// Token: 0x04003245 RID: 12869
		private bool c;

		// Token: 0x04003246 RID: 12870
		private bool d;

		// Token: 0x04003247 RID: 12871
		private bool e;

		// Token: 0x04003248 RID: 12872
		private Font f;

		// Token: 0x04003249 RID: 12873
		private float g;

		// Token: 0x0400324A RID: 12874
		private float h;

		// Token: 0x0400324B RID: 12875
		private float i;

		// Token: 0x0400324C RID: 12876
		private float j;

		// Token: 0x0400324D RID: 12877
		private air k;

		// Token: 0x0400324E RID: 12878
		private Color l;

		// Token: 0x0400324F RID: 12879
		private Color m;

		// Token: 0x04003250 RID: 12880
		private float n = 1f;

		// Token: 0x04003251 RID: 12881
		private bool o;

		// Token: 0x04003252 RID: 12882
		private VAlign p;

		// Token: 0x04003253 RID: 12883
		private float q;

		// Token: 0x04003254 RID: 12884
		private x5 r;

		// Token: 0x04003255 RID: 12885
		private x5 s;

		// Token: 0x04003256 RID: 12886
		private x5 t;

		// Token: 0x04003257 RID: 12887
		private x5 u;

		// Token: 0x04003258 RID: 12888
		private short v = short.MinValue;

		// Token: 0x04003259 RID: 12889
		private alo w;

		// Token: 0x0400325A RID: 12890
		private LayingOutEventHandler x;

		// Token: 0x0400325B RID: 12891
		private RecordAreaLaidOutEventHandler y;

		// Token: 0x0400325C RID: 12892
		private TextSettingEventHandler z;

		// Token: 0x0400325D RID: 12893
		private TextSetEventHandler aa;
	}
}
