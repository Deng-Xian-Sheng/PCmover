﻿using System;
using System.Security;
using System.Text;

namespace System.Globalization
{
	// Token: 0x020003D5 RID: 981
	internal static class TimeSpanFormat
	{
		// Token: 0x060031E9 RID: 12777 RVA: 0x000BEE33 File Offset: 0x000BD033
		[SecuritySafeCritical]
		private static string IntToString(int n, int digits)
		{
			return ParseNumbers.IntToString(n, 10, digits, '0', 0);
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x000BEE44 File Offset: 0x000BD044
		internal static string Format(TimeSpan value, string format, IFormatProvider formatProvider)
		{
			if (format == null || format.Length == 0)
			{
				format = "c";
			}
			if (format.Length != 1)
			{
				return TimeSpanFormat.FormatCustomized(value, format, DateTimeFormatInfo.GetInstance(formatProvider));
			}
			char c = format[0];
			if (c == 'c' || c == 't' || c == 'T')
			{
				return TimeSpanFormat.FormatStandard(value, true, format, TimeSpanFormat.Pattern.Minimum);
			}
			if (c == 'g' || c == 'G')
			{
				DateTimeFormatInfo instance = DateTimeFormatInfo.GetInstance(formatProvider);
				if (value._ticks < 0L)
				{
					format = instance.FullTimeSpanNegativePattern;
				}
				else
				{
					format = instance.FullTimeSpanPositivePattern;
				}
				TimeSpanFormat.Pattern pattern;
				if (c == 'g')
				{
					pattern = TimeSpanFormat.Pattern.Minimum;
				}
				else
				{
					pattern = TimeSpanFormat.Pattern.Full;
				}
				return TimeSpanFormat.FormatStandard(value, false, format, pattern);
			}
			throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
		}

		// Token: 0x060031EB RID: 12779 RVA: 0x000BEEEC File Offset: 0x000BD0EC
		private static string FormatStandard(TimeSpan value, bool isInvariant, string format, TimeSpanFormat.Pattern pattern)
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			int num = (int)(value._ticks / 864000000000L);
			long num2 = value._ticks % 864000000000L;
			if (value._ticks < 0L)
			{
				num = -num;
				num2 = -num2;
			}
			int n = (int)(num2 / 36000000000L % 24L);
			int n2 = (int)(num2 / 600000000L % 60L);
			int n3 = (int)(num2 / 10000000L % 60L);
			int num3 = (int)(num2 % 10000000L);
			TimeSpanFormat.FormatLiterals formatLiterals;
			if (isInvariant)
			{
				if (value._ticks < 0L)
				{
					formatLiterals = TimeSpanFormat.NegativeInvariantFormatLiterals;
				}
				else
				{
					formatLiterals = TimeSpanFormat.PositiveInvariantFormatLiterals;
				}
			}
			else
			{
				formatLiterals = default(TimeSpanFormat.FormatLiterals);
				formatLiterals.Init(format, pattern == TimeSpanFormat.Pattern.Full);
			}
			if (num3 != 0)
			{
				num3 = (int)((long)num3 / (long)Math.Pow(10.0, (double)(7 - formatLiterals.ff)));
			}
			stringBuilder.Append(formatLiterals.Start);
			if (pattern == TimeSpanFormat.Pattern.Full || num != 0)
			{
				stringBuilder.Append(num);
				stringBuilder.Append(formatLiterals.DayHourSep);
			}
			stringBuilder.Append(TimeSpanFormat.IntToString(n, formatLiterals.hh));
			stringBuilder.Append(formatLiterals.HourMinuteSep);
			stringBuilder.Append(TimeSpanFormat.IntToString(n2, formatLiterals.mm));
			stringBuilder.Append(formatLiterals.MinuteSecondSep);
			stringBuilder.Append(TimeSpanFormat.IntToString(n3, formatLiterals.ss));
			if (!isInvariant && pattern == TimeSpanFormat.Pattern.Minimum)
			{
				int num4 = formatLiterals.ff;
				while (num4 > 0 && num3 % 10 == 0)
				{
					num3 /= 10;
					num4--;
				}
				if (num4 > 0)
				{
					stringBuilder.Append(formatLiterals.SecondFractionSep);
					stringBuilder.Append(num3.ToString(DateTimeFormat.fixedNumberFormats[num4 - 1], CultureInfo.InvariantCulture));
				}
			}
			else if (pattern == TimeSpanFormat.Pattern.Full || num3 != 0)
			{
				stringBuilder.Append(formatLiterals.SecondFractionSep);
				stringBuilder.Append(TimeSpanFormat.IntToString(num3, formatLiterals.ff));
			}
			stringBuilder.Append(formatLiterals.End);
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x000BF0E8 File Offset: 0x000BD2E8
		internal static string FormatCustomized(TimeSpan value, string format, DateTimeFormatInfo dtfi)
		{
			int num = (int)(value._ticks / 864000000000L);
			long num2 = value._ticks % 864000000000L;
			if (value._ticks < 0L)
			{
				num = -num;
				num2 = -num2;
			}
			int value2 = (int)(num2 / 36000000000L % 24L);
			int value3 = (int)(num2 / 600000000L % 60L);
			int value4 = (int)(num2 / 10000000L % 60L);
			int num3 = (int)(num2 % 10000000L);
			int i = 0;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
			while (i < format.Length)
			{
				char c = format[i];
				int num5;
				if (c <= 'F')
				{
					if (c <= '%')
					{
						if (c != '"')
						{
							if (c != '%')
							{
								goto IL_34D;
							}
							int num4 = DateTimeFormat.ParseNextChar(format, i);
							if (num4 >= 0 && num4 != 37)
							{
								stringBuilder.Append(TimeSpanFormat.FormatCustomized(value, ((char)num4).ToString(), dtfi));
								num5 = 2;
								goto IL_35D;
							}
							throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
						}
					}
					else if (c != '\'')
					{
						if (c != 'F')
						{
							goto IL_34D;
						}
						num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
						if (num5 > 7)
						{
							throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
						}
						long num6 = (long)num3;
						num6 /= (long)Math.Pow(10.0, (double)(7 - num5));
						int num7 = num5;
						while (num7 > 0 && num6 % 10L == 0L)
						{
							num6 /= 10L;
							num7--;
						}
						if (num7 > 0)
						{
							stringBuilder.Append(num6.ToString(DateTimeFormat.fixedNumberFormats[num7 - 1], CultureInfo.InvariantCulture));
							goto IL_35D;
						}
						goto IL_35D;
					}
					StringBuilder stringBuilder2 = new StringBuilder();
					num5 = DateTimeFormat.ParseQuoteString(format, i, stringBuilder2);
					stringBuilder.Append(stringBuilder2);
				}
				else if (c <= 'h')
				{
					if (c != '\\')
					{
						switch (c)
						{
						case 'd':
							num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
							if (num5 > 8)
							{
								throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
							}
							DateTimeFormat.FormatDigits(stringBuilder, num, num5, true);
							break;
						case 'e':
						case 'g':
							goto IL_34D;
						case 'f':
						{
							num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
							if (num5 > 7)
							{
								throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
							}
							long num6 = (long)num3;
							stringBuilder.Append((num6 / (long)Math.Pow(10.0, (double)(7 - num5))).ToString(DateTimeFormat.fixedNumberFormats[num5 - 1], CultureInfo.InvariantCulture));
							break;
						}
						case 'h':
							num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
							if (num5 > 2)
							{
								throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
							}
							DateTimeFormat.FormatDigits(stringBuilder, value2, num5);
							break;
						default:
							goto IL_34D;
						}
					}
					else
					{
						int num4 = DateTimeFormat.ParseNextChar(format, i);
						if (num4 < 0)
						{
							throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
						}
						stringBuilder.Append((char)num4);
						num5 = 2;
					}
				}
				else if (c != 'm')
				{
					if (c != 's')
					{
						goto IL_34D;
					}
					num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
					if (num5 > 2)
					{
						throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
					}
					DateTimeFormat.FormatDigits(stringBuilder, value4, num5);
				}
				else
				{
					num5 = DateTimeFormat.ParseRepeatPattern(format, i, c);
					if (num5 > 2)
					{
						throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
					}
					DateTimeFormat.FormatDigits(stringBuilder, value3, num5);
				}
				IL_35D:
				i += num5;
				continue;
				IL_34D:
				throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		// Token: 0x04001539 RID: 5433
		internal static readonly TimeSpanFormat.FormatLiterals PositiveInvariantFormatLiterals = TimeSpanFormat.FormatLiterals.InitInvariant(false);

		// Token: 0x0400153A RID: 5434
		internal static readonly TimeSpanFormat.FormatLiterals NegativeInvariantFormatLiterals = TimeSpanFormat.FormatLiterals.InitInvariant(true);

		// Token: 0x02000B71 RID: 2929
		internal enum Pattern
		{
			// Token: 0x04003472 RID: 13426
			None,
			// Token: 0x04003473 RID: 13427
			Minimum,
			// Token: 0x04003474 RID: 13428
			Full
		}

		// Token: 0x02000B72 RID: 2930
		internal struct FormatLiterals
		{
			// Token: 0x1700124E RID: 4686
			// (get) Token: 0x06006C27 RID: 27687 RVA: 0x001762ED File Offset: 0x001744ED
			internal string Start
			{
				get
				{
					return this.literals[0];
				}
			}

			// Token: 0x1700124F RID: 4687
			// (get) Token: 0x06006C28 RID: 27688 RVA: 0x001762F7 File Offset: 0x001744F7
			internal string DayHourSep
			{
				get
				{
					return this.literals[1];
				}
			}

			// Token: 0x17001250 RID: 4688
			// (get) Token: 0x06006C29 RID: 27689 RVA: 0x00176301 File Offset: 0x00174501
			internal string HourMinuteSep
			{
				get
				{
					return this.literals[2];
				}
			}

			// Token: 0x17001251 RID: 4689
			// (get) Token: 0x06006C2A RID: 27690 RVA: 0x0017630B File Offset: 0x0017450B
			internal string MinuteSecondSep
			{
				get
				{
					return this.literals[3];
				}
			}

			// Token: 0x17001252 RID: 4690
			// (get) Token: 0x06006C2B RID: 27691 RVA: 0x00176315 File Offset: 0x00174515
			internal string SecondFractionSep
			{
				get
				{
					return this.literals[4];
				}
			}

			// Token: 0x17001253 RID: 4691
			// (get) Token: 0x06006C2C RID: 27692 RVA: 0x0017631F File Offset: 0x0017451F
			internal string End
			{
				get
				{
					return this.literals[5];
				}
			}

			// Token: 0x06006C2D RID: 27693 RVA: 0x0017632C File Offset: 0x0017452C
			internal static TimeSpanFormat.FormatLiterals InitInvariant(bool isNegative)
			{
				TimeSpanFormat.FormatLiterals formatLiterals = new TimeSpanFormat.FormatLiterals
				{
					literals = new string[6]
				};
				formatLiterals.literals[0] = (isNegative ? "-" : string.Empty);
				formatLiterals.literals[1] = ".";
				formatLiterals.literals[2] = ":";
				formatLiterals.literals[3] = ":";
				formatLiterals.literals[4] = ".";
				formatLiterals.literals[5] = string.Empty;
				formatLiterals.AppCompatLiteral = ":.";
				formatLiterals.dd = 2;
				formatLiterals.hh = 2;
				formatLiterals.mm = 2;
				formatLiterals.ss = 2;
				formatLiterals.ff = 7;
				return formatLiterals;
			}

			// Token: 0x06006C2E RID: 27694 RVA: 0x001763DC File Offset: 0x001745DC
			internal void Init(string format, bool useInvariantFieldLengths)
			{
				this.literals = new string[6];
				for (int i = 0; i < this.literals.Length; i++)
				{
					this.literals[i] = string.Empty;
				}
				this.dd = 0;
				this.hh = 0;
				this.mm = 0;
				this.ss = 0;
				this.ff = 0;
				StringBuilder stringBuilder = StringBuilderCache.Acquire(16);
				bool flag = false;
				char c = '\'';
				int num = 0;
				int j = 0;
				while (j < format.Length)
				{
					char c2 = format[j];
					if (c2 <= 'F')
					{
						if (c2 <= '%')
						{
							if (c2 != '"')
							{
								if (c2 != '%')
								{
									goto IL_1AF;
								}
								goto IL_1AF;
							}
						}
						else if (c2 != '\'')
						{
							if (c2 != 'F')
							{
								goto IL_1AF;
							}
							goto IL_19A;
						}
						if (flag && c == format[j])
						{
							if (num < 0 || num > 5)
							{
								return;
							}
							this.literals[num] = stringBuilder.ToString();
							stringBuilder.Length = 0;
							flag = false;
						}
						else if (!flag)
						{
							c = format[j];
							flag = true;
						}
					}
					else if (c2 <= 'h')
					{
						if (c2 != '\\')
						{
							switch (c2)
							{
							case 'd':
								if (!flag)
								{
									num = 1;
									this.dd++;
								}
								break;
							case 'e':
							case 'g':
								goto IL_1AF;
							case 'f':
								goto IL_19A;
							case 'h':
								if (!flag)
								{
									num = 2;
									this.hh++;
								}
								break;
							default:
								goto IL_1AF;
							}
						}
						else
						{
							if (flag)
							{
								goto IL_1AF;
							}
							j++;
						}
					}
					else if (c2 != 'm')
					{
						if (c2 != 's')
						{
							goto IL_1AF;
						}
						if (!flag)
						{
							num = 4;
							this.ss++;
						}
					}
					else if (!flag)
					{
						num = 3;
						this.mm++;
					}
					IL_1BE:
					j++;
					continue;
					IL_19A:
					if (!flag)
					{
						num = 5;
						this.ff++;
						goto IL_1BE;
					}
					goto IL_1BE;
					IL_1AF:
					stringBuilder.Append(format[j]);
					goto IL_1BE;
				}
				this.AppCompatLiteral = this.MinuteSecondSep + this.SecondFractionSep;
				if (useInvariantFieldLengths)
				{
					this.dd = 2;
					this.hh = 2;
					this.mm = 2;
					this.ss = 2;
					this.ff = 7;
				}
				else
				{
					if (this.dd < 1 || this.dd > 2)
					{
						this.dd = 2;
					}
					if (this.hh < 1 || this.hh > 2)
					{
						this.hh = 2;
					}
					if (this.mm < 1 || this.mm > 2)
					{
						this.mm = 2;
					}
					if (this.ss < 1 || this.ss > 2)
					{
						this.ss = 2;
					}
					if (this.ff < 1 || this.ff > 7)
					{
						this.ff = 7;
					}
				}
				StringBuilderCache.Release(stringBuilder);
			}

			// Token: 0x04003475 RID: 13429
			internal string AppCompatLiteral;

			// Token: 0x04003476 RID: 13430
			internal int dd;

			// Token: 0x04003477 RID: 13431
			internal int hh;

			// Token: 0x04003478 RID: 13432
			internal int mm;

			// Token: 0x04003479 RID: 13433
			internal int ss;

			// Token: 0x0400347A RID: 13434
			internal int ff;

			// Token: 0x0400347B RID: 13435
			private string[] literals;
		}
	}
}
