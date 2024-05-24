using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x02000383 RID: 899
	internal class xl : Label
	{
		// Token: 0x0600264B RID: 9803 RVA: 0x00163874 File Offset: 0x00162874
		internal xl(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
		}

		// Token: 0x0600264C RID: 9804 RVA: 0x001638A4 File Offset: 0x001628A4
		internal override x5 fa(x5 A_0)
		{
			return w0.c;
		}

		// Token: 0x0600264D RID: 9805 RVA: 0x001638BC File Offset: 0x001628BC
		internal override PageElement fc()
		{
			return new xl(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor)
			{
				VAlign = base.VAlign,
				Underline = base.Underline,
				RightToLeft = base.RightToLeft,
				a = this.a
			};
		}

		// Token: 0x0600264E RID: 9806 RVA: 0x00163940 File Offset: 0x00162940
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x0600264F RID: 9807 RVA: 0x00163958 File Offset: 0x00162958
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x040010B4 RID: 4276
		private new short a = short.MinValue;
	}
}
