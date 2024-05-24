using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.Layout;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200084B RID: 2123
	public class RecordBox : ReportElement
	{
		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060055C6 RID: 21958 RVA: 0x00298938 File Offset: 0x00297938
		// (remove) Token: 0x060055C7 RID: 21959 RVA: 0x00298974 File Offset: 0x00297974
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

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060055C8 RID: 21960 RVA: 0x002989B0 File Offset: 0x002979B0
		// (remove) Token: 0x060055C9 RID: 21961 RVA: 0x002989EC File Offset: 0x002979EC
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

		// Token: 0x060055CA RID: 21962 RVA: 0x00298A28 File Offset: 0x00297A28
		internal RecordBox(rm A_0, wf A_1)
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
			this.n = A_1.l();
			this.o = A_1.m();
			this.p = A_1.n();
			this.q = A_1.o();
			this.r = A_1.p();
			this.u = A_1.s();
			this.v = A_1.t();
			this.t = A_1.r();
			this.s = A_1.q();
			if (this.q.c())
			{
				A_0.b().ex().a(this.q.d());
			}
			A_0.b().DocumentLayout.a(A_1.f0(), this);
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
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x060055CB RID: 21963 RVA: 0x00298BEC File Offset: 0x00297BEC
		internal override void gi(xh A_0, LayoutWriter A_1)
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
				layoutTextArea = new LayoutTextArea(this, string.Empty);
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
				vi vi = new vi();
				this.q.a().eu(A_1, vi, layoutTextArea);
				if (this.q.d().c())
				{
					if (this.q.d().d() == null)
					{
						((Report)this.y).f().f().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
					}
					else
					{
						((SubReport)this.y).f().f().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
					}
				}
				else if (this.y is FixedPage)
				{
					((FixedPage)this.y).h().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
				}
				else
				{
					((w1)A_1).e2().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
				}
				vi.a();
			}
			else
			{
				object obj = this.q.a().es(A_1);
				if (obj == null)
				{
					return;
				}
				string a_;
				if (this.p != null && this.p.Length > 0)
				{
					if (obj is IFormattable)
					{
						IFormattable formattable = (IFormattable)obj;
						if (this.x == null)
						{
							a_ = formattable.ToString(this.p, A_1.DocumentLayout.FormatProvider);
						}
						else
						{
							a_ = formattable.ToString(this.p, this.x);
						}
					}
					else
					{
						a_ = obj.ToString();
					}
				}
				else
				{
					a_ = obj.ToString();
				}
				layoutTextArea = new LayoutTextArea(this, a_);
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

		// Token: 0x060055CC RID: 21964 RVA: 0x00298EF4 File Offset: 0x00297EF4
		internal override void fi(xf A_0, LayoutWriter A_1)
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
				layoutTextArea = new LayoutTextArea(this, string.Empty);
				A_0.a(layoutTextArea);
				IFormatProvider formatProvider = this.x;
				if (formatProvider == null)
				{
					formatProvider = A_1.DocumentLayout.FormatProvider;
				}
				vi vi = new vi();
				this.q.a().eu(A_1, vi, layoutTextArea);
				if (this.q.d().c())
				{
					if (this.q.d().d() == null)
					{
						((Report)this.y).f().f().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
					}
					else
					{
						((SubReport)this.y).f().f().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
					}
				}
				else if (this.y is FixedPage)
				{
					((FixedPage)this.y).h().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
				}
				else
				{
					((w1)A_1).e2().a(new vl(layoutTextArea, vi, this.q, formatProvider, this.p));
				}
				vi.a();
			}
			else
			{
				object obj = this.q.a().es(A_1);
				if (obj == null)
				{
					return;
				}
				string a_;
				if (this.p != null && this.p.Length > 0)
				{
					if (obj is IFormattable)
					{
						IFormattable formattable = (IFormattable)obj;
						if (this.x == null)
						{
							a_ = formattable.ToString(this.p, A_1.DocumentLayout.FormatProvider);
						}
						else
						{
							a_ = formattable.ToString(this.p, this.x);
						}
					}
					else
					{
						a_ = obj.ToString();
					}
				}
				else
				{
					a_ = obj.ToString();
				}
				layoutTextArea = new LayoutTextArea(this, a_);
				A_0.a(layoutTextArea);
			}
			if (this.aa != null)
			{
				RecordBoxLaidOutEventArgs recordBoxLaidOutEventArgs = new RecordBoxLaidOutEventArgs(A_1, layoutTextArea);
				this.aa(this, recordBoxLaidOutEventArgs);
			}
		}

		// Token: 0x060055CD RID: 21965 RVA: 0x002991C0 File Offset: 0x002981C0
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x060055CE RID: 21966 RVA: 0x002991D4 File Offset: 0x002981D4
		internal override short gk()
		{
			return this.w;
		}

		// Token: 0x060055CF RID: 21967 RVA: 0x002991EC File Offset: 0x002981EC
		internal override void gl(short A_0)
		{
			this.w = A_0;
		}

		// Token: 0x060055D0 RID: 21968 RVA: 0x002991F8 File Offset: 0x002981F8
		internal override x5 gm()
		{
			return this.v;
		}

		// Token: 0x060055D1 RID: 21969 RVA: 0x00299210 File Offset: 0x00298210
		internal override x5 gn()
		{
			return x5.f(this.v, this.s);
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x060055D2 RID: 21970 RVA: 0x00299234 File Offset: 0x00298234
		// (set) Token: 0x060055D3 RID: 21971 RVA: 0x0029924C File Offset: 0x0029824C
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

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x060055D4 RID: 21972 RVA: 0x00299258 File Offset: 0x00298258
		// (set) Token: 0x060055D5 RID: 21973 RVA: 0x00299270 File Offset: 0x00298270
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

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x060055D6 RID: 21974 RVA: 0x0029927C File Offset: 0x0029827C
		// (set) Token: 0x060055D7 RID: 21975 RVA: 0x00299294 File Offset: 0x00298294
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

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x060055D8 RID: 21976 RVA: 0x002992A0 File Offset: 0x002982A0
		// (set) Token: 0x060055D9 RID: 21977 RVA: 0x002992B8 File Offset: 0x002982B8
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

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x060055DA RID: 21978 RVA: 0x002992C4 File Offset: 0x002982C4
		// (set) Token: 0x060055DB RID: 21979 RVA: 0x002992DC File Offset: 0x002982DC
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

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x060055DC RID: 21980 RVA: 0x002992E8 File Offset: 0x002982E8
		// (set) Token: 0x060055DD RID: 21981 RVA: 0x00299300 File Offset: 0x00298300
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

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x060055DE RID: 21982 RVA: 0x0029930C File Offset: 0x0029830C
		// (set) Token: 0x060055DF RID: 21983 RVA: 0x00299324 File Offset: 0x00298324
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

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x060055E0 RID: 21984 RVA: 0x00299330 File Offset: 0x00298330
		// (set) Token: 0x060055E1 RID: 21985 RVA: 0x00299348 File Offset: 0x00298348
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

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x060055E2 RID: 21986 RVA: 0x0029935C File Offset: 0x0029835C
		// (set) Token: 0x060055E3 RID: 21987 RVA: 0x00299374 File Offset: 0x00298374
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

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x060055E4 RID: 21988 RVA: 0x00299380 File Offset: 0x00298380
		// (set) Token: 0x060055E5 RID: 21989 RVA: 0x00299398 File Offset: 0x00298398
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

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x060055E6 RID: 21990 RVA: 0x002993A4 File Offset: 0x002983A4
		// (set) Token: 0x060055E7 RID: 21991 RVA: 0x002993BC File Offset: 0x002983BC
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

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x060055E8 RID: 21992 RVA: 0x002993C8 File Offset: 0x002983C8
		// (set) Token: 0x060055E9 RID: 21993 RVA: 0x002993E0 File Offset: 0x002983E0
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

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x060055EA RID: 21994 RVA: 0x002993EC File Offset: 0x002983EC
		// (set) Token: 0x060055EB RID: 21995 RVA: 0x00299404 File Offset: 0x00298404
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

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x060055EC RID: 21996 RVA: 0x00299410 File Offset: 0x00298410
		// (set) Token: 0x060055ED RID: 21997 RVA: 0x00299428 File Offset: 0x00298428
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

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x060055EE RID: 21998 RVA: 0x00299434 File Offset: 0x00298434
		// (set) Token: 0x060055EF RID: 21999 RVA: 0x0029944C File Offset: 0x0029844C
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

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x060055F0 RID: 22000 RVA: 0x00299458 File Offset: 0x00298458
		// (set) Token: 0x060055F1 RID: 22001 RVA: 0x00299470 File Offset: 0x00298470
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

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x060055F2 RID: 22002 RVA: 0x0029947C File Offset: 0x0029847C
		// (set) Token: 0x060055F3 RID: 22003 RVA: 0x00299499 File Offset: 0x00298499
		public string Field
		{
			get
			{
				return this.q.b();
			}
			set
			{
				this.q = new vk(value);
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x060055F4 RID: 22004 RVA: 0x002994A8 File Offset: 0x002984A8
		// (set) Token: 0x060055F5 RID: 22005 RVA: 0x002994C0 File Offset: 0x002984C0
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

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x060055F6 RID: 22006 RVA: 0x002994CC File Offset: 0x002984CC
		// (set) Token: 0x060055F7 RID: 22007 RVA: 0x002994EA File Offset: 0x002984EA
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

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x060055F8 RID: 22008 RVA: 0x002994FC File Offset: 0x002984FC
		// (set) Token: 0x060055F9 RID: 22009 RVA: 0x0029951A File Offset: 0x0029851A
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

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x060055FA RID: 22010 RVA: 0x0029952C File Offset: 0x0029852C
		// (set) Token: 0x060055FB RID: 22011 RVA: 0x0029954A File Offset: 0x0029854A
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

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x060055FC RID: 22012 RVA: 0x0029955C File Offset: 0x0029855C
		// (set) Token: 0x060055FD RID: 22013 RVA: 0x0029957A File Offset: 0x0029857A
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

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x060055FE RID: 22014 RVA: 0x0029958C File Offset: 0x0029858C
		// (set) Token: 0x060055FF RID: 22015 RVA: 0x002995A4 File Offset: 0x002985A4
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

		// Token: 0x04002DC2 RID: 11714
		private TextAlign a;

		// Token: 0x04002DC3 RID: 11715
		private bool b;

		// Token: 0x04002DC4 RID: 11716
		private bool c;

		// Token: 0x04002DC5 RID: 11717
		private bool d;

		// Token: 0x04002DC6 RID: 11718
		private bool e;

		// Token: 0x04002DC7 RID: 11719
		private Font f;

		// Token: 0x04002DC8 RID: 11720
		private float g;

		// Token: 0x04002DC9 RID: 11721
		private float h;

		// Token: 0x04002DCA RID: 11722
		private float i;

		// Token: 0x04002DCB RID: 11723
		private float j;

		// Token: 0x04002DCC RID: 11724
		private Color k;

		// Token: 0x04002DCD RID: 11725
		private Color l;

		// Token: 0x04002DCE RID: 11726
		private float m = 1f;

		// Token: 0x04002DCF RID: 11727
		private bool n;

		// Token: 0x04002DD0 RID: 11728
		private VAlign o;

		// Token: 0x04002DD1 RID: 11729
		private string p;

		// Token: 0x04002DD2 RID: 11730
		private vk q;

		// Token: 0x04002DD3 RID: 11731
		private float r;

		// Token: 0x04002DD4 RID: 11732
		private x5 s;

		// Token: 0x04002DD5 RID: 11733
		private x5 t;

		// Token: 0x04002DD6 RID: 11734
		private x5 u;

		// Token: 0x04002DD7 RID: 11735
		private x5 v;

		// Token: 0x04002DD8 RID: 11736
		private short w = short.MinValue;

		// Token: 0x04002DD9 RID: 11737
		private IFormatProvider x;

		// Token: 0x04002DDA RID: 11738
		private rm y;

		// Token: 0x04002DDB RID: 11739
		private LayingOutEventHandler z;

		// Token: 0x04002DDC RID: 11740
		private RecordBoxLaidOutEventHandler aa;
	}
}
