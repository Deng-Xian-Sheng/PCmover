using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;

namespace zz93
{
	// Token: 0x0200059B RID: 1435
	internal class alr : LayoutWriter
	{
		// Token: 0x0600390D RID: 14605 RVA: 0x001EA4A6 File Offset: 0x001E94A6
		internal alr(Document A_0, DocumentLayout A_1, LayoutData A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.g = new DataProviderStack(A_1, A_2);
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x001EA4E0 File Offset: 0x001E94E0
		internal override void m3()
		{
			DocumentLayoutPartList layoutParts = this.b.LayoutParts;
			if (layoutParts.a())
			{
				this.d = new aig();
				this.c = new aie(layoutParts);
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				layoutParts[i].m0(this);
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				ahs ahs = ((alo)layoutParts[i]).a();
				if (ahs != null && ahs.b() > 0)
				{
					ahs.c(this);
				}
			}
			for (int i = 0; i < layoutParts.Count; i++)
			{
				if (layoutParts[i] is FixedPage)
				{
					FixedPage fixedPage = (FixedPage)layoutParts[i];
					if (fixedPage.g() != null)
					{
						fixedPage.g().a(this, false);
					}
				}
			}
		}

		// Token: 0x0600390F RID: 14607 RVA: 0x001EA5F4 File Offset: 0x001E95F4
		internal override aie m4()
		{
			return this.c;
		}

		// Token: 0x06003910 RID: 14608 RVA: 0x001EA60C File Offset: 0x001E960C
		internal override aig m5()
		{
			return this.d;
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x001EA624 File Offset: 0x001E9624
		internal DateTime a()
		{
			return this.e;
		}

		// Token: 0x06003912 RID: 14610 RVA: 0x001EA63C File Offset: 0x001E963C
		public override DataProviderStack get_Data()
		{
			return this.g;
		}

		// Token: 0x06003913 RID: 14611 RVA: 0x001EA654 File Offset: 0x001E9654
		public override Document get_Document()
		{
			return this.a;
		}

		// Token: 0x06003914 RID: 14612 RVA: 0x001EA66C File Offset: 0x001E966C
		internal override anf m6()
		{
			return null;
		}

		// Token: 0x06003915 RID: 14613 RVA: 0x001EA680 File Offset: 0x001E9680
		public override DocumentLayout get_DocumentLayout()
		{
			return this.b;
		}

		// Token: 0x06003916 RID: 14614 RVA: 0x001EA698 File Offset: 0x001E9698
		internal override AlternateRow m7()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06003917 RID: 14615 RVA: 0x001EA6A5 File Offset: 0x001E96A5
		internal override void m8(AlternateRow A_0)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06003918 RID: 14616 RVA: 0x001EA6B2 File Offset: 0x001E96B2
		internal override void m9()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06003919 RID: 14617 RVA: 0x001EA6BF File Offset: 0x001E96BF
		internal override float na()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x0600391A RID: 14618 RVA: 0x001EA6CC File Offset: 0x001E96CC
		internal override am5 nb()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x0600391B RID: 14619 RVA: 0x001EA6DC File Offset: 0x001E96DC
		internal override alr nc()
		{
			return this;
		}

		// Token: 0x0600391C RID: 14620 RVA: 0x001EA6F0 File Offset: 0x001E96F0
		internal int b()
		{
			return this.f;
		}

		// Token: 0x0600391D RID: 14621 RVA: 0x001EA708 File Offset: 0x001E9708
		internal void a(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x04001B30 RID: 6960
		private Document a;

		// Token: 0x04001B31 RID: 6961
		private DocumentLayout b;

		// Token: 0x04001B32 RID: 6962
		private aie c;

		// Token: 0x04001B33 RID: 6963
		private aig d;

		// Token: 0x04001B34 RID: 6964
		private DateTime e = DateTime.Now;

		// Token: 0x04001B35 RID: 6965
		private int f = -1;

		// Token: 0x04001B36 RID: 6966
		private DataProviderStack g;
	}
}
