using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020005CD RID: 1485
	internal class am4 : Label, rv
	{
		// Token: 0x06003AD0 RID: 15056 RVA: 0x001F9490 File Offset: 0x001F8490
		internal am4(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8, bool A_9) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
			this.b = A_9;
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x001F94D0 File Offset: 0x001F84D0
		internal am4(char[] A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8, bool A_9) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
			this.b = A_9;
		}

		// Token: 0x06003AD2 RID: 15058 RVA: 0x001F9510 File Offset: 0x001F8510
		internal override x5 fa(x5 A_0)
		{
			return al1.c;
		}

		// Token: 0x06003AD3 RID: 15059 RVA: 0x001F9528 File Offset: 0x001F8528
		internal override PageElement fc()
		{
			return new am4(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor, this.b)
			{
				VAlign = base.VAlign,
				Underline = base.Underline,
				RightToLeft = base.RightToLeft,
				a = this.a
			};
		}

		// Token: 0x06003AD4 RID: 15060 RVA: 0x001F95B0 File Offset: 0x001F85B0
		void rv.a(char[] A_0, bool A_1)
		{
			this.b = bool.Parse(new string(A_0));
		}

		// Token: 0x06003AD5 RID: 15061 RVA: 0x001F95C4 File Offset: 0x001F85C4
		protected override void DrawRotated(PageWriter writer)
		{
			if (this.b)
			{
				base.DrawRotated(writer);
			}
		}

		// Token: 0x06003AD6 RID: 15062 RVA: 0x001F95E8 File Offset: 0x001F85E8
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06003AD7 RID: 15063 RVA: 0x001F9600 File Offset: 0x001F8600
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003AD8 RID: 15064 RVA: 0x001F960A File Offset: 0x001F860A
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04001BC5 RID: 7109
		private new short a = short.MinValue;

		// Token: 0x04001BC6 RID: 7110
		private bool b = false;
	}
}
