using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace zz93
{
	// Token: 0x020002AE RID: 686
	internal class rz : Label, rv
	{
		// Token: 0x06001EBB RID: 7867 RVA: 0x001362BC File Offset: 0x001352BC
		internal rz(string A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8, bool A_9) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
			this.b = A_9;
		}

		// Token: 0x06001EBC RID: 7868 RVA: 0x001362FC File Offset: 0x001352FC
		internal rz(char[] A_0, float A_1, float A_2, float A_3, float A_4, Font A_5, float A_6, TextAlign A_7, Color A_8, bool A_9) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8)
		{
			this.b = A_9;
		}

		// Token: 0x06001EBD RID: 7869 RVA: 0x0013633C File Offset: 0x0013533C
		internal override x5 fa(x5 A_0)
		{
			return w0.c;
		}

		// Token: 0x06001EBE RID: 7870 RVA: 0x00136354 File Offset: 0x00135354
		internal override PageElement fc()
		{
			return new rz(base.Text, this.X, this.Y, base.Width, this.Height, base.Font, base.FontSize, base.Align, base.TextColor, this.b)
			{
				VAlign = base.VAlign,
				Underline = base.Underline,
				RightToLeft = base.RightToLeft,
				a = this.a
			};
		}

		// Token: 0x06001EBF RID: 7871 RVA: 0x001363DC File Offset: 0x001353DC
		void rv.a(char[] A_0, bool A_1)
		{
			this.b = bool.Parse(new string(A_0));
		}

		// Token: 0x06001EC0 RID: 7872 RVA: 0x001363F0 File Offset: 0x001353F0
		protected override void DrawRotated(PageWriter writer)
		{
			if (this.b)
			{
				base.DrawRotated(writer);
			}
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x00136414 File Offset: 0x00135414
		internal override short fd()
		{
			return this.a;
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x0013642C File Offset: 0x0013542C
		internal void a(short A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x00136436 File Offset: 0x00135436
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04000D97 RID: 3479
		private new short a = short.MinValue;

		// Token: 0x04000D98 RID: 3480
		private bool b = false;
	}
}
