using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003C4 RID: 964
	[ComVisible(true)]
	[Serializable]
	public abstract class EastAsianLunisolarCalendar : Calendar
	{
		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x0600301C RID: 12316 RVA: 0x000B8E57 File Offset: 0x000B7057
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.LunisolarCalendar;
			}
		}

		// Token: 0x0600301D RID: 12317 RVA: 0x000B8E5C File Offset: 0x000B705C
		public virtual int GetSexagenaryYear(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.TimeToLunar(time, ref num, ref num2, ref num3);
			return (num - 4) % 60 + 1;
		}

		// Token: 0x0600301E RID: 12318 RVA: 0x000B8E94 File Offset: 0x000B7094
		public int GetCelestialStem(int sexagenaryYear)
		{
			if (sexagenaryYear < 1 || sexagenaryYear > 60)
			{
				throw new ArgumentOutOfRangeException("sexagenaryYear", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					60
				}));
			}
			return (sexagenaryYear - 1) % 10 + 1;
		}

		// Token: 0x0600301F RID: 12319 RVA: 0x000B8EE0 File Offset: 0x000B70E0
		public int GetTerrestrialBranch(int sexagenaryYear)
		{
			if (sexagenaryYear < 1 || sexagenaryYear > 60)
			{
				throw new ArgumentOutOfRangeException("sexagenaryYear", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					60
				}));
			}
			return (sexagenaryYear - 1) % 12 + 1;
		}

		// Token: 0x06003020 RID: 12320
		internal abstract int GetYearInfo(int LunarYear, int Index);

		// Token: 0x06003021 RID: 12321
		internal abstract int GetYear(int year, DateTime time);

		// Token: 0x06003022 RID: 12322
		internal abstract int GetGregorianYear(int year, int era);

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06003023 RID: 12323
		internal abstract int MinCalendarYear { get; }

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06003024 RID: 12324
		internal abstract int MaxCalendarYear { get; }

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06003025 RID: 12325
		internal abstract EraInfo[] CalEraInfo { get; }

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06003026 RID: 12326
		internal abstract DateTime MinDate { get; }

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06003027 RID: 12327
		internal abstract DateTime MaxDate { get; }

		// Token: 0x06003028 RID: 12328 RVA: 0x000B8F2C File Offset: 0x000B712C
		internal int MinEraCalendarYear(int era)
		{
			EraInfo[] calEraInfo = this.CalEraInfo;
			if (calEraInfo == null)
			{
				return this.MinCalendarYear;
			}
			if (era == 0)
			{
				era = this.CurrentEraValue;
			}
			if (era == this.GetEra(this.MinDate))
			{
				return this.GetYear(this.MinCalendarYear, this.MinDate);
			}
			for (int i = 0; i < calEraInfo.Length; i++)
			{
				if (era == calEraInfo[i].era)
				{
					return calEraInfo[i].minEraYear;
				}
			}
			throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x000B8FB0 File Offset: 0x000B71B0
		internal int MaxEraCalendarYear(int era)
		{
			EraInfo[] calEraInfo = this.CalEraInfo;
			if (calEraInfo == null)
			{
				return this.MaxCalendarYear;
			}
			if (era == 0)
			{
				era = this.CurrentEraValue;
			}
			if (era == this.GetEra(this.MaxDate))
			{
				return this.GetYear(this.MaxCalendarYear, this.MaxDate);
			}
			for (int i = 0; i < calEraInfo.Length; i++)
			{
				if (era == calEraInfo[i].era)
				{
					return calEraInfo[i].maxEraYear;
				}
			}
			throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
		}

		// Token: 0x0600302A RID: 12330 RVA: 0x000B9031 File Offset: 0x000B7231
		internal EastAsianLunisolarCalendar()
		{
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x000B903C File Offset: 0x000B723C
		internal void CheckTicksRange(long ticks)
		{
			if (ticks < this.MinSupportedDateTime.Ticks || ticks > this.MaxSupportedDateTime.Ticks)
			{
				throw new ArgumentOutOfRangeException("time", string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("ArgumentOutOfRange_CalendarRange"), this.MinSupportedDateTime, this.MaxSupportedDateTime));
			}
		}

		// Token: 0x0600302C RID: 12332 RVA: 0x000B90A0 File Offset: 0x000B72A0
		internal void CheckEraRange(int era)
		{
			if (era == 0)
			{
				era = this.CurrentEraValue;
			}
			if (era < this.GetEra(this.MinDate) || era > this.GetEra(this.MaxDate))
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}

		// Token: 0x0600302D RID: 12333 RVA: 0x000B90E0 File Offset: 0x000B72E0
		internal int CheckYearRange(int year, int era)
		{
			this.CheckEraRange(era);
			year = this.GetGregorianYear(year, era);
			if (year < this.MinCalendarYear || year > this.MaxCalendarYear)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					this.MinEraCalendarYear(era),
					this.MaxEraCalendarYear(era)
				}));
			}
			return year;
		}

		// Token: 0x0600302E RID: 12334 RVA: 0x000B914C File Offset: 0x000B734C
		internal int CheckYearMonthRange(int year, int month, int era)
		{
			year = this.CheckYearRange(year, era);
			if (month == 13 && this.GetYearInfo(year, 0) == 0)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
			if (month < 1 || month > 13)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
			return year;
		}

		// Token: 0x0600302F RID: 12335 RVA: 0x000B91A8 File Offset: 0x000B73A8
		internal int InternalGetDaysInMonth(int year, int month)
		{
			int num = 32768;
			num >>= month - 1;
			int result;
			if ((this.GetYearInfo(year, 3) & num) == 0)
			{
				result = 29;
			}
			else
			{
				result = 30;
			}
			return result;
		}

		// Token: 0x06003030 RID: 12336 RVA: 0x000B91D9 File Offset: 0x000B73D9
		public override int GetDaysInMonth(int year, int month, int era)
		{
			year = this.CheckYearMonthRange(year, month, era);
			return this.InternalGetDaysInMonth(year, month);
		}

		// Token: 0x06003031 RID: 12337 RVA: 0x000B91EE File Offset: 0x000B73EE
		private static int GregorianIsLeapYear(int y)
		{
			if (y % 4 != 0)
			{
				return 0;
			}
			if (y % 100 != 0)
			{
				return 1;
			}
			if (y % 400 == 0)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06003032 RID: 12338 RVA: 0x000B920C File Offset: 0x000B740C
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			year = this.CheckYearMonthRange(year, month, era);
			int num = this.InternalGetDaysInMonth(year, month);
			if (day < 1 || day > num)
			{
				throw new ArgumentOutOfRangeException("day", Environment.GetResourceString("ArgumentOutOfRange_Day", new object[]
				{
					num,
					month
				}));
			}
			int year2 = 0;
			int month2 = 0;
			int day2 = 0;
			if (this.LunarToGregorian(year, month, day, ref year2, ref month2, ref day2))
			{
				return new DateTime(year2, month2, day2, hour, minute, second, millisecond);
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		// Token: 0x06003033 RID: 12339 RVA: 0x000B929C File Offset: 0x000B749C
		internal void GregorianToLunar(int nSYear, int nSMonth, int nSDate, ref int nLYear, ref int nLMonth, ref int nLDate)
		{
			int num = EastAsianLunisolarCalendar.GregorianIsLeapYear(nSYear);
			int num2 = (num == 1) ? EastAsianLunisolarCalendar.DaysToMonth366[nSMonth - 1] : EastAsianLunisolarCalendar.DaysToMonth365[nSMonth - 1];
			num2 += nSDate;
			int i = num2;
			nLYear = nSYear;
			int yearInfo;
			int yearInfo2;
			if (nLYear == this.MaxCalendarYear + 1)
			{
				nLYear--;
				i += ((EastAsianLunisolarCalendar.GregorianIsLeapYear(nLYear) == 1) ? 366 : 365);
				yearInfo = this.GetYearInfo(nLYear, 1);
				yearInfo2 = this.GetYearInfo(nLYear, 2);
			}
			else
			{
				yearInfo = this.GetYearInfo(nLYear, 1);
				yearInfo2 = this.GetYearInfo(nLYear, 2);
				if (nSMonth < yearInfo || (nSMonth == yearInfo && nSDate < yearInfo2))
				{
					nLYear--;
					i += ((EastAsianLunisolarCalendar.GregorianIsLeapYear(nLYear) == 1) ? 366 : 365);
					yearInfo = this.GetYearInfo(nLYear, 1);
					yearInfo2 = this.GetYearInfo(nLYear, 2);
				}
			}
			i -= EastAsianLunisolarCalendar.DaysToMonth365[yearInfo - 1];
			i -= yearInfo2 - 1;
			int num3 = 32768;
			int yearInfo3 = this.GetYearInfo(nLYear, 3);
			int num4 = ((yearInfo3 & num3) != 0) ? 30 : 29;
			nLMonth = 1;
			while (i > num4)
			{
				i -= num4;
				nLMonth++;
				num3 >>= 1;
				num4 = (((yearInfo3 & num3) != 0) ? 30 : 29);
			}
			nLDate = i;
		}

		// Token: 0x06003034 RID: 12340 RVA: 0x000B93E4 File Offset: 0x000B75E4
		internal bool LunarToGregorian(int nLYear, int nLMonth, int nLDate, ref int nSolarYear, ref int nSolarMonth, ref int nSolarDay)
		{
			if (nLDate < 1 || nLDate > 30)
			{
				return false;
			}
			int num = nLDate - 1;
			for (int i = 1; i < nLMonth; i++)
			{
				num += this.InternalGetDaysInMonth(nLYear, i);
			}
			int yearInfo = this.GetYearInfo(nLYear, 1);
			int yearInfo2 = this.GetYearInfo(nLYear, 2);
			int num2 = EastAsianLunisolarCalendar.GregorianIsLeapYear(nLYear);
			int[] array = (num2 == 1) ? EastAsianLunisolarCalendar.DaysToMonth366 : EastAsianLunisolarCalendar.DaysToMonth365;
			nSolarDay = yearInfo2;
			if (yearInfo > 1)
			{
				nSolarDay += array[yearInfo - 1];
			}
			nSolarDay += num;
			if (nSolarDay > num2 + 365)
			{
				nSolarYear = nLYear + 1;
				nSolarDay -= num2 + 365;
			}
			else
			{
				nSolarYear = nLYear;
			}
			nSolarMonth = 1;
			while (nSolarMonth < 12 && array[nSolarMonth] < nSolarDay)
			{
				nSolarMonth++;
			}
			nSolarDay -= array[nSolarMonth - 1];
			return true;
		}

		// Token: 0x06003035 RID: 12341 RVA: 0x000B94BC File Offset: 0x000B76BC
		internal DateTime LunarToTime(DateTime time, int year, int month, int day)
		{
			int year2 = 0;
			int month2 = 0;
			int day2 = 0;
			this.LunarToGregorian(year, month, day, ref year2, ref month2, ref day2);
			return GregorianCalendar.GetDefaultInstance().ToDateTime(year2, month2, day2, time.Hour, time.Minute, time.Second, time.Millisecond);
		}

		// Token: 0x06003036 RID: 12342 RVA: 0x000B950C File Offset: 0x000B770C
		internal void TimeToLunar(DateTime time, ref int year, ref int month, ref int day)
		{
			Calendar defaultInstance = GregorianCalendar.GetDefaultInstance();
			int year2 = defaultInstance.GetYear(time);
			int month2 = defaultInstance.GetMonth(time);
			int dayOfMonth = defaultInstance.GetDayOfMonth(time);
			this.GregorianToLunar(year2, month2, dayOfMonth, ref year, ref month, ref day);
		}

		// Token: 0x06003037 RID: 12343 RVA: 0x000B954C File Offset: 0x000B774C
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					-120000,
					120000
				}));
			}
			this.CheckTicksRange(time.Ticks);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.TimeToLunar(time, ref num, ref num2, ref num3);
			int i = num2 + months;
			if (i > 0)
			{
				int num4 = this.InternalIsLeapYear(num) ? 13 : 12;
				while (i - num4 > 0)
				{
					i -= num4;
					num++;
					num4 = (this.InternalIsLeapYear(num) ? 13 : 12);
				}
				num2 = i;
			}
			else
			{
				while (i <= 0)
				{
					int num5 = this.InternalIsLeapYear(num - 1) ? 13 : 12;
					i += num5;
					num--;
				}
				num2 = i;
			}
			int num6 = this.InternalGetDaysInMonth(num, num2);
			if (num3 > num6)
			{
				num3 = num6;
			}
			DateTime result = this.LunarToTime(time, num, num2, num3);
			Calendar.CheckAddResult(result.Ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return result;
		}

		// Token: 0x06003038 RID: 12344 RVA: 0x000B9658 File Offset: 0x000B7858
		public override DateTime AddYears(DateTime time, int years)
		{
			this.CheckTicksRange(time.Ticks);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			this.TimeToLunar(time, ref num, ref num2, ref num3);
			num += years;
			if (num2 == 13 && !this.InternalIsLeapYear(num))
			{
				num2 = 12;
				num3 = this.InternalGetDaysInMonth(num, num2);
			}
			int num4 = this.InternalGetDaysInMonth(num, num2);
			if (num3 > num4)
			{
				num3 = num4;
			}
			DateTime result = this.LunarToTime(time, num, num2, num3);
			Calendar.CheckAddResult(result.Ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return result;
		}

		// Token: 0x06003039 RID: 12345 RVA: 0x000B96D8 File Offset: 0x000B78D8
		public override int GetDayOfYear(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			int year = 0;
			int num = 0;
			int num2 = 0;
			this.TimeToLunar(time, ref year, ref num, ref num2);
			for (int i = 1; i < num; i++)
			{
				num2 += this.InternalGetDaysInMonth(year, i);
			}
			return num2;
		}

		// Token: 0x0600303A RID: 12346 RVA: 0x000B9720 File Offset: 0x000B7920
		public override int GetDayOfMonth(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			int num = 0;
			int num2 = 0;
			int result = 0;
			this.TimeToLunar(time, ref num, ref num2, ref result);
			return result;
		}

		// Token: 0x0600303B RID: 12347 RVA: 0x000B9750 File Offset: 0x000B7950
		public override int GetDaysInYear(int year, int era)
		{
			year = this.CheckYearRange(year, era);
			int num = 0;
			int num2 = this.InternalIsLeapYear(year) ? 13 : 12;
			while (num2 != 0)
			{
				num += this.InternalGetDaysInMonth(year, num2--);
			}
			return num;
		}

		// Token: 0x0600303C RID: 12348 RVA: 0x000B9790 File Offset: 0x000B7990
		public override int GetMonth(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			int num = 0;
			int result = 0;
			int num2 = 0;
			this.TimeToLunar(time, ref num, ref result, ref num2);
			return result;
		}

		// Token: 0x0600303D RID: 12349 RVA: 0x000B97C0 File Offset: 0x000B79C0
		public override int GetYear(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			int year = 0;
			int num = 0;
			int num2 = 0;
			this.TimeToLunar(time, ref year, ref num, ref num2);
			return this.GetYear(year, time);
		}

		// Token: 0x0600303E RID: 12350 RVA: 0x000B97F5 File Offset: 0x000B79F5
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		// Token: 0x0600303F RID: 12351 RVA: 0x000B981B File Offset: 0x000B7A1B
		public override int GetMonthsInYear(int year, int era)
		{
			year = this.CheckYearRange(year, era);
			if (!this.InternalIsLeapYear(year))
			{
				return 12;
			}
			return 13;
		}

		// Token: 0x06003040 RID: 12352 RVA: 0x000B9838 File Offset: 0x000B7A38
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			year = this.CheckYearMonthRange(year, month, era);
			int num = this.InternalGetDaysInMonth(year, month);
			if (day < 1 || day > num)
			{
				throw new ArgumentOutOfRangeException("day", Environment.GetResourceString("ArgumentOutOfRange_Day", new object[]
				{
					num,
					month
				}));
			}
			int yearInfo = this.GetYearInfo(year, 0);
			return yearInfo != 0 && month == yearInfo + 1;
		}

		// Token: 0x06003041 RID: 12353 RVA: 0x000B98A4 File Offset: 0x000B7AA4
		public override bool IsLeapMonth(int year, int month, int era)
		{
			year = this.CheckYearMonthRange(year, month, era);
			int yearInfo = this.GetYearInfo(year, 0);
			return yearInfo != 0 && month == yearInfo + 1;
		}

		// Token: 0x06003042 RID: 12354 RVA: 0x000B98D0 File Offset: 0x000B7AD0
		public override int GetLeapMonth(int year, int era)
		{
			year = this.CheckYearRange(year, era);
			int yearInfo = this.GetYearInfo(year, 0);
			if (yearInfo > 0)
			{
				return yearInfo + 1;
			}
			return 0;
		}

		// Token: 0x06003043 RID: 12355 RVA: 0x000B98F9 File Offset: 0x000B7AF9
		internal bool InternalIsLeapYear(int year)
		{
			return this.GetYearInfo(year, 0) != 0;
		}

		// Token: 0x06003044 RID: 12356 RVA: 0x000B9906 File Offset: 0x000B7B06
		public override bool IsLeapYear(int year, int era)
		{
			year = this.CheckYearRange(year, era);
			return this.InternalIsLeapYear(year);
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06003045 RID: 12357 RVA: 0x000B9919 File Offset: 0x000B7B19
		// (set) Token: 0x06003046 RID: 12358 RVA: 0x000B9950 File Offset: 0x000B7B50
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.BaseCalendarID, this.GetYear(new DateTime(2029, 1, 1)));
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > this.MaxCalendarYear)
				{
					throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
					{
						99,
						this.MaxCalendarYear
					}));
				}
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x06003047 RID: 12359 RVA: 0x000B99AB File Offset: 0x000B7BAB
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			year = base.ToFourDigitYear(year);
			this.CheckYearRange(year, 0);
			return year;
		}

		// Token: 0x0400148A RID: 5258
		internal const int LeapMonth = 0;

		// Token: 0x0400148B RID: 5259
		internal const int Jan1Month = 1;

		// Token: 0x0400148C RID: 5260
		internal const int Jan1Date = 2;

		// Token: 0x0400148D RID: 5261
		internal const int nDaysPerMonth = 3;

		// Token: 0x0400148E RID: 5262
		internal static readonly int[] DaysToMonth365 = new int[]
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
			334
		};

		// Token: 0x0400148F RID: 5263
		internal static readonly int[] DaysToMonth366 = new int[]
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
			335
		};

		// Token: 0x04001490 RID: 5264
		internal const int DatePartYear = 0;

		// Token: 0x04001491 RID: 5265
		internal const int DatePartDayOfYear = 1;

		// Token: 0x04001492 RID: 5266
		internal const int DatePartMonth = 2;

		// Token: 0x04001493 RID: 5267
		internal const int DatePartDay = 3;

		// Token: 0x04001494 RID: 5268
		internal const int MaxCalendarMonth = 13;

		// Token: 0x04001495 RID: 5269
		internal const int MaxCalendarDay = 30;

		// Token: 0x04001496 RID: 5270
		private const int DEFAULT_GREGORIAN_TWO_DIGIT_YEAR_MAX = 2029;
	}
}
