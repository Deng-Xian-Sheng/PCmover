using System;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger.Forms;

namespace zz93
{
	// Token: 0x020003F9 RID: 1017
	internal class aal : FormField
	{
		// Token: 0x06002A6E RID: 10862 RVA: 0x0018A97B File Offset: 0x0018997B
		internal aal(PdfFormField A_0) : base(A_0.Name, A_0.Flags, null)
		{
			this.a = A_0;
			base.IsAnnotation = A_0.w();
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x0018A9A8 File Offset: 0x001899A8
		internal override PdfFormField hb()
		{
			return this.a;
		}

		// Token: 0x0400137E RID: 4990
		private new PdfFormField a;
	}
}
