using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000765 RID: 1893
	public abstract class UpcBase : BarCode
	{
		// Token: 0x06004CE5 RID: 19685 RVA: 0x0026E229 File Offset: 0x0026D229
		protected UpcBase(string value, float x, float y) : base(value, x, y, 72f, 1f)
		{
		}

		// Token: 0x06004CE6 RID: 19686 RVA: 0x0026E241 File Offset: 0x0026D241
		protected UpcBase(string value, float x, float y, float scale) : base(value, x, y, 72f * scale, 1f * scale)
		{
		}

		// Token: 0x06004CE7 RID: 19687 RVA: 0x0026E25F File Offset: 0x0026D25F
		public void SetScale(float scale)
		{
			this.Height = 72f * scale;
			this.XDimension = scale;
		}

		// Token: 0x06004CE8 RID: 19688 RVA: 0x0026E278 File Offset: 0x0026D278
		internal float c()
		{
			return this.XDimension * 12f;
		}

		// Token: 0x06004CE9 RID: 19689 RVA: 0x0026E298 File Offset: 0x0026D298
		internal float d()
		{
			return this.Y + this.Height;
		}

		// Token: 0x06004CEA RID: 19690 RVA: 0x0026E2B8 File Offset: 0x0026D2B8
		internal float e()
		{
			return this.Y + this.XDimension * 12f * 0.64f;
		}

		// Token: 0x06004CEB RID: 19691 RVA: 0x0026E2E4 File Offset: 0x0026D2E4
		internal float f()
		{
			return this.Height - this.XDimension * 12f * 0.72f;
		}

		// Token: 0x06004CEC RID: 19692 RVA: 0x0026E310 File Offset: 0x0026D310
		internal float g()
		{
			return this.Height - this.XDimension * 12f * 0.36f;
		}

		// Token: 0x06004CED RID: 19693 RVA: 0x0026E33C File Offset: 0x0026D33C
		internal float h()
		{
			return this.f() - this.XDimension * 12f * 0.72f;
		}

		// Token: 0x06004CEE RID: 19694 RVA: 0x0026E368 File Offset: 0x0026D368
		internal float i()
		{
			return this.Y + this.XDimension * 12f * 0.72f;
		}

		// Token: 0x06004CEF RID: 19695 RVA: 0x0026E394 File Offset: 0x0026D394
		internal void a(PageWriter A_0, char[] A_1, float A_2, float A_3)
		{
			A_0.SetGraphicsMode();
			float num = this.i() + A_3;
			float num2 = this.h() - A_3;
			ba ba = new ba();
			BitArray bitArray = ba.a(A_1);
			int a_ = 47 * base.PixelsPerXDimension;
			int a_2 = 1;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_2);
			A_0.a(A_2, num + num2, 47f * this.XDimension, num2, a_, 1, a_3);
		}

		// Token: 0x06004CF0 RID: 19696 RVA: 0x0026E414 File Offset: 0x0026D414
		internal void b(PageWriter A_0, char[] A_1, float A_2, float A_3)
		{
			A_0.SetGraphicsMode();
			float num = this.i() + A_3;
			float num2 = this.h() - A_3;
			a9 a = new a9();
			BitArray bitArray = a.a(A_1);
			int a_ = 20 * base.PixelsPerXDimension;
			int a_2 = 1;
			byte[] a_3 = BarCode.a(bitArray, base.PixelsPerXDimension, 1, bitArray.Length, a_2);
			A_0.a(A_2, num + num2, 20f * this.XDimension, num2, a_, 1, a_3);
		}

		// Token: 0x06004CF1 RID: 19697 RVA: 0x0026E492 File Offset: 0x0026D492
		internal void c(PageWriter A_0, char[] A_1, float A_2, float A_3)
		{
			A_0.SetTextMode();
			A_0.SetFont(Font.CourierBold, this.c());
			A_0.Write_Tm(A_2, this.e() + A_3);
			A_0.Write_Tj_(A_1, 0, 5, false);
		}

		// Token: 0x06004CF2 RID: 19698 RVA: 0x0026E4CA File Offset: 0x0026D4CA
		internal void d(PageWriter A_0, char[] A_1, float A_2, float A_3)
		{
			A_0.SetTextMode();
			A_0.SetFont(Font.CourierBold, this.c());
			A_0.Write_Tm(A_2, this.e() + A_3);
			A_0.b(A_1, 0, 2, false);
		}

		// Token: 0x06004CF3 RID: 19699 RVA: 0x0026E502 File Offset: 0x0026D502
		internal void a(PageWriter A_0, char[] A_1, float A_2, float A_3, float A_4)
		{
			A_0.SetTextMode();
			A_0.SetFont(Font.CourierBold, A_4);
			A_0.Write_Tm(A_2, A_3);
			A_0.Write_Tj_(A_1, false);
		}

		// Token: 0x06004CF4 RID: 19700 RVA: 0x0026E52D File Offset: 0x0026D52D
		internal void a(PageWriter A_0, TextLineList A_1, float A_2, float A_3)
		{
			A_0.SetTextMode();
			A_1.g();
			A_1.Draw(A_0, A_2, A_3, TextAlign.Left, base.Color, false, false);
		}
	}
}
