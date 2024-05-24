using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200094E RID: 2382
	public class PageBreak : LayoutElement
	{
		// Token: 0x060060E9 RID: 24809 RVA: 0x0036256E File Offset: 0x0036156E
		internal PageBreak(alo A_0, ala A_1)
		{
			this.a = A_1.a();
			A_0.b().DocumentLayout.a(A_1.mu(), this);
		}

		// Token: 0x060060EA RID: 24810 RVA: 0x003625A0 File Offset: 0x003615A0
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			if (A_0.i() == null)
			{
				A_0.a(new ane());
			}
			A_0.i().a(this.a);
		}

		// Token: 0x060060EB RID: 24811 RVA: 0x003625DC File Offset: 0x003615DC
		internal override bool n2()
		{
			return false;
		}

		// Token: 0x060060EC RID: 24812 RVA: 0x003625F0 File Offset: 0x003615F0
		internal override ushort n0()
		{
			return 61440;
		}

		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x060060ED RID: 24813 RVA: 0x00362608 File Offset: 0x00361608
		// (set) Token: 0x060060EE RID: 24814 RVA: 0x00362626 File Offset: 0x00361626
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

		// Token: 0x04003211 RID: 12817
		private x5 a;
	}
}
