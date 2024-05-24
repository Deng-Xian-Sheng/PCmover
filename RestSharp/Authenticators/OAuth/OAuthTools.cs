using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using RestSharp.Authenticators.OAuth.Extensions;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace RestSharp.Authenticators.OAuth
{
	// Token: 0x02000061 RID: 97
	[NullableContext(1)]
	[Nullable(0)]
	internal static class OAuthTools
	{
		// Token: 0x06000543 RID: 1347 RVA: 0x0000CEE0 File Offset: 0x0000B0E0
		static OAuthTools()
		{
			byte[] array = new byte[4];
			OAuthTools.Rng.GetBytes(array);
			OAuthTools.Random = new Random(BitConverter.ToInt32(array, 0));
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0000CF94 File Offset: 0x0000B194
		public static string GetNonce()
		{
			char[] array = new char[16];
			object randomLock = OAuthTools.RandomLock;
			lock (randomLock)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = "abcdefghijklmnopqrstuvwxyz1234567890"[OAuthTools.Random.Next(0, "abcdefghijklmnopqrstuvwxyz1234567890".Length)];
				}
			}
			return new string(array);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0000D00C File Offset: 0x0000B20C
		public static string GetTimestamp()
		{
			return OAuthTools.GetTimestamp(DateTime.UtcNow);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0000D018 File Offset: 0x0000B218
		private static string GetTimestamp(DateTime dateTime)
		{
			return dateTime.ToUnixTime().ToString();
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0000D034 File Offset: 0x0000B234
		public static string UrlEncodeRelaxed(string value)
		{
			StringBuilder stringBuilder = new StringBuilder(value);
			for (int i = 0; i < OAuthTools.UriRfc3986CharsToEscape.Length; i++)
			{
				string oldValue = OAuthTools.UriRfc3986CharsToEscape[i];
				stringBuilder.Replace(oldValue, OAuthTools.UriRfc3968EscapedHex[i]);
			}
			return Uri.EscapeDataString(stringBuilder.ToString());
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0000D07C File Offset: 0x0000B27C
		public static string UrlEncodeStrict(string value)
		{
			return string.Join("", value.Select(delegate(char x)
			{
				if (!"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-._~".Contains(x))
				{
					return string.Format("%{0:X2}", (byte)x);
				}
				return x.ToString();
			}));
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0000D0AD File Offset: 0x0000B2AD
		private static string NormalizeRequestParameters(WebPairCollection parameters)
		{
			return string.Join("&", OAuthTools.SortParametersExcludingSignature(parameters));
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		public static IEnumerable<string> SortParametersExcludingSignature(WebPairCollection parameters)
		{
			return from x in (from x in parameters
			where !x.Name.EqualsIgnoreCase("oauth_signature")
			select new WebPair(OAuthTools.UrlEncodeStrict(x.Name), OAuthTools.UrlEncodeStrict(x.Value), x.Encode)).OrderBy((WebPair x) => x, WebPair.Comparer)
			select x.Name + "=" + x.Value;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000D164 File Offset: 0x0000B364
		private static string ConstructRequestUrl(Uri url)
		{
			Ensure.NotNull(url, "url");
			bool flag = url.Scheme == "http" && url.Port == 80;
			bool flag2 = url.Scheme == "https" && url.Port == 443;
			string text = (flag || flag2) ? "" : string.Format(":{0}", url.Port);
			return string.Concat(new string[]
			{
				url.Scheme,
				"://",
				url.Host,
				text,
				url.AbsolutePath
			});
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0000D214 File Offset: 0x0000B414
		public static string ConcatenateRequestElements(string method, string url, WebPairCollection parameters)
		{
			string str = method.ToUpperInvariant().Then("&");
			string str2 = OAuthTools.UrlEncodeRelaxed(OAuthTools.ConstructRequestUrl(url.AsUri())).Then("&");
			string str3 = OAuthTools.UrlEncodeRelaxed(OAuthTools.NormalizeRequestParameters(parameters));
			return str + str2 + str3;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0000D25F File Offset: 0x0000B45F
		public static string GetSignature(OAuthSignatureMethod signatureMethod, string signatureBase, string consumerSecret)
		{
			return OAuthTools.GetSignature(signatureMethod, OAuthSignatureTreatment.Escaped, signatureBase, consumerSecret, null);
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0000D26B File Offset: 0x0000B46B
		public static string GetSignature(OAuthSignatureMethod signatureMethod, OAuthSignatureTreatment signatureTreatment, string signatureBase, string consumerSecret)
		{
			return OAuthTools.GetSignature(signatureMethod, signatureTreatment, signatureBase, consumerSecret, null);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0000D278 File Offset: 0x0000B478
		public static string GetSignature(OAuthSignatureMethod signatureMethod, OAuthSignatureTreatment signatureTreatment, string signatureBase, string consumerSecret, [Nullable(2)] string tokenSecret)
		{
			OAuthTools.<>c__DisplayClass23_0 CS$<>8__locals1;
			CS$<>8__locals1.signatureBase = signatureBase;
			if (tokenSecret.IsEmpty())
			{
				tokenSecret = string.Empty;
			}
			CS$<>8__locals1.unencodedConsumerSecret = consumerSecret;
			consumerSecret = Uri.EscapeDataString(consumerSecret);
			tokenSecret = Uri.EscapeDataString(tokenSecret);
			string text;
			switch (signatureMethod)
			{
			case OAuthSignatureMethod.HmacSha1:
				text = OAuthTools.GetHmacSignature(new HMACSHA1(), consumerSecret, tokenSecret, CS$<>8__locals1.signatureBase);
				break;
			case OAuthSignatureMethod.HmacSha256:
				text = OAuthTools.GetHmacSignature(new HMACSHA256(), consumerSecret, tokenSecret, CS$<>8__locals1.signatureBase);
				break;
			case OAuthSignatureMethod.PlainText:
				text = consumerSecret + "&" + tokenSecret;
				break;
			case OAuthSignatureMethod.RsaSha1:
				text = OAuthTools.<GetSignature>g__GetRsaSignature|23_0(ref CS$<>8__locals1);
				break;
			default:
				throw new NotImplementedException("Only HMAC-SHA1, HMAC-SHA256, and RSA-SHA1 are currently supported.");
			}
			string text2 = text;
			if (signatureTreatment != OAuthSignatureTreatment.Escaped)
			{
				return text2;
			}
			return OAuthTools.UrlEncodeRelaxed(text2);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000D32C File Offset: 0x0000B52C
		private static string GetHmacSignature(KeyedHashAlgorithm crypto, string consumerSecret, string tokenSecret, string signatureBase)
		{
			string s = consumerSecret + "&" + tokenSecret;
			crypto.Key = OAuthTools.Encoding.GetBytes(s);
			return signatureBase.HashWith(crypto);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000D360 File Offset: 0x0000B560
		[CompilerGenerated]
		internal static string <GetSignature>g__GetRsaSignature|23_0(ref OAuthTools.<>c__DisplayClass23_0 A_0)
		{
			string result;
			using (RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider
			{
				PersistKeyInCsp = false
			})
			{
				rsacryptoServiceProvider.FromXmlString2(A_0.unencodedConsumerSecret);
				byte[] rgbHash = new SHA1Managed().ComputeHash(OAuthTools.Encoding.GetBytes(A_0.signatureBase));
				result = Convert.ToBase64String(rsacryptoServiceProvider.SignHash(rgbHash, CryptoConfig.MapNameToOID("SHA1")));
			}
			return result;
		}

		// Token: 0x0400015F RID: 351
		private const string AlphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

		// Token: 0x04000160 RID: 352
		private const string Digit = "1234567890";

		// Token: 0x04000161 RID: 353
		private const string Lower = "abcdefghijklmnopqrstuvwxyz";

		// Token: 0x04000162 RID: 354
		private const string Unreserved = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890-._~";

		// Token: 0x04000163 RID: 355
		private const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		// Token: 0x04000164 RID: 356
		private static readonly Random Random;

		// Token: 0x04000165 RID: 357
		private static readonly object RandomLock = new object();

		// Token: 0x04000166 RID: 358
		private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

		// Token: 0x04000167 RID: 359
		private static readonly Encoding Encoding = Encoding.UTF8;

		// Token: 0x04000168 RID: 360
		private static readonly string[] UriRfc3986CharsToEscape = new string[]
		{
			"!",
			"*",
			"'",
			"(",
			")"
		};

		// Token: 0x04000169 RID: 361
		private static readonly string[] UriRfc3968EscapedHex = new string[]
		{
			"%21",
			"%2A",
			"%27",
			"%28",
			"%29"
		};
	}
}
