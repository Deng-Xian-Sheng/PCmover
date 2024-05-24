using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200084E RID: 2126
	public class Rectangle : ReportElement
	{
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06005607 RID: 22023 RVA: 0x002995F8 File Offset: 0x002985F8
		// (remove) Token: 0x06005608 RID: 22024 RVA: 0x00299634 File Offset: 0x00298634
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

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06005609 RID: 22025 RVA: 0x00299670 File Offset: 0x00298670
		// (remove) Token: 0x0600560A RID: 22026 RVA: 0x002996AC File Offset: 0x002986AC
		public event RectangleLaidOutEventHandler LaidOut
		{
			add
			{
				RectangleLaidOutEventHandler rectangleLaidOutEventHandler = this.o;
				RectangleLaidOutEventHandler rectangleLaidOutEventHandler2;
				do
				{
					rectangleLaidOutEventHandler2 = rectangleLaidOutEventHandler;
					RectangleLaidOutEventHandler value2 = (RectangleLaidOutEventHandler)Delegate.Combine(rectangleLaidOutEventHandler2, value);
					rectangleLaidOutEventHandler = Interlocked.CompareExchange<RectangleLaidOutEventHandler>(ref this.o, value2, rectangleLaidOutEventHandler2);
				}
				while (rectangleLaidOutEventHandler != rectangleLaidOutEventHandler2);
			}
			remove
			{
				RectangleLaidOutEventHandler rectangleLaidOutEventHandler = this.o;
				RectangleLaidOutEventHandler rectangleLaidOutEventHandler2;
				do
				{
					rectangleLaidOutEventHandler2 = rectangleLaidOutEventHandler;
					RectangleLaidOutEventHandler value2 = (RectangleLaidOutEventHandler)Delegate.Remove(rectangleLaidOutEventHandler2, value);
					rectangleLaidOutEventHandler = Interlocked.CompareExchange<RectangleLaidOutEventHandler>(ref this.o, value2, rectangleLaidOutEventHandler2);
				}
				while (rectangleLaidOutEventHandler != rectangleLaidOutEventHandler2);
			}
		}

		// Token: 0x0600560B RID: 22027 RVA: 0x002996E8 File Offset: 0x002986E8
		internal Rectangle(rm A_0, wg A_1)
		{
			this.a = A_1.a();
			this.b = A_1.b();
			this.c = A_1.c();
			this.d = A_1.d();
			this.e = A_1.e();
			this.f = A_1.f();
			this.g = A_1.g();
			this.j = A_1.j();
			this.k = A_1.k();
			this.i = A_1.i();
			this.h = A_1.h();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x0600560C RID: 22028 RVA: 0x002997C0 File Offset: 0x002987C0
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (this.f == AlternateRow.All || this.f == A_1.e4())
			{
				if (this.n != null)
				{
					LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
					this.n(this, layingOutEventArgs);
					if (!layingOutEventArgs.Layout)
					{
						return;
					}
				}
				xn xn = new xn(x5.b(this.j), x5.b(this.k), x5.b(this.i), x5.b(this.h), this.a, this.e, this.c, this.b);
				xn.Angle = this.g;
				xn.CornerRadius = this.d;
				xn.a(this.l);
				xn.a(this.m);
				A_0.a(xn);
				if (this.o != null)
				{
					RectangleLaidOutEventArgs rectangleLaidOutEventArgs = new RectangleLaidOutEventArgs(A_1, xn);
					this.o(this, rectangleLaidOutEventArgs);
				}
			}
		}

		// Token: 0x0600560D RID: 22029 RVA: 0x002998D8 File Offset: 0x002988D8
		internal override bool gp()
		{
			return true;
		}

		// Token: 0x0600560E RID: 22030 RVA: 0x002998EC File Offset: 0x002988EC
		internal override x5 gm()
		{
			return this.k;
		}

		// Token: 0x0600560F RID: 22031 RVA: 0x00299904 File Offset: 0x00298904
		internal override x5 gn()
		{
			return x5.f(this.k, this.h);
		}

		// Token: 0x06005610 RID: 22032 RVA: 0x00299928 File Offset: 0x00298928
		internal override void gq(short A_0)
		{
			if (this.l == null)
			{
				this.l = new wv();
			}
			this.l.a(A_0);
		}

		// Token: 0x06005611 RID: 22033 RVA: 0x00299960 File Offset: 0x00298960
		internal override bool fj()
		{
			return this.l == null || this.l.a == null;
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06005612 RID: 22034 RVA: 0x00299998 File Offset: 0x00298998
		// (set) Token: 0x06005613 RID: 22035 RVA: 0x002999B0 File Offset: 0x002989B0
		public Color BorderColor
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

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06005614 RID: 22036 RVA: 0x002999BC File Offset: 0x002989BC
		// (set) Token: 0x06005615 RID: 22037 RVA: 0x002999D4 File Offset: 0x002989D4
		public LineStyle BorderStyle
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

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06005616 RID: 22038 RVA: 0x002999E0 File Offset: 0x002989E0
		// (set) Token: 0x06005617 RID: 22039 RVA: 0x002999F8 File Offset: 0x002989F8
		public float BorderWidth
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

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06005618 RID: 22040 RVA: 0x00299A04 File Offset: 0x00298A04
		// (set) Token: 0x06005619 RID: 22041 RVA: 0x00299A1C File Offset: 0x00298A1C
		public float CornerRadius
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

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x0600561A RID: 22042 RVA: 0x00299A28 File Offset: 0x00298A28
		// (set) Token: 0x0600561B RID: 22043 RVA: 0x00299A40 File Offset: 0x00298A40
		public Color FillColor
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

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x0600561C RID: 22044 RVA: 0x00299A4C File Offset: 0x00298A4C
		// (set) Token: 0x0600561D RID: 22045 RVA: 0x00299A64 File Offset: 0x00298A64
		public AlternateRow ShowAlternateRow
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

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x0600561E RID: 22046 RVA: 0x00299A70 File Offset: 0x00298A70
		// (set) Token: 0x0600561F RID: 22047 RVA: 0x00299A88 File Offset: 0x00298A88
		public float Angle
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

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06005620 RID: 22048 RVA: 0x00299A94 File Offset: 0x00298A94
		// (set) Token: 0x06005621 RID: 22049 RVA: 0x00299AB2 File Offset: 0x00298AB2
		public float Height
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

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06005622 RID: 22050 RVA: 0x00299AC4 File Offset: 0x00298AC4
		// (set) Token: 0x06005623 RID: 22051 RVA: 0x00299AE2 File Offset: 0x00298AE2
		public float Width
		{
			get
			{
				return x5.b(this.i);
			}
			set
			{
				this.i = x5.a(value);
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06005624 RID: 22052 RVA: 0x00299AF4 File Offset: 0x00298AF4
		// (set) Token: 0x06005625 RID: 22053 RVA: 0x00299B12 File Offset: 0x00298B12
		public float X
		{
			get
			{
				return x5.b(this.j);
			}
			set
			{
				this.j = x5.a(value);
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06005626 RID: 22054 RVA: 0x00299B24 File Offset: 0x00298B24
		// (set) Token: 0x06005627 RID: 22055 RVA: 0x00299B42 File Offset: 0x00298B42
		public float Y
		{
			get
			{
				return x5.b(this.k);
			}
			set
			{
				this.k = x5.a(value);
			}
		}

		// Token: 0x06005628 RID: 22056 RVA: 0x00299B54 File Offset: 0x00298B54
		internal override short gk()
		{
			return this.m;
		}

		// Token: 0x06005629 RID: 22057 RVA: 0x00299B6C File Offset: 0x00298B6C
		internal override void gl(short A_0)
		{
			this.m = A_0;
		}

		// Token: 0x04002DDF RID: 11743
		private Color a;

		// Token: 0x04002DE0 RID: 11744
		private LineStyle b;

		// Token: 0x04002DE1 RID: 11745
		private float c;

		// Token: 0x04002DE2 RID: 11746
		private float d;

		// Token: 0x04002DE3 RID: 11747
		private Color e;

		// Token: 0x04002DE4 RID: 11748
		private AlternateRow f;

		// Token: 0x04002DE5 RID: 11749
		private float g;

		// Token: 0x04002DE6 RID: 11750
		private x5 h;

		// Token: 0x04002DE7 RID: 11751
		private x5 i;

		// Token: 0x04002DE8 RID: 11752
		private x5 j;

		// Token: 0x04002DE9 RID: 11753
		private x5 k;

		// Token: 0x04002DEA RID: 11754
		private wv l;

		// Token: 0x04002DEB RID: 11755
		private short m = short.MinValue;

		// Token: 0x04002DEC RID: 11756
		private LayingOutEventHandler n;

		// Token: 0x04002DED RID: 11757
		private RectangleLaidOutEventHandler o;
	}
}
