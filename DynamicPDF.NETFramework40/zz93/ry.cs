using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020002AC RID: 684
	internal class ry : PageNumberingLabel
	{
		// Token: 0x06001E96 RID: 7830 RVA: 0x00135C00 File Offset: 0x00134C00
		internal ry(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x00135C34 File Offset: 0x00134C34
		internal override x5 fa(x5 A_0)
		{
			return w0.c;
		}

		// Token: 0x06001E98 RID: 7832 RVA: 0x00135C4C File Offset: 0x00134C4C
		internal override PageElement fc()
		{
			return new ry(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor)
			{
				Angle = this.Angle,
				VAlign = base.VAlign,
				Underline = base.Underline,
				PageOffset = base.PageOffset,
				PageTotalOffset = base.PageTotalOffset,
				a = this.a
			};
		}

		// Token: 0x06001E99 RID: 7833 RVA: 0x00135CE8 File Offset: 0x00134CE8
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x04000D85 RID: 3461
		private new short a = short.MinValue;
	}
}
