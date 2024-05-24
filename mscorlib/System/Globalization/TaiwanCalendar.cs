using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003D1 RID: 977
	[ComVisible(true)]
	[Serializable]
	public class TaiwanCalendar : Calendar
	{
		// Token: 0x06003176 RID: 12662 RVA: 0x000BDF3B File Offset: 0x000BC13B
		internal static Calendar GetDefaultInstance()
		{
			if (TaiwanCalendar.s_defaultInstance == null)
			{
				TaiwanCalendar.s_defaultInstance = new TaiwanCalendar();
			}
			return TaiwanCalendar.s_defaultInstance;
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06003177 RID: 12663 RVA: 0x000BDF59 File Offset: 0x000BC159
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return TaiwanCalendar.calendarMinValue;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06003178 RID: 12664 RVA: 0x000BDF60 File Offset: 0x000BC160
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06003179 RID: 12665 RVA: 0x000BDF67 File Offset: 0x000BC167
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x0600317A RID: 12666 RVA: 0x000BDF6C File Offset: 0x000BC16C
		public TaiwanCalendar()
		{
			try
			{
				new CultureInfo("zh-TW");
			}
			catch (ArgumentException innerException)
			{
				throw new TypeInitializationException(base.GetType().FullName, innerException);
			}
			this.helper = new GregorianCalendarHelper(this, TaiwanCalendar.taiwanEraInfo);
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x0600317B RID: 12667 RVA: 0x000BDFC0 File Offset: 0x000BC1C0
		internal override int ID
		{
			get
			{
				return 4;
			}
		}

		// Token: 0x0600317C RID: 12668 RVA: 0x000BDFC3 File Offset: 0x000BC1C3
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		// Token: 0x0600317D RID: 12669 RVA: 0x000BDFD2 File Offset: 0x000BC1D2
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.helper.AddYears(time, years);
		}

		// Token: 0x0600317E RID: 12670 RVA: 0x000BDFE1 File Offset: 0x000BC1E1
		public override int GetDaysInMonth(int year, int month, int era)
		{
			return this.helper.GetDaysInMonth(year, month, era);
		}

		// Token: 0x0600317F RID: 12671 RVA: 0x000BDFF1 File Offset: 0x000BC1F1
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x000BE000 File Offset: 0x000BC200
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		// Token: 0x06003181 RID: 12673 RVA: 0x000BE00E File Offset: 0x000BC20E
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		// Token: 0x06003182 RID: 12674 RVA: 0x000BE01C File Offset: 0x000BC21C
		public override int GetDayOfYear(DateTime time)
		{
			return this.helper.GetDayOfYear(time);
		}

		// Token: 0x06003183 RID: 12675 RVA: 0x000BE02A File Offset: 0x000BC22A
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		// Token: 0x06003184 RID: 12676 RVA: 0x000BE039 File Offset: 0x000BC239
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x000BE049 File Offset: 0x000BC249
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000BE057 File Offset: 0x000BC257
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x000BE065 File Offset: 0x000BC265
		public override int GetYear(DateTime time)
		{
			return this.helper.GetYear(time);
		}

		// Token: 0x06003188 RID: 12680 RVA: 0x000BE073 File Offset: 0x000BC273
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			return this.helper.IsLeapDay(year, month, day, era);
		}

		// Token: 0x06003189 RID: 12681 RVA: 0x000BE085 File Offset: 0x000BC285
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x000BE094 File Offset: 0x000BC294
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			return this.helper.GetLeapMonth(year, era);
		}

		// Token: 0x0600318B RID: 12683 RVA: 0x000BE0A3 File Offset: 0x000BC2A3
		public override bool IsLeapMonth(int year, int month, int era)
		{
			return this.helper.IsLeapMonth(year, month, era);
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x000BE0B4 File Offset: 0x000BC2B4
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600318D RID: 12685 RVA: 0x000BE0D9 File Offset: 0x000BC2D9
		public override int[] Eras
		{
			get
			{
				return this.helper.Eras;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x0600318E RID: 12686 RVA: 0x000BE0E6 File Offset: 0x000BC2E6
		// (set) Token: 0x0600318F RID: 12687 RVA: 0x000BE10C File Offset: 0x000BC30C
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 99);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > this.helper.MaxYear)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, this.helper.MaxYear));
				}
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x06003190 RID: 12688 RVA: 0x000BE170 File Offset: 0x000BC370
		public override int ToFourDigitYear(int year)
		{
			if (year <= 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			if (year > this.helper.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, this.helper.MaxYear));
			}
			return year;
		}

		// Token: 0x04001519 RID: 5401
		internal static EraInfo[] taiwanEraInfo = new EraInfo[]
		{
			new EraInfo(1, 1912, 1, 1, 1911, 1, 8088)
		};

		// Token: 0x0400151A RID: 5402
		internal static volatile Calendar s_defaultInstance;

		// Token: 0x0400151B RID: 5403
		internal GregorianCalendarHelper helper;

		// Token: 0x0400151C RID: 5404
		internal static readonly DateTime calendarMinValue = new DateTime(1912, 1, 1);

		// Token: 0x0400151D RID: 5405
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 99;
	}
}
