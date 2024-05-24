using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x02000797 RID: 1943
	public class PercentageDataLabel : XYDataLabel
	{
		// Token: 0x06004E78 RID: 20088 RVA: 0x00276333 File Offset: 0x00275333
		public PercentageDataLabel(bool showValue)
		{
			this.a = showValue;
		}

		// Token: 0x06004E79 RID: 20089 RVA: 0x00276345 File Offset: 0x00275345
		public PercentageDataLabel(bool showValue, bool showSeries)
		{
			this.a = showValue;
			this.d = showSeries;
		}

		// Token: 0x06004E7A RID: 20090 RVA: 0x0027635E File Offset: 0x0027535E
		public PercentageDataLabel(bool showValue, bool showPosition, bool showSeries)
		{
			this.a = showValue;
			this.c = showPosition;
			this.d = showSeries;
		}

		// Token: 0x06004E7B RID: 20091 RVA: 0x0027637E File Offset: 0x0027537E
		public PercentageDataLabel(bool showValue, bool showPercentage, bool showPosition, bool showSeries)
		{
			this.a = showValue;
			this.b = showPercentage;
			this.c = showPosition;
			this.d = showSeries;
		}

		// Token: 0x06004E7C RID: 20092 RVA: 0x002763A6 File Offset: 0x002753A6
		public PercentageDataLabel(Font font, float fontSize, Color color, bool showValue)
		{
			base.Font = font;
			base.FontSize = fontSize;
			base.Color = color;
			this.a = showValue;
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06004E7D RID: 20093 RVA: 0x002763D4 File Offset: 0x002753D4
		// (set) Token: 0x06004E7E RID: 20094 RVA: 0x002763EC File Offset: 0x002753EC
		public bool ShowValue
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

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06004E7F RID: 20095 RVA: 0x002763F8 File Offset: 0x002753F8
		// (set) Token: 0x06004E80 RID: 20096 RVA: 0x00276410 File Offset: 0x00275410
		public bool ShowPercentage
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

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06004E81 RID: 20097 RVA: 0x0027641C File Offset: 0x0027541C
		// (set) Token: 0x06004E82 RID: 20098 RVA: 0x00276434 File Offset: 0x00275434
		public bool ShowPosition
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

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06004E83 RID: 20099 RVA: 0x00276440 File Offset: 0x00275440
		// (set) Token: 0x06004E84 RID: 20100 RVA: 0x00276458 File Offset: 0x00275458
		public bool ShowSeries
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

		// Token: 0x04002A63 RID: 10851
		private new bool a;

		// Token: 0x04002A64 RID: 10852
		private bool b;

		// Token: 0x04002A65 RID: 10853
		private bool c;

		// Token: 0x04002A66 RID: 10854
		private bool d;
	}
}
