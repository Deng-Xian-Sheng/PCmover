using System;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x0200087F RID: 2175
	public abstract class XYSeries : SeriesBase
	{
		// Token: 0x06005894 RID: 22676 RVA: 0x00336BE1 File Offset: 0x00335BE1
		internal XYSeries(XAxis A_0, YAxis A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06005895 RID: 22677 RVA: 0x00336C10 File Offset: 0x00335C10
		internal XAxis m()
		{
			return this.a;
		}

		// Token: 0x06005896 RID: 22678 RVA: 0x00336C28 File Offset: 0x00335C28
		internal void a(XAxis A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005897 RID: 22679 RVA: 0x00336C34 File Offset: 0x00335C34
		internal YAxis n()
		{
			return this.b;
		}

		// Token: 0x06005898 RID: 22680 RVA: 0x00336C4C File Offset: 0x00335C4C
		internal void a(YAxis A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06005899 RID: 22681 RVA: 0x00336C58 File Offset: 0x00335C58
		internal float o()
		{
			return this.d;
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x00336C70 File Offset: 0x00335C70
		internal void a(float A_0)
		{
			if (A_0 > this.d)
			{
				this.d = A_0;
			}
		}

		// Token: 0x0600589B RID: 22683 RVA: 0x00336C98 File Offset: 0x00335C98
		internal float p()
		{
			return this.c;
		}

		// Token: 0x0600589C RID: 22684 RVA: 0x00336CB0 File Offset: 0x00335CB0
		internal void b(float A_0)
		{
			if (A_0 < this.c)
			{
				this.c = A_0;
			}
		}

		// Token: 0x0600589D RID: 22685 RVA: 0x00336CD8 File Offset: 0x00335CD8
		internal virtual float ig()
		{
			return -2.1474836E+09f;
		}

		// Token: 0x0600589E RID: 22686 RVA: 0x00336CEF File Offset: 0x00335CEF
		internal virtual void iy(float A_0)
		{
		}

		// Token: 0x0600589F RID: 22687 RVA: 0x00336CF4 File Offset: 0x00335CF4
		internal virtual float iz()
		{
			return 2.1474836E+09f;
		}

		// Token: 0x060058A0 RID: 22688 RVA: 0x00336D0B File Offset: 0x00335D0B
		internal virtual void i0(float A_0)
		{
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x00336D10 File Offset: 0x00335D10
		internal virtual DateTime ih()
		{
			return DateTime.MinValue;
		}

		// Token: 0x060058A2 RID: 22690 RVA: 0x00336D27 File Offset: 0x00335D27
		internal virtual void ii(DateTime A_0)
		{
		}

		// Token: 0x060058A3 RID: 22691 RVA: 0x00336D2C File Offset: 0x00335D2C
		internal virtual DateTime ij()
		{
			return DateTime.MinValue;
		}

		// Token: 0x060058A4 RID: 22692 RVA: 0x00336D43 File Offset: 0x00335D43
		internal virtual void ik(DateTime A_0)
		{
		}

		// Token: 0x060058A5 RID: 22693 RVA: 0x00336D48 File Offset: 0x00335D48
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
				if (((DateTimeXAxis)this.a).DateTimeType == DateTimeType.Month)
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
				DateTimeType dateTimeType = ((DateTimeXAxis)this.a).DateTimeType;
				if (dateTimeType == DateTimeType.Undefined)
				{
					dateTimeType = acj.a(this.ih(), this.ij());
				}
				if (dateTimeType != DateTimeType.Undefined)
				{
					TimeSpan timeSpan = A_0 - this.ij();
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
				DateTimeType dateTimeType = acj.a(this.ih(), this.ij());
				result = num / (int)this.a(this.ih(), this.ij(), dateTimeType, acj);
			}
			return result;
		}

		// Token: 0x060058A6 RID: 22694 RVA: 0x0033716C File Offset: 0x0033616C
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
				DateTimeType dateTimeType = ((DateTimeYAxis)this.b).DateTimeType;
				if (dateTimeType == DateTimeType.Undefined)
				{
					dateTimeType = acj.a(this.ih(), this.ij());
				}
				if (dateTimeType != DateTimeType.Undefined)
				{
					TimeSpan timeSpan = A_0 - this.ij();
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
				DateTimeType dateTimeType = acj.a(this.ih(), this.ij());
				result = num / (int)this.a(this.ih(), this.ij(), dateTimeType, acj);
			}
			return result;
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x00337590 File Offset: 0x00336590
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
					num2 = (float)A_0.Year;
					num = (float)A_1.Year;
					break;
				case DateTimeType.Month:
					num2 = (float)A_0.Month;
					num = (float)A_1.Month;
					break;
				case DateTimeType.Day:
					num2 = (float)A_0.Day;
					num = (float)A_1.Day;
					break;
				case DateTimeType.Hour:
					num2 = (float)A_0.Hour;
					num = (float)A_1.Hour;
					break;
				case DateTimeType.Minute:
					num2 = (float)A_0.Minute;
					num = (float)A_1.Minute;
					break;
				case DateTimeType.Second:
					num2 = (float)A_0.Second;
					num = (float)A_1.Second;
					break;
				}
				if (num2 - num >= 10f)
				{
					result = A_3.a(num2 - num);
				}
			}
			return result;
		}

		// Token: 0x04002F12 RID: 12050
		private new XAxis a;

		// Token: 0x04002F13 RID: 12051
		private YAxis b;

		// Token: 0x04002F14 RID: 12052
		private float c = float.MaxValue;

		// Token: 0x04002F15 RID: 12053
		private float d = float.MinValue;
	}
}
