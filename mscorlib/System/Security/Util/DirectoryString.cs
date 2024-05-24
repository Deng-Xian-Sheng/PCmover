using System;
using System.Collections;

namespace System.Security.Util
{
	// Token: 0x02000380 RID: 896
	[Serializable]
	internal class DirectoryString : SiteString
	{
		// Token: 0x06002C99 RID: 11417 RVA: 0x000A7067 File Offset: 0x000A5267
		public DirectoryString()
		{
			this.m_site = "";
			this.m_separatedSite = new ArrayList();
		}

		// Token: 0x06002C9A RID: 11418 RVA: 0x000A7085 File Offset: 0x000A5285
		public DirectoryString(string directory, bool checkForIllegalChars)
		{
			this.m_site = directory;
			this.m_checkForIllegalChars = checkForIllegalChars;
			this.m_separatedSite = this.CreateSeparatedString(directory);
		}

		// Token: 0x06002C9B RID: 11419 RVA: 0x000A70A8 File Offset: 0x000A52A8
		private ArrayList CreateSeparatedString(string directory)
		{
			if (directory == null || directory.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
			}
			ArrayList arrayList = new ArrayList();
			string[] array = directory.Split(DirectoryString.m_separators);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && !array[i].Equals(""))
				{
					if (array[i].Equals("*"))
					{
						if (i != array.Length - 1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
						}
						arrayList.Add(array[i]);
					}
					else
					{
						if (this.m_checkForIllegalChars && array[i].IndexOfAny(DirectoryString.m_illegalDirectoryCharacters) != -1)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDirectoryOnUrl"));
						}
						arrayList.Add(array[i]);
					}
				}
			}
			return arrayList;
		}

		// Token: 0x06002C9C RID: 11420 RVA: 0x000A716D File Offset: 0x000A536D
		public virtual bool IsSubsetOf(DirectoryString operand)
		{
			return this.IsSubsetOf(operand, true);
		}

		// Token: 0x06002C9D RID: 11421 RVA: 0x000A7178 File Offset: 0x000A5378
		public virtual bool IsSubsetOf(DirectoryString operand, bool ignoreCase)
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

		// Token: 0x040011E0 RID: 4576
		private bool m_checkForIllegalChars;

		// Token: 0x040011E1 RID: 4577
		private new static char[] m_separators = new char[]
		{
			'/'
		};

		// Token: 0x040011E2 RID: 4578
		protected static char[] m_illegalDirectoryCharacters = new char[]
		{
			'\\',
			':',
			'*',
			'?',
			'"',
			'<',
			'>',
			'|'
		};
	}
}
