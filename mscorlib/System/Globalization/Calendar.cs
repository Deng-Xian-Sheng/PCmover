﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003A1 RID: 929
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Calendar : ICloneable
	{
		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06002D9B RID: 11675 RVA: 0x000AEA93 File Offset: 0x000ACC93
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual DateTime MinSupportedDateTime
		{
			[__DynamicallyInvokable]
			get
			{
				return DateTime.MinValue;
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06002D9C RID: 11676 RVA: 0x000AEA9A File Offset: 0x000ACC9A
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual DateTime MaxSupportedDateTime
		{
			[__DynamicallyInvokable]
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x06002D9D RID: 11677 RVA: 0x000AEAA1 File Offset: 0x000ACCA1
		[__DynamicallyInvokable]
		protected Calendar()
		{
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06002D9E RID: 11678 RVA: 0x000AEAB7 File Offset: 0x000ACCB7
		internal virtual int ID
		{
			get
			{
				return -1;
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06002D9F RID: 11679 RVA: 0x000AEABA File Offset: 0x000ACCBA
		internal virtual int BaseCalendarID
		{
			get
			{
				return this.ID;
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06002DA0 RID: 11680 RVA: 0x000AEAC2 File Offset: 0x000ACCC2
		[ComVisible(false)]
		public virtual CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.Unknown;
			}
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06002DA1 RID: 11681 RVA: 0x000AEAC5 File Offset: 0x000ACCC5
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public bool IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_isReadOnly;
			}
		}

		// Token: 0x06002DA2 RID: 11682 RVA: 0x000AEAD0 File Offset: 0x000ACCD0
		[ComVisible(false)]
		public virtual object Clone()
		{
			object obj = base.MemberwiseClone();
			((Calendar)obj).SetReadOnlyState(false);
			return obj;
		}

		// Token: 0x06002DA3 RID: 11683 RVA: 0x000AEAF4 File Offset: 0x000ACCF4
		[ComVisible(false)]
		public static Calendar ReadOnly(Calendar calendar)
		{
			if (calendar == null)
			{
				throw new ArgumentNullException("calendar");
			}
			if (calendar.IsReadOnly)
			{
				return calendar;
			}
			Calendar calendar2 = (Calendar)calendar.MemberwiseClone();
			calendar2.SetReadOnlyState(true);
			return calendar2;
		}

		// Token: 0x06002DA4 RID: 11684 RVA: 0x000AEB2D File Offset: 0x000ACD2D
		internal void VerifyWritable()
		{
			if (this.m_isReadOnly)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
			}
		}

		// Token: 0x06002DA5 RID: 11685 RVA: 0x000AEB47 File Offset: 0x000ACD47
		internal void SetReadOnlyState(bool readOnly)
		{
			this.m_isReadOnly = readOnly;
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06002DA6 RID: 11686 RVA: 0x000AEB50 File Offset: 0x000ACD50
		internal virtual int CurrentEraValue
		{
			get
			{
				if (this.m_currentEraValue == -1)
				{
					this.m_currentEraValue = CalendarData.GetCalendarData(this.BaseCalendarID).iCurrentEra;
				}
				return this.m_currentEraValue;
			}
		}

		// Token: 0x06002DA7 RID: 11687 RVA: 0x000AEB77 File Offset: 0x000ACD77
		internal static void CheckAddResult(long ticks, DateTime minValue, DateTime maxValue)
		{
			if (ticks < minValue.Ticks || ticks > maxValue.Ticks)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("Argument_ResultCalendarRange"), minValue, maxValue));
			}
		}

		// Token: 0x06002DA8 RID: 11688 RVA: 0x000AEBB4 File Offset: 0x000ACDB4
		internal DateTime Add(DateTime time, double value, int scale)
		{
			double num = value * (double)scale + ((value >= 0.0) ? 0.5 : -0.5);
			if (num <= -315537897600000.0 || num >= 315537897600000.0)
			{
				throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_AddValue"));
			}
			long num2 = (long)num;
			long ticks = time.Ticks + num2 * 10000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		// Token: 0x06002DA9 RID: 11689 RVA: 0x000AEC40 File Offset: 0x000ACE40
		[__DynamicallyInvokable]
		public virtual DateTime AddMilliseconds(DateTime time, double milliseconds)
		{
			return this.Add(time, milliseconds, 1);
		}

		// Token: 0x06002DAA RID: 11690 RVA: 0x000AEC4B File Offset: 0x000ACE4B
		[__DynamicallyInvokable]
		public virtual DateTime AddDays(DateTime time, int days)
		{
			return this.Add(time, (double)days, 86400000);
		}

		// Token: 0x06002DAB RID: 11691 RVA: 0x000AEC5B File Offset: 0x000ACE5B
		[__DynamicallyInvokable]
		public virtual DateTime AddHours(DateTime time, int hours)
		{
			return this.Add(time, (double)hours, 3600000);
		}

		// Token: 0x06002DAC RID: 11692 RVA: 0x000AEC6B File Offset: 0x000ACE6B
		[__DynamicallyInvokable]
		public virtual DateTime AddMinutes(DateTime time, int minutes)
		{
			return this.Add(time, (double)minutes, 60000);
		}

		// Token: 0x06002DAD RID: 11693
		[__DynamicallyInvokable]
		public abstract DateTime AddMonths(DateTime time, int months);

		// Token: 0x06002DAE RID: 11694 RVA: 0x000AEC7B File Offset: 0x000ACE7B
		[__DynamicallyInvokable]
		public virtual DateTime AddSeconds(DateTime time, int seconds)
		{
			return this.Add(time, (double)seconds, 1000);
		}

		// Token: 0x06002DAF RID: 11695 RVA: 0x000AEC8B File Offset: 0x000ACE8B
		[__DynamicallyInvokable]
		public virtual DateTime AddWeeks(DateTime time, int weeks)
		{
			return this.AddDays(time, weeks * 7);
		}

		// Token: 0x06002DB0 RID: 11696
		[__DynamicallyInvokable]
		public abstract DateTime AddYears(DateTime time, int years);

		// Token: 0x06002DB1 RID: 11697
		[__DynamicallyInvokable]
		public abstract int GetDayOfMonth(DateTime time);

		// Token: 0x06002DB2 RID: 11698
		[__DynamicallyInvokable]
		public abstract DayOfWeek GetDayOfWeek(DateTime time);

		// Token: 0x06002DB3 RID: 11699
		[__DynamicallyInvokable]
		public abstract int GetDayOfYear(DateTime time);

		// Token: 0x06002DB4 RID: 11700 RVA: 0x000AEC97 File Offset: 0x000ACE97
		[__DynamicallyInvokable]
		public virtual int GetDaysInMonth(int year, int month)
		{
			return this.GetDaysInMonth(year, month, 0);
		}

		// Token: 0x06002DB5 RID: 11701
		[__DynamicallyInvokable]
		public abstract int GetDaysInMonth(int year, int month, int era);

		// Token: 0x06002DB6 RID: 11702 RVA: 0x000AECA2 File Offset: 0x000ACEA2
		[__DynamicallyInvokable]
		public virtual int GetDaysInYear(int year)
		{
			return this.GetDaysInYear(year, 0);
		}

		// Token: 0x06002DB7 RID: 11703
		[__DynamicallyInvokable]
		public abstract int GetDaysInYear(int year, int era);

		// Token: 0x06002DB8 RID: 11704
		[__DynamicallyInvokable]
		public abstract int GetEra(DateTime time);

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06002DB9 RID: 11705
		[__DynamicallyInvokable]
		public abstract int[] Eras { [__DynamicallyInvokable] get; }

		// Token: 0x06002DBA RID: 11706 RVA: 0x000AECAC File Offset: 0x000ACEAC
		[__DynamicallyInvokable]
		public virtual int GetHour(DateTime time)
		{
			return (int)(time.Ticks / 36000000000L % 24L);
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x000AECC4 File Offset: 0x000ACEC4
		[__DynamicallyInvokable]
		public virtual double GetMilliseconds(DateTime time)
		{
			return (double)(time.Ticks / 10000L % 1000L);
		}

		// Token: 0x06002DBC RID: 11708 RVA: 0x000AECDC File Offset: 0x000ACEDC
		[__DynamicallyInvokable]
		public virtual int GetMinute(DateTime time)
		{
			return (int)(time.Ticks / 600000000L % 60L);
		}

		// Token: 0x06002DBD RID: 11709
		[__DynamicallyInvokable]
		public abstract int GetMonth(DateTime time);

		// Token: 0x06002DBE RID: 11710 RVA: 0x000AECF1 File Offset: 0x000ACEF1
		[__DynamicallyInvokable]
		public virtual int GetMonthsInYear(int year)
		{
			return this.GetMonthsInYear(year, 0);
		}

		// Token: 0x06002DBF RID: 11711
		[__DynamicallyInvokable]
		public abstract int GetMonthsInYear(int year, int era);

		// Token: 0x06002DC0 RID: 11712 RVA: 0x000AECFB File Offset: 0x000ACEFB
		[__DynamicallyInvokable]
		public virtual int GetSecond(DateTime time)
		{
			return (int)(time.Ticks / 10000000L % 60L);
		}

		// Token: 0x06002DC1 RID: 11713 RVA: 0x000AED10 File Offset: 0x000ACF10
		internal int GetFirstDayWeekOfYear(DateTime time, int firstDayOfWeek)
		{
			int num = this.GetDayOfYear(time) - 1;
			int num2 = this.GetDayOfWeek(time) - (DayOfWeek)(num % 7);
			int num3 = (num2 - firstDayOfWeek + 14) % 7;
			return (num + num3) / 7 + 1;
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x000AED44 File Offset: 0x000ACF44
		private int GetWeekOfYearFullDays(DateTime time, int firstDayOfWeek, int fullDays)
		{
			int num = this.GetDayOfYear(time) - 1;
			int num2 = this.GetDayOfWeek(time) - (DayOfWeek)(num % 7);
			int num3 = (firstDayOfWeek - num2 + 14) % 7;
			if (num3 != 0 && num3 >= fullDays)
			{
				num3 -= 7;
			}
			int num4 = num - num3;
			if (num4 >= 0)
			{
				return num4 / 7 + 1;
			}
			if (time <= this.MinSupportedDateTime.AddDays((double)num))
			{
				return this.GetWeekOfYearOfMinSupportedDateTime(firstDayOfWeek, fullDays);
			}
			return this.GetWeekOfYearFullDays(time.AddDays((double)(-(double)(num + 1))), firstDayOfWeek, fullDays);
		}

		// Token: 0x06002DC3 RID: 11715 RVA: 0x000AEDC0 File Offset: 0x000ACFC0
		private int GetWeekOfYearOfMinSupportedDateTime(int firstDayOfWeek, int minimumDaysInFirstWeek)
		{
			int num = this.GetDayOfYear(this.MinSupportedDateTime) - 1;
			int num2 = this.GetDayOfWeek(this.MinSupportedDateTime) - (DayOfWeek)(num % 7);
			int num3 = (firstDayOfWeek + 7 - num2) % 7;
			if (num3 == 0 || num3 >= minimumDaysInFirstWeek)
			{
				return 1;
			}
			int num4 = this.DaysInYearBeforeMinSupportedYear - 1;
			int num5 = num2 - 1 - num4 % 7;
			int num6 = (firstDayOfWeek - num5 + 14) % 7;
			int num7 = num4 - num6;
			if (num6 >= minimumDaysInFirstWeek)
			{
				num7 += 7;
			}
			return num7 / 7 + 1;
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06002DC4 RID: 11716 RVA: 0x000AEE32 File Offset: 0x000AD032
		protected virtual int DaysInYearBeforeMinSupportedYear
		{
			get
			{
				return 365;
			}
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x000AEE3C File Offset: 0x000AD03C
		[__DynamicallyInvokable]
		public virtual int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			if (firstDayOfWeek < DayOfWeek.Sunday || firstDayOfWeek > DayOfWeek.Saturday)
			{
				throw new ArgumentOutOfRangeException("firstDayOfWeek", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					DayOfWeek.Sunday,
					DayOfWeek.Saturday
				}));
			}
			switch (rule)
			{
			case CalendarWeekRule.FirstDay:
				return this.GetFirstDayWeekOfYear(time, (int)firstDayOfWeek);
			case CalendarWeekRule.FirstFullWeek:
				return this.GetWeekOfYearFullDays(time, (int)firstDayOfWeek, 7);
			case CalendarWeekRule.FirstFourDayWeek:
				return this.GetWeekOfYearFullDays(time, (int)firstDayOfWeek, 4);
			default:
				throw new ArgumentOutOfRangeException("rule", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					CalendarWeekRule.FirstDay,
					CalendarWeekRule.FirstFourDayWeek
				}));
			}
		}

		// Token: 0x06002DC6 RID: 11718
		[__DynamicallyInvokable]
		public abstract int GetYear(DateTime time);

		// Token: 0x06002DC7 RID: 11719 RVA: 0x000AEEDB File Offset: 0x000AD0DB
		[__DynamicallyInvokable]
		public virtual bool IsLeapDay(int year, int month, int day)
		{
			return this.IsLeapDay(year, month, day, 0);
		}

		// Token: 0x06002DC8 RID: 11720
		[__DynamicallyInvokable]
		public abstract bool IsLeapDay(int year, int month, int day, int era);

		// Token: 0x06002DC9 RID: 11721 RVA: 0x000AEEE7 File Offset: 0x000AD0E7
		[__DynamicallyInvokable]
		public virtual bool IsLeapMonth(int year, int month)
		{
			return this.IsLeapMonth(year, month, 0);
		}

		// Token: 0x06002DCA RID: 11722
		[__DynamicallyInvokable]
		public abstract bool IsLeapMonth(int year, int month, int era);

		// Token: 0x06002DCB RID: 11723 RVA: 0x000AEEF2 File Offset: 0x000AD0F2
		[ComVisible(false)]
		public virtual int GetLeapMonth(int year)
		{
			return this.GetLeapMonth(year, 0);
		}

		// Token: 0x06002DCC RID: 11724 RVA: 0x000AEEFC File Offset: 0x000AD0FC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual int GetLeapMonth(int year, int era)
		{
			if (!this.IsLeapYear(year, era))
			{
				return 0;
			}
			int monthsInYear = this.GetMonthsInYear(year, era);
			for (int i = 1; i <= monthsInYear; i++)
			{
				if (this.IsLeapMonth(year, i, era))
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x000AEF38 File Offset: 0x000AD138
		[__DynamicallyInvokable]
		public virtual bool IsLeapYear(int year)
		{
			return this.IsLeapYear(year, 0);
		}

		// Token: 0x06002DCE RID: 11726
		[__DynamicallyInvokable]
		public abstract bool IsLeapYear(int year, int era);

		// Token: 0x06002DCF RID: 11727 RVA: 0x000AEF44 File Offset: 0x000AD144
		[__DynamicallyInvokable]
		public virtual DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
		{
			return this.ToDateTime(year, month, day, hour, minute, second, millisecond, 0);
		}

		// Token: 0x06002DD0 RID: 11728
		[__DynamicallyInvokable]
		public abstract DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);

		// Token: 0x06002DD1 RID: 11729 RVA: 0x000AEF64 File Offset: 0x000AD164
		internal virtual bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result)
		{
			result = DateTime.MinValue;
			bool result2;
			try
			{
				result = this.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
				result2 = true;
			}
			catch (ArgumentException)
			{
				result2 = false;
			}
			return result2;
		}

		// Token: 0x06002DD2 RID: 11730 RVA: 0x000AEFB4 File Offset: 0x000AD1B4
		internal virtual bool IsValidYear(int year, int era)
		{
			return year >= this.GetYear(this.MinSupportedDateTime) && year <= this.GetYear(this.MaxSupportedDateTime);
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x000AEFD9 File Offset: 0x000AD1D9
		internal virtual bool IsValidMonth(int year, int month, int era)
		{
			return this.IsValidYear(year, era) && month >= 1 && month <= this.GetMonthsInYear(year, era);
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x000AEFF9 File Offset: 0x000AD1F9
		internal virtual bool IsValidDay(int year, int month, int day, int era)
		{
			return this.IsValidMonth(year, month, era) && day >= 1 && day <= this.GetDaysInMonth(year, month, era);
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06002DD5 RID: 11733 RVA: 0x000AF01D File Offset: 0x000AD21D
		// (set) Token: 0x06002DD6 RID: 11734 RVA: 0x000AF025 File Offset: 0x000AD225
		[__DynamicallyInvokable]
		public virtual int TwoDigitYearMax
		{
			[__DynamicallyInvokable]
			get
			{
				return this.twoDigitYearMax;
			}
			[__DynamicallyInvokable]
			set
			{
				this.VerifyWritable();
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x06002DD7 RID: 11735 RVA: 0x000AF034 File Offset: 0x000AD234
		[__DynamicallyInvokable]
		public virtual int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year < 100)
			{
				return (this.TwoDigitYearMax / 100 - ((year > this.TwoDigitYearMax % 100) ? 1 : 0)) * 100 + year;
			}
			return year;
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x000AF080 File Offset: 0x000AD280
		internal static long TimeToTicks(int hour, int minute, int second, int millisecond)
		{
			if (hour < 0 || hour >= 24 || minute < 0 || minute >= 60 || second < 0 || second >= 60)
			{
				throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
			}
			if (millisecond < 0 || millisecond >= 1000)
			{
				throw new ArgumentOutOfRangeException("millisecond", string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 999));
			}
			return TimeSpan.TimeToTicks(hour, minute, second) + (long)millisecond * 10000L;
		}

		// Token: 0x06002DD9 RID: 11737 RVA: 0x000AF108 File Offset: 0x000AD308
		[SecuritySafeCritical]
		internal static int GetSystemTwoDigitYearSetting(int CalID, int defaultYearValue)
		{
			int num = CalendarData.nativeGetTwoDigitYearMax(CalID);
			if (num < 0)
			{
				num = defaultYearValue;
			}
			return num;
		}

		// Token: 0x040012B0 RID: 4784
		internal const long TicksPerMillisecond = 10000L;

		// Token: 0x040012B1 RID: 4785
		internal const long TicksPerSecond = 10000000L;

		// Token: 0x040012B2 RID: 4786
		internal const long TicksPerMinute = 600000000L;

		// Token: 0x040012B3 RID: 4787
		internal const long TicksPerHour = 36000000000L;

		// Token: 0x040012B4 RID: 4788
		internal const long TicksPerDay = 864000000000L;

		// Token: 0x040012B5 RID: 4789
		internal const int MillisPerSecond = 1000;

		// Token: 0x040012B6 RID: 4790
		internal const int MillisPerMinute = 60000;

		// Token: 0x040012B7 RID: 4791
		internal const int MillisPerHour = 3600000;

		// Token: 0x040012B8 RID: 4792
		internal const int MillisPerDay = 86400000;

		// Token: 0x040012B9 RID: 4793
		internal const int DaysPerYear = 365;

		// Token: 0x040012BA RID: 4794
		internal const int DaysPer4Years = 1461;

		// Token: 0x040012BB RID: 4795
		internal const int DaysPer100Years = 36524;

		// Token: 0x040012BC RID: 4796
		internal const int DaysPer400Years = 146097;

		// Token: 0x040012BD RID: 4797
		internal const int DaysTo10000 = 3652059;

		// Token: 0x040012BE RID: 4798
		internal const long MaxMillis = 315537897600000L;

		// Token: 0x040012BF RID: 4799
		internal const int CAL_GREGORIAN = 1;

		// Token: 0x040012C0 RID: 4800
		internal const int CAL_GREGORIAN_US = 2;

		// Token: 0x040012C1 RID: 4801
		internal const int CAL_JAPAN = 3;

		// Token: 0x040012C2 RID: 4802
		internal const int CAL_TAIWAN = 4;

		// Token: 0x040012C3 RID: 4803
		internal const int CAL_KOREA = 5;

		// Token: 0x040012C4 RID: 4804
		internal const int CAL_HIJRI = 6;

		// Token: 0x040012C5 RID: 4805
		internal const int CAL_THAI = 7;

		// Token: 0x040012C6 RID: 4806
		internal const int CAL_HEBREW = 8;

		// Token: 0x040012C7 RID: 4807
		internal const int CAL_GREGORIAN_ME_FRENCH = 9;

		// Token: 0x040012C8 RID: 4808
		internal const int CAL_GREGORIAN_ARABIC = 10;

		// Token: 0x040012C9 RID: 4809
		internal const int CAL_GREGORIAN_XLIT_ENGLISH = 11;

		// Token: 0x040012CA RID: 4810
		internal const int CAL_GREGORIAN_XLIT_FRENCH = 12;

		// Token: 0x040012CB RID: 4811
		internal const int CAL_JULIAN = 13;

		// Token: 0x040012CC RID: 4812
		internal const int CAL_JAPANESELUNISOLAR = 14;

		// Token: 0x040012CD RID: 4813
		internal const int CAL_CHINESELUNISOLAR = 15;

		// Token: 0x040012CE RID: 4814
		internal const int CAL_SAKA = 16;

		// Token: 0x040012CF RID: 4815
		internal const int CAL_LUNAR_ETO_CHN = 17;

		// Token: 0x040012D0 RID: 4816
		internal const int CAL_LUNAR_ETO_KOR = 18;

		// Token: 0x040012D1 RID: 4817
		internal const int CAL_LUNAR_ETO_ROKUYOU = 19;

		// Token: 0x040012D2 RID: 4818
		internal const int CAL_KOREANLUNISOLAR = 20;

		// Token: 0x040012D3 RID: 4819
		internal const int CAL_TAIWANLUNISOLAR = 21;

		// Token: 0x040012D4 RID: 4820
		internal const int CAL_PERSIAN = 22;

		// Token: 0x040012D5 RID: 4821
		internal const int CAL_UMALQURA = 23;

		// Token: 0x040012D6 RID: 4822
		internal int m_currentEraValue = -1;

		// Token: 0x040012D7 RID: 4823
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly;

		// Token: 0x040012D8 RID: 4824
		[__DynamicallyInvokable]
		public const int CurrentEra = 0;

		// Token: 0x040012D9 RID: 4825
		internal int twoDigitYearMax = -1;
	}
}
