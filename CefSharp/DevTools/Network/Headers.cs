using System;
using System.Collections.Generic;
using System.Linq;

namespace CefSharp.DevTools.Network
{
	// Token: 0x0200030D RID: 781
	public class Headers : Dictionary<string, string>
	{
		// Token: 0x060016FD RID: 5885 RVA: 0x0001AF95 File Offset: 0x00019195
		public Headers() : base(StringComparer.OrdinalIgnoreCase)
		{
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x0001AFA2 File Offset: 0x000191A2
		public Dictionary<string, string> ToDictionary()
		{
			return this;
		}

		// Token: 0x060016FF RID: 5887 RVA: 0x0001AFA8 File Offset: 0x000191A8
		public bool TryGetValues(string key, out string[] values)
		{
			values = null;
			string text;
			if (base.TryGetValue(key, out text))
			{
				List<string> list = new List<string>();
				int num = -1;
				int num2 = -1;
				bool flag = false;
				for (int i = 0; i < text.Length; i++)
				{
					char c = text[i];
					if (c == '"')
					{
						flag = !flag;
					}
					else if (flag || !char.IsWhiteSpace(c))
					{
						if (num == -1)
						{
							num = i;
						}
						if (!flag && c == ',')
						{
							if (num2 == -1)
							{
								list.Add(string.Empty);
							}
							else
							{
								list.Add(text.Substring(num, num2 + 1 - num));
							}
							num = -1;
							num2 = -1;
						}
						else
						{
							num2 = i;
						}
					}
				}
				if (num2 == -1)
				{
					list.Add(string.Empty);
				}
				else
				{
					list.Add(text.Substring(num, num2 + 1 - num));
				}
				values = list.ToArray();
				return true;
			}
			return false;
		}

		// Token: 0x06001700 RID: 5888 RVA: 0x0001B07C File Offset: 0x0001927C
		public string[] GetCommaSeparatedValues(string key)
		{
			string[] result;
			if (this.TryGetValues(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06001701 RID: 5889 RVA: 0x0001B098 File Offset: 0x00019298
		public void AppendCommaSeparatedValues(string key, params string[] values)
		{
			string str;
			if (base.TryGetValue(key, out str))
			{
				base[key] = str + "," + string.Join(",", values.Select(new Func<string, string>(Headers.QuoteIfNeeded)));
				return;
			}
			this.SetCommaSeparatedValues(key, values);
		}

		// Token: 0x06001702 RID: 5890 RVA: 0x0001B0E7 File Offset: 0x000192E7
		public void SetCommaSeparatedValues(string key, params string[] values)
		{
			base[key] = string.Join(",", values.Select(new Func<string, string>(Headers.QuoteIfNeeded)));
		}

		// Token: 0x06001703 RID: 5891 RVA: 0x0001B10C File Offset: 0x0001930C
		private static string QuoteIfNeeded(string value)
		{
			if (!string.IsNullOrEmpty(value) && value.Contains(',') && (value[0] != '"' || value[value.Length - 1] != '"'))
			{
				return "\"" + value + "\"";
			}
			return value;
		}
	}
}
