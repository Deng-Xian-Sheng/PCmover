using System;
using ceTe.DynamicPDF.PageElements.Charting.Values;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200088C RID: 2188
	public class DateTime100PercentStackedAreaSeriesElement : Stacked100PercentAreaSeriesElement
	{
		// Token: 0x06005924 RID: 22820 RVA: 0x0033981F File Offset: 0x0033881F
		public DateTime100PercentStackedAreaSeriesElement(string name) : this(name, null, null, null)
		{
		}

		// Token: 0x06005925 RID: 22821 RVA: 0x0033982E File Offset: 0x0033882E
		public DateTime100PercentStackedAreaSeriesElement(string name, Color color) : this(name, color, null, null)
		{
		}

		// Token: 0x06005926 RID: 22822 RVA: 0x0033983D File Offset: 0x0033883D
		public DateTime100PercentStackedAreaSeriesElement(string name, Color color, Legend legend) : this(name, color, null, legend)
		{
		}

		// Token: 0x06005927 RID: 22823 RVA: 0x0033984C File Offset: 0x0033884C
		public DateTime100PercentStackedAreaSeriesElement(string name, Color color, Marker marker) : this(name, color, marker, null)
		{
		}

		// Token: 0x06005928 RID: 22824 RVA: 0x0033985B File Offset: 0x0033885B
		public DateTime100PercentStackedAreaSeriesElement(string name, Color color, Marker marker, Legend legend) : base(name, color, marker, legend)
		{
			base.a(new DateTime100PercentStackedAreaValueList(this));
		}

		// Token: 0x06005929 RID: 22825 RVA: 0x00339890 File Offset: 0x00338890
		internal override DateTime il()
		{
			return this.b;
		}

		// Token: 0x0600592A RID: 22826 RVA: 0x003398A8 File Offset: 0x003388A8
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

		// Token: 0x0600592B RID: 22827 RVA: 0x003398F0 File Offset: 0x003388F0
		internal override DateTime @in()
		{
			return this.a;
		}

		// Token: 0x0600592C RID: 22828 RVA: 0x00339908 File Offset: 0x00338908
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

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x0600592D RID: 22829 RVA: 0x00339950 File Offset: 0x00338950
		public DateTime100PercentStackedAreaValueList Values
		{
			get
			{
				return (DateTime100PercentStackedAreaValueList)base.a();
			}
		}

		// Token: 0x04002F37 RID: 12087
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002F38 RID: 12088
		private new DateTime b = DateTime.MinValue;
	}
}
