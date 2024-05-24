using System;
using System.Threading;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000835 RID: 2101
	public class Image : ReportElement
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060054BC RID: 21692 RVA: 0x0029628C File Offset: 0x0029528C
		// (remove) Token: 0x060054BD RID: 21693 RVA: 0x002962C8 File Offset: 0x002952C8
		public event LayingOutEventHandler LayingOut
		{
			add
			{
				LayingOutEventHandler layingOutEventHandler = this.i;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Combine(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.i, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
			remove
			{
				LayingOutEventHandler layingOutEventHandler = this.i;
				LayingOutEventHandler layingOutEventHandler2;
				do
				{
					layingOutEventHandler2 = layingOutEventHandler;
					LayingOutEventHandler value2 = (LayingOutEventHandler)Delegate.Remove(layingOutEventHandler2, value);
					layingOutEventHandler = Interlocked.CompareExchange<LayingOutEventHandler>(ref this.i, value2, layingOutEventHandler2);
				}
				while (layingOutEventHandler != layingOutEventHandler2);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060054BE RID: 21694 RVA: 0x00296304 File Offset: 0x00295304
		// (remove) Token: 0x060054BF RID: 21695 RVA: 0x00296340 File Offset: 0x00295340
		public event ImageLaidOutEventHandler LaidOut
		{
			add
			{
				ImageLaidOutEventHandler imageLaidOutEventHandler = this.j;
				ImageLaidOutEventHandler imageLaidOutEventHandler2;
				do
				{
					imageLaidOutEventHandler2 = imageLaidOutEventHandler;
					ImageLaidOutEventHandler value2 = (ImageLaidOutEventHandler)Delegate.Combine(imageLaidOutEventHandler2, value);
					imageLaidOutEventHandler = Interlocked.CompareExchange<ImageLaidOutEventHandler>(ref this.j, value2, imageLaidOutEventHandler2);
				}
				while (imageLaidOutEventHandler != imageLaidOutEventHandler2);
			}
			remove
			{
				ImageLaidOutEventHandler imageLaidOutEventHandler = this.j;
				ImageLaidOutEventHandler imageLaidOutEventHandler2;
				do
				{
					imageLaidOutEventHandler2 = imageLaidOutEventHandler;
					ImageLaidOutEventHandler value2 = (ImageLaidOutEventHandler)Delegate.Remove(imageLaidOutEventHandler2, value);
					imageLaidOutEventHandler = Interlocked.CompareExchange<ImageLaidOutEventHandler>(ref this.j, value2, imageLaidOutEventHandler2);
				}
				while (imageLaidOutEventHandler != imageLaidOutEventHandler2);
			}
		}

		// Token: 0x060054C0 RID: 21696 RVA: 0x0029637C File Offset: 0x0029537C
		internal Image(rm A_0, v3 A_1)
		{
			this.a = A_1.a();
			this.d = A_1.d();
			this.e = A_1.e();
			this.c = A_1.c();
			this.b = A_1.b();
			this.f = A_1.f();
			this.h = A_1.g();
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x060054C1 RID: 21697 RVA: 0x0029642C File Offset: 0x0029542C
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			if (this.i != null)
			{
				LayingOutEventArgs layingOutEventArgs = new LayingOutEventArgs(A_1);
				this.i(this, layingOutEventArgs);
				if (!layingOutEventArgs.Layout)
				{
					return;
				}
			}
			Image image = new Image(this.f, x5.b(this.d), x5.b(this.e));
			image.Width = x5.b(this.c);
			image.Height = x5.b(this.b);
			image.Angle = this.a;
			image.AlternateText = this.h;
			image.a(this.g);
			A_0.a(image);
			if (this.j != null)
			{
				ImageLaidOutEventArgs imageLaidOutEventArgs = new ImageLaidOutEventArgs(A_1, image);
				this.j(this, imageLaidOutEventArgs);
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x060054C2 RID: 21698 RVA: 0x0029650C File Offset: 0x0029550C
		// (set) Token: 0x060054C3 RID: 21699 RVA: 0x00296524 File Offset: 0x00295524
		public float Angle
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

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x060054C4 RID: 21700 RVA: 0x00296530 File Offset: 0x00295530
		// (set) Token: 0x060054C5 RID: 21701 RVA: 0x0029654E File Offset: 0x0029554E
		public float Height
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

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x060054C6 RID: 21702 RVA: 0x00296560 File Offset: 0x00295560
		// (set) Token: 0x060054C7 RID: 21703 RVA: 0x0029657E File Offset: 0x0029557E
		public float Width
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

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x060054C8 RID: 21704 RVA: 0x00296590 File Offset: 0x00295590
		// (set) Token: 0x060054C9 RID: 21705 RVA: 0x002965AE File Offset: 0x002955AE
		public float X
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

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x060054CA RID: 21706 RVA: 0x002965C0 File Offset: 0x002955C0
		// (set) Token: 0x060054CB RID: 21707 RVA: 0x002965DE File Offset: 0x002955DE
		public float Y
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

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x060054CC RID: 21708 RVA: 0x002965F0 File Offset: 0x002955F0
		// (set) Token: 0x060054CD RID: 21709 RVA: 0x00296608 File Offset: 0x00295608
		public ImageData ImageData
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

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x060054CE RID: 21710 RVA: 0x00296614 File Offset: 0x00295614
		// (set) Token: 0x060054CF RID: 21711 RVA: 0x0029662C File Offset: 0x0029562C
		public string AlternateText
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

		// Token: 0x060054D0 RID: 21712 RVA: 0x00296638 File Offset: 0x00295638
		internal override x5 gn()
		{
			return x5.f(this.e, this.b);
		}

		// Token: 0x060054D1 RID: 21713 RVA: 0x0029665C File Offset: 0x0029565C
		internal override short gk()
		{
			return this.g;
		}

		// Token: 0x060054D2 RID: 21714 RVA: 0x00296674 File Offset: 0x00295674
		internal override void gl(short A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060054D3 RID: 21715 RVA: 0x00296680 File Offset: 0x00295680
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x04002D5B RID: 11611
		private float a;

		// Token: 0x04002D5C RID: 11612
		private x5 b;

		// Token: 0x04002D5D RID: 11613
		private x5 c;

		// Token: 0x04002D5E RID: 11614
		private x5 d;

		// Token: 0x04002D5F RID: 11615
		private x5 e;

		// Token: 0x04002D60 RID: 11616
		private ImageData f;

		// Token: 0x04002D61 RID: 11617
		private short g = short.MinValue;

		// Token: 0x04002D62 RID: 11618
		private string h = null;

		// Token: 0x04002D63 RID: 11619
		private LayingOutEventHandler i;

		// Token: 0x04002D64 RID: 11620
		private ImageLaidOutEventHandler j;
	}
}
