using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	// Token: 0x020003BC RID: 956
	[ComVisible(true)]
	[Serializable]
	public class GregorianCalendar : Calendar
	{
		// Token: 0x06002F57 RID: 12119 RVA: 0x000B5D68 File Offset: 0x000B3F68
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			if (this.m_type < GregorianCalendarTypes.Localized || this.m_type > GregorianCalendarTypes.TransliteratedFrench)
			{
				throw new SerializationException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Serialization_MemberOutOfRange"), "type", "GregorianCalendar"));
			}
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06002F58 RID: 12120 RVA: 0x000B5DA1 File Offset: 0x000B3FA1
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06002F59 RID: 12121 RVA: 0x000B5DA8 File Offset: 0x000B3FA8
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06002F5A RID: 12122 RVA: 0x000B5DAF File Offset: 0x000B3FAF
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x06002F5B RID: 12123 RVA: 0x000B5DB2 File Offset: 0x000B3FB2
		internal static Calendar GetDefaultInstance()
		{
			if (GregorianCalendar.s_defaultInstance == null)
			{
				GregorianCalendar.s_defaultInstance = new GregorianCalendar();
			}
			return GregorianCalendar.s_defaultInstance;
		}

		// Token: 0x06002F5C RID: 12124 RVA: 0x000B5DD0 File Offset: 0x000B3FD0
		public GregorianCalendar() : this(GregorianCalendarTypes.Localized)
		{
		}

		// Token: 0x06002F5D RID: 12125 RVA: 0x000B5DDC File Offset: 0x000B3FDC
		public GregorianCalendar(GregorianCalendarTypes type)
		{
			if (type < GregorianCalendarTypes.Localized || type > GregorianCalendarTypes.TransliteratedFrench)
			{
				throw new ArgumentOutOfRangeException("type", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					GregorianCalendarTypes.Localized,
					GregorianCalendarTypes.TransliteratedFrench
				}));
			}
			this.m_type = type;
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06002F5E RID: 12126 RVA: 0x000B5E2D File Offset: 0x000B402D
		// (set) Token: 0x06002F5F RID: 12127 RVA: 0x000B5E35 File Offset: 0x000B4035
		public virtual GregorianCalendarTypes CalendarType
		{
			get
			{
				return this.m_type;
			}
			set
			{
				base.VerifyWritable();
				if (value - GregorianCalendarTypes.Localized <= 1 || value - GregorianCalendarTypes.MiddleEastFrench <= 3)
				{
					this.m_type = value;
					return;
				}
				throw new ArgumentOutOfRangeException("m_type", Environment.GetResourceString("ArgumentOutOfRange_Enum"));
			}
		}

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06002F60 RID: 12128 RVA: 0x000B5E66 File Offset: 0x000B4066
		internal override int ID
		{
			get
			{
				return (int)this.m_type;
			}
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x000B5E70 File Offset: 0x000B4070
		internal virtual int GetDatePart(long ticks, int part)
		{
			int i = (int)(ticks / 864000000000L);
			int num = i / 146097;
			i -= num * 146097;
			int num2 = i / 36524;
			if (num2 == 4)
			{
				num2 = 3;
			}
			i -= num2 * 36524;
			int num3 = i / 1461;
			i -= num3 * 1461;
			int num4 = i / 365;
			if (num4 == 4)
			{
				num4 = 3;
			}
			if (part == 0)
			{
				return num * 400 + num2 * 100 + num3 * 4 + num4 + 1;
			}
			i -= num4 * 365;
			if (part == 1)
			{
				return i + 1;
			}
			int[] array = (num4 == 3 && (num3 != 24 || num2 == 3)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			int num5 = i >> 6;
			while (i >= array[num5])
			{
				num5++;
			}
			if (part == 2)
			{
				return num5;
			}
			return i - array[num5 - 1] + 1;
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x000B5F54 File Offset: 0x000B4154
		internal static long GetAbsoluteDate(int year, int month, int day)
		{
			if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
			{
				int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
				if (day >= 1 && day <= array[month] - array[month - 1])
				{
					int num = year - 1;
					int num2 = num * 365 + num / 4 - num / 100 + num / 400 + array[month - 1] + day - 1;
					return (long)num2;
				}
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x000B5FE1 File Offset: 0x000B41E1
		internal virtual long DateToTicks(int year, int month, int day)
		{
			return GregorianCalendar.GetAbsoluteDate(year, month, day) * 864000000000L;
		}

		// Token: 0x06002F64 RID: 12132 RVA: 0x000B5FF8 File Offset: 0x000B41F8
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num;
			int num2;
			int num3;
			time.GetDatePart(out num, out num2, out num3);
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
			int[] array = (num % 4 == 0 && (num % 100 != 0 || num % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			int num5 = array[num2] - array[num2 - 1];
			if (num3 > num5)
			{
				num3 = num5;
			}
			long ticks = this.DateToTicks(num, num2, num3) + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		// Token: 0x06002F65 RID: 12133 RVA: 0x000B60F1 File Offset: 0x000B42F1
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		// Token: 0x06002F66 RID: 12134 RVA: 0x000B60FE File Offset: 0x000B42FE
		public override int GetDayOfMonth(DateTime time)
		{
			return time.Day;
		}

		// Token: 0x06002F67 RID: 12135 RVA: 0x000B6107 File Offset: 0x000B4307
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x000B6120 File Offset: 0x000B4320
		public override int GetDayOfYear(DateTime time)
		{
			return time.DayOfYear;
		}

		// Token: 0x06002F69 RID: 12137 RVA: 0x000B612C File Offset: 0x000B432C
		public override int GetDaysInMonth(int year, int month, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					9999
				}));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
			int[] array = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) ? GregorianCalendar.DaysToMonth366 : GregorianCalendar.DaysToMonth365;
			return array[month] - array[month - 1];
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x000B61E0 File Offset: 0x000B43E0
		public override int GetDaysInYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0))
			{
				return 365;
			}
			return 366;
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x000B6263 File Offset: 0x000B4463
		public override int GetEra(DateTime time)
		{
			return 1;
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06002F6C RID: 12140 RVA: 0x000B6266 File Offset: 0x000B4466
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					1
				};
			}
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x000B6272 File Offset: 0x000B4472
		public override int GetMonth(DateTime time)
		{
			return time.Month;
		}

		// Token: 0x06002F6E RID: 12142 RVA: 0x000B627C File Offset: 0x000B447C
		public override int GetMonthsInYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year >= 1 && year <= 9999)
			{
				return 12;
			}
			throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
		}

		// Token: 0x06002F6F RID: 12143 RVA: 0x000B62E2 File Offset: 0x000B44E2
		public override int GetYear(DateTime time)
		{
			return time.Year;
		}

		// Token: 0x06002F70 RID: 12144 RVA: 0x000B62EC File Offset: 0x000B44EC
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					12
				}));
			}
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					9999
				}));
			}
			if (day < 1 || day > this.GetDaysInMonth(year, month))
			{
				throw new ArgumentOutOfRangeException("day", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					this.GetDaysInMonth(year, month)
				}));
			}
			return this.IsLeapYear(year) && (month == 2 && day == 29);
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x000B63E8 File Offset: 0x000B45E8
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			return 0;
		}

		// Token: 0x06002F72 RID: 12146 RVA: 0x000B6450 File Offset: 0x000B4650
		public override bool IsLeapMonth(int year, int month, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year < 1 || year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					1,
					12
				}));
			}
			return false;
		}

		// Token: 0x06002F73 RID: 12147 RVA: 0x000B64EC File Offset: 0x000B46EC
		public override bool IsLeapYear(int year, int era)
		{
			if (era != 0 && era != 1)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
			if (year >= 1 && year <= 9999)
			{
				return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
			}
			throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
		}

		// Token: 0x06002F74 RID: 12148 RVA: 0x000B6569 File Offset: 0x000B4769
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			if (era == 0 || era == 1)
			{
				return new DateTime(year, month, day, hour, minute, second, millisecond);
			}
			throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x000B6599 File Offset: 0x000B4799
		internal override bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result)
		{
			if (era == 0 || era == 1)
			{
				return DateTime.TryCreate(year, month, day, hour, minute, second, millisecond, out result);
			}
			result = DateTime.MinValue;
			return false;
		}

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06002F76 RID: 12150 RVA: 0x000B65C4 File Offset: 0x000B47C4
		// (set) Token: 0x06002F77 RID: 12151 RVA: 0x000B65EC File Offset: 0x000B47EC
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 2029);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > 9999)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, 9999));
				}
				this.twoDigitYearMax = value;
			}
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x000B6644 File Offset: 0x000B4844
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year > 9999)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9999));
			}
			return base.ToFourDigitYear(year);
		}

		// Token: 0x0400141B RID: 5147
		public const int ADEra = 1;

		// Token: 0x0400141C RID: 5148
		internal const int DatePartYear = 0;

		// Token: 0x0400141D RID: 5149
		internal const int DatePartDayOfYear = 1;

		// Token: 0x0400141E RID: 5150
		internal const int DatePartMonth = 2;

		// Token: 0x0400141F RID: 5151
		internal const int DatePartDay = 3;

		// Token: 0x04001420 RID: 5152
		internal const int MaxYear = 9999;

		// Token: 0x04001421 RID: 5153
		internal GregorianCalendarTypes m_type;

		// Token: 0x04001422 RID: 5154
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
			334,
			365
		};

		// Token: 0x04001423 RID: 5155
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
			335,
			366
		};

		// Token: 0x04001424 RID: 5156
		private static volatile Calendar s_defaultInstance;

		// Token: 0x04001425 RID: 5157
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 2029;
	}
}
