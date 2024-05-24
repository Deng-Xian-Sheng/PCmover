using System;

namespace System.Globalization
{
	// Token: 0x020003BB RID: 955
	public static class GlobalizationExtensions
	{
		// Token: 0x06002F56 RID: 12118 RVA: 0x000B5D0C File Offset: 0x000B3F0C
		public static StringComparer GetStringComparer(this CompareInfo compareInfo, CompareOptions options)
		{
			if (compareInfo == null)
			{
				throw new ArgumentNullException("compareInfo");
			}
			if (options == CompareOptions.Ordinal)
			{
				return StringComparer.Ordinal;
			}
			if (options == CompareOptions.OrdinalIgnoreCase)
			{
				return StringComparer.OrdinalIgnoreCase;
			}
			if ((options & ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.StringSort)) != CompareOptions.None)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFlag"), "options");
			}
			return new CultureAwareComparer(compareInfo, options);
		}

		// Token: 0x0400141A RID: 5146
		private const CompareOptions ValidCompareMaskOffFlags = ~(CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.StringSort);
	}
}
