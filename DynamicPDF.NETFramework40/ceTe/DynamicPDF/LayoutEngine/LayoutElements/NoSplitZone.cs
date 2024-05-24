using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094D RID: 2381
	public class NoSplitZone : LayoutElement
	{
		// Token: 0x060060DD RID: 24797 RVA: 0x0036237C File Offset: 0x0036137C
		internal NoSplitZone(alo A_0, ak8 A_1)
		{
			if (x5.c(A_1.a(), A_1.b()))
			{
				this.a = A_1.b();
				this.b = A_1.a();
			}
			else
			{
				this.a = A_1.a();
				this.b = A_1.b();
			}
			A_0.b().DocumentLayout.a(A_1.mu(), this);
		}

		// Token: 0x060060DE RID: 24798 RVA: 0x003623F8 File Offset: 0x003613F8
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (A_0.k() == null)
			{
				A_0.a(new anc());
			}
			if (x5.c(this.a, x5.a()) && x5.c(this.b, x5.a()) && this.c != null)
			{
				A_0.k().a(this.a, this.b, this.c);
			}
		}

		// Token: 0x060060DF RID: 24799 RVA: 0x0036247C File Offset: 0x0036147C
		internal override void n1(short A_0, alv A_1)
		{
			if (this.c == null)
			{
				this.c = new alt();
			}
			this.c.a(A_0, A_1);
		}

		// Token: 0x060060E0 RID: 24800 RVA: 0x003624B3 File Offset: 0x003614B3
		internal void a(x5 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060060E1 RID: 24801 RVA: 0x003624BD File Offset: 0x003614BD
		internal void b(x5 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060060E2 RID: 24802 RVA: 0x003624C8 File Offset: 0x003614C8
		internal override x5 ny()
		{
			return this.a;
		}

		// Token: 0x060060E3 RID: 24803 RVA: 0x003624E0 File Offset: 0x003614E0
		internal override x5 nz()
		{
			return this.b;
		}

		// Token: 0x060060E4 RID: 24804 RVA: 0x003624F8 File Offset: 0x003614F8
		internal override ushort n0()
		{
			return 61443;
		}

		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x060060E5 RID: 24805 RVA: 0x00362510 File Offset: 0x00361510
		// (set) Token: 0x060060E6 RID: 24806 RVA: 0x0036252E File Offset: 0x0036152E
		public float Top
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

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x060060E7 RID: 24807 RVA: 0x00362540 File Offset: 0x00361540
		// (set) Token: 0x060060E8 RID: 24808 RVA: 0x0036255E File Offset: 0x0036155E
		public float Bottom
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

		// Token: 0x0400320E RID: 12814
		private x5 a;

		// Token: 0x0400320F RID: 12815
		private x5 b;

		// Token: 0x04003210 RID: 12816
		private alt c;
	}
}
