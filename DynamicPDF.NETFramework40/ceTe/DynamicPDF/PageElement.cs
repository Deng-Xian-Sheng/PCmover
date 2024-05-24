using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000382 RID: 898
	[Serializable]
	public abstract class PageElement : ISerializable
	{
		// Token: 0x0600262D RID: 9773 RVA: 0x00163698 File Offset: 0x00162698
		protected PageElement()
		{
		}

		// Token: 0x0600262E RID: 9774 RVA: 0x001636B8 File Offset: 0x001626B8
		protected PageElement(SerializationInfo info, StreamingContext context)
		{
			this.a = info.GetString("id");
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600262F RID: 9775 RVA: 0x001636EC File Offset: 0x001626EC
		// (set) Token: 0x06002630 RID: 9776 RVA: 0x00163704 File Offset: 0x00162704
		public string ID
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

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06002631 RID: 9777 RVA: 0x00163710 File Offset: 0x00162710
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RequiredLicenseLevel
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06002632 RID: 9778
		public abstract void Draw(PageWriter writer);

		// Token: 0x06002633 RID: 9779 RVA: 0x00163728 File Offset: 0x00162728
		internal virtual x5 b7()
		{
			return x5.a();
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x00163740 File Offset: 0x00162740
		internal virtual x5 b8()
		{
			return x5.b();
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x00163758 File Offset: 0x00162758
		internal virtual bool fe()
		{
			return false;
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x0016376C File Offset: 0x0016276C
		internal virtual bool gg()
		{
			return false;
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x00163780 File Offset: 0x00162780
		internal virtual bool gf()
		{
			return false;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x00163794 File Offset: 0x00162794
		internal virtual short fd()
		{
			return short.MinValue;
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x001637AC File Offset: 0x001627AC
		internal virtual byte cb()
		{
			return 0;
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x001637C0 File Offset: 0x001627C0
		internal virtual bool b4()
		{
			return false;
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x001637D3 File Offset: 0x001627D3
		internal void a(FormFieldOutput A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x001637E0 File Offset: 0x001627E0
		internal FormFieldOutput n()
		{
			return this.c;
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x001637F8 File Offset: 0x001627F8
		internal void o()
		{
			this.b = 0;
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x00163802 File Offset: 0x00162802
		internal void d(int A_0)
		{
			this.b |= A_0;
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x00163813 File Offset: 0x00162813
		internal virtual void b9(x5 A_0)
		{
		}

		// Token: 0x06002640 RID: 9792 RVA: 0x00163816 File Offset: 0x00162816
		internal virtual void ca(x5 A_0)
		{
		}

		// Token: 0x06002641 RID: 9793 RVA: 0x00163819 File Offset: 0x00162819
		internal virtual void b5(dv A_0)
		{
		}

		// Token: 0x06002642 RID: 9794 RVA: 0x0016381C File Offset: 0x0016281C
		internal virtual void b6(acw A_0)
		{
		}

		// Token: 0x06002643 RID: 9795 RVA: 0x0016381F File Offset: 0x0016281F
		internal virtual PageElement fb(x5 A_0)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x0016382C File Offset: 0x0016282C
		internal virtual x5 fa(x5 A_0)
		{
			return al1.d;
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x00163843 File Offset: 0x00162843
		internal virtual void ge(xg A_0)
		{
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x00163846 File Offset: 0x00162846
		internal virtual void a(ceTe.DynamicPDF.ReportWriter.IO.LayoutWriter A_0, bool A_1, bool A_2)
		{
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x00163849 File Offset: 0x00162849
		internal virtual void nq(amk A_0)
		{
		}

		// Token: 0x06002648 RID: 9800 RVA: 0x0016384C File Offset: 0x0016284C
		internal virtual void a(ceTe.DynamicPDF.LayoutEngine.LayoutWriter A_0, bool A_1, bool A_2)
		{
		}

		// Token: 0x06002649 RID: 9801 RVA: 0x0016384F File Offset: 0x0016284F
		internal virtual PageElement fc()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x0600264A RID: 9802 RVA: 0x0016385C File Offset: 0x0016285C
		[SecurityCritical]
		void ISerializable.a(SerializationInfo A_0, StreamingContext A_1)
		{
			A_0.AddValue("id", this.a);
		}

		// Token: 0x040010B1 RID: 4273
		private string a = null;

		// Token: 0x040010B2 RID: 4274
		private int b = 1;

		// Token: 0x040010B3 RID: 4275
		private FormFieldOutput c = FormFieldOutput.Inherit;
	}
}
