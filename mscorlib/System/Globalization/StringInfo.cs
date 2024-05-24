using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	// Token: 0x020003D0 RID: 976
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class StringInfo
	{
		// Token: 0x06003164 RID: 12644 RVA: 0x000BDB66 File Offset: 0x000BBD66
		[__DynamicallyInvokable]
		public StringInfo() : this("")
		{
		}

		// Token: 0x06003165 RID: 12645 RVA: 0x000BDB73 File Offset: 0x000BBD73
		[__DynamicallyInvokable]
		public StringInfo(string value)
		{
			this.String = value;
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x000BDB82 File Offset: 0x000BBD82
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.m_str = string.Empty;
		}

		// Token: 0x06003167 RID: 12647 RVA: 0x000BDB8F File Offset: 0x000BBD8F
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			if (this.m_str.Length == 0)
			{
				this.m_indexes = null;
			}
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x000BDBA8 File Offset: 0x000BBDA8
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			StringInfo stringInfo = value as StringInfo;
			return stringInfo != null && this.m_str.Equals(stringInfo.m_str);
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x000BDBD2 File Offset: 0x000BBDD2
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_str.GetHashCode();
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x0600316A RID: 12650 RVA: 0x000BDBDF File Offset: 0x000BBDDF
		private int[] Indexes
		{
			get
			{
				if (this.m_indexes == null && 0 < this.String.Length)
				{
					this.m_indexes = StringInfo.ParseCombiningCharacters(this.String);
				}
				return this.m_indexes;
			}
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x0600316B RID: 12651 RVA: 0x000BDC0E File Offset: 0x000BBE0E
		// (set) Token: 0x0600316C RID: 12652 RVA: 0x000BDC16 File Offset: 0x000BBE16
		[__DynamicallyInvokable]
		public string String
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_str;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("String", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.m_str = value;
				this.m_indexes = null;
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x0600316D RID: 12653 RVA: 0x000BDC3E File Offset: 0x000BBE3E
		[__DynamicallyInvokable]
		public int LengthInTextElements
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.Indexes == null)
				{
					return 0;
				}
				return this.Indexes.Length;
			}
		}

		// Token: 0x0600316E RID: 12654 RVA: 0x000BDC54 File Offset: 0x000BBE54
		public string SubstringByTextElements(int startingTextElement)
		{
			if (this.Indexes != null)
			{
				return this.SubstringByTextElements(startingTextElement, this.Indexes.Length - startingTextElement);
			}
			if (startingTextElement < 0)
			{
				throw new ArgumentOutOfRangeException("startingTextElement", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			throw new ArgumentOutOfRangeException("startingTextElement", Environment.GetResourceString("Arg_ArgumentOutOfRangeException"));
		}

		// Token: 0x0600316F RID: 12655 RVA: 0x000BDCA8 File Offset: 0x000BBEA8
		public string SubstringByTextElements(int startingTextElement, int lengthInTextElements)
		{
			if (startingTextElement < 0)
			{
				throw new ArgumentOutOfRangeException("startingTextElement", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			if (this.String.Length == 0 || startingTextElement >= this.Indexes.Length)
			{
				throw new ArgumentOutOfRangeException("startingTextElement", Environment.GetResourceString("Arg_ArgumentOutOfRangeException"));
			}
			if (lengthInTextElements < 0)
			{
				throw new ArgumentOutOfRangeException("lengthInTextElements", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			if (startingTextElement > this.Indexes.Length - lengthInTextElements)
			{
				throw new ArgumentOutOfRangeException("lengthInTextElements", Environment.GetResourceString("Arg_ArgumentOutOfRangeException"));
			}
			int num = this.Indexes[startingTextElement];
			if (startingTextElement + lengthInTextElements == this.Indexes.Length)
			{
				return this.String.Substring(num);
			}
			return this.String.Substring(num, this.Indexes[lengthInTextElements + startingTextElement] - num);
		}

		// Token: 0x06003170 RID: 12656 RVA: 0x000BDD71 File Offset: 0x000BBF71
		[__DynamicallyInvokable]
		public static string GetNextTextElement(string str)
		{
			return StringInfo.GetNextTextElement(str, 0);
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x000BDD7C File Offset: 0x000BBF7C
		internal static int GetCurrentTextElementLen(string str, int index, int len, ref UnicodeCategory ucCurrent, ref int currentCharCount)
		{
			if (index + currentCharCount == len)
			{
				return currentCharCount;
			}
			int num;
			UnicodeCategory unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, index + currentCharCount, out num);
			if (CharUnicodeInfo.IsCombiningCategory(unicodeCategory) && !CharUnicodeInfo.IsCombiningCategory(ucCurrent) && ucCurrent != UnicodeCategory.Format && ucCurrent != UnicodeCategory.Control && ucCurrent != UnicodeCategory.OtherNotAssigned && ucCurrent != UnicodeCategory.Surrogate)
			{
				int num2 = index;
				for (index += currentCharCount + num; index < len; index += num)
				{
					unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, index, out num);
					if (!CharUnicodeInfo.IsCombiningCategory(unicodeCategory))
					{
						ucCurrent = unicodeCategory;
						currentCharCount = num;
						break;
					}
				}
				return index - num2;
			}
			int result = currentCharCount;
			ucCurrent = unicodeCategory;
			currentCharCount = num;
			return result;
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x000BDE10 File Offset: 0x000BC010
		[__DynamicallyInvokable]
		public static string GetNextTextElement(string str, int index)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			int length = str.Length;
			if (index >= 0 && index < length)
			{
				int num;
				UnicodeCategory unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, index, out num);
				return str.Substring(index, StringInfo.GetCurrentTextElementLen(str, index, length, ref unicodeCategory, ref num));
			}
			if (index == length)
			{
				return string.Empty;
			}
			throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
		}

		// Token: 0x06003173 RID: 12659 RVA: 0x000BDE76 File Offset: 0x000BC076
		[__DynamicallyInvokable]
		public static TextElementEnumerator GetTextElementEnumerator(string str)
		{
			return StringInfo.GetTextElementEnumerator(str, 0);
		}

		// Token: 0x06003174 RID: 12660 RVA: 0x000BDE80 File Offset: 0x000BC080
		[__DynamicallyInvokable]
		public static TextElementEnumerator GetTextElementEnumerator(string str, int index)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			int length = str.Length;
			if (index < 0 || index > length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return new TextElementEnumerator(str, index, length);
		}

		// Token: 0x06003175 RID: 12661 RVA: 0x000BDEC8 File Offset: 0x000BC0C8
		[__DynamicallyInvokable]
		public static int[] ParseCombiningCharacters(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			int length = str.Length;
			int[] array = new int[length];
			if (length == 0)
			{
				return array;
			}
			int num = 0;
			int i = 0;
			int num2;
			UnicodeCategory unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, 0, out num2);
			while (i < length)
			{
				array[num++] = i;
				i += StringInfo.GetCurrentTextElementLen(str, i, length, ref unicodeCategory, ref num2);
			}
			if (num < length)
			{
				int[] array2 = new int[num];
				Array.Copy(array, array2, num);
				return array2;
			}
			return array;
		}

		// Token: 0x04001517 RID: 5399
		[OptionalField(VersionAdded = 2)]
		private string m_str;

		// Token: 0x04001518 RID: 5400
		[NonSerialized]
		private int[] m_indexes;
	}
}
