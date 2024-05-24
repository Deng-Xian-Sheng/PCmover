using System;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x0200083D RID: 2109
	public class Line : ReportElement
	{
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600550D RID: 21773 RVA: 0x00296C9C File Offset: 0x00295C9C
		// (remove) Token: 0x0600550E RID: 21774 RVA: 0x00296CD8 File Offset: 0x00295CD8
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

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600550F RID: 21775 RVA: 0x00296D14 File Offset: 0x00295D14
		// (remove) Token: 0x06005510 RID: 21776 RVA: 0x00296D50 File Offset: 0x00295D50
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

		// Token: 0x06005511 RID: 21777 RVA: 0x00296D8C File Offset: 0x00295D8C
		internal Line(rm A_0, v5 A_1)
		{
			this.a = A_1.b();
			this.b = A_1.c();
			this.c = A_1.d();
			this.d = A_1.e();
			this.e = A_1.f();
			this.f = A_1.g();
			this.h = A_1.a();
			this.g = A_1.h();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005512 RID: 21778 RVA: 0x00296E40 File Offset: 0x00295E40
		internal override void fi(xf A_0, LayoutWriter A_1)
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
			xm xm = new xm(x5.b(this.a), x5.b(this.c), x5.b(this.b), x5.b(this.d), x5.b(this.e), this.g, this.h);
			xm.Cap = this.f;
			xm.a(this.i);
			A_0.a(xm);
			if (this.k != null)
			{
				LineLaidOutEventArgs lineLaidOutEventArgs = new LineLaidOutEventArgs(A_1, xm);
				this.k(this, lineLaidOutEventArgs);
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06005513 RID: 21779 RVA: 0x00296F18 File Offset: 0x00295F18
		// (set) Token: 0x06005514 RID: 21780 RVA: 0x00296F36 File Offset: 0x00295F36
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

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06005515 RID: 21781 RVA: 0x00296F48 File Offset: 0x00295F48
		// (set) Token: 0x06005516 RID: 21782 RVA: 0x00296F66 File Offset: 0x00295F66
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

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06005517 RID: 21783 RVA: 0x00296F78 File Offset: 0x00295F78
		// (set) Token: 0x06005518 RID: 21784 RVA: 0x00296F96 File Offset: 0x00295F96
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

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06005519 RID: 21785 RVA: 0x00296FA8 File Offset: 0x00295FA8
		// (set) Token: 0x0600551A RID: 21786 RVA: 0x00296FC6 File Offset: 0x00295FC6
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

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x0600551B RID: 21787 RVA: 0x00296FD8 File Offset: 0x00295FD8
		// (set) Token: 0x0600551C RID: 21788 RVA: 0x00296FF6 File Offset: 0x00295FF6
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

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x0600551D RID: 21789 RVA: 0x00297008 File Offset: 0x00296008
		// (set) Token: 0x0600551E RID: 21790 RVA: 0x00297020 File Offset: 0x00296020
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

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x0600551F RID: 21791 RVA: 0x0029702C File Offset: 0x0029602C
		// (set) Token: 0x06005520 RID: 21792 RVA: 0x00297044 File Offset: 0x00296044
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

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06005521 RID: 21793 RVA: 0x00297050 File Offset: 0x00296050
		// (set) Token: 0x06005522 RID: 21794 RVA: 0x00297068 File Offset: 0x00296068
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

		// Token: 0x06005523 RID: 21795 RVA: 0x00297074 File Offset: 0x00296074
		internal override x5 gm()
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

		// Token: 0x06005524 RID: 21796 RVA: 0x002970B0 File Offset: 0x002960B0
		internal override x5 gn()
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

		// Token: 0x06005525 RID: 21797 RVA: 0x002970EC File Offset: 0x002960EC
		internal override short gk()
		{
			return this.i;
		}

		// Token: 0x06005526 RID: 21798 RVA: 0x00297104 File Offset: 0x00296104
		internal override void gl(short A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06005527 RID: 21799 RVA: 0x00297110 File Offset: 0x00296110
		internal override ushort fk()
		{
			return 40960;
		}

		// Token: 0x04002D7A RID: 11642
		private x5 a;

		// Token: 0x04002D7B RID: 11643
		private x5 b;

		// Token: 0x04002D7C RID: 11644
		private x5 c;

		// Token: 0x04002D7D RID: 11645
		private x5 d;

		// Token: 0x04002D7E RID: 11646
		private x5 e;

		// Token: 0x04002D7F RID: 11647
		private LineCap f;

		// Token: 0x04002D80 RID: 11648
		private Color g;

		// Token: 0x04002D81 RID: 11649
		private LineStyle h;

		// Token: 0x04002D82 RID: 11650
		private short i = short.MinValue;

		// Token: 0x04002D83 RID: 11651
		private LayingOutEventHandler j;

		// Token: 0x04002D84 RID: 11652
		private LineLaidOutEventHandler k;
	}
}
