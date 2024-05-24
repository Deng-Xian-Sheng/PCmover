using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x02000884 RID: 2180
	public abstract class StackedSeriesElementBase : SeriesElement
	{
		// Token: 0x060058CF RID: 22735 RVA: 0x00337A5C File Offset: 0x00336A5C
		internal StackedSeriesElementBase(string A_0, Color A_1, Legend A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x060058D0 RID: 22736 RVA: 0x00337A78 File Offset: 0x00336A78
		// (set) Token: 0x060058D1 RID: 22737 RVA: 0x00337A90 File Offset: 0x00336A90
		public string ValueFormat
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

		// Token: 0x060058D2 RID: 22738 RVA: 0x00337A9C File Offset: 0x00336A9C
		internal XAxis d()
		{
			return this.a;
		}

		// Token: 0x060058D3 RID: 22739 RVA: 0x00337AB4 File Offset: 0x00336AB4
		internal void a(XAxis A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060058D4 RID: 22740 RVA: 0x00337AC0 File Offset: 0x00336AC0
		internal YAxis e()
		{
			return this.b;
		}

		// Token: 0x060058D5 RID: 22741 RVA: 0x00337AD8 File Offset: 0x00336AD8
		internal void a(YAxis A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060058D6 RID: 22742 RVA: 0x00337AE4 File Offset: 0x00336AE4
		internal virtual float i1()
		{
			return -2.1474836E+09f;
		}

		// Token: 0x060058D7 RID: 22743 RVA: 0x00337AFB File Offset: 0x00336AFB
		internal virtual void i2(float A_0)
		{
		}

		// Token: 0x060058D8 RID: 22744 RVA: 0x00337B00 File Offset: 0x00336B00
		internal virtual float i3()
		{
			return 2.1474836E+09f;
		}

		// Token: 0x060058D9 RID: 22745 RVA: 0x00337B17 File Offset: 0x00336B17
		internal virtual void i4(float A_0)
		{
		}

		// Token: 0x060058DA RID: 22746 RVA: 0x00337B1C File Offset: 0x00336B1C
		internal virtual DateTime il()
		{
			return DateTime.MinValue;
		}

		// Token: 0x060058DB RID: 22747 RVA: 0x00337B33 File Offset: 0x00336B33
		internal virtual void im(DateTime A_0)
		{
		}

		// Token: 0x060058DC RID: 22748 RVA: 0x00337B38 File Offset: 0x00336B38
		internal virtual DateTime @in()
		{
			return DateTime.MinValue;
		}

		// Token: 0x060058DD RID: 22749 RVA: 0x00337B4F File Offset: 0x00336B4F
		internal virtual void io(DateTime A_0)
		{
		}

		// Token: 0x060058DE RID: 22750 RVA: 0x00337B54 File Offset: 0x00336B54
		internal int a(DateTime A_0)
		{
			int num = 0;
			acj acj = ((DateTimeXAxis)this.a).d();
			if (this.a is DateTimeXAxis && ((DateTimeXAxis)this.a).Min != DateTime.MinValue)
			{
				TimeSpan timeSpan = A_0 - ((DateTimeXAxis)this.a).Min;
				if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Year)
				{
					num = (int)(timeSpan.Ticks / 10000L / 31104000000L);
				}
				else if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Month)
				{
					num = (int)Math.Round((double)(timeSpan.Ticks / 10000L) / 2592000000.0);
				}
				else if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Day)
				{
					num = (int)(timeSpan.Ticks / 10000L / 86400000L);
				}
				else if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Hour)
				{
					num = (int)(timeSpan.Ticks / 10000L / 3600000L);
				}
				else if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Minute)
				{
					num = (int)(timeSpan.Ticks / 10000L / 60000L);
				}
				else if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Second)
				{
					num = (int)(timeSpan.Ticks / 10000L / 1000L);
				}
			}
			else
			{
				DateTimeType dateTimeType = acj.a(this.il(), this.@in());
				if (dateTimeType != DateTimeType.Undefined)
				{
					TimeSpan timeSpan = A_0 - this.@in();
					switch (dateTimeType)
					{
					case DateTimeType.Year:
						num = (int)(timeSpan.Ticks / 10000L / 31104000000L);
						break;
					case DateTimeType.Month:
						num = (int)Math.Round((double)(timeSpan.Ticks / 10000L) / 2592000000.0);
						break;
					case DateTimeType.Day:
						num = (int)(timeSpan.Ticks / 10000L / 86400000L);
						break;
					case DateTimeType.Hour:
						num = (int)(timeSpan.Ticks / 10000L / 3600000L);
						break;
					case DateTimeType.Minute:
						num = (int)(timeSpan.Ticks / 10000L / 60000L);
						break;
					case DateTimeType.Second:
						num = (int)(timeSpan.Ticks / 10000L / 1000L);
						break;
					}
				}
			}
			int result;
			if (this.a.t() > 0f)
			{
				result = num / (int)this.a.t();
			}
			else if (((DateTimeXAxis)this.a).Max != DateTime.MinValue && ((DateTimeXAxis)this.a).Min != DateTime.MinValue)
			{
				DateTimeType dateTimeType;
				if (((DateTimeXAxis)this.a).DateTimeType != DateTimeType.Year)
				{
					dateTimeType = ((DateTimeXAxis)this.a).DateTimeType;
				}
				else
				{
					dateTimeType = acj.a(((DateTimeXAxis)this.a).Max, ((DateTimeXAxis)this.a).Min);
				}
				result = num / (int)this.a(((DateTimeXAxis)this.a).Max, ((DateTimeXAxis)this.a).Min, dateTimeType, acj);
			}
			else
			{
				DateTimeType dateTimeType = acj.a(this.il(), this.@in());
				result = num / (int)this.a(this.il(), this.@in(), dateTimeType, acj);
			}
			return result;
		}

		// Token: 0x060058DF RID: 22751 RVA: 0x00337F60 File Offset: 0x00336F60
		internal int b(DateTime A_0)
		{
			int num = 0;
			acj acj = ((DateTimeYAxis)this.b).d();
			if (this.b is DateTimeYAxis && ((DateTimeYAxis)this.b).Min != DateTime.MinValue)
			{
				TimeSpan timeSpan = A_0 - ((DateTimeYAxis)this.b).Min;
				if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Year)
				{
					num = (int)(timeSpan.Ticks / 10000L / 31104000000L);
				}
				if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Month)
				{
					num = (int)Math.Round((double)(timeSpan.Ticks / 10000L) / 2592000000.0);
				}
				else if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Day)
				{
					num = (int)(timeSpan.Ticks / 10000L / 86400000L);
				}
				else if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Hour)
				{
					num = (int)(timeSpan.Ticks / 10000L / 3600000L);
				}
				else if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Minute)
				{
					num = (int)(timeSpan.Ticks / 10000L / 60000L);
				}
				else if (((DateTimeYAxis)this.b).DateTimeType == DateTimeType.Second)
				{
					num = (int)(timeSpan.Ticks / 10000L / 1000L);
				}
			}
			else
			{
				DateTimeType dateTimeType = acj.a(this.il(), this.@in());
				if (dateTimeType != DateTimeType.Undefined)
				{
					TimeSpan timeSpan = A_0 - this.@in();
					switch (dateTimeType)
					{
					case DateTimeType.Year:
						num = (int)(timeSpan.Ticks / 10000L / 31104000000L);
						break;
					case DateTimeType.Month:
						num = (int)Math.Round((double)(timeSpan.Ticks / 10000L) / 2592000000.0);
						break;
					case DateTimeType.Day:
						num = (int)(timeSpan.Ticks / 10000L / 86400000L);
						break;
					case DateTimeType.Hour:
						num = (int)(timeSpan.Ticks / 10000L / 3600000L);
						break;
					case DateTimeType.Minute:
						num = (int)(timeSpan.Ticks / 10000L / 60000L);
						break;
					case DateTimeType.Second:
						num = (int)(timeSpan.Ticks / 10000L / 1000L);
						break;
					}
				}
			}
			int result;
			if (this.b.t() > 0f)
			{
				result = num / (int)this.b.t();
			}
			else if (((DateTimeYAxis)this.b).Max != DateTime.MinValue && ((DateTimeYAxis)this.b).Min != DateTime.MinValue)
			{
				DateTimeType dateTimeType;
				if (((DateTimeYAxis)this.b).DateTimeType != DateTimeType.Year)
				{
					dateTimeType = ((DateTimeYAxis)this.b).DateTimeType;
				}
				else
				{
					dateTimeType = acj.a(((DateTimeYAxis)this.b).Max, ((DateTimeYAxis)this.b).Min);
				}
				result = num / (int)this.a(((DateTimeYAxis)this.b).Max, ((DateTimeYAxis)this.b).Min, dateTimeType, acj);
			}
			else
			{
				DateTimeType dateTimeType = acj.a(this.il(), this.@in());
				result = num / (int)this.a(this.il(), this.@in(), dateTimeType, acj);
			}
			return result;
		}

		// Token: 0x060058E0 RID: 22752 RVA: 0x00338364 File Offset: 0x00337364
		private float a(DateTime A_0, DateTime A_1, DateTimeType A_2, acj A_3)
		{
			float result = 1f;
			if (A_2 != DateTimeType.Undefined)
			{
				float num = 0f;
				float num2 = 0f;
				switch (A_2)
				{
				case DateTimeType.Year:
					num = (float)A_0.Year;
					num2 = (float)A_1.Year;
					break;
				case DateTimeType.Month:
					num = (float)A_0.Month;
					num2 = (float)A_1.Month;
					break;
				case DateTimeType.Day:
					num = (float)A_0.Day;
					num2 = (float)A_1.Day;
					break;
				case DateTimeType.Hour:
					num = (float)A_0.Hour;
					num2 = (float)A_1.Hour;
					break;
				case DateTimeType.Minute:
					num = (float)A_0.Minute;
					num2 = (float)A_1.Minute;
					break;
				case DateTimeType.Second:
					num = (float)A_0.Second;
					num2 = (float)A_1.Second;
					break;
				}
				if (num - num2 >= 10f)
				{
					result = A_3.a(num - num2);
				}
			}
			return result;
		}

		// Token: 0x04002F26 RID: 12070
		private new XAxis a;

		// Token: 0x04002F27 RID: 12071
		private YAxis b;

		// Token: 0x04002F28 RID: 12072
		private string c = "#.##";
	}
}
