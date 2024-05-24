using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003C6 RID: 966
	[ComVisible(true)]
	[Serializable]
	public class JulianCalendar : Calendar
	{
		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x0600305B RID: 12379 RVA: 0x000B9BDC File Offset: 0x000B7DDC
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x0600305C RID: 12380 RVA: 0x000B9BE3 File Offset: 0x000B7DE3
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x0600305D RID: 12381 RVA: 0x000B9BEA File Offset: 0x000B7DEA
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x0600305E RID: 12382 RVA: 0x000B9BED File Offset: 0x000B7DED
		public JulianCalendar()
		{
			this.twoDigitYearMax = 2029;
		}

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x0600305F RID: 12383 RVA: 0x000B9C0B File Offset: 0x000B7E0B
		internal override int ID
		{
			get
			{
				return 13;
			}
		}

		// Token: 0x06003060 RID: 12384 RVA: 0x000B9C0F File Offset: 0x000B7E0F
		internal static void CheckEraRange(int era)
		{
			if (era != 0 && era != JulianCalendar.JulianEra)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}

		// Token: 0x06003061 RID: 12385 RVA: 0x000B9C34 File Offset: 0x000B7E34
		internal void CheckYearEraRange(int year, int era)
		{
			JulianCalendar.CheckEraRange(era);
			if (year <= 0 || year > this.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, this.MaxYear));
			}
		}

		// Token: 0x06003062 RID: 12386 RVA: 0x000B9C84 File Offset: 0x000B7E84
		internal static void CheckMonthRange(int month)
		{
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
		}

		// Token: 0x06003063 RID: 12387 RVA: 0x000B9CA4 File Offset: 0x000B7EA4
		internal static void CheckDayRange(int year, int month, int day)
		{
			if (year == 1 && month == 1 && day < 3)
			{
				throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
			}
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num = array[month] - array[month - 1];
			if (day < 1 || day > num)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, num));
			}
		}

		// Token: 0x06003064 RID: 12388 RVA: 0x000B9D24 File Offset: 0x000B7F24
		internal static int GetDatePart(long ticks, int part)
		{
			long num = ticks + 1728000000000L;
			int i = (int)(num / 864000000000L);
			int num2 = i / 1461;
			i -= num2 * 1461;
			int num3 = i / 365;
			if (num3 == 4)
			{
				num3 = 3;
			}
			if (part == 0)
			{
				return num2 * 4 + num3 + 1;
			}
			i -= num3 * 365;
			if (part == 1)
			{
				return i + 1;
			}
			int[] array = (num3 == 3) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num4 = i >> 6;
			while (i >= array[num4])
			{
				num4++;
			}
			if (part == 2)
			{
				return num4;
			}
			return i - array[num4 - 1] + 1;
		}

		// Token: 0x06003065 RID: 12389 RVA: 0x000B9DC8 File Offset: 0x000B7FC8
		internal static long DateToTicks(int year, int month, int day)
		{
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num = year - 1;
			int num2 = num * 365 + num / 4 + array[month - 1] + day - 1;
			return (long)(num2 - 2) * 864000000000L;
		}

		// Token: 0x06003066 RID: 12390 RVA: 0x000B9E10 File Offset: 0x000B8010
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num = JulianCalendar.GetDatePart(time.Ticks, 0);
			int num2 = JulianCalendar.GetDatePart(time.Ticks, 2);
			int num3 = JulianCalendar.GetDatePart(time.Ticks, 3);
			int num4 = num2 - 1 + months;
			if (num4 >= 0)
			{
				num2 = num4 % 12 + 1;
				num += num4 / 12;
			}
			else
			{
				num2 = 12 + (num4 + 1) % 12;
				num += (num4 - 11) / 12;
			}
			int[] array = (num % 4 == 0 && (num % 100 != 0 || num % 400 == 0)) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num5 = array[num2] - array[num2 - 1];
			if (num3 > num5)
			{
				num3 = num5;
			}
			long ticks = JulianCalendar.DateToTicks(num, num2, num3) + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		// Token: 0x06003067 RID: 12391 RVA: 0x000B9F25 File Offset: 0x000B8125
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		// Token: 0x06003068 RID: 12392 RVA: 0x000B9F32 File Offset: 0x000B8132
		public override int GetDayOfMonth(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 3);
		}

		// Token: 0x06003069 RID: 12393 RVA: 0x000B9F41 File Offset: 0x000B8141
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		// Token: 0x0600306A RID: 12394 RVA: 0x000B9F5A File Offset: 0x000B815A
		public override int GetDayOfYear(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 1);
		}

		// Token: 0x0600306B RID: 12395 RVA: 0x000B9F6C File Offset: 0x000B816C
		public override int GetDaysInMonth(int year, int month, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			return array[month] - array[month - 1];
		}

		// Token: 0x0600306C RID: 12396 RVA: 0x000B9FA2 File Offset: 0x000B81A2
		public override int GetDaysInYear(int year, int era)
		{
			if (!this.IsLeapYear(year, era))
			{
				return 365;
			}
			return 366;
		}

		// Token: 0x0600306D RID: 12397 RVA: 0x000B9FB9 File Offset: 0x000B81B9
		public override int GetEra(DateTime time)
		{
			return JulianCalendar.JulianEra;
		}

		// Token: 0x0600306E RID: 12398 RVA: 0x000B9FC0 File Offset: 0x000B81C0
		public override int GetMonth(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 2);
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x0600306F RID: 12399 RVA: 0x000B9FCF File Offset: 0x000B81CF
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					JulianCalendar.JulianEra
				};
			}
		}

		// Token: 0x06003070 RID: 12400 RVA: 0x000B9FDF File Offset: 0x000B81DF
		public override int GetMonthsInYear(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return 12;
		}

		// Token: 0x06003071 RID: 12401 RVA: 0x000B9FEB File Offset: 0x000B81EB
		public override int GetYear(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 0);
		}

		// Token: 0x06003072 RID: 12402 RVA: 0x000B9FFA File Offset: 0x000B81FA
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			JulianCalendar.CheckMonthRange(month);
			if (this.IsLeapYear(year, era))
			{
				JulianCalendar.CheckDayRange(year, month, day);
				return month == 2 && day == 29;
			}
			JulianCalendar.CheckDayRange(year, month, day);
			return false;
		}

		// Token: 0x06003073 RID: 12403 RVA: 0x000BA02A File Offset: 0x000B822A
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return 0;
		}

		// Token: 0x06003074 RID: 12404 RVA: 0x000BA035 File Offset: 0x000B8235
		public override bool IsLeapMonth(int year, int month, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			return false;
		}

		// Token: 0x06003075 RID: 12405 RVA: 0x000BA046 File Offset: 0x000B8246
		public override bool IsLeapYear(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return year % 4 == 0;
		}

		// Token: 0x06003076 RID: 12406 RVA: 0x000BA058 File Offset: 0x000B8258
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			JulianCalendar.CheckDayRange(year, month, day);
			if (millisecond < 0 || millisecond >= 1000)
			{
				throw new ArgumentOutOfRangeException("millisecond", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 999));
			}
			if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
			{
				return new DateTime(JulianCalendar.DateToTicks(year, month, day) + new TimeSpan(0, hour, minute, second, millisecond).Ticks);
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06003077 RID: 12407 RVA: 0x000BA10F File Offset: 0x000B830F
		// (set) Token: 0x06003078 RID: 12408 RVA: 0x000BA118 File Offset: 0x000B8318
		public override int TwoDigitYearMax
		{
			get
			{
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > this.MaxYear)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, this.MaxYear));
				}
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x06003079 RID: 12409 RVA: 0x000BA174 File Offset: 0x000B8374
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year > this.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Bounds_Lower_Upper"), 1, this.MaxYear));
			}
			return base.ToFourDigitYear(year);
		}

		// Token: 0x040014A4 RID: 5284
		public static readonly int JulianEra = 1;

		// Token: 0x040014A5 RID: 5285
		private const int DatePartYear = 0;

		// Token: 0x040014A6 RID: 5286
		private const int DatePartDayOfYear = 1;

		// Token: 0x040014A7 RID: 5287
		private const int DatePartMonth = 2;

		// Token: 0x040014A8 RID: 5288
		private const int DatePartDay = 3;

		// Token: 0x040014A9 RID: 5289
		private const int JulianDaysPerYear = 365;

		// Token: 0x040014AA RID: 5290
		private const int JulianDaysPer4Years = 1461;

		// Token: 0x040014AB RID: 5291
		private static readonly int[] DaysToMonth365 = new int[]
		{
			0,
			31,
			59,
			90,
			120,
			151,
			181,
			212,
			243,
			273,
			304,
			334,
			365
		};

		// Token: 0x040014AC RID: 5292
		private static readonly int[] DaysToMonth366 = new int[]
		{
			0,
			31,
			60,
			91,
			121,
			152,
			182,
			213,
			244,
			274,
			305,
			335,
			366
		};

		// Token: 0x040014AD RID: 5293
		internal int MaxYear = 9999;
	}
}
