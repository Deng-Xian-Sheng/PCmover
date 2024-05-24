using System;
using System.Collections.Generic;
using System.Linq;

namespace CefSharp.Internals
{
	// Token: 0x020000C6 RID: 198
	public static class CommandLineArgsParser
	{
		// Token: 0x060005E2 RID: 1506 RVA: 0x00009770 File Offset: 0x00007970
		public static bool HasArgument(this IEnumerable<string> args, string arg)
		{
			return args.Any((string a) => a.StartsWith(arg));
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0000979C File Offset: 0x0000799C
		public static string GetArgumentValue(this IEnumerable<string> args, string argumentName)
		{
			string text = args.FirstOrDefault((string a) => a.StartsWith(argumentName));
			if (text == null)
			{
				return null;
			}
			return text.Split(new char[]
			{
				'='
			}).Last<string>();
		}
	}
}
