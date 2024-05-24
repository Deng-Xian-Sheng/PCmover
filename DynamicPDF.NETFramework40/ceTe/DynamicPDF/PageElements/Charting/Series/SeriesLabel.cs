using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C6 RID: 2246
	public class SeriesLabel
	{
		// Token: 0x06005C23 RID: 23587 RVA: 0x00344565 File Offset: 0x00343565
		public SeriesLabel(string text)
		{
			this.a = text;
		}

		// Token: 0x06005C24 RID: 23588 RVA: 0x0034457E File Offset: 0x0034357E
		public SeriesLabel(string text, SeriesNameDisplay seriesNameDisplay)
		{
			this.a = text;
			this.e = seriesNameDisplay;
		}

		// Token: 0x06005C25 RID: 23589 RVA: 0x0034459E File Offset: 0x0034359E
		public SeriesLabel(string text, Font font, SeriesNameDisplay seriesNameDisplay)
		{
			this.a = text;
			this.b = font;
			this.e = seriesNameDisplay;
		}

		// Token: 0x06005C26 RID: 23590 RVA: 0x003445C5 File Offset: 0x003435C5
		public SeriesLabel(string text, Color textColor, Font font, float fontSize)
		{
			this.a = text;
			this.d = textColor;
			this.b = font;
			this.c = fontSize;
		}

		// Token: 0x06005C27 RID: 23591 RVA: 0x003445F4 File Offset: 0x003435F4
		public SeriesLabel(string text, Color textColor, Font font, float fontSize, SeriesNameDisplay seriesNameDisplay)
		{
			this.a = text;
			this.d = textColor;
			this.b = font;
			this.c = fontSize;
			this.e = seriesNameDisplay;
		}

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x06005C28 RID: 23592 RVA: 0x0034462C File Offset: 0x0034362C
		// (set) Token: 0x06005C29 RID: 23593 RVA: 0x00344644 File Offset: 0x00343644
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

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x06005C2A RID: 23594 RVA: 0x00344650 File Offset: 0x00343650
		// (set) Token: 0x06005C2B RID: 23595 RVA: 0x00344668 File Offset: 0x00343668
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

		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x06005C2C RID: 23596 RVA: 0x00344674 File Offset: 0x00343674
		// (set) Token: 0x06005C2D RID: 23597 RVA: 0x0034468C File Offset: 0x0034368C
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

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x06005C2E RID: 23598 RVA: 0x00344698 File Offset: 0x00343698
		// (set) Token: 0x06005C2F RID: 23599 RVA: 0x003446B0 File Offset: 0x003436B0
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

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x06005C30 RID: 23600 RVA: 0x003446BC File Offset: 0x003436BC
		// (set) Token: 0x06005C31 RID: 23601 RVA: 0x003446D4 File Offset: 0x003436D4
		public SeriesNameDisplay DisplayPosition
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

		// Token: 0x06005C32 RID: 23602 RVA: 0x003446E0 File Offset: 0x003436E0
		internal void a(Chart A_0)
		{
			if (this.b == null)
			{
				this.b = A_0.Font;
			}
			if (this.c <= 0f)
			{
				this.c = A_0.FontSize;
			}
			if (this.d == null)
			{
				this.d = A_0.TextColor;
			}
		}

		// Token: 0x06005C33 RID: 23603 RVA: 0x00344744 File Offset: 0x00343744
		internal float a(float A_0)
		{
			return this.b.GetTextLines(this.a.ToCharArray(), A_0, float.MaxValue, this.c).GetTextHeight();
		}

		// Token: 0x06005C34 RID: 23604 RVA: 0x00344780 File Offset: 0x00343780
		internal void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4)
		{
			TextLineList textLines = this.b.GetTextLines(this.a.ToCharArray(), A_3, this.a(A_3), this.c);
			switch (this.e)
			{
			case SeriesNameDisplay.Below:
				textLines.ja(A_0, A_1, A_2 + A_4 - this.a(A_3), TextAlign.Center, this.d, null, 0f, false, false, false);
				break;
			case SeriesNameDisplay.Above:
				textLines.ja(A_0, A_1, A_2, TextAlign.Center, this.d, null, 0f, false, false, false);
				break;
			}
		}

		// Token: 0x04002FE1 RID: 12257
		private string a;

		// Token: 0x04002FE2 RID: 12258
		private Font b;

		// Token: 0x04002FE3 RID: 12259
		private float c;

		// Token: 0x04002FE4 RID: 12260
		private Color d;

		// Token: 0x04002FE5 RID: 12261
		private SeriesNameDisplay e = SeriesNameDisplay.Below;
	}
}
