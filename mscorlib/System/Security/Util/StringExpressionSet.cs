using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Security.Util
{
	// Token: 0x0200037C RID: 892
	[Serializable]
	internal class StringExpressionSet
	{
		// Token: 0x06002C3A RID: 11322 RVA: 0x000A4B30 File Offset: 0x000A2D30
		public StringExpressionSet() : this(true, null, false)
		{
		}

		// Token: 0x06002C3B RID: 11323 RVA: 0x000A4B3B File Offset: 0x000A2D3B
		public StringExpressionSet(string str) : this(true, str, false)
		{
		}

		// Token: 0x06002C3C RID: 11324 RVA: 0x000A4B46 File Offset: 0x000A2D46
		public StringExpressionSet(bool ignoreCase, bool throwOnRelative) : this(ignoreCase, null, throwOnRelative)
		{
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x000A4B51 File Offset: 0x000A2D51
		[SecuritySafeCritical]
		public StringExpressionSet(bool ignoreCase, string str, bool throwOnRelative)
		{
			this.m_list = null;
			this.m_ignoreCase = ignoreCase;
			this.m_throwOnRelative = throwOnRelative;
			if (str == null)
			{
				this.m_expressions = null;
				return;
			}
			this.AddExpressions(str);
		}

		// Token: 0x06002C3E RID: 11326 RVA: 0x000A4B80 File Offset: 0x000A2D80
		protected virtual StringExpressionSet CreateNewEmpty()
		{
			return new StringExpressionSet();
		}

		// Token: 0x06002C3F RID: 11327 RVA: 0x000A4B88 File Offset: 0x000A2D88
		[SecuritySafeCritical]
		public virtual StringExpressionSet Copy()
		{
			StringExpressionSet stringExpressionSet = this.CreateNewEmpty();
			if (this.m_list != null)
			{
				stringExpressionSet.m_list = new ArrayList(this.m_list);
			}
			stringExpressionSet.m_expressions = this.m_expressions;
			stringExpressionSet.m_ignoreCase = this.m_ignoreCase;
			stringExpressionSet.m_throwOnRelative = this.m_throwOnRelative;
			return stringExpressionSet;
		}

		// Token: 0x06002C40 RID: 11328 RVA: 0x000A4BDA File Offset: 0x000A2DDA
		public void SetThrowOnRelative(bool throwOnRelative)
		{
			this.m_throwOnRelative = throwOnRelative;
		}

		// Token: 0x06002C41 RID: 11329 RVA: 0x000A4BE3 File Offset: 0x000A2DE3
		private static string StaticProcessWholeString(string str)
		{
			return str.Replace(StringExpressionSet.m_alternateDirectorySeparator, StringExpressionSet.m_directorySeparator);
		}

		// Token: 0x06002C42 RID: 11330 RVA: 0x000A4BF5 File Offset: 0x000A2DF5
		private static string StaticProcessSingleString(string str)
		{
			return str.Trim(StringExpressionSet.m_trimChars);
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x000A4C02 File Offset: 0x000A2E02
		protected virtual string ProcessWholeString(string str)
		{
			return StringExpressionSet.StaticProcessWholeString(str);
		}

		// Token: 0x06002C44 RID: 11332 RVA: 0x000A4C0A File Offset: 0x000A2E0A
		protected virtual string ProcessSingleString(string str)
		{
			return StringExpressionSet.StaticProcessSingleString(str);
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x000A4C14 File Offset: 0x000A2E14
		[SecurityCritical]
		public void AddExpressions(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (str.Length == 0)
			{
				return;
			}
			str = this.ProcessWholeString(str);
			if (this.m_expressions == null)
			{
				this.m_expressions = str;
			}
			else
			{
				this.m_expressions = this.m_expressions + StringExpressionSet.m_separators[0].ToString() + str;
			}
			this.m_expressionsArray = null;
			string[] array = this.Split(str);
			if (this.m_list == null)
			{
				this.m_list = new ArrayList();
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && !array[i].Equals(""))
				{
					string text = this.ProcessSingleString(array[i]);
					int num = text.IndexOf('\0');
					if (num != -1)
					{
						text = text.Substring(0, num);
					}
					if (text != null && !text.Equals(""))
					{
						if (this.m_throwOnRelative)
						{
							if (Path.IsRelative(text))
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_AbsolutePathRequired"));
							}
							text = StringExpressionSet.CanonicalizePath(text);
						}
						this.m_list.Add(text);
					}
				}
			}
			this.Reduce();
		}

		// Token: 0x06002C46 RID: 11334 RVA: 0x000A4D24 File Offset: 0x000A2F24
		[SecurityCritical]
		public void AddExpressions(string[] str, bool checkForDuplicates, bool needFullPath)
		{
			this.AddExpressions(StringExpressionSet.CreateListFromExpressions(str, needFullPath), checkForDuplicates);
		}

		// Token: 0x06002C47 RID: 11335 RVA: 0x000A4D34 File Offset: 0x000A2F34
		[SecurityCritical]
		public void AddExpressions(ArrayList exprArrayList, bool checkForDuplicates)
		{
			this.m_expressionsArray = null;
			this.m_expressions = null;
			if (this.m_list != null)
			{
				this.m_list.AddRange(exprArrayList);
			}
			else
			{
				this.m_list = new ArrayList(exprArrayList);
			}
			if (checkForDuplicates)
			{
				this.Reduce();
			}
		}

		// Token: 0x06002C48 RID: 11336 RVA: 0x000A4D70 File Offset: 0x000A2F70
		[SecurityCritical]
		internal static ArrayList CreateListFromExpressions(string[] str, bool needFullPath)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == null)
				{
					throw new ArgumentNullException("str");
				}
				string text = StringExpressionSet.StaticProcessWholeString(str[i]);
				if (text != null && text.Length != 0)
				{
					string text2 = StringExpressionSet.StaticProcessSingleString(text);
					int num = text2.IndexOf('\0');
					if (num != -1)
					{
						text2 = text2.Substring(0, num);
					}
					if (text2 != null && text2.Length != 0)
					{
						if (PathInternal.IsPartiallyQualified(text2))
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_AbsolutePathRequired"));
						}
						text2 = StringExpressionSet.CanonicalizePath(text2, needFullPath);
						arrayList.Add(text2);
					}
				}
			}
			return arrayList;
		}

		// Token: 0x06002C49 RID: 11337 RVA: 0x000A4E16 File Offset: 0x000A3016
		[SecurityCritical]
		protected void CheckList()
		{
			if (this.m_list == null && this.m_expressions != null)
			{
				this.CreateList();
			}
		}

		// Token: 0x06002C4A RID: 11338 RVA: 0x000A4E30 File Offset: 0x000A3030
		protected string[] Split(string expressions)
		{
			if (this.m_throwOnRelative)
			{
				List<string> list = new List<string>();
				string[] array = expressions.Split(new char[]
				{
					'"'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (i % 2 == 0)
					{
						string[] array2 = array[i].Split(new char[]
						{
							';'
						});
						for (int j = 0; j < array2.Length; j++)
						{
							if (array2[j] != null && !array2[j].Equals(""))
							{
								list.Add(array2[j]);
							}
						}
					}
					else
					{
						list.Add(array[i]);
					}
				}
				string[] array3 = new string[list.Count];
				IEnumerator enumerator = list.GetEnumerator();
				int num = 0;
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					array3[num++] = (string)obj;
				}
				return array3;
			}
			return expressions.Split(StringExpressionSet.m_separators);
		}

		// Token: 0x06002C4B RID: 11339 RVA: 0x000A4F18 File Offset: 0x000A3118
		[SecurityCritical]
		protected void CreateList()
		{
			string[] array = this.Split(this.m_expressions);
			this.m_list = new ArrayList();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && !array[i].Equals(""))
				{
					string text = this.ProcessSingleString(array[i]);
					int num = text.IndexOf('\0');
					if (num != -1)
					{
						text = text.Substring(0, num);
					}
					if (text != null && !text.Equals(""))
					{
						if (this.m_throwOnRelative)
						{
							if (Path.IsRelative(text))
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_AbsolutePathRequired"));
							}
							text = StringExpressionSet.CanonicalizePath(text);
						}
						this.m_list.Add(text);
					}
				}
			}
		}

		// Token: 0x06002C4C RID: 11340 RVA: 0x000A4FC5 File Offset: 0x000A31C5
		[SecuritySafeCritical]
		public bool IsEmpty()
		{
			if (this.m_list == null)
			{
				return this.m_expressions == null;
			}
			return this.m_list.Count == 0;
		}

		// Token: 0x06002C4D RID: 11341 RVA: 0x000A4FE8 File Offset: 0x000A31E8
		[SecurityCritical]
		public bool IsSubsetOf(StringExpressionSet ses)
		{
			if (this.IsEmpty())
			{
				return true;
			}
			if (ses == null || ses.IsEmpty())
			{
				return false;
			}
			this.CheckList();
			ses.CheckList();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				if (!this.StringSubsetStringExpression((string)this.m_list[i], ses, this.m_ignoreCase))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002C4E RID: 11342 RVA: 0x000A5054 File Offset: 0x000A3254
		[SecurityCritical]
		public bool IsSubsetOfPathDiscovery(StringExpressionSet ses)
		{
			if (this.IsEmpty())
			{
				return true;
			}
			if (ses == null || ses.IsEmpty())
			{
				return false;
			}
			this.CheckList();
			ses.CheckList();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				if (!StringExpressionSet.StringSubsetStringExpressionPathDiscovery((string)this.m_list[i], ses, this.m_ignoreCase))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002C4F RID: 11343 RVA: 0x000A50BC File Offset: 0x000A32BC
		[SecurityCritical]
		public StringExpressionSet Union(StringExpressionSet ses)
		{
			if (ses == null || ses.IsEmpty())
			{
				return this.Copy();
			}
			if (this.IsEmpty())
			{
				return ses.Copy();
			}
			this.CheckList();
			ses.CheckList();
			StringExpressionSet stringExpressionSet = (ses.m_list.Count > this.m_list.Count) ? ses : this;
			StringExpressionSet stringExpressionSet2 = (ses.m_list.Count <= this.m_list.Count) ? ses : this;
			StringExpressionSet stringExpressionSet3 = stringExpressionSet.Copy();
			stringExpressionSet3.Reduce();
			for (int i = 0; i < stringExpressionSet2.m_list.Count; i++)
			{
				stringExpressionSet3.AddSingleExpressionNoDuplicates((string)stringExpressionSet2.m_list[i]);
			}
			stringExpressionSet3.GenerateString();
			return stringExpressionSet3;
		}

		// Token: 0x06002C50 RID: 11344 RVA: 0x000A5174 File Offset: 0x000A3374
		[SecurityCritical]
		public StringExpressionSet Intersect(StringExpressionSet ses)
		{
			if (this.IsEmpty() || ses == null || ses.IsEmpty())
			{
				return this.CreateNewEmpty();
			}
			this.CheckList();
			ses.CheckList();
			StringExpressionSet stringExpressionSet = this.CreateNewEmpty();
			for (int i = 0; i < this.m_list.Count; i++)
			{
				for (int j = 0; j < ses.m_list.Count; j++)
				{
					if (this.StringSubsetString((string)this.m_list[i], (string)ses.m_list[j], this.m_ignoreCase))
					{
						if (stringExpressionSet.m_list == null)
						{
							stringExpressionSet.m_list = new ArrayList();
						}
						stringExpressionSet.AddSingleExpressionNoDuplicates((string)this.m_list[i]);
					}
					else if (this.StringSubsetString((string)ses.m_list[j], (string)this.m_list[i], this.m_ignoreCase))
					{
						if (stringExpressionSet.m_list == null)
						{
							stringExpressionSet.m_list = new ArrayList();
						}
						stringExpressionSet.AddSingleExpressionNoDuplicates((string)ses.m_list[j]);
					}
				}
			}
			stringExpressionSet.GenerateString();
			return stringExpressionSet;
		}

		// Token: 0x06002C51 RID: 11345 RVA: 0x000A52A4 File Offset: 0x000A34A4
		[SecuritySafeCritical]
		protected void GenerateString()
		{
			if (this.m_list != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				IEnumerator enumerator = this.m_list.GetEnumerator();
				bool flag = true;
				while (enumerator.MoveNext())
				{
					if (!flag)
					{
						stringBuilder.Append(StringExpressionSet.m_separators[0]);
					}
					else
					{
						flag = false;
					}
					string text = (string)enumerator.Current;
					if (text != null)
					{
						int num = text.IndexOf(StringExpressionSet.m_separators[0]);
						if (num != -1)
						{
							stringBuilder.Append('"');
						}
						stringBuilder.Append(text);
						if (num != -1)
						{
							stringBuilder.Append('"');
						}
					}
				}
				this.m_expressions = stringBuilder.ToString();
				return;
			}
			this.m_expressions = null;
		}

		// Token: 0x06002C52 RID: 11346 RVA: 0x000A5345 File Offset: 0x000A3545
		[SecurityCritical]
		public string UnsafeToString()
		{
			this.CheckList();
			this.Reduce();
			this.GenerateString();
			return this.m_expressions;
		}

		// Token: 0x06002C53 RID: 11347 RVA: 0x000A535F File Offset: 0x000A355F
		[SecurityCritical]
		public string[] UnsafeToStringArray()
		{
			if (this.m_expressionsArray == null && this.m_list != null)
			{
				this.m_expressionsArray = (string[])this.m_list.ToArray(typeof(string));
			}
			return this.m_expressionsArray;
		}

		// Token: 0x06002C54 RID: 11348 RVA: 0x000A5398 File Offset: 0x000A3598
		[SecurityCritical]
		private bool StringSubsetStringExpression(string left, StringExpressionSet right, bool ignoreCase)
		{
			for (int i = 0; i < right.m_list.Count; i++)
			{
				if (this.StringSubsetString(left, (string)right.m_list[i], ignoreCase))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002C55 RID: 11349 RVA: 0x000A53DC File Offset: 0x000A35DC
		[SecurityCritical]
		private static bool StringSubsetStringExpressionPathDiscovery(string left, StringExpressionSet right, bool ignoreCase)
		{
			for (int i = 0; i < right.m_list.Count; i++)
			{
				if (StringExpressionSet.StringSubsetStringPathDiscovery(left, (string)right.m_list[i], ignoreCase))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002C56 RID: 11350 RVA: 0x000A541C File Offset: 0x000A361C
		protected virtual bool StringSubsetString(string left, string right, bool ignoreCase)
		{
			StringComparison comparisonType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
			if (right == null || left == null || right.Length == 0 || left.Length == 0 || right.Length > left.Length)
			{
				return false;
			}
			if (right.Length == left.Length)
			{
				return string.Compare(right, left, comparisonType) == 0;
			}
			if (left.Length - right.Length == 1 && left[left.Length - 1] == StringExpressionSet.m_directorySeparator)
			{
				return string.Compare(left, 0, right, 0, right.Length, comparisonType) == 0;
			}
			if (right[right.Length - 1] == StringExpressionSet.m_directorySeparator)
			{
				return string.Compare(right, 0, left, 0, right.Length, comparisonType) == 0;
			}
			return left[right.Length] == StringExpressionSet.m_directorySeparator && string.Compare(right, 0, left, 0, right.Length, comparisonType) == 0;
		}

		// Token: 0x06002C57 RID: 11351 RVA: 0x000A54FC File Offset: 0x000A36FC
		protected static bool StringSubsetStringPathDiscovery(string left, string right, bool ignoreCase)
		{
			StringComparison comparisonType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
			if (right == null || left == null || right.Length == 0 || left.Length == 0)
			{
				return false;
			}
			if (right.Length == left.Length)
			{
				return string.Compare(right, left, comparisonType) == 0;
			}
			string text;
			string text2;
			if (right.Length < left.Length)
			{
				text = right;
				text2 = left;
			}
			else
			{
				text = left;
				text2 = right;
			}
			return string.Compare(text, 0, text2, 0, text.Length, comparisonType) == 0 && ((text.Length == 3 && text.EndsWith(":\\", StringComparison.Ordinal) && ((text[0] >= 'A' && text[0] <= 'Z') || (text[0] >= 'a' && text[0] <= 'z'))) || text2[text.Length] == StringExpressionSet.m_directorySeparator);
		}

		// Token: 0x06002C58 RID: 11352 RVA: 0x000A55C8 File Offset: 0x000A37C8
		[SecuritySafeCritical]
		protected void AddSingleExpressionNoDuplicates(string expression)
		{
			int i = 0;
			this.m_expressionsArray = null;
			this.m_expressions = null;
			if (this.m_list == null)
			{
				this.m_list = new ArrayList();
			}
			while (i < this.m_list.Count)
			{
				if (this.StringSubsetString((string)this.m_list[i], expression, this.m_ignoreCase))
				{
					this.m_list.RemoveAt(i);
				}
				else
				{
					if (this.StringSubsetString(expression, (string)this.m_list[i], this.m_ignoreCase))
					{
						return;
					}
					i++;
				}
			}
			this.m_list.Add(expression);
		}

		// Token: 0x06002C59 RID: 11353 RVA: 0x000A5668 File Offset: 0x000A3868
		[SecurityCritical]
		protected void Reduce()
		{
			this.CheckList();
			if (this.m_list == null)
			{
				return;
			}
			for (int i = 0; i < this.m_list.Count - 1; i++)
			{
				int j = i + 1;
				while (j < this.m_list.Count)
				{
					if (this.StringSubsetString((string)this.m_list[j], (string)this.m_list[i], this.m_ignoreCase))
					{
						this.m_list.RemoveAt(j);
					}
					else if (this.StringSubsetString((string)this.m_list[i], (string)this.m_list[j], this.m_ignoreCase))
					{
						this.m_list[i] = this.m_list[j];
						this.m_list.RemoveAt(j);
						j = i + 1;
					}
					else
					{
						j++;
					}
				}
			}
		}

		// Token: 0x06002C5A RID: 11354
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void GetLongPathName(string path, StringHandleOnStack retLongPath);

		// Token: 0x06002C5B RID: 11355 RVA: 0x000A5758 File Offset: 0x000A3958
		[SecurityCritical]
		internal static string CanonicalizePath(string path)
		{
			return StringExpressionSet.CanonicalizePath(path, true);
		}

		// Token: 0x06002C5C RID: 11356 RVA: 0x000A5764 File Offset: 0x000A3964
		[SecurityCritical]
		internal static string CanonicalizePath(string path, bool needFullPath)
		{
			if (needFullPath)
			{
				string text = Path.GetFullPathInternal(path);
				if (path.EndsWith(StringExpressionSet.m_directorySeparator.ToString() + ".", StringComparison.Ordinal))
				{
					if (text.EndsWith(StringExpressionSet.m_directorySeparator))
					{
						text += ".";
					}
					else
					{
						text = text + StringExpressionSet.m_directorySeparator.ToString() + ".";
					}
				}
				path = text;
			}
			else if (path.IndexOf('~') != -1)
			{
				string text2 = null;
				StringExpressionSet.GetLongPathName(path, JitHelpers.GetStringHandleOnStack(ref text2));
				path = ((text2 != null) ? text2 : path);
			}
			if (path.IndexOf(':', 2) != -1)
			{
				throw new NotSupportedException(Environment.GetResourceString("Argument_PathFormatNotSupported"));
			}
			return path;
		}

		// Token: 0x040011C1 RID: 4545
		[SecurityCritical]
		protected ArrayList m_list;

		// Token: 0x040011C2 RID: 4546
		protected bool m_ignoreCase;

		// Token: 0x040011C3 RID: 4547
		[SecurityCritical]
		protected string m_expressions;

		// Token: 0x040011C4 RID: 4548
		[SecurityCritical]
		protected string[] m_expressionsArray;

		// Token: 0x040011C5 RID: 4549
		protected bool m_throwOnRelative;

		// Token: 0x040011C6 RID: 4550
		protected static readonly char[] m_separators = new char[]
		{
			';'
		};

		// Token: 0x040011C7 RID: 4551
		protected static readonly char[] m_trimChars = new char[]
		{
			' '
		};

		// Token: 0x040011C8 RID: 4552
		protected static readonly char m_directorySeparator = '\\';

		// Token: 0x040011C9 RID: 4553
		protected static readonly char m_alternateDirectorySeparator = '/';
	}
}
