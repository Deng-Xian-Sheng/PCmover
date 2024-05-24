using System;
using System.Text;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007DB RID: 2011
	internal static class SoapType
	{
		// Token: 0x06005714 RID: 22292 RVA: 0x00134C30 File Offset: 0x00132E30
		internal static string FilterBin64(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] != ' ' && value[i] != '\n' && value[i] != '\r')
				{
					stringBuilder.Append(value[i]);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06005715 RID: 22293 RVA: 0x00134C8C File Offset: 0x00132E8C
		internal static string LineFeedsBin64(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < value.Length; i++)
			{
				if (i % 76 == 0)
				{
					stringBuilder.Append('\n');
				}
				stringBuilder.Append(value[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06005716 RID: 22294 RVA: 0x00134CD4 File Offset: 0x00132ED4
		internal static string Escape(string value)
		{
			if (value == null || value.Length == 0)
			{
				return value;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = value.IndexOf('&');
			if (num > -1)
			{
				stringBuilder.Append(value);
				stringBuilder.Replace("&", "&#38;", num, stringBuilder.Length - num);
			}
			num = value.IndexOf('"');
			if (num > -1)
			{
				if (stringBuilder.Length == 0)
				{
					stringBuilder.Append(value);
				}
				stringBuilder.Replace("\"", "&#34;", num, stringBuilder.Length - num);
			}
			num = value.IndexOf('\'');
			if (num > -1)
			{
				if (stringBuilder.Length == 0)
				{
					stringBuilder.Append(value);
				}
				stringBuilder.Replace("'", "&#39;", num, stringBuilder.Length - num);
			}
			num = value.IndexOf('<');
			if (num > -1)
			{
				if (stringBuilder.Length == 0)
				{
					stringBuilder.Append(value);
				}
				stringBuilder.Replace("<", "&#60;", num, stringBuilder.Length - num);
			}
			num = value.IndexOf('>');
			if (num > -1)
			{
				if (stringBuilder.Length == 0)
				{
					stringBuilder.Append(value);
				}
				stringBuilder.Replace(">", "&#62;", num, stringBuilder.Length - num);
			}
			num = value.IndexOf('\0');
			if (num > -1)
			{
				if (stringBuilder.Length == 0)
				{
					stringBuilder.Append(value);
				}
				stringBuilder.Replace('\0'.ToString(), "&#0;", num, stringBuilder.Length - num);
			}
			string result;
			if (stringBuilder.Length > 0)
			{
				result = stringBuilder.ToString();
			}
			else
			{
				result = value;
			}
			return result;
		}

		// Token: 0x040027E0 RID: 10208
		internal static Type typeofSoapTime = typeof(SoapTime);

		// Token: 0x040027E1 RID: 10209
		internal static Type typeofSoapDate = typeof(SoapDate);

		// Token: 0x040027E2 RID: 10210
		internal static Type typeofSoapYearMonth = typeof(SoapYearMonth);

		// Token: 0x040027E3 RID: 10211
		internal static Type typeofSoapYear = typeof(SoapYear);

		// Token: 0x040027E4 RID: 10212
		internal static Type typeofSoapMonthDay = typeof(SoapMonthDay);

		// Token: 0x040027E5 RID: 10213
		internal static Type typeofSoapDay = typeof(SoapDay);

		// Token: 0x040027E6 RID: 10214
		internal static Type typeofSoapMonth = typeof(SoapMonth);

		// Token: 0x040027E7 RID: 10215
		internal static Type typeofSoapHexBinary = typeof(SoapHexBinary);

		// Token: 0x040027E8 RID: 10216
		internal static Type typeofSoapBase64Binary = typeof(SoapBase64Binary);

		// Token: 0x040027E9 RID: 10217
		internal static Type typeofSoapInteger = typeof(SoapInteger);

		// Token: 0x040027EA RID: 10218
		internal static Type typeofSoapPositiveInteger = typeof(SoapPositiveInteger);

		// Token: 0x040027EB RID: 10219
		internal static Type typeofSoapNonPositiveInteger = typeof(SoapNonPositiveInteger);

		// Token: 0x040027EC RID: 10220
		internal static Type typeofSoapNonNegativeInteger = typeof(SoapNonNegativeInteger);

		// Token: 0x040027ED RID: 10221
		internal static Type typeofSoapNegativeInteger = typeof(SoapNegativeInteger);

		// Token: 0x040027EE RID: 10222
		internal static Type typeofSoapAnyUri = typeof(SoapAnyUri);

		// Token: 0x040027EF RID: 10223
		internal static Type typeofSoapQName = typeof(SoapQName);

		// Token: 0x040027F0 RID: 10224
		internal static Type typeofSoapNotation = typeof(SoapNotation);

		// Token: 0x040027F1 RID: 10225
		internal static Type typeofSoapNormalizedString = typeof(SoapNormalizedString);

		// Token: 0x040027F2 RID: 10226
		internal static Type typeofSoapToken = typeof(SoapToken);

		// Token: 0x040027F3 RID: 10227
		internal static Type typeofSoapLanguage = typeof(SoapLanguage);

		// Token: 0x040027F4 RID: 10228
		internal static Type typeofSoapName = typeof(SoapName);

		// Token: 0x040027F5 RID: 10229
		internal static Type typeofSoapIdrefs = typeof(SoapIdrefs);

		// Token: 0x040027F6 RID: 10230
		internal static Type typeofSoapEntities = typeof(SoapEntities);

		// Token: 0x040027F7 RID: 10231
		internal static Type typeofSoapNmtoken = typeof(SoapNmtoken);

		// Token: 0x040027F8 RID: 10232
		internal static Type typeofSoapNmtokens = typeof(SoapNmtokens);

		// Token: 0x040027F9 RID: 10233
		internal static Type typeofSoapNcName = typeof(SoapNcName);

		// Token: 0x040027FA RID: 10234
		internal static Type typeofSoapId = typeof(SoapId);

		// Token: 0x040027FB RID: 10235
		internal static Type typeofSoapIdref = typeof(SoapIdref);

		// Token: 0x040027FC RID: 10236
		internal static Type typeofSoapEntity = typeof(SoapEntity);

		// Token: 0x040027FD RID: 10237
		internal static Type typeofISoapXsd = typeof(ISoapXsd);
	}
}
