using System;
using Prism.Regions;

namespace Prism.Common
{
	// Token: 0x02000082 RID: 130
	public static class UriParsingHelper
	{
		// Token: 0x060003C8 RID: 968 RVA: 0x00009ADD File Offset: 0x00007CDD
		public static string GetQuery(Uri uri)
		{
			return UriParsingHelper.EnsureAbsolute(uri).Query;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00009AEA File Offset: 0x00007CEA
		public static string GetAbsolutePath(Uri uri)
		{
			return UriParsingHelper.EnsureAbsolute(uri).AbsolutePath;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00009AF7 File Offset: 0x00007CF7
		public static NavigationParameters ParseQuery(Uri uri)
		{
			return new NavigationParameters(UriParsingHelper.GetQuery(uri));
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00009B04 File Offset: 0x00007D04
		private static Uri EnsureAbsolute(Uri uri)
		{
			if (uri.IsAbsoluteUri)
			{
				return uri;
			}
			if (uri != null && !uri.OriginalString.StartsWith("/", StringComparison.Ordinal))
			{
				return new Uri("http://localhost/" + uri, UriKind.Absolute);
			}
			return new Uri("http://localhost" + uri, UriKind.Absolute);
		}
	}
}
