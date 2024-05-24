using System;
using System.Runtime.CompilerServices;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000003 RID: 3
	public static class CodeHelper
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020D8 File Offset: 0x000002D8
		public static void trycatch(Action func)
		{
			try
			{
				func();
			}
			catch
			{
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002100 File Offset: 0x00000300
		public static void trycatch(LlTraceSource ts, Action func, [CallerMemberName] string caller = "")
		{
			try
			{
				func();
			}
			catch (Exception ex)
			{
				ts.TraceException(ex, caller);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002130 File Offset: 0x00000330
		public static string TrimIfEndsWith(this string value, string suffix)
		{
			if (!value.EndsWith(suffix))
			{
				return value;
			}
			return value.Substring(0, value.Length - suffix.Length);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002151 File Offset: 0x00000351
		public static string FixPathParameter(this string path)
		{
			if (!path.EndsWith("\""))
			{
				return path;
			}
			return path.Substring(0, path.Length - 1) + "\\";
		}
	}
}
