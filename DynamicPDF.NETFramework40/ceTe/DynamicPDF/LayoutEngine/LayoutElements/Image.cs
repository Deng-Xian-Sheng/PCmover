using System;
using System.Threading;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094A RID: 2378
	public class Image : LayoutElement
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06006087 RID: 24711 RVA: 0x003615C8 File Offset: 0x003605C8
		// (remove) Token: 0x06006088 RID: 24712 RVA: 0x00361604 File Offset: 0x00360604
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

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06006089 RID: 24713 RVA: 0x00361640 File Offset: 0x00360640
		// (remove) Token: 0x0600608A RID: 24714 RVA: 0x0036167C File Offset: 0x0036067C
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

		// Token: 0x0600608B RID: 24715 RVA: 0x003616B8 File Offset: 0x003606B8
		internal Image(alo A_0, ak5 A_1)
		{
			this.a = A_1.a();
			this.d = A_1.d();
			this.e = A_1.e();
			this.c = A_1.c();
			this.b = A_1.b();
			this.f = A_1.f();
			this.h = A_1.g();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x0600608C RID: 24716 RVA: 0x00361768 File Offset: 0x00360768
		internal override void nt(amj A_0, LayoutWriter A_1)
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

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x0600608D RID: 24717 RVA: 0x00361848 File Offset: 0x00360848
		// (set) Token: 0x0600608E RID: 24718 RVA: 0x00361860 File Offset: 0x00360860
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

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x0600608F RID: 24719 RVA: 0x0036186C File Offset: 0x0036086C
		// (set) Token: 0x06006090 RID: 24720 RVA: 0x0036188A File Offset: 0x0036088A
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

		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06006091 RID: 24721 RVA: 0x0036189C File Offset: 0x0036089C
		// (set) Token: 0x06006092 RID: 24722 RVA: 0x003618BA File Offset: 0x003608BA
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

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06006093 RID: 24723 RVA: 0x003618CC File Offset: 0x003608CC
		// (set) Token: 0x06006094 RID: 24724 RVA: 0x003618EA File Offset: 0x003608EA
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

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x06006095 RID: 24725 RVA: 0x003618FC File Offset: 0x003608FC
		// (set) Token: 0x06006096 RID: 24726 RVA: 0x0036191A File Offset: 0x0036091A
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

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x06006097 RID: 24727 RVA: 0x0036192C File Offset: 0x0036092C
		// (set) Token: 0x06006098 RID: 24728 RVA: 0x00361944 File Offset: 0x00360944
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

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x06006099 RID: 24729 RVA: 0x00361950 File Offset: 0x00360950
		// (set) Token: 0x0600609A RID: 24730 RVA: 0x00361968 File Offset: 0x00360968
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

		// Token: 0x0600609B RID: 24731 RVA: 0x00361974 File Offset: 0x00360974
		internal override x5 nz()
		{
			return x5.f(this.e, this.b);
		}

		// Token: 0x0600609C RID: 24732 RVA: 0x00361998 File Offset: 0x00360998
		internal override short nw()
		{
			return this.g;
		}

		// Token: 0x0600609D RID: 24733 RVA: 0x003619B0 File Offset: 0x003609B0
		internal override void nx(short A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600609E RID: 24734 RVA: 0x003619BC File Offset: 0x003609BC
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x040031EA RID: 12778
		private float a;

		// Token: 0x040031EB RID: 12779
		private x5 b;

		// Token: 0x040031EC RID: 12780
		private x5 c;

		// Token: 0x040031ED RID: 12781
		private x5 d;

		// Token: 0x040031EE RID: 12782
		private x5 e;

		// Token: 0x040031EF RID: 12783
		private ImageData f;

		// Token: 0x040031F0 RID: 12784
		private short g = short.MinValue;

		// Token: 0x040031F1 RID: 12785
		private string h = null;

		// Token: 0x040031F2 RID: 12786
		private LayingOutEventHandler i;

		// Token: 0x040031F3 RID: 12787
		private ImageLaidOutEventHandler j;
	}
}
