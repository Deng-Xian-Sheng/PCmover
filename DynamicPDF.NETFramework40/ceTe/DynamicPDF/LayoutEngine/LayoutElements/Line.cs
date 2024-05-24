using System;
using System.Threading;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094C RID: 2380
	public class Line : LayoutElement
	{
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060060C2 RID: 24770 RVA: 0x00361EF0 File Offset: 0x00360EF0
		// (remove) Token: 0x060060C3 RID: 24771 RVA: 0x00361F2C File Offset: 0x00360F2C
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.j;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.j, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.j;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.j, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060060C4 RID: 24772 RVA: 0x00361F68 File Offset: 0x00360F68
		// (remove) Token: 0x060060C5 RID: 24773 RVA: 0x00361FA4 File Offset: 0x00360FA4
		public event LineLaidOutEventHandler LaidOut
		{
			add
			{
				LineLaidOutEventHandler lineLaidOutEventHandler = this.k;
				LineLaidOutEventHandler lineLaidOutEventHandler2;
				do
				{
					lineLaidOutEventHandler2 = lineLaidOutEventHandler;
					LineLaidOutEventHandler value2 = (LineLaidOutEventHandler)Delegate.Combine(lineLaidOutEventHandler2, value);
					lineLaidOutEventHandler = Interlocked.CompareExchange<LineLaidOutEventHandler>(ref this.k, value2, lineLaidOutEventHandler2);
				}
				while (lineLaidOutEventHandler != lineLaidOutEventHandler2);
			}
			remove
			{
				LineLaidOutEventHandler lineLaidOutEventHandler = this.k;
				LineLaidOutEventHandler lineLaidOutEventHandler2;
				do
				{
					lineLaidOutEventHandler2 = lineLaidOutEventHandler;
					LineLaidOutEventHandler value2 = (LineLaidOutEventHandler)Delegate.Remove(lineLaidOutEventHandler2, value);
					lineLaidOutEventHandler = Interlocked.CompareExchange<LineLaidOutEventHandler>(ref this.k, value2, lineLaidOutEventHandler2);
				}
				while (lineLaidOutEventHandler != lineLaidOutEventHandler2);
			}
		}

		// Token: 0x060060C6 RID: 24774 RVA: 0x00361FE0 File Offset: 0x00360FE0
		internal Line(alo A_0, ak7 A_1)
		{
			this.a = A_1.b();
			this.b = A_1.c();
			this.c = A_1.d();
			this.d = A_1.e();
			this.e = A_1.f();
			this.f = A_1.g();
			this.h = A_1.a();
			this.g = A_1.h();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x060060C7 RID: 24775 RVA: 0x00362094 File Offset: 0x00361094
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.j != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.j(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			amu amu = new amu(x5.b(this.a), x5.b(this.c), x5.b(this.b), x5.b(this.d), x5.b(this.e), this.g, this.h);
			amu.Cap = this.f;
			amu.a(this.i);
			A_0.a(amu);
			if (this.k != null)
			{
				LineLaidOutEventArgs lineLaidOutEventArgs = new LineLaidOutEventArgs(A_1, amu);
				this.k(this, lineLaidOutEventArgs);
			}
		}

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x060060C8 RID: 24776 RVA: 0x0036216C File Offset: 0x0036116C
		// (set) Token: 0x060060C9 RID: 24777 RVA: 0x0036218A File Offset: 0x0036118A
		public float X1
		{
			get
			{
				return x5.b(this.a);
			}
			set
			{
				this.a = x5.a(value);
			}
		}

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x060060CA RID: 24778 RVA: 0x0036219C File Offset: 0x0036119C
		// (set) Token: 0x060060CB RID: 24779 RVA: 0x003621BA File Offset: 0x003611BA
		public float X2
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x060060CC RID: 24780 RVA: 0x003621CC File Offset: 0x003611CC
		// (set) Token: 0x060060CD RID: 24781 RVA: 0x003621EA File Offset: 0x003611EA
		public float Y1
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x060060CE RID: 24782 RVA: 0x003621FC File Offset: 0x003611FC
		// (set) Token: 0x060060CF RID: 24783 RVA: 0x0036221A File Offset: 0x0036121A
		public float Y2
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x060060D0 RID: 24784 RVA: 0x0036222C File Offset: 0x0036122C
		// (set) Token: 0x060060D1 RID: 24785 RVA: 0x0036224A File Offset: 0x0036124A
		public float Width
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

		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x060060D2 RID: 24786 RVA: 0x0036225C File Offset: 0x0036125C
		// (set) Token: 0x060060D3 RID: 24787 RVA: 0x00362274 File Offset: 0x00361274
		public LineCap Cap
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

		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x060060D4 RID: 24788 RVA: 0x00362280 File Offset: 0x00361280
		// (set) Token: 0x060060D5 RID: 24789 RVA: 0x00362298 File Offset: 0x00361298
		public Color Color
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

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x060060D6 RID: 24790 RVA: 0x003622A4 File Offset: 0x003612A4
		// (set) Token: 0x060060D7 RID: 24791 RVA: 0x003622BC File Offset: 0x003612BC
		public LineStyle LineStyle
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x060060D8 RID: 24792 RVA: 0x003622C8 File Offset: 0x003612C8
		internal override x5 ny()
		{
			x5 result;
			if (x5.d(this.c, this.d))
			{
				result = this.c;
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x060060D9 RID: 24793 RVA: 0x00362304 File Offset: 0x00361304
		internal override x5 nz()
		{
			x5 result;
			if (x5.c(this.c, this.d))
			{
				result = this.d;
			}
			else
			{
				result = this.c;
			}
			return result;
		}

		// Token: 0x060060DA RID: 24794 RVA: 0x00362340 File Offset: 0x00361340
		internal override short nw()
		{
			return this.i;
		}

		// Token: 0x060060DB RID: 24795 RVA: 0x00362358 File Offset: 0x00361358
		internal override void nx(short A_0)
		{
			this.i = A_0;
		}

		// Token: 0x060060DC RID: 24796 RVA: 0x00362364 File Offset: 0x00361364
		internal override ushort n0()
		{
			return 40960;
		}

		// Token: 0x04003203 RID: 12803
		private x5 a;

		// Token: 0x04003204 RID: 12804
		private x5 b;

		// Token: 0x04003205 RID: 12805
		private x5 c;

		// Token: 0x04003206 RID: 12806
		private x5 d;

		// Token: 0x04003207 RID: 12807
		private x5 e;

		// Token: 0x04003208 RID: 12808
		private LineCap f;

		// Token: 0x04003209 RID: 12809
		private Color g;

		// Token: 0x0400320A RID: 12810
		private LineStyle h;

		// Token: 0x0400320B RID: 12811
		private short i = short.MinValue;

		// Token: 0x0400320C RID: 12812
		private LayingOutEventHandler j;

		// Token: 0x0400320D RID: 12813
		private LineLaidOutEventHandler k;
	}
}
