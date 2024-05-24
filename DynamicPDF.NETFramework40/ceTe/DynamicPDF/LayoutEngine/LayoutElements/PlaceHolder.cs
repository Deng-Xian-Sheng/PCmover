using System;
using System.Threading;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000950 RID: 2384
	public class PlaceHolder : LayoutElement
	{
		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06006116 RID: 24854 RVA: 0x00362BC4 File Offset: 0x00361BC4
		// (remove) Token: 0x06006117 RID: 24855 RVA: 0x00362C00 File Offset: 0x00361C00
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

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06006118 RID: 24856 RVA: 0x00362C3C File Offset: 0x00361C3C
		// (remove) Token: 0x06006119 RID: 24857 RVA: 0x00362C78 File Offset: 0x00361C78
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

		// Token: 0x0600611A RID: 24858 RVA: 0x00362CB4 File Offset: 0x00361CB4
		internal PlaceHolder(alo A_0, alc A_1)
		{
			this.c = A_1.a();
			this.d = A_1.b();
			this.b = A_1.c();
			this.a = A_1.d();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x0600611B RID: 24859 RVA: 0x00362D38 File Offset: 0x00361D38
		internal override void nt(amj A_0, LayoutWriter A_1)
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

		// Token: 0x17000A89 RID: 2697
		// (get) Token: 0x0600611C RID: 24860 RVA: 0x00362DE8 File Offset: 0x00361DE8
		// (set) Token: 0x0600611D RID: 24861 RVA: 0x00362E06 File Offset: 0x00361E06
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

		// Token: 0x17000A8A RID: 2698
		// (get) Token: 0x0600611E RID: 24862 RVA: 0x00362E18 File Offset: 0x00361E18
		// (set) Token: 0x0600611F RID: 24863 RVA: 0x00362E36 File Offset: 0x00361E36
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

		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06006120 RID: 24864 RVA: 0x00362E48 File Offset: 0x00361E48
		// (set) Token: 0x06006121 RID: 24865 RVA: 0x00362E66 File Offset: 0x00361E66
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

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06006122 RID: 24866 RVA: 0x00362E78 File Offset: 0x00361E78
		// (set) Token: 0x06006123 RID: 24867 RVA: 0x00362E96 File Offset: 0x00361E96
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

		// Token: 0x06006124 RID: 24868 RVA: 0x00362EA8 File Offset: 0x00361EA8
		internal override x5 ny()
		{
			return this.d;
		}

		// Token: 0x06006125 RID: 24869 RVA: 0x00362EC0 File Offset: 0x00361EC0
		internal override x5 nz()
		{
			return x5.f(this.d, this.a);
		}

		// Token: 0x06006126 RID: 24870 RVA: 0x00362EE4 File Offset: 0x00361EE4
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x06006127 RID: 24871 RVA: 0x00362EF8 File Offset: 0x00361EF8
		internal override short nw()
		{
			return this.e;
		}

		// Token: 0x06006128 RID: 24872 RVA: 0x00362F10 File Offset: 0x00361F10
		internal override void nx(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04003223 RID: 12835
		private x5 a;

		// Token: 0x04003224 RID: 12836
		private x5 b;

		// Token: 0x04003225 RID: 12837
		private x5 c;

		// Token: 0x04003226 RID: 12838
		private x5 d;

		// Token: 0x04003227 RID: 12839
		private short e = short.MinValue;

		// Token: 0x04003228 RID: 12840
		private PlaceHolderLaidOutEventHandler f;

		// Token: 0x04003229 RID: 12841
		private LayingOutEventHandler g;
	}
}
