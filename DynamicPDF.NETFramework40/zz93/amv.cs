using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005C4 RID: 1476
	internal class amv : PageNumberingLabel
	{
		// Token: 0x06003A71 RID: 14961 RVA: 0x001F5648 File Offset: 0x001F4648
		internal amv(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x001F567C File Offset: 0x001F467C
		internal override x5 fa(x5 A_0)
		{
			return al1.c;
		}

		// Token: 0x06003A73 RID: 14963 RVA: 0x001F5694 File Offset: 0x001F4694
		internal override PageElement fc()
		{
			return new amv(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor)
			{
				Angle = this.Angle,
				VAlign = base.VAlign,
				Underline = base.Underline,
				PageOffset = base.PageOffset,
				PageTotalOffset = base.PageTotalOffset,
				a = this.a
			};
		}

		// Token: 0x06003A74 RID: 14964 RVA: 0x001F5730 File Offset: 0x001F4730
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x04001BA3 RID: 7075
		private new short a = short.MinValue;
	}
}
