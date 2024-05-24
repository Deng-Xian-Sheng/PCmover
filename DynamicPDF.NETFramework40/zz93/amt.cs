using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005C2 RID: 1474
	internal class amt : Label
	{
		// Token: 0x06003A60 RID: 14944 RVA: 0x001F5298 File Offset: 0x001F4298
		internal amt(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
		}

		// Token: 0x06003A61 RID: 14945 RVA: 0x001F52C8 File Offset: 0x001F42C8
		internal override x5 fa(x5 A_0)
		{
			return al1.c;
		}

		// Token: 0x06003A62 RID: 14946 RVA: 0x001F52E0 File Offset: 0x001F42E0
		internal override PageElement fc()
		{
			return new amt(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor)
			{
				VAlign = base.VAlign,
				Underline = base.Underline,
				RightToLeft = base.RightToLeft,
				a = this.a
			};
		}

		// Token: 0x06003A63 RID: 14947 RVA: 0x001F5364 File Offset: 0x001F4364
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06003A64 RID: 14948 RVA: 0x001F537C File Offset: 0x001F437C
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x04001BA1 RID: 7073
		private new short a = short.MinValue;
	}
}
