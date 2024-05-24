using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Prism.Regions
{
	// Token: 0x0200001F RID: 31
	public class NavigationParameters : IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00002964 File Offset: 0x00000B64
		public NavigationParameters()
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002978 File Offset: 0x00000B78
		public NavigationParameters(string query)
		{
			if (query != null)
			{
				int length = query.Length;
				for (int i = (query.Length > 0 && query[0] == '?') ? 1 : 0; i < length; i++)
				{
					int num = i;
					int num2 = -1;
					while (i < length)
					{
						char c = query[i];
						if (c == '=')
						{
							if (num2 < 0)
							{
								num2 = i;
							}
						}
						else if (c == '&')
						{
							break;
						}
						i++;
					}
					string text = null;
					string stringToUnescape;
					if (num2 >= 0)
					{
						text = query.Substring(num, num2 - num);
						stringToUnescape = query.Substring(num2 + 1, i - num2 - 1);
					}
					else
					{
						stringToUnescape = query.Substring(num, i - num);
					}
					this.Add((text != null) ? Uri.UnescapeDataString(text) : null, Uri.UnescapeDataString(stringToUnescape));
					if (i == length - 1 && query[i] == '&')
					{
						this.Add(null, "");
					}
				}
			}
		}

		// Token: 0x17000020 RID: 32
		public object this[string key]
		{
			get
			{
				foreach (KeyValuePair<string, object> keyValuePair in this.entries)
				{
					if (string.Compare(keyValuePair.Key, key, StringComparison.Ordinal) == 0)
					{
						return keyValuePair.Value;
					}
				}
				return null;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return this.entries.GetEnumerator();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002AE2 File Offset: 0x00000CE2
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002AEA File Offset: 0x00000CEA
		public void Add(string key, object value)
		{
			this.entries.Add(new KeyValuePair<string, object>(key, value));
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002B00 File Offset: 0x00000D00
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.entries.Count > 0)
			{
				stringBuilder.Append('?');
				bool flag = true;
				foreach (KeyValuePair<string, object> keyValuePair in this.entries)
				{
					if (!flag)
					{
						stringBuilder.Append('&');
					}
					else
					{
						flag = false;
					}
					stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Key));
					stringBuilder.Append('=');
					stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Value.ToString()));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400000C RID: 12
		private readonly List<KeyValuePair<string, object>> entries = new List<KeyValuePair<string, object>>();
	}
}
