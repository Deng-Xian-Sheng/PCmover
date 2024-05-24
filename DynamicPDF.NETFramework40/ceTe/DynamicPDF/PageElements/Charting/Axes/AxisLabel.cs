using System;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B5 RID: 1973
	public abstract class AxisLabel
	{
		// Token: 0x06005040 RID: 20544 RVA: 0x0027F902 File Offset: 0x0027E902
		internal AxisLabel(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005041 RID: 20545 RVA: 0x0027F91B File Offset: 0x0027E91B
		internal AxisLabel(string A_0, Font A_1, float A_2, Color A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06005042 RID: 20546 RVA: 0x0027F94C File Offset: 0x0027E94C
		// (set) Token: 0x06005043 RID: 20547 RVA: 0x0027F964 File Offset: 0x0027E964
		public string Text
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

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06005044 RID: 20548 RVA: 0x0027F970 File Offset: 0x0027E970
		// (set) Token: 0x06005045 RID: 20549 RVA: 0x0027F988 File Offset: 0x0027E988
		public Font Font
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06005046 RID: 20550 RVA: 0x0027F994 File Offset: 0x0027E994
		// (set) Token: 0x06005047 RID: 20551 RVA: 0x0027F9AC File Offset: 0x0027E9AC
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06005048 RID: 20552 RVA: 0x0027F9B8 File Offset: 0x0027E9B8
		// (set) Token: 0x06005049 RID: 20553 RVA: 0x0027F9D0 File Offset: 0x0027E9D0
		public Color TextColor
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x0600504A RID: 20554 RVA: 0x0027F9DA File Offset: 0x0027E9DA
		internal void a(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x0600504B RID: 20555 RVA: 0x0027F9E4 File Offset: 0x0027E9E4
		internal double a(float A_0, float A_1)
		{
			return (double)(Math.Abs(A_0) * this.h + this.g * Math.Abs(A_1));
		}

		// Token: 0x0600504C RID: 20556 RVA: 0x0027FA20 File Offset: 0x0027EA20
		internal float a(bool A_0, float A_1)
		{
			if (this.g <= 0f)
			{
				this.g = this.Font.GetTextWidth(this.Text.ToCharArray(), this.c);
				if (A_1 != -3.4028235E+38f && this.g > A_1)
				{
					this.g = A_1;
				}
			}
			if (this.h <= 0f)
			{
				this.e = this.Font.GetTextLines(this.Text.ToCharArray(), this.g, float.MaxValue, this.c);
				if (A_0)
				{
					this.h = this.e.GetRequiredHeight(0);
				}
				else
				{
					this.h = this.e.GetTextHeight(1);
				}
			}
			return this.g;
		}

		// Token: 0x0600504D RID: 20557 RVA: 0x0027FAFE File Offset: 0x0027EAFE
		internal void b(float A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600504E RID: 20558 RVA: 0x0027FB08 File Offset: 0x0027EB08
		internal float b(bool A_0, float A_1)
		{
			if (this.g <= 0f)
			{
				if (A_1 != -3.4028235E+38f)
				{
					this.g = A_1;
				}
				else
				{
					this.g = this.i;
				}
			}
			if (this.h <= 0f)
			{
				this.e = this.Font.GetTextLines(this.Text.ToCharArray(), this.g, float.MaxValue, this.c);
				if (A_0)
				{
					this.h = this.e.GetRequiredHeight(0);
				}
				else
				{
					this.h = this.e.GetTextHeight(1);
				}
			}
			return this.h;
		}

		// Token: 0x0600504F RID: 20559 RVA: 0x0027FBC2 File Offset: 0x0027EBC2
		internal void c(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06005050 RID: 20560 RVA: 0x0027FBCC File Offset: 0x0027EBCC
		internal float b()
		{
			return this.g;
		}

		// Token: 0x06005051 RID: 20561 RVA: 0x0027FBE4 File Offset: 0x0027EBE4
		internal float c()
		{
			return this.h;
		}

		// Token: 0x06005052 RID: 20562 RVA: 0x0027FBFC File Offset: 0x0027EBFC
		internal float d()
		{
			return this.h / 2f;
		}

		// Token: 0x06005053 RID: 20563 RVA: 0x0027FC1C File Offset: 0x0027EC1C
		internal TextLineList e()
		{
			return this.e;
		}

		// Token: 0x06005054 RID: 20564 RVA: 0x0027FC34 File Offset: 0x0027EC34
		internal float a(int A_0, float A_1)
		{
			float result = 0f;
			if (A_0 == 90 || A_0 == 270)
			{
				result = this.h / 2f;
			}
			else if (A_0 == 180 || A_0 == 0 || A_0 == 360)
			{
				if (this.g > this.b.GetTextWidth(this.a, this.c))
				{
					result = this.b.GetTextWidth(this.a, this.c) / 2f;
				}
				else
				{
					result = this.g / 2f;
				}
			}
			else if ((A_0 > 0 && A_0 < 90) || (A_0 > 180 && A_0 < 270))
			{
				result = Math.Abs(A_1) * this.h;
			}
			else if ((A_0 > 90 && A_0 < 180) || (A_0 > 270 && A_0 < 360))
			{
				if (this.g > this.b.GetTextWidth(this.a, this.c))
				{
					result = Math.Abs(A_1) * this.b.GetTextWidth(this.a, this.c);
				}
				else
				{
					result = Math.Abs(A_1) * this.g;
				}
			}
			return result;
		}

		// Token: 0x06005055 RID: 20565 RVA: 0x0027FDAC File Offset: 0x0027EDAC
		internal float a(int A_0, float A_1, float A_2)
		{
			float result = 0f;
			if (A_0 == 90 || A_0 == 270)
			{
				result = this.h / 2f;
			}
			else if (A_0 == 180 || A_0 == 0 || A_0 == 360)
			{
				if (this.g > this.b.GetTextWidth(this.a, this.c))
				{
					result = this.b.GetTextWidth(this.a, this.c) / 2f;
				}
				else
				{
					result = this.g / 2f;
				}
			}
			else if ((A_0 > 0 && A_0 < 90) || (A_0 > 180 && A_0 < 270))
			{
				if (this.g > this.b.GetTextWidth(this.a, this.c))
				{
					result = Math.Abs(A_1) * this.b.GetTextWidth(this.a, this.c);
				}
				else
				{
					result = Math.Abs(A_1) * this.g;
				}
			}
			else if ((A_0 > 90 && A_0 < 180) || (A_0 > 270 && A_0 < 360))
			{
				result = Math.Abs(A_2) * this.h;
			}
			return result;
		}

		// Token: 0x06005056 RID: 20566 RVA: 0x0027FF24 File Offset: 0x0027EF24
		internal bool f()
		{
			return this.f;
		}

		// Token: 0x06005057 RID: 20567 RVA: 0x0027FF3C File Offset: 0x0027EF3C
		internal void a(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x04002B39 RID: 11065
		private string a;

		// Token: 0x04002B3A RID: 11066
		private Font b;

		// Token: 0x04002B3B RID: 11067
		private float c;

		// Token: 0x04002B3C RID: 11068
		private Color d;

		// Token: 0x04002B3D RID: 11069
		private TextLineList e;

		// Token: 0x04002B3E RID: 11070
		private bool f = false;

		// Token: 0x04002B3F RID: 11071
		private float g;

		// Token: 0x04002B40 RID: 11072
		private float h;

		// Token: 0x04002B41 RID: 11073
		private float i;
	}
}
