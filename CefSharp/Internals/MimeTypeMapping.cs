using System;
using System.Collections.Generic;

namespace CefSharp.Internals
{
	// Token: 0x020000E2 RID: 226
	public static class MimeTypeMapping
	{
		// Token: 0x060006D9 RID: 1753 RVA: 0x0000B2A4 File Offset: 0x000094A4
		public static string GetCustomMapping(string extension)
		{
			string result;
			if (!MimeTypeMapping.CustomMappings.TryGetValue(extension, out result))
			{
				return "application/octet-stream";
			}
			return result;
		}

		// Token: 0x04000385 RID: 901
		public static readonly IDictionary<string, string> CustomMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
		{
			{
				"woff2",
				"font/woff2"
			},
			{
				"ttf",
				"font/ttf"
			},
			{
				"otf",
				"font/otf"
			}
		};
	}
}
