using System;
using System.Resources;
using Microsoft.Reflection;

namespace System.Diagnostics.Tracing.Internal
{
	// Token: 0x02000488 RID: 1160
	internal static class Environment
	{
		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06003764 RID: 14180 RVA: 0x000D53D0 File Offset: 0x000D35D0
		public static int TickCount
		{
			get
			{
				return Environment.TickCount;
			}
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x000D53D8 File Offset: 0x000D35D8
		public static string GetResourceString(string key, params object[] args)
		{
			string @string = Environment.rm.GetString(key);
			if (@string != null)
			{
				return string.Format(@string, args);
			}
			string text = string.Empty;
			foreach (object obj in args)
			{
				if (text != string.Empty)
				{
					text += ", ";
				}
				text += obj.ToString();
			}
			return key + " (" + text + ")";
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x000D544F File Offset: 0x000D364F
		public static string GetRuntimeResourceString(string key, params object[] args)
		{
			return Environment.GetResourceString(key, args);
		}

		// Token: 0x040018AB RID: 6315
		public static readonly string NewLine = Environment.NewLine;

		// Token: 0x040018AC RID: 6316
		private static ResourceManager rm = new ResourceManager("Microsoft.Diagnostics.Tracing.Messages", typeof(Environment).Assembly());
	}
}
