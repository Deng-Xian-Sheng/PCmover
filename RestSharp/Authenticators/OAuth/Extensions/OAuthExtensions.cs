using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace RestSharp.Authenticators.OAuth.Extensions
{
	// Token: 0x02000065 RID: 101
	[NullableContext(1)]
	[Nullable(0)]
	internal static class OAuthExtensions
	{
		// Token: 0x06000594 RID: 1428 RVA: 0x0000DB88 File Offset: 0x0000BD88
		public static string ToRequestValue(this OAuthSignatureMethod signatureMethod)
		{
			string text = signatureMethod.ToString().ToUpperInvariant();
			int num = text.IndexOf("SHA", StringComparison.Ordinal);
			if (num <= -1)
			{
				return text;
			}
			return text.Insert(num, "-");
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		public static string HashWith(this string input, HashAlgorithm algorithm)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(algorithm.ComputeHash(bytes));
		}
	}
}
