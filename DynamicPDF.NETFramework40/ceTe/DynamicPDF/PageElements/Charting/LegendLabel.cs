using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A7 RID: 1959
	public class LegendLabel
	{
		// Token: 0x06004F3A RID: 20282 RVA: 0x0027AE14 File Offset: 0x00279E14
		internal LegendLabel(string A_0, Font A_1, float A_2, Color A_3, TextAlign A_4)
		{
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.a = A_0;
			this.j = A_4;
			this.g = this.Font.GetTextLines(this.Text.ToCharArray(), 100000f, A_2);
		}

		// Token: 0x06004F3B RID: 20283 RVA: 0x0027AE94 File Offset: 0x00279E94
		internal PlotAreaElement a()
		{
			return this.i;
		}

		// Token: 0x06004F3C RID: 20284 RVA: 0x0027AEAC File Offset: 0x00279EAC
		internal void a(PlotAreaElement A_0)
		{
			this.i = A_0;
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06004F3D RID: 20285 RVA: 0x0027AEB8 File Offset: 0x00279EB8
		// (set) Token: 0x06004F3E RID: 20286 RVA: 0x0027AED0 File Offset: 0x00279ED0
		public TextAlign Align
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x06004F3F RID: 20287 RVA: 0x0027AEDC File Offset: 0x00279EDC
		// (set) Token: 0x06004F40 RID: 20288 RVA: 0x0027AEF4 File Offset: 0x00279EF4
		public string Text
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				this.g.SetText(this.a);
			}
		}

		// Token: 0x06004F41 RID: 20289 RVA: 0x0027AF10 File Offset: 0x00279F10
		internal float b()
		{
			return this.f;
		}

		// Token: 0x06004F42 RID: 20290 RVA: 0x0027AF28 File Offset: 0x00279F28
		internal void a(float A_0)
		{
			this.g.Width = A_0;
			this.f = A_0;
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06004F43 RID: 20291 RVA: 0x0027AF40 File Offset: 0x00279F40
		// (set) Token: 0x06004F44 RID: 20292 RVA: 0x0027AF58 File Offset: 0x00279F58
		public float SymbolWidth
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06004F45 RID: 20293 RVA: 0x0027AF64 File Offset: 0x00279F64
		public float RequiredWidth
		{
			get
			{
				float result;
				if (this.g != null)
				{
					result = this.g.GetMaximumWidth();
				}
				else
				{
					result = 0f;
				}
				return result;
			}
		}

		// Token: 0x06004F46 RID: 20294 RVA: 0x0027AF96 File Offset: 0x00279F96
		internal void b(float A_0)
		{
			this.g.Height = A_0;
		}

		// Token: 0x06004F47 RID: 20295 RVA: 0x0027AFA8 File Offset: 0x00279FA8
		internal float c()
		{
			float result;
			if (this.e)
			{
				result = this.g.GetRequiredHeight(0);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06004F48 RID: 20296 RVA: 0x0027AFDC File Offset: 0x00279FDC
		// (set) Token: 0x06004F49 RID: 20297 RVA: 0x0027AFF4 File Offset: 0x00279FF4
		public bool Visible
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06004F4A RID: 20298 RVA: 0x0027B000 File Offset: 0x0027A000
		// (set) Token: 0x06004F4B RID: 20299 RVA: 0x0027B018 File Offset: 0x0027A018
		public Font Font
		{
			get
			{
				return this.b;
			}
			set
			{
				this.g.Font = value;
				if (value is OpenTypeFont && ((OpenTypeFont)value).UseCharacterShaping)
				{
					this.g = value.a(this.g);
				}
				this.b = value;
			}
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06004F4C RID: 20300 RVA: 0x0027B06C File Offset: 0x0027A06C
		// (set) Token: 0x06004F4D RID: 20301 RVA: 0x0027B084 File Offset: 0x0027A084
		public float FontSize
		{
			get
			{
				return this.c;
			}
			set
			{
				this.g.FontSize = value;
				this.c = value;
			}
		}

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06004F4E RID: 20302 RVA: 0x0027B09C File Offset: 0x0027A09C
		// (set) Token: 0x06004F4F RID: 20303 RVA: 0x0027B0B4 File Offset: 0x0027A0B4
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

		// Token: 0x06004F50 RID: 20304 RVA: 0x0027B0C0 File Offset: 0x0027A0C0
		internal void a(PageWriter A_0, float A_1, float A_2)
		{
			this.g.ja(A_0, A_1, A_2, this.j, this.d, null, 0f, false, false, false);
		}

		// Token: 0x04002AD6 RID: 10966
		private string a;

		// Token: 0x04002AD7 RID: 10967
		private Font b;

		// Token: 0x04002AD8 RID: 10968
		private float c;

		// Token: 0x04002AD9 RID: 10969
		private Color d = null;

		// Token: 0x04002ADA RID: 10970
		private bool e = true;

		// Token: 0x04002ADB RID: 10971
		private float f;

		// Token: 0x04002ADC RID: 10972
		private TextLineList g;

		// Token: 0x04002ADD RID: 10973
		private float h = 0f;

		// Token: 0x04002ADE RID: 10974
		private PlotAreaElement i;

		// Token: 0x04002ADF RID: 10975
		private TextAlign j = TextAlign.Left;
	}
}
