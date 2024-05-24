using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000652 RID: 1618
	public class AutoGradient : Gradient
	{
		// Token: 0x06003D4B RID: 15691 RVA: 0x0021448D File Offset: 0x0021348D
		public AutoGradient(float angle, RgbColor color1, RgbColor color2) : base(0f, 0f, 0f, 0f, color1, color2)
		{
			this.a = angle;
		}

		// Token: 0x06003D4C RID: 15692 RVA: 0x002144B5 File Offset: 0x002134B5
		public AutoGradient(float angle, CmykColor color1, CmykColor color2) : base(0f, 0f, 0f, 0f, color1, color2)
		{
			this.a = angle;
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x002144DD File Offset: 0x002134DD
		public AutoGradient(float angle, Grayscale color1, Grayscale color2) : base(0f, 0f, 0f, 0f, color1, color2)
		{
			this.a = angle;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06003D4E RID: 15694 RVA: 0x00214508 File Offset: 0x00213508
		// (set) Token: 0x06003D4F RID: 15695 RVA: 0x00214520 File Offset: 0x00213520
		public float Angle
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

		// Token: 0x06003D50 RID: 15696 RVA: 0x0021452C File Offset: 0x0021352C
		public override void DrawFill(PageWriter writer)
		{
			if (writer.e() == null)
			{
				writer.a(new cj(this, null));
			}
			else
			{
				writer.e().b(this);
			}
			base.DrawFill(writer);
		}

		// Token: 0x06003D51 RID: 15697 RVA: 0x00214574 File Offset: 0x00213574
		public override void DrawStroke(PageWriter writer)
		{
			if (writer.e() == null)
			{
				writer.a(new cj(null, this));
			}
			else
			{
				writer.e().c(this);
			}
			base.DrawStroke(writer);
		}

		// Token: 0x06003D52 RID: 15698 RVA: 0x002145BC File Offset: 0x002135BC
		internal override RgbColor m()
		{
			RgbColor rgbColor = base.Color1.m();
			RgbColor rgbColor2 = base.Color2.m();
			float num = rgbColor.R + rgbColor2.R;
			float num2 = rgbColor.G + rgbColor2.G;
			float num3 = rgbColor.B + rgbColor2.B;
			num /= 2f;
			num2 /= 2f;
			num3 /= 2f;
			return new RgbColor(num, num2, num3);
		}

		// Token: 0x04002101 RID: 8449
		private new float a;
	}
}
