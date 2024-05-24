using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x02000948 RID: 2376
	public class ContentGroup : LayoutElement
	{
		// Token: 0x06006054 RID: 24660 RVA: 0x0036084C File Offset: 0x0035F84C
		internal ContentGroup(alo A_0, aku A_1)
		{
			this.c = A_1.e();
			this.d = A_1.f();
			this.b = A_1.d();
			this.a = A_1.a();
			this.e = A_1.b();
			this.f = new LayoutElementList(A_0, A_1.c());
			this.a();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
		}

		// Token: 0x06006055 RID: 24661 RVA: 0x003608F3 File Offset: 0x0035F8F3
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			throw new LayoutEngineException("A content group can only be placed in the detail of a report.");
		}

		// Token: 0x06006056 RID: 24662 RVA: 0x00360900 File Offset: 0x0035F900
		internal override void nu(aml A_0, LayoutWriter A_1)
		{
			if (this.f != null)
			{
				amo amo = new amo(this.c, this.d, this.a, this.e, this.g, this.h, this.f);
				for (int i = 0; i < this.f.Count; i++)
				{
					this.f[i].nu(amo.a(), A_1);
				}
				amo.a(this.g);
				A_0.a(amo);
				A_0.a().a(amo);
			}
		}

		// Token: 0x06006057 RID: 24663 RVA: 0x003609A8 File Offset: 0x0035F9A8
		private void a()
		{
			short num = 0;
			for (int i = 0; i < this.f.Count; i++)
			{
				if (this.f[i].n3())
				{
					for (int j = 0; j < this.f.Count; j++)
					{
						if (this.f[j].nv() && x5.d(this.f[i].ny(), this.f[j].nz()) && x5.a(this.f[i].nz(), this.f[j].nz()) && i != j)
						{
							if (this.f[j].nw() == -32768)
							{
								LayoutElement layoutElement = this.f[j];
								short num2 = num;
								num = num2 + 1;
								layoutElement.nx(num2);
							}
							this.h = true;
							this.f[i].n4(this.f[j].nw());
						}
					}
				}
			}
		}

		// Token: 0x06006058 RID: 24664 RVA: 0x00360AF0 File Offset: 0x0035FAF0
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x06006059 RID: 24665 RVA: 0x00360B04 File Offset: 0x0035FB04
		internal override short nw()
		{
			return this.g;
		}

		// Token: 0x0600605A RID: 24666 RVA: 0x00360B1C File Offset: 0x0035FB1C
		internal override void nx(short A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600605B RID: 24667 RVA: 0x00360B28 File Offset: 0x0035FB28
		internal override x5 ny()
		{
			return this.d;
		}

		// Token: 0x0600605C RID: 24668 RVA: 0x00360B40 File Offset: 0x0035FB40
		internal override x5 nz()
		{
			return x5.f(this.d, this.a);
		}

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x0600605D RID: 24669 RVA: 0x00360B64 File Offset: 0x0035FB64
		// (set) Token: 0x0600605E RID: 24670 RVA: 0x00360B82 File Offset: 0x0035FB82
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

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x0600605F RID: 24671 RVA: 0x00360B94 File Offset: 0x0035FB94
		public LayoutElementList Elements
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x06006060 RID: 24672 RVA: 0x00360BAC File Offset: 0x0035FBAC
		// (set) Token: 0x06006061 RID: 24673 RVA: 0x00360BCA File Offset: 0x0035FBCA
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

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06006062 RID: 24674 RVA: 0x00360BDC File Offset: 0x0035FBDC
		// (set) Token: 0x06006063 RID: 24675 RVA: 0x00360BFA File Offset: 0x0035FBFA
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

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06006064 RID: 24676 RVA: 0x00360C0C File Offset: 0x0035FC0C
		// (set) Token: 0x06006065 RID: 24677 RVA: 0x00360C2A File Offset: 0x0035FC2A
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

		// Token: 0x040031D3 RID: 12755
		private x5 a;

		// Token: 0x040031D4 RID: 12756
		private x5 b;

		// Token: 0x040031D5 RID: 12757
		private x5 c;

		// Token: 0x040031D6 RID: 12758
		private x5 d;

		// Token: 0x040031D7 RID: 12759
		private bool e;

		// Token: 0x040031D8 RID: 12760
		private LayoutElementList f;

		// Token: 0x040031D9 RID: 12761
		private short g = short.MinValue;

		// Token: 0x040031DA RID: 12762
		private bool h;
	}
}
