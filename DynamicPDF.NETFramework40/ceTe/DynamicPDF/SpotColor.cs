using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B1 RID: 1713
	public class SpotColor : Color
	{
		// Token: 0x060041F6 RID: 16886 RVA: 0x002265C3 File Offset: 0x002255C3
		public SpotColor(float tint, SpotColorInk ink)
		{
			this.a = tint;
			this.b = ink;
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x060041F7 RID: 16887 RVA: 0x002265DC File Offset: 0x002255DC
		public override ColorSpace ColorSpace
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x060041F8 RID: 16888 RVA: 0x002265F4 File Offset: 0x002255F4
		public float Tint
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x060041F9 RID: 16889 RVA: 0x0022660C File Offset: 0x0022560C
		public override bool Equals(object obj)
		{
			return obj is SpotColor && this.a == ((SpotColor)obj).a && this.b.Name == ((SpotColor)obj).b.Name && this.b.AlternateColor.Equals(((SpotColor)obj).b.AlternateColor);
		}

		// Token: 0x060041FA RID: 16890 RVA: 0x00226680 File Offset: 0x00225680
		public override int GetHashCode()
		{
			return this.a.GetHashCode() ^ this.b.GetHashCode();
		}

		// Token: 0x060041FB RID: 16891 RVA: 0x002266A9 File Offset: 0x002256A9
		public override void DrawStroke(PageWriter writer)
		{
			writer.SetStrokeColorSpace(this.b);
			writer.Write_SCN(this);
		}

		// Token: 0x060041FC RID: 16892 RVA: 0x002266C1 File Offset: 0x002256C1
		public override void DrawFill(PageWriter writer)
		{
			writer.SetFillColorSpace(this.b);
			writer.Write_scn_(this);
		}

		// Token: 0x060041FD RID: 16893 RVA: 0x002266DC File Offset: 0x002256DC
		internal override RgbColor m()
		{
			float num = this.b.AlternateColor.C;
			float num2 = this.b.AlternateColor.M;
			float num3 = this.b.AlternateColor.Y;
			float num4 = this.b.AlternateColor.K;
			float num5 = this.Tint;
			if (num5 <= 0f)
			{
				num5 = 0f;
			}
			else if (num5 >= 0f)
			{
				num5 = 1f;
			}
			num *= num5;
			num2 *= num5;
			num3 *= num5;
			num4 *= num5;
			CmykColor cmykColor = new CmykColor(num, num2, num3, num4);
			return cmykColor.m();
		}

		// Token: 0x040024A3 RID: 9379
		private new float a;

		// Token: 0x040024A4 RID: 9380
		private new SpotColorInk b;
	}
}
