using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RestSharp.Authenticators.OAuth.Extensions
{
	// Token: 0x02000066 RID: 102
	[NullableContext(1)]
	[Nullable(0)]
	internal static class StringExtensions
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x0000DBED File Offset: 0x0000BDED
		public static bool EqualsIgnoreCase(this string left, string right)
		{
			return string.Equals(left, right, StringComparison.InvariantCultureIgnoreCase);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0000DBF7 File Offset: 0x0000BDF7
		public static string Then(this string input, string value)
		{
			return input + value;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000DC00 File Offset: 0x0000BE00
		public static Uri AsUri(this string value)
		{
			return new Uri(value);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000DC08 File Offset: 0x0000BE08
		public static byte[] GetBytes(this string input)
		{
			return Encoding.UTF8.GetBytes(input);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0000DC15 File Offset: 0x0000BE15
		public static string PercentEncode(this string s)
		{
			return string.Join("", from x in s.GetBytes()
			select string.Format("%{0:X2}", x));
		}
	}
}
