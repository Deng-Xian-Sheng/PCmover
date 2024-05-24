using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace System.Globalization
{
	// Token: 0x020003D3 RID: 979
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class TextInfo : ICloneable, IDeserializationCallback
	{
		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x0600319B RID: 12699 RVA: 0x000BE3F5 File Offset: 0x000BC5F5
		internal static TextInfo Invariant
		{
			get
			{
				if (TextInfo.s_Invariant == null)
				{
					TextInfo.s_Invariant = new TextInfo(CultureData.Invariant);
				}
				return TextInfo.s_Invariant;
			}
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x000BE418 File Offset: 0x000BC618
		internal TextInfo(CultureData cultureData)
		{
			this.m_cultureData = cultureData;
			this.m_cultureName = this.m_cultureData.CultureName;
			this.m_textInfoName = this.m_cultureData.STEXTINFO;
			IntPtr handleOrigin;
			this.m_dataHandle = CompareInfo.InternalInitSortHandle(this.m_textInfoName, out handleOrigin);
			this.m_handleOrigin = handleOrigin;
		}

		// Token: 0x0600319D RID: 12701 RVA: 0x000BE46E File Offset: 0x000BC66E
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.m_cultureData = null;
			this.m_cultureName = null;
		}

		// Token: 0x0600319E RID: 12702 RVA: 0x000BE480 File Offset: 0x000BC680
		private void OnDeserialized()
		{
			if (this.m_cultureData == null)
			{
				if (this.m_cultureName == null)
				{
					if (this.customCultureName != null)
					{
						this.m_cultureName = this.customCultureName;
					}
					else if (this.m_win32LangID == 0)
					{
						this.m_cultureName = "ar-SA";
					}
					else
					{
						this.m_cultureName = CultureInfo.GetCultureInfo(this.m_win32LangID).m_cultureData.CultureName;
					}
				}
				this.m_cultureData = CultureInfo.GetCultureInfo(this.m_cultureName).m_cultureData;
				this.m_textInfoName = this.m_cultureData.STEXTINFO;
				IntPtr handleOrigin;
				this.m_dataHandle = CompareInfo.InternalInitSortHandle(this.m_textInfoName, out handleOrigin);
				this.m_handleOrigin = handleOrigin;
			}
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x000BE527 File Offset: 0x000BC727
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			this.OnDeserialized();
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x000BE52F File Offset: 0x000BC72F
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			this.m_useUserOverride = false;
			this.customCultureName = this.m_cultureName;
			this.m_win32LangID = CultureInfo.GetCultureInfo(this.m_cultureName).LCID;
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x000BE55A File Offset: 0x000BC75A
		internal static int GetHashCodeOrdinalIgnoreCase(string s)
		{
			return TextInfo.GetHashCodeOrdinalIgnoreCase(s, false, 0L);
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x000BE565 File Offset: 0x000BC765
		internal static int GetHashCodeOrdinalIgnoreCase(string s, bool forceRandomizedHashing, long additionalEntropy)
		{
			return TextInfo.Invariant.GetCaseInsensitiveHashCode(s, forceRandomizedHashing, additionalEntropy);
		}

		// Token: 0x060031A3 RID: 12707 RVA: 0x000BE574 File Offset: 0x000BC774
		[SecuritySafeCritical]
		internal static bool TryFastFindStringOrdinalIgnoreCase(int searchFlags, string source, int startIndex, string value, int count, ref int foundIndex)
		{
			return TextInfo.InternalTryFindStringOrdinalIgnoreCase(searchFlags, source, count, startIndex, value, value.Length, ref foundIndex);
		}

		// Token: 0x060031A4 RID: 12708 RVA: 0x000BE589 File Offset: 0x000BC789
		[SecuritySafeCritical]
		internal static int CompareOrdinalIgnoreCase(string str1, string str2)
		{
			return TextInfo.InternalCompareStringOrdinalIgnoreCase(str1, 0, str2, 0, str1.Length, str2.Length);
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x000BE5A0 File Offset: 0x000BC7A0
		[SecuritySafeCritical]
		internal static int CompareOrdinalIgnoreCaseEx(string strA, int indexA, string strB, int indexB, int lengthA, int lengthB)
		{
			return TextInfo.InternalCompareStringOrdinalIgnoreCase(strA, indexA, strB, indexB, lengthA, lengthB);
		}

		// Token: 0x060031A6 RID: 12710 RVA: 0x000BE5B0 File Offset: 0x000BC7B0
		internal static int IndexOfStringOrdinalIgnoreCase(string source, string value, int startIndex, int count)
		{
			if (source.Length == 0 && value.Length == 0)
			{
				return 0;
			}
			int result = -1;
			if (TextInfo.TryFastFindStringOrdinalIgnoreCase(4194304, source, startIndex, value, count, ref result))
			{
				return result;
			}
			int num = startIndex + count;
			int num2 = num - value.Length;
			while (startIndex <= num2)
			{
				if (TextInfo.CompareOrdinalIgnoreCaseEx(source, startIndex, value, 0, value.Length, value.Length) == 0)
				{
					return startIndex;
				}
				startIndex++;
			}
			return -1;
		}

		// Token: 0x060031A7 RID: 12711 RVA: 0x000BE618 File Offset: 0x000BC818
		internal static int LastIndexOfStringOrdinalIgnoreCase(string source, string value, int startIndex, int count)
		{
			if (value.Length == 0)
			{
				return startIndex;
			}
			int result = -1;
			if (TextInfo.TryFastFindStringOrdinalIgnoreCase(8388608, source, startIndex, value, count, ref result))
			{
				return result;
			}
			int num = startIndex - count + 1;
			if (value.Length > 0)
			{
				startIndex -= value.Length - 1;
			}
			while (startIndex >= num)
			{
				if (TextInfo.CompareOrdinalIgnoreCaseEx(source, startIndex, value, 0, value.Length, value.Length) == 0)
				{
					return startIndex;
				}
				startIndex--;
			}
			return -1;
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x060031A8 RID: 12712 RVA: 0x000BE685 File Offset: 0x000BC885
		public virtual int ANSICodePage
		{
			get
			{
				return this.m_cultureData.IDEFAULTANSICODEPAGE;
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x060031A9 RID: 12713 RVA: 0x000BE692 File Offset: 0x000BC892
		public virtual int OEMCodePage
		{
			get
			{
				return this.m_cultureData.IDEFAULTOEMCODEPAGE;
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x060031AA RID: 12714 RVA: 0x000BE69F File Offset: 0x000BC89F
		public virtual int MacCodePage
		{
			get
			{
				return this.m_cultureData.IDEFAULTMACCODEPAGE;
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x060031AB RID: 12715 RVA: 0x000BE6AC File Offset: 0x000BC8AC
		public virtual int EBCDICCodePage
		{
			get
			{
				return this.m_cultureData.IDEFAULTEBCDICCODEPAGE;
			}
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x060031AC RID: 12716 RVA: 0x000BE6B9 File Offset: 0x000BC8B9
		[ComVisible(false)]
		public int LCID
		{
			get
			{
				return CultureInfo.GetCultureInfo(this.m_textInfoName).LCID;
			}
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x060031AD RID: 12717 RVA: 0x000BE6CB File Offset: 0x000BC8CB
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public string CultureName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_textInfoName;
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x060031AE RID: 12718 RVA: 0x000BE6D3 File Offset: 0x000BC8D3
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public bool IsReadOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_isReadOnly;
			}
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x000BE6DC File Offset: 0x000BC8DC
		[ComVisible(false)]
		public virtual object Clone()
		{
			object obj = base.MemberwiseClone();
			((TextInfo)obj).SetReadOnlyState(false);
			return obj;
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x000BE700 File Offset: 0x000BC900
		[ComVisible(false)]
		public static TextInfo ReadOnly(TextInfo textInfo)
		{
			if (textInfo == null)
			{
				throw new ArgumentNullException("textInfo");
			}
			if (textInfo.IsReadOnly)
			{
				return textInfo;
			}
			TextInfo textInfo2 = (TextInfo)textInfo.MemberwiseClone();
			textInfo2.SetReadOnlyState(true);
			return textInfo2;
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x000BE739 File Offset: 0x000BC939
		private void VerifyWritable()
		{
			if (this.m_isReadOnly)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
			}
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x000BE753 File Offset: 0x000BC953
		internal void SetReadOnlyState(bool readOnly)
		{
			this.m_isReadOnly = readOnly;
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x060031B3 RID: 12723 RVA: 0x000BE75C File Offset: 0x000BC95C
		// (set) Token: 0x060031B4 RID: 12724 RVA: 0x000BE77D File Offset: 0x000BC97D
		[__DynamicallyInvokable]
		public virtual string ListSeparator
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				if (this.m_listSeparator == null)
				{
					this.m_listSeparator = this.m_cultureData.SLIST;
				}
				return this.m_listSeparator;
			}
			[ComVisible(false)]
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value", Environment.GetResourceString("ArgumentNull_String"));
				}
				this.VerifyWritable();
				this.m_listSeparator = value;
			}
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x000BE7A4 File Offset: 0x000BC9A4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual char ToLower(char c)
		{
			if (TextInfo.IsAscii(c) && this.IsAsciiCasingSameAsInvariant)
			{
				return TextInfo.ToLowerAsciiInvariant(c);
			}
			return TextInfo.InternalChangeCaseChar(this.m_dataHandle, this.m_handleOrigin, this.m_textInfoName, c, false);
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x000BE7D6 File Offset: 0x000BC9D6
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual string ToLower(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return TextInfo.InternalChangeCaseString(this.m_dataHandle, this.m_handleOrigin, this.m_textInfoName, str, false);
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x000BE7FF File Offset: 0x000BC9FF
		private static char ToLowerAsciiInvariant(char c)
		{
			if ('A' <= c && c <= 'Z')
			{
				c |= ' ';
			}
			return c;
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x000BE813 File Offset: 0x000BCA13
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual char ToUpper(char c)
		{
			if (TextInfo.IsAscii(c) && this.IsAsciiCasingSameAsInvariant)
			{
				return TextInfo.ToUpperAsciiInvariant(c);
			}
			return TextInfo.InternalChangeCaseChar(this.m_dataHandle, this.m_handleOrigin, this.m_textInfoName, c, true);
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x000BE845 File Offset: 0x000BCA45
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual string ToUpper(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return TextInfo.InternalChangeCaseString(this.m_dataHandle, this.m_handleOrigin, this.m_textInfoName, str, true);
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x000BE86E File Offset: 0x000BCA6E
		private static char ToUpperAsciiInvariant(char c)
		{
			if ('a' <= c && c <= 'z')
			{
				c = (char)((int)c & -33);
			}
			return c;
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x000BE882 File Offset: 0x000BCA82
		private static bool IsAscii(char c)
		{
			return c < '\u0080';
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x060031BC RID: 12732 RVA: 0x000BE88C File Offset: 0x000BCA8C
		private bool IsAsciiCasingSameAsInvariant
		{
			get
			{
				if (this.m_IsAsciiCasingSameAsInvariant == TextInfo.Tristate.NotInitialized)
				{
					this.m_IsAsciiCasingSameAsInvariant = ((CultureInfo.GetCultureInfo(this.m_textInfoName).CompareInfo.Compare("abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", CompareOptions.IgnoreCase) == 0) ? TextInfo.Tristate.True : TextInfo.Tristate.False);
				}
				return this.m_IsAsciiCasingSameAsInvariant == TextInfo.Tristate.True;
			}
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x000BE8CC File Offset: 0x000BCACC
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			TextInfo textInfo = obj as TextInfo;
			return textInfo != null && this.CultureName.Equals(textInfo.CultureName);
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x000BE8F6 File Offset: 0x000BCAF6
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.CultureName.GetHashCode();
		}

		// Token: 0x060031BF RID: 12735 RVA: 0x000BE903 File Offset: 0x000BCB03
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return "TextInfo - " + this.m_cultureData.CultureName;
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x000BE91C File Offset: 0x000BCB1C
		public string ToTitleCase(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			if (str.Length == 0)
			{
				return str;
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text = null;
			for (int i = 0; i < str.Length; i++)
			{
				int num;
				UnicodeCategory unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, i, out num);
				if (char.CheckLetter(unicodeCategory))
				{
					i = this.AddTitlecaseLetter(ref stringBuilder, ref str, i, num) + 1;
					int num2 = i;
					bool flag = unicodeCategory == UnicodeCategory.LowercaseLetter;
					while (i < str.Length)
					{
						unicodeCategory = CharUnicodeInfo.InternalGetUnicodeCategory(str, i, out num);
						if (TextInfo.IsLetterCategory(unicodeCategory))
						{
							if (unicodeCategory == UnicodeCategory.LowercaseLetter)
							{
								flag = true;
							}
							i += num;
						}
						else if (str[i] == '\'')
						{
							i++;
							if (flag)
							{
								if (text == null)
								{
									text = this.ToLower(str);
								}
								stringBuilder.Append(text, num2, i - num2);
							}
							else
							{
								stringBuilder.Append(str, num2, i - num2);
							}
							num2 = i;
							flag = true;
						}
						else
						{
							if (TextInfo.IsWordSeparator(unicodeCategory))
							{
								break;
							}
							i += num;
						}
					}
					int num3 = i - num2;
					if (num3 > 0)
					{
						if (flag)
						{
							if (text == null)
							{
								text = this.ToLower(str);
							}
							stringBuilder.Append(text, num2, num3);
						}
						else
						{
							stringBuilder.Append(str, num2, num3);
						}
					}
					if (i < str.Length)
					{
						i = TextInfo.AddNonLetter(ref stringBuilder, ref str, i, num);
					}
				}
				else
				{
					i = TextInfo.AddNonLetter(ref stringBuilder, ref str, i, num);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x000BEA69 File Offset: 0x000BCC69
		private static int AddNonLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen)
		{
			if (charLen == 2)
			{
				result.Append(input[inputIndex++]);
				result.Append(input[inputIndex]);
			}
			else
			{
				result.Append(input[inputIndex]);
			}
			return inputIndex;
		}

		// Token: 0x060031C2 RID: 12738 RVA: 0x000BEAA8 File Offset: 0x000BCCA8
		private int AddTitlecaseLetter(ref StringBuilder result, ref string input, int inputIndex, int charLen)
		{
			if (charLen == 2)
			{
				result.Append(this.ToUpper(input.Substring(inputIndex, charLen)));
				inputIndex++;
			}
			else
			{
				char c = input[inputIndex];
				switch (c)
				{
				case 'Ǆ':
				case 'ǅ':
				case 'ǆ':
					result.Append('ǅ');
					break;
				case 'Ǉ':
				case 'ǈ':
				case 'ǉ':
					result.Append('ǈ');
					break;
				case 'Ǌ':
				case 'ǋ':
				case 'ǌ':
					result.Append('ǋ');
					break;
				default:
					switch (c)
					{
					case 'Ǳ':
					case 'ǲ':
					case 'ǳ':
						result.Append('ǲ');
						break;
					default:
						result.Append(this.ToUpper(input[inputIndex]));
						break;
					}
					break;
				}
			}
			return inputIndex;
		}

		// Token: 0x060031C3 RID: 12739 RVA: 0x000BEB82 File Offset: 0x000BCD82
		private static bool IsWordSeparator(UnicodeCategory category)
		{
			return (536672256 & 1 << (int)category) != 0;
		}

		// Token: 0x060031C4 RID: 12740 RVA: 0x000BEB93 File Offset: 0x000BCD93
		private static bool IsLetterCategory(UnicodeCategory uc)
		{
			return uc == UnicodeCategory.UppercaseLetter || uc == UnicodeCategory.LowercaseLetter || uc == UnicodeCategory.TitlecaseLetter || uc == UnicodeCategory.ModifierLetter || uc == UnicodeCategory.OtherLetter;
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x060031C5 RID: 12741 RVA: 0x000BEBAA File Offset: 0x000BCDAA
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public bool IsRightToLeft
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.IsRightToLeft;
			}
		}

		// Token: 0x060031C6 RID: 12742 RVA: 0x000BEBB7 File Offset: 0x000BCDB7
		void IDeserializationCallback.OnDeserialization(object sender)
		{
			this.OnDeserialized();
		}

		// Token: 0x060031C7 RID: 12743 RVA: 0x000BEBBF File Offset: 0x000BCDBF
		[SecuritySafeCritical]
		internal int GetCaseInsensitiveHashCode(string str)
		{
			return this.GetCaseInsensitiveHashCode(str, false, 0L);
		}

		// Token: 0x060031C8 RID: 12744 RVA: 0x000BEBCB File Offset: 0x000BCDCB
		[SecuritySafeCritical]
		internal int GetCaseInsensitiveHashCode(string str, bool forceRandomizedHashing, long additionalEntropy)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str");
			}
			return TextInfo.InternalGetCaseInsHash(this.m_dataHandle, this.m_handleOrigin, this.m_textInfoName, str, forceRandomizedHashing, additionalEntropy);
		}

		// Token: 0x060031C9 RID: 12745
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern char InternalChangeCaseChar(IntPtr handle, IntPtr handleOrigin, string localeName, char ch, bool isToUpper);

		// Token: 0x060031CA RID: 12746
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string InternalChangeCaseString(IntPtr handle, IntPtr handleOrigin, string localeName, string str, bool isToUpper);

		// Token: 0x060031CB RID: 12747
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int InternalGetCaseInsHash(IntPtr handle, IntPtr handleOrigin, string localeName, string str, bool forceRandomizedHashing, long additionalEntropy);

		// Token: 0x060031CC RID: 12748
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int InternalCompareStringOrdinalIgnoreCase(string string1, int index1, string string2, int index2, int length1, int length2);

		// Token: 0x060031CD RID: 12749
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool InternalTryFindStringOrdinalIgnoreCase(int searchFlags, string source, int sourceCount, int startIndex, string target, int targetCount, ref int foundIndex);

		// Token: 0x04001527 RID: 5415
		[OptionalField(VersionAdded = 2)]
		private string m_listSeparator;

		// Token: 0x04001528 RID: 5416
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly;

		// Token: 0x04001529 RID: 5417
		[OptionalField(VersionAdded = 3)]
		private string m_cultureName;

		// Token: 0x0400152A RID: 5418
		[NonSerialized]
		private CultureData m_cultureData;

		// Token: 0x0400152B RID: 5419
		[NonSerialized]
		private string m_textInfoName;

		// Token: 0x0400152C RID: 5420
		[NonSerialized]
		private IntPtr m_dataHandle;

		// Token: 0x0400152D RID: 5421
		[NonSerialized]
		private IntPtr m_handleOrigin;

		// Token: 0x0400152E RID: 5422
		[NonSerialized]
		private TextInfo.Tristate m_IsAsciiCasingSameAsInvariant;

		// Token: 0x0400152F RID: 5423
		internal static volatile TextInfo s_Invariant;

		// Token: 0x04001530 RID: 5424
		[OptionalField(VersionAdded = 2)]
		private string customCultureName;

		// Token: 0x04001531 RID: 5425
		[OptionalField(VersionAdded = 1)]
		internal int m_nDataItem;

		// Token: 0x04001532 RID: 5426
		[OptionalField(VersionAdded = 1)]
		internal bool m_useUserOverride;

		// Token: 0x04001533 RID: 5427
		[OptionalField(VersionAdded = 1)]
		internal int m_win32LangID;

		// Token: 0x04001534 RID: 5428
		private const int wordSeparatorMask = 536672256;

		// Token: 0x02000B70 RID: 2928
		private enum Tristate : byte
		{
			// Token: 0x0400346E RID: 13422
			NotInitialized,
			// Token: 0x0400346F RID: 13423
			True,
			// Token: 0x04003470 RID: 13424
			False
		}
	}
}
