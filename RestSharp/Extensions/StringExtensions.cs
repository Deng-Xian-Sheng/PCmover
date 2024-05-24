using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RestSharp.Extensions
{
	// Token: 0x0200004E RID: 78
	[NullableContext(1)]
	[Nullable(0)]
	public static class StringExtensions
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x0000C0E4 File Offset: 0x0000A2E4
		public static string UrlDecode(this string input)
		{
			return HttpUtility.UrlDecode(input);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0000C0EC File Offset: 0x0000A2EC
		public static string UrlEncode(this string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (input.Length <= 32766)
			{
				return Uri.EscapeDataString(input);
			}
			StringBuilder stringBuilder = new StringBuilder(input.Length * 2);
			string text;
			for (int i = 0; i < input.Length; i += text.Length)
			{
				int num = Math.Min(input.Length - i, 32766);
				while (CharUnicodeInfo.GetUnicodeCategory(input[i + num - 1]) == UnicodeCategory.Surrogate)
				{
					num--;
				}
				text = input.Substring(i, num);
				stringBuilder.Append(Uri.EscapeDataString(text));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0000C188 File Offset: 0x0000A388
		public static string UrlEncode(this string input, Encoding encoding)
		{
			string text = HttpUtility.UrlEncode(input, encoding);
			if (text == null)
			{
				return null;
			}
			return text.Replace("+", "%20");
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000C1A6 File Offset: 0x0000A3A6
		public static bool HasValue(this string input)
		{
			return !string.IsNullOrEmpty(input);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000C1B1 File Offset: 0x0000A3B1
		public static string RemoveUnderscoresAndDashes(this string input)
		{
			return input.Replace("_", "").Replace("-", "");
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
		public static DateTime ParseJsonDate(this string input, CultureInfo culture)
		{
			input = input.Replace("\n", "");
			input = input.Replace("\r", "");
			input = input.RemoveSurroundingQuotes();
			long num;
			if (long.TryParse(input, out num))
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				if (num <= 253402300799L)
				{
					return dateTime.AddSeconds((double)num);
				}
				return dateTime.AddMilliseconds((double)num);
			}
			else
			{
				if (input.Contains("/Date("))
				{
					return StringExtensions.ExtractDate(input, StringExtensions.DateRegex, culture);
				}
				if (input.Contains("new Date("))
				{
					input = input.Replace(" ", "");
					return StringExtensions.ExtractDate(input, StringExtensions.NewDateRegex, culture);
				}
				return StringExtensions.ParseFormattedDate(input, culture);
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0000C296 File Offset: 0x0000A496
		private static string RemoveSurroundingQuotes(this string input)
		{
			if (input.StartsWith("\"") && input.EndsWith("\""))
			{
				input = input.Substring(1, input.Length - 2);
			}
			return input;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		private static DateTime ParseFormattedDate(string input, CultureInfo culture)
		{
			string[] formats = new string[]
			{
				"u",
				"s",
				"yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'",
				"yyyy-MM-ddTHH:mm:ssZ",
				"yyyy-MM-dd HH:mm:ssZ",
				"yyyy-MM-ddTHH:mm:ss",
				"yyyy-MM-ddTHH:mm:sszzzzzz",
				"yyyy-MM-ddTHH:mm:ss.fffZ",
				"M/d/yyyy h:mm:ss tt"
			};
			DateTime result;
			if (DateTime.TryParseExact(input, formats, culture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
			{
				return result;
			}
			if (!DateTime.TryParse(input, culture, DateTimeStyles.None, out result))
			{
				return default(DateTime);
			}
			return result;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0000C348 File Offset: 0x0000A548
		private static DateTime ExtractDate(string input, Regex regex, CultureInfo culture)
		{
			DateTime result = DateTime.MinValue;
			if (!regex.IsMatch(input))
			{
				return result;
			}
			Match match = regex.Matches(input)[0];
			long num = Convert.ToInt64(match.Groups[1].Value);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			result = dateTime.AddMilliseconds((double)num);
			if (match.Groups.Count <= 2 || string.IsNullOrEmpty(match.Groups[3].Value))
			{
				return result;
			}
			DateTime dateTime2 = DateTime.ParseExact(match.Groups[3].Value, "HHmm", culture);
			return (match.Groups[2].Value == "+") ? result.Add(dateTime2.TimeOfDay) : result.Subtract(dateTime2.TimeOfDay);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000C42A File Offset: 0x0000A62A
		public static string ToPascalCase(this string lowercaseAndUnderscoredWord, CultureInfo culture)
		{
			return lowercaseAndUnderscoredWord.ToPascalCase(true, culture);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000C434 File Offset: 0x0000A634
		public static string ToPascalCase(this string text, bool removeUnderscores, CultureInfo culture)
		{
			StringExtensions.<>c__DisplayClass22_0 CS$<>8__locals1 = new StringExtensions.<>c__DisplayClass22_0();
			CS$<>8__locals1.culture = culture;
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			text = text.Replace('_', ' ');
			string separator = removeUnderscores ? string.Empty : "_";
			return (from x in text.Split(new char[]
			{
				' '
			})
			where x.Length > 0
			select x).Select(new Func<string, string>(CS$<>8__locals1.<ToPascalCase>g__CaseWord|1)).JoinToString(separator);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000C4C0 File Offset: 0x0000A6C0
		public static string ToCamelCase(this string lowercaseAndUnderscoredWord, CultureInfo culture)
		{
			return lowercaseAndUnderscoredWord.ToPascalCase(culture).MakeInitialLowerCase(culture);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000C4CF File Offset: 0x0000A6CF
		public static string MakeInitialLowerCase(this string word, CultureInfo culture)
		{
			return word.Substring(0, 1).ToLower(culture) + word.Substring(1);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000C4EB File Offset: 0x0000A6EB
		public static string AddUnderscores(this string pascalCasedWord)
		{
			return StringExtensions.AddUnderscoresRegex1.Replace(StringExtensions.AddUnderscoresRegex2.Replace(StringExtensions.AddUnderscoresRegex3.Replace(pascalCasedWord, "$1_$2"), "$1_$2"), "_");
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000C51B File Offset: 0x0000A71B
		public static string AddDashes(this string pascalCasedWord)
		{
			return StringExtensions.AddDashesRegex1.Replace(StringExtensions.AddDashesRegex2.Replace(StringExtensions.AddDashesRegex3.Replace(pascalCasedWord, "$1-$2"), "$1-$2"), "-");
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000C54B File Offset: 0x0000A74B
		public static string AddUnderscorePrefix(this string pascalCasedWord)
		{
			return "_" + pascalCasedWord;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000C558 File Offset: 0x0000A758
		public static string AddSpaces(this string pascalCasedWord)
		{
			return StringExtensions.AddSpacesRegex1.Replace(StringExtensions.AddSpacesRegex2.Replace(StringExtensions.AddSpacesRegex3.Replace(pascalCasedWord, "$1 $2"), "$1 $2"), " ");
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000C588 File Offset: 0x0000A788
		[NullableContext(2)]
		internal static bool IsEmpty(this string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000C590 File Offset: 0x0000A790
		internal static bool IsNotEmpty(this string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000C59B File Offset: 0x0000A79B
		public static IEnumerable<string> GetNameVariants(this string name, CultureInfo culture)
		{
			if (string.IsNullOrEmpty(name))
			{
				yield break;
			}
			yield return name;
			yield return name.ToCamelCase(culture);
			yield return name.ToLower(culture);
			yield return name.AddUnderscores();
			yield return name.AddUnderscores().ToLower(culture);
			yield return name.AddDashes();
			yield return name.AddDashes().ToLower(culture);
			yield return name.AddUnderscorePrefix();
			yield return name.AddUnderscores().ToCamelCase(culture);
			yield return name.ToCamelCase(culture).AddUnderscorePrefix();
			yield return name.AddUnderscores().ToCamelCase(culture).AddUnderscorePrefix();
			yield return name.AddSpaces();
			yield return name.AddSpaces().ToLower(culture);
			yield break;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000C5B2 File Offset: 0x0000A7B2
		internal static string JoinToString<[Nullable(2)] T>(this IEnumerable<T> collection, string separator, Func<T, string> getString)
		{
			return collection.Select(getString).JoinToString(separator);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000C5C1 File Offset: 0x0000A7C1
		internal static string JoinToString(this IEnumerable<string> strings, string separator)
		{
			return string.Join(separator, strings);
		}

		// Token: 0x0400012B RID: 299
		private static readonly Regex DateRegex = new Regex("\\\\?/Date\\((-?\\d+)(-|\\+)?([0-9]{4})?\\)\\\\?/");

		// Token: 0x0400012C RID: 300
		private static readonly Regex NewDateRegex = new Regex("newDate\\((-?\\d+)*\\)");

		// Token: 0x0400012D RID: 301
		private static readonly Regex IsUpperCaseRegex = new Regex("^[A-Z]+$");

		// Token: 0x0400012E RID: 302
		private static readonly Regex AddUnderscoresRegex1 = new Regex("[-\\s]");

		// Token: 0x0400012F RID: 303
		private static readonly Regex AddUnderscoresRegex2 = new Regex("([a-z\\d])([A-Z])");

		// Token: 0x04000130 RID: 304
		private static readonly Regex AddUnderscoresRegex3 = new Regex("([A-Z]+)([A-Z][a-z])");

		// Token: 0x04000131 RID: 305
		private static readonly Regex AddDashesRegex1 = new Regex("[\\s]");

		// Token: 0x04000132 RID: 306
		private static readonly Regex AddDashesRegex2 = new Regex("([a-z\\d])([A-Z])");

		// Token: 0x04000133 RID: 307
		private static readonly Regex AddDashesRegex3 = new Regex("([A-Z]+)([A-Z][a-z])");

		// Token: 0x04000134 RID: 308
		private static readonly Regex AddSpacesRegex1 = new Regex("[-\\s]");

		// Token: 0x04000135 RID: 309
		private static readonly Regex AddSpacesRegex2 = new Regex("([a-z\\d])([A-Z])");

		// Token: 0x04000136 RID: 310
		private static readonly Regex AddSpacesRegex3 = new Regex("([A-Z]+)([A-Z][a-z])");
	}
}
