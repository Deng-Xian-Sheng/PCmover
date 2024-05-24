using System;

namespace System.Globalization
{
	// Token: 0x020003C8 RID: 968
	[Serializable]
	public class PersianCalendar : Calendar
	{
		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x0600308C RID: 12428 RVA: 0x000BA3AF File Offset: 0x000B85AF
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return PersianCalendar.minDate;
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600308D RID: 12429 RVA: 0x000BA3B6 File Offset: 0x000B85B6
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return PersianCalendar.maxDate;
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600308E RID: 12430 RVA: 0x000BA3BD File Offset: 0x000B85BD
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06003090 RID: 12432 RVA: 0x000BA3C8 File Offset: 0x000B85C8
		internal override int BaseCalendarID
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06003091 RID: 12433 RVA: 0x000BA3CB File Offset: 0x000B85CB
		internal override int ID
		{
			get
			{
				return 22;
			}
		}

		// Token: 0x06003092 RID: 12434 RVA: 0x000BA3D0 File Offset: 0x000B85D0
		private long GetAbsoluteDatePersian(int year, int month, int day)
		{
			if (year >= 1 && year <= 9378 && month >= 1 && month <= 12)
			{
				int num = PersianCalendar.DaysInPreviousMonths(month) + day - 1;
				int num2 = (int)(365.242189 * (double)(year - 1));
				long num3 = CalendricalCalculationsHelper.PersianNewYearOnOrBefore(PersianCalendar.PersianEpoch + (long)num2 + 180L);
				return num3 + (long)num;
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		// Token: 0x06003093 RID: 12435 RVA: 0x000BA43C File Offset: 0x000B863C
		internal static void CheckTicksRange(long ticks)
		{
			if (ticks < PersianCalendar.minDate.Ticks || ticks > PersianCalendar.maxDate.Ticks)
			{
				throw new ArgumentOutOfRangeException("time", string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("ArgumentOutOfRange_CalendarRange"), PersianCalendar.minDate, PersianCalendar.maxDate));
			}
		}

		// Token: 0x06003094 RID: 12436 RVA: 0x000BA496 File Offset: 0x000B8696
		internal static void CheckEraRange(int era)
		{
			if (era != 0 && era != PersianCalendar.PersianEra)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}

		// Token: 0x06003095 RID: 12437 RVA: 0x000BA4B8 File Offset: 0x000B86B8
		internal static void CheckYearRange(int year, int era)
		{
			PersianCalendar.CheckEraRange(era);
			if (year < 1 || year > 9378)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9378));
			}
		}

		// Token: 0x06003096 RID: 12438 RVA: 0x000BA508 File Offset: 0x000B8708
		internal static void CheckYearMonthRange(int year, int month, int era)
		{
			PersianCalendar.CheckYearRange(year, era);
			if (year == 9378 && month > 10)
			{
				throw new ArgumentOutOfRangeException("month", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 10));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
		}

		// Token: 0x06003097 RID: 12439 RVA: 0x000BA574 File Offset: 0x000B8774
		private static int MonthFromOrdinalDay(int ordinalDay)
		{
			int num = 0;
			while (ordinalDay > PersianCalendar.DaysToMonth[num])
			{
				num++;
			}
			return num;
		}

		// Token: 0x06003098 RID: 12440 RVA: 0x000BA594 File Offset: 0x000B8794
		private static int DaysInPreviousMonths(int month)
		{
			month--;
			return PersianCalendar.DaysToMonth[month];
		}

		// Token: 0x06003099 RID: 12441 RVA: 0x000BA5A4 File Offset: 0x000B87A4
		internal int GetDatePart(long ticks, int part)
		{
			PersianCalendar.CheckTicksRange(ticks);
			long num = ticks / 864000000000L + 1L;
			long num2 = CalendricalCalculationsHelper.PersianNewYearOnOrBefore(num);
			int num3 = (int)Math.Floor((double)(num2 - PersianCalendar.PersianEpoch) / 365.242189 + 0.5) + 1;
			if (part == 0)
			{
				return num3;
			}
			int num4 = (int)(num - CalendricalCalculationsHelper.GetNumberOfDays(this.ToDateTime(num3, 1, 1, 0, 0, 0, 0, 1)));
			if (part == 1)
			{
				return num4;
			}
			int num5 = PersianCalendar.MonthFromOrdinalDay(num4);
			if (part == 2)
			{
				return num5;
			}
			int result = num4 - PersianCalendar.DaysInPreviousMonths(num5);
			if (part == 3)
			{
				return result;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DateTimeParsing"));
		}

		// Token: 0x0600309A RID: 12442 RVA: 0x000BA644 File Offset: 0x000B8844
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num = this.GetDatePart(time.Ticks, 0);
			int num2 = this.GetDatePart(time.Ticks, 2);
			int num3 = this.GetDatePart(time.Ticks, 3);
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
			int daysInMonth = this.GetDaysInMonth(num, num2);
			if (num3 > daysInMonth)
			{
				num3 = daysInMonth;
			}
			long ticks = this.GetAbsoluteDatePersian(num, num2, num3) * 864000000000L + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		// Token: 0x0600309B RID: 12443 RVA: 0x000BA742 File Offset: 0x000B8942
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		// Token: 0x0600309C RID: 12444 RVA: 0x000BA74F File Offset: 0x000B894F
		public override int GetDayOfMonth(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 3);
		}

		// Token: 0x0600309D RID: 12445 RVA: 0x000BA75F File Offset: 0x000B895F
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		// Token: 0x0600309E RID: 12446 RVA: 0x000BA778 File Offset: 0x000B8978
		public override int GetDayOfYear(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 1);
		}

		// Token: 0x0600309F RID: 12447 RVA: 0x000BA788 File Offset: 0x000B8988
		public override int GetDaysInMonth(int year, int month, int era)
		{
			PersianCalendar.CheckYearMonthRange(year, month, era);
			if (month == 10 && year == 9378)
			{
				return 13;
			}
			int num = PersianCalendar.DaysToMonth[month] - PersianCalendar.DaysToMonth[month - 1];
			if (month == 12 && !this.IsLeapYear(year))
			{
				num--;
			}
			return num;
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x000BA7D2 File Offset: 0x000B89D2
		public override int GetDaysInYear(int year, int era)
		{
			PersianCalendar.CheckYearRange(year, era);
			if (year == 9378)
			{
				return PersianCalendar.DaysToMonth[9] + 13;
			}
			if (!this.IsLeapYear(year, 0))
			{
				return 365;
			}
			return 366;
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x000BA804 File Offset: 0x000B8A04
		public override int GetEra(DateTime time)
		{
			PersianCalendar.CheckTicksRange(time.Ticks);
			return PersianCalendar.PersianEra;
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x060030A2 RID: 12450 RVA: 0x000BA817 File Offset: 0x000B8A17
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					PersianCalendar.PersianEra
				};
			}
		}

		// Token: 0x060030A3 RID: 12451 RVA: 0x000BA827 File Offset: 0x000B8A27
		public override int GetMonth(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 2);
		}

		// Token: 0x060030A4 RID: 12452 RVA: 0x000BA837 File Offset: 0x000B8A37
		public override int GetMonthsInYear(int year, int era)
		{
			PersianCalendar.CheckYearRange(year, era);
			if (year == 9378)
			{
				return 10;
			}
			return 12;
		}

		// Token: 0x060030A5 RID: 12453 RVA: 0x000BA84D File Offset: 0x000B8A4D
		public override int GetYear(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 0);
		}

		// Token: 0x060030A6 RID: 12454 RVA: 0x000BA860 File Offset: 0x000B8A60
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			int daysInMonth = this.GetDaysInMonth(year, month, era);
			if (day < 1 || day > daysInMonth)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Day"), daysInMonth, month));
			}
			return this.IsLeapYear(year, era) && month == 12 && day == 30;
		}

		// Token: 0x060030A7 RID: 12455 RVA: 0x000BA8C2 File Offset: 0x000B8AC2
		public override int GetLeapMonth(int year, int era)
		{
			PersianCalendar.CheckYearRange(year, era);
			return 0;
		}

		// Token: 0x060030A8 RID: 12456 RVA: 0x000BA8CC File Offset: 0x000B8ACC
		public override bool IsLeapMonth(int year, int month, int era)
		{
			PersianCalendar.CheckYearMonthRange(year, month, era);
			return false;
		}

		// Token: 0x060030A9 RID: 12457 RVA: 0x000BA8D7 File Offset: 0x000B8AD7
		public override bool IsLeapYear(int year, int era)
		{
			PersianCalendar.CheckYearRange(year, era);
			return year != 9378 && this.GetAbsoluteDatePersian(year + 1, 1, 1) - this.GetAbsoluteDatePersian(year, 1, 1) == 366L;
		}

		// Token: 0x060030AA RID: 12458 RVA: 0x000BA908 File Offset: 0x000B8B08
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			int daysInMonth = this.GetDaysInMonth(year, month, era);
			if (day < 1 || day > daysInMonth)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Day"), daysInMonth, month));
			}
			long absoluteDatePersian = this.GetAbsoluteDatePersian(year, month, day);
			if (absoluteDatePersian >= 0L)
			{
				return new DateTime(absoluteDatePersian * 864000000000L + Calendar.TimeToTicks(hour, minute, second, millisecond));
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x060030AB RID: 12459 RVA: 0x000BA991 File Offset: 0x000B8B91
		// (set) Token: 0x060030AC RID: 12460 RVA: 0x000BA9B8 File Offset: 0x000B8BB8
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 1410);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > 9378)
				{
					throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, 9378));
				}
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x060030AD RID: 12461 RVA: 0x000BAA10 File Offset: 0x000B8C10
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year < 100)
			{
				return base.ToFourDigitYear(year);
			}
			if (year > 9378)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9378));
			}
			return year;
		}

		// Token: 0x040014BA RID: 5306
		public static readonly int PersianEra = 1;

		// Token: 0x040014BB RID: 5307
		internal static long PersianEpoch = new DateTime(622, 3, 22).Ticks / 864000000000L;

		// Token: 0x040014BC RID: 5308
		private const int ApproximateHalfYear = 180;

		// Token: 0x040014BD RID: 5309
		internal const int DatePartYear = 0;

		// Token: 0x040014BE RID: 5310
		internal const int DatePartDayOfYear = 1;

		// Token: 0x040014BF RID: 5311
		internal const int DatePartMonth = 2;

		// Token: 0x040014C0 RID: 5312
		internal const int DatePartDay = 3;

		// Token: 0x040014C1 RID: 5313
		internal const int MonthsPerYear = 12;

		// Token: 0x040014C2 RID: 5314
		internal static int[] DaysToMonth = new int[]
		{
			0,
			31,
			62,
			93,
			124,
			155,
			186,
			216,
			246,
			276,
			306,
			336,
			366
		};

		// Token: 0x040014C3 RID: 5315
		internal const int MaxCalendarYear = 9378;

		// Token: 0x040014C4 RID: 5316
		internal const int MaxCalendarMonth = 10;

		// Token: 0x040014C5 RID: 5317
		internal const int MaxCalendarDay = 13;

		// Token: 0x040014C6 RID: 5318
		internal static DateTime minDate = new DateTime(622, 3, 22);

		// Token: 0x040014C7 RID: 5319
		internal static DateTime maxDate = DateTime.MaxValue;

		// Token: 0x040014C8 RID: 5320
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 1410;
	}
}
