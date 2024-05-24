using System;
using System.Collections;
using System.Globalization;

namespace System.Security.Util
{
	// Token: 0x0200037B RID: 891
	[Serializable]
	internal class SiteString
	{
		// Token: 0x06002C29 RID: 11305 RVA: 0x000A462C File Offset: 0x000A282C
		protected internal SiteString()
		{
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x000A4634 File Offset: 0x000A2834
		public SiteString(string site)
		{
			this.m_separatedSite = SiteString.CreateSeparatedSite(site);
			this.m_site = site;
		}

		// Token: 0x06002C2B RID: 11307 RVA: 0x000A464F File Offset: 0x000A284F
		private SiteString(string site, ArrayList separatedSite)
		{
			this.m_separatedSite = separatedSite;
			this.m_site = site;
		}

		// Token: 0x06002C2C RID: 11308 RVA: 0x000A4668 File Offset: 0x000A2868
		private static ArrayList CreateSeparatedSite(string site)
		{
			if (site == null || site.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
			}
			ArrayList arrayList = new ArrayList();
			int num = -1;
			int num2 = site.IndexOf('[');
			if (num2 == 0)
			{
				num = site.IndexOf(']', num2 + 1);
			}
			if (num != -1)
			{
				string value = site.Substring(num2 + 1, num - num2 - 1);
				arrayList.Add(value);
				return arrayList;
			}
			string[] array = site.Split(SiteString.m_separators);
			for (int i = array.Length - 1; i > -1; i--)
			{
				if (array[i] == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
				}
				if (array[i].Equals(""))
				{
					if (i != array.Length - 1)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
					}
				}
				else if (array[i].Equals("*"))
				{
					if (i != 0)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
					}
					arrayList.Add(array[i]);
				}
				else
				{
					if (!SiteString.AllLegalCharacters(array[i]))
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidSite"));
					}
					arrayList.Add(array[i]);
				}
			}
			return arrayList;
		}

		// Token: 0x06002C2D RID: 11309 RVA: 0x000A4790 File Offset: 0x000A2990
		private static bool AllLegalCharacters(string str)
		{
			foreach (char c in str)
			{
				if (!SiteString.IsLegalDNSChar(c) && !SiteString.IsNetbiosSplChar(c))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002C2E RID: 11310 RVA: 0x000A47C9 File Offset: 0x000A29C9
		private static bool IsLegalDNSChar(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-';
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x000A47F4 File Offset: 0x000A29F4
		private static bool IsNetbiosSplChar(char c)
		{
			if (c <= '@')
			{
				switch (c)
				{
				case '!':
				case '#':
				case '$':
				case '%':
				case '&':
				case '\'':
				case '(':
				case ')':
				case '-':
				case '.':
					break;
				case '"':
				case '*':
				case '+':
				case ',':
					return false;
				default:
					if (c != '@')
					{
						return false;
					}
					break;
				}
			}
			else if (c != '^' && c != '_')
			{
				switch (c)
				{
				case '{':
				case '}':
				case '~':
					break;
				case '|':
					return false;
				default:
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x000A4876 File Offset: 0x000A2A76
		public override string ToString()
		{
			return this.m_site;
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x000A487E File Offset: 0x000A2A7E
		public override bool Equals(object o)
		{
			return o != null && o is SiteString && this.Equals((SiteString)o, true);
		}

		// Token: 0x06002C32 RID: 11314 RVA: 0x000A489C File Offset: 0x000A2A9C
		public override int GetHashCode()
		{
			TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
			return textInfo.GetCaseInsensitiveHashCode(this.m_site);
		}

		// Token: 0x06002C33 RID: 11315 RVA: 0x000A48C0 File Offset: 0x000A2AC0
		internal bool Equals(SiteString ss, bool ignoreCase)
		{
			if (this.m_site == null)
			{
				return ss.m_site == null;
			}
			return ss.m_site != null && this.IsSubsetOf(ss, ignoreCase) && ss.IsSubsetOf(this, ignoreCase);
		}

		// Token: 0x06002C34 RID: 11316 RVA: 0x000A48F2 File Offset: 0x000A2AF2
		public virtual SiteString Copy()
		{
			return new SiteString(this.m_site, this.m_separatedSite);
		}

		// Token: 0x06002C35 RID: 11317 RVA: 0x000A4905 File Offset: 0x000A2B05
		public virtual bool IsSubsetOf(SiteString operand)
		{
			return this.IsSubsetOf(operand, true);
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x000A4910 File Offset: 0x000A2B10
		public virtual bool IsSubsetOf(SiteString operand, bool ignoreCase)
		{
			StringComparison comparisonType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
			if (operand == null)
			{
				return false;
			}
			if (this.m_separatedSite.Count == operand.m_separatedSite.Count && this.m_separatedSite.Count == 0)
			{
				return true;
			}
			if (this.m_separatedSite.Count < operand.m_separatedSite.Count - 1)
			{
				return false;
			}
			if (this.m_separatedSite.Count > operand.m_separatedSite.Count && operand.m_separatedSite.Count > 0 && !operand.m_separatedSite[operand.m_separatedSite.Count - 1].Equals("*"))
			{
				return false;
			}
			if (string.Compare(this.m_site, operand.m_site, comparisonType) == 0)
			{
				return true;
			}
			for (int i = 0; i < operand.m_separatedSite.Count - 1; i++)
			{
				if (string.Compare((string)this.m_separatedSite[i], (string)operand.m_separatedSite[i], comparisonType) != 0)
				{
					return false;
				}
			}
			if (this.m_separatedSite.Count < operand.m_separatedSite.Count)
			{
				return operand.m_separatedSite[operand.m_separatedSite.Count - 1].Equals("*");
			}
			return this.m_separatedSite.Count != operand.m_separatedSite.Count || string.Compare((string)this.m_separatedSite[this.m_separatedSite.Count - 1], (string)operand.m_separatedSite[this.m_separatedSite.Count - 1], comparisonType) == 0 || operand.m_separatedSite[operand.m_separatedSite.Count - 1].Equals("*");
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x000A4ACE File Offset: 0x000A2CCE
		public virtual SiteString Intersect(SiteString operand)
		{
			if (operand == null)
			{
				return null;
			}
			if (this.IsSubsetOf(operand))
			{
				return this.Copy();
			}
			if (operand.IsSubsetOf(this))
			{
				return operand.Copy();
			}
			return null;
		}

		// Token: 0x06002C38 RID: 11320 RVA: 0x000A4AF6 File Offset: 0x000A2CF6
		public virtual SiteString Union(SiteString operand)
		{
			if (operand == null)
			{
				return this;
			}
			if (this.IsSubsetOf(operand))
			{
				return operand.Copy();
			}
			if (operand.IsSubsetOf(this))
			{
				return this.Copy();
			}
			return null;
		}

		// Token: 0x040011BE RID: 4542
		protected string m_site;

		// Token: 0x040011BF RID: 4543
		protected ArrayList m_separatedSite;

		// Token: 0x040011C0 RID: 4544
		protected static char[] m_separators = new char[]
		{
			'.'
		};
	}
}
