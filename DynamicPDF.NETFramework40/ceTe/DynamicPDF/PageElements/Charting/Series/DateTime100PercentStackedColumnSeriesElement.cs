using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000894 RID: 2196
	public class DateTime100PercentStackedColumnSeriesElement : Stacked100PercentColumnSeriesElement
	{
		// Token: 0x0600597A RID: 22906 RVA: 0x0033A91A File Offset: 0x0033991A
		public DateTime100PercentStackedColumnSeriesElement(string name) : this(name, null, 0f, null, null)
		{
		}

		// Token: 0x0600597B RID: 22907 RVA: 0x0033A92E File Offset: 0x0033992E
		public DateTime100PercentStackedColumnSeriesElement(string name, Color color) : this(name, color, 0f, null, null)
		{
		}

		// Token: 0x0600597C RID: 22908 RVA: 0x0033A942 File Offset: 0x00339942
		public DateTime100PercentStackedColumnSeriesElement(string name, Color color, Legend legend) : this(name, color, 0f, null, legend)
		{
		}

		// Token: 0x0600597D RID: 22909 RVA: 0x0033A956 File Offset: 0x00339956
		public DateTime100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth) : this(name, color, borderWidth, null, null)
		{
		}

		// Token: 0x0600597E RID: 22910 RVA: 0x0033A966 File Offset: 0x00339966
		public DateTime100PercentStackedColumnSeriesElement(string name, float borderWidth, Color borderColor) : this(name, null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x0600597F RID: 22911 RVA: 0x0033A976 File Offset: 0x00339976
		public DateTime100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor) : this(name, color, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005980 RID: 22912 RVA: 0x0033A987 File Offset: 0x00339987
		public DateTime100PercentStackedColumnSeriesElement(string name, Color color, float borderWidth, Color borderColor, Legend legend) : base(name, color, borderWidth, borderColor, legend)
		{
			base.a(new DateTime100PercentStackedColumnValueList(this));
		}

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06005981 RID: 22913 RVA: 0x0033A9BC File Offset: 0x003399BC
		public DateTime100PercentStackedColumnValueList Values
		{
			get
			{
				return (DateTime100PercentStackedColumnValueList)base.a();
			}
		}

		// Token: 0x06005982 RID: 22914 RVA: 0x0033A9DC File Offset: 0x003399DC
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x06005983 RID: 22915 RVA: 0x0033A9F4 File Offset: 0x003399F4
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

		// Token: 0x06005984 RID: 22916 RVA: 0x0033AA3C File Offset: 0x00339A3C
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x06005985 RID: 22917 RVA: 0x0033AA54 File Offset: 0x00339A54
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

		// Token: 0x04002F49 RID: 12105
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F4A RID: 12106
		private new DateTime b = DateTime.MinValue;
	}
}
