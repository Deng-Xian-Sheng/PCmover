using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003A5 RID: 933
	[__DynamicallyInvokable]
	public static class CharUnicodeInfo
	{
		// Token: 0x06002DE6 RID: 11750 RVA: 0x000AFB04 File Offset: 0x000ADD04
		[SecuritySafeCritical]
		private unsafe static bool InitTable()
		{
			byte* globalizationResourceBytePtr = GlobalizationAssembly.GetGlobalizationResourceBytePtr(typeof(CharUnicodeInfo).Assembly, "charinfo.nlp");
			CharUnicodeInfo.UnicodeDataHeader* ptr = (CharUnicodeInfo.UnicodeDataHeader*)globalizationResourceBytePtr;
			CharUnicodeInfo.s_pCategoryLevel1Index = (ushort*)(globalizationResourceBytePtr + ptr->OffsetToCategoriesIndex);
			CharUnicodeInfo.s_pCategoriesValue = globalizationResourceBytePtr + ptr->OffsetToCategoriesValue;
			CharUnicodeInfo.s_pNumericLevel1Index = (ushort*)(globalizationResourceBytePtr + ptr->OffsetToNumbericIndex);
			CharUnicodeInfo.s_pNumericValues = globalizationResourceBytePtr + ptr->OffsetToNumbericValue;
			CharUnicodeInfo.s_pDigitValues = (CharUnicodeInfo.DigitValues*)(globalizationResourceBytePtr + ptr->OffsetToDigitValue);
			return true;
		}

		// Token: 0x06002DE7 RID: 11751 RVA: 0x000AFB74 File Offset: 0x000ADD74
		internal static int InternalConvertToUtf32(string s, int index)
		{
			if (index < s.Length - 1)
			{
				int num = (int)(s[index] - '\ud800');
				if (num >= 0 && num <= 1023)
				{
					int num2 = (int)(s[index + 1] - '\udc00');
					if (num2 >= 0 && num2 <= 1023)
					{
						return num * 1024 + num2 + 65536;
					}
				}
			}
			return (int)s[index];
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x000AFBDC File Offset: 0x000ADDDC
		internal static int InternalConvertToUtf32(string s, int index, out int charLength)
		{
			charLength = 1;
			if (index < s.Length - 1)
			{
				int num = (int)(s[index] - '\ud800');
				if (num >= 0 && num <= 1023)
				{
					int num2 = (int)(s[index + 1] - '\udc00');
					if (num2 >= 0 && num2 <= 1023)
					{
						charLength++;
						return num * 1024 + num2 + 65536;
					}
				}
			}
			return (int)s[index];
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x000AFC4C File Offset: 0x000ADE4C
		internal static bool IsWhiteSpace(string s, int index)
		{
			UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(s, index);
			return unicodeCategory - UnicodeCategory.SpaceSeparator <= 2;
		}

		// Token: 0x06002DEA RID: 11754 RVA: 0x000AFC6C File Offset: 0x000ADE6C
		internal static bool IsWhiteSpace(char c)
		{
			UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			return unicodeCategory - UnicodeCategory.SpaceSeparator <= 2;
		}

		// Token: 0x06002DEB RID: 11755 RVA: 0x000AFC8C File Offset: 0x000ADE8C
		[SecuritySafeCritical]
		internal unsafe static double InternalGetNumericValue(int ch)
		{
			ushort num = CharUnicodeInfo.s_pNumericLevel1Index[ch >> 8];
			num = CharUnicodeInfo.s_pNumericLevel1Index[(int)num + (ch >> 4 & 15)];
			byte* ptr = (byte*)(CharUnicodeInfo.s_pNumericLevel1Index + num);
			byte* ptr2 = CharUnicodeInfo.s_pNumericValues + ptr[ch & 15] * 8;
			if (ptr2 % 8L != null)
			{
				double result;
				byte* dest = (byte*)(&result);
				Buffer.Memcpy(dest, ptr2, 8);
				return result;
			}
			return *(double*)(CharUnicodeInfo.s_pNumericValues + (IntPtr)ptr[ch & 15] * 8);
		}

		// Token: 0x06002DEC RID: 11756 RVA: 0x000AFD00 File Offset: 0x000ADF00
		[SecuritySafeCritical]
		internal unsafe static CharUnicodeInfo.DigitValues* InternalGetDigitValues(int ch)
		{
			ushort num = CharUnicodeInfo.s_pNumericLevel1Index[ch >> 8];
			num = CharUnicodeInfo.s_pNumericLevel1Index[(int)num + (ch >> 4 & 15)];
			byte* ptr = (byte*)(CharUnicodeInfo.s_pNumericLevel1Index + num);
			return CharUnicodeInfo.s_pDigitValues + ptr[ch & 15];
		}

		// Token: 0x06002DED RID: 11757 RVA: 0x000AFD50 File Offset: 0x000ADF50
		[SecuritySafeCritical]
		internal unsafe static sbyte InternalGetDecimalDigitValue(int ch)
		{
			return CharUnicodeInfo.InternalGetDigitValues(ch)->decimalDigit;
		}

		// Token: 0x06002DEE RID: 11758 RVA: 0x000AFD5D File Offset: 0x000ADF5D
		[SecuritySafeCritical]
		internal unsafe static sbyte InternalGetDigitValue(int ch)
		{
			return CharUnicodeInfo.InternalGetDigitValues(ch)->digit;
		}

		// Token: 0x06002DEF RID: 11759 RVA: 0x000AFD6A File Offset: 0x000ADF6A
		[__DynamicallyInvokable]
		public static double GetNumericValue(char ch)
		{
			return CharUnicodeInfo.InternalGetNumericValue((int)ch);
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x000AFD72 File Offset: 0x000ADF72
		[__DynamicallyInvokable]
		public static double GetNumericValue(string s, int index)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (index < 0 || index >= s.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return CharUnicodeInfo.InternalGetNumericValue(CharUnicodeInfo.InternalConvertToUtf32(s, index));
		}

		// Token: 0x06002DF1 RID: 11761 RVA: 0x000AFDB0 File Offset: 0x000ADFB0
		public static int GetDecimalDigitValue(char ch)
		{
			return (int)CharUnicodeInfo.InternalGetDecimalDigitValue((int)ch);
		}

		// Token: 0x06002DF2 RID: 11762 RVA: 0x000AFDB8 File Offset: 0x000ADFB8
		public static int GetDecimalDigitValue(string s, int index)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (index < 0 || index >= s.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return (int)CharUnicodeInfo.InternalGetDecimalDigitValue(CharUnicodeInfo.InternalConvertToUtf32(s, index));
		}

		// Token: 0x06002DF3 RID: 11763 RVA: 0x000AFDF6 File Offset: 0x000ADFF6
		public static int GetDigitValue(char ch)
		{
			return (int)CharUnicodeInfo.InternalGetDigitValue((int)ch);
		}

		// Token: 0x06002DF4 RID: 11764 RVA: 0x000AFDFE File Offset: 0x000ADFFE
		public static int GetDigitValue(string s, int index)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (index < 0 || index >= s.Length)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			return (int)CharUnicodeInfo.InternalGetDigitValue(CharUnicodeInfo.InternalConvertToUtf32(s, index));
		}

		// Token: 0x06002DF5 RID: 11765 RVA: 0x000AFE3C File Offset: 0x000AE03C
		[__DynamicallyInvokable]
		public static UnicodeCategory GetUnicodeCategory(char ch)
		{
			return CharUnicodeInfo.InternalGetUnicodeCategory((int)ch);
		}

		// Token: 0x06002DF6 RID: 11766 RVA: 0x000AFE44 File Offset: 0x000AE044
		[__DynamicallyInvokable]
		public static UnicodeCategory GetUnicodeCategory(string s, int index)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (index >= s.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return CharUnicodeInfo.InternalGetUnicodeCategory(s, index);
		}

		// Token: 0x06002DF7 RID: 11767 RVA: 0x000AFE6F File Offset: 0x000AE06F
		internal static UnicodeCategory InternalGetUnicodeCategory(int ch)
		{
			return (UnicodeCategory)CharUnicodeInfo.InternalGetCategoryValue(ch, 0);
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x000AFE78 File Offset: 0x000AE078
		[SecuritySafeCritical]
		internal unsafe static byte InternalGetCategoryValue(int ch, int offset)
		{
			ushort num = CharUnicodeInfo.s_pCategoryLevel1Index[ch >> 8];
			num = CharUnicodeInfo.s_pCategoryLevel1Index[(int)num + (ch >> 4 & 15)];
			byte* ptr = (byte*)(CharUnicodeInfo.s_pCategoryLevel1Index + num);
			byte b = ptr[ch & 15];
			return CharUnicodeInfo.s_pCategoriesValue[(int)(b * 2) + offset];
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x000AFEC8 File Offset: 0x000AE0C8
		internal static BidiCategory GetBidiCategory(string s, int index)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (index >= s.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return (BidiCategory)CharUnicodeInfo.InternalGetCategoryValue(CharUnicodeInfo.InternalConvertToUtf32(s, index), 1);
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x000AFEF9 File Offset: 0x000AE0F9
		internal static UnicodeCategory InternalGetUnicodeCategory(string value, int index)
		{
			return CharUnicodeInfo.InternalGetUnicodeCategory(CharUnicodeInfo.InternalConvertToUtf32(value, index));
		}

		// Token: 0x06002DFB RID: 11771 RVA: 0x000AFF07 File Offset: 0x000AE107
		internal static UnicodeCategory InternalGetUnicodeCategory(string str, int index, out int charLength)
		{
			return CharUnicodeInfo.InternalGetUnicodeCategory(CharUnicodeInfo.InternalConvertToUtf32(str, index, out charLength));
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x000AFF16 File Offset: 0x000AE116
		internal static bool IsCombiningCategory(UnicodeCategory uc)
		{
			return uc == UnicodeCategory.NonSpacingMark || uc == UnicodeCategory.SpacingCombiningMark || uc == UnicodeCategory.EnclosingMark;
		}

		// Token: 0x040012F8 RID: 4856
		internal const char HIGH_SURROGATE_START = '\ud800';

		// Token: 0x040012F9 RID: 4857
		internal const char HIGH_SURROGATE_END = '\udbff';

		// Token: 0x040012FA RID: 4858
		internal const char LOW_SURROGATE_START = '\udc00';

		// Token: 0x040012FB RID: 4859
		internal const char LOW_SURROGATE_END = '\udfff';

		// Token: 0x040012FC RID: 4860
		internal const int UNICODE_CATEGORY_OFFSET = 0;

		// Token: 0x040012FD RID: 4861
		internal const int BIDI_CATEGORY_OFFSET = 1;

		// Token: 0x040012FE RID: 4862
		private static bool s_initialized = CharUnicodeInfo.InitTable();

		// Token: 0x040012FF RID: 4863
		[SecurityCritical]
		private unsafe static ushort* s_pCategoryLevel1Index;

		// Token: 0x04001300 RID: 4864
		[SecurityCritical]
		private unsafe static byte* s_pCategoriesValue;

		// Token: 0x04001301 RID: 4865
		[SecurityCritical]
		private unsafe static ushort* s_pNumericLevel1Index;

		// Token: 0x04001302 RID: 4866
		[SecurityCritical]
		private unsafe static byte* s_pNumericValues;

		// Token: 0x04001303 RID: 4867
		[SecurityCritical]
		private unsafe static CharUnicodeInfo.DigitValues* s_pDigitValues;

		// Token: 0x04001304 RID: 4868
		internal const string UNICODE_INFO_FILE_NAME = "charinfo.nlp";

		// Token: 0x04001305 RID: 4869
		internal const int UNICODE_PLANE01_START = 65536;

		// Token: 0x02000B69 RID: 2921
		[StructLayout(LayoutKind.Explicit)]
		internal struct UnicodeDataHeader
		{
			// Token: 0x04003450 RID: 13392
			[FieldOffset(0)]
			internal char TableName;

			// Token: 0x04003451 RID: 13393
			[FieldOffset(32)]
			internal ushort version;

			// Token: 0x04003452 RID: 13394
			[FieldOffset(40)]
			internal uint OffsetToCategoriesIndex;

			// Token: 0x04003453 RID: 13395
			[FieldOffset(44)]
			internal uint OffsetToCategoriesValue;

			// Token: 0x04003454 RID: 13396
			[FieldOffset(48)]
			internal uint OffsetToNumbericIndex;

			// Token: 0x04003455 RID: 13397
			[FieldOffset(52)]
			internal uint OffsetToDigitValue;

			// Token: 0x04003456 RID: 13398
			[FieldOffset(56)]
			internal uint OffsetToNumbericValue;
		}

		// Token: 0x02000B6A RID: 2922
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		internal struct DigitValues
		{
			// Token: 0x04003457 RID: 13399
			internal sbyte decimalDigit;

			// Token: 0x04003458 RID: 13400
			internal sbyte digit;
		}
	}
}
