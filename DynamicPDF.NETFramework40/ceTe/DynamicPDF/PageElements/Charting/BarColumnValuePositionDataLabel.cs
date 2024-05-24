using System;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x0200079A RID: 1946
	public class BarColumnValuePositionDataLabel : ValuePositionDataLabel
	{
		// Token: 0x06004E96 RID: 20118 RVA: 0x002765D2 File Offset: 0x002755D2
		public BarColumnValuePositionDataLabel(bool showValue) : base(showValue)
		{
		}

		// Token: 0x06004E97 RID: 20119 RVA: 0x002765E5 File Offset: 0x002755E5
		public BarColumnValuePositionDataLabel(bool showValue, bool showSeries) : base(showValue, showSeries)
		{
		}

		// Token: 0x06004E98 RID: 20120 RVA: 0x002765F9 File Offset: 0x002755F9
		public BarColumnValuePositionDataLabel(bool showValue, bool showPosition, bool showSeries) : base(showValue, showPosition, showSeries)
		{
		}

		// Token: 0x06004E99 RID: 20121 RVA: 0x0027660E File Offset: 0x0027560E
		public BarColumnValuePositionDataLabel(Font font, float fontSize, Color color, bool showValue) : base(font, fontSize, color, showValue)
		{
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x06004E9A RID: 20122 RVA: 0x00276628 File Offset: 0x00275628
		// (set) Token: 0x06004E9B RID: 20123 RVA: 0x00276640 File Offset: 0x00275640
		public DataLabelLocation Location
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

		// Token: 0x04002A6B RID: 10859
		private new DataLabelLocation a = DataLabelLocation.Default;
	}
}
