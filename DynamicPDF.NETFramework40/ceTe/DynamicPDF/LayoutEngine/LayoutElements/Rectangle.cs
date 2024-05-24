using System;
using System.Threading;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200096D RID: 2413
	public class Rectangle : LayoutElement
	{
		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06006201 RID: 25089 RVA: 0x00364F34 File Offset: 0x00363F34
		// (remove) Token: 0x06006202 RID: 25090 RVA: 0x00364F70 File Offset: 0x00363F70
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

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06006203 RID: 25091 RVA: 0x00364FAC File Offset: 0x00363FAC
		// (remove) Token: 0x06006204 RID: 25092 RVA: 0x00364FE8 File Offset: 0x00363FE8
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

		// Token: 0x06006205 RID: 25093 RVA: 0x00365024 File Offset: 0x00364024
		internal Rectangle(alo A_0, alg A_1)
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
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x06006206 RID: 25094 RVA: 0x003650FC File Offset: 0x003640FC
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (this.f == AlternateRow.All || this.f == A_1.m7())
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
				amw amw = new amw(x5.b(this.j), x5.b(this.k), x5.b(this.i), x5.b(this.h), this.a, this.e, this.c, this.b);
				amw.Angle = this.g;
				amw.CornerRadius = this.d;
				amw.a(this.l);
				amw.a(this.m);
				A_0.a(amw);
				if (this.o != null)
				{
					RectangleLaidOutEventArgs rectangleLaidOutEventArgs = new RectangleLaidOutEventArgs(A_1, amw);
					this.o(this, rectangleLaidOutEventArgs);
				}
			}
		}

		// Token: 0x06006207 RID: 25095 RVA: 0x00365214 File Offset: 0x00364214
		internal override bool n3()
		{
			return true;
		}

		// Token: 0x06006208 RID: 25096 RVA: 0x00365228 File Offset: 0x00364228
		internal override x5 ny()
		{
			return this.k;
		}

		// Token: 0x06006209 RID: 25097 RVA: 0x00365240 File Offset: 0x00364240
		internal override x5 nz()
		{
			return x5.f(this.k, this.h);
		}

		// Token: 0x0600620A RID: 25098 RVA: 0x00365264 File Offset: 0x00364264
		internal override void n4(short A_0)
		{
			if (this.l == null)
			{
				this.l = new alt();
			}
			this.l.a(A_0);
		}

		// Token: 0x0600620B RID: 25099 RVA: 0x0036529C File Offset: 0x0036429C
		internal override bool n2()
		{
			return this.l == null || this.l.a == null;
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x0600620C RID: 25100 RVA: 0x003652D4 File Offset: 0x003642D4
		// (set) Token: 0x0600620D RID: 25101 RVA: 0x003652EC File Offset: 0x003642EC
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

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x0600620E RID: 25102 RVA: 0x003652F8 File Offset: 0x003642F8
		// (set) Token: 0x0600620F RID: 25103 RVA: 0x00365310 File Offset: 0x00364310
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

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x06006210 RID: 25104 RVA: 0x0036531C File Offset: 0x0036431C
		// (set) Token: 0x06006211 RID: 25105 RVA: 0x00365334 File Offset: 0x00364334
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

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x06006212 RID: 25106 RVA: 0x00365340 File Offset: 0x00364340
		// (set) Token: 0x06006213 RID: 25107 RVA: 0x00365358 File Offset: 0x00364358
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

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06006214 RID: 25108 RVA: 0x00365364 File Offset: 0x00364364
		// (set) Token: 0x06006215 RID: 25109 RVA: 0x0036537C File Offset: 0x0036437C
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

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x06006216 RID: 25110 RVA: 0x00365388 File Offset: 0x00364388
		// (set) Token: 0x06006217 RID: 25111 RVA: 0x003653A0 File Offset: 0x003643A0
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

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06006218 RID: 25112 RVA: 0x003653AC File Offset: 0x003643AC
		// (set) Token: 0x06006219 RID: 25113 RVA: 0x003653C4 File Offset: 0x003643C4
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

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x0600621A RID: 25114 RVA: 0x003653D0 File Offset: 0x003643D0
		// (set) Token: 0x0600621B RID: 25115 RVA: 0x003653EE File Offset: 0x003643EE
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

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x0600621C RID: 25116 RVA: 0x00365400 File Offset: 0x00364400
		// (set) Token: 0x0600621D RID: 25117 RVA: 0x0036541E File Offset: 0x0036441E
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

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x0600621E RID: 25118 RVA: 0x00365430 File Offset: 0x00364430
		// (set) Token: 0x0600621F RID: 25119 RVA: 0x0036544E File Offset: 0x0036444E
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

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06006220 RID: 25120 RVA: 0x00365460 File Offset: 0x00364460
		// (set) Token: 0x06006221 RID: 25121 RVA: 0x0036547E File Offset: 0x0036447E
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

		// Token: 0x06006222 RID: 25122 RVA: 0x00365490 File Offset: 0x00364490
		internal override short nw()
		{
			return this.m;
		}

		// Token: 0x06006223 RID: 25123 RVA: 0x003654A8 File Offset: 0x003644A8
		internal override void nx(short A_0)
		{
			this.m = A_0;
		}

		// Token: 0x0400327B RID: 12923
		private Color a;

		// Token: 0x0400327C RID: 12924
		private LineStyle b;

		// Token: 0x0400327D RID: 12925
		private float c;

		// Token: 0x0400327E RID: 12926
		private float d;

		// Token: 0x0400327F RID: 12927
		private Color e;

		// Token: 0x04003280 RID: 12928
		private AlternateRow f;

		// Token: 0x04003281 RID: 12929
		private float g;

		// Token: 0x04003282 RID: 12930
		private x5 h;

		// Token: 0x04003283 RID: 12931
		private x5 i;

		// Token: 0x04003284 RID: 12932
		private x5 j;

		// Token: 0x04003285 RID: 12933
		private x5 k;

		// Token: 0x04003286 RID: 12934
		private alt l;

		// Token: 0x04003287 RID: 12935
		private short m = short.MinValue;

		// Token: 0x04003288 RID: 12936
		private LayingOutEventHandler n;

		// Token: 0x04003289 RID: 12937
		private RectangleLaidOutEventHandler o;
	}
}
