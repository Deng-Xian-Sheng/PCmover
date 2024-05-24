using System;
using System.Threading;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000845 RID: 2117
	public class PlaceHolder : ReportElement
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x0600556F RID: 21871 RVA: 0x00297A00 File Offset: 0x00296A00
		// (remove) Token: 0x06005570 RID: 21872 RVA: 0x00297A3C File Offset: 0x00296A3C
		public event PlaceHolderLaidOutEventHandler LaidOut
		{
			add
			{
				PlaceHolderLaidOutEventHandler placeHolderLaidOutEventHandler = this.f;
				PlaceHolderLaidOutEventHandler placeHolderLaidOutEventHandler2;
				do
				{
					placeHolderLaidOutEventHandler2 = placeHolderLaidOutEventHandler;
					PlaceHolderLaidOutEventHandler value2 = (PlaceHolderLaidOutEventHandler)Delegate.Combine(placeHolderLaidOutEventHandler2, value);
					placeHolderLaidOutEventHandler = Interlocked.CompareExchange<PlaceHolderLaidOutEventHandler>(ref this.f, value2, placeHolderLaidOutEventHandler2);
				}
				while (placeHolderLaidOutEventHandler != placeHolderLaidOutEventHandler2);
			}
			remove
			{
				PlaceHolderLaidOutEventHandler placeHolderLaidOutEventHandler = this.f;
				PlaceHolderLaidOutEventHandler placeHolderLaidOutEventHandler2;
				do
				{
					placeHolderLaidOutEventHandler2 = placeHolderLaidOutEventHandler;
					PlaceHolderLaidOutEventHandler value2 = (PlaceHolderLaidOutEventHandler)Delegate.Remove(placeHolderLaidOutEventHandler2, value);
					placeHolderLaidOutEventHandler = Interlocked.CompareExchange<PlaceHolderLaidOutEventHandler>(ref this.f, value2, placeHolderLaidOutEventHandler2);
				}
				while (placeHolderLaidOutEventHandler != placeHolderLaidOutEventHandler2);
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06005571 RID: 21873 RVA: 0x00297A78 File Offset: 0x00296A78
		// (remove) Token: 0x06005572 RID: 21874 RVA: 0x00297AB4 File Offset: 0x00296AB4
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.g;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.g, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.g;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.g, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x06005573 RID: 21875 RVA: 0x00297AF0 File Offset: 0x00296AF0
		internal PlaceHolder(rm A_0, wc A_1)
		{
			this.c = A_1.a();
			this.d = A_1.b();
			this.b = A_1.c();
			this.a = A_1.d();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005574 RID: 21876 RVA: 0x00297B74 File Offset: 0x00296B74
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (this.g != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.g(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			ContentArea contentArea = new ContentArea(x5.b(this.c), x5.b(this.d), x5.b(this.b), x5.b(this.a));
			contentArea.a(this.e);
			A_0.a(contentArea);
			if (this.f != null)
			{
				PlaceHolderLaidOutEventArgs placeHolderLaidOutEventArgs = new PlaceHolderLaidOutEventArgs(A_1, contentArea);
				this.f(this, placeHolderLaidOutEventArgs);
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06005575 RID: 21877 RVA: 0x00297C24 File Offset: 0x00296C24
		// (set) Token: 0x06005576 RID: 21878 RVA: 0x00297C42 File Offset: 0x00296C42
		public float X
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

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06005577 RID: 21879 RVA: 0x00297C54 File Offset: 0x00296C54
		// (set) Token: 0x06005578 RID: 21880 RVA: 0x00297C72 File Offset: 0x00296C72
		public float Y
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

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06005579 RID: 21881 RVA: 0x00297C84 File Offset: 0x00296C84
		// (set) Token: 0x0600557A RID: 21882 RVA: 0x00297CA2 File Offset: 0x00296CA2
		public float Width
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

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x0600557B RID: 21883 RVA: 0x00297CB4 File Offset: 0x00296CB4
		// (set) Token: 0x0600557C RID: 21884 RVA: 0x00297CD2 File Offset: 0x00296CD2
		public float Height
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

		// Token: 0x0600557D RID: 21885 RVA: 0x00297CE4 File Offset: 0x00296CE4
		internal override x5 gm()
		{
			return this.d;
		}

		// Token: 0x0600557E RID: 21886 RVA: 0x00297CFC File Offset: 0x00296CFC
		internal override x5 gn()
		{
			return x5.f(this.d, this.a);
		}

		// Token: 0x0600557F RID: 21887 RVA: 0x00297D20 File Offset: 0x00296D20
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005580 RID: 21888 RVA: 0x00297D34 File Offset: 0x00296D34
		internal override short gk()
		{
			return this.e;
		}

		// Token: 0x06005581 RID: 21889 RVA: 0x00297D4C File Offset: 0x00296D4C
		internal override void gl(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04002D9E RID: 11678
		private x5 a;

		// Token: 0x04002D9F RID: 11679
		private x5 b;

		// Token: 0x04002DA0 RID: 11680
		private x5 c;

		// Token: 0x04002DA1 RID: 11681
		private x5 d;

		// Token: 0x04002DA2 RID: 11682
		private short e = short.MinValue;

		// Token: 0x04002DA3 RID: 11683
		private PlaceHolderLaidOutEventHandler f;

		// Token: 0x04002DA4 RID: 11684
		private LayingOutEventHandler g;
	}
}
