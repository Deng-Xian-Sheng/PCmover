using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	// Token: 0x020003D4 RID: 980
	[ComVisible(true)]
	[Serializable]
	public class ThaiBuddhistCalendar : Calendar
	{
		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x060031CE RID: 12750 RVA: 0x000BEBF5 File Offset: 0x000BCDF5
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x060031CF RID: 12751 RVA: 0x000BEBFC File Offset: 0x000BCDFC
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x060031D0 RID: 12752 RVA: 0x000BEC03 File Offset: 0x000BCE03
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x000BEC06 File Offset: 0x000BCE06
		public ThaiBuddhistCalendar()
		{
			this.helper = new GregorianCalendarHelper(this, ThaiBuddhistCalendar.thaiBuddhistEraInfo);
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x060031D2 RID: 12754 RVA: 0x000BEC1F File Offset: 0x000BCE1F
		internal override int ID
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x000BEC22 File Offset: 0x000BCE22
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		// Token: 0x060031D4 RID: 12756 RVA: 0x000BEC31 File Offset: 0x000BCE31
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.helper.AddYears(time, years);
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x000BEC40 File Offset: 0x000BCE40
		public override int GetDaysInMonth(int year, int month, int era)
		{
			return this.helper.GetDaysInMonth(year, month, era);
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x000BEC50 File Offset: 0x000BCE50
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x000BEC5F File Offset: 0x000BCE5F
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x000BEC6D File Offset: 0x000BCE6D
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x000BEC7B File Offset: 0x000BCE7B
		public override int GetDayOfYear(DateTime time)
		{
			return this.helper.GetDayOfYear(time);
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x000BEC89 File Offset: 0x000BCE89
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x000BEC98 File Offset: 0x000BCE98
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x000BECA8 File Offset: 0x000BCEA8
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x000BECB6 File Offset: 0x000BCEB6
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000BECC4 File Offset: 0x000BCEC4
		public override int GetYear(DateTime time)
		{
			return this.helper.GetYear(time);
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x000BECD2 File Offset: 0x000BCED2
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			return this.helper.IsLeapDay(year, month, day, era);
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x000BECE4 File Offset: 0x000BCEE4
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x000BECF3 File Offset: 0x000BCEF3
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			return this.helper.GetLeapMonth(year, era);
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x000BED02 File Offset: 0x000BCF02
		public override bool IsLeapMonth(int year, int month, int era)
		{
			return this.helper.IsLeapMonth(year, month, era);
		}

		// Token: 0x060031E3 RID: 12771 RVA: 0x000BED14 File Offset: 0x000BCF14
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x060031E4 RID: 12772 RVA: 0x000BED39 File Offset: 0x000BCF39
		public override int[] Eras
		{
			get
			{
				return this.helper.Eras;
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x060031E5 RID: 12773 RVA: 0x000BED46 File Offset: 0x000BCF46
		// (set) Token: 0x060031E6 RID: 12774 RVA: 0x000BED70 File Offset: 0x000BCF70
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 2572);
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

		// Token: 0x060031E7 RID: 12775 RVA: 0x000BEDD3 File Offset: 0x000BCFD3
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.helper.ToFourDigitYear(year, this.TwoDigitYearMax);
		}

		// Token: 0x04001535 RID: 5429
		internal static EraInfo[] thaiBuddhistEraInfo = new EraInfo[]
		{
			new EraInfo(1, 1, 1, 1, -543, 544, 10542)
		};

		// Token: 0x04001536 RID: 5430
		public const int ThaiBuddhistEra = 1;

		// Token: 0x04001537 RID: 5431
		internal GregorianCalendarHelper helper;

		// Token: 0x04001538 RID: 5432
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 2572;
	}
}
