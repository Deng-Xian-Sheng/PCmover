using System;
using ceTe.DynamicPDF.PageElements.Charting;

namespace zz93
{
	// Token: 0x02000445 RID: 1093
	internal class acj
	{
		// Token: 0x06002D20 RID: 11552 RVA: 0x0019AD1C File Offset: 0x00199D1C
		internal acj()
		{
		}

		// Token: 0x06002D21 RID: 11553 RVA: 0x0019AD28 File Offset: 0x00199D28
		internal static acj a()
		{
			if (acj.a == null)
			{
				acj.a = new acj();
			}
			return acj.a;
		}

		// Token: 0x06002D22 RID: 11554 RVA: 0x0019AD5C File Offset: 0x00199D5C
		internal double a(DateTime A_0, DateTime A_1, DateTimeType A_2)
		{
			double result = 0.0;
			if (A_2 != DateTimeType.Undefined)
			{
				switch (A_2)
				{
				case DateTimeType.Year:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 31536000000.0;
					break;
				case DateTimeType.Month:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 2592000000.0;
					break;
				case DateTimeType.Day:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 86400000.0;
					break;
				case DateTimeType.Hour:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 3600000.0;
					break;
				case DateTimeType.Minute:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 60000.0;
					break;
				case DateTimeType.Second:
					result = (double)(A_0.Ticks / 10000L - A_1.Ticks / 10000L) / 1000.0;
					break;
				}
			}
			return result;
		}

		// Token: 0x06002D23 RID: 11555 RVA: 0x0019AEB8 File Offset: 0x00199EB8
		internal DateTimeType a(DateTime A_0, DateTime A_1)
		{
			long num = A_0.Ticks / 10000L - A_1.Ticks / 10000L;
			DateTimeType result = DateTimeType.Undefined;
			if (num >= 31536000000L)
			{
				result = DateTimeType.Year;
			}
			else if (num >= (long)((ulong)-1702967296))
			{
				result = DateTimeType.Month;
			}
			else if (num >= 86400000L)
			{
				result = DateTimeType.Day;
			}
			else if (num >= 3600000L)
			{
				result = DateTimeType.Hour;
			}
			else if (num >= 60000L)
			{
				result = DateTimeType.Minute;
			}
			else if (num >= 1000L)
			{
				result = DateTimeType.Second;
			}
			return result;
		}

		// Token: 0x06002D24 RID: 11556 RVA: 0x0019AF60 File Offset: 0x00199F60
		internal float a(float A_0)
		{
			float num = 0f;
			int num2 = 0;
			float num3 = A_0;
			if (A_0 > 0f && A_0 < 1f)
			{
				A_0 *= (float)((int)Math.Pow(10.0, (double)A_0.ToString("#.0######").Substring(A_0.ToString("#.0######").IndexOf('.') + 1).Length));
			}
			if (A_0 > 0f)
			{
				num2 = Convert.ToString(Math.Round((double)A_0)).Length;
			}
			float num4 = (float)Math.Pow(10.0, (double)(num2 - 1));
			float num5 = 5f * (float)Math.Pow(10.0, (double)(num2 - 2));
			float num6 = 2f * (float)Math.Pow(10.0, (double)(num2 - 2));
			float num7 = Math.Abs(A_0 / num4 - 10f);
			float num8 = Math.Abs(A_0 / num5 - 10f);
			float num9 = Math.Abs(A_0 / num6 - 10f);
			float num10 = Math.Min(Math.Min(num7, num8), num9);
			if (num10 == num7)
			{
				num = num4;
			}
			else if (num10 == num8)
			{
				num = num5;
			}
			else if (num10 == num9)
			{
				num = num6;
			}
			if (num3 > 0f && num3 < 1f)
			{
				num /= (float)Math.Pow(10.0, (double)num3.ToString("#.0######").Substring(num3.ToString("#.0######").IndexOf('.') + 1).Length);
			}
			return num;
		}

		// Token: 0x04001553 RID: 5459
		private static acj a = null;
	}
}
