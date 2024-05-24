using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003CD RID: 973
	[ComVisible(true)]
	[Serializable]
	public class KoreanCalendar : Calendar
	{
		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06003128 RID: 12584 RVA: 0x000BD383 File Offset: 0x000BB583
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06003129 RID: 12585 RVA: 0x000BD38A File Offset: 0x000BB58A
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x0600312A RID: 12586 RVA: 0x000BD391 File Offset: 0x000BB591
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x0600312B RID: 12587 RVA: 0x000BD394 File Offset: 0x000BB594
		public KoreanCalendar()
		{
			try
			{
				new CultureInfo("ko-KR");
			}
			catch (ArgumentException innerException)
			{
				throw new TypeInitializationException(base.GetType().FullName, innerException);
			}
			this.helper = new GregorianCalendarHelper(this, KoreanCalendar.koreanEraInfo);
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x0600312C RID: 12588 RVA: 0x000BD3E8 File Offset: 0x000BB5E8
		internal override int ID
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x000BD3EB File Offset: 0x000BB5EB
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x000BD3FA File Offset: 0x000BB5FA
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.helper.AddYears(time, years);
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x000BD409 File Offset: 0x000BB609
		public override int GetDaysInMonth(int year, int month, int era)
		{
			return this.helper.GetDaysInMonth(year, month, era);
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x000BD419 File Offset: 0x000BB619
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x000BD428 File Offset: 0x000BB628
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x000BD436 File Offset: 0x000BB636
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		// Token: 0x06003133 RID: 12595 RVA: 0x000BD444 File Offset: 0x000BB644
		public override int GetDayOfYear(DateTime time)
		{
			return this.helper.GetDayOfYear(time);
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x000BD452 File Offset: 0x000BB652
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		// Token: 0x06003135 RID: 12597 RVA: 0x000BD461 File Offset: 0x000BB661
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		// Token: 0x06003136 RID: 12598 RVA: 0x000BD471 File Offset: 0x000BB671
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		// Token: 0x06003137 RID: 12599 RVA: 0x000BD47F File Offset: 0x000BB67F
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		// Token: 0x06003138 RID: 12600 RVA: 0x000BD48D File Offset: 0x000BB68D
		public override int GetYear(DateTime time)
		{
			return this.helper.GetYear(time);
		}

		// Token: 0x06003139 RID: 12601 RVA: 0x000BD49B File Offset: 0x000BB69B
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			return this.helper.IsLeapDay(year, month, day, era);
		}

		// Token: 0x0600313A RID: 12602 RVA: 0x000BD4AD File Offset: 0x000BB6AD
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x000BD4BC File Offset: 0x000BB6BC
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			return this.helper.GetLeapMonth(year, era);
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x000BD4CB File Offset: 0x000BB6CB
		public override bool IsLeapMonth(int year, int month, int era)
		{
			return this.helper.IsLeapMonth(year, month, era);
		}

		// Token: 0x0600313D RID: 12605 RVA: 0x000BD4DC File Offset: 0x000BB6DC
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600313E RID: 12606 RVA: 0x000BD501 File Offset: 0x000BB701
		public override int[] Eras
		{
			get
			{
				return this.helper.Eras;
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x0600313F RID: 12607 RVA: 0x000BD50E File Offset: 0x000BB70E
		// (set) Token: 0x06003140 RID: 12608 RVA: 0x000BD538 File Offset: 0x000BB738
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 4362);
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

		// Token: 0x06003141 RID: 12609 RVA: 0x000BD59B File Offset: 0x000BB79B
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.helper.ToFourDigitYear(year, this.TwoDigitYearMax);
		}

		// Token: 0x04001508 RID: 5384
		public const int KoreanEra = 1;

		// Token: 0x04001509 RID: 5385
		internal static EraInfo[] koreanEraInfo = new EraInfo[]
		{
			new EraInfo(1, 1, 1, 1, -2333, 2334, 12332)
		};

		// Token: 0x0400150A RID: 5386
		internal GregorianCalendarHelper helper;

		// Token: 0x0400150B RID: 5387
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 4362;
	}
}
