using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000005 RID: 5
	public class EnvLookup
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002217 File Offset: 0x00000417
		// (set) Token: 0x0600000F RID: 15 RVA: 0x0000221F File Offset: 0x0000041F
		public IDictionary Dict { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002228 File Offset: 0x00000428
		public static HashSet<string> Excluded6432Vars { get; } = new HashSet<string>
		{
			"PROGRAMFILES",
			"PROGRAMW6432",
			"PROGRAMFILES(X86)",
			"COMMONPROGRAMFILES",
			"COMMONPROGRAMW6432",
			"COMMONPROGRAMFILES(X86)",
			"PROCESSOR_ARCHITECTURE",
			"PROCESSOR_ARCHITEW6432",
			"PROCESSOR_ARCHITECTURE(x86)"
		};

		// Token: 0x06000011 RID: 17 RVA: 0x0000222F File Offset: 0x0000042F
		public EnvLookup(IDictionary envDict)
		{
			this.Dict = envDict;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002240 File Offset: 0x00000440
		public EnvLookup Remove6432Vars()
		{
			if (this.Dict == null)
			{
				return this;
			}
			bool flag = false;
			Hashtable hashtable = new Hashtable();
			foreach (object obj in this.Dict)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (EnvLookup.Excluded6432Vars.Contains(dictionaryEntry.Key.ToString().ToUpper()))
				{
					flag = true;
				}
				else
				{
					hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
				}
			}
			if (flag)
			{
				return new EnvLookup(hashtable);
			}
			return this;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022E8 File Offset: 0x000004E8
		public string CreateEnvironmentBlock()
		{
			if (this.Dict == null)
			{
				return null;
			}
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (object obj in this.Dict)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					stringBuilder.Append(string.Format("{0}={1}\0", dictionaryEntry.Key, dictionaryEntry.Value));
				}
				result = stringBuilder.ToString();
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002388 File Offset: 0x00000588
		public string Expand(string srcString)
		{
			if (srcString == null)
			{
				return null;
			}
			string text = "";
			int num;
			for (int i = 0; i < srcString.Length; i = num + 1)
			{
				num = srcString.IndexOf('%', i);
				if (num == -1)
				{
					text += srcString.Substring(i);
					break;
				}
				text += srcString.Substring(i, num - i);
				i = num + 1;
				num = srcString.IndexOf('%', i);
				if (num == -1)
				{
					text += srcString.Substring(i - 1);
					break;
				}
				int num2 = num - i;
				string var = srcString.Substring(i, num2).ToUpper();
				string var2 = this.GetVar(var);
				if (var2 == null)
				{
					text += srcString.Substring(i - 1, num2 + 2);
				}
				else
				{
					text += var2;
				}
			}
			return text;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002450 File Offset: 0x00000650
		public string GetVar(string var)
		{
			string result = null;
			foreach (object obj in this.Dict)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (var == dictionaryEntry.Key.ToString().ToUpper())
				{
					result = dictionaryEntry.Value.ToString();
					break;
				}
			}
			return result;
		}
	}
}
