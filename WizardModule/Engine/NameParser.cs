using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WizardModule.Engine
{
	// Token: 0x020000BE RID: 190
	public static class NameParser
	{
		// Token: 0x06001022 RID: 4130 RVA: 0x000295B4 File Offset: 0x000277B4
		public static Name Parse(string fullName)
		{
			Name name = new Name
			{
				First = string.Empty,
				Last = string.Empty,
				Middle = string.Empty,
				Salutation = string.Empty,
				Suffix = string.Empty
			};
			List<string> list = Regex.Split(fullName, "(?<=[., ])").ToList<string>();
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i].Trim() == "")
				{
					list.RemoveAt(i);
				}
			}
			if (list.Count > 0)
			{
				IEnumerable<string> source = new string[]
				{
					"mr",
					"mrs",
					"ms",
					"dr",
					"miss",
					"sir",
					"madam",
					"mayor",
					"president"
				};
				string value = list.First<string>().Replace(".", "").Replace(",", "").Trim().ToLower();
				if (source.Contains(value))
				{
					name.Salutation = list[0].Trim();
					list.RemoveAt(0);
				}
			}
			if (list.Count > 0)
			{
				IEnumerable<string> source2 = new string[]
				{
					"jr",
					"sr",
					"i",
					"ii",
					"iii",
					"iv",
					"v",
					"vi",
					"vii",
					"viii",
					"ix",
					"x",
					"xi",
					"xii",
					"xiii",
					"xiv",
					"xv"
				};
				string value2 = list.Last<string>().Replace(".", "").Replace(",", "").Trim().ToLower();
				if (source2.Contains(value2))
				{
					name.Suffix = list.Last<string>().Replace(",", "").Trim();
					list.RemoveAt(list.Count - 1);
				}
			}
			if (list.Count == 0)
			{
				return name;
			}
			if (list.Count == 1)
			{
				if (name.Salutation == "")
				{
					name.First = list.First<string>().Replace(",", "").Trim();
				}
				else
				{
					name.Last = list.First<string>().Replace(",", "").Trim();
				}
			}
			else if (list.First<string>().EndsWith(","))
			{
				name.Last = list.First<string>().Replace(",", "").Trim();
				for (int j = 1; j < list.Count; j++)
				{
					Name name2 = name;
					name2.First = name2.First + list[j].Replace(",", "").Trim() + " ";
				}
				name.First = name.First.Trim();
			}
			else if (list.First<string>().EndsWith("."))
			{
				name.First = list.First<string>().Replace(".", "").Trim();
				name.Last = list.Last<string>().Replace(".", "").Trim();
			}
			else
			{
				if (list.Count > 0)
				{
					name.First = list.First<string>().Replace(",", "").Trim();
					list.RemoveAt(0);
				}
				if (list.Count > 0)
				{
					name.Last = list.Last<string>().Replace(",", "").Trim();
					list.RemoveAt(list.Count - 1);
				}
				if (list.Count > 0)
				{
					for (int k = 0; k < list.Count - 1; k++)
					{
						Name name3 = name;
						name3.Middle = name3.Middle + list[k].Replace(",", "").Trim() + " ";
					}
					name.Middle = name.Middle.Trim();
				}
			}
			return name;
		}
	}
}
