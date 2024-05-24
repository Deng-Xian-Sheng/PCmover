using System;
using System.Collections;

namespace System.Security.Util
{
	// Token: 0x02000381 RID: 897
	[Serializable]
	internal class LocalSiteString : SiteString
	{
		// Token: 0x06002C9F RID: 11423 RVA: 0x000A7234 File Offset: 0x000A5434
		public LocalSiteString(string site)
		{
			this.m_site = site.Replace('|', ':');
			if (this.m_site.Length > 2 && this.m_site.IndexOf(':') != -1)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
			}
			this.m_separatedSite = this.CreateSeparatedString(this.m_site);
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x000A7298 File Offset: 0x000A5498
		private ArrayList CreateSeparatedString(string directory)
		{
			if (directory == null || directory.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
			}
			ArrayList arrayList = new ArrayList();
			string[] array = directory.Split(LocalSiteString.m_separators);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null || array[i].Equals(""))
				{
					if (i < 2 && directory[i] == '/')
					{
						arrayList.Add("//");
					}
					else if (i != array.Length - 1)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
					}
				}
				else if (array[i].Equals("*"))
				{
					if (i != array.Length - 1)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
					}
					arrayList.Add(array[i]);
				}
				else
				{
					arrayList.Add(array[i]);
				}
			}
			return arrayList;
		}

		// Token: 0x06002CA1 RID: 11425 RVA: 0x000A736D File Offset: 0x000A556D
		public virtual bool IsSubsetOf(LocalSiteString operand)
		{
			return this.IsSubsetOf(operand, true);
		}

		// Token: 0x06002CA2 RID: 11426 RVA: 0x000A7378 File Offset: 0x000A5578
		public virtual bool IsSubsetOf(LocalSiteString operand, bool ignoreCase)
		{
			if (operand == null)
			{
				return false;
			}
			if (operand.m_separatedSite.Count == 0)
			{
				return this.m_separatedSite.Count == 0 || (this.m_separatedSite.Count > 0 && string.Compare((string)this.m_separatedSite[0], "*", StringComparison.Ordinal) == 0);
			}
			if (this.m_separatedSite.Count == 0)
			{
				return string.Compare((string)operand.m_separatedSite[0], "*", StringComparison.Ordinal) == 0;
			}
			return base.IsSubsetOf(operand, ignoreCase);
		}

		// Token: 0x040011E3 RID: 4579
		private new static char[] m_separators = new char[]
		{
			'/'
		};
	}
}
