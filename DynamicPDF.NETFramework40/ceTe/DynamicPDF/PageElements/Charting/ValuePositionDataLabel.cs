using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x02000799 RID: 1945
	public class ValuePositionDataLabel : XYDataLabel
	{
		// Token: 0x06004E8C RID: 20108 RVA: 0x002764EE File Offset: 0x002754EE
		public ValuePositionDataLabel(bool showValue)
		{
			this.a = showValue;
		}

		// Token: 0x06004E8D RID: 20109 RVA: 0x00276500 File Offset: 0x00275500
		public ValuePositionDataLabel(bool showValue, bool showSeries)
		{
			this.a = showValue;
			this.c = showSeries;
		}

		// Token: 0x06004E8E RID: 20110 RVA: 0x00276519 File Offset: 0x00275519
		public ValuePositionDataLabel(bool showValue, bool showPosition, bool showSeries)
		{
			this.a = showValue;
			this.b = showPosition;
			this.c = showSeries;
		}

		// Token: 0x06004E8F RID: 20111 RVA: 0x00276539 File Offset: 0x00275539
		public ValuePositionDataLabel(Font font, float fontSize, Color color, bool showValue)
		{
			base.Font = font;
			base.FontSize = fontSize;
			base.Color = color;
			this.ShowValue = showValue;
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06004E90 RID: 20112 RVA: 0x00276568 File Offset: 0x00275568
		// (set) Token: 0x06004E91 RID: 20113 RVA: 0x00276580 File Offset: 0x00275580
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

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06004E92 RID: 20114 RVA: 0x0027658C File Offset: 0x0027558C
		// (set) Token: 0x06004E93 RID: 20115 RVA: 0x002765A4 File Offset: 0x002755A4
		public bool ShowPosition
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

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06004E94 RID: 20116 RVA: 0x002765B0 File Offset: 0x002755B0
		// (set) Token: 0x06004E95 RID: 20117 RVA: 0x002765C8 File Offset: 0x002755C8
		public bool ShowSeries
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

		// Token: 0x04002A68 RID: 10856
		private new bool a;

		// Token: 0x04002A69 RID: 10857
		private bool b;

		// Token: 0x04002A6A RID: 10858
		private bool c;
	}
}
