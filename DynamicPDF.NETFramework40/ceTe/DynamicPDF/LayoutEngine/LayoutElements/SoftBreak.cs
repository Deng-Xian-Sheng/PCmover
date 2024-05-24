using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200096E RID: 2414
	public class SoftBreak : LayoutElement
	{
		// Token: 0x06006224 RID: 25124 RVA: 0x003654B2 File Offset: 0x003644B2
		internal SoftBreak(alo A_0, alj A_1)
		{
			this.a = A_1.a();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
		}

		// Token: 0x06006225 RID: 25125 RVA: 0x003654E4 File Offset: 0x003644E4
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (A_0.j() == null)
			{
				A_0.b(new ane());
			}
			A_0.j().a(this.a);
		}

		// Token: 0x06006226 RID: 25126 RVA: 0x00365520 File Offset: 0x00364520
		internal override bool n2()
		{
			return false;
		}

		// Token: 0x06006227 RID: 25127 RVA: 0x00365534 File Offset: 0x00364534
		internal override ushort n0()
		{
			return 61440;
		}

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06006228 RID: 25128 RVA: 0x0036554C File Offset: 0x0036454C
		// (set) Token: 0x06006229 RID: 25129 RVA: 0x0036556A File Offset: 0x0036456A
		public float Y
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

		// Token: 0x0400328A RID: 12938
		private x5 a;
	}
}
