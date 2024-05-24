using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;

namespace System.Globalization
{
	// Token: 0x020003CC RID: 972
	[ComVisible(true)]
	[Serializable]
	public class JapaneseCalendar : Calendar
	{
		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06003104 RID: 12548 RVA: 0x000BCCD9 File Offset: 0x000BAED9
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return JapaneseCalendar.calendarMinValue;
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06003105 RID: 12549 RVA: 0x000BCCE0 File Offset: 0x000BAEE0
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06003106 RID: 12550 RVA: 0x000BCCE7 File Offset: 0x000BAEE7
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		// Token: 0x06003107 RID: 12551 RVA: 0x000BCCEC File Offset: 0x000BAEEC
		internal static EraInfo[] GetEraInfo()
		{
			if (JapaneseCalendar.japaneseEraInfo == null)
			{
				JapaneseCalendar.japaneseEraInfo = JapaneseCalendar.GetErasFromRegistry();
				if (JapaneseCalendar.japaneseEraInfo == null)
				{
					JapaneseCalendar.japaneseEraInfo = new EraInfo[]
					{
						new EraInfo(4, 1989, 1, 8, 1988, 1, 8011, "平成", "平", "H"),
						new EraInfo(3, 1926, 12, 25, 1925, 1, 64, "昭和", "昭", "S"),
						new EraInfo(2, 1912, 7, 30, 1911, 1, 15, "大正", "大", "T"),
						new EraInfo(1, 1868, 1, 1, 1867, 1, 45, "明治", "明", "M")
					};
				}
			}
			return JapaneseCalendar.japaneseEraInfo;
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x000BCDD8 File Offset: 0x000BAFD8
		[SecuritySafeCritical]
		private static EraInfo[] GetErasFromRegistry()
		{
			int num = 0;
			EraInfo[] array = null;
			try
			{
				PermissionSet permissionSet = new PermissionSet(PermissionState.None);
				permissionSet.AddPermission(new RegistryPermission(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Nls\\Calendars\\Japanese\\Eras"));
				permissionSet.Assert();
				RegistryKey registryKey = RegistryKey.GetBaseKey(RegistryKey.HKEY_LOCAL_MACHINE).OpenSubKey("System\\CurrentControlSet\\Control\\Nls\\Calendars\\Japanese\\Eras", false);
				if (registryKey == null)
				{
					return null;
				}
				string[] valueNames = registryKey.GetValueNames();
				if (valueNames != null && valueNames.Length != 0)
				{
					array = new EraInfo[valueNames.Length];
					for (int i = 0; i < valueNames.Length; i++)
					{
						EraInfo eraFromValue = JapaneseCalendar.GetEraFromValue(valueNames[i], registryKey.GetValue(valueNames[i]).ToString());
						if (eraFromValue != null)
						{
							array[num] = eraFromValue;
							num++;
						}
					}
				}
			}
			catch (SecurityException)
			{
				return null;
			}
			catch (IOException)
			{
				return null;
			}
			catch (UnauthorizedAccessException)
			{
				return null;
			}
			if (num < 4)
			{
				return null;
			}
			Array.Resize<EraInfo>(ref array, num);
			Array.Sort<EraInfo>(array, new Comparison<EraInfo>(JapaneseCalendar.CompareEraRanges));
			for (int j = 0; j < array.Length; j++)
			{
				array[j].era = array.Length - j;
				if (j == 0)
				{
					array[0].maxEraYear = 9999 - array[0].yearOffset;
				}
				else
				{
					array[j].maxEraYear = array[j - 1].yearOffset + 1 - array[j].yearOffset;
				}
			}
			return array;
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x000BCF44 File Offset: 0x000BB144
		private static int CompareEraRanges(EraInfo a, EraInfo b)
		{
			return b.ticks.CompareTo(a.ticks);
		}

		// Token: 0x0600310A RID: 12554 RVA: 0x000BCF58 File Offset: 0x000BB158
		private static EraInfo GetEraFromValue(string value, string data)
		{
			if (value == null || data == null)
			{
				return null;
			}
			if (value.Length != 10)
			{
				return null;
			}
			int num;
			int startMonth;
			int startDay;
			if (!Number.TryParseInt32(value.Substring(0, 4), NumberStyles.None, NumberFormatInfo.InvariantInfo, out num) || !Number.TryParseInt32(value.Substring(5, 2), NumberStyles.None, NumberFormatInfo.InvariantInfo, out startMonth) || !Number.TryParseInt32(value.Substring(8, 2), NumberStyles.None, NumberFormatInfo.InvariantInfo, out startDay))
			{
				return null;
			}
			string[] array = data.Split(new char[]
			{
				'_'
			});
			if (array.Length != 4)
			{
				return null;
			}
			if (array[0].Length == 0 || array[1].Length == 0 || array[2].Length == 0 || array[3].Length == 0)
			{
				return null;
			}
			return new EraInfo(0, num, startMonth, startDay, num - 1, 1, 0, array[0], array[1], array[3]);
		}

		// Token: 0x0600310B RID: 12555 RVA: 0x000BD01B File Offset: 0x000BB21B
		internal static Calendar GetDefaultInstance()
		{
			if (JapaneseCalendar.s_defaultInstance == null)
			{
				JapaneseCalendar.s_defaultInstance = new JapaneseCalendar();
			}
			return JapaneseCalendar.s_defaultInstance;
		}

		// Token: 0x0600310C RID: 12556 RVA: 0x000BD03C File Offset: 0x000BB23C
		public JapaneseCalendar()
		{
			try
			{
				new CultureInfo("ja-JP");
			}
			catch (ArgumentException innerException)
			{
				throw new TypeInitializationException(base.GetType().FullName, innerException);
			}
			this.helper = new GregorianCalendarHelper(this, JapaneseCalendar.GetEraInfo());
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x0600310D RID: 12557 RVA: 0x000BD090 File Offset: 0x000BB290
		internal override int ID
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x0600310E RID: 12558 RVA: 0x000BD093 File Offset: 0x000BB293
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		// Token: 0x0600310F RID: 12559 RVA: 0x000BD0A2 File Offset: 0x000BB2A2
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.helper.AddYears(time, years);
		}

		// Token: 0x06003110 RID: 12560 RVA: 0x000BD0B1 File Offset: 0x000BB2B1
		public override int GetDaysInMonth(int year, int month, int era)
		{
			return this.helper.GetDaysInMonth(year, month, era);
		}

		// Token: 0x06003111 RID: 12561 RVA: 0x000BD0C1 File Offset: 0x000BB2C1
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		// Token: 0x06003112 RID: 12562 RVA: 0x000BD0D0 File Offset: 0x000BB2D0
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		// Token: 0x06003113 RID: 12563 RVA: 0x000BD0DE File Offset: 0x000BB2DE
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		// Token: 0x06003114 RID: 12564 RVA: 0x000BD0EC File Offset: 0x000BB2EC
		public override int GetDayOfYear(DateTime time)
		{
			return this.helper.GetDayOfYear(time);
		}

		// Token: 0x06003115 RID: 12565 RVA: 0x000BD0FA File Offset: 0x000BB2FA
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		// Token: 0x06003116 RID: 12566 RVA: 0x000BD109 File Offset: 0x000BB309
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		// Token: 0x06003117 RID: 12567 RVA: 0x000BD119 File Offset: 0x000BB319
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x000BD127 File Offset: 0x000BB327
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x000BD135 File Offset: 0x000BB335
		public override int GetYear(DateTime time)
		{
			return this.helper.GetYear(time);
		}

		// Token: 0x0600311A RID: 12570 RVA: 0x000BD143 File Offset: 0x000BB343
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			return this.helper.IsLeapDay(year, month, day, era);
		}

		// Token: 0x0600311B RID: 12571 RVA: 0x000BD155 File Offset: 0x000BB355
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		// Token: 0x0600311C RID: 12572 RVA: 0x000BD164 File Offset: 0x000BB364
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			return this.helper.GetLeapMonth(year, era);
		}

		// Token: 0x0600311D RID: 12573 RVA: 0x000BD173 File Offset: 0x000BB373
		public override bool IsLeapMonth(int year, int month, int era)
		{
			return this.helper.IsLeapMonth(year, month, era);
		}

		// Token: 0x0600311E RID: 12574 RVA: 0x000BD184 File Offset: 0x000BB384
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		// Token: 0x0600311F RID: 12575 RVA: 0x000BD1AC File Offset: 0x000BB3AC
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

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06003120 RID: 12576 RVA: 0x000BD216 File Offset: 0x000BB416
		public override int[] Eras
		{
			get
			{
				return this.helper.Eras;
			}
		}

		// Token: 0x06003121 RID: 12577 RVA: 0x000BD224 File Offset: 0x000BB424
		internal static string[] EraNames()
		{
			EraInfo[] eraInfo = JapaneseCalendar.GetEraInfo();
			string[] array = new string[eraInfo.Length];
			for (int i = 0; i < eraInfo.Length; i++)
			{
				array[i] = eraInfo[eraInfo.Length - i - 1].eraName;
			}
			return array;
		}

		// Token: 0x06003122 RID: 12578 RVA: 0x000BD260 File Offset: 0x000BB460
		internal static string[] AbbrevEraNames()
		{
			EraInfo[] eraInfo = JapaneseCalendar.GetEraInfo();
			string[] array = new string[eraInfo.Length];
			for (int i = 0; i < eraInfo.Length; i++)
			{
				array[i] = eraInfo[eraInfo.Length - i - 1].abbrevEraName;
			}
			return array;
		}

		// Token: 0x06003123 RID: 12579 RVA: 0x000BD29C File Offset: 0x000BB49C
		internal static string[] EnglishEraNames()
		{
			EraInfo[] eraInfo = JapaneseCalendar.GetEraInfo();
			string[] array = new string[eraInfo.Length];
			for (int i = 0; i < eraInfo.Length; i++)
			{
				array[i] = eraInfo[eraInfo.Length - i - 1].englishEraName;
			}
			return array;
		}

		// Token: 0x06003124 RID: 12580 RVA: 0x000BD2D8 File Offset: 0x000BB4D8
		internal override bool IsValidYear(int year, int era)
		{
			return this.helper.IsValidYear(year, era);
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06003125 RID: 12581 RVA: 0x000BD2E7 File Offset: 0x000BB4E7
		// (set) Token: 0x06003126 RID: 12582 RVA: 0x000BD30C File Offset: 0x000BB50C
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

		// Token: 0x04001501 RID: 5377
		internal static readonly DateTime calendarMinValue = new DateTime(1868, 9, 8);

		// Token: 0x04001502 RID: 5378
		internal static volatile EraInfo[] japaneseEraInfo;

		// Token: 0x04001503 RID: 5379
		private const string c_japaneseErasHive = "System\\CurrentControlSet\\Control\\Nls\\Calendars\\Japanese\\Eras";

		// Token: 0x04001504 RID: 5380
		private const string c_japaneseErasHivePermissionList = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Nls\\Calendars\\Japanese\\Eras";

		// Token: 0x04001505 RID: 5381
		internal static volatile Calendar s_defaultInstance;

		// Token: 0x04001506 RID: 5382
		internal GregorianCalendarHelper helper;

		// Token: 0x04001507 RID: 5383
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 99;
	}
}
