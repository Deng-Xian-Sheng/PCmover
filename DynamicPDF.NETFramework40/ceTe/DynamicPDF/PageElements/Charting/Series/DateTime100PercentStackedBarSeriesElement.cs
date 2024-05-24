using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000890 RID: 2192
	public class DateTime100PercentStackedBarSeriesElement : Stacked100PercentBarSeriesElement
	{
		// Token: 0x0600594E RID: 22862 RVA: 0x0033A086 File Offset: 0x00339086
		public DateTime100PercentStackedBarSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x0600594F RID: 22863 RVA: 0x0033A09A File Offset: 0x0033909A
		public DateTime100PercentStackedBarSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x06005950 RID: 22864 RVA: 0x0033A0AE File Offset: 0x003390AE
		public DateTime100PercentStackedBarSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x0033A0C2 File Offset: 0x003390C2
		public DateTime100PercentStackedBarSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x06005952 RID: 22866 RVA: 0x0033A0D2 File Offset: 0x003390D2
		public DateTime100PercentStackedBarSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005953 RID: 22867 RVA: 0x0033A0E2 File Offset: 0x003390E2
		public DateTime100PercentStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005954 RID: 22868 RVA: 0x0033A0F3 File Offset: 0x003390F3
		public DateTime100PercentStackedBarSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTime100PercentStackedBarValueList(this));
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06005955 RID: 22869 RVA: 0x0033A128 File Offset: 0x00339128
		public DateTime100PercentStackedBarValueList Values
		{
			get
			{
				return (DateTime100PercentStackedBarValueList)base.a();
			}
		}

		// Token: 0x06005956 RID: 22870 RVA: 0x0033A148 File Offset: 0x00339148
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x0033A160 File Offset: 0x00339160
		internal override void im(DateTime A_0)
		{
			if (this.b == DateTime.MinValue)
			{
				this.b = A_0;
			}
			else if (A_0 > this.b)
			{
				this.b = A_0;
			}
		}

		// Token: 0x06005958 RID: 22872 RVA: 0x0033A1A8 File Offset: 0x003391A8
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005959 RID: 22873 RVA: 0x0033A1C0 File Offset: 0x003391C0
		internal override void io(DateTime A_0)
		{
			if (this.a == DateTime.MinValue)
			{
				this.a = A_0;
			}
			else if (A_0 < this.a)
			{
				this.a = A_0;
			}
		}

		// Token: 0x04002F40 RID: 12096
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F41 RID: 12097
		private new DateTime b = DateTime.MinValue;
	}
}
